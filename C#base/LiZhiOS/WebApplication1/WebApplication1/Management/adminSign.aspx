<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminSign.aspx.cs" Inherits="WebApplication1.Management.adminSign" %>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="css/Sign.css" rel="stylesheet" type="text/css" />
<link href="css/buttonStyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/Management/js/ShowOutExcle.js"></script>
<script type="text/javascript" src="/Management/js/ShowStatistics.js"></script>
<script type="text/javascript" src="js/jquery.js"></script>
<%--<script type="text/javascript" src="/Management/js/Chart.js"></script>--%>   
    <script type="text/javascript" src="/Management/js/echarts.js"></script>

<script type="text/javascript">
    $(function () {
        //导航切换
        $(".imglist li").click(function () {
            $(".imglist li.selected").removeClass("selected")
            $(this).addClass("selected");
        })
    })
    function outExcle() {
        //导出
        
        var getDateFirst = document.getElementById("firstDate").value;
        alert(getDateFirst);
    }

  // 获取窗口的高度
    var win_h = $(window).height();
    $(".rightFrame").height(win_h);
 
    // 窗口变化事改变高度
    $(window).resize(function(event) {
        // 获取窗口的高度
        var win_h = $(window).height();
 
        $(".body").height(win_h);
    }
)


</script>
  <%--   <script type="text/JavaScript">
<!--AJAX  -->
        //创建XMLHttpRequest对象
        var request = false;
        try {
            request = new XMLHttpRequest();
        } catch (trymicrosoft) {
            try {
                request = new ActiveXObject("Msxml2.XMLHTTP");
            } catch (othermicrosoft) {
                try {
                    request = new ActiveXObject("Microsoft.XMLHTTP");
                } catch (failed) {
                    request = false;
                }
            }
        }
        if (!request) alert("Error initializing XMLHttpRequest!");
        //获取信息
        function getInfo() {
            var url = "AJAX/getSignExcle.aspx";
            request.open("GET", url, true);
            request.onreadystatechange = updatePage;
            request.send(null);
        }
        //更新页面
        function updatePage() {
            if (request.readyState == 4) {
                if (request.status == 200) {
                    var response = request.responseText;
                    document.getElementById("div1").innerText = response;
                } else if (request.status == 404) {
                    alert("Requested URL is not found.");
                } else if (request.status == 403) {
                    alert("Access denied.");
                } else
                    alert("status is " + request.status);
            }
        }
</script>

</script>
   <!-- 路径选择 安全问题 无法直接使用-->
    <script>
        function browseFolder(path) {
            try {
                var Message = "\u8bf7\u9009\u62e9\u6587\u4ef6\u5939"; //选择框提示信息
                var Shell = new ActiveXObject("Shell.Application");
                var Folder = Shell.BrowseForFolder(0, Message, 64, 17); //起始目录为：我的电脑
                //var Folder = Shell.BrowseForFolder(0,Message,0); //起始目录为：桌面
                if (Folder != null) {
                    Folder = Folder.items(); // 返回 FolderItems 对象
                    Folder = Folder.item(); // 返回 Folderitem 对象
                    Folder = Folder.Path; // 返回路径
                    if (Folder.charAt(Folder.length - 1) != "") {
                        Folder = Folder + "";
                    }
                    document.getElementById(path).value = Folder;
                    return Folder;
                }
            }
            catch (e) {
                alert(e.message);
            }
        }
</script>--%>
</head>


