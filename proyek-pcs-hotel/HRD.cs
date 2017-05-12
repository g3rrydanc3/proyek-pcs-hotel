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
    public partial class HRD : Form
    {
        public HRD()
        {
            InitializeComponent();
            hrD_People1.Show();
            hrD_Recruitment1.Hide();
            hrD_Payroll1.Hide();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hrD_People1.Show();
            hrD_Recruitment1.Hide();
            hrD_Payroll1.Hide();
        }

        private void recruitmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hrD_People1.Hide();
            hrD_Recruitment1.Show();
            hrD_Payroll1.Hide();
        }

        private void payrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hrD_People1.Hide();
            hrD_Recruitment1.Hide();
            hrD_Payroll1.Show();
        }
    }
}
