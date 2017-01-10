<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InspirationalWeb.WebPL.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>登录</title>
    <link rel="stylesheet" type="text/css" href="/WebPL/CSS/Login.css" />
</head>
<body>

<div id="divLogin" 
    style="z-index:1001;
	 position: absolute; 
	 top:50%; 
	 left:50%;
	 margin:-200px 0 0 -200px;   
     border:1px solid #66D9EF;
    background: #fff;
	position:absolute; 
        
    width: 400px;
    height: 350px;
	">

<a href="javascript:void(0)" onclick="ShowNo()"><img src="/WebPL/Images/logo.gif"></a>
<form  method="post" action="/WebPL/User/Login.aspx">
		<table id="loginWindow">
                <tr>
        	<td>账 户：</td>
            <td><input type="text" class="text" name="Name" id="userName"//></td>
        </tr>
       <tr>
        	<td>密 码：</td>
            <td><input type="password" class="text" name="PassWord" id="userPasswd"/></td>
        </tr>
        
        <tr>
        	<td></td>
            <td> 
            <input class="button" type="reset" name="register" value="重置"></input>
            <input  class="login" type="submit" name="login" value="登录"></input>
            
            </td>
        </tr>
    </table>
    </form>

</div></body>
</html>