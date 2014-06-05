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

using MappingDLL;

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
            Car newCar = new Car();
            newCar.name = "Combain";

            newCar.name = textBoxName.Text.ToString();
            newCar.mark = comboBoxBrand.SelectedValue.ToString();
            newCar.year = Convert.ToInt32(comboBoxYear.SelectedValue.ToString());
            newCar.price = Convert.ToInt32(textBoxPrice.Text);
            newCar.info = richTextBoxInfo.Text.ToString();
            newCar.region = comboBoxRegion.SelectedValue.ToString();
            newCar.url_photo = textBoxUrlPhoto.Text.ToString();


            db.Cars.InsertOnSubmit(newCar);
            db.SubmitChanges();
            MessageBox.Show("Успешно добавлено!");
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
