using System;
using System.Drawing;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
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
                labelUserInfo.Text = "Управляющий";
            }

            // Подписка на события
            this.Load += ManagerForm_Load;

            // Кнопки домов
            buttonAddHouse.Click += ButtonAddHouse_Click;
            buttonEditHouse.Click += ButtonEditHouse_Click;

            // Кнопки услуг
            buttonAddService.Click += ButtonAddService_Click;
            buttonEditService.Click += ButtonEditService_Click;

            // Кнопка персонала (НОВАЯ)
            buttonManageStaff.Click += ButtonManageStaff_Click;

            // Кнопка отчетов
            buttonReportHouse.Click += ButtonReportHouse_Click;

            // Кнопка выхода
            buttonExit.Click += ButtonExit_Click;

            // Эффекты наведения
            buttonAddHouse.MouseEnter += ButtonAddHouse_MouseEnter;
            buttonAddHouse.MouseLeave += ButtonAddHouse_MouseLeave;
            buttonEditHouse.MouseEnter += ButtonEditHouse_MouseEnter;
            buttonEditHouse.MouseLeave += ButtonEditHouse_MouseLeave;

            buttonAddService.MouseEnter += ButtonAddService_MouseEnter;
            buttonAddService.MouseLeave += ButtonAddService_MouseLeave;
            buttonEditService.MouseEnter += ButtonEditService_MouseEnter;
            buttonEditService.MouseLeave += ButtonEditService_MouseLeave;

            buttonManageStaff.MouseEnter += ButtonManageStaff_MouseEnter;
            buttonManageStaff.MouseLeave += ButtonManageStaff_MouseLeave;

            buttonReportHouse.MouseEnter += ButtonReportHouse_MouseEnter;
            buttonReportHouse.MouseLeave += ButtonReportHouse_MouseLeave;

            buttonExit.MouseEnter += ButtonExit_MouseEnter;
            buttonExit.MouseLeave += ButtonExit_MouseLeave;
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            // Дополнительная инициализация при загрузке
        }

        // ============================================
        // ОБРАБОТЧИКИ КЛИКОВ
        // ============================================

        private void ButtonAddHouse_Click(object sender, EventArgs e)
        {
            // Открыть форму добавления дома
            AddHous addHous = new AddHous();
            addHous.Show();
            this.Hide();
        }

        private void ButtonEditHouse_Click(object sender, EventArgs e)
        {
            // Открыть форму просмотра домов
            HousList housList = new HousList();
            housList.Show();
            this.Hide();
        }

        private void ButtonAddService_Click(object sender, EventArgs e)
        {
            // Открыть форму добавления услуги
            AddService addService = new AddService();
            addService.Show();
            this.Hide();
        }

        private void ButtonEditService_Click(object sender, EventArgs e)
        {
            // Открыть форму просмотра услуг
            ServiceList serviceList = new ServiceList();
            serviceList.Show();
            this.Hide();
        }

        // НОВАЯ КНОПКА - УПРАВЛЕНИЕ ПЕРСОНАЛОМ
        private void ButtonManageStaff_Click(object sender, EventArgs e)
        {
            // Открыть форму списка сотрудников
            StaffList staffList = new StaffList();
            staffList.Show();
            this.Hide();
        }

        private void ButtonReportHouse_Click(object sender, EventArgs e)
        {
            // Открыть форму отчета
            RevenueReport revenueReport = new RevenueReport();
            revenueReport.Show();
            this.Hide();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
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

        // ============================================
        // ЭФФЕКТЫ ПРИ НАВЕДЕНИИ
        // ============================================

        // Дома - синие
        private void ButtonAddHouse_MouseEnter(object sender, EventArgs e)
        {
            buttonAddHouse.BackColor = Color.FromArgb(96, 165, 215);
            buttonAddHouse.Font = new Font(buttonAddHouse.Font, FontStyle.Bold);
        }

        private void ButtonAddHouse_MouseLeave(object sender, EventArgs e)
        {
            buttonAddHouse.BackColor = Color.FromArgb(76, 145, 195);
            buttonAddHouse.Font = new Font(buttonAddHouse.Font, FontStyle.Regular);
        }

        private void ButtonEditHouse_MouseEnter(object sender, EventArgs e)
        {
            buttonEditHouse.BackColor = Color.FromArgb(96, 165, 215);
            buttonEditHouse.Font = new Font(buttonEditHouse.Font, FontStyle.Bold);
        }

        private void ButtonEditHouse_MouseLeave(object sender, EventArgs e)
        {
            buttonEditHouse.BackColor = Color.FromArgb(76, 145, 195);
            buttonEditHouse.Font = new Font(buttonEditHouse.Font, FontStyle.Regular);
        }

        // Услуги - зеленые
        private void ButtonAddService_MouseEnter(object sender, EventArgs e)
        {
            buttonAddService.BackColor = Color.FromArgb(126, 173, 105);
            buttonAddService.Font = new Font(buttonAddService.Font, FontStyle.Bold);
        }

        private void ButtonAddService_MouseLeave(object sender, EventArgs e)
        {
            buttonAddService.BackColor = Color.FromArgb(106, 153, 85);
            buttonAddService.Font = new Font(buttonAddService.Font, FontStyle.Regular);
        }

        private void ButtonEditService_MouseEnter(object sender, EventArgs e)
        {
            buttonEditService.BackColor = Color.FromArgb(126, 173, 105);
            buttonEditService.Font = new Font(buttonEditService.Font, FontStyle.Bold);
        }

        private void ButtonEditService_MouseLeave(object sender, EventArgs e)
        {
            buttonEditService.BackColor = Color.FromArgb(106, 153, 85);
            buttonEditService.Font = new Font(buttonEditService.Font, FontStyle.Regular);
        }

        // Персонал - фиолетовый
        private void ButtonManageStaff_MouseEnter(object sender, EventArgs e)
        {
            buttonManageStaff.BackColor = Color.FromArgb(175, 109, 202); // Светлее
            buttonManageStaff.Font = new Font(buttonManageStaff.Font, FontStyle.Bold);
        }

        private void ButtonManageStaff_MouseLeave(object sender, EventArgs e)
        {
            buttonManageStaff.BackColor = Color.FromArgb(155, 89, 182); // Оригинал
            buttonManageStaff.Font = new Font(buttonManageStaff.Font, FontStyle.Regular);
        }

        // Отчеты - синяя
        private void ButtonReportHouse_MouseEnter(object sender, EventArgs e)
        {
            buttonReportHouse.BackColor = Color.FromArgb(96, 165, 215);
            buttonReportHouse.Font = new Font(buttonReportHouse.Font, FontStyle.Bold);
        }

        private void ButtonReportHouse_MouseLeave(object sender, EventArgs e)
        {
            buttonReportHouse.BackColor = Color.FromArgb(76, 145, 195);
            buttonReportHouse.Font = new Font(buttonReportHouse.Font, FontStyle.Regular);
        }

        // Выход - красная обводка
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

        private void labelVersion_Click(object sender, EventArgs e)
        {

        }
    }
}