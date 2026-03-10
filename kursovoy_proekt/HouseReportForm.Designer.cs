namespace kursovoy_proekt
{
    partial class HouseReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelReport = new System.Windows.Forms.Panel();
            this.dataGridViewReport = new System.Windows.Forms.DataGridView();
            this.panelStats = new System.Windows.Forms.Panel();
            this.groupStats = new System.Windows.Forms.GroupBox();
            this.labelTotalBookingsTitle = new System.Windows.Forms.Label();
            this.labelTotalBookings = new System.Windows.Forms.Label();
            this.labelTotalRevenueTitle = new System.Windows.Forms.Label();
            this.labelTotalRevenue = new System.Windows.Forms.Label();
            this.labelAvgOccupancyTitle = new System.Windows.Forms.Label();
            this.labelAvgOccupancy = new System.Windows.Forms.Label();
            this.labelPopularHouseTitle = new System.Windows.Forms.Label();
            this.labelPopularHouse = new System.Windows.Forms.Label();
            this.labelHouseRevenueTitle = new System.Windows.Forms.Label();
            this.labelHouseRevenue = new System.Windows.Forms.Label();
            this.labelServiceRevenueTitle = new System.Windows.Forms.Label();
            this.labelServiceRevenue = new System.Windows.Forms.Label();
            this.labelPeriodInfo = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).BeginInit();
            this.panelStats.SuspendLayout();
            this.groupStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Controls.Add(this.panelReport);
            this.panelMain.Controls.Add(this.panelStats);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Size = new System.Drawing.Size(1100, 700);
            this.panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.labelPeriod);
            this.panelTop.Controls.Add(this.dateTimePickerStart);
            this.panelTop.Controls.Add(this.dateTimePickerEnd);
            this.panelTop.Controls.Add(this.labelTo);
            this.panelTop.Controls.Add(this.buttonGenerate);
            this.panelTop.Controls.Add(this.buttonRefresh);
            this.panelTop.Controls.Add(this.buttonExport);
            this.panelTop.Controls.Add(this.buttonPrint);
            this.panelTop.Controls.Add(this.buttonExcel);
            this.panelTop.Controls.Add(this.buttonClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(10, 10);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1080, 70);
            this.panelTop.TabIndex = 0;
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelPeriod.Location = new System.Drawing.Point(15, 25);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(68, 19);
            this.labelPeriod.TabIndex = 0;
            this.labelPeriod.Text = "Период:";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStart.Location = new System.Drawing.Point(89, 22);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(120, 25);
            this.dateTimePickerStart.TabIndex = 1;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(269, 22);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(120, 25);
            this.dateTimePickerEnd.TabIndex = 3;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTo.Location = new System.Drawing.Point(239, 25);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(25, 19);
            this.labelTo.TabIndex = 2;
            this.labelTo.Text = "по";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.buttonGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonGenerate.ForeColor = System.Drawing.Color.White;
            this.buttonGenerate.Location = new System.Drawing.Point(404, 20);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(100, 30);
            this.buttonGenerate.TabIndex = 4;
            this.buttonGenerate.Text = "📊 Сформировать";
            this.buttonGenerate.UseVisualStyleBackColor = false;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(514, 20);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(80, 30);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "🔄 Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.Location = new System.Drawing.Point(604, 20);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(80, 30);
            this.buttonExport.TabIndex = 6;
            this.buttonExport.Text = "📁 CSV";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonPrint.ForeColor = System.Drawing.Color.White;
            this.buttonPrint.Location = new System.Drawing.Point(784, 20);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(80, 30);
            this.buttonPrint.TabIndex = 8;
            this.buttonPrint.Text = "🖨️ Печать";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.buttonExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonExcel.ForeColor = System.Drawing.Color.White;
            this.buttonExcel.Location = new System.Drawing.Point(694, 20);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(80, 30);
            this.buttonExcel.TabIndex = 7;
            this.buttonExcel.Text = "📗 Excel";
            this.buttonExcel.UseVisualStyleBackColor = false;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(980, 20);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 30);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "✖️ Закрыть";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelReport
            // 
            this.panelReport.BackColor = System.Drawing.Color.White;
            this.panelReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReport.Controls.Add(this.dataGridViewReport);
            this.panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReport.Location = new System.Drawing.Point(10, 10);
            this.panelReport.Name = "panelReport";
            this.panelReport.Padding = new System.Windows.Forms.Padding(10);
            this.panelReport.Size = new System.Drawing.Size(1080, 520);
            this.panelReport.TabIndex = 1;
            // 
            // dataGridViewReport
            // 
            this.dataGridViewReport.AllowUserToAddRows = false;
            this.dataGridViewReport.AllowUserToDeleteRows = false;
            this.dataGridViewReport.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewReport.ColumnHeadersHeight = 35;
            this.dataGridViewReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReport.EnableHeadersVisualStyles = false;
            this.dataGridViewReport.GridColor = System.Drawing.Color.LightGray;
            this.dataGridViewReport.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewReport.Name = "dataGridViewReport";
            this.dataGridViewReport.ReadOnly = true;
            this.dataGridViewReport.RowHeadersVisible = false;
            this.dataGridViewReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReport.Size = new System.Drawing.Size(1058, 498);
            this.dataGridViewReport.TabIndex = 0;
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.White;
            this.panelStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStats.Controls.Add(this.groupStats);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStats.Location = new System.Drawing.Point(10, 530);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(10);
            this.panelStats.Size = new System.Drawing.Size(1080, 160);
            this.panelStats.TabIndex = 2;
            // 
            // groupStats
            // 
            this.groupStats.Controls.Add(this.labelTotalBookingsTitle);
            this.groupStats.Controls.Add(this.labelTotalBookings);
            this.groupStats.Controls.Add(this.labelTotalRevenueTitle);
            this.groupStats.Controls.Add(this.labelTotalRevenue);
            this.groupStats.Controls.Add(this.labelAvgOccupancyTitle);
            this.groupStats.Controls.Add(this.labelAvgOccupancy);
            this.groupStats.Controls.Add(this.labelPopularHouseTitle);
            this.groupStats.Controls.Add(this.labelPopularHouse);
            this.groupStats.Controls.Add(this.labelHouseRevenueTitle);
            this.groupStats.Controls.Add(this.labelHouseRevenue);
            this.groupStats.Controls.Add(this.labelServiceRevenueTitle);
            this.groupStats.Controls.Add(this.labelServiceRevenue);
            this.groupStats.Controls.Add(this.labelPeriodInfo);
            this.groupStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupStats.Location = new System.Drawing.Point(10, 10);
            this.groupStats.Name = "groupStats";
            this.groupStats.Size = new System.Drawing.Size(1058, 138);
            this.groupStats.TabIndex = 0;
            this.groupStats.TabStop = false;
            this.groupStats.Text = "ИТОГОВАЯ СТАТИСТИКА";
            // 
            // labelTotalBookingsTitle
            // 
            this.labelTotalBookingsTitle.AutoSize = true;
            this.labelTotalBookingsTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTotalBookingsTitle.Location = new System.Drawing.Point(20, 30);
            this.labelTotalBookingsTitle.Name = "labelTotalBookingsTitle";
            this.labelTotalBookingsTitle.Size = new System.Drawing.Size(144, 19);
            this.labelTotalBookingsTitle.TabIndex = 0;
            this.labelTotalBookingsTitle.Text = "Всего бронирований:";
            // 
            // labelTotalBookings
            // 
            this.labelTotalBookings.AutoSize = true;
            this.labelTotalBookings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalBookings.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelTotalBookings.Location = new System.Drawing.Point(170, 28);
            this.labelTotalBookings.Name = "labelTotalBookings";
            this.labelTotalBookings.Size = new System.Drawing.Size(37, 21);
            this.labelTotalBookings.TabIndex = 1;
            this.labelTotalBookings.Text = "125";
            // 
            // labelTotalRevenueTitle
            // 
            this.labelTotalRevenueTitle.AutoSize = true;
            this.labelTotalRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTotalRevenueTitle.Location = new System.Drawing.Point(20, 60);
            this.labelTotalRevenueTitle.Name = "labelTotalRevenueTitle";
            this.labelTotalRevenueTitle.Size = new System.Drawing.Size(101, 19);
            this.labelTotalRevenueTitle.TabIndex = 2;
            this.labelTotalRevenueTitle.Text = "Общий доход:";
            // 
            // labelTotalRevenue
            // 
            this.labelTotalRevenue.AutoSize = true;
            this.labelTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalRevenue.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelTotalRevenue.Location = new System.Drawing.Point(120, 58);
            this.labelTotalRevenue.Name = "labelTotalRevenue";
            this.labelTotalRevenue.Size = new System.Drawing.Size(103, 21);
            this.labelTotalRevenue.TabIndex = 3;
            this.labelTotalRevenue.Text = "1 250 000.00";
            // 
            // labelAvgOccupancyTitle
            // 
            this.labelAvgOccupancyTitle.AutoSize = true;
            this.labelAvgOccupancyTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelAvgOccupancyTitle.Location = new System.Drawing.Point(350, 30);
            this.labelAvgOccupancyTitle.Name = "labelAvgOccupancyTitle";
            this.labelAvgOccupancyTitle.Size = new System.Drawing.Size(123, 19);
            this.labelAvgOccupancyTitle.TabIndex = 4;
            this.labelAvgOccupancyTitle.Text = "Средняя загрузка:";
            // 
            // labelAvgOccupancy
            // 
            this.labelAvgOccupancy.AutoSize = true;
            this.labelAvgOccupancy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelAvgOccupancy.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelAvgOccupancy.Location = new System.Drawing.Point(470, 28);
            this.labelAvgOccupancy.Name = "labelAvgOccupancy";
            this.labelAvgOccupancy.Size = new System.Drawing.Size(55, 21);
            this.labelAvgOccupancy.TabIndex = 5;
            this.labelAvgOccupancy.Text = "67.5%";
            // 
            // labelPopularHouseTitle
            // 
            this.labelPopularHouseTitle.AutoSize = true;
            this.labelPopularHouseTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelPopularHouseTitle.Location = new System.Drawing.Point(350, 60);
            this.labelPopularHouseTitle.Name = "labelPopularHouseTitle";
            this.labelPopularHouseTitle.Size = new System.Drawing.Size(139, 19);
            this.labelPopularHouseTitle.TabIndex = 6;
            this.labelPopularHouseTitle.Text = "Самый популярный:";
            // 
            // labelPopularHouse
            // 
            this.labelPopularHouse.AutoSize = true;
            this.labelPopularHouse.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelPopularHouse.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelPopularHouse.Location = new System.Drawing.Point(500, 58);
            this.labelPopularHouse.Name = "labelPopularHouse";
            this.labelPopularHouse.Size = new System.Drawing.Size(135, 20);
            this.labelPopularHouse.TabIndex = 7;
            this.labelPopularHouse.Text = "Коттедж Уютный";
            // 
            // labelHouseRevenueTitle
            // 
            this.labelHouseRevenueTitle.AutoSize = true;
            this.labelHouseRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelHouseRevenueTitle.Location = new System.Drawing.Point(700, 30);
            this.labelHouseRevenueTitle.Name = "labelHouseRevenueTitle";
            this.labelHouseRevenueTitle.Size = new System.Drawing.Size(153, 19);
            this.labelHouseRevenueTitle.TabIndex = 8;
            this.labelHouseRevenueTitle.Text = "Доход от проживания:";
            // 
            // labelHouseRevenue
            // 
            this.labelHouseRevenue.AutoSize = true;
            this.labelHouseRevenue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelHouseRevenue.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelHouseRevenue.Location = new System.Drawing.Point(859, 28);
            this.labelHouseRevenue.Name = "labelHouseRevenue";
            this.labelHouseRevenue.Size = new System.Drawing.Size(89, 20);
            this.labelHouseRevenue.TabIndex = 9;
            this.labelHouseRevenue.Text = "980 000.00";
            // 
            // labelServiceRevenueTitle
            // 
            this.labelServiceRevenueTitle.AutoSize = true;
            this.labelServiceRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelServiceRevenueTitle.Location = new System.Drawing.Point(700, 60);
            this.labelServiceRevenueTitle.Name = "labelServiceRevenueTitle";
            this.labelServiceRevenueTitle.Size = new System.Drawing.Size(137, 19);
            this.labelServiceRevenueTitle.TabIndex = 10;
            this.labelServiceRevenueTitle.Text = "Доход от доп. услуг:";
            // 
            // labelServiceRevenue
            // 
            this.labelServiceRevenue.AutoSize = true;
            this.labelServiceRevenue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelServiceRevenue.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelServiceRevenue.Location = new System.Drawing.Point(843, 58);
            this.labelServiceRevenue.Name = "labelServiceRevenue";
            this.labelServiceRevenue.Size = new System.Drawing.Size(89, 20);
            this.labelServiceRevenue.TabIndex = 11;
            this.labelServiceRevenue.Text = "270 000.00";
            // 
            // labelPeriodInfo
            // 
            this.labelPeriodInfo.AutoSize = true;
            this.labelPeriodInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.labelPeriodInfo.ForeColor = System.Drawing.Color.Gray;
            this.labelPeriodInfo.Location = new System.Drawing.Point(20, 100);
            this.labelPeriodInfo.Name = "labelPeriodInfo";
            this.labelPeriodInfo.Size = new System.Drawing.Size(142, 15);
            this.labelPeriodInfo.TabIndex = 12;
            this.labelPeriodInfo.Text = "с 01.01.2025 по 31.01.2025";
            // 
            // HouseReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HouseReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёт по домам";
            this.panelMain.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).EndInit();
            this.panelStats.ResumeLayout(false);
            this.groupStats.ResumeLayout(false);
            this.groupStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelReport;
        private System.Windows.Forms.DataGridView dataGridViewReport;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.GroupBox groupStats;
        private System.Windows.Forms.Label labelTotalBookingsTitle;
        private System.Windows.Forms.Label labelTotalBookings;
        private System.Windows.Forms.Label labelTotalRevenueTitle;
        private System.Windows.Forms.Label labelTotalRevenue;
        private System.Windows.Forms.Label labelAvgOccupancyTitle;
        private System.Windows.Forms.Label labelAvgOccupancy;
        private System.Windows.Forms.Label labelPopularHouseTitle;
        private System.Windows.Forms.Label labelPopularHouse;
        private System.Windows.Forms.Label labelHouseRevenueTitle;
        private System.Windows.Forms.Label labelHouseRevenue;
        private System.Windows.Forms.Label labelServiceRevenueTitle;
        private System.Windows.Forms.Label labelServiceRevenue;
        private System.Windows.Forms.Label labelPeriodInfo;
    }
}