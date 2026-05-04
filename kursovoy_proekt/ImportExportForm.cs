using System;
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
                MessageBox.Show("Укажите путь для сохранения.", "Внимание");
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                ExportToCSV(textBoxExportPath.Text);
                Cursor = Cursors.Default;

                MessageBox.Show($"Данные экспортированы в CSV!\n{textBoxExportPath.Text}", "Успех");

                if (File.Exists(textBoxExportPath.Text))
                    System.Diagnostics.Process.Start(textBoxExportPath.Text);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка");
            }
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxExportPath.Text))
            {
                MessageBox.Show("Укажите путь для сохранения.", "Внимание");
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                string excelPath = Path.ChangeExtension(textBoxExportPath.Text, ".xls");
                ExportToExcel(excelPath);

                Cursor = Cursors.Default;
                MessageBox.Show($"Данные экспортированы в Excel!\n{excelPath}", "Успех");

                if (File.Exists(excelPath))
                    System.Diagnostics.Process.Start(excelPath);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Ошибка экспорта в Excel: {ex.Message}", "Ошибка");
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
                        // Заголовки
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            writer.Write($"\"{reader.GetName(i)}\"");
                            if (i < reader.FieldCount - 1) writer.Write(";");
                        }
                        writer.WriteLine();

                        // Данные
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
                        writer.WriteLine("<?xml version=\"1.0\"?>");
                        writer.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
                        writer.WriteLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                        writer.WriteLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
                        writer.WriteLine("<Worksheet ss:Name=\"Export\"><Table>");

                        // Заголовки
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
                                    .Replace(">", "&gt;");
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
                MessageBox.Show("Выберите файл для импорта.", "Внимание");
                return;
            }

            if (!File.Exists(textBoxImportPath.Text))
            {
                MessageBox.Show("Файл не найден.", "Ошибка");
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                int count = ImportFromCSV(textBoxImportPath.Text);
                Cursor = Cursors.Default;

                labelImportStatus.Text = $"✅ Импортировано: {count} записей";
                labelImportStatus.ForeColor = Color.FromArgb(46, 139, 87);

                MessageBox.Show($"Успешно импортировано {count} записей!", "Успех");
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                labelImportStatus.Text = "❌ Ошибка импорта";
                labelImportStatus.ForeColor = Color.FromArgb(220, 80, 80);
                MessageBox.Show($"Ошибка импорта: {ex.Message}", "Ошибка");
            }
        }

        private int ImportFromCSV(string filePath)
        {
            string tableName = GetTableName(comboBoxImportTable.SelectedIndex);
            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            int count = 0;

            if (lines.Length < 2) return 0;

            // Первая строка - заголовки
            string[] headers = lines[0].Split(';');
            for (int i = 0; i < headers.Length; i++)
                headers[i] = headers[i].Trim().Trim('"');

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        for (int i = 1; i < lines.Length; i++)
                        {
                            if (string.IsNullOrWhiteSpace(lines[i])) continue;

                            string[] values = ParseCSVLine(lines[i]);

                            // Строим INSERT запрос
                            StringBuilder sql = new StringBuilder();
                            sql.Append($"INSERT INTO {tableName} (");
                            sql.Append(string.Join(", ", headers));
                            sql.Append(") VALUES (");

                            for (int j = 0; j < values.Length; j++)
                            {
                                if (j > 0) sql.Append(", ");
                                sql.Append($"@p{j}");
                            }
                            sql.Append(")");

                            using (var cmd = new MySqlCommand(sql.ToString(), connection, transaction))
                            {
                                for (int j = 0; j < values.Length && j < headers.Length; j++)
                                {
                                    cmd.Parameters.AddWithValue($"@p{j}", values[j].Trim());
                                }
                                cmd.ExecuteNonQuery();
                                count++;
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return count;
        }

        private string[] ParseCSVLine(string line)
        {
            var result = new System.Collections.Generic.List<string>();
            bool inQuotes = false;
            StringBuilder current = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
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

        private void buttonClose_Click(object sender, EventArgs e) => Close();
    }
}