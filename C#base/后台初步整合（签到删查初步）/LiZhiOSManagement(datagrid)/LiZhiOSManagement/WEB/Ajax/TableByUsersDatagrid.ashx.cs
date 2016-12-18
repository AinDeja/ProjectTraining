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
    /// TableByUsersDatagrid 的摘要说明
    /// </summary>
    public class TableByUsersDatagrid : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";



            string belong = context.Request.Params["belongkind"];
            string bysel = context.Request.Params["bysel"].ToString() == null ? null : context.Request.Params["bysel"].ToString();  //限制条件
            string byserch = context.Request.Params["byserch"].ToString() == null ? null : context.Request.Params["byserch"].ToString();  //输入的条件
            int pagenumber = Convert.ToInt32(context.Request["page"]) == 0 ? 1 : Convert.ToInt32(context.Request["page"]);   //页数
            int pageIndex = Convert.ToInt32(context.Request["rows"]) == 0 ? 10 : Convert.ToInt32(context.Request["rows"]);  //行数
            ShowUsersMessagesBLL sum = new ShowUsersMessagesBLL();
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            List<Users> list = new List<Users>();
            List<Users> rows = new List<Users>();
            List<Managers> listman=new List<Managers>();
            listman = smm.selectM();
            if(bysel=="ID")
            {
                if(byserch=="*")
                {
                    if(belong=="All")
                    {
                        list = sum.selectAllUsers();
                    }
                    else
                    {
                        list = sum.selectAllUsers().Where(r => r.Belong == belong).ToList();
                    }
                }
                else
                {
                    if(belong=="All")
                    {
                        list = sum.ShowUsersById(Convert.ToInt32(byserch));
                    }
                    else
                    {
                        list = sum.ShowUsersById(Convert.ToInt32(byserch)).Where(r=>r.Belong==belong).ToList();
                    }
                    pageIndex = 10;
                }
            }
            else if(bysel=="IsDelete")
            {
                if(byserch=="*")
                {
                    if(belong=="All")
                    {
                        list = sum.selectAllUsers();
                    }
                    else
                    {
                        list = sum.selectAllUsers().Where(r=>r.Belong==belong).ToList();
                    }
                }
                else
                {
                    if(belong=="All")
                    {
                        list = sum.ShowUsersByIsDelete("%"+byserch+"%");
                    }
                    else
                    {
                        list = sum.ShowUsersByIsDelete("%" + byserch + "%").Where(r => r.Belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "CreateTime")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectAllUsers();
                    }
                    else
                    {
                        list = sum.selectAllUsers().Where(r => r.Belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.ShowUsersByCreattime(byserch);
                    }
                    else
                    {
                        list = sum.ShowUsersByCreattime(byserch).Where(r => r.Belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserName")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectAllUsers();
                    }
                    else
                    {
                        list = sum.selectAllUsers().Where(r => r.Belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.ShowUsersByUserName("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.ShowUsersByUserName("%" + byserch + "%").Where(r => r.Belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserPassWord")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectAllUsers();
                    }
                    else
                    {
                        list = sum.selectAllUsers().Where(r => r.Belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.ShowUsersByUserPassWord("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.ShowUsersByUserPassWord("%" + byserch + "%").Where(r => r.Belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserSex")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectAllUsers();
                    }
                    else
                    {
                        list = sum.selectAllUsers().Where(r => r.Belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.ShowUsersByUserSex("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.ShowUsersByUserSex("%" + byserch + "%").Where(r => r.Belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserQQ")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectAllUsers();
                    }
                    else
                    {
                        list = sum.selectAllUsers().Where(r => r.Belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.ShowUsersByUserQQ("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.ShowUsersByUserQQ("%" + byserch + "%").Where(r => r.Belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserPhone")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectAllUsers();
                    }
                    else
                    {
                        list = sum.selectAllUsers().Where(r => r.Belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.ShowUsersByUserPhone("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.ShowUsersByUserPhone("%" + byserch + "%").Where(r => r.Belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserStuID")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectAllUsers();
                    }
                    else
                    {
                        list = sum.selectAllUsers().Where(r => r.Belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.ShowUsersByUserStuID("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.ShowUsersByUserStuID("%" + byserch + "%").Where(r => r.Belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserFname")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectAllUsers();
                    }
                    else
                    {
                        list = sum.selectAllUsers().Where(r => r.Belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.ShowUsersByUserFname("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.ShowUsersByUserFname("%" + byserch + "%").Where(r => r.Belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserIP")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectAllUsers();
                    }
                    else
                    {
                        list = sum.selectAllUsers().Where(r => r.Belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.ShowUsersByUserIP("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.ShowUsersByUserIP("%" + byserch + "%").Where(r => r.Belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "belong")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectAllUsers();
                    }
                    else
                    {
                        list = sum.selectAllUsers().Where(r => r.Belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.ShowUsersBybelong("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.ShowUsersBybelong("%" + byserch + "%").Where(r => r.Belong == belong).ToList();
                    }
                }
            }

            if(HttpContext.Current.Session["quan"].ToString()=="m")
            {
                foreach(var item in list)
                {
                    if(listman.Exists(r=>r.UserName==item.UserName))
                    {
                        if(item.UserName==HttpContext.Current.Session["name"].ToString())
                        {

                        }
                        else
                        {
                            item.UserPassWord = "*****";
                        }
                    }
                }
            }




            //list = sum.ShowUsers(belongkind);
            rows = (from u in list orderby u.ID select u).Skip(pageIndex *(pagenumber-1)).Take(pageIndex).ToList();
            int total = list.Count();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jso = jss.Serialize(rows);
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