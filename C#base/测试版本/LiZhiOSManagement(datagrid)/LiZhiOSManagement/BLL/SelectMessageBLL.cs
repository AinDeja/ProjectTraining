using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class SelectMessageBLL
    {
        public List<Messages> selectMessages(int id)               //初始，正序
        {
            SelectMessageDAL smdal = new SelectMessageDAL();

            return smdal.selectMessages(id);
        }
        //public string selectMessagesBelongUser(int messagesId,int i)
        //{
        //    SelectMessageDAL sm = new SelectMessageDAL();
        //    return sm.selectMessagesBelongUser(messagesId,i);
        //}

        public List<Messages> selectMessagesByTimeDesc(int id)               //按照时间降序
        {
            SelectMessageDAL smdal = new SelectMessageDAL();
            return smdal.selectMessagesByTimeDesc(id);
        }

        public List<Messages> selectMessagesByFavoriteDesc(int id)                    //按照喜欢降序
        {
            SelectMessageDAL smdal = new SelectMessageDAL();
            return smdal.selectMessagesByFavoriteDesc(id);
        }

        public string selectMessagesBelongSUser(int messagesId)
        {
            SelectMessageDAL smdal = new SelectMessageDAL();
            return smdal.selectMessagesBelongSUser(messagesId);
        }

    }
}