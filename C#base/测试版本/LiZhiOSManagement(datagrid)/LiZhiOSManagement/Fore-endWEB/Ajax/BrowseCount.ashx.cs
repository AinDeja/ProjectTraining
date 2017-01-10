using LiZhiOSManagement.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.Fore_endWEB
{
    /// <summary>
    /// BrowseCount 的摘要说明
    /// </summary>
    public class BrowseCount : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            AddArticleBLL aab = new AddArticleBLL();
            int id = Convert.ToInt32(context.Request.Params["aid"]);
            int count = Convert.ToInt32(context.Request.Params["acount"]) + 1;  //浏览次数
            int s = aab.addArticleBrowse(id, count);

            context.Response.Write(count);
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