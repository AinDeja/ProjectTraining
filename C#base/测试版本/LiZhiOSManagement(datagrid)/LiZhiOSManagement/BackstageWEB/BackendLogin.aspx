<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackendLogin.aspx.cs" Inherits="LiZhiOSManagement.WEB.BackendLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>jQuery站点后台登录表单代码 -爱编程实例，分享jQuery、html5、css3等插件</title>
<meta name="author" content="DeathGhost"/>
<link rel="stylesheet" type="text/css" href="CSS/style.css" tppabs="CSS/style.css"/>
<style>
body{height:100%;background:#16a085;overflow:hidden;}
canvas{z-index:-1;position:absolute;}
</style>
<script src="JS/jquery.js"></script>
<script src="JS/verificationNumbers.js" tppabs="JS/verificationNumbers.js"></script>
<script src="JS/Particleground.js" tppabs="JS/Particleground.js"></script>
<script>
    $(document).ready(function () {
        //粒子背景特效
        $('body').particleground({
            dotColor: '#5cbdaa',
            lineColor: '#5cbdaa'
        });
        //验证码
        createCode();
        //测试提交，对接程序删除即可
        $(".submit_btn").click(function () {
            var b = validate();
            //document.getElementById("J_codetext").setAttribute("placeholder","输入验证码");
            //alert();
            if ($('.login_txtbx').val() == null && $('#pwd').val() == null)
            {
                alert("账号和密码不能为空！");
            }
            else
            {
                if (b == false) {
                    if (document.getElementById("J_codetext").getAttribute("placeholder") == "输入验证码") {
                        alert("请输入验证码");
                    }
                    if (document.getElementById("J_codetext").getAttribute("placeholder") == "验证码错误") {
                        alert("请输入正确的验证码");
                    }
                }
                else {
                    location.href = "backendlogin.aspx?name=" + $('.login_txtbx').val() + "&pwd=" + $('#pwd').val()/*tpa=http://***index.html*/;
                }
            }
            
        });
    });
</script>
</head>
<body>
<dl class="admin_login">
 <dt>
  <strong>励志工作室论坛后台管理系统</strong>
  <em>Management System</em>
 </dt>
 <dd class="user_icon">
  <input type="text" placeholder="账号" class="login_txtbx"/>
 </dd>
 <dd class="pwd_icon">
  <input type="password" placeholder="密码" class="login_txtbx" id="pwd"/>
 </dd>
 <dd class="val_icon">
  <div class="checkcode">
    <input type="text" id="J_codetext" placeholder="验证码" maxlength="4" class="login_txtbx"/>
    <canvas class="J_codeimg" id="myCanvas" onclick="createCode()">对不起，您的浏览器不支持canvas，请下载最新版浏览器!</canvas>
  </div>
  <input type="button" value="验证码核验" class="ver_btn" onclick="validate();"/>
 </dd>
 <dd>
  <input type="button" value="立即登陆" class="submit_btn"/>
 </dd>
 <dd>
<p>适用浏览器：360、FireFox、Chrome、Safari、Opera、傲游、搜狗、世界之窗. 不支持IE8及以下浏览器。</p>

 </dd>
</dl>
    </body>
<%--<script src="http://www.w2bc.com/scripts/2bc/_gg_980_90.js" type="text/javascript"></script></body>  广告--%>
</html>
