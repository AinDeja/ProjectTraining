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
    public partial class PostView : System.Web.UI.Page
    {
       protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
       protected object PostType;
       protected int pageNumber;
       protected int pageMax;
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.Execute("Head.aspx");


            int pt = Convert.ToInt32(Context.Request["postType"]);
            PostType = pt;//获取贴子类型
            Session["postType"] = pt;

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





            if (Request.HttpMethod.ToLower()=="post")
            {
               string postSerchText= Context.Request["serchText"];
               DataTable postSerch = SqlHelper.ExecuteDataTable("select*from DS_Post where PostTitle like'%"+postSerchText+"%' order by id");
               DataTable userList = SqlHelper.ExecuteDataTable(@"
                     ;WITH userOrder AS
(SELECT ROW_NUMBER() OVER (ORDER BY id) RowNumber,*FROM DS_Post where PostTitle like'%" + postSerchText + "')SELECT * FROM userOrder WHERE RowNumber BETWEEN @star AND @end", new SqlParameter("@Star", (pageNumber - 1) * 10 + 1),
                             new SqlParameter("@End", pageNumber * 10));
                foreach (DataRow dr in postSerch.Rows)
                {
                    tTr.Append("<tr class='mtr' onclick=\"turnto('PostView.aspx?postPage=" + dr["id"] + "')\">");
                    tTr.Append("<td>" + dr["PostName"] + "</td>");
                    tTr.Append("<td>" + dr["PostTitle"] + "</td>");
                    tTr.Append("<td>" + dr["PostDate"] + "</td>");
                    //tTr.Append("<td style='width:300px'>" + dr["PostTheme"] + "</td>");
                    tTr.AppendLine("</tr>");
                }
            }
            else
            {
                    
            
            

           
            DataTable userList = SqlHelper.ExecuteDataTable(@"
                     ;WITH userOrder AS
(SELECT ROW_NUMBER() OVER (ORDER BY id) RowNumber,*FROM DS_Post where PostType="+pt+")SELECT * FROM userOrder WHERE RowNumber BETWEEN @star AND @end", new SqlParameter("@Star", (pageNumber - 1) * 10 + 1),
                               new SqlParameter("@End", pageNumber * 10));
            //DataTable postLists = SqlHelper.ExecuteDataTable("select*from DS_Post where PostType=" + pt + " order by id");
            foreach (DataRow dr in userList.Rows)
            {
                string pd = String.Format("{0:yyyy/MM/dd}", dr["PostDate"]);//格式化时间
                //string themes = dr["PostTheme"].ToString();
                //string the = themes.Substring(1);
                tTr.Append("<tr class='mtr' onclick=\"turnto('PostView.aspx?postPage="+dr["id"]+"')\">");
                 
                    tTr.Append("<td>" + dr["PostName"] + "</td>");
                tTr.Append("<td>" + dr["PostTitle"] + "</td>");
                tTr.Append("<td>" + pd + "</td>");
                //tTr.Append("<td>" + dr["PostTheme"] + "</td>");
                tTr.AppendLine("</tr>");
            }
            }
        }

    }
}