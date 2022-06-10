using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccess
{
   public class ChamCong
   {
       ConnectDB cn = new ConnectDB();
       public int themmoikh(BusinessLogic.Entities.BANGCHAMCONG kh)
       {
           return cn.ExcuteNonQueryreturnID("insert into BANGCHAMCONG(thoigiandangnhap,manv) OUTPUT INSERTED.ID values(N'" + kh.thoigiandangnhap + "',N'" + kh.manv + "')");
       }
       public void suakh(BusinessLogic.Entities.BANGCHAMCONG kh)
       {
           cn.ExcuteNonQuery("update BANGCHAMCONG set thoigiandangxuat=N'" + kh.thoigiandangxuat + "' where ID=N'" + kh.ID + "'");
       }
       public DataTable data()
       {
           string sql = @"Select BANGCHAMCONG.ID, BANGCHAMCONG.manv, BANGCHAMCONG.thoigiandangnhap, BANGCHAMCONG.thoigiandangxuat
                from NHANVIEN INNER JOIN BANGCHAMCONG ON NHANVIEN.manv= BANGCHAMCONG.manv";
           return cn.taobang(sql);
       }
    }
}
