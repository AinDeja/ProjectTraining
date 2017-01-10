using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspirationalWeb.BLL
{
    public class Distinguish
    {
        public static void LoginMess(string tip)
        {
            HttpContext context = HttpContext.Current;
                    context.Response.Write("<script language=javascript>alert('"+tip+"');</script>");
        }
            public static void RegisterMess(string tip){
                HttpContext context = HttpContext.Current;
                context.Response.Write("<script language=javascript>alert('" + tip + "');</script>");
            }
            public static void Tip(string tip)
            {
                HttpContext context = HttpContext.Current;
                context.Response.Write("<script language=javascript>alert('" + tip + "');</script>");
            }
            public static void CheckLogin()
            {
                HttpContext context = HttpContext.Current;
                if (context.Session["Name"] == null && context.Session["AdminName"] == null)
                {
                    HttpCookie freelogin = context.Request.Cookies["UName"];

                    if (freelogin != null)
                    {
                        string names = freelogin.Values["Name"];
                        System.Web.HttpContext.Current.Session["Name"] = names;
                        context.Response.Write("<script language=javascript>window.location='/WebPL/Index.aspx'</script>");
                    }
                    else
                    {
                        context.Response.Write("<script language=javascript>alert('即将返回首页，请登录后操作！');window.location='/WebPL/Index.aspx'</script>");//绝对路径 以“/”开头
                    }
                }

            }
            public static void CheckAdminLogin()
            {
                HttpContext context = HttpContext.Current;
                if (context.Session["Name"] == null && context.Session["AdminName"] == null)
                {
                    HttpCookie freelogin = context.Request.Cookies["AName"];

                    if (freelogin != null)
                    {
                        string names = freelogin.Values["AdminName"];
                        System.Web.HttpContext.Current.Session["AdminName"] = names;
                        context.Response.Write("<script language=javascript>window.location='/WebPL/Admin/AdminCenter.aspx'</script>");
                    }
                    else
                    {
                        context.Response.Write("<script language=javascript>alert('Error！Return...');window.location='/WebPL/Admin/AdminLogin.aspx'</script>");//绝对路径 以“/”开头
                    }
                }

            }
        
    }
}