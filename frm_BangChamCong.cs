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
    public partial class frm_BangChamCong : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public frm_BangChamCong()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        DataAccess.ChamCong dll = new ChamCong();
        BusinessLogic.Entities.BANGCHAMCONG ck = new BusinessLogic.Entities.BANGCHAMCONG();
        int dong;
        public void setnull()
        {
            txtTGTruc.Text = "";
            txtTuNgay.Text = DateTime.Now.ToShortDateString();
            txtDenNgay.Text = DateTime.Now.ToShortDateString();
        }
        public void Locktext()
        {
            txtTGTruc.Enabled = false;
            txtTGT2.Enabled = false;
        }
        public void hienthi()
        {
            msds1.DataSource = dll.data();
        }
        private void frm_BangChamCong_Load(object sender, EventArgs e)
        {
            Locktext();
            cn.LoadCombobox(cboNV, "Select * from NHANVIEN", "hoten", "manv");
        }

        private void msds1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Locktext();
                dong = e.RowIndex;

            }
            catch
            { }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
             string tungay= txtTuNgay.Value.ToString("dd/MM/yyyy HH:mm:ss");
            string denngay= txtDenNgay.Value.ToString("dd/MM/yyyy HH:mm:ss");

            Locktext();
            try
            {
                if (txtTuNgay.Text != "" && txtDenNgay.Text != "")
                {
                    string SQL = @"SELECT BANGCHAMCONG.ID, NHANVIEN.manv, BANGCHAMCONG.thoigiandangnhap, BANGCHAMCONG.thoigiandangxuat
                                FROM BANGCHAMCONG INNER JOIN NHANVIEN ON BANGCHAMCONG.manv = NHANVIEN.manv
                                WHERE (Convert(Datetime,BANGCHAMCONG.thoigiandangnhap,103)>=Convert(Datetime,'" + tungay + "',103) and Convert(Datetime,BANGCHAMCONG.thoigiandangnhap,103)<=Convert(Datetime,'" + denngay + "',103)) and  NHANVIEN.manv=N'" + cboNV.SelectedValue.ToString() + "'";

                    msds1.DataSource = cn.taobang(SQL);

                    string SQL1 = @"SELECT SUM(DATEDIFF ( HOUR,thoigiandangnhap,thoigiandangxuat)) FROM BANGCHAMCONG INNER JOIN NHANVIEN ON BANGCHAMCONG.manv = NHANVIEN.manv WHERE (Convert(Datetime,BANGCHAMCONG.thoigiandangnhap,103)>=Convert(Datetime,'" + tungay + "',103) and Convert(Datetime,BANGCHAMCONG.thoigiandangnhap,103)<=Convert(Datetime,'" + denngay + "',103)) and  NHANVIEN.manv=N'" + cboNV.SelectedValue.ToString() + "'";
                    txtTGTruc.Text = cn.LoadLable(SQL1);
                    string SQL2 = @"SELECT (SUM(DATEDIFF ( MINUTE,thoigiandangnhap,thoigiandangxuat))) %60 FROM BANGCHAMCONG INNER JOIN NHANVIEN ON BANGCHAMCONG.manv = NHANVIEN.manv WHERE (Convert(Datetime,BANGCHAMCONG.thoigiandangnhap,103)>=Convert(Datetime,'" + tungay + "',103) and Convert(Datetime,BANGCHAMCONG.thoigiandangnhap,103)<=Convert(Datetime,'" + denngay + "',103)) and  NHANVIEN.manv=N'" + cboNV.SelectedValue.ToString() + "'";
                    txtTGT2.Text = cn.LoadLable(SQL2);
                }
                else
                {
                    if (txtTuNgay.Text != "" || txtDenNgay.Text != "")
                    {
                        if (txtTuNgay.Text != "")
                        {
                            string SQL = @"SELECT BANGCHAMCONG.ID, NHANVIEN.manv, BANGCHAMCONG.thoigiandangnhap, BANGCHAMCONG.thoigiandangxuat
                                    FROM BANGCHAMCONG INNER JOIN NHANVIEN ON BANGCHAMCONG.manv = NHANVIEN.manv
                                    WHERE (Convert(Datetime,BANGCHAMCONG.thoigiandangnhap,103)>=Convert(Datetime,'" + tungay + "',103)) and  NHANVIEN.manv=N'" + cboNV.SelectedValue.ToString() + "'";
                            msds1.DataSource = cn.taobang(SQL);
                            string SQL1 = @"SELECT SUM(DATEDIFF ( HOUR,thoigiandangnhap,thoigiandangxuat)) FROM BANGCHAMCONG INNER JOIN NHANVIEN ON BANGCHAMCONG.manv = NHANVIEN.manv WHERE (Convert(Datetime,BANGCHAMCONG.thoigiandangnhap,103)>=Convert(Datetime,'" + tungay + "',103)) and  NHANVIEN.manv=N'" + cboNV.SelectedValue.ToString() + "'";
                            txtTGTruc.Text = cn.LoadLable(SQL1);
                            string SQL2 = @"SELECT (SUM(DATEDIFF ( MINUTE,thoigiandangnhap,thoigiandangxuat))) %60 FROM BANGCHAMCONG INNER JOIN NHANVIEN ON BANGCHAMCONG.manv = NHANVIEN.manv WHERE (Convert(Datetime,BANGCHAMCONG.thoigiandangnhap,103)>=Convert(Datetime,'" + tungay + "',103)) and  NHANVIEN.manv=N'" + cboNV.SelectedValue.ToString() + "'";
                            txtTGT2.Text = cn.LoadLable(SQL2);
                        }
                        else
                        {
                            string SQL = @"SELECT BANGCHAMCONG.ID, NHANVIEN.manv, BANGCHAMCONG.thoigiandangnhap, BANGCHAMCONG.thoigiandangxuat
                                    FROM BANGCHAMCONG INNER JOIN NHANVIEN ON BANGCHAMCONG.manv = NHANVIEN.manv
                                    WHERE (Convert(Datetime,BANGCHAMCONG.thoigiandangnhap,103)<=Convert(Datetime,'" + denngay + "',103)) and  NHANVIEN.manv=N'" + cboNV.SelectedValue.ToString() + "'";
                            msds1.DataSource = cn.taobang(SQL);
                            string SQL1 = @"SELECT SUM(DATEDIFF ( HOUR,thoigiandangnhap,thoigiandangxuat)) FROM BANGCHAMCONG INNER JOIN NHANVIEN ON BANGCHAMCONG.manv = NHANVIEN.manv WHERE ( Convert(Datetime,BANGCHAMCONG.thoigiandangnhap,103)<=Convert(Datetime,'" + denngay + "',103)) and  NHANVIEN.manv=N'" + cboNV.SelectedValue.ToString() + "'";
                            txtTGTruc.Text = cn.LoadLable(SQL1);
                            string SQL2 = @"SELECT (SUM(DATEDIFF ( MINUTE,thoigiandangnhap,thoigiandangxuat))) %60 FROM BANGCHAMCONG INNER JOIN NHANVIEN ON BANGCHAMCONG.manv = NHANVIEN.manv WHERE (Convert(Datetime,BANGCHAMCONG.thoigiandangnhap,103)<=Convert(Datetime,'" + denngay + "',103)) and  NHANVIEN.manv=N'" + cboNV.SelectedValue.ToString() + "'";
                            txtTGT2.Text = cn.LoadLable(SQL2);
                        }
                    }
                    else
                    {
                        string SQL = @"SELECT BANGCHAMCONG.ID, NHANVIEN.manv, BANGCHAMCONG.thoigiandangnhap, BANGCHAMCONG.thoigiandangxuat
                                    FROM BANGCHAMCONG INNER JOIN NHANVIEN ON BANGCHAMCONG.manv = NHANVIEN.manv
                                    WHERE NHANVIEN.manv=N'" + cboNV.SelectedValue.ToString() + "'";
                        msds1.DataSource = cn.taobang(SQL);
                        string SQL1 = @"SELECT SUM(DATEDIFF ( HOUR,thoigiandangnhap,thoigiandangxuat)) FROM BANGCHAMCONG INNER JOIN NHANVIEN ON BANGCHAMCONG.manv = NHANVIEN.manv WHERE NHANVIEN.manv=N'" + cboNV.SelectedValue.ToString() + "'";
                        txtTGTruc.Text = cn.LoadLable(SQL1);
                        string SQL2 = @"SELECT (SUM(DATEDIFF ( MINUTE,thoigiandangnhap,thoigiandangxuat))) %60 FROM BANGCHAMCONG INNER JOIN NHANVIEN ON BANGCHAMCONG.manv = NHANVIEN.manv WHERE  NHANVIEN.manv=N'" + cboNV.SelectedValue.ToString() + "'";
                        txtTGT2.Text = cn.LoadLable(SQL2);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        
        }

       

        
    }
}
