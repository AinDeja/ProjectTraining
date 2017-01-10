using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class AddManagerDAL
    {
        public int insertManagers(bool isdelete, DateTime createtime, string username, string userpassword, string usersex, long userqq, long userphone, long userstuid, string userfname, string userip, string belong)
        {
            string sql = "insert into T_Managers(IsDelete,CreateTime,UserName,UserPassWord,UserSex,UserQQ,UserPhone,UserStuID,UserFname,UserIP,belong) values(@isdelete,@createtime,@username,@userpassword,@usersex,@userqq,@userphone,@userstuid,@userfname,@userip,@belong); ";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@isdelete",isdelete),
                new SqlParameter("@createtime",createtime),
                new SqlParameter("@username",username),
                new SqlParameter("@userpassword",userpassword),
                new SqlParameter("@usersex",usersex),
                new SqlParameter("@userqq",userqq),
                new SqlParameter("@userphone",userphone),
                new SqlParameter("@userstuid",userstuid),
                new SqlParameter("@userfname",userfname),
                new SqlParameter("@userip",userip),
                new SqlParameter("@belong",belong)
            };
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp));
        }

        public int updateManagers(int id, bool isdelete, DateTime createtime, string username, string pwd, string usersex, long userqq, long userphone, long userstuid, string userfname, string userip, string belong)
        {
            string sql = "update T_Managers set IsDelete=@isdelete,CreateTime=@createtime,UserName=@username,UserPassWord=@pwd,UserSex=@usersex,UserQQ=@userqq,UserPhone=@userphone,UserStuID=@userstuid,UserFname=@userfname,UserIP=@userip,belong=@belong where ID=@id";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@id",id),
                new SqlParameter("@isdelete",isdelete),
                new SqlParameter("@createtime",createtime),
                new SqlParameter("@username",username),
                new SqlParameter("@pwd",pwd),
                new SqlParameter("@usersex",usersex),
                new SqlParameter("@userqq",userqq),
                new SqlParameter("@userphone",userphone),
                new SqlParameter("@userstuid",userstuid),
                new SqlParameter("@userfname",userfname),
                new SqlParameter("@userip",userip),
                new SqlParameter("@belong",belong)
            };
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sp));
        }
    }
}