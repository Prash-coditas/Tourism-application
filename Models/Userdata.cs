using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourism_1.Models
{
    public class Userdata
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserMobile { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string UserAddress { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }

    }
}