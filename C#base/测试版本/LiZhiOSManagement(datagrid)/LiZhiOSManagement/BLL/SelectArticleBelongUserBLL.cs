using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class SelectArticleBelongUserBLL
    {
        public string SelectUser(int id)
        {
            SelectArticleBelongUserDAL selectUser = new SelectArticleBelongUserDAL();
            return selectUser.SelectUser(id);
        }
    }
}