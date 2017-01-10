using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DSBBS
{
    public class Distinguish
    {
        public static void CheckLoginIndex()
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["Name"] == null && context.Session["AdminName"] == null)
            {
                HttpCookie freelogin = context.Request.Cookies["UName"];

                if (freelogin != null)
                {
                    string names = freelogin.Values["Name"];
                    System.Web.HttpContext.Current.Session["Name"] = names;
                    context.Response.Write("<script language=javascript>window.location='/HTML/UserIndex.aspx'</script>");
                }
              
            }

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
                    context.Response.Write("<script language=javascript>window.location='/HTML/UserIndex.aspx'</script>");
                }
                else
                {
                    context.Response.Write("<script language=javascript>alert('请登录！');window.location='/HTML/Login.aspx'</script>");//绝对路径 以“/”开头
                }
            }
            
        }
        public static void CheckAdminLogin()
        {
            HttpContext context = HttpContext.Current;
        if (context.Session["AdminName"] == null)
            {
                HttpCookie Afreelogin = context.Request.Cookies["AName"];

                if (Afreelogin != null)
                {
                    string Anames = Afreelogin.Values["AdminName"];
                    System.Web.HttpContext.Current.Session["AdminName"] = Anames;
                    context.Response.Write("<script language=javascript>window.location='/HTML/UserIndex.aspx'</script>");
                }
                else
                {
                    context.Response.Write("<script language=javascript>alert('请登录！');window.location='/HTML/Login.aspx'</script>");//绝对路径 以“/”开头
                }
                //context.Response.Write("<script>alert('您未登录!')</script>");
                //context.Response.Redirect("../Index.aspx");  //不会执行write就跳转
            }
        }

        public static void sysAdminLogin()
        {

            HttpContext context = HttpContext.Current;
            if (context.Session["AdminName"] == null)
            {
                HttpCookie Afreelogin = context.Request.Cookies["AName"];

                if (Afreelogin != null)
                {
                    string Anames = Afreelogin.Values["AdminName"];
                    System.Web.HttpContext.Current.Session["AdminName"] = Anames;
                    context.Response.Write("<script language=javascript>window.location='/HTML/SysAdmin.aspx'</script>");
                }
                else
                {
                    context.Response.Write("<script language=javascript>alert('请登录！');window.location='/HTML/SysAdmin.aspx'</script>");//绝对路径 以“/”开头
                }
            }
        }
        public static bool isNumber(string message)
        {
            for (int i = 0; i < message.Length;i++)
            {
                byte messageByte = Convert.ToByte(message[i]);
                if ((messageByte<48)||(messageByte>57))
                {
                    return false;
                }
               
            }
            return true;
        }
    }
}