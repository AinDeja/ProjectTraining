<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminArticleType.aspx.cs" Inherits="InspirationalWeb.WebPL.Admin.AdminArticleType" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

     <link rel="stylesheet" type="text/css"  href="/WebPL/CSS/AdminCenter.css" />

</head>
    <script type="text/javascript">
        function turnto(toa) {
            window.location.href = toa;
        }//页面跳转
        function doDelF(id) {
            if (confirm("您确定要删除吗？")) {
                window.location = "AdminArticleType.aspx?del=1&id=" + id;
            }
        }
        function doDelS(id) {
            if (confirm("您确定要删除吗？")) {
                window.location = "AdminArticleType.aspx?del=2&id=" + id;
            }
        }
        function gel(id) { return document.getElementById(id); }
        window.onload = function () {
            gel("chkAll").onclick = function () {
                var chks = document.getElementsByName("chkId");
                for (var i = 0; i < chks.length; i++) {
                    chks[i].checked = this.checked;
                }
            };

            //批量删除按钮
            gel("btnDelBatch").onclick = function () {
                //检查 是否至少选中 一个 复选框
                var chks = document.getElementsByName("chkId");
                var isBatchDel = false;
                for (var i = 0; i < chks.length; i++) {
                    if (chks[i].checked) {
                        isBatchDel = true;
                        break;
                    }
                }
                //如果至少选中一个 复选框，则 提交表单
                if (isBatchDel) {
                    document.forms[0].submit();
                } else {
                    alert("请选择要删除的帖子");
                }
            };
        };
    </script>
<body>
    <div id="top"></div>
    <div id="Main">
        <div id="leftList">
            <ul>
                
                 <li> <h2><a href="AdminCenter.aspx?list=0&del=0">首 页</a></h2></li>
                <h2>文章管理</h2>
                <li><a href="AdminArticle.aspx?list=1&del=0">用户文章</a></li>
                <li><a href="AdminArticle.aspx?list=1&del=0">文章分类</a></li>
                <h2>相册管理</h2>
                <li><a href="AdminImges.aspx?list=2&del=0">相册管理</a></li>
                <h2>留言管理</h2>
                <li><a href="AdminMessages.aspx?list=3&del=0">留言管理</a></li>
            </ul>
        </div>
        <div id="rightMain">
           
        
            <form method="post" action="AdminArticleType.aspx" >

<dl id="father">
    <dt>父类</dt>
    <dd><input type="text" value="" name="newFather" class="btNew" /></dd>
    <dd><input type="submit" value="创建新父类" class="btNew" /></dd>
    <%=fatherTr %>

</dl>
    <dl id="son">
   <dt>子类</dt>
        <dd><input type="text" value="" name="newSon" class="btNew" /></dd>
        <dd><input type="submit" value="创建新子类" class="btNew" /></dd>
   <%=sonTr %>
    </dl>
    
    </form>
      
        </div>
    </div>
</body>
</html>
