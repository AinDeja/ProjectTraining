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
        public List<User> ShowUsers(string belongkind)
        {
            return sum.ShowUsers(belongkind);
        }



        public List<User> ShowUsersById(int id)
        {
            return sum.ShowUsersById(id);
        }
        public string selectGroupbyName(string name)
        {
            return sum.selectGroupbyName(name);
        }


        public List<User> ShowUsersByIsDelete(string isdelete)                                       //boolean模糊查询  IsDelete
        {
            return sum.ShowUsersByIsDelete(isdelete);
        }

        public List<User> ShowUsersByCreattime(string dt)
        {
            return sum.ShowUsersByCreattime(dt);
        }

        public List<User> ShowUsersByUserName(string username)
        {
            return sum.ShowUsersByUserName(username);
        }
        public List<User> ShowUsersByUserPassWord(string pwd)                                          //userpassword
        {
            return sum.ShowUsersByUserPassWord(pwd);
        }
        public List<User> ShowUsersByUserSex(string usersex)                                          //usresex
        {
            return sum.ShowUsersByUserSex(usersex);
        }
        public List<User> ShowUsersByUserQQ(string userqq)                                          //usresex
        {
            return sum.ShowUsersByUserQQ(userqq);
        }
        public List<User> ShowUsersByUserPhone(string userphone)                                          //userphone
        {
            return sum.ShowUsersByUserPhone(userphone);
        }
        public List<User> ShowUsersByUserStuID(string userstuid)                                          //UserStuID
        {
            return sum.ShowUsersByUserStuID(userstuid);
        }
        public List<User> ShowUsersByUserFname(string userfname)
        {
            return sum.ShowUsersByUserFname(userfname);
        }
        public List<User> ShowUsersByUserIP(string userip)
        {
            return sum.ShowUsersByUserIP(userip);
        }
        public List<User> ShowUsersBybelong(string belong)
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

        public List<User> selectAllUsers()
        {
            return sum.selectAllUsers();
        }
        public List<User> selectUserNameId(string name)
        {
            return sum.selectUserNameId(name);
        }


        public List<User> addManagersFromUsers(string ids)
        {
            return sum.addManagersFromUsers(ids);
        }
    }
}