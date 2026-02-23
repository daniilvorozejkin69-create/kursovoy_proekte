using System;

namespace kursovoy_proekt
{
    partial class RevenueReport
    {
        private System.ComponentModel.IContainer components = null;

        // Основные панели
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelFilter;

        // Фильтры
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.RadioButton radioToday;
        private System.Windows.Forms.RadioButton radioWeek;
        private System.Windows.Forms.RadioButton radioMonth;
        private System.Windows.Forms.RadioButton radioYear;
        private System.Windows.Forms.RadioButton radioCustom;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;

        // Кнопки
        private System.Windows.Forms.Button buttonApplyFilter;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonExportExcel;
        private System.Windows.Forms.Button buttonExportWord;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonBackToMenu;

        // DataGridView
        private System.Windows.Forms.DataGridView dataGridViewRevenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHouseCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServicesCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;

        // Сводка
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label labelSummaryTitle;
        private System.Windows.Forms.Label labelTotalOrders;
        private System.Windows.Forms.Label labelTotalOrdersValue;
        private System.Windows.Forms.Label labelTotalHouseRevenue;
        private System.Windows.Forms.Label labelTotalHouseRevenueValue;
        private System.Windows.Forms.Label labelTotalServicesRevenue;
        private System.Windows.Forms.Label labelTotalServicesRevenueValue;
        private System.Windows.Forms.Label labelTotalRevenue;
        private System.Windows.Forms.Label labelTotalRevenueValue;
        private System.Windows.Forms.Label labelAverageCheck;
        private System.Windows.Forms.Label labelAverageCheckValue;

