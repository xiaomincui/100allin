<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="test"  EnableEventValidation="false" ValidateRequest="false" EnableViewState="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
<asp:Literal id="Literal1" runat="server"><title>整箱运费查询订舱,查询海运整箱运价,提供全球海运整箱在线订舱-环球运费网</title></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="海运整箱运费查询与订舱频道,查询国际海运整箱运价,海运整箱在线订舱,整箱运费查询整箱运价查询整箱在线订舱,尽在环球运费网" /></asp:Literal>
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="整箱,整箱运费,整箱运价,整箱订舱" /></asp:Literal>
<link href="/css3/fcl.css" rel="stylesheet" type="text/css" />
<link href="/css/fcl_list.css" rel="stylesheet" type="text/css" />
<link href="/js/auto/port.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/js/function.js"></script>
<script language="javascript" type="text/javascript" src="/js/fcl_list.js"></script>
<script type="text/javascript" language="javascript" src="/js/autocomplete/prototype.js"></script>
<script type="text/javascript" language="javascript" src="/js/auto/ac_zd.js"></script>
<script type="text/javascript" language="javascript" src="/js/auto/ac_zd_head_fcl.js"></script>
<script type="text/javascript" language="javascript" src="/js/moredp/more_prot.js"></script>
<script type="text/javascript" src="/js/MSClass.js"></script>
<style type="text/css"></style>
</head>

<body>
<form id="form1" runat="server" autocomplete="off">
<div id="messages"></div>
<script type='text/javascript'>document.getElementById('form1').action = window.location.href;</script>
<div class="h_box">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_1" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_1" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_1" runat="server" />
</div>
<div class="main">
<div class="tchu_box" id="more" style="position:absolute; width:225px; left:10px; visibility:hidden; padding:10px; line-height:22px; z-index:100;">
<div class="tchu_box_top"></div>
<div class="tchu_box_mid" id="more_in"></div>
<div class="tchu_box_bot"></div>
</div>
<div class="tchu_box" id="moredp" style="position:absolute; width:429px; left:10px; visibility:hidden; padding:10px; line-height:22px; z-index:100;">
<div class="tchu_box_top" style="width:429px;background:url(../images/fcl/tchu1_b.gif) no-repeat top;"></div>
<div class="tchu_box_mid" id="moredp_in" style="width:399px;line-height:12px;background:url(../images/fcl/tchu_bg_b.gif) repeat-y;">
<div style="width: 400px;">
<div style="padding-bottom:5px;font-size:12px;  "><strong>点击选择目的港（按字母排列）</strong>
<a id="language_zh" class="select_Language" onmouseover="ch_lan(this,'en')" style="margin-left:100px;">中文</a> <a id="language_en" class="noselect_Language" onmouseover="ch_lan(this,'zh')">English</a>
</div>        
<div id="tab_list"><ul><li id="AC" class="tab_li_on">A-C</li><li id="DK">D-K</li><li id="LO">L-O</li><li id="PS">P-S</li><li id="TZ">T-Z</li></ul></div>
<div style="clear:both;"></div>
<div class="p_l_d"><ul id="prot_list_u" class="prot_ul"><li></li><li></li><li></li><li></li><li><img src="/js/autocomplete/loading.gif" /></li><li>正在载入港口列表...</li><li></li><li></li><li></li><li></li></ul></div>
<div style="clear: both;"></div>
<div id="page_number"></div>
<div style="clear: both;"></div>
</div>
</div>
<div class="tchu_box_bot" style="width:429px;background:url(../images/fcl/tchu2_b.gif) no-repeat top;"></div>
</div>	

<div class="tchu_box" id="morecarrier" style="position:absolute; width:225px; left:10px; visibility:hidden; padding:10px; line-height:22px; z-index:100;">
<div class="tchu_box_top"></div>
<div class="tchu_box_mid" id="morecarrier_in"></div>
<div class="tchu_box_bot"></div>
</div>
<div id="mm" style="position:absolute; visibility:hidden; z-index:100;" ><div class="pop_main" id="pop_main_window"></div></div> 


