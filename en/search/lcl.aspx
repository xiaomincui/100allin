<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lcl.aspx.vb" Inherits="en_search_lcl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>100allin.com-The biggest freight rate web in the world</title>
<link href="/en/css/fcl_list.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="/js/autocomplete/port_en.js"></script>
</head>

<body>
<form id="form1" runat="server" autocomplete="off">
<script type='text/javascript'>document.getElementById('form1').action = window.location.href;</script>
<div class="main" id="main">
<div class="head">
<div class="top_box">
<div class="solo">Welcome！Jason</div>
<div class="top_links"><img src="/en/images/fcl/exit.gif" width="16" height="16" /><a href="#" target="_blank">Exit</a></div>
</div>
<div class="head_mid">
<div id="logo"><a href="#"><img src="/en/images/index/logo.gif" border="0" /></a></div>
<div class="search_bar">
<div class="login_box">
<a href="#"><img src="/en/images/fcl/list_ico6.gif" />live help</a><br /><a><img src="/en/images/fcl/list_ico5.gif" />0086+02151086987</a><br />
</div>
<div class="login_box" style="border-right:1px dotted #666;">
<a href="#"><img src="/en/images/fcl/list_ico7.gif" />login</a><br />
<a href="#"><img src="/en/images/fcl/list_ico7.gif" />Office</a>
</div>
</div>
</div>
<div class="nav">
<ul>
<li><a href="/en/">Home</a></li>
<li class="divider"></li>
<li><a href="/en/fcl/">FCL Freight</a></li>
<li class="divider"></li>
<li class="st"><a href="/en/lcl/">LCL Freight</a></li>
<li class="divider"></li>
<li><a href="/en/air/">Air Freight</a></li>
<li class="divider"></li>
<li><a href="/en/surcharge/">Surcharge</a></li>
<li class="divider"></li>
<li><a href="/en/cooperation/">Cooperation</a></li>
<li class="divider"></li>
<li><a href="/en/company/">Company</a></li>
</ul>
</div>
<div class="search">
<div class="search_mid">
<div class="search_bar_b">
<div class="sear_top"><table width="100%" border="0" cellspacing="1" cellpadding="0">
<tr>
<td width="3%"><img src="/en/images/fcl/fcl_ico.gif" /></td>
<td width="6%"><strong>Line</strong>&nbsp;: </td>
<td width="13%">
<asp:HiddenField ID="hidType" runat="server" Value="fcl" />
<asp:HiddenField ID="hidStartport" runat="server" Value="" />
<asp:HiddenField ID="hidDestport" runat="server" Value="" />
<asp:HiddenField ID="hidCarrier" runat="server" Value="" />
<asp:HiddenField ID="hidLine" runat="server" Value="0" />
<asp:DropDownList ID="txtLine" runat="server" Width=105 Font-Size="12px">
<asp:ListItem Value="">All</asp:ListItem>
<asp:ListItem Value="美加线">North America</asp:ListItem>
<asp:ListItem Value="欧地线">Euro/Med</asp:ListItem>
<asp:ListItem Value="中南美线">Middle/South America</asp:ListItem>
<asp:ListItem Value="日韩线">Japan and Korea</asp:ListItem>
<asp:ListItem Value="近洋线">Southeast Asia</asp:ListItem>
<asp:ListItem Value="非洲线">Africa</asp:ListItem>
<asp:ListItem Value="澳洲线">Australia</asp:ListItem>
<asp:ListItem Value="中东印巴线">Middle East</asp:ListItem>
<asp:ListItem Value="红海线">Red Sea</asp:ListItem>
</asp:DropDownList>
</td>
<td width="6%" align="right"><strong>Pol</strong> :&nbsp;</td>
<td width="11%"><asp:TextBox ID="txtStartport" runat="server" Width="90px" sou_type="start_port"></asp:TextBox></td>
<td width="7%" align="right"><strong>Pod</strong> :&nbsp;</td>
<td width="11%"><asp:TextBox ID="txtDestport" runat="server" Width="90px" sou_type="end_port"></asp:TextBox></td>
<td width="13%" align="right"><strong>Ship Owner</strong> :&nbsp;</td>
<td width="11%"><asp:TextBox ID="txtCarrier" runat="server" Width="60px" sou_type="ship_com"></asp:TextBox></td>
<td width="19%" align="center" valign="middle"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/en/images/fcl/search.gif" width="128" height="28" border="0"  /></td>
</tr>
</table>
</div>
</div>
</div>
</div>
</div>

