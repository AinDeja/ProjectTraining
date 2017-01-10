<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Front-endManagersTable.aspx.cs" Inherits="LiZhiOSManagement.WEB.Front_endManagersTable" %>

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
            $("#tt").datagrid({
                url: 'Ajax/TableByManagersDatagrid.ashx?belongkind=Front-end&bysel=ID&byserch=*',
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
                fit: true,          //设置分页栏的位置固定在……
                striped: true,  //交替显示背景
                pageList: [10, 20, 30],
                queryParams: {},
                columns: [[
                        { field: 'ck', checkbox: true, align: 'left', width: 50 },
                        { field: 'ID', title: '主键', width: 80 },
                        { field: 'IsDelete', title: '是否删除', width: 80, },
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
                        { field: 'belong', title: '组别', width: 80 },

                ]],
                onCheck: function (rowIndex, rowData) {       //选中n行
                    var selrow = $('#tt').datagrid('getChecked');
                    if (selrow != null) {
                        $('.cid').val(selrow[0].ID);
                        $('.isdel').val(selrow[0].IsDelete);
                        $.get('Ajax/SelectTimeForManagersEdit.ashx?id=' + selrow[0].ID, function (data) {
                            $('.ctime').val(data);
                        });
                        $('.cname').val(selrow[0].UserName);
                        $('.cpwd').val(selrow[0].UserPassWord);
                        $('.csex').val(selrow[0].UserSex);
                        $('.cqq').val(selrow[0].UserQQ);
                        $('.cphone').val(selrow[0].UserPhone);
                        $('.cstuid').val(selrow[0].UserStuID);
                        $('.cfname').val(selrow[0].UserFname);
                        $('.cip').val(selrow[0].UserIP);
                        $('.cgroup').val(selrow[0].belong);
                        $('#ebtnadd').bind('click', function () {
                            //alert("进入");
                            $.post('Ajax/SaveEditManagers.ashx', { id: $('.cid').val(), isdelete: $('.isdel').val(), createtime: $('.ctime').val(), username: $('.cname').val(), userpassword: $('.cpwd').val(), usersex: $('.csex').val(), userqq: $('.cqq').val(), userphone: $('.cphone').val(), userstuid: $('.cstuid').val(), userfname: $('.cfname').val(), userip: $('.cip').val(), belong: $(".cgroup").val() }, function (data) {
                                if (data > 0) {
                                    alert("编辑成功!");
                                    window.location.reload();
                                } else {
                                    alert("权限不足,编辑失败！");
                                }
                            });  //发送数据到后台，进而添加到数据库
                        });
                        $('#ebtncan').bind('click', function () {
                            $('#ee').dialog('close');
                        });
                    } else {
                        $('.cid').val("");
                        $('.isdel').val(rowData[""]);
                        $('.ctime').val(rowData[""]);
                        $('.cname').val(rowData[""]);
                        $('.cpwd').val(rowData[""]);
                        $('.csex').val(rowData[""]);
                        $('.cqq').val(rowData[""]);
                        $('.ctype').val(rowData[""]);
                        $('.cphone').val(rowData[""]);
                        $('.cstuid').val(rowData[""]);
                        $('.cfname').val(rowData[""]);
                        $('.cip').val(rowData[""]);
                        $('.cgroup').val(rowData[""]);

                        $('#ebtnadd').bind('click', function () {
                            $('#ee').dialog('close');
                        });
                        $('#ebtncan').bind('click', function () {
                            $('#ee').dialog('close');
                        });
                    }
                    if ($('#tt').datagrid('getChecked').length <= 0) {
                        $('#dd .tixing').text("请勾选要删除的数据");
                        $('#dabtnadd').bind('click', function () {
                            $('#dd').dialog('close');
                        });
                        $('#dabtncan').bind('click', function () {
                            $('#dd').dialog('close');
                        });
                    }
                    else {
                        //alert($('.cid').val());
                        $('#dd .tixing').text("您选择了" + $('#tt').datagrid('getChecked').length + "条数据，是否要删除？");
                        $('#dabtnadd').bind('click', function () {
                            if ($('#tt').datagrid('getChecked').length > 0) {
                                var sz = null;

                                var rows = $('#tt').datagrid('getSelections');
                                for (var n = 0; n < rows.length; n++) {
                                    sz += rows[n].ID + ",";
                                }
                                $.get('Ajax/DeleteManager.ashx', { shuzu: sz }, function (data) {

                                    if (data == 110) {
                                        alert("删除成功");
                                        window.parent.location.href = "BackendLogin.aspx";
                                    }
                                    else if (data == 1) {
                                        alert("删除成功");
                                        window.location.reload();
                                    } else if (data == 0) {
                                        alert("权限不足，部分删除成功");
                                        window.location.reload();
                                    } else {
                                        alert("权限不足，删除失败");
                                    }
                                });
                            }
                            else {
                                $('#dd .tixing').text("请勾选要删除的数据");
                            }

                            event.stopPropagation();     //阻止事件冒泡
                        });
                        $('#dabtncan').bind('click', function () {
                            $('#dd').dialog('close');
                        });

                    }
                },
                onUncheck: function (rowIndex, rowData) {
                    //$('#tt').datagrid('getChecked')(0).attr('class','datagrid-row');
                    var selrow = $('#tt').datagrid('getSelections');

                    //编辑
                    if ($('#tt').datagrid('getChecked').length > 0) {

                        $('.cid').val($('#tt').datagrid('getChecked')[0].ID);
                        $('.isdel').val($('#tt').datagrid('getChecked')[0].IsDelete);

                        $.get('Ajax/SelectTimeForManagersEdit.ashx?id=' + $('#tt').datagrid('getChecked')[0].ID, function (data) {
                            $('.ctime').val(data);
                        });
                        //$('.ctime').val($('#tt').datagrid('getChecked')[0].CreateTime);
                        $('.cname').val($('#tt').datagrid('getChecked')[0].UserName);
                        $('.cpwd').val($('#tt').datagrid('getChecked')[0].UserPassWord);
                        $('.csex').val($('#tt').datagrid('getChecked')[0].UserSex);
                        $('.cqq').val($('#tt').datagrid('getChecked')[0].UserQQ);
                        $('.cphone').val($('#tt').datagrid('getChecked')[0].UserPhone);
                        $('.cstuid').val($('#tt').datagrid('getChecked')[0].UserStuID);
                        $('.cfname').val($('#tt').datagrid('getChecked')[0].UserFname);
                        $('.cip').val($('#tt').datagrid('getChecked')[0].UserIP);
                        $('.cgroup').val($('#tt').datagrid('getChecked')[0].belong);
                        $('#ebtnadd').bind('click', function () {
                            $.post('Ajax/SaveEditManagers.ashx', { id: $('.cid').val(), isdelete: $('.isdel').val(), createtime: $('.ctime').val(), username: $('.cname').val(), userpassword: $('.cpwd').val(), usersex: $('.csex').val(), userqq: $('.cqq').val(), userphone: $('.cphone').val(), userstuid: $('.cstuid').val(), userfname: $('.cfname').val(), userip: $('.cip').val(), belong: $(".cgroup").val() }, function (data) {
                                if (data > 0) {
                                    alert("编辑成功!");
                                    window.location.reload();
                                } else {
                                    alert("权限不足，编辑失败！");
                                }
                            });  //发送数据到后台，进而添加到数据库
                        });
                        $('#ebtncan').bind('click', function () {
                            $('#ee').dialog('close');
                        });

                    } else {
                        $('.cid').val("");
                        $('.isdel').val(rowData[""]);
                        $('.ctime').val(rowData[""]);
                        $('.cname').val(rowData[""]);
                        $('.cpwd').val(rowData[""]);
                        $('.csex').val(rowData[""]);
                        $('.cqq').val(rowData[""]);
                        $('.ctype').val(rowData[""]);
                        $('.cphone').val(rowData[""]);
                        $('.cstuid').val(rowData[""]);
                        $('.cfname').val(rowData[""]);
                        $('.cip').val(rowData[""]);
                        $('.cgroup').val(rowData[""]);
                        $('#ebtnadd').bind('click', function () {
                            $('#ee').dialog('close');
                        });
                        $('#ebtncan').bind('click', function () {
                            $('#ee').dialog('close');
                        });
                    }

                    //删除
                    if ($('#tt').datagrid('getChecked').length <= 0) {
                        $('#dd .tixing').text("请勾选要删除的数据");
                        $('#dabtnadd').bind('click', function () {
                            $('#dd').dialog('close');
                        });
                        $('#dabtncan').bind('click', function () {
                            $('#dd').dialog('close');
                        });
                    }
                    else {
                        //alert($('.cid').val());
                        $('#dd .tixing').text("您选择了" + $('#tt').datagrid('getChecked').length + "条数据，是否要删除？");
                        $('#dabtnadd').bind('click', function () {
                            if ($('#tt').datagrid('getChecked').length > 0) {
                                var sz = null;

                                var rows = $('#tt').datagrid('getSelections');
                                for (var n = 0; n < rows.length; n++) {
                                    sz += rows[n].ID + ",";
                                }
                                $.get('Ajax/DeleteManager.ashx', { shuzu: sz }, function (data) {

                                    if (data == 110) {
                                        alert("删除成功");
                                        window.parent.location.href = "BackendLogin.aspx";
                                    }
                                    else if (data == 1) {
                                        alert("删除成功");
                                        window.location.reload();
                                    } else if (data == 0) {
                                        alert("权限不足，部分删除成功");
                                        window.location.reload();
                                    } else {
                                        alert("权限不足，删除失败");
                                    }
                                });
                            }
                            else {
                                $('#dd .tixing').text("请勾选要删除的数据5");
                            }

                            event.stopPropagation();     //阻止事件冒泡
                        });
                        $('#dabtncan').bind('click', function () {
                            $('#dd').dialog('close');
                        });

                    }
                },
                onCheckAll: function (rows) {               //全选
                    var selrow = $('#tt').datagrid('getChecked');
                    if (selrow != null) {
                        $('.cid').val(selrow[0].ID);
                        $('.isdel').val(selrow[0].IsDelete);
                        $('.ctime').val(selrow[0].CreateTime);
                        $('.cname').val(selrow[0].UserName);
                        $('.cpwd').val(selrow[0].UserPassWord);
                        $('.csex').val(selrow[0].UserSex);
                        $('.cqq').val(selrow[0].UserQQ);
                        $('.cphone').val(selrow[0].UserPhone);
                        $('.cstuid').val(selrow[0].UserStuID);
                        $('.cfname').val(selrow[0].UserFname);
                        $('.cip').val(selrow[0].UserIP);
                        $('.cgroup').val(selrow[0].belong);

                    } else {
                        $('.cid').val("");
                        $('.isdel').val(rowData[""]);
                        $('.ctime').val(rowData[""]);
                        $('.cname').val(rowData[""]);
                        $('.cpwd').val(rowData[""]);
                        $('.csex').val(rowData[""]);
                        $('.cqq').val(rowData[""]);
                        $('.ctype').val(rowData[""]);
                        $('.cphone').val(rowData[""]);
                        $('.cstuid').val(rowData[""]);
                        $('.cfname').val(rowData[""]);
                        $('.cip').val(rowData[""]);
                        $('.cgroup').val(rowData[""]);
                    }
                    if ($('#tt').datagrid('getChecked').length <= 0) {
                        alert($('#tt').datagrid('getChecked').length);
                        $('#dd .tixing').text("请勾选要删除的数据1");
                        $('#dabtnadd').bind('click', function () {
                            $('#dd').dialog('close');
                        });
                        $('#dabtncan').bind('click', function () {
                            $('#dd').dialog('close');
                        });
                    }
                    else {
                        //alert($('.cid').val());
                        $('#dd .tixing').text("您选择了" + $('#tt').datagrid('getChecked').length + "条数据，是否要删除？");
                        $('#dabtnadd').bind('click', function () {
                            if ($('#tt').datagrid('getChecked').length > 0) {
                                var sz = null;

                                var rows = $('#tt').datagrid('getSelections');
                                for (var n = 0; n < rows.length; n++) {
                                    sz += rows[n].ID + ",";
                                }
                                $.get('Ajax/DeleteManager.ashx', { shuzu: sz }, function (data) {

                                    if (data == 110) {
                                        alert("删除成功");
                                        window.parent.location.href = "BackendLogin.aspx";
                                    }
                                    else if (data == 1) {
                                        alert("删除成功");
                                        window.location.reload();
                                    } else if (data == 0) {
                                        alert("权限不足，部分删除成功");
                                        window.location.reload();
                                    } else {
                                        alert("权限不足，删除失败");
                                    }
                                });
                            }
                            else {
                                $('#dd .tixing').text("请勾选要删除的数据5");
                            }

                            event.stopPropagation();     //阻止事件冒泡
                        });
                        $('#dabtncan').bind('click', function () {
                            $('#dd').dialog('close');
                        });

                    }
                },
                onUncheckAll: function (rows) {     //全不选
                    var selrow = $('#tt').datagrid('getChecked');
                    if (selrow != null) {
                        $('.cid').val(selrow[0].ID);
                        $('.isdel').val(selrow[0].IsDelete);
                        $('.ctime').val(selrow[0].CreateTime);
                        $('.cname').val(selrow[0].UserName);
                        $('.cpwd').val(selrow[0].UserPassWord);
                        $('.csex').val(selrow[0].UserSex);
                        $('.cqq').val(selrow[0].UserQQ);
                        $('.cphone').val(selrow[0].UserPhone);
                        $('.cstuid').val(selrow[0].UserStuID);
                        $('.cfname').val(selrow[0].UserFname);
                        $('.cip').val(selrow[0].UserIP);
                        $('.cgroup').val(selrow[0].belong)

                    } else {
                        $('.cid').val("");
                        $('.isdel').val(rowData[""]);
                        $('.ctime').val(rowData[""]);
                        $('.cname').val(rowData[""]);
                        $('.cpwd').val(rowData[""]);
                        $('.csex').val(rowData[""]);
                        $('.cqq').val(rowData[""]);
                        $('.ctype').val(rowData[""]);
                        $('.cphone').val(rowData[""]);
                        $('.cstuid').val(rowData[""]);
                        $('.cfname').val(rowData[""]);
                        $('.cip').val(rowData[""]);
                        $('.cgroup').val(rowData[""]);
                    }
                    if ($('#tt').datagrid('getChecked').length <= 0) {
                        $('#dd .tixing').text("请勾选要删除的数据");
                        $('#dabtnadd').bind('click', function () {
                            $('#dd').dialog('close');
                        });
                        $('#dabtncan').bind('click', function () {
                            $('#dd').dialog('close');
                        });
                    }
                    else {
                        //alert($('.cid').val());
                        $('#dd .tixing').text("您选择了" + $('#tt').datagrid('getChecked').length + "条数据，是否要删除？");
                        $('#dabtnadd').bind('click', function () {
                            if ($('#tt').datagrid('getChecked').length > 0) {
                                var sz = null;

                                var rows = $('#tt').datagrid('getSelections');
                                for (var n = 0; n < rows.length; n++) {
                                    sz += rows[n].ID + ",";
                                }
                                $.get('Ajax/DeleteManager.ashx', { shuzu: sz }, function (data) {

                                    if (data == 110) {
                                        alert("删除成功");
                                        window.parent.location.href = "BackendLogin.aspx";
                                    }
                                    else if (data == 1) {
                                        alert("删除成功");
                                        window.location.reload();
                                    } else if (data == 0) {
                                        alert("权限不足，部分删除成功");
                                        window.location.reload();
                                    } else {
                                        alert("权限不足，删除失败");
                                    }
                                });
                            }
                            else {
                                $('#dd .tixing').text("请勾选要删除的数据5");
                            }

                            event.stopPropagation();     //阻止事件冒泡
                        });
                        $('#dabtncan').bind('click', function () {
                            $('#dd').dialog('close');
                        });

                    }
                },
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
                        $('#ss').dialog('open').dialog({
                            title: 'My Dialog',
                            width: 400,
                            minheight: 300,
                            closed: false,
                            cache: false,
                            //href: 'get_content.php',
                            modal: true
                        });
                    }
                }, '-', {
                    id: 'toolbardel',
                    text: '删除',
                    iconCls: 'icon-cancel',
                    handler: function () {
                        $('#dd').dialog('open').dialog({
                            title: 'My Dialog',
                            width: 400,
                            height: 200,
                            closed: false,
                            cache: false,
                            //href: 'get_content.php',
                            modal: true
                        });
                    }
                }, '-', {
                    id: 'toolbaredit',
                    text: '编辑',
                    iconCls: 'icon-edit',
                    handler: function () {
                        $('#ee').dialog('open').dialog({
                            title: 'My Dialog',
                            closed: false,
                            cache: false,
                            //href: 'get_content.php',
                            modal: true
                        });
                    }
                }, '-', {
                    text: '<select id="searchsel" class="easyui-combobox" name="dept" style="width:100px;"><option value="ID">主键</option><option value="IsDelete">是否删除</option><option value="CreateTime">创建时间</option><option value="UserName">姓名</option><option value="UserPassWord">密码</option><option value="UserSex">性别</option><option value="UserQQ">QQ</option><option value="UserPhone">手机号</option><option value="UserStuID">学号</option><option value="UserFname">昵称</option><option value="UserIP">IP</option><option value="belong">组别</option></select>&nbsp;<input type="text" id="searchin" style="padding-right:20px;"/>',
                    handler: function () {
                        this.removeAttribute("href");            //生成所在的a标签有个href="javascript:void(0)",不能进行选择，移除掉后可以
                    }

                }, {
                    id: 'toolbarsearch',
                    text: '搜索',
                    iconCls: 'icon-search',
                    handler: function () {
                        //alert($('#searchsel').val());
                        if ($('#searchin').val().length > 0) {
                            alert($('#searchsel').val());
                            alert($('#searchin').val());
                            $("#tt").datagrid({ url: "Ajax/TableByManagersDatagrid.ashx?belongkind=All&bysel=" + $('#searchsel').val() + "&byserch=" + $('#searchin').val() });
                            $("#tt").datagrid('reload');
                        }
                        else {
                            alert("搜索框不能为空");
                        }

                    }
                }, '-', {
                    id: 'toolbaredit',
                    text: 'ExcelOutPut',
                    iconCls: 'icon-excel',
                    handler: function () {
                        var list = [];
                        if ($('#tt').datagrid('getChecked').length > 0) {
                            for (var i = 0; i < $('#tt').datagrid('getChecked').length; i++) {
                                list[i] = $('#tt').datagrid('getChecked')[i].ID;
                                //alert(list[i]);
                            }
                            window.location.href = "Ajax/ManagersExcelOutPut.ashx?id=" + list;
                        }
                        else {
                            //window.location.href = "ArticleExcelOutPut.ashx?id=" + list;
                            alert("请选择要导出的数据");
                        }
                    }
                }]
            });
        }

        //添加的弹窗
        $(function () {

            //添加弹窗的时间选择器
            $('#dt').datetimebox({
                value: new Date().toLocaleTimeString(),
                required: true,
                showSeconds: true
            });
            //添加（确定） 
            $('#abtnadd').bind('click', function () {
                //$.post("AddMessages.ashx", {});
                var v = $('#dt').datetimebox('getValue');
                //alert(v);
                var y = v.split('/')[2].split(' ')[0];   //年
                var m = v.split('/')[0];                 //月
                var d = v.split('/')[1];                 //日
                var s = v.split('/')[2].split(y)[1];     //秒
                var zong = y + "-" + m + "-" + d + s;    //最后时间  例如：   11/6/2016 15:46:25
                if (zong.length != 0 && ($("select").find("option:selected").val().length != 0) && ($('.name').val().length != 0) && ($('.pwd').val().length != 0) && ($('.sex').val().length != 0) && ($('.qq').val().length != 0) && ($('.phone').val().length != 0) && ($('.stuid').val().length != 0) && ($('.fname').val().length != 0) && ($('.ip').val().length != 0) && ($('.isdelete').val().length != 0)) {
                    $.post('Ajax/AddManagers.ashx', { isdelete: $('.isdelete').val(), createtime: zong, name: $('.name').val(), pwd: $('.pwd').val(), sex: $('.sex').val(), qq: $('.qq').val(), phone: $('.phone').val(), stuid: $('.stuid').val(), fname: $('.fname').val(), ip: $('.ip').val(), group: $(".group").val() }, function (data) {
                        if (data > 0) {
                            alert("添加成功!");
                            window.location.reload();

                        } else {
                            alert("权限不足,添加失败！");
                        }
                    });  //发送数据到后台，进而添加到数据库
                } else {
                    alert("添加失败，请把信息填完整");
                }


            });
            //添加（取消）

            $('#abtncan').bind('click', function () {
                $('#ss').dialog('close');
            });
        });

        //加载后删除、编辑按钮
        $(document).ready(function () {

            var delrow = $('#tt').datagrid('getSelections');  //点击删除按钮，显示删除的条数，并提醒

            $('#dd .tixing').text("请勾选要删除的数据");

            $('#dabtnadd').bind('click', function () {
                $('#dd').dialog('close');
            });
            $('#dabtncan').bind('click', function () {
                $('#dd').dialog('close');
            });

            $('#ebtnadd').bind('click', function () {    //点击编辑按钮
                $('#ee').dialog('close');
            });
            $('#ebtncan').bind('click', function () {
                $('#ee').dialog('close');
            });
        });
    </script>
