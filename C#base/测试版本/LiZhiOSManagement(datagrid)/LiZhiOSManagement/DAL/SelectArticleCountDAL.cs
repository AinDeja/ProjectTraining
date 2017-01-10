using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class SelectArticleCountDAL
    {
        //哪个组的
        public int SelectArticleCount(string belongkind)
        {
            string sql = "select count(*) from T_Article where BelongKind=@belongkind";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@belongkind",belongkind)
            };
            return (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, sp);
        }
    }
}