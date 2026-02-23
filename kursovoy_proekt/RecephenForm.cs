using System;
using System.Drawing;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class RecephenForm : Form
    {
        public RecephenForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Устанавливаем имя пользователя
            if (Session.IsLoggedIn)
            {
                labelUserInfo.Text = Session.UserName;
            }
            else
            {
                labelUserInfo.Text = "Сотрудник ресепшена";
            }

            // Настройка цветов кнопок по группам
            SetupButtonColors();
        }

        private void SetupButtonColors()
        {
            // Клиенты - синие
            buttonAddClient.BackColor = Color.FromArgb(76, 145, 195);
            buttonEditClient.BackColor = Color.FromArgb(76, 145, 195);

            // Заказы и бронирования - зеленые
            buttonCheck.BackColor = Color.FromArgb(106, 153, 85);
            buttonBooking.BackColor = Color.FromArgb(106, 153, 85);
            buttonBookingManagement.BackColor = Color.FromArgb(106, 153, 85);

            // Справочники - синие (второй оттенок)
            buttonHouses.BackColor = Color.FromArgb(86, 155, 205);
            buttonServices.BackColor = Color.FromArgb(86, 155, 205);

            // Кнопка выхода - прозрачная с красной обводкой
            buttonExit.BackColor = Color.Transparent;
        }

        // ===== ОБРАБОТЧИКИ КЛИКОВ =====
        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient();
            addClient.Show();
            this.Hide();
        }

        private void buttonEditClient_Click(object sender, EventArgs e)
        {
            ClientList clientList = new ClientList();
            clientList.Show();
            this.Hide();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            Check checkForm = new Check();
            checkForm.Show();
        }

        private void buttonHouses_Click(object sender, EventArgs e)
        {
            HousList housList = new HousList();
            housList.Show();
            this.Hide();
        }

        private void buttonBooking_Click(object sender, EventArgs e)
        {
            BookingForm bookingForm = new BookingForm();
            bookingForm.Show();
            this.Hide();
        }

        private void buttonServices_Click(object sender, EventArgs e)
        {
            ServiceList serviceList = new ServiceList();
            serviceList.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookingManagementForm bookingManagementForm = new BookingManagementForm();
            bookingManagementForm.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти из системы?",
                "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Session.Clear();
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }

        // ===== ЭФФЕКТЫ ПРИ НАВЕДЕНИИ =====
        // Кнопки клиентов (синие)
        private void ButtonAddClient_MouseEnter(object sender, EventArgs e)
        {
            buttonAddClient.BackColor = Color.FromArgb(96, 165, 215);
            buttonAddClient.Font = new Font(buttonAddClient.Font, FontStyle.Bold);
        }

        private void ButtonAddClient_MouseLeave(object sender, EventArgs e)
        {
            buttonAddClient.BackColor = Color.FromArgb(76, 145, 195);
            buttonAddClient.Font = new Font(buttonAddClient.Font, FontStyle.Regular);
        }

        private void ButtonEditClient_MouseEnter(object sender, EventArgs e)
        {
            buttonEditClient.BackColor = Color.FromArgb(96, 165, 215);
            buttonEditClient.Font = new Font(buttonEditClient.Font, FontStyle.Bold);
        }

        private void ButtonEditClient_MouseLeave(object sender, EventArgs e)
        {
            buttonEditClient.BackColor = Color.FromArgb(76, 145, 195);
            buttonEditClient.Font = new Font(buttonEditClient.Font, FontStyle.Regular);
        }

        // Кнопки заказов и бронирований (зеленые)
        private void ButtonCheck_MouseEnter(object sender, EventArgs e)
        {
            buttonCheck.BackColor = Color.FromArgb(126, 173, 105);
            buttonCheck.Font = new Font(buttonCheck.Font, FontStyle.Bold);
        }

        private void ButtonCheck_MouseLeave(object sender, EventArgs e)
        {
            buttonCheck.BackColor = Color.FromArgb(106, 153, 85);
            buttonCheck.Font = new Font(buttonCheck.Font, FontStyle.Regular);
        }

        private void ButtonBooking_MouseEnter(object sender, EventArgs e)
        {
            buttonBooking.BackColor = Color.FromArgb(126, 173, 105);
            buttonBooking.Font = new Font(buttonBooking.Font, FontStyle.Bold);
        }

        private void ButtonBooking_MouseLeave(object sender, EventArgs e)
        {
            buttonBooking.BackColor = Color.FromArgb(106, 153, 85);
            buttonBooking.Font = new Font(buttonBooking.Font, FontStyle.Regular);
        }

        // ИСПРАВЛЕНО: Добавлены недостающие методы для кнопки управления бронированиями
        private void ButtonBookingManagement_MouseEnter(object sender, EventArgs e)
        {
            buttonBookingManagement.BackColor = Color.FromArgb(126, 173, 105);
            buttonBookingManagement.Font = new Font(buttonBookingManagement.Font, FontStyle.Bold);
        }

        private void ButtonBookingManagement_MouseLeave(object sender, EventArgs e)
        {
            buttonBookingManagement.BackColor = Color.FromArgb(106, 153, 85);
            buttonBookingManagement.Font = new Font(buttonBookingManagement.Font, FontStyle.Regular);
        }

        // Кнопки справочников (синие, второй оттенок)
        private void ButtonHouses_MouseEnter(object sender, EventArgs e)
        {
            buttonHouses.BackColor = Color.FromArgb(106, 175, 225);
            buttonHouses.Font = new Font(buttonHouses.Font, FontStyle.Bold);
        }

        private void ButtonHouses_MouseLeave(object sender, EventArgs e)
        {
            buttonHouses.BackColor = Color.FromArgb(86, 155, 205);
            buttonHouses.Font = new Font(buttonHouses.Font, FontStyle.Regular);
        }

        private void ButtonServices_MouseEnter(object sender, EventArgs e)
        {
            buttonServices.BackColor = Color.FromArgb(106, 175, 225);
            buttonServices.Font = new Font(buttonServices.Font, FontStyle.Bold);
        }

        private void ButtonServices_MouseLeave(object sender, EventArgs e)
        {
            buttonServices.BackColor = Color.FromArgb(86, 155, 205);
            buttonServices.Font = new Font(buttonServices.Font, FontStyle.Regular);
        }

        // Кнопка выхода (красная)
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

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}