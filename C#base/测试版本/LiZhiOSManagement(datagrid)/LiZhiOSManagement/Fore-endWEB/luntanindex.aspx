<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="luntanindex.aspx.cs" Inherits="LiZhiOSManagement.Fore_endWEB.luntanindex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>励志工作室——学习讨论区</title>
    <link href="CSS/reset.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/layout.css" type="text/css" media="all"/>
    <link href="CSS/style.css" rel="stylesheet" />
    <link href="CSS/prettyPhoto.css" rel="stylesheet" />
    <script src="JS/jquery.min.js"></script>
    <script src="JS/mobilyblocks.js"></script>
    <script src="JS/script.js"></script>
    <script src="JS/superfish.js"></script>
    <script src="JS/jquery.transform-0.9.3.min.js"></script>
    <script src="JS/atooltip.jquery.js"></script>
    <script src="JS/pages.js"></script>
    <script src="JS/jScrollPane.js"></script>
    <script src="JS/jquery.mousewheel.js"></script>
    <script src="JS/contact-form.js"></script>
</head>
<body class="keBody">
    <h1 class="keTitle">学习讨论区</h1>
<div class="kePublic">
<!--效果html开始-->
        <div id="content">
            <ul>
                <li id="page_0">
                    <div class="inner">
                        <nav class="menu">
                            <ul id="menu" class="reset">
                                <li id="nav1"><a href="Android.aspx"><img src="images/nav1.png" alt="" class="img"><img src="images/nav1_active.png" alt="Andriod" class="img_act"></a></li>

                              <li id="nav7"><a href="Front-end.aspx"><img src="images/nav7.png" alt="" class="img"><img src="images/nav7_active.png" alt="Front-end" class="img_act"></a></li>
                              
                                <li id="nav4"><a href="Net.aspx"><img src="images/nav4.png" alt="" class="img"><img src="images/nav4_active.png" alt="Net" class="img_act"></a></li>
                              
                                
                                
                                
                            </ul>
                        </nav>
                        <div class="menu_box">
                            <div class="images">
                                <span class="nav1"></span>
                               
                                <span class="nav4"></span>
                                
                                <span class="nav7"></span>
                               
                            </div>
                            <div class="tittles">
                                <div class="nav1">
                                    <h2>Android</h2>
                                </div>
                                
                                <div class="nav4">
                                    <h2>.Net</h2>
                                </div>
                                
                                <div class="nav7">
                                    <h2>Front-end</h2>
                                </div>
                               
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
      </div>
        <!--content end-->
</div>
<script>
    $(window).load(function () {
        $('.spinner').hide();
        $('body').css({ overflow: 'inherit' });
    })
</script>
<div class="keBottom">
<p class="keTxtP"> <b>Copyright © 2016 郑州大学西亚斯国际学院 | Designed by 网络管理中心励志工作室</b>
</div>
</body>
</html>
