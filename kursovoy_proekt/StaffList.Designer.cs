namespace kursovoy_proekt
{
    partial class StaffList
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelUserInfo;
        private System.Windows.Forms.Panel panelSeparator;

        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxStatus;

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonBackToMenu;

        private System.Windows.Forms.DataGridView dataGridViewStaff;

        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelPageInfo;

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffList));

            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelGreenLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.dataGridViewStaff = new System.Windows.Forms.DataGridView();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelPageInfo = new System.Windows.Forms.Label();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.labelUserInfo = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();

            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelContent.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStaff)).BeginInit();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 80);
            this.panelHeader.TabIndex = 0;

            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(25, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;

            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(75, 22);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(250, 32);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "УПРАВЛЕНИЕ ПЕРСОНАЛОМ";

            // panelGreenLine
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 80);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(1200, 3);
            this.panelGreenLine.TabIndex = 1;

            // panelContent
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(240, 245, 235);
            this.panelContent.Controls.Add(this.statusStrip);
            this.panelContent.Controls.Add(this.labelVersion);
            this.panelContent.Controls.Add(this.buttonBackToMenu);
            this.panelContent.Controls.Add(this.buttonRefresh);
            this.panelContent.Controls.Add(this.buttonDelete);
            this.panelContent.Controls.Add(this.buttonEdit);
            this.panelContent.Controls.Add(this.buttonAdd);
            this.panelContent.Controls.Add(this.comboBoxStatus);
            this.panelContent.Controls.Add(this.labelStatus);
            this.panelContent.Controls.Add(this.comboBoxRole);
            this.panelContent.Controls.Add(this.labelRole);
            this.panelContent.Controls.Add(this.textBoxSearch);
            this.panelContent.Controls.Add(this.labelSearch);
            this.panelContent.Controls.Add(this.dataGridViewStaff);
            this.panelContent.Controls.Add(this.buttonPrev);
            this.panelContent.Controls.Add(this.buttonNext);
            this.panelContent.Controls.Add(this.labelPageInfo);
            this.panelContent.Controls.Add(this.panelSeparator);
            this.panelContent.Controls.Add(this.labelUserInfo);
            this.panelContent.Controls.Add(this.labelWelcome);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 83);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(1200, 667);
            this.panelContent.TabIndex = 2;

            // labelWelcome
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelWelcome.Location = new System.Drawing.Point(30, 20);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(131, 21);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Добро пожаловать,";

            // labelUserInfo
            this.labelUserInfo.AutoSize = true;
            this.labelUserInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.labelUserInfo.ForeColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.labelUserInfo.Location = new System.Drawing.Point(161, 20);
            this.labelUserInfo.Name = "labelUserInfo";
            this.labelUserInfo.Size = new System.Drawing.Size(136, 21);
            this.labelUserInfo.TabIndex = 1;
            this.labelUserInfo.Text = "Имя пользователя";

            // panelSeparator
            this.panelSeparator.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.panelSeparator.Location = new System.Drawing.Point(30, 50);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(1140, 2);
            this.panelSeparator.TabIndex = 2;

            // labelSearch
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelSearch.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelSearch.Location = new System.Drawing.Point(30, 70);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(51, 19);
            this.labelSearch.TabIndex = 3;
            this.labelSearch.Text = "Поиск:";

            // textBoxSearch
            this.textBoxSearch.Location = new System.Drawing.Point(30, 95);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(300, 22);
            this.textBoxSearch.TabIndex = 4;

            // labelRole
            this.labelRole.AutoSize = true;
            this.labelRole.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelRole.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelRole.Location = new System.Drawing.Point(350, 70);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(38, 19);
            this.labelRole.TabIndex = 5;
            this.labelRole.Text = "Роль:";

            // comboBoxRole
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.Items.AddRange(new object[] {
                "Все роли",
                "Администратор",
                "Рецепшен",
                "Менеджер"});
            this.comboBoxRole.Location = new System.Drawing.Point(350, 95);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(150, 21);
            this.comboBoxRole.TabIndex = 6;

            // labelStatus
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelStatus.Location = new System.Drawing.Point(520, 70);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(55, 19);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Статус:";

            // comboBoxStatus
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Items.AddRange(new object[] {
                "Все",
                "Активные",
                "Неактивные"});
            this.comboBoxStatus.Location = new System.Drawing.Point(520, 95);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(120, 21);
            this.comboBoxStatus.TabIndex = 8;

            // buttonAdd
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(950, 85);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 35);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "➕ ДОБАВИТЬ";
            this.buttonAdd.UseVisualStyleBackColor = true;

            // buttonEdit
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(1060, 85);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(120, 35);
            this.buttonEdit.TabIndex = 10;
            this.buttonEdit.Text = "✏️ РЕДАКТИРОВАТЬ";
            this.buttonEdit.UseVisualStyleBackColor = true;

            // buttonDelete
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(1190, 85);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 35);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "🗑️ УДАЛИТЬ";
            this.buttonDelete.UseVisualStyleBackColor = true;

            // buttonRefresh
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Location = new System.Drawing.Point(1300, 85);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 35);
            this.buttonRefresh.TabIndex = 12;
            this.buttonRefresh.Text = "🔄 ОБНОВИТЬ";
            this.buttonRefresh.UseVisualStyleBackColor = true;

            // dataGridViewStaff
            this.dataGridViewStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStaff.Location = new System.Drawing.Point(30, 140);
            this.dataGridViewStaff.Name = "dataGridViewStaff";
            this.dataGridViewStaff.ReadOnly = true;
            this.dataGridViewStaff.Size = new System.Drawing.Size(1370, 350);
            this.dataGridViewStaff.TabIndex = 13;
            this.dataGridViewStaff.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStaff_CellDoubleClick);
            this.dataGridViewStaff.SelectionChanged += new System.EventHandler(this.dataGridViewStaff_SelectionChanged);

            // buttonPrev
            this.buttonPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPrev.Location = new System.Drawing.Point(400, 510);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(50, 40);
            this.buttonPrev.TabIndex = 14;
            this.buttonPrev.Text = "◀";
            this.buttonPrev.UseVisualStyleBackColor = true;

            // buttonNext
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNext.Location = new System.Drawing.Point(470, 510);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(50, 40);
            this.buttonNext.TabIndex = 15;
            this.buttonNext.Text = "▶";
            this.buttonNext.UseVisualStyleBackColor = true;

            // labelPageInfo
            this.labelPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPageInfo.AutoSize = true;
            this.labelPageInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelPageInfo.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelPageInfo.Location = new System.Drawing.Point(30, 520);
            this.labelPageInfo.Name = "labelPageInfo";
            this.labelPageInfo.Size = new System.Drawing.Size(125, 19);
            this.labelPageInfo.TabIndex = 16;
            this.labelPageInfo.Text = "Страница 1 из 1 | 0";

            // buttonBackToMenu
            this.buttonBackToMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBackToMenu.Location = new System.Drawing.Point(1250, 505);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(150, 45);
            this.buttonBackToMenu.TabIndex = 17;
            this.buttonBackToMenu.Text = "🏠 В МЕНЮ";
            this.buttonBackToMenu.UseVisualStyleBackColor = true;

            // statusStrip
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(30, 560);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1370, 22);
            this.statusStrip.TabIndex = 18;

            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(135, 17);
            this.toolStripStatusLabel.Text = "Загрузка данных...";

            // labelVersion
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.labelVersion.Location = new System.Drawing.Point(30, 590);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(158, 13);
            this.labelVersion.TabIndex = 19;
            this.labelVersion.Text = "База отдыха v1.0 | Персонал";

            // StaffList
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 750);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StaffList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление персоналом";
            this.Load += new System.EventHandler(this.StaffList_Load);

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStaff)).EndInit();
            this.ResumeLayout(false);
        }
    }
}