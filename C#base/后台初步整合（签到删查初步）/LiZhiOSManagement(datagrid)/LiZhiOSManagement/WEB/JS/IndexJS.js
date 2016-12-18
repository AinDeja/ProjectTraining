
//function t(i) {
//    (function () {
//        //$(".tt .c" + i).css("background-color", "red");
//        $(".tt .c" + i).toggleClass("exchange");               //整行变色
//    }(i))
//};




function s(i) {
    (function () {
        var newdiv = document.createElement('div');
        htmlobj = $.ajax({ url: "./SelectArticleContent.ashx?id="+i, async: false });
        
        newdiv.id = 'showcontent'
        newdiv.style = 'position:absolute;top:10px;right:10px;width:300px;min-height:300px;background-color:#D0F79C;align:center;box-shadow:-10px 10px 5px #E7F0FF';
        newdiv.innerHTML = htmlobj.responseText;
        document.body.appendChild(newdiv);
    })(i)

};

function sl() {
    document.body.removeChild(showcontent);    //showcontent为id
};



//左边导航栏点击效果
$(function () {
    var lil = $("li").length;
    var i = 1;
    for ( i ; i <= $("li").length; i++) {
        if (i > $("li").length)
        {
            i = 1;
        }
        else
        {
            (function (i, lil) {
                $(".li" + i).click(function () {
                    //$("li" + i + " div").css("background-color", "red");
                    $(".li" + i + " div").css("background-color", "#D0F79C");
                    var j = 1;

                    while ($("li").length != 0) {
                        //alert($(".li" + j + " div").css("background-color"));
                        var str = [];
                        var rgb = $(".li" + j + " div").css("background-color").split('(');
                        for (var k = 0; k < 3; k++) {
                            str[k] = parseInt(rgb[1].split(',')[k]).toString(16);
                        }
                        str = '#' + str[0] + str[1] + str[2];
                        for (var n = 1; n <= $("li").length; n++) {

                            if (str.toUpperCase() == "#D0F79C") {
                                
                                if (n == i) {
                                    continue;
                                }
                                else {
                                    if (n < 5)
                                    {
                                        $(".li" + n + " div").css("background-color", "#C3E6C8");
                                    } else if (n < 9) {
                                        $(".li" + n + " div").css("background-color", "#eee");
                                    } else {
                                        $(".li" + n + " div").css("background-color", "#eee");
                                    }
                                    
                                }
                            }
                        }
                        j++;
                        $("li").length--;
                    }
                });
            })(i, lil);
        }
    }
});


//表格
$(function () {
    InitList();
});

