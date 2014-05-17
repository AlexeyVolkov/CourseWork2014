using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    }
}
