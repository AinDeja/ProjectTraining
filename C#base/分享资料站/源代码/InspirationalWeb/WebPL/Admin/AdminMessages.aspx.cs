﻿using InspirationalWeb.BLL;
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
    public partial class AdminMessages : System.Web.UI.Page
    {
        public int list;
        protected int trpage;
        protected int pageNumber;
        protected int pageMax;
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckAdminLogin();

            B_Admin alist = new B_Admin();
            pageNumber = alist.PageMaxPlan(trpage);
            string id = Context.Request["id"];
            string del = Context.Request["del"];
            if (del == "1")//判断是否执行删除操作
            {
                T_Admin dela = new T_Admin();
                dela.delMessagesWhereID(Convert.ToInt32(id));
                Response.Redirect("AdminMessages.aspx");
            }
            //批量删除
            if (Request.HttpMethod.ToLower() == "post")
            {
                string strBoth = Context.Request.Form["chkId"];
                if (string.IsNullOrEmpty(strBoth))
                {
                    Response.Redirect("AdminMessages.aspx");
                }
                else
                {
                    T_Admin dela = new T_Admin();
                    dela.delMessagesAll(strBoth);
                    Response.Redirect("AdminMessages.aspx");
                }
            }

            pageNumber = Convert.ToInt32(Context.Request["pageNumber"]);
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            T_Admin allMessages = new T_Admin();
            DataTable allMessagesList = allMessages.allMessagesList(pageNumber);
            foreach (DataRow dr in allMessagesList.Rows)
            {

                if ((bool)dr["IsDelete"] == false)
                {
                    string pd = String.Format("{0:yyyy/MM/dd}", dr["CreateTime"]);//格式化时间
                    tTr.Append("<tr class='mtr'>");
                    tTr.Append("<td><input type='checkbox' value='" + dr["ID"] + "' name='chkId'/></td>");
                    if (dr["MessBelongA"]!=null)
                    {
                        tTr.Append("<td>文章</td>");
                        tTr.Append("<td>" + dr["MessBelongA"] + "</td>");
                    }

                    else if (dr["MessBelongP"]!=null)
                    {
                        tTr.Append("<td>照片</td>");
                        tTr.Append("<td>" + dr["MessBelongP"] + "</td>");
                    }
                        
                    
                    tTr.Append("<td>" + dr["MessCreator"] + "</td>");

                    if (dr["MessTem"] != null)
                        tTr.Append("<td>" + dr["MessTem"] + "</td>");
                    else
                        tTr.Append("<td>空</td>");

                    tTr.Append("<td>" + pd + "</td>");
                    //tTr.Append("<td>" + dr["PostClass"] + "</td>");
                    tTr.Append("<td><span><a href='#' onclick='doDel(" + dr["ID"] + ")'>删除</a></span><span><a href='#' onclick=\"turnto('/WebPL/User/ArticleView.aspx?arID=" + dr["id"] + "');return false;\">浏览</a></span></td>");
                    tTr.AppendLine("</tr>");
                }

            }
        }
    }
}