</head>
<body class="easyui-layout">
    <table id="tt">
            <thead>
                <tr style="background-color: #D0F79C;">
                    <th>ID</th>
                    <th>是否删除</th>
                    <th>创建时间</th>
                    <th>姓名</th>
                    <th>密码</th>
                    <th>性别</th>
                    <th>QQ</th>
                    <th>手机号</th>
                    <th>学号</th>
                    <th>昵称</th>
                    <th>IP</th>
                    <th>组别</th>
                </tr>
            </thead>
        </table>

    <div id="ss" class="easyui-dialog" title="Add Dialog" style="width:400px;min-height:300px;text-align:center;"   
        data-options="iconCls:'icon-add',resizable:true,modal:false,closed:true">  
    <table style="margin-left:auto;margin-right:auto;vertical-align:middle;margin-top:20px;">
        <tr><td colspan="2">添加内容</td></tr>
        <tr><td>主键 </td><td><input type="text" value="***" disabled="true" class="id"/></td><td></td></tr>
        <tr><td>是否删除</td><td><input type="text" value="false" class="isdelete"/></td><td></td></tr>
        <tr><td>创建时间</td><td><input id="dt" type="text" name="birthday"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <tr><td>姓名</td><td><input type="text" class="name"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <tr><td>密码</td><td><input type="text" class="pwd"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <tr><td>性别</td><td><input type="text" class="sex"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <tr><td>QQ</td><td><input type="text" class="qq"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <tr><td>手机号</td><td><input type="text" class="phone"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <tr><td>学号</td><td><input type="text" class="stuid"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <tr><td>昵称</td><td><input type="text" class="fname"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <tr><td>IP</td><td><input type="text" class="ip"/></td><td><span style="color:red;">&nbsp;&nbsp;*</span></td></tr>
        <tr><td>组别</td><td>
            
            <%
                string quan = HttpContext.Current.Session["quan"].ToString() == null ? null : HttpContext.Current.Session["quan"].ToString();              //登陆人的权限
                if(quan=="sm")
                {
                    %>
            <select class="group" style="width:143px;"><option>.Net</option><option>Front-end</option><option>Android</option></select></td><td><span style="color:red;">&nbsp;&nbsp;*</span>
            <%
                }
                else
                {
                    List<LiZhiOSManagement.Model.Managers> listm = new List<LiZhiOSManagement.Model.Managers>();   //管理员
                    LiZhiOSManagement.BLL.ShowManagersMessagesBLL smm = new LiZhiOSManagement.BLL.ShowManagersMessagesBLL();
                    listm = smm.selectM();            //所有管理员
                    %>
                <select class="group" style="width:143px;"><option selected="selected"><%=listm.Where(r=>r.UserName==Convert.ToString(Session["name"])).ToList()[0].belong %></option></select></td><td><span style="color:red;">&nbsp;&nbsp;*</span>
                <%
                }
                
                 %>
            



                                                                                                                                            </td></tr>
        <tr><td><a id="abtnadd" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'">save</a></td>
            <td><a id="abtncan" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'">close</a></td></tr>
    </table>
</div>         
           <%--添加--%>
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
        <tr><td>姓名</td><td><input type="text" class="cname"/></td></tr>
        <tr><td>密码</td><td><input type="text" class="cpwd"/></td></tr>
        <tr><td>性别</td><td><input type="text" class="csex"/></td></tr>
        <tr><td>QQ</td><td><input type="text" class="cqq"/></td></tr>
        <tr><td>手机号</td><td><input type="text" class="cphone"/></td></tr>
        <tr><td>学号</td><td><input type="text" class="cstuid"/></td></tr>
        <tr><td>昵称</td><td><input type="text" class="cfname"/></td></tr>
        <tr><td>IP</td><td><input type="text" class="cip"/></td></tr>
        <tr><td>组别</td><td><input type="text" class="cgroup"/></td></tr>
        <tr><td><a id="ebtnadd" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'">save</a></td>
            <td><a id="ebtncan" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'">cancle</a> </td></tr>
    </table>
</div>                <%--编辑--%>



</body>
</html>
