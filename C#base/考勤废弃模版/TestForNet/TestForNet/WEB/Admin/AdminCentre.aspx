<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCentre.aspx.cs" Inherits="TestForNet.WEB.Admin.AdminCentre" %>

<!doctype html>
<html lang="zh">
<head>
<meta charset="UTF-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>后台管理中心</title>
<link rel="stylesheet" type="text/css" href="/WEB/CSS/RightList/default.css">

<link href="/WEB/CSS/RightList/app.css" rel="stylesheet" type="text/css">
</head>
<body onload="AllHide()">
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
						<a href="#" onclick="UserMess()"><i class="fa fa-angle-right leftNavIcon"></i> 成员信息</a>
					</li>
				</ul>
			</li>
			<li>
				<a href="#"><i class="fa fa-flask leftNavIcon"></i> 前端</a>
				<ul>

					<li>
						<a href="#" onclick="HtmlTest()"><i class="fa fa-angle-right leftNavIcon"></i> 测试</a>
					</li>
					<li>
						<a href="#" onclick="HtmlProject()"><i class="fa fa-angle-right leftNavIcon"></i> 项目</a>
					</li>
				</ul>
			</li>
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
            <li>
				<a href="#"><i class="fa fa-truck leftNavIcon"></i> 安卓</a>
				<ul>

					<li>
						<a href="#"><i class="fa fa-angle-right leftNavIcon"></i> 测试</a>
					</li>
					<li>
						<a href="#"><i class="fa fa-angle-right leftNavIcon"></i> 项目</a>
					</li>
				</ul>
			</li>
			<li class="clickable">
				<a href="#"><i class="fa fa-envelope-o leftNavIcon"></i> 客服邮箱</a>
			</li>

		</ul>

	</div>
      
	<div id="contentRight" >

	  

        <div id="SignInShow">
         <header class="htmleaf-header">
			<h1>jQuery左侧固定侧边栏菜单代码</h1>
		</header>

    </div>

        <div id="UserMess">

            2
    </div>


        <div id="HtmlTest">
            3

    </div>
         
    <div id="HtmlProject">
        4

    </div>

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