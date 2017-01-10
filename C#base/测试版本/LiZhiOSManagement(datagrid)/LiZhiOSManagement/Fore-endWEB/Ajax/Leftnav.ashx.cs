using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.Fore_endWEB.Ajax
{
    /// <summary>
    /// Leftnav 的摘要说明
    /// </summary>
    public class Leftnav : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<Article> list = new List<Article>();
            SelectArticleBLL sa = new SelectArticleBLL();

            SelectArticleBelongUserBLL selectUser = new SelectArticleBelongUserBLL();
            string dcount = (context.Request.Params["count"] != null) ? (context.Request.Params["count"]) : null;  //第几页
            string s = null;
            int count = 0;//总页数
            string kind_type = context.Request.Params["kind_type"].ToString();  //Android、.Net、Front-end
            if (kind_type != "null" && (!kind_type.Equals("")))
            {
                #region 小时
                if (context.Request.Params["selectArticleById"].ToString() == "hour")
                {
                    list = sa.ShowFyByHour(kind_type);

                    count = list.Count;

                    list = (from u in list orderby u.CreateTime descending select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();  //按时间降序排列
                    //第几页
                    foreach (var item in list)
                    {
                        s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                    }

                    //int pageCount = Convert.ToInt32(Math.Ceiling((double)selectArticleCount.SelectArticleCount() / 5));
                    int pageCount = Convert.ToInt32(Math.Ceiling((double)count / 5));

                    if (pageCount >= 1)
                    {
                        s = s + "<nav style=" + "\"" + "margin:0 auto;width:100%;" + "\"" + "><ul class=" + "\"" + "pagination pagination-lg" + "\"" + "><li><a href=" + "Leftnav.ashx?count=" + "1" + " aria-label=" + "\"" + "Previous" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&laquo;</span></a></li>";
                        string splus = null;
                        if (pageCount <= 9)
                        {

                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "hour" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus;
                        }
                        else
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "hour" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus + "<li><a href=" + "\"" + "Leftnav.ashx?count=" + pageCount + "\"" + " aria-label=" + "\"" + "Next" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&raquo;" + "</span></a></li></ul></nav>";
                        }
                    }


                }
                #endregion
                #region 周
                else if (context.Request.Params["selectArticleById"].ToString() == "week")
                {

                    list = sa.ShowFyByWeek(kind_type);
                    count = list.Count;
                    list = (from u in list orderby u.CreateTime descending select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();

                    foreach (var item in list)
                    {


                        s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                    }
                    //分页栏
                    int pageCount = Convert.ToInt32(Math.Ceiling((double)count / 5));
                    if (pageCount >= 1)
                    {
                        s = s + "<nav style=" + "\"" + "margin:0 auto;width:100%;" + "\"" + "><ul class=" + "\"" + "pagination pagination-lg" + "\"" + "><li><a href=" + "Leftnav.ashx?count=" + "1" + " aria-label=" + "\"" + "Previous" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&laquo;</span></a></li>";
                        string splus = null;
                        if (pageCount <= 9)
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "week" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus;
                        }
                        else
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "week" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus + "<li><a href=" + "\"" + "Leftnav.ashx?count=" + pageCount + "\"" + " aria-label=" + "\"" + "Next" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&raquo;" + "</span></a></li></ul></nav>";
                        }
                    }
                }
                #endregion
                #region 月
                else if (context.Request.Params["selectArticleById"].ToString() == "month")
                {
                    list = sa.ShowFyByMonth(kind_type);
                    count = list.Count;
                    list = (from u in list orderby u.CreateTime descending select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();
                    foreach (var item in list)
                    {
                        s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                    }
                    //分页栏
                    int pageCount = Convert.ToInt32(Math.Ceiling((double)count / 5));
                    if (pageCount >= 1)
                    {
                        s = s + "<nav style=" + "\"" + "margin:0 auto;width:100%;" + "\"" + "><ul class=" + "\"" + "pagination pagination-lg" + "\"" + "><li><a href=" + "Leftnav.ashx?count=" + "1" + " aria-label=" + "\"" + "Previous" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&laquo;</span></a></li>";
                        string splus = null;
                        if (pageCount <= 9)
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "month" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus;
                        }
                        else
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "month" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus + "<li><a href=" + "\"" + "Leftnav.ashx?count=" + pageCount + "\"" + " aria-label=" + "\"" + "Next" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&raquo;" + "</span></a></li></ul></nav>";
                        }
                    }

                }
                #endregion
                #region  年
                else if (context.Request.Params["selectArticleById"].ToString() == "year")
                {

                    list = sa.ShowFyByYear(kind_type);
                    count = list.Count;
                    list = (from u in list orderby u.CreateTime descending select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();

                    foreach (var item in list)
                    {
                        s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                    }
                    //分页栏
                    int pageCount = Convert.ToInt32(Math.Ceiling((double)count / 5));
                    if (pageCount >= 1)
                    {
                        s = s + "<nav style=" + "\"" + "margin:0 auto;width:100%;" + "\"" + "><ul class=" + "\"" + "pagination pagination-lg" + "\"" + "><li><a href=" + "Leftnav.ashx?count=" + "1" + " aria-label=" + "\"" + "Previous" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&laquo;</span></a></li>";
                        string splus = null;
                        if (pageCount <= 9)
                        {

                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "month" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus;
                        }
                        else
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "month" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus + "<li><a href=" + "\"" + "Leftnav.ashx?count=" + pageCount + "\"" + " aria-label=" + "\"" + "Next" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&raquo;" + "</span></a></li></ul></nav>";
                        }
                    }

                }
                #endregion
                #region 新
                else if (context.Request.Params["selectArticleById"].ToString() == "bynew")
                {
                    list = sa.selectKindsArticle(kind_type);
                    count = list.Count;
                    list = (from u in list orderby u.CreateTime descending select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();
                    foreach (var item in list)
                    {
                        s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                    }
                    //分页栏
                    int pageCount = Convert.ToInt32(Math.Ceiling((double)count / 5));
                    if (pageCount >= 1)
                    {
                        s = s + "<nav style=" + "\"" + "margin:0 auto;width:100%;" + "\"" + "><ul class=" + "\"" + "pagination pagination-lg" + "\"" + "><li><a href=" + "Leftnav.ashx?count=" + "1" + " aria-label=" + "\"" + "Previous" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&laquo;</span></a></li>";
                        string splus = null;
                        if (pageCount <= 9)
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "bynew" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus;
                        }
                        else
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "bynew" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus + "<li><a href=" + "\"" + "Leftnav.ashx?count=" + pageCount + "\"" + " aria-label=" + "\"" + "Next" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&raquo;" + "</span></a></li></ul></nav>";
                        }
                    }
                }
                #endregion
                #region 回复
                else if (context.Request.Params["selectArticleById"].ToString() == "bycomment")
                {
                    List<Messages> listmsg = new List<Messages>();
                    List<Article> listset = new List<Article>();
                    List<Article> listresult = new List<Article>();
                    listset = sa.selectKindsArticle(kind_type);  //包含该组所有的文章

                    listmsg = sa.SelectArticleByComment(kind_type);     //包含所有有评论的文章
                    count = listset.Count;

                    foreach (var item in listmsg)
                    {
                        listresult.Add(listset.Find(c => c.ID == item.ArticleID));  // 包含所有有评论的文章
                        listset.Remove(listset.Find(c => c.ID == item.ArticleID));  //从包含该组所有文章的集合中删除有评论的
                    }

                    int lastpage = Convert.ToInt32(Math.Ceiling((double)listresult.Count / 5));  //有评论的最后一页
                    int losedata = listresult.Count % 5;   //有评论的最后一页的数据条数

                    if (losedata != 0)
                    {
                        if (Convert.ToInt32(dcount) < lastpage)
                        {
                            listresult = (from u in listresult select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();
                            foreach (var item in listresult)
                            {
                                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                            }
                        }
                        else if (Convert.ToInt32(dcount) == lastpage)
                        {
                            listresult = (from u in listresult select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();
                            foreach (var item in listresult)
                            {
                                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                            }
                            List<Article> selectlist = new List<Article>();
                            selectlist = listset.Take(5 - losedata).ToList();
                            foreach (var item in selectlist)
                            {
                                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";

                            }
                            //listset.Remove(listset.Find());
                        }
                        else
                        {
                            //------>在这                          
                            listset.RemoveRange(0, (5 - losedata));
                            int ce = listset.Count();
                            listset = (from u in listset orderby u.CreateTime descending select u).Skip(5 * (Convert.ToInt32(dcount) - 1 - lastpage)).Take(5).ToList();
                            foreach (var item in listset)
                            {
                                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(dcount) <= lastpage)
                        {
                            listresult = (from u in listresult select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();
                            foreach (var item in listresult)
                            {
                                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                            }
                        }
                        else
                        {
                            listset = (from u in listset orderby u.CreateTime descending select u).Skip(5 * (Convert.ToInt32(dcount) - 1 - lastpage)).Take(5).ToList();
                            foreach (var item in listset)
                            {
                                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                            }

                        }
                    }

                    //分页栏
                    int pageCount = Convert.ToInt32(Math.Ceiling((double)count / 5));

                    if (pageCount >= 1)
                    {
                        s = s + "<nav style=" + "\"" + "margin:0 auto;width:100%;" + "\"" + "><ul class=" + "\"" + "pagination pagination-lg" + "\"" + "><li><a href=" + "Leftnav.ashx?count=" + "1" + " aria-label=" + "\"" + "Previous" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&laquo;</span></a></li>";
                        string splus = null;
                        if (pageCount <= 9)
                        {

                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "bycomment" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus;
                        }
                        else
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "bycomment" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus + "<li><a href=" + "\"" + "Leftnav.ashx?count=" + pageCount + "\"" + " aria-label=" + "\"" + "Next" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&raquo;" + "</span></a></li></ul></nav>";
                        }
                    }

                }
                #endregion 喜欢
                #region 喜欢
                else if (context.Request.Params["selectArticleById"].ToString() == "byfavorite")
                {
                    List<EnjoyArticle> listmsg = new List<EnjoyArticle>();
                    List<Article> listset = new List<Article>();
                    List<Article> listresult = new List<Article>();
                    listset = sa.selectKindsArticle(kind_type);  //包含该组所有的文章

                    listmsg = sa.SelectArticleByFavorite(kind_type);     //包含所有有评论的文章
                    count = listset.Count;

                    foreach (var item in listmsg)
                    {
                        listresult.Add(listset.Find(c => c.ID == item.ArticleID));  // 包含所有有评论的文章
                        listset.Remove(listset.Find(c => c.ID == item.ArticleID));  //从包含该组所有文章的集合中删除有评论的
                    }

                    int lastpage = Convert.ToInt32(Math.Ceiling((double)listresult.Count / 5));  //有评论的最后一页
                    int losedata = listresult.Count % 5;   //有评论的最后一页的数据条数

                    if (losedata != 0)
                    {
                        if (Convert.ToInt32(dcount) < lastpage)
                        {
                            listresult = (from u in listresult select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();
                            foreach (var item in listresult)
                            {
                                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                            }
                        }
                        else if (Convert.ToInt32(dcount) == lastpage)
                        {
                            listresult = (from u in listresult select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();
                            foreach (var item in listresult)
                            {
                                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                            }
                            List<Article> selectlist = new List<Article>();
                            selectlist = listset.Take(5 - losedata).ToList();
                            foreach (var item in selectlist)
                            {
                                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";

                            }
                            //listset.Remove(listset.Find());
                        }
                        else
                        {
                            //------>在这                          
                            listset.RemoveRange(0, (5 - losedata));
                            int ce = listset.Count();
                            listset = (from u in listset orderby u.CreateTime descending select u).Skip(5 * (Convert.ToInt32(dcount) - 1 - lastpage)).Take(5).ToList();
                            foreach (var item in listset)
                            {
                                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(dcount) <= lastpage)
                        {
                            listresult = (from u in listresult select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();
                            foreach (var item in listresult)
                            {
                                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                            }
                        }
                        else
                        {
                            listset = (from u in listset orderby u.CreateTime descending select u).Skip(5 * (Convert.ToInt32(dcount) - 1 - lastpage)).Take(5).ToList();
                            foreach (var item in listset)
                            {
                                s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                            }

                        }
                    }

                    //分页栏
                    int pageCount = Convert.ToInt32(Math.Ceiling((double)count / 5));

                    if (pageCount >= 1)
                    {
                        s = s + "<nav style=" + "\"" + "margin:0 auto;width:100%;" + "\"" + "><ul class=" + "\"" + "pagination pagination-lg" + "\"" + "><li><a href=" + "Leftnav.ashx?count=" + "1" + " aria-label=" + "\"" + "Previous" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&laquo;</span></a></li>";
                        string splus = null;
                        if (pageCount <= 9)
                        {

                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "bycomment" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus;
                        }
                        else
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "bycomment" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus + "<li><a href=" + "\"" + "Leftnav.ashx?count=" + pageCount + "\"" + " aria-label=" + "\"" + "Next" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&raquo;" + "</span></a></li></ul></nav>";
                        }
                    }
                }
                #endregion
                #region 浏览
                else if (context.Request.Params["selectArticleById"].ToString() == "bywatch")
                {
                    List<Article> listzong = new List<Article>();
                    listzong = sa.selectKindsArticle(kind_type); ;
                    List<Article> listshow = new List<Article>();
                    listshow = sa.SelectArticleByWatch(Convert.ToInt32(dcount), kind_type);
                    count = listzong.Count;
                    foreach (var item in listshow)
                    {
                        s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                    }
                    //分页栏
                    int pageCount = Convert.ToInt32(Math.Ceiling((double)count / 5));
                    if (pageCount >= 1)
                    {
                        s = s + "<nav style=" + "\"" + "margin:0 auto;width:100%;" + "\"" + "><ul class=" + "\"" + "pagination pagination-lg" + "\"" + "><li><a href=" + "Leftnav.ashx?count=" + "1" + " aria-label=" + "\"" + "Previous" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&laquo;</span></a></li>";
                        string splus = null;
                        if (pageCount <= 9)
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "bywatch" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus;
                        }
                        else
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + "bywatch" + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus + "<li><a href=" + "\"" + "Leftnav.ashx?count=" + pageCount + "\"" + " aria-label=" + "\"" + "Next" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&raquo;" + "</span></a></li></ul></nav>";
                        }
                    }

                }
                #endregion
                #region 组、类
                else
                {
                    string ce = context.Request.Params["selectArticleById"].ToString();
                    list = sa.ShowFyByBelongkind_type(kind_type, context.Request.Params["selectArticleById"].ToString());
                    count = list.Count;
                    list = (from u in list orderby u.CreateTime descending select u).Skip(5 * (Convert.ToInt32(dcount) - 1)).Take(5).ToList();
                    foreach (var item in list)
                    {
                        s += "<article id=" + "\"" + "62" + "\"" + " class=" + "\"" + "post" + "\"" + "><div class=" + "\"" + "post-head" + "\"" + "><h1 class=" + "\"" + "post-title" + "\"" + ">" + item.Title + "</h1><div class=" + "\"" + "post-meta" + "\"" + "><span class=" + "\"" + "author" + "\"" + ">" + "作者：" + selectUser.SelectUser(item.BelongUser) + "</span> " + "·" + "<time class=" + "\"" + "post-date" + "\"" + ">" + item.CreateTime + "</time></div></div><div class=" + "\"" + "featured-media" + "\"" + "></div><div class=" + "\"" + "post-content" + "\"" + ">" + item.Content + "</div><div class=" + "\"" + "post-permalink" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "\"" + " class=" + "\"" + "btn btn-default" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + ">" + "阅读全文" + "</a><div><footer class=" + "\"" + "post-footer clearfix" + "\"" + "><div class=" + "\"" + "pull-left tag-list" + "\"" + "><span class=" + "\"" + "glyphicon glyphicon-tag" + "\"" + "></span><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind + "</a>,<a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.BelongKind_Type + "</a></div><div class=" + "\"" + "comment" + "\"" + "><a href=" + "\"" + "Android-Article.aspx?ID=" + item.ID + "&kind_type=" + item.BelongKind + "#article-comment" + "\"" + " onclick=" + "\"" + "myAjax(" + "this" + ")" + "\"" + " id=" + "\"" + item.ID + "\"" + " count=" + "\"" + Convert.ToInt32(item.MostBrowse) + "\"" + "><span>" + "评论" + "</span><span class=" + "\"" + "glyphicon glyphicon-comment" + "\"" + "></span></a></div><div class=" + "\"" + "pull-right share" + "\"" + "></div></footer></article>";
                    }
                    //分页栏
                    int pageCount = Convert.ToInt32(Math.Ceiling((double)count / 5));
                    if (pageCount >= 1)
                    {
                        s = s + "<nav style=" + "\"" + "margin:0 auto;width:100%;" + "\"" + "><ul class=" + "\"" + "pagination pagination-lg" + "\"" + "><li><a href=" + "Leftnav.ashx?count=" + "1" + " aria-label=" + "\"" + "Previous" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&laquo;</span></a></li>";
                        string splus = null;
                        if (pageCount <= 9)
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + context.Request.Params["selectArticleById"].ToString() + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus;
                        }
                        else
                        {
                            for (int i = 1; i <= pageCount; i++)
                            {
                                splus += "<li class=" + "\"" + "leftnavajax" + "\"" + " pb=" + "\"" + context.Request.Params["selectArticleById"].ToString() + "\"" + " count=" + "\"" + i + "\"" + " kind_type=" + "\"" + kind_type + "\"" + " onclick=" + "\"" + "leftnav(this)" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + i + "</a></li>";
                            }
                            s = s + splus + "<li><a href=" + "\"" + "Leftnav.ashx?count=" + pageCount + "\"" + " aria-label=" + "\"" + "Next" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&raquo;" + "</span></a></li></ul></nav>";
                        }
                    }
                }
                #endregion
            }
            else
            {
                //没有类型的



            }

            context.Response.Write(s);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}