<body>

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">首页</a></li>
    <li><a href="#">功能管理</a></li>
    <li><a href="#">签到管理</a></li>
    </ul>
    </div>
    
    <div class="rightinfo">
    
    <div class="tools">
    
    	<ul class="toolbar">
        <li class="click"  onclick="showFloatOut()" ><span><img src="images/t01.png" /></span>导出</li>
        <li class="click"><span><img src="images/t02.png" /></span>修改</li>
        <li><span><img src="images/t03.png" /></span>删除</li>
        <li class="click"  onclick="showFloatSign()" ><span><img src="images/t04.png" /></span>统计</li>
        </ul>
        
        
    <%--    <ul class="toolbar1">
        <li><span><img src="images/t05.png" /></span>设置</li>
        </ul>--%>
    
    </div>
    
    
    
    <ul class="classlist">
    
   <%-- <li><span><img src="images/001.jpg" /></span><div class="lright">
    <h2>7月1号</h2>
    <p>总人数：22<br />应签:22<br />实签:22</p>
    <a class="enter">查看详情</a>
    </div> </li>--%>
    <%=sginList %>
    
    
    </ul>
    
    <div class="clear"></div>
   
    <div class="pagin">
    	<div class="message">共<i class="blue"><%=pageRemainder %></i>条记录，当前显示第&nbsp;<i class="blue"><%=pageNumber %>&nbsp;</i>页</div>
        <ul class="paginList">
        <li class="paginItem"><a href="adminSign.aspx?trpage=<%=pageNumber-1 %>"><span class="pagepre"></span></a></li>
      <%--    <li class="paginItem"><a href="javascript:;">1</a></li>
      <li class="paginItem current"><a href="javascript:;">2</a></li>
        <li class="paginItem"><a href="javascript:;">3</a></li>
        <li class="paginItem"><a href="javascript:;">4</a></li>
        <li class="paginItem"><a href="javascript:;">5</a></li>
        <li class="paginItem more"><a href="javascript:;">...</a></li>
        <li class="paginItem"><a href="javascript:;">10</a></li>--%>

         <%--  <li class="paginItem"><a  href="adminSign.aspx?trpage=<%=pageNumber-1 %>">上一页</a> </li>
           <li class="paginItem"><a  href="adminSign.aspx?trpage=<%=pageNumber+1 %>">下一页</a> </li>--%>
            <%=pageList %>


        <li class="paginItem"><a href="adminSign.aspx?trpage=<%=pageNumber+1 %>"><span class="pagenxt"></span></a></li>
        </ul>

    </div>
    
    
    <div class="tip">
    	<div class="tiptop"><span>提示信息</span><a></a></div>
        
      <div class="tipinfo">
        <span><img src="images/ticon.png" /></span>
        <div class="tipright">
        <p>是否确认对信息的修改 ？</p>
        <cite>如果是请点击确定按钮 ，否则请点取消。</cite>
        </div>
        </div>
        
        <div class="tipbtn">
        <input name="" type="button"  class="sure" value="确定" />&nbsp;
        <input name="" type="button"  class="cancel" value="取消" />
        </div>
    
    </div>
    

    
    
    </div>
    

                <!--弹出式签到信息【导出】--->
 <!--加一个半透明层--> 
    <div id="doingExcle" style="filter:alpha(opacity=30);-moz-opacity:0.3;opacity:0.3;background-color:#000;width:50px;height:50px;z-index:1000;position: absolute;top:0;display:none;overflow: hidden;margin:0 auto;"> 
    </div>  
<!--加一个登录层--> 

<div id="divExcle" 
    style="z-index:1001;
	 position: absolute; 
	 display: none;
	 top:30%; 
	 left:40%;
	 margin:-200px 0 0 -200px;   
     border:1px solid #66D9EF;
    background: #fff;
	position:absolute; 
    width: 400px;
    height: 400px;
	">

<a class="closeOut" href="javascript:void(0)" onclick="ShowNo()" style="color:red;display:block;width:15px;height:15px;float:right;font-size:15px;">×</a>

    <div id="selectDate" style="margin:100px auto auto 40px;font-size:20px;">
    开始日期：<input style="border:2px solid #66D9EF;line-height:20px;" type="date" value="" id="firstDate" /><br />
    结束日期：<input style="border:2px solid #66D9EF;line-height:20px;" type="date" value="" id="lastDate"/><br />
    <%--保存地址：<input style="border:2px solid #66D9EF;line-height:20px;" type="file" value="" id="filePath"/><br />--%>
        </div>
    

    <script>
        function openout() {
            var Fday = document.getElementById('firstDate').value;
            var Lday = document.getElementById('lastDate').value;
            //var Path = document.getElementById('filePath').value;
            alert("文件即将下载！");
            window.location.href = 'AJAX/OutExcle.ashx?Fday=' + Fday + '&Lday=' + Lday + '';


        }
    </script>
<div style="position: absolute;top:200px;left:40px">  
    <a href="javascript:void(0)" class="button button-3d button-primary button-rounded"   onclick="openout()">导出文件</a>
</div>
   <%-- <div style="position: absolute;top:280px;left:40px">  
    <a href="javascript:void(0)" class="button button-3d button-primary button-rounded" onclick="">打开文件</a>
