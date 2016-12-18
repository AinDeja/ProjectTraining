using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;      //session 导入此命名空间
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// SaveEditUsers 的摘要说明
    /// </summary>
    public class SaveEditUsers : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
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
            List<Managers> listm = new List<Managers>();   //管理员
            List<SuperManagers> listsm = new List<SuperManagers>();    //超级管理员
            ShowManagersMessagesBLL smm=new ShowManagersMessagesBLL();
            listm = smm.selectM();            //所有管理员
            listsm = smm.selectSM();         //超级管理员  
            string quan = HttpContext.Current.Session["quan"].ToString() == null ? null : HttpContext.Current.Session["quan"].ToString();              //登陆人的权限
            string lname = HttpContext.Current.Session["name"].ToString() == null ? null : HttpContext.Current.Session["name"].ToString();                //登陆人的名字
            int s;         //编辑保存结果
            AddUsersByManagerBLL aub = new AddUsersByManagerBLL();
            if(quan=="sm")
            {
                s = aub.updateUsers(id, isdelete, dt, username, userpassword, usersex, userqq, userphone, userstuid, userfname, userip, belong);
            }
            else
            {
                if (listm.Exists(r => r.UserName == username) || listsm.Exists(r => r.UserName == username) || listm.Where(r => r.UserName == lname).ToList()[0].belong != belong)                     //被编辑的人为超级管理员或管理员或不在同一组
                {
                    if (listm.Where(r => r.UserName == lname).ToList()[0].UserName != lname)     //被编辑的人是自己
                    {
                        s = aub.updateUsers(id, isdelete, dt, username, userpassword, usersex, userqq, userphone, userstuid, userfname, userip, belong);
                    }
                    else
                    {
                        s = 0;
                    }
                }
                else
                {
                    s = aub.updateUsers(id, isdelete, dt, username, userpassword, usersex, userqq, userphone, userstuid, userfname, userip, belong);
                }
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