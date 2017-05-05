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
    public partial class Self_Booking : Form
    {
        public Self_Booking()
        {
            InitializeComponent();
        }

        private void Self_Booking_Load(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
            //textBox1.GotFocus += new EventHandler(this.TextGotFocus);
            //textBox1.LostFocus += new EventHandler(this.TextLostFocus);
        }

        public void TextGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "aaa")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        public void TextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "aaa";
                tb.ForeColor = Color.LightGray;
            }
        }
    }
}
