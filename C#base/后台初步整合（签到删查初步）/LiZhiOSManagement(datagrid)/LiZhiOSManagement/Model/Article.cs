using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.Model
{
    public class Article
    {
        public int ID
        {
            get;
            set;
        }
        public bool IsDelete
        {
            get;
            set;
        }
        public DateTime CreateTime
        {
            get;
            set;
        }
        public string BelongKind
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }
        public int BelongUser
        {
            get;
            set;
        }
        public string BelongKind_Type
        {
            get;
            set;
        }
        public int MostBrowse
        {
            get;
            set;
        }


        public string Author
        {
            get;
            set;
        }
    }
}