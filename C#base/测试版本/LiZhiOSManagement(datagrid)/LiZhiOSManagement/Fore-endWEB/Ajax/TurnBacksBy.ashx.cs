using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;


namespace LiZhiOSManagement.Fore_endWEB.Ajax
{
    /// <summary>
    /// TurnBacksBy 的摘要说明
    /// </summary>
    public class TurnBacksBy : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
            //string pwd = context.Request.Params["pwd"];

            context.Response.Write(BitConverter.ToString(new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(System.Text.Encoding.Default.GetBytes(HttpContext.Current.Session["userName"].ToString() + HttpContext.Current.Session["pwd"].ToString()))).Replace("-", ""));
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