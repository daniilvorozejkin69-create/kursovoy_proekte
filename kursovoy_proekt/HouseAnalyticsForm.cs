using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public partial class HouseAnalyticsForm : Form
    {
        private int selectedHouseId = 0;

        public HouseAnalyticsForm()
        {
            InitializeComponent();
            SetupCardControls();
            LoadData();
        }

        private void SetupCardControls()
        {
            // Создаём всё внутри panelHouseCard
            panelHouseCard.Controls.Clear();

            labelHouseName = new Label
            {
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(15, 10),
                Size = new Size(260, 35),
                TextAlign = ContentAlignment.MiddleCenter
            };

            labelHouseClass = new Label
            {
                Font = new Font("Segoe UI Semibold", 11),
                ForeColor = Color.FromArgb(76, 145, 195),
                Location = new Point(15, 50),
                Size = new Size(260, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };

            labelPopularity = new Label
            {
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(15, 85),
                Size = new Size(260, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Разделитель
            Panel line = new Panel
            {
                BackColor = Color.FromArgb(200, 200, 200),
                Location = new Point(30, 120),
                Size = new Size(230, 1)
            };

            // Метрики
            labelHouseCapacity = CreateMetricLabel("👥 Вместимость:", 130);
            labelTotalBookings = CreateMetricLabel("📋 Броней:", 160);
            labelAvgStay = CreateMetricLabel("📅 Среднее проживание:", 190);
            labelTotalRevenue = CreateMetricLabel("💰 Доход:", 220);
            labelUniqueClients = CreateMetricLabel("👤 Клиентов:", 250);
            labelOccupancyRate = CreateMetricLabel("📊 Загрузка:", 280);

            // Кнопка
            buttonDetails = new Button
            {
                Text = "📋 Кто арендовал",
                Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(76, 145, 195),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(35, 325),
                Size = new Size(220, 35),
                Cursor = Cursors.Hand
            };
            buttonDetails.FlatAppearance.BorderSize = 0;
            buttonDetails.Click += buttonDetails_Click;

            // График спроса
            Label lblDemand = new Label
            {
                Text = "Спрос по месяцам:",
                Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold),
                Location = new Point(15, 375),
                Size = new Size(200, 20)
            };

            chartDemand = new Chart
            {
                Location = new Point(15, 400),
                Size = new Size(260, 210),
                BackColor = Color.White
            };

            ChartArea demandArea = new ChartArea("Demand");
            demandArea.BackColor = Color.White;
            demandArea.AxisX.MajorGrid.Enabled = false;
            demandArea.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            demandArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 7);
            demandArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 7);
            chartDemand.ChartAreas.Add(demandArea);

            panelHouseCard.Controls.AddRange(new Control[] {
                labelHouseName, labelHouseClass, labelPopularity, line,
                labelHouseCapacity, labelTotalBookings, labelAvgStay,
                labelTotalRevenue, labelUniqueClients, labelOccupancyRate,
                buttonDetails, lblDemand, chartDemand
            });
        }

        private Label CreateMetricLabel(string title, int y)
        {
            Label lbl = new Label
            {
                Text = $"{title} -",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(15, y),
                Size = new Size(260, 25)
            };
            return lbl;
        }

        private void buttonApplyFilter_Click(object sender, EventArgs e) => LoadData();
        private void buttonResetFilter_Click(object sender, EventArgs e)
        {
            comboBoxClass.SelectedIndex = 0;
            dateTimePickerFrom.Value = DateTime.Today.AddMonths(-6);
            dateTimePickerTo.Value = DateTime.Today;
            LoadData();
        }

        private void listBoxHouses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxHouses.SelectedItem is HouseSummary house)
            {
                selectedHouseId = house.Id;
                LoadHouseDetail(house.Id);
                LoadDemandChart(house.Id);
            }
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (selectedHouseId > 0 && labelHouseName != null)
            {
                HouseClientsForm form = new HouseClientsForm(
                    selectedHouseId,
                    labelHouseName.Text,
                    dateTimePickerFrom.Value,
                    dateTimePickerTo.Value);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Сначала выберите дом из списка.", "Внимание");
            }
        }

        private void LoadData()
        {
            listBoxHouses.Items.Clear();
            chartMain.Series.Clear();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string classFilter = comboBoxClass.SelectedIndex > 0 ? " AND hc.class = @class" : "";
                    string query = $@"
                        SELECT h.id, h.name, hc.class, 
                               COUNT(ci.order_number) AS bookings,
                               COALESCE(SUM(ci.house_total_price), 0) AS revenue
                        FROM house h
                        JOIN home_class hc ON h.home_class_id = hc.id
                        LEFT JOIN check_in ci ON h.id = ci.house_id 
                            AND ci.check_in_date BETWEEN @from AND @to
                        WHERE 1=1 {classFilter}
                        GROUP BY h.id, h.name, hc.class
                        ORDER BY bookings DESC";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@from", dateTimePickerFrom.Value);
                        cmd.Parameters.AddWithValue("@to", dateTimePickerTo.Value);
                        if (comboBoxClass.SelectedIndex > 0)
                            cmd.Parameters.AddWithValue("@class", comboBoxClass.Text);

                        Series barSeries = new Series("Брони")
                        {
                            ChartType = SeriesChartType.Column,
                            Color = Color.FromArgb(106, 153, 85),
                            BorderWidth = 1
                        };

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader.GetString("name");
                                int bookings = reader.GetInt32("bookings");
                                decimal revenue = reader.GetDecimal("revenue");

                                listBoxHouses.Items.Add(new HouseSummary
                                {
                                    Id = reader.GetInt32("id"),
                                    Name = name,
                                    Class = reader.GetString("class"),
                                    Bookings = bookings,
                                    Revenue = revenue
                                });

                                barSeries.Points.AddXY(name, bookings);
                            }
                        }

                        chartMain.Series.Add(barSeries);
                        chartMain.ChartAreas[0].AxisX.Interval = 1;
                        chartMain.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                        chartMain.ChartAreas[0].AxisY.Title = "Бронирований";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void LoadHouseDetail(int houseId)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT h.name, hc.class, h.capacity,
                               COUNT(DISTINCT ci.order_number) AS bookings,
                               ROUND(AVG(ci.residence_time), 1) AS avg_stay,
                               COALESCE(SUM(ci.house_total_price), 0) + 
                               COALESCE(SUM(cis.service_total_price), 0) AS total_revenue,
                               COUNT(DISTINCT ci.client_id) AS clients
                        FROM house h
                        JOIN home_class hc ON h.home_class_id = hc.id
                        LEFT JOIN check_in ci ON h.id = ci.house_id 
                            AND ci.check_in_date BETWEEN @from AND @to
                        LEFT JOIN check_in_services cis ON ci.order_number = cis.order_number
                        WHERE h.id = @id
                        GROUP BY h.name, hc.class, h.capacity";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", houseId);
                        cmd.Parameters.AddWithValue("@from", dateTimePickerFrom.Value);
                        cmd.Parameters.AddWithValue("@to", dateTimePickerTo.Value);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                labelHouseName.Text = reader["name"].ToString();
                                labelHouseClass.Text = $"⭐ {reader["class"]}";

                                int bookings = Convert.ToInt32(reader["bookings"]);
                                labelHouseCapacity.Text = $"👥 Вместимость: {reader["capacity"]} чел.";
                                labelTotalBookings.Text = $"📋 Броней: {bookings}";
                                labelAvgStay.Text = $"📅 Среднее: {reader["avg_stay"]} дн.";

                                decimal totalRev = Convert.ToDecimal(reader["total_revenue"]);
                                labelTotalRevenue.Text = $"💰 Доход: {totalRev:N0} ₽";
                                labelUniqueClients.Text = $"👤 Клиентов: {reader["clients"]}";

                                decimal occupancy = bookings > 0 ? Math.Min(100, Math.Round(bookings * 100m / 180m, 1)) : 0;
                                labelOccupancyRate.Text = $"📊 Загрузка: {occupancy}%";

                                labelPopularity.Text = bookings > 10 ? "🔥 Высокий спрос" :
                                                       bookings > 5 ? "⭐ Средний спрос" :
                                                       bookings > 0 ? "📊 Низкий спрос" : "❌ Нет броней";
                                labelPopularity.ForeColor = bookings > 5 ? Color.FromArgb(106, 153, 85) : Color.FromArgb(200, 80, 80);

                                panelHouseCard.Visible = true;
                                labelCardTitle.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void LoadDemandChart(int houseId)
        {
            chartDemand.Series.Clear();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT DATE_FORMAT(ci.check_in_date, '%Y-%m') AS month,
                               COUNT(ci.order_number) AS bookings
                        FROM check_in ci
                        WHERE ci.house_id = @id
                          AND ci.check_in_date BETWEEN @from AND @to
                        GROUP BY DATE_FORMAT(ci.check_in_date, '%Y-%m')
                        ORDER BY month";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", houseId);
                        cmd.Parameters.AddWithValue("@from", dateTimePickerFrom.Value);
                        cmd.Parameters.AddWithValue("@to", dateTimePickerTo.Value);

                        Series lineSeries = new Series("Брони")
                        {
                            ChartType = SeriesChartType.Spline,
                            Color = Color.FromArgb(76, 145, 195),
                            BorderWidth = 3,
                            MarkerStyle = MarkerStyle.Circle,
                            MarkerSize = 8,
                            MarkerColor = Color.FromArgb(76, 145, 195)
                        };

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string month = Convert.ToDateTime(reader["month"] + "-01").ToString("MMM yy");
                                int bookings = reader.GetInt32("bookings");
                                lineSeries.Points.AddXY(month, bookings);
                            }
                        }

                        chartDemand.Series.Add(lineSeries);
                    }
                }
            }
            catch { }
        }

        private class HouseSummary
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }
            public int Bookings { get; set; }
            public decimal Revenue { get; set; }
            public override string ToString() => $"{Name} ({Bookings} бр.)";
        }
    }

    // ===== ФОРМА "КТО АРЕНДОВАЛ" (КРАСИВАЯ) =====
    public class HouseClientsForm : Form
    {
        public HouseClientsForm(int houseId, string houseName, DateTime from, DateTime to)
        {
            this.Text = $"Гости: {houseName}";
            this.Size = new Size(820, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(240, 245, 235);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Заголовок
            Panel panelTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(76, 145, 195)
            };

            Label lblTitle = new Label
            {
                Text = $"📋 Кто арендовал «{houseName}»",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblPeriod = new Label
            {
                Text = $"{from:dd.MM.yyyy} — {to:dd.MM.yyyy}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(220, 235, 255),
                Location = new Point(20, 45),
                AutoSize = true
            };
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(lblPeriod);

            // Таблица
            DataGridView dgv = new DataGridView
            {
                Location = new Point(15, 85),
                Size = new Size(775, 330),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                ColumnHeadersHeight = 40,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(76, 145, 195),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9.5F),
                    SelectionBackColor = Color.FromArgb(220, 235, 210)
                }
            };

            dgv.Columns.Add("FIO", "Гость");
            dgv.Columns.Add("Passport", "Паспорт");
            dgv.Columns.Add("CheckIn", "Заезд");
            dgv.Columns.Add("CheckOut", "Выезд");
            dgv.Columns.Add("Days", "Дней");
            dgv.Columns.Add("Amount", "Сумма");

            dgv.Columns["FIO"].Width = 200;
            dgv.Columns["Passport"].Width = 130;
            dgv.Columns["CheckIn"].Width = 100;
            dgv.Columns["CheckOut"].Width = 100;
            dgv.Columns["Days"].Width = 60;
            dgv.Columns["Amount"].Width = 110;
            dgv.Columns["Amount"].DefaultCellStyle.Format = "N0 ₽";

            // Загрузка данных
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string q = @"SELECT c.FIO, c.passport_series_number, 
                                ci.check_in_date, ci.check_out_date, 
                                ci.residence_time, ci.house_total_price
                        FROM check_in ci 
                        JOIN client c ON ci.client_id = c.id
                        WHERE ci.house_id = @id 
                          AND ci.check_in_date BETWEEN @from AND @to 
                        ORDER BY ci.check_in_date DESC";
                    using (var cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", houseId);
                        cmd.Parameters.AddWithValue("@from", from);
                        cmd.Parameters.AddWithValue("@to", to);
                        using (var r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                dgv.Rows.Add(
                                    r["FIO"].ToString(),
                                    r["passport_series_number"].ToString(),
                                    Convert.ToDateTime(r["check_in_date"]).ToString("dd.MM.yyyy"),
                                    Convert.ToDateTime(r["check_out_date"]).ToString("dd.MM.yyyy"),
                                    r["residence_time"].ToString(),
                                    Convert.ToDecimal(r["house_total_price"])
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

            // Кнопка закрыть
            Button btnClose = new Button
            {
                Text = "Закрыть",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(76, 145, 195),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(660, 425),
                Size = new Size(130, 35)
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, ev) => Close();

            this.Controls.AddRange(new Control[] { panelTop, dgv, btnClose });
        }
    }
}