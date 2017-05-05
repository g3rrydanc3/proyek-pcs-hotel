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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public string mode;

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text.Trim().ToLower().Count() == 0 && maskedTextBox1.Text.Count() == 0)
            if (true)
            {
                if (mode == "Receptionist")
                {
                    Receptionist f = new Receptionist();
                    f.Closed += (s, args) => this.Close();
                    this.Hide();
                    f.Show();
                }
                else if (mode == "Restoran")
                {

                }
                else if (mode == "Dapur")
                {

                }
                else if (mode == "Laundry")
                {

                }
                else if (mode == "Self_Booking")
                {

                }
                else if (mode == "HRD")
                {

                }
                else if (mode == "Laporan")
                {

                }
            }
        }
    }
}
