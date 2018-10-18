using SharedHouseManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharedHouseManagementSystem.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {

        [HttpPost, Route("CreateCharge")]
        public string CreateCharge(Charges charges)
        {
            var DBProductsBought = new SHMSProductsBoughtConnectionString();
            var ProductTableobj = new ProductsBought();
            ProductTableobj.Quantity = charges.Product.quantity;
            ProductTableobj.Price = charges.Product.Price;
            ProductTableobj.Description = charges.Product.Description;
            ProductTableobj.ProductGroup = charges.Product.ProductGroup;
            ProductTableobj.UserPaidFull = charges.UserWhoPaidDetails.UserID;
            ProductTableobj.HouseID = charges.UserWhoPaidDetails.HouseID;
            ProductTableobj.Name = charges.UserWhoPaidDetails.Name;


            DBProductsBought.ProductsBoughts.Add(ProductTableobj);
            DBProductsBought.SaveChanges();

            List<ProductsBought> productList = DBProductsBought.ProductsBoughts.ToList();
            ProductTableobj.ProductID = productList.Last().ProductID;

            var DBChargesTable = new SHMSChargeTableConnectionString();
            var ChargesTableObj = new ChargeTable();

            for (int i = 0; i < charges.HouseMates.Count; i++)
            {
                ChargesTableObj.UserID = charges.HouseMates[i].UserID;
                ChargesTableObj.FirstName = charges.HouseMates[i].FirstName;
                ChargesTableObj.LastName = charges.HouseMates[i].LastName;
                ChargesTableObj.Email = charges.HouseMates[i].Email;
                ChargesTableObj.HouseID = charges.HouseMates[i].HouseID;
                ChargesTableObj.IsPaying = charges.HouseMates[i].IsPaying;
                ChargesTableObj.Price = (charges.Product.Price / (charges.HouseMates.Count + 1 ));
                ChargesTableObj.ProductID = ProductTableobj.ProductID;
                //Buzzing now I need to add to the database and make sure i'm passing the correct data.
                DBChargesTable.ChargeTables.Add(ChargesTableObj);
                DBChargesTable.SaveChanges();
            };

            return "Yep";
        }
    }
}
