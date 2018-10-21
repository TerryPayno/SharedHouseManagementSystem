using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharedHouseManagementSystem.Models;
using System.Data.SqlClient;
using SharedHouseManagementSystem.Repository;
using Dapper;
using System.Data;
using System.Web.Http;

namespace SharedHouseManagementSystem.Controllers
{
    [RoutePrefix("api/Charge")]
    public class ChargeController : ApiController
    {
        [HttpPost, Route("GetCharges")]
        public IEnumerable<Charge> GetCharges(LoginReturn userInfo)
        {
            Database db = new Database();
            SqlConnection myConnection = new SqlConnection();
            myConnection = db.connect();

            //Charge charges = new Charge();
            IEnumerable<Charge> charges = myConnection.Query<Charge>("spGetCharges", new { UserID = userInfo.UserID },
                commandType: CommandType.StoredProcedure);

            return charges;
        }
    }
}