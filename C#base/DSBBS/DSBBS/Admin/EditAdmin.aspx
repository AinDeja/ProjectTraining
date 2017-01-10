<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAdmin.aspx.cs" Inherits="DSBBS.Admin.EditAdmin" %>

<script type="text/javascript">
    function doDel(id) {
        if (confirm("您确定要删除吗？")) {
            window.location = "/Admin/EditAdmin.aspx?del=1&id=" + id;
        }
    }
    function gel(id) { return document.getElementById(id); }
    window.onload = function () {
        gel("chkAll").onclick = function () {
            var chks = document.getElementsByName("chkId");
            for (var i = 0; i < chks.length; i++) {
                chks[i].checked = this.checked;
            }
        };

        //批量删除按钮
        gel("btnDelBatch").onclick = function () {
            //检查 是否至少选中 一个 复选框
            var chks = document.getElementsByName("chkId");
            var isBatchDel = false;
            for (var i = 0; i < chks.length; i++) {
                if (chks[i].checked) {
                    isBatchDel = true;
                    break;
                }
            }
            //如果至少选中一个 复选框，则 提交表单
            if (isBatchDel) {
                document.forms[0].submit();
            } else {
                alert("请选择要删除的用户");
            }
        };
    };
    </script>

<form method="post" action="EditAdmin.aspx">
<table class="tbList">
        <tr id="tbth">
            <th><input type="checkbox" id="chkAll" />全选</th>
            <th>管理帐号</th>
            <th>管理密码</th>
            <th>操作</th>
        </tr>
        <%=tTr.ToString() %>
        
</table>
    <table class="tbpage" style="margin-top:0;background-color:#000">
    <tr id="tbPage">
         <td style="width:160px"> <a  href="EditAdmin.aspx?trpage=1">首页</a>                       </td>
         <td style="width:160px"> <a  href="EditAdmin.aspx?trpage=<%=pageNumber-1 %>">上一页</a>    </td>
         <td style="width:160px"> <a  href="EditAdmin.aspx?trpage=<%=pageNumber+1 %>">下一页</a>    </td>
         <td style="width:160px"> <a  href="EditAdmin.aspx?trpage=<%=pageMax %>">尾页</a>           </td>
         <td style="width:160px" id="btnDelBatch"><a>批量删除</a></td>
        </tr>

        </table>
    </form>

</div><!--右侧区域结束-->
</body>
</html>

