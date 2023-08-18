using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order_Management_System.Reports
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void btnSalebymonth_Click(object sender, EventArgs e)
        {
            frmSalebymonth frm = new frmSalebymonth();
            frm.ShowDialog();
        }
    }
}
