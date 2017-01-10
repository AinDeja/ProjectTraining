using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InspirationalWeb.DAL
{
    public class T_Reply
    {
        //检索文章回复
        public DataTable ArticleReply(int arId)
        {
            string sql = "select*from T_Messages where MessBelongA=@id order by CreateTime";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@id", System.Data.SqlDbType.Int, 50) { Value = arId } };
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, pms);
            return view;
        }

        //新建文章回复
        public DataTable NewArticleReply(string MessTem, int MessCreator, int MessBelongA)
        {
            string su = "Insert into T_Messages(MessTem,MessCreator,MessBelongA) values(@MessTem,@MessCreator,@MessBelongA)";
            SqlParameter[] set = new SqlParameter[]{
                new SqlParameter("@MessTem",System.Data.SqlDbType.Text){Value=MessTem},
                 new SqlParameter("@MessCreator",System.Data.SqlDbType.Int){Value=MessCreator},
                 new SqlParameter("@MessBelongA",System.Data.SqlDbType.Int){Value=MessBelongA},
            };

            return Sql.ExecuteDataTable(su, System.Data.CommandType.Text, set);
        }
    }
}