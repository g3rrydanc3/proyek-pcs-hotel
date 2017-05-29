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
        string tempKodeUpdate = "";

        public Receptionist()
        {
            InitializeComponent();
        }

        private void refreshComboBoxTipe()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("All");
            OracleDataAdapter adap = new OracleDataAdapter("select distinct tipe_kamar from kamar", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            comboBox1.SelectedIndex = 0;
        }

        public void refreshKamar()
        {
            OracleCommand cmd;
            if (comboBox1.Text == "All")
            {
                cmd = new OracleCommand(@"select kode_kamar as nomor, tipe_kamar as tipe, catatan, harga_kamar as harga
                                                    from kamar k
                                                    where kode_kamar not in (
                                                        select kode_kamar 
                                                        from hotel_djual
                                                        where (to_date(:a, 'dd-mm-yy') between tgl_in and tgl_out - 1)
                                                    )", conn);
                cmd.Parameters.Add(":a", dateTimePicker1.Value.ToString("dd-MM-yy"));
            }
            else
            {
                cmd = new OracleCommand(@"select kode_kamar as nomor, tipe_kamar as tipe, catatan, harga_kamar as harga
                                                    from kamar k
                                                    where kode_kamar not in (
                                                        select kode_kamar 
                                                        from hotel_djual
                                                        where (to_date(:a, 'dd-mm-yy') between tgl_in and tgl_out - 1)
                                                    ) and
                                                    tipe_kamar = :b", conn);
                cmd.Parameters.Add(":a", dateTimePicker1.Value.ToString("dd-MM-yy"));
                cmd.Parameters.Add(":b", comboBox1.Text);
            }

            OracleDataAdapter adap = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.ReadOnly = true;
                if (col.HeaderText == "HARGA")
                {
                    col.DefaultCellStyle.Format = "N2";
                }
            }
        }

        private void statusHariIni()
        {
            dataGridView2.Columns.Clear();
            try
            {
                OracleCommand cmd = new OracleCommand(@"select kode_kamar as nomor, tipe_kamar as tipe, catatan, harga_kamar as harga, (select count(*) 
                                                            from hotel_djual d
                                                            where (to_date(:a, 'dd-mm-yy') between tgl_in and tgl_out - 1) and
                                                            k.kode_kamar = d.kode_kamar
                                                        ) as terisi
                                                        from kamar k", conn);
                cmd.Parameters.Add(":a", DateTime.Now.ToString("dd-MM-yy"));
                OracleDataAdapter adap = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dataGridView2.DataSource = dt;

                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    if (col.HeaderText == "TERISI")
                    {
                        col.ReadOnly = true;
                    }
                    if (col.HeaderText == "HARGA")
                    {
                        col.DefaultCellStyle.Format = "N2";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Receptionist_Load(object sender, EventArgs e)
        {
            refreshComboBoxTipe();
            refreshKamar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshKamar();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            refreshKamar();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                refreshComboBoxTipe();
                refreshKamar();
            }
            else
            {
                statusHariIni();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //booking kamar
            Receptionist_IsiKamar f = new Receptionist_IsiKamar();
            f.conn = conn;
            f.label4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            f.comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            f.label7.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            f.tanggal = dateTimePicker1.Value.ToString().Substring(0, 10);
            f.tipe = "booking";
            f.Show();
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            tempKodeUpdate = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            OracleCommand cmd = new OracleCommand("update kamar set kode_kamar = :a, tipe_kamar = :b, catatan = :c, harga_kamar = :d where kode_kamar = :e", conn);
            cmd.Parameters.Add(":a", dataGridView2.Rows[e.RowIndex].Cells[0].Value);
            cmd.Parameters.Add(":b", dataGridView2.Rows[e.RowIndex].Cells[1].Value);
            cmd.Parameters.Add(":c", dataGridView2.Rows[e.RowIndex].Cells[2].Value);
            cmd.Parameters.Add(":d", dataGridView2.Rows[e.RowIndex].Cells[3].Value);
            cmd.Parameters.Add(":e", tempKodeUpdate);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Error update kamar");
            }
            tempKodeUpdate = "";
            refreshComboBoxTipe();
            refreshKamar();
        }

        private void messageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Message f = new Message();
            f.conn = this.conn;
            f.divisi = 1;
            f.ShowDialog();
        }
    }
}
