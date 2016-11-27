﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestForNet.BAL;
using TestForNet.DAL;

namespace TestForNet.WEB
{
    public partial class PersionalInformation : System.Web.UI.Page
    {
        protected string userIP;
        protected string getIP;
        protected string userName;
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckLogin();
            string ph= DateTime.Now.ToString("HH:mm");
          
            if (Session["userName"] != null)
            {
                T_User ip = new T_User();
                userIP = ip.IpByUserNameSearch(Session["userName"].ToString());
                getIP = Request.ServerVariables["REMOTE_ADDR"];//获取客户端IP
                T_User user = new T_User();
                DataRow uName = user.userStuIDByUserNameSearch(Session["userName"].ToString());
                userName = uName["UserFName"].ToString();
                Session["UserFName"] = userName;
            }
           


            //新增签到信息
            string  newTimes=Context.Request["newTime"];
            if (newTimes == "1")
            {
                //if ((newTimes.CompareTo("05:00") > 0 && newTimes.CompareTo("12:00") < 0) || (newTimes.CompareTo("13:00") > 0 && newTimes.CompareTo("17:00") < 0) || (newTimes.CompareTo("18:00") > 0 && newTimes.CompareTo("22:00") < 0))
               // {
                    if (Session["userName"] != null)
                    {
                        T_User ip = new T_User();
                        userIP = ip.IpByUserNameSearch(Session["userName"].ToString());
                    }
                    getIP = Request.ServerVariables["REMOTE_ADDR"];//获取客户端IP
                    if (getIP == userIP)
                    {
                        T_SignIN newTime = new T_SignIN();
                        newTime.setNewSignIN(Session["userName"].ToString(), ph);
                        newTimes = "0";
                        Response.Redirect("/WEB/SignIN.aspx");
                    }
                    else

                        newTimes = "0";
                    Response.Write("<script language=javascript>alert('请使用指定IP签到！');window.location='/Index.aspx'</script>");

               // }
            }
            //else
            //{
            //    newTimes = "0";
            //    Response.Write("<script language=javascript>alert('现在不是签到时间！\n可签到时间如下：\n早上5:00~12:00\n下午13：00~17:00\n晚上18:00~22:00');window.location='/Index.aspx'</script>");
            //}
            
        }
        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <returns></returns>
        public string GetLocalIp()  
                    {  
                        string hostname = Dns.GetHostName();//得到本机名   
                        //IPHostEntry localhost = Dns.GetHostByName(hostname);//方法已过期，只得到IPv4的地址   
                        IPHostEntry localhost = Dns.GetHostEntry(hostname);  
                        IPAddress localaddr = localhost.AddressList[5];  
                        return localaddr.ToString();  
                    }
      
    }
}