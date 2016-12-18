using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// TableByDatagrid 的摘要说明
    /// </summary>
    public class TableByDatagrid : IHttpHandler
    {
        
        


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
             List<Article> dtall=null;
             List<Article> rows;
             JavaScriptSerializer jss;
       
            string jso;



            string belongkind =context.Request.Params["belongkind"];
            string bysel = context.Request.Params["bysel"].ToString() == null ? null : context.Request.Params["bysel"].ToString();  //限制条件
            string byserch = context.Request.Params["byserch"].ToString() == null ? null : context.Request.Params["byserch"].ToString();  //输入的条件
            int pagenumber = Convert.ToInt32(context.Request["page"]) == 0 ? 1 : Convert.ToInt32(context.Request["page"]);   //页数
            int pageIndex = Convert.ToInt32(context.Request["rows"])==0?10:Convert.ToInt32(context.Request["rows"]);  //行数

            ShowArticleByGroupBLL sabg = new ShowArticleByGroupBLL();
            ShowUsersMessagesBLL sum=new ShowUsersMessagesBLL();
            
                    if(bysel=="ID")
                    {
                        if (byserch == "*")
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.SelectAllArticle();                  //所有文章
                            }
                            else
                            {
                                dtall = sabg.SelectAllArticle().Where(r => r.BelongKind == belongkind).ToList();
                            }
                                
                        }
                        else
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.ShowArticleById(Convert.ToInt32(byserch));
                            }
                            else
                            {
                                dtall = sabg.ShowArticleById(Convert.ToInt32(byserch)).Where(r=>r.BelongKind==belongkind).ToList();
                            }
                            
                            pageIndex=10;

                        }
                    }
                        
                    else if(bysel=="IsDelete")
                    {
                        if (byserch == "*")
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.SelectAllArticle();
                            }
                            else
                            {
                                dtall = sabg.SelectAllArticle().Where(r=>r.BelongKind==belongkind).ToList();
                            }
                            
                        }
                        else
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.ShowArticleByIsDelete("%" + byserch + "%");
                            }
                            else
                            {
                                dtall = sabg.ShowArticleByIsDelete("%" + byserch + "%").Where(r=>r.BelongKind==belongkind).ToList();
                            }
                                
                        }
                        
                    }
                        
                    else if(bysel=="CreateTime")                            //需要改
                    {
                        if (byserch == "*")
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.SelectAllArticle();
                            }
                            else
                            {
                                dtall = sabg.SelectAllArticle().Where(r=>r.BelongKind==belongkind).ToList();
                            }
                            
                        }
                        else
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.ShowArticleByCreattime(byserch);
                            }
                            else
                            {
                                dtall = sabg.ShowArticleByCreattime(byserch).Where(r=>r.BelongKind==belongkind).ToList();
                            }
                        }
                    }
                    else if (bysel == "BelongKind")
                    {
                        if (byserch == "*")
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.SelectAllArticle();
                            }
                            else
                            {
                                dtall = sabg.SelectAllArticle().Where(r=>r.BelongKind==belongkind).ToList();
                            }
                        }
                        else
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.ShowArticleByBelongkind("%" + byserch + "%");
                            }
                            else
                            {
                                dtall = sabg.ShowArticleByBelongkind("%" + byserch + "%").Where(r=>r.BelongKind==belongkind).ToList();
                            }
                            
                        }
                    }
                    else if (bysel == "Title")
                    {
                        if (byserch == "*")
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.SelectAllArticle();
                            }
                            else
                            {
                                dtall = sabg.SelectAllArticle().Where(r=>r.BelongKind==belongkind).ToList();
                            }
                            
                        }
                        else
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.ShowArticleByTitle("%" + byserch + "%");
                            }
                            else
                            {
                                dtall = sabg.ShowArticleByTitle("%" + byserch + "%").Where(r=>r.BelongKind==belongkind).ToList();
                            }
                        }
                    }
                    else if (bysel == "Content")
                    {
                        if (byserch == "*")
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.SelectAllArticle();
                            }
                            else
                            {
                                dtall = sabg.SelectAllArticle().Where(r=>r.BelongKind==belongkind).ToList();
                            }
                            
                        }
                        else
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.ShowArticleByContent("%" + byserch + "%");
                            }
                            else
                            {
                                dtall = sabg.ShowArticleByContent("%" + byserch + "%").Where(r=>r.BelongKind==belongkind).ToList();
                            }
                            
                        }
                    }
                    else if (bysel == "BelongUser")                     //需要改
                    {
                        List<Users> list = new List<Users>();                  //模糊查询用户的id
                        list = sum.selectUserNameId("%"+byserch+"%");             //根据姓名模糊查询出的用户id
                        List<Article> listser=new List<Article>();
                        if(belongkind=="All")
                        {
                            
                            foreach (var item in list)
                            {
                                listser.AddRange(sabg.ShowArticleByBelongUser(Convert.ToInt32(item.ID)));      //所有
                            }
                            dtall = listser;
                        }
                        else
                        {
                            foreach (var item in list)
                            {
                                listser.AddRange(sabg.ShowArticleByBelongUser(Convert.ToInt32(item.ID)));      //所有
                            }
                            dtall = listser.Where(r=>r.BelongKind==belongkind).ToList();
                        }
                        
                    }
                    else if (bysel == "BelongKind_Type")
                    {
                        if (byserch == "*")
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.SelectAllArticle();
                            }
                            else
                            {
                                dtall = sabg.SelectAllArticle().Where(r => r.BelongKind == belongkind).ToList() ;
                            }
                            
                        }
                        else
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.ShowArticleByeongKind_type("%" + byserch + "%");
                            }
                            else
                            {
                                dtall = sabg.ShowArticleByeongKind_type("%" + byserch + "%").Where(r=>r.BelongKind==belongkind).ToList();
                            }
                            
                        }
                    }
                    else if (bysel == "MostBrowse")
                    {
                        if (byserch == "*")
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.SelectAllArticle();
                            }else
                            {
                                dtall = sabg.SelectAllArticle().Where(r=>r.BelongKind==belongkind).ToList();
                            }
                            
                        }
                        else
                        {
                            if(belongkind=="All")
                            {
                                dtall = sabg.ShowArticleByMostBrowse(Convert.ToInt32(byserch));
                            }
                            else
                            {
                                dtall = sabg.ShowArticleByMostBrowse(Convert.ToInt32(byserch)).Where(r=>r.BelongKind==belongkind).ToList();
                            }
                            
                        }
                     }
                    else
                    {

                    }
            rows = (from u in dtall orderby u.ID descending select u).Skip(pageIndex * (pagenumber - 1)).Take(pageIndex).ToList();
            int total = dtall.Count();
            
            
            foreach (var item in rows)
            {
                item.Author = sum.showUserName(item.BelongUser);     //T_Title表中人名（int）  转换成（string）
            }
            jss = new JavaScriptSerializer();
            jso = jss.Serialize(rows);
            string json = "{\"total\":" + total + ",\"rows\":" + jso + "}";
            
            
            context.Response.Write(json);
            context.Response.End();
            //List<Article> dtall = null;
            //List<Article> rows;
            
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