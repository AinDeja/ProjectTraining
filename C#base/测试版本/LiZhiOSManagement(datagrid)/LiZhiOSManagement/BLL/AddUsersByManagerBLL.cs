using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class AddUsersByManagerBLL
    {
        AddUsersByManagerDAL aubm = new AddUsersByManagerDAL();
        public int insertUsers(bool isdelete,DateTime createtime,string username,string userpassword,string usersex,long userqq,long userphone,long userstuid,string userfname,string userip,string belong)
        {
            return aubm.insertUsers(isdelete,createtime,username,userpassword,usersex,userqq,userphone,userstuid,userfname,userip,belong);
        }
        public int updateUsers(int id, bool isdelete, DateTime createtime, string username, string pwd, string usersex, long userqq, long userphone, long userstuid, string userfname, string userip, string belong)
        {
            return aubm.updateUsers(id,isdelete,createtime,username,pwd,usersex,userqq,userphone,userstuid,userfname,userip,belong);
        }
    }
}