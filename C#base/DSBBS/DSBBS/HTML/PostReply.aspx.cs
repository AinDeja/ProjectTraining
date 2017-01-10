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
    public partial class PostReply : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.Execute("Head.aspx");
            string replytext = ckeditReply.Text;
            DateTime postTime = DateTime.Now;
            if (Request.HttpMethod.ToLower()=="post")
            {
                if (Session["Name"] != null)
                {
                    int pid = Convert.ToInt32(Session["postPage"].ToString().Trim());//session转INT
                    DataTable pr = SqlHelper.ExecuteDataTable("Insert into DS_Reply(ReplyName,ReplyText,ReplyDate,PostId) values(@ReplyName,@ReplyText,@ReplyDate,@PostId)", new SqlParameter("@ReplyName", Session["Name"]), new SqlParameter("@ReplyText", replytext), new SqlParameter("@ReplyDate", postTime), new SqlParameter("@PostId", pid));
                    Response.Redirect("PostView.aspx?PostPage=" + Session["PostPage"]);
                }
                else
                {
                    int pid = Convert.ToInt32(Session["postPage"].ToString().Trim());
                    string yc = "游客";
                    DataTable pr = SqlHelper.ExecuteDataTable("Insert into DS_Reply(ReplyName,ReplyText,ReplyDate,PostId) values(@ReplyName,@ReplyText,@ReplyDate,@PostId)", new SqlParameter("@ReplyName", yc), new SqlParameter("@ReplyText", replytext), new SqlParameter("@ReplyDate", postTime), new SqlParameter("@PostId", pid));
                    Response.Redirect("PostView.aspx?PostPage=" + Session["PostPage"]);
                }
            }
            
        }
    }
}