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
using BusinessLogic.Entities;
namespace QL_GiuXe
{
    public partial class frm_DangNhap : DevComponents.DotNetBar.Office2007Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        public static string MANV { get; set; }
        public static string MatKhau { get; set; }
        public static int PhieunDangnhap { get; set; }
        private void frm_DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void cmddn_Click(object sender, EventArgs e)
        {
            string sql = "Select count(*) from NHANVIEN where manv=N'" + txtten.Text + "'  and matkhau=N'" + txtmk.Text + "'";
            string quyen = "Select manhom from NHANVIEN where  manv=N'" + txtten.Text + "'  and matkhau=N'" + txtmk.Text + "'";

            if ((cn.LoadLable(sql)) == "1")
            {
                MessageBox.Show("Đăng nhập thành công", "Chúc mừng", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                frm_Main fr = new frm_Main();
                fr.quyen = cn.LoadLable(quyen);
                MANV = txtten.Text.Trim();
                MatKhau = txtmk.Text.Trim();
                BANGCHAMCONG ckchamcong = new BANGCHAMCONG();
                ChamCong dllcc = new ChamCong();
                ckchamcong.manv = MANV;
                ckchamcong.thoigiandangnhap = DateTime.Now;
                PhieunDangnhap = dllcc.themmoikh(ckchamcong);
                this.Hide();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại hoặc\nBạn không có quyền truy cập vào hệ thống", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtten.Focus();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtten_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtmk.Focus();
            }
        }

        private void txtmk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cmddn_Click(sender, e);
            }
        }
    }
}
