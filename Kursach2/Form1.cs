using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Media;
using System.Threading;

using System.Data.SqlClient;
using System.Data.Linq;
using System.ServiceModel;
using CommunicationInterface;
using MappingDLL;
using SearchClass;

namespace Kursach
{
    [ServiceContract]
    public interface IMyObject
    {
        [OperationContract] // Делегируемый метод.                            -Тут изменять при изменениии
        bool newCarFromGrid(string name, string mark, int year, int price, string url, string region);

        [OperationContract] // Делегируемый метод.                            -Тут изменять при изменениии
        bool newCarFromUser(string name, string mark, int year, int price, string info, string region, string url_photo);
        [OperationContract] // Делегируемый метод.                            -Тут изменять при изменениии
        bool newClient(string full_name, string email, string passport);
        [OperationContract] // Делегируемый метод.                            -Тут изменять при изменениии
        bool newOrder(int FK_id_client, int FK_id_car, DateTime data, int summ);
        [OperationContract]
        List<Client> getClients();
        [OperationContract]
        List<Car> getCars();
        [OperationContract]
        bool deleteClient(int id);
    }
    public partial class ParserForm : Form
    {
        /*
         * Variables
         */
        DateTime localOldestDate = new DateTime();
        PhotoForm picForm = new PhotoForm();
        public ParserForm()
        {
            InitializeComponent();
            
            DefaultLists defaultLists = new DefaultLists();//----Create a defaultList object

            Dictionary<string, string> brandList = defaultLists.brand();//------Default brands
            comboBoxBrand.DisplayMember = "Key";
            comboBoxBrand.ValueMember = "Value";
            comboBoxBrand.DataSource = new BindingSource(brandList, null);

            Dictionary<string, string> yearList = defaultLists.year();//------Default years
            comboBoxYear1.DisplayMember = "Key";
            comboBoxYear1.ValueMember = "Value";
            comboBoxYear1.DataSource = new BindingSource(yearList, null);
            comboBoxYear1.SelectedIndex = 1;

            comboBoxYear2.DisplayMember = "Key";
            comboBoxYear2.ValueMember = "Value";
            comboBoxYear2.DataSource = new BindingSource(yearList, null);

            Dictionary<string, string> regionList = defaultLists.region();//------Default regions
            comboBoxRegion.DisplayMember = "Key";
            comboBoxRegion.ValueMember = "Value";
            comboBoxRegion.DataSource = new BindingSource(regionList, null);
            comboBoxRegion.SelectedIndex = 75;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)//-----Search Button Click
        {
            groupBox1.Enabled = false;//can't make multiply search queries
            dataGridView.Visible = false;//dataGridView is being blocked
            checkBoxFollow.Visible = false;
            buttonExcel.Visible = false;

            int mark_id = 0;
            try
            {
                mark_id = Convert.ToInt32(comboBoxBrand.SelectedValue.ToString());
            }
            catch{}
            int year1 = Convert.ToInt32(comboBoxYear1.SelectedValue.ToString());
            int year2 = Convert.ToInt32(comboBoxYear2.SelectedValue.ToString());
            int region = 0;
            try
            {
                region = Convert.ToInt32(comboBoxRegion.SelectedValue.ToString());
            }
            catch{}

            SearchInfo asyncInfo = new SearchInfo();//made an object of Information for Async
            asyncInfo.setInfo(mark_id, year1, year2, region);

            backgroundWorkerSearch.RunWorkerAsync(asyncInfo);//sent information to backgroundWorker1_DoWork
            pictureBox1.Visible = true;//loading.gif
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void comboBoxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            Excel file = new Excel();
            string[][] toTable = new string[dataGridView.Rows.Count][];
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                toTable[i] = new string[dataGridView.ColumnCount];
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    try
                    {
                        toTable[i][j] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                    catch
                    {
                        toTable[i][j] = "";
                    }
                }
            }

            if (file.save(toTable, "file.xls"))
                MessageBox.Show("Успешно сохранено.\nФайл: file.xls");
            else
                MessageBox.Show("Не удалось сохранить");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFollow.Checked)
            {
                timer.Enabled = true;
                if (timer.Enabled)
                    MessageBox.Show("Слежение запущено");
            }
            else
            {
                timer.Enabled = false;
                if (!timer.Enabled)
                    MessageBox.Show("Слежение остановлено");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int mark_id = 0;
            try
            {
                mark_id = Convert.ToInt32(comboBoxBrand.SelectedValue.ToString());
            }
            catch { }
            int year1 = Convert.ToInt32(comboBoxYear1.SelectedValue.ToString());
            int year2 = Convert.ToInt32(comboBoxYear2.SelectedValue.ToString());
            int region = 0;
            try
            {
                region = Convert.ToInt32(comboBoxRegion.SelectedValue.ToString());
            }
            catch { }
            Search cars = new Search();//!!!!!!

            cars.oldestDate = localOldestDate;
            foreach (DateTime date in cars.datesList)
            {
                if (DateTime.Compare(cars.oldestDate, date) < 0)
                {
                    MessageBox.Show("Появилось новое объявление");
                    SoundPlayer simpleSound = new SoundPlayer(@"c:\beepbeep.wav");
                    simpleSound.Play();
                    localOldestDate = date;
                    cars.oldestDate = localOldestDate;
                }
            }
        }

