using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharedHouseManagementSystem.Models;
using System.Data.SqlClient;
using System.Data;
using SharedHouseManagementSystem.Repository;
using Dapper;
using System.Security.Cryptography;

namespace SharedHouseManagementSystem.app.Processing
{
    public class Hashing
    {
        public string current(UserCredentials Credentials)
        {


            Database db = new Database();
            LoginReturn success = new LoginReturn();
            success = db.getHashedPassword(Credentials);


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
            return "Password";
        }
    }
}