namespace kursovoy_proekt
{
    partial class ManagerForm
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
        private System.Windows.Forms.Button buttonAddHouse;
        private System.Windows.Forms.Button buttonEditHouse;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Button buttonEditService;
        private System.Windows.Forms.Button buttonReportHouse;
        private System.Windows.Forms.Button buttonExit;

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
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonReportHouse = new System.Windows.Forms.Button();
            this.buttonEditService = new System.Windows.Forms.Button();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.buttonEditHouse = new System.Windows.Forms.Button();
            this.buttonAddHouse = new System.Windows.Forms.Button();
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
            this.panelHeader.Size = new System.Drawing.Size(800, 90);
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
            this.labelHeader.Size = new System.Drawing.Size(336, 45);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Панель управляющего";
            // 
            // panelGreenLine
            // 
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 90);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(800, 3);
            this.panelGreenLine.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.buttonExit);
            this.panelContent.Controls.Add(this.buttonReportHouse);
            this.panelContent.Controls.Add(this.buttonEditService);
            this.panelContent.Controls.Add(this.buttonAddService);
            this.panelContent.Controls.Add(this.buttonEditHouse);
            this.panelContent.Controls.Add(this.buttonAddHouse);
            this.panelContent.Controls.Add(this.panelSeparator);
            this.panelContent.Controls.Add(this.labelUserInfo);
            this.panelContent.Controls.Add(this.labelWelcome);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 93);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(800, 507);
            this.panelContent.TabIndex = 2;
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
            this.buttonExit.Location = new System.Drawing.Point(250, 380);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(300, 60);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "🚪 ВЫХОД ИЗ СИСТЕМЫ";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.ButtonExit_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.ButtonExit_MouseLeave);
            // 
            // buttonReportHouse
            // 
            this.buttonReportHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(155)))), ((int)(((byte)(205)))));
            this.buttonReportHouse.FlatAppearance.BorderSize = 0;
            this.buttonReportHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReportHouse.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReportHouse.ForeColor = System.Drawing.Color.White;
            this.buttonReportHouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReportHouse.Location = new System.Drawing.Point(30, 280);
            this.buttonReportHouse.Name = "buttonReportHouse";
            this.buttonReportHouse.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonReportHouse.Size = new System.Drawing.Size(740, 70);
            this.buttonReportHouse.TabIndex = 4;
            this.buttonReportHouse.Text = "    📊 ОТЧЁТ ПО ЗАГРУЗКЕ ДОМОВ И ВЫРУЧКЕ";
            this.buttonReportHouse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReportHouse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonReportHouse.UseVisualStyleBackColor = false;
            this.buttonReportHouse.Click += new System.EventHandler(this.buttonReportHouse_Click);
            this.buttonReportHouse.MouseEnter += new System.EventHandler(this.ButtonReportHouse_MouseEnter);
            this.buttonReportHouse.MouseLeave += new System.EventHandler(this.ButtonReportHouse_MouseLeave);
            // 
            // buttonEditService
            // 
            this.buttonEditService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonEditService.FlatAppearance.BorderSize = 0;
            this.buttonEditService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditService.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditService.ForeColor = System.Drawing.Color.White;
            this.buttonEditService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditService.Location = new System.Drawing.Point(410, 190);
            this.buttonEditService.Name = "buttonEditService";
            this.buttonEditService.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonEditService.Size = new System.Drawing.Size(360, 70);
            this.buttonEditService.TabIndex = 3;
            this.buttonEditService.Text = "    📋 СПИСОК УСЛУГ";
            this.buttonEditService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditService.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEditService.UseVisualStyleBackColor = false;
            this.buttonEditService.Click += new System.EventHandler(this.buttonEditService_Click);
            this.buttonEditService.MouseEnter += new System.EventHandler(this.ButtonEditService_MouseEnter);
            this.buttonEditService.MouseLeave += new System.EventHandler(this.ButtonEditService_MouseLeave);
            // 
            // buttonAddService
            // 
            this.buttonAddService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonAddService.FlatAppearance.BorderSize = 0;
            this.buttonAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddService.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddService.ForeColor = System.Drawing.Color.White;
            this.buttonAddService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddService.Location = new System.Drawing.Point(30, 190);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonAddService.Size = new System.Drawing.Size(360, 70);
            this.buttonAddService.TabIndex = 2;
            this.buttonAddService.Text = "    ✨ ДОБАВИТЬ НОВУЮ УСЛУГУ";
            this.buttonAddService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddService.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAddService.UseVisualStyleBackColor = false;
            this.buttonAddService.Click += new System.EventHandler(this.buttonAddService_Click);
            this.buttonAddService.MouseEnter += new System.EventHandler(this.ButtonAddService_MouseEnter);
            this.buttonAddService.MouseLeave += new System.EventHandler(this.ButtonAddService_MouseLeave);
            // 
            // buttonEditHouse
            // 
            this.buttonEditHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonEditHouse.FlatAppearance.BorderSize = 0;
            this.buttonEditHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditHouse.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditHouse.ForeColor = System.Drawing.Color.White;
            this.buttonEditHouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditHouse.Location = new System.Drawing.Point(410, 100);
            this.buttonEditHouse.Name = "buttonEditHouse";
            this.buttonEditHouse.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonEditHouse.Size = new System.Drawing.Size(360, 70);
            this.buttonEditHouse.TabIndex = 1;
            this.buttonEditHouse.Text = "    📋 СПИСОК ДОМОВ";
            this.buttonEditHouse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditHouse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonEditHouse.UseVisualStyleBackColor = false;
            this.buttonEditHouse.Click += new System.EventHandler(this.buttonEditHouse_Click);
            this.buttonEditHouse.MouseEnter += new System.EventHandler(this.ButtonEditHouse_MouseEnter);
            this.buttonEditHouse.MouseLeave += new System.EventHandler(this.ButtonEditHouse_MouseLeave);
            // 
            // buttonAddHouse
            // 
            this.buttonAddHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonAddHouse.FlatAppearance.BorderSize = 0;
            this.buttonAddHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddHouse.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddHouse.ForeColor = System.Drawing.Color.White;
            this.buttonAddHouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddHouse.Location = new System.Drawing.Point(30, 100);
            this.buttonAddHouse.Name = "buttonAddHouse";
            this.buttonAddHouse.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonAddHouse.Size = new System.Drawing.Size(360, 70);
            this.buttonAddHouse.TabIndex = 0;
            this.buttonAddHouse.Text = "    🏠 ДОБАВИТЬ НОВЫЙ ДОМ";
            this.buttonAddHouse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddHouse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAddHouse.UseVisualStyleBackColor = false;
            this.buttonAddHouse.Click += new System.EventHandler(this.buttonAddHouse_Click);
            this.buttonAddHouse.MouseEnter += new System.EventHandler(this.ButtonAddHouse_MouseEnter);
            this.buttonAddHouse.MouseLeave += new System.EventHandler(this.ButtonAddHouse_MouseLeave);
            // 
            // panelSeparator
            // 
            this.panelSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelSeparator.Location = new System.Drawing.Point(30, 70);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(740, 2);
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
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управляющий - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}