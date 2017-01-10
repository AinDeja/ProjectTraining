using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class SelectArticleGroupDAL
    {
        public List<ArticleGroup> SelectArticleGroup()
        {
            string sql = "select * from T_ArticleGroup";
            List<ArticleGroup> list = new List<ArticleGroup>();


            using (DataTable table = SqlHelper.ExecuteDataTable(sql, CommandType.Text))
            {
                foreach (DataRow row in table.Rows)
                {
                    ArticleGroup ag = new ArticleGroup()
                    {
                        ID = Convert.ToInt32(row[0]),
                        BelongGroup = Convert.ToString(row[1])
                    };
                    list.Add(ag);
                }
            }
            return list;
        }

        public string SelectArticleRGroup(int group)
        {
            string sql = "select BelongGroup from T_ArticleGroup where ID=@ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@ID",group)
            };
            return SqlHelper.ExecuteScalar(sql, CommandType.Text, sp).ToString();
        }
    }
}