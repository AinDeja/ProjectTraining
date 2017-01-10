<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="InspirationalWeb.WebPL.User.UserCenter" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>登录</title>
    <link rel="stylesheet" type="text/css" href="/WebPL/CSS/Register.css" />
</head>
<body>

<div id="login">
<div id="center">
<img src="/WebPL/Images/logo.gif">

<form  method="post" action="UserRegister.aspx">
		<table>
        <tr>
        	<td>账 户：</td>
            <td><input type="text" class="text" name="username"/> <span>必填</span></td>
        </tr>
       <tr>
        	<td>密 码：</td>
            <td><input type="password" class="text" name="userpassword"/> <span>必填</span></td>
        </tr>
             <tr>
        	<td>昵 称：</td>
            <td><input type="text" class="text" name="UserFname" /></td>
        </tr>
       <tr>
        	<td>性 别：</td>
            <td><input type="text" class="text" name="UserSex"/></td>
        </tr>
             <tr>
        	<td>年 龄：</td>
            <td><input type="text" class="text" name="UserAge" /></td>
        </tr>
       <tr>
        	<td>生 日：</td>
            <td><input type="text" class="text" name="UserBirth"/></td>
        </tr>
             <tr>
        </tr>
       <tr>
        	<td>电 话：</td>
            <td><input type="text" class="text" name="UserPhone"/></td>
        </tr>
             <tr>
        	<td>邮 箱：</td>
            <td><input type="text" class="text" name="UserEmail" /></td>
        </tr>
       <tr>
        	<td>QQ：</td>
            <td><input type="text" class="text" name="UserQQ"/></td>
        </tr>
        
        <tr>
        	<td></td>
            <td> 
            <input class="button" type="submit" name="register" value="注册"></input>
            <input  class="login" type="reset" name="login" value="重置"></input>
            
            </td>
        </tr>
    

   
    </table>
    </form>
</div>
</div>

</body>
</html>
