<%@ Page Language="VB" AutoEventWireup="false" CodeFile="fcl_detail.aspx.vb" Inherits="search_fcl_detail" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal1" runat="server"><title>整箱海运运价-环球运费网</title></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="整箱海运运价-环球运费网" /></asp:Literal>
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="整箱海运运价-环球运费网" /></asp:Literal>
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
<tr><td height="28" align="left" style="line-height:18px; font-size:14px;">
亲爱的用户，该运价已被删除或不存在，请点击以下地址，查询更多运价<br/>
<a href="/fcl/">http://www.100allin.com/fcl/</a></td></tr>
</table>
<br/><br/><br/><br/>
</div>
</div>
</div>  
</asp:Panel>
<asp:Panel ID="Panel5" runat="server" Visible="false">
<div class="main_content"><!--中部开始-->
<div class="" style="background:url(/images/fcl/info_bg.gif) no-repeat left top;">
<div style="clear:both;">
<table width="92%" border="0" align="center" cellpadding="0" cellspacing="1" style="background:url(/images/fcl/33.gif) no-repeat right 65px;">
<tr><td height="10" align="center"></td></tr>
<tr><td height="32" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images/fcl/jt2.gif" />&nbsp;<strong>环球运费网提示</strong></div></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>
<tr><td height="10" align="center" ></td></tr>								
<tr><td height="28" align="left" style="line-height:18px; font-size:14px;">
<asp:Label ID="Label28" runat="server" Text=""></asp:Label></td></tr>
</table>
<br/><br/><br/><br/>
</div>
</div>
</div>        
</asp:Panel>
<asp:Panel ID="Panel6" runat="server">
<div class="info_box">
<div class="info_left">
<h1><asp:Literal ID="Label1" runat="server" Text="运价标题"></asp:Literal></h1>
<ul>
<li>运价类型：<asp:Literal ID="Literal4" runat="server"></asp:Literal></li>
<li>航线描述：<asp:Literal ID="Literal6" runat="server"></asp:Literal></li>
<li>&nbsp;&nbsp;起运港：<asp:Literal ID="Literal5" runat="server"></asp:Literal></li>
<li>&nbsp;&nbsp;目的港：<asp:Literal ID="LabDestport" runat="server"></asp:Literal></li>
<li>发布时间：<asp:Literal ID="ltrPostDate" runat="server"></asp:Literal></li>
<li>截止时间：<asp:Literal ID="ltrEndDate" runat="server"></asp:Literal></li>
<li style="width:580px;"><div class="blue_box"><span class="sju">20GP:<a><asp:Literal ID="Lab20GP" runat="server"></asp:Literal></a></span><span class="sju">40GP:<a><asp:Literal ID="Lab40GP" runat="server"></asp:Literal></a></span><span class="sju">40HQ:<a><asp:Literal ID="Lab40HQ" runat="server"></asp:Literal></a></span><span class="sju">45HQ:<a><asp:Literal ID="Lab45HQ" runat="server"></asp:Literal></a></span></div>
    <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible="true">
        <div class="blue_box"><asp:Literal ID="Literal21" runat="server"></asp:Literal> </div>
    </asp:PlaceHolder>
