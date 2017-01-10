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
    /// DeleteArticleAndComments 的摘要说明
    /// </summary>
    public class DeleteArticleAndComments : IHttpHandler,IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            DeleteArticleAndCommentBLL daac = new DeleteArticleAndCommentBLL();
            int articleid = Convert.ToInt32(context.Request.Params["articleid"].ToString().Remove(0, 9));    //被删文章id
            string quan = HttpContext.Current.Session["quan"].ToString() == null ? null : HttpContext.Current.Session["quan"].ToString();              //登陆人的权限
            string lname = HttpContext.Current.Session["name"].ToString() == null ? null : HttpContext.Current.Session["name"].ToString();                //登陆人的名字
            List<Managers> listm = new List<Managers>();
            List<SuperManagers> listsm = new List<SuperManagers>();
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            listm = smm.selectM();      //所有的管理员
            listsm = smm.selectSM();       //超级管理员
            ShowArticleByGroupBLL sab=new ShowArticleByGroupBLL();
            List<Article> list = sab.SelectAllArticle();
            ShowUsersMessagesBLL sum = new ShowUsersMessagesBLL();
            string name = sum.showUserName(list.Where(r=>r.ID==articleid).ToArray()[0].BelongUser);    //要删除的文章的作者

            string group = sum.selectGroupbyName(name);


            int s = 0;
            if (quan == "sm")
            {
                if (listsm.Exists(r => r.UserName == HttpContext.Current.Session["name"].ToString()))        //删除的登陆的超级管理员自己
                {
                    s = daac.DeleteArticle(articleid);
                    daac.DeleteAllCommments(articleid);
                }
                else                                                                                     //不能删除别的超管
                {
                    s = 0;
                }

            }
            else
            {
                if (listm.Exists(r => r.UserName == name) || listsm.Exists(r => r.UserName == name) || listm.Where(r => r.UserName == lname).ToList()[0].belong != group)                     //被删除的文章作者为超级管理员或管理员或不在同一组
                {
                    if (listm.Where(r => r.UserName == lname).ToList()[0].UserName == name)
                    {
                        s = daac.DeleteArticle(articleid);
                        daac.DeleteAllCommments(articleid);
                    }
                    else
                    {
                        s = 0;
                    }
                }
                else
                {
                    s = daac.DeleteArticle(articleid);
                    daac.DeleteAllCommments(articleid);
                }
            }

            //int s = daac.DeleteArticle(articleid);
            //daac.DeleteAllCommments(articleid);
            
                //context.Response.Write("文章及评论已删除，现在该页面为空");
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