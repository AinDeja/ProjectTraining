using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class DeleteArticleAndCommentDAL
    {

//文章表
        public int deleteArticlesBy(string delid)
        {
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery("delete from T_Article where ID in("+delid+")",CommandType.Text));
        }
        public int deleteCommentsBy(string delid)
        {
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery("delete from T_Messages where ArticleID in(" + delid + ")", CommandType.Text));
        }



//评论页面
        //删除发表的内容
        public int deleteArticle(int id)
        {
            string sql = "delete from T_Article where ID=@id";
            SqlParameter sp = new SqlParameter("@id", id);
            int i = Convert.ToInt32(SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp));
            return i;
        }

        //删除该文章下所有评论
        public void DeleteAllComments(int id)
        {
            string sql = "delete from T_Messages where ArticleID=@id";
            SqlParameter sp = new SqlParameter("@id",id);
            int j = Convert.ToInt32(SqlHelper.ExecuteNonQuery(sql,CommandType.Text,sp));
        }

        //只删除评论
        public void DeleteByComments(int id)
        {
            string sql = "delete from T_Messages where ID=@id";
            SqlParameter sp = new SqlParameter("@id", id);
            int i = Convert.ToInt32(SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp));

        }
    }
}