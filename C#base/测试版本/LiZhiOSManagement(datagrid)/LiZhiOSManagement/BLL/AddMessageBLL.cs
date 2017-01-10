using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class AddMessageBLL
    {
        public int addMessage(bool IsDelete, DateTime CreateTime, string MessTem, int ArticleID, string MessBelong, int CID, string CommentUser)
        {
            AddMessageDAL amdal = new AddMessageDAL();
            return amdal.addMessage(IsDelete, CreateTime, MessTem, ArticleID, MessBelong, CID, CommentUser);
        }

    }
}