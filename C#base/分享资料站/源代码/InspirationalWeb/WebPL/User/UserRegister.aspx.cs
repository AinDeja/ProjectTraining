using InspirationalWeb.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InspirationalWeb.WebPL.User
{
    public partial class UserCenter : System.Web.UI.Page
    {
        
        string tip;
        protected void Page_Load(object sender, EventArgs e)
        { 

            string name = Context.Request["username"];
            string password = Context.Request["userpassword"];
            if (Request.HttpMethod.ToLower() == "post")
            {
                B_User bll = new B_User();
                int check=bll.Register(name,password);
                switch(check)
                {
                    case 1: tip = "注册成功!";
                        break;
                    case 0: tip = "用户名已存在!";
                        break;
                    case 2: tip = "请输入正确的用户名和密码！";
                        break;
                    default: tip = "系统错误";
                        break;

                }
                Distinguish.RegisterMess(tip);
                
            }
            if (tip == "注册成功!")
            Response.Redirect("Login.aspx");
        }
    }
}