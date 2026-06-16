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

            dataGridViewOrders.CellFormatting += (s, ev) =>
            {
                if (ev.RowIndex < 0) return;
                if (dataGridViewOrders.Columns[ev.ColumnIndex].Name == "Status")
                {
                    string status = dataGridViewOrders.Rows[ev.RowIndex].Cells["Status"].Value?.ToString();
                    if (status == "Активный")
                        dataGridViewOrders.Rows[ev.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220);
                    else if (status == "Отменён")
                        dataGridViewOrders.Rows[ev.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                }
            };

            dataGridViewOrders.CellClick += (s, ev) =>
            {
                if (ev.RowIndex < 0 || ev.ColumnIndex < 0) return;
                if (dataGridViewOrders.Columns[ev.ColumnIndex].Name == "Actions")
                {
                    int id = Convert.ToInt32(dataGridViewOrders.Rows[ev.RowIndex].Cells["OrderNumber"].Value);
                    string status = dataGridViewOrders.Rows[ev.RowIndex].Cells["Status"].Value?.ToString();
                    ShowMenu(id, status, ev.RowIndex);
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
            buttonExport.Click += (s, e) => ExportExcel();
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

            dateTimePickerFrom.Value = DateTime.Today.AddMonths(-36);
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
                    string query = @"SELECT ci.order_number, ci.client_id, ci.house_id, ci.user_id, ci.house_total_price, ci.check_in_date, ci.check_out_date, ci.residence_time FROM check_in ci WHERE ci.order_number = @id";
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
                                List<ServiceItem> services = new List<ServiceItem>();
                                reader.Close();
                                string svcQuery = @"SELECT s.name_services, cis.quantity, cis.service_total_price FROM check_in_services cis JOIN services s ON cis.service_id = s.id WHERE cis.order_number = @oid";
                                using (var cmd2 = new MySqlCommand(svcQuery, conn))
                                {
                                    cmd2.Parameters.AddWithValue("@oid", orderId);
                                    using (var r2 = cmd2.ExecuteReader())
                                    {
                                        while (r2.Read())
                                            services.Add(new ServiceItem { Name = r2["name_services"].ToString(), Quantity = Convert.ToInt32(r2["quantity"]), Price = Convert.ToDecimal(r2["service_total_price"]) / Convert.ToInt32(r2["quantity"]) });
                                    }
                                }
                                ReceiptForm receiptForm = new ReceiptForm(orderId, clientId, houseId, houseTotal, services, userId, checkIn, checkOut, days);
                                PrintDocument pd = new PrintDocument();
                                pd.PrintPage += receiptForm.PrintPageHandlerPublic;
                                pd.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
                                foreach (PaperSize ps in pd.PrinterSettings.PaperSizes) if (ps.Kind == PaperKind.A4) { pd.DefaultPageSettings.PaperSize = ps; break; }
                                PrintDialog dlg = new PrintDialog { Document = pd };
                                if (dlg.ShowDialog() == DialogResult.OK) pd.Print();
                                receiptForm.Dispose();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка печати: " + ex.Message); }
        }

        private void ShowDetails(int rowIndex)
        {
            var r = dataGridViewOrders.Rows[rowIndex];
            MessageBox.Show("Заказ №" + r.Cells[0].Value + "\n\n" + r.Cells[1].Value + "\n" + r.Cells[2].Value + "\n" + r.Cells[3].Value + " — " + r.Cells[4].Value + "\n" + r.Cells[6].Value, "Детали");
        }

        private void ExportExcel()
        {
            if (ordersTable == null || ordersTable.Rows.Count == 0) { MessageBox.Show("Нет данных."); return; }
            var sfd = new SaveFileDialog { Filter = "Excel (*.xls)|*.xls", FileName = "Заказы_" + DateTime.Now.ToString("yyyy-MM-dd") };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            int totalCount = ordersTable.Rows.Count;
            int activeCount = 0, completedCount = 0, cancelledCount = 0;
            decimal totalRevenue = 0;

            foreach (DataRow row in ordersTable.Rows)
            {
                string status = row["status"]?.ToString() ?? "";
                if (status == "Активный") activeCount++;
                else if (status == "Завершён") completedCount++;
                else if (status == "Отменён") cancelledCount++;

                if (status != "Отменён")
                {
                    string totalStr = row["total"]?.ToString() ?? "0";
                    totalStr = totalStr.Replace("₽", "").Replace(" ", "").Trim();
                    decimal.TryParse(totalStr, out decimal val);
                    totalRevenue += val;
                }
            }

            try
            {
                using (var w = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                {
                    w.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    w.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
                    w.WriteLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");

                    w.WriteLine("<Styles>");
                    w.WriteLine("<Style ss:ID=\"Title\"><Font ss:FontName=\"Segoe UI\" ss:Size=\"14\" ss:Bold=\"1\" ss:Color=\"#4C91C3\"/></Style>");
                    w.WriteLine("<Style ss:ID=\"SubTitle\"><Font ss:FontName=\"Segoe UI\" ss:Size=\"10\" ss:Color=\"#666666\"/></Style>");
                    w.WriteLine("<Style ss:ID=\"Summary\"><Font ss:FontName=\"Segoe UI\" ss:Size=\"10\" ss:Bold=\"1\"/><Interior ss:Color=\"#F5F5F5\" ss:Pattern=\"Solid\"/><Borders><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#CCCCCC\"/><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#CCCCCC\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#CCCCCC\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#CCCCCC\"/></Borders></Style>");
                    w.WriteLine("<Style ss:ID=\"H\"><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Center\"/><Font ss:FontName=\"Segoe UI\" ss:Size=\"11\" ss:Bold=\"1\" ss:Color=\"#FFFFFF\"/><Interior ss:Color=\"#4C91C3\" ss:Pattern=\"Solid\"/><Borders><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#4C91C3\"/><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"2\" ss:Color=\"#4C91C3\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#4C91C3\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#4C91C3\"/></Borders></Style>");
                    w.WriteLine("<Style ss:ID=\"A\"><Interior ss:Color=\"#DCFFDC\" ss:Pattern=\"Solid\"/><Borders><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/></Borders></Style>");
                    w.WriteLine("<Style ss:ID=\"C\"><Interior ss:Color=\"#FFDCDC\" ss:Pattern=\"Solid\"/><Borders><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/></Borders></Style>");
                    w.WriteLine("<Style ss:ID=\"D\"><Interior ss:Color=\"#F0F0F0\" ss:Pattern=\"Solid\"/><Borders><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/></Borders></Style>");
                    w.WriteLine("<Style ss:ID=\"N\"><Alignment ss:Vertical=\"Center\"/><Font ss:FontName=\"Segoe UI\" ss:Size=\"10\"/><Borders><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#C0C0C0\"/></Borders></Style>");
                    w.WriteLine("</Styles>");

                    w.WriteLine("<Worksheet ss:Name=\"Заказы\"><Table>");
                    w.WriteLine("<Column ss:Width=\"70\"/><Column ss:Width=\"200\"/><Column ss:Width=\"170\"/><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Column ss:Width=\"70\"/><Column ss:Width=\"130\"/><Column ss:Width=\"120\"/>");

                    w.WriteLine($"<Row ss:Height=\"30\"><Cell ss:StyleID=\"Title\" ss:MergeAcross=\"7\"><Data ss:Type=\"String\">ОТЧЁТ ПО ЗАКАЗАМ</Data></Cell></Row>");
                    w.WriteLine($"<Row ss:Height=\"20\"><Cell ss:StyleID=\"SubTitle\" ss:MergeAcross=\"7\"><Data ss:Type=\"String\">Период: {dateTimePickerFrom.Value:dd.MM.yyyy} — {dateTimePickerTo.Value:dd.MM.yyyy}</Data></Cell></Row>");
                    w.WriteLine($"<Row ss:Height=\"20\"><Cell ss:StyleID=\"SubTitle\" ss:MergeAcross=\"7\"><Data ss:Type=\"String\">Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}</Data></Cell></Row>");
                    w.WriteLine("<Row ss:Height=\"10\"><Cell ss:MergeAcross=\"7\"></Cell></Row>");

                    w.WriteLine("<Row ss:Height=\"25\">");
                    w.WriteLine($"<Cell ss:StyleID=\"Summary\"><Data ss:Type=\"String\">ВСЕГО ЗАКАЗОВ</Data></Cell>");
                    w.WriteLine($"<Cell ss:StyleID=\"Summary\"><Data ss:Type=\"Number\">{totalCount}</Data></Cell>");
                    w.WriteLine($"<Cell ss:StyleID=\"Summary\"><Data ss:Type=\"String\">Активных</Data></Cell>");
                    w.WriteLine($"<Cell ss:StyleID=\"Summary\"><Data ss:Type=\"Number\">{activeCount}</Data></Cell>");
                    w.WriteLine($"<Cell ss:StyleID=\"Summary\"><Data ss:Type=\"String\">Завершённых</Data></Cell>");
                    w.WriteLine($"<Cell ss:StyleID=\"Summary\"><Data ss:Type=\"Number\">{completedCount}</Data></Cell>");
                    w.WriteLine($"<Cell ss:StyleID=\"Summary\"><Data ss:Type=\"String\">Отменённых</Data></Cell>");
                    w.WriteLine($"<Cell ss:StyleID=\"Summary\"><Data ss:Type=\"Number\">{cancelledCount}</Data></Cell>");
                    w.WriteLine("</Row>");
                    w.WriteLine("<Row ss:Height=\"25\">");
                    w.WriteLine($"<Cell ss:StyleID=\"Summary\"><Data ss:Type=\"String\">ОБЩАЯ ВЫРУЧКА</Data></Cell>");
                    w.WriteLine($"<Cell ss:StyleID=\"Summary\" ss:MergeAcross=\"6\"><Data ss:Type=\"String\">{totalRevenue.ToString("N2")} ₽</Data></Cell>");
                    w.WriteLine("</Row>");
                    w.WriteLine("<Row ss:Height=\"10\"><Cell ss:MergeAcross=\"7\"></Cell></Row>");

                    w.WriteLine("<Row ss:Height=\"40\">");
                    string[] headers = { "№ заказа", "Клиент", "Дом", "Заезд", "Выезд", "Дней", "Сумма", "Статус" };
                    foreach (string h in headers) w.WriteLine($"<Cell ss:StyleID=\"H\"><Data ss:Type=\"String\">{EscapeXml(h)}</Data></Cell>");
                    w.WriteLine("</Row>");

                    foreach (DataRow row in ordersTable.Rows)
                    {
                        string status = row["status"]?.ToString() ?? "";
                        string style = status == "Активный" ? "A" : status == "Отменён" ? "C" : status == "Завершён" ? "D" : "N";
                        w.WriteLine($"<Row ss:Height=\"30\">");
                        foreach (DataColumn col in ordersTable.Columns)
                        {
                            string val = row[col]?.ToString() ?? "";
                            w.WriteLine($"<Cell ss:StyleID=\"{style}\"><Data ss:Type=\"String\">{EscapeXml(val)}</Data></Cell>");
                        }
                        w.WriteLine("</Row>");
                    }

                    w.WriteLine("</Table></Worksheet></Workbook>");
                }
                MessageBox.Show("Экспортировано в Excel!\n" + sfd.FileName, "Готово");
                System.Diagnostics.Process.Start(sfd.FileName);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private string EscapeXml(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
        }

        private void Exec(string q, int id) { using (var c = DatabaseConnection.GetConnection()) { c.Open(); using (var cmd = new MySqlCommand(q, c)) { cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery(); } } }
    }
}