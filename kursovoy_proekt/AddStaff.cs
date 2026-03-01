using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class AddStaff : Form
    {
        public enum FormMode { Add, Edit }
        private FormMode currentMode;
        private int editingStaffId = -1;
        public bool DataChanged { get; private set; } = false;
        private byte[] currentPhotoBytes = null;

        public AddStaff()
        {
            InitializeComponent();
            currentMode = FormMode.Add;
            SetupForm();
        }

        public AddStaff(int staffId)
        {
            InitializeComponent();
            currentMode = FormMode.Edit;
            editingStaffId = staffId;
            SetupForm();
        }

        private void SetupForm()
        {
            // Загружаем должности
            LoadPositions();

            // Настройка дат
            dateTimePickerHireDate.MaxDate = DateTime.Now;
            dateTimePickerHireDate.Value = DateTime.Now;

            if (currentMode == FormMode.Edit)
            {
                labelHeader.Text = "✏️ РЕДАКТИРОВАНИЕ СОТРУДНИКА";
                buttonSave.Text = "💾 СОХРАНИТЬ";
                buttonFire.Visible = true;
                LoadStaffData();
            }
            else
            {
                labelHeader.Text = "➕ ДОБАВЛЕНИЕ СОТРУДНИКА";
                buttonSave.Text = "✅ ДОБАВИТЬ";
                buttonFire.Visible = false;
                comboBoxStatus.SelectedIndex = 0;
            }

            // Подписка на события
            buttonLoadPhoto.Click += ButtonLoadPhoto_Click;
            buttonClearPhoto.Click += ButtonClearPhoto_Click;
            buttonSave.Click += ButtonSave_Click;
            buttonFire.Click += ButtonFire_Click;
            buttonCancel.Click += ButtonCancel_Click;

            textBoxSalary.KeyPress += TextBoxSalary_KeyPress;
            textBoxSalary.Leave += TextBoxSalary_Leave;
        }

        private void LoadPositions()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT id, position_name FROM positions ORDER BY position_name";

                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        comboBoxPosition.Items.Clear();
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string name = reader.GetString("position_name");
                            comboBoxPosition.Items.Add(new PositionItem(id, name));
                        }
                    }
                }

                if (comboBoxPosition.Items.Count > 0)
                    comboBoxPosition.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки должностей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class PositionItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public PositionItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private void LoadStaffData()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            p.FIO,
                            p.position_id,
                            p.job_title,
                            p.telephone_number,
                            p.email,
                            p.passport_series_number,
                            p.address,
                            p.hire_date,
                            p.salary,
                            p.is_active,
                            p.photo
                        FROM personal p
                        WHERE p.id = @staffId";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@staffId", editingStaffId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxFIO.Text = reader["FIO"].ToString();

                                int positionId = reader.GetInt32("position_id");
                                foreach (PositionItem item in comboBoxPosition.Items)
                                {
                                    if (item.Id == positionId)
                                    {
                                        comboBoxPosition.SelectedItem = item;
                                        break;
                                    }
                                }

                                string phone = reader["telephone_number"].ToString();
                                maskedTextBoxPhone.Text = FormatPhoneForMask(phone);

                                textBoxEmail.Text = reader["email"].ToString();

                                string passport = reader["passport_series_number"].ToString();
                                if (!string.IsNullOrEmpty(passport) && passport.Length == 10)
                                {
                                    maskedTextBoxPassport.Text =
                                        $"{passport.Substring(0, 2)} {passport.Substring(2, 2)} {passport.Substring(4)}";
                                }

                                textBoxAddress.Text = reader["address"].ToString();

                                if (reader["hire_date"] != DBNull.Value)
                                {
                                    dateTimePickerHireDate.Value = Convert.ToDateTime(reader["hire_date"]);
                                }

                                if (reader["salary"] != DBNull.Value)
                                {
                                    decimal salary = Convert.ToDecimal(reader["salary"]);
                                    textBoxSalary.Text = salary.ToString("F2");
                                }

                                bool isActive = reader["is_active"] != DBNull.Value && Convert.ToBoolean(reader["is_active"]);
                                comboBoxStatus.SelectedIndex = isActive ? 0 : 1;

                                // ЗАЩИТА: Если это текущий пользователь, блокируем кнопку увольнения
                                if (editingStaffId == Session.UserId)
                                {
                                    buttonFire.Enabled = false;
                                    buttonFire.Text = "НЕЛЬЗЯ УВОЛИТЬ СЕБЯ";
                                    buttonFire.BackColor = Color.Gray;
                                }

                                if (reader["photo"] != DBNull.Value)
                                {
                                    currentPhotoBytes = (byte[])reader["photo"];
                                    using (MemoryStream ms = new MemoryStream(currentPhotoBytes))
                                    {
                                        pictureBoxPhoto.Image = Image.FromStream(ms);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void TextBoxSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void TextBoxSalary_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxSalary.Text, out decimal salary))
            {
                textBoxSalary.Text = salary.ToString("F2");
            }
            else
            {
                textBoxSalary.Text = "0.00";
            }
        }

        private void ButtonLoadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Выберите фото сотрудника";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Image original = Image.FromFile(openFileDialog.FileName))
                        {
                            Image resized = ResizeImage(original, 200, 200);
                            pictureBoxPhoto.Image = resized;

                            using (MemoryStream ms = new MemoryStream())
                            {
                                resized.Save(ms, ImageFormat.Jpeg);
                                currentPhotoBytes = ms.ToArray();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void ButtonClearPhoto_Click(object sender, EventArgs e)
        {
            pictureBoxPhoto.Image = null;
            currentPhotoBytes = null;
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(textBoxFIO.Text))
            {
                ShowError("Введите ФИО сотрудника", textBoxFIO);
                return false;
            }

            if (comboBoxPosition.SelectedItem == null)
            {
                ShowError("Выберите должность", comboBoxPosition);
                return false;
            }

            string phone = GetCleanPhone();
            if (string.IsNullOrWhiteSpace(phone) || phone.Length != 10)
            {
                ShowError("Введите корректный номер телефона", maskedTextBoxPhone);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(textBoxEmail.Text) && !IsValidEmail(textBoxEmail.Text))
            {
                ShowError("Введите корректный email адрес", textBoxEmail);
                return false;
            }

            string passport = GetCleanPassport();
            if (!string.IsNullOrWhiteSpace(passport) && passport.Length != 10)
            {
                ShowError("Паспорт должен содержать 10 цифр", maskedTextBoxPassport);
                return false;
            }

            if (!decimal.TryParse(textBoxSalary.Text, out decimal salary) || salary < 0)
            {
                ShowError("Введите корректную сумму зарплаты", textBoxSalary);
                return false;
            }

            return true;
        }

        private string GetCleanPhone()
        {
            string phone = new string(maskedTextBoxPhone.Text.Where(char.IsDigit).ToArray());
            if (phone.Length == 11 && phone.StartsWith("7"))
                return phone.Substring(1);
            return phone;
        }

        private string GetCleanPassport()
        {
            return new string(maskedTextBoxPassport.Text.Where(char.IsDigit).ToArray());
        }

        private bool IsValidEmail(string email)
        {
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

        private void ShowError(string message, Control control)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
            control.BackColor = Color.FromArgb(255, 230, 230);
        }

        private string FormatPhoneForDB(string cleanPhone)
        {
            if (cleanPhone.Length == 10)
            {
                return $"+7({cleanPhone.Substring(0, 3)}){cleanPhone.Substring(3, 3)}-{cleanPhone.Substring(6, 2)}-{cleanPhone.Substring(8)}";
            }
            return cleanPhone;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            if (currentMode == FormMode.Add)
                SaveNewStaff();
            else
                UpdateStaff();
        }

        private void SaveNewStaff()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string phone = GetCleanPhone();
                    string formattedPhone = FormatPhoneForDB(phone);
                    string passport = GetCleanPassport();
                    decimal salary = decimal.Parse(textBoxSalary.Text);
                    bool isActive = comboBoxStatus.SelectedIndex == 0;

                    PositionItem selectedPosition = (PositionItem)comboBoxPosition.SelectedItem;

                    string insertQuery = @"
                        INSERT INTO personal (
                            FIO, position_id, job_title, telephone_number, email, 
                            passport_series_number, address, hire_date, salary, is_active, photo
                        ) VALUES (
                            @fio, @positionId, @positionName, @phone, @email, 
                            @passport, @address, @hireDate, @salary, @isActive, @photo
                        )";

                    using (var cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@fio", textBoxFIO.Text.Trim());
                        cmd.Parameters.AddWithValue("@positionId", selectedPosition.Id);
                        cmd.Parameters.AddWithValue("@positionName", selectedPosition.Name);
                        cmd.Parameters.AddWithValue("@phone", formattedPhone);
                        cmd.Parameters.AddWithValue("@email",
                            string.IsNullOrWhiteSpace(textBoxEmail.Text) ? DBNull.Value : (object)textBoxEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@passport",
                            string.IsNullOrWhiteSpace(passport) ? DBNull.Value : (object)passport);
                        cmd.Parameters.AddWithValue("@address",
                            string.IsNullOrWhiteSpace(textBoxAddress.Text) ? DBNull.Value : (object)textBoxAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@hireDate", dateTimePickerHireDate.Value.Date);
                        cmd.Parameters.AddWithValue("@salary", salary);
                        cmd.Parameters.AddWithValue("@isActive", isActive);
                        cmd.Parameters.AddWithValue("@photo", currentPhotoBytes ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("✅ Сотрудник успешно добавлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    if (ex.Message.Contains("email"))
                        MessageBox.Show("❌ Сотрудник с таким email уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (ex.Message.Contains("passport_series_number"))
                        MessageBox.Show("❌ Сотрудник с таким паспортом уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStaff()
        {
            // ЗАЩИТА: Не даем изменить свой статус на "Уволен"
            if (editingStaffId == Session.UserId && comboBoxStatus.SelectedIndex == 1)
            {
                MessageBox.Show("❌ Вы не можете уволить самого себя через редактирование!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxStatus.SelectedIndex = 0; // Возвращаем "Активен"
                return;
            }

            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string phone = GetCleanPhone();
                    string formattedPhone = FormatPhoneForDB(phone);
                    string passport = GetCleanPassport();
                    decimal salary = decimal.Parse(textBoxSalary.Text);
                    bool isActive = comboBoxStatus.SelectedIndex == 0;

                    PositionItem selectedPosition = (PositionItem)comboBoxPosition.SelectedItem;

                    string updateQuery = @"
                        UPDATE personal SET
                            FIO = @fio,
                            position_id = @positionId,
                            job_title = @positionName,
                            telephone_number = @phone,
                            email = @email,
                            passport_series_number = @passport,
                            address = @address,
                            hire_date = @hireDate,
                            salary = @salary,
                            is_active = @isActive,
                            photo = @photo
                        WHERE id = @staffId";

                    using (var cmd = new MySqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@fio", textBoxFIO.Text.Trim());
                        cmd.Parameters.AddWithValue("@positionId", selectedPosition.Id);
                        cmd.Parameters.AddWithValue("@positionName", selectedPosition.Name);
                        cmd.Parameters.AddWithValue("@phone", formattedPhone);
                        cmd.Parameters.AddWithValue("@email",
                            string.IsNullOrWhiteSpace(textBoxEmail.Text) ? DBNull.Value : (object)textBoxEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@passport",
                            string.IsNullOrWhiteSpace(passport) ? DBNull.Value : (object)passport);
                        cmd.Parameters.AddWithValue("@address",
                            string.IsNullOrWhiteSpace(textBoxAddress.Text) ? DBNull.Value : (object)textBoxAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@hireDate", dateTimePickerHireDate.Value.Date);
                        cmd.Parameters.AddWithValue("@salary", salary);
                        cmd.Parameters.AddWithValue("@isActive", isActive);
                        cmd.Parameters.AddWithValue("@photo", currentPhotoBytes ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@staffId", editingStaffId);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("✅ Данные сотрудника обновлены!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    if (ex.Message.Contains("email"))
                        MessageBox.Show("❌ Сотрудник с таким email уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (ex.Message.Contains("passport_series_number"))
                        MessageBox.Show("❌ Сотрудник с таким паспортом уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Ошибка при обновлении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonFire_Click(object sender, EventArgs e)
        {
            // ЗАЩИТА: Не даем уволить самого себя
            if (editingStaffId == Session.UserId)
            {
                MessageBox.Show("❌ Вы не можете уволить самого себя!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите уволить этого сотрудника?\n" +
                                        "⚠️ Это действие нельзя отменить.",
                                        "Подтверждение увольнения",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var connection = DatabaseConnection.GetConnection())
                    {
                        connection.Open();

                        string query = "UPDATE personal SET is_active = FALSE WHERE id = @staffId";

                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@staffId", editingStaffId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("🔥 Сотрудник уволен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataChanged = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при увольнении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}