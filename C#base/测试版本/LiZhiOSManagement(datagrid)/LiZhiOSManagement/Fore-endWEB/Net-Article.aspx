<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Net-Article.aspx.cs" Inherits="LiZhiOSManagement.Fore_endWEB.Net_Article" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>.Net讨论区</title>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/luntan.css" rel="stylesheet" />
    <link href="CSS/smohan.share.css" rel="stylesheet" />
    <script src="../ueditor/ueditor.config.js"></script>
    <script src="../ueditor/ueditor.all.js"></script>
    <style type="text/css">
        #myEditor {
            width: 700px;
        }
    </style>
</head>
<body>
    <a href="javascript:void(0)" id="back-to-top"><i class="fa fa-angle-up"><span class="glyphicon glyphicon-chevron-up"></span>
        <pseudo:before />
        <pseudo:before />
    </i></a>
    <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <a class="navbar-brand" href="Net.aspx">.Net</a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav pull-left">
                    <li class="active"><a href="index.aspx"><span class="glyphicon glyphicon-home"></span>首页 <span class="sr-only">(current)</span></a></li>
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
                        <form class="navbar-form " role="search" method="get" action="Net-Search.aspx">
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Search">
                            </div>
                            <input type="submit" value='搜索' class="btn btn-default">
                        </form>
                    </li>
                </ul>
                <!--nav.pull-left-->
                <ul class="nav navbar-nav navbar-right">
                    <li><a class="username"><span class="glyphicon glyphicon-user"></span><span class="user_name"><%=Session["txtUser"] %></span></a></li>
                </ul>
                <!--nav.pull-right-->
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
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
                <img src="images/home-banner-bg-hires-3aed57c6c13aa587773dfceab0bbc374.jpg">
                <div class="carousel-caption">
                </div>
            </div>
            <div class="item">
                <img src="images/demo-2-bg.jpg">
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
            <div class="col-md-8" style="overflow:auto;">

                <article class="post" id="1">
                    <header class="post-head">
                        <%
            
                            //LiZhiOSManagement.BLL.SelectArticleBLL sa = new LiZhiOSManagement.BLL.SelectArticleBLL();
                            LiZhiOSManagement.DAL.SelectArticleBelongUserDAL sd = new LiZhiOSManagement.DAL.SelectArticleBelongUserDAL();
                            LiZhiOSManagement.BLL.SelectFavoriteArticleIDBLL sf = new LiZhiOSManagement.BLL.SelectFavoriteArticleIDBLL();

                            Session["kind_type"] = Request.Params["kind_type"] == null ? Session["kind_type"] : Request.Params["kind_type"];

                            //string id = Request.Params["ID"];
                            //Session["articleID"] = (Convert.ToInt32(Request.Params["ID"]) != 0) ? Convert.ToInt32(Request.Params["ID"]) : Session["articleID"];
                            //List<LiZhiOSManagement.Model.Article> list = sa.SelectArticleById(Convert.ToInt32(Session["articleID"]));
                            foreach (var item in listshow)
                            {
                        %>

                        <h1 class="post-title"><%=item.Title %></h1>

                        <section class="post-meta">
                            <span class="author"><%=sd.SelectUser(item.BelongUser)%></span> •
            <time title="2016年4月6日星期三凌晨3点19分" datetime="2016年4月6日星期三凌晨3点19分" class="post-date"><%=item.CreateTime %></time>
                        </section>
                        <section class="postContent"><%=item.Content %></section>

                        <%
                            }
                        %>
                    </header>
                    <footer class="post-footer clearfix">

                        <div class="comment-amount">
                            <a href="javascript:void(0)" class="like pull-left" articleid="<%=Convert.ToInt32(Session["articleBysearchID"])%>" userid="<%=Convert.ToInt32(Session["ID"])%>" kindtype="<%=Convert.ToString(Session["kind_type"]) %>">
                                <%if (sf.SelectFavoriteArticleId(Convert.ToInt32(Session["articleBysearchID"]), Convert.ToInt32(Session["ID"])).Count > 0)
                                  { %>
                                <span class="glyphicon glyphicon-heart red"></span><%} %>
                                <%else
                                  {%>
                                <span class="glyphicon glyphicon-heart-empty"></span><%} %>
          喜欢(<span class="favorite" id="a"><%=sf.SelectFavoriteArticleCount(Convert.ToInt32(Session["articleBysearchID"]),Convert.ToString(Session["kind_type"])) %></span>)</a>
                            <a class="share" style="float: right"><span class="glyphicon glyphicon-share"></span>分享</a>
                        </div>
                    </footer>





                </article>




                <div id="comments" class="comment-list clearfix">
                    <div class="comment-head">
                        <span class="wzpl"><span class="glyphicon glyphicon-edit"></span>文章评论</span><br>
                        <%=listChildrenMessages.Count %>条评论
          <span class="order">（
            <a data-order="asc" class="active" href="javascript:void(0)">按时间正序</a>·
            <a data-order="desc" href="javascript:void(0)">按时间倒序</a>·
            <a data-order="likes_count" href="javascript:void(0)">按喜欢排序</a>
              ）
          </span>

                    </div>
                    <!--结束comment-head-->
                    <% for (int i = 0; i < listChildrenMessages.Count; i++)
                       { %>
                    <div id="comment-list">

                        <div class="note-comment clearfix" id="comment-1" style="overflow:auto;">
                            <!--此id为第评论+回复数（总）-->
                            <span class="comment-name"><%=listChildrenMessages[i].CommentUser %></span><br>
                            <span class="comment-floor"><%=i+1 %>楼</span> · <time class="comment-time"><%=listChildrenMessages[i].CreateTime %></time>
                            <p class="comment-content"><%=listChildrenMessages[i].MessBelong %></p>
                            <%--  一级评论--%>
                            <div class="comment-toolbar clearfix">

                                <a href="javascript:void(0)" class="like pull-left" commentid="<%=listChildrenMessages[i].ID %>" userid="<%=Convert.ToInt32(Session["ID"]) %>" articleid="<%=Convert.ToInt32(Session["articleBysearchID"])%>" kindtype=".Net">
                                    <% 
                           if (sf.SelectFavoriteMessagesId(listChildrenMessages[i].ID, Convert.ToInt32(Session["ID"]), Convert.ToInt32(Session["articleBysearchID"])) > 0)
                           {%>
                                    <span class="glyphicon glyphicon-heart red"></span><% }%>
                                    <%else
           {%>
                                    <span class="glyphicon glyphicon-heart-empty"></span><%}%>
          
          
 
    喜欢(<span class="favorite"><%=sf.SelectFavoriteMessagesCount(listChildrenMessages[i].ID,Convert.ToInt32(Session["articleBysearchID"])) %></span>)</a>
                                <span class="pull-right">
                                    <a href="javascript:void(0)" class="reply" data-id="0">
                                        <i class="fa fa-pencil"></i>
                                        <span class="glyphicon glyphicon-pencil"></span>
                                        添加新回复</a>
                                </span>
                            </div>
                            <!--结束comment-toolbar-->


                            <%=GetMessageData(listChildrenMessages[i].ID) %>



                            <div class="comment-text">
                                <form action="Net-Article.aspx?commentId=<%=Convert.ToInt32(listChildrenMessages[i].ID) %>" method="post">
                                    <textarea maxlength="2000" placeholder="写下你的回复…" class="form-control" name="makeComment"></textarea><input type="submit" value="提交" class="btn btn-primary btn-sm" />
                                </form>
                            </div>
                            <!--结束comment-text-->
                            <hr>
                            <%--</div>--%><!--结束child-comment-list-->


                        </div>
                        <!--结束note-comment-->



                    </div>
                    <!--结束comment-list-->
                    <%  } %>
                </div>
                <!--结束comments-->



                <div id="article-comment" class="container-fluid">
                    <span class="glyphicon glyphicon-pencil" style="font-size: medium">添加新评论</span>

                    <div>
                        <form id="form1">

                            <textarea id="myEditor" name="myEditor" runat="server" onblur="setUeditor()"></textarea>
                            <script type="text/javascript">
                                var editor = new baidu.editor.ui.Editor();
                                editor.render("myEditor");
                            </script>

                            <button type="submit" class="btn btn-info pull-right" style="margin-right: -10px; margin-top: 16px;">发表</button>



                        </form>
                    </div>

                </div>


            </div>
            <!--结束8col-->
            <aside class="col-md-4 sidebar">
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
                        <a href="javascript:void(0)" class="btn btn-default btn-block">工作室资源下载</a>
                    </div>
                </div>
                <!-- end widget -->

                <!-- start tag cloud widget -->
                <div class="widget">
                    <h4 class="title">标签云</h4>
                    </pseudo:after></pseudo:after>
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
        <a href="javascript:void(0)">...</a>
    </div>
                </div>
                <!-- end tag cloud widget -->
            </aside>


        </div>
        <!--结束row-->

        <footer class="main-footer">
            <p>
                Copyright © 2016 郑州大学西亚斯国际学院 | Designed by 网络管理中心励志工作室
            </p>
        </footer>
        <!--结束Footer-->
    </div>
    <!--结束container-fluid-->
    <div class="carrousel"><span class="close entypo-cancel"></span></div>
    <script src="js/jQuery v1.11.2 .js"></script>
    <script src="js/smohan.share.min.js"></script>
    <script>
        $('.share').smohanShare({
            btns: ['sina', 'qzone', 'tq', 'renren', 'huaban', 'facebook', 'twitter'],
            common: {
                title: '',
                url: '',
                texts: '', //描述
                image: '' //图片

            },

        });
    </script>
    <script src="js/bsjquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/luntanJS.js"></script>
</body>
</html>
