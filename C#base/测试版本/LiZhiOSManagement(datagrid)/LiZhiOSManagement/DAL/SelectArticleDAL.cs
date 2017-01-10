using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class SelectArticleDAL
    {
        public List<Article> SelectArticle()
        {
            List<Article> list = new List<Article>();
            string sql = "select * from T_Article where IsDelete='False'";
            using (DataTable table = SqlHelper.ExecuteDataTable(sql, CommandType.Text))
            {
                int s = table.Rows.Count;
                foreach (DataRow row in table.Rows)
                {
                    Article article = new Article()
                    {
                        ID = Convert.ToInt32(row[0]),
                        IsDelete = Convert.ToBoolean(row[1]),
                        CreateTime = Convert.ToDateTime(row[2]),
                        BelongKind = Convert.ToString(row[3]),
                        Title = Convert.ToString(row[4]),
                        Content = Convert.ToString(row[5]),
                        BelongUser = Convert.ToInt32(row[6]),
                        BelongKind_Type = Convert.ToString(row[7]),
                        MostBrowse = Convert.ToInt32(row[8])
                    };
                    list.Add(article);
                }
            }
            return list;
        }

        public List<Article> selectKindsArticle(string articletype)
        {
            List<Article> list = new List<Article>();
            string sql = "select * from T_Article where BelongKind=@articletype and IsDelete='False' order by ID desc";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@articletype",articletype)
            };
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow rows in dt.Rows)
                {
                    Article a = new Article()
                    {
                        ID = Convert.ToInt32(rows["ID"]),
                        IsDelete = Convert.ToBoolean(rows["IsDelete"]),
                        CreateTime = Convert.ToDateTime(rows["CreateTime"]),
                        BelongKind = Convert.ToString(rows["BelongKind"]),
                        Title = Convert.ToString(rows["Title"]),
                        Content = Convert.ToString(rows["Content"]),
                        BelongUser = Convert.ToInt32(rows["BelongUser"]),
                        BelongKind_Type = Convert.ToString(rows["BelongKind_Type"]),
                        MostBrowse = (rows["MostBrowse"] == DBNull.Value ? 0 : Convert.ToInt32(rows["MostBrowse"]))
                    };
                    list.Add(a);
                }
            }
            return list;
        }

        public List<Article> ShowFy(int count, string belongkind)
        {

            List<Article> ls = new List<Article>();
            string sql;
            SqlParameter[] ps;

            sql = "select top 5 * from T_Article where ID not in (select top((@count-1)*5) ID from T_Article where BelongKind=@belongkind order by ID desc) and BelongKind=@belongkind order by ID desc";
            ps = new SqlParameter[]{
                new SqlParameter("@count",count),
                new SqlParameter("@belongkind",belongkind)
                };
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, ps))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Article a = new Article()
                    {
                        ID = Convert.ToInt32(row[0]),
                        IsDelete = Convert.ToBoolean(row[1]),
                        CreateTime = Convert.ToDateTime(row[2]),
                        BelongKind = Convert.ToString(row[3]),
                        Title = Convert.ToString(row[4]),
                        Content = Convert.ToString(row[5]),
                        BelongUser = Convert.ToInt32(row[6]),
                        BelongKind_Type = Convert.ToString(row[7]),
                        MostBrowse = (row[8] == DBNull.Value ? 0 : Convert.ToInt32(row[8]))
                    };
                    ls.Add(a);
                }
            }
            return ls;
        }

        public List<Article> ShowFyByLeftClass(int count, string belongkind_type)
        {

            List<Article> ls = new List<Article>();
            string sql;
            SqlParameter[] ps;

            sql = "select top 5 * from T_Article where ID not in (select top((@count-1)*5) ID from T_Article where BelongKind_Type=@belongkind_type order by ID desc) and BelongKind=@belongkind order by ID desc";
            ps = new SqlParameter[]{
                new SqlParameter("@count",count),
                new SqlParameter("@belongkind_type",belongkind_type)
                };


            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, ps))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Article a = new Article()
                    {
                        ID = Convert.ToInt32(row[0]),
                        IsDelete = Convert.ToBoolean(row[1]),
                        CreateTime = Convert.ToDateTime(row[2]),
                        BelongKind = Convert.ToString(row[3]),
                        Title = Convert.ToString(row[4]),
                        Content = Convert.ToString(row[5]),
                        BelongUser = Convert.ToInt32(row[6]),
                        BelongKind_Type = Convert.ToString(row[7])
                    };
                    ls.Add(a);
                }
            }
            return ls;
        }

        public List<Article> ShowFyByBelongkind_type(string belongkind, string belongkind_type)
        {

            List<Article> ls = new List<Article>();
            string sql;
            SqlParameter[] ps;

            sql = "select * from T_Article where BelongKind=@belongkind and BelongKind_Type=@belongkind_type order by ID desc";
            ps = new SqlParameter[]{
                new SqlParameter("@belongkind",belongkind),
                new SqlParameter("@belongkind_type",belongkind_type)
                };


            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, ps))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Article a = new Article()
                    {
                        ID = Convert.ToInt32(row[0]),
                        IsDelete = Convert.ToBoolean(row[1]),
                        CreateTime = Convert.ToDateTime(row[2]),
                        BelongKind = Convert.ToString(row[3]),
                        Title = Convert.ToString(row[4]),
                        Content = Convert.ToString(row[5]),
                        BelongUser = Convert.ToInt32(row[6]),
                        BelongKind_Type = Convert.ToString(row[7]),
                        MostBrowse = (row[8] == DBNull.Value ? 0 : Convert.ToInt32(row[8]))
                    };
                    ls.Add(a);
                }
            }
            return ls;
        }

        public List<Article> ShowFyByHour(string belong_kind)
        {

            List<Article> ls = new List<Article>();
            string sql;


            sql = "select * from T_Article where DATEDIFF(hh,CreateTime,getdate())<=24 and BelongKind=@belong_kind order by ID desc";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@belong_kind",belong_kind)
            };

            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Article a = new Article()
                    {
                        ID = Convert.ToInt32(row[0]),
                        IsDelete = Convert.ToBoolean(row[1]),
                        CreateTime = Convert.ToDateTime(row[2]),
                        BelongKind = Convert.ToString(row[3]),
                        Title = Convert.ToString(row[4]),
                        Content = Convert.ToString(row[5]),
                        BelongUser = Convert.ToInt32(row[6]),
                        BelongKind_Type = Convert.ToString(row[7]),
                        MostBrowse = (row[8] == DBNull.Value ? 0 : Convert.ToInt32(row[8]))
                    };
                    ls.Add(a);
                }
            }
            return ls;
        }

        public List<Article> ShowFyByWeek(string belong_kind)
        {
            List<Article> ls = new List<Article>();
            string sql = "select * from T_Article where DATEDIFF(week,CreateTime,getdate())=0 and BelongKind=@belong_kind order by ID desc";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@belong_kind",belong_kind)
            };
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Article a = new Article()
                    {
                        ID = Convert.ToInt32(row[0]),
                        IsDelete = Convert.ToBoolean(row[1]),
                        CreateTime = Convert.ToDateTime(row[2]),
                        BelongKind = Convert.ToString(row[3]),
                        Title = Convert.ToString(row[4]),
                        Content = Convert.ToString(row[5]),
                        BelongUser = Convert.ToInt32(row[6]),
                        BelongKind_Type = Convert.ToString(row[7]),
                        MostBrowse = (row[8] == DBNull.Value ? 0 : Convert.ToInt32(row[8]))
                    };
                    ls.Add(a);
                }
            }
            return ls;
        }

        public List<Article> ShowFyByMonth(string belong_kind)
        {

            List<Article> ls = new List<Article>();
            string sql;
            sql = "select * from T_Article where DATEDIFF(month,CreateTime,getdate())=0 and BelongKind=@belong_kind order by ID desc";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@belong_kind",belong_kind)
            };
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Article a = new Article()
                    {
                        ID = Convert.ToInt32(row[0]),
                        IsDelete = Convert.ToBoolean(row[1]),
                        CreateTime = Convert.ToDateTime(row[2]),
                        BelongKind = Convert.ToString(row[3]),
                        Title = Convert.ToString(row[4]),
                        Content = Convert.ToString(row[5]),
                        BelongUser = Convert.ToInt32(row[6]),
                        BelongKind_Type = Convert.ToString(row[7]),
                        MostBrowse = (row[8] == DBNull.Value ? 0 : Convert.ToInt32(row[8]))
                    };
                    ls.Add(a);
                }
            }
            return ls;
        }


        public List<Article> ShowFyByYear(string belong_kind)
        {

            List<Article> ls = new List<Article>();
            string sql;
            sql = "select * from T_Article where DATEDIFF(year,CreateTime,getdate())=0 and BelongKind=@belong_kind order by ID desc";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@belong_kind",belong_kind)
            };
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Article a = new Article()
                    {
                        ID = Convert.ToInt32(row[0]),
                        IsDelete = Convert.ToBoolean(row[1]),
                        CreateTime = Convert.ToDateTime(row[2]),
                        BelongKind = Convert.ToString(row[3]),
                        Title = Convert.ToString(row[4]),
                        Content = Convert.ToString(row[5]),
                        BelongUser = Convert.ToInt32(row[6]),
                        BelongKind_Type = Convert.ToString(row[7]),
                        MostBrowse = (row[8] == DBNull.Value ? 0 : Convert.ToInt32(row[8]))
                    };
                    ls.Add(a);
                }
            }
            return ls;
        }


        public List<Article> SelectArticleById(int id)
        {
            List<Article> list = new List<Article>();
            string sql = "select * from T_Article where ID=@id";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@id",id)
            };
            using (DataTable table = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                int s = table.Rows.Count;
                foreach (DataRow row in table.Rows)
                {
                    Article article = new Article()
                    {
                        ID = Convert.ToInt32(row[0]),
                        IsDelete = Convert.ToBoolean(row[1]),
                        CreateTime = Convert.ToDateTime(row[2]),
                        BelongKind = Convert.ToString(row[3]),
                        Title = Convert.ToString(row[4]),
                        Content = Convert.ToString(row[5]),
                        BelongUser = Convert.ToInt32(row[6])
                    };
                    list.Add(article);
                }
            }
            return list;
        }

        //最多回复倒序排列ID
        public List<Messages> SelectArticleByMostId()
        {
            List<Messages> list = new List<Messages>();
            string sql = "select ArticleID from T_Messages group by ArticleID order by count(ArticleID) desc";
            using (DataTable table = SqlHelper.ExecuteDataTable(sql, CommandType.Text))
            {
                foreach (DataRow row in table.Rows)
                {
                    Messages m = new Messages()
                    {
                        ArticleID = Convert.ToInt32(row["ArticleId"])
                    };
                    list.Add(m);
                }
            }
            return list;
        }


        //查询最多回复
        public List<Messages> SelectArticleByComment(string grouptype)
        {
            List<Messages> list = new List<Messages>();
            string sql = "select ArticleID from T_Messages where MessTem=@grouptype and CID=0 and IsDelete='False' group by ArticleID order by count(ArticleID) desc";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@grouptype",grouptype)
            };
            using (DataTable table = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                int s = table.Rows.Count;
                foreach (DataRow row in table.Rows)
                {
                    Messages msg = new Messages()
                    {
                        ArticleID = Convert.ToInt32(row["ArticleID"])
                    };
                    list.Add(msg);
                }
            }
            return list;
        }

        //查询最多喜欢
        public List<EnjoyArticle> SelectArticleByFavorite(string kind_type)
        {
            List<EnjoyArticle> list = new List<EnjoyArticle>();
            string sql = "select ArticleID from T_EnjoyArticle where IsDelete='False' and MessTem=@grouptype group by ArticleID order by count(ArticleID) desc";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@grouptype",kind_type)
            };

            using (DataTable table = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow row in table.Rows)
                {
                    EnjoyArticle ea = new EnjoyArticle()
                    {
                        ArticleID = Convert.ToInt32(row["ArticleID"])
                    };
                    list.Add(ea);
                }
            }
            return list;
        }

        //查询最多浏览
        public List<Article> SelectArticleByWatch(int count, string belongkind)
        {

            List<Article> ls = new List<Article>();
            string sql;
            SqlParameter[] ps;

            sql = "select top 5 * from T_Article where MostBrowse not in (select top((@count-1)*5) MostBrowse from T_Article where BelongKind=@belongkind order by MostBrowse desc) and BelongKind=@belongkind order by MostBrowse desc";
            ps = new SqlParameter[]{
                new SqlParameter("@count",count),
                new SqlParameter("@belongkind",belongkind)
                };
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, ps))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Article a = new Article()
                    {
                        ID = Convert.ToInt32(row[0]),
                        IsDelete = Convert.ToBoolean(row[1]),
                        CreateTime = Convert.ToDateTime(row[2]),
                        BelongKind = Convert.ToString(row[3]),
                        Title = Convert.ToString(row[4]),
                        Content = Convert.ToString(row[5]),
                        BelongUser = Convert.ToInt32(row[6]),
                        BelongKind_Type = Convert.ToString(row[7]),
                        MostBrowse = (row[8] == DBNull.Value ? 0 : Convert.ToInt32(row[8]))
                    };
                    ls.Add(a);
                }
            }
            return ls;
        }


        //搜索
        public List<Article> SelectArticleBySearch(string kindtype, string searchbydata)
        {
            string sql = "select * from T_Article where BelongKind=@kindtype and IsDelete='False' and (Title like @searchbydata or Content like @searchbydata or BelongKind_Type like @searchbydata or BelongUser in (select ID from T_User where UserName like @searchbydata)) order by ID Desc";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@kindtype",kindtype),
                new SqlParameter("@searchbydata","%"+searchbydata+"%")
            };
            List<Article> list = new List<Article>();
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow row in dt.Rows)
                {
                    Article a = new Article()
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        IsDelete = Convert.ToBoolean(row["IsDelete"]),
                        CreateTime = Convert.ToDateTime(row["CreateTime"]),
                        BelongKind = Convert.ToString(row["BelongKind"]).Replace(searchbydata, "<span style=" + "\"" + "background-color:#FFF000" + "\"" + ">" + searchbydata + "</span>"),
                        Title = Convert.ToString(row["Title"]).Replace(searchbydata, "<span style=" + "\"" + "background-color:#FFF000" + "\"" + ">" + searchbydata + "</span>"),
                        Content = Convert.ToString(row["Content"]).Replace(searchbydata, "<span style=" + "\"" + "background-color:#FFF000" + "\"" + ">" + searchbydata + "</span>"),
                        BelongUser = Convert.ToInt32(row["BelongUser"]),
                        BelongKind_Type = Convert.ToString(row["BelongKind_Type"]).Replace(searchbydata, "<span style=" + "\"" + "background-color:#FFF000" + "\"" + ">" + searchbydata + "</span>"),
                        MostBrowse = (row["MostBrowse"] == DBNull.Value ? 0 : Convert.ToInt32(row["MostBrowse"]))
                    };

                    list.Add(a);
                }
            }
            return list;
        }
    }
}