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

namespace Kursach
{
    public partial class Form1 : Form
    {
        DateTime localOldestDate = new DateTime();
        public Form1()
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
            comboBoxRegion.SelectedIndex = 73;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)//-----Search
        {
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

            //string url = "http://cars.auto.ru/list/?mark_id=" + mark_id + "&year%5B1%5D=" + year1 + "&year%5B2%5D=" + year2 + "&region_id=" + region;
            //richTextBox1.Text = url;

           Search cars = new Search(mark_id, year1, year2, region);//int mark_id, int year1, int year2, int region

           if (cars.Enabled)
           {
               dataGridView.Visible = true;
               dataGridView.Rows.Clear();
               checkBoxFollow.Visible = true;
               buttonExcel.Visible = true;
           }
           else
           {
               dataGridView.Visible = false;
               checkBoxFollow.Visible = false;
               buttonExcel.Visible = false;
               MessageBox.Show("По вашему запросу ничего не найдено.\nПопробуйте изменить некоторые параметры");
           }


           int j = 0;
           foreach(string[] i in cars.carsList)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView.Rows[0].Clone();
                try
                {
                    row.Cells[0].Value = i[0];
                    row.Cells[1].Value = i[1];
                    row.Cells[2].Value = i[2];
                    row.Cells[3].Value = i[3];
                    row.Cells[4].Value = cars.datesList[j].ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
                    row.Cells[5].Value = cars.linksList[j];
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
            Search cars = new Search(mark_id, year1, year2, region);

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

        
    }
}
