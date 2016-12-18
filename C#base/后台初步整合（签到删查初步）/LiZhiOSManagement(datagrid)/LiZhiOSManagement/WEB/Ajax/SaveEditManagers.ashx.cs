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
    /// SaveEditManagers 的摘要说明
    /// </summary>
    public class SaveEditManagers : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int s = 0;
            int id = Convert.ToInt32(context.Request.Params["id"]);
            bool isdelete = Convert.ToBoolean(context.Request.Params["isdelete"]);
            DateTime dt = Convert.ToDateTime(context.Request.Params["createtime"]);
            string username = Convert.ToString(context.Request.Params["username"]);
            string userpassword = context.Request.Params["userpassword"].ToString();
            string usersex = context.Request.Params["usersex"].ToString();
            long userqq = Convert.ToInt64(context.Request.Params["userqq"]);
            long userphone = Convert.ToInt64(context.Request.Params["userphone"]);
            long userstuid = Convert.ToInt64(context.Request.Params["userstuid"]);
            string userfname = context.Request.Params["userfname"].ToString();
            string userip = context.Request.Params["userip"].ToString();
            string belong = context.Request.Params["belong"].ToString();
            List<SuperManagers> listsm = new List<SuperManagers>();    
            ShowManagersMessagesBLL smm=new ShowManagersMessagesBLL();
            AddManagerBLL am = new AddManagerBLL();
            listsm = smm.selectSM();         //超级管理员 
            if (HttpContext.Current.Session["quan"].ToString()=="sm")        //登陆人权限：超级管理员
            {
                if(listsm.Exists(r=>r.UserName==username))                   //被修改人权限：超级管理员
                {
                    if(HttpContext.Current.Session["name"].ToString()==username)       //被修改人是登陆人自己
                    {
                        s = am.updateManagers(id,isdelete,dt,username,userpassword,usersex,userqq,userphone,userstuid,userfname,userip,belong);
                    }
                    else                                                           //同为超级管理员
                    {
                        s = 0;
                    }
                }
                else                                                     //被修改人：管理员
                {
                    s = am.updateManagers(id, isdelete, dt, username, userpassword, usersex, userqq, userphone, userstuid, userfname, userip, belong);
                }
            }
            else                                                    //登陆人：管理员
            {
                s = 0;
            }


            context.Response.Write(s);
            context.Response.End();
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