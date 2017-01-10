<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserUpDate.aspx.cs" Inherits="InspirationalWeb.WebPL.User.UserUpDate" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>个人信息修改</title>
    <link rel="stylesheet" type="text/css" href="/WebPL/CSS/Register.css" />
</head>
<body>

<div id="register"
        style="z-index:1001;
	 position: absolute; 
	 top:30%; 
	 left:50%;
	 margin:-200px 0 0 -200px;   
     border:1px solid #66D9EF;
    background: #fff;
	position:absolute; 
        
    width: 400px;
    height: 650px;
	">
<img src="/WebPL/Images/logo.gif">

<form  method="post" action="UserUpDate.aspx">
		<table>
            <%=tTr.ToString() %>
            <tr>
        	<td></td>
            <td> 
            <input class='button' type='submit' name='register' value='修改'></input>
            <input  class='login' type='reset' name='login' value='重置'></input>
            
            </td>
        </tr>
   
    </table>
    </form>
</div>
</body>
</html>