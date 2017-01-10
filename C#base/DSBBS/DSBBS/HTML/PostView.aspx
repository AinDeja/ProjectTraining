<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostView.aspx.cs" Inherits="DSBBS.HTML.PostView1" %>


<table id="postview">
    <tr>
        <td>
<div id="box1">
    <div id="leftname">
        <%=pName %>
    </div>

    <div id="datefloor">
        <div style="height:32px">
            <%=pDate %>  <span style="float:right;margin-right:10px;">#1</span>
    </div>
        <div id="textbox">
            <%=pTheme %>
    </div>
     
      <div id="reply"><input type="button" value="回复" onclick="turnto('/HTML/PostReply.aspx')" style="float:right;margin-top:5px;" /></div>
    </div>
         
</div>
        </td>
</tr>
    <%=tTr.ToString() %>
</table>
<%--<div id="reply"><input type="button" value="回复" onclick="turnto('/HTML/PostReply.aspx')" style="float:right;margin-top:5px;" /></div>--%>
</div>

 <div id="ruturntop" onclick="pageScroll()"><h2>TOP</h2></div>

</div><!--右侧区域结束-->
</body>
</html>

