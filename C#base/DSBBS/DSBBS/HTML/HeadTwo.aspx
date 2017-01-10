<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HeadTwo.aspx.cs" Inherits="DSBBS.HTML.HeadTwo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>DS_BBS</title>
    <link type="text/css" rel="stylesheet" href="../CSS/Index.css" />

    <link rel="stylesheet" href="css/style.css" type="text/css">

    <script type="text/javascript">
        function turnto(toa) {
            window.location.href = toa;
        }
    </script>
</head>
<body>
    <div id="left">
        <div id="leftTitle">
            <h1 id="h01">DS</h1>
        </div>
        <div id="meums">
            <ul id="meumsUL">
                <li><%if (Session["Name"] == null)
                      {
                          Context.Response.Write("<a href='../Index.aspx'><i id='i3'></i>论坛首页</a>");
                      }
                      else
                      {
                          Context.Response.Write("<a href='UserIndex.aspx'><i id='i1'></i>论坛首页</a>");
                      }%></li>
                <li><%if (Session["Name"] == null)
                      {
                          if (Session["AdminName"]==null)
                          {
                              Context.Response.Write("<i id='i3'></i>游客您好");
                          }
                          else
                          {
                              Context.Response.Write("<i id=‘i2’></i>欢迎您 " + Session["AdminName"] + "");
                          }
                          
                      }
                      else
                      {
                          Context.Response.Write("<i id=‘i2’></i>欢迎您 "+Session["Name"]+"");
                      }%></li>
                <li><%if (Session["Name"] == null)
                      {
                          if (Session["AdminName"]==null)
                          {
                              Context.Response.Write("<a href='/HTML/Login.aspx'><i id='i3'></i>登录</a>");
                          }
                          else
                          {
                              Context.Response.Write("<a href='/Admin/AuserMess.aspx'><i id='i3'></i>信息管理</a>");
                          }
                          
                      }
                      else
                      {
                          Context.Response.Write("<a href='UserMess.aspx'><i id='i3'></i>个人信息管理</a>");
                      }%></li>
                <li><%if (Session["Name"] == null)
                      {
                          if (Session["AdminName"] == null)
                          {
                              Context.Response.Write("<a href='Register.aspx'><i id='i4'></i>注册</a>");
                          }
                          else
                          {
                              Context.Response.Write(" <a href='/Admin/ApostEdit.aspx'><i id='i4'></i>贴子管理</a>");
                          }
                          
                      }
                      else
                      {
                          Context.Response.Write("<a href='UserPost.aspx'><i id='i4'></i>个人贴子管理</a>");
                      }%></li>
                <%if (Session["AdminName"] != null)
                      {
                          Context.Response.Write(" <li><a href='/Admin/EditPostType.aspx'><i id='i4'></i>板块管理</a></li>");
                      }%>
                 <%if (Session["AdminName"]!=null&&Session["AdminName"].ToString() == "sysadmin")
                      {
                          Context.Response.Write(" <li><a href='/Admin/EditAdmin.aspx'><i id='i4'></i>权限管理</a></li>");
                      }%>
                <li><%if (Session["Name"] == null)
                      {
                          if (Session["AdminName"] == null)
                          {
                              Context.Response.Write("<a href='/Admin/AdminLogin.aspx'><i id='i5'></i>系统登录</a>");
                          }
                          else
                          {
                              Context.Response.Write("<a href='/Admin/AdminLogin.aspx?exitUser=1'><i id='i4'></i>退出登录</a>");
                          }
                          
                      }
                      else
                      {
                          Context.Response.Write("<a href='/HTML/Login.aspx?exitUser=1'><i id='i5'></i>退出登录</a>");
                      }%></li>
            </ul>

        </div>
    </div>


    <div id="right">
        <div id="rightTitle">
            <h1 id="h02">BBS</h1>
        </div>

