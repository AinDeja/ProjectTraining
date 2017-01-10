using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSBBS.HTML
{
    public partial class UserMess : System.Web.UI.Page
    {
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckLogin();
            Server.Execute("Head.aspx");
           
            if (Request.HttpMethod.ToLower() == "post")
            {
                string Rname = Context.Request["Rname"];
               string Pname = Context.Request["Pname"];
               string gender = Context.Request["sex"];
               string age = Context.Request["age"];
               string email = Context.Request["email"];
               string phone = Context.Request["phone"];
               string qq = Context.Request["qq"];
               DateTime bir =DateTime.Parse( Context.Request["bir"]);

            

               if (Distinguish.isNumber(age) == false || Distinguish.isNumber(phone) == false || Distinguish.isNumber(qq) == false)
               {
                     Context.Response.Write("<script language=javascript>alert('请正确完整输入信息！');window.location='/HTML/UserMess.aspx'</script>");
                     return;
               }

               SqlHelper.ExecuteDataTable("update DS_User set RealName=@RealName,PetName=@PetName,Gender=@Gender,Age=@Age,Email=@Email,Phone=@Phone,QQ=@QQ,Birthday=@Birthday where UserName=@username", new SqlParameter("@RealName", Rname), new SqlParameter("@PetName", Pname), new SqlParameter("@Gender", gender), new SqlParameter("@Age", age), new SqlParameter("@Email", email), new SqlParameter("@Phone", phone), new SqlParameter("@QQ", qq), new SqlParameter("@Birthday", bir), new SqlParameter("@username", Session["Name"]));
               Response.Redirect("UserMess.aspx");
            }
            else
            {

            if (Session["Name"]!=null)
            {
                string uName = Session["Name"].ToString();
                DataTable uname = SqlHelper.ExecuteDataTable("select*from DS_User  where  UserName=@name", new SqlParameter("@name", uName));
                DataRow un = uname.Rows[0];
                string birday = String.Format("{0:yyyy-MM-dd}", un["Birthday"]);//格式化时间
                //string gender;
                string checked1 = "", checked0 = "";
                if (birday==""||birday==null)
                {
                    birday = "yyyy/MM/dd";
                }
                if (un["Gender"].ToString()=="True")
                {
                  checked1 = "checked";
                }
                else
                {
                  checked0 = "checked";
                }

                tTr.Append("<tr><td>真实姓名</td><td><input type='text' name='Rname' value='" + un["RealName"] + "'/></td></tr><tr><td>昵称</td><td><input type='text' name='Pname' value='" + un["PetName"] + "'/></td></tr><tr><td>性别</td><td><input type='radio' name='sex' value='1' " + checked1 + " />男<input type='radio' name='sex' value='0'" + checked0 + " />女</td></tr><tr><td>年龄</td><td><input type='text' name='age' value='" + un["Age"] + "'/></td></tr><tr><td>邮箱</td><td><input type='text' name='email' value='" + un["Email"] + "'/></td></tr><tr><td>电话</td><td><input type='text' name='phone' value='" + un["Phone"] + "'/></td></tr><tr><td>QQ</td><td><input type='text' name='qq' value='" + un["QQ"] + "'/></td></tr><tr><td>生日</td><td><input type='date' name='bir' value='" + birday + "'/></td></tr>");

                
            }

            }
            

        }
    }
}