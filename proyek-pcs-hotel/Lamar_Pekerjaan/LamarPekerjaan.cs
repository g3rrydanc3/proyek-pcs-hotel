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
    public partial class LamarPekerjaan : Form
    {
        public LamarPekerjaan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabPage1.Hide();
            tabPage2.Show();
            tabControl1.SelectedIndex = (tabControl1.SelectedIndex + 1 < tabControl1.TabCount) ?
                             tabControl1.SelectedIndex + 1 : tabControl1.SelectedIndex;
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

        private void button3_Click(object sender, EventArgs e)
        {
            tabPage2.Hide();
            tabPage1.Show();
            tabControl1.SelectedIndex = (tabControl1.SelectedIndex - 1 < tabControl1.TabCount) ?
                             tabControl1.SelectedIndex - 1 : tabControl1.SelectedIndex;
        }
    }
}
