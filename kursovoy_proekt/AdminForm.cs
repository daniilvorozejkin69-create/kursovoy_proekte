using System;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void ButtonAddUser_MouseEnter(object sender, EventArgs e)
        {
            buttonAddUser.BackColor = System.Drawing.Color.FromArgb(120, 170, 100);
        }

        private void ButtonAddUser_MouseLeave(object sender, EventArgs e)
        {
            buttonAddUser.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
        }

        private void ButtonEditUser_MouseEnter(object sender, EventArgs e)
        {
            buttonEditUser.BackColor = System.Drawing.Color.FromArgb(120, 170, 100);
        }

        private void ButtonEditUser_MouseLeave(object sender, EventArgs e)
        {
            buttonEditUser.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
        }

        private void ButtonReport_MouseEnter(object sender, EventArgs e)
        {
            buttonReport.BackColor = System.Drawing.Color.FromArgb(120, 170, 100);
        }

        private void ButtonReport_MouseLeave(object sender, EventArgs e)
        {
            buttonReport.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
        }

        private void ButtonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackColor = System.Drawing.Color.FromArgb(240, 100, 100);
        }

        private void ButtonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackColor = System.Drawing.Color.FromArgb(220, 80, 80);
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
            this.Close();
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            UsersList usersList = new UsersList();
            usersList.Show();
            this.Close();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            OtchetForm reportForm = new OtchetForm();
            reportForm.Show();
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

