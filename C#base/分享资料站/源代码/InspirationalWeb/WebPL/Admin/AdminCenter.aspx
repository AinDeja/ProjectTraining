<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCenter.aspx.cs" Inherits="InspirationalWeb.WebPL.Admin.AdminCenter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

     <link rel="stylesheet" type="text/css"  href="/WebPL/CSS/AdminCenter.css" />

</head>

<body>
    <div id="top"></div>
    <div id="Main">
        <div id="leftList">
            <ul>
                <li> <h2><a href="AdminCenter.aspx?list=0&del=0">首 页</a></h2></li>
                <h2>文章管理</h2>
                <li><a href="AdminArticle.aspx?list=1&del=0">用户文章</a></li>
                <li><a href="AdminArticleType.aspx?list=1&del=0">文章分类</a></li>
                <h2>相册管理</h2>
                <li><a href="AdminImges.aspx?list=2&del=0">相册管理</a></li>
                <h2>留言管理</h2>
                <li><a href="AdminMessages.aspx?list=3&del=0">留言管理</a></li>
            </ul>
        </div>
        <div id="rightMain">
           
            <%=aTr %>
            <%=tTr %>
            <%=aTr1 %>
            <% %>
        </div>
    </div>
</body>
</html>
