﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="air_detail.aspx.vb" Inherits="search_air_detail" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal1" runat="server"><title>空运运价-环球运费网</title></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="空运运价-环球运费网" /></asp:Literal>
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="空运运价-环球运费网" /></asp:Literal>
<link href="/css2/fcl.css" rel="stylesheet" type="text/css" /> 
<script type="text/javascript" src="/js/MSClass.js"></script>
</head>
<body>
<form id="form1">
<div class="h_box">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_1" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_1" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_1" runat="server" />
</div>
<div class="main"><!--页面主体开始-->	

<asp:Panel ID="Panel2" runat="server"  Visible="false">
<div class="main_content"><!--中部开始-->
<div class="" style="background:url(/images/fcl/info_bg.gif) no-repeat left top;"><!--左边开始-->
<div style="clear:both;">
<table width="92%" border="0" align="center" cellpadding="0" cellspacing="1" style="background:url(/images/fcl/33.gif) no-repeat right 65px;">
<tr><td height="10" align="center"></td></tr>
<tr><td height="32" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images/fcl/jt2.gif" />&nbsp;<strong>环球运费网提示</strong></div></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>								
<tr><td height="28" align="left" style="line-height:18px; font-size:14px;">
以下为该条运价预览效果</td></tr>
</table>
<br/><br/><br/><br/>
</div>
</div>
</div>  
</asp:Panel>

