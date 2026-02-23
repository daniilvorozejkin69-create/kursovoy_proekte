using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class OtchetForm : Form
    {
        public OtchetForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminForm mainForm = new AdminForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
