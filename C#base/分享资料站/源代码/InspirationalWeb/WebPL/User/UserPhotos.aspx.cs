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
    public partial class UserPhotos : System.Web.UI.Page
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
            //Photo Album
            pageNumber = Convert.ToInt32(Context.Request["pageNumber"]);
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            if (Convert.ToInt32(Session["typeID"]) != Convert.ToInt32(Context.Request["typeID"]) && Convert.ToInt32(Context.Request["typeID"]) != 0)
                Session["typeID"] = Context.Request["typeID"];
            int typeid = Convert.ToInt32(Session["typeID"]);
            T_Img down = new T_Img();
            DataTable downlist = down.down(typeid, pageNumber);
            int i = 0, j = 0, k = 0;
            if (downlist.Rows.Count == 0)
                imgTr.Append("<p>此相册无照片！</p>");
            foreach (DataRow imgdr in downlist.Rows)
            {


                if (j == 0)
                    imgTr.Append("<ul class='imgUL'>");
                j = 1;
                if (i < 3)
                {
                    imgTr.Append("<li><div class='imgOut'><div class='imgIn'><img src='" + imgdr["ImgPath"] + "' /></div><p>" + imgdr["ImgMess"] + "</p></div></li>");
                    k++; i++;
                }
                if (k == 3)
                {
                    imgTr.Append("</ul>");
                    i = 0;
                    j = 0;
                    k = 0;
                }





            }

        }
    }
}