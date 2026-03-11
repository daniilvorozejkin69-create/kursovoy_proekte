namespace kursovoy_proekt
{
    partial class HouseReportForm
    {
        private System.ComponentModel.IContainer components = null;

        // Элементы управления
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelFilter;
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
        private System.Windows.Forms.Button buttonApplyFilter;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonExportExcel;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonBackToMenu;
        private System.Windows.Forms.DataGridView dataGridViewReport;
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelGreenLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
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
            this.dataGridViewReport = new System.Windows.Forms.DataGridView();
            this.colRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHouseClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBookings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRevenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvgStay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOccupancy = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).BeginInit();
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
            this.panelHeader.Size = new System.Drawing.Size(1151, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(20, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(231, 37);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Отчёт по домам";
            // 
            // panelGreenLine
            // 
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 70);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(1151, 3);
            this.panelGreenLine.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.panelFilter);
            this.panelContent.Controls.Add(this.dataGridViewReport);
            this.panelContent.Controls.Add(this.panelSummary);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 73);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(10);
            this.panelContent.Size = new System.Drawing.Size(1151, 505);
            this.panelContent.TabIndex = 2;
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.buttonBackToMenu);
            this.panelFilter.Controls.Add(this.buttonPrint);
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
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(10, 10);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1131, 130);
            this.panelFilter.TabIndex = 0;
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackToMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonBackToMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonBackToMenu.Location = new System.Drawing.Point(130, 80);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(100, 30);
            this.buttonBackToMenu.TabIndex = 14;
            this.buttonBackToMenu.Text = "🏠 В меню";
            this.buttonBackToMenu.UseVisualStyleBackColor = false;
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonPrint.ForeColor = System.Drawing.Color.White;
            this.buttonPrint.Location = new System.Drawing.Point(20, 80);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(100, 30);
            this.buttonPrint.TabIndex = 13;
            this.buttonPrint.Text = "🖨️ Печать";
            this.buttonPrint.UseVisualStyleBackColor = false;
            // 
            // buttonExportExcel
            // 
            this.buttonExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonExportExcel.ForeColor = System.Drawing.Color.White;
            this.buttonExportExcel.Location = new System.Drawing.Point(881, 41);
            this.buttonExportExcel.Name = "buttonExportExcel";
            this.buttonExportExcel.Size = new System.Drawing.Size(104, 29);
            this.buttonExportExcel.TabIndex = 11;
            this.buttonExportExcel.Text = "📊 Excel";
            this.buttonExportExcel.UseVisualStyleBackColor = false;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(750, 80);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(235, 30);
            this.buttonRefresh.TabIndex = 10;
            this.buttonRefresh.Text = "🔄 Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            // 
            // buttonApplyFilter
            // 
            this.buttonApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApplyFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonApplyFilter.ForeColor = System.Drawing.Color.White;
            this.buttonApplyFilter.Location = new System.Drawing.Point(750, 40);
            this.buttonApplyFilter.Name = "buttonApplyFilter";
            this.buttonApplyFilter.Size = new System.Drawing.Size(125, 30);
            this.buttonApplyFilter.TabIndex = 9;
            this.buttonApplyFilter.Text = "✅ Применить";
            this.buttonApplyFilter.UseVisualStyleBackColor = false;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(620, 42);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(110, 25);
            this.dateTimePickerTo.TabIndex = 8;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(500, 42);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(110, 25);
            this.dateTimePickerFrom.TabIndex = 6;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTo.Location = new System.Drawing.Point(620, 20);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(30, 19);
            this.labelTo.TabIndex = 7;
            this.labelTo.Text = "По:";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelFrom.Location = new System.Drawing.Point(500, 20);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(21, 19);
            this.labelFrom.TabIndex = 5;
            this.labelFrom.Text = "С:";
            // 
            // radioCustom
            // 
            this.radioCustom.AutoSize = true;
            this.radioCustom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioCustom.Location = new System.Drawing.Point(360, 40);
            this.radioCustom.Name = "radioCustom";
            this.radioCustom.Size = new System.Drawing.Size(122, 23);
            this.radioCustom.TabIndex = 4;
            this.radioCustom.Text = "Произвольный";
            this.radioCustom.UseVisualStyleBackColor = true;
            // 
            // radioYear
            // 
            this.radioYear.AutoSize = true;
            this.radioYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioYear.Location = new System.Drawing.Point(290, 40);
            this.radioYear.Name = "radioYear";
            this.radioYear.Size = new System.Drawing.Size(50, 23);
            this.radioYear.TabIndex = 3;
            this.radioYear.Text = "Год";
            this.radioYear.UseVisualStyleBackColor = true;
            // 
            // radioMonth
            // 
            this.radioMonth.AutoSize = true;
            this.radioMonth.Checked = true;
            this.radioMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioMonth.Location = new System.Drawing.Point(200, 40);
            this.radioMonth.Name = "radioMonth";
            this.radioMonth.Size = new System.Drawing.Size(68, 23);
            this.radioMonth.TabIndex = 2;
            this.radioMonth.TabStop = true;
            this.radioMonth.Text = "Месяц";
            this.radioMonth.UseVisualStyleBackColor = true;
            // 
            // radioWeek
            // 
            this.radioWeek.AutoSize = true;
            this.radioWeek.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioWeek.Location = new System.Drawing.Point(110, 40);
            this.radioWeek.Name = "radioWeek";
            this.radioWeek.Size = new System.Drawing.Size(73, 23);
            this.radioWeek.TabIndex = 1;
            this.radioWeek.Text = "Неделя";
            this.radioWeek.UseVisualStyleBackColor = true;
            // 
            // radioToday
            // 
            this.radioToday.AutoSize = true;
            this.radioToday.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioToday.Location = new System.Drawing.Point(20, 40);
            this.radioToday.Name = "radioToday";
            this.radioToday.Size = new System.Drawing.Size(79, 23);
            this.radioToday.TabIndex = 0;
            this.radioToday.Text = "Сегодня";
            this.radioToday.UseVisualStyleBackColor = true;
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.labelPeriod.Location = new System.Drawing.Point(20, 15);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(68, 20);
            this.labelPeriod.TabIndex = 15;
            this.labelPeriod.Text = "Период:";
            // 
            // dataGridViewReport
            // 
            this.dataGridViewReport.AllowUserToAddRows = false;
            this.dataGridViewReport.AllowUserToDeleteRows = false;
            this.dataGridViewReport.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewReport.ColumnHeadersHeight = 40;
            this.dataGridViewReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRank,
            this.colHouseName,
            this.colHouseClass,
            this.colBookings,
            this.colDays,
            this.colRevenue,
            this.colAvgStay,
            this.colOccupancy});
            this.dataGridViewReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReport.EnableHeadersVisualStyles = false;
            this.dataGridViewReport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            this.dataGridViewReport.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewReport.Name = "dataGridViewReport";
            this.dataGridViewReport.ReadOnly = true;
            this.dataGridViewReport.RowHeadersVisible = false;
            this.dataGridViewReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReport.Size = new System.Drawing.Size(1131, 405);
            this.dataGridViewReport.TabIndex = 1;
            // 
            // colRank
            // 
            this.colRank.HeaderText = "№";
            this.colRank.Name = "colRank";
            this.colRank.ReadOnly = true;
            this.colRank.Width = 40;
            // 
            // colHouseName
            // 
            this.colHouseName.HeaderText = "Название дома";
            this.colHouseName.Name = "colHouseName";
            this.colHouseName.ReadOnly = true;
            this.colHouseName.Width = 200;
            // 
            // colHouseClass
            // 
            this.colHouseClass.HeaderText = "Класс";
            this.colHouseClass.Name = "colHouseClass";
            this.colHouseClass.ReadOnly = true;
            this.colHouseClass.Width = 80;
            // 
            // colBookings
            // 
            this.colBookings.HeaderText = "Бронирований";
            this.colBookings.Name = "colBookings";
            this.colBookings.ReadOnly = true;
            // 
            // colDays
            // 
            this.colDays.HeaderText = "Занято дней";
            this.colDays.Name = "colDays";
            this.colDays.ReadOnly = true;
            this.colDays.Width = 90;
            // 
            // colRevenue
            // 
            this.colRevenue.HeaderText = "Доход, ₽";
            this.colRevenue.Name = "colRevenue";
            this.colRevenue.ReadOnly = true;
            this.colRevenue.Width = 120;
            // 
            // colAvgStay
            // 
            this.colAvgStay.HeaderText = "Ср. длит.";
            this.colAvgStay.Name = "colAvgStay";
            this.colAvgStay.ReadOnly = true;
            this.colAvgStay.Width = 80;
            // 
            // colOccupancy
            // 
            this.colOccupancy.HeaderText = "Загрузка";
            this.colOccupancy.Name = "colOccupancy";
            this.colOccupancy.ReadOnly = true;
            this.colOccupancy.Width = 80;
            // 
            // panelSummary
            // 
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
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSummary.Location = new System.Drawing.Point(10, 415);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(1131, 80);
            this.panelSummary.TabIndex = 2;
            // 
            // labelSummaryTitle
            // 
            this.labelSummaryTitle.AutoSize = true;
            this.labelSummaryTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.labelSummaryTitle.Location = new System.Drawing.Point(10, 30);
            this.labelSummaryTitle.Name = "labelSummaryTitle";
            this.labelSummaryTitle.Size = new System.Drawing.Size(64, 20);
            this.labelSummaryTitle.TabIndex = 0;
            this.labelSummaryTitle.Text = "Сводка:";
            // 
            // labelTotalOrders
            // 
            this.labelTotalOrders.AutoSize = true;
            this.labelTotalOrders.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTotalOrders.Location = new System.Drawing.Point(90, 32);
            this.labelTotalOrders.Name = "labelTotalOrders";
            this.labelTotalOrders.Size = new System.Drawing.Size(98, 19);
            this.labelTotalOrders.TabIndex = 1;
            this.labelTotalOrders.Text = "Всего заказов:";
            // 
            // labelTotalOrdersValue
            // 
            this.labelTotalOrdersValue.AutoSize = true;
            this.labelTotalOrdersValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.labelTotalOrdersValue.Location = new System.Drawing.Point(190, 32);
            this.labelTotalOrdersValue.Name = "labelTotalOrdersValue";
            this.labelTotalOrdersValue.Size = new System.Drawing.Size(17, 19);
            this.labelTotalOrdersValue.TabIndex = 2;
            this.labelTotalOrdersValue.Text = "0";
            // 
            // labelTotalHouseRevenue
            // 
            this.labelTotalHouseRevenue.AutoSize = true;
            this.labelTotalHouseRevenue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTotalHouseRevenue.Location = new System.Drawing.Point(234, 32);
            this.labelTotalHouseRevenue.Name = "labelTotalHouseRevenue";
            this.labelTotalHouseRevenue.Size = new System.Drawing.Size(160, 19);
            this.labelTotalHouseRevenue.TabIndex = 3;
            this.labelTotalHouseRevenue.Text = "Выручка с проживания:";
            // 
            // labelTotalHouseRevenueValue
            // 
            this.labelTotalHouseRevenueValue.AutoSize = true;
            this.labelTotalHouseRevenueValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.labelTotalHouseRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.labelTotalHouseRevenueValue.Location = new System.Drawing.Point(400, 32);
            this.labelTotalHouseRevenueValue.Name = "labelTotalHouseRevenueValue";
            this.labelTotalHouseRevenueValue.Size = new System.Drawing.Size(29, 19);
            this.labelTotalHouseRevenueValue.TabIndex = 4;
            this.labelTotalHouseRevenueValue.Text = "0 ₽";
            // 
            // labelTotalServicesRevenue
            // 
            this.labelTotalServicesRevenue.AutoSize = true;
            this.labelTotalServicesRevenue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTotalServicesRevenue.Location = new System.Drawing.Point(467, 32);
            this.labelTotalServicesRevenue.Name = "labelTotalServicesRevenue";
            this.labelTotalServicesRevenue.Size = new System.Drawing.Size(113, 19);
            this.labelTotalServicesRevenue.TabIndex = 5;
            this.labelTotalServicesRevenue.Text = "Выручка с услуг:";
            // 
            // labelTotalServicesRevenueValue
            // 
            this.labelTotalServicesRevenueValue.AutoSize = true;
            this.labelTotalServicesRevenueValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.labelTotalServicesRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelTotalServicesRevenueValue.Location = new System.Drawing.Point(587, 32);
            this.labelTotalServicesRevenueValue.Name = "labelTotalServicesRevenueValue";
            this.labelTotalServicesRevenueValue.Size = new System.Drawing.Size(29, 19);
            this.labelTotalServicesRevenueValue.TabIndex = 6;
            this.labelTotalServicesRevenueValue.Text = "0 ₽";
            // 
            // labelTotalRevenue
            // 
            this.labelTotalRevenue.AutoSize = true;
            this.labelTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTotalRevenue.Location = new System.Drawing.Point(670, 32);
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
            this.labelTotalRevenueValue.Location = new System.Drawing.Point(780, 30);
            this.labelTotalRevenueValue.Name = "labelTotalRevenueValue";
            this.labelTotalRevenueValue.Size = new System.Drawing.Size(55, 21);
            this.labelTotalRevenueValue.TabIndex = 8;
            this.labelTotalRevenueValue.Text = "0,00 ₽";
            // 
            // labelAverageCheck
            // 
            this.labelAverageCheck.AutoSize = true;
            this.labelAverageCheck.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelAverageCheck.Location = new System.Drawing.Point(903, 32);
            this.labelAverageCheck.Name = "labelAverageCheck";
            this.labelAverageCheck.Size = new System.Drawing.Size(94, 19);
            this.labelAverageCheck.TabIndex = 9;
            this.labelAverageCheck.Text = "Средний чек:";
            // 
            // labelAverageCheckValue
            // 
            this.labelAverageCheckValue.AutoSize = true;
            this.labelAverageCheckValue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.labelAverageCheckValue.Location = new System.Drawing.Point(1003, 32);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 578);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1151, 22);
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
            // HouseReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HouseReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёт по домам";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).EndInit();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHouseClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookings;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRevenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvgStay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOccupancy;
    }
}