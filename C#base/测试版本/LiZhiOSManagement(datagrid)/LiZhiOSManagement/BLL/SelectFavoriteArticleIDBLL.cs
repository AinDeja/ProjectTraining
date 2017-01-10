using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class SelectFavoriteArticleIDBLL
    {
        SelectFavoriteArticleIDDAL sf = new SelectFavoriteArticleIDDAL();
        public int SelectFavoriteArticleCount(int articleId, string kind_type)
        {
            return sf.SelectFavoriteArticleCount(articleId, kind_type);
        }

        public List<EnjoyArticle> SelectFavoriteArticleId(int articleId, int userId)
        {

            return sf.SelectFavoriteArticleId(articleId, userId);
        }

        public int DeleteFavoriteArticleId(int articleId, int userId, bool b)
        {

            return sf.DeleteFavoriteArticleId(articleId, userId, b);
        }
        public int InsertFavoriteArticleId(int articleId, int userId, string kind_type)
        {

            return sf.InsertFavoriteArticleId(articleId, userId, kind_type);
        }

        public int SelectFavoriteMessagesId(int messagesid, int userid, int articleid)
        {
            return sf.SelectFavoriteMessagesId(messagesid, userid, articleid);
        }
        public int SelectFavoriteMessagesCount(int messagesid, int articleid)
        {
            return sf.SelectFavoriteMessagesCount(messagesid, articleid);
        }

        public int InsertFavoriteMessagesId(int messagesid, int userid, int articleid)
        {
            return sf.InsertFavoriteMessagesId(messagesid, userid, articleid);
        }
        public int DeleteFavoriteMessagesId(int messagesid, int userid, int articleid)
        {
            return sf.DeleteFavoriteMessagesId(messagesid, userid, articleid);
        }
    }
}