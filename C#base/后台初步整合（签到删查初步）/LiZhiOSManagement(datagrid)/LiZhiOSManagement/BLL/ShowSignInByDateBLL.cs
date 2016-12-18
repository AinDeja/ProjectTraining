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
        public List<Sign> showForDeleteFalse()
        {
            return sum.showForDeleteFalse();
        }
        public List<Sign> showForDeleteTrue()
        {
            return sum.showForDeleteTrue();
        }

        public List<Sign> showForDate(string date)
        {
            return sum.showForDate(date);
        }
    }
}