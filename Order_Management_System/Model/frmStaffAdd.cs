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

namespace Order_Management_System.Model
{
    public partial class frmStaffAdd : Form
    {
        public frmStaffAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void btnSave_Click(object sender, EventArgs e)
        {
            string qry = " ";

            if (id == 0)//insert
            {
                qry = "Insert into staff Values(@Name, @Gender, @Phone, @Address, @Role)";

            }
            else //update
            {
                qry = "Update staff set sName = @Name, sGender= @Gender, sPhone = @Phone, sAddress = @Address, sRole = @Role " +
                    " where staffID = @id ";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@Gender", cbGender.Text);
            ht.Add("@Phone", txtPhone.Text);
            ht.Add("@Address", txtAddress.Text);
            ht.Add("@Role", cbRole.Text);

            if (MainClass.SQL(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Lưu thành công!");
                id = 0;
                txtName.Focus();
                cbGender.SelectedIndex = -1;
                txtPhone.Focus();
                txtAddress.Focus();
                cbRole.SelectedIndex = -1;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
