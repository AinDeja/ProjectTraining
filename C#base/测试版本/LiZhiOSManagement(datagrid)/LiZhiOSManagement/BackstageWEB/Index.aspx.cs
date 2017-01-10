using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiZhiOSManagement.WEB
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            //Session["quan"] = smm.quan.ToString();
            string s = Request.Params["ShowID"];
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            List<Managers> listm = new List<Managers>();
            List<SuperManagers> listsm = new List<SuperManagers>();
            listm = smm.selectM();
            string ce = null;
            foreach (var item in listm)
            {
                ce = BitConverter.ToString(new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(System.Text.Encoding.Default.GetBytes(item.UserName+item.UserPassWord))).Replace("-","");
                string ss = ce;
                if(ce==s)
                {
                    Session["quan"] = "m";
                    Session["name"] = item.UserName;
                    if (smm.selectsm(item.UserName) > 0)
                    {
                        Session["quan"] = "sm";
                    }
                    break;
                }
            }

        }
    }
}