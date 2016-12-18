using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.Model
{
    public class Messages
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
        public string MessTem
        {
            get;
            set;
        }
        public int ArticleID
        {
            get;
            set;
        }
        public string MessBelong
        {
            get;
            set;
        }
        public int CID
        {
            get;
            set;
        }
        public string CommentUser
        {
            get;
            set;
        }
    }
}