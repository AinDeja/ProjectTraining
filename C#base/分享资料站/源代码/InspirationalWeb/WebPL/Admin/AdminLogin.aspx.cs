using InspirationalWeb.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InspirationalWeb.WebPL.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected string tip;
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Context.Request["AdminName"];
            string password = Context.Request["AdminPwd"];
            int ck = 0;
            if (Request.HttpMethod.ToLower() == "post")
            {

                B_Admin bll = new B_Admin();
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
                Session["AdminName"] = name;
                Response.Redirect("AdminCenter.aspx");
            }

        }
    }
}