<asp:Panel ID="Panel4" runat="server" Visible="false">
<div class="main_content"><!--中部开始-->
<div class="" style="background:url(/images/fcl/info_bg.gif) no-repeat left top;"><!--左边开始-->
<div style="clear:both;">
<table width="92%" border="0" align="center" cellpadding="0" cellspacing="1" style="background:url(/images/fcl/33.gif) no-repeat right 65px;">
<tr><td height="10" align="center"></td></tr>
<tr><td height="32" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images/fcl/jt2.gif" />&nbsp;<strong>环球运费网提示</strong></div></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>								
<tr><td height="28" align="left" style="line-height:18px; font-size:14px;">亲爱的用户，该运价已被删除或不存在，请点击以下地址，查询更多运价<br/><a href="/air/">http://www.100allin.com/air/</a></td></tr>
</table>
<br/><br/><br/><br/>
</div>
</div>
</div>        
</asp:Panel>  
<asp:Panel ID="Panel5" runat="server" Visible="false">
<div class="main_content"><!--中部开始-->
<div class="" style="background:url(/images/fcl/info_bg.gif) no-repeat left top;"><!--左边开始-->
<div style="clear:both;">
<table width="92%" border="0" align="center" cellpadding="0" cellspacing="1" style="background:url(/images/fcl/33.gif) no-repeat right 65px;">
<tr><td height="10" align="center"></td></tr>
<tr><td height="32" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images/fcl/jt2.gif" />&nbsp;<strong>环球运费网提示</strong></div></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>								
<tr><td height="28" align="left" style="line-height:18px; font-size:14px;"><asp:Label ID="Label28" runat="server" Text=""></asp:Label></td></tr>
</table>
<br/><br/><br/><br/>
</div>
</div>
</div>        
</asp:Panel>
<asp:Panel ID="Panel6" runat="server">
<div class="info_box">
<div class="info_left">
<h1><asp:Label ID="Label1" runat="server" Text="运价标题"></asp:Label></h1>
<ul>
<li>运价类型：<asp:Literal ID="Literal4" runat="server"></asp:Literal></li>
<li>航线描述：<asp:Literal ID="Literal6" runat="server"></asp:Literal></li>
<li style="word-wrap: break-word; word-break: normal;">&nbsp;&nbsp;起运港：<asp:Literal ID="Literal5" runat="server"></asp:Literal></li>
<li style="word-wrap: break-word; word-break: normal;">&nbsp;&nbsp;目的港：<asp:Literal ID="LabDestport" runat="server"></asp:Literal></li>
<li>发布时间：<asp:Literal ID="ltrPostDate" runat="server"></asp:Literal></li>
<li>截止时间：<asp:Literal ID="ltrEndDate" runat="server"></asp:Literal></li>
<li style="width:580px;">
<div class="blue_box_air">
<span class="air_jg"><table width="100%" border="0" cellpadding="0" cellspacing="1" bordercolor="#3E8EFF">
<tr>
<td width="13%" align="center">M</td>
<td width="13%" align="center">N</td>
<td width="13%" align="center">+45</td>
<td width="13%" align="center">+100</td>
<td width="13%" align="center">+300</td>
<td width="13%" align="center">+500</td>
<td width="13%" align="center">+1000</td>
</tr>
<tr>
<td align="center"><a><asp:Literal ID="LabM" runat="server"></asp:Literal></a></td>
<td align="center"><a><asp:Literal ID="LabN" runat="server"></asp:Literal></a></td>
<td align="center"><a><asp:Literal ID="Lab45" runat="server"></asp:Literal></a></td>
<td align="center"><a><asp:Literal ID="Lab100" runat="server"></asp:Literal></a></td>
<td align="center"><a><asp:Literal ID="Lab300" runat="server"></asp:Literal></a></td>
<td align="center"><a><asp:Literal ID="Lab500" runat="server"></asp:Literal></a></td>
<td align="center"><a><asp:Literal ID="Lab1000" runat="server"></asp:Literal></a></td>
</tr>
</table></span>
</div>		      			      
</li>
<li>&nbsp;&nbsp;<span class="blue2">附加费</span>：<asp:Literal ID="LabPlus" runat="server"></asp:Literal></li>
<li>&nbsp;&nbsp;<span class="blue2"></span><asp:Literal ID="Labshipcompany" runat="server"></asp:Literal></li>
<li>&nbsp;&nbsp;<span class="blue2">出发日</span>：<asp:Literal ID="LabDepartureWkd" runat="server"></asp:Literal></li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;<span class="blue2">航程</span>：<asp:Literal ID="LabDistance" runat="server"></asp:Literal></li>
<asp:PlaceHolder ID="PlaceHolder5" runat="server">
<li id="bttj" style="margin-top:20px; font-size:14px;">
<asp:Literal ID="Literal20" runat="server"></asp:Literal>
</li>
</asp:PlaceHolder>
</ul>
</div>
<div class="info_right">
<h2><asp:Literal ID="Literal8" runat="server"></asp:Literal></h2>
<div id="pic"><img id="imghead" src="/images/fcl/people.GIF" runat="server" width="76" height="76" /></div>
<div class="name"><img src="/images/fcl/women.gif" />&nbsp;<asp:Label ID="Label15" runat="server" Text=""></asp:Label><br />
<asp:PlaceHolder ID="PlaceHolder3" runat="server">
<asp:Literal ID="Literal25" runat="server"></asp:Literal><br />
<asp:Literal ID="Literal26" runat="server"></asp:Literal>
</asp:PlaceHolder>
</div>
<asp:Panel ID="Panel3" runat="server">
<div class="details_info">
<ul style="height:150px; text-align:center; padding-top:30px">
<li>
<span class="blue bold">想查看该用户联系方式请 <a href="/accounts/login.aspx"><span class="red">立即登陆</span></a></span>
</li>
<li>
<span class="blue bold">如您还不是环球运费网会员请</span>
</li>
<li>
<a href="/accounts/reg.aspx"><img src="/images/login/bt2.GIF" width="128" height="35" border="0" /></a>
</li>
</ul>
</div>
</asp:Panel>  
<asp:Panel ID="Panel1" runat="server">  
<div class="details_info" style="border:none; margin-top:0px;">
<ul>
<li>电 话：<asp:Label ID="Label9" runat="server" Text=""></asp:Label></li>
<li>手 机：<asp:Label ID="Label11" runat="server" Text=""></asp:Label> </li>
<li>email：<asp:Label ID="Label12" runat="server" Text=""></asp:Label></li>
<li>地 址：<asp:Label ID="Label13" runat="server" Text=""></asp:Label></li>
<li>邮 编：<asp:Label ID="Label14" runat="server" Text=""></asp:Label></li>
</ul>
</div>
<div class="details_info">
<ul>
<li>客户评价：<asp:Label ID="LabCommentCount" runat="server" Text="" ForeColor="OrangeRed" Font-Bold="true"></asp:Label>条&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%--发布运价：<asp:Label ID="LabYunjiaCount" runat="server" Text="" ForeColor="OrangeRed" Font-Bold="true"></asp:Label>条--%></li>
<li>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="26%">在线联系：</td>
<td width="11%"><asp:Literal ID="Literal29" runat="server"></asp:Literal></td>
<td width="63%"><asp:Literal ID="Literal30" runat="server"></asp:Literal></td>
<td width="11%"><asp:Label ID="Label29" runat="server" Text=""></asp:Label></td>
<td width="63%"><asp:Label ID="Label30" runat="server" Text=""></asp:Label></td>
</tr>
</table>
</li>
</ul>
</div>
</asp:Panel>  
</div>
</div>
				
