namespace kursovoy_proekt
{
    partial class ReceiptForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelReceiptContent;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelOrderNumber;
        private System.Windows.Forms.Label labelOrderDate;
        private System.Windows.Forms.Label labelClientName;
        private System.Windows.Forms.Label labelClientPassport;
        private System.Windows.Forms.Label labelClientPhone;
        private System.Windows.Forms.Label labelClientEmail;
        private System.Windows.Forms.Label labelHouseName;
        private System.Windows.Forms.Label labelHouseClass;
        private System.Windows.Forms.Label labelHouseAddress;
        private System.Windows.Forms.Label labelHouseCapacity;
        private System.Windows.Forms.Label labelHouseDescription;
        private System.Windows.Forms.Label labelHouseCost;
        private System.Windows.Forms.Label labelServicesCost;
        private System.Windows.Forms.Label labelTotalCost;
        private System.Windows.Forms.Label labelAmountInWords;
        private System.Windows.Forms.Label labelStaffName;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonSavePDF;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelReceiptDate;
        private System.Windows.Forms.Label labelQRInfo;
        private System.Windows.Forms.Label labelStaffLogin;
        private System.Windows.Forms.Label labelCheckInDate;
        private System.Windows.Forms.Label labelCheckOutDate;
        private System.Windows.Forms.Label labelStayPeriod;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelReceiptContent = new System.Windows.Forms.Panel();
            this.labelStayPeriod = new System.Windows.Forms.Label();
            this.labelCheckOutDate = new System.Windows.Forms.Label();
            this.labelCheckInDate = new System.Windows.Forms.Label();
            this.labelQRInfo = new System.Windows.Forms.Label();
            this.labelReceiptDate = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSavePDF = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.labelStaffLogin = new System.Windows.Forms.Label();
            this.labelStaffName = new System.Windows.Forms.Label();
            this.labelAmountInWords = new System.Windows.Forms.Label();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.labelServicesCost = new System.Windows.Forms.Label();
            this.labelHouseCost = new System.Windows.Forms.Label();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.labelHouseDescription = new System.Windows.Forms.Label();
            this.labelHouseCapacity = new System.Windows.Forms.Label();
            this.labelHouseAddress = new System.Windows.Forms.Label();
            this.labelHouseClass = new System.Windows.Forms.Label();
            this.labelHouseName = new System.Windows.Forms.Label();
            this.labelClientEmail = new System.Windows.Forms.Label();
            this.labelClientPhone = new System.Windows.Forms.Label();
            this.labelClientPassport = new System.Windows.Forms.Label();
            this.labelClientName = new System.Windows.Forms.Label();
            this.labelOrderDate = new System.Windows.Forms.Label();
            this.labelOrderNumber = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelReceiptContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.SuspendLayout();
            // 
            // panelReceiptContent
            // 
            this.panelReceiptContent.AutoScroll = true;
            this.panelReceiptContent.BackColor = System.Drawing.Color.White;
            this.panelReceiptContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReceiptContent.Controls.Add(this.labelStayPeriod);
            this.panelReceiptContent.Controls.Add(this.labelCheckOutDate);
            this.panelReceiptContent.Controls.Add(this.labelCheckInDate);
            this.panelReceiptContent.Controls.Add(this.labelQRInfo);
            this.panelReceiptContent.Controls.Add(this.labelReceiptDate);
            this.panelReceiptContent.Controls.Add(this.buttonClose);
            this.panelReceiptContent.Controls.Add(this.buttonSavePDF);
            this.panelReceiptContent.Controls.Add(this.buttonPrint);
            this.panelReceiptContent.Controls.Add(this.labelStaffLogin);
            this.panelReceiptContent.Controls.Add(this.labelStaffName);
            this.panelReceiptContent.Controls.Add(this.labelAmountInWords);
            this.panelReceiptContent.Controls.Add(this.labelTotalCost);
            this.panelReceiptContent.Controls.Add(this.labelServicesCost);
            this.panelReceiptContent.Controls.Add(this.labelHouseCost);
            this.panelReceiptContent.Controls.Add(this.dataGridViewServices);
            this.panelReceiptContent.Controls.Add(this.labelHouseDescription);
            this.panelReceiptContent.Controls.Add(this.labelHouseCapacity);
            this.panelReceiptContent.Controls.Add(this.labelHouseAddress);
            this.panelReceiptContent.Controls.Add(this.labelHouseClass);
            this.panelReceiptContent.Controls.Add(this.labelHouseName);
            this.panelReceiptContent.Controls.Add(this.labelClientEmail);
            this.panelReceiptContent.Controls.Add(this.labelClientPhone);
            this.panelReceiptContent.Controls.Add(this.labelClientPassport);
            this.panelReceiptContent.Controls.Add(this.labelClientName);
            this.panelReceiptContent.Controls.Add(this.labelOrderDate);
            this.panelReceiptContent.Controls.Add(this.labelOrderNumber);
            this.panelReceiptContent.Controls.Add(this.labelTitle);
            this.panelReceiptContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReceiptContent.Location = new System.Drawing.Point(0, 0);
            this.panelReceiptContent.Name = "panelReceiptContent";
            this.panelReceiptContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelReceiptContent.Size = new System.Drawing.Size(800, 850);
            this.panelReceiptContent.TabIndex = 0;
            // 
            // labelStayPeriod
            // 
            this.labelStayPeriod.AutoSize = true;
            this.labelStayPeriod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.labelStayPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelStayPeriod.Location = new System.Drawing.Point(40, 420);
            this.labelStayPeriod.Name = "labelStayPeriod";
            this.labelStayPeriod.Size = new System.Drawing.Size(135, 19);
            this.labelStayPeriod.TabIndex = 26;
            this.labelStayPeriod.Text = "Период: 1 день(ей)";
            // 
            // labelCheckOutDate
            // 
            this.labelCheckOutDate.AutoSize = true;
            this.labelCheckOutDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelCheckOutDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCheckOutDate.Location = new System.Drawing.Point(250, 390);
            this.labelCheckOutDate.Name = "labelCheckOutDate";
            this.labelCheckOutDate.Size = new System.Drawing.Size(150, 19);
            this.labelCheckOutDate.TabIndex = 25;
            this.labelCheckOutDate.Text = "Дата выезда: 02.01.2024";
            // 
            // labelCheckInDate
            // 
            this.labelCheckInDate.AutoSize = true;
            this.labelCheckInDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelCheckInDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCheckInDate.Location = new System.Drawing.Point(40, 390);
            this.labelCheckInDate.Name = "labelCheckInDate";
            this.labelCheckInDate.Size = new System.Drawing.Size(150, 19);
            this.labelCheckInDate.TabIndex = 24;
            this.labelCheckInDate.Text = "Дата заезда: 01.01.2024";
            // 
            // labelQRInfo
            // 
            this.labelQRInfo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.labelQRInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.labelQRInfo.Location = new System.Drawing.Point(500, 140);
            this.labelQRInfo.Name = "labelQRInfo";
            this.labelQRInfo.Size = new System.Drawing.Size(260, 70);
            this.labelQRInfo.TabIndex = 23;
            this.labelQRInfo.Text = "Заказ #00000 от 01.01.2024\r\nСумма: 15 000,00 ₽\r\nКлиент: ФИО\r\n\r\n(QR-код здесь)";
            this.labelQRInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelReceiptDate
            // 
            this.labelReceiptDate.AutoSize = true;
            this.labelReceiptDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelReceiptDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelReceiptDate.Location = new System.Drawing.Point(600, 105);
            this.labelReceiptDate.Name = "labelReceiptDate";
            this.labelReceiptDate.Size = new System.Drawing.Size(61, 15);
            this.labelReceiptDate.TabIndex = 22;
            this.labelReceiptDate.Text = "01.01.2024";
            this.labelReceiptDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(290, 770);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(140, 40);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.Text = "✖️ Закрыть";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSavePDF
            // 
            this.buttonSavePDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.buttonSavePDF.FlatAppearance.BorderSize = 0;
            this.buttonSavePDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSavePDF.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSavePDF.ForeColor = System.Drawing.Color.White;
            this.buttonSavePDF.Location = new System.Drawing.Point(600, 770);
            this.buttonSavePDF.Name = "buttonSavePDF";
            this.buttonSavePDF.Size = new System.Drawing.Size(160, 40);
            this.buttonSavePDF.TabIndex = 20;
            this.buttonSavePDF.Text = "💾 Сохранить PDF";
            this.buttonSavePDF.UseVisualStyleBackColor = false;
            this.buttonSavePDF.Click += new System.EventHandler(this.buttonSavePDF_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonPrint.FlatAppearance.BorderSize = 0;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonPrint.ForeColor = System.Drawing.Color.White;
            this.buttonPrint.Location = new System.Drawing.Point(450, 770);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(140, 40);
            this.buttonPrint.TabIndex = 19;
            this.buttonPrint.Text = "🖨️ Печать";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // labelStaffLogin
            // 
            this.labelStaffLogin.AutoSize = true;
            this.labelStaffLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelStaffLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelStaffLogin.Location = new System.Drawing.Point(40, 800);
            this.labelStaffLogin.Name = "labelStaffLogin";
            this.labelStaffLogin.Size = new System.Drawing.Size(136, 19);
            this.labelStaffLogin.TabIndex = 18;
            this.labelStaffLogin.Text = "Логин: administrator";
            // 
            // labelStaffName
            // 
            this.labelStaffName.AutoSize = true;
            this.labelStaffName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelStaffName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelStaffName.Location = new System.Drawing.Point(40, 770);
            this.labelStaffName.Name = "labelStaffName";
            this.labelStaffName.Size = new System.Drawing.Size(161, 19);
            this.labelStaffName.TabIndex = 17;
            this.labelStaffName.Text = "Сотрудник: Петров П.П.";
            // 
            // labelAmountInWords
            // 
            this.labelAmountInWords.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.labelAmountInWords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelAmountInWords.Location = new System.Drawing.Point(40, 705);
            this.labelAmountInWords.Name = "labelAmountInWords";
            this.labelAmountInWords.Size = new System.Drawing.Size(720, 40);
            this.labelAmountInWords.TabIndex = 16;
            this.labelAmountInWords.Text = "Пятнадцать тысяч рублей";
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTotalCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelTotalCost.Location = new System.Drawing.Point(40, 670);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(178, 25);
            this.labelTotalCost.TabIndex = 15;
            this.labelTotalCost.Text = "ВСЕГО К ОПЛАТЕ: ";
            // 
            // labelServicesCost
            // 
            this.labelServicesCost.AutoSize = true;
            this.labelServicesCost.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelServicesCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelServicesCost.Location = new System.Drawing.Point(40, 630);
            this.labelServicesCost.Name = "labelServicesCost";
            this.labelServicesCost.Size = new System.Drawing.Size(185, 20);
            this.labelServicesCost.TabIndex = 14;
            this.labelServicesCost.Text = "Дополнительные услуги: ";
            // 
            // labelHouseCost
            // 
            this.labelHouseCost.AutoSize = true;
            this.labelHouseCost.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelHouseCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseCost.Location = new System.Drawing.Point(40, 600);
            this.labelHouseCost.Name = "labelHouseCost";
            this.labelHouseCost.Size = new System.Drawing.Size(183, 20);
            this.labelHouseCost.TabIndex = 13;
            this.labelHouseCost.Text = "Стоимость проживания: ";
            // 
            // dataGridViewServices
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewServices.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewServices.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewServices.EnableHeadersVisualStyles = false;
            this.dataGridViewServices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            this.dataGridViewServices.Location = new System.Drawing.Point(40, 450);
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.RowHeadersVisible = false;
            this.dataGridViewServices.RowTemplate.Height = 35;
            this.dataGridViewServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewServices.Size = new System.Drawing.Size(720, 150);
            this.dataGridViewServices.TabIndex = 12;
            // 
            // labelHouseDescription
            // 
            this.labelHouseDescription.AutoSize = true;
            this.labelHouseDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelHouseDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseDescription.Location = new System.Drawing.Point(40, 360);
            this.labelHouseDescription.Name = "labelHouseDescription";
            this.labelHouseDescription.Size = new System.Drawing.Size(215, 19);
            this.labelHouseDescription.TabIndex = 11;
            this.labelHouseDescription.Text = "Описание: Просторный коттедж";
            // 
            // labelHouseCapacity
            // 
            this.labelHouseCapacity.AutoSize = true;
            this.labelHouseCapacity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelHouseCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseCapacity.Location = new System.Drawing.Point(40, 330);
            this.labelHouseCapacity.Name = "labelHouseCapacity";
            this.labelHouseCapacity.Size = new System.Drawing.Size(168, 19);
            this.labelHouseCapacity.TabIndex = 10;
            this.labelHouseCapacity.Text = "Вместимость: 4 человека";
            // 
            // labelHouseAddress
            // 
            this.labelHouseAddress.AutoSize = true;
            this.labelHouseAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelHouseAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseAddress.Location = new System.Drawing.Point(40, 300);
            this.labelHouseAddress.Name = "labelHouseAddress";
            this.labelHouseAddress.Size = new System.Drawing.Size(132, 19);
            this.labelHouseAddress.TabIndex = 9;
            this.labelHouseAddress.Text = "Адрес: Участок №1";
            // 
            // labelHouseClass
            // 
            this.labelHouseClass.AutoSize = true;
            this.labelHouseClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelHouseClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseClass.Location = new System.Drawing.Point(40, 270);
            this.labelHouseClass.Name = "labelHouseClass";
            this.labelHouseClass.Size = new System.Drawing.Size(110, 19);
            this.labelHouseClass.TabIndex = 8;
            this.labelHouseClass.Text = "Класс: Премиум";
            // 
            // labelHouseName
            // 
            this.labelHouseName.AutoSize = true;
            this.labelHouseName.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.labelHouseName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseName.Location = new System.Drawing.Point(40, 240);
            this.labelHouseName.Name = "labelHouseName";
            this.labelHouseName.Size = new System.Drawing.Size(134, 20);
            this.labelHouseName.TabIndex = 7;
            this.labelHouseName.Text = "Дом: Коттедж №1";
            // 
            // labelClientEmail
            // 
            this.labelClientEmail.AutoSize = true;
            this.labelClientEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelClientEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClientEmail.Location = new System.Drawing.Point(40, 200);
            this.labelClientEmail.Name = "labelClientEmail";
            this.labelClientEmail.Size = new System.Drawing.Size(172, 19);
            this.labelClientEmail.TabIndex = 6;
            this.labelClientEmail.Text = "Email: client@example.com";
            // 
            // labelClientPhone
            // 
            this.labelClientPhone.AutoSize = true;
            this.labelClientPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelClientPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClientPhone.Location = new System.Drawing.Point(40, 170);
            this.labelClientPhone.Name = "labelClientPhone";
            this.labelClientPhone.Size = new System.Drawing.Size(188, 19);
            this.labelClientPhone.TabIndex = 5;
            this.labelClientPhone.Text = "Телефон: +7 999 999-99-99";
            // 
            // labelClientPassport
            // 
            this.labelClientPassport.AutoSize = true;
            this.labelClientPassport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelClientPassport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClientPassport.Location = new System.Drawing.Point(40, 140);
            this.labelClientPassport.Name = "labelClientPassport";
            this.labelClientPassport.Size = new System.Drawing.Size(153, 19);
            this.labelClientPassport.TabIndex = 4;
            this.labelClientPassport.Text = "Паспорт: 1234 567890";
            // 
            // labelClientName
            // 
            this.labelClientName.AutoSize = true;
            this.labelClientName.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.labelClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClientName.Location = new System.Drawing.Point(40, 110);
            this.labelClientName.Name = "labelClientName";
            this.labelClientName.Size = new System.Drawing.Size(238, 20);
            this.labelClientName.TabIndex = 3;
            this.labelClientName.Text = "Клиент: Иванов Иван Иванович";
            // 
            // labelOrderDate
            // 
            this.labelOrderDate.AutoSize = true;
            this.labelOrderDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelOrderDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelOrderDate.Location = new System.Drawing.Point(40, 80);
            this.labelOrderDate.Name = "labelOrderDate";
            this.labelOrderDate.Size = new System.Drawing.Size(155, 19);
            this.labelOrderDate.TabIndex = 2;
            this.labelOrderDate.Text = "Дата: 01.01.2024 12:00";
            // 
            // labelOrderNumber
            // 
            this.labelOrderNumber.AutoSize = true;
            this.labelOrderNumber.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelOrderNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelOrderNumber.Location = new System.Drawing.Point(270, 50);
            this.labelOrderNumber.Name = "labelOrderNumber";
            this.labelOrderNumber.Size = new System.Drawing.Size(248, 25);
            this.labelOrderNumber.TabIndex = 1;
            this.labelOrderNumber.Text = "КАССОВЫЙ ЧЕК № 00000";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTitle.Location = new System.Drawing.Point(180, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(487, 32);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "БАЗА ОТДЫХА \"ПРЕМИУМ КОТТЕДЖИ\"";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(800, 850);
            this.Controls.Add(this.panelReceiptContent);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кассовый чек";
            this.Load += new System.EventHandler(this.ReceiptForm_Load);
            this.panelReceiptContent.ResumeLayout(false);
            this.panelReceiptContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}