<div class="notice" style="padding:0px 0px 10px 20px; font-size:12px;"><p>
<span class="orange"><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></span> results		    
for：&nbsp;
<asp:Label ID="Label9" runat="server" Text="Carrier: "></asp:Label><b><asp:Label ID="hidTxtCarrier" runat="server" ></asp:Label></b>&nbsp;
<asp:Label ID="Label10" runat="server" Text="Startport: "></asp:Label><b><asp:Label ID="hidTxtStartport" runat="server" ></asp:Label></b>&nbsp;
<asp:Label ID="Label11" runat="server" Text="Destport: "></asp:Label><b><asp:Label ID="hidTxtDestport" runat="server" ></asp:Label></b>&nbsp;
<asp:Label ID="Label12" runat="server" Text="Line: "></asp:Label><b><asp:Label ID="hidTxtLine" runat="server" ></asp:Label></b>&nbsp;
</p>
</div>

<div class="main_page">
<div class="page_left">
<div class="list">
<div class="list_title"><span class="r"></span><a href="#">FCL Freight</a></div>
<ul>
<li><table width="640" height="42" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="10" height="42">&nbsp;</td>
<td width="65"><strong>Line</strong></td>
<td width="75"><strong>POL</strong></td>
<td width="65"><strong>POD</strong></td>
<td width="75"><strong>Price(m)</strong></td>
<td width="75"><strong>Price(v)</strong></td>
<td width="105"><strong>Carrier</strong></td>
<td width="90"><strong>Time</strong></td>
<td width="80"><strong>Company</strong></td>
</tr>
</table>
</li>
<asp:Repeater ID="Rptfcl" runat="server">
<ItemTemplate>
<li>
<table width="640" height="42" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="10" height="42">&nbsp;</td>
<td width="65" align="left"><%#GetFirstString(LineCNtoEN(Eval("hangxianmiaoshu").ToString), 4)%></td>
<td width="75" align="left"><%#GetFirstString(Eval("startport").ToString, 4)%></td>
<td width="65" align="left"><%#GetFirstString(Eval("destport").ToString, 4)%></td>
<td width="75" align="left" class="blue"><a href="/en/lcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#GetFirstString(Eval("pricegp").ToString, 4)%></a></td>
<td width="75" align="left" class="blue"><a href="/en/lcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#GetFirstString(Eval("pricegpv").ToString, 4)%></a></td>
<td width="105" align="left"><%#GetFirstString(Eval("shipcompany").ToString, 4)%></td>
<td width="90" align="left"><%#Format(Eval("postdate"), "MM").ToString%>/<%#Format(Eval("postdate"), "dd").ToString%> - <%#Format(CDate(Eval("enddate")), "MM").ToString%>/<%#Format(CDate(Eval("enddate")), "dd").ToString%></td>
<td width="80" align="left"><a href="/company/<%# key(eval("userid"))%>/" target="_blank" style="color:#666666;"><%#GetFirstString(Eval("EN_CompanyName").ToString, 4)%></a></td>
</tr>
</table>
</li>
</ItemTemplate>
</asp:Repeater>
<input id="Hidden1" runat="server" style="width: 1px" type="hidden" />		
<input id="Hiddennn1" runat="server" style="width: 1px" type="hidden" />
</ul>
<div class="page_head"><SPAN class=disabled style="margin:0px; padding:0px; line-height:27px; height:27px; border:none; color:#28385A; float:left;">
<asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label>/<asp:HiddenField ID="hidTotalPage" runat="server" Value="1" /><asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label>
</SPAN></div>
<div class="page">

<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
<asp:Label ID="hidSaveSearchWords" runat="server" Text="1" CssClass="hidden"></asp:Label>
To Page <input id="txtPageJump" name="txtPageJump" type="text" style=" width:20px; height:12px;" runat="server"/>  
<input id="btnPageJump" name="btnPageJump" type="button" value="确定" style=" width:40px; height:20px;" runat="server"/>

</span>
</div>
</div>
</div>
<div class="page_right">
<div class="list_right_box">
<h2><img src="/en/images/fcl/list_ico1.gif" />The Freght You Browsed</h2>
<a href="#">· Munich  specialises in intelligent</a><br />
<a href="#">· Munich  specialises in intelligent</a>
</div>
<div class="list_right_box">
<h2><img src="/en/images/fcl/list_ico2.gif" width="16" height="16" />The Freght You Searched</h2>
<a href="#">· Munich  specialises in intelligent</a><br />
<a href="#">· Munich  specialises in intelligent</a>
</div>
<div class="list_right_box">
<h2><img src="/en/images/fcl/list_ico3.gif" width="16" height="16" />The Latest Exchange</h2>
<asp:Literal ID="ltrTotalSurcharge" runat="server"></asp:Literal>
</p>
</div>
<div class="list_right_box">
<h2><img src="/en/images/fcl/list_ico4.gif" width="16" height="16" />Translation  On Line</h2>
<textarea name="" cols="20" rows="3"></textarea>
<input style="margin-top:8px;" type="submit" name="Submit" value="提交" />
</div>
</div>
<div class="foot"><a href="#">About Us</a>︱<a href="#">Privacy Policy</a>︱<a href="#">Terms Of Use Agreement</a>︱ <a href="#">Site Map</a>︱<a href="#">Contact Us</a></div>
</div>
</div>
</form>
</body>
</html>
