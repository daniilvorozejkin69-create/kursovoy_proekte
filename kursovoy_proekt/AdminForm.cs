using System;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class AdminForm : Form
    {
        private string currentUser;
        private string currentUserRole;

        public AdminForm()
        {
            InitializeComponent();

            if (Session.IsLoggedIn)
            {
                currentUser = Session.UserName;
                currentUserRole = "Администратор";
            }
            else
            {
                currentUser = "Администратор";
                currentUserRole = "Администратор";
            }

            labelUserInfo.Text = $"{currentUser} ({currentUserRole})";

            // Подписка на события кнопок
            buttonAddUser.Click += ButtonAddUser_Click;
            buttonEditUser.Click += ButtonEditUser_Click;
            buttonDirectories.Click += ButtonDirectories_Click;
            buttonReport.Click += ButtonReport_Click;
            buttonExit.Click += ButtonExit_Click;

            // Подписка на события MouseEnter/MouseLeave
            buttonAddUser.MouseEnter += ButtonAddUser_MouseEnter;
            buttonAddUser.MouseLeave += ButtonAddUser_MouseLeave;
            buttonEditUser.MouseEnter += ButtonEditUser_MouseEnter;
            buttonEditUser.MouseLeave += ButtonEditUser_MouseLeave;
            buttonDirectories.MouseEnter += ButtonDirectories_MouseEnter;
            buttonDirectories.MouseLeave += ButtonDirectories_MouseLeave;
            buttonReport.MouseEnter += ButtonReport_MouseEnter;
            buttonReport.MouseLeave += ButtonReport_MouseLeave;
            buttonExit.MouseEnter += ButtonExit_MouseEnter;
            buttonExit.MouseLeave += ButtonExit_MouseLeave;
        }

        public AdminForm(string userName, string userRole) : this()
        {
            currentUser = userName;
            currentUserRole = userRole;
            labelUserInfo.Text = $"{userName} ({userRole})";
        }

        // Эффекты наведения
        private void ButtonAddUser_MouseEnter(object sender, EventArgs e)
        {
            buttonAddUser.BackColor = System.Drawing.Color.FromArgb(90, 160, 210);
        }

        private void ButtonAddUser_MouseLeave(object sender, EventArgs e)
        {
            buttonAddUser.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
        }

        private void ButtonEditUser_MouseEnter(object sender, EventArgs e)
        {
            buttonEditUser.BackColor = System.Drawing.Color.FromArgb(90, 160, 210);
        }

        private void ButtonEditUser_MouseLeave(object sender, EventArgs e)
        {
            buttonEditUser.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
        }

        private void ButtonDirectories_MouseEnter(object sender, EventArgs e)
        {
            buttonDirectories.BackColor = System.Drawing.Color.FromArgb(120, 170, 100);
        }

        private void ButtonDirectories_MouseLeave(object sender, EventArgs e)
        {
            buttonDirectories.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
        }

        private void ButtonReport_MouseEnter(object sender, EventArgs e)
        {
            buttonReport.BackColor = System.Drawing.Color.FromArgb(90, 160, 210);
        }

        private void ButtonReport_MouseLeave(object sender, EventArgs e)
        {
            buttonReport.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
        }

        private void ButtonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackColor = System.Drawing.Color.FromArgb(240, 100, 100);
        }

        private void ButtonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackColor = System.Drawing.Color.FromArgb(220, 80, 80);
        }

        // ИСПРАВЛЕННЫЕ обработчики - НИЧЕГО НЕ ЗАКРЫВАЕМ!
        private void ButtonAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Просто показываем сообщение, не закрывая форму
                MessageBox.Show("Форма добавления пользователя", "Информация");

                // Если есть форма - показываем её и НЕ закрываем AdminForm
                // AddUser addUser = new AddUser();
                // addUser.Show();
                // this.Hide(); // можно Hide, но не Close!
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void ButtonEditUser_Click(object sender, EventArgs e)
        {
            try
            {
                UsersList usersList = new UsersList();
                usersList.Show();
                // НЕ ЗАКРЫВАЕМ AdminForm - просто открываем поверх
                // this.Hide(); // можно Hide, но не Close!
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void ButtonDirectories_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoriesForm directoriesForm = new DirectoriesForm();
                directoriesForm.Show();
                // НЕ ЗАКРЫВАЕМ AdminForm - просто открываем поверх
                // this.Hide(); // можно Hide, но не Close!
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии справочников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonReport_Click(object sender, EventArgs e)
        {
            try
            {
                HouseReportForm reportForm = new HouseReportForm();
                reportForm.Show();
                // НЕ ЗАКРЫВАЕМ AdminForm - просто открываем поверх
                // this.Hide(); // можно Hide, но не Close!
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии отчёта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            try
            {
                // Возвращаемся на главную форму
                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide(); // Используем Hide вместо Close
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Убираем OnFormClosing - он не нужен
    }
}