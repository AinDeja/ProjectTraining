using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// SelectTimeForEdit 的摘要说明
    /// </summary>
    public class SelectTimeForEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ShowArticleByGroupBLL sac = new ShowArticleByGroupBLL();
            List<Article> list = new List<Article>();
            list = sac.SelectAllArticle();
            int id =Convert.ToInt32(context.Request.Params["id"]);
            DateTime dt= list.Where(r=>r.ID==id).ToArray()[0].CreateTime;

            context.Response.Write(dt);
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