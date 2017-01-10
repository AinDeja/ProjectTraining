using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.BLL
{
    public class SelectLoginBLL
    {
        public DataTable SelectName(string txtUser, string txtPwd)
        {
            SelectLoginDAL SLDAL = new SelectLoginDAL();
            return SLDAL.SelectName(txtUser, txtPwd);
        }
    }
}