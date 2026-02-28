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
            // Настройка элементов
            SetupControls();

            // Загружаем должности в комбобокс
            LoadPositions();

            // Настройка дат
            dateTimePickerBirthDate.MaxDate = DateTime.Now.AddYears(-18);
            dateTimePickerBirthDate.MinDate = DateTime.Now.AddYears(-100);
            dateTimePickerBirthDate.Value = DateTime.Now.AddYears(-30);

            dateTimePickerHireDate.MaxDate = DateTime.Now;
            dateTimePickerHireDate.Value = DateTime.Now;

            if (currentMode == FormMode.Edit)
            {
                labelHeader.Text = "✏️  РЕДАКТИРОВАНИЕ СОТРУДНИКА";
                buttonSave.Text = "💾  СОХРАНИТЬ";
                LoadStaffData();
            }
            else
            {
                labelHeader.Text = "➕  ДОБАВЛЕНИЕ СОТРУДНИКА";
                buttonSave.Text = "✅  ДОБАВИТЬ";
            }

            // Подписка на события
            buttonLoadPhoto.Click += ButtonLoadPhoto_Click;
            buttonClearPhoto.Click += ButtonClearPhoto_Click;
            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Click += ButtonCancel_Click;

            // Эффекты наведения
            buttonSave.MouseEnter += ButtonSave_MouseEnter;
            buttonSave.MouseLeave += ButtonSave_MouseLeave;
            buttonCancel.MouseEnter += ButtonCancel_MouseEnter;
            buttonCancel.MouseLeave += ButtonCancel_MouseLeave;
            buttonLoadPhoto.MouseEnter += ButtonLoadPhoto_MouseEnter;
            buttonLoadPhoto.MouseLeave += ButtonLoadPhoto_MouseLeave;
            buttonClearPhoto.MouseEnter += ButtonClearPhoto_MouseEnter;
            buttonClearPhoto.MouseLeave += ButtonClearPhoto_MouseLeave;

            // Подсветка полей
            textBoxFIO.Enter += Control_Enter;
            textBoxFIO.Leave += Control_Leave;
            textBoxEmail.Enter += Control_Enter;
            textBoxEmail.Leave += Control_Leave;
            textBoxAddress.Enter += Control_Enter;
            textBoxAddress.Leave += Control_Leave;
            maskedTextBoxPhone.Enter += Control_Enter;
            maskedTextBoxPhone.Leave += Control_Leave;
            maskedTextBoxPassport.Enter += Control_Enter;
            maskedTextBoxPassport.Leave += Control_Leave;
            comboBoxPosition.Enter += Control_Enter;
            comboBoxPosition.Leave += Control_Leave;
            dateTimePickerBirthDate.Enter += Control_Enter;
            dateTimePickerBirthDate.Leave += Control_Leave;
            dateTimePickerHireDate.Enter += Control_Enter;
            dateTimePickerHireDate.Leave += Control_Leave;
        }

        private void SetupControls()
        {
            // Настройка масок
            maskedTextBoxPhone.Mask = "+7 (000) 000-00-00";
            maskedTextBoxPhone.PromptChar = ' ';

            maskedTextBoxPassport.Mask = "00 00 000000";
            maskedTextBoxPassport.PromptChar = ' ';

            // Настройка шрифтов
            textBoxFIO.Font = new Font("Segoe UI", 11);
            textBoxEmail.Font = new Font("Segoe UI", 11);
            textBoxAddress.Font = new Font("Segoe UI", 11);

            // Настройка выпадающего списка
            comboBoxPosition.DropDownStyle = ComboBoxStyle.DropDownList;
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

        // Вспомогательный класс для хранения должностей
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
                            p.*
                        FROM personal p
                        WHERE p.id = @staffId";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@staffId", editingStaffId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // ФИО
                                textBoxFIO.Text = reader["FIO"].ToString();

                                // Должность
                                int positionId = reader.GetInt32("position_id");
                                foreach (PositionItem item in comboBoxPosition.Items)
                                {
                                    if (item.Id == positionId)
                                    {
                                        comboBoxPosition.SelectedItem = item;
                                        break;
                                    }
                                }

                                // Дата рождения - проверяем наличие поля
                                if (reader["birth_date"] != DBNull.Value)
                                {
                                    dateTimePickerBirthDate.Value = Convert.ToDateTime(reader["birth_date"]);
                                }

                                // Телефон
                                string phone = reader["telephone_number"].ToString();
                                maskedTextBoxPhone.Text = FormatPhoneForMask(phone);

                                // Email
                                textBoxEmail.Text = reader["email"].ToString();

                                // Паспорт
                                string passport = reader["passport_series_number"].ToString();
                                if (!string.IsNullOrEmpty(passport) && passport.Length == 10)
                                {
                                    maskedTextBoxPassport.Text =
                                        $"{passport.Substring(0, 2)} {passport.Substring(2, 2)} {passport.Substring(4)}";
                                }

                                // Адрес
                                textBoxAddress.Text = reader["address"].ToString();

                                // Дата приёма
                                if (reader["hire_date"] != DBNull.Value)
                                {
                                    dateTimePickerHireDate.Value = Convert.ToDateTime(reader["hire_date"]);
                                }

                                // Фото
                                if (reader["photo"] != DBNull.Value)
                                {
                                    currentPhotoBytes = (byte[])reader["photo"];
                                    using (MemoryStream ms = new MemoryStream(currentPhotoBytes))
                                    {
                                        pictureBoxPhoto.Image = Image.FromStream(ms);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Сотрудник не найден.", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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

                    PositionItem selectedPosition = (PositionItem)comboBoxPosition.SelectedItem;

                    string insertQuery = @"
                        INSERT INTO personal (
                            FIO, position_id, job_title, 
                            telephone_number, email, passport_series_number, 
                            address, hire_date, photo, is_active
                        ) VALUES (
                            @fio, @positionId, @positionName, 
                            @phone, @email, @passport, 
                            @address, @hireDate, @photo, TRUE
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
                        cmd.Parameters.AddWithValue("@photo", currentPhotoBytes ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }

                    DataChanged = true;
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
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string phone = GetCleanPhone();
                    string formattedPhone = FormatPhoneForDB(phone);
                    string passport = GetCleanPassport();

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
                        cmd.Parameters.AddWithValue("@photo", currentPhotoBytes ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@staffId", editingStaffId);

                        cmd.ExecuteNonQuery();
                    }

                    DataChanged = true;
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

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ============================================
        // ЭФФЕКТЫ НАВЕДЕНИЯ
        // ============================================

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

        private void ButtonCancel_MouseEnter(object sender, EventArgs e)
        {
            buttonCancel.BackColor = Color.FromArgb(52, 152, 219);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Font = new Font(buttonCancel.Font, FontStyle.Bold | FontStyle.Underline);
        }

        private void ButtonCancel_MouseLeave(object sender, EventArgs e)
        {
            buttonCancel.BackColor = Color.Transparent;
            buttonCancel.ForeColor = Color.FromArgb(52, 152, 219);
            buttonCancel.Font = new Font(buttonCancel.Font, FontStyle.Bold);
        }

        private void ButtonLoadPhoto_MouseEnter(object sender, EventArgs e)
        {
            buttonLoadPhoto.BackColor = Color.FromArgb(96, 165, 215);
            buttonLoadPhoto.Font = new Font(buttonLoadPhoto.Font, FontStyle.Bold);
        }

        private void ButtonLoadPhoto_MouseLeave(object sender, EventArgs e)
        {
            buttonLoadPhoto.BackColor = Color.FromArgb(76, 145, 195);
            buttonLoadPhoto.Font = new Font(buttonLoadPhoto.Font, FontStyle.Regular);
        }

        private void ButtonClearPhoto_MouseEnter(object sender, EventArgs e)
        {
            buttonClearPhoto.BackColor = Color.FromArgb(240, 100, 100);
            buttonClearPhoto.ForeColor = Color.White;
            buttonClearPhoto.Font = new Font(buttonClearPhoto.Font, FontStyle.Bold);
        }

        private void ButtonClearPhoto_MouseLeave(object sender, EventArgs e)
        {
            buttonClearPhoto.BackColor = Color.Transparent;
            buttonClearPhoto.ForeColor = Color.FromArgb(220, 80, 80);
            buttonClearPhoto.Font = new Font(buttonClearPhoto.Font, FontStyle.Regular);
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