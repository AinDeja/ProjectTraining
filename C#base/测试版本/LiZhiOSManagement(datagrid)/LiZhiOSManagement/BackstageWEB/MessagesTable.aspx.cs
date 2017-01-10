using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiZhiOSManagement.WEB
{
    public partial class MessagesTable : System.Web.UI.Page
    {
        protected List<Article> dt;
        protected List<Article> dtall;
        protected JavaScriptSerializer jss;
        protected string jso;
        protected void Page_Load(object sender, EventArgs e)
        {
            //ShowArticleByGroupBLL sabg = new ShowArticleByGroupBLL();
            //dt = sabg.ShowArticleBy(null,0);
            //dtall = sabg.SelectAllArticle();
            //string belongkind = Request.Params["belongkind"];
            //if(belongkind!=null)
            //{
            //    //Response.Write("<script>$('#tt').datagrid('reload',{belongkind:"+belongkind+"});</script>");
            //    Response.Write("<script>$('#tt').css('belongkind'," + belongkind + ");</script>");
            //}
            

            //jss = new JavaScriptSerializer();
            //jso = jss.Serialize(dt);
            
        }
    }
}