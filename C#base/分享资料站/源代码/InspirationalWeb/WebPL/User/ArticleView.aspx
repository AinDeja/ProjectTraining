<%@ Page Language="C#"   CodeBehind="ArticleView.aspx.cs" Inherits="InspirationalWeb.WebPL.User.ArticleView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>文章列表</title>
<link rel="stylesheet" type="text/css" href="/WebPL/CSS/ArticleView.css">
    <link rel="stylesheet" type="text/css" href="/WebPL/Plug/UEditor/themes/default/css/ueditor.css"/>
    <link rel="stylesheet" type="text/css" href="/WebPL/CSS/Login.css" />
    <link rel="stylesheet" type="text/css" href="/WebPL/CSS/Register.css" />
    <script type="text/javascript" src="/WebPL/JS/LoginTop.js"></script>
    <script type="text/javascript" src="/WebPL/JS/RegisterTop.js"></script>
    <script type="text/javascript" charset="utf-8" src="/WebPL/Plug/UEditor/ueditor.all.js"></script>
    <script type="text/javascript" charset="utf-8" src="/WebPL/Plug/UEditor/ueditor.config.js"></script>
</head>

<body>
	<div id="top">
	<%--<ul>
    	<li><a href="###">收藏本站</a><>
        <li><a href="###">文章</a><>
    </ul>
    <ul class="logic">
        <li>登录<>
        <li>注册<>
        <li>系统登录<>
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
	<%--<div id="lead">
    	<ul>
        <li><a href="#">首页</a></li>
        <li><a href="#">生活</a></li>
        <li><a href="#">相册</a></li>
        <li><a href="#">管理中心</a></li>
        </ul>
        </div>--%>
</div>
<div id="content">
	<h1><%=arTitle %></h1>
    <ul>
    <li class="index">作者：<a href="#"><%=arAuthor %></a></li>
    <li>发布时间：<a href="#"><%=arTime %></a></li>
    </ul>
    <div>
    <p><%=arContents %></p>
    <ul>
    <li class="one"><%=lastTr %></li>
     
    <li class="one"><%=nextTr %></li>
    </ul>
    </div>
</div>
<div id="banner">
<p><a href="#">评论(<%=j %>)</a></p>
    <ul>
    <%=replyTr %>
        </ul>
<%--<div class="userMess"><a href="#">小小</a></div>
<ul><li class="index"><a href="#">1楼</a></li>
<li><a href="#">发表时间：2015-9-10</a></li>
<li><p>呵呵，写得不错，支持一下……，我的空间更新了哦，欢迎互粉。</p></li>
<li><span><a href="#">回复</a></span></li></ul>--%>


</div>
    <br />
    <div class="two">
<form method="post" action="ArticleView.aspx" id="ueidtor">
    <textarea id="txteditor" name="txteditor" runat="server" cols="20" rows="2">
 <p>请输入</p>
 </textarea>
 <p>
     <script type="text/javascript">
         var editor = new baidu.editor.ui.Editor();
         editor.render('txteditor'); </script>
 </p>
    <p>
        <script type="text/javascript">
            var ue = UE.getEditor('txteditor',{
                toolbars: [ 
                    [ 'undo', //撤销
            'redo', //重做
            'bold', //加粗
            'indent', //首行缩进

            'italic', //斜体
            'underline', //下划线
            'strikethrough', //删除线
            'subscript', //下标
            'fontborder', //字符边框
            'superscript', //上标

            'source', //源代码

            'pasteplain', //纯文本粘贴模式
            'selectall', //全选

            'horizontal', //分隔线


            'cleardoc', //清空文档


            'fontfamily', //字体
            'fontsize', //字号
            'paragraph', //段落格式


            'link', //超链接

             'imagecenter', //居中
            'justifyleft', //居左对齐
            'justifyright', //居右对齐
            'justifycenter', //居中对齐
            'justifyjustify', //两端对齐
            'forecolor', //字体颜色
            ]
                ],
                autoHeightEnabled: true,
                autoFloatEnabled: true
            });
        </script>
    </p>
    <input id="Submit1" type="submit" value="submit" />
 </form>
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
