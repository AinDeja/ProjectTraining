using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class AddArticleByManagersDAL
    {
        public int addArticle(bool isdelete,DateTime createtime,string belongkind,string title,string content,int belonguser,string belongkind_type,int mostbrowse)
        {
            string sql = "insert into T_Article(IsDelete,CreateTime,BelongKind,Title,Content,BelongUser,BelongKind_Type,MostBrowse) values(@isdelete,@createtime,@belongkind,@title,@content,@belonguser,@belongkind_type,@mostbrowse)";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@isdelete",isdelete),
                new SqlParameter("@createtime",createtime),
                new SqlParameter("@belongkind",belongkind),
                new SqlParameter("@title",title),
                new SqlParameter("@content",content),
                new SqlParameter("@belonguser",belonguser),
                new SqlParameter("@belongkind_type",belongkind_type),
                new SqlParameter("@mostbrowse",mostbrowse)
            };
            int i = Convert.ToInt32(SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp));
            return i;
        }
        public int editArticle(int id,bool isdelete,DateTime createtime,string belongkind,string title,string content,string belonguser,string belongkind_type,int mostbrowse)
        {
            string sql = "update T_Article set IsDelete=@isdelete,Createtime=@createtime,BelongKind=@belongkind,Title=@title,Content=@content,BelongKind_Type=@belongkind_type,MostBrowse=@mostbrowse,BelongUser=(select T_User.ID from T_User where UserName=@belonguser) where T_Article.ID=@id";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@isdelete",isdelete),
                new SqlParameter("@createtime",createtime),
                new SqlParameter("@belongkind",belongkind),
                new SqlParameter("@title",title),
                new SqlParameter("@content",content),
                new SqlParameter("@belongkind_type",belongkind_type),
                new SqlParameter("@mostbrowse",mostbrowse),
                new SqlParameter("@belonguser",belonguser),
                new SqlParameter("@id",id)
            };
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp));
        }

    }
}