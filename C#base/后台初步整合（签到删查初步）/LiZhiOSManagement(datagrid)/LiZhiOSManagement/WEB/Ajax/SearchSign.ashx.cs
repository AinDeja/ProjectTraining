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
    /// SearchSign 的摘要说明
    /// </summary>
    public class SearchSign : IHttpHandler
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
            string bysel = context.Request.Params["bysel"].ToString() == null ? null : context.Request.Params["bysel"].ToString();  //限制条件
            string byserch = context.Request.Params["byserch"].ToString() == null ? null : context.Request.Params["byserch"].ToString();  //输入的条件
            ShowSignInByDateBLL sabg = new ShowSignInByDateBLL();
            dtall = sabg.ShowSign();
            //按是否删除查询
            if (bysel == "IsDelete")
            {
                if (byserch == "*")//查询所有
                {
                    dtall=sabg.ShowSign();
                }
                else if (byserch == "true")
                {
                    //查询部分
                    dtall = sabg.showForDeleteTrue();
                    pageIndex = 10;
                }
                else if (byserch == "false")
                {
                    //查询部分
                    dtall = sabg.showForDeleteFalse();
                    pageIndex = 10;
                }
            }
            //按日期查询
            if (bysel == "today")
            {
                if (byserch == "*")//查询所有
                {
                    dtall = sabg.ShowSign();
                }
                else
                {
                    //查询部分
                    dtall = sabg.showForDate(byserch);
                    pageIndex = 10;
                }
        
            }
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