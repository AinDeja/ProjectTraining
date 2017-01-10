using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class DeleteCommentDAL
    {
        public int DeleteComment(int deleteid)
        {
            string sql = "update T_Messages set IsDelete='true' where ID=@deleteid";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@deleteid",deleteid)
            };
            return (int)SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp);
        }
    }
}