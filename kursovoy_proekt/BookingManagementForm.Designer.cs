namespace kursovoy_proekt
{
    partial class BookingManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;

        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Label labelDateFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerFilterFrom;
        private System.Windows.Forms.Label labelDateTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFilterTo;
        private System.Windows.Forms.CheckBox checkBoxFilterByDate;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxFilterStatus;
        private System.Windows.Forms.Label labelHouse;
        private System.Windows.Forms.ComboBox comboBoxFilterHouse;

        private System.Windows.Forms.Button buttonApplyFilter;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonExport;

        private System.Windows.Forms.Label labelStatistics;
        private System.Windows.Forms.DataGridView dataGridViewBookings;

        private System.Windows.Forms.Button buttonBackToMenu;

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
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.buttonApplyFilter = new System.Windows.Forms.Button();
            this.labelStatistics = new System.Windows.Forms.Label();
            this.dataGridViewBookings = new System.Windows.Forms.DataGridView();
            this.comboBoxFilterHouse = new System.Windows.Forms.ComboBox();
            this.labelHouse = new System.Windows.Forms.Label();
            this.comboBoxFilterStatus = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.checkBoxFilterByDate = new System.Windows.Forms.CheckBox();
            this.dateTimePickerFilterTo = new System.Windows.Forms.DateTimePicker();
            this.labelDateTo = new System.Windows.Forms.Label();
            this.dateTimePickerFilterFrom = new System.Windows.Forms.DateTimePicker();
            this.labelDateFrom = new System.Windows.Forms.Label();
            this.labelFilter = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookings)).BeginInit();
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
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(30, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(438, 45);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Управление бронированиями";
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
            this.panelContent.Controls.Add(this.buttonBackToMenu);
            this.panelContent.Controls.Add(this.buttonExport);
            this.panelContent.Controls.Add(this.buttonRefresh);
            this.panelContent.Controls.Add(this.buttonClearFilter);
            this.panelContent.Controls.Add(this.buttonApplyFilter);
            this.panelContent.Controls.Add(this.labelStatistics);
            this.panelContent.Controls.Add(this.dataGridViewBookings);
            this.panelContent.Controls.Add(this.comboBoxFilterHouse);
            this.panelContent.Controls.Add(this.labelHouse);
            this.panelContent.Controls.Add(this.comboBoxFilterStatus);
            this.panelContent.Controls.Add(this.labelStatus);
            this.panelContent.Controls.Add(this.checkBoxFilterByDate);
            this.panelContent.Controls.Add(this.dateTimePickerFilterTo);
            this.panelContent.Controls.Add(this.labelDateTo);
            this.panelContent.Controls.Add(this.dateTimePickerFilterFrom);
            this.panelContent.Controls.Add(this.labelDateFrom);
            this.panelContent.Controls.Add(this.labelFilter);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 83);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(1200, 717);
            this.panelContent.TabIndex = 2;
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonBackToMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonBackToMenu.FlatAppearance.BorderSize = 2;
            this.buttonBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackToMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonBackToMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonBackToMenu.Location = new System.Drawing.Point(1020, 630);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(160, 50);
            this.buttonBackToMenu.TabIndex = 17;
            this.buttonBackToMenu.Text = "🏠 В меню";
            this.buttonBackToMenu.UseVisualStyleBackColor = false;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonExport.FlatAppearance.BorderSize = 0;
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.Location = new System.Drawing.Point(1020, 150);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(160, 35);
            this.buttonExport.TabIndex = 16;
            this.buttonExport.Text = "📊 Экспорт";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(1020, 105);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(160, 35);
            this.buttonRefresh.TabIndex = 15;
            this.buttonRefresh.Text = "🔄 Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonClearFilter.FlatAppearance.BorderSize = 0;
            this.buttonClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonClearFilter.ForeColor = System.Drawing.Color.White;
            this.buttonClearFilter.Location = new System.Drawing.Point(840, 150);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(160, 35);
            this.buttonClearFilter.TabIndex = 14;
            this.buttonClearFilter.Text = "🧹 Сбросить фильтры";
            this.buttonClearFilter.UseVisualStyleBackColor = false;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // buttonApplyFilter
            // 
            this.buttonApplyFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonApplyFilter.FlatAppearance.BorderSize = 0;
            this.buttonApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApplyFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonApplyFilter.ForeColor = System.Drawing.Color.White;
            this.buttonApplyFilter.Location = new System.Drawing.Point(840, 105);
            this.buttonApplyFilter.Name = "buttonApplyFilter";
            this.buttonApplyFilter.Size = new System.Drawing.Size(160, 35);
            this.buttonApplyFilter.TabIndex = 13;
            this.buttonApplyFilter.Text = "🔍 Применить фильтры";
            this.buttonApplyFilter.UseVisualStyleBackColor = false;
            this.buttonApplyFilter.Click += new System.EventHandler(this.buttonApplyFilter_Click);
            // 
            // labelStatistics
            // 
            this.labelStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatistics.BackColor = System.Drawing.Color.White;
            this.labelStatistics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStatistics.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelStatistics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelStatistics.Location = new System.Drawing.Point(20, 630);
            this.labelStatistics.Name = "labelStatistics";
            this.labelStatistics.Padding = new System.Windows.Forms.Padding(10);
            this.labelStatistics.Size = new System.Drawing.Size(980, 50);
            this.labelStatistics.TabIndex = 12;
            this.labelStatistics.Text = "Статистика загружается...";
            this.labelStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewBookings
            // 
            this.dataGridViewBookings.AllowUserToAddRows = false;
            this.dataGridViewBookings.AllowUserToDeleteRows = false;
            this.dataGridViewBookings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBookings.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBookings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewBookings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewBookings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBookings.ColumnHeadersHeight = 40;
            this.dataGridViewBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBookings.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBookings.EnableHeadersVisualStyles = false;
            this.dataGridViewBookings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            this.dataGridViewBookings.Location = new System.Drawing.Point(20, 200);
            this.dataGridViewBookings.Name = "dataGridViewBookings";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBookings.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBookings.RowHeadersVisible = false;
            this.dataGridViewBookings.RowTemplate.Height = 35;
            this.dataGridViewBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBookings.Size = new System.Drawing.Size(1160, 420);
            this.dataGridViewBookings.TabIndex = 11;
            // 
            // comboBoxFilterHouse
            // 
            this.comboBoxFilterHouse.BackColor = System.Drawing.Color.White;
            this.comboBoxFilterHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxFilterHouse.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.comboBoxFilterHouse.FormattingEnabled = true;
            this.comboBoxFilterHouse.Location = new System.Drawing.Point(580, 105);
            this.comboBoxFilterHouse.Name = "comboBoxFilterHouse";
            this.comboBoxFilterHouse.Size = new System.Drawing.Size(240, 25);
            this.comboBoxFilterHouse.TabIndex = 10;
            // 
            // labelHouse
            // 
            this.labelHouse.AutoSize = true;
            this.labelHouse.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelHouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouse.Location = new System.Drawing.Point(580, 85);
            this.labelHouse.Name = "labelHouse";
            this.labelHouse.Size = new System.Drawing.Size(114, 17);
            this.labelHouse.TabIndex = 9;
            this.labelHouse.Text = "Фильтр по дому:";
            // 
            // comboBoxFilterStatus
            // 
            this.comboBoxFilterStatus.BackColor = System.Drawing.Color.White;
            this.comboBoxFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.comboBoxFilterStatus.FormattingEnabled = true;
            this.comboBoxFilterStatus.Location = new System.Drawing.Point(320, 105);
            this.comboBoxFilterStatus.Name = "comboBoxFilterStatus";
            this.comboBoxFilterStatus.Size = new System.Drawing.Size(240, 25);
            this.comboBoxFilterStatus.TabIndex = 8;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelStatus.Location = new System.Drawing.Point(320, 85);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(126, 17);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Фильтр по статусу:";
            // 
            // checkBoxFilterByDate
            // 
            this.checkBoxFilterByDate.AutoSize = true;
            this.checkBoxFilterByDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.checkBoxFilterByDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxFilterByDate.Location = new System.Drawing.Point(20, 85);
            this.checkBoxFilterByDate.Name = "checkBoxFilterByDate";
            this.checkBoxFilterByDate.Size = new System.Drawing.Size(131, 21);
            this.checkBoxFilterByDate.TabIndex = 6;
            this.checkBoxFilterByDate.Text = "Фильтр по датам:";
            this.checkBoxFilterByDate.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerFilterTo
            // 
            this.dateTimePickerFilterTo.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerFilterTo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateTimePickerFilterTo.Location = new System.Drawing.Point(170, 105);
            this.dateTimePickerFilterTo.Name = "dateTimePickerFilterTo";
            this.dateTimePickerFilterTo.Size = new System.Drawing.Size(130, 25);
            this.dateTimePickerFilterTo.TabIndex = 5;
            // 
            // labelDateTo
            // 
            this.labelDateTo.AutoSize = true;
            this.labelDateTo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelDateTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDateTo.Location = new System.Drawing.Point(170, 85);
            this.labelDateTo.Name = "labelDateTo";
            this.labelDateTo.Size = new System.Drawing.Size(29, 17);
            this.labelDateTo.TabIndex = 4;
            this.labelDateTo.Text = "По:";
            // 
            // dateTimePickerFilterFrom
            // 
            this.dateTimePickerFilterFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerFilterFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateTimePickerFilterFrom.Location = new System.Drawing.Point(20, 105);
            this.dateTimePickerFilterFrom.Name = "dateTimePickerFilterFrom";
            this.dateTimePickerFilterFrom.Size = new System.Drawing.Size(130, 25);
            this.dateTimePickerFilterFrom.TabIndex = 3;
            // 
            // labelDateFrom
            // 
            this.labelDateFrom.AutoSize = true;
            this.labelDateFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelDateFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDateFrom.Location = new System.Drawing.Point(20, 85);
            this.labelDateFrom.Name = "labelDateFrom";
            this.labelDateFrom.Size = new System.Drawing.Size(19, 17);
            this.labelDateFrom.TabIndex = 2;
            this.labelDateFrom.Text = "С:";
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelFilter.Location = new System.Drawing.Point(20, 30);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(216, 25);
            this.labelFilter.TabIndex = 0;
            this.labelFilter.Text = "Фильтры и параметры:";
            // 
            // BookingManagementForm
            // 
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1216, 839);
            this.Name = "BookingManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление бронированиями - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookings)).EndInit();
            this.ResumeLayout(false);

        }
    }
}