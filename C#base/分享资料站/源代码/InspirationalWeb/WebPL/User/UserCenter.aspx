<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCenter.aspx.cs" Inherits="InspirationalWeb.WebPL.User.UserCenter1" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>修改资料</title>
<link type="text/css" rel="stylesheet" href="/WebPL/CSS/UserCenter.css">
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
    	<li><a href="Index.html">进入首页</a></li>
        <li>登录</li>
        <li>注册</li>
        <li>系统登录</li>
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
                            
                              Context.Response.Write("<a href='#' onclick='showFloat()'><i id='i3'></i>登录</a>");
                       
                          }
                          else
                          {
                          
                                  Context.Response.Write("<a href='/WebPL/User/UserCenter.aspx'><i id='i3'></i>用户中心</a>");
                        
                          }
                         
                      %></li>
                <li><%if (Session["Name"] == null)
                      {
                       
                              Context.Response.Write("<a href='#' onclick='showFloatRegister()'><i id='i4'></i>注册</a>");
                        
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

<div id="file">
        <div id="leftarea">
        	<div class="panel">
              <div class="panel-title">
                <h3><a href="###">个人资料</a></h3>
                </div>
                <div class="panel-content">
                  <ul>
                     <li><a href="/WebPL/User/UserCenter.aspx">· 个人资料</a></li>
                  </ul>
                </div>
              </div>
            <div class="panel">
              <div class="panel-title">
                <h3><a href="###">个人文章</a></h3>
              </div>
              <div class="panel-content">
                <ul>
                  <li><a href="/WebPL/User/UserArticleManage.aspx">· 文章管理</a></li>
                  <li><a href="/WebPL/User/UserArticleType.aspx">· 分类管理</a></li>
                </ul>
              </div>
            </div>
            <div class="panel">
              <div class="panel-title">
                <h3><a href="###">相册</a></h3>
              </div>
              <div class="panel-content">
                <ul>
                  <li><a href="###"  onclick="turnto('/WebPL/imgup.aspx')">· 上传相片</a></li>
                </ul>
              </div>
            </div>
        </div>
	<div id="rightarea">
    	<div class="data">
    	<div class="data-title">
        	<h3>基本资料<a href="###"></a></h3>
        </div>

        
<form method="post" action="UserCenter.aspx" >
<table>
    
<%=tTr.ToString() %>
    
    <tr>
        
        <td><input type="submit" value="修改"/></td>
        <%=sure.ToString() %>
    </tr>
    
</table>
    </form>


        </div>
</div>
<div id="footer">
    <p class="address">地址：待定&nbsp;电话：123456789&nbsp;开发者版权所有。</p>
<p>Copyright&nbsp;&copy;2015 <a href="http://www.baidu.com/">百度连接</a>&nbsp;|&nbsp;Designed by&nbsp;<a href="#####">开发者致</a></p>
</div>
</body>
</html>
