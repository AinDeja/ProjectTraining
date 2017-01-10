using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSBBS.Admin
{
    public partial class AdminIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckAdminLogin();
            Server.Execute("Head.aspx");
            HttpCookie Afreelogin = Request.Cookies["AName"];
            if (Afreelogin != null)
            {
                string Anames = Afreelogin.Values["AdminName"];
                System.Web.HttpContext.Current.Session["AdminName"] = Anames;
                Context.Response.Write("<script language=javascript>window.location='/Admin/UserAdmin.aspx'</script>");
            }
        }
    }
}