using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspirationalWeb.Model
{
    public class Seat
    {

        public int UserID { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }

        public bool UserSex { get; set; }

        public int UserAge { get; set; }

        public DateTime UserBirth { get; set; }

        public Int64 UserQQ { get; set; }

        public Int64 UserPhone { get; set; }

        public string UserEmail { get; set; }
        public string UserFname { get; set; }
  
    }
}