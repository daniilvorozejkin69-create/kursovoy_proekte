using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace kursovoy_proekt
{
    public partial class RevenueReport : Form
    {
        private DataTable revenueData;
        private DateTime dateFrom;
        private DateTime dateTo;

        public RevenueReport()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Настройка DataGridView
            SetupDataGridView();

            // Подписка на события
            this.Load += RevenueReport_Load;
            radioToday.CheckedChanged += RadioPeriod_CheckedChanged;
            radioWeek.CheckedChanged += RadioPeriod_CheckedChanged;
            radioMonth.CheckedChanged += RadioPeriod_CheckedChanged;
            radioYear.CheckedChanged += RadioPeriod_CheckedChanged;
            radioCustom.CheckedChanged += RadioPeriod_CheckedChanged;

            buttonApplyFilter.Click += ButtonApplyFilter_Click;
            buttonRefresh.Click += ButtonRefresh_Click;
            buttonExportExcel.Click += ButtonExportExcel_Click;
            buttonExportWord.Click += ButtonExportWord_Click;
            buttonPrint.Click += ButtonPrint_Click;
            buttonBackToMenu.Click += ButtonBackToMenu_Click;
        }

        private void SetupDataGridView()
        {
            dataGridViewRevenue.AutoGenerateColumns = false;
            dataGridViewRevenue.AllowUserToAddRows = false;
            dataGridViewRevenue.AllowUserToDeleteRows = false;
            dataGridViewRevenue.ReadOnly = true;
            dataGridViewRevenue.RowHeadersVisible = false;
            dataGridViewRevenue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Настройка цветов
            dataGridViewRevenue.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(106, 153, 85);
            dataGridViewRevenue.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewRevenue.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            dataGridViewRevenue.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewRevenue.ColumnHeadersHeight = 40;

            dataGridViewRevenue.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewRevenue.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewRevenue.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 210);
            dataGridViewRevenue.DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewRevenue.DefaultCellStyle.Padding = new Padding(5);

            dataGridViewRevenue.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
            dataGridViewRevenue.GridColor = Color.FromArgb(220, 235, 210);
            dataGridViewRevenue.BorderStyle = BorderStyle.None;
            dataGridViewRevenue.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewRevenue.EnableHeadersVisualStyles = false;
        }

        private void RevenueReport_Load(object sender, EventArgs e)
        {
            // Установка периода по умолчанию - текущий месяц
            radioMonth.Checked = true;
            dateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTo = DateTime.Now;

            dateTimePickerFrom.Value = dateFrom;
            dateTimePickerTo.Value = dateTo;

            LoadRevenueData();
        }

        private void RadioPeriod_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio == null || !radio.Checked) return;

            DateTime now = DateTime.Now;

            if (radio == radioToday)
            {
                dateFrom = now.Date;
                dateTo = now.Date;
                dateTimePickerFrom.Value = dateFrom;
                dateTimePickerTo.Value = dateTo;
                dateTimePickerFrom.Enabled = false;
                dateTimePickerTo.Enabled = false;
            }
            else if (radio == radioWeek)
            {
                dateFrom = now.Date.AddDays(-(int)now.DayOfWeek + 1);
                dateTo = now.Date;
                dateTimePickerFrom.Value = dateFrom;
                dateTimePickerTo.Value = dateTo;
                dateTimePickerFrom.Enabled = false;
                dateTimePickerTo.Enabled = false;
            }
            else if (radio == radioMonth)
            {
                dateFrom = new DateTime(now.Year, now.Month, 1);
                dateTo = now.Date;
                dateTimePickerFrom.Value = dateFrom;
                dateTimePickerTo.Value = dateTo;
                dateTimePickerFrom.Enabled = false;
                dateTimePickerTo.Enabled = false;
            }
            else if (radio == radioYear)
            {
                dateFrom = new DateTime(now.Year, 1, 1);
                dateTo = now.Date;
                dateTimePickerFrom.Value = dateFrom;
                dateTimePickerTo.Value = dateTo;
                dateTimePickerFrom.Enabled = false;
                dateTimePickerTo.Enabled = false;
            }
            else if (radio == radioCustom)
            {
                dateTimePickerFrom.Enabled = true;
                dateTimePickerTo.Enabled = true;
            }
        }

        private void ButtonApplyFilter_Click(object sender, EventArgs e)
        {
            if (radioCustom.Checked)
            {
                dateFrom = dateTimePickerFrom.Value.Date;
                dateTo = dateTimePickerTo.Value.Date;

                if (dateFrom > dateTo)
                {
                    MessageBox.Show("Дата 'С' не может быть позже даты 'По'", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            LoadRevenueData();
            UpdateSummary();
            toolStripStatusLabel.Text = $"Фильтр применен: {dateFrom:dd.MM.yyyy} - {dateTo:dd.MM.yyyy}";
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadRevenueData();
            UpdateSummary();
            toolStripStatusLabel.Text = $"Данные обновлены: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
        }

        private void LoadRevenueData()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            ci.check_in_date as OrderDate,
                            ci.order_number as OrderNumber,
                            c.FIO as ClientName,
                            CONCAT(h.name, ' (', hc.class, ')') as HouseName,
                            ci.house_total_price as HouseCost,
                            IFNULL(SUM(cis.service_total_price), 0) as ServicesCost,
                            ci.house_total_price + IFNULL(SUM(cis.service_total_price), 0) as TotalCost
                        FROM check_in ci
                        JOIN client c ON ci.client_id = c.id
                        JOIN house h ON ci.house_id = h.id
                        JOIN home_class hc ON h.home_class_id = hc.id
                        LEFT JOIN check_in_services cis ON ci.order_number = cis.order_number
                        WHERE ci.check_in_date BETWEEN @dateFrom AND @dateTo
                        GROUP BY ci.order_number
                        ORDER BY ci.check_in_date DESC, ci.order_number DESC";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@dateFrom", dateFrom.Date);
                        cmd.Parameters.AddWithValue("@dateTo", dateTo.Date.AddDays(1).AddSeconds(-1));

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        revenueData = new DataTable();
                        adapter.Fill(revenueData);
                    }
                }

                // Заполнение DataGridView
                dataGridViewRevenue.Rows.Clear();

                foreach (DataRow row in revenueData.Rows)
                {
                    dataGridViewRevenue.Rows.Add(
                        Convert.ToDateTime(row["OrderDate"]).ToString("dd.MM.yyyy"),
                        row["OrderNumber"],
                        row["ClientName"],
                        row["HouseName"],
                        Convert.ToDecimal(row["HouseCost"]),
                        Convert.ToDecimal(row["ServicesCost"]),
                        Convert.ToDecimal(row["TotalCost"])
                    );
                }

                toolStripStatusLabel.Text = $"Загружено записей: {revenueData.Rows.Count} | Период: {dateFrom:dd.MM.yyyy} - {dateTo:dd.MM.yyyy}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                revenueData = new DataTable();
            }
        }

        private void UpdateSummary()
        {
            if (revenueData == null || revenueData.Rows.Count == 0)
            {
                labelTotalOrdersValue.Text = "0";
                labelTotalHouseRevenueValue.Text = "0 ₽";
                labelTotalServicesRevenueValue.Text = "0 ₽";
                labelTotalRevenueValue.Text = "0,00 ₽";
                labelAverageCheckValue.Text = "0 ₽";
                return;
            }

            int totalOrders = revenueData.Rows.Count;
            decimal totalHouse = 0;
            decimal totalServices = 0;
            decimal totalRevenue = 0;

            foreach (DataRow row in revenueData.Rows)
            {
                totalHouse += Convert.ToDecimal(row["HouseCost"]);
                totalServices += Convert.ToDecimal(row["ServicesCost"]);
                totalRevenue += Convert.ToDecimal(row["TotalCost"]);
            }

            decimal averageCheck = totalOrders > 0 ? totalRevenue / totalOrders : 0;

            labelTotalOrdersValue.Text = totalOrders.ToString();
            labelTotalHouseRevenueValue.Text = $"{totalHouse:N2} ₽";
            labelTotalServicesRevenueValue.Text = $"{totalServices:N2} ₽";
            labelTotalRevenueValue.Text = $"{totalRevenue:N2} ₽";
            labelAverageCheckValue.Text = $"{averageCheck:N2} ₽";
        }

        // ==================== ЭКСПОРТ В EXCEL ====================
        private void ButtonExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel файлы (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls";
                saveDialog.FileName = $"Отчёт_по_выручке_{dateFrom:yyyyMMdd}-{dateTo:yyyyMMdd}";
                saveDialog.DefaultExt = "xlsx";
                saveDialog.OverwritePrompt = true;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(saveDialog.FileName);
                    toolStripStatusLabel.Text = $"Отчёт экспортирован в Excel: {Path.GetFileName(saveDialog.FileName)}";

                    if (MessageBox.Show("Отчёт успешно создан! Открыть файл?", "Экспорт завершён",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта в Excel: {ex.Message}\n\nУбедитесь, что Microsoft Excel установлен.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel(string filePath)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                excelApp.DisplayAlerts = false;
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Worksheets[1];

                // Заголовок
                worksheet.Cells[1, 1] = "ОТЧЁТ ПО ВЫРУЧКЕ";
                worksheet.Cells[2, 1] = $"Период: {dateFrom:dd.MM.yyyy} - {dateTo:dd.MM.yyyy}";
                worksheet.Cells[3, 1] = $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
                worksheet.Cells[4, 1] = $"Сотрудник: {Session.UserName}";

                Excel.Range titleRange = worksheet.Range["A1", "G1"];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.Font.Color = Color.FromArgb(76, 145, 195);
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Заголовки колонок
                string[] headers = { "Дата", "№ заказа", "Клиент", "Дом", "Проживание", "Услуги", "Итого" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[6, i + 1] = headers[i];
                    Excel.Range cell = worksheet.Cells[6, i + 1];
                    cell.Font.Bold = true;
                    cell.Font.Color = Color.White;
                    cell.Interior.Color = Color.FromArgb(106, 153, 85);
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }

                // Данные
                int row = 7;
                decimal totalHouse = 0;
                decimal totalServices = 0;
                decimal totalSum = 0;

                foreach (DataGridViewRow dgvRow in dataGridViewRevenue.Rows)
                {
                    if (dgvRow.IsNewRow) continue;

                    worksheet.Cells[row, 1] = dgvRow.Cells["colDate"].Value?.ToString() ?? "";
                    worksheet.Cells[row, 2] = dgvRow.Cells["colOrderNumber"].Value?.ToString() ?? "";
                    worksheet.Cells[row, 3] = dgvRow.Cells["colClient"].Value?.ToString() ?? "";
                    worksheet.Cells[row, 4] = dgvRow.Cells["colHouse"].Value?.ToString() ?? "";
                    worksheet.Cells[row, 5] = dgvRow.Cells["colHouseCost"].Value;
                    worksheet.Cells[row, 6] = dgvRow.Cells["colServicesCost"].Value;
                    worksheet.Cells[row, 7] = dgvRow.Cells["colTotal"].Value;

                    // Формат чисел
                    ((Excel.Range)worksheet.Cells[row, 5]).NumberFormat = "#,##0.00 ₽";
                    ((Excel.Range)worksheet.Cells[row, 6]).NumberFormat = "#,##0.00 ₽";
                    ((Excel.Range)worksheet.Cells[row, 7]).NumberFormat = "#,##0.00 ₽";

                    // Альтернативный цвет строк
                    if (row % 2 == 0)
                    {
                        Excel.Range rowRange = worksheet.Range[$"A{row}", $"G{row}"];
                        rowRange.Interior.Color = Color.FromArgb(249, 249, 249);
                    }

                    // Суммирование
                    if (decimal.TryParse(dgvRow.Cells["colHouseCost"].Value?.ToString(), out decimal house))
                        totalHouse += house;
                    if (decimal.TryParse(dgvRow.Cells["colServicesCost"].Value?.ToString(), out decimal services))
                        totalServices += services;
                    if (decimal.TryParse(dgvRow.Cells["colTotal"].Value?.ToString(), out decimal total))
                        totalSum += total;

                    row++;
                }

                // Итоговая строка
                row++;
                worksheet.Cells[row, 1] = "ИТОГО:";
                Excel.Range totalLabelRange = worksheet.Range[$"A{row}", $"D{row}"];
                totalLabelRange.Merge();
                totalLabelRange.Font.Bold = true;
                totalLabelRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                worksheet.Cells[row, 5] = totalHouse;
                worksheet.Cells[row, 6] = totalServices;
                worksheet.Cells[row, 7] = totalSum;

                ((Excel.Range)worksheet.Cells[row, 5]).Font.Bold = true;
                ((Excel.Range)worksheet.Cells[row, 5]).NumberFormat = "#,##0.00 ₽";
                ((Excel.Range)worksheet.Cells[row, 6]).Font.Bold = true;
                ((Excel.Range)worksheet.Cells[row, 6]).NumberFormat = "#,##0.00 ₽";
                ((Excel.Range)worksheet.Cells[row, 7]).Font.Bold = true;
                ((Excel.Range)worksheet.Cells[row, 7]).NumberFormat = "#,##0.00 ₽";
                ((Excel.Range)worksheet.Cells[row, 7]).Font.Color = Color.FromArgb(106, 153, 85);

                // Автоширина
                worksheet.Columns.AutoFit();

                // Сохранение
                workbook.SaveAs(filePath);
            }
            finally
            {
                if (workbook != null) workbook.Close(false);
                if (excelApp != null) excelApp.Quit();

                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        // ==================== ЭКСПОРТ В WORD ====================
        private void ButtonExportWord_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Word файлы (*.docx)|*.docx|Word 97-2003 (*.doc)|*.doc";
                saveDialog.FileName = $"Отчёт_по_выручке_{dateFrom:yyyyMMdd}-{dateTo:yyyyMMdd}";
                saveDialog.DefaultExt = "docx";
                saveDialog.OverwritePrompt = true;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToWord(saveDialog.FileName);
                    toolStripStatusLabel.Text = $"Отчёт экспортирован в Word: {Path.GetFileName(saveDialog.FileName)}";

                    if (MessageBox.Show("Отчёт успешно создан! Открыть файл?", "Экспорт завершён",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта в Word: {ex.Message}\n\nУбедитесь, что Microsoft Word установлен.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToWord(string filePath)
        {
            Word.Application wordApp = null;
            Word.Document document = null;

            try
            {
                wordApp = new Word.Application();
                wordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;

                document = wordApp.Documents.Add();
                document.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                // Заголовок
                Word.Paragraph title = document.Content.Paragraphs.Add();
                title.Range.Text = "ОТЧЁТ ПО ВЫРУЧКЕ\n";
                title.Range.Font.Bold = 1;
                title.Range.Font.Size = 18;
                title.Range.Font.Color = Word.WdColor.wdColorDarkBlue;
                title.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                title.Range.InsertParagraphAfter();

                // Информация о периоде
                Word.Paragraph info = document.Content.Paragraphs.Add();
                info.Range.Text = $"Период: {dateFrom:dd.MM.yyyy} - {dateTo:dd.MM.yyyy}\n";
                info.Range.Font.Size = 12;
                info.Range.Font.Bold = 1;
                info.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                info.Range.InsertParagraphAfter();

                Word.Paragraph dateInfo = document.Content.Paragraphs.Add();
                dateInfo.Range.Text = $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm:ss}\n";
                dateInfo.Range.Font.Size = 11;
                dateInfo.Range.Font.Italic = 1;
                dateInfo.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                dateInfo.Range.InsertParagraphAfter();

                Word.Paragraph userInfo = document.Content.Paragraphs.Add();
                userInfo.Range.Text = $"Сотрудник: {Session.UserName}\n\n";
                userInfo.Range.Font.Size = 11;
                userInfo.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                userInfo.Range.InsertParagraphAfter();

                // Таблица с данными
                int rowCount = dataGridViewRevenue.Rows.Count;
                if (rowCount > 0) rowCount++; // Убираем лишнюю строку

                Word.Table table = document.Tables.Add(
                    document.Range(),
                    rowCount + 2,
                    7
                );

                table.Borders.Enable = 1;
                table.Range.Font.Size = 10;
                table.Range.Font.Name = "Calibri";

                // Заголовки таблицы
                string[] headers = { "Дата", "№ заказа", "Клиент", "Дом", "Проживание", "Услуги", "Итого" };
                for (int i = 0; i < headers.Length; i++)
                {
                    table.Cell(1, i + 1).Range.Text = headers[i];
                    table.Cell(1, i + 1).Range.Font.Bold = 1;
                    table.Cell(1, i + 1).Range.Font.Color = Word.WdColor.wdColorWhite;
                    table.Cell(1, i + 1).Shading.BackgroundPatternColor = Word.WdColor.wdColorGreen;
                    table.Cell(1, i + 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                // Данные
                decimal totalHouse = 0, totalServices = 0, totalSum = 0;
                int row = 2;

                foreach (DataGridViewRow dgvRow in dataGridViewRevenue.Rows)
                {
                    if (dgvRow.IsNewRow) continue;

                    table.Cell(row, 1).Range.Text = dgvRow.Cells["colDate"].Value?.ToString() ?? "";
                    table.Cell(row, 2).Range.Text = dgvRow.Cells["colOrderNumber"].Value?.ToString() ?? "";
                    table.Cell(row, 3).Range.Text = dgvRow.Cells["colClient"].Value?.ToString() ?? "";
                    table.Cell(row, 4).Range.Text = dgvRow.Cells["colHouse"].Value?.ToString() ?? "";

                    if (dgvRow.Cells["colHouseCost"].Value != null)
                        table.Cell(row, 5).Range.Text = $"{Convert.ToDecimal(dgvRow.Cells["colHouseCost"].Value):N2} ₽";
                    if (dgvRow.Cells["colServicesCost"].Value != null)
                        table.Cell(row, 6).Range.Text = $"{Convert.ToDecimal(dgvRow.Cells["colServicesCost"].Value):N2} ₽";
                    if (dgvRow.Cells["colTotal"].Value != null)
                        table.Cell(row, 7).Range.Text = $"{Convert.ToDecimal(dgvRow.Cells["colTotal"].Value):N2} ₽";

                    table.Cell(row, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    table.Cell(row, 6).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    table.Cell(row, 7).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

                    if (dgvRow.Cells["colHouseCost"].Value != null)
                        totalHouse += Convert.ToDecimal(dgvRow.Cells["colHouseCost"].Value);
                    if (dgvRow.Cells["colServicesCost"].Value != null)
                        totalServices += Convert.ToDecimal(dgvRow.Cells["colServicesCost"].Value);
                    if (dgvRow.Cells["colTotal"].Value != null)
                        totalSum += Convert.ToDecimal(dgvRow.Cells["colTotal"].Value);

                    row++;
                }

                // Итоговая строка
                table.Cell(row, 1).Range.Text = "ИТОГО:";
                table.Cell(row, 1).Range.Font.Bold = 1;

                table.Cell(row, 5).Range.Text = $"{totalHouse:N2} ₽";
                table.Cell(row, 6).Range.Text = $"{totalServices:N2} ₽";
                table.Cell(row, 7).Range.Text = $"{totalSum:N2} ₽";

                table.Cell(row, 5).Range.Font.Bold = 1;
                table.Cell(row, 6).Range.Font.Bold = 1;
                table.Cell(row, 7).Range.Font.Bold = 1;
                table.Cell(row, 7).Range.Font.Color = Word.WdColor.wdColorGreen;

                // Автоподбор ширины
                table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);

                // Сохранение
                document.SaveAs2(filePath);
            }
            finally
            {
                if (document != null) document.Close(false);
                if (wordApp != null) wordApp.Quit();

                if (document != null) Marshal.ReleaseComObject(document);
                if (wordApp != null) Marshal.ReleaseComObject(wordApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        // ==================== ПЕЧАТЬ ====================
        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                    toolStripStatusLabel.Text = "Отчёт отправлен на печать";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка печати: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            Font normalFont = new Font("Segoe UI", 10);

            float yPos = e.MarginBounds.Top;

            e.Graphics.DrawString("ОТЧЁТ ПО ВЫРУЧКЕ", titleFont, Brushes.DarkBlue, e.MarginBounds.Left, yPos);
            yPos += titleFont.GetHeight() + 10;

            e.Graphics.DrawString($"Период: {dateFrom:dd.MM.yyyy} - {dateTo:dd.MM.yyyy}", normalFont, Brushes.Black, e.MarginBounds.Left, yPos);
            yPos += normalFont.GetHeight() + 20;

            e.Graphics.DrawString($"Всего заказов: {labelTotalOrdersValue.Text}", normalFont, Brushes.Black, e.MarginBounds.Left, yPos);
            yPos += normalFont.GetHeight() + 5;

            e.Graphics.DrawString($"Общая выручка: {labelTotalRevenueValue.Text}", normalFont, Brushes.Black, e.MarginBounds.Left, yPos);
            yPos += normalFont.GetHeight() + 5;

            e.Graphics.DrawString($"Средний чек: {labelAverageCheckValue.Text}", normalFont, Brushes.Black, e.MarginBounds.Left, yPos);
        }

        private void ButtonBackToMenu_Click(object sender, EventArgs e)
        {
            ManagerForm housList = new ManagerForm();
            housList.Show();
            this.Close();
        }

        private void buttonBackToMenu_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonApplyFilter_Click_1(object sender, EventArgs e)
        {

        }
    }
}