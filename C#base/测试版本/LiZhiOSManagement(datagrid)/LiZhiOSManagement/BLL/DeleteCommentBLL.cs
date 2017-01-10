using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class DeleteCommentBLL
    {

        public int DeleteComment(int deleteid)
        {
            DeleteCommentDAL dcd = new DeleteCommentDAL();
            return dcd.DeleteComment(deleteid);
        }

    }
}