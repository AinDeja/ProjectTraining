using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class SelectArticleBLL
    {
        public List<Article> SelectArticle()
        {
            SelectArticleDAL selectArticle = new SelectArticleDAL();
            return selectArticle.SelectArticle();
        }

        public List<Article> ShowFy(int count, string belongkind)
        {
            SelectArticleDAL showFy = new SelectArticleDAL();
            return showFy.ShowFy(count, belongkind);
        }
        //sql分页
        public List<Article> ShowFyByLeftClass(int count, string belongkind_type)
        {
            SelectArticleDAL showFyByLeftClass = new SelectArticleDAL();
            return showFyByLeftClass.ShowFyByLeftClass(count, belongkind_type);
        }

        //list分页
        public List<Article> ShowFyByBelongkind_type(string belongkind, string belongkind_type)
        {
            SelectArticleDAL showFyByBelongkind_type = new SelectArticleDAL();
            return showFyByBelongkind_type.ShowFyByBelongkind_type(belongkind, belongkind_type);
        }
        public List<Article> ShowFyByHour(string belong_kind)
        {
            SelectArticleDAL showFyByHour = new SelectArticleDAL();
            return showFyByHour.ShowFyByHour(belong_kind);
        }
        public List<Article> ShowFyByWeek(string belong_kind)
        {
            SelectArticleDAL showFyByWeek = new SelectArticleDAL();
            return showFyByWeek.ShowFyByWeek(belong_kind);
        }
        public List<Article> ShowFyByMonth(string belong_kind)
        {
            SelectArticleDAL showFyByMonth = new SelectArticleDAL();
            return showFyByMonth.ShowFyByMonth(belong_kind);
        }
        public List<Article> ShowFyByYear(string belong_kind)
        {
            SelectArticleDAL showFyByYear = new SelectArticleDAL();
            return showFyByYear.ShowFyByYear(belong_kind);
        }
        public List<Article> SelectArticleById(int id)
        {
            SelectArticleDAL sbyid = new SelectArticleDAL();
            return sbyid.SelectArticleById(id);
        }

        public List<Article> selectKindsArticle(string articletype)
        {
            SelectArticleDAL sa = new SelectArticleDAL();
            return sa.selectKindsArticle(articletype);
        }

        public List<Messages> SelectArticleByComment(string grouptype)
        {
            SelectArticleDAL sa = new SelectArticleDAL();
            return sa.SelectArticleByComment(grouptype);
        }

        public List<EnjoyArticle> SelectArticleByFavorite(string kind_type)
        {
            SelectArticleDAL selectArticleByFavorite = new SelectArticleDAL();
            return selectArticleByFavorite.SelectArticleByFavorite(kind_type);
        }
        public List<Article> SelectArticleByWatch(int count, string belongkind)
        {
            SelectArticleDAL sad = new SelectArticleDAL();
            return sad.SelectArticleByWatch(count, belongkind);
        }

        public List<Article> SelectArticleBySearch(string kindtype, string searchbydata)
        {
            SelectArticleDAL sad = new SelectArticleDAL();
            return sad.SelectArticleBySearch(kindtype, searchbydata);
        }
    }
}