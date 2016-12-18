using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.WEB.Ajax
{
    /// <summary>
    /// SelectSignForEdit 的摘要说明
    /// </summary>
    public class SelectSignForEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //ShowArticleByGroupBLL sac = new ShowArticleByGroupBLL();
            //List<Article> list = new List<Article>();
            //list = sac.SelectAllArticle();
            //int id = Convert.ToInt32(context.Request.Params["id"]);
            //DateTime dt = list.Where(r => r.ID == id).ToArray()[0].CreateTime;
            ShowSignInByDateBLL forID = new ShowSignInByDateBLL();
            List<Sign> list = new List<Sign>();
            list = forID.ShowSign();
            int id = Convert.ToInt32(context.Request.Params["id"]);


            context.Response.Write(list);
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