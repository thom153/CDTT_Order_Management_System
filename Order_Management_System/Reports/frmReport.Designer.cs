﻿
namespace Order_Management_System.Reports
{
    partial class frmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.label1 = new System.Windows.Forms.Label();
            this.btnVoidOrder = new Guna.UI2.WinForms.Guna2Button();
            this.btnSalebyStaff = new Guna.UI2.WinForms.Guna2Button();
            this.btnSalebymonth = new Guna.UI2.WinForms.Guna2Button();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(59, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "BÁO CÁO";
            // 
            // btnVoidOrder
            // 
            this.btnVoidOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVoidOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVoidOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVoidOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVoidOrder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnVoidOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVoidOrder.ForeColor = System.Drawing.Color.White;
            this.btnVoidOrder.Image = global::Order_Management_System.Properties.Resources.icons8_delete_graph_report_50;
            this.btnVoidOrder.Location = new System.Drawing.Point(67, 289);
            this.btnVoidOrder.Name = "btnVoidOrder";
            this.btnVoidOrder.Size = new System.Drawing.Size(334, 87);
            this.btnVoidOrder.TabIndex = 4;
            this.btnVoidOrder.Text = "Báo cáo hủy order";
            this.btnVoidOrder.Click += new System.EventHandler(this.btnVoidOrder_Click);
            // 
            // btnSalebyStaff
            // 
            this.btnSalebyStaff.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSalebyStaff.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSalebyStaff.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSalebyStaff.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSalebyStaff.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSalebyStaff.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSalebyStaff.ForeColor = System.Drawing.Color.White;
            this.btnSalebyStaff.Image = global::Order_Management_System.Properties.Resources.icons8_staff_64;
            this.btnSalebyStaff.Location = new System.Drawing.Point(67, 196);
            this.btnSalebyStaff.Name = "btnSalebyStaff";
            this.btnSalebyStaff.Size = new System.Drawing.Size(334, 87);
            this.btnSalebyStaff.TabIndex = 1;
            this.btnSalebyStaff.Text = "Báo cáo doanh thu theo nhân viên";
            this.btnSalebyStaff.Click += new System.EventHandler(this.btnSalebyStaff_Click);
            // 
            // btnSalebymonth
            // 
            this.btnSalebymonth.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSalebymonth.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSalebymonth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSalebymonth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSalebymonth.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSalebymonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSalebymonth.ForeColor = System.Drawing.Color.White;
            this.btnSalebymonth.Image = ((System.Drawing.Image)(resources.GetObject("btnSalebymonth.Image")));
            this.btnSalebymonth.Location = new System.Drawing.Point(67, 103);
            this.btnSalebymonth.Name = "btnSalebymonth";
            this.btnSalebymonth.Size = new System.Drawing.Size(334, 87);
            this.btnSalebymonth.TabIndex = 0;
            this.btnSalebymonth.Text = "Báo cáo bán hàng ";
            this.btnSalebymonth.Click += new System.EventHandler(this.btnSalebymonth_Click);
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = "OMS";
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.guna2MessageDialog1.Parent = null;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.guna2MessageDialog1.Text = null;
            // 
            // frmReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVoidOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalebyStaff);
            this.Controls.Add(this.btnSalebymonth);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSalebymonth;
        private Guna.UI2.WinForms.Guna2Button btnSalebyStaff;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnVoidOrder;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}