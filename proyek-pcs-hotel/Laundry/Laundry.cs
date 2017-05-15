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
    public partial class Laundry : Form
    {
        public Laundry()
        {
            InitializeComponent();
            laundry_Detail1.Hide();
            laundry_Order1.Show();
        }

        private void newLaundryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            laundry_Detail1.Hide();
            laundry_Order1.Show();
        }

        private void detailLaundryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            laundry_Detail1.Show();
            laundry_Order1.Hide();
        }
    }
}
