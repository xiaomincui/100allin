<%@ Page Language="VB" AutoEventWireup="false" CodeFile="air_need.aspx.vb" Inherits="search_air_need" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>空运缺失运价 - 环球运费网</title>
    <link href="/css/fcl1210.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main"><!--页面主体开始-->	
<usernewtop1209:usernewtop1209 ID="usernewtop12091" runat="server" />
<div class="main_content"><!--中部开始-->
<div class="search">
<div class="search_mid">
<div class="search_bar" style="border:none;">

</div>
<p>
起运港： <asp:Label ID="lblStartportHot" runat="server" Text=""></asp:Label><br />
目的港： <asp:Label ID="lblDestportHot" runat="server" Text=""></asp:Label><br />
</p>
</div>
</div>

<div class="notice"><p>
共找到<span class="orange"><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></span>条记录
<asp:Label ID="Label7" runat="server" Text="起运港："></asp:Label><b><asp:Label ID="hidTxtStartport" runat="server" ></asp:Label></b>&nbsp;&nbsp;
<asp:Label ID="Label13" runat="server" Text="目的港："></asp:Label><b><asp:Label ID="hidTxtDestport" runat="server" ></asp:Label></b>
</p>
</div>

<DIV class="menu2box">
<UL id="menu2">
<LI><A href="/search/fcl_need.aspx">整箱海运缺失运价</A></LI>
<LI><A href="/search/lcl_need.aspx">拼箱海运缺失运价</A></LI>
<LI class="hover"><A style="color:#05233B;" href="/search/air_need.aspx">空运缺失运价</A></LI>
</UL>
</DIV>
<DIV class="main2box"><div class="biaoti">
<table width="950" height="44" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="1" bgcolor="#CAC9C7"><img src="/images/fcl/biaoti_bg.gif" /></td>
<td background="/images/fcl/biaoti_bg2.gif"><table width="742" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="blue2"><table width="99%" height="38" border="0" cellpadding="0" cellspacing="1">
<tr>
<td width="1%" height="38" align="center">&nbsp;</td>
<td width="18%"><strong>搜索日期</strong></td>
<td width="16%"><strong>航线</strong></td>
<td width="16%"><strong>起运港</strong></td>
<td width="16%"><strong>目的港</strong></td>
<td width="16%"><strong>船公司</strong></td>
<td width="16%"><strong>添加这条运价</strong></td>
</tr>
</table></td>
</tr>
</table></td>
<td width="1" ><img src="/images/fcl/biaoti_bg3.gif" /></td>
</tr>
</table>
</div></DIV>
<div class="main_left"><!--左边开始-->
<div class="freight_List">
<div class="list_box">
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
<ul>
<li>
<table width="100%" height="38" border="0" cellpadding="0" cellspacing="1">
<tr>
<td width="2%" height="38" align="center">&nbsp;</td>
<td width="18%"><%#Eval("STIME")%></td>
<td width="16%"><%#Eval("LINE")%></td>
<td width="16%"><%#Eval("STARTPORT").ToUpper()%></td>
<td width="16%"><%#Eval("DESTPORT").ToUpper()%></td>
<td width="16%"><%#Eval("CARRIER").ToUpper()%></td>
<td width="16%"><a href="/member/AirRelease.aspx?startport=<%#Server.UrlEncode(Eval("STARTPORT").ToString)%>&destport=<%#Server.UrlEncode(Eval("DESTPORT").ToString)%>&hx=<%#Server.UrlEncode(Eval("LINE").ToString)%>&shipcompany=<%#Server.UrlEncode(Eval("CARRIER").ToString)%>" target="_blank">添加这条运价</a></td>
</tr>
</table>
</li>
</ul>
</ItemTemplate>
</asp:Repeater>  	
</div>
<DIV class=manu>
<SPAN class=disabled style="margin:0px; padding:0px; line-height:27px; height:27px; border:none; color:#28385A; float:left;">
<asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label>/<asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label><asp:HiddenField
ID="hidTotalPage" runat="server" />
</SPAN>
<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
<asp:Label ID="hidSaveSearchWords" runat="server" Text="1" CssClass="hidden"></asp:Label>
直接到第 <input id="txtPageJump" name="txtPageJump" type="text" style=" width:20px; height:12px;" runat="server"/> 页 
<input id="btnPageJump" name="btnPageJump" type="button" value="确定" style=" width:40px; height:20px;" runat="server"/>
</DIV>
</div>

</div>

<div class="main_right"><!--右边开始-->
<div class="right_boxs">
	<div class="right_boxs_title" style="background:#fff url(images/fcl/g1.GIF) repeat-x top;">
	  <h2><img src="/images/fcl/b3.gif" width="14" height="14" />最受关注的缺失运价</h2>
	</div>
	<ul>
	<asp:Repeater ID="RptHotFcl" runat="server">
	<ItemTemplate>	
	<li>[整箱] <%#Eval("STARTPORT")%>-<%#Eval("LINE")%> <a href="/member/Release.aspx?startport=<%#Server.UrlEncode(Eval("STARTPORT").ToString)%>&hx=<%#Server.UrlEncode(Eval("LINE").ToString)%>" target="_blank">发布</a></li>
	</ItemTemplate>
	</asp:Repeater>
	<asp:Repeater ID="RptHotLcl" runat="server">
	<ItemTemplate>	
	<li>[拼箱] <%#Eval("STARTPORT")%>-<%#Eval("LINE")%> <a href="/member/Release.aspx?startport=<%#Server.UrlEncode(Eval("STARTPORT").ToString)%>&hx=<%#Server.UrlEncode(Eval("LINE").ToString)%>" target="_blank">发布</a></li>
	</ItemTemplate>
	</asp:Repeater>	
	<asp:Repeater ID="RptHotAir" runat="server">
	<ItemTemplate>	
	<li>[空运] <%#Eval("STARTPORT")%>-<%#Eval("LINE")%> <a href="/member/Release.aspx?startport=<%#Server.UrlEncode(Eval("STARTPORT").ToString)%>&hx=<%#Server.UrlEncode(Eval("LINE").ToString)%>" target="_blank">发布</a></li>
	</ItemTemplate>
	</asp:Repeater>		
	</ul>
</div>
	

</div><!--右边结束-->			
<userbottomline:userbottomline ID="userbottomline1" runat="server" />
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div>
</div><!--页面主体结束-->	
    </form>
</body>
</html>
