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
    public partial class Receptionist_IsiKamar : Form
    {
        public OracleConnection conn;
        public String tanggal;
        public String tipe;

        public Receptionist_IsiKamar()
        {
            InitializeComponent();
        }

        private void Receptionist_IsiKamar_Load(object sender, EventArgs e)
        {
            //Autocomplete();
            OracleDataAdapter adap = new OracleDataAdapter("select * from kamar where kode_kamar = '" + label4.Text + "'", conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            comboBox1.Text = dt.Rows[0].ItemArray[1].ToString();
            label7.Text = dt.Rows[0].ItemArray[3].ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int harga = Convert.ToInt32(label7.Text) * Convert.ToInt32(numericUpDown1.Value);
            label7.Text = harga.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleDataAdapter da = new OracleDataAdapter("select max(nota_hotel) from hotel_hjual", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int notahotel = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) + 1;
            OracleCommand cmd = new OracleCommand("insert into hotel_hjual values(:a, :b, :c)", conn);
            cmd.Parameters.Add(":a", notahotel);
            cmd.Parameters.Add(":b", textBox1.Text);
            cmd.Parameters.Add(":c", textBox2.Text);
            cmd.ExecuteNonQuery();
            cmd = new OracleCommand("insert into hotel_djual values(:d, :e, :f, :g)", conn);
            if (tipe == "pesan")
            {
                tanggal = DateTime.Now.ToString().Substring(0,10);
            }
            String temp = tanggal.Substring(0, 2);
            String jangka = (Convert.ToInt32(temp) + Convert.ToInt32(numericUpDown1.Value)).ToString().PadLeft(2, '0') + tanggal.Substring(3, 7);
            cmd.Parameters.Add(":d", notahotel);
            cmd.Parameters.Add(":e", label4.Text);
            cmd.Parameters.Add(":f", tanggal);
            cmd.Parameters.Add(":g", jangka);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Booking/Pesan sukses");
            this.Close();
        }

        private void Autocomplete()
        {
            try
            {
                OracleDataAdapter da = new OracleDataAdapter("SELECT distinct nama_cust FROM customer", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    col.Add(dt.Rows[i].ItemArray[0].ToString());

                }
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox1.AutoCompleteCustomSource = col;
                textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }
    }
}
