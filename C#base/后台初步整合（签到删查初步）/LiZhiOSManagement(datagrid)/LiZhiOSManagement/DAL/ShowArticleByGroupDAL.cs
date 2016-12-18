using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{

    public class ShowArticleByGroupDAL
    {
        
        public List<Article> SelectAllArticle()
        {
            List<Article> list = new List<Article>();
            using (DataTable dt = SqlHelper.ExecuteDataTable("select * from T_Article", CommandType.Text))
            {
                foreach (DataRow rows in dt.Rows)
                {
                    Article alla = new Article()
                    {
                        ID = Convert.ToInt32(rows["ID"]),
                        IsDelete = rows["IsDelete"] == DBNull.Value ? false : Convert.ToBoolean(rows["IsDelete"]),
                        CreateTime = Convert.ToDateTime(rows["CreateTime"]),
                        BelongKind = Convert.ToString(rows["BelongKind"]),
                        BelongKind_Type = Convert.ToString(rows["BelongKind_Type"]),
                        Title = Convert.ToString(rows["Title"]),
                        Content = Convert.ToString(rows["Content"]),
                        BelongUser = Convert.ToInt32(rows["BelongUser"]),
                        MostBrowse = (rows["MostBrowse"] == DBNull.Value ? 0 : Convert.ToInt32(rows["MostBrowse"]))

                    };
                    list.Add(alla);
                }
            }
            return list;
        }

        public List<Article> ShowArticleBy(string belongKind)
        {
            List<Article> list = new List<Article>();
            string sql = "select * from T_Article where BelongKind=@belongKind order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("@belongKind",belongKind)
                };
            list = zong(sql, sp, list);

            return list;
        }
        public List<Article> ShowArticleByBelongkind(string belongKind)
        {
            List<Article> list = new List<Article>();
            string sql = "select * from T_Article where BelongKind like @belongKind order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("@belongKind",belongKind)
                };
            list = zong(sql, sp, list);

            return list;
        }
        public List<Article> ShowArticleById(int id)
        {
            List<Article> list = new List<Article>();
            string sql = "select * from T_Article where ID=@id order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@id",id)
            };
            list = zong(sql, sp, list);
            return list;

        }

        public List<Article> ShowArticleByIsDelete(string isdelete)           //boolean模糊查询
        {
            List<Article> list = new List<Article>();
            string sql = "select *,IIF(IsDelete='false','false','true') as result from T_Article where IIF(IsDelete='false','false','true') like @isdelete order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@isdelete",isdelete)
            };
            list = zong(sql, sp, list);
            return list;
        }
        public List<Article> ShowArticleByCreattime(string dt)
        {
            List<Article> list = new List<Article>();
            string sql = "select * from T_Article where convert(varchar,CreateTime,120) like @dt order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@dt",dt)
            };
            list = zong(sql, sp, list);
            return list;
        }
       
        public List<Article> ShowArticleByTitle(string title)
        {
            List<Article> list = new List<Article>();
            string sql = "select * from T_Article where Title like @title order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@title",title)
            };
            list = zong(sql, sp, list);
            return list;
        }
        public List<Article> ShowArticleByContent(string content)
        {
            List<Article> list = new List<Article>();
            string sql = "select * from T_Article where Content like @content order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@content",content)
            };
            list = zong(sql, sp, list);
            return list;
        }
        public List<Article> ShowArticleByBelongUser(int uid)
        {
            List<Article> list = new List<Article>();
            string sql = "select * from T_Article where BelongUser=@uid order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@uid",uid)
            };
            list = zong(sql, sp, list);
            return list;
        }
        public List<Article> ShowArticleByeongKind_type(string belongkind_type)
        {
            List<Article> list = new List<Article>();
            string sql = "select * from T_Article where BelongKind_Type like @belongkind_type order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@belongkind_type",belongkind_type)
            };
            list = zong(sql, sp, list);
            return list;
        }

        public List<Article> ShowArticleByMostBrowse(int mostbrowse)
        {
            List<Article> list = new List<Article>();
            string sql = "select * from T_Article where MostBrowse=@mostbrowse order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@mostbrowse",mostbrowse)
            };
            list = zong(sql, sp,list);
            return list;
        }
        public List<Article> zong(string sql, SqlParameter[] sp,List<Article> list)
        {

            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow rows in dt.Rows)
                {
                    Article a = new Article()
                    {
                        ID = Convert.ToInt32(rows["ID"]),
                        IsDelete = rows["IsDelete"] == DBNull.Value ? false : Convert.ToBoolean(rows["IsDelete"]),
                        CreateTime = Convert.ToDateTime(rows["CreateTime"]),
                        BelongKind = Convert.ToString(rows["BelongKind"]),
                        BelongKind_Type = Convert.ToString(rows["BelongKind_Type"]),
                        Title = Convert.ToString(rows["Title"]),
                        Content = HttpContext.Current.Server.HtmlEncode(Convert.ToString(rows["Content"])),       ////重要
                        BelongUser = Convert.ToInt32(rows["BelongUser"]),
                        MostBrowse = (rows["MostBrowse"] == DBNull.Value ? 0 : Convert.ToInt32(rows["MostBrowse"]))
                    };
                    list.Add(a);
                }
            }
            return list;
        }


        //文章饼图嵌套       //内环
        public List<BelongKindCount> showBKandCount()
        {
            List<BelongKindCount> list = new List<BelongKindCount>();
            using(DataTable dt=SqlHelper.ExecuteDataTable("select BelongKind,count(*) as count from T_Article group by BelongKind",CommandType.Text))
            {
                
                
                foreach (DataRow row in dt.Rows)
                {
                    BelongKindCount bkc=new BelongKindCount();
                    bkc.value=Convert.ToInt32(row["count"]);
                    bkc.name=Convert.ToString(row["BelongKind"]);
                    list.Add(bkc);
                }
                return list;
            }
        }

        //文章饼图嵌套      //外环
        public List<BelongKindCount> showBKandBelongUserCount()
        {
            List<BelongKindCount> list = new List<BelongKindCount>();
            using(DataTable dt=SqlHelper.ExecuteDataTable("select BelongUser,count(*) as count,BelongKind from T_Article group by BelongKind,BelongUser order by BelongKind ",CommandType.Text))
            {

                foreach (DataRow row in dt.Rows)
                {
                    BelongKindCount bkc = new BelongKindCount();
                    bkc.value = Convert.ToInt32(row["count"]);
                    bkc.name = Convert.ToString(row["BelongUser"]);
                    list.Add(bkc);
                }
                
            }
            return list;
        }


    }

}