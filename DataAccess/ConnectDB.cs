using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DataAccess
{
    public class ConnectDB
    {
        SqlConnection con;
        SqlCommand sqlcom;
        SqlDataReader sqldr;
        public SqlConnection getcon()
        {
            return new SqlConnection(@"Data Source=localhost;Initial Catalog=QL_GiuXe;Integrated Security=True");

        }
        public int returnscalarnumber(string sql)
        {
            con = getcon();
            con.Open();
            sqlcom = new SqlCommand(sql, con);
            int n = (int)sqlcom.ExecuteScalar();
            con.Close();
            return n;
        }
        public DataTable taobang(string sql)
        {
            con = getcon();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public void ExcuteNonQuery(string sql)
        {
            con = getcon();
            sqlcom = new SqlCommand(sql, con);
            con.Open();
            sqlcom.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
        public string LoadLable(string sql)
        {
            string ketqua = "";
            con = getcon();
            con.Open();
            sqlcom = new SqlCommand(sql, con);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                ketqua = sqldr[0].ToString();
            }
            con.Close();
            return ketqua;
        }
        public void LoadCombobox(ComboBox cb, string SQL, string DisplayMember, string ValueMember)
        {
            con = getcon();
            con.Open();
            cb.DataSource = taobang(SQL);
            cb.DisplayMember = DisplayMember;
            cb.ValueMember = ValueMember;
            con.Close();
        }
        public void taomatudong(TextBox txtma, string truong, string table, string kieu)
        {
            string ma;
            DataSet ds = new DataSet();

            con = getcon();
            con.Open();
            string str = "select right(" + truong + ",6) as ma  from " + table + " where right(" + truong + ",6) >= All(select right(" + truong + ",6) as ma from " + table + ")";
            SqlCommand cm1 = new SqlCommand(str, con);
            SqlDataAdapter da = new SqlDataAdapter(cm1);

            da.Fill(ds, table);
            con.Close();
            if (ds.Tables[table].Rows.Count == 0)
            {
                ma = kieu + "000001";
                txtma.Text = ma;
            }

            else
            {
                for (int i = 0; i < ds.Tables[table].Rows.Count; i++)
                {
                    // MessageBox.Show(ds.Tables["hdban"].Rows[i]["hoadon"].ToString());
                    double a = Convert.ToDouble(ds.Tables[table].Rows[i]["ma"].ToString());

                    if (a <= 10)
                    {
                        ma = kieu + "00000" + (a + 1);
                        txtma.Text = ma;
                    }
                    else 
                    if (a < 100)
                    {
                        ma = kieu + "0000" + (a + 1);
                        txtma.Text = ma;
                    }
                    else if (a < 1000)
                    {
                        ma = kieu + "000" + (a + 1);
                        txtma.Text = ma;
                    }
                    else if (a < 10000)
                    {
                        ma = kieu + "00" + (a + 1);
                        txtma.Text = ma;
                    }
                    else if (a < 100000)
                    {
                        ma = kieu + "0" + (a + 1);
                        txtma.Text = ma;
                    }
                    else if (a < 1000000)
                    {
                        ma = kieu + (a + 1);
                        txtma.Text = ma;
                    }
                }
            }
        } // end taomatudong
        public int ExcuteNonQueryreturnID(string sql)
        {
            con = getcon();
            sqlcom = new SqlCommand(sql , con);
            con.Open();
            object result = (int)sqlcom.ExecuteScalar();
            int modified = Convert.ToInt32(result);
            con.Close();
            con.Dispose();
            return modified;
            
        }
    }
}