        // Status
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelGreenLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonExportWord = new System.Windows.Forms.Button();
            this.buttonExportExcel = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonApplyFilter = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.radioCustom = new System.Windows.Forms.RadioButton();
            this.radioYear = new System.Windows.Forms.RadioButton();
            this.radioMonth = new System.Windows.Forms.RadioButton();
            this.radioWeek = new System.Windows.Forms.RadioButton();
            this.radioToday = new System.Windows.Forms.RadioButton();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.dataGridViewRevenue = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHouseCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServicesCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.labelSummaryTitle = new System.Windows.Forms.Label();
            this.labelTotalOrders = new System.Windows.Forms.Label();
            this.labelTotalOrdersValue = new System.Windows.Forms.Label();
            this.labelTotalHouseRevenue = new System.Windows.Forms.Label();
            this.labelTotalHouseRevenueValue = new System.Windows.Forms.Label();
            this.labelTotalServicesRevenue = new System.Windows.Forms.Label();
            this.labelTotalServicesRevenueValue = new System.Windows.Forms.Label();
            this.labelTotalRevenue = new System.Windows.Forms.Label();
            this.labelTotalRevenueValue = new System.Windows.Forms.Label();
            this.labelAverageCheck = new System.Windows.Forms.Label();
            this.labelAverageCheckValue = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRevenue)).BeginInit();
            this.panelSummary.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(30, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(269, 45);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Отчёт по выручке";
            // 
            // panelGreenLine
            // 
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 80);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(1200, 3);
            this.panelGreenLine.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.panelFilter);
            this.panelContent.Controls.Add(this.dataGridViewRevenue);
            this.panelContent.Controls.Add(this.panelSummary);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 83);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(1200, 667);
            this.panelContent.TabIndex = 2;
            // 
            // panelFilter
            // 
            this.panelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.buttonBackToMenu);
            this.panelFilter.Controls.Add(this.buttonPrint);
            this.panelFilter.Controls.Add(this.buttonExportWord);
            this.panelFilter.Controls.Add(this.buttonExportExcel);
            this.panelFilter.Controls.Add(this.buttonRefresh);
            this.panelFilter.Controls.Add(this.buttonApplyFilter);
            this.panelFilter.Controls.Add(this.dateTimePickerTo);
            this.panelFilter.Controls.Add(this.dateTimePickerFrom);
            this.panelFilter.Controls.Add(this.labelTo);
            this.panelFilter.Controls.Add(this.labelFrom);
            this.panelFilter.Controls.Add(this.radioCustom);
            this.panelFilter.Controls.Add(this.radioYear);
            this.panelFilter.Controls.Add(this.radioMonth);
            this.panelFilter.Controls.Add(this.radioWeek);
            this.panelFilter.Controls.Add(this.radioToday);
            this.panelFilter.Controls.Add(this.labelPeriod);
            this.panelFilter.Location = new System.Drawing.Point(20, 20);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1180, 140);
            this.panelFilter.TabIndex = 0;
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonBackToMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonBackToMenu.FlatAppearance.BorderSize = 2;
            this.buttonBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackToMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonBackToMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonBackToMenu.Location = new System.Drawing.Point(1040, 88);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(99, 30);
            this.buttonBackToMenu.TabIndex = 15;
            this.buttonBackToMenu.Text = "🏠 В меню";
            this.buttonBackToMenu.UseVisualStyleBackColor = false;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click_1);
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonPrint.FlatAppearance.BorderSize = 0;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonPrint.ForeColor = System.Drawing.Color.White;
            this.buttonPrint.Location = new System.Drawing.Point(940, 88);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(90, 30);
            this.buttonPrint.TabIndex = 14;
            this.buttonPrint.Text = "🖨️ Печать";
            this.buttonPrint.UseVisualStyleBackColor = false;
            // 
            // buttonExportWord
            // 
            this.buttonExportWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonExportWord.FlatAppearance.BorderSize = 0;
            this.buttonExportWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportWord.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonExportWord.ForeColor = System.Drawing.Color.White;
            this.buttonExportWord.Location = new System.Drawing.Point(1040, 48);
            this.buttonExportWord.Name = "buttonExportWord";
            this.buttonExportWord.Size = new System.Drawing.Size(90, 30);
            this.buttonExportWord.TabIndex = 13;
            this.buttonExportWord.Text = "📄 Word";
            this.buttonExportWord.UseVisualStyleBackColor = false;
            // 
            // buttonExportExcel
            // 
            this.buttonExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonExportExcel.FlatAppearance.BorderSize = 0;
            this.buttonExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonExportExcel.ForeColor = System.Drawing.Color.White;
            this.buttonExportExcel.Location = new System.Drawing.Point(940, 48);
            this.buttonExportExcel.Name = "buttonExportExcel";
            this.buttonExportExcel.Size = new System.Drawing.Size(90, 30);
            this.buttonExportExcel.TabIndex = 12;
            this.buttonExportExcel.Text = "📊 Excel";
            this.buttonExportExcel.UseVisualStyleBackColor = false;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(800, 88);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(120, 30);
            this.buttonRefresh.TabIndex = 11;
            this.buttonRefresh.Text = "🔄 Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            // 
            // buttonApplyFilter
            // 
            this.buttonApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonApplyFilter.FlatAppearance.BorderSize = 0;
            this.buttonApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApplyFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonApplyFilter.ForeColor = System.Drawing.Color.White;
            this.buttonApplyFilter.Location = new System.Drawing.Point(800, 48);
            this.buttonApplyFilter.Name = "buttonApplyFilter";
            this.buttonApplyFilter.Size = new System.Drawing.Size(120, 30);
            this.buttonApplyFilter.TabIndex = 10;
            this.buttonApplyFilter.Text = "✅ Применить";
            this.buttonApplyFilter.UseVisualStyleBackColor = false;
            this.buttonApplyFilter.Click += new System.EventHandler(this.buttonApplyFilter_Click_1);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(664, 50);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(120, 25);
            this.dateTimePickerTo.TabIndex = 9;
            this.dateTimePickerTo.Value = new System.DateTime(2026, 2, 12, 23, 22, 21, 434);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(524, 50);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(120, 25);
            this.dateTimePickerFrom.TabIndex = 7;
            this.dateTimePickerFrom.Value = new System.DateTime(2026, 2, 1, 0, 0, 0, 0);
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTo.Location = new System.Drawing.Point(660, 28);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(30, 19);
            this.labelTo.TabIndex = 8;
            this.labelTo.Text = "По:";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelFrom.Location = new System.Drawing.Point(520, 28);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(21, 19);
            this.labelFrom.TabIndex = 6;
            this.labelFrom.Text = "С:";
            // 
            // radioCustom
            // 
            this.radioCustom.AutoSize = true;
            this.radioCustom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioCustom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioCustom.Location = new System.Drawing.Point(367, 50);
            this.radioCustom.Name = "radioCustom";
            this.radioCustom.Size = new System.Drawing.Size(122, 23);
            this.radioCustom.TabIndex = 5;
            this.radioCustom.Text = "Произвольный";
            this.radioCustom.UseVisualStyleBackColor = true;
            // 
            // radioYear
            // 
            this.radioYear.AutoSize = true;
            this.radioYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioYear.Location = new System.Drawing.Point(300, 50);
            this.radioYear.Name = "radioYear";
            this.radioYear.Size = new System.Drawing.Size(50, 23);
            this.radioYear.TabIndex = 4;
            this.radioYear.Text = "Год";
            this.radioYear.UseVisualStyleBackColor = true;
            // 
            // radioMonth
            // 
            this.radioMonth.AutoSize = true;
            this.radioMonth.Checked = true;
            this.radioMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioMonth.Location = new System.Drawing.Point(213, 50);
            this.radioMonth.Name = "radioMonth";
            this.radioMonth.Size = new System.Drawing.Size(68, 23);
            this.radioMonth.TabIndex = 3;
            this.radioMonth.TabStop = true;
            this.radioMonth.Text = "Месяц";
            this.radioMonth.UseVisualStyleBackColor = true;
            // 
            // radioWeek
            // 
            this.radioWeek.AutoSize = true;
            this.radioWeek.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioWeek.Location = new System.Drawing.Point(120, 50);
            this.radioWeek.Name = "radioWeek";
            this.radioWeek.Size = new System.Drawing.Size(73, 23);
            this.radioWeek.TabIndex = 2;
            this.radioWeek.Text = "Неделя";
            this.radioWeek.UseVisualStyleBackColor = true;
            // 
            // radioToday
            // 
            this.radioToday.AutoSize = true;
            this.radioToday.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioToday.Location = new System.Drawing.Point(24, 50);
            this.radioToday.Name = "radioToday";
            this.radioToday.Size = new System.Drawing.Size(79, 23);
            this.radioToday.TabIndex = 1;
            this.radioToday.Text = "Сегодня";
            this.radioToday.UseVisualStyleBackColor = true;
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPeriod.Location = new System.Drawing.Point(20, 20);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(68, 20);
            this.labelPeriod.TabIndex = 0;
            this.labelPeriod.Text = "Период:";
            // 
            // dataGridViewRevenue
            // 
            this.dataGridViewRevenue.AllowUserToAddRows = false;
            this.dataGridViewRevenue.AllowUserToDeleteRows = false;
            this.dataGridViewRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRevenue.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRevenue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewRevenue.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewRevenue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewRevenue.ColumnHeadersHeight = 40;
            this.dataGridViewRevenue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colOrderNumber,
            this.colClient,
            this.colHouse,
            this.colHouseCost,
            this.colServicesCost,
            this.colTotal});
            this.dataGridViewRevenue.EnableHeadersVisualStyles = false;
            this.dataGridViewRevenue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            this.dataGridViewRevenue.Location = new System.Drawing.Point(20, 180);
            this.dataGridViewRevenue.Name = "dataGridViewRevenue";
            this.dataGridViewRevenue.ReadOnly = true;
            this.dataGridViewRevenue.RowHeadersVisible = false;
            this.dataGridViewRevenue.RowTemplate.Height = 30;
            this.dataGridViewRevenue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRevenue.Size = new System.Drawing.Size(1140, 350);
            this.dataGridViewRevenue.TabIndex = 1;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Дата";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.HeaderText = "№ заказа";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.ReadOnly = true;
            this.colOrderNumber.Width = 90;
            // 
            // colClient
            // 
            this.colClient.HeaderText = "Клиент";
            this.colClient.Name = "colClient";
            this.colClient.ReadOnly = true;
            this.colClient.Width = 220;
            // 
            // colHouse
            // 
            this.colHouse.HeaderText = "Дом";
            this.colHouse.Name = "colHouse";
            this.colHouse.ReadOnly = true;
            this.colHouse.Width = 180;
            // 
            // colHouseCost
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.colHouseCost.DefaultCellStyle = dataGridViewCellStyle1;
            this.colHouseCost.HeaderText = "Проживание";
            this.colHouseCost.Name = "colHouseCost";
            this.colHouseCost.ReadOnly = true;
            this.colHouseCost.Width = 120;
            // 
            // colServicesCost
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.colServicesCost.DefaultCellStyle = dataGridViewCellStyle2;
            this.colServicesCost.HeaderText = "Услуги";
            this.colServicesCost.Name = "colServicesCost";
            this.colServicesCost.ReadOnly = true;
            this.colServicesCost.Width = 120;
            // 
            // colTotal
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Format = "N2";
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotal.HeaderText = "Итого";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 130;
            // 
            // panelSummary
            // 
            this.panelSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSummary.BackColor = System.Drawing.Color.White;
            this.panelSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummary.Controls.Add(this.labelSummaryTitle);
            this.panelSummary.Controls.Add(this.labelTotalOrders);
            this.panelSummary.Controls.Add(this.labelTotalOrdersValue);
            this.panelSummary.Controls.Add(this.labelTotalHouseRevenue);
            this.panelSummary.Controls.Add(this.labelTotalHouseRevenueValue);
            this.panelSummary.Controls.Add(this.labelTotalServicesRevenue);
            this.panelSummary.Controls.Add(this.labelTotalServicesRevenueValue);
            this.panelSummary.Controls.Add(this.labelTotalRevenue);
            this.panelSummary.Controls.Add(this.labelTotalRevenueValue);
            this.panelSummary.Controls.Add(this.labelAverageCheck);
            this.panelSummary.Controls.Add(this.labelAverageCheckValue);
            this.panelSummary.Location = new System.Drawing.Point(20, 550);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(1140, 80);
            this.panelSummary.TabIndex = 2;
            // 
            // labelSummaryTitle
            // 
            this.labelSummaryTitle.AutoSize = true;
            this.labelSummaryTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelSummaryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelSummaryTitle.Location = new System.Drawing.Point(20, 30);
            this.labelSummaryTitle.Name = "labelSummaryTitle";
            this.labelSummaryTitle.Size = new System.Drawing.Size(64, 20);
            this.labelSummaryTitle.TabIndex = 0;
            this.labelSummaryTitle.Text = "Сводка:";
            // 
            // labelTotalOrders
            // 
            this.labelTotalOrders.AutoSize = true;
            this.labelTotalOrders.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTotalOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalOrders.Location = new System.Drawing.Point(120, 32);
            this.labelTotalOrders.Name = "labelTotalOrders";
            this.labelTotalOrders.Size = new System.Drawing.Size(98, 19);
            this.labelTotalOrders.TabIndex = 1;
            this.labelTotalOrders.Text = "Всего заказов:";
            // 
            // labelTotalOrdersValue
            // 
            this.labelTotalOrdersValue.AutoSize = true;
            this.labelTotalOrdersValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotalOrdersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalOrdersValue.Location = new System.Drawing.Point(235, 32);
            this.labelTotalOrdersValue.Name = "labelTotalOrdersValue";
            this.labelTotalOrdersValue.Size = new System.Drawing.Size(17, 19);
            this.labelTotalOrdersValue.TabIndex = 2;
            this.labelTotalOrdersValue.Text = "0";
            // 
            // labelTotalHouseRevenue
            // 
            this.labelTotalHouseRevenue.AutoSize = true;
            this.labelTotalHouseRevenue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTotalHouseRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalHouseRevenue.Location = new System.Drawing.Point(300, 32);
            this.labelTotalHouseRevenue.Name = "labelTotalHouseRevenue";
            this.labelTotalHouseRevenue.Size = new System.Drawing.Size(160, 19);
            this.labelTotalHouseRevenue.TabIndex = 3;
            this.labelTotalHouseRevenue.Text = "Выручка с проживания:";
            // 
            // labelTotalHouseRevenueValue
            // 
            this.labelTotalHouseRevenueValue.AutoSize = true;
            this.labelTotalHouseRevenueValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotalHouseRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.labelTotalHouseRevenueValue.Location = new System.Drawing.Point(455, 32);
            this.labelTotalHouseRevenueValue.Name = "labelTotalHouseRevenueValue";
            this.labelTotalHouseRevenueValue.Size = new System.Drawing.Size(29, 19);
            this.labelTotalHouseRevenueValue.TabIndex = 4;
            this.labelTotalHouseRevenueValue.Text = "0 ₽";
            // 
            // labelTotalServicesRevenue
            // 
            this.labelTotalServicesRevenue.AutoSize = true;
            this.labelTotalServicesRevenue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTotalServicesRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalServicesRevenue.Location = new System.Drawing.Point(520, 32);
            this.labelTotalServicesRevenue.Name = "labelTotalServicesRevenue";
            this.labelTotalServicesRevenue.Size = new System.Drawing.Size(113, 19);
            this.labelTotalServicesRevenue.TabIndex = 5;
            this.labelTotalServicesRevenue.Text = "Выручка с услуг:";
            // 
            // labelTotalServicesRevenueValue
            // 
            this.labelTotalServicesRevenueValue.AutoSize = true;
            this.labelTotalServicesRevenueValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotalServicesRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelTotalServicesRevenueValue.Location = new System.Drawing.Point(645, 32);
            this.labelTotalServicesRevenueValue.Name = "labelTotalServicesRevenueValue";
            this.labelTotalServicesRevenueValue.Size = new System.Drawing.Size(29, 19);
            this.labelTotalServicesRevenueValue.TabIndex = 6;
            this.labelTotalServicesRevenueValue.Text = "0 ₽";
            // 
            // labelTotalRevenue
            // 
            this.labelTotalRevenue.AutoSize = true;
            this.labelTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalRevenue.Location = new System.Drawing.Point(720, 32);
            this.labelTotalRevenue.Name = "labelTotalRevenue";
            this.labelTotalRevenue.Size = new System.Drawing.Size(101, 19);
            this.labelTotalRevenue.TabIndex = 7;
            this.labelTotalRevenue.Text = "Общая сумма:";
            // 
            // labelTotalRevenueValue
            // 
            this.labelTotalRevenueValue.AutoSize = true;
            this.labelTotalRevenueValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelTotalRevenueValue.Location = new System.Drawing.Point(820, 29);
            this.labelTotalRevenueValue.Name = "labelTotalRevenueValue";
            this.labelTotalRevenueValue.Size = new System.Drawing.Size(55, 21);
            this.labelTotalRevenueValue.TabIndex = 8;
            this.labelTotalRevenueValue.Text = "0,00 ₽";
            // 
            // labelAverageCheck
            // 
            this.labelAverageCheck.AutoSize = true;
            this.labelAverageCheck.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelAverageCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelAverageCheck.Location = new System.Drawing.Point(910, 32);
            this.labelAverageCheck.Name = "labelAverageCheck";
            this.labelAverageCheck.Size = new System.Drawing.Size(94, 19);
            this.labelAverageCheck.TabIndex = 9;
            this.labelAverageCheck.Text = "Средний чек:";
            // 
            // labelAverageCheckValue
            // 
            this.labelAverageCheckValue.AutoSize = true;
            this.labelAverageCheckValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelAverageCheckValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelAverageCheckValue.Location = new System.Drawing.Point(1005, 32);
            this.labelAverageCheckValue.Name = "labelAverageCheckValue";
            this.labelAverageCheckValue.Size = new System.Drawing.Size(29, 19);
            this.labelAverageCheckValue.TabIndex = 10;
            this.labelAverageCheckValue.Text = "0 ₽";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 750);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(191, 17);
            this.toolStripStatusLabel.Text = "Готов к работе. Выберите период";
            // 
            // RevenueReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 772);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(1216, 811);
            this.Name = "RevenueReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёт по выручке - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRevenue)).EndInit();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}