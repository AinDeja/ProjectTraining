<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Indexs.aspx.cs" Inherits="LiZhiOSManagement.Fore_endWEB.Indexs" %>

<!DOCTYPE html>

<html lang="en" class="demo-loading no-js">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <meta name="viewport" content="width=device-width, initial-scale=1.0"> 
		<title>励志OS</title>
    <meta name="description" content="SVG Drawing Animation: Mockup drawing animation with website fade-in" />
		<meta name="keywords" content="svg, line drawing, animation, illustration, fade in, web design, responsive" />
    <script src="JS/jquery-2.1.1.min.js"></script>
    <script src="JS/jquery.min.js"></script>
    <link href="CSS/Index/normalize.css" rel="stylesheet" />
    <link href="CSS/Index/demo.css" rel="stylesheet" />
    <link href="CSS/Index/component.css" rel="stylesheet" />
    <script type="text/javascript">


        


        function ingTip() {
            window.location.href = "Index.aspx";
        }
        function BackTip() {
            $.post("Ajax/TurnBacksBy.ashx", function (data) {
                //window.location.href = "/BackstageWEB/Index.aspx?ShowID="+data;
                //alert(data);
                window.location.href = "/BackstageWEB/Index.aspx?ShowID=" + data
            });
            //window.location.href = "/BackstageWEB/Index.aspx?ShowID=4" ;
        }
        function AdminTip() {
            var tip = "开发人员信息：\n前端：王翔宇\n后台：王翔宇\n从属：.NET组";
            alert(tip);
        }
        </script>
