//*********************统计
//弹出式菜单
function ShowNoSign()                        //隐藏两个层 
{
    document.getElementById("doingSign").style.display = "none";
    document.getElementById("divSign").style.display = "none";
}
//function $(id) {
//    return (document.getElementById) ? document.getElementById(id) : document.all[id];
//}
function showFloatSign()                    //根据屏幕的大小显示两个层 
{
    //alert("1");
    var range = getSignDiv();
    document.getElementById("doingSign").style.width = range.width + "px";
    document.getElementById("doingSign").style.height = range.height + "px";
    document.getElementById("doingSign").style.display = "block";
    document.getElementById("divSign").style.display = "block";
}
function getSignDiv()                      //得到屏幕的大小 
{
    var top = document.body.scrollTop;
    var left = document.body.scrollLeft;
    var height = document.body.clientHeight;
    var width = document.body.clientWidth;

    if (top == 0 && left == 0 && height == 0 && width == 0) {
        top = document.documentElement.scrollTop;
        left = document.documentElement.scrollLeft;
        height = document.documentElement.clientHeight;
        width = document.documentElement.clientWidth;
    }
    return { top: top, left: left, height: height, width: width };
}