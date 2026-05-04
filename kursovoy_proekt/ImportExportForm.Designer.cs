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
            // ===== ФОРМА =====
            this.Text = "Импорт и экспорт данных";
            this.Size = new System.Drawing.Size(550, 550);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(240, 245, 235);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // ===== ШАПКА =====
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();

            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 65;

            this.labelHeader.Text = "📦 Импорт и экспорт данных";
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelHeader.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);

            this.panelHeader.Controls.Add(this.labelHeader);

            // ===== КОНТЕНТ =====
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Padding = new System.Windows.Forms.Padding(15);

            // ===== ГРУППА ЭКСПОРТ =====
            this.groupBoxExport = new System.Windows.Forms.GroupBox();
            this.groupBoxExport.Text = "📤 Экспорт данных";
            this.groupBoxExport.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxExport.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.groupBoxExport.Location = new System.Drawing.Point(15, 15);
            this.groupBoxExport.Size = new System.Drawing.Size(505, 200);

            this.labelExportTable = new System.Windows.Forms.Label();
            this.labelExportTable.Text = "Таблица для экспорта:";
            this.labelExportTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelExportTable.Location = new System.Drawing.Point(20, 30);
            this.labelExportTable.AutoSize = true;

            this.comboBoxExportTable = new System.Windows.Forms.ComboBox();
            this.comboBoxExportTable.Location = new System.Drawing.Point(20, 50);
            this.comboBoxExportTable.Size = new System.Drawing.Size(250, 25);
            this.comboBoxExportTable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxExportTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExportTable.Items.AddRange(new object[] {
                "Клиенты (client)",
                "Дома (house)",
                "Бронирования (booking)",
                "Заселения (check_in)",
                "Услуги (services)",
                "Персонал (personal)",
                "Скидки (discounts)"
            });
            this.comboBoxExportTable.SelectedIndex = 0;

            this.labelExportPath = new System.Windows.Forms.Label();
            this.labelExportPath.Text = "Путь сохранения:";
            this.labelExportPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelExportPath.Location = new System.Drawing.Point(20, 85);
            this.labelExportPath.AutoSize = true;

            this.textBoxExportPath = new System.Windows.Forms.TextBox();
            this.textBoxExportPath.Location = new System.Drawing.Point(20, 105);
            this.textBoxExportPath.Size = new System.Drawing.Size(350, 25);
            this.textBoxExportPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxExportPath.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\export.csv";

            this.buttonBrowseExport = new System.Windows.Forms.Button();
            this.buttonBrowseExport.Text = "📂 Обзор";
            this.buttonBrowseExport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBrowseExport.Location = new System.Drawing.Point(380, 103);
            this.buttonBrowseExport.Size = new System.Drawing.Size(100, 28);
            this.buttonBrowseExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBrowseExport.Click += new System.EventHandler(this.buttonBrowseExport_Click);

            this.buttonExportCSV = new System.Windows.Forms.Button();
            this.buttonExportCSV.Text = "📄 Экспорт в CSV";
            this.buttonExportCSV.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonExportCSV.ForeColor = System.Drawing.Color.White;
            this.buttonExportCSV.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.buttonExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportCSV.FlatAppearance.BorderSize = 0;
            this.buttonExportCSV.Location = new System.Drawing.Point(20, 145);
            this.buttonExportCSV.Size = new System.Drawing.Size(220, 40);
            this.buttonExportCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExportCSV.Click += new System.EventHandler(this.buttonExportCSV_Click);

            this.buttonExportExcel = new System.Windows.Forms.Button();
            this.buttonExportExcel.Text = "📊 Экспорт в Excel";
            this.buttonExportExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.buttonExportExcel.ForeColor = System.Drawing.Color.White;
            this.buttonExportExcel.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.buttonExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportExcel.FlatAppearance.BorderSize = 0;
            this.buttonExportExcel.Location = new System.Drawing.Point(260, 145);
            this.buttonExportExcel.Size = new System.Drawing.Size(220, 40);
            this.buttonExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExportExcel.Click += new System.EventHandler(this.buttonExportExcel_Click);

            this.groupBoxExport.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.labelExportTable, this.comboBoxExportTable,
                this.labelExportPath, this.textBoxExportPath, this.buttonBrowseExport,
                this.buttonExportCSV, this.buttonExportExcel
            });

            // ===== ГРУППА ИМПОРТ =====
            this.groupBoxImport = new System.Windows.Forms.GroupBox();
            this.groupBoxImport.Text = "📥 Импорт данных";
            this.groupBoxImport.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxImport.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.groupBoxImport.Location = new System.Drawing.Point(15, 230);
            this.groupBoxImport.Size = new System.Drawing.Size(505, 200);

            this.labelImportTable = new System.Windows.Forms.Label();
            this.labelImportTable.Text = "Таблица для импорта:";
            this.labelImportTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelImportTable.Location = new System.Drawing.Point(20, 30);
            this.labelImportTable.AutoSize = true;

            this.comboBoxImportTable = new System.Windows.Forms.ComboBox();
            this.comboBoxImportTable.Location = new System.Drawing.Point(20, 50);
            this.comboBoxImportTable.Size = new System.Drawing.Size(250, 25);
            this.comboBoxImportTable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxImportTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxImportTable.Items.AddRange(new object[] {
                "Клиенты (client)",
                "Дома (house)",
                "Услуги (services)",
                "Скидки (discounts)"
            });
            this.comboBoxImportTable.SelectedIndex = 0;

            this.labelImportPath = new System.Windows.Forms.Label();
            this.labelImportPath.Text = "Файл для импорта (.csv):";
            this.labelImportPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelImportPath.Location = new System.Drawing.Point(20, 85);
            this.labelImportPath.AutoSize = true;

            this.textBoxImportPath = new System.Windows.Forms.TextBox();
            this.textBoxImportPath.Location = new System.Drawing.Point(20, 105);
            this.textBoxImportPath.Size = new System.Drawing.Size(350, 25);
            this.textBoxImportPath.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.buttonBrowseImport = new System.Windows.Forms.Button();
            this.buttonBrowseImport.Text = "📂 Обзор";
            this.buttonBrowseImport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBrowseImport.Location = new System.Drawing.Point(380, 103);
            this.buttonBrowseImport.Size = new System.Drawing.Size(100, 28);
            this.buttonBrowseImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBrowseImport.Click += new System.EventHandler(this.buttonBrowseImport_Click);

            this.buttonImportCSV = new System.Windows.Forms.Button();
            this.buttonImportCSV.Text = "📥 Импортировать";
            this.buttonImportCSV.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonImportCSV.ForeColor = System.Drawing.Color.White;
            this.buttonImportCSV.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.buttonImportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImportCSV.FlatAppearance.BorderSize = 0;
            this.buttonImportCSV.Location = new System.Drawing.Point(20, 145);
            this.buttonImportCSV.Size = new System.Drawing.Size(220, 40);
            this.buttonImportCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonImportCSV.Click += new System.EventHandler(this.buttonImportCSV_Click);

            this.labelImportStatus = new System.Windows.Forms.Label();
            this.labelImportStatus.Text = "";
            this.labelImportStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelImportStatus.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.labelImportStatus.Location = new System.Drawing.Point(260, 150);
            this.labelImportStatus.Size = new System.Drawing.Size(220, 30);

            this.groupBoxImport.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.labelImportTable, this.comboBoxImportTable,
                this.labelImportPath, this.textBoxImportPath, this.buttonBrowseImport,
                this.buttonImportCSV, this.labelImportStatus
            });

            // ===== КНОПКА ЗАКРЫТЬ =====
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonClose.Text = "✕ Закрыть";
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.buttonClose.BackColor = System.Drawing.Color.White;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.buttonClose.Location = new System.Drawing.Point(400, 445);
            this.buttonClose.Size = new System.Drawing.Size(120, 35);
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);

            // Диалоги
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

            // Сборка
            this.panelContent.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.groupBoxExport, this.groupBoxImport, this.buttonClose
            });

            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.ResumeLayout(false);
        }
    }
}