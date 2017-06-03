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
    public partial class Dapur : Form
    {
        public OracleConnection conn;

        public Dapur()
        {
            InitializeComponent();
        }

        private void refresh()
        {
            OracleCommand cmd = new OracleCommand(@"select h.tgl_resto, m.kode_menu, m.jenis_menu, m.nama_menu, d.quantity, h.nota_resto, h.kode_kamar, h.meja
                                                    from restoran_hjual h, restoran_djual d, restoran_menu m
                                                    where d.kode_menu = m.kode_menu and
	                                                    d.selesai = '0' and
	                                                    h.nota_resto = d.nota_resto
                                                    order by h.tgl_resto, m.kode_menu", conn);
            OracleDataAdapter adap = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Dapur_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refresh();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OracleCommand cmd = new OracleCommand("update restoran_djual set selesai = '1' where nota_resto = :a and kode_menu = :b", conn);
            cmd.Parameters.Add(":a", dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
            cmd.Parameters.Add(":b", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Update menu selesai error");
            }
            refresh();
        }

        private void soldOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dapur_SoldOut f = new Dapur_SoldOut();
            f.conn = conn;
            f.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu a = new MainMenu();
            a.Show();
        }
    }
}
