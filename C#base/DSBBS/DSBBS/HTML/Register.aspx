<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DSBBS.HTML.Register" %>




<center>
<table id="register">
<tr>
<td>
      <form action="Register.aspx" method="post">
      <fieldset>
            <legend>账号注册</legend>
      <table>
             <tr>
                 <td colspan="2">
                 <b>***请填您的个人信息（请您务必填写真实，有效和完整的注册信息。)***</b>
                 </td>
             </tr>  
             <tr>
                 <td align="right">
                 注册账号：
                 </td>          
                 <td> 
                 <input size="40" type="text" name="name">
                 </td>
             </tr>   
             <tr>
                 <td align="right">
                 初始密码：
                 </td>          
                 <td> 
                 <input size="40" type="password" name="key" >
                 </td>
             </tr>  
          <tr>
                 <td align="right">
                 昵称：
                 </td>          
                 <td> 
                 <input size="40" type="text" name="nc" >
                 </td>
             </tr> 
             <tr>
                 <td align="right">
                 性别：
                 </td>
                 <td>
                 <input type="radio" name="sex" value="1"  />男
                 <input type="radio" name="sex" value="0" />女
                 </td>
             </tr>
             <tr>
                 <td align="right">
                 年龄：
                 </td>          
                 <td> 
                 <input size="40" type="text" name="age" >
                 </td>
             </tr> 
             <%--<tr>
                 <td align="right">
                 注册主页：
                 </td>
                 <td>
                 <input size="40" type="text" name="weba" value="www.">
                 </td>
             </tr>
             <tr>
                 <td align="right">
                 注册主页后缀：
                 </td>
                 <td>
                 <input type="checkbox" name="x" value=".com">.com
                 <input type="checkbox" name="x" value=".net">.net
                 <input type="checkbox" name="x" value=".org">.org
                 <input type="checkbox" name="x" value=".cn">.cn
                 </td>
             </tr>--%>
             <%--<tr>
                 <td align="right">
                 主页所有者（中文）：
                 </td>
                 <td>
                 <input size="40" type="text" name="chinese" value="请输入中文">
                 </td>
             </tr>
             <tr>
                 <td align="right">
                 主页所有者（拼音）：
                 </td>
                 <td>
                 <input size="40" type="text" name="id" value="请以大写字母开头">
                 </td>
             </tr>
             <tr>
                 <td align="right">
                 所属区域：
                 </td>
                 <td>
                 <select name="address">
                 <optgroup label="河南"></optgroup>
                 <option selected="selected" value="zz">郑州</option>
                 <option value="xz">新郑</option>
                 <option value="ly">洛阳</option>
                 <option value="xx">新乡</option>
                 <option value="ny">南阳</option>
                 <optgroup label="广东"></optgroup>
                 <option value="gz">广州</option>
                 <option value="sz">深圳</option>
                 <option value="fs">佛山</option>
                 <option value="dg">东莞</option>
                 <option value="zs">中山</option>
                 <option value="dz">惠州</option>
                 </td>
             </tr>
             <tr>
                 <td align="right">
                 B-Home所在地：
                 </td>
                 <td>
                 <input size="40" type="text" name="ca" value="请仔细核对">
                 </td>
             </tr>
             <tr>
                 <td align="right">
                 B-Home负责人：
                 </td>
                 <td>
                 <input size="40" type="text" name="cb" value="请仔细核对">
                 </td>
             </tr>
             <tr>
                 <td align="right">
                 通信地址：
                 </td>
                 <td>
                 <input size="40" type="text" name="pa" value="请仔细核对">
                 </td>
             </tr>
             <tr>
                 <td align="right">
                 联系电话：
                 </td>
                 <td>
                 <input size="40" type="text" name="p" value="请仔细核对">
                 </td>
             </tr>--%>
             <tr>
                 <td align="right">
                 <input type="submit" value="注册" />
                 </td>
                 <td align="center">
                 <input type="reset" value="重填" />
                 </td>
             </tr>
      </table>
      </fieldset> 
      </form>
</td>
</tr>
</table>
</center>




</div><!--右侧区域结束-->
</body>
</html>
