<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestForNet.WEB.Login" %>

<!doctype html>
<html lang="zh">
<head>
<meta charset="UTF-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>系统登录</title>

<link rel="stylesheet" type="text/css" href="CSS/Login.css">

</head>
<body>


<div class="wrapper">

	<div class="container">
		<h1>欢迎登录</h1>
		<form class="form" action="/WEB/Login.aspx" method="post">
			<input type="text" placeholder="Username" name="userName">
			<input type="password" placeholder="Password" name="passWord">
            <a href="/WEB/Register.aspx"><button type="button" id="register-button" style="margin-bottom:8px;">注册</button></a><br />
			<button type="submit" id="login-button" style="font-weight:bold;">登录</button>
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