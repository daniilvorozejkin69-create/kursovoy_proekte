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
        private int editingUserId = -1;
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

            dateTimePickerHireDate.MaxDate = DateTime.Now;
            dateTimePickerHireDate.Value = DateTime.Now;

            if (currentMode == FormMode.Edit)
            {
                labelHeader.Text = "✏️  РЕДАКТИРОВАНИЕ СОТРУДНИКА";
                buttonSave.Text = "💾  СОХРАНИТЬ ИЗМЕНЕНИЯ";
                buttonDelete.Visible = true;
                LoadStaffData();
            }
            else
            {
                labelHeader.Text = "➕  ДОБАВЛЕНИЕ НОВОГО СОТРУДНИКА";
                buttonSave.Text = "✅  ДОБАВИТЬ СОТРУДНИКА";
                buttonDelete.Visible = false;
                textBoxFIO.TextChanged += TextBoxFIO_TextChanged;
            }

            // Подписка на события
            buttonLoadPhoto.Click += ButtonLoadPhoto_Click;
            buttonClearPhoto.Click += ButtonClearPhoto_Click;
            buttonSave.Click += ButtonSave_Click;
            buttonDelete.Click += ButtonDelete_Click;
            buttonMenu.Click += ButtonMenu_Click;
            buttonGeneratePassword.Click += ButtonGeneratePassword_Click;

            checkBoxCreateAccount.CheckedChanged += CheckBoxCreateAccount_CheckedChanged;

            // Подписка на события для эффектов наведения
            buttonSave.MouseEnter += ButtonSave_MouseEnter;
            buttonSave.MouseLeave += ButtonSave_MouseLeave;
            buttonDelete.MouseEnter += ButtonDelete_MouseEnter;
            buttonDelete.MouseLeave += ButtonDelete_MouseLeave;
            buttonMenu.MouseEnter += ButtonMenu_MouseEnter;
            buttonMenu.MouseLeave += ButtonMenu_MouseLeave;
            buttonLoadPhoto.MouseEnter += ButtonLoadPhoto_MouseEnter;
            buttonLoadPhoto.MouseLeave += ButtonLoadPhoto_MouseLeave;
            buttonClearPhoto.MouseEnter += ButtonClearPhoto_MouseEnter;
            buttonClearPhoto.MouseLeave += ButtonClearPhoto_MouseLeave;
            buttonGeneratePassword.MouseEnter += ButtonGeneratePassword_MouseEnter;
            buttonGeneratePassword.MouseLeave += ButtonGeneratePassword_MouseLeave;

            // Подписка на события для полей ввода
            textBoxFIO.Enter += Control_Enter;
            textBoxFIO.Leave += Control_Leave;
            maskedTextBoxPhone.Enter += Control_Enter;
            maskedTextBoxPhone.Leave += Control_Leave;
            textBoxEmail.Enter += Control_Enter;
            textBoxEmail.Leave += Control_Leave;
            textBoxLogin.Enter += Control_Enter;
            textBoxLogin.Leave += Control_Leave;
            textBoxPassword.Enter += Control_Enter;
            textBoxPassword.Leave += Control_Leave;
            comboBoxPosition.Enter += Control_Enter;
            comboBoxPosition.Leave += Control_Leave;
            comboBoxRole.Enter += Control_Enter;
            comboBoxRole.Leave += Control_Leave;
            dateTimePickerHireDate.Enter += Control_Enter;
            dateTimePickerHireDate.Leave += Control_Leave;
        }

        private void SetupControls()
        {
            // Настройка маски для телефона
            maskedTextBoxPhone.Mask = "+7 (000) 000-00-00";
            maskedTextBoxPhone.PromptChar = ' ';

            // Настройка полей
            textBoxFIO.Font = new Font("Segoe UI", 11);
            textBoxEmail.Font = new Font("Segoe UI", 11);
            textBoxLogin.Font = new Font("Segoe UI", 10);
            textBoxPassword.Font = new Font("Segoe UI", 10);

            // Настройка выпадающих списков
            comboBoxPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRole.Items.AddRange(new object[] { "Администратор", "Сотрудник ресепшена", "Управляющий" });

            // Настройка блока учетной записи
            panelAccountFields.Enabled = false;
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

        // Вспомогательный класс для хранения должностей в комбобоксе
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
                            p.*,
                            u.id as UserId,
                            u.login,
                            u.role_id,
                            u.is_active as user_active,
                            pos.position_name
                        FROM personal p
                        LEFT JOIN users u ON p.id = u.personal_id
                        LEFT JOIN positions pos ON p.position_id = pos.id
                        WHERE p.id = @staffId";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@staffId", editingStaffId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Основная информация
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

                                // Телефон
                                string phone = reader["telephone_number"].ToString();
                                maskedTextBoxPhone.Text = FormatPhoneForMask(phone);

                                // Email
                                textBoxEmail.Text = reader["email"].ToString();

                                // Дата приёма
                                if (reader["hire_date"] != DBNull.Value)
                                    dateTimePickerHireDate.Value = Convert.ToDateTime(reader["hire_date"]);

                                // Фото (загружаем из BLOB)
                                if (reader["photo"] != DBNull.Value)
                                {
                                    currentPhotoBytes = (byte[])reader["photo"];
                                    using (MemoryStream ms = new MemoryStream(currentPhotoBytes))
                                    {
                                        pictureBoxPhoto.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    // Показываем заглушку
                                    pictureBoxPhoto.Image = CreateDefaultAvatar(textBoxFIO.Text);
                                }

                                // Учетная запись
                                if (reader["UserId"] != DBNull.Value)
                                {
                                    editingUserId = Convert.ToInt32(reader["UserId"]);
                                    checkBoxCreateAccount.Checked = true;
                                    textBoxLogin.Text = reader["login"].ToString();
                                    textBoxPassword.Text = "●●●●●●";
                                    textBoxPassword.Enabled = false;

                                    if (reader["role_id"] != DBNull.Value)
                                        comboBoxRole.SelectedIndex = Convert.ToInt32(reader["role_id"]) - 1;

                                    checkBoxIsActive.Checked = reader["user_active"] != DBNull.Value &&
                                                              Convert.ToBoolean(reader["user_active"]);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Сотрудник не найден в базе данных.", "Ошибка",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private Image CreateDefaultAvatar(string fio)
        {
            Bitmap bmp = new Bitmap(200, 200);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(76, 145, 195));

                string initials = "";
                if (!string.IsNullOrEmpty(fio))
                {
                    string[] parts = fio.Split(' ');
                    if (parts.Length > 0 && !string.IsNullOrEmpty(parts[0]))
                        initials += parts[0][0];
                    if (parts.Length > 1 && !string.IsNullOrEmpty(parts[1]))
                        initials += parts[1][0];
                }

                using (Font font = new Font("Segoe UI", 60, FontStyle.Bold))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    g.DrawString(initials, font, Brushes.White,
                        new RectangleF(0, 0, 200, 200), sf);
                }
            }
            return bmp;
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

        private void TextBoxFIO_TextChanged(object sender, EventArgs e)
        {
            if (currentMode == FormMode.Add && !checkBoxCreateAccount.Checked)
            {
                string login = GenerateLoginFromFIO(textBoxFIO.Text);
                textBoxLogin.Text = login;
            }
        }

        private string GenerateLoginFromFIO(string fio)
        {
            if (string.IsNullOrWhiteSpace(fio)) return "";

            string[] parts = fio.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return "";

            string lastName = Transliterate(parts[0].ToLower());
            if (parts.Length == 1) return lastName;

            string firstName = parts.Length > 1 ? Transliterate(parts[1].ToLower()) : "";
            return $"{lastName}_{firstName}";
        }

        private string Transliterate(string text)
        {
            var translit = new System.Collections.Generic.Dictionary<char, string>
            {
                {'а', "a"}, {'б', "b"}, {'в', "v"}, {'г', "g"}, {'д', "d"},
                {'е', "e"}, {'ё', "e"}, {'ж', "zh"}, {'з', "z"}, {'и', "i"},
                {'й', "y"}, {'к', "k"}, {'л', "l"}, {'м', "m"}, {'н', "n"},
                {'о', "o"}, {'п', "p"}, {'р', "r"}, {'с', "s"}, {'т', "t"},
                {'у', "u"}, {'ф', "f"}, {'х', "h"}, {'ц', "ts"}, {'ч', "ch"},
                {'ш', "sh"}, {'щ', "sch"}, {'ъ', ""}, {'ы', "y"}, {'ь', ""},
                {'э', "e"}, {'ю', "yu"}, {'я', "ya"}
            };

            string result = "";
            foreach (char c in text)
            {
                if (translit.ContainsKey(c))
                    result += translit[c];
                else
                    result += c;
            }
            return result;
        }

        private void CheckBoxCreateAccount_CheckedChanged(object sender, EventArgs e)
        {
            panelAccountFields.Enabled = checkBoxCreateAccount.Checked;

            if (checkBoxCreateAccount.Checked && currentMode == FormMode.Add && string.IsNullOrEmpty(textBoxLogin.Text))
            {
                textBoxLogin.Text = GenerateLoginFromFIO(textBoxFIO.Text);
                textBoxPassword.Text = GenerateRandomPassword();
            }

            if (!checkBoxCreateAccount.Checked)
            {
                textBoxPassword.Text = "";
            }
        }

        private void ButtonGeneratePassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text = GenerateRandomPassword();
        }

        private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
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
                            // Изменяем размер фото до 200x200
                            Image resized = ResizeImage(original, 200, 200);
                            pictureBoxPhoto.Image = resized;

                            // Конвертируем в байты для сохранения в БД
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

            // Если есть ФИО, показываем заглушку
            if (!string.IsNullOrEmpty(textBoxFIO.Text))
            {
                pictureBoxPhoto.Image = CreateDefaultAvatar(textBoxFIO.Text);
            }
        }

        private bool ValidateData()
        {
            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(textBoxFIO.Text))
            {
                ShowError("Введите ФИО сотрудника", textBoxFIO);
                return false;
            }

            // Проверка должности
            if (comboBoxPosition.SelectedItem == null)
            {
                ShowError("Выберите должность", comboBoxPosition);
                return false;
            }

            // Проверка телефона
            string phone = GetCleanPhone();
            if (string.IsNullOrWhiteSpace(phone) || phone.Length != 10)
            {
                ShowError("Введите корректный номер телефона", maskedTextBoxPhone);
                return false;
            }

            // Проверка email (если указан)
            if (!string.IsNullOrWhiteSpace(textBoxEmail.Text) && !IsValidEmail(textBoxEmail.Text))
            {
                ShowError("Введите корректный email адрес", textBoxEmail);
                return false;
            }

            // Проверка учетной записи
            if (checkBoxCreateAccount.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
                {
                    ShowError("Введите логин", textBoxLogin);
                    return false;
                }

                if (currentMode == FormMode.Add && string.IsNullOrWhiteSpace(textBoxPassword.Text))
                {
                    ShowError("Введите пароль", textBoxPassword);
                    return false;
                }

                if (comboBoxRole.SelectedIndex == -1)
                {
                    ShowError("Выберите роль", comboBoxRole);
                    return false;
                }
            }

            return true;
        }

        private string GetCleanPhone()
        {
            string phone = new string(maskedTextBoxPhone.Text.Where(char.IsDigit).ToArray());
            if (phone.Length == 11 && phone.StartsWith("7"))
                return phone.Substring(1);
            return phone.Length == 10 ? phone : "";
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
            MessageBox.Show(message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private string GetPasswordHash(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
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
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string phone = GetCleanPhone();
                            string formattedPhone = FormatPhoneForDB(phone);

                            PositionItem selectedPosition = (PositionItem)comboBoxPosition.SelectedItem;

                            // Добавляем сотрудника с фото в BLOB и job_title из выбранной должности
                            string insertPersonal = @"
                                INSERT INTO personal (
                                    FIO, position_id, job_title, telephone_number, 
                                    email, hire_date, photo, is_active
                                ) VALUES (
                                    @fio, @positionId, @jobTitle, @phone, 
                                    @email, @hireDate, @photo, TRUE
                                );
                                SELECT LAST_INSERT_ID();";

                            int personalId;
                            using (var cmd = new MySqlCommand(insertPersonal, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@fio", textBoxFIO.Text.Trim());
                                cmd.Parameters.AddWithValue("@positionId", selectedPosition.Id);
                                cmd.Parameters.AddWithValue("@jobTitle", selectedPosition.Name); // Автоматически из выбранной должности
                                cmd.Parameters.AddWithValue("@phone", formattedPhone);
                                cmd.Parameters.AddWithValue("@email",
                                    string.IsNullOrWhiteSpace(textBoxEmail.Text) ?
                                    DBNull.Value : (object)textBoxEmail.Text.Trim());
                                cmd.Parameters.AddWithValue("@hireDate", dateTimePickerHireDate.Value.Date);
                                cmd.Parameters.AddWithValue("@photo",
                                    currentPhotoBytes ?? (object)DBNull.Value);

                                personalId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // Создаем учетную запись
                            if (checkBoxCreateAccount.Checked)
                            {
                                string insertUser = @"
                                    INSERT INTO users (personal_id, login, password, role_id, is_active)
                                    VALUES (@personalId, @login, @password, @roleId, @isActive)";

                                using (var cmd = new MySqlCommand(insertUser, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@personalId", personalId);
                                    cmd.Parameters.AddWithValue("@login", textBoxLogin.Text.Trim());
                                    cmd.Parameters.AddWithValue("@password", GetPasswordHash(textBoxPassword.Text));
                                    cmd.Parameters.AddWithValue("@roleId", comboBoxRole.SelectedIndex + 1);
                                    cmd.Parameters.AddWithValue("@isActive", checkBoxIsActive.Checked);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            DataChanged = true;
                            MessageBox.Show("✅ Сотрудник успешно добавлен!", "Успех",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                if (ex.Message.Contains("login"))
                    MessageBox.Show("❌ Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (ex.Message.Contains("email"))
                    MessageBox.Show("❌ Сотрудник с таким email уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStaff()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string phone = GetCleanPhone();
                            string formattedPhone = FormatPhoneForDB(phone);

                            PositionItem selectedPosition = (PositionItem)comboBoxPosition.SelectedItem;

                            // Обновляем данные сотрудника (включая фото и job_title из должности)
                            string updatePersonal = @"
                                UPDATE personal SET
                                    FIO = @fio,
                                    position_id = @positionId,
                                    job_title = @jobTitle,
                                    telephone_number = @phone,
                                    email = @email,
                                    hire_date = @hireDate,
                                    photo = @photo
                                WHERE id = @staffId";

                            using (var cmd = new MySqlCommand(updatePersonal, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@fio", textBoxFIO.Text.Trim());
                                cmd.Parameters.AddWithValue("@positionId", selectedPosition.Id);
                                cmd.Parameters.AddWithValue("@jobTitle", selectedPosition.Name); // Автоматически из выбранной должности
                                cmd.Parameters.AddWithValue("@phone", formattedPhone);
                                cmd.Parameters.AddWithValue("@email",
                                    string.IsNullOrWhiteSpace(textBoxEmail.Text) ?
                                    DBNull.Value : (object)textBoxEmail.Text.Trim());
                                cmd.Parameters.AddWithValue("@hireDate", dateTimePickerHireDate.Value.Date);
                                cmd.Parameters.AddWithValue("@photo",
                                    currentPhotoBytes ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@staffId", editingStaffId);

                                cmd.ExecuteNonQuery();
                            }

                            // Обновляем учетную запись
                            if (checkBoxCreateAccount.Checked)
                            {
                                if (editingUserId > 0)
                                {
                                    string updateUser = @"
                                        UPDATE users SET
                                            login = @login,
                                            role_id = @roleId,
                                            is_active = @isActive
                                        WHERE id = @userId";

                                    using (var cmd = new MySqlCommand(updateUser, connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@login", textBoxLogin.Text.Trim());
                                        cmd.Parameters.AddWithValue("@roleId", comboBoxRole.SelectedIndex + 1);
                                        cmd.Parameters.AddWithValue("@isActive", checkBoxIsActive.Checked);
                                        cmd.Parameters.AddWithValue("@userId", editingUserId);

                                        cmd.ExecuteNonQuery();
                                    }

                                    // Обновляем пароль если был изменен
                                    if (textBoxPassword.Enabled && !string.IsNullOrEmpty(textBoxPassword.Text)
                                        && textBoxPassword.Text != "●●●●●●")
                                    {
                                        string updatePassword = @"
                                            UPDATE users SET password = @password WHERE id = @userId";

                                        using (var cmd = new MySqlCommand(updatePassword, connection, transaction))
                                        {
                                            cmd.Parameters.AddWithValue("@password", GetPasswordHash(textBoxPassword.Text));
                                            cmd.Parameters.AddWithValue("@userId", editingUserId);
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                else
                                {
                                    string insertUser = @"
                                        INSERT INTO users (personal_id, login, password, role_id, is_active)
                                        VALUES (@personalId, @login, @password, @roleId, @isActive)";

                                    using (var cmd = new MySqlCommand(insertUser, connection, transaction))
                                    {
                                        cmd.Parameters.AddWithValue("@personalId", editingStaffId);
                                        cmd.Parameters.AddWithValue("@login", textBoxLogin.Text.Trim());
                                        cmd.Parameters.AddWithValue("@password", GetPasswordHash(textBoxPassword.Text));
                                        cmd.Parameters.AddWithValue("@roleId", comboBoxRole.SelectedIndex + 1);
                                        cmd.Parameters.AddWithValue("@isActive", checkBoxIsActive.Checked);

                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            else if (editingUserId > 0)
                            {
                                // Удаляем учетную запись
                                string deleteUser = "DELETE FROM users WHERE id = @userId";
                                using (var cmd = new MySqlCommand(deleteUser, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@userId", editingUserId);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();

                            DataChanged = true;
                            MessageBox.Show("✅ Данные сотрудника успешно обновлены!", "Успех",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                if (ex.Message.Contains("login"))
                    MessageBox.Show("❌ Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (ex.Message.Contains("email"))
                    MessageBox.Show("❌ Сотрудник с таким email уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (currentMode != FormMode.Edit) return;

            if (editingUserId == Session.UserId)
            {
                MessageBox.Show("Вы не можете удалить свою собственную учетную запись.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить этого сотрудника?\n" +
                                        "⚠️ Это действие нельзя отменить.",
                                        "Подтверждение удаления",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteStaff();
            }
        }

        private void DeleteStaff()
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Удаляем пользователя
                            string deleteUser = "DELETE FROM users WHERE personal_id = @staffId";
                            using (var cmd = new MySqlCommand(deleteUser, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@staffId", editingStaffId);
                                cmd.ExecuteNonQuery();
                            }

                            // Удаляем сотрудника
                            string deleteStaff = "DELETE FROM personal WHERE id = @staffId";
                            using (var cmd = new MySqlCommand(deleteStaff, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@staffId", editingStaffId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            MessageBox.Show("🗑️ Сотрудник успешно удален!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show("❌ Нельзя удалить сотрудника, который создавал заказы или бронирования.\n" +
                              "Сначала деактивируйте его учетную запись.",
                              "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonMenu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Эффекты наведения для кнопок
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
            if (buttonDelete.Visible)
            {
                buttonDelete.BackColor = Color.FromArgb(192, 57, 43);
                buttonDelete.Font = new Font(buttonDelete.Font, FontStyle.Bold | FontStyle.Underline);
            }
        }

        private void ButtonDelete_MouseLeave(object sender, EventArgs e)
        {
            if (buttonDelete.Visible)
            {
                buttonDelete.BackColor = Color.FromArgb(231, 76, 60);
                buttonDelete.Font = new Font(buttonDelete.Font, FontStyle.Bold);
            }
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

        private void ButtonGeneratePassword_MouseEnter(object sender, EventArgs e)
        {
            buttonGeneratePassword.BackColor = Color.FromArgb(126, 173, 105);
            buttonGeneratePassword.Font = new Font(buttonGeneratePassword.Font, FontStyle.Bold);
        }

        private void ButtonGeneratePassword_MouseLeave(object sender, EventArgs e)
        {
            buttonGeneratePassword.BackColor = Color.FromArgb(106, 153, 85);
            buttonGeneratePassword.Font = new Font(buttonGeneratePassword.Font, FontStyle.Regular);
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