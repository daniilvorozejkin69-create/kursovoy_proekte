namespace kursovoy_proekt
{
    partial class HouseAnalyticsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label labelFilterTitle;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.ComboBox comboBoxClass;
        private System.Windows.Forms.Button buttonApplyFilter;
        private System.Windows.Forms.Button buttonResetFilter;
        private System.Windows.Forms.Label labelHousesTitle;
        private System.Windows.Forms.ListBox listBoxHouses;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Label labelChartTitle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label labelCardTitle;
        private System.Windows.Forms.Panel panelHouseCard;
        private System.Windows.Forms.Label labelHouseName;
        private System.Windows.Forms.Label labelHouseClass;
        private System.Windows.Forms.Label labelPopularity;
        private System.Windows.Forms.Label labelHouseCapacity;
        private System.Windows.Forms.Label labelTotalBookings;
        private System.Windows.Forms.Label labelAvgStay;
        private System.Windows.Forms.Label labelTotalRevenue;
        private System.Windows.Forms.Label labelUniqueClients;
        private System.Windows.Forms.Label labelOccupancyRate;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDemand;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.labelFilterTitle = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.buttonApplyFilter = new System.Windows.Forms.Button();
            this.buttonResetFilter = new System.Windows.Forms.Button();
            this.labelHousesTitle = new System.Windows.Forms.Label();
            this.listBoxHouses = new System.Windows.Forms.ListBox();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.labelChartTitle = new System.Windows.Forms.Label();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelRight = new System.Windows.Forms.Panel();
            this.labelCardTitle = new System.Windows.Forms.Label();
            this.panelHouseCard = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1184, 65);
            this.panelHeader.TabIndex = 1;
            // 
            // labelHeader
            // 
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 22F);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.labelHeader.Size = new System.Drawing.Size(1184, 65);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "📊 Аналитика спроса на дома";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelLeft);
            this.panelContent.Controls.Add(this.panelCenter);
            this.panelContent.Controls.Add(this.panelRight);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 65);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(15);
            this.panelContent.Size = new System.Drawing.Size(1184, 666);
            this.panelContent.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.labelFilterTitle);
            this.panelLeft.Controls.Add(this.labelFrom);
            this.panelLeft.Controls.Add(this.dateTimePickerFrom);
            this.panelLeft.Controls.Add(this.labelTo);
            this.panelLeft.Controls.Add(this.dateTimePickerTo);
            this.panelLeft.Controls.Add(this.comboBoxClass);
            this.panelLeft.Controls.Add(this.buttonApplyFilter);
            this.panelLeft.Controls.Add(this.buttonResetFilter);
            this.panelLeft.Controls.Add(this.labelHousesTitle);
            this.panelLeft.Controls.Add(this.listBoxHouses);
            this.panelLeft.Location = new System.Drawing.Point(15, 15);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(250, 640);
            this.panelLeft.TabIndex = 0;
            // 
            // labelFilterTitle
            // 
            this.labelFilterTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelFilterTitle.Location = new System.Drawing.Point(15, 15);
            this.labelFilterTitle.Name = "labelFilterTitle";
            this.labelFilterTitle.Size = new System.Drawing.Size(220, 25);
            this.labelFilterTitle.TabIndex = 0;
            this.labelFilterTitle.Text = "Фильтры";
            // 
            // labelFrom
            // 
            this.labelFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelFrom.Location = new System.Drawing.Point(15, 50);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(100, 18);
            this.labelFrom.TabIndex = 1;
            this.labelFrom.Text = "Период с:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(15, 70);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(220, 20);
            this.dateTimePickerFrom.TabIndex = 2;
            this.dateTimePickerFrom.Value = new System.DateTime(2025, 10, 30, 0, 0, 0, 0);
            // 
            // labelTo
            // 
            this.labelTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelTo.Location = new System.Drawing.Point(15, 100);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(100, 18);
            this.labelTo.TabIndex = 3;
            this.labelTo.Text = "Период по:";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(15, 120);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(220, 20);
            this.dateTimePickerTo.TabIndex = 4;
            this.dateTimePickerTo.Value = new System.DateTime(2026, 4, 30, 0, 0, 0, 0);
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClass.Items.AddRange(new object[] {
            "Все классы",
            "Эконом",
            "Комфорт",
            "Люкс",
            "Премиум",
            "Бизнес"});
            this.comboBoxClass.Location = new System.Drawing.Point(15, 170);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(220, 21);
            this.comboBoxClass.TabIndex = 5;
            // 
            // buttonApplyFilter
            // 
            this.buttonApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonApplyFilter.FlatAppearance.BorderSize = 0;
            this.buttonApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApplyFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.buttonApplyFilter.ForeColor = System.Drawing.Color.White;
            this.buttonApplyFilter.Location = new System.Drawing.Point(15, 210);
            this.buttonApplyFilter.Name = "buttonApplyFilter";
            this.buttonApplyFilter.Size = new System.Drawing.Size(105, 35);
            this.buttonApplyFilter.TabIndex = 6;
            this.buttonApplyFilter.Text = "🔄 Применить";
            this.buttonApplyFilter.UseVisualStyleBackColor = false;
            this.buttonApplyFilter.Click += new System.EventHandler(this.buttonApplyFilter_Click);
            // 
            // buttonResetFilter
            // 
            this.buttonResetFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonResetFilter.FlatAppearance.BorderSize = 0;
            this.buttonResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.buttonResetFilter.ForeColor = System.Drawing.Color.White;
            this.buttonResetFilter.Location = new System.Drawing.Point(130, 210);
            this.buttonResetFilter.Name = "buttonResetFilter";
            this.buttonResetFilter.Size = new System.Drawing.Size(105, 35);
            this.buttonResetFilter.TabIndex = 7;
            this.buttonResetFilter.Text = "🗑 Сбросить";
            this.buttonResetFilter.UseVisualStyleBackColor = false;
            this.buttonResetFilter.Click += new System.EventHandler(this.buttonResetFilter_Click);
            // 
            // labelHousesTitle
            // 
            this.labelHousesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.labelHousesTitle.Location = new System.Drawing.Point(15, 260);
            this.labelHousesTitle.Name = "labelHousesTitle";
            this.labelHousesTitle.Size = new System.Drawing.Size(220, 25);
            this.labelHousesTitle.TabIndex = 8;
            this.labelHousesTitle.Text = "Дома:";
            // 
            // listBoxHouses
            // 
            this.listBoxHouses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxHouses.Location = new System.Drawing.Point(15, 290);
            this.listBoxHouses.Name = "listBoxHouses";
            this.listBoxHouses.Size = new System.Drawing.Size(220, 340);
            this.listBoxHouses.TabIndex = 9;
            this.listBoxHouses.SelectedIndexChanged += new System.EventHandler(this.listBoxHouses_SelectedIndexChanged);
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.White;
            this.panelCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCenter.Controls.Add(this.labelChartTitle);
            this.panelCenter.Controls.Add(this.chartMain);
            this.panelCenter.Location = new System.Drawing.Point(280, 15);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(560, 640);
            this.panelCenter.TabIndex = 1;
            // 
            // labelChartTitle
            // 
            this.labelChartTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelChartTitle.Location = new System.Drawing.Point(15, 15);
            this.labelChartTitle.Name = "labelChartTitle";
            this.labelChartTitle.Size = new System.Drawing.Size(530, 25);
            this.labelChartTitle.TabIndex = 0;
            this.labelChartTitle.Text = "Загрузка домов и доход";
            // 
            // chartMain
            // 
            chartArea1.AxisX.LabelStyle.Angle = -45;
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.Name = "MainArea";
            this.chartMain.ChartAreas.Add(chartArea1);
            this.chartMain.Location = new System.Drawing.Point(15, 50);
            this.chartMain.Name = "chartMain";
            this.chartMain.Size = new System.Drawing.Size(530, 575);
            this.chartMain.TabIndex = 1;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.labelCardTitle);
            this.panelRight.Controls.Add(this.panelHouseCard);
            this.panelRight.Location = new System.Drawing.Point(855, 15);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(310, 640);
            this.panelRight.TabIndex = 2;
            // 
            // labelCardTitle
            // 
            this.labelCardTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelCardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.labelCardTitle.Location = new System.Drawing.Point(15, 280);
            this.labelCardTitle.Name = "labelCardTitle";
            this.labelCardTitle.Size = new System.Drawing.Size(280, 40);
            this.labelCardTitle.TabIndex = 0;
            this.labelCardTitle.Text = "Выберите дом в списке";
            this.labelCardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHouseCard
            // 
            this.panelHouseCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(245)))));
            this.panelHouseCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHouseCard.Location = new System.Drawing.Point(10, 10);
            this.panelHouseCard.Name = "panelHouseCard";
            this.panelHouseCard.Size = new System.Drawing.Size(290, 620);
            this.panelHouseCard.TabIndex = 1;
            this.panelHouseCard.Visible = false;
            // 
            // HouseAnalyticsForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1184, 731);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Name = "HouseAnalyticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аналитика спроса на дома";
            this.panelHeader.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}