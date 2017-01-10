using InspirationalWeb.BLL;
using InspirationalWeb.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InspirationalWeb.WebPL.User
{
    public partial class UserArticleManage : System.Web.UI.Page
    
    {
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected int trpage;
        protected int pageNumber;
        protected int pageMax;
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckLogin();
            //int pt = Convert.ToInt32(Context.Request["postType"]);
            //PostType = pt;//获取贴子类型
            //Session["postType"] = pt;
            //string username = Session["Name"].ToString();
            if (Request.HttpMethod.ToLower() == "post")
            {
                int uid = 5;
                string SerchText = Context.Request["serchText"];
                T_User uidname = new T_User();
               string username= uidname.UserNameSearchByID(uid);
                T_ArticleSelect searchList = new T_ArticleSelect();
                DataTable searchOut = searchList.SerchArticle(uid, SerchText);
                string id = Context.Request["id"];
                string del = Context.Request["del"];
                if (del == "1")//判断是否执行删除操作
                {
                    T_ArticleSelect dela = new T_ArticleSelect();
                    dela.delArticle(id);
                    Response.Redirect("UserArticleManage.aspx");
                }
                //批量删除
                if (Request.HttpMethod.ToLower() == "post")
                {
                    string strBoth = Context.Request.Form["chkId"];
                    if (string.IsNullOrEmpty(strBoth))
                    {
                        Response.Redirect("UserArticleManage.aspx");
                    }
                    else
                    {
                        T_ArticleSelect dela = new T_ArticleSelect();
                        dela.delArticle(strBoth);
                        Response.Redirect("UserArticleManage.aspx");
                    }
                }


                if(searchOut.Rows.Count!=0)
                foreach (DataRow dr in searchOut.Rows)
                {
                    if ((bool)dr["IsDelete"] == false)
                    {
                        string pd = String.Format("{0:yyyy/MM/dd}", dr["CreateTime"]);//格式化时间
                        tTr.Append("<tr class='mtr'> onclick=\"turnto('/WebPL/User/ArticleView.aspx?arID=" + dr["id"] + "')\">");
                        tTr.Append("<td><input type='checkbox' value='" + dr["ID"] + "' name='chkId'/></td>");
                        tTr.Append("<td>" + username + "</td>");
                        tTr.Append("<td>" + dr["ArTitle"] + "</td>");
                        tTr.Append("<td>" + pd + "</td>");
                        tTr.Append("<td><a href='javascript:void(0)' onclick='doDel(" + dr["ID"] + ")'>删除</a></td>");
                        tTr.AppendLine("</tr>");
                    }
                }
                else
                {
                   
                        tTr.Append("<tr class='mtr'>");
                        tTr.AppendLine("</tr>");

                        tTr.Append("<tr class='mtr'>");
                        tTr.Append("<td></td>");
                        tTr.Append("<td>没有符合条件的内容</td>");
                        tTr.Append("<td></td>");
                        tTr.AppendLine("</tr>");
                    
                }
            }
            else
            {
                int username = 0;
                B_User alist = new B_User();
                

                T_User sr = new T_User();
                DataTable articleList= sr.pagingT(username,alist.PageMaxPlan(username, trpage));
                pageNumber = alist.PageMaxPlan(username, trpage);
                foreach (DataRow dr in articleList.Rows)
                {
                    if ((bool)dr["IsDelete"] == false)
                    {
                        string pd = String.Format("{0:yyyy/MM/dd}", dr["CreateTime"]);//格式化时间
                        tTr.Append("<tr class='mtr' >");
                        tTr.Append("<td><input type='checkbox' value='" + dr["ID"] + "' name='chkId'/></td>");
                        tTr.Append("<td>" + username + "</td>");
                        tTr.Append("<td>" + dr["ArTitle"] + "</td>");
                        tTr.Append("<td>" + pd + "</td>");
                        tTr.Append("<td><span><a href='javascript:void(0)' onclick='doDel(" + dr["ID"] + ")'>删除</a></span><span><a href='#' onclick=\"turnto('/WebPL/User/ArticleView.aspx?arID=" + dr["id"] + "');return false;\">浏览</a></span></td>");
                        tTr.AppendLine("</tr>");
                    }
                }

            }
        }
    }
}