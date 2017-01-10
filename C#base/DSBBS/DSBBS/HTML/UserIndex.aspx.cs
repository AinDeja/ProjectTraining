using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSBBS.HTML
{
    public partial class UserIndex : System.Web.UI.Page
    {
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected object PostType;
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.Execute("Head.aspx");
            //板块展示
            int i = 5;
            DataTable postSerch = SqlHelper.ExecuteDataTable("select*from DS_PostType order by id");
            foreach (DataRow dr in postSerch.Rows)
            {
                if (i % 4 == 1)
                {
                    tTr.Append("<tr>");
                }

                tTr.Append("<td><div class='postType' onclick=\"turnto('/HTML/PostList.aspx?postType=" + dr["id"] + "')\">" + dr["PostClass"] + "</div></td>");
                if (i / 4 == 0)
                {
                    tTr.Append("</tr>");
                }
                i++;
            }
        }
    }
}