<div class="info_other">
<table id="pd" cellspacing="0" cellpadding="0" width="100%"  border="0">
<tbody>
<tr>
<td colspan="15" align="left"><h2><asp:Label ID="Label27" runat="server" Text=""></asp:Label></h2></td>
</tr>
<tr>
<td colspan="15" align="left" style="background: url(/images/fcl/qit2.gif) repeat-x top; line-height:20px; padding:9px 0 9px 6px;word-break:break-all;">目的港：<%=IIf(ddest.ToString = "", "<b style=""color:#ff6600"">全部</b>&nbsp;", "<a href=""/air/" & GetQueryString("yid") & "_0.html"">全部</a>")%><asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate><%#IIf(Eval("destport").ToString() = ddest.ToString, "<b style=""color:#ff6600"">" & Eval("destport").ToString() & "</b>&nbsp;", "<a href=""/air/" & key(Eval("sid")) & "_" & JingHao(Eval("destport").ToString) & ".html"">" & Eval("destport").ToString() & "</a>")%></ItemTemplate></asp:Repeater>
</td>
</tr>
<tr style="background-image:url(/images/fcl/fjf_bg1.gif)">
<td width="13%" height="26" class="blue2"><strong>目的港</strong></td>
<td width="7%"><strong>M</strong></td>
<td width="7%"><strong>N</strong></td>
<td width="7%"><strong>+45</strong></td>
<td width="7%"><strong>+100</strong></td>
<td width="7%"><strong>+300</strong></td>
<td width="7%"><strong>+500</strong></td>
<td width="7%"><strong>+1000</strong></td>                                                                  
<td width="10%"><strong>附加费</strong></td>
<td width="5%"><strong>航程</strong></td>
<td width="5%"><strong>出发日</strong></td>
<td width="12%"><strong>备注</strong></td>              
<td width="6%"><strong>继续搜</strong></td>
</tr>
<asp:Repeater ID="RptYunjia" runat="server">
<ItemTemplate>                    
<tr>
<td height="32" ><div class="tmb1"><%#Eval("destport") %></div></td>
<td><%#Eval("PRICE_M")%></td>
<td><%#Eval("PRICE_N")%></td>
<td><%#Eval("PRICE_P45")%></td>
<td><%#Eval("PRICE_P100")%></td>
<td><%#Eval("PRICE_P300")%></td>
<td><%#Eval("PRICE_P500")%></td>
<td><%#Eval("PRICE_P1000")%></td>                                            
<td><%#Eval("price20gpAppend") %></td>
<td><%#Eval("Distance")%></td>
<td><%#Eval("DepartureWkd")%></td>
<td><%#Eval("memo")%></td>
<td><a href="/fcl/list-<%#Eval("startport1")%>-<%#Eval("destport") %>--0-0-0-----1.html" target="_blank">
<img src="/images/fcl/c_search.gif" border=0 alt="从<%#Eval("startport1")%>到<%#Eval("destport") %>更多运价" />
</a></td>
</tr>
<tr style="display:<%#Every3(RptYunjia.Items.Count.ToString) %>">
<td height="1" colspan="15" bgcolor="#F3F3F3"></td>
</tr>
</ItemTemplate>
</asp:Repeater>
<tr>
<td height="25" colspan="15" align="left" style="line-height:20px; background:#F7FDFD; border-top:1px solid #CAE7EF; "><DIV class="page clearfix" style="TEXT-ALIGN: right">
<span id="fen">共 
<asp:Literal ID="ltrTp" runat="server"></asp:Literal> 页 <asp:Literal ID="ltrTi" runat="server"></asp:Literal> 条结果
<asp:Literal ID="ltrPage" runat="server" Visible="false"></asp:Literal></span>
<asp:Literal ID="ltrPage2" runat="server"></asp:Literal>
</DIV></td>
</tr>               
<tr>
<td colspan="15" align="left" style="line-height:20px; background:#F7FDFD; border-bottom:1px solid #CAE7EF; border-top:1px solid #CAE7EF; padding:6px 0 6px 6px;">
<span class="gray"><img src="/images/fcl/gt.gif" width="14" height="13" /> 备注：<asp:Literal ID="LabMemo" runat="server"></asp:Literal></span></td>
</tr>
</tbody>
</table>
</div>
<asp:PlaceHolder ID="phOrder" runat="server" Visible="false">
<div class="fcl_rd"><table id="Table3" cellspacing="0" cellpadding="0" width="100%"  border="0">
<tbody>
<tr>
<td colspan="11" align="left" style="background: url(/images/fcl/qit2.gif) repeat-x top; line-height:20px; padding:9px 0 9px 15px; font:14px '宋体';"><img src="/images/fcl/LedIcon_306.GIF" /> <strong>该公司订舱记录</strong></td>
</tr>
<tr>
<td height="5" colspan="11" align="left"></td>
</tr>
<tr>
<td width="16%" height="26" background="/images/fcl/fjf_bg1.gif" class="blue_1"><strong>日期</strong></td>
<td width="12%" background="/images/fcl/fjf_bg1.gif" class="blue_1"><strong>运输方式</strong></td>
<td width="12%" background="/images/fcl/fjf_bg1.gif" class="blue_1"><strong>订舱状态</strong></td>
<td width="12%" background="/images/fcl/fjf_bg1.gif" class="blue_1"><strong>成交对象</strong></td>
<td width="36%" background="/images/fcl/fjf_bg1.gif" class="blue_1"><strong>相关运价</strong></td>
<td width="12%" background="/images/fcl/fjf_bg1.gif" class="blue_1"><strong>评价</strong></td>
</tr>
<asp:Repeater ID="RptOrder" runat="server">
<ItemTemplate>                     
<tr>
<td height="28"><%#Eval("date_create")%></td>
<td><%#GetFreightType(Eval("freight_type"))%></td>
<td><%#Eval("status_name_forward")%></td>
<td><%#Eval("RealName")%></td>
<td><%#Eval("price_title")%></td>
<td><%#GetPingType(Eval("yiping_forward"), Eval("ping_forward"))%></td>
</tr>
</ItemTemplate>
</asp:Repeater>
<asp:PlaceHolder ID="phNoOrder" runat="server" Visible="false">
<tr><td colspan="6" align="center"><div style="margin-top:10px;">暂无订舱记录</div></td></tr>
</asp:PlaceHolder>                
</tbody>
</table>
</div>	 
<userbottomline:userbottomline id="userbottomline2" runat="server"/>	  
</asp:PlaceHolder>	  

<asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
<div class="other_list">
<h1><asp:Label ID="Label17" runat="server" Text=""></asp:Label><asp:Label ID="Label18" runat="server" Text=""></asp:Label></h1>
<div class="other_list_left">
<h2><strong>相关空运运价</strong><asp:Literal ID="ltrXgLink1" runat="server"></asp:Literal></h2>
<div class="other_list_box">
<table width="100%" border="0" cellpadding="3" cellspacing="0" bgcolor="#CAE7F0">  
<tr bgcolor="#E9F3F8" height=28>
<td width="25%">标题</td>
<td width="8%">+45</td>
<td width="8%">+100</td>
<td width="8%">+300</td>
<td width="8%">+500</td>
<td width="8%">+1000</td>
<td width="15%">发布/截止日期</td>
<td width="20%">发布公司</td>
</tr>
<asp:Repeater ID="RptOtherDestport" runat="server">
<ItemTemplate>
<tr bgcolor="#FFFFFF" height=28 style="color:#333333;">
<td><a href="/air/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#GetFirstString(Eval("title").ToString, 34)%></a></td>
<td><%#GetFirstString(Eval("price_p45").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price_p100").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price_p300").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price_p500").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price_p1000").ToString, 5)%></td>
<td><%#Format(Eval("postdate"), "MM-dd").ToString%> 到 <%#Format(Eval("enddate"), "MM-dd").ToString%></td>
<td><a href="/company/<%# key(eval("userid")) %>/" target="_blank"><%#GetFirstString(Eval("companyname").ToString, 24)%></a></td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>

