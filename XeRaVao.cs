using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using System.Data.SqlClient;
using System.Data;
namespace DataAccess
{
   public class XeRaVao
   {
       ConnectDB con = new ConnectDB();

       SqlConnection cn = new SqlConnection();
       SqlCommand cmd = new SqlCommand();
       public void XeVao(XEVO dt)
       {
           cn = con.getcon();
           cn.Open();
           cmd = new SqlCommand("XeVao", cn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@NgayGioVao", SqlDbType.DateTime).Value = dt.NgayGioVao;
           cmd.Parameters.Add("@maloai", SqlDbType.NVarChar).Value = dt.maloai;
           cmd.Parameters.Add("@sothe", SqlDbType.NVarChar).Value = dt.sothe;
           cmd.Parameters.Add("@manv", SqlDbType.NVarChar).Value = dt.manv;
           cmd.Parameters.Add("@biensoxe", SqlDbType.NVarChar).Value = dt.biensoxe;
           cmd.Parameters.Add("@AnhPhiaTruoc", SqlDbType.Image).Value = dt.AnhPhiaTruoc;
           cmd.Parameters.Add("@AnhPhiaSau", SqlDbType.Image).Value = dt.AnhPhiaSau;
           cmd.Parameters.Add("@TinhTrang", SqlDbType.Bit).Value = false;
           cmd.ExecuteNonQuery();
           cmd.Dispose();
           cn.Close();
       }
       public void XeRa(int ID)
       {
           cn = con.getcon();
           cn.Open();
           cmd = new SqlCommand("Xera", cn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
           cmd.Parameters.Add("@TinhTrang", SqlDbType.Bit).Value = true;
           cmd.Parameters.Add("@NgayGioRa", SqlDbType.DateTime).Value = DateTime.Now;
           
           cmd.ExecuteNonQuery();
           cmd.Dispose();
           cn.Close();
       }
       public DataTable CheckXeRa(string ID)
       {
           cn = con.getcon();
           cn.Open();
           var dt = new DataTable();
           var da = new SqlDataAdapter("GetCheckXeRa", cn);
           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.SelectCommand.Parameters.Add("@sothe", SqlDbType.NVarChar).Value = ID;
           da.Fill(dt);
           return dt;
       }


    }
}
