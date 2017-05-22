using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace proyek_pcs_hotel
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public string mode;
        public OracleConnection conn;

        private void buka(bool ada)
        {
            if (mode == "Receptionist")
            {
                if (ada)
                {
                    Receptionist f = new Receptionist();
                    f.conn = conn;
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
                if (ada)
                {
                    Restoran f = new Restoran();
                    f.conn = conn;
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
                if (ada)
                {
                    Dapur f = new Dapur();
                    //f.conn = conn;
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
                if (ada)
                {
                    Laundry f = new Laundry();
                    //f.conn = conn;
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
                if (ada)
                {
                    HRD f = new HRD();
                    //f.conn = conn;
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
                if (textBox1.Text == "admin" && textBox2.Text == "admin")
                {
                    Laporan f = new Laporan();
                    //f.conn = conn;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().ToLower().Count() != 0 && textBox2.Text.Count() != 0)
            {
                textBox1.Text = textBox1.Text.Trim();
                textBox2.Text = textBox2.Text.TrimStart().TrimEnd();

                OracleCommand cmd = new OracleCommand("select count(*) from pegawai p, pegawai_divisi d where p.kode_divisi = d.kode_divisi and p.username = :a and p.password = :b and d.nama_divisi = :c", conn);
                cmd.Parameters.Add(":a", textBox1.Text);
                cmd.Parameters.Add(":b", textBox2.Text);
                cmd.Parameters.Add(":c", mode);
                bool ada = Convert.ToBoolean(Int32.Parse(cmd.ExecuteScalar().ToString()));

                buka(ada);
            }
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            if (mode == "Self_Booking")
            {
                SB f = new SB();
                //f.conn = conn;
                f.Closed += (s, args) => this.Close();
                this.Hide();
                f.Show();
            }
            else if (mode == "Lamar")
            {
                LamarPekerjaan f = new LamarPekerjaan();
                f.conn = conn;
                f.Closed += (s, args) => this.Close();
                this.Hide();
                f.Show();
            }
            /////////////////////
            //JANGAN LUPA DELETE
            //////////////////////
            buka(true);
        }
    }
}
