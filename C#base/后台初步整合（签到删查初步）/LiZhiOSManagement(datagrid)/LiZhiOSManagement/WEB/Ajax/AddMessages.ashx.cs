using LiZhiOSManagement.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// AddMessages 的摘要说明
    /// </summary>
    public class AddMessages : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string ceshi = context.Request.Params["createtime"].ToString();
            DateTime dt = Convert.ToDateTime(context.Request.Params["createtime"]);
            string title = Convert.ToString(context.Request.Params["title"]);
            string content = Convert.ToString(context.Request.Params["content"]);
            string belonguser = Convert.ToString(context.Request.Params["belonguser"]);  //作者
            string belongkind_type = Convert.ToString(context.Request.Params["belongkind_type"]);
            int mostbrowse = Convert.ToInt32(context.Request.Params["mostbrowse"]);

            AddArticleByManagersBLL aab = new AddArticleByManagersBLL();
            ShowUsersMessagesBLL sum = new ShowUsersMessagesBLL();
            string belongkind = sum.selectGroup(belongkind_type);  //用户属的组
            int userid = sum.selectUseridbyname(belonguser);         //用户的id
            int s = aab.addArticle(false, dt, belongkind, title, content, userid, belongkind_type, mostbrowse);
            context.Response.Write(s);
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