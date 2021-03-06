﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyek_pcs_hotel
{
    public partial class HRD : Form
    {
        public HRD()
        {
            InitializeComponent();
        }
        public OracleConnection conn;

        private void refreshKaryawan()
        {
            OracleCommand cmd = new OracleCommand(@"select p.kode_peg, p.nama_peg, d.nama_divisi
                                                    from pegawai p, pegawai_divisi d
                                                    where p.kode_divisi = d.kode_divisi", conn);
            OracleDataAdapter adap = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridViewKaryawan.DataSource = dt;

            foreach (DataGridViewColumn col in dataGridViewKaryawan.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.ReadOnly = true;
            }
        }

        public void refreshPenggajian()
        {
            OracleCommand cmd = new OracleCommand(@"select g.kode_gaji ,g.tgl_gaji ,p.kode_peg, p.nama_peg as nama, d.nama_divisi as divisi, gaji_divisi as ""GAJI DASAR"", jum_gaji as gaji
                                                    from pegawai p, pegawai_divisi d, penggajian g
                                                    where p.kode_peg = g.kode_peg and
                                                    p.kode_divisi = d.kode_divisi and
                                                    to_char(g.tgl_gaji, 'mm') = :a and
                                                    to_char(g.tgl_gaji, 'yy') = :b
                                                    order by g.kode_gaji", conn);
            cmd.Parameters.Add(":a", dateTimePicker1.Value.ToString("MM"));
            cmd.Parameters.Add(":b", dateTimePicker1.Value.ToString("yy"));
            OracleDataAdapter adap = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridViewPenggajian.DataSource = dt;

            foreach (DataGridViewColumn col in dataGridViewPenggajian.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.ReadOnly = true;
                if (col.HeaderText == "GAJI DASAR" || col.HeaderText == "GAJI")
                {
                    col.DefaultCellStyle.Format = "N2";
                }
                if (col.HeaderText == "GAJI")
                {
                    Font font = new Font(dataGridViewPenggajian.Font, FontStyle.Bold);
                    col.HeaderCell.Style.Font = font;
                    col.DefaultCellStyle.Font = font;
                    col.ReadOnly = false;
                }
            }
            if (dataGridViewPenggajian.Rows.Count == 0)
            {
                buttonBuatGaji.Enabled = true;
            }
            else
            {
                buttonBuatGaji.Enabled = false;
            }
        }

        public void refreshPelamar()
        {
            OracleCommand cmd = new OracleCommand(@"select p.kode_pelamar , p.nama, p.kotalahir, p.jk_pelamar, p.pendidikan_pelamar, d.nama_divisi ""DIVISI DIINGINKAN"" from pelamar p ,pegawai_divisi d where p.kode_divisi = d.kode_divisi", conn);
            OracleDataAdapter adap = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridViewPelamar.DataSource = dt;

            foreach (DataGridViewColumn col in dataGridViewPelamar.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.ReadOnly = true;
            }
        }

        private void HRD_Load(object sender, EventArgs e)
        {
            refreshKaryawan();
            refreshPenggajian();
            refreshPelamar();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            refreshPenggajian();
        }

        private void buttonBuatGaji_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("select * from pegawai", conn);
            OracleDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                cmd = new OracleCommand("select max(kode_gaji) from penggajian", conn);
                int kode_gaji = Int32.Parse(cmd.ExecuteScalar().ToString()) + 1;

                cmd = new OracleCommand("select gaji_divisi from pegawai_divisi where kode_divisi = :a", conn);
                cmd.Parameters.Add(":a", res.GetDecimal(1));
                int gaji = Int32.Parse(cmd.ExecuteScalar().ToString());

                cmd = new OracleCommand("insert into penggajian values(:a, :b, to_date(:c, 'mm-yy'), :d)", conn);
                cmd.Parameters.Add(":a", kode_gaji);
                cmd.Parameters.Add(":b", res.GetDecimal(0));
                cmd.Parameters.Add(":c", dateTimePicker1.Value.ToString("MM-yy"));
                cmd.Parameters.Add(":d", gaji);
                cmd.ExecuteNonQuery();
            }

            refreshPenggajian();
        }

        private void dataGridViewPenggajian_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            OracleCommand cmd = new OracleCommand("update penggajian set jum_gaji = :a where kode_gaji = :b", conn);
            cmd.Parameters.Add(":a", dataGridViewPenggajian.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            cmd.Parameters.Add(":b", dataGridViewPenggajian.Rows[e.RowIndex].Cells[0].Value);
            cmd.ExecuteNonQuery();

            MethodInvoker invoker = () => refreshPenggajian();
            BeginInvoke(invoker);
        }

        private void messageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inbox f = new Inbox();
            f.conn = this.conn;
            f.divisi = 5;
            f.ShowDialog();
        }

        private void dataGridViewPelamar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            HRD_DataPelamar f = new HRD_DataPelamar();
            OracleCommand cmd = new OracleCommand("select * from pelamar where kode_pelamar = :a", conn);
            cmd.Parameters.Add(":a", Convert.ToInt32(dataGridViewPelamar.Rows[e.RowIndex].Cells[0].Value.ToString()));
            OracleDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                f.labelKode.Text = res.GetDecimal(0).ToString();
                f.labelNama.Text = res.GetString(1);
                f.labelKota.Text = res.GetString(2);
                f.labelTgl.Text = res.GetDateTime(3).ToString("dd-MM-yy");
                f.labelJK.Text = res.GetString(4);
                f.labelAgama.Text = res.GetString(5);
                f.labelWNI.Text = res.GetString(6);
                f.labelMenikah.Text = res.GetString(7);
                f.labelPendidikan.Text = res.GetString(8);
                f.labelAlamat.Text = res.GetString(9);
                f.labelTelepon.Text = res.GetString(10);
                f.labelEmail.Text = res.GetString(11);
                f.pictureBox1.ImageLocation = Path.GetDirectoryName(Application.ExecutablePath) + @"\Pictures\" + res.GetString(12);
                cmd = new OracleCommand("select nama_divisi from pegawai_divisi where kode_divisi = :a", conn);
                cmd.Parameters.Add(":a", res.GetDecimal(13));
                f.labelDivisi.Text = cmd.ExecuteScalar().ToString();
                f.conn = conn;
                f.ff = this;
            }
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