        private void buttonSearch_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SearchInfo getInfo = (SearchInfo) e.Argument;//set fields
            Search cars = new Search();

            cars.mark_id = getInfo.mark_id;
            cars.region = getInfo.region;
            cars.year1 = getInfo.year1;
            cars.year2 = getInfo.year2;
            cars.query();//search cars

            SearchResult result = new SearchResult();//sending Results
            result.carsList = cars.carsList;
            result.linksList = cars.linksList;
            result.datesList = cars.datesList;
            result.photoList = cars.photoList;
            result.Enabled = cars.Enabled;

            //sender = result;
            e.Result = result;
        }

        private void backgroundWorkerSearch_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;//loading.gif
            groupBox1.Enabled = true;//able to search again

            SearchResult cars = (SearchResult)e.Result;
            if (cars.Enabled)
            {
                dataGridView.Visible = true;
                dataGridView.Rows.Clear();
                //checkBoxFollow.Visible = true;                 -Тут изменить, если чё
                //buttonExcel.Visible = true;                               -Тут изменить, если чё
                AddToBDbutton.Visible = true;
            }
            else
            {
                dataGridView.Visible = false;
                checkBoxFollow.Visible = false;
                buttonExcel.Visible = false;
                MessageBox.Show("По вашему запросу ничего не найдено.\nПопробуйте изменить некоторые параметры");
            }

            int j = 0;
            foreach (string[] i in cars.carsList)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView.Rows[0].Clone();
                try
                {
                    row.Cells[0].Value = i[0];
                    row.Cells[1].Value = i[1];
                    row.Cells[2].Value = i[2];
                    row.Cells[3].Value = i[3];

                    //row.Cells[4].Value = Image.FromFile(cars.photoList[j]); C:\Users\Алексей\YandexDisk\Photos\Vk.me
                    row.Cells[4].Value = cars.photoList[j];

                    row.Cells[5].Value = cars.datesList[j].ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
                    row.Cells[6].Value = cars.linksList[j];
                    
                }
                catch
                {
                    row.Cells[0].Value = "";
                    row.Cells[1].Value = "";
                    row.Cells[2].Value = "";
                    row.Cells[3].Value = "";
                    row.Cells[4].Value = "";
                    row.Cells[5].Value = "";
                }
                dataGridView.Rows.Add(row);
                j++;
            }

            foreach (DateTime date in cars.datesList)
            {
                if (DateTime.Compare(cars.oldestDate, date) < 0)
                    cars.oldestDate = date;
            }
            localOldestDate = cars.oldestDate;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNewCarForm carForm = new AddNewCarForm();
            carForm.Show();
        }

        private void ParserForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carsDataSet1.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter1.Fill(this.carsDataSet1.Cars);
            // TODO: This line of code loads data into the 'carsDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.carsDataSet.Cars);

        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void AddToBDbutton_Click(object sender, EventArgs e)
        {
            string name = dataGridView.CurrentRow.Cells[0].Value.ToString();
            string mark = comboBoxBrand.SelectedValue.ToString();
            int year = Convert.ToInt32(dataGridView.CurrentRow.Cells[2].Value.ToString());
            int price = Convert.ToInt32(dataGridView.CurrentRow.Cells[1].Value.ToString().Replace(" ", string.Empty));
            string url = dataGridView.CurrentRow.Cells[5].Value.ToString();
            string region = comboBoxRegion.SelectedValue.ToString();

            Uri tcpUri = new Uri("http://localhost:8080/");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IMyObject> factory = new ChannelFactory<IMyObject>(binding, address);
            IMyObject service = factory.CreateChannel();

            bool answer = service.newCarFromGrid(name, mark, year, price, url, region);
            if (answer)
            {
                MessageBox.Show("Успешно добавлено!");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewImageCell cell = (DataGridViewImageCell)dataGridView.CurrentCell;
            /*
             * Current - это не та ячейка, на которую наводим
             */
            if (e.RowIndex > -1 && e.ColumnIndex == 4 && e.RowIndex < (dataGridView.Rows.Count-1))
            {
                string url = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                picForm.setImage(url);
                picForm.Show();
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_MouseLeave(object sender, EventArgs e)
        {
        }

        private void dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            picForm.Hide();
        }    
    }
}
