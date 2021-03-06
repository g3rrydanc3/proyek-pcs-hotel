﻿using Oracle.ManagedDataAccess.Client;
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
    public partial class Laundry : Form
    {
        public OracleConnection conn;
        public Laundry()
        {
            InitializeComponent();
        }

        private void refreshOrder()
        {
            comboBoxKamar.Items.Clear();
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
                comboBoxKamar.Items.Add(res.GetInt32(0));
            }
        }

        private void refreshDetail()
        {
            OracleCommand cmd = new OracleCommand(@"select h.tgl_laundry, h.nota_laundry, jenis_laundry, d.berat_laundry, h.kode_kamar, d.berat_laundry * j.harga_laundry as harga
                                                    from laundry_jenis j, laundry_djual d, laundry_hjual h
                                                    where j.kode_laundry = d.kode_laundry and d.nota_laundry = h.nota_laundry and
                                                    d.sudah = '0'", conn);
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

        private void Laundry_Load(object sender, EventArgs e)
        {
            refreshOrder();
            refreshDetail();
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            if (comboBoxKamar.Text != "")
            {
                string kamar = comboBoxKamar.Text;
                int berat = (int) numericUpDownBerat.Value;
                int jenis = 1;
                string strJenis = "Cuci Basah";
                if (radioButtonCuciKering.Checked)
                {
                    jenis = 2;
                    strJenis = "Cuci Kering";
                }
                else if (radioButtonSetrika.Checked)
                {
                    jenis = 3;
                    strJenis = "Setrika";
                }

                comboBoxKamar.Enabled = false;
                dataGridViewOrder.Rows.Add(dataGridViewOrder.Rows.Count + 1, strJenis + "-" + jenis, berat);
                buttonSelesai.Enabled = true;
            }
            else
            {
                MessageBox.Show("Nomor kamar tidak boleh kosong");
            }
        }

        private void buttonSelesai_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("select max(nota_laundry) from laundry_hjual", conn);
            int nota_laundry = Int32.Parse(cmd.ExecuteScalar().ToString()) + 1;

            cmd = new OracleCommand("insert into laundry_hjual values (:a, sysdate, :b)", conn);
            cmd.Parameters.Add(":a", nota_laundry);
            cmd.Parameters.Add(":b", comboBoxKamar.Text);
            if (cmd.ExecuteNonQuery() != 0)
            {
                foreach (DataGridViewRow rows in dataGridViewOrder.Rows)
                {
                    cmd = new OracleCommand("insert into laundry_djual values(:a, :b, :c, :d)", conn);
                    cmd.Parameters.Add(":a", nota_laundry);
                    cmd.Parameters.Add(":b", rows.Cells[1].Value.ToString().Split('-')[1]);
                    cmd.Parameters.Add(":c", Int32.Parse(rows.Cells[2].Value.ToString()));
                    cmd.Parameters.Add(":d", '0');
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("Error insert laundry_djual");
                    }
                }
            }
            else
            {
                MessageBox.Show("Error insert laundry_hjual");
            }

            refreshDetail();
            refreshOrder();
            comboBoxKamar.Enabled = true;
            radioButtonCuciKering.Checked = true;
            numericUpDownBerat.Value = 1;
            dataGridViewOrder.Rows.Clear();
            buttonSelesai.Enabled = false;
        }

        private void messageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inbox f = new Inbox();
            f.conn = this.conn;
            f.divisi = 4;
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
