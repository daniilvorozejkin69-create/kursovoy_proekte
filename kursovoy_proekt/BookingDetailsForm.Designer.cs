namespace kursovoy_proekt
{
    partial class BookingDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonPrint;

        // Основная информация
        private System.Windows.Forms.Label labelBookingId;
        private System.Windows.Forms.Label labelClientInfoTitle;
        private System.Windows.Forms.Label labelClientName;
        private System.Windows.Forms.Label labelPassport;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelEmail;

        // Информация о доме
        private System.Windows.Forms.Label labelHouseInfoTitle;
        private System.Windows.Forms.Label labelHouseName;
        private System.Windows.Forms.Label labelHouseClass;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.TextBox textBoxHouseDescription;

        // Даты
        private System.Windows.Forms.Label labelDatesTitle;
        private System.Windows.Forms.Label labelDates;
        private System.Windows.Forms.Label labelDaysCount;

        // Стоимость
        private System.Windows.Forms.Label labelPriceTitle;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.Label labelDeposit;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Label labelTotalPriceLabel;
        private System.Windows.Forms.Label labelDepositLabel;
        private System.Windows.Forms.Label labelBalanceLabel;

        // Статус
        private System.Windows.Forms.Label labelStatusTitle;
        private System.Windows.Forms.Label labelStatus;

        // Дополнительная информация
        private System.Windows.Forms.Label labelAdditionalInfoTitle;
        private System.Windows.Forms.Label labelCreatedBy;
        private System.Windows.Forms.Label labelCreatedDate;
        private System.Windows.Forms.TextBox textBoxNotes;

        // Разделители
        private System.Windows.Forms.Panel panelSeparator1;
        private System.Windows.Forms.Panel panelSeparator2;
        private System.Windows.Forms.Panel panelSeparator3;

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
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelSeparator3 = new System.Windows.Forms.Panel();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.labelCreatedBy = new System.Windows.Forms.Label();
            this.labelAdditionalInfoTitle = new System.Windows.Forms.Label();
            this.panelSeparator2 = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelStatusTitle = new System.Windows.Forms.Label();
            this.labelBalanceLabel = new System.Windows.Forms.Label();
            this.labelDepositLabel = new System.Windows.Forms.Label();
            this.labelTotalPriceLabel = new System.Windows.Forms.Label();
            this.labelBalance = new System.Windows.Forms.Label();
            this.labelDeposit = new System.Windows.Forms.Label();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.labelPriceTitle = new System.Windows.Forms.Label();
            this.panelSeparator1 = new System.Windows.Forms.Panel();
            this.labelDaysCount = new System.Windows.Forms.Label();
            this.labelDates = new System.Windows.Forms.Label();
            this.labelDatesTitle = new System.Windows.Forms.Label();
            this.textBoxHouseDescription = new System.Windows.Forms.TextBox();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.labelHouseClass = new System.Windows.Forms.Label();
            this.labelHouseName = new System.Windows.Forms.Label();
            this.labelHouseInfoTitle = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelPassport = new System.Windows.Forms.Label();
            this.labelClientName = new System.Windows.Forms.Label();
            this.labelClientInfoTitle = new System.Windows.Forms.Label();
            this.labelBookingId = new System.Windows.Forms.Label();
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
            this.panelHeader.Size = new System.Drawing.Size(800, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(30, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(282, 37);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Детали бронирования";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.buttonPrint);
            this.panelContent.Controls.Add(this.buttonClose);
            this.panelContent.Controls.Add(this.panelSeparator3);
            this.panelContent.Controls.Add(this.textBoxNotes);
            this.panelContent.Controls.Add(this.labelCreatedDate);
            this.panelContent.Controls.Add(this.labelCreatedBy);
            this.panelContent.Controls.Add(this.labelAdditionalInfoTitle);
            this.panelContent.Controls.Add(this.panelSeparator2);
            this.panelContent.Controls.Add(this.labelStatus);
            this.panelContent.Controls.Add(this.labelStatusTitle);
            this.panelContent.Controls.Add(this.labelBalanceLabel);
            this.panelContent.Controls.Add(this.labelDepositLabel);
            this.panelContent.Controls.Add(this.labelTotalPriceLabel);
            this.panelContent.Controls.Add(this.labelBalance);
            this.panelContent.Controls.Add(this.labelDeposit);
            this.panelContent.Controls.Add(this.labelTotalPrice);
            this.panelContent.Controls.Add(this.labelPriceTitle);
            this.panelContent.Controls.Add(this.panelSeparator1);
            this.panelContent.Controls.Add(this.labelDaysCount);
            this.panelContent.Controls.Add(this.labelDates);
            this.panelContent.Controls.Add(this.labelDatesTitle);
            this.panelContent.Controls.Add(this.textBoxHouseDescription);
            this.panelContent.Controls.Add(this.labelCapacity);
            this.panelContent.Controls.Add(this.labelHouseClass);
            this.panelContent.Controls.Add(this.labelHouseName);
            this.panelContent.Controls.Add(this.labelHouseInfoTitle);
            this.panelContent.Controls.Add(this.labelEmail);
            this.panelContent.Controls.Add(this.labelPhone);
            this.panelContent.Controls.Add(this.labelPassport);
            this.panelContent.Controls.Add(this.labelClientName);
            this.panelContent.Controls.Add(this.labelClientInfoTitle);
            this.panelContent.Controls.Add(this.labelBookingId);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 70);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(800, 833);
            this.panelContent.TabIndex = 1;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonPrint.FlatAppearance.BorderSize = 0;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonPrint.ForeColor = System.Drawing.Color.White;
            this.buttonPrint.Location = new System.Drawing.Point(620, 733);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(160, 50);
            this.buttonPrint.TabIndex = 31;
            this.buttonPrint.Text = "🖨️ Печать";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonClose.FlatAppearance.BorderSize = 2;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonClose.Location = new System.Drawing.Point(20, 733);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(160, 50);
            this.buttonClose.TabIndex = 30;
            this.buttonClose.Text = "✕ Закрыть";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelSeparator3
            // 
            this.panelSeparator3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSeparator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelSeparator3.Location = new System.Drawing.Point(20, 530);
            this.panelSeparator3.Name = "panelSeparator3";
            this.panelSeparator3.Size = new System.Drawing.Size(760, 2);
            this.panelSeparator3.TabIndex = 29;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNotes.BackColor = System.Drawing.Color.White;
            this.textBoxNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxNotes.Location = new System.Drawing.Point(20, 640);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.ReadOnly = true;
            this.textBoxNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNotes.Size = new System.Drawing.Size(760, 80);
            this.textBoxNotes.TabIndex = 28;
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelCreatedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCreatedDate.Location = new System.Drawing.Point(420, 600);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(114, 19);
            this.labelCreatedDate.TabIndex = 27;
            this.labelCreatedDate.Text = "Дата создания: -";
            // 
            // labelCreatedBy
            // 
            this.labelCreatedBy.AutoSize = true;
            this.labelCreatedBy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelCreatedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCreatedBy.Location = new System.Drawing.Point(20, 600);
            this.labelCreatedBy.Name = "labelCreatedBy";
            this.labelCreatedBy.Size = new System.Drawing.Size(82, 19);
            this.labelCreatedBy.TabIndex = 26;
            this.labelCreatedBy.Text = "Создал(а): -";
            // 
            // labelAdditionalInfoTitle
            // 
            this.labelAdditionalInfoTitle.AutoSize = true;
            this.labelAdditionalInfoTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelAdditionalInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelAdditionalInfoTitle.Location = new System.Drawing.Point(20, 570);
            this.labelAdditionalInfoTitle.Name = "labelAdditionalInfoTitle";
            this.labelAdditionalInfoTitle.Size = new System.Drawing.Size(246, 21);
            this.labelAdditionalInfoTitle.TabIndex = 25;
            this.labelAdditionalInfoTitle.Text = "Дополнительная информация:";
            // 
            // panelSeparator2
            // 
            this.panelSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelSeparator2.Location = new System.Drawing.Point(20, 510);
            this.panelSeparator2.Name = "panelSeparator2";
            this.panelSeparator2.Size = new System.Drawing.Size(760, 2);
            this.panelSeparator2.TabIndex = 24;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelStatus.Location = new System.Drawing.Point(420, 470);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(64, 21);
            this.labelStatus.TabIndex = 23;
            this.labelStatus.Text = "Статус:";
            // 
            // labelStatusTitle
            // 
            this.labelStatusTitle.AutoSize = true;
            this.labelStatusTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelStatusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelStatusTitle.Location = new System.Drawing.Point(20, 470);
            this.labelStatusTitle.Name = "labelStatusTitle";
            this.labelStatusTitle.Size = new System.Drawing.Size(62, 21);
            this.labelStatusTitle.TabIndex = 22;
            this.labelStatusTitle.Text = "Статус:";
            // 
            // labelBalanceLabel
            // 
            this.labelBalanceLabel.AutoSize = true;
            this.labelBalanceLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelBalanceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelBalanceLabel.Location = new System.Drawing.Point(20, 430);
            this.labelBalanceLabel.Name = "labelBalanceLabel";
            this.labelBalanceLabel.Size = new System.Drawing.Size(136, 20);
            this.labelBalanceLabel.TabIndex = 21;
            this.labelBalanceLabel.Text = "Остаток к оплате:";
            // 
            // labelDepositLabel
            // 
            this.labelDepositLabel.AutoSize = true;
            this.labelDepositLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelDepositLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDepositLabel.Location = new System.Drawing.Point(20, 405);
            this.labelDepositLabel.Name = "labelDepositLabel";
            this.labelDepositLabel.Size = new System.Drawing.Size(151, 20);
            this.labelDepositLabel.TabIndex = 20;
            this.labelDepositLabel.Text = "Внесенный депозит:";
            // 
            // labelTotalPriceLabel
            // 
            this.labelTotalPriceLabel.AutoSize = true;
            this.labelTotalPriceLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelTotalPriceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalPriceLabel.Location = new System.Drawing.Point(20, 380);
            this.labelTotalPriceLabel.Name = "labelTotalPriceLabel";
            this.labelTotalPriceLabel.Size = new System.Drawing.Size(136, 20);
            this.labelTotalPriceLabel.TabIndex = 19;
            this.labelTotalPriceLabel.Text = "Общая стоимость:";
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelBalance.Location = new System.Drawing.Point(200, 430);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(53, 20);
            this.labelBalance.TabIndex = 18;
            this.labelBalance.Text = "0,00 ₽";
            // 
            // labelDeposit
            // 
            this.labelDeposit.AutoSize = true;
            this.labelDeposit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDeposit.Location = new System.Drawing.Point(200, 405);
            this.labelDeposit.Name = "labelDeposit";
            this.labelDeposit.Size = new System.Drawing.Size(48, 20);
            this.labelDeposit.TabIndex = 17;
            this.labelDeposit.Text = "0,00 ₽";
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalPrice.Location = new System.Drawing.Point(200, 380);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(48, 20);
            this.labelTotalPrice.TabIndex = 16;
            this.labelTotalPrice.Text = "0,00 ₽";
            // 
            // labelPriceTitle
            // 
            this.labelPriceTitle.AutoSize = true;
            this.labelPriceTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelPriceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPriceTitle.Location = new System.Drawing.Point(20, 350);
            this.labelPriceTitle.Name = "labelPriceTitle";
            this.labelPriceTitle.Size = new System.Drawing.Size(150, 21);
            this.labelPriceTitle.TabIndex = 15;
            this.labelPriceTitle.Text = "Расчет стоимости:";
            // 
            // panelSeparator1
            // 
            this.panelSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelSeparator1.Location = new System.Drawing.Point(20, 330);
            this.panelSeparator1.Name = "panelSeparator1";
            this.panelSeparator1.Size = new System.Drawing.Size(760, 2);
            this.panelSeparator1.TabIndex = 14;
            // 
            // labelDaysCount
            // 
            this.labelDaysCount.AutoSize = true;
            this.labelDaysCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelDaysCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelDaysCount.Location = new System.Drawing.Point(200, 300);
            this.labelDaysCount.Name = "labelDaysCount";
            this.labelDaysCount.Size = new System.Drawing.Size(17, 19);
            this.labelDaysCount.TabIndex = 13;
            this.labelDaysCount.Text = "0";
            // 
            // labelDates
            // 
            this.labelDates.AutoSize = true;
            this.labelDates.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelDates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDates.Location = new System.Drawing.Point(20, 300);
            this.labelDates.Name = "labelDates";
            this.labelDates.Size = new System.Drawing.Size(79, 19);
            this.labelDates.TabIndex = 12;
            this.labelDates.Text = "01.01.2024";
            // 
            // labelDatesTitle
            // 
            this.labelDatesTitle.AutoSize = true;
            this.labelDatesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelDatesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDatesTitle.Location = new System.Drawing.Point(20, 270);
            this.labelDatesTitle.Name = "labelDatesTitle";
            this.labelDatesTitle.Size = new System.Drawing.Size(154, 21);
            this.labelDatesTitle.TabIndex = 11;
            this.labelDatesTitle.Text = "Даты проживания:";
            // 
            // textBoxHouseDescription
            // 
            this.textBoxHouseDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHouseDescription.BackColor = System.Drawing.Color.White;
            this.textBoxHouseDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxHouseDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBoxHouseDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxHouseDescription.Location = new System.Drawing.Point(20, 210);
            this.textBoxHouseDescription.Multiline = true;
            this.textBoxHouseDescription.Name = "textBoxHouseDescription";
            this.textBoxHouseDescription.ReadOnly = true;
            this.textBoxHouseDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxHouseDescription.Size = new System.Drawing.Size(760, 50);
            this.textBoxHouseDescription.TabIndex = 10;
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCapacity.Location = new System.Drawing.Point(420, 180);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(94, 19);
            this.labelCapacity.TabIndex = 9;
            this.labelCapacity.Text = "Вместимость:";
            // 
            // labelHouseClass
            // 
            this.labelHouseClass.AutoSize = true;
            this.labelHouseClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelHouseClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseClass.Location = new System.Drawing.Point(200, 180);
            this.labelHouseClass.Name = "labelHouseClass";
            this.labelHouseClass.Size = new System.Drawing.Size(46, 19);
            this.labelHouseClass.TabIndex = 8;
            this.labelHouseClass.Text = "Класс:";
            // 
            // labelHouseName
            // 
            this.labelHouseName.AutoSize = true;
            this.labelHouseName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelHouseName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseName.Location = new System.Drawing.Point(20, 180);
            this.labelHouseName.Name = "labelHouseName";
            this.labelHouseName.Size = new System.Drawing.Size(50, 19);
            this.labelHouseName.TabIndex = 7;
            this.labelHouseName.Text = "Дом: -";
            // 
            // labelHouseInfoTitle
            // 
            this.labelHouseInfoTitle.AutoSize = true;
            this.labelHouseInfoTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelHouseInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseInfoTitle.Location = new System.Drawing.Point(20, 150);
            this.labelHouseInfoTitle.Name = "labelHouseInfoTitle";
            this.labelHouseInfoTitle.Size = new System.Drawing.Size(174, 21);
            this.labelHouseInfoTitle.TabIndex = 6;
            this.labelHouseInfoTitle.Text = "Информация о доме:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEmail.Location = new System.Drawing.Point(420, 120);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(54, 19);
            this.labelEmail.TabIndex = 5;
            this.labelEmail.Text = "Email: -";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPhone.Location = new System.Drawing.Point(200, 120);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(76, 19);
            this.labelPhone.TabIndex = 4;
            this.labelPhone.Text = "Телефон: -";
            // 
            // labelPassport
            // 
            this.labelPassport.AutoSize = true;
            this.labelPassport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelPassport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPassport.Location = new System.Drawing.Point(20, 120);
            this.labelPassport.Name = "labelPassport";
            this.labelPassport.Size = new System.Drawing.Size(75, 19);
            this.labelPassport.TabIndex = 3;
            this.labelPassport.Text = "Паспорт: -";
            // 
            // labelClientName
            // 
            this.labelClientName.AutoSize = true;
            this.labelClientName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClientName.Location = new System.Drawing.Point(20, 95);
            this.labelClientName.Name = "labelClientName";
            this.labelClientName.Size = new System.Drawing.Size(121, 20);
            this.labelClientName.TabIndex = 2;
            this.labelClientName.Text = "ФИО клиента: -";
            // 
            // labelClientInfoTitle
            // 
            this.labelClientInfoTitle.AutoSize = true;
            this.labelClientInfoTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelClientInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClientInfoTitle.Location = new System.Drawing.Point(20, 65);
            this.labelClientInfoTitle.Name = "labelClientInfoTitle";
            this.labelClientInfoTitle.Size = new System.Drawing.Size(195, 21);
            this.labelClientInfoTitle.TabIndex = 1;
            this.labelClientInfoTitle.Text = "Информация о клиенте:";
            // 
            // labelBookingId
            // 
            this.labelBookingId.AutoSize = true;
            this.labelBookingId.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelBookingId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.labelBookingId.Location = new System.Drawing.Point(20, 20);
            this.labelBookingId.Name = "labelBookingId";
            this.labelBookingId.Size = new System.Drawing.Size(179, 25);
            this.labelBookingId.TabIndex = 0;
            this.labelBookingId.Text = "Бронирование №";
            // 
            // BookingDetailsForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 903);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(816, 839);
            this.Name = "BookingDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Детали бронирования - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}