</li>
<li>&nbsp;&nbsp;附加费：<asp:Literal ID="LabPlus" runat="server"></asp:Literal></li>
<li>&nbsp;&nbsp;船公司：<asp:Literal ID="Labshipcompany" runat="server"></asp:Literal></li>
<li>&nbsp;&nbsp;出发日：<asp:Literal ID="LabDepartureWkd" runat="server"></asp:Literal></li>
<li>&nbsp;&nbsp;&nbsp;&nbsp;航程：<asp:Literal ID="LabDistance" runat="server"></asp:Literal></li>
<asp:PlaceHolder ID="PlaceHolder5" runat="server">
<li id="bttj" style="margin-top:20px; font-size:14px;">
<asp:Literal ID="Literal20" runat="server"></asp:Literal>
</li>
</asp:PlaceHolder>
</ul>
</div>
<asp:PlaceHolder ID="PlaceHolder8" runat="server">
<div class="info_right">
<h2><asp:Literal ID="Literal8" runat="server"></asp:Literal></h2>
<div id="pic"><img id="imghead" src="/images/fcl/people.GIF" runat="server" width="76" height="76" /></div>
<div class="name"><img src="/images/fcl/women.gif" width="16" height="16" />&nbsp;<asp:Label ID="Label15" runat="server" Text=""></asp:Label><br />
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
<li>电 话：<asp:Literal ID="Literal9" runat="server"></asp:Literal></li>
<li>手 机：<asp:Literal ID="Literal11" runat="server"></asp:Literal></li>
<li>email：<asp:Literal ID="Literal12" runat="server"></asp:Literal></li>
<li>地 址：<asp:Literal ID="Literal13" runat="server"></asp:Literal></li>
<li>邮 编：<asp:Literal ID="Literal14" runat="server"></asp:Literal></li>
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
</tr>
</table>
</li>
</ul>
</div>
</asp:Panel>  
</div>
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolder9" runat="server" Visible="false">
<div class="info_right">
<h2><a href="/company/RDdHMDRRVTdoMnVvMkMxQVFWMVRvZz09/" target="_blank" title="点击查看TA的商铺" style="color:293B5E">上海天极国际货运代理有限公司</a></h2>
<div id="pic"><img src="/member/Head/39.jpg" id="img1" width="76" height="76" /></div>
<div style="padding:10px 20px 0px 0px;overflow:hidden;line-height:22px;">地 址：上海市延安东路700号港泰广场2501-2503室
<br/>邮 编：200001
</div>  
<asp:Panel ID="Panel7" runat="server">  
<div class="details_info" style="border:none; margin-top:0px;">
<ul>
<li><a href="msnim:chat?contact=andy2eva@hotmail.com" ><img src="/images/fcl_s/msn.png" style="margin:0px" border=0 alt="Ta的MSN：andy2eva@hotmail.com" width='16' height='16'/></a> <b>王琦 先生</b></li>
<li>电 话：021-51089799*188</li>
<li>手 机：13916091722</li>
<li>Email：andy.wang@galax.com.cn</li>
<li>MSN：<a href="msnim:chat?contact=andy2eva@hotmail.com" >andy2eva@hotmail.com</a></li>
<li>&nbsp;</li>
<li><a href="msnim:chat?contact=sandywyq@hotmail.com" ><img src="/images/fcl_s/msn.png" style="margin:0px" border=0 alt="Ta的MSN：andy2eva@hotmail.com" width='16' height='16'/></a> <b>汪依菁 小姐</b></li>
<li>电 话：021-53850981</li>
<li>手 机：13601953827</li>
<li>Email：sandy.wang@galax.com.cn</li>
<li>MSN：<a href="msnim:chat?contact=sandywyq@hotmail.com" >sandywyq@hotmail.com</a></li>
</ul>
</div>
</asp:Panel>  
</div>
</asp:PlaceHolder>
</div>
 
	  
<div class="info_other">
<table id="pd" cellspacing="0" cellpadding="0" width="100%"  border="0">
<tbody>
<tr>
<td colspan="13" align="left"><h2>运价详情</h2></td>
</tr>
<tr>
<td colspan="13" align="left" style="background: url(http://img02.100allin.com/images2/fcl/qit2.gif) repeat-x top; line-height:20px; padding:9px 0 9px 6px;word-break:break-all;">目的港：<%=IIf(ddest.ToString = "", "<b style=""color:#ff6600"">全部</b>&nbsp;", "<a href=""/fcl/" & GetQueryString("yid") & "_0.html"">全部</a>")%><asp:Repeater ID="Repeater1" runat="server"><ItemTemplate><%#IIf(Eval("destport").ToString() = ddest.ToString, "<b style=""color:#ff6600"">" & Eval("destport").ToString() & "</b>&nbsp;", "<a href=""/fcl/" & key(Eval("sid")) & "_" & JingHao(Eval("destport").ToString) & ".html"">" & Eval("destport").ToString().ToUpper() & "</a>")%></ItemTemplate></asp:Repeater></td>
</tr>
<tr style="background-image:url(http://img02.100allin.com/images2/fcl/fjf_bg1.gif)">
<td width="24%" height="26"><strong>目的港</strong></td>
<td width="8%"><strong>20GP</strong></td>
<td width="8%"><strong>40GP</strong></td>
<td width="8%"><strong>40HQ</strong></td>
<td width="8%"><strong>45HQ</strong></td>
<td width="10%"><strong>附加费</strong></td>
<td width="10%"><strong>航程</strong></td>
<td width="6%"><strong>出发日</strong></td>
<td width="10%"><strong>船公司</strong></td>
<td width="10%"><strong>备注</strong></td>                                        
<td width="6%"><strong>继续搜</strong></td>
</tr>
<asp:Repeater ID="RptYunjia" runat="server">
<ItemTemplate>                    
<tr>
<td height="32"><%#Eval("destport").ToString.ToUpper %></td>
<td><%#Eval("price20gp")%></td>
<td><%#Eval("price40gp")%></td>
<td><%#Eval("price40hq")%></td>
<td><%#Eval("price45hq")%></td>
<td><%#Eval("price20gpAppend") %></td>
<td><%#Eval("Distance")%></td>
<td><%#Eval("DepartureWkd")%></td>
<td><%#Eval("shipcompany")%></td>
<td><%#Eval("memo")%></td>                                       
<td align="left" bgcolor="#ffffff"><a href="/fcl/list-<%#Eval("startport1")%>-<%#Eval("destport") %>--0-0-0-----1.html" target="_blank">
<img src="/images/fcl/c_search.gif" border=0 alt="从<%#Eval("startport1")%>到<%#Eval("destport") %>更多运价" width="40" height="19"/>
</a></td>
</tr>
<tr style="display:<%#Every3(RptYunjia.Items.Count.ToString) %>">
<td height="1" colspan="13" align="left" bgcolor="#F3F3F3"></td>
</tr>
</ItemTemplate>
</asp:Repeater>
<tr>
<td height="25" colspan="13" align="left" style="line-height:20px; background:#FFF8F8; border-top:1px solid #E0C5C5; "><DIV class="page clearfix" style="TEXT-ALIGN: right">
<span id="fen">共 
<asp:Literal ID="ltrTp" runat="server"></asp:Literal> 页 <asp:Literal ID="ltrTi" runat="server"></asp:Literal> 条结果
<asp:Literal ID="ltrPage" runat="server" Visible="false"></asp:Literal></span>
<asp:Literal ID="ltrPage2" runat="server"></asp:Literal>
</DIV></td>
</tr>                
<tr>
<td colspan="13" align="left" style="line-height:20px; background:#FFF8F8; border-bottom:1px solid #E0C5C5; border-top:1px solid #E0C5C5; padding:6px 0 6px 6px;">
<span class="gray"><img src="/images/fcl/gt.gif" width="14" height="13" /> 备注：<asp:Literal ID="LabMemo" runat="server"></asp:Literal></span></td>
</tr>
</tbody>
</table>
</div>
<asp:PlaceHolder ID="phOrder" runat="server" Visible="false">
<div class="fcl_rd"><table id="Table3" cellspacing="0" cellpadding="0" width="100%"  border="0">
<tbody>
<tr>
<td colspan="11" align="left" style="background: url(http://img02.100allin.com/images2/fcl/qit2.gif) repeat-x top; line-height:20px; padding:9px 0 9px 15px; font:14px '宋体';"><img src="/images/fcl/LedIcon_306.GIF" /> <strong>该公司订舱记录</strong></td>
</tr>
<tr>
<td height="5" colspan="11" align="left"></td>
</tr>
<tr>
	  <td height="1" colspan="6" align="left" bgcolor="#E0C5C5"></td>
