
//弹出式登录
    function ShowNo()                        //隐藏两个层 
    {
        document.getElementById("doing").style.display = "none";
        document.getElementById("divLogin").style.display = "none";
    }
function $(id) {
    return (document.getElementById) ? document.getElementById(id) : document.all[id];
}
function showFloat()                    //根据屏幕的大小显示两个层 
{
    var range = getRange();
    $('doing').style.width = range.width + "px";
    $('doing').style.height = range.height + "px";
    $('doing').style.display = "block";
    document.getElementById("divLogin").style.display = "";
}
function getRange()                      //得到屏幕的大小 
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
//这是自己写的登录方法，如果要用的话请注意修改这一块
/*function Login() {
    var username = document.getElementById("userName").value;
    var pwd = document.getElementById("userPasswd").value;
    if (username == "" || pwd == "") {
        alert("请输入用户名或密码");
        return;
    }
    var div = document.getElementById("userinfo");
    var xmlHttp = GetXmlHttpObject();
    //指定回调函数
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
            m = xmlHttp.responseText;
            if (m == "0") {
                alert("用户名或密码不正确");
            }
            else {
                Msg = m;
                div.innerHTML = "<a href='/WebPL/User/UserCenter.aspx' target='_blank'>" + m + "</a>";
                div.setAttribute("class", "mid");
                ShowNo();
                  
            }
        }
    };
    //初始化xmlhttprequst
    xmlHttp.open("POST", "Login.aspx", true);
    //设置头部
    xmlHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    //发送数据
    var data = "username=" + escape(username) + "&pwd=" + escape(pwd);
    xmlHttp.send(data);
}*/
