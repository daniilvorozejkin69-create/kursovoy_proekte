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
            if (Session.IsLoggedIn)
            {
                labelUserInfo.Text = Session.UserName;
            }
            else
            {
                labelUserInfo.Text = "Управляющий";
            }

            // Подписка на события
            buttonAddHouse.Click += ButtonAddHouse_Click;
            buttonEditHouse.Click += ButtonEditHouse_Click;
            buttonAddService.Click += ButtonAddService_Click;
            buttonEditService.Click += ButtonEditService_Click;
            buttonManageStaff.Click += ButtonManageStaff_Click;
            buttonReportHouse.Click += ButtonReportHouse_Click;
            buttonDiscounts.Click += ButtonDiscounts_Click;  // НОВАЯ КНОПКА
            buttonExit.Click += ButtonExit_Click;

            // Эффекты наведения
            buttonAddHouse.MouseEnter += (s, e) => buttonAddHouse.BackColor = Color.FromArgb(96, 165, 215);
            buttonAddHouse.MouseLeave += (s, e) => buttonAddHouse.BackColor = Color.FromArgb(76, 145, 195);

            buttonEditHouse.MouseEnter += (s, e) => buttonEditHouse.BackColor = Color.FromArgb(96, 165, 215);
            buttonEditHouse.MouseLeave += (s, e) => buttonEditHouse.BackColor = Color.FromArgb(76, 145, 195);

            buttonAddService.MouseEnter += (s, e) => buttonAddService.BackColor = Color.FromArgb(126, 173, 105);
            buttonAddService.MouseLeave += (s, e) => buttonAddService.BackColor = Color.FromArgb(106, 153, 85);

            buttonEditService.MouseEnter += (s, e) => buttonEditService.BackColor = Color.FromArgb(126, 173, 105);
            buttonEditService.MouseLeave += (s, e) => buttonEditService.BackColor = Color.FromArgb(106, 153, 85);

            buttonManageStaff.MouseEnter += (s, e) => buttonManageStaff.BackColor = Color.FromArgb(175, 109, 202);
            buttonManageStaff.MouseLeave += (s, e) => buttonManageStaff.BackColor = Color.FromArgb(155, 89, 182);

            buttonReportHouse.MouseEnter += (s, e) => buttonReportHouse.BackColor = Color.FromArgb(96, 165, 215);
            buttonReportHouse.MouseLeave += (s, e) => buttonReportHouse.BackColor = Color.FromArgb(76, 145, 195);

            buttonDiscounts.MouseEnter += (s, e) => buttonDiscounts.BackColor = Color.FromArgb(175, 109, 202);
            buttonDiscounts.MouseLeave += (s, e) => buttonDiscounts.BackColor = Color.FromArgb(155, 89, 182);

            // Эффекты для кнопки ВЫХОДА
            buttonExit.MouseEnter += (s, e) =>
            {
                buttonExit.BackColor = Color.FromArgb(220, 80, 80);
                buttonExit.ForeColor = Color.White;
            };
            buttonExit.MouseLeave += (s, e) =>
            {
                buttonExit.BackColor = Color.Transparent;
                buttonExit.ForeColor = Color.FromArgb(220, 80, 80);
            };
        }

        private void ButtonAddHouse_Click(object sender, EventArgs e)
        {
            AddHous addHous = new AddHous();
            addHous.ShowDialog();
        }

        private void ButtonEditHouse_Click(object sender, EventArgs e)
        {
            HousList housList = new HousList();
            housList.ShowDialog();
        }

        private void ButtonAddService_Click(object sender, EventArgs e)
        {
            AddService addService = new AddService();
            addService.ShowDialog();
        }

        private void ButtonEditService_Click(object sender, EventArgs e)
        {
            ServiceList serviceList = new ServiceList();
            serviceList.ShowDialog();
        }

        private void ButtonManageStaff_Click(object sender, EventArgs e)
        {
            StaffList staffList = new StaffList();
            staffList.ShowDialog();
        }

        private void ButtonReportHouse_Click(object sender, EventArgs e)
        {
            RevenueReport revenueReport = new RevenueReport();
            revenueReport.ShowDialog();
        }

        private void ButtonDiscounts_Click(object sender, EventArgs e)
        {
            DiscountsForm discountsForm = new DiscountsForm();
            discountsForm.ShowDialog();
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
    }
}