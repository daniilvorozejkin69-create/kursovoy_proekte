namespace kursovoy_proekt
{
    partial class ImportExportForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelContent;

        // Группа Экспорт
        private System.Windows.Forms.GroupBox groupBoxExport;
        private System.Windows.Forms.Label labelExportTable;
        private System.Windows.Forms.ComboBox comboBoxExportTable;
        private System.Windows.Forms.Label labelExportPath;
        private System.Windows.Forms.TextBox textBoxExportPath;
        private System.Windows.Forms.Button buttonBrowseExport;
        private System.Windows.Forms.Button buttonExportCSV;
        private System.Windows.Forms.Button buttonExportExcel;

        // Группа Импорт
        private System.Windows.Forms.GroupBox groupBoxImport;
        private System.Windows.Forms.Label labelImportTable;
        private System.Windows.Forms.ComboBox comboBoxImportTable;
        private System.Windows.Forms.Label labelImportPath;
        private System.Windows.Forms.TextBox textBoxImportPath;
        private System.Windows.Forms.Button buttonBrowseImport;
        private System.Windows.Forms.Button buttonImportCSV;
        private System.Windows.Forms.Label labelImportStatus;

        // Кнопки внизу
        private System.Windows.Forms.Button buttonClose;

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportExportForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBoxExport = new System.Windows.Forms.GroupBox();
            this.labelExportTable = new System.Windows.Forms.Label();
            this.comboBoxExportTable = new System.Windows.Forms.ComboBox();
            this.labelExportPath = new System.Windows.Forms.Label();
            this.textBoxExportPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseExport = new System.Windows.Forms.Button();
            this.buttonExportCSV = new System.Windows.Forms.Button();
            this.buttonExportExcel = new System.Windows.Forms.Button();
            this.groupBoxImport = new System.Windows.Forms.GroupBox();
            this.labelImportTable = new System.Windows.Forms.Label();
            this.comboBoxImportTable = new System.Windows.Forms.ComboBox();
            this.labelImportPath = new System.Windows.Forms.Label();
            this.textBoxImportPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseImport = new System.Windows.Forms.Button();
            this.buttonImportCSV = new System.Windows.Forms.Button();
            this.labelImportStatus = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.groupBoxExport.SuspendLayout();
            this.groupBoxImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(534, 65);
            this.panelHeader.TabIndex = 1;
            // 
            // labelHeader
            // 
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.labelHeader.Size = new System.Drawing.Size(534, 65);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "📦 Импорт и экспорт данных";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.groupBoxExport);
            this.panelContent.Controls.Add(this.groupBoxImport);
            this.panelContent.Controls.Add(this.buttonClose);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 65);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(15);
            this.panelContent.Size = new System.Drawing.Size(534, 446);
            this.panelContent.TabIndex = 0;
            // 
            // groupBoxExport
            // 
            this.groupBoxExport.Controls.Add(this.labelExportTable);
            this.groupBoxExport.Controls.Add(this.comboBoxExportTable);
            this.groupBoxExport.Controls.Add(this.labelExportPath);
            this.groupBoxExport.Controls.Add(this.textBoxExportPath);
            this.groupBoxExport.Controls.Add(this.buttonBrowseExport);
            this.groupBoxExport.Controls.Add(this.buttonExportCSV);
            this.groupBoxExport.Controls.Add(this.buttonExportExcel);
            this.groupBoxExport.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxExport.Location = new System.Drawing.Point(15, 15);
            this.groupBoxExport.Name = "groupBoxExport";
            this.groupBoxExport.Size = new System.Drawing.Size(505, 200);
            this.groupBoxExport.TabIndex = 0;
            this.groupBoxExport.TabStop = false;
            this.groupBoxExport.Text = "📤 Экспорт данных";
            // 
            // labelExportTable
            // 
            this.labelExportTable.AutoSize = true;
            this.labelExportTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelExportTable.Location = new System.Drawing.Point(20, 30);
            this.labelExportTable.Name = "labelExportTable";
            this.labelExportTable.Size = new System.Drawing.Size(132, 15);
            this.labelExportTable.TabIndex = 0;
            this.labelExportTable.Text = "Таблица для экспорта:";
            // 
            // comboBoxExportTable
            // 
            this.comboBoxExportTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExportTable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxExportTable.Items.AddRange(new object[] {
            "Клиенты (client)",
            "Дома (house)",
            "Бронирования (booking)",
            "Заселения (check_in)",
            "Услуги (services)",
            "Персонал (personal)",
            "Скидки (discounts)"});
            this.comboBoxExportTable.Location = new System.Drawing.Point(20, 50);
            this.comboBoxExportTable.Name = "comboBoxExportTable";
            this.comboBoxExportTable.Size = new System.Drawing.Size(250, 25);
            this.comboBoxExportTable.TabIndex = 1;
            // 
            // labelExportPath
            // 
            this.labelExportPath.AutoSize = true;
            this.labelExportPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelExportPath.Location = new System.Drawing.Point(20, 85);
            this.labelExportPath.Name = "labelExportPath";
            this.labelExportPath.Size = new System.Drawing.Size(103, 15);
            this.labelExportPath.TabIndex = 2;
            this.labelExportPath.Text = "Путь сохранения:";
            // 
            // textBoxExportPath
            // 
            this.textBoxExportPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxExportPath.Location = new System.Drawing.Point(20, 105);
            this.textBoxExportPath.Name = "textBoxExportPath";
            this.textBoxExportPath.Size = new System.Drawing.Size(350, 23);
            this.textBoxExportPath.TabIndex = 3;
            this.textBoxExportPath.Text = "C:\\Users\\Разработка\\Desktop\\export.csv";
            // 
            // buttonBrowseExport
            // 
            this.buttonBrowseExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBrowseExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseExport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBrowseExport.Location = new System.Drawing.Point(380, 103);
            this.buttonBrowseExport.Name = "buttonBrowseExport";
            this.buttonBrowseExport.Size = new System.Drawing.Size(100, 28);
            this.buttonBrowseExport.TabIndex = 4;
            this.buttonBrowseExport.Text = "📂 Обзор";
            this.buttonBrowseExport.Click += new System.EventHandler(this.buttonBrowseExport_Click);
            // 
            // buttonExportCSV
            // 
            this.buttonExportCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonExportCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExportCSV.FlatAppearance.BorderSize = 0;
            this.buttonExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportCSV.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonExportCSV.ForeColor = System.Drawing.Color.White;
            this.buttonExportCSV.Location = new System.Drawing.Point(20, 145);
            this.buttonExportCSV.Name = "buttonExportCSV";
            this.buttonExportCSV.Size = new System.Drawing.Size(220, 40);
            this.buttonExportCSV.TabIndex = 5;
            this.buttonExportCSV.Text = "📄 Экспорт в CSV";
            this.buttonExportCSV.UseVisualStyleBackColor = false;
            this.buttonExportCSV.Click += new System.EventHandler(this.buttonExportCSV_Click);
            // 
            // buttonExportExcel
            // 
            this.buttonExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExportExcel.FlatAppearance.BorderSize = 0;
            this.buttonExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonExportExcel.ForeColor = System.Drawing.Color.White;
            this.buttonExportExcel.Location = new System.Drawing.Point(260, 145);
            this.buttonExportExcel.Name = "buttonExportExcel";
            this.buttonExportExcel.Size = new System.Drawing.Size(220, 40);
            this.buttonExportExcel.TabIndex = 6;
            this.buttonExportExcel.Text = "📊 Экспорт в Excel";
            this.buttonExportExcel.UseVisualStyleBackColor = false;
            this.buttonExportExcel.Click += new System.EventHandler(this.buttonExportExcel_Click);
            // 
            // groupBoxImport
            // 
            this.groupBoxImport.Controls.Add(this.labelImportTable);
            this.groupBoxImport.Controls.Add(this.comboBoxImportTable);
            this.groupBoxImport.Controls.Add(this.labelImportPath);
            this.groupBoxImport.Controls.Add(this.textBoxImportPath);
            this.groupBoxImport.Controls.Add(this.buttonBrowseImport);
            this.groupBoxImport.Controls.Add(this.buttonImportCSV);
            this.groupBoxImport.Controls.Add(this.labelImportStatus);
            this.groupBoxImport.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxImport.Location = new System.Drawing.Point(15, 230);
            this.groupBoxImport.Name = "groupBoxImport";
            this.groupBoxImport.Size = new System.Drawing.Size(505, 200);
            this.groupBoxImport.TabIndex = 1;
            this.groupBoxImport.TabStop = false;
            this.groupBoxImport.Text = "📥 Импорт данных";
            // 
            // labelImportTable
            // 
            this.labelImportTable.AutoSize = true;
            this.labelImportTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelImportTable.Location = new System.Drawing.Point(20, 30);
            this.labelImportTable.Name = "labelImportTable";
            this.labelImportTable.Size = new System.Drawing.Size(130, 15);
            this.labelImportTable.TabIndex = 0;
            this.labelImportTable.Text = "Таблица для импорта:";
            // 
            // comboBoxImportTable
            // 
            this.comboBoxImportTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxImportTable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxImportTable.Items.AddRange(new object[] {
            "Клиенты (client)",
            "Дома (house)",
            "Услуги (services)",
            "Скидки (discounts)"});
            this.comboBoxImportTable.Location = new System.Drawing.Point(20, 50);
            this.comboBoxImportTable.Name = "comboBoxImportTable";
            this.comboBoxImportTable.Size = new System.Drawing.Size(250, 25);
            this.comboBoxImportTable.TabIndex = 1;
            // 
            // labelImportPath
            // 
            this.labelImportPath.AutoSize = true;
            this.labelImportPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelImportPath.Location = new System.Drawing.Point(20, 85);
            this.labelImportPath.Name = "labelImportPath";
            this.labelImportPath.Size = new System.Drawing.Size(143, 15);
            this.labelImportPath.TabIndex = 2;
            this.labelImportPath.Text = "Файл для импорта (.csv):";
            // 
            // textBoxImportPath
            // 
            this.textBoxImportPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxImportPath.Location = new System.Drawing.Point(20, 105);
            this.textBoxImportPath.Name = "textBoxImportPath";
            this.textBoxImportPath.Size = new System.Drawing.Size(350, 23);
            this.textBoxImportPath.TabIndex = 3;
            // 
            // buttonBrowseImport
            // 
            this.buttonBrowseImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBrowseImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseImport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBrowseImport.Location = new System.Drawing.Point(380, 103);
            this.buttonBrowseImport.Name = "buttonBrowseImport";
            this.buttonBrowseImport.Size = new System.Drawing.Size(100, 28);
            this.buttonBrowseImport.TabIndex = 4;
            this.buttonBrowseImport.Text = "📂 Обзор";
            this.buttonBrowseImport.Click += new System.EventHandler(this.buttonBrowseImport_Click);
            // 
            // buttonImportCSV
            // 
            this.buttonImportCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonImportCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonImportCSV.FlatAppearance.BorderSize = 0;
            this.buttonImportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImportCSV.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonImportCSV.ForeColor = System.Drawing.Color.White;
            this.buttonImportCSV.Location = new System.Drawing.Point(20, 145);
            this.buttonImportCSV.Name = "buttonImportCSV";
            this.buttonImportCSV.Size = new System.Drawing.Size(220, 40);
            this.buttonImportCSV.TabIndex = 5;
            this.buttonImportCSV.Text = "📥 Импортировать";
            this.buttonImportCSV.UseVisualStyleBackColor = false;
            this.buttonImportCSV.Click += new System.EventHandler(this.buttonImportCSV_Click);
            // 
            // labelImportStatus
            // 
            this.labelImportStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelImportStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.labelImportStatus.Location = new System.Drawing.Point(260, 150);
            this.labelImportStatus.Name = "labelImportStatus";
            this.labelImportStatus.Size = new System.Drawing.Size(220, 30);
            this.labelImportStatus.TabIndex = 6;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.White;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonClose.Location = new System.Drawing.Point(400, 445);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 35);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "✕ Закрыть";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ImportExportForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ImportExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Импорт и экспорт данных";
            this.panelHeader.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.groupBoxExport.ResumeLayout(false);
            this.groupBoxExport.PerformLayout();
            this.groupBoxImport.ResumeLayout(false);
            this.groupBoxImport.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}