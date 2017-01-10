<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignINmanage.aspx.cs" Inherits="LiZhiOSManagement.Fore_endWEB.Admin.SignINmanage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div>
        <form action="SignINmanage.aspx" method="get">
           <ul>
                <li>
                    <select name="SelectMonth">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10"1></option>
                        <option value="11"11></option>
                        <option value="12"12></option>
                    </select>月
                </li>
                <li><select name="SelectDay">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                        <option value="11">11</option>
                        <option value="12">12</option>
                        <option value="13">13</option>
                        <option value="14">14</option>
                        <option value="15">15</option>
                        <option value="16">16</option>
                        <option value="17">17</option>
                        <option value="18">18</option>
                        <option value="19">19</option>
                        <option value="20">20</option>
                        <option value="21">21</option>
                        <option value="22">22</option>
                        <option value="23">23</option>
                        <option value="24">24</option>
                        <option value="25">25</option>
                        <option value="26">26</option>
                        <option value="27">27</option>
                        <option value="28">28</option>
                        <option value="29">29</option>
                        <option value="30">30</option>
                        <option value="31">31</option>
                    </select>号</li>
           </ul>
           <input type="submit" value="select" />
</form>
        </div>
        <table id="table">
                <thead>
                    <tr>
                        <th>姓名</th>
                        <th>从属</th>
                        <th>上午</th>
                        <th>下午</th>
                        <th>晚上</th>
                    </tr>
                </thead>
                <tbody>
                   <!--签到信息展示-->
                    <%=tTr %>
                </tbody>
            </table>
</body>
</html>
