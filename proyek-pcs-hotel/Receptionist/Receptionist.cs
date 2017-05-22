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
    public partial class Receptionist : Form
    {
        public OracleConnection conn;
        public Receptionist()
        {
            InitializeComponent();
        }

        private void Receptionist_Load(object sender, EventArgs e)
        {
            comboTipeKamar();
        }

        public void comboTipeKamar()
        {
            comboBox1.Items.Clear();
            try
            {
                OracleDataAdapter adap = new OracleDataAdapter("select distinct tipe_kamar from kamar", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleDataAdapter adap = new OracleDataAdapter("select kamar.kode_kamar, tipe_kamar, harga_kamar from kamar, hotel_djual where tipe_kamar = '" + comboBox1.Text + "' and kamar.kode_kamar = '" + textBox1.Text + "' and kamar.kode_kamar = hotel_djual.kode_kamar and to_date(sysdate,'DD/MM/YYYY') < tgl_in and to_date(sysdate,'DD/MM/YYYY') >= tgl_out", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dt;
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
