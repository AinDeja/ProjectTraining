using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSBBS.Admin
{
    public partial class EditAdminMess : System.Web.UI.Page
    {
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected void Page_Load(object sender, EventArgs e)
        {

            Distinguish.CheckAdminLogin();
            Server.Execute("Head.aspx");
            if (Request.HttpMethod.ToLower() == "post")
            {
                string adminName = Context.Request["adminName"];
                string adminPassword = Context.Request["adminPassword"];

                SqlHelper.ExecuteDataTable("update DS_Admin set  AdminName=@Name,AdminPassword=@userPassword where id=@id", new SqlParameter("@Name", adminName), new SqlParameter("@userPassword", adminPassword), new SqlParameter("@id", Session["userId"]));
                Response.Redirect("/Admin/EditAdmin.aspx");
            }
            else
            {

                //if (Session["userId"] == null && Context.Request["newE"] == "1")
                //{
                    Session["userId"] = Context.Request["userId"];
                //}

                DataTable uname = SqlHelper.ExecuteDataTable("select*from DS_Admin  where  id=@id", new SqlParameter("@id", Session["userId"]));
                DataRow un = uname.Rows[0];

                tTr.Append("<tr><td>用户账户</td><td><input type='text' name='adminName' value='" + un["AdminName"] + "'/></td></tr><tr><td>用户密码</td><td><input type='text' name='adminPassword' value='" + un["AdminPassword"] + "'/></td></tr>");




            }
        }
    }
}