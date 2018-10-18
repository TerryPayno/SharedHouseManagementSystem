using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharedHouseManagementSystem.Models;

namespace SharedHouseManagementSystem.Controllers
{
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {

        [HttpPost, Route("GetHouseMates")]
        public List<Users> GetHouseMates(Users user)
        {
            var UsersDB = new SHMSUserDataConnectionString();
            var UnMappedHosueMates = UsersDB.spGetAllHouseMates(user.HouseID);
            List<Users> HouseMates = GetAllHouseMatesMapper(UnMappedHosueMates);
            
            return HouseMates;
        }
        public List<Users> GetAllHouseMatesMapper (System.Data.Entity.Core.Objects.ObjectResult<spGetAllHouseMates_Result> items)
        {
            var HouseMates = new List<Users>();
            foreach (var i in items)
            {
                HouseMates.Add(new Users() { UserID = i.UserID, FirstName = i.FirstName, LastName = i.LastName, Email = i.Email, HouseID = i.HouseID });
            }
            return HouseMates;
        }
    }
}
