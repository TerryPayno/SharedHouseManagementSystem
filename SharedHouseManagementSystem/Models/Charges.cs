using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedHouseManagementSystem.Models
{
    public class Charges
    {
        public Product Product { get; set; }
        public List<Users> HouseMates {get;set;}
        public UserWhoPaidDetails UserWhoPaidDetails { get; set; }

    }
    public class Product
    {
        public string Name { get; set; }
        public int quantity { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ProductGroup { get; set; }
    }
    public class UserWhoPaidDetails
    {
        public int UserID { get; set; }
        public int HouseID { get; set; }
        public string UserName { get; set; }
    }

}