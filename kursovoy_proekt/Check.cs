using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class Check : Form
    {
        private decimal houseDailyPrice = 0;
        private int stayDays = 1;
        private decimal totalPrice = 0;
        private decimal discountAmount = 0;
        private List<ServiceItem> selectedServices = new List<ServiceItem>();
        private DataTable activeBookingsTable;
        private const int MAX_BOOKING_MONTHS_AHEAD = 12;
        private const int MAX_STAY_DAYS = 90;

        public Check()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            dateTimePickerCheckIn.MinDate = DateTime.Today;
            dateTimePickerCheckIn.MaxDate = DateTime.Today.AddMonths(MAX_BOOKING_MONTHS_AHEAD);
            dateTimePickerCheckIn.Value = DateTime.Today;

            dateTimePickerCheckOut.MinDate = DateTime.Today.AddDays(1);
            dateTimePickerCheckOut.MaxDate = DateTime.Today.AddMonths(MAX_BOOKING_MONTHS_AHEAD).AddDays(MAX_STAY_DAYS);
            dateTimePickerCheckOut.Value = DateTime.Today.AddDays(1);

            SetupDataGridViewColumns();

            buttonAddService.Click += buttonAddService_Click;
            buttonRemoveService.Click += buttonRemoveService_Click;
            buttonClearServices.Click += buttonClearServices_Click;
            dateTimePickerCheckIn.ValueChanged += dateTimePickerCheckIn_ValueChanged;
            dateTimePickerCheckOut.ValueChanged += dateTimePickerCheckOut_ValueChanged;
            comboBoxHouses.SelectedIndexChanged += comboBoxHouses_SelectedIndexChanged;
            comboBoxDiscount.SelectedIndexChanged += comboBoxDiscount_SelectedIndexChanged;
            buttonLoadBooking.Click += buttonLoadBooking_Click;
            buttonCreateOrder.Click += buttonCreateOrder_Click;
            buttonBackToMenu.Click += buttonBackToMenu_Click;
            listBoxServices.DoubleClick += listBoxServices_DoubleClick;
            listBoxServices.SelectedIndexChanged += listBoxServices_SelectedIndexChanged;

            LoadFormData();
            UpdateTotalPrice();
        }

        private void SetupDataGridViewColumns()
        {
            if (dataGridViewServices == null) return;
            dataGridViewServices.CellClick -= DataGridViewServices_CellClick;
            dataGridViewServices.Columns.Clear();

            dataGridViewServices.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Услуга", Width = 220, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Кол-во", Width = 60, ReadOnly = true },
                new DataGridViewButtonColumn { Name = "Decrease", Text = "−", Width = 35, UseColumnTextForButtonValue = true },
                new DataGridViewButtonColumn { Name = "Increase", Text = "+", Width = 35, UseColumnTextForButtonValue = true },
                new DataGridViewTextBoxColumn { Name = "UnitPrice", HeaderText = "Цена", Width = 90, ReadOnly = true, DefaultCellStyle = { Format = "N2" } },
                new DataGridViewTextBoxColumn { Name = "TotalPrice", HeaderText = "Сумма", Width = 100, ReadOnly = true, DefaultCellStyle = { Format = "N2" } }
            );
            dataGridViewServices.CellClick += DataGridViewServices_CellClick;
        }

        private void DataGridViewServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.RowIndex >= selectedServices.Count) return;
            var service = selectedServices[e.RowIndex];
            string colName = dataGridViewServices.Columns[e.ColumnIndex].Name;

            if (colName == "Decrease" && service.Quantity > 1) service.Quantity--;
            else if (colName == "Increase" && service.Quantity < 100) service.Quantity++;

            UpdateServicesGrid();
            UpdateTotalPrice();
        }

        private void LoadFormData()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    LoadClients(connection);
                    LoadHouses(connection);
                    LoadServices(connection);
                    LoadActiveBookings(connection);
                    LoadDiscounts(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void LoadClients(MySqlConnection conn)
        {
            string query = "SELECT id, FIO, passport_series_number FROM client ORDER BY FIO";
            using (var cmd = new MySqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                comboBoxClients.Items.Clear();
                while (reader.Read())
                    comboBoxClients.Items.Add(new ClientData
                    {
                        Id = reader.GetInt32("id"),
                        FIO = reader.GetString("FIO"),
                        Passport = reader.GetString("passport_series_number")
                    });
                if (comboBoxClients.Items.Count > 0) comboBoxClients.SelectedIndex = 0;
            }
        }

        private void LoadHouses(MySqlConnection conn)
        {
            string query = @"SELECT h.id, h.name, hc.class, h.capacity,
                CASE hc.class WHEN 'Эконом' THEN 2000 WHEN 'Комфорт' THEN 3500 
                WHEN 'Люкс' THEN 6000 WHEN 'Премиум' THEN 9000 WHEN 'Бизнес' THEN 7000 
                ELSE 3000 END AS price
                FROM house h JOIN home_class hc ON h.home_class_id = hc.id ORDER BY h.name";
            using (var cmd = new MySqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                comboBoxHouses.Items.Clear();
                while (reader.Read())
                    comboBoxHouses.Items.Add(new HouseData
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        Class = reader.GetString("class"),
                        Capacity = reader.GetInt32("capacity"),
                        PricePerDay = reader.GetDecimal("price")
                    });
                if (comboBoxHouses.Items.Count > 0) comboBoxHouses.SelectedIndex = 0;
            }
        }

        private void LoadServices(MySqlConnection conn)
        {
            string query = "SELECT id, name_services, price, description, duration FROM services ORDER BY name_services";
            using (var cmd = new MySqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                listBoxServices.Items.Clear();
                while (reader.Read())
                    listBoxServices.Items.Add(new ServiceItem
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name_services"),
                        Price = reader.GetDecimal("price"),
                        Description = reader["description"]?.ToString() ?? "",
                        Duration = reader.GetInt32("duration")
                    });
            }
        }

        private void LoadActiveBookings(MySqlConnection conn)
        {
            string query = @"SELECT b.id, c.FIO, h.name, b.check_in_date, b.check_out_date
                FROM booking b JOIN client c ON b.client_id = c.id 
                JOIN house h ON b.house_id = h.id
                WHERE b.status = 'confirmed' AND b.check_in_date >= CURDATE() 
                ORDER BY b.check_in_date";
            using (var cmd = new MySqlCommand(query, conn))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                activeBookingsTable = new DataTable();
                adapter.Fill(activeBookingsTable);
            }
            comboBoxBookings.Items.Clear();
            foreach (DataRow row in activeBookingsTable.Rows)
                comboBoxBookings.Items.Add(new BookingItem
                {
                    Id = Convert.ToInt32(row["id"]),
                    ClientName = row["FIO"].ToString(),
                    HouseName = row["name"].ToString(),
                    CheckInDate = Convert.ToDateTime(row["check_in_date"]),
                    DisplayText = $"№{row["id"]} - {row["FIO"]} - {row["name"]} - {Convert.ToDateTime(row["check_in_date"]):dd.MM.yyyy}"
                });
        }

        private void LoadDiscounts(MySqlConnection conn)
        {
            string query = "SELECT id, name, percent, type, min_days, description FROM discounts WHERE is_active = 1 ORDER BY name";
            using (var cmd = new MySqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                comboBoxDiscount.Items.Clear();
                comboBoxDiscount.Items.Add(new DiscountData { Id = 0, Name = "Без скидки", Percent = 0, MinDays = 0, Description = "" });
                while (reader.Read())
                    comboBoxDiscount.Items.Add(new DiscountData
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name"),
                        Percent = reader.GetDecimal("percent"),
                        Type = reader.GetString("type"),
                        MinDays = reader.GetInt32("min_days"),
                        Description = reader["description"]?.ToString() ?? ""
                    });
                comboBoxDiscount.SelectedIndex = 0;
            }
        }

        private void comboBoxDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDiscount.SelectedItem is DiscountData discount)
            {
                if (discount.Id == 0)
                {
                    discountAmount = 0;
                    labelDiscountInfo.Text = "";
                }
                else if (stayDays >= discount.MinDays)
                {
                    discountAmount = (houseDailyPrice * stayDays) * discount.Percent / 100;
                    labelDiscountInfo.Text = $"✅ {discount.Description}";
                    labelDiscountInfo.ForeColor = Color.FromArgb(46, 139, 87);
                }
                else
                {
                    discountAmount = 0;
                    labelDiscountInfo.Text = $"⚠ Нужно минимум {discount.MinDays} дн.";
                    labelDiscountInfo.ForeColor = Color.FromArgb(220, 80, 80);
                }
                UpdateTotalPrice();
            }
        }

        private void UpdateTotalPrice()
        {
            decimal houseCost = houseDailyPrice * stayDays;
            decimal servicesCost = selectedServices.Sum(s => s.Price * s.Quantity);
            totalPrice = houseCost + servicesCost - discountAmount;
            if (totalPrice < 0) totalPrice = 0;

            labelHouseCost.Text = $"{houseCost:N2} ₽";
            labelServicesCost.Text = $"{servicesCost:N2} ₽";
            labelDiscountAmount.Text = $"-{discountAmount:N2} ₽";
            labelTotalCost.Text = $"{totalPrice:N2} ₽";
        }

        private void UpdateServicesGrid()
        {
            dataGridViewServices.Rows.Clear();
            foreach (var s in selectedServices)
                dataGridViewServices.Rows.Add(s.Name, s.Quantity, s.Price, s.Price * s.Quantity);
        }

        private void buttonLoadBooking_Click(object sender, EventArgs e)
        {
            if (comboBoxBookings.SelectedItem == null) { MessageBox.Show("Выберите бронирование."); return; }
            BookingItem sel = (BookingItem)comboBoxBookings.SelectedItem;

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT b.client_id, b.house_id, b.check_in_date, b.check_out_date,
                    CASE hc.class WHEN 'Эконом' THEN 2000 WHEN 'Комфорт' THEN 3500 
                    WHEN 'Люкс' THEN 6000 WHEN 'Премиум' THEN 9000 WHEN 'Бизнес' THEN 7000 
                    ELSE 3000 END AS price
                    FROM booking b JOIN house h ON b.house_id = h.id 
                    JOIN home_class hc ON h.home_class_id = hc.id WHERE b.id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", sel.Id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int cid = reader.GetInt32("client_id");
                            int hid = reader.GetInt32("house_id");
                            foreach (ClientData c in comboBoxClients.Items) { if (c.Id == cid) { comboBoxClients.SelectedItem = c; break; } }
                            foreach (HouseData h in comboBoxHouses.Items) { if (h.Id == hid) { comboBoxHouses.SelectedItem = h; break; } }
                            dateTimePickerCheckIn.Value = reader.GetDateTime("check_in_date");
                            dateTimePickerCheckOut.Value = reader.GetDateTime("check_out_date");
                            houseDailyPrice = reader.GetDecimal("price");
                            CalculateStayDays();
                            UpdateTotalPrice();
                        }
                    }
                }
            }
        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            if (listBoxServices.SelectedItem is ServiceItem sel)
            {
                var exist = selectedServices.FirstOrDefault(s => s.Name == sel.Name);
                if (exist != null) exist.Quantity++;
                else selectedServices.Add(new ServiceItem { Id = sel.Id, Name = sel.Name, Price = sel.Price, Quantity = 1, Description = sel.Description });
                UpdateServicesGrid();
                UpdateTotalPrice();
            }
        }

        private void buttonRemoveService_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0 && dataGridViewServices.SelectedRows[0].Cells["Name"].Value != null)
            {
                string name = dataGridViewServices.SelectedRows[0].Cells["Name"].Value.ToString();
                var s = selectedServices.FirstOrDefault(x => x.Name == name);
                if (s != null) { if (s.Quantity > 1) s.Quantity--; else selectedServices.Remove(s); }
                UpdateServicesGrid();
                UpdateTotalPrice();
            }
        }

        private void buttonClearServices_Click(object sender, EventArgs e)
        {
            if (selectedServices.Count > 0 && MessageBox.Show("Удалить все услуги?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                selectedServices.Clear();
                UpdateServicesGrid();
                UpdateTotalPrice();
            }
        }

        private void dateTimePickerCheckIn_ValueChanged(object sender, EventArgs e)
        {
            DateTime newCheckIn = dateTimePickerCheckIn.Value.Date;
            dateTimePickerCheckOut.MinDate = newCheckIn.AddDays(1);
            if (dateTimePickerCheckOut.Value.Date < dateTimePickerCheckOut.MinDate)
                dateTimePickerCheckOut.Value = dateTimePickerCheckOut.MinDate;
            if ((dateTimePickerCheckOut.Value.Date - newCheckIn).TotalDays > MAX_STAY_DAYS)
                dateTimePickerCheckOut.Value = newCheckIn.AddDays(MAX_STAY_DAYS);
            CalculateStayDays();
            UpdateTotalPrice();
        }

        private void dateTimePickerCheckOut_ValueChanged(object sender, EventArgs e)
        {
            DateTime checkIn = dateTimePickerCheckIn.Value.Date;
            DateTime checkOut = dateTimePickerCheckOut.Value.Date;
            if ((checkOut - checkIn).TotalDays > MAX_STAY_DAYS)
            {
                dateTimePickerCheckOut.Value = checkIn.AddDays(MAX_STAY_DAYS);
                MessageBox.Show($"Максимальная продолжительность — {MAX_STAY_DAYS} дней.", "Ограничение");
                return;
            }
            CalculateStayDays();
            UpdateTotalPrice();
        }

        private void CalculateStayDays()
        {
            DateTime checkIn = dateTimePickerCheckIn.Value.Date;
            DateTime checkOut = dateTimePickerCheckOut.Value.Date;

            if (checkOut > checkIn)
            {
                stayDays = (int)(checkOut - checkIn).TotalDays;
                if (stayDays > MAX_STAY_DAYS)
                {
                    stayDays = MAX_STAY_DAYS;
                    dateTimePickerCheckOut.Value = checkIn.AddDays(MAX_STAY_DAYS);
                }
                labelStayDays.Text = stayDays == 1 ? "1 день" : stayDays < 5 ? $"{stayDays} дня" : $"{stayDays} дней";
            }
            else
            {
                stayDays = 1;
                labelStayDays.Text = "1 день";
                dateTimePickerCheckOut.Value = checkIn.AddDays(1);
            }
            comboBoxDiscount_SelectedIndexChanged(null, null);
        }

        private void comboBoxHouses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHouses.SelectedItem is HouseData house)
            {
                houseDailyPrice = house.PricePerDay;
                labelHouseInfo.Text = $"Вместимость: {house.Capacity} чел. | {house.PricePerDay:N2}₽/сут.";
                comboBoxDiscount_SelectedIndexChanged(null, null);
            }
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            if (comboBoxClients.SelectedItem == null || comboBoxHouses.SelectedItem == null)
            { MessageBox.Show("Выберите клиента и дом."); return; }

            int uid = Session.IsLoggedIn ? Session.UserId : 0;
            if (uid == 0) { MessageBox.Show("Ошибка пользователя."); return; }

            if (MessageBox.Show($"Оформить заказ на {totalPrice:N2}₽?", "Подтверждение", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            int cid = ((ClientData)comboBoxClients.SelectedItem).Id;
            int hid = ((HouseData)comboBoxHouses.SelectedItem).Id;
            decimal houseCost = houseDailyPrice * stayDays;
            int orderId = 0;

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var tr = conn.BeginTransaction())
                {
                    try
                    {
                        string insert = @"INSERT INTO check_in (client_id, house_id, user_id, check_in_date, check_out_date, residence_time, house_total_price)
                            VALUES (@cid, @hid, @uid, @d1, @d2, @days, @total); SELECT LAST_INSERT_ID();";
                        using (var cmd = new MySqlCommand(insert, conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@cid", cid);
                            cmd.Parameters.AddWithValue("@hid", hid);
                            cmd.Parameters.AddWithValue("@uid", uid);
                            cmd.Parameters.AddWithValue("@d1", dateTimePickerCheckIn.Value.Date);
                            cmd.Parameters.AddWithValue("@d2", dateTimePickerCheckOut.Value.Date);
                            cmd.Parameters.AddWithValue("@days", stayDays);
                            cmd.Parameters.AddWithValue("@total", houseCost);
                            orderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        foreach (var s in selectedServices)
                        {
                            using (var cmd = new MySqlCommand("INSERT INTO check_in_services (order_number, service_id, quantity, service_total_price) VALUES (@oid, @sid, @q, @t)", conn, tr))
                            {
                                cmd.Parameters.AddWithValue("@oid", orderId);
                                cmd.Parameters.AddWithValue("@sid", s.Id);
                                cmd.Parameters.AddWithValue("@q", s.Quantity);
                                cmd.Parameters.AddWithValue("@t", s.Price * s.Quantity);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tr.Commit();

                        if (comboBoxBookings.SelectedItem != null)
                        {
                            using (var cmd = new MySqlCommand("UPDATE booking SET status = 'completed' WHERE id = @id", conn))
                            { cmd.Parameters.AddWithValue("@id", ((BookingItem)comboBoxBookings.SelectedItem).Id); cmd.ExecuteNonQuery(); }
                        }

                        new ReceiptForm(orderId, cid, hid, houseCost, selectedServices, uid, dateTimePickerCheckIn.Value, dateTimePickerCheckOut.Value, stayDays).Show();
                        ClearForm();
                    }
                    catch { tr.Rollback(); throw; }
                }
            }
        }

        private void ClearForm()
        {
            comboBoxClients.SelectedIndex = comboBoxClients.Items.Count > 0 ? 0 : -1;
            comboBoxHouses.SelectedIndex = comboBoxHouses.Items.Count > 0 ? 0 : -1;
            comboBoxDiscount.SelectedIndex = 0;
            selectedServices.Clear();
            UpdateServicesGrid();
            dateTimePickerCheckIn.Value = DateTime.Today;
            dateTimePickerCheckOut.Value = DateTime.Today.AddDays(1);
            CalculateStayDays();
            UpdateTotalPrice();
            using (var conn = DatabaseConnection.GetConnection()) { conn.Open(); LoadActiveBookings(conn); }
        }

        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            if (selectedServices.Count > 0 || comboBoxClients.SelectedItem != null)
            { if (MessageBox.Show("Вернуться? Данные потеряются.", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes) Close(); }
            else Close();
        }

        private void listBoxServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxServices.SelectedItem is ServiceItem s)
            {
                textBoxServiceDescription.Text = s.Description;
                labelServicePrice.Text = $"Цена: {s.Price:N2}₽ ({s.Duration} мин.)";
            }
        }

        private void listBoxServices_DoubleClick(object sender, EventArgs e) => buttonAddService_Click(sender, e);

        // Классы данных
        private class ClientData { public int Id; public string FIO; public string Passport; public override string ToString() => FIO; }
        private class HouseData { public int Id; public string Name; public string Class; public int Capacity; public decimal PricePerDay; public override string ToString() => Name; }
        private class BookingItem { public int Id; public string ClientName; public string HouseName; public DateTime CheckInDate; public string DisplayText; public override string ToString() => DisplayText; }
        private class DiscountData { public int Id; public string Name; public decimal Percent; public string Type; public int MinDays; public string Description; public override string ToString() => $"{Name} ({Percent}%)"; }
    }
}