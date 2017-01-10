<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysAdmin.aspx.cs" Inherits="DSBBS.Admin.SysAdmin" %>





       <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DS-BBS</title>
    <link rel="stylesheet" type="text/css"  href="/css/IndexTwo.css" />
  <script type="text/javascript">
      function turnto(toa) {
          window.location.href = toa;
      }
      function pageScroll() {
          //把内容滚动指定的像素数（第一个参数是向右滚动的像素数，第二个参数是向下滚动的像素数）
          window.scrollBy(0, -500);
          //延时递归调用，模拟滚动向上效果
          scrolldelay = setTimeout('pageScroll()', 100);
          //获取scrollTop值，声明了DTD的标准网页取document.documentElement.scrollTop，否则取document.body.scrollTop；因为二者只有一个会生效，另一个就恒为0，所以取和值可以得到网页的真正的scrollTop值
          var sTop = document.documentElement.scrollTop + document.body.scrollTop;
          //判断当页面到达顶部，取消延时代码（否则页面滚动到顶部会无法再向下正常浏览页面）
          if (sTop == 0) clearTimeout(scrolldelay);
      }
  </script>
</head>
    
<body>
    <div id="unbody">
    <%--top--%>
   <div id="top">
       <ul id="collect">

          <li><a href="#" >收藏本站</a></li>
          <li><a href="#">设为首页</a></li>
      </ul>

      <ul id="login">
         <li><%if (Session["AdminName"] == null)
                      {
                          Context.Response.Write("<a href='/IndexTwo.aspx'><i id='i3'></i>论坛首页</a>");
                      }
                      else
                      {
                          Context.Response.Write("<a href='/HTML/UserIndex.aspx'><i id='i1'></i>论坛首页</a>");
                      }%></li>
                <li><a href="#"><i id="i2"></i>欢迎您 <%=Session["AdminName"] %></a></li>
                <li><%if (Session["AdminName"] == null)
                      {
                          Context.Response.Write("<a href='AdminLogin.aspx'><i id='i3'></i>管理登录</a>");
                      }
                      else
                      {
                          Context.Response.Write("<a href='AuserMess.aspx'><i id='i3'></i>信息管理</a>");
                      }%></li>
               <%if (Session["AdminName"] != null)
                      {
                          Context.Response.Write(" <li><a href='ApostEdit.aspx'><i id='i4'></i>贴子管理</a></li>");
                      }%>
                <%if (Session["AdminName"] != null)
                      {
                      
                          Context.Response.Write("<li><a href='AdminLogin.aspx?exitUser=1'><i id='i4'></i>退出登录</a></li>");
                      }%>
      </ul>
   </div>

<%--    logo--%>
    <div id="logo">
        <embed src="/flash/we.swf"width="800" height="200" wmode="transparent"></embed>
    </div>

        <div id="mainBg">
   <%-- main--%>
    <div id="main">


<div id="loginwin">    
        <form method="post" action="/Admin/SysAdmin.aspx">
            <fieldset  class="loginUser">
            <legend><%=tip %></legend>
<table>
            
    <tr>
        <td>
            帐号：
        </td>
        <td>
            <input type="text" name="AdminName" />
        </td>
    </tr>
    <tr>
        <td>
            密码：
        </td>
        <td>
            <input type="password" name="PassWord" />
        </td>
    </tr>
      <tr>
          
        <td>
             <input type="reset"  />
        </td>
        <td>
            <input type="submit" name="sub" value="登录"/>
        </td>
          <td>
              <%--<input type="checkbox"  name="freeLogin" value="一周内免登录" />一周内免登录--%>
          </td>
    </tr>
</table>
                </fieldset> 
</form>
      </div>


</div><!--右侧区域结束-->
</body>
</html>