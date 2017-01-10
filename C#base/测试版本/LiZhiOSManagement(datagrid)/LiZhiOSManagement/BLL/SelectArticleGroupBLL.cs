using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class SelectArticleGroupBLL
    {
        public List<ArticleGroup> SelectArticleGroup()
        {
            SelectArticleGroupDAL selectGroup = new SelectArticleGroupDAL();
            //List<ArticleGroup> list = new List<ArticleGroup>();
            return selectGroup.SelectArticleGroup();
        }
        public string SelectArticleRGroup(int group)
        {
            SelectArticleGroupDAL srg = new SelectArticleGroupDAL();
            return srg.SelectArticleRGroup(group);
        }

    }
}