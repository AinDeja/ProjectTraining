using InspirationalWeb.BLL;
using InspirationalWeb.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InspirationalWeb.WebPL
{
    public partial class ArticleList : System.Web.UI.Page
    {
        protected string tip;
        protected int pageNumber;
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder pTr = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder aTr = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder imgTr = new System.Text.StringBuilder(500);
        protected void Page_Load(object sender, EventArgs e)
        {
 //登录监测
            string name = Context.Request["Name"];
            string password = Context.Request["PassWord"];
            int ck = 0;
           
            if (Request.HttpMethod.ToLower() == "post")
            {

                B_User bll = new B_User();
                LoginResult result = bll.Login1(name, password, out name);
                switch (result)
                {
                    case LoginResult.UserNotExists:
                        tip = ("用户不存在！");

                        break;
                    case LoginResult.ErrorPassword:
                        tip = ("密码错误！");
                        break;
                    case LoginResult.OK:
                        tip = ("登录成功!");
                        ck = 1;
                        break;
                    default:
                        tip = ("未知错误！");
                        break;
                }
                Distinguish.LoginMess(tip);

            }
            if (ck == 1)
            {
                Session["Name"] = name;
                Response.Redirect("User/UserCenter.aspx");
            }
            
            
            //Menu
            T_Menu menu = new T_Menu();
            DataTable Menu = menu.SelsctArMenu();
            DataTable MenuSon = menu.SelsctArMenuSon();
            DataTable MenuPhoto = menu.SelsctPoMenu();
            foreach (DataRow dr in Menu.Rows)
            {
                tTr.Append("<li><a class='hide' href='javascript:volid(0);'>" + dr["TypeName"] + "</a>");
                tTr.Append("<ul>");
                foreach (DataRow sdr in MenuSon.Rows)
                {
                    if (Convert.ToInt32(sdr["TypeFather"]) == Convert.ToInt32(dr["ID"]))
                        tTr.Append(" <li><a href='/WebPL/ArticleList.aspx?typeID="+sdr["ID"]+"'>" + sdr["TypeName"] + "</a></li>");
                }

                tTr.Append("</ul>");
                tTr.AppendLine("</li>");
            }
            //Photo Menu
            foreach (DataRow pdr in MenuPhoto.Rows)
            {

                pTr.Append(" <li><a href='/WebPL/User/UserAlbum.aspx?typeID=" + pdr["ID"] + "&pageNumber=1'>" + pdr["AlbumName"] + "</a></li>");
            }
            //ArticleLis
            if (Convert.ToInt32(Session["typeID"]) != Convert.ToInt32(Context.Request["typeID"]))
            Session["typeID"] = Context.Request["typeID"];
            int typeid=Convert.ToInt32(Session["typeID"]);
            pageNumber = Convert.ToInt32(Context.Request["pageNumber"]);
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            T_ArticleSelect article = new T_ArticleSelect();
            DataTable arList = article.typeArticleList(pageNumber, typeid);
            if(arList.Rows.Count!=0)
            foreach (DataRow dr in arList.Rows)
            {
                if ((bool)dr["IsDelete"] == false)
                { 
                string pd = String.Format("{0:yyyy/MM/dd}", dr["CreateTime"]);//格式化时间
                aTr.Append("<tr class='mtr'onclick=\"turnto('/WebPL/User/ArticleView.aspx?arID=" + dr["id"] + "')\">");

                aTr.Append("<td>" + dr["ArTitle"] + "</td>");
                aTr.Append("<td>" + dr["ArCreator"] + "</td>");
                aTr.Append("<td>" + pd + "</td>");
                aTr.AppendLine("</tr>");
            }
            }
            else
            {

                aTr.Append("<tr class='mtr'>");

                aTr.Append("<td></td>");
                aTr.Append("<td>此类别文章为空！</td>");
                aTr.Append("<td></td>");
                aTr.AppendLine("</tr>");
            }
        }
    }
}