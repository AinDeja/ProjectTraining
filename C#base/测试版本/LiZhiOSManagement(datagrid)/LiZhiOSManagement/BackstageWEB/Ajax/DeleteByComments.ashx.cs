using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// DeleteByComments 的摘要说明
    /// </summary>
    public class DeleteByComments : IHttpHandler,IRequiresSessionState
    {
        public List<Messages> list;    //总的评论内容
        public List<Messages> dellist;  //要删的评论内容
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ShowMessagesBLL smb = new ShowMessagesBLL();
            List<Managers> listm = new List<Managers>();
            List<SuperManagers> listsm = new List<SuperManagers>();
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            listm = smm.selectM();            //管理
            listsm = smm.selectSM();          //超级


            list = smb.selectAllMessages();
            int id = Convert.ToInt32(context.Request.Params["id"].ToString().Remove(0, 2));
            string name=list.Where(r=>r.ID==id).ToArray()[0].CommentUser;                 //被删除人的名字
            if(HttpContext.Current.Session["quan"].ToString()=="sm")                      //登陆人为超管
            {
                if(listsm.Exists(r=>r.UserName==name))                                         //被删除身份是超管
                {
                    if(name==HttpContext.Current.Session["name"].ToString())                       //要删除的是自己
                    {
                        if (deleteComments(id))
                        {
                            context.Response.Write(1);
                        }
                        else
                            context.Response.Write(0);
                    }
                    else
                    {
                           context.Response.Write(0);                                              //要删除的评论所有者是另外 sm 删除失败
                    }
                }
                else
                {
                    if (deleteComments(id))
                    {
                        context.Response.Write(1);
                    }
                    else
                        context.Response.Write(0);
                }
            }
            else                                                                        //一般管理员
            {
                if(!listsm.Exists(r=>r.UserName==name))                                     //被删评论所有者不是超管
                {
                    if(!listsm.Exists(r=>r.UserName==name))                                    //要删除的评论的所有者不是管理员
                    {
                        if(listm.Where(r=>r.UserName==HttpContext.Current.Session["name"].ToString()).ToArray()[0].belong==list.Where(r=>r.CommentUser==name).ToArray()[0].MessTem)    //被删的评论所属组与登陆的管理员在一个组
                        {
                            if (deleteComments(id))
                            {
                                context.Response.Write(1);
                            }
                            else
                            {
                                context.Response.Write(0);
                            }
                        }
                        else
                        {
                            context.Response.Write(0);
                        }
                    }
                    else
                    {
                        context.Response.Write(0);
                    }
                }
                else
                {
                    context.Response.Write(0);
                }
            }
            context.Response.End();
        }

        public bool deleteComments(int id)
        {
            
            dellist = list.Where(r => r.CID == id).ToList();
            foreach (var item in dellist)
            {
                deleteComments(item.ID);
            }
            DeleteArticleAndCommentBLL daa = new DeleteArticleAndCommentBLL();
            daa.DeleteByComments(id);
            return true;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}