</head>
<body>
		<div class="container">
			<header class="codrops-header">
				<svg id="logo" class="line-drawing" width="100" height="100" xmlns="http://www.w3.org/2000/svg">
					<path class="darker" d="M 80.889194,41.80541 C 80.889194,63.45198 63.341174,81 41.694594,81 20.048024,81 2.5,63.45198 2.5,41.80541 2.5,20.158827 20.048024,2.61081 41.694594,2.61081 c 21.64658,0 39.1946,17.548017 39.1946,39.1946 z"/>
				</svg>
				<div data-svg="logo" class="codrops-logo hide" onclick="AdminTip()" ></div>
			</header>
			<div class="main">
				<div class="headline">
					<svg id="rectangle" class="line-drawing" preserveAspectRatio="none" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 710 374">
						<path d="m -6.5883883,2.7054603 725.0078083,0 0,368.9433697 -725.0078083,0 z" />
					</svg>
	  				<div data-svg="rectangle" class="hide"></div>
	  				<svg id="headline" class="line-drawing" width="560" height="120" viewBox="0 0 560 120" xmlns="http://www.w3.org/2000/svg">
						<path class="darker" d="m20.714289,18.822632l518.571417,0c2.77002,0 5,2.22998 5,5l0,37.857178c0,2.769958 -2.22998,5 -5,5l-518.571417,0c-2.77,0 -5.000001,-2.230042 -5.000001,-5l0,-37.857178c0,-2.77002 2.23,-5 5.000001,-5z"/>
	  					<path d="m35.269436,78.108337l492.063084,0c1.13855,0 2.055176,1.279114 2.055176,2.867981l0,16.79834c0,1.588745 -0.916626,2.86792 -2.055176,2.86792l-492.063084,0c-1.13855,0 -2.055149,-1.279175 -2.055149,-2.86792l0,-16.79834c0,-1.588867 0.916599,-2.867981 2.055149,-2.867981z"/>
	  				</svg>
					<h1 data-svg="headline" class="hide">
						<span>姓名：<%=userName %></span>
      
                        <span>指定IP：<%=userIP %></span>
					</h1>
				</div>
				<section>
                	<figure>
						<svg id="thumb5" class="line-drawing" width="200" height="320" viewBox="0 0 200 320" xmlns="http://www.w3.org/2000/svg">
							<path d="m2.40394,2.216187l195.585959,0l0,145.917998l-195.585959,0l0,-145.917998z" />
						</svg>
						<a href="Indexs.aspx?newTime=1"><img data-svg="thumb5" class="hide" src="Images/Index/img/thumb5.png" alt="img05" /></a>
						<figcaption>
							<svg id="figheadline5" class="line-drawing" width="200" height="320" viewBox="0 0 200 320" xmlns="http://www.w3.org/2000/svg">
								<path class="darker" d="m2.5,177.750244c0,-1.086761 0.913242,-2 2,-2l122.218567,0c1.086761,0 2,0.913239 2,2l0,15.091995c0,1.086761 -0.913239,2 -2,2l-122.218567,0c-1.086758,0 -2,-0.913239 -2,-2l0,-15.091995z" />
							</svg>
							<h2 data-svg="figheadline5" class="hide">签到</h2>
							<svg id="figparagraph5" class="line-drawing" width="200" height="320" viewBox="0 0 200 320" xmlns="http://www.w3.org/2000/svg">
								<path d="m2.5,225.187012c0,-0.543381 0.456621,-1 1,-1l187.85817,0c0.543381,0 1,0.456619 1,1l0,8.960159c0,0.543381 -0.456619,1 -1,1l-187.85817,0c-0.543379,0 -1,-0.456619 -1,-1l0,-8.960159z" />
								<path d="m2.459239,244.278931c0,-0.543381 0.441853,-1 0.967658,-1l181.782347,0c0.525803,0 0.967667,0.456619 0.967667,1l0,8.960159c0,0.543381 -0.441864,1 -0.967667,1l-181.782347,0c-0.525805,0 -0.967658,-0.456619 -0.967658,-1l0,-8.960159z" />
								<path d="m2.316734,263.017273c0,-0.543365 0.392128,-1 0.858761,-1l161.325253,0c0.466629,0 0.858749,0.456635 0.858749,1l0,8.960144c0,0.543365 -0.39212,1 -0.858749,1l-161.325253,0c-0.466632,0 -0.858761,-0.456635 -0.858761,-1l0,-8.960144z" />
								<path d="m2.535285,282.109131c0,-0.543365 0.469602,-1 1.028428,-1l193.198479,0c0.558838,0 1.028427,0.456635 1.028427,1l0,8.960144c0,0.543365 -0.469589,1 -1.028427,1l-193.198479,0c-0.558826,0 -1.028428,-0.456635 -1.028428,-1l0,-8.960144z" />
								<path d="m2.535285,301.554504c0,-0.543365 0.221114,-1 0.484239,-1l90.968223,0c0.263123,0 0.484238,0.456635 0.484238,1l0,8.960144c0,0.543365 -0.221115,1 -0.484238,1l-90.968223,0c-0.263125,0 -0.484239,-0.456635 -0.484239,-1l0,-8.960144z" />
							</svg>
							<p data-svg="figparagraph5" class="hide">每日签到</p>
						</figcaption>
					</figure>
					<figure>
						<svg id="thumb1" class="line-drawing" width="200" height="320" viewBox="0 0 200 320" xmlns="http://www.w3.org/2000/svg">
							<path d="m2.40394,2.216187l195.585959,0l0,145.917998l-195.585959,0l0,-145.917998z" />
						</svg>
						<img data-svg="thumb1" class="hide" src="Images/Index/img/thumb1.png" alt="img01" onclick="BackTip()"/>
						<figcaption>
							<svg id="figheadline1" class="line-drawing" width="200" height="320" viewBox="0 0 200 320" xmlns="http://www.w3.org/2000/svg">
								<path class="darker" d="m2.5,177.750244c0,-1.086761 0.913242,-2 2,-2l122.218567,0c1.086761,0 2,0.913239 2,2l0,15.091995c0,1.086761 -0.913239,2 -2,2l-122.218567,0c-1.086758,0 -2,-0.913239 -2,-2l0,-15.091995z" />
							</svg>
							<h2 data-svg="figheadline1" class="hide">后台管理</h2>
							<svg id="figparagraph1" class="line-drawing" width="200" height="320" viewBox="0 0 200 320" xmlns="http://www.w3.org/2000/svg">
								<path d="m2.5,225.187012c0,-0.543381 0.456621,-1 1,-1l187.85817,0c0.543381,0 1,0.456619 1,1l0,8.960159c0,0.543381 -0.456619,1 -1,1l-187.85817,0c-0.543379,0 -1,-0.456619 -1,-1l0,-8.960159z" />
								<path d="m2.459239,244.278931c0,-0.543381 0.441853,-1 0.967658,-1l181.782347,0c0.525803,0 0.967667,0.456619 0.967667,1l0,8.960159c0,0.543381 -0.441864,1 -0.967667,1l-181.782347,0c-0.525805,0 -0.967658,-0.456619 -0.967658,-1l0,-8.960159z" />
								<path d="m2.316734,263.017273c0,-0.543365 0.392128,-1 0.858761,-1l161.325253,0c0.466629,0 0.858749,0.456635 0.858749,1l0,8.960144c0,0.543365 -0.39212,1 -0.858749,1l-161.325253,0c-0.466632,0 -0.858761,-0.456635 -0.858761,-1l0,-8.960144z" />
								<path d="m2.535285,282.109131c0,-0.543365 0.469602,-1 1.028428,-1l193.198479,0c0.558838,0 1.028427,0.456635 1.028427,1l0,8.960144c0,0.543365 -0.469589,1 -1.028427,1l-193.198479,0c-0.558826,0 -1.028428,-0.456635 -1.028428,-1l0,-8.960144z" />
								<path d="m2.535285,301.554504c0,-0.543365 0.221114,-1 0.484239,-1l90.968223,0c0.263123,0 0.484238,0.456635 0.484238,1l0,8.960144c0,0.543365 -0.221115,1 -0.484238,1l-90.968223,0c-0.263125,0 -0.484239,-0.456635 -0.484239,-1l0,-8.960144z" />
							</svg>
							<p data-svg="figparagraph1" class="hide">信息管理</p>
						</figcaption>
					</figure>
					<figure>
						<svg id="thumb2" class="line-drawing" width="200" height="320" viewBox="0 0 200 320" xmlns="http://www.w3.org/2000/svg">
							<path d="m2.40394,2.216187l195.585959,0l0,145.917998l-195.585959,0l0,-145.917998z" />
						</svg>
						<img data-svg="thumb2" class="hide" src="Images/Index/img/thumb2.png" alt="img02" onclick="ingTip()" />
						<figcaption>
							<svg id="figheadline2" class="line-drawing" width="200" height="320" viewBox="0 0 200 320" xmlns="http://www.w3.org/2000/svg">
								<path class="darker" d="m2.5,177.750244c0,-1.086761 0.913242,-2 2,-2l122.218567,0c1.086761,0 2,0.913239 2,2l0,15.091995c0,1.086761 -0.913239,2 -2,2l-122.218567,0c-1.086758,0 -2,-0.913239 -2,-2l0,-15.091995z" />
							</svg>
							<h2 data-svg="figheadline2" class="hide">论坛</h2>
							<svg id="figparagraph2" class="line-drawing" width="200" height="320" viewBox="0 0 200 320" xmlns="http://www.w3.org/2000/svg">
								<path d="m2.5,225.187012c0,-0.543381 0.456621,-1 1,-1l187.85817,0c0.543381,0 1,0.456619 1,1l0,8.960159c0,0.543381 -0.456619,1 -1,1l-187.85817,0c-0.543379,0 -1,-0.456619 -1,-1l0,-8.960159z" />
								<path d="m2.459239,244.278931c0,-0.543381 0.441853,-1 0.967658,-1l181.782347,0c0.525803,0 0.967667,0.456619 0.967667,1l0,8.960159c0,0.543381 -0.441864,1 -0.967667,1l-181.782347,0c-0.525805,0 -0.967658,-0.456619 -0.967658,-1l0,-8.960159z" />
								<path d="m2.316734,263.017273c0,-0.543365 0.392128,-1 0.858761,-1l161.325253,0c0.466629,0 0.858749,0.456635 0.858749,1l0,8.960144c0,0.543365 -0.39212,1 -0.858749,1l-161.325253,0c-0.466632,0 -0.858761,-0.456635 -0.858761,-1l0,-8.960144z" />
								<path d="m2.535285,282.109131c0,-0.543365 0.469602,-1 1.028428,-1l193.198479,0c0.558838,0 1.028427,0.456635 1.028427,1l0,8.960144c0,0.543365 -0.469589,1 -1.028427,1l-193.198479,0c-0.558826,0 -1.028428,-0.456635 -1.028428,-1l0,-8.960144z" />
								<path d="m2.535285,301.554504c0,-0.543365 0.221114,-1 0.484239,-1l90.968223,0c0.263123,0 0.484238,0.456635 0.484238,1l0,8.960144c0,0.543365 -0.221115,1 -0.484238,1l-90.968223,0c-0.263125,0 -0.484239,-0.456635 -0.484239,-1l0,-8.960144z" />
							</svg>
							<p data-svg="figparagraph2" class="hide">美文分享</p>
						</figcaption>
					</figure>
					
			</section>
		</div>
         </div>
            <!-- /container -->
            <script src="JS/Index/classie.js"></script>
            <script src="JS/Index/svganimations2.js"></script>
	</body>
</html>
