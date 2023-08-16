//using Order_Management_System.Model;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Order_Management_System.View
//{
//    public partial class frmItemView : Form
//    {
//        public frmItemView()
//        {
//            InitializeComponent();
//        }

//        public void GetData()
//        {
//            string qry = "select itemID, iName, iPrice, iUnitCost, categoryID, c.catName, IsActive from Items i " +
//                "inner join category c on c.catID = i.categoryID where iName like '%" + txtSearch.Text + "%' ";
//            ListBox lb = new ListBox();
//            lb.Items.Add(dgvid);
//            lb.Items.Add(dgvName);
//            lb.Items.Add(dgvPrice);
//            lb.Items.Add(dgvUnitCost);
//            lb.Items.Add(dgvcatID);
//            lb.Items.Add(dgvcat);
//            lb.Items.Add(dgvIsActive);

//            MainClass.LoadData(qry, guna2DataGridView1, lb);

//            // Lặp qua từng dòng và thiết lập trạng thái checkbox
//            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
//            {
//                bool isActive = Convert.ToBoolean(row.Cells["dgvIsActive"].Value);
//                DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)row.Cells["dgvIsActive"];
//                chkCell.Value = isActive;
//            }
//        }

//        private bool isActive = true;
//        private void frmItemView_Load(object sender, EventArgs e)
//        {
//            GetData();
//        }

//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            MainClass.BlurBackground(new frmItemAdd());
//            GetData();
//        }

//        private void txtSearch_TextChanged(object sender, EventArgs e)
//        {
//            GetData();
//        }

//        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
//            {
//                frmItemAdd frm = new frmItemAdd();
//                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
//                frm.cID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvcatID"].Value);
//                //frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
//                //frm.txtPrice.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPrice"].Value);
//                //frm.txtUnitCost.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvUnitCost"].Value);
//                //frm.cbCat.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvcat"].Value);

//                MainClass.BlurBackground(frm);
//                GetData();

//            }
//            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvDel")
//            {
//                //need to confirm before delete
//                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
//                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

//                if (guna2MessageDialog1.Show("Bạn có chắc chắn muốn xóa không?") == DialogResult.Yes)
//                {
//                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
//                    string qry = "Delete from items where itemID = " + id + "";
//                    Hashtable ht = new Hashtable();
//                    MainClass.SQL(qry, ht);

//                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
//                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

//                    guna2MessageDialog1.Show("Đã xóa thành công!");
//                    GetData();
//                }
//            }
//        }

//        private void guna2DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
//        {
//            // Xác định dòng và cột của ô được thay đổi
//            if (e.RowIndex >= 0 && e.ColumnIndex == dgvIsActive.Index)
//            {
//                DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvIsActive"];
//                bool newIsActiveValue = (bool)chkCell.Value;

//                // Lấy giá trị itemID từ cột khác
//                int itemID = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);

//                // Thực hiện cập nhật vào cơ sở dữ liệu dựa trên itemID và newIsActiveValue
//                // ... (Viết mã SQL hoặc gọi hàm để cập nhật dữ liệu)
//            }
//        }
//    }
//}




using Order_Management_System.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order_Management_System.View
{
    public partial class frmItemView : Form
    {
        public frmItemView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "select itemID, iName, iPrice, iUnitCost, categoryID, c.catName, IsActive from Items i " +
                         "inner join category c on c.catID = i.categoryID where iName like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPrice);
            lb.Items.Add(dgvUnitCost);
            lb.Items.Add(dgvcatID);
            lb.Items.Add(dgvcat);
            lb.Items.Add(dgvIsActive);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
          
            // Lặp qua từng dòng và thiết lập trạng thái checkbox
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                bool isActive = Convert.ToBoolean(row.Cells["dgvIsActive"].Value);
                DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)row.Cells["dgvIsActive"];
                chkCell.Value = isActive;
            }
        }

        private void frmItemView_Load(object sender, EventArgs e)
        {
            GetData();
            guna2DataGridView1.Columns["dgvIsActive"].DisplayIndex = guna2DataGridView1.Columns["dgvedit"].DisplayIndex;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmItemAdd());
            GetData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
                {
                    frmItemAdd frm = new frmItemAdd();
                    frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    frm.cID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvcatID"].Value);
                    frm.isActive= Convert.ToBoolean(guna2DataGridView1.CurrentRow.Cells["dgvIsActive"].Value);

                    MainClass.BlurBackground(frm);
                    GetData();
                }
                else if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvDel")
                {
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                    if (guna2MessageDialog1.Show("Bạn có chắc chắn muốn xóa không?") == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                        string qry = "Delete from items where itemID = " + id + "";
                        Hashtable ht = new Hashtable();
                        MainClass.SQL(qry, ht);

                        guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                        guna2MessageDialog1.Show("Đã xóa thành công!");
                        GetData();
                    }
                }
            }
        }

        private void guna2DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvIsActive.Index)
            {
                DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)guna2DataGridView1.Rows[e.RowIndex].Cells["dgvIsActive"];
                bool newIsActiveValue = (bool)chkCell.Value;

                int itemID = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["dgvid"].Value);

                string qry = "UPDATE Items SET IsActive = @IsActive WHERE itemID = @itemID";
                Hashtable ht = new Hashtable();
                ht.Add("@IsActive", newIsActiveValue);
                ht.Add("@itemID", itemID);

                MainClass.SQL(qry, ht);
            }
        }
    }
}

