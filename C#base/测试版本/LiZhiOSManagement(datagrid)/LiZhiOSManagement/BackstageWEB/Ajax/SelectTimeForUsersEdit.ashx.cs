using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// SelectTimeForUsersEdit 的摘要说明
    /// </summary>
    public class SelectTimeForUsersEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ShowUsersMessagesBLL sum = new ShowUsersMessagesBLL();
            List<User> list = new List<User>();
            list = sum.selectAllUsers();
            int id = Convert.ToInt32(context.Request.Params["id"]);
            DateTime dt = list.Where(r => r.ID == id).ToArray()[0].CreateTime;

            context.Response.Write(dt);
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