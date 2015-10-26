<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detail.aspx.cs" Inherits="pro_order_detail" EnableViewState="false" EnableEventValidation="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>订舱单详情</title>
<link href="css/master.css" rel="stylesheet" type="text/css" />
<link href="css/userlist.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
<div id="page">
<div id="center">
<protop:protop ID="protop1" runat="server" />
<div id="main">
<proleft:proleft ID="proleft1" runat="server" />										
<div id="right">
<div class="tt18 bd rightTitle">
<div class="text">订单 <asp:Literal ID="ltrHeadTitle" runat="server"></asp:Literal></div>
</div>
<div class="rightArea txth22">
<div class="listTable">
<div>					
<table cellspacing="0" cellpadding="3" rules="rows" bordercolor ="#D9D9D9" border="1" id="GridView1" style="border-width:1px;border-style:Solid;border-collapse:collapse;">
<tr style="background-color:#F0F0F0;">
<th scope="col" style="width:3px;"></th>
<th scope="col" style="width:650px;">订单编号</th>
<th scope="col" style="width:120px;">详情</th>
</tr>
<asp:Repeater ID="RptOrderDetail" runat="server">
<ItemTemplate>
<tr onmouseover="this.style.backgroundColor='#F4F7FB';" onmouseout="this.style.backgroundColor='#ffffff';">
<td style="width:3px;"></td>
<td style="width:650px;"><%#Eval("detail_txt")%></td>
<td style="width:120px;"><%#Eval("detail_date")%></td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>
</div>
</div>
</div>
</div>			
</div>
<probottom:probottom ID="probottom1" runat="server" />
</div>
</div>
</form>
</body>
</html>
