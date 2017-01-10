<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Front-end-Search.aspx.cs" Inherits="LiZhiOSManagement.Fore_endWEB.Front_end_Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Front-end讨论区</title>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/luntan.css" rel="stylesheet" />
</head>
<body>
    <a href="javascript:void(0)" id="back-to-top"><i class="fa fa-angle-up"> <span class="glyphicon glyphicon-chevron-up" ></span><pseudo:before/><pseudo:before/></i></a>
    <nav class="navbar navbar-default navbar-fixed-top">
  <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <a class="navbar-brand" href="Front-end.aspx">Front-end</a>
    </div>
    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav pull-left">
        <li class="active"><a href="index.aspx"> <span class = "glyphicon glyphicon-home"></span> 首页 <span class="sr-only">(current)</span></a></li>
        <li class="dropdown">
          <a href="javascript:void(0)" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">讨论区 <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="Android.aspx">Android讨论区</a></li>
            <li><a href="Net.aspx">.NET讨论区</a></li>
            <li><a href="Front-end.aspx">Front-end讨论区</a></li>
          </ul>
      </li>
        <li><a href="Android-Write-Article.aspx">发表文章</a></li>
      <li>
     <form class="navbar-form " role="search" method="get" action="Front-end-Search.aspx">
        <div class="form-group">
          <input type="text" class="form-control" placeholder="Search" name="searchMsg"/>
        </div>
        <input type="submit" value='搜索' class="btn btn-default" />
      </form>
      </li>
      </ul><!--nav.pull-left-->
      <ul class="nav navbar-nav navbar-right">
          <li><a class="username"><span class="glyphicon glyphicon-user"></span><span class="user_name"><%=Session["txtUser"] %></span></a></li>
      </ul><!--nav.pull-right-->
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav>
<div id="carousel-example-generic" class="carousel slide" data-ride="carousel" style="margin-bottom: 35px;">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src="images/2de797545de56274f03a5920eb3a1.jpg" alt="...">
      <div class="carousel-caption">
      
      </div>
    </div>
    <div class="item">
      <img src="images/home-banner-bg-hires-3aed57c6c13aa587773dfceab0bbc374.jpg" alt="..." >
      <div class="carousel-caption">
        
      </div>
    </div>
    <div class="item">
      <img src="images/demo-2-bg.jpg" alt="...">
      <div class="carousel-caption">
 
      </div>
    </div>
  </div>

  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
<!--结束Carousel-->

