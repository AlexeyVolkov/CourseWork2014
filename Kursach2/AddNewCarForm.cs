using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.Linq;
using CommunicationInterface;
using MappingDLL;
using System.ServiceModel;

namespace Kursach
{
    public partial class AddNewCarForm : Form
    {
        DB db = new DB(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Алексей\Documents\SourceTree\CourseWork2014\Kursach2\cars.mdf;Integrated Security=True;Connect Timeout=30");
        public AddNewCarForm()
        {
            InitializeComponent();

            DefaultLists defaultLists = new DefaultLists();//----Create a defaultList object

            Dictionary<string, string> brandList = defaultLists.brand();//------Default brands
            comboBoxBrand.DisplayMember = "Key";
            comboBoxBrand.ValueMember = "Value";
            comboBoxBrand.DataSource = new BindingSource(brandList, null);

            Dictionary<string, string> yearList = defaultLists.year();//------Default years
            comboBoxYear.DisplayMember = "Key";
            comboBoxYear.ValueMember = "Value";
            comboBoxYear.DataSource = new BindingSource(yearList, null);
            comboBoxYear.SelectedIndex = 1;

            Dictionary<string, string> regionList = defaultLists.region();//------Default regions
            comboBoxRegion.DisplayMember = "Key";
            comboBoxRegion.ValueMember = "Value";
            comboBoxRegion.DataSource = new BindingSource(regionList, null);
            comboBoxRegion.SelectedIndex = 75;
        }

        private void AddNewCarForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carsDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.carsDataSet.Cars);

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)//Add
        {
            string name = textBoxName.Text.ToString();
            string mark = comboBoxBrand.SelectedValue.ToString();
            int year = Convert.ToInt32(comboBoxYear.SelectedValue.ToString());
            int price = Convert.ToInt32(textBoxPrice.Text);
            string info = richTextBoxInfo.Text.ToString();
            string region = comboBoxRegion.SelectedValue.ToString();
            string url_photo = textBoxUrlPhoto.Text.ToString();

            Uri tcpUri = new Uri("http://localhost:8080/");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IMyObject> factory = new ChannelFactory<IMyObject>(binding, address);
            IMyObject service = factory.CreateChannel();

            bool answer = service.newCarFromUser(name, mark, year, price, info, region, url_photo);
            if (answer)
            {
                MessageBox.Show("Успешно добавлено!");
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
    public class DB : DataContext
    {
        public DB(string cs)
            : base(cs)
        {
        }

        public System.Data.Linq.Table<Car> Cars
        {
            get { return this.GetTable<Car>(); }

        }
    }
}
