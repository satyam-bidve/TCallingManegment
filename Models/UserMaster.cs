using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCallingManegment.Models
{
    public class UserMaster
    {
        public string UserName { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int RoleID { get; set; }
        public int ReportingRoleID { get; set; }
        public DateTime LastLoginDate { get; set; }
       
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}