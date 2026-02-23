namespace kursovoy_proekt
{
    partial class AddClient
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;

        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.Label labelPassport;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPassport;
        private System.Windows.Forms.Label labelBirthDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthDate;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPhone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.ToolTip toolTip;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClient));

            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelGreenLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.maskedTextBoxPhone = new System.Windows.Forms.MaskedTextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.dateTimePickerBirthDate = new System.Windows.Forms.DateTimePicker();
            this.labelBirthDate = new System.Windows.Forms.Label();
            this.maskedTextBoxPassport = new System.Windows.Forms.MaskedTextBox();
            this.labelPassport = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.labelFIO = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);

            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(700, 80);
            this.panelHeader.TabIndex = 0;

            // pictureBoxLogo
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(25, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;

            // labelHeader
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(75, 22);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(324, 32);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "ДОБАВЛЕНИЕ НОВОГО КЛИЕНТА";

            // panelGreenLine
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 80);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(700, 3);
            this.panelGreenLine.TabIndex = 1;

            // panelContent
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(240, 245, 235);
            this.panelContent.Controls.Add(this.buttonMenu);
            this.panelContent.Controls.Add(this.buttonDelete);
            this.panelContent.Controls.Add(this.buttonSave);
            this.panelContent.Controls.Add(this.comboBoxGender);
            this.panelContent.Controls.Add(this.labelGender);
            this.panelContent.Controls.Add(this.textBoxEmail);
            this.panelContent.Controls.Add(this.labelEmail);
            this.panelContent.Controls.Add(this.maskedTextBoxPhone);
            this.panelContent.Controls.Add(this.labelPhone);
            this.panelContent.Controls.Add(this.dateTimePickerBirthDate);
            this.panelContent.Controls.Add(this.labelBirthDate);
            this.panelContent.Controls.Add(this.maskedTextBoxPassport);
            this.panelContent.Controls.Add(this.labelPassport);
            this.panelContent.Controls.Add(this.textBoxFIO);
            this.panelContent.Controls.Add(this.labelFIO);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 83);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.panelContent.Size = new System.Drawing.Size(700, 567);
            this.panelContent.TabIndex = 2;

            // labelFIO
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.labelFIO.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelFIO.Location = new System.Drawing.Point(40, 15);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(47, 20);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "ФИО:";

            // textBoxFIO
            this.textBoxFIO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFIO.BackColor = System.Drawing.Color.White;
            this.textBoxFIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFIO.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxFIO.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.textBoxFIO.Location = new System.Drawing.Point(40, 40);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(600, 27);
            this.textBoxFIO.TabIndex = 0;
            this.toolTip.SetToolTip(this.textBoxFIO, "Пример: Иванов Иван Иванович");

            // labelPassport
            this.labelPassport.AutoSize = true;
            this.labelPassport.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.labelPassport.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelPassport.Location = new System.Drawing.Point(40, 85);
            this.labelPassport.Name = "labelPassport";
            this.labelPassport.Size = new System.Drawing.Size(130, 20);
            this.labelPassport.TabIndex = 0;
            this.labelPassport.Text = "Номер паспорта:";

            // maskedTextBoxPassport
            this.maskedTextBoxPassport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBoxPassport.BackColor = System.Drawing.Color.White;
            this.maskedTextBoxPassport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBoxPassport.Font = new System.Drawing.Font("Consolas", 11F);
            this.maskedTextBoxPassport.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.maskedTextBoxPassport.Location = new System.Drawing.Point(40, 110);
            this.maskedTextBoxPassport.Mask = "00 00 000000";
            this.maskedTextBoxPassport.Name = "maskedTextBoxPassport";
            this.maskedTextBoxPassport.PromptChar = ' ';
            this.maskedTextBoxPassport.Size = new System.Drawing.Size(600, 25);
            this.maskedTextBoxPassport.TabIndex = 1;
            this.toolTip.SetToolTip(this.maskedTextBoxPassport, "Формат: 45 10 123456");

            // labelBirthDate
            this.labelBirthDate.AutoSize = true;
            this.labelBirthDate.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.labelBirthDate.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelBirthDate.Location = new System.Drawing.Point(40, 155);
            this.labelBirthDate.Name = "labelBirthDate";
            this.labelBirthDate.Size = new System.Drawing.Size(121, 20);
            this.labelBirthDate.TabIndex = 0;
            this.labelBirthDate.Text = "Дата рождения:";

            // dateTimePickerBirthDate
            this.dateTimePickerBirthDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dateTimePickerBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBirthDate.Location = new System.Drawing.Point(40, 180);
            this.dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            this.dateTimePickerBirthDate.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerBirthDate.TabIndex = 2;
            this.toolTip.SetToolTip(this.dateTimePickerBirthDate, "Клиент должен быть старше 18 лет");

            // labelPhone
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.labelPhone.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelPhone.Location = new System.Drawing.Point(40, 225);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(74, 20);
            this.labelPhone.TabIndex = 0;
            this.labelPhone.Text = "Телефон:";

            // maskedTextBoxPhone
            this.maskedTextBoxPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBoxPhone.BackColor = System.Drawing.Color.White;
            this.maskedTextBoxPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBoxPhone.Font = new System.Drawing.Font("Consolas", 11F);
            this.maskedTextBoxPhone.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.maskedTextBoxPhone.Location = new System.Drawing.Point(40, 250);
            this.maskedTextBoxPhone.Mask = "+7 (000) 000-00-00";
            this.maskedTextBoxPhone.Name = "maskedTextBoxPhone";
            this.maskedTextBoxPhone.PromptChar = ' ';
            this.maskedTextBoxPhone.Size = new System.Drawing.Size(600, 25);
            this.maskedTextBoxPhone.TabIndex = 3;
            this.toolTip.SetToolTip(this.maskedTextBoxPhone, "Формат: +7 (900) 123-45-67");

            // labelEmail
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelEmail.Location = new System.Drawing.Point(40, 295);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(154, 20);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "Email (необязательно):";

            // textBoxEmail
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.BackColor = System.Drawing.Color.White;
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxEmail.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.textBoxEmail.Location = new System.Drawing.Point(40, 320);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(600, 27);
            this.textBoxEmail.TabIndex = 4;
            this.toolTip.SetToolTip(this.textBoxEmail, "Пример: example@mail.ru");

            // labelGender
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.labelGender.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelGender.Location = new System.Drawing.Point(40, 365);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(44, 20);
            this.labelGender.TabIndex = 0;
            this.labelGender.Text = "Пол:";

            // comboBoxGender
            this.comboBoxGender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGender.BackColor = System.Drawing.Color.White;
            this.comboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxGender.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.comboBoxGender.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Items.AddRange(new object[] {
            "👨 Мужской",
            "👩 Женский"});
            this.comboBoxGender.Location = new System.Drawing.Point(40, 390);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(600, 28);
            this.comboBoxGender.TabIndex = 5;

            // buttonSave
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(40, 460);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(280, 50);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "✅  СОХРАНИТЬ";
            this.buttonSave.UseVisualStyleBackColor = false;

            // buttonDelete
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(360, 460);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(140, 50);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "🗑️  УДАЛИТЬ";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Visible = false;

            // buttonMenu
            this.buttonMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.buttonMenu.FlatAppearance.BorderSize = 2;
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonMenu.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.buttonMenu.Location = new System.Drawing.Point(540, 460);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(100, 50);
            this.buttonMenu.TabIndex = 8;
            this.buttonMenu.Text = "❌  НАЗАД";
            this.buttonMenu.UseVisualStyleBackColor = false;

            // AddClient
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 650);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление клиентами";

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}