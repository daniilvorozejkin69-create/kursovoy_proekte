namespace kursovoy_proekt
{
    partial class Check
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelServicesContainer;
        private System.Windows.Forms.Panel panelServicesList;

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
        private System.Windows.Forms.Label labelServicesTitle;
        private System.Windows.Forms.ListBox listBoxServices;
        private System.Windows.Forms.Label labelServiceDetails;
        private System.Windows.Forms.TextBox textBoxServiceDescription;
        private System.Windows.Forms.Label labelServicePrice;
        private System.Windows.Forms.Label labelSelectedServices;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Button buttonRemoveService;
        private System.Windows.Forms.Button buttonClearServices;

        private System.Windows.Forms.Label labelCostTitle;
        private System.Windows.Forms.Label labelHouseCostLabel;
        private System.Windows.Forms.Label labelHouseCost;
        private System.Windows.Forms.Label labelServicesCostLabel;
        private System.Windows.Forms.Label labelServicesCost;
        private System.Windows.Forms.Label labelDiscountLabel;
        private System.Windows.Forms.Label labelDiscountAmount;
        private System.Windows.Forms.Label labelTotalCostLabel;
        private System.Windows.Forms.Label labelTotalCost;

        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonBackToMenu;

        private System.Windows.Forms.Label labelBookingTitle;
        private System.Windows.Forms.ComboBox comboBoxBookings;
        private System.Windows.Forms.Button buttonLoadBooking;

        private System.Windows.Forms.Label labelDiscountTitle;
        private System.Windows.Forms.ComboBox comboBoxDiscount;
        private System.Windows.Forms.Label labelDiscountInfo;

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
            this.labelDiscountInfo = new System.Windows.Forms.Label();
            this.comboBoxDiscount = new System.Windows.Forms.ComboBox();
            this.labelDiscountTitle = new System.Windows.Forms.Label();
            this.comboBoxBookings = new System.Windows.Forms.ComboBox();
            this.buttonLoadBooking = new System.Windows.Forms.Button();
            this.labelBookingTitle = new System.Windows.Forms.Label();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.labelTotalCostLabel = new System.Windows.Forms.Label();
            this.labelDiscountAmount = new System.Windows.Forms.Label();
            this.labelDiscountLabel = new System.Windows.Forms.Label();
            this.labelServicesCost = new System.Windows.Forms.Label();
            this.labelServicesCostLabel = new System.Windows.Forms.Label();
            this.labelHouseCost = new System.Windows.Forms.Label();
            this.labelHouseCostLabel = new System.Windows.Forms.Label();
            this.labelCostTitle = new System.Windows.Forms.Label();
            this.buttonClearServices = new System.Windows.Forms.Button();
            this.buttonRemoveService = new System.Windows.Forms.Button();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.labelSelectedServices = new System.Windows.Forms.Label();
            this.panelServicesContainer = new System.Windows.Forms.Panel();
            this.labelServicePrice = new System.Windows.Forms.Label();
            this.textBoxServiceDescription = new System.Windows.Forms.TextBox();
            this.labelServiceDetails = new System.Windows.Forms.Label();
            this.listBoxServices = new System.Windows.Forms.ListBox();
            this.labelServicesTitle = new System.Windows.Forms.Label();
            this.panelServicesList = new System.Windows.Forms.Panel();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.panelServicesContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1166, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(30, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(305, 45);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Оформление заказа";
            // 
            // panelGreenLine
            // 
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 80);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(1166, 3);
            this.panelGreenLine.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.labelDiscountInfo);
            this.panelContent.Controls.Add(this.comboBoxDiscount);
            this.panelContent.Controls.Add(this.labelDiscountTitle);
            this.panelContent.Controls.Add(this.comboBoxBookings);
            this.panelContent.Controls.Add(this.buttonLoadBooking);
            this.panelContent.Controls.Add(this.labelBookingTitle);
            this.panelContent.Controls.Add(this.buttonBackToMenu);
            this.panelContent.Controls.Add(this.buttonCreateOrder);
            this.panelContent.Controls.Add(this.labelTotalCost);
            this.panelContent.Controls.Add(this.labelTotalCostLabel);
            this.panelContent.Controls.Add(this.labelDiscountAmount);
            this.panelContent.Controls.Add(this.labelDiscountLabel);
            this.panelContent.Controls.Add(this.labelServicesCost);
            this.panelContent.Controls.Add(this.labelServicesCostLabel);
            this.panelContent.Controls.Add(this.labelHouseCost);
            this.panelContent.Controls.Add(this.labelHouseCostLabel);
            this.panelContent.Controls.Add(this.labelCostTitle);
            this.panelContent.Controls.Add(this.buttonClearServices);
            this.panelContent.Controls.Add(this.buttonRemoveService);
            this.panelContent.Controls.Add(this.buttonAddService);
            this.panelContent.Controls.Add(this.dataGridViewServices);
            this.panelContent.Controls.Add(this.labelSelectedServices);
            this.panelContent.Controls.Add(this.panelServicesContainer);
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
            this.panelContent.Size = new System.Drawing.Size(1166, 617);
            this.panelContent.TabIndex = 2;
            // 
            // labelDiscountInfo
            // 
            this.labelDiscountInfo.AutoSize = true;
            this.labelDiscountInfo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.labelDiscountInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.labelDiscountInfo.Location = new System.Drawing.Point(690, 145);
            this.labelDiscountInfo.Name = "labelDiscountInfo";
            this.labelDiscountInfo.Size = new System.Drawing.Size(0, 13);
            this.labelDiscountInfo.TabIndex = 35;
            // 
            // comboBoxDiscount
            // 
            this.comboBoxDiscount.BackColor = System.Drawing.Color.White;
            this.comboBoxDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDiscount.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.comboBoxDiscount.FormattingEnabled = true;
            this.comboBoxDiscount.Location = new System.Drawing.Point(678, 25);
            this.comboBoxDiscount.Name = "comboBoxDiscount";
            this.comboBoxDiscount.Size = new System.Drawing.Size(250, 25);
            this.comboBoxDiscount.TabIndex = 34;
            // 
            // labelDiscountTitle
            // 
            this.labelDiscountTitle.AutoSize = true;
            this.labelDiscountTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelDiscountTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDiscountTitle.Location = new System.Drawing.Point(675, 5);
            this.labelDiscountTitle.Name = "labelDiscountTitle";
            this.labelDiscountTitle.Size = new System.Drawing.Size(120, 17);
            this.labelDiscountTitle.TabIndex = 33;
            this.labelDiscountTitle.Text = "Выберите скидку:";
            // 
            // comboBoxBookings
            // 
            this.comboBoxBookings.BackColor = System.Drawing.Color.White;
            this.comboBoxBookings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxBookings.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.comboBoxBookings.FormattingEnabled = true;
            this.comboBoxBookings.Location = new System.Drawing.Point(22, 78);
            this.comboBoxBookings.Name = "comboBoxBookings";
            this.comboBoxBookings.Size = new System.Drawing.Size(370, 25);
            this.comboBoxBookings.TabIndex = 26;
            // 
            // buttonLoadBooking
            // 
            this.buttonLoadBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonLoadBooking.FlatAppearance.BorderSize = 0;
            this.buttonLoadBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadBooking.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.buttonLoadBooking.ForeColor = System.Drawing.Color.White;
            this.buttonLoadBooking.Location = new System.Drawing.Point(408, 76);
            this.buttonLoadBooking.Name = "buttonLoadBooking";
            this.buttonLoadBooking.Size = new System.Drawing.Size(170, 27);
            this.buttonLoadBooking.TabIndex = 27;
            this.buttonLoadBooking.Text = "📥 Загрузить бронирование";
            this.buttonLoadBooking.UseVisualStyleBackColor = false;
            // 
            // labelBookingTitle
            // 
            this.labelBookingTitle.AutoSize = true;
            this.labelBookingTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelBookingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelBookingTitle.Location = new System.Drawing.Point(22, 53);
            this.labelBookingTitle.Name = "labelBookingTitle";
            this.labelBookingTitle.Size = new System.Drawing.Size(169, 17);
            this.labelBookingTitle.TabIndex = 28;
            this.labelBookingTitle.Text = "Загрузить бронирование:";
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
            this.buttonBackToMenu.Location = new System.Drawing.Point(966, 540);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(160, 50);
            this.buttonBackToMenu.TabIndex = 24;
            this.buttonBackToMenu.Text = "🏠 В меню";
            this.buttonBackToMenu.UseVisualStyleBackColor = false;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonCreateOrder.FlatAppearance.BorderSize = 0;
            this.buttonCreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateOrder.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonCreateOrder.ForeColor = System.Drawing.Color.White;
            this.buttonCreateOrder.Location = new System.Drawing.Point(20, 540);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(936, 50);
            this.buttonCreateOrder.TabIndex = 23;
            this.buttonCreateOrder.Text = "✅ ОФОРМИТЬ ЗАКАЗ";
            this.buttonCreateOrder.UseVisualStyleBackColor = false;
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelTotalCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelTotalCost.Location = new System.Drawing.Point(880, 478);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(66, 25);
            this.labelTotalCost.TabIndex = 22;
            this.labelTotalCost.Text = "0,00 ₽";
            // 
            // labelTotalCostLabel
            // 
            this.labelTotalCostLabel.AutoSize = true;
            this.labelTotalCostLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelTotalCostLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalCostLabel.Location = new System.Drawing.Point(690, 481);
            this.labelTotalCostLabel.Name = "labelTotalCostLabel";
            this.labelTotalCostLabel.Size = new System.Drawing.Size(127, 21);
            this.labelTotalCostLabel.TabIndex = 21;
            this.labelTotalCostLabel.Text = "Итого к оплате:";
            // 
            // labelDiscountAmount
            // 
            this.labelDiscountAmount.AutoSize = true;
            this.labelDiscountAmount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelDiscountAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.labelDiscountAmount.Location = new System.Drawing.Point(880, 418);
            this.labelDiscountAmount.Name = "labelDiscountAmount";
            this.labelDiscountAmount.Size = new System.Drawing.Size(53, 21);
            this.labelDiscountAmount.TabIndex = 32;
            this.labelDiscountAmount.Text = "0,00 ₽";
            // 
            // labelDiscountLabel
            // 
            this.labelDiscountLabel.AutoSize = true;
            this.labelDiscountLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelDiscountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDiscountLabel.Location = new System.Drawing.Point(690, 418);
            this.labelDiscountLabel.Name = "labelDiscountLabel";
            this.labelDiscountLabel.Size = new System.Drawing.Size(65, 21);
            this.labelDiscountLabel.TabIndex = 31;
            this.labelDiscountLabel.Text = "Скидка:";
            // 
            // labelServicesCost
            // 
            this.labelServicesCost.AutoSize = true;
            this.labelServicesCost.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelServicesCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelServicesCost.Location = new System.Drawing.Point(880, 380);
            this.labelServicesCost.Name = "labelServicesCost";
            this.labelServicesCost.Size = new System.Drawing.Size(53, 21);
            this.labelServicesCost.TabIndex = 20;
            this.labelServicesCost.Text = "0,00 ₽";
            // 
            // labelServicesCostLabel
            // 
            this.labelServicesCostLabel.AutoSize = true;
            this.labelServicesCostLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelServicesCostLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelServicesCostLabel.Location = new System.Drawing.Point(690, 388);
            this.labelServicesCostLabel.Name = "labelServicesCostLabel";
            this.labelServicesCostLabel.Size = new System.Drawing.Size(105, 21);
            this.labelServicesCostLabel.TabIndex = 19;
            this.labelServicesCostLabel.Text = "Услуги (итог):";
            // 
            // labelHouseCost
            // 
            this.labelHouseCost.AutoSize = true;
            this.labelHouseCost.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelHouseCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseCost.Location = new System.Drawing.Point(880, 358);
            this.labelHouseCost.Name = "labelHouseCost";
            this.labelHouseCost.Size = new System.Drawing.Size(53, 21);
            this.labelHouseCost.TabIndex = 18;
            this.labelHouseCost.Text = "0,00 ₽";
            // 
            // labelHouseCostLabel
            // 
            this.labelHouseCostLabel.AutoSize = true;
            this.labelHouseCostLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelHouseCostLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseCostLabel.Location = new System.Drawing.Point(690, 358);
            this.labelHouseCostLabel.Name = "labelHouseCostLabel";
            this.labelHouseCostLabel.Size = new System.Drawing.Size(105, 21);
            this.labelHouseCostLabel.TabIndex = 17;
            this.labelHouseCostLabel.Text = "Проживание:";
            // 
            // labelCostTitle
            // 
            this.labelCostTitle.AutoSize = true;
            this.labelCostTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelCostTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCostTitle.Location = new System.Drawing.Point(689, 333);
            this.labelCostTitle.Name = "labelCostTitle";
            this.labelCostTitle.Size = new System.Drawing.Size(172, 25);
            this.labelCostTitle.TabIndex = 16;
            this.labelCostTitle.Text = "Расчет стоимости:";
            // 
            // buttonClearServices
            // 
            this.buttonClearServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.buttonClearServices.FlatAppearance.BorderSize = 0;
            this.buttonClearServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearServices.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonClearServices.ForeColor = System.Drawing.Color.White;
            this.buttonClearServices.Location = new System.Drawing.Point(700, 295);
            this.buttonClearServices.Name = "buttonClearServices";
            this.buttonClearServices.Size = new System.Drawing.Size(170, 30);
            this.buttonClearServices.TabIndex = 15;
            this.buttonClearServices.Text = "🗑️ Очистить все";
            this.buttonClearServices.UseVisualStyleBackColor = false;
            // 
            // buttonRemoveService
            // 
            this.buttonRemoveService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.buttonRemoveService.FlatAppearance.BorderSize = 0;
            this.buttonRemoveService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveService.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonRemoveService.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveService.Location = new System.Drawing.Point(520, 295);
            this.buttonRemoveService.Name = "buttonRemoveService";
            this.buttonRemoveService.Size = new System.Drawing.Size(170, 30);
            this.buttonRemoveService.TabIndex = 14;
            this.buttonRemoveService.Text = "➖ Удалить выбранное";
            this.buttonRemoveService.UseVisualStyleBackColor = false;
            // 
            // buttonAddService
            // 
            this.buttonAddService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonAddService.FlatAppearance.BorderSize = 0;
            this.buttonAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddService.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.buttonAddService.ForeColor = System.Drawing.Color.White;
            this.buttonAddService.Location = new System.Drawing.Point(340, 295);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Size = new System.Drawing.Size(170, 30);
            this.buttonAddService.TabIndex = 13;
            this.buttonAddService.Text = "➕ Добавить выбранное";
            this.buttonAddService.UseVisualStyleBackColor = false;
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.AllowUserToAddRows = false;
            this.dataGridViewServices.AllowUserToDeleteRows = false;
            this.dataGridViewServices.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewServices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewServices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewServices.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewServices.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewServices.EnableHeadersVisualStyles = false;
            this.dataGridViewServices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            this.dataGridViewServices.Location = new System.Drawing.Point(340, 145);
            this.dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewServices.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewServices.RowHeadersVisible = false;
            this.dataGridViewServices.RowTemplate.Height = 35;
            this.dataGridViewServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewServices.Size = new System.Drawing.Size(757, 140);
            this.dataGridViewServices.TabIndex = 12;
            // 
            // labelSelectedServices
            // 
            this.labelSelectedServices.AutoSize = true;
            this.labelSelectedServices.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelSelectedServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelSelectedServices.Location = new System.Drawing.Point(345, 122);
            this.labelSelectedServices.Name = "labelSelectedServices";
            this.labelSelectedServices.Size = new System.Drawing.Size(208, 20);
            this.labelSelectedServices.TabIndex = 11;
            this.labelSelectedServices.Text = "Выбранные услуги в заказе:";
            // 
            // panelServicesContainer
            // 
            this.panelServicesContainer.BackColor = System.Drawing.Color.White;
            this.panelServicesContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelServicesContainer.Controls.Add(this.labelServicePrice);
            this.panelServicesContainer.Controls.Add(this.textBoxServiceDescription);
            this.panelServicesContainer.Controls.Add(this.labelServiceDetails);
            this.panelServicesContainer.Controls.Add(this.listBoxServices);
            this.panelServicesContainer.Controls.Add(this.labelServicesTitle);
            this.panelServicesContainer.Controls.Add(this.panelServicesList);
            this.panelServicesContainer.Location = new System.Drawing.Point(12, 174);
            this.panelServicesContainer.Name = "panelServicesContainer";
            this.panelServicesContainer.Size = new System.Drawing.Size(300, 340);
            this.panelServicesContainer.TabIndex = 10;
            // 
            // labelServicePrice
            // 
            this.labelServicePrice.AutoSize = true;
            this.labelServicePrice.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelServicePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelServicePrice.Location = new System.Drawing.Point(10, 300);
            this.labelServicePrice.Name = "labelServicePrice";
            this.labelServicePrice.Size = new System.Drawing.Size(71, 20);
            this.labelServicePrice.TabIndex = 5;
            this.labelServicePrice.Text = "Цена: 0₽";
            // 
            // textBoxServiceDescription
            // 
            this.textBoxServiceDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.textBoxServiceDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxServiceDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxServiceDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxServiceDescription.Location = new System.Drawing.Point(10, 250);
            this.textBoxServiceDescription.Multiline = true;
            this.textBoxServiceDescription.Name = "textBoxServiceDescription";
            this.textBoxServiceDescription.ReadOnly = true;
            this.textBoxServiceDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxServiceDescription.Size = new System.Drawing.Size(275, 45);
            this.textBoxServiceDescription.TabIndex = 4;
            this.textBoxServiceDescription.Text = "Выберите услугу для просмотра описания...";
            // 
            // labelServiceDetails
            // 
            this.labelServiceDetails.AutoSize = true;
            this.labelServiceDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelServiceDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelServiceDetails.Location = new System.Drawing.Point(10, 230);
            this.labelServiceDetails.Name = "labelServiceDetails";
            this.labelServiceDetails.Size = new System.Drawing.Size(117, 17);
            this.labelServiceDetails.TabIndex = 3;
            this.labelServiceDetails.Text = "Описание услуги:";
            // 
            // listBoxServices
            // 
            this.listBoxServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.listBoxServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxServices.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.listBoxServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBoxServices.FormattingEnabled = true;
            this.listBoxServices.ItemHeight = 17;
            this.listBoxServices.Location = new System.Drawing.Point(10, 60);
            this.listBoxServices.Name = "listBoxServices";
            this.listBoxServices.Size = new System.Drawing.Size(275, 170);
            this.listBoxServices.TabIndex = 2;
            // 
            // labelServicesTitle
            // 
            this.labelServicesTitle.AutoSize = true;
            this.labelServicesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelServicesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelServicesTitle.Location = new System.Drawing.Point(10, 15);
            this.labelServicesTitle.Name = "labelServicesTitle";
            this.labelServicesTitle.Size = new System.Drawing.Size(284, 21);
            this.labelServicesTitle.TabIndex = 1;
            this.labelServicesTitle.Text = "Доступные дополнительные услуги:";
            // 
            // panelServicesList
            // 
            this.panelServicesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelServicesList.Location = new System.Drawing.Point(10, 40);
            this.panelServicesList.Name = "panelServicesList";
            this.panelServicesList.Size = new System.Drawing.Size(275, 2);
            this.panelServicesList.TabIndex = 0;
            // 
            // labelStayDays
            // 
            this.labelStayDays.AutoSize = true;
            this.labelStayDays.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.labelStayDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelStayDays.Location = new System.Drawing.Point(292, 126);
            this.labelStayDays.Name = "labelStayDays";
            this.labelStayDays.Size = new System.Drawing.Size(47, 17);
            this.labelStayDays.TabIndex = 9;
            this.labelStayDays.Text = "1 день";
            // 
            // dateTimePickerCheckOut
            // 
            this.dateTimePickerCheckOut.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerCheckOut.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateTimePickerCheckOut.Location = new System.Drawing.Point(156, 124);
            this.dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            this.dateTimePickerCheckOut.Size = new System.Drawing.Size(130, 25);
            this.dateTimePickerCheckOut.TabIndex = 8;
            // 
            // labelCheckOut
            // 
            this.labelCheckOut.AutoSize = true;
            this.labelCheckOut.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelCheckOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCheckOut.Location = new System.Drawing.Point(153, 106);
            this.labelCheckOut.Name = "labelCheckOut";
            this.labelCheckOut.Size = new System.Drawing.Size(89, 17);
            this.labelCheckOut.TabIndex = 7;
            this.labelCheckOut.Text = "Дата выезда:";
            // 
            // dateTimePickerCheckIn
            // 
            this.dateTimePickerCheckIn.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerCheckIn.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateTimePickerCheckIn.Location = new System.Drawing.Point(20, 124);
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new System.Drawing.Size(130, 25);
            this.dateTimePickerCheckIn.TabIndex = 6;
            // 
            // labelCheckIn
            // 
            this.labelCheckIn.AutoSize = true;
            this.labelCheckIn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelCheckIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCheckIn.Location = new System.Drawing.Point(19, 106);
            this.labelCheckIn.Name = "labelCheckIn";
            this.labelCheckIn.Size = new System.Drawing.Size(85, 17);
            this.labelCheckIn.TabIndex = 5;
            this.labelCheckIn.Text = "Дата заезда:";
            // 
            // labelHouseInfo
            // 
            this.labelHouseInfo.AutoSize = true;
            this.labelHouseInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.labelHouseInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.labelHouseInfo.Location = new System.Drawing.Point(685, 35);
            this.labelHouseInfo.Name = "labelHouseInfo";
            this.labelHouseInfo.Size = new System.Drawing.Size(0, 15);
            this.labelHouseInfo.TabIndex = 4;
            // 
            // comboBoxHouses
            // 
            this.comboBoxHouses.BackColor = System.Drawing.Color.White;
            this.comboBoxHouses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHouses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxHouses.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.comboBoxHouses.FormattingEnabled = true;
            this.comboBoxHouses.Location = new System.Drawing.Point(398, 25);
            this.comboBoxHouses.Name = "comboBoxHouses";
            this.comboBoxHouses.Size = new System.Drawing.Size(270, 25);
            this.comboBoxHouses.TabIndex = 3;
            // 
            // labelHouse
            // 
            this.labelHouse.AutoSize = true;
            this.labelHouse.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelHouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouse.Location = new System.Drawing.Point(395, 5);
            this.labelHouse.Name = "labelHouse";
            this.labelHouse.Size = new System.Drawing.Size(103, 17);
            this.labelHouse.TabIndex = 2;
            this.labelHouse.Text = "Выберите дом:";
            // 
            // comboBoxClients
            // 
            this.comboBoxClients.BackColor = System.Drawing.Color.White;
            this.comboBoxClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxClients.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.comboBoxClients.FormattingEnabled = true;
            this.comboBoxClients.Location = new System.Drawing.Point(22, 25);
            this.comboBoxClients.Name = "comboBoxClients";
            this.comboBoxClients.Size = new System.Drawing.Size(370, 25);
            this.comboBoxClients.TabIndex = 1;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClient.Location = new System.Drawing.Point(20, 5);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(127, 17);
            this.labelClient.TabIndex = 0;
            this.labelClient.Text = "Выберите клиента:";
            // 
            // Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 700);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1116, 739);
            this.Name = "Check";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оформление заказа - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            this.panelServicesContainer.ResumeLayout(false);
            this.panelServicesContainer.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}