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
    public partial class frm_The : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frm_The()
        {
            InitializeComponent();
        }
        int dong;
        bool themmoi;
        
        DataAccess.THE dll = new THE();
        BusinessLogic.Entities.THE ck = new BusinessLogic.Entities.THE();
        ConnectDB cn = new ConnectDB();
        public void setnull()
        {
            txtma.Text = "";
            txtngaysd.Value = DateTime.Now;
        }
        public void Locktext()
        {
            txtngaysd.Enabled = false;
            txtma.Enabled = false;
            
            cmdthem.Enabled = true;
            cmdluu.Enabled = false;
            cmdsua.Enabled = true;
            cmdxoa.Enabled = true;
        }
        public void Un_locktex()
        {
            txtngaysd.Enabled = true;

            cmdthem.Enabled = false;
            cmdluu.Enabled = true;
            cmdsua.Enabled = false;
            cmdxoa.Enabled = false;
        }
        public void hienthi()
        {

            msds1.DataSource = dll.data();
        }
        private void frm_The_Load(object sender, EventArgs e)
        {
            hienthi();
            Locktext();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void msds1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Locktext();
                dong = e.RowIndex;
                txtma.Text = msds1.Rows[dong].Cells["sothe"].Value.ToString();
                txtngaysd.Text = msds1.Rows[dong].Cells["ngaybdsd"].Value.ToString();
                cbtinhtrang.Text = msds1.Rows[dong].Cells["Tinhtrang"].Value.ToString();
                txtngaykt.Text = msds1.Rows[dong].Cells["NgayKt"].Value.ToString();
            }
            catch
            { }
        }

        private void cmdthem_Click(object sender, EventArgs e)
        {
            setnull();
            Un_locktex();
            themmoi = true;
            cn.taomatudong(txtma, "sothe", "THE", "ST");
        }
        void getValues()
        {
            ck.sothe = txtma.Text.ToUpper();
            ck.ngaybdsd = txtngaysd.Value;
            ck.NgayKt = txtngaykt.Value;
            ck.Tinhtrang = cbtinhtrang.Text;
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
    }
}
