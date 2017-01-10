<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutSignOfExcle.aspx.cs" Inherits="LiZhiOSManagement.Management.adminSign" %>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="CSS/SignStyle.css" rel="stylesheet" type="text/css" />
<link href="CSS/buttonStyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="JS/jquery.js"></script>
    <script type="text/javascript" src="JS/dist/echarts.js"></script>

    </head>


<body>
 
                <!--签到信息【导出】--->

<div id="divExcle" 
    style="z-index:1001;
	 display: block;
   background: #E4EBEB;
   margin:0 auto;
   margin:50px;
    width: 400px;
    height: 400px;
	">


    <div id="selectDate" style="margin:100px auto auto 40px;font-size:20px;">
    <b>开始日期：</b><input style="border:2px solid #66D9EF;line-height:20px;" type="date" value="" id="firstDate" /><br />
    <b>结束日期：</b><input style="border:2px solid #66D9EF;line-height:20px;" type="date" value="" id="lastDate"/><br />
    <%--保存地址：<input style="border:2px solid #66D9EF;line-height:20px;" type="file" value="" id="filePath"/><br />--%>
            <div  style="margin-top:20px;">  
    <a href="javascript:void(0)" class="button button-3d button-primary button-rounded"   onclick="openout()">导出文件</a>
</div>
        </div>

    

    <script>
        function openout() {
            var Fday = document.getElementById('firstDate').value;
            var Lday = document.getElementById('lastDate').value;
            if (Fday == 0 && Lday == 0) {
                alert("日起不能为空！");
            }
                //var Path = document.getElementById('filePath').value;
            else {
                alert("文件即将下载！");
                window.location.href = 'AJAX/SignExcleOutPut.ashx?Fday=' + Fday + '&Lday=' + Lday + '';
            }
            


        }
    </script>





    </div>


    
</body>

</html>
