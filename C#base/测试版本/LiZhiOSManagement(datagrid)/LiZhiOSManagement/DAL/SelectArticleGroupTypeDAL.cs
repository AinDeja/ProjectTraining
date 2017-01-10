using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class SelectArticleGroupTypeDAL
    {
        public List<ArticleGroupType> SelectArticleType(int ID)
        {
            string sql = "select * from T_ArticleGroupType where IDCount=@ID";
            SqlParameter[] ps = new SqlParameter[]{
                new SqlParameter("@ID",ID)
            };
            List<ArticleGroupType> list = new List<ArticleGroupType>();
            using (DataTable table = SqlHelper.ExecuteDataTable(sql, CommandType.Text, ps))
            {
                foreach (DataRow row in table.Rows)
                {
                    ArticleGroupType agt = new ArticleGroupType()
                    {
                        ID = Convert.ToInt32(row[0]),
                        BelongType = Convert.ToString(row[1]),
                        IDCount = Convert.ToInt32(row[2])
                    };
                    list.Add(agt);
                }
            }
            return list;
        }
        public string SelectArticleRType(int articleType)
        {
            string sql = "select BelongType from T_ArticleGroupType where ID=@IDCount";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@IDCount",articleType)
            };
            return SqlHelper.ExecuteScalar(sql, CommandType.Text, sp).ToString();
        }
    }
}