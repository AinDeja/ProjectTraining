using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// ShowSuperManagers 的摘要说明
    /// </summary>
    public class ShowSuperManagers : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int pagenumber = Convert.ToInt32(context.Request["page"]) == 0 ? 1 : Convert.ToInt32(context.Request["page"]);   //页数
            int pageIndex = Convert.ToInt32(context.Request["rows"]) == 0 ? 10 : Convert.ToInt32(context.Request["rows"]);  //行数
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            List<SuperManagers> listsm = new List<SuperManagers>();
            List<SuperManagers> listsmshow = new List<SuperManagers>();
            listsm = smm.selectSM();       //所有超级管理员
            //string lname=HttpContext.Current.Session["name"].ToString();
            string jso = null;
            string json = null;
            string quan = HttpContext.Current.Session["quan"].ToString();
            if (HttpContext.Current.Session["quan"].ToString() == "sm")
            {
                listsmshow = (from u in listsm orderby u.ID select u).Skip(pageIndex * (pagenumber - 1)).Take(pageIndex).ToList();
                int total = listsm.Count();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                jso = jss.Serialize(listsmshow);
                json = "{\"total\":" + total + ",\"rows\":" + jso + "}";
            }
            else
            {
                jso = null;
                json = "{\"total\":" + null + ",\"rows\":" + null + "}";
            }



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