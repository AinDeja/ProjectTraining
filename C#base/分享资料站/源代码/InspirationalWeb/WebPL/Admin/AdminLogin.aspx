<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="InspirationalWeb.WebPL.Admin.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title></title>
     <link rel="stylesheet" type="text/css" href="/WebPL/CSS/AdminLogin.css" />
</head>
<body>

<div id="divLogin">
<form  method="post" action="AdminLogin.aspx">
		<table >
        <tr>
        	<td>账 户：</td>
            <td><input type="text" class="text" name="AdminName"/></td>
        </tr>
       <tr>
        	<td>密 码：</td>
            <td><input type="password" class="text" name="AdminPwd"/></td>
        </tr>
        
        <tr>
        	<td></td>
            <td> 
            <input class="button" type="reset" name="register" value="重置"></input>
            <input  class="login" type="submit" name="login" value="登录"></input>
            
            </td>
        </tr>
    
</div>
   
    </table>
    </form>

</body>
</html>
