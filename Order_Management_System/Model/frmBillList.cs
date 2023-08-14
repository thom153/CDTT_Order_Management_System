using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                //this is change to set form text properties before open
                MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                this.Close();

            }
            
        }
    }
}
