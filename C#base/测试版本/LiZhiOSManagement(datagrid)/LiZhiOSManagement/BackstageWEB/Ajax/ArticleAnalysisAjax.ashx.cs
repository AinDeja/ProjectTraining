using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// ArticleAnalysisAjax 的摘要说明
    /// </summary>
    public class ArticleAnalysisAjax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ShowUsersMessagesBLL sum = new ShowUsersMessagesBLL();
            List<User> listu = new List<User>();
            listu = sum.selectAllUsers();

            ShowArticleByGroupBLL sab = new ShowArticleByGroupBLL();
            List<BelongKindCount> listn = new List<BelongKindCount>();
            List<BelongKindCount> listw = new List<BelongKindCount>();

            listn = sab.showBKandCount();             //内环
            listw = sab.showBKandBelongUserCount();      //外环
            foreach (var item in listw)
            {
                item.name = listu.Where(r=>r.ID==Convert.ToInt32(item.name)).ToArray()[0].UserName;
            }
            listn.AddRange(listw);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(listn);
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