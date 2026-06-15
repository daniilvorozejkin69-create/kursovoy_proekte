using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class OrdersViewForm : Form
    {
        private DataTable ordersTable;

        public OrdersViewForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupGridView();
            LoadFilters();
            BindEvents();
            LoadData();
        }

        private void SetupGridView()
        {
            dataGridViewOrders.AutoGenerateColumns = false;
            dataGridViewOrders.Columns.Clear();

            dataGridViewOrders.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn { Name = "OrderNumber", HeaderText = "№", DataPropertyName = "order_number", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
                new DataGridViewTextBoxColumn { Name = "Client", HeaderText = "Клиент", DataPropertyName = "client_name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, MinimumWidth = 150 },
                new DataGridViewTextBoxColumn { Name = "House", HeaderText = "Дом", DataPropertyName = "house_name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, MinimumWidth = 120 },
                new DataGridViewTextBoxColumn { Name = "CheckIn", HeaderText = "Заезд", DataPropertyName = "check_in", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
                new DataGridViewTextBoxColumn { Name = "CheckOut", HeaderText = "Выезд", DataPropertyName = "check_out", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
                new DataGridViewTextBoxColumn { Name = "Days", HeaderText = "Дней", DataPropertyName = "days", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
                new DataGridViewTextBoxColumn { Name = "TotalPrice", HeaderText = "Сумма", DataPropertyName = "total", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
                new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Статус", DataPropertyName = "status", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells },
                new DataGridViewButtonColumn { Name = "Actions", HeaderText = "", Text = "⚙", Width = 40, UseColumnTextForButtonValue = true }
            });

            dataGridViewOrders.CellFormatting += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                if (dataGridViewOrders.Columns[e.ColumnIndex].Name == "Status")
                {
                    string status = dataGridViewOrders.Rows[e.RowIndex].Cells["Status"].Value?.ToString();
                    if (status == "Активный")
                        dataGridViewOrders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220);
                    else if (status == "Отменён")
                        dataGridViewOrders.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                }
            };

            dataGridViewOrders.CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                if (dataGridViewOrders.Columns[e.ColumnIndex].Name == "Actions")
                {
                    int id = Convert.ToInt32(dataGridViewOrders.Rows[e.RowIndex].Cells["OrderNumber"].Value);
                    string status = dataGridViewOrders.Rows[e.RowIndex].Cells["Status"].Value?.ToString();
                    ShowMenu(id, status, e.RowIndex);
                }
            };
        }

        private void ShowMenu(int id, string status, int rowIndex)
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("📋 Детали", null, (s, e) => ShowDetails(rowIndex));
            if (status == "Активный") menu.Items.Add("✅ Завершить", null, (s, e) => CompleteOrder(id));
            if (status != "Отменён") menu.Items.Add("❌ Отменить", null, (s, e) => CancelOrder(id));
            menu.Items.Add("🖨 Печать", null, (s, e) => PrintOrder(id));
            var rect = dataGridViewOrders.GetCellDisplayRectangle(dataGridViewOrders.Columns["Actions"].Index, rowIndex, false);
            menu.Show(dataGridViewOrders, rect.Left, rect.Bottom);
        }

        private void BindEvents()
        {
            buttonApplyFilter.Click += (s, e) => LoadData();
            buttonClearFilter.Click += (s, e) => { comboBoxStatusFilter.SelectedIndex = 0; comboBoxHouseFilter.SelectedIndex = 0; dateTimePickerFrom.Value = DateTime.Today.AddMonths(-1); dateTimePickerTo.Value = DateTime.Today; textBoxSearch.Clear(); LoadData(); };
            buttonRefresh.Click += (s, e) => LoadData();
            buttonBackToMenu.Click += (s, e) => Close();
            buttonExport.Click += (s, e) => ExportCSV();
        }

        private void LoadFilters()
        {
            comboBoxStatusFilter.Items.Clear();
            comboBoxStatusFilter.Items.AddRange(new object[] { "Все", "Активные", "Завершённые", "Отменённые" });
            comboBoxStatusFilter.SelectedIndex = 0;

            comboBoxHouseFilter.Items.Clear();
            comboBoxHouseFilter.Items.Add("Все дома");
            comboBoxHouseFilter.SelectedIndex = 0;

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("SELECT name FROM house ORDER BY name", conn))
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) comboBoxHouseFilter.Items.Add(r.GetString("name"));
                }
            }
            catch { }

            dateTimePickerFrom.Value = DateTime.Today.AddMonths(-1);
            dateTimePickerTo.Value = DateTime.Today;
        }

        private void LoadData()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT ci.order_number, c.FIO AS client_name, h.name AS house_name, DATE_FORMAT(ci.check_in_date,'%d.%m.%Y') AS check_in, DATE_FORMAT(ci.check_out_date,'%d.%m.%Y') AS check_out, ci.residence_time AS days, CONCAT(FORMAT(ci.house_total_price+COALESCE(SUM(cis.service_total_price),0),2),' ₽') AS total, CASE WHEN ci.tag LIKE '%Отменён%' THEN 'Отменён' WHEN ci.tag LIKE '%Выселен%' OR ci.check_out_date<CURDATE() THEN 'Завершён' ELSE 'Активный' END AS status FROM check_in ci JOIN client c ON ci.client_id=c.id JOIN house h ON ci.house_id=h.id LEFT JOIN check_in_services cis ON ci.order_number=cis.order_number WHERE ci.check_in_date BETWEEN @d1 AND @d2";
                    if (comboBoxStatusFilter.SelectedIndex == 1) sql += " AND ci.check_out_date>=CURDATE() AND ci.tag NOT LIKE '%Отменён%' AND ci.tag NOT LIKE '%Выселен%'";
                    else if (comboBoxStatusFilter.SelectedIndex == 2) sql += " AND (ci.check_out_date<CURDATE() OR ci.tag LIKE '%Выселен%') AND ci.tag NOT LIKE '%Отменён%'";
                    else if (comboBoxStatusFilter.SelectedIndex == 3) sql += " AND ci.tag LIKE '%Отменён%'";
                    if (comboBoxHouseFilter.SelectedIndex > 0) sql += " AND h.name=@h";
                    if (!string.IsNullOrWhiteSpace(textBoxSearch.Text) && textBoxSearch.Text != "🔍 Поиск по клиенту...") sql += " AND c.FIO LIKE @s";
                    sql += " GROUP BY ci.order_number ORDER BY ci.check_in_date DESC";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@d1", dateTimePickerFrom.Value.Date);
                        cmd.Parameters.AddWithValue("@d2", dateTimePickerTo.Value.Date.AddDays(1));
                        if (comboBoxHouseFilter.SelectedIndex > 0) cmd.Parameters.AddWithValue("@h", comboBoxHouseFilter.Text);
                        if (!string.IsNullOrWhiteSpace(textBoxSearch.Text) && textBoxSearch.Text != "🔍 Поиск по клиенту...") cmd.Parameters.AddWithValue("@s", "%" + textBoxSearch.Text + "%");
                        ordersTable = new DataTable();
                        new MySqlDataAdapter(cmd).Fill(ordersTable);
                        dataGridViewOrders.DataSource = ordersTable;
                    }
                    labelStatistics.Text = "Заказов: " + ordersTable.Rows.Count;
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void CompleteOrder(int id) { if (MessageBox.Show("Завершить?", "", MessageBoxButtons.YesNo) != DialogResult.Yes) return; Exec("UPDATE check_in SET tag=CONCAT(IFNULL(tag,''),' | Выселен ',CURDATE()),check_out_date=CURDATE(),residence_time=DATEDIFF(CURDATE(),check_in_date) WHERE order_number=@id", id); LoadData(); }
        private void CancelOrder(int id) { if (MessageBox.Show("Отменить?", "", MessageBoxButtons.YesNo) != DialogResult.Yes) return; Exec("UPDATE check_in SET tag=CONCAT(IFNULL(tag,''),' | Отменён ',CURDATE()) WHERE order_number=@id", id); LoadData(); }
        private void PrintOrder(int orderNumber)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT ci.order_number, ci.client_id, ci.house_id, ci.user_id,
                       ci.house_total_price, ci.check_in_date, ci.check_out_date,
                       ci.residence_time
                FROM check_in ci
                WHERE ci.order_number = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", orderNumber);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int orderId = reader.GetInt32("order_number");
                                int clientId = reader.GetInt32("client_id");
                                int houseId = reader.GetInt32("house_id");
                                int userId = reader.GetInt32("user_id");
                                decimal houseTotal = reader.GetDecimal("house_total_price");
                                DateTime checkIn = reader.GetDateTime("check_in_date");
                                DateTime checkOut = reader.GetDateTime("check_out_date");
                                int days = reader.GetInt32("residence_time");

                                // Загружаем услуги
                                List<ServiceItem> services = new List<ServiceItem>();
                                reader.Close();

                                string svcQuery = @"SELECT s.name_services, cis.quantity, cis.service_total_price
                                           FROM check_in_services cis
                                           JOIN services s ON cis.service_id = s.id
                                           WHERE cis.order_number = @oid";
                                using (var cmd2 = new MySqlCommand(svcQuery, conn))
                                {
                                    cmd2.Parameters.AddWithValue("@oid", orderId);
                                    using (var r2 = cmd2.ExecuteReader())
                                    {
                                        while (r2.Read())
                                        {
                                            services.Add(new ServiceItem
                                            {
                                                Name = r2["name_services"].ToString(),
                                                Quantity = Convert.ToInt32(r2["quantity"]),
                                                Price = Convert.ToDecimal(r2["service_total_price"]) / Convert.ToInt32(r2["quantity"])
                                            });
                                        }
                                    }
                                }

                                // Открываем форму договора с печатью
                                ReceiptForm receiptForm = new ReceiptForm(
                                    orderId, clientId, houseId, houseTotal,
                                    services, userId, checkIn, checkOut, days);

                                // Сразу печатаем без показа формы
                                PrintDocument pd = new PrintDocument();
                                pd.PrintPage += receiptForm.PrintPageHandlerPublic;
                                pd.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

                                foreach (PaperSize ps in pd.PrinterSettings.PaperSizes)
                                    if (ps.Kind == PaperKind.A4) { pd.DefaultPageSettings.PaperSize = ps; break; }

                                PrintDialog dlg = new PrintDialog { Document = pd };
                                if (dlg.ShowDialog() == DialogResult.OK)
                                {
                                    pd.Print();
                                }

                                receiptForm.Dispose();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка печати договора: " + ex.Message, "Ошибка");
            }
        }
        private void ShowDetails(int rowIndex)
        {
            var r = dataGridViewOrders.Rows[rowIndex];
            MessageBox.Show("Заказ №" + r.Cells[0].Value + "\n\n" + r.Cells[1].Value + "\n" + r.Cells[2].Value + "\n" + r.Cells[3].Value + " — " + r.Cells[4].Value + "\n" + r.Cells[6].Value, "Детали");
        }

        private void ExportCSV()
        {
            if (ordersTable == null || ordersTable.Rows.Count == 0) { MessageBox.Show("Нет данных."); return; }
            var sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "Заказы_" + DateTime.Now.ToString("yyyy-MM-dd") };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            using (var w = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
            {
                var cols = new System.Collections.Generic.List<string>(); foreach (DataColumn c in ordersTable.Columns) cols.Add(c.ColumnName);
                w.WriteLine(string.Join(";", cols));
                foreach (DataRow row in ordersTable.Rows) { var vals = new System.Collections.Generic.List<string>(); foreach (DataColumn c in ordersTable.Columns) vals.Add(row[c]?.ToString() ?? ""); w.WriteLine(string.Join(";", vals)); }
            }
            MessageBox.Show("Экспортировано!");
        }

        private void Exec(string q, int id) { using (var c = DatabaseConnection.GetConnection()) { c.Open(); using (var cmd = new MySqlCommand(q, c)) { cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery(); } } }
    }
}