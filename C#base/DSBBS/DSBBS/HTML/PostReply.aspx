<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostReply.aspx.cs" Inherits="DSBBS.HTML.PostReply" %>






        <form method="post" action="PostReply.aspx"  runat=server>
            <table id="pubPost">
    <tr>

            
        
        <td>
            <CKEditor:CKEditorControl ID="ckeditReply" BasePath="~/ckeditor" runat="server"></CKEditor:CKEditorControl>
        
            <input type="submit" value="发表回复" />
            </td>
        </tr>
                </table>
        </form>




</div><!--右侧区域结束-->
</body>
</html>