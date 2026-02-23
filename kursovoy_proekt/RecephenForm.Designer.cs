namespace kursovoy_proekt
{
    partial class RecephenForm
    {
        private System.ComponentModel.IContainer components = null;

        // Основные панели
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;

        // Информация о пользователе
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelUserInfo;
        private System.Windows.Forms.Panel panelSeparator;

        // Кнопки
        private System.Windows.Forms.Button buttonAddClient;
        private System.Windows.Forms.Button buttonEditClient;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonBooking;
        private System.Windows.Forms.Button buttonBookingManagement;
        private System.Windows.Forms.Button buttonHouses;
        private System.Windows.Forms.Button buttonServices;
        private System.Windows.Forms.Button buttonExit;

        // Версия
        private System.Windows.Forms.Label labelVersion;

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
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelGreenLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonServices = new System.Windows.Forms.Button();
            this.buttonHouses = new System.Windows.Forms.Button();
            this.buttonBookingManagement = new System.Windows.Forms.Button();
            this.buttonBooking = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonEditClient = new System.Windows.Forms.Button();
            this.buttonAddClient = new System.Windows.Forms.Button();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.labelUserInfo = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 90);
            this.panelHeader.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(25, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(90, 25);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(449, 45);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Панель сотрудника ресепшена";
            // 
            // panelGreenLine
            // 
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 90);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(900, 3);
            this.panelGreenLine.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.labelVersion);
            this.panelContent.Controls.Add(this.buttonExit);
            this.panelContent.Controls.Add(this.buttonServices);
            this.panelContent.Controls.Add(this.buttonHouses);
            this.panelContent.Controls.Add(this.buttonBookingManagement);
            this.panelContent.Controls.Add(this.buttonBooking);
            this.panelContent.Controls.Add(this.buttonCheck);
            this.panelContent.Controls.Add(this.buttonEditClient);
            this.panelContent.Controls.Add(this.buttonAddClient);
            this.panelContent.Controls.Add(this.panelSeparator);
            this.panelContent.Controls.Add(this.labelUserInfo);
            this.panelContent.Controls.Add(this.labelWelcome);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 93);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(900, 557);
            this.panelContent.TabIndex = 2;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.labelVersion.Location = new System.Drawing.Point(30, 510);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(151, 13);
            this.labelVersion.TabIndex = 8;
            this.labelVersion.Text = "База отдыха v1.0 | Ресепшен";
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonExit.FlatAppearance.BorderSize = 2;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonExit.Location = new System.Drawing.Point(300, 380);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(300, 60);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "🚪 ВЫХОД ИЗ СИСТЕМЫ";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.ButtonExit_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.ButtonExit_MouseLeave);
            // 
            // buttonServices
            // 
            this.buttonServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(155)))), ((int)(((byte)(205)))));
            this.buttonServices.FlatAppearance.BorderSize = 0;
            this.buttonServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonServices.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonServices.ForeColor = System.Drawing.Color.White;
            this.buttonServices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonServices.Location = new System.Drawing.Point(470, 280);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonServices.Size = new System.Drawing.Size(400, 70);
            this.buttonServices.TabIndex = 6;
            this.buttonServices.Text = "    🛎️ СПИСОК УСЛУГ";
            this.buttonServices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonServices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonServices.UseVisualStyleBackColor = false;
            this.buttonServices.Click += new System.EventHandler(this.buttonServices_Click);
            this.buttonServices.MouseEnter += new System.EventHandler(this.ButtonServices_MouseEnter);
            this.buttonServices.MouseLeave += new System.EventHandler(this.ButtonServices_MouseLeave);
            // 
            // buttonHouses
            // 
            this.buttonHouses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(155)))), ((int)(((byte)(205)))));
            this.buttonHouses.FlatAppearance.BorderSize = 0;
            this.buttonHouses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHouses.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHouses.ForeColor = System.Drawing.Color.White;
            this.buttonHouses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHouses.Location = new System.Drawing.Point(30, 280);
            this.buttonHouses.Name = "buttonHouses";
            this.buttonHouses.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonHouses.Size = new System.Drawing.Size(400, 70);
            this.buttonHouses.TabIndex = 5;
            this.buttonHouses.Text = "    🏠 СПИСОК ДОМОВ";
            this.buttonHouses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHouses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonHouses.UseVisualStyleBackColor = false;
            this.buttonHouses.Click += new System.EventHandler(this.buttonHouses_Click);
            this.buttonHouses.MouseEnter += new System.EventHandler(this.ButtonHouses_MouseEnter);
            this.buttonHouses.MouseLeave += new System.EventHandler(this.ButtonHouses_MouseLeave);
            // 
            // buttonBookingManagement
            // 
            this.buttonBookingManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonBookingManagement.FlatAppearance.BorderSize = 0;
            this.buttonBookingManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBookingManagement.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBookingManagement.ForeColor = System.Drawing.Color.White;
            this.buttonBookingManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBookingManagement.Location = new System.Drawing.Point(610, 190);
            this.buttonBookingManagement.Name = "buttonBookingManagement";
            this.buttonBookingManagement.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonBookingManagement.Size = new System.Drawing.Size(260, 70);
            this.buttonBookingManagement.TabIndex = 4;
            this.buttonBookingManagement.Text = "    🔄 УПРАВЛЕНИЕ БРОНИРОВАНИЯМИ";
            this.buttonBookingManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBookingManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonBookingManagement.UseVisualStyleBackColor = false;
            this.buttonBookingManagement.Click += new System.EventHandler(this.button1_Click);
            this.buttonBookingManagement.MouseEnter += new System.EventHandler(this.ButtonBookingManagement_MouseEnter);
            this.buttonBookingManagement.MouseLeave += new System.EventHandler(this.ButtonBookingManagement_MouseLeave);
            // 
            // buttonBooking
            // 
            this.buttonBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonBooking.FlatAppearance.BorderSize = 0;
            this.buttonBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBooking.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBooking.ForeColor = System.Drawing.Color.White;
            this.buttonBooking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBooking.Location = new System.Drawing.Point(320, 190);
            this.buttonBooking.Name = "buttonBooking";
            this.buttonBooking.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonBooking.Size = new System.Drawing.Size(270, 70);
            this.buttonBooking.TabIndex = 3;
            this.buttonBooking.Text = "    📅 БРОНИРОВАНИЕ";
            this.buttonBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonBooking.UseVisualStyleBackColor = false;
            this.buttonBooking.Click += new System.EventHandler(this.buttonBooking_Click);
            this.buttonBooking.MouseEnter += new System.EventHandler(this.ButtonBooking_MouseEnter);
            this.buttonBooking.MouseLeave += new System.EventHandler(this.ButtonBooking_MouseLeave);
            // 
            // buttonCheck
            // 
            this.buttonCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonCheck.FlatAppearance.BorderSize = 0;
            this.buttonCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheck.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCheck.ForeColor = System.Drawing.Color.White;
            this.buttonCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCheck.Location = new System.Drawing.Point(30, 190);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonCheck.Size = new System.Drawing.Size(270, 70);
            this.buttonCheck.TabIndex = 2;
            this.buttonCheck.Text = "    🧾 ОФОРМИТЬ ЗАКАЗ";
            this.buttonCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCheck.UseVisualStyleBackColor = false;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            this.buttonCheck.MouseEnter += new System.EventHandler(this.ButtonCheck_MouseEnter);
            this.buttonCheck.MouseLeave += new System.EventHandler(this.ButtonCheck_MouseLeave);
            // 
            // buttonEditClient
            // 
            this.buttonEditClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonEditClient.FlatAppearance.BorderSize = 0;
            this.buttonEditClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditClient.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditClient.ForeColor = System.Drawing.Color.White;
            this.buttonEditClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditClient.Location = new System.Drawing.Point(470, 100);
            this.buttonEditClient.Name = "buttonEditClient";
            this.buttonEditClient.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonEditClient.Size = new System.Drawing.Size(400, 70);
            this.buttonEditClient.TabIndex = 1;
            this.buttonEditClient.Text = "    📋 СПИСОК КЛИЕНТОВ";
            this.buttonEditClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditClient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEditClient.UseVisualStyleBackColor = false;
            this.buttonEditClient.Click += new System.EventHandler(this.buttonEditClient_Click);
            this.buttonEditClient.MouseEnter += new System.EventHandler(this.ButtonEditClient_MouseEnter);
            this.buttonEditClient.MouseLeave += new System.EventHandler(this.ButtonEditClient_MouseLeave);
            // 
            // buttonAddClient
            // 
            this.buttonAddClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonAddClient.FlatAppearance.BorderSize = 0;
            this.buttonAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddClient.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddClient.ForeColor = System.Drawing.Color.White;
            this.buttonAddClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddClient.Location = new System.Drawing.Point(30, 100);
            this.buttonAddClient.Name = "buttonAddClient";
            this.buttonAddClient.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonAddClient.Size = new System.Drawing.Size(400, 70);
            this.buttonAddClient.TabIndex = 0;
            this.buttonAddClient.Text = "    ➕ ДОБАВИТЬ НОВОГО КЛИЕНТА";
            this.buttonAddClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddClient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAddClient.UseVisualStyleBackColor = false;
            this.buttonAddClient.Click += new System.EventHandler(this.buttonAddClient_Click);
            this.buttonAddClient.MouseEnter += new System.EventHandler(this.ButtonAddClient_MouseEnter);
            this.buttonAddClient.MouseLeave += new System.EventHandler(this.ButtonAddClient_MouseLeave);
            // 
            // panelSeparator
            // 
            this.panelSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelSeparator.Location = new System.Drawing.Point(30, 70);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(840, 2);
            this.panelSeparator.TabIndex = 2;
            // 
            // labelUserInfo
            // 
            this.labelUserInfo.AutoSize = true;
            this.labelUserInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.labelUserInfo.Location = new System.Drawing.Point(219, 30);
            this.labelUserInfo.Name = "labelUserInfo";
            this.labelUserInfo.Size = new System.Drawing.Size(179, 25);
            this.labelUserInfo.TabIndex = 1;
            this.labelUserInfo.Text = "Имя пользователя";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelWelcome.Location = new System.Drawing.Point(30, 30);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(183, 25);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Добро пожаловать,";
            // 
            // RecephenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecephenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ресепшен - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}