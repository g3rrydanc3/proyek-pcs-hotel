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
        

        public Receptionist_IsiKamar()
        {
            InitializeComponent();
        }

        private void Receptionist_IsiKamar_Load(object sender, EventArgs e)
        {
            /*OracleCommand cmd = new OracleCommand("SELECT nama_cust FROM customer", conn);
            OracleDataReader reader = cmd.ExecuteReader();
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            while (reader.Read())
            {
                MyCollection.Add(reader.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = MyCollection;*/
            
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
            try
            {
                OracleDataAdapter adap = new OracleDataAdapter("select nama_cust from customer", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
