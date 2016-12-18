using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;         //session 导入此命名空间
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// AddUsersByManager 的摘要说明  ----------管理员添加用户------------
    /// </summary>
    public class AddUsersByManager : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            AddUsersByManagerBLL aubm = new AddUsersByManagerBLL();
            int s;
            bool isdelete = Convert.ToBoolean(context.Request.Params["isdelete"]);
            string ceshi = context.Request.Params["createtime"].ToString();
            DateTime createtime = Convert.ToDateTime(context.Request.Params["createtime"].ToString());
            string name = context.Request.Params["name"].ToString();
            string pwd = context.Request.Params["pwd"].ToString();
            string sex = context.Request.Params["sex"].ToString();
            long qq = Convert.ToInt64(context.Request.Params["qq"]);
            long phone = Convert.ToInt64(context.Request.Params["phone"]);
            long stuid = Convert.ToInt64(context.Request.Params["stuid"]);
            string fname = context.Request.Params["fname"].ToString();
            string ip = context.Request.Params["ip"].ToString();
            string group = context.Request.Params["group"].ToString();

            string quan = HttpContext.Current.Session["quan"].ToString() == null ? null : HttpContext.Current.Session["quan"].ToString();              //登陆人的权限
            string lname = HttpContext.Current.Session["name"].ToString() == null ? null : HttpContext.Current.Session["name"].ToString();                //登陆人的名字
            List<Managers> listm = new List<Managers>();
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            listm = smm.selectM();      //所有的管理员
            if(quan=="sm")
            {
                s = aubm.insertUsers(isdelete, createtime, name, pwd, sex, qq, phone, stuid, fname, ip, group);
            }
            else
            {
                if(listm.Exists(r => r.belong == group))
                {
                    s = aubm.insertUsers(isdelete, createtime, name, pwd, sex, qq, phone, stuid, fname, ip, group);
                }
                else
                {
                    s = 0;
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