using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedHouseManagementSystem.Models
{
    public class PasswordResetobj
    {
        public int ReturnCode { get; set; }
        public Guid UniqueID { get; set; }
        public string Email { get; set; }
    }
}