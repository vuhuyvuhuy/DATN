using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using System.Data;

namespace DataAccess
{
    public class NHANVIEN
    {
        ConnectDB cn = new ConnectDB();
        public string kiemtra(string manv, string manhom)
        {
            return cn.LoadLable("Select count(*) from NHANVIEN where manv=N'" + manv + "' and manhom=N'" + manhom + "'");
        }
        public void themmoikh(BusinessLogic.Entities.NHANVIEN kh)
        {
            cn.ExcuteNonQuery("insert into NHANVIEN values(N'" + kh.manv + "',N'" + kh.manhom + "',N'" + kh.matkhau + "',N'" + kh.mathenv + "',N'" + kh.hoten + "',N'" + kh.ngaysinh + "',N'" + kh.gioitinh + "',N'" + kh.diachi + "',N'" + kh.sdt + "',N'" + kh.email + "')");
        }
        public void xoakh(BusinessLogic.Entities.NHANVIEN kh)
        {
            cn.ExcuteNonQuery("delete NHANVIEN where manv=N'" + kh.manv + "'");
        }
        public void suakh(BusinessLogic.Entities.NHANVIEN kh)
        {
            cn.ExcuteNonQuery("update NHANVIEN set matkhau=N'" + kh.matkhau + "',mathenv=N'" + kh.mathenv + "',hoten=N'" + kh.hoten + "',ngaysinh=N'" + kh.ngaysinh + "',gioitinh=N'" + kh.gioitinh + "',diachi=N'" + kh.diachi + "',sdt=N'" + kh.sdt + "',email=N'" + kh.email + "', manhom=N'" + kh.manhom + "' where manv=N'" + kh.manv + "' ");

        }
        public void DoiMK(BusinessLogic.Entities.NHANVIEN kh)
        {
            cn.ExcuteNonQuery("update NHANVIEN set matkhau=N'" + kh.matkhau + "' where manv=N'" + kh.manv + "'");

        }
        public DataTable data(string ID)
        {
            string sql = @"Select NHANVIEN.manv, NHANVIEN.hoten, NHANVIEN.ngaysinh, NHANVIEN.sdt, NHANVIEN.gioitinh, NHANVIEN.diachi, NHANVIEN.mathenv, NHANVIEN.email, NHANVIEN.matkhau, NHOMNGUOIDUNG.tennhom 
from NHANVIEN INNER JOIN NHOMNGUOIDUNG ON NHANVIEN.manhom= NHOMNGUOIDUNG.manhom";
            return cn.taobang(sql);
        }
    }
}
//where  NHANVIEN.manv=N'" + ID + "'