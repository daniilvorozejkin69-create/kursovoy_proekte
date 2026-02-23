using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class AddClient : Form
    {
        public enum FormMode { Add, Edit }
        private FormMode currentMode;
        private int editingClientId = -1;
        public bool DataChanged { get; private set; } = false;

        public AddClient()
        {
            InitializeComponent();
            currentMode = FormMode.Add;
            SetupForm();
        }

        public AddClient(int clientId)
        {
            InitializeComponent();
            currentMode = FormMode.Edit;
            editingClientId = clientId;
            SetupForm();
        }

        private void SetupForm()
        {
            // Настройка элементов
            SetupControls();

            dateTimePickerBirthDate.MaxDate = DateTime.Now;
            dateTimePickerBirthDate.MinDate = DateTime.Now.AddYears(-100);

            if (currentMode == FormMode.Edit)
            {
                labelHeader.Text = "✏️  РЕДАКТИРОВАНИЕ КЛИЕНТА";
                buttonSave.Text = "💾  СОХРАНИТЬ ИЗМЕНЕНИЯ";
                buttonDelete.Visible = true;
                LoadClientData(editingClientId);
            }
            else
            {
                labelHeader.Text = "➕  ДОБАВЛЕНИЕ НОВОГО КЛИЕНТА";
                buttonSave.Text = "✅  ДОБАВИТЬ КЛИЕНТА";
                buttonDelete.Visible = false;
            }
        }

        private void SetupControls()
        {
            // Настройка кнопок
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.BackColor = Color.FromArgb(46, 204, 113);
            buttonSave.ForeColor = Color.White;
            buttonSave.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            buttonSave.Cursor = Cursors.Hand;

            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.BackColor = Color.FromArgb(231, 76, 60);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            buttonDelete.Cursor = Cursors.Hand;

            buttonMenu.FlatStyle = FlatStyle.Flat;
            buttonMenu.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
            buttonMenu.FlatAppearance.BorderSize = 2;
            buttonMenu.BackColor = Color.Transparent;
            buttonMenu.ForeColor = Color.FromArgb(52, 152, 219);
            buttonMenu.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            buttonMenu.Cursor = Cursors.Hand;

            // Подписка на события
            buttonSave.MouseEnter += ButtonSave_MouseEnter;
            buttonSave.MouseLeave += ButtonSave_MouseLeave;
            buttonDelete.MouseEnter += ButtonDelete_MouseEnter;
            buttonDelete.MouseLeave += ButtonDelete_MouseLeave;
            buttonMenu.MouseEnter += ButtonMenu_MouseEnter;
            buttonMenu.MouseLeave += ButtonMenu_MouseLeave;
        }

        // Эффекты наведения
        private void ButtonSave_MouseEnter(object sender, EventArgs e)
        {
            buttonSave.BackColor = Color.FromArgb(39, 174, 96);
            buttonSave.Font = new Font(buttonSave.Font, FontStyle.Bold | FontStyle.Underline);
        }

        private void ButtonSave_MouseLeave(object sender, EventArgs e)
        {
            buttonSave.BackColor = Color.FromArgb(46, 204, 113);
            buttonSave.Font = new Font(buttonSave.Font, FontStyle.Bold);
        }

        private void ButtonDelete_MouseEnter(object sender, EventArgs e)
        {
            buttonDelete.BackColor = Color.FromArgb(192, 57, 43);
            buttonDelete.Font = new Font(buttonDelete.Font, FontStyle.Bold | FontStyle.Underline);
        }

        private void ButtonDelete_MouseLeave(object sender, EventArgs e)
        {
            buttonDelete.BackColor = Color.FromArgb(231, 76, 60);
            buttonDelete.Font = new Font(buttonDelete.Font, FontStyle.Bold);
        }

        private void ButtonMenu_MouseEnter(object sender, EventArgs e)
        {
            buttonMenu.BackColor = Color.FromArgb(52, 152, 219);
            buttonMenu.ForeColor = Color.White;
            buttonMenu.Font = new Font(buttonMenu.Font, FontStyle.Bold | FontStyle.Underline);
        }

        private void ButtonMenu_MouseLeave(object sender, EventArgs e)
        {
            buttonMenu.BackColor = Color.Transparent;
            buttonMenu.ForeColor = Color.FromArgb(52, 152, 219);
            buttonMenu.Font = new Font(buttonMenu.Font, FontStyle.Bold);
        }

        private void LoadClientData(int clientId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            FIO,
                            passport_series_number,
                            date_of_birth,
                            telephone_number,
                            email,
                            gender
                        FROM client 
                        WHERE id = @ClientId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientId", clientId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxFIO.Text = reader["FIO"].ToString();

                                // Загружаем паспорт в маску
                                string passport = reader["passport_series_number"].ToString();
                                if (!string.IsNullOrEmpty(passport) && passport.Length == 10)
                                {
                                    maskedTextBoxPassport.Text =
                                        $"{passport.Substring(0, 2)} {passport.Substring(2, 2)} {passport.Substring(4)}";
                                }
                                else
                                {
                                    maskedTextBoxPassport.Text = passport;
                                }

                                if (reader["date_of_birth"] != DBNull.Value)
                                {
                                    dateTimePickerBirthDate.Value = Convert.ToDateTime(reader["date_of_birth"]);
                                }

                                string phone = reader["telephone_number"].ToString();
                                maskedTextBoxPhone.Text = FormatPhoneForMask(phone);

                                textBoxEmail.Text = reader["email"].ToString();

                                string gender = reader["gender"].ToString();
                                if (gender == "М" || gender == "Мужской")
                                {
                                    comboBoxGender.SelectedIndex = 0;
                                }
                                else if (gender == "Ж" || gender == "Женский")
                                {
                                    comboBoxGender.SelectedIndex = 1;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Клиент не найден в базе данных.", "Ошибка",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных клиента: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // ИСПРАВЛЕНО: всегда возвращает строку
        private string FormatPhoneForMask(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return "";

            string digits = new string(phone.Where(char.IsDigit).ToArray());

            if (digits.Length == 11 && (digits.StartsWith("7") || digits.StartsWith("8")))
            {
                digits = digits.Substring(1);
            }

            return digits.Length >= 10 ? digits.Substring(0, 10) : digits;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            if (currentMode == FormMode.Add)
            {
                AddNewClient();
            }
            else
            {
                UpdateClient();
            }
        }

        // ИСПРАВЛЕНО: всегда возвращает bool
        private bool ValidateData()
        {
            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(textBoxFIO.Text))
            {
                ShowValidationError("Введите ФИО клиента", textBoxFIO);
                return false;
            }

            var nameParts = textBoxFIO.Text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length < 2)
            {
                ShowValidationError("Введите фамилию и имя (минимум 2 слова)", textBoxFIO);
                return false;
            }

            // Проверка паспорта
            string passport = GetCleanPassport();
            if (string.IsNullOrWhiteSpace(passport))
            {
                ShowValidationError("Введите номер паспорта полностью", maskedTextBoxPassport);
                return false;
            }

            if (passport.Length != 10)
            {
                ShowValidationError("Номер паспорта должен содержать ровно 10 цифр\nПример: 4510 123456", maskedTextBoxPassport);
                return false;
            }

            // Проверка телефона
            string phone = GetCleanPhone();
            if (string.IsNullOrWhiteSpace(phone))
            {
                ShowValidationError("Введите номер телефона полностью", maskedTextBoxPhone);
                return false;
            }

            if (phone.Length != 10)
            {
                ShowValidationError("Номер телефона должен содержать 10 цифр\nПример: +7 (900) 123-45-67", maskedTextBoxPhone);
                return false;
            }

            // Проверка email (если указан)
            if (!string.IsNullOrWhiteSpace(textBoxEmail.Text) && !IsValidEmail(textBoxEmail.Text))
            {
                ShowValidationError("Введите корректный email адрес\nПример: example@mail.ru", textBoxEmail);
                return false;
            }

            // Проверка даты рождения
            if (dateTimePickerBirthDate.Value > DateTime.Now)
            {
                ShowValidationError("Дата рождения не может быть в будущем", dateTimePickerBirthDate);
                return false;
            }

            int age = DateTime.Now.Year - dateTimePickerBirthDate.Value.Year;
            if (dateTimePickerBirthDate.Value.Date > DateTime.Now.AddYears(-age))
                age--;

            if (age < 18)
            {
                ShowValidationError("Клиент должен быть совершеннолетним (18+)", dateTimePickerBirthDate);
                return false;
            }

            // Проверка пола
            if (comboBoxGender.SelectedIndex == -1)
            {
                ShowValidationError("Выберите пол", comboBoxGender);
                return false;
            }

            return true;
        }

        // ИСПРАВЛЕНО: всегда возвращает строку
        private string GetCleanPassport()
        {
            string result = new string(maskedTextBoxPassport.Text.Where(char.IsDigit).ToArray());
            return string.IsNullOrEmpty(result) ? "" : result;
        }

        // ИСПРАВЛЕНО: всегда возвращает строку
        private string GetCleanPhone()
        {
            string phone = new string(maskedTextBoxPhone.Text.Where(char.IsDigit).ToArray());

            if (phone.Length == 11 && phone.StartsWith("7"))
            {
                return phone.Substring(1);
            }

            return phone.Length == 10 ? phone : "";
        }

        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Ошибка ввода",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            control.BackColor = Color.FromArgb(255, 230, 230);
        }

        // ИСПРАВЛЕНО: всегда возвращает bool
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // ИСПРАВЛЕНО: всегда возвращает bool
        private bool CheckForDuplicates(string passport, string phone, int excludeClientId = -1)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Проверка дублей паспорта
                    string passportQuery = @"
                        SELECT id, FIO, passport_series_number 
                        FROM client 
                        WHERE passport_series_number = @Passport 
                          AND (@ExcludeId = -1 OR id != @ExcludeId)";

                    using (MySqlCommand passportCommand = new MySqlCommand(passportQuery, connection))
                    {
                        passportCommand.Parameters.AddWithValue("@Passport", passport);
                        passportCommand.Parameters.AddWithValue("@ExcludeId", excludeClientId);

                        using (MySqlDataReader reader = passportCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show(
                                    $"Паспорт уже используется другим клиентом:\n\n" +
                                    $"ФИО: {reader["FIO"]}\n" +
                                    $"Паспорт: {reader["passport_series_number"]}",
                                    "Дублирование паспорта",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                return true;
                            }
                        }
                    }

                    // Проверка дублей телефона
                    if (!string.IsNullOrEmpty(phone))
                    {
                        string formattedPhone = FormatPhoneForDatabase(phone);
                        string phoneQuery = @"
                            SELECT id, FIO, telephone_number 
                            FROM client 
                            WHERE telephone_number = @Phone 
                              AND (@ExcludeId = -1 OR id != @ExcludeId)";

                        using (MySqlCommand phoneCommand = new MySqlCommand(phoneQuery, connection))
                        {
                            phoneCommand.Parameters.AddWithValue("@Phone", formattedPhone);
                            phoneCommand.Parameters.AddWithValue("@ExcludeId", excludeClientId);

                            using (MySqlDataReader reader = phoneCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    MessageBox.Show(
                                        $"Телефон уже используется другим клиентом:\n\n" +
                                        $"ФИО: {reader["FIO"]}\n" +
                                        $"Телефон: {reader["telephone_number"]}",
                                        "Дублирование телефона",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                                    return true;
                                }
                            }
                        }
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке дубликатов: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ИСПРАВЛЕНО: всегда возвращает строку
        private string FormatPhoneForDatabase(string cleanPhone)
        {
            if (cleanPhone.Length == 10)
            {
                return $"+7({cleanPhone.Substring(0, 3)}){cleanPhone.Substring(3, 3)}-{cleanPhone.Substring(6, 2)}-{cleanPhone.Substring(8)}";
            }

            if (cleanPhone.StartsWith("+7("))
            {
                return cleanPhone;
            }

            return cleanPhone; // Добавлен возврат для всех случаев
        }

        private void AddNewClient()
        {
            string passport = GetCleanPassport();
            string phone = GetCleanPhone();

            if (CheckForDuplicates(passport, phone))
                return;

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string formattedPhone = FormatPhoneForDatabase(phone);

                    string insertQuery = @"
                        INSERT INTO client (
                            FIO, 
                            passport_series_number, 
                            date_of_birth, 
                            telephone_number, 
                            email, 
                            gender
                        ) VALUES (
                            @FIO, 
                            @Passport, 
                            @BirthDate, 
                            @Phone, 
                            @Email, 
                            @Gender
                        )";

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FIO", textBoxFIO.Text.Trim());
                        command.Parameters.AddWithValue("@Passport", passport);
                        command.Parameters.AddWithValue("@BirthDate", dateTimePickerBirthDate.Value);
                        command.Parameters.AddWithValue("@Phone", formattedPhone);
                        command.Parameters.AddWithValue("@Email",
                            string.IsNullOrWhiteSpace(textBoxEmail.Text) ?
                            DBNull.Value : (object)textBoxEmail.Text.Trim());
                        command.Parameters.AddWithValue("@Gender",
                            comboBoxGender.SelectedItem.ToString() == "👨 Мужской" ? "М" : "Ж");

                        command.ExecuteNonQuery();
                    }

                    DataChanged = true;
                    MessageBox.Show("✅ Клиент успешно добавлен!", "Успех",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062 && ex.Message.Contains("passport_series_number"))
                {
                    MessageBox.Show("❌ Клиент с таким номером паспорта уже существует.",
                                   "Ошибка дублирования",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 1062 && ex.Message.Contains("telephone_number"))
                {
                    MessageBox.Show("❌ Клиент с таким номером телефона уже существует.",
                                   "Ошибка дублирования",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при добавлении клиента: {ex.Message}",
                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении клиента: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateClient()
        {
            string passport = GetCleanPassport();
            string phone = GetCleanPhone();

            if (CheckForDuplicates(passport, phone, editingClientId))
                return;

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string formattedPhone = FormatPhoneForDatabase(phone);

                    string updateQuery = @"
                        UPDATE client SET
                            FIO = @FIO, 
                            passport_series_number = @Passport, 
                            date_of_birth = @BirthDate, 
                            telephone_number = @Phone, 
                            email = @Email, 
                            gender = @Gender
                        WHERE id = @ClientId";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FIO", textBoxFIO.Text.Trim());
                        command.Parameters.AddWithValue("@Passport", passport);
                        command.Parameters.AddWithValue("@BirthDate", dateTimePickerBirthDate.Value);
                        command.Parameters.AddWithValue("@Phone", formattedPhone);
                        command.Parameters.AddWithValue("@Email",
                            string.IsNullOrWhiteSpace(textBoxEmail.Text) ?
                            DBNull.Value : (object)textBoxEmail.Text.Trim());
                        command.Parameters.AddWithValue("@Gender",
                            comboBoxGender.SelectedItem.ToString() == "👨 Мужской" ? "М" : "Ж");
                        command.Parameters.AddWithValue("@ClientId", editingClientId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DataChanged = true;
                            MessageBox.Show("✅ Данные клиента успешно обновлены!", "Успех",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Клиент не найден или данные не были изменены.", "Информация",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062 && ex.Message.Contains("passport_series_number"))
                {
                    MessageBox.Show("❌ Другой клиент с таким номером паспорта уже существует.",
                                   "Ошибка дублирования",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 1062 && ex.Message.Contains("telephone_number"))
                {
                    MessageBox.Show("❌ Другой клиент с таким номером телефона уже существует.",
                                   "Ошибка дублирования",
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (currentMode != FormMode.Edit)
                return;

            var result = MessageBox.Show("Вы уверены, что хотите удалить этого клиента?\n" +
                                        "⚠️ Это действие нельзя отменить.",
                                        "Подтверждение удаления",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteClient();
            }
        }

        private void DeleteClient()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM client WHERE id = @ClientId";

                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ClientId", editingClientId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DataChanged = true;
                            MessageBox.Show("🗑️ Клиент успешно удален!", "Успех",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Клиент не найден.", "Ошибка",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show("❌ Нельзя удалить клиента, у которого есть бронирования.\n" +
                                  "Сначала удалите все связанные бронирования.",
                                  "Ошибка удаления",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при удалении клиента: {ex.Message}",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении клиента: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

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
    }
}