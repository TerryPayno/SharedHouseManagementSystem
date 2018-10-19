using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace SharedHouseManagementSystem.Repository
{
    public class Database
    {
        public SqlConnection connect()
        {

            SqlConnection myConnection = new SqlConnection("Integrated Security=True;server=localhost\\SQLEXPRESS;" +
                               "Trusted_Connection=yes;" +
                               "database=SHMS; " +
                               "connection timeout=30");
            return myConnection;
        }
    }
}