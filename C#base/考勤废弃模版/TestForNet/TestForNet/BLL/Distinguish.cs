using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestForNet.BAL
{
    public class Distinguish
    {
        public static void CheckLogin()
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["userName"] == null && context.Session["adminName"] == null)
            {
                HttpCookie freelogin = context.Request.Cookies["UName"];

                if (freelogin != null)
                {
                    string names = freelogin.Values["userName"];
                    System.Web.HttpContext.Current.Session["userName"] = names;
                    context.Response.Write("<script language=javascript>window.location='/WEB/Index.aspx'</script>");
                }
                else
                {
                    context.Response.Write("<script language=javascript>alert('点击确定登录页面，请登录后操作！');window.location='/WEB/Login.aspx'</script>");//绝对路径 以“/”开头
                }
            }

        }

        public static void LoginMess(string tip)
        {
            HttpContext context = HttpContext.Current;
            context.Response.Write("<script language=javascript>alert('" + tip + "');</script>");
        }


    }
}