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
    public partial class SB : Form
    {
        public SB()
        {
            InitializeComponent();
            sB_11.Show();
            sB_21.Hide();
            sB_31.Hide();
            sB_11.button1.Click += new EventHandler(sB_11_ButtonClick);
        }

        private void sB_11_ButtonClick(object sender, EventArgs e)
        {
            sB_11.Hide();
            sB_21.Show();
            sB_31.Hide();
        }
    }
}
