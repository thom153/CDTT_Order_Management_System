

using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Order_Management_System.Model
{
    public partial class frmTableSelect : Form
    {
        public string TableName;

        public frmTableSelect()
        {
            InitializeComponent();
        }

        private string GetTableStatus(string tableName)
        {
            string query = "SELECT tStatus FROM tables WHERE tName = @tableName";

            using (SqlCommand cmd = new SqlCommand(query, MainClass.con))
            {
                cmd.Parameters.AddWithValue("@tableName", tableName);

                try
                {
                    if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra khi lấy trạng thái bàn: " + ex.Message);
                }
                finally
                {
                    if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
                }
            }

            return string.Empty;
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

        private void frmTableSelect_Load(object sender, EventArgs e)
        {
            LoadTableButtons();
        }

        private void LoadTableButtons()
        {
            string qry = "SELECT * FROM tables";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                Guna.UI2.WinForms.Guna2Button b = CreateTableButton(row);
                flowLayoutPanel1.Controls.Add(b);
            }
        }

        private Guna.UI2.WinForms.Guna2Button CreateTableButton(DataRow row)
        {
            Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
            string tableName = row["tname"].ToString();
            string tableStatus = GetTableStatus(tableName);

            b.Text = tableName + "\nSố ghế: " + row["tchair"].ToString();
            b.Width = 150;
            b.Height = 50;
            b.FillColor = Color.FromArgb(255, 128, 128);
            b.HoverState.FillColor = Color.FromArgb(128, 128, 255);

            if (tableStatus != "Trống")
            {
                b.FillColor = Color.Silver;
                b.Enabled = false;
            }
            else
            {
                b.Click += new EventHandler(b_Click);
            }

            return b;
        }

        private void b_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button button = (Guna.UI2.WinForms.Guna2Button)sender;
            string[] buttonText = button.Text.Split('\n');
            string tableName = buttonText[0];

            UpdateTableStatus(tableName, "Đang phục vụ");
            TableName = tableName;
            this.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

