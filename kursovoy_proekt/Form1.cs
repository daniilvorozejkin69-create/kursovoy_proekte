using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace kursovoy_proekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Load += Form1_Load;

            if (textBoxLogin != null)
            {
                textBoxLogin.Enter += TextBox_Enter;
                textBoxLogin.Leave += TextBox_Leave;
            }

            if (textBoxPassword != null)
            {
                textBoxPassword.Enter += TextBox_Enter;
                textBoxPassword.Leave += TextBox_Leave;
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.KeyDown += TextBoxPassword_KeyDown;
            }

            if (buttonLogin != null)
            {
                buttonLogin.MouseEnter += ButtonLogin_MouseEnter;
                buttonLogin.MouseLeave += ButtonLogin_MouseLeave;
                buttonLogin.Click += ButtonLogin_Click;
            }

            if (buttonExit != null)
            {
                buttonExit.MouseEnter += ButtonExit_MouseEnter;
                buttonExit.MouseLeave += ButtonExit_MouseLeave;
                buttonExit.Click += ButtonExit_Click;
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.FromArgb(240, 250, 240);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PerformLogin();
            }
        }

        private void ButtonLogin_MouseEnter(object sender, EventArgs e)
        {
            buttonLogin.BackColor = Color.FromArgb(126, 173, 105);
            buttonLogin.Font = new Font(buttonLogin.Font, FontStyle.Bold);
        }

        private void ButtonLogin_MouseLeave(object sender, EventArgs e)
        {
            buttonLogin.BackColor = Color.FromArgb(106, 153, 85);
            buttonLogin.Font = new Font(buttonLogin.Font, FontStyle.Regular);
        }

        private void ButtonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackColor = Color.FromArgb(220, 80, 80);
            buttonExit.ForeColor = Color.White;
            buttonExit.Font = new Font(buttonExit.Font, FontStyle.Bold);
        }

        private void ButtonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackColor = Color.Transparent;
            buttonExit.ForeColor = Color.FromArgb(220, 80, 80);
            buttonExit.Font = new Font(buttonExit.Font, FontStyle.Regular);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PerformLogin()
        {
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLogin.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
                return;
            }

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT u.id, u.login, u.role_id, COALESCE(p.FIO, u.login) as user_name, r.role_name
                        FROM users u 
                        LEFT JOIN personal p ON u.personal_id = p.id
                        JOIN role r ON u.role_id = r.id
                        WHERE u.login = @login AND u.password = @password AND u.is_active = TRUE";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", GetPasswordHash(password));

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Session.UserId = reader.GetInt32("id");
                                Session.UserLogin = reader.GetString("login");
                                Session.RoleId = reader.GetInt32("role_id");
                                Session.UserName = reader.GetString("user_name");
                                Session.RoleName = reader.GetString("role_name");
                                Session.IsLoggedIn = true;
                                Session.LoginTime = DateTime.Now;

                                OpenMainForm();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин, пароль или учетная запись неактивна",
                                    "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxPassword.SelectAll();
                                textBoxPassword.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenMainForm()
        {
            Form mainForm = null;

            switch (Session.RoleId)
            {
                case 1:
                    mainForm = new AdminForm();
                    break;
                case 2:
                    mainForm = new RecephenForm();
                    break;
                case 3:
                    mainForm = new ManagerForm();
                    break;
                default:
                    MessageBox.Show($"Неизвестная роль пользователя (ID: {Session.RoleId})",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            if (mainForm != null)
            {
                // Подписываемся на закрытие главной формы
                mainForm.FormClosed += (s, args) =>
                {
                    // Проверяем, вышел ли пользователь из системы
                    if (!Session.IsLoggedIn)
                    {
                        // Если вышел - закрываем приложение
                        Application.Exit();
                    }
                    else
                    {
                        // Если просто вернулся в меню - показываем форму входа
                        this.Show();
                        textBoxLogin.Text = "";
                        textBoxPassword.Text = "";
                        textBoxLogin.Focus();
                    }
                };

                mainForm.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Session.Clear();

            if (!DatabaseConnection.TestConnection())
            {
                MessageBox.Show("Не удалось подключиться к базе данных. Проверьте настройки подключения.",
                    "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            textBoxLogin.Focus();
        }

        private string GetPasswordHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}