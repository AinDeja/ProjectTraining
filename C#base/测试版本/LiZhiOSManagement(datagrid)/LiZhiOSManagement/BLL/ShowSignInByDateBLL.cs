using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class ShowSignInByDateBLL
    {
        ShowSignInByDateDAL sum = new ShowSignInByDateDAL();
        public List<Sign> ShowSign()
        {
            return sum.ShowSignForAdmin();
        }
    }
}