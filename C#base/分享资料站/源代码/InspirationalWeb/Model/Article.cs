using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspirationalWeb.Model
{
    public class Article
    {
        public DateTime CreateTime { get; set; }
        public string ArType { get; set; }
        public string ArTitle { get; set; }
        public string ArCont { get; set; }

    }
}