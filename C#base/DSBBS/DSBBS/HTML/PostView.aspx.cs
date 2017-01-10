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
    public partial class PostView1 : System.Web.UI.Page
    {
        protected string pTitle,pTheme,pName,pDate;
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.Execute("Head.aspx");
            if (Context.Request["userId"]!=null)
            {
                Session["PostPage"] = Context.Request["userId"];
            }
            else
            {
                Session["PostPage"] = Context.Request["postPage"];
            }
            
            if (Session["PostPage"]!=null)
            {
                DataTable pv = SqlHelper.ExecuteDataTable("select*from DS_Post where id=@id", new SqlParameter("@id", Session["PostPage"]));
                DataRow postview = pv.Rows[0];
                pTitle = postview["PostTitle"].ToString();
                pTheme = postview["PostTheme"].ToString();
                pName = postview["PostName"].ToString();
                pDate = postview["PostDate"].ToString();


                //读取回复
                DataTable postList = SqlHelper.ExecuteDataTable("select*from DS_Reply where PostId=@pid order by ReplyDate", new SqlParameter("@pid", Session["PostPage"]));
                int i = 2;
                foreach (DataRow dr in postList.Rows)
                {

                    //tTr.Append("<tr>");
                    //tTr.Append("<td>" + dr["ReplyName"] + "</td>");
                    //tTr.Append("<td>" + dr["ReplyDate"] + "</td>");
                    //tTr.Append("<td>" + dr["ReplyText"] + "</td>");
                    //tTr.AppendLine("</tr>");
                    tTr.Append("<tr><td><div id='box1'><div id='leftname'>" + dr["ReplyName"] + "</div>");
                    tTr.Append("<div id='datefloor'><div style='height:32px'>" + dr["ReplyDate"] + "<span style='float:right;margin-right:10px;'>#" + i + "</span></div>");
                    tTr.Append("<div id='textbox'>" + dr["ReplyText"] + "</div><div id='reply'><input type='button' value='回复' onclick=\"turnto('/HTML/PostReply.aspx')\" style='float:right;margin-top:5px;' /></div></div></div></td></tr>");
                    i++;
                }

            }
            
        }
    }
}