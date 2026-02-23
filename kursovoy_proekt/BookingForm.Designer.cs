namespace kursovoy_proekt
{
    partial class BookingForm
    {
        private System.ComponentModel.IContainer components = null;

        // Основные панели
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;

        // Элементы формы
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.ComboBox comboBoxClients;
        private System.Windows.Forms.Label labelHouse;
        private System.Windows.Forms.ComboBox comboBoxHouses;
        private System.Windows.Forms.Label labelHouseInfo;
        private System.Windows.Forms.Label labelCheckIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckIn;
        private System.Windows.Forms.Label labelCheckOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckOut;
        private System.Windows.Forms.Label labelStayDays;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.TextBox textBoxNotes;

        // Расчет стоимости
        private System.Windows.Forms.Label labelTotalCost;
        private System.Windows.Forms.Label labelTotalCostLabel;
        private System.Windows.Forms.Label labelCostTitle;

        // Кнопки
        private System.Windows.Forms.Button buttonCreateBooking;
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelGreenLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.buttonCreateBooking = new System.Windows.Forms.Button();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.labelTotalCostLabel = new System.Windows.Forms.Label();
            this.labelCostTitle = new System.Windows.Forms.Label();
            this.labelStayDays = new System.Windows.Forms.Label();
            this.dateTimePickerCheckOut = new System.Windows.Forms.DateTimePicker();
            this.labelCheckOut = new System.Windows.Forms.Label();
            this.dateTimePickerCheckIn = new System.Windows.Forms.DateTimePicker();
            this.labelCheckIn = new System.Windows.Forms.Label();
            this.labelHouseInfo = new System.Windows.Forms.Label();
            this.comboBoxHouses = new System.Windows.Forms.ComboBox();
            this.labelHouse = new System.Windows.Forms.Label();
            this.comboBoxClients = new System.Windows.Forms.ComboBox();
            this.labelClient = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(30, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(247, 45);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Бронирование дома";
            // 
            // panelGreenLine
            // 
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 80);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(800, 3);
            this.panelGreenLine.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.textBoxNotes);
            this.panelContent.Controls.Add(this.labelNotes);
            this.panelContent.Controls.Add(this.buttonBackToMenu);
            this.panelContent.Controls.Add(this.buttonCreateBooking);
            this.panelContent.Controls.Add(this.labelTotalCost);
            this.panelContent.Controls.Add(this.labelTotalCostLabel);
            this.panelContent.Controls.Add(this.labelCostTitle);
            this.panelContent.Controls.Add(this.labelStayDays);
            this.panelContent.Controls.Add(this.dateTimePickerCheckOut);
            this.panelContent.Controls.Add(this.labelCheckOut);
            this.panelContent.Controls.Add(this.dateTimePickerCheckIn);
            this.panelContent.Controls.Add(this.labelCheckIn);
            this.panelContent.Controls.Add(this.labelHouseInfo);
            this.panelContent.Controls.Add(this.comboBoxHouses);
            this.panelContent.Controls.Add(this.labelHouse);
            this.panelContent.Controls.Add(this.comboBoxClients);
            this.panelContent.Controls.Add(this.labelClient);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 83);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(800, 517);
            this.panelContent.TabIndex = 2;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.BackColor = System.Drawing.Color.White;
            this.textBoxNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxNotes.Location = new System.Drawing.Point(20, 320);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNotes.Size = new System.Drawing.Size(760, 80);
            this.textBoxNotes.TabIndex = 19;
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelNotes.Location = new System.Drawing.Point(20, 300);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(109, 17);
            this.labelNotes.TabIndex = 18;
            this.labelNotes.Text = "Примечания (опционально):";
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
            this.buttonBackToMenu.Location = new System.Drawing.Point(620, 440);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(160, 50);
            this.buttonBackToMenu.TabIndex = 17;
            this.buttonBackToMenu.Text = "🏠 В меню";
            this.buttonBackToMenu.UseVisualStyleBackColor = false;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click);
            // 
            // buttonCreateBooking
            // 
            this.buttonCreateBooking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonCreateBooking.FlatAppearance.BorderSize = 0;
            this.buttonCreateBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateBooking.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonCreateBooking.ForeColor = System.Drawing.Color.White;
            this.buttonCreateBooking.Location = new System.Drawing.Point(20, 440);
            this.buttonCreateBooking.Name = "buttonCreateBooking";
            this.buttonCreateBooking.Size = new System.Drawing.Size(580, 50);
            this.buttonCreateBooking.TabIndex = 16;
            this.buttonCreateBooking.Text = "✅ СОЗДАТЬ БРОНИРОВАНИЕ";
            this.buttonCreateBooking.UseVisualStyleBackColor = false;
            this.buttonCreateBooking.Click += new System.EventHandler(this.buttonCreateBooking_Click);
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelTotalCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelTotalCost.Location = new System.Drawing.Point(620, 260);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(66, 25);
            this.labelTotalCost.TabIndex = 15;
            this.labelTotalCost.Text = "0,00 ₽";
            // 
            // labelTotalCostLabel
            // 
            this.labelTotalCostLabel.AutoSize = true;
            this.labelTotalCostLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalCostLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalCostLabel.Location = new System.Drawing.Point(430, 263);
            this.labelTotalCostLabel.Name = "labelTotalCostLabel";
            this.labelTotalCostLabel.Size = new System.Drawing.Size(184, 21);
            this.labelTotalCostLabel.TabIndex = 14;
            this.labelTotalCostLabel.Text = "Итого к оплате (всего):";
            // 
            // labelCostTitle
            // 
            this.labelCostTitle.AutoSize = true;
            this.labelCostTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelCostTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCostTitle.Location = new System.Drawing.Point(430, 230);
            this.labelCostTitle.Name = "labelCostTitle";
            this.labelCostTitle.Size = new System.Drawing.Size(184, 25);
            this.labelCostTitle.TabIndex = 13;
            this.labelCostTitle.Text = "Расчет стоимости:";
            // 
            // labelStayDays
            // 
            this.labelStayDays.AutoSize = true;
            this.labelStayDays.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.labelStayDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelStayDays.Location = new System.Drawing.Point(345, 195);
            this.labelStayDays.Name = "labelStayDays";
            this.labelStayDays.Size = new System.Drawing.Size(50, 17);
            this.labelStayDays.TabIndex = 12;
            this.labelStayDays.Text = "1 день";
            // 
            // dateTimePickerCheckOut
            // 
            this.dateTimePickerCheckOut.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerCheckOut.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateTimePickerCheckOut.Location = new System.Drawing.Point(205, 190);
            this.dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            this.dateTimePickerCheckOut.Size = new System.Drawing.Size(130, 25);
            this.dateTimePickerCheckOut.TabIndex = 11;
            this.dateTimePickerCheckOut.ValueChanged += new System.EventHandler(this.dateTimePickerCheckOut_ValueChanged);
            // 
            // labelCheckOut
            // 
            this.labelCheckOut.AutoSize = true;
            this.labelCheckOut.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelCheckOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCheckOut.Location = new System.Drawing.Point(205, 165);
            this.labelCheckOut.Name = "labelCheckOut";
            this.labelCheckOut.Size = new System.Drawing.Size(87, 17);
            this.labelCheckOut.TabIndex = 10;
            this.labelCheckOut.Text = "Дата выезда:";
            // 
            // dateTimePickerCheckIn
            // 
            this.dateTimePickerCheckIn.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerCheckIn.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateTimePickerCheckIn.Location = new System.Drawing.Point(65, 190);
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new System.Drawing.Size(130, 25);
            this.dateTimePickerCheckIn.TabIndex = 9;
            this.dateTimePickerCheckIn.ValueChanged += new System.EventHandler(this.dateTimePickerCheckIn_ValueChanged);
            // 
            // labelCheckIn
            // 
            this.labelCheckIn.AutoSize = true;
            this.labelCheckIn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelCheckIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCheckIn.Location = new System.Drawing.Point(65, 165);
            this.labelCheckIn.Name = "labelCheckIn";
            this.labelCheckIn.Size = new System.Drawing.Size(89, 17);
            this.labelCheckIn.TabIndex = 8;
            this.labelCheckIn.Text = "Дата заезда:";
            // 
            // labelHouseInfo
            // 
            this.labelHouseInfo.AutoSize = true;
            this.labelHouseInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.labelHouseInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.labelHouseInfo.Location = new System.Drawing.Point(485, 115);
            this.labelHouseInfo.Name = "labelHouseInfo";
            this.labelHouseInfo.Size = new System.Drawing.Size(0, 15);
            this.labelHouseInfo.TabIndex = 7;
            // 
            // comboBoxHouses
            // 
            this.comboBoxHouses.BackColor = System.Drawing.Color.White;
            this.comboBoxHouses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHouses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxHouses.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.comboBoxHouses.FormattingEnabled = true;
            this.comboBoxHouses.Location = new System.Drawing.Point(205, 110);
            this.comboBoxHouses.Name = "comboBoxHouses";
            this.comboBoxHouses.Size = new System.Drawing.Size(270, 25);
            this.comboBoxHouses.TabIndex = 6;
            this.comboBoxHouses.SelectedIndexChanged += new System.EventHandler(this.comboBoxHouses_SelectedIndexChanged);
            // 
            // labelHouse
            // 
            this.labelHouse.AutoSize = true;
            this.labelHouse.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelHouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouse.Location = new System.Drawing.Point(205, 85);
            this.labelHouse.Name = "labelHouse";
            this.labelHouse.Size = new System.Drawing.Size(103, 17);
            this.labelHouse.TabIndex = 5;
            this.labelHouse.Text = "Выберите дом:";
            // 
            // comboBoxClients
            // 
            this.comboBoxClients.BackColor = System.Drawing.Color.White;
            this.comboBoxClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxClients.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.comboBoxClients.FormattingEnabled = true;
            this.comboBoxClients.Location = new System.Drawing.Point(20, 110);
            this.comboBoxClients.Name = "comboBoxClients";
            this.comboBoxClients.Size = new System.Drawing.Size(170, 25);
            this.comboBoxClients.TabIndex = 4;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClient.Location = new System.Drawing.Point(20, 85);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(116, 17);
            this.labelClient.TabIndex = 3;
            this.labelClient.Text = "Выберите клиента:";
            // 
            // BookingForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(816, 639);
            this.Name = "BookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Бронирование дома - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}