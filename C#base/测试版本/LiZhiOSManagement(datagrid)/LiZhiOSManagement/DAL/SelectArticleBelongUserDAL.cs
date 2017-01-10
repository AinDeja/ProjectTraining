using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class SelectArticleBelongUserDAL
    {
        public string SelectUser(int id)
        {
            string sql = "select UserName from T_User where ID=@id";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@id",id)
            };
            return (string)SqlHelper.ExecuteScalar(sql, CommandType.Text, sp);
        }
    }
}