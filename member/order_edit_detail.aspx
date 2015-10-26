<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_edit_detail.aspx.cs" Inherits="member_order_edit_detail" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>修改订单运费信息</title>
    <link href="css/offices.css" rel="stylesheet" type="text/css" />
    <link href="/member/css/dialog.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="main_container">
<memberheader:memberheader ID="memberheader1" runat="server" />
<div class="center">
<memberleft:memberleft ID="memberleft1" runat="server" />	
<div class="main">
<memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
<div class="fcl_tit"><table width="100%" border="0" cellspacing="1" cellpadding="0">
<tr>
<td width="6%" align="center"><img src="images/edit_icon.gif" /></td>
<td width="44%"><strong>修改订单运费信息</strong></td>
<td width="50%" align="right"></td>
</tr>
</table>
</div>
<div class="fcl_tit" style="padding:10px 0px 0px 20px;">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</div>
</div>

</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
</div>
</form>
</body>
</html>