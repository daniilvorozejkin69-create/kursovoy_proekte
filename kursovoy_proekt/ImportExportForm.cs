using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public partial class ImportExportForm : Form
    {
        public ImportExportForm()
        {
            InitializeComponent();
        }

        // ==========================================
        // ЭКСПОРТ
        // ==========================================
        private void buttonBrowseExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
            saveFileDialog1.FileName = $"export_{GetTableName(comboBoxExportTable.SelectedIndex)}_{DateTime.Now:yyyyMMdd}.csv";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxExportPath.Text = saveFileDialog1.FileName;
            }
        }

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxExportPath.Text))
            {
                MessageBox.Show("Укажите путь для сохранения.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                ExportToCSV(textBoxExportPath.Text);
                Cursor = Cursors.Default;

                MessageBox.Show($"Данные успешно экспортированы в CSV!\n{textBoxExportPath.Text}", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (File.Exists(textBoxExportPath.Text))
                    System.Diagnostics.Process.Start(textBoxExportPath.Text);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Ошибка экспорта:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxExportPath.Text))
            {
                MessageBox.Show("Укажите путь для сохранения.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                string excelPath = Path.ChangeExtension(textBoxExportPath.Text, ".xls");
                ExportToExcel(excelPath);

                Cursor = Cursors.Default;
                MessageBox.Show($"Данные успешно экспортированы в Excel!\n{excelPath}", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (File.Exists(excelPath))
                    System.Diagnostics.Process.Start(excelPath);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Ошибка экспорта в Excel:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV(string filePath)
        {
            string tableName = GetTableName(comboBoxExportTable.SelectedIndex);
            string query = $"SELECT * FROM {tableName}";

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        // Запись заголовков
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            writer.Write($"\"{reader.GetName(i)}\"");
                            if (i < reader.FieldCount - 1) writer.Write(";");
                        }
                        writer.WriteLine();

                        // Запись данных
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string val = reader.IsDBNull(i) ? "" : reader[i].ToString().Replace("\"", "\"\"");
                                writer.Write($"\"{val}\"");
                                if (i < reader.FieldCount - 1) writer.Write(";");
                            }
                            writer.WriteLine();
                        }
                    }
                }
            }
        }

        private void ExportToExcel(string filePath)
        {
            string tableName = GetTableName(comboBoxExportTable.SelectedIndex);
            string query = $"SELECT * FROM {tableName}";

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new MySqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        // Заголовок Excel XML
                        writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                        writer.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
                        writer.WriteLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                        writer.WriteLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
                        writer.WriteLine("<Worksheet ss:Name=\"Export\"><Table>");

                        // Заголовки колонок
                        writer.WriteLine("<Row>");
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            writer.WriteLine($"<Cell><Data ss:Type=\"String\">{reader.GetName(i)}</Data></Cell>");
                        }
                        writer.WriteLine("</Row>");

                        // Данные
                        while (reader.Read())
                        {
                            writer.WriteLine("<Row>");
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string val = reader.IsDBNull(i) ? "" : reader[i].ToString()
                                    .Replace("&", "&amp;")
                                    .Replace("<", "&lt;")
                                    .Replace(">", "&gt;")
                                    .Replace("\"", "&quot;");
                                writer.WriteLine($"<Cell><Data ss:Type=\"String\">{val}</Data></Cell>");
                            }
                            writer.WriteLine("</Row>");
                        }

                        writer.WriteLine("</Table></Worksheet></Workbook>");
                    }
                }
            }
        }

        // ==========================================
        // ИМПОРТ
        // ==========================================
        private void buttonBrowseImport_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxImportPath.Text = openFileDialog1.FileName;
            }
        }

        private void buttonImportCSV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxImportPath.Text))
            {
                MessageBox.Show("Выберите файл для импорта.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(textBoxImportPath.Text))
            {
                MessageBox.Show("Файл не найден.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tableName = GetTableName(comboBoxImportTable.SelectedIndex);

            var result = MessageBox.Show(
                $"Импортировать данные в таблицу «{tableName}»?\n\n" +
                "ВНИМАНИЕ! Все существующие данные в этой таблице будут удалены перед импортом!",
                "Подтверждение импорта",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                labelImportStatus.Text = "Импорт...";
                labelImportStatus.ForeColor = Color.FromArgb(100, 100, 100);
                Application.DoEvents();

                int count = ImportFromCSV(textBoxImportPath.Text);

                Cursor = Cursors.Default;
                labelImportStatus.Text = $"✅ Импортировано: {count} записей";
                labelImportStatus.ForeColor = Color.FromArgb(46, 139, 87);

                MessageBox.Show($"Успешно импортировано {count} записей в таблицу «{tableName}»!", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                labelImportStatus.Text = "❌ Ошибка импорта";
                labelImportStatus.ForeColor = Color.FromArgb(220, 80, 80);
                MessageBox.Show($"Ошибка импорта:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ImportFromCSV(string filePath)
        {
            string tableName = GetTableName(comboBoxImportTable.SelectedIndex);
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            int count = 0;

            if (lines.Length < 2)
                throw new Exception("Файл пуст или содержит только заголовки.");

            string[] headers = ParseCSVLine(lines[0]);
            for (int i = 0; i < headers.Length; i++)
                headers[i] = headers[i].Trim().Trim('"').Trim();

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Отключаем проверку внешних ключей
                        using (var cmdFK = new MySqlCommand("SET FOREIGN_KEY_CHECKS = 0", connection, transaction))
                        {
                            cmdFK.ExecuteNonQuery();
                        }

                        // Очищаем таблицу
                        using (var cmdDelete = new MySqlCommand($"DELETE FROM {tableName}", connection, transaction))
                        {
                            cmdDelete.ExecuteNonQuery();
                        }

                        // Сбрасываем AUTO_INCREMENT
                        try
                        {
                            using (var cmdReset = new MySqlCommand($"ALTER TABLE {tableName} AUTO_INCREMENT = 1", connection, transaction))
                            {
                                cmdReset.ExecuteNonQuery();
                            }
                        }
                        catch { }

                        // Получаем список колонок и их типы из БД
                        Dictionary<string, string> tableColumns = new Dictionary<string, string>();
                        using (var cmdCols = new MySqlCommand($"SHOW COLUMNS FROM {tableName}", connection, transaction))
                        using (var reader = cmdCols.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string colName = reader.GetString(0).ToLower();
                                string colType = reader.GetString(1).ToLower();
                                tableColumns[colName] = colType;
                            }
                        }

                        // Импортируем данные
                        for (int i = 1; i < lines.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(lines[i])) continue;

                            string[] values = ParseCSVLine(lines[i]);
                            if (values.Length == 0) continue;

                            List<string> validColumns = new List<string>();
                            List<object> validValues = new List<object>();

                            for (int j = 0; j < headers.Length && j < values.Length; j++)
                            {
                                string colName = headers[j].ToLower().Trim();
                                if (tableColumns.ContainsKey(colName))
                                {
                                    string rawValue = values[j].Trim();
                                    object convertedValue = ConvertValue(rawValue, tableColumns[colName]);

                                    validColumns.Add(colName);
                                    validValues.Add(convertedValue);
                                }
                            }

                            if (validColumns.Count == 0) continue;

                            StringBuilder sql = new StringBuilder();
                            sql.Append($"INSERT INTO {tableName} (");
                            sql.Append(string.Join(", ", validColumns));
                            sql.Append(") VALUES (");

                            List<string> paramNames = new List<string>();
                            for (int j = 0; j < validValues.Count; j++)
                                paramNames.Add($"@p{j}");
                            sql.Append(string.Join(", ", paramNames));
                            sql.Append(")");

                            using (var cmd = new MySqlCommand(sql.ToString(), connection, transaction))
                            {
                                for (int j = 0; j < validValues.Count; j++)
                                {
                                    object val = validValues[j] ?? DBNull.Value;
                                    cmd.Parameters.AddWithValue($"@p{j}", val);
                                }
                                cmd.ExecuteNonQuery();
                                count++;
                            }
                        }

                        // Включаем проверку внешних ключей обратно
                        using (var cmdFK = new MySqlCommand("SET FOREIGN_KEY_CHECKS = 1", connection, transaction))
                        {
                            cmdFK.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        try
                        {
                            using (var cmdFK = new MySqlCommand("SET FOREIGN_KEY_CHECKS = 1", connection))
                            {
                                cmdFK.ExecuteNonQuery();
                            }
                        }
                        catch { }

                        throw new Exception($"Ошибка при импорте (строка {count + 2}): {ex.Message}", ex);
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Конвертирует строковое значение в нужный тип в зависимости от типа колонки MySQL
        /// </summary>
        private object ConvertValue(string rawValue, string columnType)
        {
            if (string.IsNullOrEmpty(rawValue) || rawValue == "NULL" || rawValue == "null")
                return DBNull.Value;

            // Дата и время
            if (columnType.Contains("date") || columnType.Contains("timestamp"))
            {
                // Пробуем разные форматы дат
                string[] formats = {
            "dd.MM.yyyy H:mm:ss",
            "dd.MM.yyyy HH:mm:ss",
            "dd.MM.yyyy",
            "yyyy-MM-dd HH:mm:ss",
            "yyyy-MM-dd",
            "dd/MM/yyyy",
            "MM/dd/yyyy",
            "dd.MM.yyyy H:mm",
            "yyyy-MM-dd H:mm:ss"
        };

                foreach (string format in formats)
                {
                    if (DateTime.TryParseExact(rawValue, format, null, System.Globalization.DateTimeStyles.None, out DateTime date))
                    {
                        if (columnType.Contains("timestamp") || columnType.Contains("datetime"))
                            return date.ToString("yyyy-MM-dd HH:mm:ss");
                        else
                            return date.ToString("yyyy-MM-dd");
                    }
                }

                // Если не подошёл ни один формат - пробуем стандартный парсинг
                if (DateTime.TryParse(rawValue, out DateTime dt))
                    return dt.ToString("yyyy-MM-dd HH:mm:ss");

                // Если совсем не парсится - возвращаем NULL
                return DBNull.Value;
            }

            // Десятичные числа (decimal)
            if (columnType.Contains("decimal") || columnType.Contains("float") || columnType.Contains("double"))
            {
                rawValue = rawValue.Replace(",", ".").Replace(" ", "").Replace("₽", "").Replace("руб", "").Trim();
                if (decimal.TryParse(rawValue, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal dec))
                    return dec;
                return DBNull.Value;
            }

            // Целые числа
            if (columnType.Contains("int") || columnType.Contains("tinyint") || columnType.Contains("smallint") || columnType.Contains("bigint"))
            {
                if (int.TryParse(rawValue, out int intVal))
                    return intVal;
                return DBNull.Value;
            }

            // Строки
            return rawValue;
        }

        /// <summary>
        /// Парсинг строки CSV с поддержкой кавычек
        /// </summary>
        private string[] ParseCSVLine(string line)
        {
            var result = new List<string>();
            bool inQuotes = false;
            StringBuilder current = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        // Экранированная кавычка
                        current.Append('"');
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ';' && !inQuotes)
                {
                    result.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(c);
                }
            }
            result.Add(current.ToString());

            return result.ToArray();
        }

        // ==========================================
        // ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ
        // ==========================================
        private string GetTableName(int index)
        {
            string[] tables = { "client", "house", "booking", "check_in", "services", "personal", "discounts" };
            if (index >= 0 && index < tables.Length)
                return tables[index];
            return "client";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}