using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class ShowCommentsBLL
    {
        public List<Article> showLouZhu(int content)
        {
            ShowCommentsDAL scb = new ShowCommentsDAL();
            List<Article> list = new List<Article>();
            list = scb.showLouZhu(content);
            return list;
        }

        public List<Messages> showComments(int id)
        {
            ShowCommentsDAL scbbll = new ShowCommentsDAL();
            return scbbll.showComments(id);
        }

    }
}