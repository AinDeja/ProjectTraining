// JavaScript Document
//弹出框绑定
$(".featured-media").bind("click",function(){
					openNew();
					var src = $(this).find(".pic").attr( "src" );
					$('.popCon>img').attr("src",src);
					return false;
});


$(function(){$('.panel-title').click()})
for(var i=0;i<document.getElementsByClassName("panel-title").length;i++)
{	 
(function (i){
	document.getElementsByClassName("panel-title").item(i).addEventListener("click",function(){
$('.panel-title>span:eq('+i+')').toggleClass('glyphicon-chevron-down glyphicon-chevron-up')})})(i)
}

//back-to-top
		$(window).scroll(function(){
			if ($(this).scrollTop() > 50) {
				$('#back-to-top').fadeIn();
			} else {
				$('#back-to-top').fadeOut();
			}
		});
		$('#back-to-top').on('click', function(e){
			e.preventDefault();
			$('html, body').animate({scrollTop : 0}, 1000);
			return false;
		});


		for (var i = 0; i < document.getElementsByClassName("post-content").length;i++) {
            (function(i){
                var text = document.getElementsByClassName("post-content").item(i).innerHTML;
                if(text.length>300){             
                    text= text.substring(0,300)+"...";
                }
                document.getElementsByClassName("post-content").item(i).innerHTML = text;
            })(i)
		};
//闭包


$('.comment-text').hide();	

for(var j=0;j<($('.reply').length);j++)
{(function(j){
	$('.reply:eq('+j+')').click(
	function()
	{
	 $('.comment-text:eq('+j+')').toggle();
	}
	)})(j)
	
};

for(var j=0;j<($('.child-reply').length);j++)
{(function(j){
	$('.child-reply:eq('+j+')').click(
	function()
	{
	 $('.childReply:eq('+j+')').toggle();
	}
	)})(j)
	
};


// 喜欢按钮
for(var k=0;k<$('.like').length;k++)
{
    (function (k) {
	    $('.like:eq(' + k + ')').click(function () {
	        $('.like:eq(' + k + ')>span:first').toggleClass("glyphicon-heart-empty glyphicon-heart red");
	        var useid = $(this).attr("userid");
	        if (k == 0) {
	            var article = $(this).attr("articleid"); 
	            var kt = $(this).attr("kindtype");
	            $.post("Ajax/Favorites.ashx", { articleId: article, userId: useid, kind_type: kt }, function (data, status) {
	                if (status == "success") {
	                    $('.like:eq(' + k + ')>span:last').text(data);
	                }
	            });
	        }
	        else {
	            var articleid = $(this).attr("articleid");
	            var commentid = $(this).attr("commentid")
	            $.post("Ajax/Favorites.ashx", { articleId: articleid, userId: useid, commentId: commentid }, function (data, status) {
	                if (status == "success") {
	                    // $('.favorite:eq(' + k + ')').text = data;
	                    $('.like:eq(' + k + ')>span:last').text(data);
	                    
	                }
	            });
	        }

	}
	)})(k)
};

//浏览量
function myAjax(s) {
    var articleid = s.getAttribute("ID");
    var commentcount = s.getAttribute("count");
    //var id = s.getAttribute("id");
    //var l = parseInt(commentcount) + 1;
    //document.getElementById(id).setAttribute("count",l);
    ////alert(articleid + "," + commentcount);
    //alert(document.getElementById(id).attributes["count"].value);
    //alert(articleid);
    $.post("Ajax/BrowseCount.ashx", { aid: articleid, acount: commentcount }, function (data, status) {
        if (status == "success") {
            //document.getElementById(id).setAttribute("count", l);
            
        }
    });
};


//window.location.href = Server.HtmlEncode(data)


//删除按钮
$(".comment-delete").bind("click", function () {
    var deleteid = $(this).attr("id");
    var result = confirm("您确定要删除吗？");
    if(result)
    {
        //alert("div#comment-" + deleteid);
        $("div#comment-" + deleteid).remove();
        //window.location.href = "Android-Article.aspx?deleteid=" + deleteid;
        $.post("Android-Article.aspx", { deletecommentid: deleteid }, function (data,status) {
            if (status == "success") {
                //alert(data);
                //window.location.href = ajaxdelete;
                //alert('#comment-' + deleteid);
                //alert(data);
                //window.location.href = "Android-Article.aspx?ID=10";
                //$('#comment-' + deleteid).remove();
            }
        });
    }
});

function leftnav(e) {
    //var d = $(this).attr("pb");
    var d = e.getAttribute("pb");    //
    //var count = $(this).attr("count");
    var count = e.getAttribute("count");  //第几页
    var kind_type = e.getAttribute("kind_type");  //类型
    
    if (d.toString() != null && (count.toString() != null)) {
        var xhr = null;
        if (window.XMLHttpRequest) {
            xhr = new XMLHttpRequest();
        } else if (ActiveXObject) {
            xhr = new ActiveXObject("Microsoft.XMLHttp");
        }
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                // $(".col-md-9").innerHTML = xhr.responseText;
                //alert(xhr.responseText.toString());
                //alert(xhr.responseText);    测试
                //alert(xhr.responseText.toString());
                if (xhr.responseText.length != 0)
                {
                    document.getElementById('showArticle').innerHTML = xhr.responseText.toString();
                }
                else
                {
                    document.getElementById('showArticle').innerHTML = "<span style=" + "\"" + "width:200px;display:block;margin:0 auto" + "\"" + ">您所要查询的数据为空！</span>";
                }
                // $("#showArticle").innerHTML = xhr.responseText;
            }
        }
        xhr.open('post', 'Ajax/Leftnav.ashx?selectArticleById=' + d + '&count=' + count+'&kind_type='+kind_type, true);
        xhr.send();
    }
}









function openNew(){
	//获取页面的高度和宽度
	var sWidth=document.body.scrollWidth;
	var sHeight=document.body.scrollHeight;
	//获取页面的可视区域高度和宽度
	var wHeight=document.documentElement.clientHeight;
	var oMask=document.createElement("div");
		oMask.id="mask";
		oMask.style.height=sHeight+"px";
		oMask.style.width=sWidth+"px";
		document.body.appendChild(oMask);
	var oPop=document.createElement("div");
		oPop.id="pop";
		oPop.innerHTML="<div class='popCon'><img><div id='close'>点击关闭</div></div>";
		document.body.appendChild(oPop);
	
	//获弹出框的宽和高
	var dHeight=oPop.offsetHeight;
	var dWidth=oPop.offsetWidth;
		//设置弹出框的left和top
		oPop.style.left=(sWidth-dWidth)/2+"px";
		oPop.style.top=(wHeight-dHeight)/2+"px";
	//点击关闭按钮
	var oClose=document.getElementById("close");
	
		//点击弹出框以外的区域也可以关闭弹出框
		oClose.onclick=oMask.onclick=function(){
					document.body.removeChild(oPop);
					document.body.removeChild(oMask);
					};
};

