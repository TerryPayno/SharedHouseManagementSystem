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
        
        [HttpPost, Route("GetUserPaidShares")]
        public string GetUserPaidShares(LoginReturn userInfo)
        {
            //Charges need to have a boolean value where when the charge for that Products is paid the boolean value for charge changes to true
            //This then will need to be factored into whether the charge is put into the charges screen/table or wether the charge is put into
            //the paid shares table. This then save me from creating a new table as this it pointless when it can be done through an extra feild.
            //By just amending some of the code for adding a charge.




            //Database db = new Database();
            //SqlConnection myConnection = new SqlConnection();
            //myConnection = db.connect();

            //IEnumerable<> UserBoughtvar = myConnection.Query<>("", new { UserID = userInfo.UserID },
            //   commandType: CommandType.StoredProcedure);

            return "Yep";
        }
        [HttpPost, Route("CreateCharge")]
        public string CreateCharge(Charges charges)
        {

            var ProductTableobj = new ProductsBought();
            Database db = new Database();
            SqlConnection myConnection = new SqlConnection();
            myConnection = db.connect();
            using (var command = new SqlCommand("NEED NEW", myConnection)
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
                command.Parameters.Add(new SqlParameter("@Name", charges.UserWhoPaidDetails.Name));
                myConnection.Open();
                command.ExecuteNonQuery();
            }



            //Need to have a stored procedure here to return the id of the last entered record into the Products bought table.
            int ProductID = myConnection.Query<int>("spGetLastProduct",
                commandType: CommandType.StoredProcedure).Single();
            //List<ProductsBought> productList = DBProductsBought.ProductsBoughts.ToList();


            //This id would then be used in the below fuction that would add the charge for all housemates in the charge table.

            var DBChargesTable = new SHMSChargeTableConnectionString();
            var ChargesTableObj = new ChargeTable();

            for (int i = 0; i < charges.HouseMates.Count; i++)
                using (var command = new SqlCommand("NEED NEW", myConnection)
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
                    
                    myConnection.Open();
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
