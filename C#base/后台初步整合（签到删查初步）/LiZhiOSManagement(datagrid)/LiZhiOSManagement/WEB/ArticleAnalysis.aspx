<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleAnalysis.aspx.cs" Inherits="LiZhiOSManagement.WEB.ArticleAnalysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script src="JS/jquery.js"></script>
    <script src="JS/dist/echarts.js"></script>
    <script src="JS/dist/chart/pie.js"></script>
        <%--基于准备好的dom，初始化echarts实例--%>
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
                title:{
                    text: '励志工作室各组成员发表文章',
                    x: 'center'
                },
                tooltip: {
                    trigger: 'item',
                    formatter: "{a} <br/>{b}: {c} ({d}%)"
                },
                legend: {
                    orient: 'vertical',
                    x: 'left',
                    data: []
                    //'直达', '营销广告', '搜索引擎', '邮件营销', '联盟广告', '视频广告', '百度', '谷歌', '必应', '其他'
                },
                series: [
                    {
                        name: '访问来源',
                        type: 'pie',
                        selectedMode: 'single',
                        radius: [0, '30%'],

                        label: {
                            normal: {
                                position: 'inner'
                            }
                        },
                        labelLine: {
                            normal: {
                                show: false
                            }
                        },
                        data: [{ value: 335, name: '直达' }]

                        
                //            { value: 335, name: '直达', selected: true },
                //            { value: 679, name: '营销广告' },
                //            { value: 1548, name: '搜索引擎' }
                        
                    },
                    {
                        name: '访问来源',
                        type: 'pie',
                        radius: ['40%', '55%'],

                        data: [
                            //{ value: 335, name: '直达' },
                            //{ value: 310, name: '邮件营销' },
                            //{ value: 234, name: '联盟广告' },
                            //{ value: 135, name: '视频广告' },
                            //{ value: 1048, name: '百度' },
                            //{ value: 251, name: '谷歌' },
                            //{ value: 147, name: '必应' },
                            //{ value: 102, name: '其他' }
                        ]
                    }
                ]
            };




            myChart.setOption(option);
            $.ajax({
                type: "get",
                async: true,            //异步请求（同步请求将会锁住浏览器，用户其他操作必须等待请求完成才可以执行）
                url: "Ajax/ArticleAnalysisAjax.ashx",
                data: {},//demo 没加条件
                dataType: "json",        //返回数据形式为json
                success: function (result) {
                    var name = [];     //名字
                    var id = [];      //id
                    //var js = null;
                    //var jss = null;
                    var jsn = [];
                    var jssw = [];
                    //var array = [];
                    var j = 0;
                    for (var i = 0; i < result.length; i++) {
                        name[i] = result[i].name;
                        id[i] = result[i].value;
                        var map = {};
                        var mapw = {};
                        if(i<3)
                        {
                            js = '{"value' + '":' + '"' + result[i].value + '"' + ',"name' + '":' + '"' + result[i].name + '"' + '}';
                            var obj = jQuery.parseJSON(js);
                            jsn[i] = obj;

                            //map.value = result[i].value;
                            //map.name = result[i].name;

                            //jsn[i]=map;

                        } else {
                            jss = '{"value' + '":' + '"' + result[i].value + '"' + ',"name' + '":' + '"' + result[i].name + '"' + '}';
                            var obj = jQuery.parseJSON(jss);
                            jssw[j] = obj;
                            //mapw.value = result[i].value;
                            //mapw.name = result[i].name;
                            //jssw[j] = mapw;
                            //alert(j);
                            //alert(jssw[j].name);
                            j++;
                        }
                        
                    }
                    //alert(js);
                    //js = js.substring(4, js.length - 1);
                    
                    //var jsobj = jQuery.parseJSON(js);
                    //jss = jss.substring(4, jss.length - 1);
                    //var jssobj = jQuery.parseJSON(jss);
                    //alert(js);
                    //alert(jssobj);
                    //alert(JSON.stringify(jss))            //弹出json内容
                    //alert(jssw[0].value);
                    myChart.setOption({ //加载数据图表
                        legend: {
                            data: name
                        },
                        series: [{
                            //radius: [60, 200],
                            //roseType: 'area',
                            data: jsn
                        }, {
                            data: jssw
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

        </script>
</head>
<body>
    <div id="main" style="width: 100%; height: 600px"></div>
</body>
</html>
