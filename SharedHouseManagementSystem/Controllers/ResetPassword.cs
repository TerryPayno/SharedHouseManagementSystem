using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SharedHouseManagementSystem.Models;
using System.Data.SqlClient;
using SharedHouseManagementSystem.Repository;
using Dapper;
using System.Data;
using System.Net.Mail;
using System.Text;

namespace SharedHouseManagementSystem.Controllers
{
    [RoutePrefix("api/ResetPassword")]
    public class ResetPassword : ApiController
    {
        
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
            sbEmailBody.Append("http://localhost:2463/api/Login/ResetPasswordAction?uid=" + success.UniqueID);


            mail.IsBodyHtml = true;

            mail.Body = sbEmailBody.ToString();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("tgch.agularjs@gmail.com", "Coffee123!");
            SmtpServer.EnableSsl = true;

            return "What the fuck am i doing :)";
        }

        [HttpPost, Route("ResetPasswordAction")]
        public string ResetPasswordAction(FromUriAttribute uid)
        {
            var param = uid;
            int z = 0;
            //Database db = new Database();
            //SqlConnection myConnection = new SqlConnection();
            //myConnection = db.connect();

            ////Charge charges = new Charge();
            //var success = myConnection.Query<PasswordResetobj>("spResetPasswordRequest", new { Email = userInfo.Username },
            //    commandType: CommandType.StoredProcedure).SingleOrDefault();



            return "What the fuck am i doing :)";
        }
    }
}
