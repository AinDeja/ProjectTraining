using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class AddArticleByManagersBLL
    {
        AddArticleByManagersDAL abm = new AddArticleByManagersDAL();
        public int addArticle(bool isdelete, DateTime createtime, string belongkind, string title, string content, int belonguser, string belongkind_type,int mostbrowse)
        {
            return abm.addArticle(isdelete, createtime, belongkind, title, content, belonguser, belongkind_type,mostbrowse);
        }
        public int editArticle(int id,bool isdelete,DateTime createtime,string belongkind,string title,string content,string belonguser,string belongkind_type,int mostbrowse)
        {
            return abm.editArticle(id,isdelete,createtime,belongkind,title,content,belonguser,belongkind_type,mostbrowse);
        }
        
    }
}