using SharedHouseManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using SharedHouseManagementSystem.Repository;
using System.Data;
using Dapper;

namespace SharedHouseManagementSystem.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        
        [HttpPost, Route("GetPaidShares")]
        public IEnumerable<UserBoughtProductsData> GetPaidShares(LoginReturn userInfo)
        {

            Database db = new Database();
            SqlConnection myConnection = new SqlConnection();
            myConnection = db.connect();
            
            IEnumerable<UserBoughtProductsData> PaidSharesList = myConnection.Query<UserBoughtProductsData>("spGetPaidShares", new { UserID = userInfo.UserID },
                commandType: CommandType.StoredProcedure);

            return PaidSharesList;

        }
        [HttpPost, Route("CreateCharge")]
        public string CreateCharge(Charges charges)
        {

            var ProductTableobj = new ProductsBought();
            Database db = new Database();
            SqlConnection myConnection = new SqlConnection();
            myConnection = db.connect();
            using (var command = new SqlCommand("spAddProductsBought", myConnection)
            {
                CommandType = CommandType.StoredProcedure

            })
            {
                command.Parameters.Add(new SqlParameter("@Quantity", charges.Product.quantity));
                command.Parameters.Add(new SqlParameter("@Price", charges.Product.Price));
                command.Parameters.Add(new SqlParameter("@Description", charges.Product.Description));
                command.Parameters.Add(new SqlParameter("@ProductGroup", charges.Product.ProductGroup));
                command.Parameters.Add(new SqlParameter("@UserPaidFull", charges.UserWhoPaidDetails.UserID));
                command.Parameters.Add(new SqlParameter("@HouseID", charges.UserWhoPaidDetails.HouseID));
                command.Parameters.Add(new SqlParameter("@Name", charges.UserWhoPaidDetails.UserName));
                myConnection.Open();
                command.ExecuteNonQuery();
            }


            SqlConnection myConnection2 = new SqlConnection();
            myConnection2 = db.connect();
            //Need to have a stored procedure here to return the id of the last entered record into the Products bought table.
            int ProductID = myConnection2.Query<int>("spGetLastProduct",
                commandType: CommandType.StoredProcedure).Single();

            //List<ProductsBought> productList = DBProductsBought.ProductsBoughts.ToList();


            //This id would then be used in the below fuction that would add the charge for all housemates in the charge table.
            SqlConnection myConnection3 = new SqlConnection();
            myConnection3 = db.connect();

            for (int i = 0; i < charges.HouseMates.Count; i++)
                using (var command = new SqlCommand("spAddCharges", myConnection)
                {
                    CommandType = CommandType.StoredProcedure

                })
                {
                    command.Parameters.Add(new SqlParameter("@UserID", charges.HouseMates[i].UserID));
                    command.Parameters.Add(new SqlParameter("@FirstName", charges.HouseMates[i].FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", charges.HouseMates[i].LastName));
                    command.Parameters.Add(new SqlParameter("@Email", charges.HouseMates[i].Email));
                    command.Parameters.Add(new SqlParameter("@HouseID", charges.HouseMates[i].HouseID));
                    command.Parameters.Add(new SqlParameter("@IsPaying", charges.HouseMates[i].IsPaying));
                    command.Parameters.Add(new SqlParameter("@Price", (charges.Product.Price / (charges.HouseMates.Count + 1))));
                    command.Parameters.Add(new SqlParameter("@ProductID", ProductID));
                    command.Parameters.Add(new SqlParameter("@PaidShare", false));

                    myConnection3.Open();
                    command.ExecuteNonQuery();
                }

            return "Yep";
        }
        [HttpPost, Route("GetUserBoughtProducts")]
        public IEnumerable<UserBoughtProductsData> GetUserBoughtProducts(LoginReturn userInfo)
        {
            Database db = new Database();
            SqlConnection myConnection = new SqlConnection();
            myConnection = db.connect();

            UserBoughtProductsData UserBought = new UserBoughtProductsData();
            IEnumerable<UserBoughtProductsData> UserBoughtvar = myConnection.Query<UserBoughtProductsData>("spGetUserBoughtProducts", new { UserID = userInfo.UserID },
                commandType: CommandType.StoredProcedure);

            return UserBoughtvar;
        }
            
    }
}