</div>--%>


<%--    <script>
        function getInfo(){
            $.ajax({
                type:"GET",
            url: "AJAX/OutExcle.ashx", context: document.body, success: function () {
                alert("完成!");
            }
        });
        }
    </script>
  <form id="form1" runat="server">
    <div id="div1">
        <input type="button" value="Test Ajax" onclick="getInfo()" />
        <%=outExcle() %>
        <br />
    </div>
    </form>--%>


    </div>

    <!--隐藏结束-->



                   <!--弹出式签到信息【统计】--->
 <!--加一个半透明层--> 
    <div id="doingSign" style="filter:alpha(opacity=30);-moz-opacity:0.3;opacity:0.3;background-color:#000;width:50px;height:50px;z-index:1000;position: absolute;top:0;display:none;overflow: hidden;margin:0 auto;"> 
    </div>  
<!--加一个登录层--> 

<div id="divSign" 
    style="z-index:1001;
	 position: absolute; 
	 display: none;
	 top:30%; 
	 left:40%;
	 margin:-200px 0 0 -200px;   
     border:1px solid #66D9EF;
    background: #fff;
	position:absolute; 
    width: 800px;
    height: 600px;
	">

<a class="closeOut" href="javascript:void(0)" onclick="ShowNoSign()" style="color:red;display:block;width:15px;height:15px;float:right;font-size:15px;">×</a>
    <div style="width:370px;">
    <div id="statisticsSign" style="margin:100px auto auto 40px;font-size:20px;width:360px;">
    开始日期：<input style="border:2px solid #66D9EF;line-height:20px;" type="date" value="" id="firstSign" /><br />
    结束日期：<input style="border:2px solid #66D9EF;line-height:20px;" type="date" value="" id="lastSign"/><br />
        </div>
   