</tr>
<tr>
<td width="16%" height="26" class="blue_1" bgcolor="#FFF8F8"><strong>日期</strong></td>
<td width="12%" class="blue_1" bgcolor="#FFF8F8"><strong>运输方式</strong></td>
<td width="12%" class="blue_1" bgcolor="#FFF8F8"><strong>订舱状态</strong></td>
<td width="12%" class="blue_1" bgcolor="#FFF8F8"><strong>成交对象</strong></td>
<td width="36%" class="blue_1" bgcolor="#FFF8F8"><strong>相关运价</strong></td>
<td width="12%" class="blue_1" bgcolor="#FFF8F8"><strong>评价</strong></td>
</tr>
<tr>
	  <td height="1" colspan="6" align="left" bgcolor="#E0C5C5"></td>
</tr>
<asp:Repeater ID="RptOrder" runat="server">
<ItemTemplate>                     
<tr>
<td height="28" align="left"><%#Eval("date_create")%></td>
<td><%#GetFreightType(Eval("freight_type"))%></td>
<td><%#Eval("status_name_forward")%></td>
<td><%#Eval("RealName")%></td>
<td><%#Eval("title")%></td>
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
   <asp:PlaceHolder ID="PlaceHolder7" runat="server">
<div class="info_other">
  <table id="Table1" cellspacing="0" cellpadding="0" width="100%"  border="0">
    <tbody>
      <tr>
        <td colspan="2" align="left"><h2>100allin推荐</h2></td>
      </tr>
      <tr>
              <td colspan="2" align="left" style="background: url(/images2/fcl/qit2.jpg) repeat-x top; line-height:28px; padding:15px 0 15px 10px; font:12px '宋体';"><span class="red_2"><strong>
                  <asp:Literal ID="Literal18" runat="server"></asp:Literal></strong></span><strong>至<span class="red_2"><asp:Literal
                      ID="Literal19" runat="server"></asp:Literal></span>优质服务：</strong></td>
      </tr>
