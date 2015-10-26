<%@ Page Language="VB" AutoEventWireup="false" CodeFile="total.aspx.vb" Inherits="Web_Admin_report_total" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #D6DFF0;
}
body,td,th {
	font-size: 12px;
}
-->
</style></head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="共有：" Font-Names="宋体" Font-Size="12px"></asp:Label>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="宋体" Font-Size="12px" ForeColor="#FF8000"></asp:Label>
        <asp:Label ID="Label3" runat="server" Font-Names="宋体" Font-Size="12px" Text="条海运运价"></asp:Label>
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="宋体" Font-Size="12px"
            ForeColor="#FF8000"></asp:Label>
        <asp:Label ID="Label4" runat="server" Font-Names="宋体" Font-Size="12px" Text="条空运运价"></asp:Label></div>
    </form>
</body>
</html>