</div>
</div>
</div>
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
<div class="other_list">
<h1><asp:Label ID="Label20" runat="server" Text=""></asp:Label><asp:Label ID="Label22" runat="server" Text=""></asp:Label></h1>
<div class="other_list_left">
<h2><strong>相关空运运价</strong><asp:Literal ID="ltrXgLink2" runat="server"></asp:Literal></h2>
<div class="other_list_box">
<table width="100%" border="0" cellpadding="3" cellspacing="0" bgcolor="#CAE7F0">
<tr bgcolor="#E9F3F8" height=28>
<td width="30%">标题</td>
<td width="15%">目的地</td>
<td width="8%">+45</td>
<td width="8%">+100</td>
<td width="8%">+300</td>
<td width="8%">+500</td>
<td width="8%">+1000</td>
<td width="15%">发布/截止日期</td>
</tr>
<asp:Repeater ID="RptOtherLine" runat="server">
<ItemTemplate>
<tr bgcolor="#FFFFFF" height=28 style="color:#333333;">
<td><a href="/air/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#GetFirstString(Eval("title").ToString, 28)%></a></td>
<td bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("destport").ToString, 6)%></td>
<td><%#GetFirstString(Eval("price_p45").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price_p100").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price_p300").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price_p500").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price_p1000").ToString, 5)%></td>
<td><%#Format(Eval("postdate"), "MM-dd").ToString%> 到 <%#Format(Eval("enddate"), "MM-dd").ToString%></td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>
</div>
</div>
<div class="other_list_right">
<h2><strong>相关优质货代公司</strong></h2>
<ul>
<asp:Repeater ID="RptFreightLine" runat="server">
<ItemTemplate>					
<li><a href="/company/<%#Key(Eval("UserID"))%>/" target="_blank"><%#GetFirstString(Eval("CompanyName").ToString, 26)%></a> <%#Star1(Eval("star_allin").ToString)%></li>
</ItemTemplate>
</asp:Repeater>	
</ul>
</div>			  
</div>
</asp:PlaceHolder>
</asp:Panel>
<userbottomline:userbottomline id="userbottomline1" runat="server"/>
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div><!--页面主体结束-->	
</form>
</body>
</html>
