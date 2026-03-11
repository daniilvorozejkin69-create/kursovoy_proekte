namespace kursovoy_proekt
{
    partial class DirectoriesForm
    {
        private System.ComponentModel.IContainer components = null;

        // Основные панели
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;

        // Заголовок текущей таблицы
        private System.Windows.Forms.Label labelTitle;

        // Меню справочников (кнопки переключения)
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonPositions;
        private System.Windows.Forms.Button buttonHouseClass;

        // DataGridView
        private System.Windows.Forms.DataGridView dataGridViewDirectories;

        // Панель с кнопками действий
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonBack;

        // Статус
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;

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
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonHouseClass = new System.Windows.Forms.Button();
            this.buttonPositions = new System.Windows.Forms.Button();
            this.dataGridViewDirectories = new System.Windows.Forms.DataGridView();
            this.panelActions = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelContent.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirectories)).BeginInit();
            this.panelActions.SuspendLayout();
            this.statusStrip.SuspendLayout();
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
            this.panelHeader.Size = new System.Drawing.Size(1100, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(25, 15);
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
            this.labelHeader.Location = new System.Drawing.Point(90, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(245, 45);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "СПРАВОЧНИКИ";
            // 
            // panelGreenLine
            // 
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 80);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(1100, 3);
            this.panelGreenLine.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.labelTitle);
            this.panelContent.Controls.Add(this.panelMenu);
            this.panelContent.Controls.Add(this.dataGridViewDirectories);
            this.panelContent.Controls.Add(this.panelActions);
            this.panelContent.Controls.Add(this.labelCount);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 83);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(1100, 617);
            this.panelContent.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(358, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "👔 СПРАВОЧНИК ДОЛЖНОСТЕЙ";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.buttonHouseClass);
            this.panelMenu.Controls.Add(this.buttonPositions);
            this.panelMenu.Location = new System.Drawing.Point(20, 60);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1060, 70);
            this.panelMenu.TabIndex = 1;
            // 
            // buttonHouseClass
            // 
            this.buttonHouseClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonHouseClass.FlatAppearance.BorderSize = 0;
            this.buttonHouseClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHouseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.buttonHouseClass.ForeColor = System.Drawing.Color.White;
            this.buttonHouseClass.Location = new System.Drawing.Point(240, 15);
            this.buttonHouseClass.Name = "buttonHouseClass";
            this.buttonHouseClass.Size = new System.Drawing.Size(200, 40);
            this.buttonHouseClass.TabIndex = 1;
            this.buttonHouseClass.Text = "🏠 КЛАССЫ ДОМОВ";
            this.buttonHouseClass.UseVisualStyleBackColor = false;
            this.buttonHouseClass.Click += new System.EventHandler(this.buttonHouseClass_Click);
            // 
            // buttonPositions
            // 
            this.buttonPositions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonPositions.FlatAppearance.BorderSize = 0;
            this.buttonPositions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPositions.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.buttonPositions.ForeColor = System.Drawing.Color.White;
            this.buttonPositions.Location = new System.Drawing.Point(20, 15);
            this.buttonPositions.Name = "buttonPositions";
            this.buttonPositions.Size = new System.Drawing.Size(200, 40);
            this.buttonPositions.TabIndex = 0;
            this.buttonPositions.Text = "👔 ДОЛЖНОСТИ";
            this.buttonPositions.UseVisualStyleBackColor = false;
            this.buttonPositions.Click += new System.EventHandler(this.buttonPositions_Click);
            // 
            // dataGridViewDirectories
            // 
            this.dataGridViewDirectories.AllowUserToAddRows = false;
            this.dataGridViewDirectories.AllowUserToDeleteRows = false;
            this.dataGridViewDirectories.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDirectories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewDirectories.ColumnHeadersHeight = 40;
            this.dataGridViewDirectories.EnableHeadersVisualStyles = false;
            this.dataGridViewDirectories.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            this.dataGridViewDirectories.Location = new System.Drawing.Point(20, 140);
            this.dataGridViewDirectories.Name = "dataGridViewDirectories";
            this.dataGridViewDirectories.ReadOnly = true;
            this.dataGridViewDirectories.RowHeadersVisible = false;
            this.dataGridViewDirectories.RowTemplate.Height = 30;
            this.dataGridViewDirectories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDirectories.Size = new System.Drawing.Size(1060, 350);
            this.dataGridViewDirectories.TabIndex = 2;
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.White;
            this.panelActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActions.Controls.Add(this.buttonBack);
            this.panelActions.Controls.Add(this.buttonRefresh);
            this.panelActions.Controls.Add(this.buttonEdit);
            this.panelActions.Controls.Add(this.buttonAdd);
            this.panelActions.Location = new System.Drawing.Point(20, 500);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1060, 70);
            this.panelActions.TabIndex = 3;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Transparent;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonBack.FlatAppearance.BorderSize = 2;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.buttonBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonBack.Location = new System.Drawing.Point(890, 15);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(150, 40);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "🔙 НАЗАД";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(365, 15);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(150, 40);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "🔄 ОБНОВИТЬ";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonEdit.FlatAppearance.BorderSize = 0;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.Location = new System.Drawing.Point(176, 15);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(183, 40);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "✏️ РЕДАКТИРОВАТЬ";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(20, 15);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(150, 40);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "➕ ДОБАВИТЬ";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCount.Location = new System.Drawing.Point(20, 580);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(112, 19);
            this.labelCount.TabIndex = 4;
            this.labelCount.Text = "Всего записей: 0";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 700);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1100, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabel.Text = "Выберите справочник";
            // 
            // DirectoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 722);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DirectoriesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочники - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDirectories)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}