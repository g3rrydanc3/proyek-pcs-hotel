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
    public partial class Receptionist : Form
    {
        public Receptionist()
        {
            InitializeComponent();
            receptionist_List1.Hide();
            receptionist_Booking1.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            receptionist_Booking1.Show();
            receptionist_List1.Hide();
        }

        private void searchKamarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            receptionist_Booking1.Hide();
            receptionist_List1.Show();
        }
    }
}
