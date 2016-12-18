<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LiZhiOSManagement.WEB.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="JQueryEasyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="JQueryEasyUI/themes/icon.css" rel="stylesheet" />
    <script src="JQueryEasyUI/jquery.min.js"></script>
    <script src="JQueryEasyUI/jquery.easyui.min.js"></script>
    <script src="JS/IndexJS.js"></script>
    <link href="CSS/IndexCSS.css" rel="stylesheet" />

    <style type="text/css">
        * {
            margin: 0;
            padding: 0;
        }
    </style>
</head>
<body class="easyui-layout">
     <%--onresize="bz()"--%>
    <div style="min-height: 80px; background-color: #E9F1FF; text-align: left; line-height: 80px;">
        <div class="logo" id="menu">
            <h1>LiZhiOS</h1>
        </div>
    </div>
 
    <div id="cc" class="easyui-layout" style="width: 100%;border:1px solid #E9F1FF;">
        <div id="leftmenu" data-options="region:'west',title:'West',split:true,collapsed:false" style="width: 150px;">
            <%--做导航栏伸缩面板--%>
            <div id="aa" class="easyui-accordion" data-options="fit:true" style="width:100%;">
                <div title="签到信息管理" data-options="selected:true">
                    <ul class="am">
                        <li class="li1"><a href="SignManagersTable.aspx" target="mainFrame"><div title="Android" data-options="" style="background-color:#C3E6C8;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #A9FACD;">签到信息查看</div></a></li>
                        <li class="li2"><a href="OutSignOfExcle.aspx" target="mainFrame"><div title=".Net" data-options="" style="background-color:#C3E6C8;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #A9FACD;">签到信息导出</div></a></li>
                        <li class="li3"><a href="SignCartogram.aspx" target="mainFrame"><div title="Front-end" data-options="" style="background-color:#C3E6C8;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #A9FACD;">签到信息统计</div></a></li>

                    </ul>
                </div>
                <div title="文章信息管理" data-options="selected:true">
                    <ul class="am">
                        <li class="li1"><a href="AndroidArticle.aspx" target="mainFrame"><div title="Android" data-options="" style="background-color:#C3E6C8;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #A9FACD;">Android</div></a></li>
                        <li class="li2"><a href="NetArticle.aspx" target="mainFrame"><div title=".Net" data-options="" style="background-color:#C3E6C8;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #A9FACD;">.Net</div></a></li>
                        <li class="li3"><a href="Front-end.aspx" target="mainFrame"><div title="Front-end" data-options="" style="background-color:#C3E6C8;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #A9FACD;">Front-end</div></a></li>
                        <li class="li4"><a href="MessagesTable.aspx?belongkind=All" target="mainFrame"><div title="All" data-options="" style="background-color:#C3E6C8;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #A9FACD;">All</div></a></li>
                    </ul>
                </div>
                <div title="用户信息管理">
                    <ul class="am" data-options="collapsed:true" style="overflow: auto;">
                        <li class="li5"><a href="AndroidUsersTable.aspx" target="mainFrame"><div title="Android" data-options="" style="background-color:#eee;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #A9FACD;">Android</div></a></li>
                        <li class="li6"><a href="NetUsersTable.aspx" target="mainFrame"><div title=".Net" data-options="" style="background-color:#eee;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #A9FACD;">.Net</div></a></li>
                        <li class="li7"><a href="Front-endUsersTable.aspx" target="mainFrame"><div title="Front-end" data-options="" style="background-color:#eee;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #A9FACD;">Front-end</div></a></li>
                        <li class="li8"><a href="AllUsersTable.aspx" target="mainFrame"><div title="All" data-options="" style="background-color:#eee;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #A9FACD;">All</div></a></li>
                    </ul>
                </div>
                <div title="管理员信息">
                    <ul class="am" data-options="collapsed:true" style="overflow: auto;">
                        <li class="li9"><a href="AndroidManagersTable.aspx" target="mainFrame"><div title="Android" data-options="" style="background-color:#eee;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #ffffff;">Android</div></a></li>
                        <li class="li10"><a href="NetManagersTable.aspx" target="mainFrame"><div title=".Net" data-options="" style="background-color:#eee;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #ffffff;">.Net</div></a></li>
                        <li class="li11"><a href="Front-endManagersTable.aspx" target="mainFrame"><div title="Front-end" data-options="" style="background-color:#eee;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #ffffff;">Front-end</div></a></li>
                        <li class="li13"><a href="AllManagersTable.aspx" target="mainFrame"><div title="All" data-options="" style="background-color:#eee;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #ffffff;">All</div></a></li>
                        <li class="li12"><a href="SuperManagersTable.aspx" target="mainFrame"><div title="Super" data-options="" style="background-color:#eee;overflow: auto;height:30px;line-height:30px;font-size:14px;border:1px solid #ffffff;">Super</div></a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div id="mainFrame" class="easyui-accordion" data-options="region:'center',title:'center title',split:true,doSize:true,iconCls:'icon-house'" style="background: #eee;height:100%;">
            <iframe name="mainFrame" src="MessagesTable.aspx" width="100%" height="100%" scrolling="yes" frameborder="0" marginwidth="0" marginheight="0"></iframe>
            
        </div>
        
       
    </div>
    <!-- 底部，版权信息-->
     <div data-options="region:'south',border:false" style="height: 50px; background-color: #A9FACD;text-align: center;line-height:50px;">
        LiZhiOS版权所有©1990-2015 design by LiZhiOfficeStudio
    </div>



 
</body>
</html>
