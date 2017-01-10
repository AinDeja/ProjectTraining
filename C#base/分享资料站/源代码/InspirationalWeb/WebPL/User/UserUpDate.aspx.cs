using InspirationalWeb.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InspirationalWeb.WebPL.User
{
    public partial class UserUpDate : System.Web.UI.Page
    {
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckLogin();
            string name = (string)Session["Name"];
            //string UserPassWord, UserFname, UserEmail, Sex;
            //int UserAge;
            //Int64 UserQQ , UserPhone;
            //DateTime UserBirth ;
            string UserPassWord, UserFname, UserEmail, UserAge, UserQQ, UserPhone, UserBirth, UserSex;

            B_User bll = new B_User();
            string[] mess = bll.UserMess(name);
            UserPassWord = mess[1];
            UserSex = mess[2];
            UserAge = mess[3];
            UserBirth = mess[4];
            
            UserQQ =mess[5];
            UserPhone = mess[6];
            UserEmail = mess[7];
            UserFname = mess[8];

     tTr.Append(" <tr><td>密 码：</td><td><input type='password' class='text' name='UserPassWord' value='"+UserPassWord+"' /></td></tr>");
     tTr.Append("  <tr><td>昵 称：</td><td><input type='text' class='text' name='UserFname'       value='"+UserFname+"'/></td></tr>");
     tTr.Append("  <tr><td>性 别：</td><td><input type='text' class='text' name='UserSex'         value='" + UserSex + "'/></td></tr>   ");
     tTr.Append(" <tr><td>年 龄：</td><td><input type='text' class='text' name='UserAge'          value='"+UserAge+"' /></td></tr>   ");
     tTr.Append("<tr><td>生 日：</td><td><input type='text' class='text' name='UserBirth'         value='"+UserBirth+"'/></td> </tr>  ");
     tTr.Append(" <tr><td>电 话：</td><td><input type='text' class='text' name='UserPhone'        value='"+UserPhone+"'/></td> </tr> ");
     tTr.Append("<tr><td>邮 箱：</td><td><input type='text' class='text' name='UserEmail'         value='"+UserEmail+"'/></td></tr>  ");
     tTr.Append("<tr><td>QQ：</td><td><input type='text' class='text' name='UserQQ'               value='"+UserQQ+"'  /></td></tr>         ");
        
        
        
            if (Request.HttpMethod.ToLower() == "post")
            {
                
                int userAge;
                Int64 userQQ, userPhone;
                DateTime userBirth;
                string userSex;
                UserPassWord = Context.Request["UserPassWord"]; UserFname = Context.Request["UserFname"]; UserEmail = Context.Request["UserEmail"]; userSex = Context.Request["UserSex"];
                userAge = int.Parse(Context.Request["UserAge"]);
                userQQ = Int64.Parse(Context.Request["UserQQ"]); userPhone = Int64.Parse(Context.Request["UserPhone"]);
                userBirth = DateTime.Parse(Context.Request["UserBirth"]);
                B_User up = new B_User();
                up.UserUpDate(name, UserPassWord, userSex, UserFname, UserEmail, userAge, userQQ, userPhone, userBirth);
                Response.Redirect("UserCenter.aspx");
            }

        }
    }
}