<div id="jgpop" style="position:absolute; visibility:hidden; z-index:100;width:200px;" ><div style="border:1px solid #d8a9a9;background:#F8FBFE;line-height:20px; "><p style="border:3px solid #ffebeb;padding:5px 8px;">该用户承诺:此运价在环球运费网上接受订舱后<b>决不加价</b>.否则愿意赔偿</p></div>
</div> 
<div id="cwpop" style="position:absolute; visibility:hidden; z-index:100;width:200px;" ><div style="border:1px solid #d8a9a9;background:#F8FBFE;line-height:20px;">
<p style="border:3px solid #ffebeb;padding:5px 8px;">该用户承诺:此运价在有效期内<b>保证有舱位</b></p></div>
</div> 
<div id="dcpop" style="position:absolute; visibility:hidden; z-index:100;width:200px;" ><div style="border:1px solid #d8a9a9;background:#F8FBFE;line-height:20px;">
<p style="border:3px solid #ffebeb;padding:5px 8px;">订舱可获<b>价格保证</b>和<b>信息费奖励</b></p></div>
</div>


<div class="s_bar">
<div class="s_b2_l"><img src="/images2/2011_fcl/b2ar.gif" /></div>
<div class="s_b2_m">
<div class="s_bar_mp" style="height:35px; padding-top:20px; background-image:none;">
<table width="890" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td align="right"><strong>航线</strong>：</td>
<td>
<asp:HiddenField ID="hidType" runat="server" Value="fcl" />
<asp:HiddenField ID="hidStartport" runat="server" Value="" />
<asp:HiddenField ID="hidDestport" runat="server" Value="" />
<asp:HiddenField ID="hidCarrier" runat="server" Value="" />
<asp:HiddenField ID="hidLine" runat="server" Value="0" />
<asp:DropDownList ID="txtLine" runat="server" Width="105" Height="22" Font-Size="13px">
<asp:ListItem Text="全部航线" Value=""></asp:ListItem>
<asp:ListItem>美加线</asp:ListItem>
<asp:ListItem>欧地线</asp:ListItem>
<asp:ListItem>中南美线</asp:ListItem>
<asp:ListItem>日韩线</asp:ListItem>
<asp:ListItem>近洋线</asp:ListItem>
<asp:ListItem>非洲线</asp:ListItem>
<asp:ListItem>澳洲线</asp:ListItem>
<asp:ListItem>中东印巴线</asp:ListItem>
<asp:ListItem>红海线</asp:ListItem>
</asp:DropDownList>
</td>
<td align="right"><strong>起运港</strong>：</td>
<td><asp:TextBox ID="txtStartport" runat="server" Width="130px" sou_type="start_port" Font-Names="Verdana"></asp:TextBox></td>
<td align="right"><strong>目的港</strong>：</td>
<td><asp:TextBox ID="txtDestport" runat="server" Width="130px" sou_type="end_port" Font-Names="Verdana"></asp:TextBox></td>
<td align="right"><strong>船公司</strong>：</td>
<td><asp:TextBox ID="txtCarrier" runat="server" Width="100px" sou_type="ship_com" Font-Names="Verdana"  style="width: 80px"></asp:TextBox></td>
<td align="center"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images2/2011_fcl/s_bt.jpg" width="133" height="31" border="0"  /></td>
</tr>
</table>
</div>
<div class="s_b2_list">
<strong>起运港</strong>： <asp:Label ID="lblStartportHot" runat="server" Text=""></asp:Label><br />
<strong style="letter-spacing:13px; margin-right:-13px;">航线</strong>： <asp:Label ID="lblLineHot" runat="server" Text=""></asp:Label><br />
<strong>目的港</strong>： <asp:Label ID="lblDesportHot" runat="server" Text=""></asp:Label><br />
<strong>船公司</strong>： <asp:Label ID="lblCarrierHot" runat="server" Text=""></asp:Label></div>
</div>
<div class="s_b2_r"><img src="/images2/2011_fcl/b3ar.gif" /></div>
<div class="fd2_jt"><img src="/images2/2011_fcl/fdjt.jpg" /></div>
</div>
<div style="margin-bottom:10px;"><a href="http://www.100allin.com/company/Y0lmRlZhMzNsTzIzVGU4eDd1eENNUT09/" target="_blank"><img src="http://img02.100allin.com/images2/banner/galax.jpg" width="950" height="92" border="0" /></a></div>
<div class="notice"><p>
共找到<span class="orange"><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></span>条记录<asp:Literal ID="ltrMoreHistory2" runat="server"></asp:Literal>
<asp:Literal ID="ltrYouSearch" runat="server"></asp:Literal>&nbsp;
<asp:Label ID="Label9" runat="server" Text="船公司："></asp:Label><b><asp:Label ID="hidTxtCarrier" runat="server" ></asp:Label></b>&nbsp;
<asp:Label ID="Label10" runat="server" Text="起运港："></asp:Label><b><asp:Label ID="hidTxtStartport" runat="server" ></asp:Label></b>&nbsp;
<asp:Label ID="Label11" runat="server" Text="目的港："></asp:Label><b><asp:Label ID="hidTxtDestport" runat="server" ></asp:Label></b>&nbsp;
<asp:Label ID="Label12" runat="server" Text="航线："></asp:Label><b><asp:Label ID="hidTxtLine" runat="server" ></asp:Label></b>&nbsp;
    <asp:Literal ID="ltrMoreHistory1" runat="server"></asp:Literal>
