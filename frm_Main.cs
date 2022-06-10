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
using BusinessLogic.Entities;
using DataAccess;

namespace QL_GiuXe
{
    public partial class frm_Main : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frm_Main()
        {
            InitializeComponent();
        }
        public string quyen { get; set; }
        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
        private bool CheckOpenTabs(string p)
        {
            for (int i = 0; i < tabControl1.Tabs.Count; i++)
            {
                if (tabControl1.Tabs[i].Text == p)
                {
                    tabControl1.SelectedTabIndex = i;
                    return true;
                }
            }
            return false;
        }
        private void buttonItem14_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Nhân viên"))
            {
                TabItem t = tabControl1.CreateTab("Nhân viên");
                frm_NhanVien frm = new frm_NhanVien();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Loại xe"))
            {
                TabItem t = tabControl1.CreateTab("Loại xe");
                frm_LoaiXe frm = new frm_LoaiXe();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Nhóm người dùng"))
            {
                TabItem t = tabControl1.CreateTab("Nhóm người dùng");
                frm_NhomNguoiDung frm = new frm_NhomNguoiDung();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Quản lý thẻ xe"))
            {
                TabItem t = tabControl1.CreateTab("Quản lý thẻ xe");
                frm_The frm = new frm_The();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
        }

        private void ribbonTabItem2_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem37_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Tìm kiếm thẻ xe"))
            {
                TabItem t = tabControl1.CreateTab("Tìm kiếm thẻ xe");
                frm_TimKiemTheoThe frm = new frm_TimKiemTheoThe();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
        }

        private void buttonItem36_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hệ thống quản lý bãi giữ xe chung cư X Version 1.0 \nLiên hệ nhóm SV thực tập thực hiện:\n  1. Nguyễn Ngọc Quý 18119186 SDT: 0702306665 Email: 18119186@student.hcmute.edu.vn\n  2. Nguyễn Vũ Huy 18119152 SDT: 0976243607 Email: 18119186@student.hcmute.edu.vn", "Help", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void buttonItem35_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hệ thống quản lý bãi giữ xe chung cư X Version 1.0 \nLiên hệ nhóm SV thực tập thực hiện:\n  1. Nguyễn Ngọc Quý 18119186 SDT: 0702306665 Email: 18119186@student.hcmute.edu.vn\n  2. Nguyễn Vũ Huy 18119152 SDT: 0976243607 Email: 18119186@student.hcmute.edu.vn", "Giới thiệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void buttonItem32_Click(object sender, EventArgs e)
        {
            frm_DangNhap frm = new frm_DangNhap();
            frm.ShowDialog();
        }

        private void buttonItem33_Click(object sender, EventArgs e)
        {
            ribbonTabItem1.Enabled = false;
            ribbonTabItem3.Enabled = false;
            buttonItem34.Enabled = false;
        }

        private void buttonItem31_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ribbonTabItem1_Click(object sender, EventArgs e)
        {

        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            BANGCHAMCONG ckchamcong = new BANGCHAMCONG();
            ChamCong dllcc = new ChamCong();
            ckchamcong.ID = frm_DangNhap.PhieunDangnhap;
            ckchamcong.thoigiandangxuat = DateTime.Now;
            dllcc.suakh(ckchamcong);
            Application.Exit();
        }

  
        private void buttonItem34_Click(object sender, EventArgs e)
        {
            frm_DoiMatKhau frm = new frm_DoiMatKhau();
            frm.Id = frm_DangNhap.MANV;
            frm.Pass = frm_DangNhap.MatKhau;
            frm.ShowDialog();
        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Tìm kiếm thông tin"))
            {
                TabItem t = tabControl1.CreateTab("Tìm kiếm thông tin");
                frm_TimKiemThongTinGuiXe frm = new frm_TimKiemThongTinGuiXe();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Thống kê thẻ xe"))
            {
                TabItem t = tabControl1.CreateTab("Thống kê thẻ xe");
                frm_ThongKeThe frm = new frm_ThongKeThe();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Thống kê chấm công"))
            {
                TabItem t = tabControl1.CreateTab("Thống kê chấm công");
                frm_ThongKeChamCong frm = new frm_ThongKeChamCong();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;

        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Thống kê xe ra vào"))
            {
                TabItem t = tabControl1.CreateTab("Thống kê xe ra vào");
                frm_ThongKeXeRaVao frm = new frm_ThongKeXeRaVao();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;

        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Xe vào"))
            {
                TabItem t = tabControl1.CreateTab("Xe vào");
                frm_XeVao frm = new frm_XeVao();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
       
        }

        private void tabControl1_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            try
            {
                //if (!CheckOpenTabs("Xe vào"))
                {
                    if (frm_XeVao.videoSourcetruoc.IsRunning)
                    {
                        frm_XeVao.videoSourcetruoc.Stop();
                    }
                    if (frm_XeVao.videoSourcesau.IsRunning)
                    {
                        frm_XeVao.videoSourcesau.Stop();
                    }
                    if (frm_XeRa.videoSourcetruoc.IsRunning)
                    {
                        frm_XeRa.videoSourcetruoc.Stop();
                    }
                    if (frm_XeRa.videoSourcesau.IsRunning)
                    {
                        frm_XeRa.videoSourcesau.Stop();
                    }
                   
                }
            }
            catch
            { }
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Xe ra"))
            {
                TabItem t = tabControl1.CreateTab("Xe ra");
                frm_XeRa frm = new frm_XeRa();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
       
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Doanh thu"))
            {
                TabItem t = tabControl1.CreateTab("Doanh thu");
                frm_ThongKeDoanhThu frm = new frm_ThongKeDoanhThu();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Bảng chấm công"))
            {
                TabItem t = tabControl1.CreateTab("Bảng chấm công");
                frm_BangChamCong frm = new frm_BangChamCong();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            frm_CaiDatCamera frm = new frm_CaiDatCamera();
            frm.ShowDialog();
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("Tìm kiếm theo thẻ xe"))
            {
                TabItem t = tabControl1.CreateTab("Tìm kiếm theo thẻ xe");
                frm_TimKiemTheoThe frm = new frm_TimKiemTheoThe();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
        }

        private void ribbonTabItem6_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
            if (!CheckOpenTabs("In thẻ xe mới"))
            {
                TabItem t = tabControl1.CreateTab("In thẻ xe mới");
                frm_InTheXe frm = new frm_InTheXe();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();
                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
            else
                tabControl1.TabIndex = tabControl1.Tabs.Count - 1;
        }

        private void ribbonBar5_ItemClick(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
