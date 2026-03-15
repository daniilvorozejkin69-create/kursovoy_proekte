using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public partial class Check : Form
    {
        private decimal houseDailyPrice = 0;
        private int stayDays = 1;
        private decimal totalPrice = 0;
        private List<ServiceItem> selectedServices = new List<ServiceItem>();

        // Для выбора бронирования
        private DataTable activeBookingsTable;

        public Check()
        {
            InitializeComponent();
            InactivityManager.Start(this);
            SetupForm();
        }

        private void SetupForm()
        {
            try
            {
                if (dataGridViewServices != null)
                {
                    dataGridViewServices.AutoGenerateColumns = false;
                    dataGridViewServices.AllowUserToAddRows = false;
                    dataGridViewServices.RowHeadersVisible = false;
                    dataGridViewServices.ReadOnly = true;
                }

                SetupDataGridViewColumns();

                // ========== ПОДПИСКА НА ВСЕ КНОПКИ ==========
                // Кнопки услуг
                buttonAddService.Click += buttonAddService_Click;
                buttonRemoveService.Click += buttonRemoveService_Click;
                buttonClearServices.Click += buttonClearServices_Click;

                // Кнопки дат
                dateTimePickerCheckIn.ValueChanged += dateTimePickerCheckIn_ValueChanged;
                dateTimePickerCheckOut.ValueChanged += dateTimePickerCheckOut_ValueChanged;

                // Кнопки домов и клиентов
                comboBoxHouses.SelectedIndexChanged += comboBoxHouses_SelectedIndexChanged;

                // Кнопка загрузки бронирования
                if (buttonLoadBooking != null)
                    buttonLoadBooking.Click += buttonLoadBooking_Click;

                // Кнопка создания заказа
                buttonCreateOrder.Click += buttonCreateOrder_Click;

                // Кнопка возврата в меню
                buttonBackToMenu.Click += buttonBackToMenu_Click;

                // Двойной клик на список услуг
                listBoxServices.DoubleClick += listBoxServices_DoubleClick;
                listBoxServices.SelectedIndexChanged += listBoxServices_SelectedIndexChanged;

                // ========== ЗАГРУЗКА ДАННЫХ ==========
                LoadFormData();
                UpdateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridViewColumns()
        {
            if (dataGridViewServices == null) return;

            // Удаляем все существующие обработчики
            dataGridViewServices.CellClick -= DataGridViewServices_CellClick;

            dataGridViewServices.Columns.Clear();

            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Услуга",
                Width = 250,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn colQuantity = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Кол-во",
                Width = 80,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            DataGridViewButtonColumn colDecrease = new DataGridViewButtonColumn
            {
                Name = "Decrease",
                HeaderText = "",
                Text = "−",
                Width = 40,
                UseColumnTextForButtonValue = true
            };

            DataGridViewButtonColumn colIncrease = new DataGridViewButtonColumn
            {
                Name = "Increase",
                HeaderText = "",
                Text = "+",
                Width = 40,
                UseColumnTextForButtonValue = true
            };

            DataGridViewTextBoxColumn colUnitPrice = new DataGridViewTextBoxColumn
            {
                Name = "UnitPrice",
                HeaderText = "Цена за ед.",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            };

            DataGridViewTextBoxColumn colTotalPrice = new DataGridViewTextBoxColumn
            {
                Name = "TotalPrice",
                HeaderText = "Общая стоимость",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            };

            dataGridViewServices.Columns.AddRange(colName, colQuantity, colDecrease, colIncrease, colUnitPrice, colTotalPrice);
            dataGridViewServices.CellClick += DataGridViewServices_CellClick;
        }

        private void DataGridViewServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.RowIndex >= selectedServices.Count) return;

            var service = selectedServices[e.RowIndex];
            string columnName = dataGridViewServices.Columns[e.ColumnIndex].Name;

            if (columnName == "Decrease" && service.Quantity > 1)
            {
                service.Quantity--;
                UpdateServicesGrid();
                UpdateTotalPrice();
            }
            else if (columnName == "Increase" && service.Quantity < 100)
            {
                service.Quantity++;
                UpdateServicesGrid();
                UpdateTotalPrice();
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
                    LoadHouses(connection);
                    LoadServices(connection);
                    LoadActiveBookings(connection); // Загружаем бронирования

                    dateTimePickerCheckIn.Value = DateTime.Today;
                    dateTimePickerCheckOut.Value = DateTime.Today.AddDays(1);
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
            }
        }

        private void LoadHouses(MySqlConnection connection)
        {
            string query = @"SELECT h.id, 
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
                            ORDER BY h.name";

            using (var cmd = new MySqlCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
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
            }
        }

        private void LoadServices(MySqlConnection connection)
        {
            string query = "SELECT id, name_services, price, description, duration FROM services ORDER BY name_services";
            using (var cmd = new MySqlCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                listBoxServices.Items.Clear();
                listBoxServices.DisplayMember = "Name";
                while (reader.Read())
                {
                    listBoxServices.Items.Add(new ServiceItem
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name_services"),
                        Price = reader.GetDecimal("price"),
                        Description = reader["description"].ToString(),
                        Duration = reader.GetInt32("duration")
                    });
                }
            }

            if (textBoxServiceDescription != null)
                textBoxServiceDescription.Text = "Выберите услугу для просмотра описания...";
            if (labelServicePrice != null)
                labelServicePrice.Text = "Цена: 0₽";
        }

        // ЗАГРУЗКА АКТИВНЫХ БРОНИРОВАНИЙ
        private void LoadActiveBookings(MySqlConnection connection)
        {
            string query = @"
                SELECT 
                    b.id,
                    c.FIO as client_name,
                    h.name as house_name,
                    b.check_in_date,
                    b.check_out_date
                FROM booking b
                JOIN client c ON b.client_id = c.id
                JOIN house h ON b.house_id = h.id
                WHERE b.status = 'confirmed'
                  AND b.check_in_date >= CURDATE()
                ORDER BY b.check_in_date";

            using (var cmd = new MySqlCommand(query, connection))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                activeBookingsTable = new DataTable();
                adapter.Fill(activeBookingsTable);
            }

            comboBoxBookings.Items.Clear();

            foreach (DataRow row in activeBookingsTable.Rows)
            {
                comboBoxBookings.Items.Add(new BookingItem
                {
                    Id = Convert.ToInt32(row["id"]),
                    ClientName = row["client_name"].ToString(),
                    HouseName = row["house_name"].ToString(),
                    CheckInDate = Convert.ToDateTime(row["check_in_date"]),
                    DisplayText = $"№{row["id"]} - {row["client_name"]} - {row["house_name"]} - {Convert.ToDateTime(row["check_in_date"]):dd.MM.yyyy}"
                });
            }

            if (comboBoxBookings.Items.Count > 0)
                comboBoxBookings.SelectedIndex = 0;
        }

        // ОБРАБОТЧИК КНОПКИ ЗАГРУЗКИ БРОНИРОВАНИЯ
        private void buttonLoadBooking_Click(object sender, EventArgs e)
        {
            if (comboBoxBookings.SelectedItem == null)
            {
                MessageBox.Show("Выберите бронирование для загрузки.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BookingItem selected = (BookingItem)comboBoxBookings.SelectedItem;

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            b.client_id,
                            b.house_id,
                            b.check_in_date,
                            b.check_out_date,
                            hc.class,
                            CASE 
                                WHEN hc.class = 'Эконом' THEN 2000
                                WHEN hc.class = 'Комфорт' THEN 3500
                                WHEN hc.class = 'Люкс' THEN 6000
                                WHEN hc.class = 'Премиум' THEN 9000
                                WHEN hc.class = 'Бизнес' THEN 7000
                                ELSE 3000
                            END as price_per_day
                        FROM booking b
                        JOIN house h ON b.house_id = h.id
                        JOIN home_class hc ON h.home_class_id = hc.id
                        WHERE b.id = @bookingId";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@bookingId", selected.Id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Загружаем клиента
                                int clientId = reader.GetInt32("client_id");
                                foreach (ClientData client in comboBoxClients.Items)
                                {
                                    if (client.Id == clientId)
                                    {
                                        comboBoxClients.SelectedItem = client;
                                        break;
                                    }
                                }

                                // Загружаем дом
                                int houseId = reader.GetInt32("house_id");
                                foreach (HouseData house in comboBoxHouses.Items)
                                {
                                    if (house.Id == houseId)
                                    {
                                        comboBoxHouses.SelectedItem = house;
                                        break;
                                    }
                                }

                                // Загружаем даты
                                dateTimePickerCheckIn.Value = reader.GetDateTime("check_in_date");
                                dateTimePickerCheckOut.Value = reader.GetDateTime("check_out_date");

                                // Загружаем цену
                                houseDailyPrice = reader.GetDecimal("price_per_day");

                                CalculateStayDays();
                                UpdateTotalPrice();

                                MessageBox.Show("Бронирование успешно загружено!", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке бронирования: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotalPrice()
        {
            try
            {
                decimal houseCost = houseDailyPrice * stayDays;
                decimal servicesCost = selectedServices.Sum(s => s.Price * s.Quantity);
                totalPrice = houseCost + servicesCost;

                if (labelHouseCost != null)
                    labelHouseCost.Text = $"{houseCost:N2} ₽";
                if (labelServicesCost != null)
                    labelServicesCost.Text = $"{servicesCost:N2} ₽";
                if (labelTotalCost != null)
                    labelTotalCost.Text = $"{totalPrice:N2} ₽";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка расчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateServicesGrid()
        {
            try
            {
                if (dataGridViewServices == null) return;

                dataGridViewServices.Rows.Clear();

                foreach (var service in selectedServices)
                {
                    int rowIndex = dataGridViewServices.Rows.Add();
                    dataGridViewServices.Rows[rowIndex].Cells["Name"].Value = service.Name;
                    dataGridViewServices.Rows[rowIndex].Cells["Quantity"].Value = service.Quantity;
                    dataGridViewServices.Rows[rowIndex].Cells["UnitPrice"].Value = service.Price;
                    dataGridViewServices.Rows[rowIndex].Cells["TotalPrice"].Value = service.Price * service.Quantity;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обновления таблицы: {ex.Message}");
            }
        }

        public void listBoxServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxServices != null && listBoxServices.SelectedItem is ServiceItem service)
            {
                if (textBoxServiceDescription != null)
                    textBoxServiceDescription.Text = service.Description;
                if (labelServicePrice != null)
                    labelServicePrice.Text = $"Цена: {service.Price:N2}₽ ({service.Duration} мин.)";
            }
        }

        public void buttonAddService_Click(object sender, EventArgs e)
        {
            if (listBoxServices != null && listBoxServices.SelectedItem is ServiceItem selectedService)
            {
                var existingService = selectedServices.FirstOrDefault(s => s.Name == selectedService.Name);

                if (existingService != null)
                {
                    if (existingService.Quantity < 100)
                    {
                        existingService.Quantity++;
                    }
                    else
                    {
                        MessageBox.Show("Достигнуто максимальное количество (100).", "Внимание",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    selectedServices.Add(new ServiceItem
                    {
                        Id = selectedService.Id,
                        Name = selectedService.Name,
                        Price = selectedService.Price,
                        Quantity = 1,
                        Description = selectedService.Description,
                        Duration = selectedService.Duration
                    });
                }

                UpdateServicesGrid();
                UpdateTotalPrice();
            }
            else
            {
                MessageBox.Show("Выберите услугу из списка.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void buttonRemoveService_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices != null && dataGridViewServices.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewServices.SelectedRows[0];
                if (selectedRow.Cells["Name"].Value != null)
                {
                    string serviceName = selectedRow.Cells["Name"].Value.ToString();
                    var service = selectedServices.FirstOrDefault(s => s.Name == serviceName);

                    if (service != null)
                    {
                        if (service.Quantity > 1)
                        {
                            service.Quantity--;
                        }
                        else
                        {
                            selectedServices.Remove(service);
                        }

                        UpdateServicesGrid();
                        UpdateTotalPrice();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите услугу для удаления.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void buttonClearServices_Click(object sender, EventArgs e)
        {
            if (selectedServices.Count > 0)
            {
                var result = MessageBox.Show("Удалить все услуги из заказа?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    selectedServices.Clear();
                    UpdateServicesGrid();
                    UpdateTotalPrice();
                }
            }
        }

        public void dateTimePickerCheckIn_ValueChanged(object sender, EventArgs e)
        {
            CalculateStayDays();
            UpdateTotalPrice();
        }

        public void dateTimePickerCheckOut_ValueChanged(object sender, EventArgs e)
        {
            CalculateStayDays();
            UpdateTotalPrice();
        }

        private void CalculateStayDays()
        {
            DateTime checkIn = dateTimePickerCheckIn.Value;
            DateTime checkOut = dateTimePickerCheckOut.Value;

            if (checkOut > checkIn)
            {
                stayDays = (int)(checkOut - checkIn).TotalDays;
                if (labelStayDays != null)
                    labelStayDays.Text = GetDaysText(stayDays);
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

        public void buttonCreateOrder_Click(object sender, EventArgs e)
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

                int userId = GetCurrentUserId();
                if (userId == 0)
                {
                    MessageBox.Show("Ошибка определения пользователя.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    $"Оформить заказ на сумму {totalPrice:N2}₽?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                int clientId = ((ClientData)comboBoxClients.SelectedItem).Id;
                int houseId = ((HouseData)comboBoxHouses.SelectedItem).Id;
                decimal houseTotal = houseDailyPrice * stayDays;
                int orderId = 0;

                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertCheckIn = @"
                                INSERT INTO check_in 
                                (client_id, house_id, user_id, check_in_date, check_out_date, residence_time, house_total_price) 
                                VALUES (@client_id, @house_id, @user_id, @check_in, @check_out, @residence_time, @house_total);
                                SELECT LAST_INSERT_ID();";

                            using (var cmdCheckIn = new MySqlCommand(insertCheckIn, connection, transaction))
                            {
                                cmdCheckIn.Parameters.AddWithValue("@client_id", clientId);
                                cmdCheckIn.Parameters.AddWithValue("@house_id", houseId);
                                cmdCheckIn.Parameters.AddWithValue("@user_id", userId);
                                cmdCheckIn.Parameters.AddWithValue("@check_in", dateTimePickerCheckIn.Value.Date);
                                cmdCheckIn.Parameters.AddWithValue("@check_out", dateTimePickerCheckOut.Value.Date);
                                cmdCheckIn.Parameters.AddWithValue("@residence_time", stayDays);
                                cmdCheckIn.Parameters.AddWithValue("@house_total", houseTotal);

                                orderId = Convert.ToInt32(cmdCheckIn.ExecuteScalar());
                            }

                            if (selectedServices.Count > 0)
                            {
                                foreach (var service in selectedServices)
                                {
                                    string insertService = @"
                                        INSERT INTO check_in_services 
                                        (order_number, service_id, quantity, service_total_price) 
                                        VALUES (@order_number, @service_id, @quantity, @service_total)";

                                    using (var cmdService = new MySqlCommand(insertService, connection, transaction))
                                    {
                                        cmdService.Parameters.AddWithValue("@order_number", orderId);
                                        cmdService.Parameters.AddWithValue("@service_id", service.Id);
                                        cmdService.Parameters.AddWithValue("@quantity", service.Quantity);
                                        cmdService.Parameters.AddWithValue("@service_total", service.Price * service.Quantity);
                                        cmdService.ExecuteNonQuery();
                                    }
                                }
                            }

                            transaction.Commit();

                            // Если заказ создан из бронирования, обновляем статус бронирования
                            if (comboBoxBookings.SelectedItem != null)
                            {
                                UpdateBookingStatus(((BookingItem)comboBoxBookings.SelectedItem).Id);
                            }

                            // Открываем чек
                            ReceiptForm receipt = new ReceiptForm(
                                orderId,
                                clientId,
                                houseId,
                                houseTotal,
                                selectedServices,
                                userId,
                                dateTimePickerCheckIn.Value,
                                dateTimePickerCheckOut.Value,
                                stayDays
                            );
                            receipt.Show();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show($"Заказ №{orderId} успешно оформлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBookingStatus(int bookingId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = "UPDATE booking SET status = 'completed' WHERE id = @bookingId";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@bookingId", bookingId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обновлении статуса бронирования: {ex.Message}");
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
            comboBoxClients.SelectedIndex = -1;
            comboBoxHouses.SelectedIndex = -1;
            selectedServices.Clear();
            UpdateServicesGrid();

            if (labelHouseInfo != null)
                labelHouseInfo.Text = "";
            if (textBoxServiceDescription != null)
                textBoxServiceDescription.Text = "Выберите услугу для просмотра описания...";
            if (labelServicePrice != null)
                labelServicePrice.Text = "Цена: 0₽";

            dateTimePickerCheckIn.Value = DateTime.Today;
            dateTimePickerCheckOut.Value = DateTime.Today.AddDays(1);

            CalculateStayDays();
            UpdateTotalPrice();

            // Обновляем список бронирований
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                LoadActiveBookings(connection);
            }
        }

        public void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            if (selectedServices.Count > 0 || comboBoxClients.SelectedItem != null || comboBoxHouses.SelectedItem != null)
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
            else
            {
                this.Close();
            }
        }

        public void listBoxServices_DoubleClick(object sender, EventArgs e)
        {
            buttonAddService_Click(sender, e);
        }

        // Класс для хранения данных бронирования
        private class BookingItem
        {
            public int Id { get; set; }
            public string ClientName { get; set; }
            public string HouseName { get; set; }
            public DateTime CheckInDate { get; set; }
            public string DisplayText { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }
    }
}