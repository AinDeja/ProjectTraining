using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class ShowUsersMessagesBLL
    {
        ShowUsersMessagesDAL sum = new ShowUsersMessagesDAL();
        public List<Users> ShowUsers(string belongkind)
        {
            return sum.ShowUsers(belongkind);
        }



        public List<Users> ShowUsersById(int id)
        {
            return sum.ShowUsersById(id);
        }
        public string selectGroupbyName(string name)
        {
            return sum.selectGroupbyName(name);
        }


        public List<Users> ShowUsersByIsDelete(string isdelete)                                       //boolean模糊查询  IsDelete
        {
            return sum.ShowUsersByIsDelete(isdelete);
        }

        public List<Users> ShowUsersByCreattime(string dt)
        {
            return sum.ShowUsersByCreattime(dt);
        }

        public List<Users> ShowUsersByUserName(string username)
        {
            return sum.ShowUsersByUserName(username);
        }
        public List<Users> ShowUsersByUserPassWord(string pwd)                                          //userpassword
        {
            return sum.ShowUsersByUserPassWord(pwd);
        }
        public List<Users> ShowUsersByUserSex(string usersex)                                          //usresex
        {
            return sum.ShowUsersByUserSex(usersex);
        }
        public List<Users> ShowUsersByUserQQ(string userqq)                                          //usresex
        {
            return sum.ShowUsersByUserQQ(userqq);
        }
        public List<Users> ShowUsersByUserPhone(string userphone)                                          //userphone
        {
            return sum.ShowUsersByUserPhone(userphone);
        }
        public List<Users> ShowUsersByUserStuID(string userstuid)                                          //UserStuID
        {
            return sum.ShowUsersByUserStuID(userstuid);
        }
        public List<Users> ShowUsersByUserFname(string userfname)
        {
            return sum.ShowUsersByUserFname(userfname);
        }
        public List<Users> ShowUsersByUserIP(string userip)
        {
            return sum.ShowUsersByUserIP(userip);
        }
        public List<Users> ShowUsersBybelong(string belong)
        {
            return sum.ShowUsersBybelong(belong);
        }




        public string showUserName(int id)   //查找用户名
        {
            return sum.selectUserName(id);
            
        }
        public string selectGroup(string belonggrouptype)
        {
            return sum.selectGroup(belonggrouptype);
        }


        public int selectUseridbyname(string name)
        {
            return sum.selectUseridbyname(name);
        }

        public List<Users> selectAllUsers()
        {
            return sum.selectAllUsers();
        }
        public List<Users> selectUserNameId(string name)
        {
            return sum.selectUserNameId(name);
        }


        public List<Users> addManagersFromUsers(string ids)
        {
            return sum.addManagersFromUsers(ids);
        }
    }
}