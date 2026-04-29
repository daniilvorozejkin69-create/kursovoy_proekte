using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace kursovoy_proekt
{
    public partial class HouseReportForm : Form
    {
        private DataTable reportData;
        private DateTime startDate;
        private DateTime endDate;

        public HouseReportForm()
        {
            InitializeComponent();
            InitializeReport();
        }

        private void InitializeReport()
        {
            // Настройка дат по умолчанию
            dateTimePickerFrom.Value = DateTime.Now.AddMonths(-1);
            dateTimePickerTo.Value = DateTime.Now;

            // По умолчанию выбран "Месяц"
            radioMonth.Checked = true;

            // Подписка на события
            radioToday.Click += RadioButton_Click;
            radioWeek.Click += RadioButton_Click;
            radioMonth.Click += RadioButton_Click;
            radioYear.Click += RadioButton_Click;
            radioCustom.Click += RadioButton_Click;

            buttonApplyFilter.Click += ButtonApplyFilter_Click;
            buttonRefresh.Click += ButtonRefresh_Click;
            buttonExportExcel.Click += ButtonExportExcel_Click;
            buttonPrint.Click += ButtonPrint_Click;
            buttonBackToMenu.Click += ButtonBackToMenu_Click;

            // Загружаем данные
            LoadReportData();
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio != null)
            {
                SetDateRangeByRadio(radio.Name);
            }
        }

        private void SetDateRangeByRadio(string radioName)
        {
            DateTime now = DateTime.Now;

            switch (radioName)
            {
                case "radioToday":
                    dateTimePickerFrom.Value = now.Date;
                    dateTimePickerTo.Value = now.Date;
                    break;

                case "radioWeek":
                    int daysToMonday = ((int)now.DayOfWeek - 1 + 7) % 7;
                    dateTimePickerFrom.Value = now.AddDays(-daysToMonday).Date;
                    dateTimePickerTo.Value = now.Date;
                    break;

                case "radioMonth":
                    dateTimePickerFrom.Value = new DateTime(now.Year, now.Month, 1);
                    dateTimePickerTo.Value = now.Date;
                    break;

                case "radioYear":
                    dateTimePickerFrom.Value = new DateTime(now.Year, 1, 1);
                    dateTimePickerTo.Value = now.Date;
                    break;

                case "radioCustom":
                    // Оставляем текущие значения
                    break;
            }
        }

        private void ButtonApplyFilter_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void LoadReportData()
        {
            try
            {
                startDate = dateTimePickerFrom.Value.Date;
                endDate = dateTimePickerTo.Value.Date;

                if (startDate > endDate)
                {
                    MessageBox.Show("Дата начала не может быть позже даты окончания!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            h.id,
                            h.name AS HouseName,
                            hc.class AS HouseClass,
                            h.capacity,
                            COUNT(DISTINCT ci.order_number) AS BookingCount,
                            IFNULL(SUM(DATEDIFF(ci.check_out_date, ci.check_in_date)), 0) AS OccupiedDays,
                            IFNULL(SUM(ci.house_total_price), 0) AS HouseRevenue,
                            IFNULL(SUM(cis.service_total_price), 0) AS ServiceRevenue,
                            IFNULL(SUM(ci.house_total_price + IFNULL(cis.service_total_price, 0)), 0) AS TotalRevenue,
                            IFNULL(AVG(ci.residence_time), 0) AS AvgStayDays
                        FROM house h
                        JOIN home_class hc ON h.home_class_id = hc.id
                        LEFT JOIN check_in ci ON h.id = ci.house_id 
                            AND ci.check_in_date BETWEEN @startDate AND @endDate
                        LEFT JOIN check_in_services cis ON ci.order_number = cis.order_number
                        GROUP BY h.id, h.name, hc.class, h.capacity
                        ORDER BY TotalRevenue DESC, BookingCount DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        reportData = new DataTable();
                        adapter.Fill(reportData);
                    }
                }

                DisplayReportData();
                UpdateStatus($"Данные загружены за период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке отчёта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Ошибка загрузки данных");
            }
        }

        private void DisplayReportData()
        {
            dataGridViewReport.Rows.Clear();

            if (reportData == null || reportData.Rows.Count == 0)
            {
                labelTotalOrdersValue.Text = "0";
                labelTotalHouseRevenueValue.Text = "0 ₽";
                labelTotalServicesRevenueValue.Text = "0 ₽";
                labelTotalRevenueValue.Text = "0 ₽";
                labelAverageCheckValue.Text = "0 ₽";
                return;
            }

            int rank = 1;
            int totalBookings = 0;
            decimal totalHouseRevenue = 0;
            decimal totalServiceRevenue = 0;
            decimal totalRevenue = 0;
            int totalDays = (endDate - startDate).Days + 1;

            foreach (DataRow row in reportData.Rows)
            {
                int bookings = ConvertToInt(row["BookingCount"]);
                decimal houseRevenue = ConvertToDecimal(row["HouseRevenue"]);
                decimal serviceRevenue = ConvertToDecimal(row["ServiceRevenue"]);
                decimal revenue = ConvertToDecimal(row["TotalRevenue"]);
                int occupiedDays = ConvertToInt(row["OccupiedDays"]);
                double avgStay = ConvertToDouble(row["AvgStayDays"]);

                totalBookings += bookings;
                totalHouseRevenue += houseRevenue;
                totalServiceRevenue += serviceRevenue;
                totalRevenue += revenue;

                // Расчет загрузки в процентах
                double occupancyPercent = totalDays > 0 ? (double)occupiedDays / totalDays * 100 : 0;

                dataGridViewReport.Rows.Add(
                    rank++,
                    row["HouseName"],
                    row["HouseClass"],
                    bookings,
                    occupiedDays,
                    revenue.ToString("N2"),
                    avgStay.ToString("N1"),
                    occupancyPercent.ToString("N1") + "%"
                );
            }

            // Обновление итогов
            labelTotalOrdersValue.Text = totalBookings.ToString();
            labelTotalHouseRevenueValue.Text = totalHouseRevenue.ToString("N2") + " ₽";
            labelTotalServicesRevenueValue.Text = totalServiceRevenue.ToString("N2") + " ₽";
            labelTotalRevenueValue.Text = totalRevenue.ToString("N2") + " ₽";

            if (totalBookings > 0)
            {
                decimal avgCheck = totalRevenue / totalBookings;
                labelAverageCheckValue.Text = avgCheck.ToString("N2") + " ₽";
            }
            else
            {
                labelAverageCheckValue.Text = "0 ₽";
            }
        }

        private int ConvertToInt(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;
            return Convert.ToInt32(value);
        }

        private decimal ConvertToDecimal(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;
            return Convert.ToDecimal(value);
        }

        private double ConvertToDouble(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;
            return Convert.ToDouble(value);
        }

        private void UpdateStatus(string message)
        {
            toolStripStatusLabel.Text = message;
        }

        private void ButtonExportExcel_Click(object sender, EventArgs e)
        {
            if (reportData == null || reportData.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel файлы (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls";
            saveDialog.FileName = $"Отчёт_по_домам_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}.xlsx";
            saveDialog.Title = "Сохранить отчёт в Excel";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToExcel(saveDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}\n\nПопробуйте установить Microsoft Excel.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportToExcel(string filePath)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                // Создаем приложение Excel
                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                // Создаем новую книгу
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Worksheets[1];
                worksheet.Name = "Отчёт по домам";

                // Заголовок отчёта
                Excel.Range titleRange = worksheet.get_Range("A1", "H1");
                titleRange.Merge();
                titleRange.Value = $"ОТЧЁТ ПО ДОМАМ";
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Период
                worksheet.Cells[2, 1] = $"Период: с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}";
                worksheet.get_Range("A2", "H2").Font.Bold = true;

                // Заголовки колонок
                string[] headers = { "№", "Название дома", "Класс", "Бронирований", "Занято дней", "Доход, ₽", "Ср. длит.", "Загрузка, %" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[4, i + 1] = headers[i];
                }

                Excel.Range headerRange = worksheet.get_Range("A4", "H4");
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = Excel.XlRgbColor.rgbLightGray;
                headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // Данные
                int row = 5;
                int rank = 1;
                int totalDays = (endDate - startDate).Days + 1;

                foreach (DataRow dataRow in reportData.Rows)
                {
                    int bookings = ConvertToInt(dataRow["BookingCount"]);
                    int occupiedDays = ConvertToInt(dataRow["OccupiedDays"]);
                    double occupancyPercent = totalDays > 0 ? (double)occupiedDays / totalDays * 100 : 0;

                    worksheet.Cells[row, 1] = rank++;
                    worksheet.Cells[row, 2] = dataRow["HouseName"].ToString();
                    worksheet.Cells[row, 3] = dataRow["HouseClass"].ToString();
                    worksheet.Cells[row, 4] = bookings;
                    worksheet.Cells[row, 5] = occupiedDays;
                    worksheet.Cells[row, 6] = ConvertToDecimal(dataRow["TotalRevenue"]);
                    worksheet.Cells[row, 7] = ConvertToDouble(dataRow["AvgStayDays"]);
                    worksheet.Cells[row, 8] = occupancyPercent;

                    // Форматирование чисел
                    ((Excel.Range)worksheet.Cells[row, 6]).NumberFormat = "#,##0.00 ₽";
                    ((Excel.Range)worksheet.Cells[row, 7]).NumberFormat = "0.0";
                    ((Excel.Range)worksheet.Cells[row, 8]).NumberFormat = "0.0";

                    row++;
                }

                // Итоги
                row += 2;
                worksheet.Cells[row, 1] = "ИТОГИ:";
                worksheet.get_Range($"A{row}", $"H{row}").Font.Bold = true;

                row++;
                worksheet.Cells[row, 1] = $"Всего бронирований: {labelTotalOrdersValue.Text}";
                row++;
                worksheet.Cells[row, 1] = $"Выручка с проживания: {labelTotalHouseRevenueValue.Text}";
                row++;
                worksheet.Cells[row, 1] = $"Выручка с услуг: {labelTotalServicesRevenueValue.Text}";
                row++;
                worksheet.Cells[row, 1] = $"Общая выручка: {labelTotalRevenueValue.Text}";
                row++;
                worksheet.Cells[row, 1] = $"Средний чек: {labelAverageCheckValue.Text}";

                // Дата формирования
                row += 2;
                worksheet.Cells[row, 1] = $"Отчёт сформирован: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";

                // Автоширина колонок
                worksheet.Columns.AutoFit();

                // Сохраняем файл
                workbook.SaveAs(filePath);

                MessageBox.Show($"Отчёт успешно сохранён в Excel:\n{filePath}", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Открываем файл
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при создании Excel файла: {ex.Message}");
            }
            finally
            {
                // Освобождаем ресурсы
                if (workbook != null)
                {
                    workbook.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }
                if (excelApp != null)
                {
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void ButtonExportWord_Click(object sender, EventArgs e)
        {
            if (reportData == null || reportData.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            saveDialog.FileName = $"Отчёт_по_домам_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}.txt";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToTXT(saveDialog.FileName);
            }
        }

        private void ExportToTXT(string filePath)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("=".PadRight(80, '='));
                sb.AppendLine("ОТЧЁТ ПО ДОМАМ".PadLeft(40 + "ОТЧЁТ ПО ДОМАМ".Length / 2));
                sb.AppendLine("=".PadRight(80, '='));
                sb.AppendLine();
                sb.AppendLine($"Период: с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}");
                sb.AppendLine();
                sb.AppendLine("-".PadRight(80, '-'));
                sb.AppendLine($"{"№",-4} {"Название дома",-25} {"Класс",-10} {"Бронир.",-8} {"Дней",-8} {"Доход, ₽",-12} {"Ср.длит.",-8} {"Загр.%",-8}");
                sb.AppendLine("-".PadRight(80, '-'));

                int rank = 1;
                int totalDays = (endDate - startDate).Days + 1;

                foreach (DataRow row in reportData.Rows)
                {
                    int bookings = ConvertToInt(row["BookingCount"]);
                    int occupiedDays = ConvertToInt(row["OccupiedDays"]);
                    double occupancyPercent = totalDays > 0 ? (double)occupiedDays / totalDays * 100 : 0;

                    string name = row["HouseName"].ToString();
                    if (name.Length > 22) name = name.Substring(0, 22) + "...";

                    sb.AppendLine($"{rank++,-4} {name,-25} {row["HouseClass"],-10} {bookings,-8} {occupiedDays,-8} {ConvertToDecimal(row["TotalRevenue"]),-12:F2} {ConvertToDouble(row["AvgStayDays"]),-8:F1} {occupancyPercent,-8:F1}");
                }

                sb.AppendLine("-".PadRight(80, '-'));
                sb.AppendLine();
                sb.AppendLine("ИТОГИ:");
                sb.AppendLine($"  Всего бронирований: {labelTotalOrdersValue.Text}");
                sb.AppendLine($"  Выручка с проживания: {labelTotalHouseRevenueValue.Text}");
                sb.AppendLine($"  Выручка с услуг: {labelTotalServicesRevenueValue.Text}");
                sb.AppendLine($"  Общая выручка: {labelTotalRevenueValue.Text}");
                sb.AppendLine($"  Средний чек: {labelAverageCheckValue.Text}");
                sb.AppendLine();
                sb.AppendLine("=".PadRight(80, '='));
                sb.AppendLine($"Отчёт сформирован: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                sb.AppendLine("=".PadRight(80, '='));

                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);

                MessageBox.Show($"Отчёт сохранён: {filePath}", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            if (reportData == null || reportData.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для печати!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintReportPage;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
                UpdateStatus("Отчёт отправлен на печать");
            }
        }

        private void PrintReportPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Font titleFont = new Font("Segoe UI", 14, FontStyle.Bold);
                Font headerFont = new Font("Segoe UI", 10, FontStyle.Bold);
                Font normalFont = new Font("Segoe UI", 9);

                float y = e.MarginBounds.Top;
                float left = e.MarginBounds.Left;
                float pageWidth = e.MarginBounds.Width;
                float lineHeight = 15;

                // Заголовок
                string title = "ОТЧЁТ ПО ДОМАМ";
                SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
                e.Graphics.DrawString(title, titleFont, Brushes.Black,
                    left + (pageWidth - titleSize.Width) / 2, y);
                y += titleSize.Height + 5;

                // Период
                string period = $"с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}";
                e.Graphics.DrawString(period, headerFont, Brushes.Black, left, y);
                y += headerFont.GetHeight() + 10;

                // Заголовки таблицы
                string[] headers = { "№", "Название дома", "Класс", "Бронир.", "Дней", "Доход, ₽", "Ср.длит.", "Загр.%" };
                float[] colWidths = { 30, 180, 70, 60, 50, 90, 50, 60 };
                float x = left;

                for (int i = 0; i < headers.Length; i++)
                {
                    e.Graphics.DrawString(headers[i], headerFont, Brushes.Black, x, y);
                    x += colWidths[i];
                }
                y += headerFont.GetHeight() + 5;

                // Линия
                e.Graphics.DrawLine(Pens.Black, left, y, left + colWidths.Sum(), y);
                y += 5;

                // Данные
                int rank = 1;
                int totalDays = (endDate - startDate).Days + 1;

                foreach (DataRow row in reportData.Rows)
                {
                    x = left;

                    int bookings = ConvertToInt(row["BookingCount"]);
                    int occupiedDays = ConvertToInt(row["OccupiedDays"]);
                    double occupancyPercent = totalDays > 0 ? (double)occupiedDays / totalDays * 100 : 0;
                    decimal revenue = ConvertToDecimal(row["TotalRevenue"]);

                    e.Graphics.DrawString(rank.ToString(), normalFont, Brushes.Black, x, y);
                    x += colWidths[0];

                    string name = row["HouseName"].ToString();
                    if (name.Length > 18) name = name.Substring(0, 18) + "...";
                    e.Graphics.DrawString(name, normalFont, Brushes.Black, x, y);
                    x += colWidths[1];

                    e.Graphics.DrawString(row["HouseClass"].ToString(), normalFont, Brushes.Black, x, y);
                    x += colWidths[2];

                    e.Graphics.DrawString(bookings.ToString(), normalFont, Brushes.Black, x, y);
                    x += colWidths[3];

                    e.Graphics.DrawString(occupiedDays.ToString(), normalFont, Brushes.Black, x, y);
                    x += colWidths[4];

                    e.Graphics.DrawString(revenue.ToString("N2"), normalFont, Brushes.Black, x, y);
                    x += colWidths[5];

                    e.Graphics.DrawString(ConvertToDouble(row["AvgStayDays"]).ToString("N1"), normalFont, Brushes.Black, x, y);
                    x += colWidths[6];

                    e.Graphics.DrawString(occupancyPercent.ToString("N1"), normalFont, Brushes.Black, x, y);

                    y += lineHeight;
                    rank++;

                    if (y > e.MarginBounds.Bottom - 60)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }

                // Итоги
                y = e.MarginBounds.Bottom - 45;
                e.Graphics.DrawLine(Pens.Black, left, y - 5, left + colWidths.Sum(), y - 5);

                e.Graphics.DrawString($"Всего бронирований: {labelTotalOrdersValue.Text}", headerFont, Brushes.Black, left, y);
                e.Graphics.DrawString($"Общая выручка: {labelTotalRevenueValue.Text}", headerFont, Brushes.Black, left + 300, y);

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка печати: {ex.Message}");
            }
        }

        private void ButtonBackToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}