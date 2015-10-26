<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="admin_order_list" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>审核订舱单</title>
<link href="../css/master.css" rel="stylesheet" type="text/css" />
<link href="../css/userlist.css" rel="stylesheet" type="text/css" />
<script src="/member/order/js/adminlist.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div id="page">
<div id="center">
<admintop:admintop ID="admintop1" runat="server" />
<adminmenu:adminmenu id="adminmenu1" runat="server" />
<div id="main">
<adminleft:adminleft ID="adminleft1" runat="server" />							
<div id="right">
<div class="tt18 bd rightTitle">
<div class="text"><asp:Literal ID="ltrHeadTitle" runat="server"></asp:Literal></div>
</div>
<div class="rightArea txth22">
<div id="tipBoxSearch" class="tipBox">
<table border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="20">
<asp:Literal ID="ltrOrderAll" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
<asp:Literal ID="ltrOrderCheck" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;
</td>
</tr> 
</table>
</div>

<div class="listTable">
<div style="position:relative;">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>						
<table cellspacing="0" cellpadding="3" rules="rows" bordercolor ="#D9D9D9" border="1" id="GridView1" style="border-width:1px;border-style:Solid;border-collapse:collapse;">
<tr style="background-color:#F0F0F0;">
<th scope="col" style="width:3px;"></th>
<th scope="col" style="width:130px;">订单编号</th>
<th scope="col" style="width:110px;">下单时间</th>
<th scope="col" style="width:200px;">交易方</th>
<th scope="col" style="width:130px;">交易状态</th>
<th scope="col" style="width:125px;">操作</th>
<th scope="col" style="width:40px;">详情</th>
</tr>
<asp:Repeater ID="RptOrder" runat="server">
<ItemTemplate>
<tr onmouseover="this.style.backgroundColor='#F4F7FB';" onmouseout="this.style.backgroundColor='#ffffff';">
<td style="width:3px; height:50px;"></td>
<td style="width:130px;"><a href="view.aspx?orderid=<%#Eval("order_code")%>" target="_blank"><%#Eval("order_code")%></a></td>
<td style="width:110px;"><%#Convert.ToDateTime(Eval("date_create")).ToString("yyyy-MM-dd")%> <%#Convert.ToDateTime(Eval("date_create")).ToString("HH:mm")%>　</td>
<td style="width:200px;"><div style="width:180px; overflow: hidden; text-overflow:ellipsis;"><nobr>货主：<a href="/company/<%#setkey(Eval("aid").ToString())%>/" target="_blank"><%#Eval("aname")%></a></nobr></div><div style="width:180px; overflow: hidden; text-overflow:ellipsis;"><nobr>货代：<a href="/company/<%#setkey(Eval("bid").ToString())%>/" target="_blank"><%#Eval("bname")%></a></nobr></div></td>
<td style="width:130px;"><%#Eval("status_name")%></td>
<td style="width:125px;"><%#Eval("op").ToString().Replace("{1}",Eval("order_code").ToString())%>&nbsp;</td>
<td style="width:40px;"><a href="detail.aspx?orderid=<%#Eval("order_code")%>" target="_blank">详情</a></td>
</tr>
</ItemTemplate>
</asp:Repeater>		

</table>

<div style="display:none;">

<asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
<asp:Button ID="btnAcceptCheck6" runat="server" Text="通过审核6" OnClick="btnAcceptCheck6_Click" />
<asp:Button ID="btnRejectCheck6" runat="server" Text="不通过审核6" OnClick="btnRejectCheck6_Click" />
<asp:Button ID="btnAcceptCheck7" runat="server" Text="通过审核7" OnClick="btnAcceptCheck7_Click" />
<asp:Button ID="btnRejectCheck7" runat="server" Text="不通过审核7" OnClick="btnRejectCheck7_Click" />
<asp:Button ID="btnAcceptCheck8" runat="server" Text="通过审核8" OnClick="btnAcceptCheck8_Click" />
<asp:Button ID="btnRejectCheck8" runat="server" Text="不通过审核8" OnClick="btnRejectCheck8_Click" />
<asp:Button ID="btnAcceptCheck9" runat="server" Text="通过审核9" OnClick="btnAcceptCheck9_Click" />
<asp:Button ID="btnRejectCheck9" runat="server" Text="不通过审核9" OnClick="btnRejectCheck9_Click" />

</div>
<asp:Timer ID="Timer1" runat="server" Interval="60000" OnTick="Timer1_Tick">
</asp:Timer>
</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
<ProgressTemplate>
<div style="position:absolute; top:100px; left:200px; border:1px solid #999999; background:#FFFFFF; text-align:center; padding:10px;">
正在处理，请稍候...<br/>
<img src="/member/images/loading5.gif" alt=""/>
</div>
</ProgressTemplate>
</asp:UpdateProgress>	
</div>
</div>
</div>
</div>			
</div>
<adminbottom:adminbottom ID="adminbottom1" runat="server" />
</div>
</div>

</form>
</body>
</html>
