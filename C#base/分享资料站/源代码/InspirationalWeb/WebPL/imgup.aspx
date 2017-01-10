<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="imgup.aspx.cs" Inherits="InspirationalWeb.WebPL.imgup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/WebPL/Plug/UEditor/themes/default/css/ueditor.css"/>
    <link rel="stylesheet" type="text/css" href="/WebPL/CSS/upimg.css"/>
    <link rel="stylesheet" type="text/css" href="/WebPL/CSS/SetNewArticle.css" />
    <script type="text/javascript" charset="utf-8" src="/WebPL/Plug/UEditor/ueditor.all.js"></script>
    <script type="text/javascript" charset="utf-8" src="/WebPL/Plug/UEditor/ueditor.config.js"></script>
     <script type="text/javascript" charset="utf-8" src="/WebPL/Plug/flashupload/swfobject.js"></script>
</head>
   
         <script type="text/javascript">
             function turnto(toa) {
                 window.location.href = toa;
             }//页面跳转

    </script>
    
    <body>
        <%--baiduUE--%>
        <%--<form id="form1" runat="server">
       
         <%--<div id="editor-img" style="display:none"></div><div id="temp-img-list" style="display: none"></div>
            <textarea id="editorimg" name="txteditor" runat="server" cols="20" rows="2">

 </textarea>
 <p>

 </p>
    <p>
        <script type="text/javascript">
            var ue = UE.getEditor('editorimg', {
                toolbars: [ 
                    ['simpleupload', 'insertimage']
                ],
                autoHeightEnabled: true,
                elementPathEnabled: false,
                autoFloatEnabled: true,
                initialFrameWidth: 28.4
            });
        </script>
    </p>
    </form>--%>
        

       <%-- <script type="text/javascript">
            window.onload = function () {
                var params = {
                    uploadServerUrl: "/WebPL/Plug/flashupload/upload.aspx",
                    maxFileData: 1024 * 300,
                    jsFunction: "upload",
                    fileter:"*.jpg;*.png"
                }

                swfobject.embedSWF("uploadImage.swf", "myContent", "500", "200", "10.0.0", "expressInstall.swf", params);
            }
            function upload() {
                alert("Susses!");
            }
        </script>
        <div id="myContent"></div>--%>



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
<div id="content">

	<form method="post" action="SetNewArticle.aspx">
    <table id="arMain">
    <tr>
        <td class="labletip">

        </td>
        <td></td>
        <td></td>
    </tr>
     <tr>

    	<td class="labletip">类型：</td>
         <td> <select name="FatherType" id="father" >
        
        <%=fatherTr %>
        </select></td>

    	

        
    </tr>

         <tr>
             <% 
                 if (fts!=0)
                   Context.Response.Write(@"<td class='labletip'>图片上传：</td>
 <td class='labletip'>
        
            <textarea id='editorimg' name='txteditor' runat='server' cols='20' rows='2'>

 </textarea>
 <p>

 </p>
    <p>
        <script type='text/javascript'>
            var ue = UE.getEditor('editorimg', {
                toolbars: [
                    ['simpleupload', 'insertimage']
                ],
                autoHeightEnabled: true,
                elementPathEnabled: false,
                autoFloatEnabled: true,
                initialFrameWidth: 28.4
            });
        </script>
    </p></td> ");
        
         %></tr>
    </table>
        <br />
    </form>
</div>

<div id="footer">
    <p class="address">地址：河南省新郑市人民路东168号&nbsp;电话：13245678950&nbsp;郑州大学西亚斯国际学院网络管理中心版权所有。</p>
<p>Copyright&nbsp;&copy;2015 <a href="http://www.sias.edu.cn/">郑州大学西亚斯国际学院</a>&nbsp;|&nbsp;Designed by&nbsp;<a href="Index.html">网络管理中心励志工作室</a></p>
</div>
    </body>
</html>
