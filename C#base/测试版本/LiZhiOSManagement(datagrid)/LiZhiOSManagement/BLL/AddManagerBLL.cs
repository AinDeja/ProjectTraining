using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class AddManagerBLL
    {
        AddManagerDAL am = new AddManagerDAL();
        public int insertManagers(bool isdelete, DateTime createtime, string username, string userpassword, string usersex, long userqq, long userphone, long userstuid, string userfname, string userip, string belong)
        {
            return am.insertManagers(isdelete, createtime, username, userpassword, usersex, userqq, userphone, userstuid, userfname, userip, belong);
        }
        public int updateManagers(int id, bool isdelete, DateTime createtime, string username, string pwd, string usersex, long userqq, long userphone, long userstuid, string userfname, string userip, string belong)
        {
            
            return am.updateManagers(id, isdelete, createtime, username, pwd, usersex, userqq, userphone, userstuid, userfname, userip, belong);
        }
    }
}