namespace kursovoy_proekt
{
    partial class AddUser
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonGeneratePassword;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.ComboBox comboBoxPersonal;
        private System.Windows.Forms.Label labelPersonal;
        private System.Windows.Forms.ToolTip toolTip;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelGreenLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonGeneratePassword = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.comboBoxPersonal = new System.Windows.Forms.ComboBox();
            this.labelPersonal = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(600, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(30, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(398, 37);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "ДОБАВЛЕНИЕ НОВОГО ПОЛЬЗОВАТЕЛЯ";
            // 
            // panelGreenLine
            // 
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 80);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(600, 3);
            this.panelGreenLine.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.buttonGeneratePassword);
            this.panelContent.Controls.Add(this.buttonMenu);
            this.panelContent.Controls.Add(this.buttonDelete);
            this.panelContent.Controls.Add(this.buttonSave);
            this.panelContent.Controls.Add(this.comboBoxRole);
            this.panelContent.Controls.Add(this.labelRole);
            this.panelContent.Controls.Add(this.textBoxPassword);
            this.panelContent.Controls.Add(this.labelPassword);
            this.panelContent.Controls.Add(this.textBoxLogin);
            this.panelContent.Controls.Add(this.labelLogin);
            this.panelContent.Controls.Add(this.comboBoxPersonal);
            this.panelContent.Controls.Add(this.labelPersonal);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 83);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(600, 567);
            this.panelContent.TabIndex = 2;
            // 
            // buttonGeneratePassword
            // 
            this.buttonGeneratePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonGeneratePassword.FlatAppearance.BorderSize = 0;
            this.buttonGeneratePassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(125)))), ((int)(((byte)(175)))));
            this.buttonGeneratePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(215)))));
            this.buttonGeneratePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGeneratePassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonGeneratePassword.ForeColor = System.Drawing.Color.White;
            this.buttonGeneratePassword.Location = new System.Drawing.Point(380, 210);
            this.buttonGeneratePassword.Name = "buttonGeneratePassword";
            this.buttonGeneratePassword.Size = new System.Drawing.Size(170, 27);
            this.buttonGeneratePassword.TabIndex = 3;
            this.toolTip.SetToolTip(this.buttonGeneratePassword, "Сгенерировать безопасный пароль (Ctrl+G)");
            this.buttonGeneratePassword.Text = "🔑 Сгенерировать пароль";
            this.buttonGeneratePassword.UseVisualStyleBackColor = false;
            this.buttonGeneratePassword.Click += new System.EventHandler(this.buttonGeneratePassword_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonMenu.FlatAppearance.BorderSize = 2;
            this.buttonMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.buttonMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonMenu.Location = new System.Drawing.Point(320, 460);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(230, 50);
            this.buttonMenu.TabIndex = 6;
            this.toolTip.SetToolTip(this.buttonMenu, "Вернуться в главное меню без сохранения");
            this.buttonMenu.Text = "🏠 ВЕРНУТЬСЯ В МЕНЮ";
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(50, 460);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(230, 50);
            this.buttonDelete.TabIndex = 5;
            this.toolTip.SetToolTip(this.buttonDelete, "Удалить пользователя (в режиме редактирования)");
            this.buttonDelete.Text = "🗑️ УДАЛИТЬ ПОЛЬЗОВАТЕЛЯ";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Visible = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(130)))), ((int)(((byte)(65)))));
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(100)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(50, 400);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(500, 50);
            this.buttonSave.TabIndex = 4;
            this.toolTip.SetToolTip(this.buttonSave, "Сохранить пользователя");
            this.buttonSave.Text = "➕ ДОБАВИТЬ ПОЛЬЗОВАТЕЛЯ";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.BackColor = System.Drawing.Color.White;
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRole.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(50, 280);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(500, 28);
            this.comboBoxRole.TabIndex = 2;
            this.toolTip.SetToolTip(this.comboBoxRole, "Выберите роль пользователя");
            this.comboBoxRole.Enter += new System.EventHandler(this.Control_Enter);
            this.comboBoxRole.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelRole.Location = new System.Drawing.Point(50, 255);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(41, 19);
            this.labelRole.TabIndex = 0;
            this.labelRole.Text = "Роль:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.White;
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxPassword.Location = new System.Drawing.Point(50, 210);
            this.textBoxPassword.MaxLength = 100;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(320, 27);
            this.textBoxPassword.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBoxPassword, "Пароль (минимум 6 символов)\r\nCtrl+H - показать/скрыть\r\nПравый клик - меню");
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.Enter += new System.EventHandler(this.Control_Enter);
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyDown);
            this.textBoxPassword.Leave += new System.EventHandler(this.Control_Leave);
            this.textBoxPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxPassword_MouseDown);
            this.textBoxPassword.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPassword_Validating);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPassword.Location = new System.Drawing.Point(50, 185);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(61, 19);
            this.labelPassword.TabIndex = 0;
            this.labelPassword.Text = "Пароль:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.BackColor = System.Drawing.Color.White;
            this.textBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxLogin.Location = new System.Drawing.Point(50, 140);
            this.textBoxLogin.MaxLength = 50;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(500, 27);
            this.textBoxLogin.TabIndex = 0;
            this.toolTip.SetToolTip(this.textBoxLogin, "Логин (3-50 символов, только латинские буквы, цифры и подчеркивание)");
            this.textBoxLogin.Enter += new System.EventHandler(this.Control_Enter);
            this.textBoxLogin.Leave += new System.EventHandler(this.Control_Leave);
            this.textBoxLogin.TextChanged += new System.EventHandler(this.textBoxLogin_TextChanged);
            this.textBoxLogin.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxLogin_Validating);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelLogin.Location = new System.Drawing.Point(50, 115);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(53, 19);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Логин:";
            // 
            // comboBoxPersonal
            // 
            this.comboBoxPersonal.BackColor = System.Drawing.Color.White;
            this.comboBoxPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPersonal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxPersonal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBoxPersonal.FormattingEnabled = true;
            this.comboBoxPersonal.Location = new System.Drawing.Point(50, 70);
            this.comboBoxPersonal.Name = "comboBoxPersonal";
            this.comboBoxPersonal.Size = new System.Drawing.Size(500, 28);
            this.comboBoxPersonal.TabIndex = 7;
            this.toolTip.SetToolTip(this.comboBoxPersonal, "Выберите сотрудника для создания учетной записи");
            this.comboBoxPersonal.Enter += new System.EventHandler(this.Control_Enter);
            this.comboBoxPersonal.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // labelPersonal
            // 
            this.labelPersonal.AutoSize = true;
            this.labelPersonal.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPersonal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPersonal.Location = new System.Drawing.Point(50, 45);
            this.labelPersonal.Name = "labelPersonal";
            this.labelPersonal.Size = new System.Drawing.Size(82, 19);
            this.labelPersonal.TabIndex = 0;
            this.labelPersonal.Text = "Сотрудник:";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 650);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(616, 689);
            this.Name = "AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление пользователями - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}