<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostList.aspx.cs" Inherits="DSBBS.HTML.PostView" %>


 <form method="post" action="PostList.aspx">
<table class="tbList">
    <tr>
        <td>
            <div id="ft" onclick="turnto('Publish.aspx?postType=<%=PostType%>')">
                   发帖
            </div>
        </td>
        <td></td>
        <td >
             <div>
                    <input type="text" name="serchText" />
                </div>
        </td>

            <td>
               <input type="submit" name="serchBtn" value="搜索"  style="float:left" />
            </td>
        
    </tr>
        <tr id="tbth">
            <th>发帖人</th>
            <th>文章标题</th>
            <th>发帖时间</th>
          <%--  <th>发帖内容</th>--%>
        </tr>
        <%=tTr.ToString() %>
</table>
</form>
<table class="tbpage" >
        <tr id="tbPage" >
          <td style="width:200px;"> <a  href="PostList.aspx?trpage=1&postType=<%=PostType %>">首页</a>                    </td>
          <td style="width:200px;"><a  href="PostList.aspx?trpage=<%=pageNumber-1 %>&postType=<%=PostType %>">上一页</a>  </td>
          <td style="width:200px;"><a  href="PostList.aspx?trpage=<%=pageNumber+1 %>&postType=<%=PostType %>">下一页</a>  </td>
          <td style="width:200px;"><a  href="PostList.aspx?trpage=<%=pageMax %>&postType=<%=PostType %>">尾页</a>         </td>

        </tr>
    </table>

</div>
</div><!--右侧区域结束-->
</body>
</html>
