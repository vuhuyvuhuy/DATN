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
    public partial class frm_NhanVien : Office2007RibbonForm
    {
        public frm_NhanVien()
        {
            InitializeComponent();
        }
        DataAccess.NHANVIEN dll = new NHANVIEN();
        BusinessLogic.Entities.NHANVIEN ck = new BusinessLogic.Entities.NHANVIEN();
        ConnectDB cn = new ConnectDB();
        int dong;
        bool themmoi;
        public string ID { get; set; }

        public void setnull()
        {
            txtma.Text = "";
            txtten.Text = "";
            txtemail.Text = "";
            txtdc.Text = "";
            txtdt.Text = "";
            txtmk.Text = "";
            txtmathenv.Text = "";
            txtngaysinh.Text = "";

        }
        public void Locktext()
        {
            txtten.Enabled = false;
            txtma.Enabled = false;
            txtdc.Enabled = false;
            txtemail.Enabled = false;
            txtdt.Enabled = false;
            txtmk.Enabled = false;
            txtngaysinh.Enabled = false;
            txtmathenv.Enabled = false;
            cmdthem.Enabled = true;
            cmdluu.Enabled = false;
            cmdsua.Enabled = true;
            cmdxoa.Enabled = true;
        }
        public void Un_locktex()
        {
            txtmk.Enabled = true;
            txtten.Enabled = true;
            txtemail.Enabled = true;
            txtdc.Enabled = true;
            txtdt.Enabled = true;
            txtmathenv.Enabled = true;
            txtngaysinh.Enabled = true;
            cmdthem.Enabled = false;
            cmdluu.Enabled = true;
            cmdsua.Enabled = false;
            cmdxoa.Enabled = false;
        }
        public void hienthi()
        {

            msds.DataSource = dll.data(ID);
        }
        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
            hienthi();
            Locktext();
            cn.LoadCombobox(cbquyen, "Select * from NHOMNGUOIDUNG", "tennhom", "manhom");
        }

        private void cmdthem_Click(object sender, EventArgs e)
        {
            setnull();
            Un_locktex();
            themmoi = true;
            cn.taomatudong(txtma, "manv", "NHANVIEN", "NV");
            txtten.Focus();
        }
        void getvalues()
        {
            ck.manv = txtma.Text;
            ck.hoten = txtten.Text;
            ck.gioitinh = cbphai.Text;
            ck.email = txtemail.Text;
            ck.diachi = txtdc.Text;
            ck.sdt = txtdt.Text;
            ck.matkhau = txtmk.Text;
            ck.ngaysinh = txtngaysinh.Text;
            ck.mathenv = txtmathenv.Text;
            ck.manhom = cbquyen.SelectedValue.ToString();
        }

        private void cmdluu_Click(object sender, EventArgs e)
        {
            getvalues();
            if (themmoi == true)
            {
                if (string.IsNullOrEmpty(txtma.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {

                    if (dll.kiemtra(txtma.Text, cbquyen.SelectedValue.ToString()) == "0")
                    {

                        try
                        {
                            dll.themmoikh(ck);
                            hienthi();
                            MessageBox.Show("Lưu Thành Công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Lưu Thất Bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã Này Đã Có", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        txtten.Focus();
                    }
                }
            }
            else
            {
                try
                {
                    dll.suakh(ck);
                    hienthi();
                    MessageBox.Show("Sửa Thành Công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Sửa Thất Bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
            Locktext();
            setnull();
        }

        private void cmdsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            Un_locktex();
            txtma.Enabled = false;
        }

        private void cmdxoa_Click(object sender, EventArgs e)
        {
            try
            {
                getvalues();
                dll.xoakh(ck);
                hienthi();
                MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                setnull();
            }
            catch
            {
                MessageBox.Show("Xóa Thất Bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void msds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Locktext();
            try
            {
                dong = e.RowIndex;
                txtma.Text = msds.Rows[dong].Cells["manv"].Value.ToString();
                txtten.Text = msds.Rows[dong].Cells["hoten"].Value.ToString();
                txtemail.Text = msds.Rows[dong].Cells["email"].Value.ToString();
                cbphai.Text = msds.Rows[dong].Cells["gioitinh"].Value.ToString();
                txtdc.Text = msds.Rows[dong].Cells["diachi"].Value.ToString();
                txtdt.Text = msds.Rows[dong].Cells["sdt"].Value.ToString();
                txtngaysinh.Text = msds.Rows[dong].Cells["ngaysinh"].Value.ToString();
                txtmathenv.Text = msds.Rows[dong].Cells["mathenv"].Value.ToString();
                txtmk.Text = msds.Rows[dong].Cells["matkhau"].Value.ToString();
                cbquyen.Text = msds.Rows[dong].Cells["tennhom"].Value.ToString();
            }
            catch
            { }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
