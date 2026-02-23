namespace kursovoy_proekt
{
    partial class DepositForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelContent;

        // Информация о бронировании
        private System.Windows.Forms.GroupBox groupBoxBookingInfo;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelHouse;
        private System.Windows.Forms.Label labelCheckIn;
        private System.Windows.Forms.Label labelClientInfo;
        private System.Windows.Forms.Label labelPhoneInfo;
        private System.Windows.Forms.Label labelHouseInfo;
        private System.Windows.Forms.Label labelCheckInInfo;

        // Текущие суммы
        private System.Windows.Forms.GroupBox groupBoxCurrentAmounts;
        private System.Windows.Forms.Label labelCurrentDepositText;
        private System.Windows.Forms.Label labelCurrentDeposit;
        private System.Windows.Forms.Label labelBookingTotalText;
        private System.Windows.Forms.Label labelBookingTotal;
        private System.Windows.Forms.Label labelRemainingText;
        private System.Windows.Forms.Label labelRemaining;
        private System.Windows.Forms.ProgressBar progressBarDeposit;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label labelDepositPercentage;

        // Быстрые кнопки
        private System.Windows.Forms.GroupBox groupBoxQuickButtons;
        private System.Windows.Forms.Button buttonFullDeposit;
        private System.Windows.Forms.Button buttonHalfDeposit;
        private System.Windows.Forms.Button buttonCustom;

        // Ввод суммы
        private System.Windows.Forms.GroupBox groupBoxNewDeposit;
        private System.Windows.Forms.Label labelNewDeposit;
        private System.Windows.Forms.NumericUpDown numericUpDownDeposit;
        private System.Windows.Forms.Label labelNewDepositAmount;
        private System.Windows.Forms.Label labelNewDepositAmountText;
        private System.Windows.Forms.Label labelNewRemaining;
        private System.Windows.Forms.Label labelNewRemainingText;

        // Кнопки действий
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonPrintReceipt;

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
            this.buttonPrintReceipt = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxNewDeposit = new System.Windows.Forms.GroupBox();
            this.labelNewRemaining = new System.Windows.Forms.Label();
            this.labelNewRemainingText = new System.Windows.Forms.Label();
            this.labelNewDepositAmount = new System.Windows.Forms.Label();
            this.labelNewDepositAmountText = new System.Windows.Forms.Label();
            this.numericUpDownDeposit = new System.Windows.Forms.NumericUpDown();
            this.labelNewDeposit = new System.Windows.Forms.Label();
            this.groupBoxQuickButtons = new System.Windows.Forms.GroupBox();
            this.buttonCustom = new System.Windows.Forms.Button();
            this.buttonHalfDeposit = new System.Windows.Forms.Button();
            this.buttonFullDeposit = new System.Windows.Forms.Button();
            this.groupBoxCurrentAmounts = new System.Windows.Forms.GroupBox();
            this.labelDepositPercentage = new System.Windows.Forms.Label();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressBarDeposit = new System.Windows.Forms.ProgressBar();
            this.labelRemaining = new System.Windows.Forms.Label();
            this.labelRemainingText = new System.Windows.Forms.Label();
            this.labelBookingTotal = new System.Windows.Forms.Label();
            this.labelBookingTotalText = new System.Windows.Forms.Label();
            this.labelCurrentDeposit = new System.Windows.Forms.Label();
            this.labelCurrentDepositText = new System.Windows.Forms.Label();
            this.groupBoxBookingInfo = new System.Windows.Forms.GroupBox();
            this.labelCheckInInfo = new System.Windows.Forms.Label();
            this.labelHouseInfo = new System.Windows.Forms.Label();
            this.labelPhoneInfo = new System.Windows.Forms.Label();
            this.labelClientInfo = new System.Windows.Forms.Label();
            this.labelCheckIn = new System.Windows.Forms.Label();
            this.labelHouse = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelClient = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.groupBoxNewDeposit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeposit)).BeginInit();
            this.groupBoxQuickButtons.SuspendLayout();
            this.groupBoxCurrentAmounts.SuspendLayout();
            this.groupBoxBookingInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(500, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(20, 15);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(241, 37);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Внесение депозита";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.buttonPrintReceipt);
            this.panelContent.Controls.Add(this.buttonCancel);
            this.panelContent.Controls.Add(this.buttonSave);
            this.panelContent.Controls.Add(this.groupBoxNewDeposit);
            this.panelContent.Controls.Add(this.groupBoxQuickButtons);
            this.panelContent.Controls.Add(this.groupBoxCurrentAmounts);
            this.panelContent.Controls.Add(this.groupBoxBookingInfo);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(15);
            this.panelContent.Size = new System.Drawing.Size(500, 640);
            this.panelContent.TabIndex = 1;
            // 
            // buttonPrintReceipt
            // 
            this.buttonPrintReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPrintReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonPrintReceipt.FlatAppearance.BorderSize = 0;
            this.buttonPrintReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrintReceipt.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonPrintReceipt.ForeColor = System.Drawing.Color.White;
            this.buttonPrintReceipt.Location = new System.Drawing.Point(330, 525);
            this.buttonPrintReceipt.Name = "buttonPrintReceipt";
            this.buttonPrintReceipt.Size = new System.Drawing.Size(150, 50);
            this.buttonPrintReceipt.TabIndex = 6;
            this.buttonPrintReceipt.Text = "🖨️ Печать чека";
            this.buttonPrintReceipt.UseVisualStyleBackColor = false;
            this.buttonPrintReceipt.Click += new System.EventHandler(this.buttonPrintReceipt_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonCancel.FlatAppearance.BorderSize = 2;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonCancel.Location = new System.Drawing.Point(170, 525);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(150, 50);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "✕ Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonSave.Enabled = false;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(15, 525);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 50);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "💾 Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxNewDeposit
            // 
            this.groupBoxNewDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxNewDeposit.Controls.Add(this.labelNewRemaining);
            this.groupBoxNewDeposit.Controls.Add(this.labelNewRemainingText);
            this.groupBoxNewDeposit.Controls.Add(this.labelNewDepositAmount);
            this.groupBoxNewDeposit.Controls.Add(this.labelNewDepositAmountText);
            this.groupBoxNewDeposit.Controls.Add(this.numericUpDownDeposit);
            this.groupBoxNewDeposit.Controls.Add(this.labelNewDeposit);
            this.groupBoxNewDeposit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxNewDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxNewDeposit.Location = new System.Drawing.Point(15, 375);
            this.groupBoxNewDeposit.Name = "groupBoxNewDeposit";
            this.groupBoxNewDeposit.Size = new System.Drawing.Size(465, 140);
            this.groupBoxNewDeposit.TabIndex = 3;
            this.groupBoxNewDeposit.TabStop = false;
            this.groupBoxNewDeposit.Text = "Внесение депозита";
            // 
            // labelNewRemaining
            // 
            this.labelNewRemaining.AutoSize = true;
            this.labelNewRemaining.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelNewRemaining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelNewRemaining.Location = new System.Drawing.Point(200, 95);
            this.labelNewRemaining.Name = "labelNewRemaining";
            this.labelNewRemaining.Size = new System.Drawing.Size(68, 20);
            this.labelNewRemaining.TabIndex = 5;
            this.labelNewRemaining.Text = "0,00 ₽";
            // 
            // labelNewRemainingText
            // 
            this.labelNewRemainingText.AutoSize = true;
            this.labelNewRemainingText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelNewRemainingText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelNewRemainingText.Location = new System.Drawing.Point(15, 95);
            this.labelNewRemainingText.Name = "labelNewRemainingText";
            this.labelNewRemainingText.Size = new System.Drawing.Size(146, 20);
            this.labelNewRemainingText.TabIndex = 4;
            this.labelNewRemainingText.Text = "Новый остаток:";
            // 
            // labelNewDepositAmount
            // 
            this.labelNewDepositAmount.AutoSize = true;
            this.labelNewDepositAmount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelNewDepositAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.labelNewDepositAmount.Location = new System.Drawing.Point(200, 70);
            this.labelNewDepositAmount.Name = "labelNewDepositAmount";
            this.labelNewDepositAmount.Size = new System.Drawing.Size(68, 20);
            this.labelNewDepositAmount.TabIndex = 3;
            this.labelNewDepositAmount.Text = "0,00 ₽";
            // 
            // labelNewDepositAmountText
            // 
            this.labelNewDepositAmountText.AutoSize = true;
            this.labelNewDepositAmountText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelNewDepositAmountText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelNewDepositAmountText.Location = new System.Drawing.Point(15, 70);
            this.labelNewDepositAmountText.Name = "labelNewDepositAmountText";
            this.labelNewDepositAmountText.Size = new System.Drawing.Size(177, 20);
            this.labelNewDepositAmountText.TabIndex = 2;
            this.labelNewDepositAmountText.Text = "Общий депозит будет:";
            // 
            // numericUpDownDeposit
            // 
            this.numericUpDownDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownDeposit.DecimalPlaces = 2;
            this.numericUpDownDeposit.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.numericUpDownDeposit.Location = new System.Drawing.Point(15, 35);
            this.numericUpDownDeposit.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownDeposit.Name = "numericUpDownDeposit";
            this.numericUpDownDeposit.Size = new System.Drawing.Size(435, 32);
            this.numericUpDownDeposit.TabIndex = 1;
            this.numericUpDownDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownDeposit.ThousandsSeparator = true;
            this.numericUpDownDeposit.ValueChanged += new System.EventHandler(this.numericUpDownDeposit_ValueChanged);
            // 
            // labelNewDeposit
            // 
            this.labelNewDeposit.AutoSize = true;
            this.labelNewDeposit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelNewDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelNewDeposit.Location = new System.Drawing.Point(15, 15);
            this.labelNewDeposit.Name = "labelNewDeposit";
            this.labelNewDeposit.Size = new System.Drawing.Size(143, 19);
            this.labelNewDeposit.TabIndex = 0;
            this.labelNewDeposit.Text = "Сумма к внесению:";
            // 
            // groupBoxQuickButtons
            // 
            this.groupBoxQuickButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxQuickButtons.Controls.Add(this.buttonCustom);
            this.groupBoxQuickButtons.Controls.Add(this.buttonHalfDeposit);
            this.groupBoxQuickButtons.Controls.Add(this.buttonFullDeposit);
            this.groupBoxQuickButtons.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxQuickButtons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxQuickButtons.Location = new System.Drawing.Point(15, 290);
            this.groupBoxQuickButtons.Name = "groupBoxQuickButtons";
            this.groupBoxQuickButtons.Size = new System.Drawing.Size(465, 75);
            this.groupBoxQuickButtons.TabIndex = 2;
            this.groupBoxQuickButtons.TabStop = false;
            this.groupBoxQuickButtons.Text = "Быстрый выбор суммы";
            // 
            // buttonCustom
            // 
            this.buttonCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonCustom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.buttonCustom.FlatAppearance.BorderSize = 1;
            this.buttonCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.buttonCustom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonCustom.Location = new System.Drawing.Point(320, 30);
            this.buttonCustom.Name = "buttonCustom";
            this.buttonCustom.Size = new System.Drawing.Size(130, 35);
            this.buttonCustom.TabIndex = 2;
            this.buttonCustom.Text = "✏️ Своя сумма";
            this.buttonCustom.UseVisualStyleBackColor = false;
            // 
            // buttonHalfDeposit
            // 
            this.buttonHalfDeposit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonHalfDeposit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.buttonHalfDeposit.FlatAppearance.BorderSize = 1;
            this.buttonHalfDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHalfDeposit.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.buttonHalfDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonHalfDeposit.Location = new System.Drawing.Point(165, 30);
            this.buttonHalfDeposit.Name = "buttonHalfDeposit";
            this.buttonHalfDeposit.Size = new System.Drawing.Size(145, 35);
            this.buttonHalfDeposit.TabIndex = 1;
            this.buttonHalfDeposit.Text = "½ 50% от остатка";
            this.buttonHalfDeposit.UseVisualStyleBackColor = false;
            this.buttonHalfDeposit.Click += new System.EventHandler(this.buttonHalfDeposit_Click);
            // 
            // buttonFullDeposit
            // 
            this.buttonFullDeposit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.buttonFullDeposit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.buttonFullDeposit.FlatAppearance.BorderSize = 1;
            this.buttonFullDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFullDeposit.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.buttonFullDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonFullDeposit.Location = new System.Drawing.Point(15, 30);
            this.buttonFullDeposit.Name = "buttonFullDeposit";
            this.buttonFullDeposit.Size = new System.Drawing.Size(140, 35);
            this.buttonFullDeposit.TabIndex = 0;
            this.buttonFullDeposit.Text = "💯 Вся сумма";
            this.buttonFullDeposit.UseVisualStyleBackColor = false;
            this.buttonFullDeposit.Click += new System.EventHandler(this.buttonFullDeposit_Click);
            // 
            // groupBoxCurrentAmounts
            // 
            this.groupBoxCurrentAmounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCurrentAmounts.Controls.Add(this.labelDepositPercentage);
            this.groupBoxCurrentAmounts.Controls.Add(this.labelProgress);
            this.groupBoxCurrentAmounts.Controls.Add(this.progressBarDeposit);
            this.groupBoxCurrentAmounts.Controls.Add(this.labelRemaining);
            this.groupBoxCurrentAmounts.Controls.Add(this.labelRemainingText);
            this.groupBoxCurrentAmounts.Controls.Add(this.labelBookingTotal);
            this.groupBoxCurrentAmounts.Controls.Add(this.labelBookingTotalText);
            this.groupBoxCurrentAmounts.Controls.Add(this.labelCurrentDeposit);
            this.groupBoxCurrentAmounts.Controls.Add(this.labelCurrentDepositText);
            this.groupBoxCurrentAmounts.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxCurrentAmounts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxCurrentAmounts.Location = new System.Drawing.Point(15, 140);
            this.groupBoxCurrentAmounts.Name = "groupBoxCurrentAmounts";
            this.groupBoxCurrentAmounts.Size = new System.Drawing.Size(465, 140);
            this.groupBoxCurrentAmounts.TabIndex = 1;
            this.groupBoxCurrentAmounts.TabStop = false;
            this.groupBoxCurrentAmounts.Text = "Текущие суммы";
            // 
            // labelDepositPercentage
            // 
            this.labelDepositPercentage.AutoSize = true;
            this.labelDepositPercentage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelDepositPercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.labelDepositPercentage.Location = new System.Drawing.Point(15, 115);
            this.labelDepositPercentage.Name = "labelDepositPercentage";
            this.labelDepositPercentage.Size = new System.Drawing.Size(34, 17);
            this.labelDepositPercentage.TabIndex = 8;
            this.labelDepositPercentage.Text = "0,0%";
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelProgress.Location = new System.Drawing.Point(15, 95);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(59, 15);
            this.labelProgress.TabIndex = 7;
            this.labelProgress.Text = "Внесено:";
            // 
            // progressBarDeposit
            // 
            this.progressBarDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDeposit.Location = new System.Drawing.Point(15, 70);
            this.progressBarDeposit.Name = "progressBarDeposit";
            this.progressBarDeposit.Size = new System.Drawing.Size(435, 20);
            this.progressBarDeposit.TabIndex = 6;
            // 
            // labelRemaining
            // 
            this.labelRemaining.AutoSize = true;
            this.labelRemaining.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelRemaining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.labelRemaining.Location = new System.Drawing.Point(200, 45);
            this.labelRemaining.Name = "labelRemaining";
            this.labelRemaining.Size = new System.Drawing.Size(68, 20);
            this.labelRemaining.TabIndex = 5;
            this.labelRemaining.Text = "0,00 ₽";
            // 
            // labelRemainingText
            // 
            this.labelRemainingText.AutoSize = true;
            this.labelRemainingText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelRemainingText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelRemainingText.Location = new System.Drawing.Point(15, 45);
            this.labelRemainingText.Name = "labelRemainingText";
            this.labelRemainingText.Size = new System.Drawing.Size(146, 20);
            this.labelRemainingText.TabIndex = 4;
            this.labelRemainingText.Text = "Остаток к оплате:";
            // 
            // labelBookingTotal
            // 
            this.labelBookingTotal.AutoSize = true;
            this.labelBookingTotal.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelBookingTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelBookingTotal.Location = new System.Drawing.Point(200, 25);
            this.labelBookingTotal.Name = "labelBookingTotal";
            this.labelBookingTotal.Size = new System.Drawing.Size(68, 20);
            this.labelBookingTotal.TabIndex = 3;
            this.labelBookingTotal.Text = "0,00 ₽";
            // 
            // labelBookingTotalText
            // 
            this.labelBookingTotalText.AutoSize = true;
            this.labelBookingTotalText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelBookingTotalText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelBookingTotalText.Location = new System.Drawing.Point(15, 25);
            this.labelBookingTotalText.Name = "labelBookingTotalText";
            this.labelBookingTotalText.Size = new System.Drawing.Size(153, 20);
            this.labelBookingTotalText.TabIndex = 2;
            this.labelBookingTotalText.Text = "Общая стоимость:";
            // 
            // labelCurrentDeposit
            // 
            this.labelCurrentDeposit.AutoSize = true;
            this.labelCurrentDeposit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelCurrentDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCurrentDeposit.Location = new System.Drawing.Point(200, 5);
            this.labelCurrentDeposit.Name = "labelCurrentDeposit";
            this.labelCurrentDeposit.Size = new System.Drawing.Size(68, 20);
            this.labelCurrentDeposit.TabIndex = 1;
            this.labelCurrentDeposit.Text = "0,00 ₽";
            // 
            // labelCurrentDepositText
            // 
            this.labelCurrentDepositText.AutoSize = true;
            this.labelCurrentDepositText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelCurrentDepositText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCurrentDepositText.Location = new System.Drawing.Point(15, 5);
            this.labelCurrentDepositText.Name = "labelCurrentDepositText";
            this.labelCurrentDepositText.Size = new System.Drawing.Size(148, 20);
            this.labelCurrentDepositText.TabIndex = 0;
            this.labelCurrentDepositText.Text = "Текущий депозит:";
            // 
            // groupBoxBookingInfo
            // 
            this.groupBoxBookingInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBookingInfo.Controls.Add(this.labelCheckInInfo);
            this.groupBoxBookingInfo.Controls.Add(this.labelHouseInfo);
            this.groupBoxBookingInfo.Controls.Add(this.labelPhoneInfo);
            this.groupBoxBookingInfo.Controls.Add(this.labelClientInfo);
            this.groupBoxBookingInfo.Controls.Add(this.labelCheckIn);
            this.groupBoxBookingInfo.Controls.Add(this.labelHouse);
            this.groupBoxBookingInfo.Controls.Add(this.labelPhone);
            this.groupBoxBookingInfo.Controls.Add(this.labelClient);
            this.groupBoxBookingInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxBookingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxBookingInfo.Location = new System.Drawing.Point(15, 15);
            this.groupBoxBookingInfo.Name = "groupBoxBookingInfo";
            this.groupBoxBookingInfo.Size = new System.Drawing.Size(465, 115);
            this.groupBoxBookingInfo.TabIndex = 0;
            this.groupBoxBookingInfo.TabStop = false;
            this.groupBoxBookingInfo.Text = "Информация о бронировании";
            // 
            // labelCheckInInfo
            // 
            this.labelCheckInInfo.AutoSize = true;
            this.labelCheckInInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelCheckInInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCheckInInfo.Location = new System.Drawing.Point(120, 85);
            this.labelCheckInInfo.Name = "labelCheckInInfo";
            this.labelCheckInInfo.Size = new System.Drawing.Size(42, 15);
            this.labelCheckInInfo.TabIndex = 7;
            this.labelCheckInInfo.Text = "дата...";
            // 
            // labelHouseInfo
            // 
            this.labelHouseInfo.AutoSize = true;
            this.labelHouseInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelHouseInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseInfo.Location = new System.Drawing.Point(120, 65);
            this.labelHouseInfo.Name = "labelHouseInfo";
            this.labelHouseInfo.Size = new System.Drawing.Size(54, 15);
            this.labelHouseInfo.TabIndex = 6;
            this.labelHouseInfo.Text = "домов...";
            // 
            // labelPhoneInfo
            // 
            this.labelPhoneInfo.AutoSize = true;
            this.labelPhoneInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelPhoneInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPhoneInfo.Location = new System.Drawing.Point(120, 45);
            this.labelPhoneInfo.Name = "labelPhoneInfo";
            this.labelPhoneInfo.Size = new System.Drawing.Size(54, 15);
            this.labelPhoneInfo.TabIndex = 5;
            this.labelPhoneInfo.Text = "телефон";
            // 
            // labelClientInfo
            // 
            this.labelClientInfo.AutoSize = true;
            this.labelClientInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelClientInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClientInfo.Location = new System.Drawing.Point(120, 25);
            this.labelClientInfo.Name = "labelClientInfo";
            this.labelClientInfo.Size = new System.Drawing.Size(54, 15);
            this.labelClientInfo.TabIndex = 4;
            this.labelClientInfo.Text = "клиент...";
            // 
            // labelCheckIn
            // 
            this.labelCheckIn.AutoSize = true;
            this.labelCheckIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelCheckIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCheckIn.Location = new System.Drawing.Point(15, 85);
            this.labelCheckIn.Name = "labelCheckIn";
            this.labelCheckIn.Size = new System.Drawing.Size(72, 15);
            this.labelCheckIn.TabIndex = 3;
            this.labelCheckIn.Text = "Дата заезда:";
            // 
            // labelHouse
            // 
            this.labelHouse.AutoSize = true;
            this.labelHouse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelHouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouse.Location = new System.Drawing.Point(15, 65);
            this.labelHouse.Name = "labelHouse";
            this.labelHouse.Size = new System.Drawing.Size(37, 15);
            this.labelHouse.TabIndex = 2;
            this.labelHouse.Text = "Дом:";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPhone.Location = new System.Drawing.Point(15, 45);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(62, 15);
            this.labelPhone.TabIndex = 1;
            this.labelPhone.Text = "Телефон:";
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClient.Location = new System.Drawing.Point(15, 25);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(52, 15);
            this.labelClient.TabIndex = 0;
            this.labelClient.Text = "Клиент:";
            // 
            // DepositForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 700);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(516, 739);
            this.Name = "DepositForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Внесение депозита - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.groupBoxNewDeposit.ResumeLayout(false);
            this.groupBoxNewDeposit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeposit)).EndInit();
            this.groupBoxQuickButtons.ResumeLayout(false);
            this.groupBoxCurrentAmounts.ResumeLayout(false);
            this.groupBoxCurrentAmounts.PerformLayout();
            this.groupBoxBookingInfo.ResumeLayout(false);
            this.groupBoxBookingInfo.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}