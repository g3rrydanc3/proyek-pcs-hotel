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
    public partial class Dapur : Form
    {
        public Dapur()
        {
            InitializeComponent();
        }

        private void soldOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new Dapur_SoldOut().ShowDialog() == DialogResult.OK)
            {
                //refresh
            }
        }
    }
}
