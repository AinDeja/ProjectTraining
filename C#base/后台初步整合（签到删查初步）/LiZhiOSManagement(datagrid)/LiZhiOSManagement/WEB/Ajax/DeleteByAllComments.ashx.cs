using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// DeleteByAllComments 的摘要说明
    /// </summary>
    public class DeleteByAllComments : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            DeleteArticleAndCommentDAL daac = new DeleteArticleAndCommentDAL();
            int articleid = Convert.ToInt32(context.Request.Params["id"].ToString().Remove(0,2));
            daac.DeleteAllComments(articleid);
            context.Response.Write(1);
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