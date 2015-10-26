<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pm_shortcut.aspx.cs" Inherits="member_pm_shortcut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 3px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #F6F6F6;
	background-image: url(../images/index/top_bar_bg.jpg);
}
a:link {
	color: #293b5e;
	text-decoration: none;
}
a:visited {
	text-decoration: none;
	color: #293b5e;
}
a:hover {
	text-decoration: underline;
	color: FF6600;
}
a:active {
	text-decoration: none;
	color: #293b5e;
}
body,td,th {
	font-size: 12px;
	font-family: Arial, Helvetica, sans-serif;
}
-->
</style></head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="120000" OnTick="Timer1_Tick">
                </asp:Timer>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
