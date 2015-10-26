<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cargo_detail.aspx.vb" Inherits="search_cargo_detail" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="货盘，货代" /></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="环球运费网提供最新最全面的国际货盘信息查询与发布" /></asp:Literal>
<asp:Literal id="Literal1" runat="server"><title>货盘信息-环球运费网</title></asp:Literal>
<link href="/css/fcl1210.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>    
<div class="main"><!--页面主体开始-->	
<usernewtop1209:usernewtop1209 ID="usernewtop12091" runat="server" />
<div class="notice" style="margin:12px 0 0 0;">你怎么还在找货盘？货主们都在“安运通”订舱了，赶紧去申请吧</div>
<div class="info_box">
<div class="info_left">
<h1>该条货盘被<span class="red"><asp:Label ID="Label22" runat="server" Text="Label"></asp:Label></span>人浏览过
<a href="/member/cargoselect.aspx" target="_blank"><img src="/images/fcl/w_bt.gif" style="margin-left:300px;" border=0 style="display:none;"  /></a>
</h1>
<ul>
<li><span class="blue2">货盘标题</span>：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></li>
<li><span class="blue2">发布时间</span>：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></li>
<li>截止时间<span class="blue2"></span>：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></li>
<li>货盘类型<span class="blue2"></span>：<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></li>
<li><span class="blue2">货物名称</span>：<asp:Label ID="Label17" runat="server" Text="Label"></asp:Label></li>
<li><span class="blue2">货物类型</span>：<asp:Label ID="Label18" runat="server" Text="Label"></asp:Label></li>
<li>货物数量<span class="blue2"></span>：<asp:Label ID="Label19" runat="server" Text="Label"></asp:Label></li>
<li>&nbsp;&nbsp;起运港<span class="blue2"></span>：<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></li>
<li>&nbsp;&nbsp;目的港<span class="blue2"></span>：<asp:Label ID="Label16" runat="server" Text="Label"></asp:Label></li>
<li>航线描述<span class="blue2"></span>：<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></li>
<li>支付方法<span class="blue2"></span>：<asp:Label ID="Label20" runat="server" Text="Label"></asp:Label></li>
<li>&nbsp;&nbsp;危险品<span class="blue2"></span>：<asp:Label ID="Label21" runat="server" Text="Label"></asp:Label></li>
<li style="width:590px; border:none; line-height:">&nbsp;&nbsp;&nbsp;&nbsp;备注：<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></li>
</ul>
</div>
<div class="info_right">
<h2><asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></h2>
<div id="pic"><img id="imghead" src="/search/images/fcl/people.GIF" runat="server" width="78" height="78" /></div>
<div class="name"><img src="/images/fcl/women.gif" />&nbsp;<asp:Label ID="Label15" runat="server" Text="Label"></asp:Label><br />
<asp:PlaceHolder ID="PlaceHolder2" runat="server">  
<asp:Label ID="Label25" runat="server"></asp:Label><br />
<a href="#"><img style="margin-top:6px;" src="/images/fcl/bot_2.jpg" border="0" /></a>
</asp:PlaceHolder>
</div>
<asp:Panel ID="Panel3" runat="server">
<div class="details_info">
<ul>
<table width="100%" border="0" cellspacing="1" cellpadding="0">
<tr>
<td width="40%" height="23">&nbsp;</td>
</tr>
<tr>
<td width="40%" height="23" align="center"><span class="blue bold">想查看该用户联系方式请 <a href="/accounts/login.aspx"><span class="red">立即登陆</span></a></span></td>
</tr>
<tr>
<td width="40%" height="23" align="center"><span class="blue bold">如您还不是环球运费网会员请</span></td>
</tr>
<tr>
<td width="40%" height="23"><a href="/accounts/reg.aspx"><img src="/images/login/bt2.GIF" width="128" height="35" border="0" /></a></td>
</tr>
<tr>
<td width="40%" height="23">&nbsp;</td>
</tr>
<tr>
<td width="40%" height="23">&nbsp;</td>
</tr>
<tr>
<td height="23"><a href="#"></a></td>
</tr>
</table>
</ul>
</div> 
</asp:Panel>
<asp:Panel ID="Panel1" runat="server">
<div class="details_info" style="border:none; margin-top:0px;">
<ul>
<li>电 话：<asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></li>
<li>手 机：<asp:Label ID="Label11" runat="server" Text="Label"></asp:Label> </li>
<li>email：<asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></li>
<li>地 址：<asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></li>
<li>邮 编：<asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></li>
<li>客户评价：<a href="#"><asp:Label ID="LabCommentCount" runat="server" Text="Label"></asp:Label></a>条&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发布运价：<a href="#"><asp:Label ID="LabYunjiaCount" runat="server" Text="Label"></asp:Label></a>条</li>							
</ul>
</div>
<div class="details_info">
<ul>
<li style="line-height:20px;"><asp:Label ID="Label27" runat="server"></asp:Label></li>
</ul>
</div>
</asp:Panel>
</div>
</div>		
<userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
</form>
</body>
</html>
