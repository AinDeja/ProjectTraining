<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TestForNet.WEB.Register" %>

<!DOCTYPE html> 
<html>
	<head>
		<title>jQuery半透明注册表单 - 站长素材</title>
		
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0">
		
		<link rel="stylesheet" href="/WEB/CSS/Register/demo.css">
		<link rel="stylesheet" href="/WEB/CSS/Register/sky-forms.css">
		<!--[if lt IE 9]>
			<link rel="stylesheet" href="/WEB/CSS/Register/sky-forms-ie8.css">
		<![endif]-->
		
		<script src="/WEB/JS/Register/jquery-1.9.1.min.js"></script>
		<script src="/WEB/JS/Register/jquery.validate.min.js"></script>
		<!--[if lt IE 10]>
			<script src="/WEB/JS/Register/jquery.placeholder.min.js"></script>
		<![endif]-->		
		<!--[if lt IE 9]>
			<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
			<script src="/WEB/JS/Register/sky-forms-ie8.js"></script>
		<![endif]-->
	</head>
	
	<body class="bg-cyan">
		<div class="body body-s">		
			<form action="" id="sky-form" class="sky-form">
				<header>请认真完整填写</header>
				
				<fieldset>					
					<section>
						<label class="input">
							<i class="icon-append icon-user"></i>
							<input type="text" name="username" placeholder="账号">
							<b class="tooltip tooltip-bottom-right">请不要使用非常用字符</b>
						</label>
					</section>
					
					<section>
						<label class="input">
							<i class="icon-append icon-envelope-alt"></i>
							<input type="email" name="email" placeholder="邮箱">
							<b class="tooltip tooltip-bottom-right">请确保格式正确</b>
						</label>
					</section>
					
					<section>
						<label class="input">
							<i class="icon-append icon-lock"></i>
							<input type="password" name="password" placeholder="密码" id="password">
							<b class="tooltip tooltip-bottom-right">请牢记你的密码</b>
						</label>
					</section>
					
					<section>
						<label class="input">
							<i class="icon-append icon-lock"></i>
							<input type="password" name="passwordConfirm" placeholder="确认密码">
							<b class="tooltip tooltip-bottom-right">请牢记你的密码</b>
						</label>
					</section>
				</fieldset>
					
				<fieldset>
					<div class="row">
						<section class="col col-6">
							<label class="input">
								<input type="text" name="firstname" placeholder="姓名">
							</label>
						</section>
						<section class="col col-6">
							<label class="input">
								<input type="text" name="lastname" placeholder="学号">
							</label>
						</section>
					</div>
					
					<section>
						<label class="select">
							<select name="gender">
								<option value="0" selected disabled>性别</option>
								<option value="1">男</option>
								<option value="2">女</option>
								
							</select>
							<i></i>
						</label>
					</section>
					
					<!--<section>
						<label class="checkbox"><input type="checkbox" name="subscription" id="subscription"><i></i>I 
					want to receive news and special offers</label>
						<label class="checkbox"><input type="checkbox" name="terms" id="terms"><i></i>I 
					agree with the Terms and Conditions</label>
					</section>-->
				</fieldset>
				<footer>
					<button type="submit" class="button">Submit</button>
				</footer>
			</form>			
		</div>
		
		<script type="text/javascript">
		    $(function () {
		        // Validation		
		        $("#sky-form").validate(
				{
				    // Rules for form validation
				    rules:
					{
					    username:
						{
						    required: true
						},
					    email:
						{
						    required: true,
						    email: true
						},
					    password:
						{
						    required: true,
						    minlength: 3,
						    maxlength: 20
						},
					    passwordConfirm:
						{
						    required: true,
						    minlength: 3,
						    maxlength: 20,
						    equalTo: '#password'
						},
					    firstname:
						{
						    required: true
						},
					    lastname:
						{
						    required: true
						},
					    gender:
						{
						    required: true
						},
					    terms:
						{
						    required: true
						}
					},

				    // Messages for form validation
				    messages:
					{
					    login:
						{
						    required: '请输入正确的用户名'
						},
					    email:
						{
						    required: '请输入正确的邮箱地址',
						    email: '请输入正确的邮箱地址'
						},
					    password:
						{
						    required: '请输入密码'
						},
					    passwordConfirm:
						{
						    required: '请再次输入密码',
						    equalTo: '请输入相同的密码'
						},
					    firstname:
						{
						    required: '请输入你的姓名'
						},
					    lastname:
						{
						    required: '请输入你的学号'
						},
					    gender:
						{
						    required: '请选择性别'
						},
					    terms:
						{
						    required: 'You must agree with Terms and Conditions'
						}
					},

				    // Do not change code below
				    errorPlacement: function (error, element) {
				        error.insertAfter(element.parent());
				    }
				});
		    });
		</script>

	</body>
</html>
