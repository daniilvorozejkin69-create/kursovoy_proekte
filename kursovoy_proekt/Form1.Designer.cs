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
            this.timerBlock = new System.Windows.Forms.Timer();
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
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(450, 70);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(20, 15);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // labelHeader
            // 
            this.labelHeader.Text = "Авторизация";
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(70, 15);
            this.labelHeader.AutoSize = true;
            // 
            // panelGreenLine
            // 
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Height = 3;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(240, 245, 235);
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
            this.panelContent.Padding = new System.Windows.Forms.Padding(25);
            // 
            // panelBlock
            // 
            this.panelBlock.BackColor = System.Drawing.Color.FromArgb(255, 240, 240);
            this.panelBlock.Controls.Add(this.labelBlockInfo);
            this.panelBlock.Location = new System.Drawing.Point(25, 140);
            this.panelBlock.Name = "panelBlock";
            this.panelBlock.Size = new System.Drawing.Size(400, 120);
            this.panelBlock.Visible = false;
            this.panelBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // labelBlockInfo
            // 
            this.labelBlockInfo.Text = "Заблокировано";
            this.labelBlockInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelBlockInfo.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.labelBlockInfo.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.panelCaptcha.Visible = false;
            // 
            // labelCaptchaTitle
            // 
            this.labelCaptchaTitle.Text = "Введите код с картинки:";
            this.labelCaptchaTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelCaptchaTitle.Location = new System.Drawing.Point(0, 0);
            this.labelCaptchaTitle.AutoSize = true;
            // 
            // textBoxCaptcha
            // 
            this.textBoxCaptcha.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.textBoxCaptcha.Location = new System.Drawing.Point(0, 70);
            this.textBoxCaptcha.Size = new System.Drawing.Size(230, 27);
            this.textBoxCaptcha.CharacterCasing = CharacterCasing.Upper;
            // 
            // buttonRefreshCaptcha
            // 
            this.buttonRefreshCaptcha.Text = "🔄";
            this.buttonRefreshCaptcha.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonRefreshCaptcha.Location = new System.Drawing.Point(240, 68);
            this.buttonRefreshCaptcha.Size = new System.Drawing.Size(40, 30);
            // 
            // pictureBoxCaptcha
            // 
            this.pictureBoxCaptcha.BackColor = System.Drawing.Color.White;
            this.pictureBoxCaptcha.Location = new System.Drawing.Point(0, 20);
            this.pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            this.pictureBoxCaptcha.Size = new System.Drawing.Size(280, 45);
            this.pictureBoxCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // labelVersion
            // 
            this.labelVersion.Text = "База отдыха v1.0";
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.labelVersion.Location = new System.Drawing.Point(25, 465);
            this.labelVersion.AutoSize = true;
            // 
            // labelWelcome
            // 
            this.labelWelcome.Text = "Войдите в систему";
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelWelcome.Location = new System.Drawing.Point(25, 25);
            this.labelWelcome.AutoSize = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Text = "🚪 ВЫХОД";
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonExit.ForeColor = System.Drawing.Color.FromArgb(220, 80, 80);
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 80, 80);
            this.buttonExit.FlatAppearance.BorderSize = 2;
            this.buttonExit.Location = new System.Drawing.Point(28, 390);
            this.buttonExit.Size = new System.Drawing.Size(390, 45);
            this.buttonExit.UseVisualStyleBackColor = false;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Text = "🔐 ВОЙТИ";
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.Location = new System.Drawing.Point(28, 340);
            this.buttonLogin.Size = new System.Drawing.Size(390, 45);
            this.buttonLogin.UseVisualStyleBackColor = false;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxPassword.Location = new System.Drawing.Point(28, 170);
            this.textBoxPassword.Size = new System.Drawing.Size(390, 27);
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            this.labelPassword.Text = "Пароль:";
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelPassword.Location = new System.Drawing.Point(28, 145);
            this.labelPassword.AutoSize = true;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBoxLogin.Location = new System.Drawing.Point(28, 105);
            this.textBoxLogin.Size = new System.Drawing.Size(390, 27);
            // 
            // labelLogin
            // 
            this.labelLogin.Text = "Логин:";
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.labelLogin.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelLogin.Location = new System.Drawing.Point(28, 80);
            this.labelLogin.AutoSize = true;
            // 
            // timerBlock
            // 
            this.timerBlock.Interval = 10000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 500);
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