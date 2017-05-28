using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
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
    public partial class LamarPekerjaan : Form
    {
        public OracleConnection conn;
        
        public LamarPekerjaan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Open File JPG, JPEG, PNG";
            openFileDialog1.Filter = "JPG, JPEG, PNG files|*.JPG|*.JPEG|*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String filename = openFileDialog1.FileName;
                textBox2.Text = filename;
                pictureBox1.ImageLocation = filename;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox8.Text) || String.IsNullOrEmpty(textBox9.Text) || (radioButton1.Checked == false && radioButton2.Checked == false) || (radioButton3.Checked == false && radioButton4.Checked == false))
            {
                MessageBox.Show("Semua Isian harap diisi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //dataGridView1.Rows.Clear();
            }
            else
            {
                var result = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result.ToString() == "Yes")
                {
                    try
                    {
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }
            }
        }
    }
}
