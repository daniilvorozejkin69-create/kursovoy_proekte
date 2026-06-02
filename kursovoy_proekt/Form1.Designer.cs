using System.Windows.Forms;

namespace kursovoy_proekt
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelVersion;

        // Капча
        private System.Windows.Forms.Panel panelCaptcha;
        private System.Windows.Forms.PictureBox pictureBoxCaptcha;
        private System.Windows.Forms.TextBox textBoxCaptcha;
        private System.Windows.Forms.Button buttonRefreshCaptcha;
        private System.Windows.Forms.Label labelCaptchaTitle;

        // Блокировка
        private System.Windows.Forms.Panel panelBlock;
        private System.Windows.Forms.Label labelBlockInfo;

        // Таймеры
        private System.Windows.Forms.Timer timerBlock;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelGreenLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelBlock = new System.Windows.Forms.Panel();
            this.labelBlockInfo = new System.Windows.Forms.Label();
            this.panelCaptcha = new System.Windows.Forms.Panel();
            this.labelCaptchaTitle = new System.Windows.Forms.Label();
            this.textBoxCaptcha = new System.Windows.Forms.TextBox();
            this.buttonRefreshCaptcha = new System.Windows.Forms.Button();
            this.pictureBoxCaptcha = new System.Windows.Forms.PictureBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.timerBlock = new System.Windows.Forms.Timer(this.components);
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelContent.SuspendLayout();
            this.panelBlock.SuspendLayout();
            this.panelCaptcha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).BeginInit();
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
            this.panelHeader.Size = new System.Drawing.Size(450, 70);
            this.panelHeader.TabIndex = 2;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(20, 15);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(70, 15);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(169, 37);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Авторизация";
            // 
            // panelGreenLine
            // 
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 70);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(450, 3);
            this.panelGreenLine.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.panelBlock);
            this.panelContent.Controls.Add(this.panelCaptcha);
            this.panelContent.Controls.Add(this.labelVersion);
            this.panelContent.Controls.Add(this.labelWelcome);
            this.panelContent.Controls.Add(this.buttonExit);
            this.panelContent.Controls.Add(this.buttonLogin);
            this.panelContent.Controls.Add(this.textBoxPassword);
            this.panelContent.Controls.Add(this.labelPassword);
            this.panelContent.Controls.Add(this.textBoxLogin);
            this.panelContent.Controls.Add(this.labelLogin);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 73);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(25);
            this.panelContent.Size = new System.Drawing.Size(450, 484);
            this.panelContent.TabIndex = 0;
            // 
            // panelBlock
            // 
            this.panelBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBlock.Controls.Add(this.labelBlockInfo);
            this.panelBlock.Location = new System.Drawing.Point(25, 140);
            this.panelBlock.Name = "panelBlock";
            this.panelBlock.Size = new System.Drawing.Size(400, 120);
            this.panelBlock.TabIndex = 0;
            this.panelBlock.Visible = false;
            // 
            // labelBlockInfo
            // 
            this.labelBlockInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBlockInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelBlockInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.labelBlockInfo.Location = new System.Drawing.Point(0, 0);
            this.labelBlockInfo.Name = "labelBlockInfo";
            this.labelBlockInfo.Size = new System.Drawing.Size(398, 118);
            this.labelBlockInfo.TabIndex = 0;
            this.labelBlockInfo.Text = "Заблокировано";
            this.labelBlockInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCaptcha
            // 
            this.panelCaptcha.Controls.Add(this.labelCaptchaTitle);
            this.panelCaptcha.Controls.Add(this.textBoxCaptcha);
            this.panelCaptcha.Controls.Add(this.buttonRefreshCaptcha);
            this.panelCaptcha.Controls.Add(this.pictureBoxCaptcha);
            this.panelCaptcha.Location = new System.Drawing.Point(28, 280);
            this.panelCaptcha.Name = "panelCaptcha";
            this.panelCaptcha.Size = new System.Drawing.Size(390, 110);
            this.panelCaptcha.TabIndex = 1;
            this.panelCaptcha.Visible = false;
            // 
            // labelCaptchaTitle
            // 
            this.labelCaptchaTitle.AutoSize = true;
            this.labelCaptchaTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelCaptchaTitle.Location = new System.Drawing.Point(0, 0);
            this.labelCaptchaTitle.Name = "labelCaptchaTitle";
            this.labelCaptchaTitle.Size = new System.Drawing.Size(150, 15);
            this.labelCaptchaTitle.TabIndex = 0;
            this.labelCaptchaTitle.Text = "Введите код с картинки:";
            // 
            // textBoxCaptcha
            // 
            this.textBoxCaptcha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxCaptcha.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.textBoxCaptcha.Location = new System.Drawing.Point(0, 70);
            this.textBoxCaptcha.Name = "textBoxCaptcha";
            this.textBoxCaptcha.Size = new System.Drawing.Size(230, 27);
            this.textBoxCaptcha.TabIndex = 1;
            // 
            // buttonRefreshCaptcha
            // 
            this.buttonRefreshCaptcha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonRefreshCaptcha.Location = new System.Drawing.Point(240, 68);
            this.buttonRefreshCaptcha.Name = "buttonRefreshCaptcha";
            this.buttonRefreshCaptcha.Size = new System.Drawing.Size(40, 30);
            this.buttonRefreshCaptcha.TabIndex = 2;
            this.buttonRefreshCaptcha.Text = "🔄";
            // 
            // pictureBoxCaptcha
            // 
            this.pictureBoxCaptcha.BackColor = System.Drawing.Color.White;
            this.pictureBoxCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCaptcha.Location = new System.Drawing.Point(0, 20);
            this.pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            this.pictureBoxCaptcha.Size = new System.Drawing.Size(280, 45);
            this.pictureBoxCaptcha.TabIndex = 3;
            this.pictureBoxCaptcha.TabStop = false;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.labelVersion.Location = new System.Drawing.Point(25, 465);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(95, 13);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "База отдыха v1.0";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelWelcome.Location = new System.Drawing.Point(25, 25);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(143, 21);
            this.labelWelcome.TabIndex = 3;
            this.labelWelcome.Text = "Войдите в систему";
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonExit.FlatAppearance.BorderSize = 2;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonExit.Location = new System.Drawing.Point(28, 390);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(390, 45);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "🚪 ВЫХОД";
            this.buttonExit.UseVisualStyleBackColor = false;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(28, 340);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(390, 45);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "🔐 ВОЙТИ";
            this.buttonLogin.UseVisualStyleBackColor = false;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxPassword.Location = new System.Drawing.Point(28, 170);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(390, 27);
            this.textBoxPassword.TabIndex = 6;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPassword.Location = new System.Drawing.Point(28, 145);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(66, 20);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Пароль:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxLogin.Location = new System.Drawing.Point(28, 105);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(390, 27);
            this.textBoxLogin.TabIndex = 8;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.labelLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelLogin.Location = new System.Drawing.Point(28, 80);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(56, 20);
            this.labelLogin.TabIndex = 9;
            this.labelLogin.Text = "Логин:";
            // 
            // timerBlock
            // 
            this.timerBlock.Interval = 10000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 557);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelBlock.ResumeLayout(false);
            this.panelCaptcha.ResumeLayout(false);
            this.panelCaptcha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptcha)).EndInit();
            this.ResumeLayout(false);

        }
    }
}