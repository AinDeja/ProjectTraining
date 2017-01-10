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
    public partial class Index : System.Web.UI.Page
    {
        protected string tip;
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder pTr = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder aTr = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder imgTr = new System.Text.StringBuilder(500);
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Context.Request["Name"];
            string password = Context.Request["PassWord"];
            int ck = 0;
            //登录监测
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
                //tTr.Append("<li class='hide'>" + dr["TypeName"] + " ");
                tTr.Append("<ul>");
                foreach(DataRow sdr in MenuSon.Rows)
                {
                    if (sdr["TypeFather"].ToString() == dr["ID"].ToString())
                        tTr.Append(" <li><a href='/WebPL/ArticleList.aspx?typeID=" + sdr["ID"] + "'>" + sdr["TypeName"] + "</a></li>");
                }
                
                tTr.Append("</ul>");
                tTr.AppendLine("</li>");
            }
            //Photo Menu
            foreach (DataRow pdr in MenuPhoto.Rows)
            {
                if (Convert.ToInt32(pdr["AlbumCreator"]) == 1)
                pTr.Append(" <li><a href='/WebPL/User/UserAlbum.aspx?typeID=" + pdr["ID"] + "&pageNumber=1'>" + pdr["AlbumName"] + "</a></li>");
            }
            //NewArticle
            T_ArticleSelect article = new T_ArticleSelect();
            DataTable newArticle = article.NewArticle();
            foreach (DataRow adr in newArticle.Rows)
            {

                if ((bool)adr["IsDelete"] == false)
                {
                    string pd = String.Format("{0:yyyy/MM/dd}", adr["CreateTime"]);//格式化时间
                    aTr.Append(" <h2><span>●</span><a href='/WebPL/User/ArticleView.aspx?arID=" + adr["ID"] + "'>" + adr["ArTitle"] + "</a></h2>");
                    aTr.Append("" + adr["ArCont"] + "<span class='newArTime'>" + pd + "</span>");
                }
            }
            //NewPhotos
            T_Img imgTurn = new T_Img();
            DataTable imgs = imgTurn.turn();
            foreach (DataRow imgr in imgs.Rows)
            {
                imgTr.Append(" <li><img src=" + imgr["ImgPath"] + " /></li>");


            }
    
        }
    }
}