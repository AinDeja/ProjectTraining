﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.Model
{
    public class Users
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
        public long UserQQ
        {
            get;
            set;
        }
        public long UserPhone
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
        public string Belong
        {
            get;
            set;
        }
    }
}