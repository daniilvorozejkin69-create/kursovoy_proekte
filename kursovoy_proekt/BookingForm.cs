using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class BookingForm : Form
    {
        private decimal houseDailyPrice = 0;
        private int stayDays = 1;
        private decimal totalPrice = 0;
        private const int MAX_BOOKING_MONTHS_AHEAD = 12;
        private const int MAX_STAY_DAYS = 90;

        public BookingForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            try
            {
                if (dateTimePickerCheckIn != null)
                {
                    dateTimePickerCheckIn.MinDate = DateTime.Today;
                    dateTimePickerCheckIn.MaxDate = DateTime.Today.AddMonths(MAX_BOOKING_MONTHS_AHEAD);
                    dateTimePickerCheckIn.Value = DateTime.Today;
                }

                if (dateTimePickerCheckOut != null)
                {
                    dateTimePickerCheckOut.MinDate = DateTime.Today.AddDays(1);
                    dateTimePickerCheckOut.MaxDate = DateTime.Today.AddMonths(MAX_BOOKING_MONTHS_AHEAD).AddDays(MAX_STAY_DAYS);
                    dateTimePickerCheckOut.Value = DateTime.Today.AddDays(1);
                }

                LoadFormData();
                UpdateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFormData()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    LoadClients(connection);
                    LoadAvailableHouses(connection);
                    CalculateStayDays();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClients(MySqlConnection connection)
        {
            string query = "SELECT id, FIO, passport_series_number FROM client ORDER BY FIO";
            using (var cmd = new MySqlCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                if (comboBoxClients != null)
                {
                    comboBoxClients.Items.Clear();
                    comboBoxClients.DisplayMember = "FIO";
                    while (reader.Read())
                    {
                        comboBoxClients.Items.Add(new ClientData
                        {
                            Id = reader.GetInt32("id"),
                            FIO = reader.GetString("FIO"),
                            Passport = reader.GetString("passport_series_number")
                        });
                    }
                    if (comboBoxClients.Items.Count > 0) comboBoxClients.SelectedIndex = 0;
                }
            }
        }

        private void LoadAvailableHouses(MySqlConnection connection)
        {
            DateTime checkIn = dateTimePickerCheckIn?.Value ?? DateTime.Today;
            DateTime checkOut = dateTimePickerCheckOut?.Value ?? DateTime.Today.AddDays(1);

            string query = @"
                SELECT h.id, h.name, hc.class, h.capacity,
                       CASE 
                           WHEN hc.class = 'Эконом' THEN 2000
                           WHEN hc.class = 'Комфорт' THEN 3500
                           WHEN hc.class = 'Люкс' THEN 6000
                           WHEN hc.class = 'Премиум' THEN 9000
                           WHEN hc.class = 'Бизнес' THEN 7000
                           ELSE 3000
                       END as price_per_day
                FROM house h 
                JOIN home_class hc ON h.home_class_id = hc.id 
                WHERE h.status = 'available'
                  AND h.id NOT IN (
                    SELECT DISTINCT b.house_id 
                    FROM booking b 
                    WHERE b.status IN ('pending', 'confirmed')
                      AND b.check_in_date < @check_out 
                      AND b.check_out_date > @check_in
                    UNION
                    SELECT DISTINCT ci.house_id 
                    FROM check_in ci 
                    WHERE ci.check_in_date < @check_out 
                      AND ci.check_out_date > @check_in
                )
                ORDER BY h.name";

            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@check_in", checkIn.Date);
                cmd.Parameters.AddWithValue("@check_out", checkOut.Date);

                using (var reader = cmd.ExecuteReader())
                {
                    if (comboBoxHouses != null)
                    {
                        comboBoxHouses.Items.Clear();
                        comboBoxHouses.DisplayMember = "Name";
                        while (reader.Read())
                        {
                            comboBoxHouses.Items.Add(new HouseData
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name"),
                                Class = reader.GetString("class"),
                                Capacity = reader.GetInt32("capacity"),
                                PricePerDay = reader.GetDecimal("price_per_day")
                            });
                        }
                        if (comboBoxHouses.Items.Count > 0) comboBoxHouses.SelectedIndex = 0;
                    }
                }
            }
        }

        private void UpdateTotalPrice()
        {
            try
            {
                totalPrice = houseDailyPrice * stayDays;
                if (labelTotalCost != null) labelTotalCost.Text = $"{totalPrice:N2} ₽";
            }
            catch (Exception ex) { Console.WriteLine($"Ошибка расчета: {ex.Message}"); }
        }

        public void dateTimePickerCheckIn_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime newCheckIn = dateTimePickerCheckIn.Value.Date;
                if (dateTimePickerCheckOut != null)
                {
                    dateTimePickerCheckOut.MinDate = newCheckIn.AddDays(1);
                    if (dateTimePickerCheckOut.Value.Date < dateTimePickerCheckOut.MinDate)
                        dateTimePickerCheckOut.Value = dateTimePickerCheckOut.MinDate;
                    if ((dateTimePickerCheckOut.Value.Date - newCheckIn).TotalDays > MAX_STAY_DAYS)
                    {
                        dateTimePickerCheckOut.Value = newCheckIn.AddDays(MAX_STAY_DAYS);
                        MessageBox.Show($"Максимальная продолжительность - {MAX_STAY_DAYS} дней.", "Ограничение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                CalculateStayDays();
                ReloadAvailableHouses();
                UpdateTotalPrice();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        public void dateTimePickerCheckOut_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime checkIn = dateTimePickerCheckIn.Value.Date;
                DateTime checkOut = dateTimePickerCheckOut.Value.Date;
                int daysDifference = (int)(checkOut - checkIn).TotalDays;
                if (daysDifference > MAX_STAY_DAYS)
                {
                    dateTimePickerCheckOut.Value = checkIn.AddDays(MAX_STAY_DAYS);
                    MessageBox.Show($"Максимальная продолжительность - {MAX_STAY_DAYS} дней.", "Ограничение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CalculateStayDays();
                ReloadAvailableHouses();
                UpdateTotalPrice();
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
        }

        private void ReloadAvailableHouses()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    LoadAvailableHouses(connection);
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка обновления: {ex.Message}"); }
        }

        private void CalculateStayDays()
        {
            if (dateTimePickerCheckIn == null || dateTimePickerCheckOut == null) return;
            DateTime checkIn = dateTimePickerCheckIn.Value.Date;
            DateTime checkOut = dateTimePickerCheckOut.Value.Date;
            if (checkOut > checkIn)
            {
                stayDays = (int)(checkOut - checkIn).TotalDays;
                if (stayDays > MAX_STAY_DAYS) { stayDays = MAX_STAY_DAYS; dateTimePickerCheckOut.Value = checkIn.AddDays(MAX_STAY_DAYS); }
                if (labelStayDays != null) labelStayDays.Text = GetDaysText(stayDays);
            }
            else
            {
                stayDays = 1;
                if (labelStayDays != null) labelStayDays.Text = "1 день";
                dateTimePickerCheckOut.Value = checkIn.AddDays(1);
            }
        }

        private string GetDaysText(int days)
        {
            if (days % 10 == 1 && days % 100 != 11) return $"{days} день";
            if (days % 10 >= 2 && days % 10 <= 4 && (days % 100 < 10 || days % 100 >= 20)) return $"{days} дня";
            return $"{days} дней";
        }

        public void comboBoxHouses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHouses != null && comboBoxHouses.SelectedItem is HouseData house)
            {
                houseDailyPrice = house.PricePerDay;
                if (labelHouseInfo != null) labelHouseInfo.Text = $"Вместимость: {house.Capacity} чел. | Цена: {house.PricePerDay:N2}₽/сут.";
                UpdateTotalPrice();
            }
        }

        public void buttonCreateBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxClients == null || comboBoxClients.SelectedItem == null) { MessageBox.Show("Выберите клиента."); return; }
                if (comboBoxHouses == null || comboBoxHouses.SelectedItem == null) { MessageBox.Show("Выберите дом."); return; }
                if (stayDays > MAX_STAY_DAYS || stayDays < 1) { MessageBox.Show($"От 1 до {MAX_STAY_DAYS} дней."); return; }

                int userId = GetCurrentUserId();
                if (userId == 0) return;

                int clientId = ((ClientData)comboBoxClients.SelectedItem).Id;
                int houseId = ((HouseData)comboBoxHouses.SelectedItem).Id;
                DateTime checkIn = dateTimePickerCheckIn.Value.Date;
                DateTime checkOut = dateTimePickerCheckOut.Value.Date;

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Проверка: дом занят?
                    string qHouse = @"SELECT COUNT(*) FROM (
                        SELECT house_id FROM booking WHERE house_id=@h AND status IN ('pending','confirmed') AND check_in_date<@d2 AND check_out_date>@d1
                        UNION ALL SELECT house_id FROM check_in WHERE house_id=@h AND check_in_date<@d2 AND check_out_date>@d1) AS t";
                    using (var cmd = new MySqlCommand(qHouse, conn))
                    {
                        cmd.Parameters.AddWithValue("@h", houseId); cmd.Parameters.AddWithValue("@d1", checkIn); cmd.Parameters.AddWithValue("@d2", checkOut);
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0) { MessageBox.Show("Дом занят на эти даты!"); ReloadAvailableHouses(); return; }
                    }

                    // Проверка: клиент уже бронировал другой дом?
                    string qClient = @"SELECT COUNT(*) FROM (
                        SELECT client_id FROM booking WHERE client_id=@c AND status IN ('pending','confirmed') AND check_in_date<@d2 AND check_out_date>@d1
                        UNION ALL SELECT client_id FROM check_in WHERE client_id=@c AND check_in_date<@d2 AND check_out_date>@d1) AS t";
                    using (var cmd = new MySqlCommand(qClient, conn))
                    {
                        cmd.Parameters.AddWithValue("@c", clientId); cmd.Parameters.AddWithValue("@d1", checkIn); cmd.Parameters.AddWithValue("@d2", checkOut);
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0) { MessageBox.Show("Клиент уже бронировал другой дом на эти даты!"); return; }
                    }

                    // Проверка: клиент уже бронировал этот же дом?
                    string qSame = "SELECT COUNT(*) FROM booking WHERE client_id=@c AND house_id=@h AND status IN ('pending','confirmed') AND check_in_date<@d2 AND check_out_date>@d1";
                    using (var cmd = new MySqlCommand(qSame, conn))
                    {
                        cmd.Parameters.AddWithValue("@c", clientId); cmd.Parameters.AddWithValue("@h", houseId); cmd.Parameters.AddWithValue("@d1", checkIn); cmd.Parameters.AddWithValue("@d2", checkOut);
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0) { MessageBox.Show("Вы уже бронировали этот дом на эти даты!"); return; }
                    }
                }

                if (MessageBox.Show($"Создать бронирование на {totalPrice:N2}₽?\n{checkIn:dd.MM.yyyy} — {checkOut:dd.MM.yyyy}\n{GetDaysText(stayDays)}", "Подтверждение", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string insert = @"INSERT INTO booking (client_id, house_id, user_id, check_in_date, check_out_date, days_count, total_price, status) 
                                     VALUES (@c, @h, @u, @d1, @d2, @d, @p, 'pending')";
                    using (var cmd = new MySqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@c", clientId); cmd.Parameters.AddWithValue("@h", houseId); cmd.Parameters.AddWithValue("@u", userId);
                        cmd.Parameters.AddWithValue("@d1", checkIn); cmd.Parameters.AddWithValue("@d2", checkOut);
                        cmd.Parameters.AddWithValue("@d", stayDays); cmd.Parameters.AddWithValue("@p", totalPrice);
                        cmd.ExecuteNonQuery();
                    }
                }
                ClearForm();
                MessageBox.Show("Бронирование создано!", "Успех");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private int GetCurrentUserId() => Session.IsLoggedIn ? Session.UserId : 0;

        private void ClearForm()
        {
            comboBoxClients.SelectedIndex = comboBoxClients.Items.Count > 0 ? 0 : -1;
            comboBoxHouses.SelectedIndex = comboBoxHouses.Items.Count > 0 ? 0 : -1;
            if (labelHouseInfo != null) labelHouseInfo.Text = "";
            ReloadAvailableHouses();
            UpdateTotalPrice();
        }

        public void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вернуться в меню?", "", MessageBoxButtons.YesNo) == DialogResult.Yes) Close();
        }

        private class ClientData { public int Id; public string FIO; public string Passport; public override string ToString() => FIO; }
        private class HouseData { public int Id; public string Name; public string Class; public int Capacity; public decimal PricePerDay; public override string ToString() => Name; }
    }
}