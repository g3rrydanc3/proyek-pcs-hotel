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
            kamar();
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
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == comboBox1.Text)
                {
                    dataGridView1.Rows[i].Selected = true;
                }
            }
            comboBox1.SelectedIndex = -1;
        }
        
        public void kamar()
        {
            dataGridView1.Columns.Clear();
            try
            {
                OracleDataAdapter adap = new OracleDataAdapter("select distinct k.kode_kamar, tipe_kamar, catatan, harga_kamar, (case when tgl_in > to_date('" + dateTimePicker1.Value.ToString().Substring(0, 10) + "', 'DD-MM-YYYY') then tgl_in || ' - ' || tgl_out else ' ' end) from kamar k, hotel_djual h where k.kode_kamar = h.kode_kamar and (to_date(sysdate,'DD/MM/YYYY') < tgl_in or to_date(sysdate,'DD/MM/YYYY') >= tgl_out) union select distinct k.kode_kamar, tipe_kamar, catatan, harga_kamar, (case when tgl_in > to_date('" + dateTimePicker1.Value.ToString().Substring(0, 10) + "', 'DD-MM-YYYY') then tgl_in || ' - ' || tgl_out else ' ' end) from kamar k, hotel_djual h where k.kode_kamar not in (select h.kode_kamar from hotel_djual)", conn);
                //OracleDataAdapter adap = new OracleDataAdapter("select k.kode_kamar, tipe_kamar, catatan, harga_kamar from kamar k, hotel_djual h where k.kode_kamar = h.kode_kamar and (to_date(sysdate,'DD/MM/YYYY') < tgl_in or to_date(sysdate,'DD/MM/YYYY') >= tgl_out)", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[4].HeaderText = "DI BOOKING TANGGAL";
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                comboTipeKamar();
                kamar();
            }
            else
            {
                statusHariIni();
            }
        }

        private void statusHariIni()
        {
            dataGridView2.Columns.Clear();
            try
            {
                OracleDataAdapter adap = new OracleDataAdapter("select distinct kamar.kode_kamar, tipe_kamar, catatan, harga_kamar from kamar, hotel_djual where kamar.kode_kamar = hotel_djual.kode_kamar and (to_date(sysdate,'DD/MM/YYYY') < tgl_in or to_date(sysdate,'DD/MM/YYYY') >= tgl_out) union select distinct k.kode_kamar, tipe_kamar, catatan, harga_kamar from kamar k, hotel_djual h where k.kode_kamar not in (select h.kode_kamar from hotel_djual)", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
