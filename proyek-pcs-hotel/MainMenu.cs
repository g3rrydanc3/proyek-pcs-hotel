using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyek_pcs_hotel
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void openForm(String form)
        {
            Login f = new Login();
            f.Closed += (s, args) => this.Close();
            f.mode = form;
            this.Hide();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openForm("Receptionist");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openForm("Restoran");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openForm("Dapur");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openForm("Laundry");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openForm("Self_Booking");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openForm("HRD");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openForm("Laporan");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openForm("Lamar");
        }
    }
}
