using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order_Management_System.Model
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }

        public int MainID = 0;

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            guna2DataGridView2.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();

            ItemPanel.Controls.Clear(); 
            LoadItems();
        }

        private void AddCategory()
        {
            string qry = "Select * from Category";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CategoryPanel.Controls.Clear();
            Guna.UI2.WinForms.Guna2Button b2 = new Guna.UI2.WinForms.Guna2Button();
            b2.FillColor = Color.FromArgb(128, 128, 255);
            b2.Size = new Size(166, 57);
            b2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            b2.Text = "Tất cả";
            b2.CheckedState.FillColor = Color.FromArgb(255, 128, 128);
            b2.Click += new EventHandler(b_Click);
            CategoryPanel.Controls.Add(b2);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(128, 128, 255);
                    b.Size = new Size(166, 57);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["catName"].ToString();
                    b.CheckedState.FillColor = Color.FromArgb(255, 128, 128);

                    //event for click
                    b.Click += new EventHandler(b_Click);

                    CategoryPanel.Controls.Add(b);
                }

            }
        }


        private void b_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            if (b.Text == "Tất cả")
            {
                txtSearch.Text = "1";
                txtSearch.Text = "";
                return;

            }    
            foreach(var item in ItemPanel.Controls)
            {
                var pro = (ucItem)item;
                pro.Visible = pro.iCategory.ToLower().Contains(b.Text.Trim().ToLower());
            }    
        }
        private void AddItems(string id, string name, string cat, string price, Image iImage)
        {
            var w = new ucItem()
            {
                iName = name,
                iPrice = price,
                iCategory = cat,
                iImage = iImage,
                id = Convert.ToInt32(id)
            };

            ItemPanel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucItem)ss;

                DataGridViewRow existingRow = null;
                foreach (DataGridViewRow item in guna2DataGridView2.Rows)
                {
                    if (Convert.ToInt32(item.Cells["dgvid"].Value) == wdg.id)
                    {
                        existingRow = item;
                        break;
                    }
                }
                //thêm một biến existingRow để lưu trữ hàng tương ứng trong guna2DataGridView2 nếu mặt hàng đã được chọn tồn tại
                //trong danh sách. Nếu mặt hàng đã tồn tại, cập nhật số lượng và giá trị "Amount" của hàng đó.
                //Nếu mặt hàng chưa tồn tại, thêm mới hàng vào guna2DataGridView2.
                if (existingRow != null)
                {
                    existingRow.Cells["dgvQty"].Value = int.Parse(existingRow.Cells["dgvQty"].Value.ToString()) + 1;
                    existingRow.Cells["dgvAmount"].Value = int.Parse(existingRow.Cells["dgvQty"].Value.ToString()) *
                                                               double.Parse(existingRow.Cells["dgvPrice"].Value.ToString());
                }
                else
                {
                    guna2DataGridView2.Rows.Add(new object[] { 0, wdg.id, wdg.iName, 1, wdg.iPrice, wdg.iPrice });
                }

                GetTotal();
            };
        }

        //Getting item from database 
        private void LoadItems()
        {
            string qry = "Select * from Items inner join Category on catID = categoryID ";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                Byte[] imagearray = (byte[])item["iImage"];
                byte[] immagebytearray = imagearray;

                //Add 2 following lines to appear "000" in Price
                // Convert iPrice to a double value
                double iPrice = double.Parse(item["iPrice"].ToString());

                // Format the price with 3 zeros after the integer part
                string formattedPrice = (iPrice * 1000).ToString("N0");

                AddItems(item["itemID"].ToString(), item["iName"].ToString(), item["catName"].ToString(),
                    formattedPrice, Image.FromStream(new MemoryStream(imagearray)));
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach(var item in ItemPanel.Controls)
            {
                var pro = (ucItem)item;
                pro.Visible = pro.iName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }    
        }

        private void guna2DataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for searil no
            int count = 0;
            foreach (DataGridViewRow row in guna2DataGridView2.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void GetTotal()
        {
            double tot = 0;
            lblTotal.Text = "";
            foreach (DataGridViewRow item in guna2DataGridView2.Rows)
            {
                tot += double.Parse(item.Cells["dgvAmount"].Value.ToString());
            }
            lblTotal.Text = tot.ToString("N2");
        }

        private void guna2TileButton16_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            guna2DataGridView2.Rows.Clear();
            MainID = 0;
            lblTotal.Text = "0.00";
        }

        private void btnDinein_Click(object sender, EventArgs e)
        {
            //need to create form table selection and waiter selection
            frmTableSelect frm = new frmTableSelect();
            MainClass.BlurBackground(frm);
            if (frm.TableName != "")
            {
                lblTable1.Text = frm.TableName.Split('\n')[0];
                lblTable1.Visible = true;
            }
            else
            {
                lblTable1.Text = "";
                lblTable1.Visible = false;
            }

            frmWaiterSelect frm2 = new frmWaiterSelect();
            MainClass.BlurBackground(frm2);
            if (frm2.WaiterName != "")
            {
                lblWaiter.Text = frm2.WaiterName;
                lblWaiter.Visible = true;
            }
            else
            {
                lblWaiter.Text = "";
                lblWaiter.Visible = false;
            }
        }
    }
}
