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
using System.Diagnostics;

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

        private void reset()
        {
            refresh();
            dataGridView3.Rows.Clear();
            numericUpDownDrink.Value = 1;
            numericUpDownFood.Value = 1;
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
                dataGridView3.Rows.Add(dataGridView3.Rows.Count + 1, "Makanan", dataGridViewFood.Rows[indexFood].Cells[0].Value, dataGridViewFood.Rows[indexFood].Cells[1].Value, numericUpDownFood.Value);
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
                dataGridView3.Rows.Add(dataGridView3.Rows.Count + 1, "Minuman", dataGridViewDrink.Rows[indexDrink].Cells[0].Value, dataGridViewDrink.Rows[indexDrink].Cells[1].Value, numericUpDownFood.Value);
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
            Restoran_Input f = new Restoran_Input();
            f.label1.Text = "Nomor Meja :";

            TextBox t = new TextBox();
            t.AutoCompleteMode = AutoCompleteMode.Suggest;
            t.AutoCompleteSource = AutoCompleteSource.CustomSource;
            f.tableLayoutPanel1.Controls.Add(t, 1, 0);
            t.Dock = DockStyle.Fill;
            t.KeyPress += (s, ee) =>
            {
                if (!char.IsControl(ee.KeyChar) && !char.IsDigit(ee.KeyChar))
                {
                    ee.Handled = true;
                }

            };

            f.button1.Click += (s, args) =>
            {
                OracleCommand cmd = new OracleCommand("select max(nota_resto) from restoran_hjual", conn);
                int nota_resto = Int32.Parse(cmd.ExecuteScalar().ToString()) + 1;

                cmd = new OracleCommand("insert into restoran_hjual values (:a, sysdate, :b, :c)", conn);
                cmd.Parameters.Add(":a", nota_resto);
                cmd.Parameters.Add(":b", null);
                cmd.Parameters.Add(":c", null);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("Insert Hjual error");
                }
                else
                {
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        cmd = new OracleCommand("insert into restoran_djual values(:a, :b, :c, :d)", conn);
                        cmd.Parameters.Add(":a", nota_resto);
                        cmd.Parameters.Add(":b", row.Cells[2].Value.ToString());
                        cmd.Parameters.Add(":c", row.Cells[4].Value.ToString());
                        cmd.Parameters.Add(":d", OracleDbType.Char).Value = "0";
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("Insert Djual error" + row.Cells[2].Value.ToString());
                        }
                    }
                }
                f.Close();
                reset();
            };
            f.ShowDialog();
        }

        private void buttonTakeAway_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("select max(nota_resto) from restoran_hjual", conn);
            int nota_resto = Int32.Parse(cmd.ExecuteScalar().ToString()) + 1;

            cmd = new OracleCommand("insert into restoran_hjual values (:a, sysdate, :b, :c)", conn);
            cmd.Parameters.Add(":a", nota_resto);
            cmd.Parameters.Add(":b", null);
            cmd.Parameters.Add(":c", null);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Insert Hjual error");
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    cmd = new OracleCommand("insert into restoran_djual values(:a, :b, :c, :d)", conn);
                    cmd.Parameters.Add(":a", nota_resto);
                    cmd.Parameters.Add(":b", row.Cells[2].Value.ToString());
                    cmd.Parameters.Add(":c", row.Cells[4].Value.ToString());
                    cmd.Parameters.Add(":d", OracleDbType.Char).Value = "0";
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Insert Djual error" + row.Cells[2].Value.ToString());
                    }
                }
            }
            reset();
        }

        private void buttonDelivery_Click(object sender, EventArgs e)
        {
            Restoran_Input f = new Restoran_Input();
            f.label1.Text = "Nomor Kamar :";

            ComboBox c = new ComboBox();
            c.DropDownStyle = ComboBoxStyle.DropDownList;
            f.tableLayoutPanel1.Controls.Add(c, 1, 0);
            c.Dock = DockStyle.Fill;
            
            OracleCommand cmd = new OracleCommand(@"select k.kode_kamar
                                                    from kamar k
                                                    where k.kode_kamar = (
                                                        select d.kode_kamar
                                                        from hotel_djual d
                                                        where (sysdate between tgl_in and tgl_out) and
                                                        d.kode_kamar = k.kode_kamar
                                                    )", conn);
            OracleDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                c.Items.Add(res.GetInt32(0));
            }

            f.button1.Click += (s, args) =>
            {
                cmd = new OracleCommand("select max(nota_resto) from restoran_hjual", conn);
                int nota_resto = Int32.Parse(cmd.ExecuteScalar().ToString()) + 1;

                cmd = new OracleCommand("insert into restoran_hjual values (:a, sysdate, :b, :c)", conn);
                cmd.Parameters.Add(":a", nota_resto);
                cmd.Parameters.Add(":b", c.Text);
                cmd.Parameters.Add(":c", null);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("Insert Hjual error");
                }
                else
                {
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        cmd = new OracleCommand("insert into restoran_djual values(:a, :b, :c, :d)", conn);
                        cmd.Parameters.Add(":a", nota_resto);
                        cmd.Parameters.Add(":b", row.Cells[2].Value.ToString());
                        cmd.Parameters.Add(":c", row.Cells[4].Value.ToString());
                        cmd.Parameters.Add(":d", OracleDbType.Char).Value = "0";
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("Insert Djual error" + row.Cells[2].Value.ToString());
                        }
                    }
                }
                f.Close();
                reset();
            };
            f.ShowDialog();
        }

        private void messageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inbox f = new Inbox();
            f.conn = this.conn;
            f.divisi = 2;
            f.ShowDialog();
        }
    }
}
