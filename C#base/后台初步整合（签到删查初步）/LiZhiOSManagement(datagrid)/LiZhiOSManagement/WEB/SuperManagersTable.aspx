<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuperManagersTable.aspx.cs" Inherits="LiZhiOSManagement.WEB.SuperManagersTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="JQueryEasyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="JQueryEasyUI/themes/icon.css" rel="stylesheet" />
    <script src="JQueryEasyUI/jquery.min.js"></script>
    <script src="JQueryEasyUI/jquery.easyui.min.js"></script>
    
    <link href="CSS/IndexCSS.css" rel="stylesheet" />
    <style type="text/css">
        * {
            margin: 0;
            padding: 0;
        }
    </style>
    <script>
        $(function () {
            InitList();
        });

        function InitList() {
            $("#ss").datagrid({
                url: 'Ajax/ShowSuperManagers.ashx',
                title: '数据列表',
                //width: 1190,
                //height: 460,
                fitColumns: true,
                idField: 'ID',
                loadMsg: '正在加载成员的信息...',
                pagination: true,  //是否显示分页信息栏
                singleSelect: false,  //是否单选
                pageSize: 10,
                pageNumber: 1,
                striped: true,  //交替显示背景
                pageList: [10, 20, 30],
                queryParams: {},
                columns: [[
                        { field: 'ck', checkbox: true, align: 'left', width: 50 },
                        { field: 'ID', title: '主键', width: 80 },
                        //{ field: 'CreateTime', title: '创建时间', width: 80, },
                        {
                            field: 'CreateTime', title: '创建时间', width: 80, formatter: function (value, row, index) {
                                if (value) {
                                    var date = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));

                                    return date;
                                }
                            }
                        },
                        { field: 'UserName', title: '姓名', width: 80 },
                        { field: 'UserPassWord', title: '密码', width: 80 },
                        {
                            field: 'UserSex', title: '性别', width: 80
                        },
                        { field: 'UserQQ', title: 'QQ', width: 80 },
                        { field: 'UserPhone', title: '手机号', width: 80 },
                        { field: 'UserStuID', title: '学号', width: 80 },
                        { field: 'UserFname', title: '昵称', width: 80 },
                        { field: 'UserIP', title: 'IP', width: 80 },

                ]],
                onClickCell: function (rowIndex, field, value) {

                    if (field == "Content") {
                        if ($('#showcontent').length > 0) {
                            sl();

                        }
                        var row = $('#tt').datagrid('getData').rows[rowIndex];  //及其重要，获取载入数据
                        var id = row.ID;
                        s(id);

                    }
                    else {
                        if ($('#showcontent').length > 0) {
                            sl();
                        }

                    }


                },
                toolbar: [{
                    id: 'toolbarAdd',
                    text: '添加',
                    iconCls: 'icon-add',
                    handler: function () {
                        $.messager.alert("添加", "添加正文");
                    }
                }, '-', {
                    id: 'toolbardel',
                    text: '删除',
                    iconCls: 'icon-cancel',
                    handler: function () { alert('delete') }
                }, '-', {
                    id: 'toolbaredit',
                    text: '编辑',
                    iconCls: 'icon-edit',
                    handler: function () { alert('edit') }
                }, '-', {
                    id: 'toolbarsave',
                    text: '保存',
                    iconCls: 'icon-save',
                    handler: function () { alert('save') }
                }]
            });
        }
    </script>
</head>
<body style="margin:0;padding:0;">
    <table class="easyui-datagrid" id="ss">
            <thead>
                <tr style="background-color: #D0F79C;">
                    <th>ID</th>
                    <th>创建时间</th>
                    <th>姓名</th>
                    <th>密码</th>
                    <th>性别</th>
                    <th>QQ</th>
                    <th>手机号</th>
                    <th>学号</th>
                    <th>昵称</th>
                    <th>IP</th>
                </tr>
            </thead>
        </table>
</body>
</html>
