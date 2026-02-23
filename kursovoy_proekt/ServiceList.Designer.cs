namespace kursovoy_proekt
{
    partial class ServiceList
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Button buttonBackToMenu;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit; // Новая кнопка
        private System.Windows.Forms.Label labelPageInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelBackground;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceList));

            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button(); // Новая кнопка
            this.labelPageInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelBackground = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelBackground.SuspendLayout();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            this.dataGridView1.ColumnHeadersHeight = 45;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;

            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            this.dataGridView1.Location = new System.Drawing.Point(3, 63);
            this.dataGridView1.Name = "dataGridView1";

            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(997, 376);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);

            // labelSearch
            this.labelSearch.AutoSize = true;
            this.labelSearch.BackColor = System.Drawing.Color.Transparent;
            this.labelSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelSearch.Location = new System.Drawing.Point(22, 27);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(189, 20);
            this.labelSearch.TabIndex = 1;
            this.labelSearch.Text = "Поиск по наименованию";

            // textBoxSearch
            this.textBoxSearch.BackColor = System.Drawing.Color.White;
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.textBoxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxSearch.Location = new System.Drawing.Point(217, 24);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(300, 27);
            this.textBoxSearch.TabIndex = 2;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);

            // buttonPrev
            this.buttonPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonPrev.FlatAppearance.BorderSize = 0;
            this.buttonPrev.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(130)))), ((int)(((byte)(65)))));
            this.buttonPrev.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(100)))));
            this.buttonPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrev.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonPrev.ForeColor = System.Drawing.Color.White;
            this.buttonPrev.Location = new System.Drawing.Point(400, 580);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(60, 40);
            this.buttonPrev.TabIndex = 5;
            this.buttonPrev.Text = "◀";
            this.buttonPrev.UseVisualStyleBackColor = false;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);

            // buttonNext
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(130)))), ((int)(((byte)(65)))));
            this.buttonNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(100)))));
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonNext.ForeColor = System.Drawing.Color.White;
            this.buttonNext.Location = new System.Drawing.Point(470, 580);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(60, 40);
            this.buttonNext.TabIndex = 6;
            this.buttonNext.Text = "▶";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);

            // labelHeader
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(65, 25);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(201, 45);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Список услуг";

            // buttonBackToMenu
            this.buttonBackToMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonBackToMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonBackToMenu.FlatAppearance.BorderSize = 2;
            this.buttonBackToMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.buttonBackToMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.buttonBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackToMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonBackToMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonBackToMenu.Location = new System.Drawing.Point(827, 580);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(150, 40);
            this.buttonBackToMenu.TabIndex = 13;
            this.buttonBackToMenu.Text = "🏠 ВЕРНУТЬСЯ В МЕНЮ";
            this.buttonBackToMenu.UseVisualStyleBackColor = false;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click);

            // buttonAdd
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(125)))), ((int)(((byte)(175)))));
            this.buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(215)))));
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(800, 22);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(90, 35);
            this.buttonAdd.TabIndex = 14;
            this.buttonAdd.Text = "➕ Добавить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            // buttonEdit - НОВАЯ КНОПКА
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonEdit.Enabled = false;
            this.buttonEdit.FlatAppearance.BorderSize = 0;
            this.buttonEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(125)))), ((int)(((byte)(175)))));
            this.buttonEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(215)))));
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.Location = new System.Drawing.Point(900, 22);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(90, 35);
            this.buttonEdit.TabIndex = 20;
            this.buttonEdit.Text = "✏️ Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);

            // labelPageInfo
            this.labelPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPageInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelPageInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelPageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPageInfo.Location = new System.Drawing.Point(25, 580);
            this.labelPageInfo.Name = "labelPageInfo";
            this.labelPageInfo.Size = new System.Drawing.Size(300, 40);
            this.labelPageInfo.TabIndex = 15;
            this.labelPageInfo.Text = "Страница 1 из 1 | Всего записей: 0";
            this.labelPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // panel1
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 3);
            this.panel1.TabIndex = 16;

            // panel2
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(210)))));
            this.panel2.Location = new System.Drawing.Point(0, 165);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1003, 1);
            this.panel2.TabIndex = 17;

            // panelHeader
            this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1003, 90);
            this.panelHeader.TabIndex = 18;

            // pictureBox1
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;

            // panelBackground
            this.panelBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelBackground.Controls.Add(this.dataGridView1);
            this.panelBackground.Controls.Add(this.labelSearch);
            this.panelBackground.Controls.Add(this.textBoxSearch);
            this.panelBackground.Controls.Add(this.buttonAdd);
            this.panelBackground.Controls.Add(this.buttonEdit); // Добавляем кнопку редактирования
            this.panelBackground.Controls.Add(this.panel2);
            this.panelBackground.Location = new System.Drawing.Point(0, 96);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(1003, 442);
            this.panelBackground.TabIndex = 19;

            // ServiceList
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1003, 640);
            this.Controls.Add(this.panelBackground);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelPageInfo);
            this.Controls.Add(this.buttonBackToMenu);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.MinimumSize = new System.Drawing.Size(942, 679);
            this.Name = "ServiceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список услуг - База отдыха";
            this.Load += new System.EventHandler(this.ServiceList_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelBackground.ResumeLayout(false);
            this.panelBackground.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}