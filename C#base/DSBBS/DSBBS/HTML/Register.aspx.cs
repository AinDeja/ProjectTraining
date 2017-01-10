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
    public partial class Register : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.Execute("Head.aspx");


            if (Request.HttpMethod.ToLower()=="post")

            {
                string name = Context.Request["name"];
                string password = Context.Request["key"];
                string PetName = Context.Request["nc"];
                string Gender = Context.Request["sex"];
                string Age = Context.Request["age"];
                if (Distinguish.isNumber(Age)==false)
                {
                    Context.Response.Write("<script language=javascript>alert('请正确完整输入信息！');window.location='/HTML/Register.aspx'</script>");
                     return;
                }
                if (name!=null&&password!=null)
                {
                    DataTable su = SqlHelper.ExecuteDataTable("Insert into DS_User(UserName,UserPassword,PetName,Gender,Age) values(@UserName,@UserPassword,@PetName,@Gender,@Age)", new SqlParameter("@UserName", name), new SqlParameter("@UserPassword", password), new SqlParameter("@PetName", PetName), new SqlParameter("@Gender", Gender), new SqlParameter("@Age", Age));
                    
                    
                    //if (Distinguish.isNumber(Age) == true)
                    //{
                        
                    //}
                    //else
                    //{
                    //    Context.Response.Write(" 年龄请输入整数！");
                    //}
                    Session["Name"] = name;
                    Response.Redirect("UserIndex.aspx");
                }
                
                
            }
        }
    }
}