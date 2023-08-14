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
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }
        public double amt;
        public int MainID = 0;

        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            double amt = 0;
            double receipt = 0;
            double change = 0;

            double.TryParse(txtBillAmount.Text, out amt);
            double.TryParse(txtReceived.Text, out receipt);

            change = Math.Abs(amt - receipt); //convert positive or negative to always positive
            txtChange.Text = change.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string qry = @"Update tblMain set total = @total, received = @rec, change = @change, status = N'Đã thanh toán'
                           where MainID = @id";
            Hashtable ht = new Hashtable();
            ht.Add("@id", MainID);
            ht.Add("@total", txtBillAmount.Text);
            ht.Add("@rec", txtReceived.Text);
            ht.Add("@change", txtChange.Text);

            if(MainClass.SQL(qry,ht)>0)
            {
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Lưu thành công!");
                this.Close();
            }    
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            txtBillAmount.Text = amt.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
