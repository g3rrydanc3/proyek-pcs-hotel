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
    public partial class Restoran : Form
    {
        public OracleConnection conn;
        int indexFood = -1;
        int indexDrink = -1;
        int indexOrder = -1;
        public Restoran()
        {
            InitializeComponent();
        }
        private void refresh()
        {
            OracleCommand cmd = new OracleCommand("select kode_menu as kode, nama_menu as nama, harga_menu as harga from restoran_menu where jenis_menu = 'Makanan' and soldout = 0", conn);
            OracleDataAdapter adap = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridViewFood.DataSource = dt;

            foreach (DataGridViewColumn col in dataGridViewFood.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.ReadOnly = true;
                if (col.HeaderText == "HARGA")
                {
                    col.DefaultCellStyle.Format = "N2";
                }
            }

            cmd = new OracleCommand("select kode_menu as kode, nama_menu  as nama, harga_menu as harga from restoran_menu where jenis_menu = 'Minuman' and soldout = 0", conn);
            adap = new OracleDataAdapter(cmd);
            dt = new DataTable();
            adap.Fill(dt);
            dataGridViewDrink.DataSource = dt;

            foreach (DataGridViewColumn col in dataGridViewDrink.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.ReadOnly = true;
                if (col.HeaderText == "HARGA")
                {
                    col.DefaultCellStyle.Format = "N2";
                }
            }
        }

        private void Restoran_Load(object sender, EventArgs e)
        {
            refresh();
        }
        #region Food
        private void dataGridViewFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexFood = e.RowIndex;
            buttonOrderFood.Enabled = true;
        }
        
        private void buttonOrderFood_Click(object sender, EventArgs e)
        {
            if (indexFood != -1)
            {
                dataGridView3.Rows.Add(dataGridView3.Rows.Count + 1, "Makanan", dataGridViewFood.Rows[indexFood].Cells[1].Value, numericUpDownFood.Value);
                indexFood = -1;
                buttonOrderFood.Enabled = false;
                numericUpDownFood.Value = 1;
            }
            else
            {
                MessageBox.Show("Pilih menu dulu.", "Error");
            }
        }
        #endregion
        #region Drink
        private void dataGridViewDrink_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexDrink = e.RowIndex;
            buttonOrderDrink.Enabled = true;
        }

        private void buttonOrderDrink_Click(object sender, EventArgs e)
        {
            if (indexDrink != -1)
            {
                dataGridView3.Rows.Add(dataGridView3.Rows.Count + 1, "Minuman", dataGridViewDrink.Rows[indexDrink].Cells[1].Value, numericUpDownFood.Value);
                indexDrink = -1;
                buttonOrderDrink.Enabled = false;
                numericUpDownFood.Value = 1;
            }
            else
            {
                MessageBox.Show("Pilih menu dulu.", "Error");
            }
        }
        #endregion
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexOrder = e.RowIndex;
            buttonDelete.Enabled = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            buttonDelete.Enabled = true;
            dataGridView3.Rows.RemoveAt(indexOrder);
            int count = 0;
            dataGridView3.Sort(dataGridView3.Columns[0], ListSortDirection.Ascending);
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }
        
        private void buttonDineIn_Click(object sender, EventArgs e)
        {

        }

        private void buttonTakeAway_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelivery_Click(object sender, EventArgs e)
        {

        }
    }
}
