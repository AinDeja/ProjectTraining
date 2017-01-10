using LiZhiOSManagement.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.WEB.Ajax
{
    /// <summary>
    /// DeleteSign 的摘要说明
    /// </summary>
    public class DeleteSign : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            string shuzu = context.Request["shuzu"];
            shuzu = shuzu.Substring(4, shuzu.Length - 5);
            shuzu = "'" + shuzu + "'";
            shuzu=shuzu.Replace(",","','");

            //
            //权限
            //
            //彻底删除
            //string sql = "DELETE FROM T_SignIN WHERE ID IN ("+shuzu+")";
            //软删除
            //string sql = "update  T_SignIN SET IsDelete=1 WHERE ID IN ("+shuzu+")";
            DeleteSignBLL del = new DeleteSignBLL();
            del.deleteSign(shuzu);
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