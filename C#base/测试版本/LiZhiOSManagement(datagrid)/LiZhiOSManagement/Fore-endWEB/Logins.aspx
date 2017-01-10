<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logins.aspx.cs" Inherits="LiZhiOSManagement.Fore_endWEB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>系统登录</title>

    <link href="CSS/Login.css" rel="stylesheet" />
</head>
<body>
    <div class="wrapper">

	<div class="container">
		<h1>Welcome LiZhiOS</h1>
		<form class="form" action="/Fore-endWEB/Logins.aspx" method="post">
			<input type="text" placeholder="Username" name="userName">
			<input type="password" placeholder="Password" name="passWord">
            <!--<a href="/WEB/Register.aspx"><button type="button" id="register-button" style="margin-bottom:8px;">注册</button></a><br />-->
			<button type="submit" id="login-button" style="font-weight:bold;">Login</button>
		</form>
	</div>
	
	<ul class="bg-bubbles">
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
	</ul>
	
</div>

<script type="text/javascript" src="js/jquery-2.1.1.min.js"></script>
<%--<script type="text/javascript">
    $('#login-button').click(function (event) {
        event.preventDefault();
        $('form').fadeOut(500);
        $('.wrapper').addClass('form-success');
        
    });
</script>--%>
</body>
</html>
