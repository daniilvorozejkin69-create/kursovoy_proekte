using System;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void ButtonAddHouse_MouseEnter(object sender, EventArgs e)
        {
            buttonAddHouse.BackColor = System.Drawing.Color.FromArgb(120, 170, 100);
        }

        private void ButtonAddHouse_MouseLeave(object sender, EventArgs e)
        {
            buttonAddHouse.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
        }

        private void ButtonEditHouse_MouseEnter(object sender, EventArgs e)
        {
            buttonEditHouse.BackColor = System.Drawing.Color.FromArgb(120, 170, 100);
        }

        private void ButtonEditHouse_MouseLeave(object sender, EventArgs e)
        {
            buttonEditHouse.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
        }

        private void ButtonAddService_MouseEnter(object sender, EventArgs e)
        {
            buttonAddService.BackColor = System.Drawing.Color.FromArgb(120, 170, 100);
        }

        private void ButtonAddService_MouseLeave(object sender, EventArgs e)
        {
            buttonAddService.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
        }

        private void ButtonEditService_MouseEnter(object sender, EventArgs e)
        {
            buttonEditService.BackColor = System.Drawing.Color.FromArgb(120, 170, 100);
        }

        private void ButtonEditService_MouseLeave(object sender, EventArgs e)
        {
            buttonEditService.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
        }

        private void ButtonReportHouse_MouseEnter(object sender, EventArgs e)
        {
            buttonReportHouse.BackColor = System.Drawing.Color.FromArgb(120, 170, 100);
        }

        private void ButtonReportHouse_MouseLeave(object sender, EventArgs e)
        {
            buttonReportHouse.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
        }

        private void ButtonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackColor = System.Drawing.Color.FromArgb(240, 100, 100);
        }

        private void ButtonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackColor = System.Drawing.Color.FromArgb(220, 80, 80);
        }

        private void buttonAddHouse_Click(object sender, EventArgs e)
        {
            AddHous addHous = new AddHous();
            addHous.Show();
            this.Close();
        }

        private void buttonEditHouse_Click(object sender, EventArgs e)
        {
            HousList housList = new HousList();
            housList.Show();
            this.Close();
        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            AddService addService = new AddService();
            addService.Show();
            this.Close();
        }

        private void buttonEditService_Click(object sender, EventArgs e)
        {
            ServiceList serviceList = new ServiceList();
            serviceList.Show();
            this.Close();
        }

        private void buttonReportHouse_Click(object sender, EventArgs e)
        {
            RevenueReport serviceList = new RevenueReport();
            serviceList.Show();
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form1 serviceList = new Form1();
            serviceList.Show();
            this.Close();
        }
    }
}

