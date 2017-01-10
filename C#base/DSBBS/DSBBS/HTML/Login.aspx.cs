using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSBBS.HTML
{
    public partial class Login : System.Web.UI.Page
    {
        protected string tip;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            Server.Execute("Head.aspx");
            //清除cookie并清空 Session["Name"] 跳转至登录页
            if (Session["Name"]!=null)
            {
                string exit = Context.Request["exitUser"];
                if (exit=="1")
                {
                    HttpCookie cookie = Request.Cookies["UName"];
                    if (cookie != null)
                    {

                        cookie.Expires = DateTime.Today.AddDays(-1);
                        cookie.Values["Name"] = null;
                        Response.Cookies.Add(cookie);
                        Request.Cookies.Remove("UName");
                        Session["Name"] = null;
                        Distinguish.CheckLogin();
                    }
                    else
                    {
                        Session["Name"] = null;
                        Distinguish.CheckLogin();
                    }
                }
            }
            
            if (Request.HttpMethod.ToLower()=="post")
            {
                string name = Context.Request["Name"];
                string password = Context.Request["PassWord"];
                Session["Name"] = name;
                Session["PassWord"] = password;
                if (Session["Name"].ToString()!="")
                {
                    if (Session["PassWord"].ToString() != "")
                    {
                        DataTable su = SqlHelper.ExecuteDataTable("select*from DS_User where UserName=@name", new SqlParameter("@name", Session["Name"]));
                        //DataRow  cc=su.Rows[0];
                        if (su.Rows.Count>0)//按UserName查询无果时CaseSensitive==false
                        {
                            DataRow selectUser = su.Rows[0];
                            if (selectUser["UserPassword"].ToString() == Session["PassWord"].ToString())//object转string进行比较判断
                            {
                                string fl=Request.Form["freeLogin"];
                                if (fl == "一周内免登录")//一周内免登陆
                                {
                                    HttpCookie cookie = new HttpCookie("UName");
                                    cookie.Expires = DateTime.Now.AddDays(7);
                                    cookie.Values["Name"] = name;
                                    Response.Cookies.Add(cookie);
                                    //HttpCookie freelogin = Request.Cookies["UName"];
                                    //string names = freelogin.Values["Name"];
                                }
                                Response.Redirect("UserIndex.aspx");
                            }
                            else
                            {
                                tip=" 密码错误！";
                            }
                        }
                        else
                        {
                            tip=" 用户名错误！";

                        }
                        
                    }
                    else
                    {
                       tip=" 请输入密码！";
                    }
                  
                }
                else
                {
                    tip=" 用户名不能为空！";
                }
               
            }
            else
            {
                tip=" 请输入用户名和密码！";
            }
        }
    }
}