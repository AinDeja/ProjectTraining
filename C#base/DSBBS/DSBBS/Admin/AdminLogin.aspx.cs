using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSBBS.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected string tip;
        protected void Page_Load(object sender, EventArgs e)
        {


            Server.Execute("Head.aspx");
            //清除cookie并清空 Session["Name"] 跳转至登录页
            if (Session["AdminName"] != null)
            {
                string exit = Context.Request["exitUser"];
                if (exit == "1")
                {
                    HttpCookie cookie = Request.Cookies["AName"];
                    if (cookie != null)
                    {

                        cookie.Expires = DateTime.Today.AddDays(-1);
                        cookie.Values["AdminName"] = null;
                        Response.Cookies.Add(cookie);
                        Request.Cookies.Remove("AName");//
                        Session["AdminName"] = null;
                        Distinguish.CheckAdminLogin();
                    }
                    else
                    {
                        Session["AdminName"] = null;
                        Distinguish.CheckAdminLogin();
                    }
                }
            }

            if (Request.HttpMethod.ToLower()=="post")
            {
                string name = Context.Request["AdminName"];
                string password = Context.Request["PassWord"];
                Session["AdminName"] = name;
                Session["PassWord"] = password;
                if (Session["AdminName"].ToString() != "")
                {
                    if (Session["PassWord"].ToString() != "")
                    {
                        DataTable su = SqlHelper.ExecuteDataTable("select*from DS_Admin where AdminName=@name", new SqlParameter("@name", Session["AdminName"]));
                        //DataRow  cc=su.Rows[0];
                        if (su.Rows.Count > 0)//按UserName查询无果时CaseSensitive==false
                        {
                            DataRow selectUser = su.Rows[0];
                            if (selectUser["AdminPassword"].ToString() == Session["PassWord"].ToString())//object转string进行比较判断
                            {
                                //string fl = Request.Form["freeLogin"];
                                //if (fl == "一周内免登录")//一周内免登陆
                                //{
                                //    HttpCookie cookie = new HttpCookie("AName");
                                //    cookie.Expires = DateTime.Now.AddDays(7);
                                //    cookie.Values["AdminName"] = name;
                                //    Response.Cookies.Add(cookie);
                                //    //HttpCookie freelogin = Request.Cookies["UName"];
                                //    //string names = freelogin.Values["Name"];
                                //}
                                Response.Redirect("/IndexTwo.aspx");
                            }
                            else
                            {
                                tip = " 密码错误！";
                            }
                        }
                        else
                        {
                            tip = " 用户名错误！";

                        }

                    }
                    else
                    {
                        tip = " 请输入密码！";
                    }

                }
                else
                {
                    tip = " 用户名不能为空！";
                }

            }
            else
            {
                tip = " 管理员，您好！请登录您的管理帐号";
            }
        }
    }
}