

using Order_Management_System.Model;
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
    public partial class frmItemAdd : Form
    {
        public frmItemAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int cID = 0;
        public bool isActive = true;

        private void frmItemAdd_Load(object sender, EventArgs e)
        {
            //For cb fill
            string qry = "Select catID 'id', catName 'name' from category ";
            MainClass.CBFill(qry, cbCat);

            if (cID > 0)//For update
            {
                cbCat.SelectedValue = cID;
            }

            if (id > 0)
            {
                ForUpdateLoadData();
            }

            // Set checkbox value
            chkIsActive.Checked = isActive;
        }

        string filePath;
        Byte[] imageByteArray;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|* .png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtImage.Image = new Bitmap(filePath);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string qry = " ";

            if (id == 0)//insert
            {
                qry = "Insert into Items Values(@Name, @Price, @UnitCost, @Cat, @Image, @IsActive) ";
            }
            else //update
            {
                qry = "Update Items set iName = @Name, iPrice = @Price, iUnitCost = @UnitCost, categoryID = @Cat, iImage = @Image, IsActive = @IsActive" +
                      " where itemID = @id ";
            }

            //For image 
            Image temp = new Bitmap(txtImage.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@Price", txtPrice.Text);
            ht.Add("@UnitCost", txtUnitCost.Text);
            ht.Add("@Cat", Convert.ToInt32(cbCat.SelectedValue));
            ht.Add("@Image", imageByteArray);
            ht.Add("@IsActive", chkIsActive.Checked); // Get value from checkbox

            if (MainClass.SQL(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Lưu thành công!");
                id = 0;
                cID = 0;
                txtName.Text = "";
                txtPrice.Text = "";
                txtUnitCost.Text = "";
                cbCat.SelectedIndex = 0;
                cbCat.SelectedIndex = -1;
                txtImage.Image = Order_Management_System.Properties.Resources.icons8_meal_100;
                chkIsActive.Checked = true; // Reset checkbox
                txtName.Focus();
            }
        }

        private void ForUpdateLoadData()
        {
            string qry = @"Select * from items where itemID = " + id + "";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["iName"].ToString();
                txtPrice.Text = dt.Rows[0]["iPrice"].ToString();
                txtUnitCost.Text = dt.Rows[0]["iUnitCost"].ToString();

                Byte[] imageArray = (byte[])(dt.Rows[0]["iImage"]);
                byte[] imageByteArray = imageArray;
                txtImage.Image = Image.FromStream(new MemoryStream(imageArray));

                chkIsActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
