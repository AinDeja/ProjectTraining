
using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// SelectTimeForManagersEdit 的摘要说明
    /// </summary>
    public class SelectTimeForManagersEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ShowManagersMessagesBLL sum = new ShowManagersMessagesBLL();
            List<Managers> listm = new List<Managers>();
            listm = sum.selectM();
            int id = Convert.ToInt32(context.Request.Params["id"]);
            DateTime dt = listm.Where(r=>r.ID==id).ToArray()[0].CreateTime;
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