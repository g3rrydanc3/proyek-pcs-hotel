using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using Oracle.ManagedDataAccess.Client;
//using Oracle.DataAccess.Client;

namespace proyek_pcs_hotel
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        OracleConnection conn;

        private void MainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("_config.ini");
                string connectionString = "Data source=" + data["oracle"]["datasource"] + ";User ID=" + data["oracle"]["username"] + ";Password=" + data["oracle"]["password"];
                MessageBox.Show(connectionString);
                conn = new OracleConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }

        private void openForm(String form)
        {
            Login f = new Login();
            f.Closed += (s, args) => this.Close();
            f.mode = form;
            f.conn = conn;
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
