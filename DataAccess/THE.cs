using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using System.Data;
namespace DataAccess
{
    public class THE
    {
        ConnectDB cn = new ConnectDB();
        public string kiemtra(string ma)
        {
            return cn.LoadLable("Select count(*) from THE where sothe=N'" + ma + "'");
        }
        public void themmoikh(BusinessLogic.Entities.THE kh)
        {
            cn.ExcuteNonQuery("insert into THE values(N'" + kh.sothe + "',N'" + kh.ngaybdsd + "',N'" + kh.NgayKt + "',N'" + kh.Tinhtrang + "',N'" + kh.nsdthe + "')");
        }
        public void xoakh(BusinessLogic.Entities.THE kh)
        {
            cn.ExcuteNonQuery("delete THE where sothe=N'" + kh.sothe + "'");
        }
        public void suakh(BusinessLogic.Entities.THE kh)
        {
            cn.ExcuteNonQuery("update THE set ngaybdsd=N'" + kh.ngaybdsd + "',NgayKt=N'" + kh.NgayKt + "',Tinhtrang=N'" + kh.Tinhtrang + "',nsdthe=N'" + kh.nsdthe + "' where sothe=N'" + kh.sothe + "'");
        }
        public DataTable data()
        {
            string sql = "Select * from THE";
            return cn.taobang(sql);
        }
    }
}
