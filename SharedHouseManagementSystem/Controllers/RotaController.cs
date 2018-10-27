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
    [RoutePrefix("api/Rota")]
    public class RotaController : ApiController
    {
        [HttpPost, Route("SaveRotaData")]
        public string SaveRotaData(RotaDataToPass RotaData)
        {

            //Need to add this data to database and make the interface not look nasty.
            Database db = new Database();
            SqlConnection myConnection2 = new SqlConnection();
            myConnection2 = db.connect();

            for (int i = 0; RotaData.RotaRows.Count > i; i++)
            {
                using (var command = new SqlCommand("spSaveNewRotaData", myConnection2)
                {
                    CommandType = CommandType.StoredProcedure

                })
                {
                    command.Parameters.Add(new SqlParameter("@ID", (i+1)));
                    command.Parameters.Add(new SqlParameter("@Time", RotaData.RotaRows[i].Time));
                    command.Parameters.Add(new SqlParameter("@Monday", RotaData.RotaRows[i].Monday));
                    command.Parameters.Add(new SqlParameter("@Tuesday", RotaData.RotaRows[i].Tuesday));
                    command.Parameters.Add(new SqlParameter("@Wednesday", RotaData.RotaRows[i].Wednesday));
                    command.Parameters.Add(new SqlParameter("@Thursday", RotaData.RotaRows[i].Thursday));
                    command.Parameters.Add(new SqlParameter("@Friday", RotaData.RotaRows[i].Friday));
                    command.Parameters.Add(new SqlParameter("@Saturday", RotaData.RotaRows[i].Saturday));
                    command.Parameters.Add(new SqlParameter("@Sunday", RotaData.RotaRows[i].Sunday));

                    myConnection2.Open();
                    command.ExecuteNonQuery();
                }
                myConnection2.Close();
            }
            

            return "Test";
        }
        [HttpGet, Route("GetRotaData")]
        public IEnumerable<RotaObj> GetRotaData()
        {
            Database db = new Database();
            SqlConnection myConnection = new SqlConnection();
            myConnection = db.connect();

            IEnumerable<RotaObj> RotaData = myConnection.Query<RotaObj>("spGetRotaData",
                        commandType: CommandType.StoredProcedure);
            myConnection.Close();
            
            return RotaData;
        }
    }

}