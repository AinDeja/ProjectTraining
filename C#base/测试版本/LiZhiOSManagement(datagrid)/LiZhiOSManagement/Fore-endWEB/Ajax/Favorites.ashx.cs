using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.Fore_endWEB.Ajax
{
    /// <summary>
    /// Favorites 的摘要说明
    /// </summary>
    public class Favorites : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<EnjoyArticle> list = new List<EnjoyArticle>();
            int s;
            SelectFavoriteArticleIDBLL sf = new SelectFavoriteArticleIDBLL();
            int articleId = Convert.ToInt32(context.Request.Params["ArticleId"]);
            int commentId = Convert.ToInt32(context.Request.Params["commentId"]);
            int userId = Convert.ToInt32(context.Request.Params["userId"]);
            string kind_type = Convert.ToString(context.Request.Params["kind_type"]);
            int l;  //表示条数

            //文章的“喜欢”
            if (commentId == 0)
            {
                list = sf.SelectFavoriteArticleId(articleId, userId);  //是否是

                //判断之前插入过数据了
                if (list.Count > 0)
                {
                    string ce = list.Where(c => c.IsDelete).ToString();
                    //如果插入过了，并且状态为false，改变IsDelete的状态即可
                    if (list.Where(c => c.IsDelete == false).ToList().Count == 1)
                    {
                        s = sf.DeleteFavoriteArticleId(articleId, userId, true);
                    }
                    else
                    {
                        s = sf.DeleteFavoriteArticleId(articleId, userId, false);
                    }
                }
                else
                {
                    s = sf.InsertFavoriteArticleId(articleId, userId, kind_type);
                }

                l = sf.SelectFavoriteArticleCount(articleId, kind_type);
            }
            //评论的喜欢
            else
            {
                s = sf.SelectFavoriteMessagesId(commentId, userId, articleId);
                if (s > 0)
                {
                    s = sf.DeleteFavoriteMessagesId(commentId, userId, articleId);
                }
                else
                {
                    s = sf.InsertFavoriteMessagesId(commentId, userId, articleId);
                }
                l = sf.SelectFavoriteMessagesCount(commentId, articleId);
            }

            context.Response.Write(l);
            context.Response.End();  //为了不再输出多余的东西
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}