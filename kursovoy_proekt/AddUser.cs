using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public partial class AddUser : Form
    {
        public enum FormMode { Add, Edit }
        private FormMode currentMode;
        private int editingUserId = -1;
        private int editingPersonalId = -1;
        public bool DataChanged { get; private set; } = false;

        // Конструкторы
        public AddUser()
        {
            InitializeComponent();
            InactivityManager.Start(this);
            currentMode = FormMode.Add;
            SetupForm();
        }

        public AddUser(int userId, int personalId)
        {
            InitializeComponent();
            currentMode = FormMode.Edit;
            editingUserId = userId;
            editingPersonalId = personalId;
            SetupForm();
        }

        private void SetupForm()
        {
            LoadRoles();
            LoadAvailablePersonal();

            if (currentMode == FormMode.Edit)
            {
                labelHeader.Text = "РЕДАКТИРОВАНИЕ ПОЛЬЗОВАТЕЛЯ";
                buttonSave.Text = "💾 СОХРАНИТЬ ИЗМЕНЕНИЯ";
                buttonDelete.Visible = true;
                LoadUserData(editingUserId, editingPersonalId);
            }
            else
            {
                labelHeader.Text = "ДОБАВЛЕНИЕ НОВОГО ПОЛЬЗОВАТЕЛЯ";
                buttonSave.Text = "➕ ДОБАВИТЬ ПОЛЬЗОВАТЕЛЯ";
                buttonDelete.Visible = false;
            }
        }

        private void LoadUserData(int userId, int personalId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            u.login,
                            u.password,
                            u.role_id,
                            p.FIO,
                            p.email,
                            p.telephone_number
                        FROM users u
                        JOIN personal p ON u.personal_id = p.id
                        WHERE u.id = @UserId AND p.id = @PersonalId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@PersonalId", personalId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxLogin.Text = reader["login"].ToString();
                                textBoxPassword.Text = reader["password"].ToString();

                                // Устанавливаем роль
                                if (comboBoxRole.Items.Count > 0)
                                {
                                    foreach (DataRowView item in comboBoxRole.Items)
                                    {
                                        if (item["id"].ToString() == reader["role_id"].ToString())
                                        {
                                            comboBoxRole.SelectedItem = item;
                                            break;
                                        }
                                    }
                                }

                                // Устанавливаем сотрудника
                                if (comboBoxPersonal.Items.Count > 0)
                                {
                                    foreach (DataRowView item in comboBoxPersonal.Items)
                                    {
                                        if (item["Id"].ToString() == personalId.ToString())
                                        {
                                            comboBoxPersonal.SelectedItem = item;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пользователь не найден в базе данных.", "Ошибка",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных пользователя: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadRoles()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT id, role_name FROM role ORDER BY id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        DataTable rolesTable = new DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(rolesTable);

                        comboBoxRole.DataSource = rolesTable;
                        comboBoxRole.DisplayMember = "role_name";
                        comboBoxRole.ValueMember = "id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке ролей: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAvailablePersonal()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Загружаем сотрудников, у которых еще нет учетной записи
                    // или текущего сотрудника (если редактируем)
                    string query;
                    if (currentMode == FormMode.Edit)
                    {
                        query = @"
                            SELECT p.id, p.FIO 
                            FROM personal p 
                            WHERE p.id NOT IN (SELECT personal_id FROM users WHERE id != @ExcludeUserId)
                               OR p.id = @CurrentPersonalId
                            ORDER BY p.FIO";
                    }
                    else
                    {
                        query = @"
                            SELECT p.id, p.FIO 
                            FROM personal p 
                            WHERE p.id NOT IN (SELECT personal_id FROM users)
                            ORDER BY p.FIO";
                    }

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (currentMode == FormMode.Edit)
                        {
                            command.Parameters.AddWithValue("@ExcludeUserId", editingUserId);
                            command.Parameters.AddWithValue("@CurrentPersonalId", editingPersonalId);
                        }

                        DataTable personalTable = new DataTable();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(personalTable);

                        // Создаем таблицу с отображаемым значением
                        DataTable displayTable = new DataTable();
                        displayTable.Columns.Add("Id", typeof(int));
                        displayTable.Columns.Add("Display", typeof(string));

                        foreach (DataRow row in personalTable.Rows)
                        {
                            string fio = row["FIO"].ToString();
                            int id = Convert.ToInt32(row["id"]);

                            // Добавляем ID сотрудника в скобках для наглядности
                            string displayText = $"{fio} (ID: {id})";
                            displayTable.Rows.Add(id, displayText);
                        }

                        comboBoxPersonal.DataSource = displayTable;
                        comboBoxPersonal.DisplayMember = "Display";
                        comboBoxPersonal.ValueMember = "Id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка сотрудников: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            if (currentMode == FormMode.Add)
            {
                AddNewUser();
            }
            else
            {
                UpdateUser();
            }
        }

        private bool ValidateData()
        {
            // Проверка логина
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                ShowValidationError("Введите логин", textBoxLogin);
                return false;
            }

            if (textBoxLogin.Text.Trim().Length < 3)
            {
                ShowValidationError("Логин должен содержать минимум 3 символа", textBoxLogin);
                return false;
            }

            if (textBoxLogin.Text.Trim().Length > 50)
            {
                ShowValidationError("Логин не должен превышать 50 символов", textBoxLogin);
                return false;
            }

            // Проверка пароля
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                ShowValidationError("Введите пароль", textBoxPassword);
                return false;
            }

            if (textBoxPassword.Text.Length < 6)
            {
                ShowValidationError("Пароль должен содержать минимум 6 символов", textBoxPassword);
                return false;
            }

            // Проверка сотрудника
            if (comboBoxPersonal.SelectedIndex == -1)
            {
                ShowValidationError("Выберите сотрудника", comboBoxPersonal);
                return false;
            }

            // Проверка роли
            if (comboBoxRole.SelectedIndex == -1)
            {
                ShowValidationError("Выберите роль", comboBoxRole);
                return false;
            }

            // Проверка формата логина (только латинские буквы и цифры)
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxLogin.Text, @"^[a-zA-Z0-9_]+$"))
            {
                ShowValidationError("Логин может содержать только латинские буквы, цифры и подчеркивание", textBoxLogin);
                return false;
            }

            return true;
        }

        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Ошибка ввода",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            control.BackColor = Color.FromArgb(255, 230, 230);
        }

        private bool CheckForDuplicates(string login, int excludeUserId = -1)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT u.id, u.login, r.role_name, p.FIO
                        FROM users u
                        JOIN role r ON u.role_id = r.id
                        JOIN personal p ON u.personal_id = p.id
                        WHERE u.login = @Login 
                          AND (@ExcludeId = -1 OR u.id != @ExcludeId)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@ExcludeId", excludeUserId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show(
                                    $"Пользователь с таким логином уже существует:\n\n" +
                                    $"Логин: {reader["login"]}\n" +
                                    $"Сотрудник: {reader["FIO"]}\n" +
                                    $"Роль: {reader["role_name"]}",
                                    "Дублирование логина",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке дубликатов: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CheckIfLastAdmin(int userId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Получаем ID роли "Администратор"
                    string getAdminRoleQuery = "SELECT id FROM role WHERE role_name = 'Администратор'";
                    int adminRoleId;
                    using (MySqlCommand getAdminCommand = new MySqlCommand(getAdminRoleQuery, connection))
                    {
                        var result = getAdminCommand.ExecuteScalar();
                        if (result == null) return false;
                        adminRoleId = Convert.ToInt32(result);
                    }

                    // Считаем администраторов
                    string countAdminsQuery = @"
                        SELECT COUNT(*) 
                        FROM users 
                        WHERE role_id = @AdminRoleId 
                          AND id != @UserId";

                    using (MySqlCommand countCommand = new MySqlCommand(countAdminsQuery, connection))
                    {
                        countCommand.Parameters.AddWithValue("@AdminRoleId", adminRoleId);
                        countCommand.Parameters.AddWithValue("@UserId", userId);
                        int adminCount = Convert.ToInt32(countCommand.ExecuteScalar());

                        return adminCount == 0; // Если 0 - это последний администратор
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке администраторов: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CheckActiveBookings(int userId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT COUNT(*) 
                        FROM check_in 
                        WHERE user_id = @UserId 
                          AND check_out_date >= CURDATE()";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        int activeBookings = Convert.ToInt32(command.ExecuteScalar());

                        return activeBookings > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке активных бронирований: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void AddNewUser()
        {
            string login = textBoxLogin.Text.Trim();

            // Проверка дублей
            if (CheckForDuplicates(login))
                return;

            // Проверка, что у выбранного сотрудника еще нет учетной записи
            if (comboBoxPersonal.SelectedValue != null)
            {
                int personalId = (int)comboBoxPersonal.SelectedValue;
                if (CheckIfPersonalHasAccount(personalId))
                {
                    MessageBox.Show("У выбранного сотрудника уже есть учетная запись.\n" +
                                  "Выберите другого сотрудника или отредактируйте существующую учетную запись.",
                                  "Ошибка",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string insertQuery = @"
                        INSERT INTO users (
                            personal_id, 
                            login, 
                            password, 
                            role_id
                        ) VALUES (
                            @PersonalId, 
                            @Login, 
                            @Password, 
                            @RoleId
                        )";

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PersonalId", comboBoxPersonal.SelectedValue);
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@Password", HashPassword(textBoxPassword.Text));
                        command.Parameters.AddWithValue("@RoleId", comboBoxRole.SelectedValue);

                        command.ExecuteNonQuery();
                    }

                    DataChanged = true;
                    MessageBox.Show("Пользователь успешно добавлен!", "Успех",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Ошибка дублирования ключа
                {
                    MessageBox.Show("Пользователь с таким логином уже существует.",
                                   "Ошибка дублирования",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 1452) // Ошибка внешнего ключа
                {
                    MessageBox.Show("Ошибка связи с таблицей персонала.",
                                   "Ошибка базы данных",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при добавлении пользователя: {ex.Message}",
                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении пользователя: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckIfPersonalHasAccount(int personalId, int excludeUserId = -1)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT COUNT(*) 
                        FROM users 
                        WHERE personal_id = @PersonalId 
                          AND (@ExcludeUserId = -1 OR id != @ExcludeUserId)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonalId", personalId);
                        command.Parameters.AddWithValue("@ExcludeUserId", excludeUserId);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке учетной записи сотрудника: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UpdateUser()
        {
            string login = textBoxLogin.Text.Trim();

            // Проверка дублей (исключая текущего пользователя)
            if (CheckForDuplicates(login, editingUserId))
                return;

            // Проверка, не пытаемся ли изменить сотрудника на того, у кого уже есть учетная запись
            if (comboBoxPersonal.SelectedValue != null)
            {
                int newPersonalId = (int)comboBoxPersonal.SelectedValue;
                if (newPersonalId != editingPersonalId && CheckIfPersonalHasAccount(newPersonalId, editingUserId))
                {
                    MessageBox.Show("У выбранного сотрудника уже есть учетная запись.\n" +
                                  "Выберите другого сотрудника.",
                                  "Ошибка",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }
            }

            // Проверка, не пытаемся ли сменить роль у последнего администратора
            if (CheckIfLastAdmin(editingUserId))
            {
                int currentRoleId = Convert.ToInt32(comboBoxRole.SelectedValue);
                int adminRoleId = GetAdminRoleId();

                if (currentRoleId != adminRoleId)
                {
                    MessageBox.Show("Нельзя изменить роль последнему администратору системы.\n" +
                                  "Должен оставаться хотя бы один администратор.",
                                  "Запрещено изменение роли",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string updateQuery = @"
                        UPDATE users SET
                            personal_id = @PersonalId, 
                            login = @Login, 
                            password = @Password, 
                            role_id = @RoleId
                        WHERE id = @UserId";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PersonalId", comboBoxPersonal.SelectedValue);
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@Password", HashPassword(textBoxPassword.Text));
                        command.Parameters.AddWithValue("@RoleId", comboBoxRole.SelectedValue);
                        command.Parameters.AddWithValue("@UserId", editingUserId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DataChanged = true;
                            MessageBox.Show("Данные пользователя успешно обновлены!", "Успех",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден или данные не были изменены.", "Информация",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Другой пользователь с таким логином уже существует.",
                                   "Ошибка дублирования",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 1452)
                {
                    MessageBox.Show("Ошибка связи с таблицей персонала.",
                                   "Ошибка базы данных",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}",
                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetAdminRoleId()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id FROM role WHERE role_name = 'Администратор'";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (currentMode != FormMode.Edit)
                return;

            // Проверка на последнего администратора
            if (CheckIfLastAdmin(editingUserId))
            {
                MessageBox.Show("Нельзя удалить последнего администратора системы.\n" +
                              "Должен оставаться хотя бы один администратор.",
                              "Запрещено удаление",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return;
            }

            // Проверка активных бронирований
            if (CheckActiveBookings(editingUserId))
            {
                MessageBox.Show("Нельзя удалить пользователя, у которого есть активные бронирования.\n" +
                              "Дождитесь завершения всех бронирований или переназначьте их.",
                              "Запрещено удаление",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить этого пользователя?\n" +
                                        "Все связанные записи будут сохранены, но доступ будет утрачен.\n" +
                                        "Это действие нельзя отменить.",
                                        "Подтверждение удаления",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteUser();
            }
        }

        private void DeleteUser()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM users WHERE id = @UserId";

                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", editingUserId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DataChanged = true;
                            MessageBox.Show("Пользователь успешно удален!", "Успех",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден.", "Ошибка",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show("Нельзя удалить пользователя, у которого есть связанные записи.\n" +
                                  "Сначала удалите все связанные бронирования.",
                                  "Ошибка удаления",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при удалении пользователя: {ex.Message}",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении пользователя: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonGeneratePassword_Click(object sender, EventArgs e)
        {
            // Генерация безопасного пароля
            const string uppercase = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string lowercase = "abcdefghijkmnpqrstuvwxyz";
            const string digits = "23456789";
            const string special = "!@#$%^&*";

            var random = new Random();
            var password = new char[10];

            // Гарантируем наличие разных типов символов
            password[0] = uppercase[random.Next(uppercase.Length)];
            password[1] = lowercase[random.Next(lowercase.Length)];
            password[2] = digits[random.Next(digits.Length)];
            password[3] = special[random.Next(special.Length)];

            // Остальные символы
            string allChars = uppercase + lowercase + digits + special;
            for (int i = 4; i < 10; i++)
            {
                password[i] = allChars[random.Next(allChars.Length)];
            }

            // Перемешиваем пароль
            password = password.OrderBy(x => random.Next()).ToArray();

            textBoxPassword.Text = new string(password);
            textBoxPassword.UseSystemPasswordChar = false;
            textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Bold);

            MessageBox.Show($"Сгенерирован безопасный пароль!\n\n" +
                           $"Пароль: {new string(password)}\n\n" +
                           "Рекомендуется записать его в надежное место.",
                           "Пароль сгенерирован",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

            // Через 5 секунд скрываем пароль
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += (s, args) =>
            {
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.Font = new Font(textBoxPassword.Font, FontStyle.Regular);
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Общие обработчики событий
        private void Control_Enter(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.BackColor = Color.FromArgb(255, 255, 220);
            }
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            if (sender is Control control && !control.BackColor.Equals(Color.FromArgb(255, 230, 230)))
            {
                control.BackColor = Color.White;
            }
        }

        // Валидация в реальном времени
        private void textBoxLogin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLogin.Text))
            {
                if (textBoxLogin.Text.Length < 3)
                {
                    textBoxLogin.BackColor = Color.FromArgb(255, 230, 230);
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxLogin.Text, @"^[a-zA-Z0-9_]+$"))
                {
                    textBoxLogin.BackColor = Color.FromArgb(255, 230, 230);
                }
                else
                {
                    textBoxLogin.BackColor = Color.White;
                }
            }
        }

        private void textBoxPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPassword.Text) && textBoxPassword.Text.Length < 6)
            {
                textBoxPassword.BackColor = Color.FromArgb(255, 230, 230);
            }
            else
            {
                textBoxPassword.BackColor = Color.White;
            }
        }

        // Ограничение длины ввода
        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLogin.Text.Length > 50)
            {
                textBoxLogin.Text = textBoxLogin.Text.Substring(0, 50);
                textBoxLogin.SelectionStart = textBoxLogin.Text.Length;
            }
        }

        // Показ/скрытие пароля
        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.H)
            {
                textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
                e.Handled = true;
            }
        }

        private void textBoxPassword_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu menu = new ContextMenu();
                MenuItem showItem = new MenuItem("Показать пароль");
                showItem.Click += (s, args) =>
                {
                    textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
                    showItem.Text = textBoxPassword.UseSystemPasswordChar ? "Показать пароль" : "Скрыть пароль";
                };
                menu.MenuItems.Add(showItem);

                MenuItem copyItem = new MenuItem("Копировать");
                copyItem.Click += (s, args) => Clipboard.SetText(textBoxPassword.Text);
                menu.MenuItems.Add(copyItem);

                menu.Show(textBoxPassword, e.Location);
            }
        }

        // События для отладки (можно удалить)
        private void comboBoxPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Для отладки: показываем выбранного сотрудника
            if (comboBoxPersonal.SelectedValue != null)
            {
                toolTip.SetToolTip(comboBoxPersonal,
                    $"Выбран сотрудник ID: {comboBoxPersonal.SelectedValue}");
            }
        }
    }
}