function InitList() {
    $("#tt").datagrid({
        url: 'Ajax/TableByDatagrid.ashx?belongkind=All&bysel=ID&byserch=*',
        title: '数据列表',
        fitColumns: true,
        idField: 'ID',
        fitColumns:true,
        loadMsg: '正在加载成员的信息...',
        pagination: true,  //是否显示分页信息栏，true在数据底部
        singleSelect: false,  //是否单选
        pageSize: 10,
        pageNumber: 1,
        fit:true,
        striped: true,  //交替显示背景
        pageList: [10, 20, 30],
        queryParams: {},
        selectOnCheck:true,
        pagePosition:'bottom',       //设置分页栏的位置
        columns: [[
                { field: 'ck', checkbox: true, align: 'left', width: 50, formatter: function (value, row, index) { return '<input type="checkbox" name="DataGridCheckbox">'; } },
                { field: 'ID', title: '主键', width: 80 },
                { field: 'IsDelete', title: '是否删除', width: 80,},
                {
                    field: 'CreateTime', title: '创建时间', width: 80, formatter: function (value, row, index) {
                        if(value)
                        {
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
                            
                            return value.replace(/[<>&"]/g,function(c){return {'<':'&lt;','>':'&gt;','&':'&amp;','"':'&quot;'}[c];});
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
                $.get('Ajax/SelectTimeForEdit.ashx?id=' + selrow[0].ID, function (data) {
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
                            alert("权限不足，编辑失败");
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
                        //var _list = [];
                        //var selrow = $('#tt').datagrid('getChecked');
                        //var j = $('#tt').datagrid('getChecked').length;
                        //var s = 0;     //成功删除的条数
                        //var c = 0;     //删除失败的条数


                        var sz = null;

                        var rows = $('#tt').datagrid('getSelections');
                        for (var n = 0; n < rows.length; n++)
                        {
                            sz+=rows[n].ID+",";
                        }
                        $.get('Ajax/DeleteArticleAndCommentsbyDataGrid.ashx', { shuzu: sz }, function (data) {

                            if(data==1)
                            {
                                alert("删除成功");
                                window.location.reload();
                            } else if (data == 0) {
                                alert("权限不足，部分删除成功");
                                window.location.reload();
                            } else {
                                alert("权限不足，删除失败");
                            }
                        });



                        //for (var i = 0; i <= $('#tt').datagrid('getChecked').length; i++) {
                        //    //var delrow = $('#tt').datagrid('getRowIndex', $('#tt').datagrid('getChecked')[j].ID); //获取行
                        //    $.get('DeleteArticleAndCommentsbyDataGrid.ashx', { articleid: $('#tt').datagrid('getChecked')[i].ID, username: $('#tt').datagrid('getChecked')[i].Author, group: $('#tt').datagrid('getChecked')[i].BelongKind }, function (data) {
                        //        if (data >0) {
                        //            s++;
                                    
                        //            if (s == j)
                        //            {
                        //                alert("删除成功");
                        //                window.location.reload();
                        //            }
                        //            else {
                        //                if (i == j) {
                        //                    alert("权限不足，部分删除失败");
                        //                    window.location.reload();
                        //                }
                        //            }
                        //        } else {
                        //            c++;
                        //            if (s > 0)
                        //            {
                        //                if(i==j)
                        //                {
                        //                    alert("权限不足，部分删除失败");
                        //                    window.location.reload();
                        //                }
                        //            } 
                        //            else {
                        //                if (c == j) {
                        //                    alert("权限不足,删除失败");
                        //                } 
                        //            }
                                    
                        //        }
                        //    });
                        //}


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
                $.get('Ajax/SelectTimeForEdit.ashx?id=' + $('#tt').datagrid('getChecked')[0].ID, function (data) {
                    $('.ctime').val(data);
                });
                $('.cgroup').val($('#tt').datagrid('getChecked')[0].BelongKind);
                $('.ctitle').val($('#tt').datagrid('getChecked')[0].Title);
                $('.txtarea').val($('#tt').datagrid('getChecked')[0].Content);
                $('.cauthor').val($('#tt').datagrid('getChecked')[0].Author);
                $('.ctype').val($('#tt').datagrid('getChecked')[0].BelongKind_Type);
                $('.cbrowse').val(0);
                $('#ebtnadd').bind('click', function () {
                    alert('要写的代码');
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
                $.get('Ajax/SelectTimeForEdit.ashx?id=' + selrow["ID"].ID, function (data) {
                    $('.ctime').val(data);
                });
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
                $.get('Ajax/SelectTimeForEdit.ashx?id=' + selrow["ID"].ID, function (data) {
                    $('.ctime').val(data);
                });
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
                    //alert($('#tt').datagrid('getChecked').length);

                    if ($('#tt').datagrid('getChecked').length > 0) {
                        alert("请选择要删除的数据");
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
        onClickCell: function (rowIndex, field, value) {                  //单击内容列，显示内容
            
            if(field=="Content")
            {
                if($('#showcontent').length>0)
                {
                    sl();
                   
                }
                var row = $('#tt').datagrid('getData').rows[rowIndex];  //及其重要，获取载入数据(第几行)
                var id = row.ID;
                s(id);
                
            }
            else
            {
                if ($('#showcontent').length > 0)
                {
                    sl();
                }
                
            }
            
            
        },
                                           //列名  //值
        onDblClickCell: function (rowIndex, field, value) {
            //$(this).datagrid('beginEdit', index);
            //var ed = $(this).datagrid('getEditor', { index: index, field: field });
            //$(ed.target).focus();
            //alert(value.toString());
            //alert(value);
            if (field == "ID")
            {
                alert("rowIndex:" + rowIndex + ",field:" + field + ",value:" + value);
                window.location.href = "./CommentTable.aspx?content=" + value;
            }
            
        },
        toolbar: [{
            id: 'toolbarAdd',
            text: '添加',
            iconCls: 'icon-add',
            handler: function () {
               
                //$.messager.alert("添加", "添加正文");
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
            },
            }, '-',{
            
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
                if ($('#searchin').val().length > 0)
                {
                    alert($('#searchsel').val());
                    alert($('#searchin').val());
                    $("#tt").datagrid({ url: "Ajax/TableByDatagrid.ashx?belongkind=All&bysel=" + $('#searchsel').val() + "&byserch=" + $('#searchin').val() });
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
                    }
                    window.location.href = "Ajax/ArticleExcelOutPut.ashx?id=" + list;
                }
                else {
                    alert("请选择要导出的数据");
                }
            }
        }, '-', {                                                                //excel导出
            id: 'toolbaredit',
            text: '饼图',
            iconCls: 'icon-pie',
            handler: function () {
                window.location.href = "ArticleAnalysis.aspx";
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
    $('#abtnadd').bind('click',function(){       
        //$.post("AddMessages.ashx", {});
        var v = $('#dt').datetimebox('getValue');
        //alert(v);
        var y = v.split('/')[2].split(' ')[0];   //年
        var m = v.split('/')[0];                 //月
        var d = v.split('/')[1];                 //日
        var s = v.split('/')[2].split(y)[1];     //秒
        var zong = y + "/" + m + "/" + d + s;    //最后时间  例如：   2016/11/6 15:46:25
        if (zong.length != 0 &&($("select").find("optgroup option:selected").val().length!=0)&& ($('.title').val().length != 0) && ($('.belonguser').val().length != 0) && ($('.mostbrowse').val().length != 0) && ($('.content').val().length != 0))
        {
            $.post('Ajax/AddMessages.ashx', { createtime: zong, title: $('.title').val(), content: $('.content').val(), belonguser: $('.belonguser').val(), belongkind_type: $("select").find("optgroup option:selected").val(), mostbrowse: $('.mostbrowse').val() }, function (data) {
                if (data > 0) {
                    alert("添加成功!");
                    window.location.reload();
                } else {
                    alert("添加失败！");
                }
            });  //发送数据到后台，进而添加到数据库
        } else {

            alert("添加失败，请把信息填完整 啦啦啦");
        }


    });
    //添加（取消）
   
    $('#abtncan').bind('click', function () {
        $('#ss').dialog('close');
    });
});




function bz() {
    var h = document.documentElement.clientHeight;
    $('#cc').attr("style", "height:" + h + "px");
    $('#leftmenu').attr("style", "height:" + h + "px");
    $('#mainFrame').attr("style", "height:" + (h-3) + "px");
}



//加载后删除、编辑按钮
$(document).ready(function () {
    //$('#searchsel').combobox('enable');
    var h = document.documentElement.clientHeight-130;
    $('#cc').attr("style", "height:" + h + "px");
    $('#leftmenu').attr("style", "height:" + (h-28)+ "px");
    $('#aa').attr("style", "height:" + 200 + "px");
    
    
    $('#mainFrame').attr("style", "height:" + (h - 30) + "px");
    $('#aa').accordion({
        //fit: true,
        height: h - 28,
        
    });

    

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




