<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Net.aspx.cs" Inherits="LiZhiOSManagement.Fore_endWEB.Net" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>.Net讨论区</title>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/luntan.css" rel="stylesheet" />
</head>
<body>
    <a href="javascript:void(0)" id="back-to-top"><i class="fa fa-angle-up"> <span class="glyphicon glyphicon-chevron-up" ></span><pseudo:before/><pseudo:before/></i></a>
    <nav class="navbar navbar-default navbar-fixed-top">
  <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <a class="navbar-brand" href="NET.aspx">.Net</a>
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
     <form class="navbar-form " role="search" method="get" action="Net-Search.aspx?kindtype=.NET">
        <div class="form-group">
          <input type="text" class="form-control" placeholder="Search" name="searchMsg" />
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
      <img src="images/2de797545de56274f03a5920eb3a1.jpg" alt="..." />
      <div class="carousel-caption">
      
      </div>
    </div>
    <div class="item">
      <img src="images/home-banner-bg-hires-3aed57c6c13aa587773dfceab0bbc374.jpg" alt="..." />
      <div class="carousel-caption">
        
      </div>
    </div>
    <div class="item">
      <img src="images/demo-2-bg.jpg" alt="..." />
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
                            <li class="list-group-item" pb="bynew" count="1" kind_type=".NET" onclick="leftnav(this)">
                                <a href="javascript:void(0)">最新发布</a>
                            </li>
                            <li class="list-group-item" pb="bynew" count="1" kind_type=".NET" onclick="leftnav(this)">
                               <a href="javascript:void(0)">最多回复</a>
                            </li>
                            <li class="list-group-item" pb="bynew" count="1" kind_type=".NET" onclick="leftnav(this)">
                               <a href="javascript:void(0)">最多喜欢</a>
                            </li>
                            <li class="list-group-item" pb="bynew" count="1" kind_type=".NET" onclick="leftnav(this)">
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
                           <li class="list-group-item" pb="hour" count="1" kind_type=".NET" onclick="leftnav(this)">
                               <a href="javascript:void(0)">24小时内</a>
                            </li>
                            <li class="list-group-item" pb="week" count="1" kind_type=".NET" onclick="leftnav(this)">
                              <a href="javascript:void(0)">近一周</a>
                            </li>
                            <li class="list-group-item" pb="month" count="1" kind_type=".NET" onclick="leftnav(this)">
                               <a href="javascript:void(0)">近一月</a>
                            </li>
                            <li class="list-group-item" pb="year" count="1" kind_type=".NET" onclick="leftnav(this)">
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
    <%--<article id="1" class="post">
    <div class="post-head">
        <h1 class="post-title">Composer 走到了 v1.0 版本</h1>
        <div class="post-meta">
            <span class="author">作者：汪宇</span> •
            <time class="post-date" datetime="2016年4月6日星期三凌晨3点19分" title="2016年4月6日星期三凌晨3点19分">2016年5月20日</time>
        </div>
    </div>
    <div class="featured-media">
        <img src="images/1a.png" class="pic" alt="Laravel 5.2 正式发布">
    </div>
    <div class="post-content">
        Composer 项目刚刚宣布在其第五个生日的同一天发布了 V1.0
         正式版。 以下翻译自 Composer 创始人 Jordi Boggiano 的原文：五年前的今天，Compos
         er 诞生了。在某些方面，这感觉就像昨天发生的事，至少它不像过去了五年。但在其他方面，好像是上辈子的事了，没有一
         个完整的 PHP 生式发布了。这一版本的发布标志着 PHP 7 新系列开始了。 PHP 7.0.0 带来了新版本的 Zen式发布了。这一版本的发布标志着
          PHP 7 新系列开始了。 PHP 7.0.0 带来了新版本的 Zen式发布了。这一版本的发布标志着 PHP 7 新系列开始了。 PHP 7.0.0 带来了新
          版本的 Zen式发布了。这一版本的发布标志着 PHP 7 新系列开始了。 PHP 7.0.0 带来了新版本的 Zen式发布了。这一版本的发布标志
          着 PHP 7 新系列开始了。 PHP 7.0.0 带来了新版本的 Zen式发布了。这一版本的发布标志着 PHP 7 新系列开始了。 PHP 7.0.0 带来了新版本的 Zen
    </div>
     <div class="post-permalink">
        <a href="Android-Article.aspx" class="btn btn-default">阅读全文</a>
    </div>
    <footer class="post-footer clearfix">
        <div class="pull-left tag-list"><span class="glyphicon glyphicon-tag"></span>
            <a href="javascript:void(0)">Laravel 5</a>, <a href="javascript:void(0)">asp.Net</a>
        </div>
       <div class="comment">
        <a href="Android-Article.aspx#article-comment">
     <span>评论</span>
         <span class="glyphicon glyphicon-comment"></span>
         </a>
        </div>
            
        <div class="pull-right share">
        </div>
    </footer>