<div class="container">
  <div class="row">
 <div class="col-md-9">
        <div class="col-md-3">
            <div class="panel-group table-responsive" role="tablist">
                <div class="panel panel-primary leftMenu">
                    <!-- 利用data-target指定要折叠的分组列表 -->
                    <div class="panel-heading" id="collapseListGroupHeading1" data-toggle="collapse" data-target="#collapseListGroup1" role="tab">
                        <h5 class="panel-title">
                           最相关
                            <span style="float:right;" class="glyphicon glyphicon-chevron-down right"></span>
                        </h5>
                    </div>
                    <!-- .panel-collapse和.collapse标明折叠元素 .in表示要显示出来 -->
                    <div id="collapseListGroup1" class="panel-collapse collapse" role="tabpanel" aria-labelledby="collapseListGroupHeading1">
                        <ul class="list-group">
                            <li class="list-group-item" pb="bynew" count="1" kind_type="Front-end" onclick="leftnav(this)">
                                <a href="javascript:void(0)">最新发布</a>
                            </li>
                            <li class="list-group-item" pb="bycomment" count="1" kind_type="Front-end" onclick="leftnav(this)">
                               <a href="javascript:void(0)">最多回复</a>
                            </li>
                            <li class="list-group-item" pb="byfavorite" count="1" kind_type="Front-end" onclick="leftnav(this)">
                               <a href="javascript:void(0)">最多喜欢</a>
                            </li>
                            <li class="list-group-item" pb="bywatch" count="1" kind_type="Front-end" onclick="leftnav(this)">
                               <a href="javascript:void(0)">最多浏览</a>
                            </li>
                        </ul>
                    </div>
                </div><!--panel1 end-->
                <div class="panel panel-primary leftMenu">
                    <div class="panel-heading " id="collapseListGroupHeading2" data-toggle="collapse" data-target="#collapseListGroup2" role="tab">
                        <h4 class="panel-title">
                            时间
                            <span style="float:right;" class="glyphicon glyphicon-chevron-down right"></span>
                        </h4>
                    </div>
                    <div id="collapseListGroup2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="collapseListGroupHeading2">
                        <ul class="list-group">
                           <li class="list-group-item leftnavajax" pb="hour" count="1" kind_type="Front-end" onclick="leftnav(this)">
                               <a href="javascript:void(0)">24小时内</a>
                            </li>
                            <li class="list-group-item leftnavajax" pb="week" count="1" kind_type="Front-end" onclick="leftnav(this)">
                              <a href="javascript:void(0)">近一周</a>
                            </li>
                            <li class="list-group-item leftnavajax" pb="month" count="1" kind_type="Front-end" onclick="leftnav(this)">
                               <a href="javascript:void(0)">近一月</a>
                            </li>
                            <li class="list-group-item leftnavajax" pb="year" count="1" kind_type="Front-end" onclick="leftnav(this)">
                               <a href="javascript:void(0)">近一年</a>
                            </li>
                        </ul>
                    </div>
           </div><!--结束panel2-->
             <div class="panel panel-primary leftMenu">
                  <% List<LiZhiOSManagement.Model.ArticleGroupType> androidType=new List<LiZhiOSManagement.Model.ArticleGroupType>();
                    List<LiZhiOSManagement.Model.ArticleGroupType> netType=new List<LiZhiOSManagement.Model.ArticleGroupType>();
                    List<LiZhiOSManagement.Model.ArticleGroupType> frontendType=new List<LiZhiOSManagement.Model.ArticleGroupType>();
                    LiZhiOSManagement.BLL.SelectArticleGroupTypeBLL sagt = new LiZhiOSManagement.BLL.SelectArticleGroupTypeBLL();
                    androidType = sagt.SelectArticleType(3);
                    netType = sagt.SelectArticleType(1);
                    frontendType = sagt.SelectArticleType(2);
                    %>


                    <!-- 利用data-target指定要折叠的分组列表 -->
                    <div class="panel-heading" id="collapseListGroupHeading3" data-toggle="collapse" data-target="#collapseListGroup3" role="tab">
                        <h5 class="panel-title">
                           分类
                            <span style="float:right;" class="glyphicon glyphicon-chevron-down right"></span>
                        </h5>
                    </div>
                    <!-- .panel-collapse和.collapse标明折叠元素 .in表示要显示出来 -->
                    <div id="collapseListGroup3" class="panel-collapse collapse" role="tabpanel" aria-labelledby="collapseListGroupHeading3">
                        <ul class="list-group">
                        
                            <li class="list-group-item">
                               <a href="javascript:void(0)">Android<span class="glyphicon glyphicon-menu-right" style="float:right"></span></a>
                            <ul class="list-group">
                            	<%foreach (var item in androidType)
                                  {%>
                                      <li class="list-group-item" pb="<%=item.BelongType%>" count="1" kind_type="Android" onclick="leftnav(this)"><%=item.BelongType%></li>
                                  <%} %>
                            </ul>
                            </li>
                            <li class="list-group-item">
                               <a href="javascript:void(0)">.NET<span class="glyphicon glyphicon-menu-right" style="float:right"></span></a>
                                <ul class="list-group">
                            	<%
                                        foreach (var item in netType)
                                      {%>
                                          <li class="list-group-item" pb="<%=item.BelongType %>" count="1" kind_type=".NET" onclick="leftnav(this)"><%=item.BelongType %></li>
                                      <%}
                                         %>
                            </ul>
                            </li>
                            <li class="list-group-item">
                               <a href="javascript:void(0)">Front-end<span class="glyphicon glyphicon-menu-right" style="float:right"></span></a>
                                <ul class="list-group">
                                <%foreach (var item in frontendType)
                                      {%>
                                          <li class="list-group-item" pb="<%=item.BelongType %>" count="1" kind_type="Front-end" onclick="leftnav(this)"><%=item.BelongType %></li>
                                      <%} %>
                            </ul>
                            </li>
                            
                        </ul>
                    </div>
                </div><!--panel3 end-->
        </div><!--结束panel-group-->
    </div><!--结束md3-->
    <div class="col-md-9" runat="server" id="showArticle">
 
</div>
<!--结束md9-->
</div>
<!--结束8col-->
<aside class="col-md-3 sidebar">
                <!-- start widget -->
<!-- end widget -->	

<!-- start tag cloud widget -->
<div class="widget">
	<h4 class="title">交流群</h4>
	<div class="content community">
		<p>qq群:250492841(14-15级)</p>
        <p>qq群:250492841(13-14级)</p>
		<p>qq群:374034511(12-13级)</p>
	</div>
</div>
<!-- end tag cloud widget -->	

<!-- start widget -->
<div class="widget">
	<h4 class="title">下载</h4>
	<div class="content download">
		<a href="javascript:void(0)" class="btn btn-default btn-block" onclick="_hmt.push(['_trackEvent', 'big-button', 'click', '下载 Laravel &amp; Lumen'])">工作室资源下载</a>
	</div>
</div>
<!-- end widget -->	


<!-- start tag cloud widget -->
<div class="widget">
	<h4 class="title">标签云</h4><pseudo:after></<pseudo:after>
	<div class="content tag-cloud">
<a href="http://www.sias.edu.cn/">郑州大学西亚斯国际学院</a>
<a href="http://baike.baidu.com/link?url=m-E6ake9Y_Hg9DnrTGV38JwGHMNeqZZZ3_Pw6hnyFsuma2xnAEY3wttOb4AqdHACXuaHOH4cqnVEw2h8TRXPpa">励志工作室</a>
<a href="http://www.imooc.com/">慕课网</a>
<a href="http://blog.jobbole.com/">伯乐在线</a>
<a href="http://www.w3school.com.cn/index.html">w3school</a>
<a href="http://www.csdn.net/">CSDN</a>
<a href="http://www.w3cfuns.com/">w3cfuns</a>
<a href="http://www.runoob.com/">RUNOOB</a>
<a href="http://www.jianshu.com/">简书</a>
<a href="javascript:void(0)">···</a>
	</div>
</div>
<!-- end tag cloud widget -->	
</aside>
  </div><!--结束row-->
  <footer class="main-footer">
 <p>Copyright © 2016 郑州大学西亚斯国际学院 | Designed by 网络管理中心励志工作室
</p>
  </footer>  <!--结束Footer-->
</div><!--结束container-fluid-->

<script src="js/jQuery v1.11.2 .js"></script>
<script src="js/bsjquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/luntanJS.js"></script>
</body>
</html>
