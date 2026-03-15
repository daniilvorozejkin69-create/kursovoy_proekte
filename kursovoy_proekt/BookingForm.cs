using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            InactivityManager.Start(this);
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

                    if (comboBoxClients.Items.Count > 0)
                        comboBoxClients.SelectedIndex = 0;
                }
            }
        }

        private void LoadAvailableHouses(MySqlConnection connection)
        {
            DateTime checkIn = dateTimePickerCheckIn?.Value ?? DateTime.Today;
            DateTime checkOut = dateTimePickerCheckOut?.Value ?? DateTime.Today.AddDays(1);

            string query = @"
                SELECT h.id, 
                       h.name,
                       hc.class,
                       h.capacity,
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
                WHERE h.id NOT IN (
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

                        if (comboBoxHouses.Items.Count > 0)
                            comboBoxHouses.SelectedIndex = 0;
                    }
                }
            }
        }

        private void UpdateTotalPrice()
        {
            try
            {
                totalPrice = houseDailyPrice * stayDays;
                if (labelTotalCost != null)
                    labelTotalCost.Text = $"{totalPrice:N2} ₽";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка расчета: {ex.Message}");
            }
        }

        public void dateTimePickerCheckIn_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime newCheckIn = dateTimePickerCheckIn.Value.Date;
                DateTime currentCheckOut = dateTimePickerCheckOut.Value.Date;

                if (dateTimePickerCheckOut != null)
                {
                    dateTimePickerCheckOut.MinDate = newCheckIn.AddDays(1);

                    if (currentCheckOut < dateTimePickerCheckOut.MinDate)
                    {
                        dateTimePickerCheckOut.Value = dateTimePickerCheckOut.MinDate;
                    }

                    if ((dateTimePickerCheckOut.Value.Date - newCheckIn).TotalDays > MAX_STAY_DAYS)
                    {
                        dateTimePickerCheckOut.Value = newCheckIn.AddDays(MAX_STAY_DAYS);
                        MessageBox.Show($"Максимальная продолжительность бронирования - {MAX_STAY_DAYS} дней.",
                            "Ограничение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                CalculateStayDays();
                ReloadAvailableHouses();
                UpdateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении даты заезда: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    MessageBox.Show($"Максимальная продолжительность бронирования - {MAX_STAY_DAYS} дней.",
                        "Ограничение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                CalculateStayDays();
                ReloadAvailableHouses();
                UpdateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении даты выезда: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления списка домов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateStayDays()
        {
            if (dateTimePickerCheckIn == null || dateTimePickerCheckOut == null) return;

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

                if (labelStayDays != null)
                    labelStayDays.Text = GetDaysText(stayDays);

                if (stayDays > 30 && labelStayDays != null)
                {
                    labelStayDays.ForeColor = Color.OrangeRed;
                    labelStayDays.Font = new Font(labelStayDays.Font, FontStyle.Bold);
                }
                else if (labelStayDays != null)
                {
                    labelStayDays.ForeColor = Color.FromArgb(106, 153, 85);
                    labelStayDays.Font = new Font(labelStayDays.Font, FontStyle.Regular);
                }
            }
            else
            {
                stayDays = 1;
                if (labelStayDays != null)
                    labelStayDays.Text = "1 день";
                dateTimePickerCheckOut.Value = checkIn.AddDays(1);
                MessageBox.Show("Дата выезда должна быть позже даты заезда.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (labelHouseInfo != null)
                    labelHouseInfo.Text = $"Вместимость: {house.Capacity} чел. | Цена за день: {house.PricePerDay:N2}₽";
                UpdateTotalPrice();
            }
        }

        public void buttonCreateBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxClients == null || comboBoxClients.SelectedItem == null)
                {
                    MessageBox.Show("Выберите клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBoxHouses == null || comboBoxHouses.SelectedItem == null)
                {
                    MessageBox.Show("Выберите дом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (stayDays > MAX_STAY_DAYS || stayDays < 1)
                {
                    MessageBox.Show($"Продолжительность бронирования должна быть от 1 до {MAX_STAY_DAYS} дней.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int userId = GetCurrentUserId();
                if (userId == 0) return;

                DialogResult confirm = MessageBox.Show(
                    $"Создать бронирование на сумму {totalPrice:N2}₽?\n" +
                    $"Дата заезда: {dateTimePickerCheckIn.Value:dd.MM.yyyy}\n" +
                    $"Дата выезда: {dateTimePickerCheckOut.Value:dd.MM.yyyy}\n" +
                    $"Продолжительность: {GetDaysText(stayDays)}",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                int clientId = ((ClientData)comboBoxClients.SelectedItem).Id;
                int houseId = ((HouseData)comboBoxHouses.SelectedItem).Id;
                int bookingId = 0;

                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertBooking = @"
                                INSERT INTO booking 
                                (client_id, house_id, user_id, check_in_date, check_out_date, 
                                 days_count, total_price, status, notes) 
                                VALUES (@client_id, @house_id, @user_id, @check_in, @check_out, 
                                        @days_count, @total_price, 'pending', @notes);
                                SELECT LAST_INSERT_ID();";

                            using (var cmd = new MySqlCommand(insertBooking, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@client_id", clientId);
                                cmd.Parameters.AddWithValue("@house_id", houseId);
                                cmd.Parameters.AddWithValue("@user_id", userId);
                                cmd.Parameters.AddWithValue("@check_in", dateTimePickerCheckIn.Value.Date);
                                cmd.Parameters.AddWithValue("@check_out", dateTimePickerCheckOut.Value.Date);
                                cmd.Parameters.AddWithValue("@days_count", stayDays);
                                cmd.Parameters.AddWithValue("@total_price", totalPrice);
                                cmd.Parameters.AddWithValue("@notes", "");

                                bookingId = Convert.ToInt32(cmd.ExecuteScalar());
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

                ClearForm();

                MessageBox.Show($"Бронирование №{bookingId} успешно создано!\nСтатус: Ожидание подтверждения",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex) when (ex.Number == 1644)
            {
                MessageBox.Show("Дом уже забронирован или занят на выбранные даты.\nПожалуйста, выберите другие даты или другой дом.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReloadAvailableHouses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании бронирования: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetCurrentUserId()
        {
            if (Session.IsLoggedIn)
            {
                return Session.UserId;
            }
            return 0;
        }

        private void ClearForm()
        {
            comboBoxClients.SelectedIndex = comboBoxClients.Items.Count > 0 ? 0 : -1;
            comboBoxHouses.SelectedIndex = comboBoxHouses.Items.Count > 0 ? 0 : -1;

            if (labelHouseInfo != null)
                labelHouseInfo.Text = "";

            ReloadAvailableHouses();
            UpdateTotalPrice();
        }

        public void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Вернуться в меню? Несохраненные данные будут потеряны.",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}