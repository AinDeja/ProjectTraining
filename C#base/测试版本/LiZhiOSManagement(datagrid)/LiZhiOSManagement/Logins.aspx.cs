using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiZhiOSManagement
{
    public partial class Logins : System.Web.UI.Page
    {
        protected string tip;
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Context.Request["userName"];
            string password = Context.Request["passWord"];
            int ck = 0;
            if (Request.HttpMethod.ToLower() == "post")
            {

                B_User bll = new B_User();
                LoginResult result = bll.Login1(name, password, out name);
                switch (result)
                {
                    case LoginResult.UserNotExists:
                        tip = ("用户不存在！(若忘记用户名或密码，请联系管理员)");

                        break;
                    case LoginResult.ErrorPassword:
                        tip = ("密码错误！(若忘记用户名或密码，请联系管理员)");
                        break;
                    case LoginResult.OK:
                        tip = ("登录成功!(若忘记用户名或密码，请联系管理员)");
                        ck = 1;
                        break;
                    default:
                        tip = ("未知错误！(若忘记用户名或密码，请联系管理员)");
                        break;
                }
                Distinguish.LoginMess(tip);

            }
            if (ck == 1)
            {
                SelectLoginBLL SLBLL = new SelectLoginBLL();
                DataTable dt = SLBLL.SelectName(name, password);
                Session["userName"] = name;
                Session["ID"] = dt.Rows[0].ItemArray[0];
                Session["txtUser"] = name;
                Session["quan"] = null;
                ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
                //smm.sendSession(name);               //session 共享，在bll层ShowManagersMessagesBLL
                List<Managers> listm = smm.selectM();
                List<SuperManagers> listsm = smm.selectSM();

                if (listsm.Exists(p => p.UserName == name))
                {
                    Session["quan"] = "sm";
                }
                else if (listsm.Exists(r => r.UserName == name))
                {
                    Session["quan"] = "m";
                    Session["quan"] = new Guid();
                }
                else
                {
                }
                Response.Redirect("Fore-endWEB/Indexs.aspx");
            }

        }
    }
}