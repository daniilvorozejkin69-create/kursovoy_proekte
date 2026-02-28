namespace kursovoy_proekt
{
    partial class AddStaff
    {
        private System.ComponentModel.IContainer components = null;

        // Основные панели
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;

        // Левая колонка - фото
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label labelPhoto;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.Button buttonLoadPhoto;
        private System.Windows.Forms.Button buttonClearPhoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog;

        // Правая колонка - данные
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.TextBox textBoxFIO;

        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.ComboBox comboBoxPosition;

        private System.Windows.Forms.Label labelBirthDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthDate;

        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPhone;

        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;

        private System.Windows.Forms.Label labelPassport;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPassport;

        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress;

        private System.Windows.Forms.Label labelHireDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerHireDate;

        // Кнопки действий
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ErrorProvider errorProvider;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStaff));

            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelGreenLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonClearPhoto = new System.Windows.Forms.Button();
            this.buttonLoadPhoto = new System.Windows.Forms.Button();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.labelPhoto = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dateTimePickerHireDate = new System.Windows.Forms.DateTimePicker();
            this.labelHireDate = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.maskedTextBoxPassport = new System.Windows.Forms.MaskedTextBox();
            this.labelPassport = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.maskedTextBoxPhone = new System.Windows.Forms.MaskedTextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.dateTimePickerBirthDate = new System.Windows.Forms.DateTimePicker();
            this.labelBirthDate = new System.Windows.Forms.Label();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.labelFIO = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();

            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);

            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelContent.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();

            // ============================================
            // HEADER
            // ============================================
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 90);
            this.panelHeader.TabIndex = 0;

            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(25, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;

            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(90, 25);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(379, 45);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "ДОБАВЛЕНИЕ НОВОГО СОТРУДНИКА";

            // ============================================
            // GREEN LINE
            // ============================================
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 90);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(1000, 3);
            this.panelGreenLine.TabIndex = 1;

            // ============================================
            // CONTENT
            // ============================================
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(240, 245, 235);
            this.panelContent.Controls.Add(this.panelLeft);
            this.panelContent.Controls.Add(this.panelRight);
            this.panelContent.Controls.Add(this.panelButtons);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 93);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(1000, 657);
            this.panelContent.TabIndex = 2;

            // ============================================
            // LEFT PANEL - ФОТО
            // ============================================
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.buttonClearPhoto);
            this.panelLeft.Controls.Add(this.buttonLoadPhoto);
            this.panelLeft.Controls.Add(this.pictureBoxPhoto);
            this.panelLeft.Controls.Add(this.labelPhoto);
            this.panelLeft.Location = new System.Drawing.Point(30, 30);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(280, 400);
            this.panelLeft.TabIndex = 0;

            // labelPhoto
            this.labelPhoto.AutoSize = true;
            this.labelPhoto.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPhoto.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelPhoto.Location = new System.Drawing.Point(15, 15);
            this.labelPhoto.Name = "labelPhoto";
            this.labelPhoto.Size = new System.Drawing.Size(56, 21);
            this.labelPhoto.TabIndex = 0;
            this.labelPhoto.Text = "Фото:";

            // pictureBoxPhoto
            this.pictureBoxPhoto.BackColor = System.Drawing.Color.FromArgb(240, 245, 235);
            this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPhoto.Location = new System.Drawing.Point(15, 45);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(245, 240);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 1;
            this.pictureBoxPhoto.TabStop = false;

            // buttonLoadPhoto
            this.buttonLoadPhoto.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.buttonLoadPhoto.FlatAppearance.BorderSize = 0;
            this.buttonLoadPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadPhoto.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoadPhoto.ForeColor = System.Drawing.Color.White;
            this.buttonLoadPhoto.Location = new System.Drawing.Point(15, 300);
            this.buttonLoadPhoto.Name = "buttonLoadPhoto";
            this.buttonLoadPhoto.Size = new System.Drawing.Size(245, 40);
            this.buttonLoadPhoto.TabIndex = 2;
            this.buttonLoadPhoto.Text = "📷 Загрузить фото";
            this.buttonLoadPhoto.UseVisualStyleBackColor = false;

            // buttonClearPhoto
            this.buttonClearPhoto.BackColor = System.Drawing.Color.Transparent;
            this.buttonClearPhoto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 80, 80);
            this.buttonClearPhoto.FlatAppearance.BorderSize = 2;
            this.buttonClearPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearPhoto.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClearPhoto.ForeColor = System.Drawing.Color.FromArgb(220, 80, 80);
            this.buttonClearPhoto.Location = new System.Drawing.Point(15, 345);
            this.buttonClearPhoto.Name = "buttonClearPhoto";
            this.buttonClearPhoto.Size = new System.Drawing.Size(245, 40);
            this.buttonClearPhoto.TabIndex = 3;
            this.buttonClearPhoto.Text = "🗑️ Очистить";
            this.buttonClearPhoto.UseVisualStyleBackColor = false;

            // ============================================
            // RIGHT PANEL - ДАННЫЕ
            // ============================================
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.dateTimePickerHireDate);
            this.panelRight.Controls.Add(this.labelHireDate);
            this.panelRight.Controls.Add(this.textBoxAddress);
            this.panelRight.Controls.Add(this.labelAddress);
            this.panelRight.Controls.Add(this.maskedTextBoxPassport);
            this.panelRight.Controls.Add(this.labelPassport);
            this.panelRight.Controls.Add(this.textBoxEmail);
            this.panelRight.Controls.Add(this.labelEmail);
            this.panelRight.Controls.Add(this.maskedTextBoxPhone);
            this.panelRight.Controls.Add(this.labelPhone);
            this.panelRight.Controls.Add(this.dateTimePickerBirthDate);
            this.panelRight.Controls.Add(this.labelBirthDate);
            this.panelRight.Controls.Add(this.comboBoxPosition);
            this.panelRight.Controls.Add(this.labelPosition);
            this.panelRight.Controls.Add(this.textBoxFIO);
            this.panelRight.Controls.Add(this.labelFIO);
            this.panelRight.Location = new System.Drawing.Point(330, 30);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(640, 520);
            this.panelRight.TabIndex = 1;

            // labelFIO
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFIO.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelFIO.Location = new System.Drawing.Point(25, 25);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(47, 20);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "ФИО:";

            // textBoxFIO
            this.textBoxFIO.BackColor = System.Drawing.Color.White;
            this.textBoxFIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFIO.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFIO.Location = new System.Drawing.Point(25, 50);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(590, 27);
            this.textBoxFIO.TabIndex = 1;

            // labelPosition
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPosition.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelPosition.Location = new System.Drawing.Point(25, 90);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(84, 20);
            this.labelPosition.TabIndex = 2;
            this.labelPosition.Text = "Должность:";

            // comboBoxPosition
            this.comboBoxPosition.BackColor = System.Drawing.Color.White;
            this.comboBoxPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPosition.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPosition.Location = new System.Drawing.Point(25, 115);
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(590, 28);
            this.comboBoxPosition.TabIndex = 3;

            // labelBirthDate
            this.labelBirthDate.AutoSize = true;
            this.labelBirthDate.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBirthDate.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelBirthDate.Location = new System.Drawing.Point(25, 160);
            this.labelBirthDate.Name = "labelBirthDate";
            this.labelBirthDate.Size = new System.Drawing.Size(116, 20);
            this.labelBirthDate.TabIndex = 4;
            this.labelBirthDate.Text = "Дата рождения:";

            // dateTimePickerBirthDate
            this.dateTimePickerBirthDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBirthDate.Location = new System.Drawing.Point(25, 185);
            this.dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            this.dateTimePickerBirthDate.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerBirthDate.TabIndex = 5;

            // labelPhone
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPhone.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelPhone.Location = new System.Drawing.Point(25, 230);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(74, 20);
            this.labelPhone.TabIndex = 6;
            this.labelPhone.Text = "Телефон:";

            // maskedTextBoxPhone
            this.maskedTextBoxPhone.BackColor = System.Drawing.Color.White;
            this.maskedTextBoxPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBoxPhone.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBoxPhone.Location = new System.Drawing.Point(25, 255);
            this.maskedTextBoxPhone.Mask = "+7 (000) 000-00-00";
            this.maskedTextBoxPhone.Name = "maskedTextBoxPhone";
            this.maskedTextBoxPhone.PromptChar = ' ';
            this.maskedTextBoxPhone.Size = new System.Drawing.Size(590, 27);
            this.maskedTextBoxPhone.TabIndex = 7;

            // labelEmail
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelEmail.Location = new System.Drawing.Point(25, 300);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(49, 20);
            this.labelEmail.TabIndex = 8;
            this.labelEmail.Text = "Email:";

            // textBoxEmail
            this.textBoxEmail.BackColor = System.Drawing.Color.White;
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEmail.Location = new System.Drawing.Point(25, 325);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(590, 27);
            this.textBoxEmail.TabIndex = 9;

            // labelPassport
            this.labelPassport.AutoSize = true;
            this.labelPassport.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassport.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelPassport.Location = new System.Drawing.Point(25, 370);
            this.labelPassport.Name = "labelPassport";
            this.labelPassport.Size = new System.Drawing.Size(124, 20);
            this.labelPassport.TabIndex = 10;
            this.labelPassport.Text = "Номер паспорта:";

            // maskedTextBoxPassport
            this.maskedTextBoxPassport.BackColor = System.Drawing.Color.White;
            this.maskedTextBoxPassport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBoxPassport.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBoxPassport.Location = new System.Drawing.Point(25, 395);
            this.maskedTextBoxPassport.Mask = "00 00 000000";
            this.maskedTextBoxPassport.Name = "maskedTextBoxPassport";
            this.maskedTextBoxPassport.PromptChar = ' ';
            this.maskedTextBoxPassport.Size = new System.Drawing.Size(590, 27);
            this.maskedTextBoxPassport.TabIndex = 11;

            // labelAddress
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAddress.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelAddress.Location = new System.Drawing.Point(25, 440);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(58, 20);
            this.labelAddress.TabIndex = 12;
            this.labelAddress.Text = "Адрес:";

            // textBoxAddress
            this.textBoxAddress.BackColor = System.Drawing.Color.White;
            this.textBoxAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAddress.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAddress.Location = new System.Drawing.Point(25, 465);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(590, 27);
            this.textBoxAddress.TabIndex = 13;

            // labelHireDate
            this.labelHireDate.AutoSize = true;
            this.labelHireDate.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHireDate.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelHireDate.Location = new System.Drawing.Point(240, 185);
            this.labelHireDate.Name = "labelHireDate";
            this.labelHireDate.Size = new System.Drawing.Size(101, 20);
            this.labelHireDate.TabIndex = 14;
            this.labelHireDate.Text = "Дата приёма:";

            // dateTimePickerHireDate
            this.dateTimePickerHireDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerHireDate.Location = new System.Drawing.Point(240, 210);
            this.dateTimePickerHireDate.Name = "dateTimePickerHireDate";
            this.dateTimePickerHireDate.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerHireDate.TabIndex = 15;

            // ============================================
            // BUTTONS PANEL
            // ============================================
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Controls.Add(this.buttonSave);
            this.panelButtons.Location = new System.Drawing.Point(30, 570);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(940, 70);
            this.panelButtons.TabIndex = 2;

            // buttonSave
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(260, 10);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(200, 50);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "✅  СОХРАНИТЬ";
            this.buttonSave.UseVisualStyleBackColor = false;

            // buttonCancel
            this.buttonCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.buttonCancel.FlatAppearance.BorderSize = 2;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.buttonCancel.Location = new System.Drawing.Point(480, 10);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(200, 50);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "❌  ОТМЕНА";
            this.buttonCancel.UseVisualStyleBackColor = false;

            // openFileDialog
            this.openFileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            this.openFileDialog.Title = "Выберите фото сотрудника";

            // ============================================
            // FORM
            // ============================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление персоналом";

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
        }
    }
}