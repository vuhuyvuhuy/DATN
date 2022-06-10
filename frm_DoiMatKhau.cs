using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DataAccess;
using BusinessLogic;
namespace QL_GiuXe
{
    public partial class frm_DoiMatKhau : DevComponents.DotNetBar.Office2007Form
    {
        public frm_DoiMatKhau()
        {
            InitializeComponent();
        }
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string pass;

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        ConnectDB con = new ConnectDB();
        private void cmddn_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == pass)
            {
                if (txtpass.Text == txtmk2.Text)
                {
                    try
                    {
                        DataAccess.NHANVIEN dll = new NHANVIEN();
                        BusinessLogic.Entities.NHANVIEN ck = new BusinessLogic.Entities.NHANVIEN();
                        ck.manv = id;
                        ck.matkhau = txtmk2.Text;
                        dll.DoiMK(ck);
                        MessageBox.Show("Đổi Mật Khẩu Thành Công");
                        this.Hide();
                    }
                    catch
                    { }
                }
            }
            else
            {
                MessageBox.Show("Mật Khẩu Cũ Không Đúng");

            }
        }

        private void cmdthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void F_doimk_Load(object sender, EventArgs e)
        {

        }
    }
}
