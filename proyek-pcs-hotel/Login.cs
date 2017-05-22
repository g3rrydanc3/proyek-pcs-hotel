using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Oracle.ManagedDataAccess.Client;

namespace proyek_pcs_hotel
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public string mode;
        //public OracleConnection conn;

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text.Trim().ToLower().Count() == 0 && maskedTextBox1.Text.Count() == 0)
            if (true)
            {
                if (mode == "Receptionist")
                {
                    if (true)//CEK USERNAME
                    {
                        Receptionist f = new Receptionist();
                        f.Closed += (s, args) => this.Close();
                        this.Hide();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username / Password Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
                }
                else if (mode == "Restoran")
                {
                    if (true)//CEK USERNAME
                    {
                        Restoran f = new Restoran();
                        f.Closed += (s, args) => this.Close();
                        this.Hide();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username / Password Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (mode == "Dapur")
                {
                    if (true)//CEK USERNAME
                    {
                        Dapur f = new Dapur();
                        f.Closed += (s, args) => this.Close();
                        this.Hide();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username / Password Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (mode == "Laundry")
                {
                    if (true)//CEK USERNAME
                    {
                        Laundry f = new Laundry();
                        f.Closed += (s, args) => this.Close();
                        this.Hide();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username / Password Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (mode == "Self_Booking")
                {
                    if (true)//CEK USERNAME
                    {
                        SB f = new SB();
                        f.Closed += (s, args) => this.Close();
                        this.Hide();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username / Password Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (mode == "HRD")
                {
                    if (true)//CEK USERNAME
                    {
                        HRD f = new HRD();
                        f.Closed += (s, args) => this.Close();
                        this.Hide();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username / Password Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (mode == "Laporan")
                {
                    if (true)//CEK USERNAME
                    {
                        Laporan f = new Laporan();
                        f.Closed += (s, args) => this.Close();
                        this.Hide();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username / Password Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (mode == "Lamar")
                {
                    if (true)//CEK USERNAME
                    {
                        LamarPekerjaan f = new LamarPekerjaan();
                        f.Closed += (s, args) => this.Close();
                        this.Hide();
                        f.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username / Password Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
