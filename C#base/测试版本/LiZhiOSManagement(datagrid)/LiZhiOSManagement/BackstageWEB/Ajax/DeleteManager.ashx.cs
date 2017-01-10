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
    /// DeleteManager 的摘要说明
    /// </summary>
    public class DeleteManager : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //int s = 0;
            //string name = context.Request.Params["name"];
            
            List<SuperManagers> listsm = new List<SuperManagers>();
            List<Managers> listm=new List<Managers>();
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            int id = Convert.ToInt32(context.Request.Params["id"]);
            listsm = smm.selectSM();         //超级管理员 
            listm=smm.selectM();             //超级管理员

            string shuzu = context.Request["shuzu"];              //要删除的用户的数组
            shuzu = shuzu.Substring(4, shuzu.Length - 5);         //被删人id
            string[] delid = shuzu.Split(',');                    //  分离出来被删人id    Managers表里

            string quan = HttpContext.Current.Session["quan"].ToString() == null ? null : HttpContext.Current.Session["quan"].ToString();              //登陆人的权限
            string lname = HttpContext.Current.Session["name"].ToString() == null ? null : HttpContext.Current.Session["name"].ToString();                //登陆人的名字

            int s = 0;
            string c = null;
            string enddelid=null; //最终要删除的id
            for (int i = 0; i < delid.Length; i++)
            {
                string delname = listm.Where(r=>r.ID==Convert.ToInt32(delid[i])).ToArray()[0].UserName;      //要删除人的名字
                if (quan == "sm")                                          //登陆人  超管
                { 
                    if(lname==delname)                                        //删除自己
                    {
                        enddelid += delid[i] + ",";
                        c = "del";
                    }
                    else
                    {
                        if(!listsm.Exists(r=>r.UserName==delname))            //删除的不是超管
                        {
                            enddelid += delid[i] + ",";
                           
                        }
                    }
                }
                else                                                          //登陆人   一般管理
                {
                    //if(listm.Exists(r=>r.UserName==lname))
                    //{
                    //    enddelid += delid[i] + ",";
                    //    c = "del";
                    //}
                    if (lname == delname)
                    {
                        enddelid += delid[i] + ",";
                        c = "del";
                    }
                }
            }

            if (enddelid != null)
            {
                DeleteUserAndArticlesAndCommentsBLL duaa = new DeleteUserAndArticlesAndCommentsBLL();
                int n = duaa.deleteManager(enddelid.Substring(0,enddelid.Length-1));
                if (c != null)
                {
                    s = 110;
                }
                else
                {
                    if (n == delid.Length)
                    {
                        s = 1;
                    }
                    else if(n>0)
                    {
                        s = 0;        //权限不足，删除部分
                    }
                    else
                    {
                        s = -1;
                    }
                }
            }
            else
            {
                s = -1;
            }



                //if (HttpContext.Current.Session["quan"].ToString() == "sm")     //登陆人：超级管理
                //{
                //    if (listsm.Exists(r => r.UserName == name))                      //被删除人：超级管理
                //    {
                //        if (HttpContext.Current.Session["name"].ToString() == name)   //被删除的是自己
                //        {
                //            s = duaa.deleteManager(id);                           //删除自己在管理员表里内容
                //        }
                //        else
                //        {
                //            s = 0;
                //        }
                //    }
                //    else
                //    {
                //        s = duaa.deleteManager(id);
                //    }
                //}
                //else
                //{
                //    s = 0;
                //}

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