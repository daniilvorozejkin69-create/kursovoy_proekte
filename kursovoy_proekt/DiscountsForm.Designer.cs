namespace kursovoy_proekt
{
    partial class DiscountsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.DataGridView dataGridViewDiscounts;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Label labelEditTitle;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.NumericUpDown numericUpDownPercent;
        private System.Windows.Forms.Label labelMinDays;
        private System.Windows.Forms.NumericUpDown numericUpDownMinDays;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.dataGridViewDiscounts = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.labelEditTitle = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelPercent = new System.Windows.Forms.Label();
            this.numericUpDownPercent = new System.Windows.Forms.NumericUpDown();
            this.labelMinDays = new System.Windows.Forms.Label();
            this.numericUpDownMinDays = new System.Windows.Forms.NumericUpDown();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscounts)).BeginInit();
            this.panelEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinDays)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(798, 60);
            this.panelHeader.TabIndex = 1;
            // 
            // labelHeader
            // 
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.labelHeader.Size = new System.Drawing.Size(798, 60);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "💎 Управление скидками";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.dataGridViewDiscounts);
            this.panelContent.Controls.Add(this.panelEdit);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(798, 551);
            this.panelContent.TabIndex = 0;
            // 
            // dataGridViewDiscounts
            // 
            this.dataGridViewDiscounts.AllowUserToAddRows = false;
            this.dataGridViewDiscounts.AllowUserToDeleteRows = false;
            this.dataGridViewDiscounts.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDiscounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDiscounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDiscounts.ColumnHeadersHeight = 40;
            this.dataGridViewDiscounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Name,
            this.Percent,
            this.Type,
            this.MinDays});
            this.dataGridViewDiscounts.EnableHeadersVisualStyles = false;
            this.dataGridViewDiscounts.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewDiscounts.MultiSelect = false;
            this.dataGridViewDiscounts.Name = "dataGridViewDiscounts";
            this.dataGridViewDiscounts.ReadOnly = true;
            this.dataGridViewDiscounts.RowHeadersVisible = false;
            this.dataGridViewDiscounts.RowTemplate.Height = 30;
            this.dataGridViewDiscounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDiscounts.Size = new System.Drawing.Size(450, 520);
            this.dataGridViewDiscounts.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 40;
            // 
            // Name
            // 
            this.Name.HeaderText = "Название скидки";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 180;
            // 
            // Percent
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            this.Percent.DefaultCellStyle = dataGridViewCellStyle2;
            this.Percent.HeaderText = "%";
            this.Percent.Name = "Percent";
            this.Percent.ReadOnly = true;
            this.Percent.Width = 60;
            // 
            // Type
            // 
            this.Type.HeaderText = "Тип";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 110;
            // 
            // MinDays
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MinDays.DefaultCellStyle = dataGridViewCellStyle3;
            this.MinDays.HeaderText = "Мин. дней";
            this.MinDays.Name = "MinDays";
            this.MinDays.ReadOnly = true;
            this.MinDays.Width = 80;
            // 
            // panelEdit
            // 
            this.panelEdit.BackColor = System.Drawing.Color.White;
            this.panelEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEdit.Controls.Add(this.labelEditTitle);
            this.panelEdit.Controls.Add(this.labelName);
            this.panelEdit.Controls.Add(this.textBoxName);
            this.panelEdit.Controls.Add(this.labelType);
            this.panelEdit.Controls.Add(this.comboBoxType);
            this.panelEdit.Controls.Add(this.labelPercent);
            this.panelEdit.Controls.Add(this.numericUpDownPercent);
            this.panelEdit.Controls.Add(this.labelMinDays);
            this.panelEdit.Controls.Add(this.numericUpDownMinDays);
            this.panelEdit.Controls.Add(this.labelDescription);
            this.panelEdit.Controls.Add(this.textBoxDescription);
            this.panelEdit.Controls.Add(this.checkBoxActive);
            this.panelEdit.Controls.Add(this.buttonSave);
            this.panelEdit.Controls.Add(this.buttonDelete);
            this.panelEdit.Controls.Add(this.buttonAdd);
            this.panelEdit.Location = new System.Drawing.Point(490, 20);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(300, 520);
            this.panelEdit.TabIndex = 1;
            // 
            // labelEditTitle
            // 
            this.labelEditTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelEditTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelEditTitle.Location = new System.Drawing.Point(15, 15);
            this.labelEditTitle.Name = "labelEditTitle";
            this.labelEditTitle.Size = new System.Drawing.Size(270, 30);
            this.labelEditTitle.TabIndex = 0;
            this.labelEditTitle.Text = "Редактирование";
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelName.Location = new System.Drawing.Point(15, 55);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(270, 18);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Название:";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxName.Location = new System.Drawing.Point(15, 75);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(270, 25);
            this.textBoxName.TabIndex = 2;
            // 
            // labelType
            // 
            this.labelType.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.labelType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelType.Location = new System.Drawing.Point(15, 110);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(270, 18);
            this.labelType.TabIndex = 3;
            this.labelType.Text = "Тип скидки:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxType.Items.AddRange(new object[] {
            "Сезонная",
            "Постоянный клиент",
            "Промокод",
            "Специальная"});
            this.comboBoxType.Location = new System.Drawing.Point(15, 130);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(270, 25);
            this.comboBoxType.TabIndex = 4;
            // 
            // labelPercent
            // 
            this.labelPercent.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.labelPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPercent.Location = new System.Drawing.Point(15, 165);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(270, 18);
            this.labelPercent.TabIndex = 5;
            this.labelPercent.Text = "Процент скидки:";
            // 
            // numericUpDownPercent
            // 
            this.numericUpDownPercent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownPercent.Location = new System.Drawing.Point(15, 185);
            this.numericUpDownPercent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPercent.Name = "numericUpDownPercent";
            this.numericUpDownPercent.Size = new System.Drawing.Size(100, 25);
            this.numericUpDownPercent.TabIndex = 6;
            this.numericUpDownPercent.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelMinDays
            // 
            this.labelMinDays.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.labelMinDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelMinDays.Location = new System.Drawing.Point(15, 220);
            this.labelMinDays.Name = "labelMinDays";
            this.labelMinDays.Size = new System.Drawing.Size(270, 18);
            this.labelMinDays.TabIndex = 7;
            this.labelMinDays.Text = "Мин. дней бронирования:";
            // 
            // numericUpDownMinDays
            // 
            this.numericUpDownMinDays.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownMinDays.Location = new System.Drawing.Point(15, 240);
            this.numericUpDownMinDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDownMinDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMinDays.Name = "numericUpDownMinDays";
            this.numericUpDownMinDays.Size = new System.Drawing.Size(100, 25);
            this.numericUpDownMinDays.TabIndex = 8;
            this.numericUpDownMinDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDescription.Location = new System.Drawing.Point(15, 275);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(270, 18);
            this.labelDescription.TabIndex = 9;
            this.labelDescription.Text = "Описание:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxDescription.Location = new System.Drawing.Point(15, 295);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(270, 70);
            this.textBoxDescription.TabIndex = 10;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.checkBoxActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxActive.Location = new System.Drawing.Point(15, 375);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(270, 20);
            this.checkBoxActive.TabIndex = 11;
            this.checkBoxActive.Text = "Скидка активна";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(15, 420);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(125, 40);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "💾 Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(150, 420);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(135, 40);
            this.buttonDelete.TabIndex = 13;
            this.buttonDelete.Text = "🗑 Удалить";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(15, 470);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(270, 40);
            this.buttonAdd.TabIndex = 14;
            this.buttonAdd.Text = "➕ Новая скидка";
            this.buttonAdd.UseVisualStyleBackColor = false;
            // 
            // DiscountsForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(798, 611);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
           //this.Name = "DiscountsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление скидками";
            this.panelHeader.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscounts)).EndInit();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinDays)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinDays;
    }
}