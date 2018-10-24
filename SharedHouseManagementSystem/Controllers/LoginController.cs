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
using System.Net.Mail;
using System.Text;
using SharedHouseManagementSystem.app.Processing;

namespace SharedHouseManagementSystem.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        [HttpPost, Route("Login")]
        public string Login(UserCredentials Credentials)
        {
            Hashing HashProcessing = new Hashing();
            HashProcessing.newPassword(Credentials);


            return "Test"; //For now I will need to return the user ID and So I know who has just logged in.
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
        [HttpPost, Route("ResetPasswordRequest")]
        public string ResetPasswordRequest(UserCredentials userInfo)
        {
            Database db = new Database();
            SqlConnection myConnection = new SqlConnection();
            myConnection = db.connect();

            //Charge charges = new Charge();
            var success = myConnection.Query<PasswordResetobj>("spResetPasswordRequest", new { Email = userInfo.Username },
                commandType: CommandType.StoredProcedure).SingleOrDefault();

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("tgch.agularjs@gmail.com");
            mail.To.Add(success.Email);
            mail.Subject = "Reset password";
            StringBuilder sbEmailBody = new StringBuilder();

            sbEmailBody.Append("Click the Link you fucking Mong " + ",<br/><br/>");
            sbEmailBody.Append("<a href=" + "http://localhost:2463/ResetPasswordAction/" + success.UniqueID + ">Reset Now</a>");


            mail.IsBodyHtml = true;


            mail.Body = sbEmailBody.ToString();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("tgch.agularjs@gmail.com", "Coffee123!");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            return "What the fuck am i doing :)";
        }

        [HttpPost, Route("ResetPasswordAction")]
        public string ResetPasswordAction(Restobj newDetails)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(newDetails.newPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);



            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            Database db = new Database();
            SqlConnection myConnection = new SqlConnection();
            myConnection = db.connect();

            
            myConnection.Query<Restobj>("spChangePassword", new { GUID = newDetails.GUID, NewPassword = savedPasswordHash },
                commandType: CommandType.StoredProcedure).SingleOrDefault();



            return "What the fuck am i doing :)";
        }
        [HttpPost, Route("AddNewHouse")]
        public int AddNewHouse(NewHouseObj HouseData)
        {
            

            Database db = new Database();
            SqlConnection myConnection = new SqlConnection();
            myConnection = db.connect();

            using (var command = new SqlCommand("spAddNewHouse", myConnection)
            {
                CommandType = CommandType.StoredProcedure

            })
            {
                command.Parameters.Add(new SqlParameter("@PostCode", HouseData.PostCode));
                command.Parameters.Add(new SqlParameter("@Street", HouseData.Street));
                command.Parameters.Add(new SqlParameter("@HouseNum", HouseData.HouseNum));
                myConnection.Open();
                command.ExecuteNonQuery();
            }

            HouseData = myConnection.Query<NewHouseObj>("[spGetHouseID]", new { PostCode = HouseData.PostCode },
                commandType: CommandType.StoredProcedure).SingleOrDefault();


            return HouseData.HouseID;

        }

    }
}
