<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessagesTable.aspx.cs" Inherits="LiZhiOSManagement.WEB.MessagesTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="JQueryEasyUI/datagrid-detailview.js/datagrid-detailview.js"></script>
    <%--subgrid--%>


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
<body>
        <table id="tt">
            <thead>
                <tr style="background-color: #D0F79C;">
                    <th>ID</th>
                    <th>是否删除</th>
                    <th>创建时间</th>
                    <th>组别</th>
                    <th>类别</th>
                    <th>标题</th>
                    <th>内容</th>
                    <th>作者</th>
                    <th>评论</th>
                </tr>
            </thead>
        </table>

  
    <div id="ss" class="easyui-dialog" title="Add Dialog" style="width:100%;min-height:300px;text-align:center;"   
        data-options="iconCls:'icon-add',resizable:true,modal:false,closed:true">  
    <table style="margin-left:auto;margin-right:auto;vertical-align:middle;margin-top:20px;">
        <tr><td colspan="2">添加内容</td></tr>
        <tr><td>主键 </td><td><input type="text" value="***" disabled="true" class="id"/></td><td></td></tr>
        <tr><td>是否删除</td><td><input type="text" value="false" disabled="true" class="isdelete"/></td><td></td></tr>
        <tr><td>创建时间</td><td><input id="dt" type="text" name="birthday"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <%--<tr><td>组别</td><td><input type="text" class="belongkind" /></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>--%>
        <tr><td>组别</td><td><select id="belongkind"><optgroup label=".Net" style="width:126px;"><option>请选择组别/类别</option><option value="winform">winfrom</option><option value="asp">asp</option></optgroup><optgroup label="Android"><option value="java">java</option><option value="javaee">javaee</option></optgroup><optgroup label="Front-end"><option value="html5">html5</option><option value="CSS">CSS</option></optgroup></select></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <tr><td>标题</td><td><input type="text" class="title"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <tr><td>作者</td><td><input type="text" class="belonguser"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <%--<tr><td>类别</td><td><input type="text" class="belongkind_type"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>--%>
        <tr><td>访问量</td><td><input type="text" class="mostbrowse" value="0"/></td><td></td></tr>
        <tr><td>内容</td><td><input type="text" class="content"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <tr><td></td><td></td><td></td></tr>
        <tr><td><a id="abtnadd" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'">save</a></td>
            <td><a id="abtncan" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'">close</a></td></tr>
    </table>
</div>                <%--添加--%>


    <div id="dd" class="easyui-dialog" title="Del Dialog" style="width:400px;height:200px;"   
        data-options="iconCls:'icon-cancel',resizable:true,modal:false,closed:true">  
        <p class="tixing" style="line-height:100px;text-align:center;">请勾选要删除的数据2</p>
        <a id="dabtnadd" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'" style="margin-left:90px;">delete</a>
        <a id="dabtncan" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'" style="margin-left:90px;">cancel</a>
        
</div>                <%--删除--%>




    <div id="ee" class="easyui-dialog" title="Edit Dialog" style="width:400px;min-height:300px;text-align:center;"   
        data-options="iconCls:'icon-edit',resizable:true,modal:false,closed:true">
    <table style="margin-left:auto;margin-right:auto;vertical-align:middle;margin-top:20px;">
        <tr><td colspan="2">编辑内容</td></tr>
        <tr><td>主键</td><td><input type="text" disabled="true" class="cid"/></td></tr>
        <tr><td>是否删除</td><td><input type="text" class="isdel"/></td></tr>
        <tr><td>创建时间</td><td><input type="text" class="ctime"/></td></tr>
        <tr><td>组别</td><td><input type="text" class="cgroup"/></td></tr>
        <tr><td>标题</td><td><input type="text" class="ctitle"/></td></tr>
        <tr><td>作者</td><td><input type="text" class="cauthor"/></td></tr>
        <tr><td>类别</td><td><input type="text" class="ctype"/></td></tr>
        <tr><td>访问量</td><td><input type="text" class="cbrowse" disabled="true"/></td></tr>
        <tr><td>内容</td><td><textarea class="txtarea"></textarea></td></tr>
        <tr><td><a id="ebtnadd" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'">save</a></td>
            <td><a id="ebtncan" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'">cancle</a> </td></tr>
    </table>
</div>                <%--编辑--%>



    
</body>
</html>
