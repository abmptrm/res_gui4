using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Kasir_Restaurant
{
    class Sqlserver
    {
        public SqlConnection getConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = @"Data Source= DESKTOP-G6MV476\SQLEXPRESS; Initial Catalog=db_restaurant; Integrated Security=True";
            //Conn.ConnectionString = "Data Source= localhost; Initial Catalog=db_restaurant; Integrated Security=True";

            return Conn;
        }
    }
}
