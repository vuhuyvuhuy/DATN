using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using System.Data;
namespace DataAccess
{
    public class LOAIXE
    {
        ConnectDB cn = new ConnectDB();
        public string kiemtra(string ma)
        {
            return cn.LoadLable("Select count(*) from LOAIXE where maloai=N'" + ma + "'");
        }
        public void themmoikh(BusinessLogic.Entities.LOAIXE kh)
        {
            cn.ExcuteNonQuery("insert into LOAIXE values(N'" + kh.maloai + "',N'" + kh.loaixe + "',N'" + kh.giatien + "')");
        }
        public void xoakh(BusinessLogic.Entities.LOAIXE kh)
        {
            cn.ExcuteNonQuery("delete LOAIXE where maloai=N'" + kh.maloai + "'");
        }
        public void suakh(BusinessLogic.Entities.LOAIXE kh)
        {
            cn.ExcuteNonQuery("update LOAIXE set loaixe=N'" + kh.loaixe + "',giatien=N'" + kh.giatien + "' where maloai=N'" + kh.maloai + "'");
        }
        public DataTable data()
        {
            string sql = "Select * from LOAIXE";
            return cn.taobang(sql);
        }
    }
}
