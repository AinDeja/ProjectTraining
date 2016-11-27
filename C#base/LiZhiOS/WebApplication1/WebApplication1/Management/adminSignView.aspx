<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminSignView.aspx.cs" Inherits="WebApplication1.Management.adminSignView" %>

<!doctype html>
<html lang="zh">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0 maximum-scale=1.0, user-scalable=no" />
    <title>签到信息</title>
    <link rel="stylesheet" type="text/css" href="/WEB/CSS/Signin/zzsc-demo.css">
    <link rel="stylesheet" type="text/css" href="/WEB/CSS/Signin/style.css" />

</head>
<body>

    <div class="zzsc-container">
        <div id="page">
            <span><h1 align="center">励志工作室<a href="adminSign.aspx"> <img src="/WEB/Images/Index/tLogo.gif" width="100px"></a> 签到时间表</h1></span>
            <table id="table">
                <thead>
                    <tr>
                        <th>姓名</th>
                        <th>从属</th>
                        <th>上午</th>
                        <th>下午</th>
                        <th>晚上</th>
                    </tr>
                </thead>
                <tbody>
                   <!--签到信息展示-->
                    <%=tTr %>
                </tbody>
            </table>

            <code class="js">
                时间为<font color="blue">蓝色</font>表示迟到，<font color="#FF0000">红色</font>严重迟到，<font color="##FF0000">X</font>未签到,<font color="##FF0000">O</font>待签到
                <br>
                *签到时间：周一到周五晚上，周六上午、下午，周日下午、晚上
                <br>
                *可签到时间：早上 5:00~12:00 下午 13：00~17:00 晚上 18:00~22:00
                <br />
                *若周一到周五【白天】没课，来了也能签到，若未签或任何【颜色】显示，都不记入日常考勤
                 <br>
                *若签到信息有误，请联系管理员
            </code>



            <script src="js/Signin/jquery-2.1.1.min.js" type="text/javascript"></script>
            <script type="text/javascript" src="js/Signin/jquery.basictable.min.js"></script>
            <script type="text/javascript">
                $(document).ready(function () {
                    $('#table').basictable();

                    $('#table-breakpoint').basictable({
                        breakpoint: 768
                    });

                    $('#table-swap-axis').basictable({
                        swapAxis: true
                    });

                    $('#table-force-off').basictable({
                        forceResponsive: true
                    });

                    $('#table-no-resize').basictable({
                        noResize: true
                    });

                    $('#table-two-axis').basictable();

                    $('#table-max-height').basictable({
                        tableWrapper: true
                    });
                });
            </script>

</body>
</html>
