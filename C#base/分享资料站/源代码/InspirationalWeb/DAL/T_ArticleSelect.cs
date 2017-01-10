using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InspirationalWeb.DAL
{
    public class T_ArticleSelect
    {
        //最新文章检索
        public DataTable NewArticle()
        {
            string su = "select top(4) *from T_Article order by ID desc";

            return Sql.ExecuteDataTable(su, System.Data.CommandType.Text);
        }
        //所有文章检索
        public DataTable SelectArticleAll()
        {
            string sql = "select*from T_Article  order by ID";
          
            DataTable pList = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
            return pList;
        }
        public DataTable allArticleList(int pageNumber)
        {
            
            int star = (pageNumber - 1) * 10 + 1;
            int end = pageNumber * 10;
            string sqlForSerch = @"WITH userOrder AS
            (SELECT ROW_NUMBER() OVER (ORDER BY id) RowNumber,*FROM T_Article  ArTitle) SELECT * FROM userOrder WHERE RowNumber BETWEEN @star AND @end";

            //查询结果分页

            SqlParameter[] set = new SqlParameter[]{
                
                 new SqlParameter("@star",System.Data.SqlDbType.Int){Value=star},
                 new SqlParameter("@end",System.Data.SqlDbType.Int){Value=end},


            };
            return Sql.ExecuteDataTable(sqlForSerch, System.Data.CommandType.Text, set);

        
        }

        //文章分类检索
        public DataTable typeArticleList(int pageNumber,int typeID)
        {

            int star = (pageNumber - 1) * 10 + 1;
            int end = pageNumber * 10;
            string sqlForSerch = @"WITH userOrder AS
            (SELECT ROW_NUMBER() OVER (ORDER BY id) RowNumber,*FROM T_Article where ArType=@typeid and IsDelete=0) SELECT * FROM userOrder WHERE RowNumber BETWEEN @star AND @end";

            //查询结果分页

            SqlParameter[] set = new SqlParameter[]{
                
                 new SqlParameter("@star",System.Data.SqlDbType.Int){Value=star},
                 new SqlParameter("@end",System.Data.SqlDbType.Int){Value=end},
                  new SqlParameter("@typeid",System.Data.SqlDbType.Int){Value=typeID},


            };
            return Sql.ExecuteDataTable(sqlForSerch, System.Data.CommandType.Text, set);


        }
        /// <summary>
        /// 父类列表
        /// </summary>
        /// <returns></returns>
        public DataTable SearchArticleTypeFather()
        {
            string sql = "select*from T_ArticleType order by ID";

            return Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);

        }
        /// <summary>
        /// 子类列表
        /// </summary>
        /// <returns></returns>
        public DataTable SearchArticleTypeSon(int fatherid)
        {
            string sql = "select*from T_ArticleTypeSon where TypeFather=@fatherid order by ID";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@fatherid", System.Data.SqlDbType.Int, 50) { Value = fatherid } };
            return Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, pms);

        }
        //批量软删除文章
        public void delArticle(string ids)
        {
            string sql = "update T_Article set IsDelete=1 where ID in(" + ids + ")";
            Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
        }
        //软删除文章分类
        public void delArticleF(int ids)
        {
            DataTable sontype = SearchArticleTypeSon(ids);
            DataRow son = sontype.Rows[0];
            delArticleWhereType(Convert.ToInt32(son["ID"]));
            string sql = "update T_ArticleTypeSon set IsDelete=1 where ID in(" + Convert.ToInt32(son["ID"]) + ")";
            Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
            string sqlf = "update T_ArticleType set IsDelete=1 where ID in(" + ids + ")";
            Sql.ExecuteDataTable(sqlf, System.Data.CommandType.Text);
        }
        public void delArticleS(int ids)
        {

            delArticleWhereType(ids);
            string sql = "update T_ArticleTypeSon set IsDelete=1 where ID in(" + ids + ")";
            Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
        }
        //通过文章类型软删除文章
        public void delArticleWhereType(int tid)
        {

            string sql = "update T_Article set IsDelete=1 where ArType=@tid ";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@tid", System.Data.SqlDbType.Int) { Value = tid } };
            Sql.ExecuteDataTable(sql, System.Data.CommandType.Text,pms);
        }
        //个人文章管理检索
        public DataTable SerchArticle(int username, string SerchText)
        {
            string sqlForSerch = "select*from T_Article where ArCreator=@uid and ArTitle like'%" + SerchText + "%' order by id";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@uid", System.Data.SqlDbType.Int) { Value = username } };
            DataTable postSerch = Sql.ExecuteDataTable(sqlForSerch, System.Data.CommandType.Text,pms);
            return postSerch;
        }
        //文章上一篇
        public DataTable LastArticle(int arid)
        {
            string arL = "SELECT TOP(1) ID,ArTitle,ArCont,ArCreator,CreateTime,IsDelete FROM T_Article WHERE ID<@arid ORDER BY ID DESC";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@arid", System.Data.SqlDbType.Int, 50) { Value = arid } };
            DataTable view = Sql.ExecuteDataTable(arL, System.Data.CommandType.Text, pms);
            return view;
        }
        //文章下一篇
        public DataTable NextArticle(int arid)
        {
            string arL = "SELECT TOP(1) ID,ArTitle,ArCont,ArCreator,CreateTime,IsDelete FROM T_Article WHERE ID>@arid ORDER BY ID ASC";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@arid", System.Data.SqlDbType.Int, 50) { Value = arid } };
            DataTable view = Sql.ExecuteDataTable(arL, System.Data.CommandType.Text, pms);
            return view;
        }
    }
}