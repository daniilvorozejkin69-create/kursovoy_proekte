using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class BookingManagementForm : Form
    {
        private DataTable bookingsDataTable;
        private string currentSortColumn = "";
        private SortOrder currentSortOrder = SortOrder.None;

        public BookingManagementForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            try
            {
                // Настройка DataGridView
                dataGridViewBookings.AutoGenerateColumns = false;
                dataGridViewBookings.AllowUserToAddRows = false;
                dataGridViewBookings.RowHeadersVisible = false;
                dataGridViewBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewBookings.AllowUserToOrderColumns = true;

                SetupDataGridViewColumns();

                // Загрузка данных
                LoadBookings();
                LoadFilterComboBoxes();

                // Установка начальных дат фильтрации
                dateTimePickerFilterFrom.Value = DateTime.Today.AddMonths(-1);
                dateTimePickerFilterTo.Value = DateTime.Today.AddMonths(2);

                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridViewColumns()
        {
            dataGridViewBookings.Columns.Clear();

            // ID бронирования
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "№",
                Width = 50,
                DataPropertyName = "id",
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            // Клиент
            DataGridViewTextBoxColumn colClient = new DataGridViewTextBoxColumn
            {
                Name = "Client",
                HeaderText = "Клиент",
                Width = 200,
                DataPropertyName = "client_name",
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            // Дом
            DataGridViewTextBoxColumn colHouse = new DataGridViewTextBoxColumn
            {
                Name = "House",
                HeaderText = "Дом",
                Width = 150,
                DataPropertyName = "house_name",
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            // Даты
            DataGridViewTextBoxColumn colDates = new DataGridViewTextBoxColumn
            {
                Name = "Dates",
                HeaderText = "Даты",
                Width = 120,
                DataPropertyName = "dates_display",
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            // Продолжительность
            DataGridViewTextBoxColumn colDays = new DataGridViewTextBoxColumn
            {
                Name = "Days",
                HeaderText = "Дни",
                Width = 50,
                DataPropertyName = "days_count",
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter },
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            // Стоимость
            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Стоимость",
                Width = 100,
                DataPropertyName = "total_price",
                ReadOnly = true,
                DefaultCellStyle = {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            // Статус
            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Статус",
                Width = 120,
                DataPropertyName = "status_display",
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            // Дата создания
            DataGridViewTextBoxColumn colCreated = new DataGridViewTextBoxColumn
            {
                Name = "Created",
                HeaderText = "Создано",
                Width = 120,
                DataPropertyName = "booking_date",
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            // Кнопка действий
            DataGridViewButtonColumn colActions = new DataGridViewButtonColumn
            {
                Name = "Actions",
                HeaderText = "Действия",
                Width = 150,
                Text = "Управление",
                UseColumnTextForButtonValue = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            dataGridViewBookings.Columns.AddRange(colId, colClient, colHouse, colDates, colDays, colPrice, colStatus, colCreated, colActions);

            // Обработчики событий
            dataGridViewBookings.CellClick += DataGridViewBookings_CellClick;
            dataGridViewBookings.ColumnHeaderMouseClick += DataGridViewBookings_ColumnHeaderMouseClick;
        }

        private void DataGridViewBookings_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || dataGridViewBookings.Columns[e.ColumnIndex].Name == "Actions")
                return;

            string columnName = dataGridViewBookings.Columns[e.ColumnIndex].Name;

            if (currentSortColumn == columnName)
            {
                // Изменяем порядок сортировки
                currentSortOrder = (currentSortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                currentSortColumn = columnName;
                currentSortOrder = SortOrder.Ascending;
            }

            SortDataGridView(columnName, currentSortOrder);

            // Обновляем индикаторы сортировки
            UpdateSortIndicators();
        }

        private void SortDataGridView(string columnName, SortOrder sortOrder)
        {
            if (bookingsDataTable == null) return;

            try
            {
                DataView dv = bookingsDataTable.DefaultView;

                string sortDirection = (sortOrder == SortOrder.Ascending) ? "ASC" : "DESC";

                // Специальная обработка для разных типов колонок
                switch (columnName)
                {
                    case "Id":
                    case "Days":
                        dv.Sort = $"{columnName} {sortDirection}";
                        break;
                    case "Price":
                        dv.Sort = $"total_price {sortDirection}";
                        break;
                    case "Dates":
                        dv.Sort = $"check_in_date {sortDirection}";
                        break;
                    case "Created":
                        dv.Sort = $"booking_date {sortDirection}";
                        break;
                    default:
                        dv.Sort = $"{columnName} {sortDirection}";
                        break;
                }

                dataGridViewBookings.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сортировки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSortIndicators()
        {
            // Сбрасываем все индикаторы
            foreach (DataGridViewColumn column in dataGridViewBookings.Columns)
            {
                if (column.Name != "Actions")
                {
                    column.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }

            // Устанавливаем индикатор для текущей колонки
            if (!string.IsNullOrEmpty(currentSortColumn) && currentSortOrder != SortOrder.None)
            {
                var column = dataGridViewBookings.Columns[currentSortColumn];
                if (column != null)
                {
                    column.HeaderCell.SortGlyphDirection = currentSortOrder;
                }
            }
        }

        private void DataGridViewBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridViewBookings.Columns[e.ColumnIndex].Name == "Actions")
            {
                int bookingId = Convert.ToInt32(dataGridViewBookings.Rows[e.RowIndex].Cells["Id"].Value);
                string status = dataGridViewBookings.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                ShowBookingActionsMenu(bookingId, status, e.RowIndex);
            }
            else if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                // Выбор строки при клике на любую ячейку
                dataGridViewBookings.Rows[e.RowIndex].Selected = true;
            }
        }

        private void ShowBookingActionsMenu(int bookingId, string status, int rowIndex)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            // Просмотр деталей
            menu.Items.Add("Просмотреть детали", null, (s, ev) => ShowBookingDetails(bookingId));
            menu.Items.Add("-"); // Разделитель

            // Действия в зависимости от статуса
            if (status == "Ожидание")
            {
                menu.Items.Add("Подтвердить бронь", null, (s, ev) => ConfirmBooking(bookingId, rowIndex));
                menu.Items.Add("Внести депозит", null, (s, ev) => AddDeposit(bookingId, rowIndex));
                menu.Items.Add("Редактировать", null, (s, ev) => EditBooking(bookingId));
            }

            if (status == "Подтверждено")
            {
                menu.Items.Add("Преобразовать в заселение", null, (s, ev) => ConvertToCheckIn(bookingId, rowIndex));
                menu.Items.Add("Внести депозит", null, (s, ev) => AddDeposit(bookingId, rowIndex));
            }

            // Общие действия
            if (status == "Ожидание" || status == "Подтверждено")
            {
                menu.Items.Add("Отменить бронь", null, (s, ev) => CancelBooking(bookingId, rowIndex));
            }

            menu.Items.Add("-"); // Разделитель
            menu.Items.Add("Печать бронирования", null, (s, ev) => PrintBooking(bookingId));

            // Показываем меню рядом с кнопкой
            Rectangle cellRect = dataGridViewBookings.GetCellDisplayRectangle(dataGridViewBookings.Columns["Actions"].Index, rowIndex, false);
            menu.Show(dataGridViewBookings, cellRect.Left, cellRect.Bottom);
        }

        private void LoadBookings()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            b.id,
                            c.FIO as client_name,
                            h.name as house_name,
                            hc.class as house_class,
                            b.check_in_date,
                            b.check_out_date,
                            b.days_count,
                            b.total_price,
                            b.status,
                            b.deposit_paid,
                            b.booking_date,
                            b.notes,
                            u.login as created_by,
                            CASE 
                                WHEN b.status = 'pending' THEN 'Ожидание'
                                WHEN b.status = 'confirmed' THEN 'Подтверждено'
                                WHEN b.status = 'cancelled' THEN 'Отменено'
                                WHEN b.status = 'completed' THEN 'Завершено'
                                WHEN b.status = 'expired' THEN 'Истекло'
                                ELSE b.status
                            END as status_display,
                            CONCAT(DATE_FORMAT(b.check_in_date, '%d.%m.%Y'), ' - ', DATE_FORMAT(b.check_out_date, '%d.%m.%Y')) as dates_display,
                            DATE_FORMAT(b.booking_date, '%d.%m.%Y %H:%i') as booking_date_display
                        FROM booking b
                        JOIN client c ON b.client_id = c.id
                        JOIN house h ON b.house_id = h.id
                        JOIN home_class hc ON h.home_class_id = hc.id
                        JOIN users u ON b.user_id = u.id
                        WHERE 1=1";

                    // Добавляем фильтры
                    if (checkBoxFilterByDate.Checked)
                    {
                        query += " AND b.check_in_date BETWEEN @date_from AND @date_to";
                    }

                    if (comboBoxFilterStatus.SelectedIndex > 0)
                    {
                        string selectedStatus = GetStatusFromDisplay(comboBoxFilterStatus.SelectedItem.ToString());
                        query += " AND b.status = @status";
                    }

                    if (comboBoxFilterHouse.SelectedIndex > 0)
                    {
                        query += " AND h.id = @house_id";
                    }

                    // Добавляем сортировку по умолчанию
                    query += " ORDER BY b.check_in_date DESC, b.booking_date DESC";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        if (checkBoxFilterByDate.Checked)
                        {
                            cmd.Parameters.AddWithValue("@date_from", dateTimePickerFilterFrom.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@date_to", dateTimePickerFilterTo.Value.ToString("yyyy-MM-dd"));
                        }

                        if (comboBoxFilterStatus.SelectedIndex > 0)
                        {
                            cmd.Parameters.AddWithValue("@status", GetStatusFromDisplay(comboBoxFilterStatus.SelectedItem.ToString()));
                        }

                        if (comboBoxFilterHouse.SelectedIndex > 0)
                        {
                            // Проверяем тип элемента
                            if (comboBoxFilterHouse.SelectedItem != null)
                            {
                                // Просто получаем ID как-то иначе
                                // Например, если там строка с ID: "1 - Название дома"
                                string selectedText = comboBoxFilterHouse.SelectedItem.ToString();
                                // Парсим ID из текста...
                            }
                        }

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            bookingsDataTable = new DataTable();
                            adapter.Fill(bookingsDataTable);
                            dataGridViewBookings.DataSource = bookingsDataTable;
                        }
                    }
                }

                // Восстанавливаем сортировку после загрузки
                if (!string.IsNullOrEmpty(currentSortColumn))
                {
                    SortDataGridView(currentSortColumn, currentSortOrder);
                }

                // Обновляем статистику
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки бронирований: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFilterComboBoxes()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Загрузка статусов
                    if (comboBoxFilterStatus.Items.Count == 0)
                    {
                        comboBoxFilterStatus.Items.Clear();
                        comboBoxFilterStatus.Items.Add("Все статусы");
                        comboBoxFilterStatus.Items.Add("Ожидание");
                        comboBoxFilterStatus.Items.Add("Подтверждено");
                        comboBoxFilterStatus.Items.Add("Отменено");
                        comboBoxFilterStatus.Items.Add("Завершено");
                        comboBoxFilterStatus.Items.Add("Истекло");
                        comboBoxFilterStatus.SelectedIndex = 0;
                    }

                    // Загрузка домов
                    if (comboBoxFilterHouse.Items.Count == 0)
                    {
                        comboBoxFilterHouse.Items.Clear();
                        comboBoxFilterHouse.Items.Add("Все дома");

                        string housesQuery = "SELECT h.id, CONCAT(h.name, ' (', hc.class, ')') as display FROM house h JOIN home_class hc ON h.home_class_id = hc.id ORDER BY h.name";
                        using (var cmd = new MySqlCommand(housesQuery, connection))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBoxFilterHouse.Items.Add(new HouseData
                                {
                                    Id = reader.GetInt32("id"),
                                    Name = reader.GetString("display"),
                                    Class = "",
                                    Capacity = 0,
                                    PricePerDay = 0
                                });
                            }
                        }
                        comboBoxFilterHouse.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки фильтров: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStatusFromDisplay(string displayStatus)
        {
            if (displayStatus == "Ожидание")
                return "pending";
            else if (displayStatus == "Подтверждено")
                return "confirmed";
            else if (displayStatus == "Отменено")
                return "cancelled";
            else if (displayStatus == "Завершено")
                return "completed";
            else if (displayStatus == "Истекло")
                return "expired";
            else
                return displayStatus.ToLower();
        }

        private void UpdateStatistics()
        {
            try
            {
                if (bookingsDataTable == null) return;

                int totalCount = bookingsDataTable.Rows.Count;
                int pendingCount = 0;
                int confirmedCount = 0;
                int cancelledCount = 0;
                int completedCount = 0;
                decimal totalRevenue = 0;
                decimal totalDeposit = 0;

                foreach (DataRow row in bookingsDataTable.Rows)
                {
                    string status = row["status"].ToString();
                    decimal price = Convert.ToDecimal(row["total_price"]);
                    decimal deposit = row["deposit_paid"] != DBNull.Value ? Convert.ToDecimal(row["deposit_paid"]) : 0;

                    totalDeposit += deposit;

                    if (status == "pending")
                        pendingCount++;
                    else if (status == "confirmed")
                    {
                        confirmedCount++;
                        totalRevenue += price;
                    }
                    else if (status == "cancelled")
                        cancelledCount++;
                    else if (status == "completed")
                        completedCount++;
                }

                labelStatistics.Text = $"Всего: {totalCount} | Ожидание: {pendingCount} | Подтверждено: {confirmedCount} | " +
                                     $"Отменено: {cancelledCount} | Завершено: {completedCount} | " +
                                     $"Выручка: {totalRevenue:N2}₽ | Депозиты: {totalDeposit:N2}₽";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обновления статистики: {ex.Message}");
            }
        }

        private void ShowBookingDetails(int bookingId)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            b.*,
                            c.FIO as client_name,
                            c.passport_series_number,
                            c.telephone_number,
                            c.email,
                            h.name as house_name,
                            hc.class as house_class,
                            h.capacity,
                            h.description as house_description,
                            u.login as created_by_user,
                            p.FIO as created_by_name
                        FROM booking b
                        JOIN client c ON b.client_id = c.id
                        JOIN house h ON b.house_id = h.id
                        JOIN home_class hc ON h.home_class_id = hc.id
                        JOIN users u ON b.user_id = u.id
                        JOIN personal p ON u.personal_id = p.id
                        WHERE b.id = @booking_id";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@booking_id", bookingId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                BookingDetailsForm detailsForm = new BookingDetailsForm(reader);
                                detailsForm.ShowDialog();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки деталей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfirmBooking(int bookingId, int rowIndex)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Вы уверены, что хотите подтвердить это бронирование?\nПосле подтверждения статус изменится на 'Подтверждено'.",
                    "Подтверждение бронирования",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = "UPDATE booking SET status = 'confirmed' WHERE id = @booking_id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@booking_id", bookingId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Обновляем строку в таблице
                            if (bookingsDataTable != null && rowIndex < bookingsDataTable.Rows.Count)
                            {
                                bookingsDataTable.Rows[rowIndex]["status"] = "confirmed";
                                bookingsDataTable.Rows[rowIndex]["status_display"] = "Подтверждено";
                            }

                            UpdateStatistics();
                            MessageBox.Show("Бронирование успешно подтверждено!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подтверждения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDeposit(int bookingId, int rowIndex)
        {
            try
            {
                decimal currentDeposit = 0;

                // Получаем текущий депозит
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT deposit_paid FROM booking WHERE id = @booking_id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@booking_id", bookingId);
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            currentDeposit = Convert.ToDecimal(result);
                        }
                    }
                }

                // Форма для ввода депозита
                using (DepositForm depositForm = new DepositForm(bookingId, currentDeposit))
                {
                    if (depositForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadBookings(); // Перезагружаем данные
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка внесения депозита: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelBooking(int bookingId, int rowIndex)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Вы уверены, что хотите отменить это бронирование?\nОтмена будет записана в историю.",
                    "Отмена бронирования",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes) return;

                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = "UPDATE booking SET status = 'cancelled' WHERE id = @booking_id";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@booking_id", bookingId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Обновляем строку в таблице
                            if (bookingsDataTable != null && rowIndex < bookingsDataTable.Rows.Count)
                            {
                                bookingsDataTable.Rows[rowIndex]["status"] = "cancelled";
                                bookingsDataTable.Rows[rowIndex]["status_display"] = "Отменено";
                            }

                            UpdateStatistics();
                            MessageBox.Show("Бронирование отменено!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отмены: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConvertToCheckIn(int bookingId, int rowIndex)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Преобразовать подтвержденное бронирование в заселение?\nБронирование будет помечено как завершенное.",
                    "Преобразование в заселение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Сначала получаем данные бронирования
                    string selectQuery = @"
                        SELECT client_id, house_id, check_in_date, check_out_date, 
                               days_count, total_price 
                        FROM booking 
                        WHERE id = @booking_id AND status = 'confirmed'";

                    int clientId = 0, houseId = 0, daysCount = 0;
                    DateTime checkIn = DateTime.MinValue, checkOut = DateTime.MinValue;
                    decimal totalPrice = 0;

                    using (var cmdSelect = new MySqlCommand(selectQuery, connection))
                    {
                        cmdSelect.Parameters.AddWithValue("@booking_id", bookingId);
                        using (var reader = cmdSelect.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                clientId = reader.GetInt32("client_id");
                                houseId = reader.GetInt32("house_id");
                                checkIn = reader.GetDateTime("check_in_date");
                                checkOut = reader.GetDateTime("check_out_date");
                                daysCount = reader.GetInt32("days_count");
                                totalPrice = reader.GetDecimal("total_price");
                            }
                            else
                            {
                                MessageBox.Show("Бронирование не найдено или не подтверждено.", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    // Создаем заселение
                    int userId = Session.UserId;
                    string insertQuery = @"
                        INSERT INTO check_in 
                        (client_id, house_id, user_id, check_in_date, check_out_date, 
                         residence_time, tag, house_total_price) 
                        VALUES (@client_id, @house_id, @user_id, @check_in, @check_out, 
                                @residence_time, 'из бронирования', @house_total_price);
                        SELECT LAST_INSERT_ID();";

                    int checkInId = 0;
                    using (var cmdInsert = new MySqlCommand(insertQuery, connection))
                    {
                        cmdInsert.Parameters.AddWithValue("@client_id", clientId);
                        cmdInsert.Parameters.AddWithValue("@house_id", houseId);
                        cmdInsert.Parameters.AddWithValue("@user_id", userId);
                        cmdInsert.Parameters.AddWithValue("@check_in", checkIn.ToString("yyyy-MM-dd"));
                        cmdInsert.Parameters.AddWithValue("@check_out", checkOut.ToString("yyyy-MM-dd"));
                        cmdInsert.Parameters.AddWithValue("@residence_time", daysCount);
                        cmdInsert.Parameters.AddWithValue("@house_total_price", totalPrice);

                        checkInId = Convert.ToInt32(cmdInsert.ExecuteScalar());
                    }

                    // Обновляем статус бронирования
                    string updateQuery = "UPDATE booking SET status = 'completed' WHERE id = @booking_id";
                    using (var cmdUpdate = new MySqlCommand(updateQuery, connection))
                    {
                        cmdUpdate.Parameters.AddWithValue("@booking_id", bookingId);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // Обновляем данные в таблице
                    if (bookingsDataTable != null && rowIndex < bookingsDataTable.Rows.Count)
                    {
                        bookingsDataTable.Rows[rowIndex]["status"] = "completed";
                        bookingsDataTable.Rows[rowIndex]["status_display"] = "Завершено";
                    }

                    UpdateStatistics();

                    MessageBox.Show($"Бронирование успешно преобразовано в заселение №{checkInId}!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка преобразования: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditBooking(int bookingId)
        {
            try
            {
                // Загружаем данные бронирования для редактирования
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            b.*,
                            c.FIO as client_name,
                            h.name as house_name
                        FROM booking b
                        JOIN client c ON b.client_id = c.id
                        JOIN house h ON b.house_id = h.id
                        WHERE b.id = @booking_id";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@booking_id", bookingId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Создаем форму для редактирования
                                using (EditBookingForm editForm = new EditBookingForm(reader))
                                {
                                    if (editForm.ShowDialog() == DialogResult.OK)
                                    {
                                        // Обновляем данные после редактирования
                                        LoadBookings();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных для редактирования: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintBooking(int bookingId)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, e) =>
                {
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();

                        string query = @"
                            SELECT 
                                b.id,
                                c.FIO as client_name,
                                c.passport_series_number,
                                h.name as house_name,
                                DATE_FORMAT(b.check_in_date, '%d.%m.%Y') as check_in,
                                DATE_FORMAT(b.check_out_date, '%d.%m.%Y') as check_out,
                                b.days_count,
                                b.total_price,
                                b.deposit_paid,
                                CASE 
                                    WHEN b.status = 'pending' THEN 'Ожидание'
                                    WHEN b.status = 'confirmed' THEN 'Подтверждено'
                                    WHEN b.status = 'cancelled' THEN 'Отменено'
                                    WHEN b.status = 'completed' THEN 'Завершено'
                                    ELSE b.status
                                END as status_display,
                                DATE_FORMAT(b.booking_date, '%d.%m.%Y %H:%i') as created_date
                            FROM booking b
                            JOIN client c ON b.client_id = c.id
                            JOIN house h ON b.house_id = h.id
                            WHERE b.id = @booking_id";

                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@booking_id", bookingId);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Рисуем документ
                                    Graphics g = e.Graphics;
                                    Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                                    Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                                    Font normalFont = new Font("Arial", 10);

                                    float yPos = 50;
                                    float leftMargin = 50;

                                    // Заголовок
                                    g.DrawString("БРОНИРОВАНИЕ", titleFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 40;

                                    // Информация
                                    g.DrawString($"№: {reader["id"]}", headerFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 25;

                                    g.DrawString($"Клиент: {reader["client_name"]}", normalFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 20;
                                    g.DrawString($"Паспорт: {reader["passport_series_number"]}", normalFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 20;
                                    g.DrawString($"Дом: {reader["house_name"]}", normalFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 20;

                                    g.DrawString($"Даты: {reader["check_in"]} - {reader["check_out"]}", normalFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 20;

                                    g.DrawString($"Дней: {reader["days_count"]}", normalFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 20;

                                    decimal totalPrice = Convert.ToDecimal(reader["total_price"]);
                                    decimal deposit = reader["deposit_paid"] != DBNull.Value ? Convert.ToDecimal(reader["deposit_paid"]) : 0;
                                    g.DrawString($"Стоимость: {totalPrice:N2} ₽", normalFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 20;
                                    g.DrawString($"Депозит: {deposit:N2} ₽", normalFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 20;
                                    g.DrawString($"Остаток: {(totalPrice - deposit):N2} ₽", normalFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 30;

                                    g.DrawString($"Статус: {reader["status_display"]}", headerFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 30;

                                    g.DrawString($"Дата создания: {reader["created_date"]}", normalFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 40;

                                    g.DrawString("_________________________", normalFont, Brushes.Black, leftMargin, yPos);
                                    yPos += 15;
                                    g.DrawString("Подпись администратора", new Font("Arial", 8), Brushes.Black, leftMargin + 30, yPos);
                                }
                            }
                        }
                    }
                };

                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = pd;
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка печати: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчики событий фильтрации
        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            LoadBookings();
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            dateTimePickerFilterFrom.Value = DateTime.Today.AddMonths(-1);
            dateTimePickerFilterTo.Value = DateTime.Today.AddMonths(2);
            checkBoxFilterByDate.Checked = false;
            comboBoxFilterStatus.SelectedIndex = 0;
            comboBoxFilterHouse.SelectedIndex = 0;

            LoadBookings();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadBookings();
            MessageBox.Show("Данные успешно обновлены", "Обновление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (bookingsDataTable == null || bookingsDataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для экспорта", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "CSV файлы (*.csv)|*.csv",
                    FileName = $"Бронирования_{DateTime.Now:yyyy-MM-dd_HH-mm}"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToCsv(saveDialog.FileName);

                    MessageBox.Show($"Данные успешно экспортированы в файл:\n{saveDialog.FileName}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCsv(string filePath)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    // Заголовки
                    var headers = dataGridViewBookings.Columns
                        .Cast<DataGridViewColumn>()
                        .Where(col => col.Name != "Actions")
                        .Select(col => EscapeCsvValue(col.HeaderText));

                    writer.WriteLine(string.Join(";", headers));

                    // Данные
                    foreach (DataGridViewRow row in dataGridViewBookings.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var cells = row.Cells
                            .Cast<DataGridViewCell>()
                            .Where((cell, index) => index < dataGridViewBookings.Columns.Count - 1)
                            .Select(cell => EscapeCsvValue(cell.Value?.ToString() ?? ""));

                        writer.WriteLine(string.Join(";", cells));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string EscapeCsvValue(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";

            if (value.Contains(";") || value.Contains("\"") || value.Contains("\r") || value.Contains("\n"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

        // События для выпадающих списков
        private void comboBoxFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Автоматическое применение фильтра при выборе
            if (comboBoxFilterStatus.SelectedIndex > 0)
            {
                LoadBookings();
            }
        }

        private void comboBoxFilterHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Автоматическое применение фильтра при выборе
            if (comboBoxFilterHouse.SelectedIndex > 0)
            {
                LoadBookings();
            }
        }

        private void checkBoxFilterByDate_CheckedChanged(object sender, EventArgs e)
        {
            // Включаем/выключаем DateTimePicker'ы
            dateTimePickerFilterFrom.Enabled = checkBoxFilterByDate.Checked;
            dateTimePickerFilterTo.Enabled = checkBoxFilterByDate.Checked;

            // Если чекбокс снят, обновляем данные
            if (!checkBoxFilterByDate.Checked)
            {
                LoadBookings();
            }
        }

        private void dateTimePickerFilterFrom_ValueChanged(object sender, EventArgs e)
        {
            // Автоматическое применение фильтра при изменении даты
            if (checkBoxFilterByDate.Checked)
            {
                LoadBookings();
            }
        }

        private void dateTimePickerFilterTo_ValueChanged(object sender, EventArgs e)
        {
            // Автоматическое применение фильтра при изменении даты
            if (checkBoxFilterByDate.Checked)
            {
                LoadBookings();
            }
        }

        // Кнопки быстрой сортировки (если они есть на форме)
        private void buttonSortByDate_Click(object sender, EventArgs e)
        {
            currentSortColumn = "Dates";
            currentSortOrder = SortOrder.Descending;
            SortDataGridView("Dates", currentSortOrder);
            UpdateSortIndicators();
        }

        private void buttonSortByStatus_Click(object sender, EventArgs e)
        {
            currentSortColumn = "Status";
            currentSortOrder = SortOrder.Ascending;
            SortDataGridView("Status", currentSortOrder);
            UpdateSortIndicators();
        }

        private void buttonSortByPrice_Click(object sender, EventArgs e)
        {
            currentSortColumn = "Price";
            currentSortOrder = SortOrder.Descending;
            SortDataGridView("Price", currentSortOrder);
            UpdateSortIndicators();
        }

        private void buttonSortByHouse_Click(object sender, EventArgs e)
        {
            currentSortColumn = "House";
            currentSortOrder = SortOrder.Ascending;
            SortDataGridView("House", currentSortOrder);
            UpdateSortIndicators();
        }
    }
}