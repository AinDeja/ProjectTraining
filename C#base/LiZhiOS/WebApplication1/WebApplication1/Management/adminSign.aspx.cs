using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestForNet.DAL;
using WebApplication1.BLL;

namespace WebApplication1.Management
{
    public partial class adminSign : System.Web.UI.Page
    {
        protected System.Text.StringBuilder sginList = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder pageList = new System.Text.StringBuilder(500);
        protected int pageRemainder;
        protected int pageNumber;
        protected int pageMax;
        protected void Page_Load(object sender, EventArgs e)
        {
            T_SignIN lists = new T_SignIN();
            DataTable viewList=lists.adminSginList();
            pageRemainder = viewList.Rows.Count;//数据总条数
            PageCtrl pageCtrl = new PageCtrl();
            pageMax = pageCtrl.pageMax(pageRemainder);
            int trpage = Convert.ToInt32(Context.Request["trpage"]);
            pageNumber = pageCtrl.pageMove(pageMax, pageRemainder, trpage, pageNumber);
        
            viewList=lists.SginListCut(pageNumber);

                foreach (DataRow dr in viewList.Rows)
                {
                    sginList.Append("<li><span><img src='images/001.jpg' /></span><div class='lright'>");
                    sginList.Append("<h2>" + dr["toDay"] + "</h2>");
                    sginList.Append("<p>总人数：28<br />应签:28<br />实签:" + dr[1] + "</p>");
                    sginList.Append("<a class='enter' href='adminSignView.aspx?today=" + dr["toDay"] + "'>查看详情</a>");
                    sginList.Append("</div> </li>");
                    sginList.Append("");
                }

            ///页码tool
                for (int page = 1; page < pageMax+1; page++)
                {
                    if(page<=5)
                    pageList.Append("<li class='paginItem'><a href='adminSign.aspx?trpage=" + page + "'>" + page + "</a></li>"); 
                    else if(page==pageMax)
                        pageList.Append("<li class='paginItem'><a href='adminSign.aspx?trpage=" + pageMax + "'>" + pageMax + "</a></li>");
                    else if(page==6)
                        pageList.Append("<li class='paginItem more'><a href='javascript:;'>...</a></li>"); 
                }
                
            
        }

        public static string outExcle()
        {
            string tip = "OK!";
            string pathSelf = @"H:/新建文件夹/outsign.xlsx";
            T_SignIN SignTable = new T_SignIN();
            DataSet selectDateSign = SignTable.outExcle("2016/10/01", "2016/11/01");

            OutForExcle outxls = new OutForExcle();
            outxls.DataSetToLocalExcel(selectDateSign, pathSelf, false);
            return tip;
        }

    }
}