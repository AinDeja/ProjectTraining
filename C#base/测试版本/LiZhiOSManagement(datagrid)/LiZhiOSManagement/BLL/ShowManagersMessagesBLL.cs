using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    
    public class ShowManagersMessagesBLL
    {
        ShowManagersMessagesDAL sum= new ShowManagersMessagesDAL();
        public List<Managers> ShowManagers(string belongkind)
        {
            return sum.ShowManagers(belongkind);
        }
        public int selectQuan(string name,string pwd)
        {
            return sum.selectQuan(name, pwd);
        }
        public List<Managers> selectM()
        {
            return sum.selectM();
        }
        public List<SuperManagers> selectSM()
        {
            return sum.selectSM();
        }


        public List<Managers> showManagersByID(int id)
        {
            return sum.showManagersByID(id);
        }

        public List<Managers> showManagersByIsDelete(string isdelete)
        {
            return sum.showManagersByIsDelete(isdelete);
        }

        public List<Managers> showManagersByCreattime(string dt)
        {
            return sum.showManagersByCreattime(dt);
        }

        public List<Managers> showManagersByUserName(string username)
        {
            return sum.showManagersByUserName(username);
        }

        public List<Managers> showManagersByUserPassWord(string pwd)
        {
            return sum.showManagersByUserPassWord(pwd);
        }

        public List<Managers> showManagersByUserSex(string usersex)
        {
            return sum.showManagersByUserSex(usersex);
        }

        public List<Managers> showManagersByUserQQ(string userqq)
        {
            return sum.showManagersByUserQQ(userqq);
        }

        public List<Managers> showManagersByUserPhone(string userphone)
        {
            return sum.showManagersByUserPhone(userphone);
        }

        public List<Managers> showManagersByUserStuID(string userstuid)
        {
            return sum.showManagersByUserStuID(userstuid);
        }

        public List<Managers> showManagersByUserFname(string userfname)
        {
            return sum.showManagersByUserFname(userfname);
        }

        public List<Managers> showManagersByUserIP(string userip)
        {
            return sum.showManagersByUserIP(userip);
        }

        public List<Managers> showManagersBybelong(string belong)
        {
            return sum.showManagersBybelong(belong);
        }
        public int selectsm(string name)
        {
            return sum.selectsm(name);
        }

    }
}