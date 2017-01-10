using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.Model
{
    public class EnjoyArticle
    {
        public int ID
        {
            get;
            set;
        }
        public int ArticleID
        {
            get;
            set;

        }
        public int UserID
        {
            get;
            set;
        }
        public Boolean IsDelete
        {
            get;
            set;
        }
        public string MessTem
        {
            get;
            set;
        }
    }
}