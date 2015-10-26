<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tomd5.aspx.cs" Inherits="test_tomd5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="500" Height="500"></asp:TextBox><br/>
        
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /><br/>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
