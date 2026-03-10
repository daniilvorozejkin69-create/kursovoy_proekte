namespace kursovoy_proekt
{
    partial class ManagerForm
    {
        private System.ComponentModel.IContainer components = null;

        // Основные панели
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelHeader;
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
        private System.Windows.Forms.Button buttonManageStaff;
        private System.Windows.Forms.Button buttonReportHouse;

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
            this.buttonManageStaff = new System.Windows.Forms.Button();
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
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 24F);
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
            this.panelGreenLine.Size = new System.Drawing.Size(900, 3);
            this.panelGreenLine.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.buttonExit);
            this.panelContent.Controls.Add(this.buttonReportHouse);
            this.panelContent.Controls.Add(this.buttonManageStaff);
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
            this.panelContent.Size = new System.Drawing.Size(900, 533);
            this.panelContent.TabIndex = 2;
            this.panelContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent_Paint);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonExit.FlatAppearance.BorderSize = 2;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonExit.Location = new System.Drawing.Point(638, 459);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(250, 50);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "🚪 ВЫХОД";
            this.buttonExit.UseVisualStyleBackColor = false;
            // 
            // buttonReportHouse
            // 
            this.buttonReportHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonReportHouse.FlatAppearance.BorderSize = 0;
            this.buttonReportHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReportHouse.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonReportHouse.ForeColor = System.Drawing.Color.White;
            this.buttonReportHouse.Location = new System.Drawing.Point(30, 370);
            this.buttonReportHouse.Name = "buttonReportHouse";
            this.buttonReportHouse.Size = new System.Drawing.Size(840, 70);
            this.buttonReportHouse.TabIndex = 5;
            this.buttonReportHouse.Text = "📊 ОТЧЁТ ПО ВЫРУЧКЕ";
            this.buttonReportHouse.UseVisualStyleBackColor = false;
            // 
            // buttonManageStaff
            // 
            this.buttonManageStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.buttonManageStaff.FlatAppearance.BorderSize = 0;
            this.buttonManageStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManageStaff.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonManageStaff.ForeColor = System.Drawing.Color.White;
            this.buttonManageStaff.Location = new System.Drawing.Point(30, 280);
            this.buttonManageStaff.Name = "buttonManageStaff";
            this.buttonManageStaff.Size = new System.Drawing.Size(840, 70);
            this.buttonManageStaff.TabIndex = 4;
            this.buttonManageStaff.Text = "👥 УПРАВЛЕНИЕ ПЕРСОНАЛОМ";
            this.buttonManageStaff.UseVisualStyleBackColor = false;
            // 
            // buttonEditService
            // 
            this.buttonEditService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonEditService.FlatAppearance.BorderSize = 0;
            this.buttonEditService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditService.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonEditService.ForeColor = System.Drawing.Color.White;
            this.buttonEditService.Location = new System.Drawing.Point(470, 190);
            this.buttonEditService.Name = "buttonEditService";
            this.buttonEditService.Size = new System.Drawing.Size(400, 70);
            this.buttonEditService.TabIndex = 3;
            this.buttonEditService.Text = "📋 СПИСОК УСЛУГ";
            this.buttonEditService.UseVisualStyleBackColor = false;
            // 
            // buttonAddService
            // 
            this.buttonAddService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonAddService.FlatAppearance.BorderSize = 0;
            this.buttonAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddService.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonAddService.ForeColor = System.Drawing.Color.White;
            this.buttonAddService.Location = new System.Drawing.Point(30, 190);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Size = new System.Drawing.Size(400, 70);
            this.buttonAddService.TabIndex = 2;
            this.buttonAddService.Text = "✨ ДОБАВИТЬ УСЛУГУ";
            this.buttonAddService.UseVisualStyleBackColor = false;
            // 
            // buttonEditHouse
            // 
            this.buttonEditHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonEditHouse.FlatAppearance.BorderSize = 0;
            this.buttonEditHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditHouse.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonEditHouse.ForeColor = System.Drawing.Color.White;
            this.buttonEditHouse.Location = new System.Drawing.Point(470, 100);
            this.buttonEditHouse.Name = "buttonEditHouse";
            this.buttonEditHouse.Size = new System.Drawing.Size(400, 70);
            this.buttonEditHouse.TabIndex = 1;
            this.buttonEditHouse.Text = "📋 СПИСОК ДОМОВ";
            this.buttonEditHouse.UseVisualStyleBackColor = false;
            // 
            // buttonAddHouse
            // 
            this.buttonAddHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonAddHouse.FlatAppearance.BorderSize = 0;
            this.buttonAddHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddHouse.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonAddHouse.ForeColor = System.Drawing.Color.White;
            this.buttonAddHouse.Location = new System.Drawing.Point(30, 100);
            this.buttonAddHouse.Name = "buttonAddHouse";
            this.buttonAddHouse.Size = new System.Drawing.Size(400, 70);
            this.buttonAddHouse.TabIndex = 0;
            this.buttonAddHouse.Text = "🏠 ДОБАВИТЬ ДОМ";
            this.buttonAddHouse.UseVisualStyleBackColor = false;
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
            this.labelUserInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.labelUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.labelUserInfo.Location = new System.Drawing.Point(185, 30);
            this.labelUserInfo.Name = "labelUserInfo";
            this.labelUserInfo.Size = new System.Drawing.Size(179, 25);
            this.labelUserInfo.TabIndex = 1;
            this.labelUserInfo.Text = "Имя пользователя";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 14F);
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
            this.ClientSize = new System.Drawing.Size(900, 626);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
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

        private System.Windows.Forms.Button buttonExit;
    }
}