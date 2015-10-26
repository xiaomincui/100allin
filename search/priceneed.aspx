<%@ Page Language="VB" AutoEventWireup="false" CodeFile="priceneed.aspx.vb" Inherits="search_priceneed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>及时商机 - 环球运费网</title>
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
&nbsp;&nbsp;航线： <asp:Label ID="lblLineHot" runat="server" Text=""></asp:Label><br/>
<span class="service">目的港：<asp:Label ID="lblDesportHot" runat="server" Text=""></asp:Label></span><br />
<asp:Literal ID="Literal4" runat="server"></asp:Literal>
船公司： <asp:Label ID="lblCarrierHot" runat="server" Text=""></asp:Label>
</p>
</div>
</div>

<div class="notice"><p>
共找到<span class="orange"><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></span>条记录
<asp:Label ID="Label6" runat="server" Text="种类："></asp:Label><b><asp:Label ID="hidTxtLine" runat="server" ></asp:Label></b>&nbsp;&nbsp;
<asp:Label ID="Label7" runat="server" Text="起运港："></asp:Label><b><asp:Label ID="hidTxtStartport" runat="server" ></asp:Label></b>&nbsp;&nbsp;
<asp:Label ID="Label13" runat="server" Text="目的港："></asp:Label><b><asp:Label ID="hidTxtDestport" runat="server" ></asp:Label></b>
</p>
</div>

<div class="freight_List">
<div id="Panel1" class="menu0box">
<UL id=menu0>
<LI class=hover onclick="window.location.href =('/company/RzBjSmRib29nakZEcnMzZjlmWEEwUT09/fcl')" style="display:;"><A style="color:#05233B;" href="/company/RzBjSmRib29nakZEcnMzZjlmWEEwUT09/fcl/">整箱缺失运价</A></LI>
<LI onclick="window.location.href =('/company/RzBjSmRib29nakZEcnMzZjlmWEEwUT09/lcl')" style="display:;"><A href="/company/RzBjSmRib29nakZEcnMzZjlmWEEwUT09/lcl/">拼箱缺失运价</A></LI>
<LI onclick="window.location.href =('/company/RzBjSmRib29nakZEcnMzZjlmWEEwUT09/air')" style="display:;"><A href="/company/RzBjSmRib29nakZEcnMzZjlmWEEwUT09/air/">空运缺失运价</A></LI>
</UL>
</div>
</div>

<div class="biaoti">
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
<td width="1"><img src="/images/fcl/biaoti_bg3.gif" /></td>
</tr>
</table>
</div>
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
<td width="16%"><%#Eval("STARTPORT")%></td>
<td width="16%"><%#Eval("DESTPORT")%></td>
<td width="16%"><%#Eval("CARRIER")%></td>
<td width="16%"><a href="/member/Release.aspx?startport=<%#Eval("STARTPORT")%>&destport=<%#Eval("DESTPORT")%>&carrier=<%#Eval("CARRIER")%>" target="_blank">添加这条运价</a></td>
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


<div class="ad" style="display:none;">
<a href="/topic/lcl090619/" target="_blank">
<img src="/images/index/home_lcl090619.gif" width="742" height="65" border="0" alt="拼箱知识大放送"/>
</a>
</div>	

</div>

<div class="main_right"><!--右边开始-->
<div class="right_boxs">
	<div class="right_boxs_title" style="background:#fff url(images/fcl/g1.GIF) repeat-x top;">
	  <h2><img src="/images/fcl/b3.gif" width="14" height="14" />最受关注的缺失运价</h2>
	</div>
	<ul>
	<li>1. [整箱] 上海-中东 <a href="#">发布</a></li>
	</ul>
</div>
<div class="assured">
<h2>&nbsp;</h2>
<ul>
	<asp:Repeater ID="RptOrder" runat="server">
	<ItemTemplate>						
	<li>·<a href="/company/<%# key(Eval("userid").ToString())%>/" target="_blank"><%#GetFirstString(Eval("companyname").ToString(),24)%></a></li>
	</ItemTemplate>
	</asp:Repeater>						
</ul>
<div class="assured_an"><a href="/topic/try20091215/" target="_blank"><img src="/images/company/assured_an.gif" width="159" height="38" border="0" /></a></div>
</div>
<div class="right_ad" style="margin-bottom:4px;"><a href="/topic/order20091104/product_1.aspx" target="_blank"><img src="/images/company/company_bt2.gif" width="200" height="47" border="0" /></a></div>			

</div><!--右边结束-->			
</div>
<userbottomline:userbottomline ID="userbottomline1" runat="server" />
<userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
    </form>
</body>
</html>
