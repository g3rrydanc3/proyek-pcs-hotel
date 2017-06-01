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
    public partial class SB : Form
    {
        public OracleConnection conn;
        public SB()
        {
            InitializeComponent();
            sB_11.Show();
            sB_21.Hide();
            sB_31.Hide();
            sB_11.button1.Click += sB_11_ButtonClick;
            sB_21.buttonBack.Click += sB_21_ButtonBackClick;
            sB_31.buttonBack.Click += sB_11_ButtonClick;
            sB_31.buttonPesan.Click += sB_31_buttonPesan_Click;
        }

        private void sB_31_buttonPesan_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand("select COALESCE(max(nota_hotel), 0) from hotel_hjual", conn);
            int urutan = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            cmd = new OracleCommand("insert into hotel_hjual values(:a, :b, :c)", conn);
            cmd.Parameters.Add(":a", urutan);
            cmd.Parameters.Add(":b", sB_31.textBoxNama.Text);
            cmd.Parameters.Add(":c", sB_31.textBoxAlamat.Text);
            if (cmd.ExecuteNonQuery() != 0)
            {
                int count = 0;
                foreach (DataGridViewRow row in sB_31.dataGridView1.Rows)
                {
                    cmd = new OracleCommand("insert into hotel_djual values (:a, :b, to_date(:c, 'dd-mm-yy'), to_date(:d, 'dd-mm-yy'))", conn);
                    cmd.Parameters.Add(":a", urutan);
                    cmd.Parameters.Add(":b", nomorKamar[count]);
                    cmd.Parameters.Add(":c", sB_11.dateTimePicker1.Value.ToString("dd-MM-yy"));
                    cmd.Parameters.Add(":d", sB_11.dateTimePicker1.Value.AddDays(Convert.ToDouble(sB_11.numericUpDown1.Value)).ToString("dd-MM-yy"));
                    cmd.ExecuteNonQuery();
                    count++;
                }
                MessageBox.Show("Berhasil");
                sB_31.dataGridView1.Rows.Clear();
                sB_11.Show();
                sB_21.Hide();
                sB_31.Hide();
            }
            else
            {
                MessageBox.Show("Error insert hotel_hjual");
            }
            
        }

        List<int> jumlahKamar = new List<int>();
        List<string> tipeKamar = new List<string>();
        List<int> hargaKamar = new List<int>();
        List<int> nomorKamarTemp = new List<int>();
        List<int> nomorKamar = new List<int>();

        private void sB_11_ButtonClick(object sender, EventArgs e)
        {
            jumlahKamar.Clear();
            tipeKamar.Clear();
            hargaKamar.Clear();
            nomorKamarTemp.Clear();
            nomorKamar.Clear();
            sB_21.tableLayoutPanel1.Controls.Clear();
            sB_21.tableLayoutPanel1.RowStyles.Clear();
            sB_31.dataGridView1.Rows.Clear();
            sB_11.Hide();
            sB_21.Show();
            sB_31.Hide();

            OracleCommand cmd = new OracleCommand("select * from tipe_kamar", conn);
            OracleDataReader res = cmd.ExecuteReader();
            while(res.Read())
            {
                if (sB_21.tableLayoutPanel1.HorizontalScroll.Visible == true)
                {
                    sB_21.tableLayoutPanel1.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                }
                string tipe = res.GetString(0);
                string deskripsi = res.GetString(1);

                sB_21.tableLayoutPanel1.RowCount = sB_21.tableLayoutPanel1.RowCount + 1;
                sB_21.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                Self_Booking.SB_RoomList f = new Self_Booking.SB_RoomList();
                f.Dock = DockStyle.Fill;
                jumlahKamar.Add(0);
                int count = jumlahKamar.Count - 1;
                f.numericUpDown1.ValueChanged += (s, ev) =>
                {
                    jumlahKamar[count] = (int) f.numericUpDown1.Value;
                };

                f.labelRoom.Text = tipe;
                tipeKamar.Add(tipe);
                f.labelDesc.Text = deskripsi;
                
                cmd = new OracleCommand(@"select *
                                        from (
	                                        select harga_kamar, kode_kamar
	                                        from kamar k
	                                        where kode_kamar not in (
		                                        select kode_kamar 
		                                        from hotel_djual
		                                        where (to_date(:a, 'dd-mm-yy') between tgl_in and tgl_out - 1)
	                                        ) and 
                                            tipe_kamar = :b
                                        )
                                        where rownum <= 1", conn);
                cmd.Parameters.Add(":a", sB_11.dateTimePicker1.Value.ToString("dd-MM-yy"));
                cmd.Parameters.Add(":b", tipe);

                OracleDataReader res1 = cmd.ExecuteReader();
                int harga = 0;
                while (res1.Read())
                {
                    harga = Int32.Parse(res1.GetDecimal(0).ToString());
                    nomorKamarTemp.Add(Int32.Parse(res1.GetDecimal(1).ToString()));
                }
                
                f.labelHarga.Text = harga.ToString("C") + "/malam";
                hargaKamar.Add(harga);
                
                sB_21.tableLayoutPanel1.Controls.Add(f, 0, sB_21.tableLayoutPanel1.RowCount - 1); //add ke tablelayoutpanel
            }
            sB_21.tableLayoutPanel1.RowCount = sB_21.tableLayoutPanel1.RowCount + 1;
            sB_21.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            Button b = new Button();
            b.Text = "Book";
            b.Dock = DockStyle.Fill;
            b.Click += (s, ev) =>
            {
                bool boleh = false;
                foreach (int jum in jumlahKamar)
                {
                    if (jum >= 1)
                    {
                        boleh = true;
                    }
                }
                if (boleh)
                {
                    int count = 1;
                    for (int i = 0; i < jumlahKamar.Count; i++)
                    {
                        if (jumlahKamar[i] >= 1)
                        {
                            sB_31.dataGridView1.Rows.Add(count++, tipeKamar[i], hargaKamar[i], jumlahKamar[i], hargaKamar[i] * jumlahKamar[i]);
                            nomorKamar.Add(nomorKamarTemp[i]);
                        }
                    }
                    foreach (DataGridViewColumn col in sB_31.dataGridView1.Columns)
                    {
                        if (col.HeaderText == "Harga" || col.HeaderText == "Jumlah")
                        {
                            col.DefaultCellStyle.Format = "N2";
                        }
                    }
                    int jumlah = 0;
                    foreach (DataGridViewRow row in sB_31.dataGridView1.Rows)
                    {
                        jumlah += Int32.Parse(row.Cells[4].Value.ToString());
                    }
                    sB_31.labelHarga.Text = jumlah.ToString("C");
                    sB_21.Hide();
                    sB_31.Show();
                }
                else
                {
                    MessageBox.Show("Minimal harus ada 1 kamar");
                }
            };
            
            sB_21.tableLayoutPanel1.Controls.Add(b, 0, sB_21.tableLayoutPanel1.RowCount - 1);
        }

        private void sB_21_ButtonBackClick(object sender, EventArgs e)
        {
            sB_11.Show();
            sB_21.Hide();
            sB_31.Hide();
        }

        private void SB_Resize(object sender, EventArgs e)
        {
            if (sB_21.tableLayoutPanel1.VerticalScroll.Visible == true)
            {
                sB_21.tableLayoutPanel1.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
            }
            else
            {
                sB_21.tableLayoutPanel1.Padding = new Padding(0, 0, 0, 0);
            }
        }
    }
}
