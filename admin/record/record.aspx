<%@ Page Language="C#" AutoEventWireup="true" CodeFile="record.aspx.cs" Inherits="admin_record_record" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size:12px;">

    <table>
        <tr>
            <td>用户名</td>
            <td>姓名</td>
            <td>公司</td>
            <td>地址</td>
            <td>电话</td>
            <td>手机</td>
            <td>时间</td>            
            <td>点击过的运价</td>
        </tr>
                <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <tr>
            <td><%#Eval("username") %></td>
            <td><%#Eval("realname") %></td>
            <td><%#Eval("companyname") %></td>
            <td><%#Eval("address") %></td>
            <td><%#Eval("phone") %></td>
            <td><%#Eval("movephone") %></td>
            <td><%#Eval("NowTime") %></td>
            <td><a href="http://www.100allin.com/fcl/<%#setkey(Eval("freight_code").ToString())%>_<%#Eval("freight_code1")%>.html" target="_blank">http:/www.100allin.com/fcl/<%#setkey(Eval("freight_code").ToString())%>_<%#Eval("freight_code1")%>.html</a></td>
        </tr>        
        </ItemTemplate>
        </asp:Repeater>

    </table>

    </div>
    </form>
</body>
</html>
