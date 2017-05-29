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
    public partial class Message : Form
    {
        public OracleConnection conn;
        public int divisi;
        OracleDataAdapter adap;
        DataTable dt;
        List<int> kodedivisi = new List<int>();

        public Message()
        {
            InitializeComponent();
        }

        private void Message_Load(object sender, EventArgs e)
        {
            if (divisi == 1)
            {
                checkBox1.Text = "Restoran";
                checkBox2.Text = "Dapur";
                checkBox3.Text = "Laundry";
                checkBox4.Text = "HRD";
            }
            else if (divisi == 2)
            {
                checkBox1.Text = "Receptionist";
                checkBox2.Text = "Dapur";
                checkBox3.Text = "Laundry";
                checkBox4.Text = "HRD";
            }
            else if (divisi == 3)
            {
                checkBox1.Text = "Receptionist";
                checkBox2.Text = "Restoran";
                checkBox3.Text = "Laundry";
                checkBox4.Text = "HRD";
            }
            else if (divisi == 4)
            {
                checkBox1.Text = "Receptionist";
                checkBox2.Text = "Restoran";
                checkBox3.Text = "Dapur";
                checkBox4.Text = "HRD";
            }
            else if (divisi == 5)
            {
                checkBox1.Text = "Receptionist";
                checkBox2.Text = "Restoran";
                checkBox3.Text = "Dapur";
                checkBox4.Text = "Laundry";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adap = new OracleDataAdapter("select * from pegawai_divisi", conn);
            dt = new DataTable();
            adap.Fill(dt);
            kodedivisi.Clear();
            if(checkBox1.Checked == true)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MessageBox.Show(dt.Rows[i].ItemArray[1].ToString());
                    if (checkBox1.Text == dt.Rows[i].ItemArray[1].ToString())
                    {
                        kodedivisi.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    }
                }
            }
            if (checkBox2.Checked == true)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (checkBox2.Text == dt.Rows[i].ItemArray[1].ToString())
                    {
                        kodedivisi.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    }
                }
            }
            if (checkBox3.Checked == true)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (checkBox3.Text == dt.Rows[i].ItemArray[1].ToString())
                    {
                        kodedivisi.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    }
                }
            }
            if (checkBox4.Checked == true)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (checkBox4.Text == dt.Rows[i].ItemArray[1].ToString())
                    {
                        kodedivisi.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString()));
                    }
                }
            }
            for (int i = 0; i < kodedivisi.Count; i++)
            {
                int urutan;
                OracleDataAdapter da = new OracleDataAdapter("select max(kode_message) from message", conn);
                DataTable dtable = new DataTable();
                da.Fill(dtable);
                if (dtable.Rows[0].ItemArray[0].ToString() == "")
                {
                    urutan = 1;
                }else
                {
                    urutan = Convert.ToInt32(dtable.Rows[0].ItemArray[0].ToString()) + 1;
                }
                OracleCommand cmd = new OracleCommand("insert into message values(:a, :b, :c, CURRENT_TIMESTAMP, :e, :f)", conn);
                cmd.Parameters.Add(":a", urutan);
                cmd.Parameters.Add(":b", divisi);
                cmd.Parameters.Add(":c", kodedivisi[i]);
                //cmd.Parameters.Add(":d", DateTime.Now.ToString("HH:mm:ss"));
                cmd.Parameters.Add(":e", textBox1.Text);
                cmd.Parameters.Add(":f", richTextBox1.Text);
                cmd.ExecuteNonQuery();
                this.Close();
            }
        }
    }
}
