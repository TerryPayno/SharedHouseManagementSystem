using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharedHouseManagementSystem.Models;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using SharedHouseManagementSystem.Repository;

namespace SharedHouseManagementSystem.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        [HttpPost, Route("Login")]
        public LoginReturn Login(UserCredentials Credentials)
        {
            Database db = new Database();
            SqlConnection myConnection = new SqlConnection();
            myConnection = db.connect();
            /* Fetch the stored value */
            //string savedPasswordHash = DBContext.GetUser(u => u.UserName == user).Password;
            var UsersDB = new SHMSUserDataConnectionString();
            LoginReturn success = new LoginReturn();//

            success = myConnection.Query<LoginReturn>("spGetHashedPassword", new { Email = Credentials.Username },
                commandType: CommandType.StoredProcedure).SingleOrDefault();
            //success = UsersDB.spGetHashedPassword(Credentials.Username);
            /* Extract the bytes */
            var test = success.Password;
            byte[] hashBytes = Convert.FromBase64String(success.Password);
            /* Get the salt */
    
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(Credentials.Password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    throw new UnauthorizedAccessException();
            return success; //For now I will need to return the user ID and So I know who has just logged in.
        }
        [HttpPost, Route("CreateNewAccount")]
        public string CreateNewAccount(Users user)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(user.Password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            Database db = new Database();
            SqlConnection myConnection = new SqlConnection();
            myConnection = db.connect();

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            User HashedCredentails = new User();
            HashedCredentails.Email = user.Email;
            HashedCredentails.Password = savedPasswordHash;
            HashedCredentails.FirstName = user.FirstName;
            HashedCredentails.LastName = user.LastName;
            HashedCredentails.HouseID = user.HouseID;
            using (var command = new SqlCommand("spAddNewUser", myConnection)
            {
                CommandType = CommandType.StoredProcedure

        })
            {
                command.Parameters.Add(new SqlParameter("@FirstName", HashedCredentails.FirstName));
                command.Parameters.Add(new SqlParameter("@LastName", HashedCredentails.LastName));
                command.Parameters.Add(new SqlParameter("@Email", HashedCredentails.Email));
                command.Parameters.Add(new SqlParameter("@Password", HashedCredentails.Password));
                command.Parameters.Add(new SqlParameter("@HouseID", HashedCredentails.HouseID));
                myConnection.Open();
                command.ExecuteNonQuery();
            }

            //var UsersDB = new SHMSUserDataConnectionString();
            //UsersDB.Users.Add(HashedCredentails);
            //UsersDB.SaveChanges();

            return savedPasswordHash;

        }

    }
}
