using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class AddArticleBLL
    {
        AddArticleDAL ad = new AddArticleDAL();
        public int AddArticle(bool IsDelete, DateTime CreateTime, string BelongKind, string Title, string Content, int BelongUser, string BelongKind_Type)
        {

            return ad.AddArticle(IsDelete, CreateTime, BelongKind, Title, Content, BelongUser, BelongKind_Type);
        }
        public int addArticleBrowse(int id, int browse)
        {
            return ad.addArticleBrowse(id, browse);
        }
    }
}