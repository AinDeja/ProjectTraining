<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DSBBS.Index" %>

<%--<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>DS_BBS</title>
    <link type="text/css" rel="stylesheet" href="CSS/Index.css" />

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
                <li><a href="Index.aspx"><i id="i1"></i>论坛首页</a></li>
                <li><a href="#"><i id="i2"></i>欢迎您 <%=Session["Name"] %></a></li>
                <li><a href="HTML/Login.aspx"><i id="i3"></i>登录</a></li>
                <li><a href="HTML/Register.aspx"><i id="i4"></i>注册</a></li>
            </ul>

        </div>
    </div>


    <div id="right">
        <div id="rightTitle">
            <h1 id="h02">BBS</h1>
        </div>--%>

<table id="typeTable">
<%=tTr %>
</table>

</div><!--右侧区域结束-->
</body>
</html>