<asp:HiddenField ID="hidHistroy" runat="server" Value="" />   
</p>
</div>
<div class="main_left">
<div class="freight_List_title" style="background:url(/images2/2011_fcl/btbar_top.jpg) no-repeat top; height:35px; padding:0px; line-height:35px;">
<h2>整箱海运价列表</h2>
&nbsp;<a href="/member/releaseselect.aspx" target="_blank">我要发布运价</a>
<span class="paixu"><asp:Label ID="lblOrder" runat="server" Text=""></asp:Label></span>
<img style="margin-left:80px;" src="/images2/fcl/whao.gif"  /><a href="/help/help_fcl.html#tips" target="_blank">相关帮助</a>	  </div>
<div class="biaoti" style="position:relative;">
<table width="742" height="39" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="6" bgcolor="#CAC9C7"><img src="/images2/2011_fcl/btbar_l.gif" width="6" height="39" /></td>
<td background="/images2/2011_fcl/btbar_bg.jpg"><table border="0" cellspacing="1" cellpadding="0">
<tr>
<td width="9" align="left" ></td>
<td width="75" align="left"><strong>航线</strong></td>
<td width="100" align="left"><strong>起运港</strong></td>
<td width="161" align="left"><strong>目的港</strong></td>
<td width="53" align="left"><strong>20'</strong></td>
<td width="54" align="left"><strong>40'</strong></td>
<td width="56" align="left"><strong>40H'</strong></td>
<td width="52" align="left"><strong>45H'</strong></td>
<td width="73" align="left"><strong>船公司</strong></td>
<td width="94" align="left">&nbsp;</td>
</tr>
</table></td>
<td width="1" ><img src="/images2/2011_fcl/btbar_r.gif" width="6" height="39" /></td>
</tr>
</table>
</div>
<div class="freight_List">
<div class="list_box">
<asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
<ul>
<asp:Repeater ID="Rptfcladv" runat="server">
<ItemTemplate>
<li  style="<%#IIf(Eval("order_advx") = "1", "border:1px solid #D8D8D8;background:#F3F3F3;", (IIf(Eval("userid") = "8352","border:3px solid #2068CA;background:#DEF1FF;","border:1px solid #993333;background:#f9f4f2;")))%>">
<table width="740" height="75" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="15" height="80" align="center"><table width="15" border="0" cellpadding="0" cellspacing="1" class="fcl_spbox">
<tr>
<td width="2%" height="24" align="right"><div style="display:none"><asp:Label ID="Label1"  runat="server" Text='<%# eval("sid") %>'></asp:Label><asp:Label ID="Label2"  runat="server" Text='<%#Eval("userid")%> '></asp:Label></div></td>
</tr>
<tr>
<td height="24" bordercolor="0">&nbsp;</td>
</tr>
<tr>
<td height="24" bordercolor="0">&nbsp;</td>
</tr>
</table></td>
<td width="622" onmouseover="tt2('<%#Rptfcladv.Items.Count %>','pop_b_<%# eval("sid") %>_<%# eval("id") %>',event)" onmouseout="hidden(event)"><table width="622" height="80" border="0" cellpadding="0" cellspacing="0">
<tr>
<td colspan="3" id="pop_b_<%# eval("sid") %>_<%# eval("id") %>"><a href="/fcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#IIf(Eval("order_advx") = "0", "", IIf(Eval("userid") = "8352", "<span style=""color:#1A54A5; font-weight:bold; font-size:14px;"">", "<span style=""color:#971817; font-weight:bold;"">"))%><%#GetFirstString(Eval("title").ToString, 40)%><%#IIf(Eval("order_advx") = "0", "", "</span>")%></a>
<span class="gray_2">[<%#Format(Eval("postdate"), "yy").ToString%>/<%#Format(Eval("postdate"), "MM").ToString%>/<%#Format(Eval("postdate"), "dd").ToString%> 至 <%#Format(CDate(Eval("enddate")), "yy").ToString%>/<%#Format(CDate(Eval("enddate")), "MM").ToString%>/<%#Format(CDate(Eval("enddate")), "dd").ToString%>]</span><%#IIf(Eval("order_advx") = "1", "<img src=""http://img02.100allin.com/pm/p/images/p1.gif"" title=""环球运费网推荐"" />", "")%><%#IIf(Eval("order_advx") > "1", "<img src=""http://img02.100allin.com/pm/p/images/e1.gif"" title=""环球运费网推荐"" />", "")%></td>
</tr>
<tr>
<td width="337"><table width="90%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="25%"><%#Eval("hangxianmiaoshu").ToString%></td>
<td width="35%" style="line-height:14px;"><%#GetFirstString(Eval("startport").ToString, 7).ToUpper()%></td>
<td width="40%" style="line-height:14px;"><%#GetFirstString(Eval("destport").ToString, 20).ToUpper()%></td>
</tr>
</table></td>
<td width="222"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="<%#IIf(Eval("userid") = "8352","blue_5","red_5")%>" width="25%"><%#GetFirstString(Eval("price20gp").ToString, 4)%></td>
<td class="<%#IIf(Eval("userid") = "8352","blue_5","red_5")%>" width="25%"><%#GetFirstString(Eval("price40gp").ToString, 4)%></td>
<td class="<%#IIf(Eval("userid") = "8352","blue_5","red_5")%>" width="25%"><%#GetFirstString(Eval("price40hq").ToString, 4)%></td>
<td class="<%#IIf(Eval("userid") = "8352","blue_5","red_5")%>" width="25%"><%#GetFirstString(Eval("price45hq").ToString, 4)%></td>
</tr>
</table></td>
<td width="63"><span class="gray"><a href="/carrier/carrier-<%#IIf(GetQueryString("cr") = "0", Eval("shipcompany").ToString, GetQueryString("cr"))%>.html"><%#GetFirstString(IIf(GetQueryString("cr") = "0", Eval("shipcompany").ToString, GetQueryString("cr")), 5)%></a></span></td>
</tr>
<tr>
<td colspan="3" class="gray_2"><a href="<%#IIf(Eval("userid")="2061","http://www.100allin.com/shop/hf/",IIf(Eval("userid")="77805","http://www.100allin.com/shop/bloom/",IIf(Eval("userid")="117726","http://www.100allin.com/shop/jituo/","/company/"& key(eval("userid")) & "/")))%>" target="_blank" style="color:#666666;"><%#IIf(Eval("userid") = "8352", "<img src=""http://img02.100allin.com/pm/p/images/galax.gif"" border=""0"" style=""vertical-align:middle;"" />", "")%><%#GetFirstString(Eval("companyname").ToString, 50)%></a></td>
</tr>
</table></td>
<td width="105" align="center">
<div><a href="<%#IIf(Eval("userid")="2061","http://www.100allin.com/shop/hf/",IIf(Eval("userid")="77805","http://www.100allin.com/shop/bloom/",IIf(Eval("userid")="117726","http://www.100allin.com/shop/jituo/","/company/"& key(eval("userid")) & "/")))%>" target="_blank" style="color:#666666;"><%#IIf(Eval("order_advx") = "1", "<img src=""http://img02.100allin.com/pm/p/images/p2.gif"" border=""0"" title=""点击查看联系方式"" />", "")%><%#IIf(Eval("order_advx") > "1", "<img src=""http://img02.100allin.com/pm/p/images/" & IIf(Eval("userid") = "8352", "e3", "e2") & ".gif"" border=""0"" title=""点击查看联系方式"" />", "")%></a></div>
</td>
</tr>
</table>
</li>
</ItemTemplate>
</asp:Repeater>
</ul>
</asp:PlaceHolder>
<input id="Hidden2" runat="server" style="width: 100px" type="hidden" />
<input id="Hiddennn2" runat="server" style="width: 100px" type="hidden" />

<asp:PlaceHolder ID="PlaceHolder6" runat="server">
<!--安运通测试代码-->
<ul>
<li>
<table width="742" height="75" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="15" height="80" align="center"><table width="15" border="0" cellpadding="0" cellspacing="1" class="fcl_spbox">
<tr>
<td width="2%" height="24" align="right"><div style="display:none"><span id="Rptfcl_ctl00_Label1">289657</span><span id="Rptfcl_ctl00_Label2">8299</span></div></td>
</tr>
<tr>
<td height="24" bordercolor="0">&nbsp;</td>
</tr>
<tr>
<td height="24" bordercolor="0">&nbsp;</td>
</tr>
</table></td>
<td width="622"><table width="622" height="80" border="0" cellpadding="0" cellspacing="0">
<tr>
<td colspan="3" id="pop_a_289657_0"><a href="/fcl/M1c3RnVIWUlBWTVjQWJRdjlxUCs3UT09_8128975.html" target="_blank">中南美桑托斯最新价格</a>
<span class="gray_2">[13/08/07 至 13/08/15]</span></td>
</tr>
<tr>
<td width="337"><table width="90%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="25%">中南美线</td>
<td width="35%" style="line-height:14px;">SHANGHAI..</td>
<td width="40%" style="line-height:14px;">SANTOS</td>
</tr>
</table></td>
<td width="222"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="red_5" width="25%">1000</td>
<td class="red_5" width="25%">2000</td>
<td class="red_5" width="25%">2000</td>
<td class="red_5" width="25%"></td>
</tr>
</table></td>
<td width="63"><span class="gray"><a href="/carrier/carrier-msk.html">msk</a></span></td>
</tr>
<tr>
<td colspan="3" class="gray_2"><a href="/company/cnRhQWFFT2U4TTNFS0szVjdaQWRPZz09/" target="_blank" style="color:#666666;">上海汉万国际货物运输代理有限公司</a></td>
</tr>
</table></td>
<td width="105" align="center">
<div><a href="/search/order_temp.aspx?type=fcl&filter=new&yid=290099&ydid=0&f=8299" target="_blank"  onmouseover="tt_dcpop(event);" onmouseout="hid_dcpop();"><img src="/images/fcl/dingc_r5_c1.jpg" width="68" height="29" border=0 /></a>
</div>
<div style="margin-top:5px;">
<a href="/help/services_2.aspx" onmouseover="tt_cwpop(event);" onmouseout="hid_cwpop();"><img src="/images/fcl/fc_r1_c1_s.gif" width="18" height="18" border="0" /></a>
<a href="/help/services_1.aspx" onmouseover="tt_jgpop(event);" onmouseout="hid_jgpop();"><img src="/images/fcl/fc_r3_c1_s.gif" width="18" height="18" border="0" /></a>
</div></td>
</tr>
</table>
</li>
</ul>
<!--安运通测试代码结束-->

</asp:PlaceHolder>

<asp:Repeater ID="Rptfcl" runat="server">
<ItemTemplate>
<ul>
<li>
<table width="742" height="75" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="15" height="80" align="center"><table width="15" border="0" cellpadding="0" cellspacing="1" class="fcl_spbox">
<tr>
<td width="2%" height="24" align="right"><div style="display:none"><asp:Label ID="Label1"  runat="server" Text='<%# eval("sid") %>'></asp:Label><asp:Label ID="Label2"  runat="server" Text='<%#Eval("userid")%> '></asp:Label></div></td>
</tr>
<tr>
<td height="24" bordercolor="0">&nbsp;</td>
</tr>
<tr>
<td height="24" bordercolor="0">&nbsp;</td>
</tr>
</table></td>
<td width="622" onmouseover="tt('<%#Rptfcl.Items.Count %>','pop_a_<%# eval("sid") %>_<%# eval("id") %>',event)" onmouseout="hidden(event)"><table width="622" height="80" border="0" cellpadding="0" cellspacing="0">
<tr>
<td colspan="3" id="pop_a_<%# eval("sid") %>_<%# eval("id") %>"><a href="/fcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#GetFirstString(Eval("title").ToString, 40)%></a>
<span class="gray_2">[<%#Format(Eval("postdate"), "yy").ToString%>/<%#Format(Eval("postdate"), "MM").ToString%>/<%#Format(Eval("postdate"), "dd").ToString%> 至 <%#Format(CDate(Eval("enddate")), "yy").ToString%>/<%#Format(CDate(Eval("enddate")), "MM").ToString%>/<%#Format(CDate(Eval("enddate")), "dd").ToString%>]</span></td>
</tr>
<tr>
<td width="337"><table width="90%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="25%"><%#Eval("hangxianmiaoshu").ToString%></td>
<td width="35%" style="line-height:14px;"><%#GetFirstString(Eval("startport").ToString, 7).ToUpper()%></td>
<td width="40%" style="line-height:14px;"><%#GetFirstString(Eval("destport").ToString, 20).ToUpper()%></td>
</tr>
</table></td>
<td width="222"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="red_5" width="25%"><%#GetFirstString(Eval("price20gp").ToString, 4)%></td>
<td class="red_5" width="25%"><%#GetFirstString(Eval("price40gp").ToString, 4)%></td>
<td class="red_5" width="25%"><%#GetFirstString(Eval("price40hq").ToString, 4)%></td>
<td class="red_5" width="25%"><%#GetFirstString(Eval("price45hq").ToString, 4)%></td>
</tr>
</table></td>
<td width="63"><span class="gray"><a href="/carrier/carrier-<%#IIf(GetQueryString("cr") = "0", Eval("shipcompany").ToString, GetQueryString("cr"))%>.html"><%#GetFirstString(IIf(GetQueryString("cr") = "0", Eval("shipcompany").ToString, GetQueryString("cr")), 5)%></a></span></td>
</tr>
<tr>
<td colspan="3" class="gray_2"><a href="<%#IIf(Eval("userid")="2061","http://www.100allin.com/shop/hf/",IIf(Eval("userid")="77805","http://www.100allin.com/shop/bloom/",IIf(Eval("userid")="117726","http://www.100allin.com/shop/jituo/","/company/"& key(eval("userid")) & "/")))%>" target="_blank" style="color:#666666;"><%#GetFirstString(Eval("companyname").ToString, 50)%></a></td>
</tr>
</table></td>
<td width="105" align="center">
<div><a href="<%#IIf(Eval("userid")="2061","http://www.100allin.com/shop/hf/",IIf(Eval("userid")="77805","http://www.100allin.com/shop/bloom/",IIf(Eval("userid")="117726","http://www.100allin.com/shop/jituo/","/company/"& key(eval("userid")) & "/")))%>" target="_blank" style="color:#666666;"><img src="/images2/fcl/dingc_r62.gif" border="0" title="点击查看联系方式" /></a></div></td>
</tr>
</table>
</li>
</ul>
</ItemTemplate>
</asp:Repeater>
<asp:PlaceHolder ID="phNoResult" runat="server" Visible="false">
<div style="width:100%; padding:30px 0px 30px 0px; text-align:center; font-size:14px;">
抱歉，该港口暂时没有运价发布， 
<script language="javascript">
<!--
if(document.all || document.getElementById)
{
document.write('<span id="LR_User_Icon1"></span>');
}
else if(document.layers)
{
document.write('<layer name="LR_User_Icon1"></layer>');
}
//-->
</script>
客服中心帮助您寻找运价
</div>
</asp:PlaceHolder>
<input id="Hidden1" runat="server" style="width: 1px" type="hidden" />		
<input id="Hiddennn1" runat="server" style="width: 1px" type="hidden" />
<input id="Hiddenmm1"  runat="server" style="width: 100px" type="hidden" />
</div>
</div>				

<div class="freight_List">
<div class="list_box">
<table id="pd" width="100%" border="0" cellpadding="0" cellspacing="1" >
<tr>
<td height="32" colspan="11" align="center" bgcolor="#FFFFFF">
<asp:TextBox ID="delList" runat="server" CssClass="hidden"></asp:TextBox>
<DIV class=manu>
<SPAN class=disabled style="margin:0px; padding:0px; line-height:27px; height:27px; border:none; color:#28385A; float:left;">
<asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label>/<asp:HiddenField ID="hidTotalPage" runat="server" Value="1" /><asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label>
</SPAN>
<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
<asp:Label ID="hidSaveSearchWords" runat="server" Text="1" CssClass="hidden"></asp:Label>
直接到第 <input id="txtPageJump" name="txtPageJump" type="text" style=" width:20px; height:12px;" runat="server"/> 页 
<input id="btnPageJump" name="btnPageJump" type="button" value="确定" style=" width:40px; height:20px;" runat="server"/>
</DIV>
</td>
</tr>
</table>
</div>
</div>


<div class="freight_List">
<div class="list_box">
<asp:PlaceHolder ID="PlaceHolder5" runat="server">
<ul>
<li style="width:100%; padding:10px 0px 10px 0px; text-align:center; font-size:14px;">
<asp:Literal ID="ltrMoreHistory" runat="server"></asp:Literal>
</li>
</ul>
</asp:PlaceHolder>
</div>
</div>

</div>
<div class="main_right">
<%--<div><a href="/supplier/" target="_blank"><img src="http://img02.100allin.com/images2/index/zm.gif" width="200" height="120" border="0" /></a></div>--%>

<div class="r_hot" style="margin-top:-2px;">


<asp:Literal ID="ltrBanner" runat="server"></asp:Literal>	

<div style="display:none;">
<div class="r_hot_top"><strong>当前热门港口</strong></div>
<div class="r_hot_md">
<asp:Repeater ID="rptHotPort" runat="server">
<ItemTemplate>
<a href="/fcl/list-<%#Eval("startport").ToString() %>-<%#Eval("destport").ToString() %>--0-0-0-----1.html"><%#Eval("startport").ToString()%> - <%#Eval("destport").ToString()%></a><br />	
</ItemTemplate>
</asp:Repeater>
</div>
<div class="r_hot_bt"><img src="/images2/2011_fcl/r_hot_bt.gif" /></div>
</div>
</div>

<asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible="false">
<div class="r_nav" style="margin-top:12px;">
<div class="r_nav_top"><img src="/images2/2011_fcl/r_nav_top.gif" /></div>
<div class="r_nav_md2">
<h2 style="background:url(/images2/2011_fcl/xzhang.gif) no-repeat left; text-align:left; line-height:25px;">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="ltr89_startport" runat="server"></asp:Literal>港优势代理</h2>
<ul style="padding-bottom:0px;">
<h3 style="font-weight:normal;">
<table border="0" cellspacing="0" cellpadding="0">
<tr>
<td align="center"><asp:Literal ID="ltr89_1" runat="server"></asp:Literal></td>
<td align="center"><asp:Literal ID="ltr89_2" runat="server"></asp:Literal></td>
</tr>
<tr>
<td height="24" align="center">中东印巴线</td>
<td align="center">非洲线</td>
</tr>
<tr>
<td align="center"><asp:Literal ID="ltr89_3" runat="server"></asp:Literal></td>
<td align="center"><asp:Literal ID="ltr89_4" runat="server"></asp:Literal></td>
</tr>
<tr>
<td height="24" align="center">中南美线</td>
<td align="center">欧地线</td>
</tr>
<tr>
<td align="center"><asp:Literal ID="ltr89_5" runat="server"></asp:Literal></td>
<td align="center"><asp:Literal ID="ltr89_6" runat="server"></asp:Literal></td>
</tr>
<tr>
<td height="24" align="center">澳洲线</td>
<td align="center">美加线</td>
</tr>
<tr>
<td align="center"><asp:Literal ID="ltr89_7" runat="server"></asp:Literal></td>
<td align="center"><asp:Literal ID="ltr89_8" runat="server"></asp:Literal></td>
</tr>
<tr>
<td height="24" align="center">红海线</td>
<td align="center">日韩线</td>
</tr>
<tr>
<td align="center"><asp:Literal ID="ltr89_9" runat="server"></asp:Literal></td>
<td align="center"></td>
</tr>
<tr>
<td height="24" align="center">近洋线</td>
<td align="center"></td>
</tr>
</table>
</h3>
</ul>
</div>
<div class="r_nav_bt"><img src="/images2/2011_fcl/r_nav_bt.gif" /></div>
</div>
</asp:PlaceHolder>

<asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible="false">
<div class="r_nav" style="margin-top:12px;">
<div class="r_nav_top"><img src="/images2/2011_fcl/r_nav_top.gif" /></div>
<div class="r_nav_md2">
<h2 style="background:url(/images2/2011_fcl/xzhang.gif) no-repeat left; text-align:left; line-height:25px;">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="Literal4" runat="server"></asp:Literal><asp:Literal ID="ltr89_s" runat="server"></asp:Literal>港优势代理</h2>
<ul style="padding-bottom:0px;">
<h3 style="font-weight:normal;">
<table border="0" cellspacing="0" cellpadding="0">
<tr>
<td align="left" width="100" height="70" valign="top"><asp:Literal ID="ltr89" runat="server"></asp:Literal></td>
<td align="center" width="70" style="font-size:12px;"><asp:Literal ID="ltr89_l" runat="server"></asp:Literal></td>
</tr>
</table>
</h3>
</ul>
</div>
<div class="r_nav_bt"><img src="/images2/2011_fcl/r_nav_bt.gif" /></div>
</div>
</asp:PlaceHolder>

<div class="r_news">
<div class="r_news_top"><img src="/images2/2011_fcl/r_news_top.gif" /></div>
<div class="r_news_md">
<h2><div class="r"><a style="font-size:12px; font-weight:normal; color:#666666" target="_blank" href="/baf/">更多..</a></div>相关附加费</h2>
<div class="fat">
<div class="fj_box">
<p>
<asp:Literal ID="ltrTotalSurcharge" runat="server"></asp:Literal>
</p>
</div>

</div>
</div>
<div class="r_news_bt"><img src="/images2/2011_fcl/r_news_bt.gif" /></div>
</div>

<div class="r_hot">
<asp:Literal ID="ltrBanner1" runat="server"></asp:Literal>
</div>

<asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
<div class="r_news">
<div class="r_news_top"><img src="/images2/2011_fcl/r_news_top.gif" /></div>
<div class="r_news_md">
<h2><div class="r"><a style="font-size:12px; font-weight:normal; color:#666666" href="/bbs/forum-5-1.html" target="_blank">更多..</a></div>最新动态</h2>
<div class="fat"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
<tr>
<td width="12%" align="left" height="22"><img src="/images2/bbs/n<%#Repeater1.Items.Count+1 %>.gif" width="13" height="11" /></td>
<td width="88%"><div class="tb_freight_06"><a href="/bbs/thread-<%#Eval("id").ToString() %>-1.html" target="_blank" title="<%#Eval("title").ToString() %>(<%#Format(CDate(Eval("updatedate")), "yyyy-MM-dd").ToString%>)"><%#Eval("title").ToString() %></a></div></td>
</tr>
</ItemTemplate>
</asp:Repeater>
</table>
</div>
</div>
<div class="r_news_bt"><img src="/images2/2011_fcl/r_news_bt.gif" /></div>
</div>
</asp:PlaceHolder>

</div>
<div style="width:950px; float:left; margin-bottom:12px;">
<a href="/ports/" target="_blank"><img src="/images2/fcl/port_fcl_20110913.gif" border="0" /></a></div>	<div style="width:950px; float:left; margin-bottom:12px;display:none;"><a href="/supplier/" target="_blank"><img src="/images2/2011_fcl/ysdl_950.gif" border="0" /></a>
</div>
<div class="bot_box">
<div class="bot_box_l"><img src="/images2/2011_fcl/bt_l.gif" /></div>
<div class="bot_box_m">
<user201102listbottomcarrier:user201102listbottomcarrier ID="user201102listbottomcarrier1" runat="server" />
<user201102listbottomspecial:user201102listbottomspecial ID="user201102listbottomspecial1" runat="server" />
<user201102listbottomsupplier:user201102listbottomsupplier ID="user201102listbottomsupplier1" runat="server" />
</div>
<div class="bot_box_r"><img src="/images2/2011_fcl/bt_r.gif" /></div>
</div>
<userlinkbottom1:userlinkbottom1 ID="userlinkbottom11" runat="server" />
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div>

</form>
 
</body>
</html>
