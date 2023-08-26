using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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

            amt = ParseCurrencyVN(txtBillAmount.Text);
            //receipt = ParseCurrencyVN(txtReceived.Text);
            double.TryParse(txtReceived.Text, out receipt);

            change = Math.Abs(amt - receipt); //convert positive or negative to always positive
            txtChange.Text = formatCurrencyVN((decimal)change);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string qry = @"Update tblMain set received = @rec, change = @change, status = N'Đã thanh toán'
                           where MainID = @id";
            Hashtable ht = new Hashtable();
            ht.Add("@id", MainID);
            ht.Add("@rec", txtReceived.Text);
            ht.Add("@change", txtChange.Text);

            if(MainClass.SQL(qry,ht)>0)
            {
                UpdateTableStatusForPayment(MainID);
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Lưu thành công!");
                this.Close();
            }    
        }

        private void UpdateTableStatusForPayment(int mainID)
        {
            string query = "SELECT tableName FROM tblMain WHERE MainID = @id";

            using (SqlCommand cmd = new SqlCommand(query, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@id", mainID);

                try
                {
                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string tableName = result.ToString();
                        // Gọi hàm cập nhật trạng thái của bàn ở đây
                        UpdateTableStatus(tableName, "Trống");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra khi cập nhật trạng thái bàn: " + ex.Message);
                }
                finally
                {
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                }
            }
        }

        private void UpdateTableStatus(string tableName, string status)
        {
            string updateQuery = "UPDATE tables SET tStatus = @status WHERE tName = @tableName";

            using (SqlCommand cmd = new SqlCommand(updateQuery, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@tableName", tableName);

                try
                {
                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra khi cập nhật trạng thái bàn: " + ex.Message);
                }
                finally
                {
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                }
            }
        }


        private void frmPayment_Load(object sender, EventArgs e)
        {
            txtBillAmount.Text = formatCurrencyVN(((decimal)amt));
    

        }
        private string formatCurrencyVN(decimal value)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            string result = value.ToString("c", culture);
            return result;
        }
        public double ParseCurrencyVN(string formattedCurrency)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            double value = double.Parse(formattedCurrency, NumberStyles.Currency, culture);
            return value;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
