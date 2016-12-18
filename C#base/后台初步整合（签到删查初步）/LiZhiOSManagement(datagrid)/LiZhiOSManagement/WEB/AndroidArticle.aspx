<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AndroidArticle.aspx.cs" Inherits="LiZhiOSManagement.WEB.AndroidArticle" %>

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
                url: 'Ajax/TableByDatagrid.ashx?belongkind=Android&bysel=ID&byserch=*',
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
                        { field: 'IsDelete', title: '是否删除', width: 80, },
                        {
                            field: 'CreateTime', title: '创建时间', width: 80, formatter: function (value, row, index) {
                                if (value) {
                                    var date = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));

                                    return date;
                                }
                            }
                        },
                        { field: 'BelongKind', title: '组别', width: 80 },
                        { field: 'Title', title: '标题', width: 80 },
                        {
                            field: 'Content', title: '内容', width: 80, formatter: function (value, row, index) {
                                if (value) {

                                    return value.replace(/[<>&"]/g, function (c) { return { '<': '&lt;', '>': '&gt;', '&': '&amp;', '"': '&quot;' }[c]; });
                                }
                            }//, onClickCell: function (index, field, value) {
                            //    alert(value);
                            //}
                        },
                        { field: 'Author', title: '作者', width: 80 },
                        { field: 'BelongKind_Type', title: '类别', width: 80 },
                        { field: 'MostBrowse', title: '访问量', width: 80 },

                ]],
                onCheck: function (rowIndex, rowData) {       //选中n行
                    var selrow = $('#tt').datagrid('getChecked');
                    if (selrow != null) {
                        $('.cid').val(selrow[0].ID);
                        $('.isdel').val(selrow[0].IsDelete);
                        $.get('SelectTimeForEdit.ashx?id=' + selrow[0].ID, function (data) {
                            $('.ctime').val(data);
                        });
                        $('.cgroup').val(selrow[0].BelongKind);
                        $('.ctitle').val(selrow[0].Title);
                        $('.txtarea').val(selrow[0].Content);
                        $('.cauthor').val(selrow[0].Author);
                        $('.ctype').val(selrow[0].BelongKind_Type);
                        $('.cbrowse').val(0);
                            $('#ebtnadd').bind('click', function () {
                                $.get('Ajax/SaveEditMessages.ashx', { id: $('.cid').val(), isdelete: $('.isdel').val(), createtime: $('.ctime').val(), belongkind: $('.cgroup').val(), title: $('.ctitle').val(), content: $('.txtarea').val(), belonguser: $('.cauthor').val(), belongkind_type: $('.ctype').val(), mostbrowse: $('.cbrowse').val() }, function (data) {
                                    if (data > 0) {
                                        alert("修改成功");
                                        window.location.reload();
                                    } else {
                                        alert("权限不足,编辑失败");
                                    }
                                });
                            });
                        $('#ebtncan').bind('click', function () {
                            $('#ee').dialog('close');
                        });
                    } else {
                        $('.cid').val("");
                        $('.isdel').val(rowData[""]);
                        $('.ctime').val(rowData[""]);
                        $('.cgroup').val(rowData[""]);
                        $('.ctitle').val(rowData[""]);
                        $('.txtarea').val(rowData[""]);
                        $('.cauthor').val(rowData[""]);
                        $('.ctype').val(rowData[""]);
                        $('.cbrowse').val(0);
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
                                $.get('Ajax/DeleteArticleAndCommentsbyDataGrid.ashx', { shuzu: sz }, function (data) {

                                    if (data == 1) {
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
                onUncheck: function (rowIndex, rowData) {
                    //$('#tt').datagrid('getChecked')(0).attr('class','datagrid-row');
                    var selrow = $('#tt').datagrid('getSelections');

                    //编辑
                    if ($('#tt').datagrid('getChecked').length > 0) {

                        $('.cid').val($('#tt').datagrid('getChecked')[0].ID);
                        $('.isdel').val($('#tt').datagrid('getChecked')[0].IsDelete);
                        $.get('Ajax/SelectTimeForEdit.ashx?id=' + $('#tt').datagrid('getChecked')[0], function (data) {
                            $('.ctime').val(data);
                        });
                        //$('.ctime').val($('#tt').datagrid('getChecked')[0].CreateTime);
                        $('.cgroup').val($('#tt').datagrid('getChecked')[0].BelongKind);
                        $('.ctitle').val($('#tt').datagrid('getChecked')[0].Title);
                        $('.txtarea').val($('#tt').datagrid('getChecked')[0].Content);
                        $('.cauthor').val($('#tt').datagrid('getChecked')[0].Author);
                        $('.ctype').val($('#tt').datagrid('getChecked')[0].BelongKind_Type);
                        $('.cbrowse').val(0);
                            $('#ebtnadd').bind('click', function () {
                                $.get('Ajax/SaveEditMessages.ashx', { id: $('.cid').val(), isdelete: $('.isdel').val(), createtime: $('.ctime').val(), belongkind: $('.cgroup').val(), title: $('.ctitle').val(), content: $('.txtarea').val(), belonguser: $('.cauthor').val(), belongkind_type: $('.ctype').val(), mostbrowse: $('.cbrowse').val() }, function (data) {
                                    if (data > 0) {
                                        alert("修改成功");
                                        window.location.reload();
                                    } else {
                                        alert("权限不足,编辑失败");
                                    }
                                });
                            });
                        $('#ebtncan').bind('click', function () {
                            $('#ee').dialog('close');
                        });

                    } else {
                        $('.cid').val("");
                        $('.isdel').val(rowData[""]);
                        $('.ctime').val(rowData[""]);
                        $('.cgroup').val(rowData[""]);
                        $('.ctitle').val(rowData[""]);
                        $('.txtarea').val(rowData[""]);
                        $('.cauthor').val(rowData[""]);
                        $('.ctype').val(rowData[""]);
                        $('.cbrowse').val(0);
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
                            alert($('#tt').datagrid('getChecked').length);

                            if ($('#tt').datagrid('getChecked').length > 0) {
                                var sz = null;

                                var rows = $('#tt').datagrid('getSelections');
                                for (var n = 0; n < rows.length; n++) {
                                    sz += rows[n].ID + ",";
                                }
                                $.get('Ajax/DeleteArticleAndCommentsbyDataGrid.ashx', { shuzu: sz }, function (data) {

                                    if (data == 1) {
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
                        $('.cid').val(selrow["ID"]);
                        $('.isdel').val(selrow["IsDelete"]);
                        $.get('SelectTimeForEdit.ashx?id=' + selrow["ID"], function (data) {
                            $('.ctime').val(data);
                        });
                        //$('.ctime').val(selrow["CreateTime"]);
                        $('.cgroup').val(selrow["BelongKind"]);
                        $('.ctitle').val(selrow["Title"]);
                        $('.txtarea').val(selrow["Content"]);
                        $('.cauthor').val(selrow["Author"]);
                        $('.ctype').val(selrow["BelongKind_Type"]);
                        $('.cbrowse').val(0);
                            $('#ebtnadd').bind('click', function () {
                                $.get('Ajax/SaveEditMessages.ashx', { id: $('.cid').val(), isdelete: $('.isdel').val(), createtime: $('.ctime').val(), belongkind: $('.cgroup').val(), title: $('.ctitle').val(), content: $('.txtarea').val(), belonguser: $('.cauthor').val(), belongkind_type: $('.ctype').val(), mostbrowse: $('.cbrowse').val() }, function (data) {
                                    if (data > 0) {
                                        alert("修改成功");
                                        window.location.reload();
                                    } else {
                                        alert("权限不足,编辑失败");
                                    }
                                });
                            });
                        $('#ebtncan').bind('click', function () {
                            $('#ee').dialog('close');
                        });
                    } else {
                        $('.cid').val("");
                        $('.isdel').val(rowData[""]);
                        $('.ctime').val(rowData[""]);
                        $('.cgroup').val(rowData[""]);
                        $('.ctitle').val(rowData[""]);
                        $('.txtarea').val(rowData[""]);
                        $('.cauthor').val(rowData[""]);
                        $('.ctype').val(rowData[""]);
                        $('.cbrowse').val(0);
                        $('#ebtnadd').bind('click', function () {
                            $('#ee').dialog('close');
                        });
                        $('#ebtncan').bind('click', function () {
                            $('#ee').dialog('close');
                        });
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
                            alert($('#tt').datagrid('getSelections').length);

                            if ($('#tt').datagrid('getChecked').length > 0) {
                                var sz = null;

                                var rows = $('#tt').datagrid('getSelections');
                                for (var n = 0; n < rows.length; n++) {
                                    sz += rows[n].ID + ",";
                                }
                                $.get('Ajax/DeleteArticleAndCommentsbyDataGrid.ashx', { shuzu: sz }, function (data) {

                                    if (data == 1) {
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
                        $('.cid').val(selrow["ID"]);
                        $('.isdel').val(selrow["IsDelete"]);
                        $.get('Ajax/SelectTimeForEdit.ashx?id=' + selrow[0].ID, function (data) {
                            $('.ctime').val(data);
                        });
                        //$('.ctime').val(selrow["CreateTime"]);
                        $('.cgroup').val(selrow["BelongKind"]);
                        $('.ctitle').val(selrow["Title"]);
                        $('.txtarea').val(selrow["Content"]);
                        $('.cauthor').val(selrow["Author"]);
                        $('.ctype').val(selrow["BelongKind_Type"]);
                        $('.cbrowse').val(0);

                    } else {
                        $('.cid').val("");
                        $('.isdel').val(rowData[""]);
                        $('.ctime').val(rowData[""]);
                        $('.cgroup').val(rowData[""]);
                        $('.ctitle').val(rowData[""]);
                        $('.txtarea').val(rowData[""]);
                        $('.cauthor').val(rowData[""]);
                        $('.ctype').val(rowData[""]);
                        $('.cbrowse').val(0);
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
                            alert($('#tt').datagrid('getChecked').length);

                            if ($('#tt').datagrid('getChecked').length > 0) {
                                var sz = null;

                                var rows = $('#tt').datagrid('getSelections');
                                for (var n = 0; n < rows.length; n++) {
                                    sz += rows[n].ID + ",";
                                }
                                $.get('Ajax/DeleteArticleAndCommentsbyDataGrid.ashx', { shuzu: sz }, function (data) {

                                    if (data == 1) {
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
                onDblClickCell: function (rowIndex, field, value) {
                    //$(this).datagrid('beginEdit', index);
                    //var ed = $(this).datagrid('getEditor', { index: index, field: field });
                    //$(ed.target).focus();
                    //alert(value.toString());
                    //alert(value);
                    if (field == "ID") {
                        alert("rowIndex:" + rowIndex + ",field:" + field + ",value:" + value);
                        window.location.href = "./CommentTable.aspx?content=" + value;
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
                    text: '<select id="searchsel" class="easyui-combobox" name="dept" style="width:100px;"><option value="ID">主键</option><option value="IsDelete">是否删除</option><option value="CreateTime">创建时间</option><option value="BelongKind">组别</option><option value="Title">标题</option><option value="Content">内容</option><option value="BelongUser">作者</option><option value="BelongKind_Type">类别</option><option value="MostBrowse">访问量</option></select>&nbsp;<input type="text" id="searchin" style="padding-right:20px;"/>',
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
                            $("#tt").datagrid({ url: "Ajax/TableByDatagrid.ashx?belongkind=Android&bysel=" + $('#searchsel').val() + "&byserch=" + $('#searchin').val() });
                            $("#tt").datagrid('reload');
                        }
                        else {
                            alert("搜索框不能为空");
                        }

                    }
                }, '-', {                                                              //导出
                    id: 'toolbaredit',
                    text: 'ExcelOutPut',
                    iconCls: 'icon-excel',
                    handler: function () {
                        var list = [];
                        if ($('#tt').datagrid('getChecked').length > 0)
                        {
                            for(var i=0;i<$('#tt').datagrid('getChecked').length;i++)
                            {
                                list[i] = $('#tt').datagrid('getChecked')[i].ID;
                                //alert(list[i]);
                            }
                            window.location.href = "Ajax/ArticleExcelOutPut.ashx?id=" + list;
                        }
                        else {
                            //window.location.href = "ArticleExcelOutPut.ashx?id=" + list;
                            alert("请选择要导出的数据");
                        }
                        //window.location.href = "OutputExcel.ashx";
                    }
                }]
            });
        }

        function s(i) {
            (function () {
                var newdiv = document.createElement('div');
                htmlobj = $.ajax({ url: "Ajax/SelectArticleContent.ashx?id=" + i, async: false });

                newdiv.id = 'showcontent'
                newdiv.style = 'position:absolute;top:10px;right:10px;width:300px;min-height:300px;background-color:#D0F79C;align:center;box-shadow:-10px 10px 5px #E7F0FF';
                newdiv.innerHTML = htmlobj.responseText;
                document.body.appendChild(newdiv);
            })(i)

        };

        function sl() {
            document.body.removeChild(showcontent);    //showcontent为id
        };


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
                var zong = y + "/" + m + "/" + d + s;    //最后时间  例如：   11/6/2016 15:46:25
                if (zong.length != 0 && ($("select").find("optgroup option:selected").val().length != 0) && ($('.title').val().length != 0) && ($('.belonguser').val().length != 0) && ($('.mostbrowse').val().length != 0) && ($('.content').val().length != 0)) {
                    $.post('Ajax/AddMessages.ashx', { createtime: zong, title: $('.title').val(), content: $('.content').val(), belonguser: $('.belonguser').val(), belongkind_type: $("select").find("optgroup option:selected").val(), mostbrowse: $('.mostbrowse').val() }, function (data) {
                        if (data > 0) {
                            alert("添加成功!");
                            window.location.reload();
                        } else {
                            alert("添加失败！");
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
<body style="margin:0;padding:0;">
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

    <div id="ss" class="easyui-dialog" title="Add Dialog" style="width:400px;min-height:300px;text-align:center;"   
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



    <div id="sa" class="easyui-dialog" title="Save Dialog" style="width:400px;height:200px;"   
        data-options="iconCls:'icon-save',resizable:true,modal:false,closed:true">   
    Dialog Content.    
</div> 

</body>
</html>
