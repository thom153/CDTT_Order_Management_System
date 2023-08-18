using Order_Management_System.Model;
using Order_Management_System.Reports;
using Order_Management_System.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order_Management_System
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }
        //for accessing frm Main
        static frmMain _obj;
        public static frmMain Instance
        {
            get
            {
                if (_obj == null )
                {
                    _obj = new frmMain();
                }
                return _obj;
            }
        }


        //Method to add Controls in Main Form

        public void AddControls(Form f)
        {
            ControlsPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            ControlsPanel.Controls.Add(f);
            f.Show();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
            _obj = this;
        }

        private void btnCategory_Click_1(object sender, EventArgs e)
        {
            AddControls(new frmCategoryView1());
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            AddControls(new frmTableView1());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            AddControls(new frmStaffView());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new frmItemView());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //AddControls(new frmOrder());
            frmOrder frm = new frmOrder();
            frm.Show();
        }

        private void btnKitchen_Click(object sender, EventArgs e)
        {
            AddControls(new frmKitchenView());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            AddControls(new frmReport());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            string message = "Chức năng này sẽ được hoàn thiện trong thời gian tới";
            string caption = "OMS";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            MessageBox.Show(message, caption, buttons, icon);
        }
    }
}
