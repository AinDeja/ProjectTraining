using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspirationalWeb.BLL
{
    public class Navigation
    {
     //<ul id="collect">

     //     <li><a href="javascript:window.external.AddFavorite('http://10.212.12.156:9566/IndexTwo.aspx','DS`BBS')"  >收藏本站</a></li>
     //     <li><a href='#' onclick="this.style.behavior='url(#default #homepage)';this.setHomepage('http://10.212.12.156:9566/IndexTwo.aspx');" >设为首页</a></li>
     // </ul>

     // <ul id="login">
     //    <li><%if (Session["Name"] == null)
     //                 {
     //                     Context.Response.Write("<a href='/IndexTwo.aspx'><i id='i3'></i>论坛首页</a>");
     //                 }
     //                 else
     //                 {
     //                     Context.Response.Write("<a href='UserIndex.aspx'><i id='i1'></i>论坛首页</a>");
     //                 }%></li>
     //           <li><%if (Session["Name"] == null)
     //                 {
     //                     if (Session["AdminName"]==null)
     //                     {
     //                         Context.Response.Write("<i id='i3'></i>游客您好");
     //                     }
     //                     else
     //                     {
     //                         Context.Response.Write("<i id=‘i2’></i>欢迎您 " + Session["AdminName"] + "");
     //                     }
                          
     //                 }
     //                 else
     //                 {
     //                     Context.Response.Write("<i id=‘i2’></i>欢迎您 "+Session["Name"]+"");
     //                 }%></li>
     //           <li><%

     //                     if (Session["Name"] == null)
     //                     {
     //                         if (Session["AdminName"] == null)
     //                         {
     //                         Context.Response.Write("<a href='/HTML/Login.aspx'><i id='i3'></i>登录</a>");
     //                         }
     //                         else
     //                         {
     //                             Context.Response.Write("<a href='/Admin/AuserMess.aspx'><i id='i3'></i>用户管理</a>");
     //                         }
     //                     }
     //                     else
     //                     {
     //                         if (Session["AdminName"] == null)
     //                         {
     //                             Context.Response.Write("<a href='/HTML/UserMess.aspx'><i id='i3'></i>个人信息管理</a>");
     //                         }
     //                         else
     //                         {
     //                             Context.Response.Write("<a href='/Admin/AuserMess.aspx'><i id='i3'></i>用户管理</a>");
     //                         }
                              
     //                     }
                         
     //                 %></li>
     //           <li><%if (Session["Name"] == null)
     //                 {
     //                     if (Session["AdminName"] == null)
     //                     {
     //                         Context.Response.Write("<a href='/HTML/Register.aspx'><i id='i4'></i>注册</a>");
     //                     }
     //                     else
     //                     {
     //                         Context.Response.Write(" <a href='/Admin/ApostEdit.aspx'><i id='i4'></i>贴子管理</a>");
     //                     }
                          
     //                 }
     //                 else
     //                 {
     //                     Context.Response.Write("<a href='/HTML/UserPost.aspx'><i id='i4'></i>个人贴子管理</a>");
     //                 }%></li>
     //           <%if (Session["AdminName"] != null)
     //                 {
     //                     Context.Response.Write(" <li><a href='/Admin/EditPostType.aspx'><i id='i4'></i>板块管理</a></li>");
     //                 }%>
     //            <%if (Session["AdminName"]!=null&&Session["AdminName"].ToString() == "sysadmin")
     //                 {
     //                     Context.Response.Write(" <li><a href='/Admin/EditAdmin.aspx'><i id='i4'></i>权限管理</a></li>");
     //                 }%>
     //           <li><%if (Session["Name"] == null)
     //                 {
     //                     if (Session["AdminName"] == null)
     //                     {
     //                         Context.Response.Write("<a href='/Admin/AdminLogin.aspx'><i id='i5'></i>系统登录</a>");
     //                     }
     //                     else
     //                     {
     //                         Context.Response.Write("<a href='/Admin/AdminLogin.aspx?exitUser=1'><i id='i4'></i>退出登录</a>");
     //                     }
                          
     //                 }
     //                 else
     //                 {
     //                     Context.Response.Write("<a href='/HTML/Login.aspx?exitUser=1'><i id='i5'></i>退出登录</a>");
     //                 }%></li>

     // </ul>
        public void nav(string name)
        {
            string nav = @"";
            
        }
    }
}