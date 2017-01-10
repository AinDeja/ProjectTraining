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
    public partial class ApostEdit : System.Web.UI.Page
    {
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected int pageNumber;
        protected int pageMax;
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckLogin();
            Server.Execute("Head.aspx");

            if (Request.HttpMethod.ToLower() == "post")
            {
                string strBoth = Context.Request.Form["chkId"];
                if (string.IsNullOrEmpty(strBoth))
                {
                    Response.Redirect("/Admin/ApostEdit.aspx");
                }
                else
                {
                    SqlHelper.ExecuteDataTable("delete from DS_Post where id in(" + strBoth + ") ");
                    Response.Redirect("/Admin/ApostEdit.aspx");
                }
            }


             string id = Context.Request["id"];
            string del = Context.Request["del"];
            if (id!=null&&del=="1")//判断是否执行删除操作
            {
                SqlHelper.ExecuteDataTable("delete from DS_Post where id=@id",new SqlParameter("@id",id));
            }
            //判断最大页数
            DataTable postList = SqlHelper.ExecuteDataTable("select*from DS_User order by id");
            int pageRemainder = (postList.Rows.Count) % 10;

            if (pageRemainder > 0)
            {
                pageMax = ((postList.Rows.Count) / 10) + 1;
            }
            else
            {
                pageMax = (postList.Rows.Count) / 10;
            }

            //首尾页上下页跳转判断
            if (Context.Request["trpage"] == null)
            {
                pageNumber = 1;
            }
            else
            {
                pageNumber = Int32.Parse(Context.Request["trpage"]);
                if (pageNumber > pageMax)
                {
                    pageNumber = pageMax;
                }
                else
                {
                    if (pageNumber <= 0)
                    {
                        pageNumber = 1;
                    }
                    else
                    {
                        pageNumber = Int32.Parse(Context.Request["trpage"]); //Context.Request["trpage"]; ;
                    }

                }

            }

            DataTable userList = SqlHelper.ExecuteDataTable(@"
                     ;WITH userOrder AS
(SELECT ROW_NUMBER() OVER (ORDER BY id) RowNumber,*FROM DS_Post)
SELECT * FROM userOrder WHERE RowNumber BETWEEN @star AND @end", new SqlParameter("@Star", (pageNumber - 1) * 10 + 1),
                                     new SqlParameter("@End", pageNumber * 10));
                foreach (DataRow dr in userList.Rows)
                {
                    string pd = String.Format("{0:yyyy/MM/dd}", dr["PostDate"]);//格式化时间
                    tTr.Append("<tr class='mtr' >");
                    tTr.Append("<td><input type='checkbox' value='" + dr["id"] + "' name='chkId'/></td>");
                    tTr.Append("<td>" + dr["PostName"] + "</td>");
                    tTr.Append("<td>" + dr["PostTitle"] + "</td>");
                    tTr.Append("<td>" + pd + "</td>");
                    //tTr.Append("<td style='width:300px'>" + dr["PostTheme"] + "</td>");
                    tTr.Append("<td><a href='javascript:void(0)'onclick=\"turnto('/HTML/PostView.aspx?userId=" + dr["id"] + "')\">查看</a> | ");
                    tTr.Append("<a href='javascript:void(0)' onclick='doDel(" + dr["id"] + ")'>删除</a></td>");
                    tTr.AppendLine("</tr>");
                }
            //}
        }

    }
}



//            DataTable postList = SqlHelper.ExecuteDataTable("select*from DS_Post order by id");

//            foreach (DataRow dr in postList.Rows)
//            {
//                tTr.Append("<tr class='mtr' onclick=\"turnto('PostView.aspx?postPage=" + dr["id"] + "')\">");
//                tTr.Append("<td>" + dr["PostName"] + "</td>");
//                tTr.Append("<td>" + dr["PostTitle"] + "</td>");
//                tTr.Append("<td>" + dr["PostDate"] + "</td>");
//                tTr.Append("<td style='width:300px'>" + dr["PostTheme"] + "</td>");
//                tTr.AppendLine("</tr>");
//            }
//        }
//    }
//}