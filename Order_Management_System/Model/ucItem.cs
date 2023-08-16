//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Order_Management_System.Model
//{
//    public partial class ucItem : UserControl
//    {
//        public ucItem()
//        {
//            InitializeComponent();
//        }
//        public event EventHandler onSelect = null;
//        public int id { get; set; }
//        public string iPrice { get; set; }
//        public string iCategory { get; set; }
//        public string iName
//        {
//            get { return lblName.Text; }
//            set { lblName.Text = value; }
//        }
//        public Image iImage
//        {
//            get { return txtImage.Image; }
//            set { txtImage.Image = value; }
//        }

//        private void txtImage_Click(object sender, EventArgs e)
//        {
//            onSelect?.Invoke(this, e);
//        }
//    }
//}


using System;
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
    public partial class ucItem : UserControl
    {
        private bool isActive = true; // Thêm biến để theo dõi trạng thái IsActive

        public ucItem()
        {
            InitializeComponent();
        }

        public event EventHandler onSelect = null;
        public int id { get; set; }
        public string iPrice { get; set; }
        public string iCategory { get; set; }
        public string iName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
        public Image iImage
        {
            get { return txtImage.Image; }
            set { txtImage.Image = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                if (isActive)
                {
                    this.BackColor = Color.White; // Nếu IsActive = true, đổi màu nền về trắng
                }
                else
                {
                    this.BackColor = Color.Gray; // Nếu IsActive = false, đổi màu nền về xám
                }
            }
        }

        private void txtImage_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}
