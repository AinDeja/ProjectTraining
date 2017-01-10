using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class SelectArticleGroupTypeBLL
    {
        public List<ArticleGroupType> SelectArticleType(int ID)
        {
            SelectArticleGroupTypeDAL sagt = new SelectArticleGroupTypeDAL();
            return sagt.SelectArticleType(ID);
        }
        public string SelectArticleRType(int articleType)
        {
            SelectArticleGroupTypeDAL asgtdal = new SelectArticleGroupTypeDAL();
            return asgtdal.SelectArticleRType(articleType);
        }
    }
}