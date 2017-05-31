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
    public partial class Inbox : Form
    {
        public OracleConnection conn;
        public int divisi;
        List<int> kode = new List<int>();

        public Inbox()
        {
            InitializeComponent();
        }

        private void Inbox_Load(object sender, EventArgs e)
        {
            isilist();
        }

        public void isilist()
        {
            listBox1.Items.Clear();
            kode.Clear();
            /*OracleDataAdapter adap = new OracleDataAdapter("select * from message where kirim_kode_divisi ='" + divisi + "'", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[2].ToString() == "1")
                {
                    kode.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    listBox1.Items.Add("Receptionist");
                }
                else if (dt.Rows[i].ItemArray[2].ToString() == "2")
                {
                    kode.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    listBox1.Items.Add("Restoran");
                }
                else if (dt.Rows[i].ItemArray[2].ToString() == "3")
                {
                    kode.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    listBox1.Items.Add("Dapur");
                }
                else if (dt.Rows[i].ItemArray[2].ToString() == "4")
                {
                    kode.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    listBox1.Items.Add("Laundry");
                }
                else if (dt.Rows[i].ItemArray[2].ToString() == "5")
                {
                    kode.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    listBox1.Items.Add("HRD");
                }
            }*/
            OracleDataAdapter adap = new OracleDataAdapter("select * from message where terima_kode_divisi ='" + divisi + "'", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[1].ToString() == "1")
                {
                    kode.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    listBox1.Items.Add("Receptionist");
                }
                else if (dt.Rows[i].ItemArray[1].ToString() == "2")
                {
                    kode.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    listBox1.Items.Add("Restoran");
                }
                else if (dt.Rows[i].ItemArray[1].ToString() == "3")
                {
                    kode.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    listBox1.Items.Add("Dapur");
                }
                else if (dt.Rows[i].ItemArray[1].ToString() == "4")
                {
                    kode.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    listBox1.Items.Add("Laundry");
                }
                else if (dt.Rows[i].ItemArray[1].ToString() == "5")
                {
                    kode.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    listBox1.Items.Add("HRD");
                }
            }

        }

        private void newMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Message f = new Message();
            f.conn = conn;
            f.divisi = divisi;
            f.ShowDialog();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            button1.Visible = true;
            richTextBox1.Visible = true;
            OracleDataAdapter adap = new OracleDataAdapter("select * from message where kode_message = '" + kode[listBox1.SelectedIndex] + "'", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                richTextBox1.Text = dt.Rows[i].ItemArray[4].ToString() + ": \n" + dt.Rows[i].ItemArray[5].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
