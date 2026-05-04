using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public partial class BackupForm : Form
    {
        private bool isAutoBackupEnabled = false;
        private string backupFolder = "";

        public BackupForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            buttonBrowse.Click += ButtonBrowse_Click;
            buttonCreateBackup.Click += ButtonCreateBackup_Click;
            buttonBrowseAuto.Click += ButtonBrowseAuto_Click;
            buttonEnableAutoBackup.Click += ButtonEnableAutoBackup_Click;
            buttonDisableAutoBackup.Click += ButtonDisableAutoBackup_Click;
            buttonRestore.Click += ButtonRestore_Click;
            buttonDeleteBackup.Click += ButtonDeleteBackup_Click;

            timerAutoBackup.Interval = 86400000; // 24 часа
            timerAutoBackup.Tick += TimerAutoBackup_Tick;

            // Убираем разделение на ручной и авто путь - используем ОДНУ папку
            // Синхронизируем textBoxBackupPath и textBoxAutoPath
            textBoxBackupPath.TextChanged += (s, e) =>
            {
                if (textBoxAutoPath.Text != textBoxBackupPath.Text)
                    textBoxAutoPath.Text = textBoxBackupPath.Text;
            };

            textBoxAutoPath.TextChanged += (s, e) =>
            {
                if (textBoxBackupPath.Text != textBoxAutoPath.Text)
                    textBoxBackupPath.Text = textBoxAutoPath.Text;
            };

            LoadSettings();
            RefreshBackupList();
        }

        // ==========================================
        // ВЫБОР ПАПКИ (ЕДИНАЯ ДЛЯ РУЧНОГО И АВТО)
        // ==========================================
        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = string.IsNullOrEmpty(backupFolder)
                ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                : backupFolder;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                backupFolder = folderBrowserDialog1.SelectedPath;
                textBoxBackupPath.Text = backupFolder;
                textBoxAutoPath.Text = backupFolder;
                SaveSettings();
                RefreshBackupList();
            }
        }

        private void ButtonBrowseAuto_Click(object sender, EventArgs e)
        {
            // Используем ту же папку
            ButtonBrowse_Click(sender, e);
        }

        // ==========================================
        // РУЧНОЕ КОПИРОВАНИЕ
        // ==========================================
        private void ButtonCreateBackup_Click(object sender, EventArgs e)
        {
            string folder = textBoxBackupPath.Text.Trim();

            if (string.IsNullOrEmpty(folder))
            {
                MessageBox.Show("Сначала выберите папку для резервных копий.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(folder))
            {
                try { Directory.CreateDirectory(folder); }
                catch
                {
                    MessageBox.Show("Не удалось создать папку.", "Ошибка");
                    return;
                }
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                string backupFile = Path.Combine(folder, $"backup_hotel_{DateTime.Now:yyyyMMdd_HHmmss}.sql");

                bool success = CreateDatabaseDump(backupFile);

                if (!success || new FileInfo(backupFile).Length == 0)
                {
                    CreateTextBackup(backupFile);
                }

                // Сохраняем выбранную папку
                backupFolder = folder;
                SaveSettings();
                RefreshBackupList();

                Cursor = Cursors.Default;

                FileInfo fi = new FileInfo(backupFile);
                MessageBox.Show($"Резервная копия создана!\n{backupFile}\nРазмер: {fi.Length / 1024} КБ", "Успех");
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Ошибка при создании: {ex.Message}", "Ошибка");
            }
        }

        private bool CreateDatabaseDump(string filePath)
        {
            try
            {
                string mysqldumpPath = FindMySqlDump();
                if (string.IsNullOrEmpty(mysqldumpPath)) return false;

                string connStr = DatabaseConnection.GetConnectionString();
                var builder = new MySqlConnectionStringBuilder(connStr);

                Process process = new Process();
                process.StartInfo.FileName = mysqldumpPath;
                process.StartInfo.Arguments = $"-u {builder.UserID} -p{builder.Password} -h {builder.Server} -P {builder.Port} --databases {builder.Database} --add-drop-database --add-drop-table --result-file=\"{filePath}\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();

                return process.ExitCode == 0 && File.Exists(filePath) && new FileInfo(filePath).Length > 0;
            }
            catch
            {
                return false;
            }
        }

        private string FindMySqlDump()
        {
            string[] paths = {
                @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
                @"C:\Program Files\MySQL\MySQL Server 5.7\bin\mysqldump.exe",
                @"C:\Program Files (x86)\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
                @"C:\xampp\mysql\bin\mysqldump.exe",
                @"C:\OpenServer\modules\database\MySQL-8.0\bin\mysqldump.exe"
            };
            return paths.FirstOrDefault(File.Exists);
        }

        private void CreateTextBackup(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine("-- ═══════════════════════════════════════════");
                writer.WriteLine($"-- РЕЗЕРВНАЯ КОПИЯ БД: hotel_management");
                writer.WriteLine($"-- Дата: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                writer.WriteLine("-- ═══════════════════════════════════════════");
                writer.WriteLine();

                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string[] tables = { "client", "house", "home_class", "booking", "check_in",
                                       "check_in_services", "services", "users", "personal",
                                       "positions", "role", "discounts", "notifications" };

                    foreach (string table in tables)
                    {
                        try
                        {
                            writer.WriteLine($"-- ТАБЛИЦА: {table}");
                            string query = $"SELECT * FROM {table}";
                            using (var cmd = new MySqlCommand(query, connection))
                            using (var reader = cmd.ExecuteReader())
                            {
                                int fieldCount = reader.FieldCount;
                                while (reader.Read())
                                {
                                    writer.Write($"INSERT INTO {table} VALUES (");
                                    for (int i = 0; i < fieldCount; i++)
                                    {
                                        if (reader.IsDBNull(i))
                                            writer.Write("NULL");
                                        else
                                            writer.Write($"'{reader[i].ToString().Replace("\\", "\\\\").Replace("'", "\\'")}'");
                                        if (i < fieldCount - 1) writer.Write(", ");
                                    }
                                    writer.WriteLine(");");
                                }
                            }
                            writer.WriteLine();
                        }
                        catch { }
                    }
                }
            }
        }

        // ==========================================
        // АВТОМАТИЧЕСКОЕ КОПИРОВАНИЕ
        // ==========================================
        private void ButtonEnableAutoBackup_Click(object sender, EventArgs e)
        {
            string folder = textBoxAutoPath.Text.Trim();

            if (string.IsNullOrEmpty(folder))
            {
                MessageBox.Show("Сначала выберите папку для копий.", "Внимание");
                return;
            }

            if (!Directory.Exists(folder))
            {
                try { Directory.CreateDirectory(folder); }
                catch { MessageBox.Show("Не удалось создать папку.", "Ошибка"); return; }
            }

            isAutoBackupEnabled = true;
            backupFolder = folder;
            timerAutoBackup.Start();
            SaveSettings();

            labelStatus.Text = "▶ Автокопирование включено";
            labelStatus.ForeColor = Color.FromArgb(46, 139, 87);
            buttonEnableAutoBackup.Enabled = false;
            buttonDisableAutoBackup.Enabled = true;

            CreateAutoBackup();
            MessageBox.Show($"Автокопирование включено.\nПапка: {folder}", "Включено");
        }

        private void ButtonDisableAutoBackup_Click(object sender, EventArgs e)
        {
            isAutoBackupEnabled = false;
            timerAutoBackup.Stop();
            SaveSettings();

            labelStatus.Text = "⏹ Автокопирование отключено";
            labelStatus.ForeColor = Color.FromArgb(200, 80, 80);
            buttonEnableAutoBackup.Enabled = true;
            buttonDisableAutoBackup.Enabled = false;
        }

        private void TimerAutoBackup_Tick(object sender, EventArgs e) => CreateAutoBackup();

        private void CreateAutoBackup()
        {
            if (!isAutoBackupEnabled || string.IsNullOrEmpty(backupFolder)) return;

            try
            {
                if (!Directory.Exists(backupFolder)) Directory.CreateDirectory(backupFolder);

                string file = Path.Combine(backupFolder, $"auto_backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql");

                bool success = CreateDatabaseDump(file);
                if (!success) CreateTextBackup(file);

                CleanOldBackups(backupFolder, 7);

                this.Invoke((MethodInvoker)delegate { RefreshBackupList(); });
            }
            catch { }
        }

        private void CleanOldBackups(string folder, int keepCount)
        {
            try
            {
                var files = Directory.GetFiles(folder, "auto_backup_*.sql").OrderByDescending(f => f).ToList();
                for (int i = keepCount; i < files.Count; i++)
                {
                    try { File.Delete(files[i]); } catch { }
                }
            }
            catch { }
        }

        // ==========================================
        // ОТОБРАЖЕНИЕ БЕКАПОВ (ТОЛЬКО ВЫБРАННАЯ ПАПКА)
        // ==========================================
        private void RefreshBackupList()
        {
            listBoxBackups.Items.Clear();

            string folder = textBoxBackupPath.Text.Trim();
            if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder))
            {
                labelHistoryCount.Text = "Папка не выбрана";
                return;
            }

            try
            {
                var files = Directory.GetFiles(folder, "*.sql")
                    .Select(f => new FileInfo(f))
                    .Where(f => f.Name.Contains("backup") || f.Name.Contains("hotel"))
                    .OrderByDescending(f => f.CreationTime)
                    .ToList();

                foreach (var fi in files)
                {
                    string sizeStr = fi.Length < 1024 ? $"{fi.Length} Б" :
                                    fi.Length < 1024 * 1024 ? $"{fi.Length / 1024} КБ" :
                                    $"{fi.Length / (1024 * 1024):F1} МБ";

                    listBoxBackups.Items.Add(new BackupItem
                    {
                        FilePath = fi.FullName,
                        FileName = fi.Name,
                        Size = fi.Length,
                        Date = fi.CreationTime,
                        SizeText = sizeStr
                    });
                }

                labelHistoryCount.Text = $"Копий: {listBoxBackups.Items.Count}";
            }
            catch (Exception ex)
            {
                labelHistoryCount.Text = $"Ошибка: {ex.Message}";
            }
        }

        // ==========================================
        // ВОССТАНОВЛЕНИЕ И УДАЛЕНИЕ
        // ==========================================
        private void ButtonRestore_Click(object sender, EventArgs e)
        {
            if (!(listBoxBackups.SelectedItem is BackupItem item))
            {
                MessageBox.Show("Выберите файл из списка.", "Внимание");
                return;
            }

            if (MessageBox.Show($"Восстановить базу из:\n{item.FileName}?\n\n⚠ Текущие данные будут заменены!",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                string mysqlPath = FindMySqlPath();
                if (!string.IsNullOrEmpty(mysqlPath))
                {
                    string connStr = DatabaseConnection.GetConnectionString();
                    var builder = new MySqlConnectionStringBuilder(connStr);

                    Process process = new Process();
                    process.StartInfo.FileName = mysqlPath;
                    process.StartInfo.Arguments = $"-u {builder.UserID} -p{builder.Password} -h {builder.Server} -P {builder.Port} {builder.Database}";
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.StandardInput.Write(File.ReadAllText(item.FilePath, System.Text.Encoding.UTF8));
                    process.StandardInput.Close();
                    process.WaitForExit();
                }
                else
                {
                    string sql = File.ReadAllText(item.FilePath, System.Text.Encoding.UTF8);
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();
                        using (var cmd = new MySqlCommand(sql, connection))
                            cmd.ExecuteNonQuery();
                    }
                }

                Cursor = Cursors.Default;
                MessageBox.Show("База данных восстановлена!", "Успех");
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private string FindMySqlPath()
        {
            string[] paths = {
                @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe",
                @"C:\Program Files\MySQL\MySQL Server 5.7\bin\mysql.exe",
                @"C:\Program Files (x86)\MySQL\MySQL Server 8.0\bin\mysql.exe",
                @"C:\xampp\mysql\bin\mysql.exe",
                @"C:\OpenServer\modules\database\MySQL-8.0\bin\mysql.exe"
            };
            return paths.FirstOrDefault(File.Exists);
        }

        private void ButtonDeleteBackup_Click(object sender, EventArgs e)
        {
            if (!(listBoxBackups.SelectedItem is BackupItem item))
            {
                MessageBox.Show("Выберите файл из списка.", "Внимание");
                return;
            }

            if (MessageBox.Show($"Удалить файл:\n{item.FileName}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    File.Delete(item.FilePath);
                    RefreshBackupList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
                }
            }
        }

        // ==========================================
        // НАСТРОЙКИ
        // ==========================================
        private void SaveSettings()
        {
            string settingsFile = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "HotelManagement", "backup_settings.ini");

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(settingsFile));
                using (StreamWriter writer = new StreamWriter(settingsFile))
                {
                    writer.WriteLine("[Backup]");
                    writer.WriteLine($"BackupFolder={backupFolder}");
                    writer.WriteLine($"AutoBackupEnabled={isAutoBackupEnabled}");
                }
            }
            catch { }
        }

        private void LoadSettings()
        {
            string settingsFile = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "HotelManagement", "backup_settings.ini");

            try
            {
                if (File.Exists(settingsFile))
                {
                    foreach (string line in File.ReadAllLines(settingsFile))
                    {
                        if (line.StartsWith("BackupFolder="))
                        {
                            backupFolder = line.Substring(line.IndexOf('=') + 1).Trim();
                            textBoxBackupPath.Text = backupFolder;
                            textBoxAutoPath.Text = backupFolder;
                        }
                        if (line.StartsWith("AutoBackupEnabled="))
                        {
                            isAutoBackupEnabled = line.Split('=')[1].Trim() == "True";
                            if (isAutoBackupEnabled)
                            {
                                timerAutoBackup.Start();
                                labelStatus.Text = "▶ Автокопирование включено";
                                labelStatus.ForeColor = Color.FromArgb(46, 139, 87);
                                buttonEnableAutoBackup.Enabled = false;
                                buttonDisableAutoBackup.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void buttonClose_Click(object sender, EventArgs e) => Close();

        private class BackupItem
        {
            public string FilePath { get; set; }
            public string FileName { get; set; }
            public long Size { get; set; }
            public DateTime Date { get; set; }
            public string SizeText { get; set; }
            public override string ToString() => $"{Date:dd.MM.yyyy HH:mm} | {SizeText,8} | {FileName}";
        }
    }
}