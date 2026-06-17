namespace kursovoy_proekt
{
    partial class BackupForm
    {
        private System.ComponentModel.IContainer components = null;

        // Панели
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelContent;

        // Группа "Ручное резервное копирование"
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.Label labelBackupPath;
        private System.Windows.Forms.TextBox textBoxBackupPath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonCreateBackup;
        private System.Windows.Forms.Label labelBackupNote;

        // Группа "Автоматическое резервное копирование"
        private System.Windows.Forms.GroupBox groupBoxAuto;
        private System.Windows.Forms.Label labelAutoDescription;
        private System.Windows.Forms.Label labelBackupFolder;
        private System.Windows.Forms.TextBox textBoxAutoPath;
        private System.Windows.Forms.Button buttonBrowseAuto;
        private System.Windows.Forms.Button buttonEnableAutoBackup;
        private System.Windows.Forms.Button buttonDisableAutoBackup;
        private System.Windows.Forms.Label labelStatus;

        // Список созданных резервных копий
        private System.Windows.Forms.GroupBox groupBoxHistory;
        private System.Windows.Forms.ListBox listBoxBackups;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.Button buttonDeleteBackup;
        private System.Windows.Forms.Label labelHistoryCount;

        // Кнопка выхода
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Timer timerAutoBackup;

        // Поля
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBoxManual = new System.Windows.Forms.GroupBox();
            this.labelBackupPath = new System.Windows.Forms.Label();
            this.textBoxBackupPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonCreateBackup = new System.Windows.Forms.Button();
            this.labelBackupNote = new System.Windows.Forms.Label();
            this.groupBoxAuto = new System.Windows.Forms.GroupBox();
            this.labelAutoDescription = new System.Windows.Forms.Label();
            this.labelBackupFolder = new System.Windows.Forms.Label();
            this.textBoxAutoPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseAuto = new System.Windows.Forms.Button();
            this.buttonEnableAutoBackup = new System.Windows.Forms.Button();
            this.buttonDisableAutoBackup = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBoxHistory = new System.Windows.Forms.GroupBox();
            this.listBoxBackups = new System.Windows.Forms.ListBox();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.buttonDeleteBackup = new System.Windows.Forms.Button();
            this.labelHistoryCount = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerAutoBackup = new System.Windows.Forms.Timer(this.components);
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.groupBoxManual.SuspendLayout();
            this.groupBoxAuto.SuspendLayout();
            this.groupBoxHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(684, 65);
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
            this.labelHeader.Size = new System.Drawing.Size(684, 65);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "💾 Резервное копирование базы данных";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.groupBoxManual);
            this.panelContent.Controls.Add(this.groupBoxAuto);
            this.panelContent.Controls.Add(this.groupBoxHistory);
            this.panelContent.Controls.Add(this.buttonClose);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 65);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(15);
            this.panelContent.Size = new System.Drawing.Size(684, 546);
            this.panelContent.TabIndex = 0;
            // 
            // groupBoxManual
            // 
            this.groupBoxManual.Controls.Add(this.labelBackupPath);
            this.groupBoxManual.Controls.Add(this.textBoxBackupPath);
            this.groupBoxManual.Controls.Add(this.buttonBrowse);
            this.groupBoxManual.Controls.Add(this.buttonCreateBackup);
            this.groupBoxManual.Controls.Add(this.labelBackupNote);
            this.groupBoxManual.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxManual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxManual.Location = new System.Drawing.Point(15, 15);
            this.groupBoxManual.Name = "groupBoxManual";
            this.groupBoxManual.Size = new System.Drawing.Size(655, 130);
            this.groupBoxManual.TabIndex = 0;
            this.groupBoxManual.TabStop = false;
            this.groupBoxManual.Text = "Ручное резервное копирование";
            // 
            // labelBackupPath
            // 
            this.labelBackupPath.AutoSize = true;
            this.labelBackupPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelBackupPath.Location = new System.Drawing.Point(15, 30);
            this.labelBackupPath.Name = "labelBackupPath";
            this.labelBackupPath.Size = new System.Drawing.Size(103, 15);
            this.labelBackupPath.TabIndex = 0;
            this.labelBackupPath.Text = "Путь сохранения:";
            // 
            // textBoxBackupPath
            // 
            this.textBoxBackupPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxBackupPath.Location = new System.Drawing.Point(15, 50);
            this.textBoxBackupPath.Name = "textBoxBackupPath";
            this.textBoxBackupPath.Size = new System.Drawing.Size(500, 23);
            this.textBoxBackupPath.TabIndex = 1;
            this.textBoxBackupPath.Text = "C:\\Users\\Разработка\\Desktop\\backup_hotel.sql";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonBrowse.Location = new System.Drawing.Point(525, 48);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(110, 28);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "📂 Обзор...";
            // 
            // buttonCreateBackup
            // 
            this.buttonCreateBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.buttonCreateBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateBackup.FlatAppearance.BorderSize = 0;
            this.buttonCreateBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonCreateBackup.ForeColor = System.Drawing.Color.White;
            this.buttonCreateBackup.Location = new System.Drawing.Point(15, 85);
            this.buttonCreateBackup.Name = "buttonCreateBackup";
            this.buttonCreateBackup.Size = new System.Drawing.Size(223, 35);
            this.buttonCreateBackup.TabIndex = 3;
            this.buttonCreateBackup.Text = "💾 Создать резервную копию";
            this.buttonCreateBackup.UseVisualStyleBackColor = false;
            // 
            // labelBackupNote
            // 
            this.labelBackupNote.AutoSize = true;
            this.labelBackupNote.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.labelBackupNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.labelBackupNote.Location = new System.Drawing.Point(282, 97);
            this.labelBackupNote.Name = "labelBackupNote";
            this.labelBackupNote.Size = new System.Drawing.Size(369, 13);
            this.labelBackupNote.TabIndex = 4;
            this.labelBackupNote.Text = "При создании копии сохраняется вся структура и данные базы данных";
            // 
            // groupBoxAuto
            // 
            this.groupBoxAuto.Controls.Add(this.labelAutoDescription);
            this.groupBoxAuto.Controls.Add(this.labelBackupFolder);
            this.groupBoxAuto.Controls.Add(this.textBoxAutoPath);
            this.groupBoxAuto.Controls.Add(this.buttonBrowseAuto);
            this.groupBoxAuto.Controls.Add(this.buttonEnableAutoBackup);
            this.groupBoxAuto.Controls.Add(this.buttonDisableAutoBackup);
            this.groupBoxAuto.Controls.Add(this.labelStatus);
            this.groupBoxAuto.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxAuto.Location = new System.Drawing.Point(15, 160);
            this.groupBoxAuto.Name = "groupBoxAuto";
            this.groupBoxAuto.Size = new System.Drawing.Size(655, 130);
            this.groupBoxAuto.TabIndex = 1;
            this.groupBoxAuto.TabStop = false;
            this.groupBoxAuto.Text = "Автоматическое резервное копирование";
            // 
            // labelAutoDescription
            // 
            this.labelAutoDescription.AutoSize = true;
            this.labelAutoDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelAutoDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.labelAutoDescription.Location = new System.Drawing.Point(15, 25);
            this.labelAutoDescription.Name = "labelAutoDescription";
            this.labelAutoDescription.Size = new System.Drawing.Size(450, 15);
            this.labelAutoDescription.TabIndex = 0;
            this.labelAutoDescription.Text = "Автоматическое копирование выполняется раз в сутки при запуске программы";
            // 
            // labelBackupFolder
            // 
            this.labelBackupFolder.AutoSize = true;
            this.labelBackupFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelBackupFolder.Location = new System.Drawing.Point(15, 50);
            this.labelBackupFolder.Name = "labelBackupFolder";
            this.labelBackupFolder.Size = new System.Drawing.Size(132, 15);
            this.labelBackupFolder.TabIndex = 1;
            this.labelBackupFolder.Text = "Папка для авто-копий:";
            // 
            // textBoxAutoPath
            // 
            this.textBoxAutoPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxAutoPath.Location = new System.Drawing.Point(15, 70);
            this.textBoxAutoPath.Name = "textBoxAutoPath";
            this.textBoxAutoPath.Size = new System.Drawing.Size(500, 23);
            this.textBoxAutoPath.TabIndex = 2;
            this.textBoxAutoPath.Text = "C:\\Users\\Разработка\\Documents\\HotelBackups";
            // 
            // buttonBrowseAuto
            // 
            this.buttonBrowseAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseAuto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonBrowseAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonBrowseAuto.Location = new System.Drawing.Point(525, 71);
            this.buttonBrowseAuto.Name = "buttonBrowseAuto";
            this.buttonBrowseAuto.Size = new System.Drawing.Size(115, 28);
            this.buttonBrowseAuto.TabIndex = 3;
            this.buttonBrowseAuto.Text = "📂 Обзор...";
            // 
            // buttonEnableAutoBackup
            // 
            this.buttonEnableAutoBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonEnableAutoBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEnableAutoBackup.FlatAppearance.BorderSize = 0;
            this.buttonEnableAutoBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEnableAutoBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.buttonEnableAutoBackup.ForeColor = System.Drawing.Color.White;
            this.buttonEnableAutoBackup.Location = new System.Drawing.Point(15, 95);
            this.buttonEnableAutoBackup.Name = "buttonEnableAutoBackup";
            this.buttonEnableAutoBackup.Size = new System.Drawing.Size(200, 28);
            this.buttonEnableAutoBackup.TabIndex = 4;
            this.buttonEnableAutoBackup.Text = "▶ Включить автокопирование";
            this.buttonEnableAutoBackup.UseVisualStyleBackColor = false;
            // 
            // buttonDisableAutoBackup
            // 
            this.buttonDisableAutoBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonDisableAutoBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDisableAutoBackup.FlatAppearance.BorderSize = 0;
            this.buttonDisableAutoBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisableAutoBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.buttonDisableAutoBackup.ForeColor = System.Drawing.Color.White;
            this.buttonDisableAutoBackup.Location = new System.Drawing.Point(225, 95);
            this.buttonDisableAutoBackup.Name = "buttonDisableAutoBackup";
            this.buttonDisableAutoBackup.Size = new System.Drawing.Size(120, 28);
            this.buttonDisableAutoBackup.TabIndex = 5;
            this.buttonDisableAutoBackup.Text = "⏹ Остановить";
            this.buttonDisableAutoBackup.UseVisualStyleBackColor = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.labelStatus.Location = new System.Drawing.Point(351, 102);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(186, 15);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "⏹ Автокопирование отключено";
            // 
            // groupBoxHistory
            // 
            this.groupBoxHistory.Controls.Add(this.listBoxBackups);
            this.groupBoxHistory.Controls.Add(this.buttonRestore);
            this.groupBoxHistory.Controls.Add(this.buttonDeleteBackup);
            this.groupBoxHistory.Controls.Add(this.labelHistoryCount);
            this.groupBoxHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBoxHistory.Location = new System.Drawing.Point(15, 305);
            this.groupBoxHistory.Name = "groupBoxHistory";
            this.groupBoxHistory.Size = new System.Drawing.Size(655, 230);
            this.groupBoxHistory.TabIndex = 2;
            this.groupBoxHistory.TabStop = false;
            this.groupBoxHistory.Text = "Архив резервных копий";
            // 
            // listBoxBackups
            // 
            this.listBoxBackups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxBackups.Font = new System.Drawing.Font("Consolas", 9F);
            this.listBoxBackups.ItemHeight = 14;
            this.listBoxBackups.Location = new System.Drawing.Point(15, 25);
            this.listBoxBackups.Name = "listBoxBackups";
            this.listBoxBackups.Size = new System.Drawing.Size(500, 156);
            this.listBoxBackups.TabIndex = 0;
            // 
            // buttonRestore
            // 
            this.buttonRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRestore.FlatAppearance.BorderSize = 0;
            this.buttonRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestore.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.buttonRestore.ForeColor = System.Drawing.Color.White;
            this.buttonRestore.Location = new System.Drawing.Point(525, 30);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(115, 32);
            this.buttonRestore.TabIndex = 1;
            this.buttonRestore.Text = "📥 Восстановить";
            this.buttonRestore.UseVisualStyleBackColor = false;
            // 
            // buttonDeleteBackup
            // 
            this.buttonDeleteBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.buttonDeleteBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteBackup.FlatAppearance.BorderSize = 0;
            this.buttonDeleteBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.buttonDeleteBackup.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteBackup.Location = new System.Drawing.Point(525, 70);
            this.buttonDeleteBackup.Name = "buttonDeleteBackup";
            this.buttonDeleteBackup.Size = new System.Drawing.Size(115, 32);
            this.buttonDeleteBackup.TabIndex = 2;
            this.buttonDeleteBackup.Text = "🗑 Удалить";
            this.buttonDeleteBackup.UseVisualStyleBackColor = false;
            // 
            // labelHistoryCount
            // 
            this.labelHistoryCount.AutoSize = true;
            this.labelHistoryCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelHistoryCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.labelHistoryCount.Location = new System.Drawing.Point(15, 190);
            this.labelHistoryCount.Name = "labelHistoryCount";
            this.labelHistoryCount.Size = new System.Drawing.Size(103, 15);
            this.labelHistoryCount.TabIndex = 3;
            this.labelHistoryCount.Text = "Копий в архиве: 0";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.White;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonClose.Location = new System.Drawing.Point(550, 545);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 35);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "✕ Закрыть";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // BackupForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(684, 611);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BackupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Резервное копирование базы данных";
            this.panelHeader.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.groupBoxManual.ResumeLayout(false);
            this.groupBoxManual.PerformLayout();
            this.groupBoxAuto.ResumeLayout(false);
            this.groupBoxAuto.PerformLayout();
            this.groupBoxHistory.ResumeLayout(false);
            this.groupBoxHistory.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}