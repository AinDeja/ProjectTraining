using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;      //session  导入此命名空间

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// DeleteUser 的摘要说明
    /// </summary>
    public class DeleteUser : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //string name = context.Request.Params["name"];        //被删除的人
            //int id = Convert.ToInt32(context.Request.Params["id"]);
            //string belong = context.Request.Params["belong"];     //被删除的人所在的组


            string shuzu = context.Request["shuzu"];              //要删除的用户的数组
            shuzu = shuzu.Substring(4, shuzu.Length - 5);         //被删人id
            string[] delid = shuzu.Split(',');                    //  分离出来被删人id    user表里



            string quan = HttpContext.Current.Session["quan"].ToString() == null ? null : HttpContext.Current.Session["quan"].ToString();              //登陆人的权限
            string lname = HttpContext.Current.Session["name"].ToString() == null ? null : HttpContext.Current.Session["name"].ToString();                //登陆人的名字
            List<Managers> listm = new List<Managers>();
            List<SuperManagers> listsm = new List<SuperManagers>();
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            ShowUsersMessagesBLL sum = new ShowUsersMessagesBLL();
            List<Users> listu = new List<Users>();
            listu = sum.selectAllUsers();
            listm = smm.selectM();      //所有的管理员
            listsm = smm.selectSM();       //超级管理员
            int s = 0;
            //bool b;
            string c = null;
            int n = 0;
            string enddelid = null;         //要删除的id
            string names=null;
            for (int i = 0; i < delid.Length; i++)
            {
                string delname = listu.Where(r=>r.ID==Convert.ToInt32(delid[i])).ToArray()[0].UserName;
                if(quan=="sm")                                                    //登陆人为超管
                {
                    if(listsm.Exists(r=>r.UserName==HttpContext.Current.Session["name"].ToString()&&r.UserName==delname))
                    {
                        enddelid += delid[i] + ",";
                        names+=delname+",";
                        c = "del";
                    }
                }
                else                                                               //登陆人为一般管
                {
                    if(listsm.Exists(r=>r.UserName==delname))                              //被删人为超管
                    {

                    }
                    else if (listm.Exists(r => r.UserName == delname))                     //被删人为一般管
                    {
                        if(HttpContext.Current.Session["name"].ToString()==delname)        //被删人为自己
                        {
                            enddelid += delid[i] + ",";
                            names+=delname+",";
                            c = "del";
                        }
                    }
                    else                                                                   //被删人为一般成员
                    {
                        if(listu.Where(r=>r.UserName==HttpContext.Current.Session["name"].ToString()).ToArray()[0].Belong==listu.Where(p=>p.UserName==delname).ToArray()[0].Belong)                         //被删人跟登陆的管理员一组
                        {
                            enddelid += delid[i] + ",";
                            names+=delname+",";
                        }
                    }
                }
            }
            if(enddelid!=null)
            {
                DeleteUserAndArticlesAndCommentsBLL dua = new DeleteUserAndArticlesAndCommentsBLL();
                enddelid = enddelid.Substring(0, enddelid.Length - 1);
                names = names.Substring(0, names.Length - 1);
                n = dua.deleteUser(enddelid,names);
                if (c != null)
                {
                    HttpContext.Current.Session["quan"] = null;
                    HttpContext.Current.Session["name"] = null;
                    s = 110;
                }
                else
                {
                    if (n == delid.Length)
                    {
                        s = 1;
                    }
                    else if (n > 0)
                    {
                        s = 0;    //删除部分，权限不足
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




            
            //if(quan=="sm")     //登陆的人为超级管理员
            //{
            //    if(!listsm.Exists(r=>r.UserName==name))
            //    {
            //        b = dua.deleteUser(id, name);
            //        if (b)
            //        {
            //            s = 1;
            //        }
            //        else
            //        {
            //            s = 0;
            //        }
            //    }
            //    else                                        //被删的人为超管
            //    {
            //        s = 0;
            //    }
                
            //}
            //else                                                  //登陆的人为管理员
            //{
            //    //if(listm.Exists(r=>r.UserName==name)||listsm.Exists(r=>r.UserName==name)||(listm.Where(r=>r.UserName==lname).ToList()[0].belong!=belong))        
            //    if (listm.Exists(r => r.UserName == name) || listsm.Exists(r => r.UserName == name) || listm.Where(r => r.UserName == lname).ToList()[0].belong != belong)                     //被删的人为超级管理员或管理员或不在同一组
            //    {
            //                s = 0;
            //    }
            //    else
            //    {
            //        b = dua.deleteUser(id,name);
            //        if(b)
            //        {
            //            s = 1;
            //        }
            //        else
            //        {
            //            s = 0;
            //        }

            //    }
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