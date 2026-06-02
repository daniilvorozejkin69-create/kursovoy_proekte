using System;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public static class InactivityHelper
    {
        private static Timer inactivityTimer;
        private static int inactivitySeconds = 0;
        private const int INACTIVITY_TIMEOUT = 120; // 2 минуты
        private static Form currentLockForm = null;

        public static void StartMonitoring(Form mainForm)
        {
            StopMonitoring();

            inactivityTimer = new Timer();
            inactivityTimer.Interval = 1000;
            inactivityTimer.Tick += (s, e) =>
            {
                inactivitySeconds++;
                if (inactivitySeconds >= INACTIVITY_TIMEOUT)
                {
                    inactivityTimer.Stop();
                    LockApplication(mainForm);
                }
            };
            inactivityTimer.Start();

            // Подписываемся на события главной формы
            mainForm.KeyPreview = true;
            mainForm.KeyDown += OnUserActivity;
            mainForm.MouseMove += OnUserActivity;
            mainForm.MouseClick += OnUserActivity;

            // Рекурсивно подписываемся на все контролы
            AttachToAllControls(mainForm);
        }

        private static void AttachToAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.KeyDown += OnUserActivity;
                control.MouseMove += OnUserActivity;
                control.MouseClick += OnUserActivity;
                control.GotFocus += OnUserActivity;

                if (control is TextBox || control is ComboBox || control is DataGridView)
                {
                    control.KeyPress += OnUserActivity;
                }

                if (control.Controls.Count > 0)
                    AttachToAllControls(control);
            }
        }

        private static void OnUserActivity(object sender, EventArgs e)
        {
            ResetTimer();
        }

        public static void ResetTimer()
        {
            inactivitySeconds = 0;
            if (inactivityTimer != null && !inactivityTimer.Enabled)
                inactivityTimer.Start();
        }

        public static void StopMonitoring()
        {
            if (inactivityTimer != null)
            {
                inactivityTimer.Stop();
                inactivityTimer.Dispose();
                inactivityTimer = null;
            }
        }

        private static void LockApplication(Form mainForm)
        {
            if (currentLockForm != null) return;

            currentLockForm = new LockForm(mainForm);
            currentLockForm.ShowDialog();
            currentLockForm = null;

            ResetTimer();
        }

        private class LockForm : Form
        {
            private TextBox textBoxPassword;
            private Button buttonUnlock;
            private Label labelMessage;
            private Form parentForm;

            public LockForm(Form parent)
            {
                parentForm = parent;
                InitializeLockForm();
            }

            private void InitializeLockForm()
            {
                this.Text = "Система заблокирована";
                this.Size = new System.Drawing.Size(400, 250);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.FormBorderStyle = FormBorderStyle.None;
                this.BackColor = System.Drawing.Color.FromArgb(240, 245, 235);
                this.ShowInTaskbar = false;
                this.TopMost = true;

                // Панель заголовка
                Panel panelTop = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 60,
                    BackColor = System.Drawing.Color.FromArgb(76, 145, 195)
                };

                Label labelTitle = new Label
                {
                    Text = "Система заблокирована",
                    Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold),
                    ForeColor = System.Drawing.Color.White,
                    Dock = DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                };
                panelTop.Controls.Add(labelTitle);

                // Сообщение
                labelMessage = new Label
                {
                    Text = "Система заблокирована из-за бездействия.\nВведите пароль для разблокировки.",
                    Font = new System.Drawing.Font("Segoe UI", 10F),
                    ForeColor = System.Drawing.Color.FromArgb(64, 64, 64),
                    Location = new System.Drawing.Point(30, 80),
                    Size = new System.Drawing.Size(340, 40),
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                };

                // Поле пароля
                textBoxPassword = new TextBox
                {
                    Location = new System.Drawing.Point(50, 130),
                    Size = new System.Drawing.Size(300, 27),
                    Font = new System.Drawing.Font("Segoe UI", 11F),
                    UseSystemPasswordChar = true
                };
                textBoxPassword.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter) TryUnlock();
                };

                // Кнопка разблокировки
                buttonUnlock = new Button
                {
                    Text = "Разблокировать",
                    Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                    ForeColor = System.Drawing.Color.White,
                    BackColor = System.Drawing.Color.FromArgb(106, 153, 85),
                    FlatStyle = FlatStyle.Flat,
                    Location = new System.Drawing.Point(100, 170),
                    Size = new System.Drawing.Size(200, 35)
                };
                buttonUnlock.FlatAppearance.BorderSize = 0;
                buttonUnlock.Click += (s, e) => TryUnlock();

                this.Controls.Add(panelTop);
                this.Controls.Add(labelMessage);
                this.Controls.Add(textBoxPassword);
                this.Controls.Add(buttonUnlock);
            }

            private void TryUnlock()
            {
                string password = textBoxPassword.Text;
                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Введите пароль.", "Ошибка");
                    return;
                }

                // Проверяем пароль текущего пользователя
                try
                {
                    using (var conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        string query = "SELECT password FROM users WHERE id = @id";
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", Session.UserId);
                            string dbPassword = cmd.ExecuteScalar()?.ToString();

                            if (dbPassword == GetPasswordHash(password))
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                labelMessage.Text = "Неверный пароль. Попробуйте ещё раз.";
                                labelMessage.ForeColor = System.Drawing.Color.Red;
                                textBoxPassword.SelectAll();
                                textBoxPassword.Focus();
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка проверки пароля.", "Ошибка");
                }
            }

            private string GetPasswordHash(string password)
            {
                using (var sha256 = System.Security.Cryptography.SHA256.Create())
                {
                    byte[] hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }
        }
    }
}