<%--    <script>
        //两个日期之间的日期
        function forSelectDate(value1, value2) {
            var getDate = function (str) {
                var tempDate = new Date();
                var list = str.split("-");
                tempDate.setFullYear(list[0]);
                tempDate.setMonth(list[1] - 1);
                tempDate.setDate(list[2]);
                return tempDate;
            }
            var date1 = getDate(value1);
            var date2 = getDate(value2);
            if (date1 > date2) {
                var tempDate = date1;
                date1 = date2;
                date2 = tempDate;
            }
            var strDate = "\"" + (date1.getFullYear() + "-" + (date1.getMonth() + 1) + "-" + date1.getDate() ) + "\",";//追加第一天
            date1.setDate(date1.getDate() + 1);
            while (!(date1.getFullYear() == date2.getFullYear() && date1.getMonth() == date2.getMonth() && date1.getDate() == date2.getDate())) {
                strDate += "\"" + (date1.getFullYear() + "-" + (date1.getMonth() + 1) + "-" + date1.getDate()) + "\",";
                date1.setDate(date1.getDate() + 1);//加一天
            }
            strDate += "\"" + (date1.getFullYear() + "-" + (date1.getMonth() + 1) + "-" + date1.getDate()) + "\",";//追加最后一天
            alert(strDate);

        }
    </script>
    <script>
        function getLabels() {
            //日期遍历
            var value1 = document.getElementById("firstSign").value;
            var value2 = document.getElementById("lastSign").value;
            var getDate = function (str) {
                var tempDate = new Date();
                var list = str.split("-");
                tempDate.setFullYear(list[0]);
                tempDate.setMonth(list[1] - 1);
                tempDate.setDate(list[2]);
                return tempDate;
            }
            var date1 = getDate(value1);
            var date2 = getDate(value2);
            if (date1 > date2) {
                var tempDate = date1;
                date1 = date2;
                date2 = tempDate;
            }
            var strDate = "\"" + (date1.getFullYear() + "-" + (date1.getMonth() + 1) + "-" + date1.getDate()) + "\",";//追加第一天
            date1.setDate(date1.getDate() + 1);
            while (!(date1.getFullYear() == date2.getFullYear() && date1.getMonth() == date2.getMonth() && date1.getDate() == date2.getDate())) {
                strDate += "\"" + (date1.getFullYear() + "-" + (date1.getMonth() + 1) + "-" + date1.getDate()) + "\",";
                date1.setDate(date1.getDate() + 1);//加一天
            }
            strDate += "\"" + (date1.getFullYear() + "-" + (date1.getMonth() + 1) + "-" + date1.getDate()) + "\",";//追加最后一天
            return strDate;
        }
        function forSelectDate() {

            var ctx = document.getElementById("canvas").getContext("2d");
           
            var data = {
                //横坐标
                labels:["1","2","3"],

                datasets: [{

                    label: "",

                    fillColor: "rgba(220,220,220,0.2)",

                    strokeColor: "rgba(0,102,51,1)",

                    pointColor: "rgba(220,220,220,1)",

                    pointStrokeColor: "#339933",

                    pointHighlightFill: "#339933",

                    pointHighlightStroke: "rgba(220,220,220,1)",

                    data: [1.27, 1.30, 1.30, 1.41, 1.04, 1.29, 1.27, 1.30, 1.30, 1.41, 1.04, 1.29]

                },
                {

                    label: "",

                    fillColor: "rgba(151,187,205,0.5)",
                    strokeColor: "rgba(151,187,205,1)",
                    pointColor: "rgba(151,187,205,1)",
                    pointStrokeColor: "#fff",


                    pointHighlightFill: "#339933",

                    pointHighlightStroke: "rgba(220,220,220,1)",

                    data: [1.30, 1.30, 1.27, 1.30, 1.30, 1.41, 1.04, 1.29, 1.41, 1.04, 1.29, 1.27, 1.30, 1.30,]

                }]

            };
            var salesVolumeChart = new Chart(ctx).Line(data, {

                // 小提示的圆角

                // tooltipCornerRadius: 0,

                // 折线的曲线过渡，0是直线，默认0.4是曲线

                bezierCurveTension: 0,

                // bezierCurveTension: 0.4,

                // 关闭曲线功能

                bezierCurve: false,

                // 背景表格显示

                // scaleShowGridLines : false,

                // 点击的小提示

                tooltipTemplate: "天",

                //自定义背景小方格、y轴每个格子的单位、起始坐标

                scaleOverride: true,

                scaleSteps: 9.5,

                // scaleStepWidth: Math.ceil(Math.max.apply(null,data.datasets[0].data) / 0.1),

                scaleStepWidth: 0.05,

                scaleStartValue: 1

            });
            //myNewChart_4 = new Chart(ctx).Doughnut(doughnutData, salesVolumeChart);
            
           

        }
    </script>--%>

         <script>
             function OPSSS() {
                 //var i = "1";
                 //    $.ajax({
                 //        url: "AJAX/ShowStatistics.ashx",
                 //        type: "Get",
                 //        dataType: "text",//上传类型text json 对象 json数组 
                 //        success: function (data) {
                 //            alert(data);
                 //        },
                 //        error: function (XMLHttpRequest, textStatus, errorThrown) { alert(textStatus); }
                 //    });
                 var value1 = document.getElementById("firstSign").value;
                 var value2 = document.getElementById("lastSign").value;
                        var myChart = echarts.init(document.getElementById('main'));
                        var option = {
                            title: {
                                text: '',
                                x: 'center'
                            },
                            tooltip: {
                                trigger: 'axis'
                            },
                            legend: {
                                data: [],
                                y: 'bottom'

                            },
                            toolbox: {
                                show: true,
                                feature: {
                                    mark: { show: true },
                                    dataView: { show: true, readOnly: false },
                                    magicType: { show: true, type: ['line', 'bar'] },
                                    restore: { show: true },
                                    saveAsImage: { show: true }
                                }
                            },
                            xAxis: [{
                                type: 'category',
                                data: []
                            }],
                            yAxis: [{
                                type: 'value'
                            }],
                            series: [
                                //{
                                //name: 'aaa',
                                //type: 'line',
                                //data: [2.0, 4.9, 7.0, 23.2, 25.6, 76.7, 135.6, 162.2, 32.6, 20.0, 6.4, 3.3]
                                //}
                            ]
                        }
                  

                         $.ajax({
                             url: "AJAX/ShowStatistics.ashx?Fday=" + value1 + "&Lday=" + value2 + "",
                             type: "Get",
                             dataType: "json",//上传类型text json 对象 json数组 
                             success: function (data) {
                                 //数据接口成功返回
                                 //后台需要返回以下结构的json数据
                                 //data = {
                                 //    'legen': ['迟到', '未签'],
                                 //    'axis': ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月'],
                                 //    'series': [[2.0, 4.9, 7.0, 23.2, 25.6, 76.7, 135.6, 162.2, 32.6, 20.0, 6.4, 3.3],[4.0, 2.9, 6.0, 21.2, 50.6, 56.7, 115.6, 102.2, 62.6, 20.0, 9.4, 3.3]
                                 //    ]
                                 //};

                                 var legendData = [];
                                 var xAxisData = [];
                                 var series = [];
                                 if (data != null && data["series"].length > 0) {
                                     legendData = data["legen"];
                                     xAxisData = data["axis"];
                                     for (var i = 0, len = data["series"].length; i < len; i++) {
                                         series.push({
                                             "name": legendData[i],
                                             "type": "line",
                                             "data": data["series"][i]
                                         });

                                     }
                                 }
                                 option.title.text = '折线图';
                                 option.legend.data = legendData;
                                 option.xAxis[0].data = xAxisData;//动态添加X轴坐标
                                 option.series=series;//动态添加数据
                                 myChart.setOption(option);
                                 
                             },
                             error: function () {
                                 //数据接口异常处理
                                 var legendData = [''];
                                 var xAxisData = [''];
                                 var seriesData = [
                                         {
                                             name: '',
                                             type: 'line',
                                             data: [0]
                                         }
                                 ];
                                 option.legend.data = legendData;
                                 option.xAxis[0]['data'] = xAxisData;

                                 myChart.setOption(option);
                                 myChart.setSeries(seriesData);

                             },
                         
                         });
                     }
              


                 
    </script>
         <div style="position: absolute;top:200px;left:40px;width:150px;height:50px;">  
    <a href="javascript:void(0)" class="button button-3d button-primary button-rounded"   onclick="OPSSS()">进行统计</a>
   <a href="javascript:void(0)" class="button button-3d button-primary button-rounded"   onclick="forSelectDate(firstSign.value,lastSign.value)">日期循环</a>
