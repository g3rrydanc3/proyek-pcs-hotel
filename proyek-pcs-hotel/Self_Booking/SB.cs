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
            sB_11.button1.Click += new EventHandler(sB_11_ButtonClick);
            sB_21.buttonBack.Click += new EventHandler(sB_21_ButtonBackClick);
        }

        private void sB_11_ButtonClick(object sender, EventArgs e)
        {
            sB_11.Hide();
            sB_21.Show();
            sB_31.Hide();
            sB_21.tableLayoutPanel1.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);

            OracleCommand cmd = new OracleCommand("select * from tipe_kamar", conn);
            OracleDataReader res = cmd.ExecuteReader();
            while(res.Read())
            {
                string tipe = res.GetString(0);
                string deskripsi = res.GetString(1);

                sB_21.tableLayoutPanel1.RowCount = sB_21.tableLayoutPanel1.RowCount + 1;
                sB_21.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                Self_Booking.SB_RoomList f = new Self_Booking.SB_RoomList();
                f.Dock = DockStyle.Fill;

                f.labelRoom.Text = tipe;
                f.labelDesc.Text = deskripsi;
                //f.labelHarga.Text = ;

                f.buttonBook.Click += (s, ev) =>
                {
                    MessageBox.Show(tipe);
                };
                
                sB_21.tableLayoutPanel1.Controls.Add(f, 0, sB_21.tableLayoutPanel1.RowCount - 1);
            }
            //bug fix row terakhir membesar
            sB_21.tableLayoutPanel1.RowCount = sB_21.tableLayoutPanel1.RowCount + 1;
            sB_21.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        private void sB_21_ButtonBackClick(object sender, EventArgs e)
        {
            sB_11.Show();
            sB_21.Hide();
            sB_31.Hide();
            sB_21.tableLayoutPanel1.Controls.Clear();
            sB_21.tableLayoutPanel1.RowStyles.Clear();
        }
    }
}
