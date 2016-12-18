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
    /// AddManagers 的摘要说明
    /// </summary>
    public class AddManagers : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //AddUsersByManagerBLL aubm = new AddUsersByManagerBLL();
            //int s;
            //bool isdelete = Convert.ToBoolean(context.Request.Params["isdelete"]);
            //string ceshi = context.Request.Params["createtime"].ToString();
            //DateTime createtime = Convert.ToDateTime(context.Request.Params["createtime"].ToString());
            //string name = context.Request.Params["name"].ToString();
            //string pwd = context.Request.Params["pwd"].ToString();
            //string sex = context.Request.Params["sex"].ToString();
            //long qq = Convert.ToInt64(context.Request.Params["qq"]);
            //long phone = Convert.ToInt64(context.Request.Params["phone"]);
            //long stuid = Convert.ToInt64(context.Request.Params["stuid"]);
            //string fname = context.Request.Params["fname"].ToString();
            //string ip = context.Request.Params["ip"].ToString();
            //string group = context.Request.Params["group"].ToString();

            string shuzu = context.Request["shuzu"];              //要删除的用户的数组
            shuzu = shuzu.Substring(4, shuzu.Length - 5);         //被删人id
            string[] delid = shuzu.Split(',');
            List<Managers> listm = new List<Managers>();
            ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
            ShowUsersMessagesBLL sum=new ShowUsersMessagesBLL();
            listm = smm.selectM();               //所有管理员，包括超管
            List<Users> listu = new List<Users>();
            

            int s = 0;
            for (int i = 0; i < delid.Length;i++ )
            {
                if (HttpContext.Current.Session["quan"].ToString() == "sm")
                {
                    if (!listm.Exists(r => r.ID == Convert.ToInt32(delid[i])))
                    {
                        //
                        listu = sum.addManagersFromUsers(delid[i]);
                        AddManagerBLL am = new AddManagerBLL();
                        //isdelete, createtime, name, pwd, sex, qq, phone, stuid, fname, ip, group
                        s += am.insertManagers(listu.Where(r => r.ID == Convert.ToInt32(delid[i])).ToArray()[0].IsDelete, listu.Where(r => r.ID == Convert.ToInt32(delid[i])).ToArray()[0].CreateTime, listu.Where(r => r.ID == Convert.ToInt32(delid[i])).ToArray()[0].UserName, listu.Where(r => r.ID == Convert.ToInt32(delid[i])).ToArray()[0].UserPassWord, listu.Where(r => r.ID == Convert.ToInt32(delid[i])).ToArray()[0].UserSex, listu.Where(r => r.ID == Convert.ToInt32(delid[i])).ToArray()[0].UserQQ, listu.Where(r => r.ID == Convert.ToInt32(delid[i])).ToArray()[0].UserPhone, listu.Where(r => r.ID == Convert.ToInt32(delid[i])).ToArray()[0].UserStuID, listu.Where(r => r.ID == Convert.ToInt32(delid[i])).ToArray()[0].UserFname, listu.Where(r => r.ID == Convert.ToInt32(delid[i])).ToArray()[0].UserIP, listu.Where(r => r.ID == Convert.ToInt32(delid[i])).ToArray()[0].Belong);
                    }
                }
            }
            if (s == delid.Length) 
            {
                s = 1;
            }
            else
            {
                s = 0;
            }







                //if (HttpContext.Current.Session["quan"].ToString() == "sm")
                //{
                //    //ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
                //    if (smm.selectQuan(name, pwd) > 0)                //已存在要添加的管理员
                //    {
                //        s = 0;
                //    }
                //    else
                //    {
                //        AddManagerBLL am = new AddManagerBLL();
                //        s = am.insertManagers(isdelete, createtime, name, pwd, sex, qq, phone, stuid, fname, ip, group);
                //    }

                //}
                //else
                //{
                //    s = 0;
                //}
            context.Response.Write(s);
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