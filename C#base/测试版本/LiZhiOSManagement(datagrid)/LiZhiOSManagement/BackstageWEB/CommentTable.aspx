<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentTable.aspx.cs" Inherits="LiZhiOSManagement.WEB.CommentTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="JQueryEasyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="JQueryEasyUI/themes/icon.css" rel="stylesheet" />
    <script src="JQueryEasyUI/jquery.min.js"></script>
    <script src="JQueryEasyUI/jquery.easyui.min.js"></script>

    <link href="CSS/IndexCSS.css" rel="stylesheet" />

    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/luntan.css" rel="stylesheet" />
    <link href="CSS/smohan.share.css" rel="stylesheet" />
    <style type="text/css">
        * {
            margin: 0;
            padding: 0;
        }
    </style>
    <script type="text/javascript">

            function turns(e) {
                var s = confirm("删除帖子及评论？");
                if (s)
                {
                    $.get("Ajax/DeleteArticleAndComments.ashx?articleid=" + e.id, function (data) {
                        if (data > 0) {
                            alert("文章及评论已被删除，该页面为空");
                        } else {
                            alert("权限不足，删除失败");
                        }
                    });
                }
            };
            function delcomments(e) {
                if (confirm("要删除评论了啊"))
                {
                    $.post('Ajax/DeleteByComments.ashx', { id: e.id }, function (data) {
                        if (data == 1) {
                            alert("ok了，哈哈");
                        } else
                            alert("权限不足，删除失败");
                        var c = confirm("是否刷新页面？？？");
                        if (c) {
                            window.location.href = "CommentTable.aspx";
                        }
                    });
                }
                
            };
            function delallcomments(e) {
                var s = confirm("真的要删除所有评论？？？");
                if (s) {
                    $.post('Ajax/DeleteByAllComments.ashx', { id: e.id }, function (data) {
                        if (data == 1) {
                            alert("删除操作成功");
                            if (confirm("是否刷新页面？？")) {
                                window.location.href = "CommentTable.aspx";
                            }
                        } else {
                            alert("权限不足，删除失败");
                        }
                    });
                }
            }
    </script>
</head>
<body>
    <%--<%=listlouzhu.ToArray()[0].Content %> --%>   <%--文章内容--%>
    <%--<ul id="tts" class="easyui-tree" data-options="url:'ShowComments.ashx?id=1041'"></ul> --%>
    <div class="container">
        <div class="row" style="text-align: center;">
            <div class="col-md-12" style="text-align: center;">

                <article class="post" id="1">
                    <header class="post-head">
                        <%
                            LiZhiOSManagement.BLL.ShowUsersMessagesBLL smbll = new LiZhiOSManagement.BLL.ShowUsersMessagesBLL();
                        %>

                        <h1 class="post-title"><%=listlouzhu.ToArray()[0].Title %> </h1>
                        <%--<a href="javascript:void(0)"><span class="comment-delete pull-right glyphicon glyphicon-remove"></span></a><a href="javascript:void(0)"><span class="comment-delete pull-right glyphicon glyphicon-remove"></span></a>--%>
                        <button type="button" class="close" id="articleid<%=listlouzhu.ToArray()[0].ID %>" onclick="turns(this);"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>

                        <section class="post-meta">
                            <span class="author"><%=smbll.showUserName(listlouzhu.ToArray()[0].BelongUser) %></span> •
            <time title="2016年4月6日星期三凌晨3点19分" datetime="2016年4月6日星期三凌晨3点19分" class="post-date"><%=listlouzhu.ToArray()[0].CreateTime %></time>
                        </section>
                        <section class="postContent"><%=listlouzhu.ToArray()[0].Content %></section>


                    </header>
                </article>
                <div id="comments" class="comment-list clearfix">
                    <div class="comment-head">
                        <span class="wzpl">文章评论<button type="button" class="close" id="id<%=Convert.ToInt32(Session["id"]) %>" onclick="delallcomments(this)"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></span><br>
                        <%=listMessages.Count %>条评论
          

                    </div>
                    <!--结束comment-head-->


                    <% 
                        
                        int j = 0;
                        for (int i = 1; i <= listMessages.Count; i++,j++)
                       { %>
                    <div id="comment-list">

                        <div class="note-comment clearfix" id="comment-1">
                            <!--此id为第评论+回复数（总）-->
                            <span class="comment-name"><%=listMessages.ToArray()[j].CommentUser %> <button type="button" class="close" id="id<%=listMessages.ToArray()[j].ID %>" onclick="delcomments(this)"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></span><br>
                            <span class="comment-floor"><%=i %>楼</span> · <time class="comment-time"><%=listMessages.ToArray()[0].CreateTime %></time>
                            <p class="comment-content"><%=listMessages.ToArray()[j].MessBelong %></p>
                            


                            <%=getMostMessages(Convert.ToInt32(Session["id"]),listMessages.ToArray()[j].ID) %>
                            
                            <%--在这里写--%>
                           <%-- <div class="child-comment" id="comment-2" style="text-align: left;">

                                <div class="child-comment-footer text-center clearfix">
                                    <p>
                                        <a class="blue-link" href="javascript:void(0)">汪宇</a>：
                                        <a class="maleskine-author">@某某某</a> 我是评论的回复
                                    </p>

                                </div>
                                <!--结束child-comment-footer-->
                            </div>--%>
                            <!--结束child-comment-->




                            <hr />
                            <%--</div>--%><!--结束child-comment-list-->
                        </div>
                        <!--结束note-comment-->
                    </div>
                    <!--结束comment-list-->
                    <%  } %>
                </div>
                <!--结束comments-->
            </div>
            <!--结束8col-->

        </div>
    </div>


</body>
</html>
