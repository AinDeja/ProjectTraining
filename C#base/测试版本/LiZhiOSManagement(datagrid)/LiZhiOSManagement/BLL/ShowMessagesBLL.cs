using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class ShowMessagesBLL
    {
        ShowMessagesDAL sm = new ShowMessagesDAL();

        public List<Messages> selectAllMessages()
        {
            return sm.selectAllMessages();
        }

        public List<Messages> showAllMessages(int id)
        {
            return sm.showAllMessages(id);
        }
        public List<Messages> showMessages(int id)
        {
            
            return sm.showMessages(id);
        }
        public List<Messages> showMoreMessages(int articleid,int cid)
        {
            return sm.showMoreMessages(articleid,cid);
        }



        




    }
}