using InspirationalWeb.BLL;
using InspirationalWeb.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InspirationalWeb.WebPL.Admin
{
    public partial class AdminCenter : System.Web.UI.Page
    {
        protected int list;
        protected int trpage;
        protected int pageNumber;
        protected int pageMax;
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
         protected System.Text.StringBuilder aTr = new System.Text.StringBuilder(500);
         protected System.Text.StringBuilder aTr1 = new System.Text.StringBuilder(500);
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckAdminLogin();

            int a = Convert.ToInt32(Context.Request["list"]);
            
      
           
            if (a == 0)
            {
                T_Admin indexall = new T_Admin();
               int[] listAll=new int[3];
                listAll=indexall.CountAll();
                tTr.Append("<ul><li>文章总数："+listAll[0]+" </li>");
                tTr.Append("<li>图片总数："+listAll[1]+" </li>");
                tTr.Append("<li>留言总数："+listAll[2]+" </li></ul>");
            }
            else if (a == 1)
            {
                   
                 
                        
                   
                

            }
        }
    }
}