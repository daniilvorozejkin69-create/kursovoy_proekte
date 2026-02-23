namespace kursovoy_proekt
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonEditUser = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(500, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(358, 45);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Панель администратора";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelMain.Controls.Add(this.buttonExit);
            this.panelMain.Controls.Add(this.buttonReport);
            this.panelMain.Controls.Add(this.buttonEditUser);
            this.panelMain.Controls.Add(this.buttonAddUser);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(500, 350);
            this.panelMain.TabIndex = 1;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(100, 260);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(300, 50);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.ButtonExit_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.ButtonExit_MouseLeave);
            // 
            // buttonReport
            // 
            this.buttonReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonReport.FlatAppearance.BorderSize = 0;
            this.buttonReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReport.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReport.ForeColor = System.Drawing.Color.White;
            this.buttonReport.Location = new System.Drawing.Point(100, 190);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(300, 50);
            this.buttonReport.TabIndex = 2;
            this.buttonReport.Text = "Сформировать отчёт";
            this.buttonReport.UseVisualStyleBackColor = false;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            this.buttonReport.MouseEnter += new System.EventHandler(this.ButtonReport_MouseEnter);
            this.buttonReport.MouseLeave += new System.EventHandler(this.ButtonReport_MouseLeave);
            // 
            // buttonEditUser
            // 
            this.buttonEditUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonEditUser.FlatAppearance.BorderSize = 0;
            this.buttonEditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditUser.ForeColor = System.Drawing.Color.White;
            this.buttonEditUser.Location = new System.Drawing.Point(100, 120);
            this.buttonEditUser.Name = "buttonEditUser";
            this.buttonEditUser.Size = new System.Drawing.Size(300, 50);
            this.buttonEditUser.TabIndex = 1;
            this.buttonEditUser.Text = "Просмотр пользователей";
            this.buttonEditUser.UseVisualStyleBackColor = false;
            this.buttonEditUser.Click += new System.EventHandler(this.buttonEditUser_Click);
            this.buttonEditUser.MouseEnter += new System.EventHandler(this.ButtonEditUser_MouseEnter);
            this.buttonEditUser.MouseLeave += new System.EventHandler(this.ButtonEditUser_MouseLeave);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonAddUser.FlatAppearance.BorderSize = 0;
            this.buttonAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddUser.ForeColor = System.Drawing.Color.White;
            this.buttonAddUser.Location = new System.Drawing.Point(100, 50);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(300, 50);
            this.buttonAddUser.TabIndex = 0;
            this.buttonAddUser.Text = "Добавить пользователя";
            this.buttonAddUser.UseVisualStyleBackColor = false;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            this.buttonAddUser.MouseEnter += new System.EventHandler(this.ButtonAddUser_MouseEnter);
            this.buttonAddUser.MouseLeave += new System.EventHandler(this.ButtonAddUser_MouseLeave);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 430);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администратор";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonEditUser;
        private System.Windows.Forms.Button buttonAddUser;
    }
}
