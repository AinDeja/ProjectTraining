using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class ShowMessagesDAL
    {
        public List<Messages> selectAllMessages()
        {
            string sql = "select * from T_Messages order by CreateTime asc";
            List<Messages> list = new List<Messages>();
            using(DataTable dt=SqlHelper.ExecuteDataTable(sql,CommandType.Text))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Messages m = new Messages();
                    m.ID = Convert.ToInt32(row["ID"]);
                    m.IsDelete = row["IsDelete"] == DBNull.Value ? false : Convert.ToBoolean(row["IsDelete"]);
                    m.CreateTime = Convert.ToDateTime(row["CreateTime"]);
                    m.MessTem = Convert.ToString(row["MessTem"]);
                    m.ArticleID = Convert.ToInt32(row["ArticleID"]);
                    m.MessBelong = Convert.ToString(row["MessBelong"]);
                    m.CID = Convert.ToInt32(row["CID"]);
                    m.CommentUser = Convert.ToString(row["CommentUser"]);
                    list.Add(m);
                }
            }
            return list;
        }


        //所有某文章的评论
        public List<Messages> showAllMessages(int id)
        {
            string sql = "select * from T_Messages where ArticleID=@id order by CreateTime asc";
            SqlParameter sp = new SqlParameter("@id", id);
            List<Messages> list = new List<Messages>();
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Messages m = new Messages();
                    m.ID = Convert.ToInt32(row["ID"]);
                    m.IsDelete = row["IsDelete"] == DBNull.Value ? false : Convert.ToBoolean(row["IsDelete"]);
                    m.CreateTime = Convert.ToDateTime(row["CreateTime"]);
                    m.MessTem = Convert.ToString(row["MessTem"]);
                    m.ArticleID = Convert.ToInt32(row["ArticleID"]);
                    m.MessBelong = Convert.ToString(row["MessBelong"]);
                    m.CID = Convert.ToInt32(row["CID"]);
                    m.CommentUser = Convert.ToString(row["CommentUser"]);
                    list.Add(m);
                }

            }
            return list;
        }


        //显示评论            一级评论
        public List<Messages> showMessages(int id)
        {
            string sql = "select * from T_Messages where ArticleID=@id and CID=0 order by CreateTime asc";
            SqlParameter sp = new SqlParameter("@id",id);
            List<Messages> list = new List<Messages>();
            using(DataTable dt=SqlHelper.ExecuteDataTable(sql,CommandType.Text,sp))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Messages m = new Messages();
                    m.ID = Convert.ToInt32(row["ID"]);
                    m.IsDelete = row["IsDelete"] == DBNull.Value ? false : Convert.ToBoolean(row["IsDelete"]);
                    m.CreateTime = Convert.ToDateTime(row["CreateTime"]);
                    m.MessTem = Convert.ToString(row["MessTem"]);
                    m.ArticleID = Convert.ToInt32(row["ArticleID"]);
                    m.MessBelong = Convert.ToString(row["MessBelong"]);
                    m.CID = Convert.ToInt32(row["CID"]);
                    m.CommentUser = Convert.ToString(row["CommentUser"]);
                    list.Add(m);
                }

            }
            return list;
        }
        public List<Messages> showMoreMessages(int aritcleid,int cid)
        {
            string sql = "select * from T_Messages where ArticleID=@articleid and CID=@cid";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@articleid",aritcleid),
                new SqlParameter("@cid",cid)
            };
            List<Messages> list = new List<Messages>();
            using(DataTable dt=SqlHelper.ExecuteDataTable(sql,CommandType.Text,sp))
            {
                foreach (DataRow rows in dt.Rows)
                {
                    Messages m = new Messages();
                    m.ID = Convert.ToInt32(rows["ID"]);
                    m.IsDelete = rows["IsDelete"] == DBNull.Value ? false : Convert.ToBoolean(rows["IsDelete"]);
                    m.CreateTime = Convert.ToDateTime(rows["CreateTime"]);
                    m.MessTem = Convert.ToString(rows["MessTem"]);
                    m.ArticleID = Convert.ToInt32(rows["ArticleID"]);
                    m.MessBelong = Convert.ToString(rows["MessBelong"]);
                    m.CID = Convert.ToInt32(rows["CID"]);
                    m.CommentUser = Convert.ToString(rows["CommentUser"]);
                    list.Add(m);
                }
            }
            return list;
        }

    }


}