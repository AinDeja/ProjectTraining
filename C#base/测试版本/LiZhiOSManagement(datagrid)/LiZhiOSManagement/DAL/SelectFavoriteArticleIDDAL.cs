using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class SelectFavoriteArticleIDDAL
    {
        public int SelectFavoriteArticleCount(int articleId, string kind_type)
        {
            string sql = "select count(*) from T_EnjoyArticle where ArticleID=@articleId and IsDelete='False' and MessTem=@kind_type";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@articleId",articleId),
                new SqlParameter("@kind_type",kind_type)
            };
            return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, sp);
        }

        public List<EnjoyArticle> SelectFavoriteArticleId(int articleId, int userId)
        {
            List<EnjoyArticle> list = new List<EnjoyArticle>();
            string sql = "select * from T_EnjoyArticle where ArticleID=@articleId and UserID=@userId";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@articleId",articleId),
                new SqlParameter("@userId",userId)
            };
            using (DataTable dt = (DataTable)SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {

                foreach (DataRow row in dt.Rows)
                {
                    EnjoyArticle ea = new EnjoyArticle()
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        ArticleID = Convert.ToInt32(row["ArticleID"]),
                        UserID = Convert.ToInt32(row["UserID"]),
                        IsDelete = Convert.ToBoolean(row["IsDelete"]),
                        MessTem = Convert.ToString(row["MessTem"])
                    };
                    list.Add(ea);
                }

            }
            return list;
        }
        public int SelectFavoriteMessagesId(int messagesid, int userid, int articleid)
        {
            string sql = "select count(*) from T_EnjoyMessages where MessagesID=@messagesid and UserID=@userid and ArticleID=@articleid";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@messagesid",messagesid),
                new SqlParameter("@userid",userid),
                new SqlParameter("@articleid",articleid)
            };
            return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, sp);
        }

        public int SelectFavoriteMessagesCount(int messagesid, int articleid)
        {
            string sql = "select count(*) from T_EnjoyMessages where MessagesID=@messagesid and ArticleID=@articleid";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@messagesid",messagesid),
                new SqlParameter("@articleid",articleid)
            };
            return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, sp);
        }

        public int DeleteFavoriteArticleId(int articleId, int userId, bool b)
        {
            string sql = "update T_EnjoyArticle set IsDelete=@b where ArticleID=@articleId and UserID=@userId";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@b",b),
                new SqlParameter("@articleId",articleId),
                new SqlParameter("@userId",userId)
            };
            return (int)SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
        }
        public int InsertFavoriteArticleId(int articleId, int userId, string kind_type)
        {
            string sql = "insert into T_EnjoyArticle(ArticleID,UserId,IsDelete,MessTem) values(@articleId,@userId,'False',@kind_type)";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@articleId",articleId),
                new SqlParameter("@userId",userId),
                new SqlParameter("@kind_type",kind_type)
            };
            return (int)SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
        }

        public int InsertFavoriteMessagesId(int messagesid, int userid, int articleid)
        {
            string sql = "insert into T_EnjoyMessages(MessagesID,UserID,ArticleID) values(@messagesid,@userid,@articleid)";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@messagesid",messagesid),
                new SqlParameter("@userid",userid),
                new SqlParameter("@articleid",articleid)
            };
            return (int)SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
        }
        public int DeleteFavoriteMessagesId(int messagesid, int userid, int articleid)
        {
            string sql = "delete from T_EnjoyMessages where MessagesID=@messagesid and UserID=@userid and ArticleID=@articleid";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@messagesid",messagesid),
                new SqlParameter("@userid",userid),
                new SqlParameter("@articleid",articleid)
            };
            return (int)SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
        }
    }
}