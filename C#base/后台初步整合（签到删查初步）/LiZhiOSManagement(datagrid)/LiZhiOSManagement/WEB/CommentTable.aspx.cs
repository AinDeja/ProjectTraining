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
    public partial class CommentTable : System.Web.UI.Page
    {
        public List<Article> listlouzhu;    //楼主文章内容
        public List<Messages> listMessages;  // 一层评论
        public List<Messages> listMoreMessages;    //n层评论      n>1
        public List<Messages> listwho;
        public int content = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            listlouzhu=new List<Article>();
            ShowCommentsBLL scbll = new ShowCommentsBLL();
            //Request.Params["cellname"].GetType() cellname =Request


            Session["id"] = Convert.ToInt32(Request.Params["content"]==null?Session["id"]:Request.Params["content"]);  //删除之后重载，没有id了
            content = Convert.ToInt32(Request.Params["content"] == null ? Session["id"] : Request.Params["content"]);  //ID
            listlouzhu = scbll.showLouZhu(content);
            ShowMessagesBLL smb = new ShowMessagesBLL();

            listMessages= smb.showMessages(content);    //一级评论
            listwho = smb.showAllMessages(content);    //所有的评论

        }
        public string getMostMessages(int content, int cid)
        {
            ShowMessagesBLL smb = new ShowMessagesBLL();

            
                   //二级以下评论的所有
            listMoreMessages = smb.showMoreMessages(content, cid);
            string str = "";
            foreach (var item in listMoreMessages)
            {
                str += "<div class=" + "\"" + "child-comment" + "\"" + " id" + "=" + "comment-2" + " style=" + "text-align:left;" + "\"" + "><div class=" + "\"" + "child-comment-footer text-center clearfix" + "\"" + "><p><a class=" + "\"" + "blue-link" + "\"" + " href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.CommentUser + "</a><a class=" + "\"" + "makeskine-author" + "\"" + ">@" + listwho.Where(r => r.ID == item.CID).ToArray()[0].CommentUser + "</a> " + item.MessBelong + "  " + "<a class=" + "\"" + "makeskine-author" + "\"" + ">" + item.CreateTime + "</a><button type=" + "\"" + "button" + "\"" + " class=" + "\"" + "close" + "\"" + " id=" + "\"" + "id" + item.ID + "\"" + " onclick=" + "\"" + "delcomments(this)" + "\"" + "><span aria-hidden=" + "\"" + "true" + "\"" + ">&times;</span><span class=" + "\"" + "sr-only" + "\"" + ">Close</span></button></span>" + "</p></div></div>" + getMostMessages(content, item.ID);
            }
            return str;
        }

    }
}