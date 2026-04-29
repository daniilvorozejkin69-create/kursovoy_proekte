using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class AddHous : Form
    {
        public enum FormMode { Add, Edit }
        private FormMode currentMode;
        private int editingHouseId = -1;
        public bool DataChanged { get; private set; } = false;

        // Конструктор для добавления нового дома
        public AddHous()
        {
            InitializeComponent();
            currentMode = FormMode.Add;
            LoadHouseClasses();
            SetupForm();
        }

        // Конструктор для редактирования существующего дома
        public AddHous(int houseId)
        {
            InitializeComponent();
            currentMode = FormMode.Edit;
            editingHouseId = houseId;
            LoadHouseClasses();
            SetupForm();
        }

        private void SetupForm()
        {
            if (currentMode == FormMode.Edit)
            {
                labelHeader.Text = "РЕДАКТИРОВАНИЕ ДОМА";
                buttonSave.Text = "💾 СОХРАНИТЬ ИЗМЕНЕНИЯ";
                buttonDelete.Visible = true;
                LoadHouseData(editingHouseId);
            }
            else
            {
                labelHeader.Text = "ДОБАВЛЕНИЕ НОВОГО ДОМА";
                buttonSave.Text = "➕ ДОБАВИТЬ ДОМ";
                buttonDelete.Visible = false;
            }
        }

        private void LoadHouseClasses()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT id, class FROM home_class ORDER BY class";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            comboBoxHouseClass.Items.Clear();
                            while (reader.Read())
                            {
                                comboBoxHouseClass.Items.Add(new
                                {
                                    Id = reader["id"],
                                    Name = reader["class"].ToString()
                                });
                            }
                        }
                    }

                    comboBoxHouseClass.DisplayMember = "Name";
                    comboBoxHouseClass.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке классов домов: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHouseData(int houseId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            h.name,
                            h.address_number,
                            h.capacity,
                            h.description,
                            h.home_class_id,
                            hc.class
                        FROM house h
                        JOIN home_class hc ON h.home_class_id = hc.id
                        WHERE h.id = @HouseId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@HouseId", houseId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxName.Text = reader["name"].ToString();
                                textBoxAddressNumber.Text = reader["address_number"].ToString();
                                textBoxCapacity.Text = reader["capacity"].ToString();
                                textBoxDescription.Text = reader["description"].ToString();

                                foreach (var item in comboBoxHouseClass.Items)
                                {
                                    dynamic houseClass = item;
                                    if (houseClass.Id.ToString() == reader["home_class_id"].ToString())
                                    {
                                        comboBoxHouseClass.SelectedItem = item;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Дом не найден в базе данных.", "Ошибка",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных дома: {ex.Message}", "Ошибка",
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
                AddNewHouse();
            }
            else
            {
                UpdateHouse();
            }
        }

        private bool ValidateData()
        {
            // Проверка названия
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                ShowValidationError("Введите название дома", textBoxName);
                return false;
            }

            if (textBoxName.Text.Trim().Length > 100)
            {
                ShowValidationError("Название дома не должно превышать 100 символов", textBoxName);
                return false;
            }

            // Проверка номера дома
            if (string.IsNullOrWhiteSpace(textBoxAddressNumber.Text))
            {
                ShowValidationError("Введите номер дома", textBoxAddressNumber);
                return false;
            }

            if (textBoxAddressNumber.Text.Trim().Length > 10)
            {
                ShowValidationError("Номер дома не должен превышать 10 символов", textBoxAddressNumber);
                return false;
            }

            // Проверка вместимости
            if (!int.TryParse(textBoxCapacity.Text, out int capacity) || capacity <= 0)
            {
                ShowValidationError("Введите корректную вместимость (целое число больше 0)", textBoxCapacity);
                return false;
            }

            if (capacity > 999)
            {
                ShowValidationError("Вместимость не может превышать 999 человек", textBoxCapacity);
                return false;
            }

            // Проверка класса дома
            if (comboBoxHouseClass.SelectedIndex == -1)
            {
                ShowValidationError("Выберите класс дома", comboBoxHouseClass);
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

        private bool CheckForDuplicates(string name, string addressNumber, int excludeHouseId = -1)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    // Проверяем дубли по названию
                    string query = @"
                        SELECT id, name, address_number 
                        FROM house 
                        WHERE (name = @Name OR address_number = @AddressNumber)
                          AND (@ExcludeId = -1 OR id != @ExcludeId)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@AddressNumber", addressNumber);
                        command.Parameters.AddWithValue("@ExcludeId", excludeHouseId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string duplicateInfo = $"Найден существующий дом:\n\n";
                                duplicateInfo += $"Название: {reader["name"]}\n";
                                duplicateInfo += $"Номер: {reader["address_number"]}\n\n";

                                string existingName = reader["name"].ToString();
                                string existingAddress = reader["address_number"].ToString();

                                if (existingName == name && existingAddress == addressNumber)
                                {
                                    duplicateInfo += "Совпадают и название, и номер дома!";
                                }
                                else if (existingName == name)
                                {
                                    duplicateInfo += "Совпадает название дома!";
                                }
                                else if (existingAddress == addressNumber)
                                {
                                    duplicateInfo += "Совпадает номер дома!";
                                }

                                MessageBox.Show(duplicateInfo, "Найдены дубликаты",
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void AddNewHouse()
        {
            string name = textBoxName.Text.Trim();
            string addressNumber = textBoxAddressNumber.Text.Trim();

            // Проверка дублей
            if (CheckForDuplicates(name, addressNumber))
                return;

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string insertQuery = @"
                        INSERT INTO house (
                            name, 
                            address_number, 
                            capacity, 
                            description, 
                            home_class_id
                        ) VALUES (
                            @Name, 
                            @AddressNumber, 
                            @Capacity, 
                            @Description, 
                            @HomeClassId
                        )";

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@AddressNumber", addressNumber);
                        command.Parameters.AddWithValue("@Capacity", Convert.ToInt32(textBoxCapacity.Text.Trim()));
                        command.Parameters.AddWithValue("@Description",
                            string.IsNullOrWhiteSpace(textBoxDescription.Text) ?
                            DBNull.Value : (object)textBoxDescription.Text.Trim());
                        command.Parameters.AddWithValue("@HomeClassId",
                            ((dynamic)comboBoxHouseClass.SelectedItem).Id);

                        command.ExecuteNonQuery();
                    }

                    DataChanged = true;
                    MessageBox.Show("Дом успешно добавлен!", "Успех",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Ошибка дублирования ключа
                {
                    MessageBox.Show("Дом с таким названием или номером уже существует.",
                                   "Ошибка дублирования",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при добавлении дома: {ex.Message}",
                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении дома: {ex.Message}",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateHouse()
        {
            string name = textBoxName.Text.Trim();
            string addressNumber = textBoxAddressNumber.Text.Trim();

            // Проверка дублей (исключая текущий дом)
            if (CheckForDuplicates(name, addressNumber, editingHouseId))
                return;

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string updateQuery = @"
                        UPDATE house SET
                            name = @Name, 
                            address_number = @AddressNumber, 
                            capacity = @Capacity, 
                            description = @Description, 
                            home_class_id = @HomeClassId
                        WHERE id = @HouseId";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@AddressNumber", addressNumber);
                        command.Parameters.AddWithValue("@Capacity", Convert.ToInt32(textBoxCapacity.Text.Trim()));
                        command.Parameters.AddWithValue("@Description",
                            string.IsNullOrWhiteSpace(textBoxDescription.Text) ?
                            DBNull.Value : (object)textBoxDescription.Text.Trim());
                        command.Parameters.AddWithValue("@HomeClassId",
                            ((dynamic)comboBoxHouseClass.SelectedItem).Id);
                        command.Parameters.AddWithValue("@HouseId", editingHouseId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DataChanged = true;
                            MessageBox.Show("Данные дома успешно обновлены!", "Успех",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Дом не найден или данные не были изменены.", "Информация",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Ошибка дублирования ключа
                {
                    MessageBox.Show("Другой дом с таким названием или номером уже существует.",
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

            var result = MessageBox.Show("Вы уверены, что хотите удалить этот дом?\n" +
                                        "Все связанные бронирования будут удалены.\n" +
                                        "Это действие нельзя отменить.",
                                        "Подтверждение удаления",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteHouse();
            }
        }

        private void DeleteHouse()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM house WHERE id = @HouseId";

                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@HouseId", editingHouseId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DataChanged = true;
                            MessageBox.Show("Дом успешно удален!", "Успех",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Дом не найден.", "Ошибка",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show("Нельзя удалить дом, у которого есть бронирования.\n" +
                                  "Сначала удалите все связанные бронирования.",
                                  "Ошибка удаления",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при удалении дома: {ex.Message}",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении дома: {ex.Message}",
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

        // Обработка ввода только цифр для вместимости
        private void textBoxCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Автоформатирование вместимости
        private void textBoxCapacity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCapacity.Text))
                return;

            // Ограничиваем максимальное значение
            if (textBoxCapacity.Text.Length > 3)
            {
                textBoxCapacity.Text = textBoxCapacity.Text.Substring(0, 3);
                textBoxCapacity.SelectionStart = textBoxCapacity.Text.Length;
            }

            // Проверяем, что значение не начинается с 0
            if (textBoxCapacity.Text.StartsWith("0") && textBoxCapacity.Text.Length > 1)
            {
                textBoxCapacity.Text = textBoxCapacity.Text.TrimStart('0');
                textBoxCapacity.SelectionStart = textBoxCapacity.Text.Length;
            }
        }

        // Валидация в реальном времени
        private void textBoxCapacity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxCapacity.Text))
            {
                if (!int.TryParse(textBoxCapacity.Text, out int capacity) || capacity <= 0)
                {
                    textBoxCapacity.BackColor = Color.FromArgb(255, 230, 230);
                }
                else
                {
                    textBoxCapacity.BackColor = Color.White;
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

        private void textBoxAddressNumber_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAddressNumber.Text.Length > 10)
            {
                textBoxAddressNumber.Text = textBoxAddressNumber.Text.Substring(0, 10);
                textBoxAddressNumber.SelectionStart = textBoxAddressNumber.Text.Length;
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