using InspirationalWeb.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InspirationalWeb.WebPL.User
{
    public partial class UserCenter1 : System.Web.UI.Page
    {
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder sure = new System.Text.StringBuilder(500);
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckLogin();
            

                string name = (string)Session["Name"];
                string UserPassWord, UserFname, UserEmail, UserAge, UserQQ, UserPhone, UserBirth, UserSex;
                B_User bll = new B_User();
                string[] mess = bll.UserMess(name);
                UserPassWord = mess[1];
                UserSex = mess[2];
                UserAge = mess[3];
                UserBirth = mess[4];
                UserQQ = mess[5];
                UserPhone = mess[6];
                UserEmail = mess[7];
                UserFname = mess[8];

                tTr.Append("<tr><td>账 户:</td><td>" + name + "</td></tr>");
                tTr.Append("<tr><td>昵 称:</td><td>" + UserFname + "</td></tr>");
                tTr.Append("<tr><td>性 别:</td><td>" + UserSex + "</td></tr>");
                tTr.Append("<tr><td>年 龄:</td><td>" + UserAge + "</td></tr>");
                tTr.Append("<tr><td>生 日:</td><td>" + UserBirth + "</td></tr>");
                tTr.Append("<tr><td>Phone:</td><td>" + UserPhone + "</td></tr>");
                tTr.Append("<tr><td>Email:</td><td>" + UserEmail + "</td></tr>");
                tTr.Append("<tr><td>QQ:</td><td>" + UserQQ + "</td></tr>");
                if (Request.HttpMethod.ToLower() == "post")
                {
                   
                    Response.Redirect("UserUpDate.aspx");
                }
            

        }
    }
}