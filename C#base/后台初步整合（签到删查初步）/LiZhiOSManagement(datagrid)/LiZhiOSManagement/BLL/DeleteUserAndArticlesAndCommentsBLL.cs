using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class DeleteUserAndArticlesAndCommentsBLL
    {
        DeleteUserAndArticlesAndCommentsDAL dua = new DeleteUserAndArticlesAndCommentsDAL();

        public int deleteUser(string ids,string names)
        {
            int m = dua.deleteFromUser(ids);//删除用户
            int s = dua.deleteFromMessages(names);// 删除评论
            int u = dua.deleteFromArticle(names); //删除文章
            
            if (s + u + m >= 1)
            {
                return m;
            }
            else
            {
                return 0;
            }
        }
        public int deleteManager(string ids)
        {
            return dua.deleteFromManager(ids);
        }

    }
}