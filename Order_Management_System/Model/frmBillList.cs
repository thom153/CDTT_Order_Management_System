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
using CrystalDecisions.CrystalReports.Engine;

namespace Order_Management_System.Model
{
    public partial class frmBillList : Form
    {
        public frmBillList()
        {
            InitializeComponent();
        }

        private void frmBillList_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public int MainID = 0;

        private void LoadData()
        {
            //string qry = "select MainID, TableName, WaiterName, status, total from tblMain " +
            //    " where status <> 'Đã gửi bếp' ";
            string qry = "select MainID, TableName, WaiterName, status, total from tblMain ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvtable);
            lb.Items.Add(dgvWaiter);
            lb.Items.Add(dgvStatus);
            lb.Items.Add(dgvTotal);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }


        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for searil no
            int count = 0;
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }
        //private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
        //    {
        //        //this is change to set form text properties before open
        //        MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
        //        this.Close();

        //    }
        //    if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvPrint")
        //    {
        //        //Print bill
        //        MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
        //        string qry = @"Select * from tblMain m 
        //                        inner join tblDetails d on d.MainID = m.MainID
        //                        inner join Items i on i.itemID = d.itemmID
        //                        where m.MainID = " + MainID + "";

        //            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
        //             MainClass.con.Open();
        //            DataTable dt = new DataTable();
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(dt);
        //            MainClass.con.Close();

        //            frmPrint frm = new frmPrint();
        //            rptBill cr = new rptBill();
        //            cr.SetDataSource(dt);
        //            frm.crystalReportViewer1.ReportSource = cr;
        //            frm.crystalReportViewer1.Refresh();
        //            frm.Show();
                
        //    }
        //}

    private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
    {
        if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
        {
            //this is change to set form text properties before open
            MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
            this.Close();
        }
        if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvPrint")
        {
            //Print bill
            MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
            string qry = @"Select * from tblMain m 
                        inner join tblDetails d on d.MainID = m.MainID
                        inner join Items i on i.itemID = d.itemmID
                        where m.MainID = " + MainID + "";

            using (SqlConnection con = new SqlConnection(MainClass.con_string))
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                frmPrint frm = new frmPrint();
                ReportDocument cr = new ReportDocument(); // Tạo instance của ReportDocument

                // Load tài liệu báo cáo từ đường dẫn (sửa lại đường dẫn tương ứng)
                cr.Load("C:\\Users\\HI\\OneDrive - National Economics University\\CĐTT\\Order_Management_System\\Order_Management_System\\Reports\\rptBill.rpt");

                // Tìm các bảng liên kết trong tài liệu và gắn dữ liệu vào
                cr.Database.Tables["tblMain"].SetDataSource(dt);
                cr.Database.Tables["tblDetails"].SetDataSource(dt);
                cr.Database.Tables["Items"].SetDataSource(dt);

                frm.crystalReportViewer1.ReportSource = cr; // Gắn báo cáo với CrystalReportViewer
                frm.crystalReportViewer1.Refresh();
                frm.Show();
            }
        }
    }




}
}
