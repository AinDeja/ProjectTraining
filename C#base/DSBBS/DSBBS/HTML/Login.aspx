<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DSBBS.HTML.Login" %>

<div id="loginwin">
<form method="post" action="Login.aspx">
    <fieldset class="loginUser">
    <legend><%=tip %></legend>
<table >
    <tr>
        <td>
            帐号：
        </td>
        <td>
            <input type="text" name="Name" />
        </td>
    </tr>
    <tr>
        <td>
            密码：
        </td>
        <td>
            <input type="password" name="PassWord" />
        </td>
    </tr>
      <tr>
          
        <td>
             <input type="reset"  />
        </td>
        <td>
            <input type="submit" name="sub" value="登录"/>
        </td>
          <td>
              <input type="checkbox"  name="freeLogin" value="一周内免登录" />一周内免登录
          </td>
    </tr>
</table>
        </fieldset> 
</form>
</div>

</div>
</div><!--右侧区域结束-->
</body>
</html>

