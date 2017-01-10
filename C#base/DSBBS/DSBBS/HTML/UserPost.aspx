<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPost.aspx.cs" Inherits="DSBBS.HTML.UserPost" %>


<table class="tbList">
    <tr>
        
        <td>贴子标题</td>
        <td>发帖时间</td>
        <%--<td>内容简介</td>--%>
    </tr>
    <%=tTr.ToString() %>
</table>

    <table class="tbpage">
        <tr id="tbPage" >
          <td style="width:200px;"> <a  href="UserPost.aspx?trpage=1">首页</a>                    </td>
          <td style="width:200px;"><a  href="UserPost.aspx?trpage=<%=pageNumber-1 %>">上一页</a>  </td>
          <td style="width:200px;"><a  href="UserPost.aspx?trpage=<%=pageNumber+1 %>">下一页</a>  </td>
          <td style="width:200px;"><a  href="UserPost.aspx?trpage=<%=pageMax %>">尾页</a>         </td>

        </tr>
    </table>


</div><!--右侧区域结束-->
</body>
</html>
