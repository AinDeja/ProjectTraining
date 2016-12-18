<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenderAnalysis.aspx.cs" Inherits="LiZhiOSManagement.WEB.GenderAnalysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="JS/jquery.js"></script>
    <script src="JS/dist/echarts.js"></script>
    <script src="JS/dist/chart/pie.js"></script>

    <script type="text/javascript">
        $(function () {
            require.config({
                paths: {
                    echarts: './JS/dist'
                }
            });
            require(
       [
           'echarts',
           'echarts/chart/pie',   // 按需加载所需图表，如需动态类型切换功能，别忘了同时加载相应图表
           'echarts/chart/bar',
       ], function (ec) {
          var myChart = ec.init(document.getElementById('main'));
           var option = {
               title: {
                   text: '励志工作室全部成员',
                   subtext: '比例代表id，此图只为显示南丁格尔饼图效果',
                   x: 'center'
               },
               tooltip: {
                   trigger: 'item',
                   formatter: "{a} <br/>{b} : {c} ({d}%)"
               },
               legend: {
                   orient: 'vertical',
                   x: 'left',
                   data: ['直接访问', '邮件营销', '联盟广告', '视频广告', '搜索引擎']
               },
               calculable: true,       //外围线
               series: [
                   {
                       name: '2016年度',
                       type: 'pie',
                       center: ['50%', '50%'],
                       
                       data: [
                { value: 335, name: '直接访问' },
                       ],
                       itemStyle: {
                           emphasis: {
                               shadowBlur: 10,
                               shadowOffsetX: 0,
                               shadowColor: 'rgba(0, 0, 0, 0.5)' //这怎么会有个.5呢？ 看来还是要看看H5哟
                           }
                       }
                   }, {

                       name: '面积模式',
                       type: 'pie',
                       radius: [30, 100],
                       center: ['80%', '80%'],
                                     // for funnel
                       sort: 'ascending',     // for funnel
                       data: [
                           
                       ]
                   }
               ]
           };
           myChart.setOption(option);
           $.ajax({
               type: "get",
               async: true,            //异步请求（同步请求将会锁住浏览器，用户其他操作必须等待请求完成才可以执行）
               url: "Ajax/GenderAnalysisAjax.ashx",
               data: {},//demo 没加条件
               dataType: "json",        //返回数据形式为json
               success: function (result) {
                   var name = [];     //名字
                   var id = [];      //id
                   for (var i = 0; i < result.length; i++) {
                       //alert("你好");
                       //name.push(result[i].name);
                       name[i] = result[i].name;
                       id[i] = result[i].value;
                   }
                   myChart.setOption({ //加载数据图表
                       legend: {
                           data: name
                       },
                       series: [{
                           radius: [60, 200],
                           roseType: 'area',
                           data: result
                       }, {
                           data: result
                       }]
                   });

               },
               error: function (errorMsg) {
                   //请求失败时执行该函数
                   alert("图表请求数据失败!");

               }

           });
       }
    );
            

            


            



        })
        // })
    </script>
   
</head>
<body>
    
    <div id="main" style="width: 100%; height: 600px"></div>

</body>
</html>
