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
            Autocomplete();

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
