using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            // Настройка дат по умолчанию (последние 30 дней)
            dateTimePickerStart.Value = DateTime.Now.AddMonths(-1);
            dateTimePickerEnd.Value = DateTime.Now;

            // Настройка DataGridView
            dataGridViewReport.AutoGenerateColumns = false;
            dataGridViewReport.Columns.Clear();

            DataGridViewTextBoxColumn colRank = new DataGridViewTextBoxColumn();
            colRank.Name = "Rank";
            colRank.HeaderText = "№";
            colRank.Width = 40;
            colRank.ReadOnly = true;

            DataGridViewTextBoxColumn colHouseName = new DataGridViewTextBoxColumn();
            colHouseName.Name = "HouseName";
            colHouseName.HeaderText = "Название дома";
            colHouseName.Width = 200;
            colHouseName.ReadOnly = true;

            DataGridViewTextBoxColumn colHouseClass = new DataGridViewTextBoxColumn();
            colHouseClass.Name = "HouseClass";
            colHouseClass.HeaderText = "Класс";
            colHouseClass.Width = 100;
            colHouseClass.ReadOnly = true;

            DataGridViewTextBoxColumn colBookings = new DataGridViewTextBoxColumn();
            colBookings.Name = "Bookings";
            colBookings.HeaderText = "Бронирований";
            colBookings.Width = 100;
            colBookings.ReadOnly = true;
            colBookings.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colDays = new DataGridViewTextBoxColumn();
            colDays.Name = "Days";
            colDays.HeaderText = "Занято дней";
            colDays.Width = 100;
            colDays.ReadOnly = true;
            colDays.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colRevenue = new DataGridViewTextBoxColumn();
            colRevenue.Name = "Revenue";
            colRevenue.HeaderText = "Доход, ₽";
            colRevenue.Width = 120;
            colRevenue.ReadOnly = true;
            colRevenue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colRevenue.DefaultCellStyle.Format = "N2";

            DataGridViewTextBoxColumn colAvgStay = new DataGridViewTextBoxColumn();
            colAvgStay.Name = "AvgStay";
            colAvgStay.HeaderText = "Ср. длит.";
            colAvgStay.Width = 80;
            colAvgStay.ReadOnly = true;
            colAvgStay.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumn colOccupancy = new DataGridViewTextBoxColumn();
            colOccupancy.Name = "Occupancy";
            colOccupancy.HeaderText = "Загрузка, %";
            colOccupancy.Width = 80;
            colOccupancy.ReadOnly = true;
            colOccupancy.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colOccupancy.DefaultCellStyle.Format = "N1";

            dataGridViewReport.Columns.AddRange(colRank, colHouseName, colHouseClass, colBookings,
                                                colDays, colRevenue, colAvgStay, colOccupancy);
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            startDate = dateTimePickerStart.Value.Date;
            endDate = dateTimePickerEnd.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadReportData();
            CalculateTotals();
        }

        private void LoadReportData()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            h.id,
                            h.name AS HouseName,
                            hc.class AS HouseClass,
                            h.capacity,
                            COUNT(DISTINCT b.id) AS BookingCount,
                            COUNT(DISTINCT ci.order_number) AS CheckInCount,
                            IFNULL(SUM(
                                DATEDIFF(
                                    LEAST(IFNULL(ci.check_out_date, @endDate), @endDate),
                                    GREATEST(IFNULL(ci.check_in_date, @startDate), @startDate)
                                )
                            ), 0) AS OccupiedDays,
                            IFNULL(SUM(ci.house_total_price), 0) AS HouseRevenue,
                            IFNULL(SUM(cis.service_total_price), 0) AS ServiceRevenue,
                            IFNULL(SUM(
                                IFNULL(ci.house_total_price, 0) + IFNULL(cis.service_total_price, 0)
                            ), 0) AS TotalRevenue,
                            IFNULL(AVG(ci.residence_time), 0) AS AvgStayDays
                        FROM house h
                        JOIN home_class hc ON h.home_class_id = hc.id
                        LEFT JOIN check_in ci ON h.id = ci.house_id 
                            AND ci.check_in_date <= @endDate 
                            AND ci.check_out_date >= @startDate
                        LEFT JOIN check_in_services cis ON ci.order_number = cis.order_number
                        LEFT JOIN booking b ON h.id = b.house_id 
                            AND b.check_in_date <= @endDate 
                            AND b.check_out_date >= @startDate
                            AND b.status IN ('confirmed', 'pending')
                        GROUP BY h.id, h.name, hc.class, h.capacity
                        ORDER BY TotalRevenue DESC, OccupiedDays DESC";

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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке отчёта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayReportData()
        {
            dataGridViewReport.Rows.Clear();

            if (reportData == null || reportData.Rows.Count == 0)
            {
                labelTotalBookings.Text = "0";
                labelTotalRevenue.Text = "0.00";
                labelAvgOccupancy.Text = "0";
                labelPopularHouse.Text = "Нет данных";
                labelHouseRevenue.Text = "0.00";
                labelServiceRevenue.Text = "0.00";
                return;
            }

            int totalDays = (endDate - startDate).Days + 1;
            int rank = 1;
            int totalBookings = 0;
            decimal totalRevenue = 0;
            double totalOccupancy = 0;
            string mostPopularHouse = "";
            int maxBookings = 0;
            decimal totalHouseRevenue = 0;
            decimal totalServiceRevenue = 0;

            foreach (DataRow row in reportData.Rows)
            {
                // Безопасное получение значений с проверкой на DBNull
                int bookings = ConvertToInt(row["BookingCount"]) + ConvertToInt(row["CheckInCount"]);
                decimal revenue = ConvertToDecimal(row["TotalRevenue"]);
                int occupiedDays = ConvertToInt(row["OccupiedDays"]);
                double avgStay = ConvertToDouble(row["AvgStayDays"]);
                decimal houseRevenue = ConvertToDecimal(row["HouseRevenue"]);
                decimal serviceRevenue = ConvertToDecimal(row["ServiceRevenue"]);

                double occupancyPercent = totalDays > 0 ? (double)occupiedDays / totalDays * 100 : 0;

                totalBookings += bookings;
                totalRevenue += revenue;
                totalOccupancy += occupancyPercent;
                totalHouseRevenue += houseRevenue;
                totalServiceRevenue += serviceRevenue;

                if (bookings > maxBookings)
                {
                    maxBookings = bookings;
                    mostPopularHouse = row["HouseName"].ToString();
                }

                dataGridViewReport.Rows.Add(
                    rank++,
                    row["HouseName"],
                    row["HouseClass"],
                    bookings,
                    occupiedDays,
                    revenue,
                    avgStay.ToString("N1"),
                    occupancyPercent.ToString("N1")
                );
            }

            // Обновление итогов
            labelTotalBookings.Text = totalBookings.ToString();
            labelTotalRevenue.Text = totalRevenue.ToString("N2");
            labelAvgOccupancy.Text = (reportData.Rows.Count > 0 ? totalOccupancy / reportData.Rows.Count : 0).ToString("N1");
            labelPopularHouse.Text = string.IsNullOrEmpty(mostPopularHouse) ? "Нет данных" : mostPopularHouse;
            labelHouseRevenue.Text = totalHouseRevenue.ToString("N2");
            labelServiceRevenue.Text = totalServiceRevenue.ToString("N2");
            labelPeriodInfo.Text = $"с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}";
        }

        // Безопасное преобразование в int
        private int ConvertToInt(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;
            return Convert.ToInt32(value);
        }

        // Безопасное преобразование в decimal
        private decimal ConvertToDecimal(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;
            return Convert.ToDecimal(value);
        }

        // Безопасное преобразование в double
        private double ConvertToDouble(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;
            return Convert.ToDouble(value);
        }

        private void CalculateTotals()
        {
            // Дополнительные расчёты уже сделаны в DisplayReportData
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (reportData == null || reportData.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV файлы (*.csv)|*.csv|Текстовые файлы (*.txt)|*.txt";
            saveDialog.FileName = $"Отчёт_по_домам_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}";
            saveDialog.DefaultExt = "csv";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToCSV(saveDialog.FileName);
            }
        }

        private void ExportToCSV(string filePath)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                // Заголовок отчёта
                sb.AppendLine($"Отчёт по домам за период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}");
                sb.AppendLine();

                // Заголовки колонок
                sb.AppendLine("№;Название дома;Класс;Бронирований;Занято дней;Доход, ₽;Ср. длит.;Загрузка, %");

                // Данные
                int rank = 1;
                foreach (DataRow row in reportData.Rows)
                {
                    int bookings = ConvertToInt(row["BookingCount"]) + ConvertToInt(row["CheckInCount"]);
                    int occupiedDays = ConvertToInt(row["OccupiedDays"]);
                    int totalDays = (endDate - startDate).Days + 1;
                    double occupancyPercent = totalDays > 0 ? (double)occupiedDays / totalDays * 100 : 0;

                    sb.AppendLine($"{rank++};{row["HouseName"]};{row["HouseClass"]};{bookings};{occupiedDays};{ConvertToDecimal(row["TotalRevenue"]):F2};{ConvertToDouble(row["AvgStayDays"]):F1};{occupancyPercent:F1}");
                }

                // Итоги
                sb.AppendLine();
                sb.AppendLine($"Всего бронирований: {labelTotalBookings.Text}");
                sb.AppendLine($"Общий доход: {labelTotalRevenue.Text} ₽");
                sb.AppendLine($"Средняя загрузка: {labelAvgOccupancy.Text}%");
                sb.AppendLine($"Самый популярный дом: {labelPopularHouse.Text}");
                sb.AppendLine($"Доход от проживания: {labelHouseRevenue.Text} ₽");
                sb.AppendLine($"Доход от доп. услуг: {labelServiceRevenue.Text} ₽");

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

        private void buttonPrint_Click(object sender, EventArgs e)
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
            }
        }

        private void PrintReportPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Font titleFont = new Font("Arial", 14, FontStyle.Bold);
                Font headerFont = new Font("Arial", 10, FontStyle.Bold);
                Font normalFont = new Font("Arial", 9);
                Font totalFont = new Font("Arial", 10, FontStyle.Bold);

                float y = e.MarginBounds.Top;
                float left = e.MarginBounds.Left;
                float pageWidth = e.MarginBounds.Width;

                // Заголовок
                string title = "ОТЧЁТ ПО ДОМАМ";
                SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
                e.Graphics.DrawString(title, titleFont, Brushes.Black,
                    left + (pageWidth - titleSize.Width) / 2, y);
                y += titleSize.Height + 5;

                // Период
                string period = $"с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}";
                e.Graphics.DrawString(period, headerFont, Brushes.Black, left, y);
                y += headerFont.GetHeight() + 15;

                // Заголовки таблицы
                string[] headers = { "№", "Название дома", "Класс", "Бронир.", "Дней", "Доход, ₽", "Ср.длит.", "Загр.%" };
                float[] colWidths = { 30, 180, 80, 60, 50, 90, 50, 60 };
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
                foreach (DataRow row in reportData.Rows)
                {
                    x = left;

                    int bookings = ConvertToInt(row["BookingCount"]) + ConvertToInt(row["CheckInCount"]);
                    int occupiedDays = ConvertToInt(row["OccupiedDays"]);
                    int totalDays = (endDate - startDate).Days + 1;
                    double occupancyPercent = totalDays > 0 ? (double)occupiedDays / totalDays * 100 : 0;
                    decimal revenue = ConvertToDecimal(row["TotalRevenue"]);

                    e.Graphics.DrawString(rank.ToString(), normalFont, Brushes.Black, x, y);
                    x += colWidths[0];

                    e.Graphics.DrawString(row["HouseName"].ToString(), normalFont, Brushes.Black, x, y);
                    x += colWidths[1];

                    e.Graphics.DrawString(row["HouseClass"].ToString(), normalFont, Brushes.Black, x, y);
                    x += colWidths[2];

                    e.Graphics.DrawString(bookings.ToString(), normalFont, Brushes.Black, x, y);
                    x += colWidths[3];

                    e.Graphics.DrawString(occupiedDays.ToString(), normalFont, Brushes.Black, x, y);
                    x += colWidths[4];

                    e.Graphics.DrawString(revenue.ToString("N0"), normalFont, Brushes.Black, x, y);
                    x += colWidths[5];

                    e.Graphics.DrawString(ConvertToDouble(row["AvgStayDays"]).ToString("N1"), normalFont, Brushes.Black, x, y);
                    x += colWidths[6];

                    e.Graphics.DrawString(occupancyPercent.ToString("N1"), normalFont, Brushes.Black, x, y);

                    y += normalFont.GetHeight() + 2;
                    rank++;

                    if (y > e.MarginBounds.Bottom - 50)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }

                // Итоги
                y = e.MarginBounds.Bottom - 40;
                e.Graphics.DrawLine(Pens.Black, left, y - 5, left + colWidths.Sum(), y - 5);

                e.Graphics.DrawString($"Всего бронирований: {labelTotalBookings.Text}", totalFont, Brushes.Black, left, y);
                e.Graphics.DrawString($"Общий доход: {labelTotalRevenue.Text} ₽", totalFont, Brushes.Black, left + 250, y);
                y += totalFont.GetHeight() + 5;

                e.Graphics.DrawString($"Средняя загрузка: {labelAvgOccupancy.Text}%", totalFont, Brushes.Black, left, y);
                e.Graphics.DrawString($"Популярный дом: {labelPopularHouse.Text}", totalFont, Brushes.Black, left + 250, y);

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка печати: {ex.Message}");
            }
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            buttonExport_Click(sender, e);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            buttonGenerate_Click(sender, e);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}