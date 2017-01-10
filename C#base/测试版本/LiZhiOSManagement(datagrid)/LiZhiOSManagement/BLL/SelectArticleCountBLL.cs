using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class SelectArticleCountBLL
    {
        public int SelectArticleCount(string belongkind)
        {
            SelectArticleCountDAL selectCount = new SelectArticleCountDAL();
            return selectCount.SelectArticleCount(belongkind);
        }

    }
}