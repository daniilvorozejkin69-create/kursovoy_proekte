namespace kursovoy_proekt
{
    partial class OrdersViewForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            // panelHeader
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();

            // panelGreenLine
            this.panelGreenLine = new System.Windows.Forms.Panel();

            // panelContent
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelContent.SuspendLayout();

            // labelFilter
            this.labelFilter = new System.Windows.Forms.Label();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelDateFrom = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelDateTo = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxStatusFilter = new System.Windows.Forms.ComboBox();
            this.labelHouse = new System.Windows.Forms.Label();
            this.comboBoxHouseFilter = new System.Windows.Forms.ComboBox();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.labelStatistics = new System.Windows.Forms.Label();
            this.buttonApplyFilter = new System.Windows.Forms.Button();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonBackToMenu = new System.Windows.Forms.Button();

            // ========== НОВЫЕ ЭЛЕМЕНТЫ ДЛЯ ЛЕГЕНДЫ ==========
            this.panelLegend = new System.Windows.Forms.Panel();
            this.labelLegendTitle = new System.Windows.Forms.Label();

            // Активный
            this.panelActiveColor = new System.Windows.Forms.Panel();
            this.labelActiveText = new System.Windows.Forms.Label();

            // Отменён
            this.panelCancelledColor = new System.Windows.Forms.Panel();
            this.labelCancelledText = new System.Windows.Forms.Label();

            // Завершён
            this.panelCompletedColor = new System.Windows.Forms.Panel();
            this.labelCompletedText = new System.Windows.Forms.Label();

            // === ПАНЕЛЬ ЗАГОЛОВКА ===
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 80);
            this.panelHeader.TabIndex = 0;

            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(30, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(324, 45);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Управление заказами";

            // === ЗЕЛЕНАЯ ЛИНИЯ ===
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 80);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(1200, 3);
            this.panelGreenLine.TabIndex = 1;

            // === ОСНОВНАЯ ПАНЕЛЬ С КОНТЕНТОМ ===
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(240, 245, 235);
            this.panelContent.Controls.Add(this.buttonBackToMenu);
            this.panelContent.Controls.Add(this.buttonExport);
            this.panelContent.Controls.Add(this.buttonRefresh);
            this.panelContent.Controls.Add(this.buttonClearFilter);
            this.panelContent.Controls.Add(this.buttonApplyFilter);
            this.panelContent.Controls.Add(this.labelStatistics);
            this.panelContent.Controls.Add(this.dataGridViewOrders);
            this.panelContent.Controls.Add(this.comboBoxHouseFilter);
            this.panelContent.Controls.Add(this.labelHouse);
            this.panelContent.Controls.Add(this.comboBoxStatusFilter);
            this.panelContent.Controls.Add(this.labelStatus);
            this.panelContent.Controls.Add(this.dateTimePickerTo);
            this.panelContent.Controls.Add(this.labelDateTo);
            this.panelContent.Controls.Add(this.dateTimePickerFrom);
            this.panelContent.Controls.Add(this.labelDateFrom);
            this.panelContent.Controls.Add(this.textBoxSearch);
            this.panelContent.Controls.Add(this.labelSearch);
            this.panelContent.Controls.Add(this.labelFilter);

            // ========== ДОБАВЛЯЕМ ЛЕГЕНДУ В panelContent ==========
            this.panelContent.Controls.Add(this.panelLegend);

            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 83);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(1200, 717);
            this.panelContent.TabIndex = 2;

            // === ЭЛЕМЕНТЫ УПРАВЛЕНИЯ ===
            this.labelFilter.AutoSize = true;
            this.labelFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelFilter.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelFilter.Location = new System.Drawing.Point(320, 45);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(96, 25);
            this.labelFilter.TabIndex = 0;
            this.labelFilter.Text = "Фильтры:";

            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelSearch.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelSearch.Location = new System.Drawing.Point(20, 30);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(50, 17);
            this.labelSearch.TabIndex = 3;
            this.labelSearch.Text = "Поиск:";

            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSearch.Location = new System.Drawing.Point(20, 50);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(300, 25);
            this.textBoxSearch.TabIndex = 4;
            this.textBoxSearch.Text = "🔍 Поиск по клиенту...";

            this.labelDateFrom.AutoSize = true;
            this.labelDateFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelDateFrom.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelDateFrom.Location = new System.Drawing.Point(20, 85);
            this.labelDateFrom.Name = "labelDateFrom";
            this.labelDateFrom.Size = new System.Drawing.Size(19, 17);
            this.labelDateFrom.TabIndex = 2;
            this.labelDateFrom.Text = "С:";

            this.dateTimePickerFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateTimePickerFrom.Location = new System.Drawing.Point(20, 105);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(130, 25);
            this.dateTimePickerFrom.TabIndex = 3;

            this.labelDateTo.AutoSize = true;
            this.labelDateTo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelDateTo.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelDateTo.Location = new System.Drawing.Point(170, 85);
            this.labelDateTo.Name = "labelDateTo";
            this.labelDateTo.Size = new System.Drawing.Size(29, 17);
            this.labelDateTo.TabIndex = 4;
            this.labelDateTo.Text = "По:";

            this.dateTimePickerTo.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerTo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateTimePickerTo.Location = new System.Drawing.Point(170, 105);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(130, 25);
            this.dateTimePickerTo.TabIndex = 5;

            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelStatus.Location = new System.Drawing.Point(320, 85);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(126, 17);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Фильтр по статусу:";

            this.comboBoxStatusFilter.BackColor = System.Drawing.Color.White;
            this.comboBoxStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatusFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.comboBoxStatusFilter.Location = new System.Drawing.Point(320, 105);
            this.comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            this.comboBoxStatusFilter.Size = new System.Drawing.Size(240, 25);
            this.comboBoxStatusFilter.TabIndex = 8;

            this.labelHouse.AutoSize = true;
            this.labelHouse.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelHouse.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelHouse.Location = new System.Drawing.Point(580, 85);
            this.labelHouse.Name = "labelHouse";
            this.labelHouse.Size = new System.Drawing.Size(114, 17);
            this.labelHouse.TabIndex = 9;
            this.labelHouse.Text = "Фильтр по дому:";

            this.comboBoxHouseFilter.BackColor = System.Drawing.Color.White;
            this.comboBoxHouseFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHouseFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxHouseFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.comboBoxHouseFilter.Location = new System.Drawing.Point(580, 105);
            this.comboBoxHouseFilter.Name = "comboBoxHouseFilter";
            this.comboBoxHouseFilter.Size = new System.Drawing.Size(240, 25);
            this.comboBoxHouseFilter.TabIndex = 10;

            // === DataGridView ===
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 245);
            this.dataGridViewOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;

            this.dataGridViewOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));

            this.dataGridViewOrders.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            this.dataGridViewOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewOrders.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(220, 235, 210);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewOrders.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewOrders.Location = new System.Drawing.Point(20, 200);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.RowHeadersVisible = false;
            this.dataGridViewOrders.RowTemplate.Height = 35;
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(1160, 380);
            this.dataGridViewOrders.TabIndex = 11;

            // === СТАТИСТИКА ===
            this.labelStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatistics.BackColor = System.Drawing.Color.White;
            this.labelStatistics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStatistics.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelStatistics.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelStatistics.Location = new System.Drawing.Point(20, 630);
            this.labelStatistics.Name = "labelStatistics";
            this.labelStatistics.Padding = new System.Windows.Forms.Padding(10);
            this.labelStatistics.Size = new System.Drawing.Size(980, 50);
            this.labelStatistics.TabIndex = 12;
            this.labelStatistics.Text = "Заказов: 0";
            this.labelStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // === КНОПКИ ===
            this.buttonApplyFilter.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
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

            this.buttonClearFilter.BackColor = System.Drawing.Color.FromArgb(220, 100, 100);
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

            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
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

            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
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

            this.buttonBackToMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonBackToMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.buttonBackToMenu.FlatAppearance.BorderSize = 2;
            this.buttonBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackToMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonBackToMenu.ForeColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.buttonBackToMenu.Location = new System.Drawing.Point(1020, 630);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(160, 50);
            this.buttonBackToMenu.TabIndex = 17;
            this.buttonBackToMenu.Text = "🏠 В меню";
            this.buttonBackToMenu.UseVisualStyleBackColor = false;

            // ========== ЛЕГЕНДА ==========
            // Панель легенды
            this.panelLegend.BackColor = System.Drawing.Color.White;
            this.panelLegend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLegend.Location = new System.Drawing.Point(20, 150);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(440, 32);
            this.panelLegend.TabIndex = 18;

            // Заголовок легенды
            this.labelLegendTitle.AutoSize = true;
            this.labelLegendTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.labelLegendTitle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelLegendTitle.Location = new System.Drawing.Point(8, 8);
            this.labelLegendTitle.Name = "labelLegendTitle";
            this.labelLegendTitle.Size = new System.Drawing.Size(60, 15);
            this.labelLegendTitle.TabIndex = 0;
            this.labelLegendTitle.Text = "Статусы:";

            // Активный
            this.panelActiveColor.BackColor = System.Drawing.Color.FromArgb(198, 239, 206);
            this.panelActiveColor.Location = new System.Drawing.Point(72, 6);
            this.panelActiveColor.Name = "panelActiveColor";
            this.panelActiveColor.Size = new System.Drawing.Size(20, 20);
            this.panelActiveColor.TabIndex = 1;

            this.labelActiveText.AutoSize = true;
            this.labelActiveText.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.labelActiveText.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelActiveText.Location = new System.Drawing.Point(96, 8);
            this.labelActiveText.Name = "labelActiveText";
            this.labelActiveText.Size = new System.Drawing.Size(54, 13);
            this.labelActiveText.TabIndex = 2;
            this.labelActiveText.Text = "Активный";

            // Отменён
            this.panelCancelledColor.BackColor = System.Drawing.Color.FromArgb(255, 199, 206);
            this.panelCancelledColor.Location = new System.Drawing.Point(160, 6);
            this.panelCancelledColor.Name = "panelCancelledColor";
            this.panelCancelledColor.Size = new System.Drawing.Size(20, 20);
            this.panelCancelledColor.TabIndex = 3;

            this.labelCancelledText.AutoSize = true;
            this.labelCancelledText.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.labelCancelledText.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelCancelledText.Location = new System.Drawing.Point(184, 8);
            this.labelCancelledText.Name = "labelCancelledText";
            this.labelCancelledText.Size = new System.Drawing.Size(51, 13);
            this.labelCancelledText.TabIndex = 4;
            this.labelCancelledText.Text = "Отменён";

            // Завершён
            this.panelCompletedColor.BackColor = System.Drawing.Color.FromArgb(210, 210, 210);
            this.panelCompletedColor.Location = new System.Drawing.Point(248, 6);
            this.panelCompletedColor.Name = "panelCompletedColor";
            this.panelCompletedColor.Size = new System.Drawing.Size(20, 20);
            this.panelCompletedColor.TabIndex = 5;

            this.labelCompletedText.AutoSize = true;
            this.labelCompletedText.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.labelCompletedText.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelCompletedText.Location = new System.Drawing.Point(272, 8);
            this.labelCompletedText.Name = "labelCompletedText";
            this.labelCompletedText.Size = new System.Drawing.Size(57, 13);
            this.labelCompletedText.TabIndex = 6;
            this.labelCompletedText.Text = "Завершён";

            // Добавляем элементы в панель легенды
            this.panelLegend.Controls.Add(this.labelLegendTitle);
            this.panelLegend.Controls.Add(this.panelActiveColor);
            this.panelLegend.Controls.Add(this.labelActiveText);
            this.panelLegend.Controls.Add(this.panelCancelledColor);
            this.panelLegend.Controls.Add(this.labelCancelledText);
            this.panelLegend.Controls.Add(this.panelCompletedColor);
            this.panelLegend.Controls.Add(this.labelCompletedText);

            // === ФОРМА ===
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1216, 839);
            this.Name = "OrdersViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление заказами - База отдыха";

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
        }

        // ========== ОБЪЯВЛЕНИЕ ВСЕХ КОМПОНЕНТОВ ==========
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelDateFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelDateTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxStatusFilter;
        private System.Windows.Forms.Label labelHouse;
        private System.Windows.Forms.ComboBox comboBoxHouseFilter;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Label labelStatistics;
        private System.Windows.Forms.Button buttonApplyFilter;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonBackToMenu;

        // ========== КОМПОНЕНТЫ ДЛЯ ЛЕГЕНДЫ ==========
        private System.Windows.Forms.Panel panelLegend;
        private System.Windows.Forms.Label labelLegendTitle;
        private System.Windows.Forms.Panel panelActiveColor;
        private System.Windows.Forms.Label labelActiveText;
        private System.Windows.Forms.Panel panelCancelledColor;
        private System.Windows.Forms.Label labelCancelledText;
        private System.Windows.Forms.Panel panelCompletedColor;
        private System.Windows.Forms.Label labelCompletedText;
    }
}