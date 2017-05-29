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
    public partial class Inbox : Form
    {
        public OracleConnection conn;
        public int divisi;

        public Inbox()
        {
            InitializeComponent();
        }

        private void Inbox_Load(object sender, EventArgs e)
        {

        }

        public void isilist()
        {
            OracleDataAdapter adap = new OracleDataAdapter("select * from message where kirim_kode_divisi = :a or terima_kode_divisi = :a", conn);

        }
    }
}
