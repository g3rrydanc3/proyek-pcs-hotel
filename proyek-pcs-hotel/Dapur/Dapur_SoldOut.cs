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
    public partial class Dapur_SoldOut : Form
    {
        public Dapur_SoldOut()
        {
            InitializeComponent();
        }
        public OracleConnection conn;
        int index = -1;

        private void refresh()
        {
            OracleCommand cmd = new OracleCommand("select kode_menu as kode, nama_menu as nama, soldout from restoran_menu", conn);
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

            foreach (DataGridViewRow rows in dataGridView1.Rows)
            {
                if (rows.Cells[2].Value.ToString() == "1")
                {
                    rows.DefaultCellStyle.BackColor = Color.Cyan;
                }
            }
        }

        private void Dapur_SoldOut_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            buttonSoldOut.Enabled = true;
            buttonAvailable.Enabled = true;
        }

        private void buttonSoldOut_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("update restoran_menu set soldout = '1' where kode_menu = :a", conn);
            cmd.Parameters.Add(":a", dataGridView1.Rows[index].Cells[0].Value);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Error update restoran_menu");
            }
            refresh();
            index = -1;
            buttonSoldOut.Enabled = false;
            buttonAvailable.Enabled = false;
        }

        private void buttonAvailable_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("update restoran_menu set soldout = '0' where kode_menu = :a", conn);
            cmd.Parameters.Add(":a", dataGridView1.Rows[index].Cells[0].Value);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Error update restoran_menu");
            }
            refresh();
            index = -1;
            buttonSoldOut.Enabled = false;
            buttonAvailable.Enabled = false;
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
