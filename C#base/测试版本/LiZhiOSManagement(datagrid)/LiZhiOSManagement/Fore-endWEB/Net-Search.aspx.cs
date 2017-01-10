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
    public partial class Net_Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = null;
            string kindtype = ".Net";
            string selectMsg = Request.Params["searchMsg"];
            string dcount = Request.Params["count"];
            SelectArticleBLL sabll = new SelectArticleBLL();
            List<Article> list = new List<Article>();
            List<Article> listpagecount = new List<Article>();
            SelectArticleBelongUserBLL selectUser = new SelectArticleBelongUserBLL();
            list = sabll.SelectArticleBySearch(kindtype, selectMsg);
            listpagecount = list;
            if (dcount != null)
            {
                list = (from u in list orderby u.CreateTime descending select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();


            }
            else
            {
                list = (from u in list orderby u.CreateTime descending select u).Skip(5 * (Convert.ToInt32(1) - 1)).Take(5).ToList();
            }
            //List<int> l=new List<int>();
            //foreach (var item in list)
            //{
            //    int index = list.FindIndex(new Predicate<Article>(c => c.Equals(selectMsg)));
            //    string l= list.ToString();
            //    l.Insert(index, "lala" + selectMsg + "lala");

            //}
            foreach (var item in list)
            {

                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser).Replace(selectMsg, "<span style=" + "\"" + "background-color:#FFF000" + "\"" + ">" + selectMsg + "</span>") + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Net-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Net-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";

            }


            //分页栏

            //总页数
            int pageCount = Convert.ToInt32(Math.Ceiling((double)listpagecount.Count / 5));

            if (pageCount >= 1)
            {
                s = s + "<nav style=" + "\"" + "margin:0 auto;width:100%;" + "\"" + "><ul class=" + "\"" + "pagination pagination-lg" + "\"" + "><li><a href=" + "Net-Search.aspx?count=" + "1" + "&searchMsg=" + selectMsg + " aria-label=" + "\"" + "Previous" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&laquo;</span></a></li>";
                string splus = null;
                if (pageCount <= 9)
                {

                    for (int i = 1; i <= pageCount; i++)
                    {
                        splus += "<li><a href=" + "\"" + "Net-Search.aspx?count=" + i + "&searchMsg=" + selectMsg + "\"" + ">" + i + "</a></li>";
                    }
                    s = s + splus;
                }
                else
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        splus += "<li><a href=" + "\"" + "Net-Search.aspx?count=" + i + "&searchMsg=" + selectMsg + "\"" + ">" + i + "</a></li>";
                    }
                    s = s + splus + "<li><a href=" + "\"" + "Net-Search.aspx?count=" + pageCount + "&searchMsg=" + selectMsg + "\"" + " aria-label=" + "\"" + "Next" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&raquo;" + "</span></a></li></ul></nav>";
                }

                this.showArticle.InnerHtml = s;
            }
        }
    }
}