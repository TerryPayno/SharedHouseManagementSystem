using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedHouseManagementSystem.Models
{
    public class NewHouseObj
    {
        public int HouseID { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }
        public int HouseNum { get; set; }
    }
}