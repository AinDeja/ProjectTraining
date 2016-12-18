using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class DeleteArticleAndCommentBLL
    {


        DeleteArticleAndCommentDAL daac = new DeleteArticleAndCommentDAL();
//文章列表删除
        public int delteArticlesBy(string delid)
        {
            return daac.deleteArticlesBy(delid);
        }
        public int deleteCommentsBy(string delid)
        {
            return daac.deleteCommentsBy(delid);
        }




//评论页面删除
        public int DeleteArticle(int id)
        {
            return daac.deleteArticle(id);
        }
        

        public void DeleteAllCommments(int id)
        {
            daac.DeleteAllComments(id);
        }


        public void DeleteByComments(int id)
        {
            daac.DeleteByComments(id);
        }
    }
}