<asp:Repeater ID="Repeater2" runat="server">
<ItemTemplate>
      <tr>
        <td align="left" width="28%"><a href="/company/<%#key(Eval("userid").ToString)%>/"><img src="/member/logos/<%#Eval("userid").ToString%>.jpg" width="230" height="48" border="0" /></a></td><td align="left" width="72%" style="font-size:14px;"> <a href="/fcl/<%#key(Eval("yunjiaid").ToString)%>_<%#Eval("id").ToString%>.html">20GP：<b style="color:Red;"><%#Eval("price20gp").ToString%></b> &nbsp;&nbsp;40GP：<b style="color:Red;"><%#Eval("price40gp").ToString%></b> &nbsp;&nbsp;40HQ：<b style="color:Red;"><%#Eval("price40hq").ToString%></b> &nbsp;&nbsp;船公司：<b style="color:Red;"><%#Eval("shipcompany").ToString%></b></a>&nbsp;&nbsp;TEL：<%#Eval("phone").ToString%>(<%#Eval("realname").ToString%>)</td>
      </tr>
</ItemTemplate>
</asp:Repeater>                 
    </tbody>
  </table>
</div>
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
<div class="other_list">
<h1><asp:Label ID="Label17" runat="server" Text=""></asp:Label><asp:Label ID="Label18" runat="server" Text=""></asp:Label></h1>
<div class="other_list_left">
<h2><strong>相关整箱运价</strong><asp:Literal ID="ltrXgLink1" runat="server"></asp:Literal></h2>
<div class="other_list_box">
<table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#CAE7F0">  
<tr>
<td height="1" colspan="9" align="center" bgcolor="#ACDAA8"></td>
</tr>
<tr bgcolor="#EEFAEE" height=28>
<td width="1%"></td>
<td width="29%">标题</td>
<td width="7%">20GP</td>
<td width="7%">40GP</td>
<td width="7%">40HQ</td>
<td width="7%">45HQ</td>
<td width="8%">船公司</td>
<td width="15%">发布/截止日期</td>
<td width="29%">发布公司</td>
</tr>
<tr>
<td height="1" colspan="9" align="center" bgcolor="#ACDAA8"></td>
</tr>
<asp:Repeater ID="RptOtherDestport" runat="server">
<ItemTemplate>                                                                                        
<tr bgcolor="#FFFFFF" height=28 style="color:#333333;">
<td height="32"></td>
<td><a href="/fcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#GetFirstString(Eval("title").ToString, 33)%></a></td>
<td><%#GetFirstString(Eval("price20gp").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price40gp").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price40hq").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price45hq").ToString, 5)%></td>
<td><%#GetFirstString(Eval("shipcompany").ToString, 6)%></td>
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
<h2><strong>相关整箱运价</strong><asp:Literal ID="ltrXgLink2" runat="server"></asp:Literal></h2>
<div class="other_list_box">
<table width="100%" border="0" cellpadding="3" cellspacing="0" bgcolor="#CAE7F0" >
<tr bgcolor="#E9F3F8" height=28>
<td width="34%">标题</td>
<td width="15%">目的港</td>
<td width="7%">20GP</td>
<td width="7%">40GP</td>
<td width="7%">40HQ</td>
<td width="7%">45HQ</td>
<td width="15%">发布/截止日期</td>
<td width="8%">船公司</td>
</tr>
<asp:Repeater ID="RptOtherLine" runat="server">
<ItemTemplate>
<tr bgcolor="#FFFFFF" height=28 style="color:#333333;">
<td><a href="/fcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#GetFirstString(Eval("title").ToString, 33)%></a></td>
<td><%#GetFirstString(Eval("destport").ToString, 7)%></td>
<td><%#GetFirstString(Eval("price20gp").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price40gp").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price40hq").ToString, 5)%></td>
<td><%#GetFirstString(Eval("price45hq").ToString, 5)%></td>
<td><%#Format(Eval("postdate"), "MM-dd").ToString%> 到 <%#Format(Eval("enddate"), "MM-dd").ToString%></td>
<td><%#GetFirstString(Eval("shipcompany").ToString, 6)%></td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>
</div>
</div>
<div class="other_list_right">
<h2><strong>推荐优势货代</strong></h2>
<ul><asp:Repeater ID="RptFreightLine" runat="server"><ItemTemplate><li><a href="/company/<%#Key(Eval("UserID"))%>/" target="_blank"><%#GetFirstString(Eval("CompanyName").ToString, 26)%></a> <%#Star1(Eval("star_allin").ToString)%></li></ItemTemplate></asp:Repeater></ul>
</div>			  
</div>
</asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder6" runat="server" Visible="false">
		<div class="info_other">
          <table id="pd" cellspacing="0" cellpadding="0" width="100%"  border="0">
            <tbody>
              <tr>
                <td width="100%" align="left"><h2>公司信息</h2></td>
              </tr>
              <tr>
                      <td colspan="11" align="left" style="background: url(/images2/fcl/qit2.jpg) repeat-x top; line-height:28px; padding:15px 0 0 25px; font:14px '宋体';"></td>
              </tr>
              <tr>
                <td align="left">
						<div class="jies">
							<div class="nt" style="border:none;">
						<h2>公司简介&nbsp;<img src="/images/shops/jt.gif" /></h2>
						<p id="ps">
                            <asp:Literal ID="Literal7" runat="server"></asp:Literal></p>
						  </div>
							<div class="nt">
							  <h2>主要服务&nbsp;<img src="/images/shops/jt.gif" /></h2>
							<p><asp:Literal ID="Literal10" runat="server"></asp:Literal></p>
						  </div>
							<div class="nt">
										<h2>优势航线&nbsp;<img src="/images/shops/jt.gif" /></h2>
										<p>海运：<asp:Literal ID="Literal15" runat="server"></asp:Literal><br />
									  &nbsp;&nbsp;&nbsp;&nbsp;空运：<asp:Literal ID="Literal16" runat="server"></asp:Literal></p>
						  </div>
					 	    <div class="nt" style="border:none;">
										<h2>优势船公司&nbsp;<img src="/images/shops/jt.gif" /></h2>
										<p><asp:Literal ID="Literal17" runat="server"></asp:Literal></p>
						  </div>
						</div>
                
                </td>
              </tr>
            </tbody>
          </table>
	  </div>
	  </asp:PlaceHolder>


</asp:Panel>
<userbottomline:userbottomline id="userbottomline1" runat="server"/>
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div>
</form>
</body>
</html>
