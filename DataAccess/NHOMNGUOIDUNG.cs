using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using System.Data;
namespace DataAccess
{
    public class NHOMNGUOIDUNG
    {
        ConnectDB cn = new ConnectDB();
        public string kiemtra(string ma)
        {
            return cn.LoadLable("Select count(*) from NHOMNGUOIDUNG where manhom=N'" + ma + "'");
        }
        public void themmoikh(BusinessLogic.Entities.NHOMNGUOIDUNG kh)
        {
            cn.ExcuteNonQuery("insert into NHOMNGUOIDUNG values(N'" + kh.manhom + "',N'" + kh.tennhom + "')");
        }
        public void xoakh(BusinessLogic.Entities.NHOMNGUOIDUNG kh)
        {
            cn.ExcuteNonQuery("delete NHOMNGUOIDUNG where manhom=N'" + kh.manhom + "'");
        }
        public void suakh(BusinessLogic.Entities.NHOMNGUOIDUNG kh)
        {
            cn.ExcuteNonQuery("update NHOMNGUOIDUNG set tennhom=N'" + kh.tennhom + "' where manhom=N'" + kh.manhom + "'");
        }
        public DataTable data()
        {
            string sql = "Select * from NHOMNGUOIDUNG";
            return cn.taobang(sql);
        }
    }
}
