using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;           

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// SaveEditMessages 的摘要说明
    /// </summary>
    public class SaveEditMessages : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            AddArticleByManagersBLL aabm = new AddArticleByManagersBLL();
            int id = Convert.ToInt32(context.Request.Params["id"]);
            bool isdelete = Convert.ToBoolean(context.Request.Params["isdelete"]);
            DateTime dt = Convert.ToDateTime(context.Request.Params["createtime"]);
            string belongkind = Convert.ToString(context.Request.Params["belongkind"]);
            string title = Convert.ToString(context.Request.Params["title"]);
            string content = Convert.ToString(context.Request.Params["content"]);
            string belonguser = Convert.ToString(context.Request.Params["belonguser"]);
            string belongkind_type = Convert.ToString(context.Request.Params["belongkind_type"]);
            int mostbrowse = Convert.ToInt32(context.Request.Params["mostbrowse"]);
            string quan = HttpContext.Current.Session["quan"].ToString() == null ? null : HttpContext.Current.Session["quan"].ToString();              //登陆人的权限
            string lname = HttpContext.Current.Session["name"].ToString() == null ? null : HttpContext.Current.Session["name"].ToString();                //登陆人的名字
            List<Managers> listm = new List<Managers>();
            List<SuperManagers> listsm = new List<SuperManagers>();
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            listm = smm.selectM();      //所有的管理员
            listsm = smm.selectSM();       //超级管理员
            int s=0;
            if(quan=="sm")
            {
                s = aabm.editArticle(id, isdelete, dt, belongkind, title, content, belonguser, belongkind_type, mostbrowse);
            }
            else
            {
                if (listm.Exists(r => r.UserName == belonguser) || listsm.Exists(r => r.UserName == belonguser) || listm.Where(r => r.UserName == lname).ToList()[0].belong != belongkind)                     //被编辑文章作者为超级管理员或管理员或不在同一组
                {
                    if(listm.Where(r => r.UserName == lname).ToList()[0].UserName==belonguser)
                    {
                        s = aabm.editArticle(id, isdelete, dt, belongkind, title, content, belonguser, belongkind_type, mostbrowse);
                    }
                }
                else
                {
                    s = aabm.editArticle(id, isdelete, dt, belongkind, title, content, belonguser, belongkind_type, mostbrowse);
                }
            }
            context.Response.Write(s);
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