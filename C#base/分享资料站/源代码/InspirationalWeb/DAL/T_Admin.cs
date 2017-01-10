using InspirationalWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InspirationalWeb.DAL
{
    public class T_Admin
    {
        public int Login(string loginId, string password)
        {
            string sql = "select count(*) from T_SysAdmin where SysName=@uid and SysPassWord=@pwd";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@uid",System.Data.SqlDbType.NVarChar,50){ Value=loginId},
            new SqlParameter("@pwd",System.Data.SqlDbType.VarChar,50){ Value=password}
            };
            return (int)Sql.ExecuteScalar(sql, System.Data.CommandType.Text, pms);
        }
        public Seat GetModelByLoginId(string loginId)
        {
            Seat model = null;
            string sql = "select SysPassword,SysName from T_SysAdmin where SysName=@loginId";
            using (SqlDataReader reader = Sql.ExecuteReader(sql, System.Data.CommandType.Text, new SqlParameter("@loginId", System.Data.SqlDbType.NVarChar, 50) { Value = loginId }))
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        model = new Seat();
                        model.UserPassword = reader.GetString(0);
                        model.UserName = reader.GetString(1);

                    }
                }
            }
            return model;
        }
        //检索文章、相册、留言总数
        public int[] CountAll()
        {
            int[] all=new int[3];
            string sqlA = "select COUNT(*) from T_Article";
            string sqlP = "select COUNT(*) from T_PhotoPath";
            string sqlM = "select COUNT(*) from T_Messages";
            all[0] = Convert.ToInt32(Sql.ExecuteScalar(sqlA, System.Data.CommandType.Text));
            all[1] = Convert.ToInt32(Sql.ExecuteScalar(sqlP, System.Data.CommandType.Text));
            all[2] = Convert.ToInt32(Sql.ExecuteScalar(sqlM, System.Data.CommandType.Text));
            return all;
        }
        //新增文章类
        public void newArticleTypeT(string father)
        {
            string su = "Insert into T_ArticleType(TypeName,TypeCreator) values(@father,0)";
            SqlParameter[] set = new SqlParameter[]{
                new SqlParameter("@father",System.Data.SqlDbType.NVarChar){Value=father},
                
            };
            Sql.ExecuteScalar(su, System.Data.CommandType.Text, set);
        }
        public void newArticleTypeSonT(int father, string son)
        {
            string su = "Insert into T_ArticleTypeSon(TypeName,TypeFather,TypeCreator) values(@son,@father,0)";
            SqlParameter[] set = new SqlParameter[]{
                 new SqlParameter("@son",System.Data.SqlDbType.NVarChar){Value=son},
                new SqlParameter("@father",System.Data.SqlDbType.Int){Value=father},
                
            };
            Sql.ExecuteScalar(su, System.Data.CommandType.Text, set);
        }
        //留言管理

        /// <summary>
        /// 留言列表
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public DataTable allMessagesList(int pageNumber)
        {

            int star = (pageNumber - 1) * 10 + 1;
            int end = pageNumber * 10;
            string sqlForSerch = @"WITH userOrder AS
            (SELECT ROW_NUMBER() OVER (ORDER BY id) RowNumber,*FROM T_Messages ) SELECT * FROM userOrder WHERE RowNumber BETWEEN @star AND @end";

            //查询结果分页

            SqlParameter[] set = new SqlParameter[]{
                
                 new SqlParameter("@star",System.Data.SqlDbType.Int){Value=star},
                 new SqlParameter("@end",System.Data.SqlDbType.Int){Value=end},


            };
            return Sql.ExecuteDataTable(sqlForSerch, System.Data.CommandType.Text, set);


        }
        //软删除留言
        public void delMessagesWhereID(int tid)
        {

            string sql = "update T_Messages set IsDelete=1 where ID=@tid ";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@tid", System.Data.SqlDbType.Int) { Value = tid } };
            Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, pms);
        }
        //批量软删除留言
        public void delMessagesAll(string ids)
        {
            string sql = "update T_Messages set IsDelete=1 where ID in(" + ids + ")";
            Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
        }
    }
}