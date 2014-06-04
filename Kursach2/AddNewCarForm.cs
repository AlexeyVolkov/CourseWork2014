using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DBLibrary;

namespace Kursach
{
    public partial class AddNewCarForm : Form
    {
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
            
            ManagerClass manage = new ManagerClass();
            string query = @"INSERT INTO Cars (name, mark, year, price, info, region, url_photo) VALUES ('" + textBoxName.ToString() + "', '" + comboBoxBrand.SelectedValue.ToString() + "', " + Convert.ToInt32(comboBoxYear.SelectedValue.ToString()) + ", " + Convert.ToInt32(textBoxPrice.ToString()) + ", '" + richTextBoxInfo.ToString() + "', '" + comboBoxRegion.SelectedValue.ToString() + "', '" + textBoxUrlPhoto.ToString() + "');";
            var s = manage.ExecSQL(query);
            
            MessageBox.Show(s);
        }
    }
}
