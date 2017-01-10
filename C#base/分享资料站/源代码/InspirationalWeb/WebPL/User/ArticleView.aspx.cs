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
    public partial class ArticleView : System.Web.UI.Page
    {
        protected System.Text.StringBuilder replyTr = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder lastTr = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder nextTr = new System.Text.StringBuilder(500);
        protected string arTitle, arAuthor, arContents, arTime;
        protected string lastTitle, lastAuthor, lastContents, lastTime;
        protected string nextTitle, nextAuthor, nextContents, nextTime;
        protected string tip,lnlast,lnnext;
        protected int j=0;//评论总数计数器
        protected void Page_Load(object sender, EventArgs e)
        {
            int lnid=Convert.ToInt32(Context.Request["ln"]);
            if (Session["ARID"] == null || Convert.ToInt32(Session["ARID"])!=lnid)
            Session["ARID"] = Context.Request["arID"];
            int dadadsa = Convert.ToInt32(Context.Request["arID"]);

            //文章
            B_User view = new B_User();
            DataTable arView = view.ArticleViewB(Convert.ToInt32(Session["ARID"]));
            if (arView.Rows.Count != 0) { 
            DataRow ar = arView.Rows[0];
            arTitle = ar["ArTitle"].ToString();
            arAuthor = view.ArticleAuthor(0);//0为用户id
            arContents = ar["ArCont"].ToString();
            arTime = String.Format("{0:yyyy/MM/dd}", ar["CreateTime"]);
            //上一篇和下一篇
            lnlast = "上一篇：";
            lnnext = "下一篇：";
            T_ArticleSelect ln = new T_ArticleSelect();
            DataTable lastArticle = ln.LastArticle(Convert.ToInt32(Session["ARID"]));
            if (lastArticle.Rows.Count != 0)
            {
                DataRow last = lastArticle.Rows[0];
                if ((bool)last["IsDelete"] == false)
                {
                    lastTitle = last["ArTitle"].ToString();
                    lastAuthor = view.ArticleAuthor(0);//0为用户id
                    lastContents = last["ArCont"].ToString();
                }
                else
                {
                    tip = "没有上一篇了！";
                    lnlast = "";
                    lastTitle = tip;

                }
                //上一篇
                if (lnid == 1)
                {
                    Session["ARID"] = last["ID"];
                    Response.Redirect("ArticleView.aspx?arID=" + last["ID"] + "");
                }
            }
            else
            {
                tip = "没有上一篇了！";
                lnlast = "";
                lastTitle = tip;
            }
           
            
            DataTable nextArticle = ln.NextArticle(Convert.ToInt32(Session["ARID"]));
            if (nextArticle.Rows.Count != 0)
            {
                DataRow next = nextArticle.Rows[0];
                if ((bool)next["IsDelete"]== false)
                {
                    
                    nextTitle = next["ArTitle"].ToString();
                    nextAuthor = view.ArticleAuthor(0);//0为用户id
                    nextContents = next["ArCont"].ToString();
                }
                else
                {
                    tip = "没有上一篇了！";
                    lnlast = "";
                    lastTitle = tip;
                }
                //下一篇
                if (lnid == 2)
                {
                    Session["ARID"] = next["ID"];
                    Response.Redirect("ArticleView.aspx");

                }

            }
            else
            {
                tip = "没有下一篇了！";
                lnnext = "";
                nextTitle = tip;
            }
            }

            lastTr.Append("<a href='/WebPL/User/ArticleView.aspx?ln=1&arID=" + Convert.ToInt32(Session["ARID"]) + "'>" + lnlast + lastTitle + "</a>");
            nextTr.Append("<a href='/WebPL/User/ArticleView.aspx?ln=2&arID=" + Convert.ToInt32(Session["ARID"]) + "'>" + lnnext + nextTitle + "</a>");
           

            
            //回复
            T_Reply re = new T_Reply();
            DataTable reply = re.ArticleReply(Convert.ToInt32(Session["ARID"]));
           T_User uname=new T_User();
            string replyname;
            int i = 1;//楼层计数器
           
            foreach (DataRow replyDr in reply.Rows)
            {
                string pd = String.Format("{0:yyyy/MM/dd}", replyDr["CreateTime"]);//格式化时间
                replyname =uname.UserNameSearchByID(Convert.ToInt32(replyDr["MessCreator"]));
                replyTr.Append("<li class='replayLi'><div class='userMess'><a href='#'>" +replyname+ "</a></div>");
                replyTr.Append("<ul class='replayMain'><li class='index'><a href='#'>" + i + "楼</a>");
                replyTr.Append("<span class='reTime'>发表时间：" + pd + "</span></li>");
                replyTr.Append("<li><p>" + replyDr["MessTem"] + "</p></li>");
                //replyTr.Append("<li><span class='reBt'><a href='#'>回复</a></span></li></ul></li>");
                replyTr.Append("<li><span class='reBt'></li></ul></li>");
                i++;
                j++;
            }

            if (Request.HttpMethod.ToLower() == "post")
            {

                if (Session["Name"] != null)
                {
                    T_User uid = new T_User();
                    int userid = uid.IDByUserNameSearch(Session["Name"].ToString());
                    string text = Context.Request["txteditor"];
                    re.NewArticleReply(text, userid, Convert.ToInt32(Session["ARID"]));
                    Response.Redirect("ArticleView.aspx?arID=" + Session["ARID"] + "");
                }
                else
                    Distinguish.CheckLogin();
            }

            

        }
    }
}