</div>
        </div>

   <%--chart.js <div style="max-width:500px;float:right;margin-top:-100px;clear:both">
    <canvas id="canvas" width="500" height="500"></canvas>
    </div>--%>
    <%-- echarts.js --%>
    <div id="main" style="width: 500px;height:500px;float:right;margin-top:-100px;clear:both"></div>
    <script type="text/javascript">
        //// 另外说一下带主题加载，就是这样的，注意“e_macarons”必须是myTheme.js(上面引入的自定义主题js文件,echarts中也附带了不少主题js文件)中函数的名字
        //var myChart = echarts.init(document.getElementById('main'),e_macarons);
        //option = { 
        //    title: { ··· }, 
        //    tooltip : { ··· }, 
        //    legend: { ··· }, 
        //    toolbox: { ··· }, 
        //    grid: { ··· }, 
        //    xAxis : [ ··· ], 
        //    dataZoom: [ ··· ], 
        //    yAxis : [ ··· ], 
        //    series:[] 
        //}; 
        ////加载数据
        //jQuery.ajax({
        //    url:"url",
        //    type:'get',
        //    dataType:'json',
        //    success:function(jsons){
        //        var Item = function(){
        //            return {
        //                name:'',
        //                type:'line',
        //                itemStyle: {normal: {areaStyle: {type: 'default',opacity:isArea}}},
        //                label: {normal: {show: isShowAllData,position: 'top'}},
        //                markLine: {data: [{type: 'average', name: '平均值'}]},
        //                data:[]
        //            }
        //        };
        //        var legends = [];
        //        var Series = [];
        //        var json = jsons.data;
        //        for(var i=0;i < json.length;i++){
        //            var it = new Item();
        //            it.name = json[i].name;
        //            legends.push(json[i].name);
        //            it.data = json[i].data;
        //            Series.push(it);
        //        }
				
        //        option.xAxis[0].data = jsons.xcontent; 
        //        option.legend.data = legends;
        //        option.series = Series; // 设置图表
        //        myChart.setOption(option);// 重新加载图表
        //    },
        //    error:function(){
        //        alert("数据加载失败！请检查数据链接是否正确");
        //    }
        //});
        //// 初次加载图表(无数据) 
        //myChart.setOption(option); 
    </script>

    </div>

    <!--隐藏结束-->
</body>

</html>
