using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class DeleteSignBLL
    {
        T_SignIN DeleteFromID=new T_SignIN();

        public string deleteSign(string day)
        {
            DeleteFromID.DeleteDay(day);
            return "OKfromBLL";
        }

    }
}