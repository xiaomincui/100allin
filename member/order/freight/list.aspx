<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="pro_freight_list" EnableEventValidation="false" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
<title>整箱运价订舱</title>
<link href="../order/css/master.css" rel="stylesheet" type="text/css" />
<link href="../order/css/userlist.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div id="page">
<div id="center">
<protop:protop ID="protop1" runat="server" />
<div id="main">
<proleft:proleft ID="proleft1" runat="server" />										
<div id="right">
<div class="tt18 bd rightTitle">
<div class="text"><asp:Literal ID="ltrHeadTitle" runat="server"></asp:Literal></div>
</div>
<div class="rightArea txth22">
<div id="tipBoxSearch" class="tipBox">
<table border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="20">
<strong>选择港口：</strong>&nbsp;&nbsp;&nbsp;
<strong>上海</strong>&nbsp;&nbsp;&nbsp;
<a href="#">深圳</a>&nbsp;&nbsp;&nbsp;
<a href="#">天津</a>&nbsp;&nbsp;&nbsp;
<a href="#">宁波</a>&nbsp;&nbsp;&nbsp;
<a href="#">青岛</a>&nbsp;&nbsp;&nbsp;
<a href="#">大连</a>&nbsp;&nbsp;&nbsp;
<a href="#">连云港</a>&nbsp;&nbsp;&nbsp;
<a href="#">更多...</a>&nbsp;&nbsp;&nbsp;
</td>
</tr> 
</table>
</div>
<div class="listTable">
<div>					
<table cellspacing="0" cellpadding="3" rules="rows" bordercolor ="#D9D9D9" border="1" id="GridView1" style="border-width:1px;border-style:Solid;border-collapse:collapse;">
<tr style="background-color:#F0F0F0;">
<th scope="col" style="width:3px;"></th>
<th scope="col" style="width:250px;">主题</th>
<th scope="col" style="width:40px;">20'</th>
<th scope="col" style="width:40px;">40'</th>
<th scope="col" style="width:40px;">40H'</th>
<th scope="col" style="width:60px;">船公司</th>
<th scope="col" style="width:60px;">时限</th>
<th scope="col" style="width:180px;">发布公司</th>
<th scope="col" style="width:60px;">短信 订舱</th>
</tr>
<asp:Repeater ID="Rptfcl" runat="server">
<ItemTemplate>
<tr onmouseover="this.style.backgroundColor='#F4F7FB';" onmouseout="this.style.backgroundColor='#ffffff';">
<td style="width:3px;height:60px;"></td>
<td style="width:250px;"><a href="/fcl/<%# key(Eval("sid").ToString()) %>_<%# Eval("id") %>.html" target="_blank"><strong><%#GetFirstString(Eval("title").ToString(), 30)%></strong></a><br />
<%#Eval("startport").ToString()%> 至 <%#Eval("destport").ToString()%>&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("hangxianmiaoshu").ToString()%> 
</td>
<td style="width:40px;" style="color:#ff6600;"><strong><%#GetFirstString(Eval("price20gp").ToString(), 4)%></strong></td>
<td style="width:40px;" style="color:#ff6600;"><strong><%#GetFirstString(Eval("price40gp").ToString(), 4)%></strong></td>
<td style="width:40px;" style="color:#ff6600;"><strong><%#GetFirstString(Eval("price40hq").ToString(), 4)%></strong></td>
<td style="width:60px;"> <%#GetFirstString(Eval("shipcompany").ToString(), 5)%></td>
<td style="width:60px;"><%#Convert.ToDateTime(Eval("postdate").ToString()).ToString("MM-dd")%></td>
<td style="width:180px;"><a style="color:#3f7fb7;" href="/company/<%# key(Eval("userid").ToString())%>/" target="_blank"><strong><%#GetFirstString(Eval("companyname").ToString(), 24)%></strong></a>
<td style="width:60px;"><a href="/member/pm_detail.aspx?pid=1&cid=<%# Eval("userid") %>" target="_blank">短信</a>&nbsp;&nbsp;<a href="/pro/order/new.aspx?yid=<%# Eval("sid") %>" target="_blank" >订舱</a></td>
</td>
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
