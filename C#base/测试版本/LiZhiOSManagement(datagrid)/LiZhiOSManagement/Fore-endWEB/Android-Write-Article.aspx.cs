using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiZhiOSManagement.Fore_endWEB
{
    public partial class Android_Write_Article : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string articleGroup = "<div style=" + "\"" + "float:left;" + "\"" + "><select class=" + "\"" + "form-control" + "\"" + " onchange=" + "\"" + "selectInput(this)" + "\"" + " name=" + "\"" + "classification" + "\"" + " id=" + "\"" + "selectGroup" + "\"" + " runat=" + "\"" + "server" + "\"" + ">";
                SelectArticleGroupBLL selectGroup = new SelectArticleGroupBLL();
                List<ArticleGroup> list = new List<ArticleGroup>();
                list = selectGroup.SelectArticleGroup();
                foreach (var item in list)
                {
                    articleGroup += "<option value=" + "\"" + item.ID + "\"" + ">" + item.BelongGroup + "</option>";
                }
                if (Request.Params["ID"] == null)
                {
                    this.articleGroups.InnerHtml = articleGroup + "</select></div>" + "<div style=" + "\"" + "float:left;margin-left:10px;" + "\"" + "><select class=" + "\"" + "form-control" + "\"" + " name=" + "\"" + "classificationClass" + "\"" + " id=" + "\"" + "select2" + "\"" + "></select></div>";
                }


                if (Request.Params["ID"] != null)
                {
                    string articletype = null;
                    SelectArticleGroupTypeBLL articleType = new SelectArticleGroupTypeBLL();
                    List<ArticleGroupType> list1 = new List<ArticleGroupType>();
                    list1 = articleType.SelectArticleType(Convert.ToInt32(Request.Params["ID"]));
                    string s = "</select>" + "<div style=" + "\"" + "float:left;margin-left:10px;" + "\"" + "><select class=" + "\"" + "form-control" + "\"" + " name=" + "\"" + "classificationClass" + "\"" + " id=" + "\"" + "selectGroup" + "\"" + " runat=" + "\"" + "server" + "\"" + ">";
                    foreach (var item in list1)
                    {
                        articletype += "<option value=" + "\"" + item.ID + "\"" + ">" + item.BelongType + "</option>";
                    }

                    this.articleGroups.InnerHtml = articleGroup + s + articletype + "</select></div>";
                }

                //标题
                string articleTitle = Request.Params["articleTitle"];
                //内容
                string myEditor = Request.Params["myEditor"];
                //第一个select
                string BelongKind = Request.Params["classification"];
                //第二个select
                string BelongKind_type = Request.Params["classificationClass"];
                if ((BelongKind != null) && (!BelongKind.Equals("")) && (articleTitle != null) && (!articleTitle.Equals("")) && (myEditor != null) && (!myEditor.Equals("")))
                {
                    DateTime dt = DateTime.Now;
                    AddArticleBLL ab = new AddArticleBLL();
                    SelectArticleGroupBLL sagb = new SelectArticleGroupBLL();
                    SelectArticleGroupTypeBLL sagt = new SelectArticleGroupTypeBLL();
                    int s = ab.AddArticle(false, dt, sagb.SelectArticleRGroup(Convert.ToInt32(BelongKind)), articleTitle, myEditor, Convert.ToInt32(Session["ID"]), sagt.SelectArticleRType(Convert.ToInt32(BelongKind_type)));
                }
            }
        }
    }
}