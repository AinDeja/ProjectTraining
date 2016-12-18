using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class ShowCommentsDAL
    {
        public List<Article> showLouZhu(int content)
        {
            string sql = "select * from T_Article where ID=@content";
            SqlParameter sp = new SqlParameter("@content", content);
            List<Article> list = new List<Article>();
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {

                foreach (DataRow row in dt.Rows)
                {
                    Article a = new Article();

                    a.ID = Convert.ToInt32(row["ID"]);
                    a.IsDelete = row["IsDelete"] == DBNull.Value ? false : Convert.ToBoolean(row["IsDelete"]);
                    a.CreateTime = Convert.ToDateTime(row["CreateTime"]);
                    a.BelongKind = Convert.ToString(row["BelongKind"]);
                    a.Title = Convert.ToString(row["Title"]);
                    a.Content = Convert.ToString(row["Content"]);
                    a.BelongUser = Convert.ToInt32(row["BelongUser"]);
                    a.BelongKind_Type = Convert.ToString(row["BelongKind_Type"]);
                    a.MostBrowse = row["MostBrowse"] == DBNull.Value ? 0 : Convert.ToInt32(row["MostBrowse"]);

                    list.Add(a);
                }
            }
            return list;
        }


        public List<Messages> showComments(int id)
        {
            string sql = "select * from T_Messages where ArticleID=@id";
            SqlParameter sp = new SqlParameter("@id", id);
            List<Messages> list = new List<Messages>();
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Messages m = new Messages()
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        IsDelete = row["IsDelete"] == DBNull.Value ? false : Convert.ToBoolean(row["IsDelete"]),
                        CreateTime = Convert.ToDateTime(row["CreateTime"]),
                        MessTem = Convert.ToString(row["MessTem"]),
                        ArticleID = Convert.ToInt32(row["ArticleID"]),
                        MessBelong = Convert.ToString(row["MessBelong"]),
                        CID = Convert.ToInt32(row["CID"]),
                        CommentUser = Convert.ToString(row["CommentUser"])
                    };
                    list.Add(m);
                }
            }

            return list;

        }
    }
}