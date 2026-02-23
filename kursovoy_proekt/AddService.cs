using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kursovoy_proekt
{
    public partial class AddService : Form
    {
        public enum FormMode { Add, Edit }
        private FormMode currentMode;
        private int editingServiceId = -1;
        public bool DataChanged { get; private set; } = false;

        // Конструктор для добавления новой услуги
        public AddService()
        {
            InitializeComponent();
            currentMode = FormMode.Add;
            SetupForm();
        }

        // Конструктор для редактирования существующей услуги
        public AddService(int serviceId)
        {
            InitializeComponent();
            currentMode = FormMode.Edit;
            editingServiceId = serviceId;
            SetupForm();
        }

        private void SetupForm()
        {
            if (currentMode == FormMode.Edit)
            {
                labelHeader.Text = "РЕДАКТИРОВАНИЕ УСЛУГИ";
                buttonSave.Text = "💾 СОХРАНИТЬ ИЗМЕНЕНИЯ";
                buttonDelete.Visible = true;
                LoadServiceData(editingServiceId);
            }
            else
            {
                labelHeader.Text = "ДОБАВЛЕНИЕ НОВОЙ УСЛУГИ";
                buttonSave.Text = "➕ ДОБАВИТЬ УСЛУГУ";
                buttonDelete.Visible = false;
            }
        }

        private void LoadServiceData(int serviceId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            name_services,
                            duration,
                            price,
                            description
                        FROM services 
                        WHERE id = @ServiceId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceId", serviceId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxName.Text = reader["name_services"].ToString();

                                // Загружаем продолжительность
                                if (reader["duration"] != DBNull.Value)
                                {
                                    textBoxDuration.Text = reader["duration"].ToString();
                                }

                                // Загружаем цену
                                if (reader["price"] != DBNull.Value)
                                {
                                    decimal price = Convert.ToDecimal(reader["price"]);
                                    textBoxPrice.Text = price.ToString("0.00");
                                }

                                textBoxDescription.Text = reader["description"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Услуга не найдена в базе данных.", "Ошибка",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных услуги: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            if (currentMode == FormMode.Add)
            {
                AddNewService();
            }
            else
            {
                UpdateService();
            }
        }

        private bool ValidateData()
        {
            // Проверка названия
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                ShowValidationError("Введите название услуги", textBoxName);
                return false;
            }

            if (textBoxName.Text.Trim().Length > 100)
            {
                ShowValidationError("Название услуги не должно превышать 100 символов", textBoxName);
                return false;
            }

            // Проверка продолжительности (если указана)
            if (!string.IsNullOrWhiteSpace(textBoxDuration.Text))
            {
                if (!int.TryParse(textBoxDuration.Text, out int duration) || duration < 0 || duration > 10080) // максимум 7 дней в минутах
                {
                    ShowValidationError("Введите корректную продолжительность (0-10080 минут)", textBoxDuration);
                    return false;
                }
            }

            // Проверка цены
            if (string.IsNullOrWhiteSpace(textBoxPrice.Text))
            {
                ShowValidationError("Введите цену услуги", textBoxPrice);
                return false;
            }

            if (!decimal.TryParse(textBoxPrice.Text, out decimal price) || price < 0 || price > 9999999.99m)
            {
                ShowValidationError("Введите корректную цену (0 - 9 999 999.99)", textBoxPrice);
                return false;
            }

            // Проверка описания (если заполнено)
            if (!string.IsNullOrWhiteSpace(textBoxDescription.Text) && textBoxDescription.Text.Length > 500)
            {
                ShowValidationError("Описание не должно превышать 500 символов", textBoxDescription);
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

        private bool CheckForDuplicates(string serviceName, int excludeServiceId = -1)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT id, name_services, price 
                        FROM services 
                        WHERE name_services = @Name 
                          AND (@ExcludeId = -1 OR id != @ExcludeId)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", serviceName);
                        command.Parameters.AddWithValue("@ExcludeId", excludeServiceId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show(
                                    $"Услуга с таким названием уже существует:\n\n" +
                                    $"Название: {reader["name_services"]}\n" +
                                    $"Цена: {reader["price"]} руб.",
                                    "Дублирование услуги",
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

        private void AddNewService()
        {
            string serviceName = textBoxName.Text.Trim();

            // Проверка дублей
            if (CheckForDuplicates(serviceName))
                return;

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string insertQuery = @"
                        INSERT INTO services (
                            name_services, 
                            duration, 
                            price, 
                            description
                        ) VALUES (
                            @Name, 
                            @Duration, 
                            @Price, 
                            @Description
                        )";

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", serviceName);
                        command.Parameters.AddWithValue("@Duration",
                            string.IsNullOrWhiteSpace(textBoxDuration.Text) ?
                            DBNull.Value : (object)Convert.ToInt32(textBoxDuration.Text));
                        command.Parameters.AddWithValue("@Price", Convert.ToDecimal(textBoxPrice.Text));
                        command.Parameters.AddWithValue("@Description",
                            string.IsNullOrWhiteSpace(textBoxDescription.Text) ?
                            DBNull.Value : (object)textBoxDescription.Text.Trim());

                        command.ExecuteNonQuery();
                    }

                    DataChanged = true;
                    MessageBox.Show("Услуга успешно добавлена!", "Успех",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Ошибка дублирования ключа
                {
                    MessageBox.Show("Услуга с таким названием уже существует.",
                                   "Ошибка дублирования",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при добавлении услуги: {ex.Message}",
                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении услуги: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateService()
        {
            string serviceName = textBoxName.Text.Trim();

            // Проверка дублей (исключая текущую услугу)
            if (CheckForDuplicates(serviceName, editingServiceId))
                return;

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string updateQuery = @"
                        UPDATE services SET
                            name_services = @Name, 
                            duration = @Duration, 
                            price = @Price, 
                            description = @Description
                        WHERE id = @ServiceId";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", serviceName);
                        command.Parameters.AddWithValue("@Duration",
                            string.IsNullOrWhiteSpace(textBoxDuration.Text) ?
                            DBNull.Value : (object)Convert.ToInt32(textBoxDuration.Text));
                        command.Parameters.AddWithValue("@Price", Convert.ToDecimal(textBoxPrice.Text));
                        command.Parameters.AddWithValue("@Description",
                            string.IsNullOrWhiteSpace(textBoxDescription.Text) ?
                            DBNull.Value : (object)textBoxDescription.Text.Trim());
                        command.Parameters.AddWithValue("@ServiceId", editingServiceId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DataChanged = true;
                            MessageBox.Show("Данные услуги успешно обновлены!", "Успех",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Услуга не найдена или данные не были изменены.", "Информация",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Ошибка дублирования ключа
                {
                    MessageBox.Show("Другая услуга с таким названием уже существует.",
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

            var result = MessageBox.Show("Вы уверены, что хотите удалить эту услугу?\n" +
                                        "Она будет удалена из всех связанных заказов.\n" +
                                        "Это действие нельзя отменить.",
                                        "Подтверждение удаления",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteService();
            }
        }

        private void DeleteService()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM services WHERE id = @ServiceId";

                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceId", editingServiceId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DataChanged = true;
                            MessageBox.Show("Услуга успешно удалена!", "Успех",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Услуга не найдена.", "Ошибка",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show("Нельзя удалить услугу, которая используется в бронированиях.\n" +
                                  "Сначала удалите все связанные записи в заказах.",
                                  "Ошибка удаления",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при удалении услуги: {ex.Message}",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении услуги: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

        // Обработка ввода для продолжительности
        private void textBoxDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Автоформатирование продолжительности
        private void textBoxDuration_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDuration.Text))
                return;

            // Ограничиваем максимальную продолжительность (10080 минут = 7 дней)
            if (textBoxDuration.Text.Length > 5)
            {
                textBoxDuration.Text = textBoxDuration.Text.Substring(0, 5);
                textBoxDuration.SelectionStart = textBoxDuration.Text.Length;
            }

            // Проверяем, что значение не начинается с 0
            if (textBoxDuration.Text.StartsWith("0") && textBoxDuration.Text.Length > 1)
            {
                textBoxDuration.Text = textBoxDuration.Text.TrimStart('0');
                textBoxDuration.SelectionStart = textBoxDuration.Text.Length;
            }
        }

        // Обработка ввода для цены
        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем цифры, Backspace, запятую и точку
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Заменяем точку на запятую
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            // Проверяем, что запятая только одна
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            // После запятой можно ввести максимум 2 цифры
            if (e.KeyChar == ',' || (sender as TextBox).Text.Contains(","))
            {
                int commaIndex = (sender as TextBox).Text.IndexOf(',');
                if (commaIndex != -1)
                {
                    string afterComma = (sender as TextBox).Text.Substring(commaIndex + 1);
                    if (afterComma.Length >= 2 && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        // Автоформатирование цены
        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPrice.Text))
                return;

            // Убираем лишние символы
            string text = textBoxPrice.Text;
            textBoxPrice.Text = text;
            textBoxPrice.SelectionStart = textBoxPrice.Text.Length;
        }

        private void textBoxPrice_Leave(object sender, EventArgs e)
        {
            // Форматируем цену при уходе с поля
            if (!string.IsNullOrEmpty(textBoxPrice.Text))
            {
                if (decimal.TryParse(textBoxPrice.Text, out decimal price))
                {
                    textBoxPrice.Text = price.ToString("0.00");
                }
            }
        }

        // Валидация в реальном времени
        private void textBoxDuration_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxDuration.Text))
            {
                if (!int.TryParse(textBoxDuration.Text, out int duration) || duration < 0 || duration > 10080)
                {
                    textBoxDuration.BackColor = Color.FromArgb(255, 230, 230);
                }
                else
                {
                    textBoxDuration.BackColor = Color.White;
                }
            }
        }

        private void textBoxPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPrice.Text))
            {
                if (!decimal.TryParse(textBoxPrice.Text, out decimal price) || price < 0 || price > 9999999.99m)
                {
                    textBoxPrice.BackColor = Color.FromArgb(255, 230, 230);
                }
                else
                {
                    textBoxPrice.BackColor = Color.White;
                }
            }
        }

        // Ограничение длины ввода
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length > 100)
            {
                textBoxName.Text = textBoxName.Text.Substring(0, 100);
                textBoxName.SelectionStart = textBoxName.Text.Length;
            }
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDescription.Text.Length > 500)
            {
                textBoxDescription.Text = textBoxDescription.Text.Substring(0, 500);
                textBoxDescription.SelectionStart = textBoxDescription.Text.Length;
            }
        }
    }
}