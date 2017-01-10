using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class AddArticleDAL
    {
        public int AddArticle(bool IsDelete, DateTime CreateTime, string BelongKind, string Title, string Content, int BelongUser, string BelongKind_Type)
        {
            string sql = "insert into T_Article(IsDelete,CreateTime,BelongKind,Title,Content,BelongUser,BelongKind_Type) values(@IsDelete,@CreateTime,@BelongKind,@Title,@Content,@BelongUser,@BelongKind_Type)";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@IsDelete",IsDelete),
                new SqlParameter("@CreateTime",CreateTime),
                new SqlParameter("@BelongKind",BelongKind),
                new SqlParameter("@Title",Title),
                new SqlParameter("@Content",Content),
                new SqlParameter("@BelongUser",BelongUser),
                new SqlParameter("@BelongKind_Type",BelongKind_Type)
            };
            return (int)SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
        }

        public int addArticleBrowse(int id, int browse)
        {
            string sql = "update T_Article set MostBrowse=@browse where ID=@id";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@browse",browse),
                new SqlParameter("@id",id)
            };
            return (int)SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
        }
    }
}