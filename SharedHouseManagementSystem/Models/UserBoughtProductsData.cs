using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedHouseManagementSystem.Models
{
    public class UserBoughtProductsData
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string ProductGroup { get; set; }
        public int UserPaidFull { get; set; }
        public int HouseID { get; set; }
        public string Name { get; set; }
    }
}