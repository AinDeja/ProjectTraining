using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class SelectLoginDAL
    {
        public DataTable SelectName(string txtUser, string txtPwd)
        {
            string sql = "select ID,UserName from T_User where UserName=@UserName and UserPassWord=@UserPassWord";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@UserName",txtUser),
                new SqlParameter("@UserPassWord",txtPwd)
            };
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
        }
    }
}