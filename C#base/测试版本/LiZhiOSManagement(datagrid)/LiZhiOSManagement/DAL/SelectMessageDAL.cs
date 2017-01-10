using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class SelectMessageDAL
    {
        public List<Messages> selectMessages(int id)                                          //既是初始，又是时间正序
        {
            string sql = "select * from T_Messages where ArticleId=@id and IsDelete='false' order by CreateTime";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@id",id)
            };
            DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
            List<Messages> list = null;
            if (dt != null)
            {
                list = new List<Messages>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Messages()
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        IsDelete = Convert.ToBoolean(row["IsDelete"]),
                        CreateTime = Convert.ToDateTime(row["CreateTime"]),
                        MessTem = Convert.ToString(row["MessTem"]),
                        ArticleID = Convert.ToInt32(row["ArticleID"]),
                        MessBelong = Convert.ToString(row["MessBelong"]),
                        CID = Convert.ToInt32(row["CID"]),
                        CommentUser = Convert.ToString(row["CommentUser"])
                    });
                }
            }
            return list;
        }

        public List<Messages> selectMessagesByTimeDesc(int id)               //按照时间降序
        {
            string sql = "select * from T_Messages where ArticleId=@id and IsDelete='false' order by CreateTime desc";
            SqlParameter sp = new SqlParameter("@id",id);
            List<Messages> list = new List<Messages>();
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Messages()
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        IsDelete = Convert.ToBoolean(row["IsDelete"]),
                        CreateTime = Convert.ToDateTime(row["CreateTime"]),
                        MessTem = Convert.ToString(row["MessTem"]),
                        ArticleID = Convert.ToInt32(row["ArticleID"]),
                        MessBelong = Convert.ToString(row["MessBelong"]),
                        CID = Convert.ToInt32(row["CID"]),
                        CommentUser = Convert.ToString(row["CommentUser"])
                    });
                }
            }
            return list;
        }

        public List<int> selectMessagesByFavoriteDescFav(int id)
        {
            string sql = "select MessagesID from T_EnjoyMessages where ArticleID=@id group by MessagesID order by sum(MessagesID) desc";
            SqlParameter sp = new SqlParameter("@id",id);
            List<int> list = new List<int>();
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(Convert.ToInt32(row["MessagesID"]));
                }
            }
            return list;

        }

        public List<Messages> selectMessagesByFavoriteDesc(int id)                    //按照喜欢降序
        {
            string sql = "select * from T_Messages where ArticleId=@id and IsDelete='false' order by CreateTime desc";
            SqlParameter sp = new SqlParameter("@id", id);
            List<Messages> list = new List<Messages>();
            List<Messages> listzz = new List<Messages>();
            List<int> listint =new List<int>();

            listint = selectMessagesByFavoriteDescFav(id);
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Messages()
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        IsDelete = Convert.ToBoolean(row["IsDelete"]),
                        CreateTime = Convert.ToDateTime(row["CreateTime"]),
                        MessTem = Convert.ToString(row["MessTem"]),
                        ArticleID = Convert.ToInt32(row["ArticleID"]),
                        MessBelong = Convert.ToString(row["MessBelong"]),
                        CID = Convert.ToInt32(row["CID"]),
                        CommentUser = Convert.ToString(row["CommentUser"])
                    });
                }
            }

            foreach (var item in listint)
            {
                listzz.AddRange(list.Where(r=>r.ID==item).ToArray());
                list.Remove(list.Where(c=>c.ID==item).ToArray()[0]);
            }
            listzz.AddRange(list);

            return listzz;
        }

        public string selectMessagesBelongSUser(int ID)
        {
            string sql = "select CommentUser from T_Messages where CID=@ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@ID",ID)
            };
            return SqlHelper.ExecuteScalar(sql, CommandType.Text, sp).ToString();
        }
    }
}