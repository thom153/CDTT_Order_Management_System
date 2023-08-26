using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order_Management_System.Reports
{
    public partial class frmSalebyWaiter : Form
    {
        public frmSalebyWaiter()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //string qry = @"select distinct * from tblMain m
            //            where m.aDate between @sdate and @edate";
            string qry = @"select distinct * from tblMain m
                        where m.aDate between @sdate and @edate";

            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            cmd.Parameters.AddWithValue("@sdate", Convert.ToDateTime(dateTimePicker1.Value).Date);
            cmd.Parameters.AddWithValue("@edate", Convert.ToDateTime(dateTimePicker2.Value).Date);
            MainClass.con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            MainClass.con.Close();
            frmPrint frm = new frmPrint();
            rptSalebyWaiter cr = new rptSalebyWaiter();
            cr.SetDataSource(dt); // Đặt nguồn dữ liệu cho báo cáo
            frm.crystalReportViewer1.ReportSource = cr; // Gắn báo cáo với CrystalReportViewer
            frm.crystalReportViewer1.Refresh();
            frm.Show();
        }
    }
   
}
