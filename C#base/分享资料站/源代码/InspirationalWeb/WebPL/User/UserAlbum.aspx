<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAlbum.aspx.cs" Inherits="InspirationalWeb.WebPL.User.UserAlbum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>励志工作室</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="/WebPL/CSS/Album.css" />
    <link rel="stylesheet" type="text/css" href="/WebPL/CSS/Login.css" />
    <link rel="stylesheet" type="text/css" href="/WebPL/CSS/ImgCarousel.css" />
    <script type="text/javascript" src="JS/LoginTop.js"></script>
    <script type="text/javascript" src="JS/RegisterTop.js"></script>
    <script type="text/javascript" src="JS/ImgCarousel.js"></script>
</head>
     <script type="text/javascript">
         function turnto(toa) {
             window.location.href = toa;
         }//页面跳转

    </script>
<body>
<div id="top">
	<%--<ul>
    	<li><a href="###">收藏本站</a></li>
        <li><a href="###">设为首页</a></li>
    </ul>
    <ul class="logic">
    	<li><a href="Index.aspx">进入首页</a></li>
        <li><a href="#" onclick="showFloat()">登录</a></li>
        <li><a href="User/UserRegister.aspx">注册</a></li>
        <li><a href="#">系统登录</a></li>
    </ul>--%>
              <ul id="collect">

          <li><a href="javascript:window.external.AddFavorite('http://10.212.12.156:9566/IndexTwo.aspx','DS`BBS')"  >收藏本站</a></li>
          <li><a href='#' onclick="this.style.behavior='url(#default #homepage)';this.setHomepage('http://10.212.12.156:9566/IndexTwo.aspx');" >设为首页</a></li>
      </ul>

      <ul id="login">
         <li><%if (Session["Name"] == null)
                     {
                          Context.Response.Write("<a href='/WebPL/Index.aspx'><i id='i3'></i>首页</a>");
                      }
                      else
                      {
                          Context.Response.Write("<a href='/WebPL/Index.aspx'><i id='i1'></i>首页</a>");
                      }%></li>
                <li><%if (Session["Name"] == null)
                      {
                        
                          Context.Response.Write("<i id=‘i2’></i>欢迎您 "+Session["Name"]+"");
                      }%></li>
                <li><%

                          if (Session["Name"] == null)
                          {

                              Context.Response.Write("<a href='javascript:void(0)' onclick='showFloat()'><i id='i3'></i>登录</a>");
                       
                          }
                          else
                          {
                          
                                  Context.Response.Write("<a href='/WebPL/User/UserCenter.aspx'><i id='i3'></i>用户中心</a>");
                        
                          }
                         
                      %></li>
                <li><%if (Session["Name"] == null)
                      {

                          Context.Response.Write("<a href='javascript:void(0)' onclick='showFloatRegister()'><i id='i4'></i>注册</a>");
                        
                      }
                      //else
                      //{
                      //    Context.Response.Write("<a href='#'><i id='i4'></i>个人贴子管理</a>");
                      //}%></li>
                
                <li><%if (Session["Name"] != null)
                      {

                          Context.Response.Write("<a href='/WebPL/User/Login.aspx?exitUser=1'><i id='i5'></i>退出登录</a>");
                      }%></li>

      </ul>
</div>
<div id="head">
	<img class="logo" src="/WebPL/Images/logo.gif" />
	<p>&nbsp;IT创新<br />实践平台</p>
</div>

<div id="con">
    <div id="newPhoto" onclick="turnto('/WebPL/imgup.aspx')">上传图片</div>
<div id="left">
	<div class="menu">
<ul>
<li class="sort"><span>分类</span></li>
<li class="list"><span>文章列表</span></li>
    <%=tTr %>
<li class="list"><span>相册列表</span></li>
     <%=pTr %>


</ul>
<!-- clear the floats if required -->
<div class="clear"> </div>
</div>
<div id="lianjie">
<h1>链接</h1>
<ul>
        <li><a href="http://www.cnblogs.com/">博客园</a></li>
    <li><a href="http://www.w3school.com.cn/">W3school</a></li>
    <li><a href="http://www.zhihu.com/">知乎</a></li>
    <li><a href="#">待定</a></li>
    <li><a href="#">待定</a></li>
    <li><a href="#">待定</a></li>
</ul>
</div>
</div>
<div id="right">
    
    <form method="post" action="/WebPL/User/UserAlbum.aspx">
    <%=imgTr %>
    <table class="tbpage" style="margin-top:20px;">
    <tr id="tbPage">
          
           <td style="width:160px"> <a  href="/WebPL/User/UserAlbum.aspx?pageNumber=<%=pageNumber-1 %>">上一页</a>            </td>
          
          <td style="width:80px"> 第<%=pageNumber %>页         </td>
          
           <td style="width:160px"> <a  href="/WebPL/User/UserAlbum.aspx?pageNumber=<%=pageNumber+1 %>">下一页</a>            </td>

        </tr>
        </table>
        </form>
</div>
</div>

<div id="footer">
    <p class="address">地址：待定&nbsp;电话：123456789&nbsp;开发者版权所有。</p>
<p>Copyright&nbsp;&copy;2015 <a href="http://www.baidu.com/">百度连接</a>&nbsp;|&nbsp;Designed by&nbsp;<a href="#####">开发者致</a></p>
</div>

<!--弹出式登录--->
 <!--加一个半透明层--> 
    <div id="doing" style="filter:alpha(opacity=30);-moz-opacity:0.3;opacity:0.3;background-color:#000;width:100%;height:100%;z-index:1000;position: absolute;top:0;display:none;overflow: hidden;margin:0 auto;"> 
    </div>  
<!--加一个登录层--> 

<div id="divLogin" 
    style="z-index:1001;
	 position: absolute; 
	 display:none;
	 top:50%; 
	 left:50%;
	 margin:-200px 0 0 -200px;   
     border:1px solid #66D9EF;
    background: #fff;
	position:absolute; 
        
    width: 400px;
    height: 350px;
	">

<a href="javascript:void(0)" onclick="ShowNo()"><img src="Images/logo.gif"></a>
<form  method="post" action="Index.aspx">
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

</div>
</div>
    
<!--弹出式注册--->
 <!--加一个半透明层--> 
    <div id="ring" style="filter:alpha(opacity=30);-moz-opacity:0.3;opacity:0.3;background-color:#000;width:100%;height:100%;z-index:1000;position: absolute;top:0;display:none;overflow: hidden;margin:0 auto;"> 
    </div>  
<!--加一个登录层--> 
    <div id="register"
        style="z-index:1001;
	 position: absolute; 
	 display:none;
	 top:50%; 
	 left:50%;
	 margin:-200px 0 0 -200px;   
     border:1px solid #66D9EF;
    background: #fff;
	position:absolute; 
        
    width: 400px;
    height: 650px;
	">


<a href="javascript:void(0)" onclick="ShowNoRegister()"><img src="/WebPL/Images/logo.gif"></a>

<form  method="post" action="/WebPL/User/UserRegister.aspx">
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


</body>
</html>


