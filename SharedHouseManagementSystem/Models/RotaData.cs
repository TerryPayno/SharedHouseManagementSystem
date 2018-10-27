using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedHouseManagementSystem.Models
{
    public class RotaDataToPass
    {
        public List<RotaObj> RotaRows { get;set;}
    }
    public class RotaObj
    {
        public TimeSpan Time { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
    }
}