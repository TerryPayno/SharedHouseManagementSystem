using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedHouseManagementSystem.Models
{
    public class LoginReturn
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public int HouseID { get; set; }
    }
}