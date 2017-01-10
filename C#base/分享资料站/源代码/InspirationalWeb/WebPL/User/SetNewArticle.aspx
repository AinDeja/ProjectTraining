<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetNewArticle.aspx.cs" Inherits="InspirationalWeb.WebPL.User.SetNewArticle" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>励志工作室</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="/WebPL/CSS/SetNewArticle.css" />

    <link rel="stylesheet" type="text/css" href="/WebPL/Plug/UEditor/themes/default/css/ueditor.css"/>
    <script type="text/javascript" charset="utf-8" src="/WebPL/Plug/UEditor/ueditor.all.js"></script>
    <script type="text/javascript" charset="utf-8" src="/WebPL/Plug/UEditor/ueditor.config.js"></script>

</head>
    <script type="text/javascript">
        function turnto(toa) {
            window.location.href = toa;
        }//页面跳转
        </script>
<body>
<div id="top">
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
<div id="content">
	<form method="post" action="SetNewArticle.aspx">
    <table id="arMain">
    <tr>
    	<td></td>
        <td class="labletip">文章标题：</td>
        <td><input type="text" name="arTitle" id="title" /></td>
        <td></td>
    </tr>
     <tr>
         <td> </td>
         <td> </td>
    	<td class="labletip">父分类：
         <select name="FatherType" id="father" >
        
        <%=fatherTr %>
        </select>

    	</td>
        
        <td class="labletip">子分类： <select name="SonType" id="son">
        <%=sonTr %>
        </select></td>
        
    </tr>

    </table>
        <br />
        
        <div id="two">
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
           var ue = UE.getEditor('txteditor', {
               toolbars: [
                   ['undo', //撤销
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
                </div>
        <div id="sub"><input type="submit" value="发表" /></div>
        
    </form>
</div>

<div id="footer">
    <p class="address">地址：待定&nbsp;电话：123456789&nbsp;开发者版权所有。</p>
<p>Copyright&nbsp;&copy;2015 <a href="http://www.baidu.com/">百度连接</a>&nbsp;|&nbsp;Designed by&nbsp;<a href="#####">开发者致</a></p>
</div>



</body>
</html>
