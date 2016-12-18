<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignCartogram.aspx.cs" Inherits="LiZhiOSManagement.WEB.SignCartogram" %>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="CSS/SignStyle.css" rel="stylesheet" type="text/css" />
<link href="CSS/buttonStyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="JS/jquery.js"></script>
    <script type="text/javascript" src="JS/echarts.js"></script>

    </head>


<body>


<div id="divSign" 
    style="
	 display: block;
   background: #E4EBEB;
   margin:0 auto;
   margin:50px;
    width: 400px;
    height: 400px;
	">

    <div id="statisticsSign" style="margin:100px auto auto 40px;font-size:20px;">
    <b>开始日期：</b><input style="border:2px solid #66D9EF;line-height:20px;" type="date" value="0" id="firstSign" /><br />
    <b>结束日期：</b><input style="border:2px solid #66D9EF;line-height:20px;" type="date" value="0" id="lastSign"/><br />
                 <div style="margin-top:20px;">  
    <a href="javascript:void(0)" class="button button-3d button-primary button-rounded"   onclick="OPSSS()">进行统计</a>
</div>
        </div>
   


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
                 var myChart = echarts.init(document.getElementById('chartss'));

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
                     url: "Ajax/ShowStatistics.ashx?Fday=" + value1 + "&Lday=" + value2 + "",
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
                         option.series = series;//动态添加数据
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
     <div id="chartss" style="width: 500px;height:500px;position:absolute;top:50px;left:500px"></div>   
        </div>
    

</body>
</html>
