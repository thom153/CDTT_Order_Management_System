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
    public partial class frmSalybyWaiter : Form
    {
        public frmSalybyWaiter()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    //private void btnReport_Click(object sender, EventArgs e)
    //{
    //    string qry = @"select * from tblMain m
    //                    inner join tblDetails d on m.MainID = d.MainID
    //                    inner join items i on i.itemID = d.itemmID
    //                    where m.aDate between @sdate and @edate";

    //    SqlCommand cmd = new SqlCommand(qry, MainClass.con);
    //    cmd.Parameters.AddWithValue("@sdate", Convert.ToDateTime(dateTimePicker1.Value).Date);
    //    cmd.Parameters.AddWithValue("@edate", Convert.ToDateTime(dateTimePicker2.Value).Date);
    //    MainClass.con.Open();
    //    DataTable dt = new DataTable();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    da.Fill(dt);
    //    MainClass.con.Close();
    //    frmPrint frm = new frmPrint();
    //    rptSalebymonth cr = new rptSalebymonth();
    //    cr.SetDataSource(dt); // Đặt nguồn dữ liệu cho báo cáo
    //    frm.crystalReportViewer1.ReportSource = cr; // Gắn báo cáo với CrystalReportViewer
    //    frm.crystalReportViewer1.Refresh();
    //    frm.Show();
    //}
}
