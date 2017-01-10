using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class AddMessageDAL
    {
        public int addMessage(bool IsDelete, DateTime CreateTime, string MessTem, int ArticleID, string MessBelong, int CID, string CommentUser)
        {
            string sql = "insert into T_Messages(IsDelete,CreateTime,MessTem,ArticleID,MessBelong,CID,CommentUser) values(@IsDelete,@CreateTime,@MessTem,@ArticleID,@MessBelong,@CID,@CommentUser)";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@IsDelete",IsDelete),
                new SqlParameter("@CreateTime",CreateTime),
                new SqlParameter("@MessTem",MessTem),
                new SqlParameter("@ArticleID",ArticleID),
                new SqlParameter("@MessBelong",MessBelong),
                new SqlParameter("@CID",CID),
                new SqlParameter("@CommentUser",CommentUser)
            };
            return (int)SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
        }
    }
}