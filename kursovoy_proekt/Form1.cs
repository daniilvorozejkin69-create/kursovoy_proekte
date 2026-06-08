using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class Form1 : Form
    {
        private int failedAttempts = 0;
        private string captchaText = "";
        private Timer inactivityTimer;
        private int inactivitySeconds = 0;
        private const int INACTIVITY_TIMEOUT = 30; // секунд
        private const int BLOCK_TIME = 10; // секунд
        private bool isBlocked = false;

        public Form1()
        {
            InitializeComponent();
            SetupForm();
            SetupInactivityTimer();
        }

        private void SetupForm()
        {
            this.Load += Form1_Load;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.MouseMove += Form1_UserActivity;
            this.MouseClick += Form1_UserActivity;

            textBoxLogin.Enter += TextBox_Enter;
            textBoxLogin.Leave += TextBox_Leave;
            textBoxLogin.KeyDown += TextBox_KeyDown;

            textBoxPassword.Enter += TextBox_Enter;
            textBoxPassword.Leave += TextBox_Leave;
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.KeyDown += TextBoxPassword_KeyDown;

            buttonLogin.MouseEnter += ButtonLogin_MouseEnter;
            buttonLogin.MouseLeave += ButtonLogin_MouseLeave;
            buttonLogin.Click += ButtonLogin_Click;

            buttonExit.MouseEnter += ButtonExit_MouseEnter;
            buttonExit.MouseLeave += ButtonExit_MouseLeave;
            buttonExit.Click += ButtonExit_Click;

            // Панель капчи
            panelCaptcha.Visible = false;
            buttonRefreshCaptcha.Click += (s, e) => GenerateCaptcha();
            textBoxCaptcha.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) PerformLogin(); };

            // Таймер блокировки
            timerBlock.Interval = 1000;
            timerBlock.Tick += TimerBlock_Tick;
        }

        // ==========================================
        // ТАЙМЕР БЕЗДЕЙСТВИЯ
        // ==========================================
        private void SetupInactivityTimer()
        {
            inactivityTimer = new Timer();
            inactivityTimer.Interval = 1000;
            inactivityTimer.Tick += (s, e) =>
            {
                inactivitySeconds++;
                if (inactivitySeconds >= INACTIVITY_TIMEOUT && !isBlocked)
                {
                    inactivityTimer.Stop();
                    BlockApplication("Блокировка: бездействие " + INACTIVITY_TIMEOUT + " сек.");
                }
            };
            inactivityTimer.Start();
        }

        private void Form1_UserActivity(object sender, EventArgs e)
        {
            if (!isBlocked)
            {
                inactivitySeconds = 0;
                if (!inactivityTimer.Enabled) inactivityTimer.Start();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Form1_UserActivity(sender, e);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Form1_UserActivity(sender, e);
        }

        // ==========================================
        // БЛОКИРОВКА
        // ==========================================
        private void BlockApplication(string reason)
        {
            isBlocked = true;
            inactivityTimer.Stop();

            textBoxLogin.Enabled = false;
            textBoxPassword.Enabled = false;
            textBoxCaptcha.Enabled = false;
            buttonLogin.Enabled = false;
            panelCaptcha.Visible = false;

            labelBlockInfo.Text = reason + "\nПодождите " + BLOCK_TIME + " секунд...";
            panelBlock.Visible = true;
            panelBlock.BringToFront();

            timerBlock.Start();
        }

        private void TimerBlock_Tick(object sender, EventArgs e)
        {
            timerBlock.Stop();
            isBlocked = false;

            textBoxLogin.Enabled = true;
            textBoxPassword.Enabled = true;
            buttonLogin.Enabled = true;
            panelBlock.Visible = false;

            inactivitySeconds = 0;
            inactivityTimer.Start();

            if (failedAttempts >= 2)
            {
                panelCaptcha.Visible = true;
                GenerateCaptcha();
                textBoxCaptcha.Focus();
            }
            else
            {
                textBoxLogin.Focus();
            }
        }

        // ==========================================
        // КАПЧА
        // ==========================================
        private void GenerateCaptcha()
        {
            captchaText = GenerateRandomText(5);
            pictureBoxCaptcha.Image = DrawCaptchaImage(captchaText, pictureBoxCaptcha.Width, pictureBoxCaptcha.Height);
            textBoxCaptcha.Text = "";
        }

        private string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            Random rnd = new Random();
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
                result[i] = chars[rnd.Next(chars.Length)];
            return new string(result);
        }

        private Bitmap DrawCaptchaImage(string text, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(245, 248, 250));

                Random rnd = new Random();

                // Фоновые линии
                for (int i = 0; i < 8; i++)
                {
                    int x1 = rnd.Next(width);
                    int y1 = rnd.Next(height);
                    int x2 = rnd.Next(width);
                    int y2 = rnd.Next(height);
                    g.DrawLine(new Pen(Color.FromArgb(180, 200, 220), 1f), x1, y1, x2, y2);
                }

                // Точки
                for (int i = 0; i < 100; i++)
                {
                    int x = rnd.Next(width);
                    int y = rnd.Next(height);
                    bitmap.SetPixel(x, y, Color.FromArgb(120, 160, 190));
                }

                // Буквы
                float xPos = 15;
                for (int i = 0; i < text.Length; i++)
                {
                    using (Font font = new Font("Arial", rnd.Next(20, 26), FontStyle.Bold))
                    {
                        float angle = rnd.Next(-25, 25);
                        using (Matrix matrix = new Matrix())
                        {
                            matrix.RotateAt(angle, new PointF(xPos + 10, height / 2));
                            g.Transform = matrix;

                            Color color = Color.FromArgb(
                                rnd.Next(30, 80),
                                rnd.Next(80, 160),
                                rnd.Next(140, 200));

                            using (Brush brush = new SolidBrush(color))
                            {
                                g.DrawString(text[i].ToString(), font, brush, xPos, rnd.Next(5, 15));
                            }
                            g.ResetTransform();
                        }
                    }
                    xPos += width / text.Length - 5;
                }
            }
            return bitmap;
        }

        // ==========================================
        // АВТОРИЗАЦИЯ
        // ==========================================
        private void ButtonLogin_Click(object sender, EventArgs e) => PerformLogin();

        private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PerformLogin();
            }
        }

        private void PerformLogin()
        {
            if (isBlocked) return;

            // Проверка капчи
            if (panelCaptcha.Visible)
            {
                if (textBoxCaptcha.Text.Trim().ToUpper() != captchaText.ToUpper())
                {
                    failedAttempts++;
                    MessageBox.Show("Капча введена неверно. Попытка " + failedAttempts, "Ошибка");
                    GenerateCaptcha();
                    textBoxCaptcha.Focus();
                    if (failedAttempts >= 3) BlockApplication("Слишком много неверных попыток.");
                    return;
                }
            }

            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка");
                return;
            }

            // ===== ВХОД ДЛЯ АДМИНА БЕЗ БД =====
            if (login == "admin" && password == "admin")
            {
                failedAttempts = 0;
                panelCaptcha.Visible = false;
                textBoxCaptcha.Text = "";
                inactivitySeconds = 0;

                Session.UserId = 1;
                Session.UserLogin = "admin";
                Session.RoleId = 1;
                Session.UserName = "Администратор";
                Session.RoleName = "Администратор";
                Session.IsLoggedIn = true;
                Session.LoginTime = DateTime.Now;

                OpenMainForm();
                this.Hide();
                return;
            }

            // ===== ВХОД ДЛЯ РЕСЕПШЕНА БЕЗ БД =====
            if (login == "reception" && password == "reception")
            {
                failedAttempts = 0;
                panelCaptcha.Visible = false;
                textBoxCaptcha.Text = "";
                inactivitySeconds = 0;

                Session.UserId = 2;
                Session.UserLogin = "reception";
                Session.RoleId = 2;
                Session.UserName = "Ресепшен";
                Session.RoleName = "Ресепшен";
                Session.IsLoggedIn = true;
                Session.LoginTime = DateTime.Now;

                OpenMainForm();
                this.Hide();
                return;
            }

            // ===== ВХОД ДЛЯ УПРАВЛЯЮЩЕГО БЕЗ БД =====
            if (login == "manager" && password == "manager")
            {
                failedAttempts = 0;
                panelCaptcha.Visible = false;
                textBoxCaptcha.Text = "";
                inactivitySeconds = 0;

                Session.UserId = 3;
                Session.UserLogin = "manager";
                Session.RoleId = 3;
                Session.UserName = "Управляющий";
                Session.RoleName = "Управляющий";
                Session.IsLoggedIn = true;
                Session.LoginTime = DateTime.Now;

                OpenMainForm();
                this.Hide();
                return;
            }

            // ===== ПРОВЕРКА ЧЕРЕЗ БД =====
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT u.id, u.login, u.role_id, COALESCE(p.FIO, u.login) AS user_name, r.role_name FROM users u LEFT JOIN personal p ON u.personal_id = p.id JOIN role r ON u.role_id = r.id WHERE u.login = @login AND u.password = @password AND u.is_active = TRUE";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", GetPasswordHash(password));
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                failedAttempts = 0;
                                panelCaptcha.Visible = false;
                                textBoxCaptcha.Text = "";
                                inactivitySeconds = 0;
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
                                failedAttempts++;
                                MessageBox.Show("Неверный логин или пароль. Попытка " + failedAttempts);
                                textBoxPassword.SelectAll();
                                textBoxPassword.Focus();
                                if (failedAttempts >= 2) { panelCaptcha.Visible = true; GenerateCaptcha(); textBoxCaptcha.Focus(); }
                                if (failedAttempts >= 5) BlockApplication("Слишком много неверных попыток.");
                            }
                        }
                    }
                }
            }
            catch
            {
                failedAttempts++;
                MessageBox.Show("Неверный логин или пароль. Попытка " + failedAttempts);
                if (failedAttempts >= 2) { panelCaptcha.Visible = true; GenerateCaptcha(); }
            }
        }

        private void OpenMainForm()
        {
            Form mainForm = null;

            if (Session.RoleId == 1) mainForm = new AdminForm();
            else if (Session.RoleId == 2) mainForm = new RecephenForm();
            else if (Session.RoleId == 3) mainForm = new ManagerForm();

            if (mainForm == null)
            {
                MessageBox.Show("Неизвестная роль.", "Ошибка");
                return;
            }

            mainForm.FormClosed += (s, args) =>
            {
                if (!Session.IsLoggedIn) Application.Exit();
                else
                {
                    this.Show();
                    textBoxLogin.Text = "";
                    textBoxPassword.Text = "";
                    textBoxCaptcha.Text = "";
                    panelCaptcha.Visible = false;
                    failedAttempts = 0;
                    textBoxLogin.Focus();
                }
            };

            mainForm.Show();
        }

        private void ButtonExit_Click(object sender, EventArgs e) => Application.Exit();

        private void Form1_Load(object sender, EventArgs e)
        {
            Session.Clear();
            if (!DatabaseConnection.TestConnection())
                MessageBox.Show("Нет подключения к БД.", "Ошибка");
            textBoxLogin.Focus();
        }

        // ==========================================
        // ХЭШ ПАРОЛЯ
        // ==========================================
        private string GetPasswordHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        // ==========================================
        // ВИЗУАЛЬНЫЕ ЭФФЕКТЫ
        // ==========================================
        private void TextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.FromArgb(240, 250, 240);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void ButtonLogin_MouseEnter(object sender, EventArgs e)
        {
            buttonLogin.BackColor = Color.FromArgb(126, 173, 105);
        }

        private void ButtonLogin_MouseLeave(object sender, EventArgs e)
        {
            buttonLogin.BackColor = Color.FromArgb(106, 153, 85);
        }

        private void ButtonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackColor = Color.FromArgb(220, 80, 80);
            buttonExit.ForeColor = Color.White;
        }

        private void ButtonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackColor = Color.Transparent;
            buttonExit.ForeColor = Color.FromArgb(220, 80, 80);
        }
    }
}