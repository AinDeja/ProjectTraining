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
    /// TableByManagersDatagrid 的摘要说明
    /// </summary>
    public class TableByManagersDatagrid : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain"; 
            string belong = context.Request.Params["belongkind"];
            string bysel = context.Request.Params["bysel"].ToString() == null ? null : context.Request.Params["bysel"].ToString();  //限制条件
            string byserch = context.Request.Params["byserch"].ToString() == null ? null : context.Request.Params["byserch"].ToString();  //输入的条件
            int pagenumber = Convert.ToInt32(context.Request["page"]) == 0 ? 1 : Convert.ToInt32(context.Request["page"]);   //页数
            int pageIndex = Convert.ToInt32(context.Request["rows"]) == 0 ? 10 : Convert.ToInt32(context.Request["rows"]);  //行数
            ShowManagersMessagesBLL sum = new ShowManagersMessagesBLL();
            List<Managers> list = new List<Managers>();
            List<Managers> rows = new List<Managers>();


            if (bysel == "ID")
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectM();
                    }
                    else
                    {
                        list = sum.selectM().Where(r => r.belong == belong).ToList();
                    }
                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.showManagersByID(Convert.ToInt32(byserch));
                    }
                    else
                    {
                        list = sum.showManagersByID(Convert.ToInt32(byserch)).Where(r => r.belong == belong).ToList();
                    }
                    pageIndex = 10;
                }
            }
            else if (bysel == "IsDelete")
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectM();
                    }
                    else
                    {
                        list = sum.selectM().Where(r => r.belong == belong).ToList();
                    }
                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.showManagersByIsDelete("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.showManagersByIsDelete("%" + byserch + "%").Where(r => r.belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "CreateTime")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectM();
                    }
                    else
                    {
                        list = sum.selectM().Where(r => r.belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.showManagersByCreattime(byserch);
                    }
                    else
                    {
                        list = sum.showManagersByCreattime(byserch).Where(r => r.belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserName")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectM();
                    }
                    else
                    {
                        list = sum.selectM().Where(r => r.belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.showManagersByUserName("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.showManagersByUserName("%" + byserch + "%").Where(r => r.belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserPassWord")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectM();
                    }
                    else
                    {
                        list = sum.selectM().Where(r => r.belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.showManagersByUserPassWord("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.showManagersByUserPassWord("%" + byserch + "%").Where(r => r.belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserSex")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectM();
                    }
                    else
                    {
                        list = sum.selectM().Where(r => r.belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.showManagersByUserSex("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.showManagersByUserSex("%" + byserch + "%").Where(r => r.belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserQQ")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectM();
                    }
                    else
                    {
                        list = sum.selectM().Where(r => r.belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.showManagersByUserQQ("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.showManagersByUserQQ("%" + byserch + "%").Where(r => r.belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserPhone")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectM();
                    }
                    else
                    {
                        list = sum.selectM().Where(r => r.belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.showManagersByUserPhone("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.showManagersByUserPhone("%" + byserch + "%").Where(r => r.belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserStuID")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectM();
                    }
                    else
                    {
                        list = sum.selectM().Where(r => r.belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.showManagersByUserStuID("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.showManagersByUserStuID("%" + byserch + "%").Where(r => r.belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserFname")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectM();
                    }
                    else
                    {
                        list = sum.selectM().Where(r => r.belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.showManagersByUserFname("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.showManagersByUserFname("%" + byserch + "%").Where(r => r.belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "UserIP")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectM();
                    }
                    else
                    {
                        list = sum.selectM().Where(r => r.belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.showManagersByUserIP("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.showManagersByUserIP("%" + byserch + "%").Where(r => r.belong == belong).ToList();
                    }
                }
            }
            else if (bysel == "belong")                            //需要改
            {
                if (byserch == "*")
                {
                    if (belong == "All")
                    {
                        list = sum.selectM();
                    }
                    else
                    {
                        list = sum.selectM().Where(r => r.belong == belong).ToList();
                    }

                }
                else
                {
                    if (belong == "All")
                    {
                        list = sum.showManagersBybelong("%" + byserch + "%");
                    }
                    else
                    {
                        list = sum.showManagersBybelong("%" + byserch + "%").Where(r => r.belong == belong).ToList();
                    }
                }
            }


            if (HttpContext.Current.Session["quan"].ToString() == "m")
            {
                
                foreach (var item in list)
                {
                    if(item.UserName!=HttpContext.Current.Session["name"].ToString())
                    {
                        item.UserPassWord = "*****";
                    }
                }
            }
            





            //list = sum.ShowManagers(belongkind);
            rows = (from u in list orderby u.ID select u).Skip(pageIndex * (pagenumber - 1)).Take(pageIndex).ToList();
            int total = list.Count();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jso = jss.Serialize(rows);
            string json = "{\"total\":" + total + ",\"rows\":" + jso + "}";

            context.Response.Write(json);
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