using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SharedHouseManagementSystem.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using SharedHouseManagementSystem.Models;

namespace SharedHouseManagementSystem.Repository
{
    public class Database
    {
        public SqlConnection connect()
        {

            SqlConnection myConnection = new SqlConnection("Integrated Security=True;server=localhost\\SQLEXPRESS01;" +
                               "Trusted_Connection=yes;" +
                               "database=SHMS; " +
                               "connection timeout=30");
            return myConnection;
        }

        public LoginReturn getHashedPassword(UserCredentials Credentials)
        {
            Database db = new Database();
            SqlConnection myConnection = new SqlConnection();
            myConnection = db.connect();

            LoginReturn success = new LoginReturn();


            success = myConnection.Query<LoginReturn>("spGetHashedPassword", new { Email = Credentials.Username },
                commandType: CommandType.StoredProcedure).SingleOrDefault();
            return success;
        }
}
}