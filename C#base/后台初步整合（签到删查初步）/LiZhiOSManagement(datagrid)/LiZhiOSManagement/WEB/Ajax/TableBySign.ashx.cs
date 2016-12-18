using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace LiZhiOSManagement.WEB.Ajax
{
    /// <summary>
    /// TableBySign 的摘要说明
    /// </summary>
    public class TableBySign : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<Sign> dtall = null;
            List<Sign> rows;
            JavaScriptSerializer jss;

            string jso;


            int pagenumber = Convert.ToInt32(context.Request["page"]) == 0 ? 1 : Convert.ToInt32(context.Request["page"]);   //页数
            int pageIndex = Convert.ToInt32(context.Request["rows"]) == 0 ? 10 : Convert.ToInt32(context.Request["rows"]);  //行数

            ShowSignInByDateBLL sabg = new ShowSignInByDateBLL();
            dtall = sabg.ShowSign();


            rows = (from u in dtall orderby u.ID descending select u).Skip(pageIndex * (pagenumber - 1)).Take(pageIndex).ToList();
            int total = dtall.Count();

            jss = new JavaScriptSerializer();
            jso = jss.Serialize(rows);
            string json = "{\"total\":" + total + ",\"rows\":" + jso + "}";


            context.Response.Write(json);
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