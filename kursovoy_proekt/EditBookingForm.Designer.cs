namespace kursovoy_proekt
{
    partial class EditBookingForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelContent;

        private System.Windows.Forms.Label labelClientName;
        private System.Windows.Forms.TextBox textBoxClientName;
        private System.Windows.Forms.Label labelHouseName;
        private System.Windows.Forms.TextBox textBoxHouseName;
        private System.Windows.Forms.Label labelCheckIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckIn;
        private System.Windows.Forms.Label labelCheckOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckOut;
        private System.Windows.Forms.Label labelDays;
        private System.Windows.Forms.NumericUpDown numericUpDownDays;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownTotalPrice;
        private System.Windows.Forms.Label labelDeposit;
        private System.Windows.Forms.NumericUpDown numericUpDownDeposit;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.TextBox textBoxNotes;

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;

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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.numericUpDownDeposit = new System.Windows.Forms.NumericUpDown();
            this.labelDeposit = new System.Windows.Forms.Label();
            this.numericUpDownTotalPrice = new System.Windows.Forms.NumericUpDown();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.numericUpDownDays = new System.Windows.Forms.NumericUpDown();
            this.labelDays = new System.Windows.Forms.Label();
            this.dateTimePickerCheckOut = new System.Windows.Forms.DateTimePicker();
            this.labelCheckOut = new System.Windows.Forms.Label();
            this.dateTimePickerCheckIn = new System.Windows.Forms.DateTimePicker();
            this.labelCheckIn = new System.Windows.Forms.Label();
            this.textBoxHouseName = new System.Windows.Forms.TextBox();
            this.labelHouseName = new System.Windows.Forms.Label();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.labelClientName = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).BeginInit();
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
            this.labelHeader.Size = new System.Drawing.Size(242, 37);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Редактирование брони";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.buttonCancel);
            this.panelContent.Controls.Add(this.buttonSave);
            this.panelContent.Controls.Add(this.textBoxNotes);
            this.panelContent.Controls.Add(this.labelNotes);
            this.panelContent.Controls.Add(this.comboBoxStatus);
            this.panelContent.Controls.Add(this.labelStatus);
            this.panelContent.Controls.Add(this.numericUpDownDeposit);
            this.panelContent.Controls.Add(this.labelDeposit);
            this.panelContent.Controls.Add(this.numericUpDownTotalPrice);
            this.panelContent.Controls.Add(this.labelTotalPrice);
            this.panelContent.Controls.Add(this.numericUpDownDays);
            this.panelContent.Controls.Add(this.labelDays);
            this.panelContent.Controls.Add(this.dateTimePickerCheckOut);
            this.panelContent.Controls.Add(this.labelCheckOut);
            this.panelContent.Controls.Add(this.dateTimePickerCheckIn);
            this.panelContent.Controls.Add(this.labelCheckIn);
            this.panelContent.Controls.Add(this.textBoxHouseName);
            this.panelContent.Controls.Add(this.labelHouseName);
            this.panelContent.Controls.Add(this.textBoxClientName);
            this.panelContent.Controls.Add(this.labelClientName);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(500, 490);
            this.panelContent.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonCancel.FlatAppearance.BorderSize = 2;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonCancel.Location = new System.Drawing.Point(270, 420);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(200, 40);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Text = "✕ Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(30, 420);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(200, 40);
            this.buttonSave.TabIndex = 18;
            this.buttonSave.Text = "💾 Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(30, 340);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(440, 60);
            this.textBoxNotes.TabIndex = 17;
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelNotes.Location = new System.Drawing.Point(30, 320);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(84, 17);
            this.labelNotes.TabIndex = 16;
            this.labelNotes.Text = "Примечания:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Ожидание",
            "Подтверждено",
            "Отменено",
            "Завершено",
            "Истекло"});
            this.comboBoxStatus.Location = new System.Drawing.Point(30, 285);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(200, 25);
            this.comboBoxStatus.TabIndex = 15;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelStatus.Location = new System.Drawing.Point(30, 265);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(48, 17);
            this.labelStatus.TabIndex = 14;
            this.labelStatus.Text = "Статус:";
            // 
            // numericUpDownDeposit
            // 
            this.numericUpDownDeposit.DecimalPlaces = 2;
            this.numericUpDownDeposit.Location = new System.Drawing.Point(270, 230);
            this.numericUpDownDeposit.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownDeposit.Name = "numericUpDownDeposit";
            this.numericUpDownDeposit.Size = new System.Drawing.Size(200, 25);
            this.numericUpDownDeposit.TabIndex = 13;
            this.numericUpDownDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownDeposit.ThousandsSeparator = true;
            // 
            // labelDeposit
            // 
            this.labelDeposit.AutoSize = true;
            this.labelDeposit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDeposit.Location = new System.Drawing.Point(270, 210);
            this.labelDeposit.Name = "labelDeposit";
            this.labelDeposit.Size = new System.Drawing.Size(64, 17);
            this.labelDeposit.TabIndex = 12;
            this.labelDeposit.Text = "Депозит:";
            // 
            // numericUpDownTotalPrice
            // 
            this.numericUpDownTotalPrice.DecimalPlaces = 2;
            this.numericUpDownTotalPrice.Location = new System.Drawing.Point(30, 230);
            this.numericUpDownTotalPrice.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownTotalPrice.Name = "numericUpDownTotalPrice";
            this.numericUpDownTotalPrice.Size = new System.Drawing.Size(200, 25);
            this.numericUpDownTotalPrice.TabIndex = 11;
            this.numericUpDownTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownTotalPrice.ThousandsSeparator = true;
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTotalPrice.Location = new System.Drawing.Point(30, 210);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(136, 17);
            this.labelTotalPrice.TabIndex = 10;
            this.labelTotalPrice.Text = "Общая стоимость:";
            // 
            // numericUpDownDays
            // 
            this.numericUpDownDays.Location = new System.Drawing.Point(270, 175);
            this.numericUpDownDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDownDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDays.Name = "numericUpDownDays";
            this.numericUpDownDays.Size = new System.Drawing.Size(200, 25);
            this.numericUpDownDays.TabIndex = 9;
            this.numericUpDownDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelDays
            // 
            this.labelDays.AutoSize = true;
            this.labelDays.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDays.Location = new System.Drawing.Point(270, 155);
            this.labelDays.Name = "labelDays";
            this.labelDays.Size = new System.Drawing.Size(108, 17);
            this.labelDays.TabIndex = 8;
            this.labelDays.Text = "Количество дней:";
            // 
            // dateTimePickerCheckOut
            // 
            this.dateTimePickerCheckOut.Location = new System.Drawing.Point(30, 175);
            this.dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            this.dateTimePickerCheckOut.Size = new System.Drawing.Size(200, 25);
            this.dateTimePickerCheckOut.TabIndex = 7;
            this.dateTimePickerCheckOut.ValueChanged += new System.EventHandler(this.dateTimePickerCheckOut_ValueChanged);
            // 
            // labelCheckOut
            // 
            this.labelCheckOut.AutoSize = true;
            this.labelCheckOut.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelCheckOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCheckOut.Location = new System.Drawing.Point(30, 155);
            this.labelCheckOut.Name = "labelCheckOut";
            this.labelCheckOut.Size = new System.Drawing.Size(84, 17);
            this.labelCheckOut.TabIndex = 6;
            this.labelCheckOut.Text = "Дата выезда:";
            // 
            // dateTimePickerCheckIn
            // 
            this.dateTimePickerCheckIn.Location = new System.Drawing.Point(270, 120);
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new System.Drawing.Size(200, 25);
            this.dateTimePickerCheckIn.TabIndex = 5;
            this.dateTimePickerCheckIn.ValueChanged += new System.EventHandler(this.dateTimePickerCheckIn_ValueChanged);
            // 
            // labelCheckIn
            // 
            this.labelCheckIn.AutoSize = true;
            this.labelCheckIn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelCheckIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCheckIn.Location = new System.Drawing.Point(270, 100);
            this.labelCheckIn.Name = "labelCheckIn";
            this.labelCheckIn.Size = new System.Drawing.Size(82, 17);
            this.labelCheckIn.TabIndex = 4;
            this.labelCheckIn.Text = "Дата заезда:";
            // 
            // textBoxHouseName
            // 
            this.textBoxHouseName.Location = new System.Drawing.Point(30, 120);
            this.textBoxHouseName.Name = "textBoxHouseName";
            this.textBoxHouseName.ReadOnly = true;
            this.textBoxHouseName.Size = new System.Drawing.Size(200, 25);
            this.textBoxHouseName.TabIndex = 3;
            // 
            // labelHouseName
            // 
            this.labelHouseName.AutoSize = true;
            this.labelHouseName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelHouseName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseName.Location = new System.Drawing.Point(30, 100);
            this.labelHouseName.Name = "labelHouseName";
            this.labelHouseName.Size = new System.Drawing.Size(37, 17);
            this.labelHouseName.TabIndex = 2;
            this.labelHouseName.Text = "Дом:";
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(30, 65);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.ReadOnly = true;
            this.textBoxClientName.Size = new System.Drawing.Size(440, 25);
            this.textBoxClientName.TabIndex = 1;
            // 
            // labelClientName
            // 
            this.labelClientName.AutoSize = true;
            this.labelClientName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelClientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelClientName.Location = new System.Drawing.Point(30, 45);
            this.labelClientName.Name = "labelClientName";
            this.labelClientName.Size = new System.Drawing.Size(55, 17);
            this.labelClientName.TabIndex = 0;
            this.labelClientName.Text = "Клиент:";
            // 
            // EditBookingForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 550);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Name = "EditBookingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование бронирования";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).EndInit();
            this.ResumeLayout(false);
        }
    }
}