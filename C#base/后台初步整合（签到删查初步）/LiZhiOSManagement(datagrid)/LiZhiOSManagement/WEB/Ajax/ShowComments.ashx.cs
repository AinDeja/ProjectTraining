using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// ShowComments 的摘要说明
    /// </summary>
    public class ShowComments : IHttpHandler
    {
        
        public List<Messages> listComment;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ShowCommentsBLL scbll = new ShowCommentsBLL();
            int id = Convert.ToInt32(context.Request.Params["id"]);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            listComment = scbll.showComments(1041);
            string jso = null;
            jso = jss.Serialize(listComment.ToArray()[1].MessBelong);
            //context.Response.Write(jso);
            //string json = "{\"total\":" + total + ",\"rows\":" + jso + "}";
            context.Response.Write(jso);
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