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
    public partial class frmTableAdd : Form
    {
        public frmTableAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        private void btnSave_Click_1(object sender, EventArgs e)
        {

            string qry = " ";

            if (id == 0) // Insert
            {
                qry = "INSERT INTO tables (tName, tchair, tstatus) VALUES (@Name, @Chair, @Status)";
            }
            else // Update
            {
                qry = "UPDATE tables SET tName = @Name, tchair = @Chair, tstatus = @Status WHERE tID = @id";
            }

            // Thêm các tham số vào Hashtable
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@Chair", txtChair.Text);
            ht.Add("@Status", cbstatus.Text);

            // Tiến hành thực hiện câu truy vấn SQL
            if (MainClass.SQL(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Lưu thành công!");
                id = 0;
                txtName.Focus();
                txtChair.Focus();
                cbstatus.SelectedIndex = -1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
