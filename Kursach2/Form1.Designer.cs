﻿namespace Kursach
{
    partial class ParserForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParserForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxYear2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxYear1 = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxBrand = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Фотография = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.checkBoxFollow = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerSearch = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.carsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.carsDataSet1 = new Kursach.carsDataSet1();
            this.carsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carsDataSet = new Kursach.carsDataSet();
            this.carsTableAdapter = new Kursach.carsDataSetTableAdapters.CarsTableAdapter();
            this.carsTableAdapter1 = new Kursach.carsDataSet1TableAdapters.CarsTableAdapter();
            this.AddToBDbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxYear2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxRegion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxYear1);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.comboBoxBrand);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(129, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(331, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "-";
            // 
            // comboBoxYear2
            // 
            this.comboBoxYear2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxYear2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxYear2.FormattingEnabled = true;
            this.comboBoxYear2.Location = new System.Drawing.Point(345, 65);
            this.comboBoxYear2.Name = "comboBoxYear2";
            this.comboBoxYear2.Size = new System.Drawing.Size(80, 25);
            this.comboBoxYear2.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(242, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Год выпуска:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(58, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Марка:";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(112, 101);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(213, 23);
            this.comboBoxRegion.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(58, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Регион:";
            // 
            // comboBoxYear1
            // 
            this.comboBoxYear1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxYear1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxYear1.FormattingEnabled = true;
            this.comboBoxYear1.Location = new System.Drawing.Point(245, 65);
            this.comboBoxYear1.Name = "comboBoxYear1";
            this.comboBoxYear1.Size = new System.Drawing.Size(80, 25);
            this.comboBoxYear1.TabIndex = 6;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearch.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearch.Location = new System.Drawing.Point(447, 59);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(160, 59);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            this.buttonSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonSearch_KeyDown);
            // 
            // comboBoxBrand
            // 
            this.comboBoxBrand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBrand.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxBrand.FormattingEnabled = true;
            this.comboBoxBrand.Location = new System.Drawing.Point(61, 65);
            this.comboBoxBrand.Name = "comboBoxBrand";
            this.comboBoxBrand.Size = new System.Drawing.Size(171, 25);
            this.comboBoxBrand.TabIndex = 4;
            this.comboBoxBrand.SelectedIndexChanged += new System.EventHandler(this.comboBoxBrand_SelectedIndexChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnPrice,
            this.ColumnYear,
            this.ColumnCity,
            this.Фотография,
            this.ColumnDate,
            this.ColumnLink});
            this.dataGridView.Location = new System.Drawing.Point(129, 219);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(660, 402);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.Visible = false;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellMouseEnter);
            this.dataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellMouseLeave);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dataGridView.MouseLeave += new System.EventHandler(this.dataGridView_MouseLeave);
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Модель";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnName.Width = 220;
            // 
            // ColumnPrice
            // 
            this.ColumnPrice.HeaderText = "Цена";
            this.ColumnPrice.Name = "ColumnPrice";
            this.ColumnPrice.ReadOnly = true;
            // 
            // ColumnYear
            // 
            this.ColumnYear.HeaderText = "Год выпуска";
            this.ColumnYear.Name = "ColumnYear";
            this.ColumnYear.ReadOnly = true;
            this.ColumnYear.Width = 50;
            // 
            // ColumnCity
            // 
            this.ColumnCity.HeaderText = "Город";
            this.ColumnCity.Name = "ColumnCity";
            this.ColumnCity.ReadOnly = true;
            this.ColumnCity.Width = 140;
            // 
            // Фотография
            // 
            this.Фотография.HeaderText = "Фотография";
            this.Фотография.Name = "Фотография";
            this.Фотография.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Дата";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            this.ColumnDate.Width = 120;
            // 
            // ColumnLink
            // 
            this.ColumnLink.HeaderText = "Ссылка";
            this.ColumnLink.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.ColumnLink.Name = "ColumnLink";
            this.ColumnLink.ReadOnly = true;
            this.ColumnLink.Text = "";
            this.ColumnLink.Width = 300;
            // 
            // buttonExcel
            // 
            this.buttonExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExcel.BackgroundImage")));
            this.buttonExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExcel.Location = new System.Drawing.Point(798, 557);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(64, 64);
            this.buttonExcel.TabIndex = 2;
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Visible = false;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // checkBoxFollow
            // 
            this.checkBoxFollow.AutoSize = true;
            this.checkBoxFollow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxFollow.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxFollow.Location = new System.Drawing.Point(795, 219);
            this.checkBoxFollow.Name = "checkBoxFollow";
            this.checkBoxFollow.Size = new System.Drawing.Size(162, 17);
            this.checkBoxFollow.TabIndex = 10;
            this.checkBoxFollow.Text = "отслеживать объявления";
            this.checkBoxFollow.UseVisualStyleBackColor = true;
            this.checkBoxFollow.Visible = false;
            this.checkBoxFollow.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer
            // 
            this.timer.Interval = 1800000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // backgroundWorkerSearch
            // 
            this.backgroundWorkerSearch.WorkerReportsProgress = true;
            this.backgroundWorkerSearch.WorkerSupportsCancellation = true;
            this.backgroundWorkerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorkerSearch.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerSearch_ProgressChanged);
            this.backgroundWorkerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSearch_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(434, 332);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(795, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "или";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(817, 167);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(88, 13);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "добавить новую";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // carsBindingSource1
            // 
            this.carsBindingSource1.DataMember = "Cars";
            this.carsBindingSource1.DataSource = this.carsDataSet1;
            // 
            // carsDataSet1
            // 
            this.carsDataSet1.DataSetName = "carsDataSet1";
            this.carsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // carsBindingSource
            // 
            this.carsBindingSource.DataMember = "Cars";
            this.carsBindingSource.DataSource = this.carsDataSet;
            // 
            // carsDataSet
            // 
            this.carsDataSet.DataSetName = "carsDataSet";
            this.carsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // carsTableAdapter
            // 
            this.carsTableAdapter.ClearBeforeFill = true;
            // 
            // carsTableAdapter1
            // 
            this.carsTableAdapter1.ClearBeforeFill = true;
            // 
            // AddToBDbutton
            // 
            this.AddToBDbutton.Location = new System.Drawing.Point(820, 373);
            this.AddToBDbutton.Name = "AddToBDbutton";
            this.AddToBDbutton.Size = new System.Drawing.Size(113, 23);
            this.AddToBDbutton.TabIndex = 15;
            this.AddToBDbutton.Text = "Добавить в базу";
            this.AddToBDbutton.UseVisualStyleBackColor = true;
            this.AddToBDbutton.Visible = false;
            this.AddToBDbutton.Click += new System.EventHandler(this.AddToBDbutton_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(885, 548);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 73);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 633);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddToBDbutton);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBoxFollow);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ParserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Парсер auto.ru";
            this.Load += new System.EventHandler(this.ParserForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxYear1;
        private System.Windows.Forms.ComboBox comboBoxBrand;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.CheckBox checkBoxFollow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxYear2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private carsDataSet carsDataSet;
        private System.Windows.Forms.BindingSource carsBindingSource;
        private carsDataSetTableAdapters.CarsTableAdapter carsTableAdapter;
        private carsDataSet1 carsDataSet1;
        private System.Windows.Forms.BindingSource carsBindingSource1;
        private carsDataSet1TableAdapters.CarsTableAdapter carsTableAdapter1;
        private System.Windows.Forms.Button AddToBDbutton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCity;
        private System.Windows.Forms.DataGridViewLinkColumn Фотография;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnLink;
        private System.Windows.Forms.Button button1;
    }
}

