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
    public partial class frm_NhomNguoiDung : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frm_NhomNguoiDung()
        {
            InitializeComponent();
        }
        int dong;
        bool themmoi;
        DataAccess.NHOMNGUOIDUNG dll = new NHOMNGUOIDUNG();
        BusinessLogic.Entities.NHOMNGUOIDUNG ck = new BusinessLogic.Entities.NHOMNGUOIDUNG();
        ConnectDB cn = new ConnectDB();
        public void setnull()
        {
            txtma.Text = "";
            txtten.Text = "";
        }
        public void Locktext()
        {
            txtten.Enabled = false;
            txtma.Enabled = false;
            cmdthem.Enabled = true;
            cmdluu.Enabled = false;
            cmdsua.Enabled = true;
            cmdxoa.Enabled = true;
        }
        public void Un_locktex()
        {
            txtten.Enabled = true;

            cmdthem.Enabled = false;
            cmdluu.Enabled = true;
            cmdsua.Enabled = false;
            cmdxoa.Enabled = false;
        }
        public void hienthi()
        {

            msds1.DataSource = dll.data();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void msds1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Locktext();
                dong = e.RowIndex;
                txtma.Text = msds1.Rows[dong].Cells["manhom"].Value.ToString();
                txtten.Text = msds1.Rows[dong].Cells["tennhom"].Value.ToString();
            }
            catch
            { }
        }

        private void cmdthem_Click(object sender, EventArgs e)
        {
            setnull();
            Un_locktex();
            themmoi = true;
            cn.taomatudong(txtma, "manhom", "NHOMNGUOIDUNG", "NH");
            txtten.Focus();
        }
        void getValues()
        {
            ck.manhom = txtma.Text;
            ck.tennhom = txtten.Text;
        }
        private void cmdluu_Click(object sender, EventArgs e)
        {
            getValues();
            if (themmoi == true)
            {
                if (string.IsNullOrEmpty(txtma.Text))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin!");
                }
                else
                {

                    if (dll.kiemtra(txtma.Text) == "0")
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
                getValues();
                dll.xoakh(ck);
                hienthi();
                MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Xóa Thất Bại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void frm_NhomNguoiDung_Load(object sender, EventArgs e)
        {
            hienthi();
            Locktext();
        }

    }
}
