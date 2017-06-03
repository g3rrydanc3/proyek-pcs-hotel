using Oracle.ManagedDataAccess.Client;
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
    public partial class HRD_DataPelamar : Form
    {
        public OracleConnection conn;
        public HRD ff;

        public HRD_DataPelamar()
        {
            InitializeComponent();
        }

        private void HRD_DataPelamar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleDataAdapter adap = new OracleDataAdapter("select max(kode_peg) from pegawai", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            OracleCommand cmd = new OracleCommand("insert into pegawai values(:a, :b, :c, :d, :e)", conn);
            int urutan = Convert.ToInt16(dt.Rows[0].ItemArray[0].ToString()) +1;
            cmd.Parameters.Add(":a", urutan);
            if (labelDivisi.Text == "Receptionist")
            {
                cmd.Parameters.Add(":b", "1");
            }else if (labelDivisi.Text == "Restoran")
            {
                cmd.Parameters.Add(":b", "2");
            }
            else if (labelDivisi.Text == "Dapur")
            {
                cmd.Parameters.Add(":b", "3");
            }
            else if (labelDivisi.Text == "Laundry")
            {
                cmd.Parameters.Add(":b", "4");
            }
            else if (labelDivisi.Text == "HRD")
            {
                cmd.Parameters.Add(":b", "5");
            }
            cmd.Parameters.Add(":c", labelNama.Text);
            String[] split = labelNama.Text.Split(' ');
            String username = split[1] + split[2];
            cmd.Parameters.Add(":d", username);
            cmd.Parameters.Add(":e", "pass");
            cmd.ExecuteNonQuery();
            cmd = new OracleCommand("delete from pelamar where kode_pelamar = '" + labelKode.Text + "'", conn);
            cmd.ExecuteNonQuery();
            this.Close();
            (ff as HRD).refreshPelamar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("delete from pelamar where kode_pelamar = '" + labelKode.Text + "'", conn);
            cmd.ExecuteNonQuery();
            this.Close();
            (ff as HRD).refreshPelamar();
        }
    }
}
