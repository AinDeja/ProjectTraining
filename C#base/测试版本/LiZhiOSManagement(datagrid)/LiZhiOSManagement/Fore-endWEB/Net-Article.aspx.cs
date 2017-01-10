using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiZhiOSManagement.Fore_endWEB
{
    public partial class Net_Article : System.Web.UI.Page
    {
        public List<Messages> listMessages;
        public List<Messages> listChildrenMessages;
        public List<Article> listshow;
        public string deleteids;
        public int deletecommentids;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectMessageBLL smbll = new SelectMessageBLL();
                string ob = Request.Params["times"];
                Session["articleBysearchID"] = (Convert.ToInt32(Request.Params["ID"]) != 0) ? Convert.ToInt32(Request.Params["ID"]) : Session["articleBysearchID"];             //正序、倒序、喜欢排列
                if (ob == null || ob == "shun")
                {
                    listMessages = smbll.selectMessages(Convert.ToInt32(Session["articleBysearchID"]));
                    //listChildrenMessages = listMessages.Where(r => r.CID == 0).ToList();
                }
                else if (ob == "ni")
                {
                    listMessages = smbll.selectMessagesByTimeDesc(Convert.ToInt32(Session["articleBysearchID"]));
                }
                else
                {
                    listMessages = smbll.selectMessagesByFavoriteDesc(Convert.ToInt32(Session["articleBysearchID"]));

                }
                listChildrenMessages = listMessages.Where(r => r.CID == 0).ToList();

                string s = null;
                //评论内容
                string makeComment = Request.Params["makeComment"];
                //富文本编辑器内容
                s = Request.Params["myEditor"];
                //被评论人的ID
                int cid = Convert.ToInt32(Request.Params["commentId"]);

                if (((s != null) && (!s.Equals("")) || ((Request.Params["makeComment"] != null) && (!makeComment.Equals("")))) && (Session["ID"] != null))
                {
                    // Response.Redirect("login.aspx?s=" + s);

                    AddMessageBLL ambll = new AddMessageBLL();
                    int i;
                    if ((makeComment != null) && (!makeComment.Equals("")))
                    {
                        i = ambll.addMessage(false, DateTime.Now, ".Net", Convert.ToInt32(Session["articleID"]), makeComment, cid, Session["txtUser"].ToString());
                        if (i == 1)
                        {
                            Response.Redirect("Net-Article.aspx?ID=" + Convert.ToInt32(Session["articleID"]));
                        }

                    }
                    else
                    {
                        i = ambll.addMessage(false, DateTime.Now, "Android", Convert.ToInt32(Session["articleID"]), s, 0, Session["txtUser"].ToString());
                        if (i == 1)
                        {
                            Response.Redirect("Net-Article.aspx?ID=" + Convert.ToInt32(Session["articleID"]));
                        }

                    }
                }


                if (Request.Params["deletecommentid"] != null && (!Request.Params["deletecommentid"].Equals("")))
                {
                    DeleteCommentBLL dcb = new DeleteCommentBLL();
                    int j = dcb.DeleteComment(Convert.ToInt32(Request.Params["deletecommentid"]));
                    if (j == 1)
                    {
                        int deletecommentids = Convert.ToInt32(Session["articleID"]);
                        deleteids = "Net-Article.aspx?ID=" + deletecommentids;
                    }

                }
            }


            SelectArticleBLL sa = new SelectArticleBLL();
            Session["kind_type"] = Request.Params["kind_type"] == null ? Session["kind_type"] : Request.Params["kind_type"];

            string id = Request.Params["ID"];
            Session["articleID"] = (Convert.ToInt32(Request.Params["ID"]) != 0) ? Convert.ToInt32(Request.Params["ID"]) : Session["articleID"];
            int ceshi = Convert.ToInt32(Session["articleID"]);
            string ceshi2 = Convert.ToString(Session["kind_type"]);
            listshow = sa.SelectArticleById(Convert.ToInt32(Session["articleID"]));

        }

        int i = 0;
        public string GetMessageData(int id)
        {
            //int i = 0;
            string str = "";
            List<Messages> list = listMessages.Where(r => r.CID == id).ToList();
            if (list.Count > 0)
            {
                SelectMessageBLL sm = new SelectMessageBLL();
                foreach (var item in list)
                {

                    if (sm.selectMessagesBelongSUser(item.CID) == Convert.ToString(Session["txtUser"]))
                    {

                        str += "<div class=" + "\"" + "clild-comment-list" + "\"" + "><div class=" + "\"" + "child-comment" + "\"" + " id=" + "\"" + "comment-" + item.ID + "\"" + "><p><a class=" + "\"" + "blue-link" + "\"" + " href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.CommentUser + "</a><a class=" + "\"" + "makeskine-author" + "\"" + ">：@" + listMessages.Where(r => r.ID == item.CID).ToArray()[0].CommentUser + "</a>" + item.MessBelong + "</p><div class=" + "\"" + "child-comment-footer text-right clearfix" + "\"" + "><span class=" + "\"" + "reply-time pull-left" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.CreateTime + "</a></span><a data-id=" + "\"" + "0" + "\"" + " data-nickname=" + "\"" + "汪宇" + "\"" + " class=" + "\"" + "pull-right child-reply" + "\"" + " href=" + "\"" + "javascript:void(null)" + "\"" + ">回复</a><a href=" + "\"" + "javascript:void(0)" + "\"" + "><span class=" + "\"" + "comment-delete pull-right glyphicon glyphicon-remove" + "\"" + " id=" + "\"" + item.ID + "\"" + "></span></a><div class=" + "\"" + "childReply " + "\"" + "><form action=" + "\"" + "Net-Article.aspx?commentId=" + item.ID + "#article-comment" + "\"" + " method=" + "\"" + "post" + "\"" + "><input type=" + "\"" + "text" + "\"" + " class=" + "\"" + "form-control" + "\"" + " placeholder=" + "\"" + "写下你的回复..." + "\"" + " name=" + "\"" + "makeComment" + "\"" + "/><button class=" + "\"" + "btn btn-default btn-xs" + "\"" + " type=" + "\"" + "submit" + "\"" + ">提交</button></form></div></div></div></div>" + GetMessageData(item.ID);
                        i++;
                    }
                    else
                    {
                        str += "<div class=" + "\"" + "clild-comment-list" + "\"" + "><div class=" + "\"" + "child-comment" + "\"" + " id=" + "\"" + item.ID + "\"" + "><p><a class=" + "\"" + "blue-link" + "\"" + " href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.CommentUser + "</a><a class=" + "\"" + "makeskine-author" + "\"" + ">：@" + listMessages.Where(r => r.ID == item.CID).ToArray()[0].CommentUser + "</a>" + item.MessBelong + "</p><div class=" + "\"" + "child-comment-footer text-right clearfix" + "\"" + "><span class=" + "\"" + "reply-time pull-left" + "\"" + "><a href=" + "\"" + "javascript:void(0)" + "\"" + ">" + item.CreateTime + "</a></span><a data-id=" + "\"" + "0" + "\"" + " data-nickname=" + "\"" + "汪宇" + "\"" + " class=" + "\"" + "pull-right child-reply" + "\"" + " href=" + "\"" + "javascript:void(null)" + "\"" + ">回复</a><div class=" + "\"" + "childReply " + "\"" + "><form action=" + "\"" + "Net-Article.aspx?commentId=" + item.ID + "#article-comment" + "\"" + " method=" + "\"" + "post" + "\"" + "><input type=" + "\"" + "text" + "\"" + " class=" + "\"" + "form-control" + "\"" + " placeholder=" + "\"" + "写下你的回复..." + "\"" + " name=" + "\"" + "makeComment" + "\"" + "/><button class=" + "\"" + "btn btn-default btn-xs" + "\"" + " type=" + "\"" + "submit" + "\"" + ">提交</button></form></div></div></div></div>" + GetMessageData(item.ID);
                        i++;
                    }

                }

            }
            return str;
        }
        public string selectMessagesBelongUser(int messagesId)
        {
            SelectMessageBLL sm = new SelectMessageBLL();
            return sm.selectMessagesBelongSUser(messagesId);
        }
    }
}