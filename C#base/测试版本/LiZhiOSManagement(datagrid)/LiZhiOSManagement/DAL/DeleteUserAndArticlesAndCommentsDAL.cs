using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class DeleteUserAndArticlesAndCommentsDAL
    {
        public int deleteFromMessages(string names)    //删除评论
        {
            //string sql = "delete from T_Messages where CommentUser=@name";
            //SqlParameter sp = new SqlParameter("@name", name);
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery("delete from T_Messages where CommentUser in('"+names+"')", CommandType.Text));
        }
        public int deleteFromArticle(string names)   //删除文章
        {
            //string sql = "delete from T_Article where BelongUser in (select ID from T_User where UserName=@name)";
            //SqlParameter sp = new SqlParameter("@name", name);
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery("delete from T_Article where BelongUser in (select ID from T_User where UserName in('"+names+"'))", CommandType.Text));
        }
        public int deleteFromUser(string ids)
        {
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery("delete from T_User where ID in("+ids+")", CommandType.Text));
        }
        public int deleteFromManager(string ids)
        {
            //string sql = "delete from T_Managers where ID=@id";
            //SqlParameter sp = new SqlParameter("@id",id);
            return Convert.ToInt32(SqlHelper.ExecuteNonQuery("delete from T_Managers where ID in("+ids+")",CommandType.Text));
        }
    }
}