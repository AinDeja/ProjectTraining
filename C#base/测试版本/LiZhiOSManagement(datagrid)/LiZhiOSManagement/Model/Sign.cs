using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.Model
{
    public class Sign
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
        public string Belong
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Am
        {
            get;
            set;
        }
        public string Pm
        {
            get;
            set;
        }
        public string Nm
        {
            get;
            set;
        }
        public string Today
        {
            get;
            set;
        }
        /// <summary>
        /// 实际签到人数
        /// </summary>
        public int SureNum
        {
            get;
            set;
        }
        /// <summary>
        /// 总人数
        /// </summary>
        public int GroupNum
        {
            get;
            set;
        }
    }
}