using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.Model
{
    public class Managers
    {
      
        public int ID
        {
            get;
            set;
        }
        public Boolean IsDelete
        {
            get;
            set;
        }
        public DateTime CreateTime
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string UserPassWord
        {
            get;
            set;
        }
        public string UserSex
        {
            get;
            set;
        }
        public int UserQQ
        {
            get;
            set;
        }
        public int UserPhone
        {
            get;
            set;
        }
        public long UserStuID
        {
            get;
            set;
        }
        public string UserFname
        {
            get;
            set;
        }
        public string UserIP
        {
            get;
            set;
        }
        public string belong
        {
            get;
            set;
        }
    }
}