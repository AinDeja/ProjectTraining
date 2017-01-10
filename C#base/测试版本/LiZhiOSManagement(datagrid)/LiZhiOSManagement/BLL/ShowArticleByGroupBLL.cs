
using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    
    public class ShowArticleByGroupBLL
    {
        ShowArticleByGroupDAL sabg = new ShowArticleByGroupDAL();
        public List<Article> SelectAllArticle()
        {
            return sabg.SelectAllArticle();
        }
        public List<Article> ShowArticleBy(string belongKind)
        {
            return sabg.ShowArticleBy(belongKind);
        }
        public List<Article> ShowArticleByBelongkind(string belongKind)
        {
            return sabg.ShowArticleByBelongkind(belongKind);
        }

        public List<Article> ShowArticleById(int id)
        {
            return sabg.ShowArticleById(id);
        }
        public List<Article> ShowArticleByIsDelete(string isdelete)
        {
            return sabg.ShowArticleByIsDelete(isdelete);
        }
        public List<Article> ShowArticleByCreattime(string dt)
        {
            return sabg.ShowArticleByCreattime(dt);
        }
        public List<Article> ShowArticleByTitle(string title)
        {
            return sabg.ShowArticleByTitle(title);
        }
        public List<Article> ShowArticleByContent(string content)
        {
            return sabg.ShowArticleByContent(content);
        }
        public List<Article> ShowArticleByBelongUser(int uid)
        {
            return sabg.ShowArticleByBelongUser(uid);
        }
        public List<Article> ShowArticleByeongKind_type(string belongkind_type)
        {
            return sabg.ShowArticleByeongKind_type(belongkind_type);
        }
        public List<Article> ShowArticleByMostBrowse(int mostbrowse)
        {
            return sabg.ShowArticleByMostBrowse(mostbrowse);
        }



        //文章饼图嵌套       //内环
        public List<BelongKindCount> showBKandCount()
        {
            return sabg.showBKandCount();
        }


        //文章饼图嵌套      //外环
        public List<BelongKindCount> showBKandBelongUserCount()
        {
            return sabg.showBKandBelongUserCount();
        }
    }
}