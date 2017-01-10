using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;             //session 导入此命名空间
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// DeleteArticleAndCommentsbyDataGrid 的摘要说明
    /// </summary>
    public class DeleteArticleAndCommentsbyDataGrid : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
            //int articleid = Convert.ToInt32(context.Request.Params["articleid"].ToString());  //文章id
            //string username = context.Request.Params["username"].ToString();     //被删除人名字
            //string group = context.Request.Params["group"].ToString();      //被删除人所在组

            string shuzu = context.Request["shuzu"];    //数组
            
            shuzu = shuzu.Substring(4, shuzu.Length-5);         //被删人id
            string[] delid = shuzu.Split(',');          //  分离出来被删人id    article表里
            List<Managers> listm = new List<Managers>();
            List<SuperManagers> listsm = new List<SuperManagers>();
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            ShowUsersMessagesBLL sum=new ShowUsersMessagesBLL();
            ShowArticleByGroupBLL sab = new ShowArticleByGroupBLL();
            List<User> listu=new List<User>();
            List<Article> lista = new List<Article>();
            lista = sab.SelectAllArticle();
            listu=sum.selectAllUsers();
            listm = smm.selectM();      //所有的管理员
            listsm = smm.selectSM();       //超级管理员
            int s = 0;       //返回值，前端判断标准

            string quan = HttpContext.Current.Session["quan"].ToString() == null ? null : HttpContext.Current.Session["quan"].ToString();              //登陆人的权限
            string lname = HttpContext.Current.Session["name"].ToString() == null ? null : HttpContext.Current.Session["name"].ToString();                //登陆人的名字

            string enddelid=null;              //最终要删除的id
            for(int i=0;i<delid.Length;i++)
            {

                string idname = listu.Where(r => r.ID == lista.Where(p => p.ID == Convert.ToInt32(delid[i])).ToArray()[0].BelongUser).ToArray()[0].UserName;  //被删除id  作者
                if (quan == "sm")                                        //登陆人为超管
                {
                    if(listsm.Exists(r=>r.UserName==HttpContext.Current.Session["name"].ToString()&&r.UserName==idname))
                    {
                        enddelid += delid[i]+",";
                    }
                }
                else                                                     //登陆人为一般管理
                {
                    if(listsm.Exists(r=>r.UserName==idname))                 //被删id为超管，
                    {

                    }
                    else if (listm.Exists(r => r.UserName == idname))        //被删id为一般管理
                    {
                        if (idname == HttpContext.Current.Session["name"].ToString())         //被删id为一般管理员自己
                        {
                            enddelid += delid[i] + ",";
                        }
                    }          
                    else                                                     //被删id为成员     
                    { 
                        if(listm.Where(r=>r.UserName==HttpContext.Current.Session["name"].ToString()).ToArray()[0].belong==lista.Where(p=>p.ID==Convert.ToInt32(delid[i])).ToArray()[0].BelongKind)                           //被删id文章为登陆的一般管理员的通一组
                        {
                            enddelid += delid[i] + ",";
                        }
                        
                    }
                }
            }
            if (enddelid != null)
            {
                DeleteArticleAndCommentBLL daac = new DeleteArticleAndCommentBLL();
                
                string ce = enddelid;
                int artcount = daac.delteArticlesBy(enddelid.Substring(0, enddelid.Length - 1));
                int comcount = daac.deleteCommentsBy(enddelid.Substring(0, enddelid.Length - 1));
                if (artcount == delid.Length)
                {
                    s = 1;
                }
                else if (artcount > 0)
                {
                    s = 0;
                }
                else
                {
                    s = -1;
                }
            }
            else
            {
                s = -1;
            }
            
            //int s = 0;
            //if (quan == "sm")
            //{
            //    if (listsm.Exists(r => r.UserName == HttpContext.Current.Session["name"].ToString()))        //删除的登陆的超级管理员自己
            //    {
            //        s = daac.DeleteArticle(articleid);
            //        daac.DeleteAllCommments(articleid);
            //    }
            //    else                                                                                     //不能删除别的超管
            //    {
            //        s = 0;
            //    }

            //}
            //else
            //{
            //    if (listm.Exists(r => r.UserName == username) || listsm.Exists(r => r.UserName == username) || listm.Where(r => r.UserName == lname).ToList()[0].belong != group)                     //被删除的文章作者为超级管理员或管理员或不在同一组
            //    {
            //        if (listm.Where(r => r.UserName == lname).ToList()[0].UserName == username)
            //        {
            //            s = daac.DeleteArticle(articleid);
            //            daac.DeleteAllCommments(articleid);
            //        }
            //        else
            //        {
            //            s = 0;
            //        }
            //    }
            //    else
            //    {
            //        s = daac.DeleteArticle(articleid);
            //        daac.DeleteAllCommments(articleid);
            //    }
            //}
            //string ce = enddelid;
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