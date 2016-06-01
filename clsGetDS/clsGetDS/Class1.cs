using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsGetDS
{
    public class Class1
    {
        public DataTable clsGetDS(string sql)
        {
            string cnStr = "data source=ncryzxvg04.database.windows.net;initial catalog=jmhtestANcq7Btzo; user id=user00; password=Pa$$w0rd";
            SqlConnection cn = new SqlConnection(cnStr);
            SqlDataAdapter da = new SqlDataAdapter(sql,cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

    }
}
