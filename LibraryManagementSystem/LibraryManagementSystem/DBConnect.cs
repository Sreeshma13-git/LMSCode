using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;


namespace LibraryManagementSystem
{
    public class DBConnect
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

        public SqlConnection GetConn()
        {
            return conn;
        }

        public void OpenCon()
        {
            if (conn.State==ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public void CloseCon()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}