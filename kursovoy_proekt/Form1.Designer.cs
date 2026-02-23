namespace kursovoy_proekt
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Основные панели
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;

        // Элементы формы
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonExit;

        // Дополнительные элементы
        private System.Windows.Forms.Label labelWelcome;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelGreenLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();

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
            this.panelHeader.Size = new System.Drawing.Size(450, 90);
            this.panelHeader.TabIndex = 0;

            // pictureBoxLogo
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(25, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;

            // labelHeader
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(90, 25);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(155, 37);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Авторизация";

            // panelGreenLine
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 90);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(450, 3);
            this.panelGreenLine.TabIndex = 1;

            // panelContent
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(240, 245, 235);
            this.panelContent.Controls.Add(this.labelVersion);
            this.panelContent.Controls.Add(this.labelWelcome);
            this.panelContent.Controls.Add(this.buttonExit);
            this.panelContent.Controls.Add(this.buttonLogin);
            this.panelContent.Controls.Add(this.textBoxPassword);
            this.panelContent.Controls.Add(this.labelPassword);
            this.panelContent.Controls.Add(this.textBoxLogin);
            this.panelContent.Controls.Add(this.labelLogin);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 93);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(450, 357);
            this.panelContent.TabIndex = 2;

            // labelWelcome
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelWelcome.Location = new System.Drawing.Point(30, 30);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(309, 21);
            this.labelWelcome.TabIndex = 6;
            this.labelWelcome.Text = "Войдите в систему, чтобы продолжить";

            // labelLogin
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelLogin.Location = new System.Drawing.Point(30, 80);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(52, 20);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Логин:";

            // textBoxLogin
            this.textBoxLogin.BackColor = System.Drawing.Color.White;
            this.textBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLogin.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.textBoxLogin.Location = new System.Drawing.Point(34, 105);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(380, 27);
            this.textBoxLogin.TabIndex = 1;
            this.textBoxLogin.Enter += new System.EventHandler(this.TextBox_Enter);
            this.textBoxLogin.Leave += new System.EventHandler(this.TextBox_Leave);

            // labelPassword
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelPassword.Location = new System.Drawing.Point(30, 150);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(61, 20);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Пароль:";

            // textBoxPassword
            this.textBoxPassword.BackColor = System.Drawing.Color.White;
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.textBoxPassword.Location = new System.Drawing.Point(34, 175);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(380, 27);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.Enter += new System.EventHandler(this.TextBox_Enter);
            this.textBoxPassword.Leave += new System.EventHandler(this.TextBox_Leave);
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxPassword_KeyDown);

            // buttonLogin
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(34, 230);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(380, 50);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "🔐 ВОЙТИ В СИСТЕМУ";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            this.buttonLogin.MouseEnter += new System.EventHandler(this.ButtonLogin_MouseEnter);
            this.buttonLogin.MouseLeave += new System.EventHandler(this.ButtonLogin_MouseLeave);

            // buttonExit
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 80, 80);
            this.buttonExit.FlatAppearance.BorderSize = 2;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.ForeColor = System.Drawing.Color.FromArgb(220, 80, 80);
            this.buttonExit.Location = new System.Drawing.Point(34, 290);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(380, 50);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "🚪 ВЫХОД";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.ButtonExit_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.ButtonExit_MouseLeave);

            // labelVersion
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.labelVersion.Location = new System.Drawing.Point(30, 360);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(143, 13);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "База отдыха v1.0 | Авторизация";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}