</article>

<article id="62" class="post">
    <div class="post-head">
        <h1 class="post-title">PHP 7.0.0正式版发布了</h1>
        <div class="post-meta">
            <span class="author">作者：呆熊</span> •
            <time class="post-date" datetime="2016年4月6日星期三凌晨3点19分" title="2016年4月6日星期三凌晨3点19分">2016年4月6日</time>
        </div>
    </div>
    <div class="featured-media">
        <img src="images/php7.png" class="pic" alt="Laravel 5.2 正式发布">
    </div>
    <div class="post-content">
       PHP 团队宣布 PHP 7.0.0 正式发布了。这一版本的发布标志着 PHP 7 新系列开始了。 PHP 7.0.0 带来了新版本的 Zend 引擎、
        各方面的提升以及新特性，比如： 性能提升：PHP 7 是 PHP 5.6 的将近两倍 内存的使用显著降低 抽象语法树 一致的 64 位支持 许
        
        多重大的错误转为异常 安的 64 位支持 许多重大的错误转为异常 安的 64 位支持 许多重大的错误转为异常 安的 64 位支持 许多重大
        的错误转为异常 安的 64 位支持 许多重大的错误转为异常 安的 64 位支持 许多重大的错误转为异常 安的 64 位支持 许多重大的错误
        转为异常 安的 64 位支持 许多重大的错误转为异常 安的 64 位支持 许多重大的错误转为异常 安的 64 位支持 许多重大的错误转为异常 安全
    </div>
    <div class="post-permalink">
        <a href="/post/composer-announces-v1-0/" class="btn btn-default">阅读全文</a>
    </div>
    <footer class="post-footer clearfix">
        <div class="pull-left tag-list">
            <span class="glyphicon glyphicon-tag"></span>
            <a href="javascript:void(0)">Laravel 5</a>, <a href="javascript:void(0)">asp.Net</a>
        </div>
        <div class="comment">
        <a href="Android-Article.aspx#article_comment">
     <span>评论</span>
         <span class="glyphicon glyphicon-comment"></span>
         </a>
        </div>
            
        <div class="pull-right share">
        </div>
    </footer>
</article>

<article id="62" class="post">
    <div class="post-head">
        <h1 class="post-title">Symfony 2.7.0 LTS 正式版发布</h1>
        <div class="post-meta">
            <span class="author">作者：创业</span> •
            <time class="post-date" datetime="2016年4月6日星期三凌晨3点19分" title="2016年4月6日星期三凌晨3点19分">2016年3月3日</time>
        </div>
    </div>
    <div class="featured-media">
     
    </div>
    <div class="post-content">
        赶在五月底，Symfony 2.7.0 正式版发布了，这个版本是最新的 LTS（Long Term Support Version －－ 长期支持版本）版本。 咱
        们不是 Laravel 中文网吗，干嘛提 Symfony 呢？因为 Laravel 底层依赖 Symfony 组件，所以 Symfony 的新版本，尤其是这种持版
        本）版本。 咱们不是 Laravel 中文网吗，干嘛提 Symfony 呢？因为 Laravel 底层依赖 Symfony 组件，所以 Symfony </div>
    <div class="post-permalink">
        <a href="/post/composer-announces-v1-0/" class="btn btn-default">阅读全文</a>
    </div>
    <footer class="post-footer clearfix">
        <div class="pull-left tag-list"><span class="glyphicon glyphicon-tag"></span>
            <a href="javascript:void(0)">Laravel 5</a>, <a href="javascript:void(0)">asp.Net</a>
        </div>
        <div class="comment">
        
        <a href="#">
     <span>评论</span>
         <span class="glyphicon glyphicon-comment"></span>
         </a>
        </div>
            
        <div class="pull-right share">
        </div>
    </footer>
</article>
<nav style="margin:0 auto; width:100%;">

  <ul class="pagination pagination-lg" >
    <li>
      <a href="#" aria-label="Previous">
        <span aria-hidden="true">&laquo;</span>
      </a>
    </li>
    <li><a href="javascript:void(0)">1</a></li>
    <li><a href="javascript:void(0)">2</a></li>
    <li><a href="javascript:void(0)">3</a></li>
    <li><a href="javascript:void(0)">4</a></li>
    <li><a href="javascript:void(0)">5</a></li>
    <li><a href="javascript:void(0)">6</a></li>
    <li><a href="javascript:void(0)">7</a></li>
    <li><a href="javascript:void(0)">8</a></li>
    <li><a href="javascript:void(0)">9</a></li>
    <li><a href="javascript:void(0)">···</a></li>
    <li>
      <a href="#" aria-label="Next">
        <span aria-hidden="true">&raquo;</span>
      </a>
    </li>
  </ul>
</nav>--%>
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
