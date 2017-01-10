using LiZhiOSManagement.BLL;
using LiZhiOSManagement.DAL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace LiZhiOSManagement.WEB
{
    /// <summary>
    /// GenderAnalysisAjax 的摘要说明
    /// </summary>
    public class GenderAnalysisAjax : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ShowUsersMessagesDAL sum = new ShowUsersMessagesDAL();
            List<User> listu = new List<User>();
            listu = sum.selectAllUsers();
            List<object> list = new List<object>();
            foreach (var item in listu)
            {
                Person p = new Person();
                p.value = Convert.ToInt32(item.ID);
                p.name = item.UserName;
                list.Add(p);
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(list);
          context.Response.Write(json);
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
    public class Person
    {
        public int value { get; set; }
        public string name { get; set; }
    }
}