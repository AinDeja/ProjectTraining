<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForTest.aspx.cs" Inherits="TestForNet.WEB.ForTest" %>

<!doctype html>
<html lang="zh">
<head>
<meta charset="UTF-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>个人考察</title>
<link rel="stylesheet" type="text/css" href="/WEB/CSS/RightList/default.css">

<link href="/WEB/CSS/RightList/app.css" rel="stylesheet" type="text/css">
    <!--签到信息css-->
    <link rel="stylesheet" type="text/css" href="/WEB/CSS/Signin/zzsc-demo.css">
    <link rel="stylesheet" type="text/css" href="/WEB/CSS/Signin/style.css" />
</head>
<body onload="AllHide()" style="background-color:#E4EBEB">
<div id="contentWrapper">

	<div id="contentLeft">

		<ul id="leftNavigation">

			<li class="active">
				<a href="#"><i class="fa fa-coffee leftNavIcon"></i> 首页</a>
				<ul>
					<li>
						<a href="#" onclick="SignInShow()"><i class="fa fa-angle-right leftNavIcon"></i> 签到信息</a>
					</li>
					<li>
						<a href="#" onclick="UserMess()"><i class="fa fa-angle-right leftNavIcon"></i> 个人信息</a>
					</li>
				</ul>
			</li>
			<!--<li>
				<a href="#"><i class="fa fa-flask leftNavIcon"></i> 前端</a>
				<ul>

					<li>
						<a href="#" onclick="HtmlTest()"><i class="fa fa-angle-right leftNavIcon"></i> 测试</a>
					</li>
					<li>
						<a href="#" onclick="HtmlProject()"><i class="fa fa-angle-right leftNavIcon"></i> 项目</a>
					</li>
				</ul>
			</li>-->
			<li>
				<a href="#"><i class="fa fa-truck leftNavIcon"></i> .NET</a>
				<ul>

					<li>
						<a href="#" onclick="NetTest()"><i class="fa fa-angle-right leftNavIcon"></i> 测试</a>
					</li>
					<li>
						<a href="#" onclick="NetProject()"><i class="fa fa-angle-right leftNavIcon"></i> 项目</a>
					</li>
				</ul>
			</li>
             <!--<li>
				<a href="#"><i class="fa fa-truck leftNavIcon"></i> 安卓</a>
				<ul>

					<li>
						<a href="#"><i class="fa fa-angle-right leftNavIcon"></i> 测试</a>
					</li>
					<li>
						<a href="#"><i class="fa fa-angle-right leftNavIcon"></i> 项目</a>
					</li>
				</ul>
			</li>-->
			<li class="clickable">
				<a href="#"><i class="fa fa-envelope-o leftNavIcon"></i> 客服邮箱</a>
			</li>

		</ul>

	</div>
      
	<div id="contentRight" >

	  

      <div id="SignInShow">
        <div id="page">
            <span><h1 align="center">签到信息</h1></span>
            <table id="table">
                <thead>
                    <tr>
                        <th>姓名</th>
                        <th>日期</th>
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
                *若签到信息有误，请联系管理员
            </code>
            </div>
          
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
    </div>

        <div id="UserMess">
            <style type="text/css">
                #userMess{
                   width:400px;
                margin:0 auto;
                }
                
                .leftlist{
                   text-indent:4em;
                    width:150px;
                }
                .rightlist{
                    text-align:left;
                    width:250px;
                }
          
            </style>
             <div id="page">
            <span><h1 align="center">个人信息</h1></span>
                 <table id="userMess">
                     <tr>
                         <td class="leftlist">姓名:</td>
                         <td class="rightlist">1</td>
                     </tr>
                      <tr>
                         <td class="leftlist">学号:</td>
                         <td class="rightlist">2</td>
                     </tr>
                      <tr>
                         <td class="leftlist">从属:</td>
                         <td class="rightlist">3</td>
                     </tr>
                      <tr>
                         <td class="leftlist">指定IP:</td>
                         <td class="rightlist">4</td>
                     </tr>
                 </table>
             </div>
    </div>


     <!--  <div id="HtmlTest">
            3

    </div>
         
    <div id="HtmlProject">
        4

    </div>--> 

        <div id="NetTest">
            5

    </div>

        <div id="NetProject">

            6
    </div>


	</div><!--右侧结束-->
    

</div>

<script src="/WEB/JS/RightList/jquery-2.1.1.min.js" type="text/javascript"></script>
<script src="/WEB/JS/RightList/jquery.ssd-vertical-navigation.min.js"></script>
<script src="/WEB/JS/RightList/app.js"></script>
  <script src="/WEB/JS/ShowOrNone.js"></script>
</body>
</html>