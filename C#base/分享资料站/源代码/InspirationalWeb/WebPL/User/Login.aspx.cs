

using InspirationalWeb.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InspirationalWeb.WebPL
{
    public partial class Login : System.Web.UI.Page
    {
        protected string tip;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
            {
                string exit = Context.Request["exitUser"];
                if (exit == "1")
                {
                    //HttpCookie cookie = Request.Cookies["UserName"];
                    //if (cookie != null)
                    //{

                    //    cookie.Expires = DateTime.Today.AddDays(-1);
                    //    cookie.Values["Name"] = null;
                    //    Response.Cookies.Add(cookie);
                    //    Request.Cookies.Remove("Name");//
                    //    Session["Name"] = null;
                    //    //Distinguish.CheckAdminLogin();
                    //}
                    //else
                    //{
                        Session["Name"] = null;
                        //Distinguish.CheckAdminLogin();
                        Response.Redirect("/WebPL/Index.aspx");
                    //}
                }
            }

            string name = Context.Request["Name"];
            string password = Context.Request["PassWord"];
            int ck = 0;
            if (Request.HttpMethod.ToLower() == "post")
            {

                B_User bll = new B_User();
                LoginResult result = bll.Login1(name, password, out name);
                switch (result)
                {
                    case LoginResult.UserNotExists:
                        tip = ("用户不存在！");

                        break;
                    case LoginResult.ErrorPassword:
                        tip = ("密码错误！");
                        break;
                    case LoginResult.OK:
                        tip = ("登录成功!");
                        ck = 1;
                        break;
                    default:
                        tip = ("未知错误！");
                        break;
                }
                Distinguish.LoginMess(tip);

            }
            if (ck == 1)
            {
                Session["Name"] = name;
                Response.Redirect("/WebPL/Index.aspx");
            }

        }
    }
}