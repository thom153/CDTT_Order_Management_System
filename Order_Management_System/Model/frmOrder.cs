
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
                    b.FillColor = Color.FromArgb(28, 128, 255);
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


        private void AddItems(string id,string itemmID, string name, string cat, string price, Image iImage)
        {
            var w = new ucItem()
            {
                iName = name,
                iPrice = price,
                iCategory = cat,
                iImage = iImage,
                id = Convert.ToInt32(itemmID)
            };

            ItemPanel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucItem)ss;

                DataGridViewRow existingRow = null;
                foreach (DataGridViewRow item in guna2DataGridView2.Rows)
                {
                    if (Convert.ToInt32(item.Cells["dgvitemmID"].Value) == wdg.id)
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
                    //add new item first for STT and 2nd 0 ffrom id
                    guna2DataGridView2.Rows.Add(new object[] {0,0, wdg.id, wdg.iName, 1, wdg.iPrice, wdg.iPrice });
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

                AddItems("0",item["itemID"].ToString(), item["iName"].ToString(), item["catName"].ToString(),
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

        private void btnNeww_Click_1(object sender, EventArgs e)
        {
            lblTable1.Text = "";
            lblWaiter.Text = "";
            lblTable1.Visible = false;
            lblWaiter.Visible = false;
            guna2DataGridView2.Rows.Clear();
            MainID = 0;
            lblTotal.Text = "0.00";
        }

        private bool isDineInSelected = false;

        private void btnDinein_Click(object sender, EventArgs e)
        {
            // Cập nhật trạng thái của nút Dine-In
            isDineInSelected = true;
            frmTableSelect frm = new frmTableSelect();
            MainClass.BlurBackground(frm);
            if (frm.TableName != "")
            {
                //lblTable1.Text = frm.TableName.Split('\n')[0];
                lblTable1.Text = frm.TableName;
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

        private void btnKoTT_Click(object sender, EventArgs e)
        {
            if (!isDineInSelected)
            {
                guna2MessageDialog2.Show("Vui lòng chọn bàn và NVPV trước khi gửi bếp.");
                return;
            }

            SaveOrderToDatabase();

            // Reset dữ liệu sau khi gửi
            ResetOrderData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MainID > 0) // Chỉ lưu khi có MainID
            {
                UpdateOrderStatus("Đã lưu");
            }
            else
            {
                guna2MessageDialog1.Show("Chưa có bản ghi nào để lưu!");
            }
        }

        private void UpdateOrderStatus(string newStatus)
        {
            string updateStatusQuery = "UPDATE tblMain SET status = @status WHERE MainID = @ID";

            using (SqlCommand cmd = new SqlCommand(updateStatusQuery, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@ID", MainID);
                cmd.Parameters.AddWithValue("@status", newStatus);

                try
                {
                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    cmd.ExecuteNonQuery();
                    guna2MessageDialog1.Show("Cập nhật trạng thái thành công!");

                    // Kiểm tra trạng thái sau cập nhật
                    string checkStatusQuery = "SELECT status FROM tblMain WHERE MainID = @ID";

                    using (SqlCommand checkCmd = new SqlCommand(checkStatusQuery, MainClass.con))
                    {
                        checkCmd.Parameters.AddWithValue("@ID", MainID);
                        string status = checkCmd.ExecuteScalar().ToString();
                        MessageBox.Show("Trạng thái của MainID " + MainID + ": " + status);
                    }
                }
                catch (Exception ex)
                {
                    guna2MessageDialog1.Show("Lỗi xảy ra: " + ex.Message);
                }
                finally
                {
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                }
            }
        }

        private void SaveOrderToDatabase()
        {
            if (MainID == 0) //Insert
            {
                MainID = InsertMainRecord();
            }
            else //Update
            {
                UpdateMainRecord();
            }

            // Lưu chi tiết đơn hàng
            foreach (DataGridViewRow row in guna2DataGridView2.Rows)
            {
                int itemID = Convert.ToInt32(row.Cells["dgvitemmID"].Value);
                int quantity = Convert.ToInt32(row.Cells["dgvQty"].Value);
                double price = Convert.ToDouble(row.Cells["dgvPrice"].Value);
                double amount = Convert.ToDouble(row.Cells["dgvAmount"].Value);

                if (MainID > 0)
                {
                    int detailID = Convert.ToInt32(row.Cells["dgvid"].Value);
                    if (detailID == 0) // Insert
                    {
                        InsertDetailRecord(MainID, itemID, quantity, price, amount);
                    }
                    else // Update
                    {
                        UpdateDetailRecord(detailID, itemID, quantity, price, amount);
                    }
                }
            }
        }

        private int InsertMainRecord()
        {
            string insertQuery = @"INSERT INTO tblMain (aDate, aTime, TableName, WaiterName, status, total, received, change) 
                                   VALUES (@aDate, @aTime, @TableName, @WaiterName, @status, @total, @received, @change);
                                   SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(insertQuery, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@aDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
                cmd.Parameters.AddWithValue("@TableName", lblTable1.Text);
                cmd.Parameters.AddWithValue("@WaiterName", lblWaiter.Text);
                cmd.Parameters.AddWithValue("@status", "Đang chờ");
                cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text));
                cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
                cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));

                try
                {
                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    guna2MessageDialog1.Show("Lỗi xảy ra khi thêm đơn hàng: " + ex.Message);
                    return 0;
                }
                finally
                {
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                }
            }
        }

        private void UpdateMainRecord()
        {
            string updateQuery = @"UPDATE tblMain SET status = @status, total = @total, received = @received, change = @change 
                                   WHERE MainID = @ID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@ID", MainID);
                cmd.Parameters.AddWithValue("@status", "Đang chờ");
                cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text));
                cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
                cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));

                try
                {
                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    guna2MessageDialog1.Show("Lỗi xảy ra khi cập nhật đơn hàng: " + ex.Message);
                }
                finally
                {
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                }
            }
        }

        private void InsertDetailRecord(int mainID, int itemID, int quantity, double price, double amount)
        {
            string insertQuery = @"INSERT INTO tblDetails (MainID, itemmID, qty, price, amount) 
                                   VALUES (@MainID, @itemmID, @qty, @price, @amount)";

            using (SqlCommand cmd = new SqlCommand(insertQuery, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@MainID", mainID);
                cmd.Parameters.AddWithValue("@itemmID", itemID);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@amount", amount);

                try
                {
                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    guna2MessageDialog1.Show("Lỗi xảy ra khi thêm chi tiết đơn hàng: " + ex.Message);
                }
                finally
                {
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                }
            }
        }

        private void UpdateDetailRecord(int detailID, int itemID, int quantity, double price, double amount)
        {
            string updateQuery = @"UPDATE tblDetails SET itemmID = @itemmID, qty = @qty, price = @price, amount = @amount 
                                   WHERE detailID = @detailID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@detailID", detailID);
                cmd.Parameters.AddWithValue("@itemmID", itemID);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@amount", amount);

                try
                {
                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    guna2MessageDialog1.Show("Lỗi xảy ra khi cập nhật chi tiết order: " + ex.Message);
                }
                finally
                {
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                }
            }
        }

        private void ResetOrderData()
        {
            // Reset dữ liệu trên form sau khi gửi bếp
            lblTable1.Text = "Bàn số: ";
            lblWaiter.Text = "Nhân viên: ";
            lblTotal.Text = "0.00";
            isDineInSelected = false;
            guna2DataGridView2.Rows.Clear();
        }

    }
} 









