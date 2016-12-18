using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// SelectArticleContent 的摘要说明
    /// </summary>
    public class SelectArticleContent : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ShowArticleByGroupBLL sabg = new ShowArticleByGroupBLL();
            int id = (context.Request.Params["id"]==null)?0:Convert.ToInt32(context.Request.Params["id"]);
            List<Article> list = sabg.SelectAllArticle();
          
            context.Response.Write(context.Server.HtmlDecode(list.Where(c => c.ID == id).ToArray()[0].Content));
            context.Response.End();
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