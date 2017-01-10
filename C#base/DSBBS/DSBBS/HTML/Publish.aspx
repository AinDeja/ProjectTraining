<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Publish.aspx.cs" Inherits="DSBBS.HTML.Publish" %>

<form method="post" action="Publish.aspx"  runat=server>
<table id="pubPost">
    <tr>

            
        
        <td >
           <span style="vertical-align:bottom;"> 帖子标题:</span> <input type="text" style="height:30px;" name="title" value="<%=PostTitle %>"/>
        </td>
    </tr>

    <tr>
        
        <td  >
          
            <CKEditor:CKEditorControl ID="ckedit" BasePath="~/ckeditor" runat="server"><%=Temthe %></CKEditor:CKEditorControl>
           
            <%--<input type="text" name="temp" value="<%=Temthe %>" />--%>
        </td>
    </tr>

    <tr>
        <td>
            <%--reset不是清空表单元素的值而是恢复到默认值value--%>
            <%if (PostTitle=="")
              {
                 Context.Response.Write("<input type='reset' value='清空'/>");    
              } %>
             
        
            <input type="submit" name="sub" value="发表" style="font-size:20px;"/>
        </td>
    </tr>
    
</table>
</form>




</div><!--右侧区域结束-->
</body>
</html>

