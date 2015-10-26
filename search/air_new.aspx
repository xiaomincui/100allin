<%@ Page Language="VB" AutoEventWireup="false" CodeFile="air_new.aspx.vb" Inherits="search_air_new" EnableEventValidation="false" ValidateRequest="false" EnableViewState="false"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="空运 运费 运价" /></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="空运价格专栏,空运最新空运运费,空运运价查询,环球运费网" /></asp:Literal>
<asp:Literal id="Literal1" runat="server"><title>空运运费发布,空运价格,空运代理报价及订舱服务-环球运费网</title></asp:Literal>
<link href="/css3/fcl.css" rel="stylesheet" type="text/css" />
<link href="/css/fcl_list.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/js/function.js"></script>
<script language="javascript" type="text/javascript" src="/js/air_list.js"></script>
<script type="text/javascript" language="javascript" src="../js/auto/ac_zd.js"></script>
<script type="text/javascript" language="javascript" src="../js/auto/airprot_ch.js"></script>
<script type="text/javascript" src="/js/MSClass.js"></script>
<link href="/js/auto/port.css" rel="stylesheet" type="text/css" />
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
<div id="mm" style="position:absolute; visibility:hidden; z-index:100;" ><div class="pop_main" id="pop_main_window"></div></div> 
<div class="s_bar">
<div class="s_b3_l"><img src="/images2/2011_fcl/b2ar_3.gif" /></div>
<div class="s_b3_m">
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
<asp:ListItem>北美线</asp:ListItem>
<asp:ListItem>欧洲线</asp:ListItem>
<asp:ListItem>南美线</asp:ListItem>
<asp:ListItem>亚洲线</asp:ListItem>
<asp:ListItem>非洲线</asp:ListItem>
<asp:ListItem>澳洲线</asp:ListItem>
<asp:ListItem>国内航线</asp:ListItem>
</asp:DropDownList>
</td>
<td align="right"><strong>起运地</strong>：</td>
<td><asp:TextBox ID="txtStartport" runat="server" Width="200px" sou_type="air_start" onfocus="auto_init(event,this);" onclick="autowords(this,event);" Font-Names="Verdana"></asp:TextBox></td>
<td align="right"><strong>目的地</strong>：</td>
<td><asp:TextBox ID="txtDestport" runat="server" Width="200px" sou_type="air_port" onfocus="auto_init(event,this);" onclick="autowords(this,event);" Font-Names="Verdana"></asp:TextBox></td>
<td align="center"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images2/2011_fcl/s_bt.jpg" width="133" height="31" border="0"  /></td>
</tr>
</table>
</div>
<div class="s_b3_list">
<strong>起运地</strong>： <asp:Label ID="lblStartportHot" runat="server" Text=""></asp:Label><br />
<strong style="letter-spacing:13px; margin-right:-13px;">航线</strong>： <asp:Label ID="lblLineHot" runat="server" Text=""></asp:Label>
</div>
</div>
<div class="s_b3_r"><img src="/images2/2011_fcl/b3ar_3.gif" /></div>
<div class="fd3_jt"><img src="/images2/2011_fcl/fdjt.jpg" /></div>
</div>
<div class="notice"><p>
共找到<span class="orange"><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></span>条记录		    
您搜索的是：&nbsp;
<b><asp:Label ID="hidTxtCarrier" runat="server" ></asp:Label></b>
<asp:Label ID="Label10" runat="server" Text="起运地："></asp:Label><b><asp:Label ID="hidTxtStartport" runat="server" ></asp:Label></b>&nbsp;
<asp:Label ID="Label11" runat="server" Text="目的地："></asp:Label><b><asp:Label ID="hidTxtDestport" runat="server" ></asp:Label></b>&nbsp;
<asp:Label ID="Label12" runat="server" Text="航线："></asp:Label><b><asp:Label ID="hidTxtLine" runat="server" ></asp:Label></b>&nbsp;
    <asp:Literal ID="ltrMoreHistory1" runat="server"></asp:Literal>               
</p>
</div>
<div class="main_left">
<div class="freight_List_title" style="background:url(/images2/2011_fcl/btbar_top.jpg) no-repeat top; height:35px; padding:0px; line-height:35px;">
<h2 style="letter-spacing:2px;">空运运价列表</h2>
&nbsp;<a href="/member/releaseselect.aspx" target="_blank">我要发布运价</a>
<span class="paixu"><asp:Label ID="lblOrder" runat="server" Text=""></asp:Label></span>
<img style="margin-left:80px;" src="/images2/fcl/whao.gif"  /><a href="/help/help_fcl.html#tips" target="_blank">相关帮助</a>	  </div>
<div class="biaoti" style="position:relative;">
<table width="742" height="39" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="6" bgcolor="#CAC9C7"><img src="/images2/2011_fcl/btbar_l.gif" width="6" height="39" /></td>
<td background="/images2/2011_fcl/btbar_bg.jpg"><table border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="15" align="left" ></td>
<td width="76" align="left"><strong>航线</strong></td>
<td width="78" align="left"><strong>起运地</strong></td>
<td width="115" align="left"><strong>目的地</strong></td>
<td width="70" align="left"><strong>+45</strong></td>
<td width="70" align="left"><strong>+100</strong></td>
<td width="70" align="left"><strong>+300</strong></td>
<td width="70" align="left"><strong>+500</strong></td>
<td width="70" align="left"><strong>+1000</strong></td>
<td width="102" align="left">&nbsp;</td>
</tr>
</table></td>
<td width="1" ><img src="/images2/2011_fcl/btbar_r.gif" width="6" height="39" /></td>
</tr>
</table>
</div>
<div class="freight_List">
<div class="list_box">
<asp:Repeater ID="Rptair" runat="server">
<ItemTemplate>
<ul>
<li>
<table width="742" height="75" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="15" height="80" align="center"><table width="15" border="0" cellpadding="0" cellspacing="0" class="fcl_spbox">
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
<td width="622" onmouseover="tt('<%#Rptair.Items.Count %>','pop_a_<%# eval("sid") %>_<%# eval("id") %>',event)" onmouseout="hidden(event)"><table width="622" height="80" border="0" cellpadding="0" cellspacing="0">
<tr>
<td colspan="2" id="pop_a_<%# eval("sid") %>_<%# eval("id") %>"><a href="/air/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#GetFirstString(Eval("title").ToString, 24)%></a>
<span class="gray_2">[<%#Format(Eval("postdate"), "yy").ToString%>/<%#Format(Eval("postdate"), "MM").ToString%>/<%#Format(Eval("postdate"), "dd").ToString%> 至 <%#Format(CDate(Eval("enddate")), "yy").ToString%>/<%#Format(CDate(Eval("enddate")), "MM").ToString%>/<%#Format(CDate(Eval("enddate")), "dd").ToString%>]</span></td>
</tr>
<tr>
<td width="267"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="28%" align="left"><%#Eval("line").ToString%></td>
<td width="30%" align="left"><%#GetFirstString(IIf(GetQueryString("sp") = "0", Eval("startport").ToString, GetQueryString("sp")), 7)%></td>
<td width="44%" align="left"><%#GetFirstString(IIf(GetQueryString("dp") = "0", Eval("destport").ToString, GetQueryString("dp")), 12)%></td>
</tr>
</table></td>
<td width="335"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="red_5" width="20%"><%#GetFirstString(Eval("price_p45").ToString, 4)%></td>
<td class="red_5" width="20%"><%#GetFirstString(Eval("price_p100").ToString, 4)%></td>
<td class="red_5" width="20%"><%#GetFirstString(Eval("price_p300").ToString, 4)%></td>
<td class="red_5" width="20%"><%#GetFirstString(Eval("price_p500").ToString, 4)%></td>
<td class="red_5" width="20%"><%#GetFirstString(Eval("price_p1000").ToString, 4)%></td>
</tr>
</table></td>
</tr>
<tr>
<td colspan="2" class="gray_2"><a href="/company/<%# key(eval("userid"))%>/" target="_blank" style="color:#666666;"><%#GetFirstString(Eval("companyname").ToString, 50)%></a></td>
</tr>
</table></td>
<td width="105" align="center">
<div><a href="<%#IIf(Eval("userid")="73066","http://www.100allin.com/waysglobal/","/company/"& key(eval("userid")) & "/")%>" target="_blank" style="color:#666666;"><img src="/images2/fcl/dingc_r62.gif" border="0" title="点击查看联系方式" /></a></div>
</td>
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
<input id="btnPageJump" name="btnPageJump" type="button" value="确定"  runat="server"/>
</DIV>
</td>
</tr>
</table>
</div>
</div>
<div class="freight_List">
<div class="list_box">
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
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
<div style="margin-bottom:10px;"><a href="/supplier/" target="_blank"><img src="http://img02.100allin.com/images2/index/zm.gif" width="200" height="120" border="0" /></a></div>
<asp:Literal ID="ltrBanner" runat="server"></asp:Literal>	
<div class="r_hot" style="margin-top:-2px;">
<div class="r_hot_top"><strong>当前热门港口</strong></div>
<div class="r_hot_md">
<a href="/air/list-SHANGHAI-BOG--0-0-0-----1.html">SHANGHAI - BOG</a><br />
<a href="/air/list-SHANGHAI-BRUSSELS--0-0-0-----1.html">SHANGHAI - BRUSSELS</a><br />
<a href="/air/list-PVG-CCS--0-0-0-----1.html">PVG - CCS</a><br />
<a href="/air/list-SHANGHAI-CDG--0-0-0-----1.html">SHANGHAI - CDG</a><br />
<a href="/air/list-PVG-LAX--0-0-0-----1.html">PVG - LAX</a><br />
<a href="/air/list-SHANGHAI-TOKYO--0-0-0-----1.html">SHANGHAI - TOKYO</a><br />
<a href="/air/list-SZX-BEY--0-0-0-----1.html">SZX - BEY</a><br />
<a href="/air/list-SHA-BAK--0-0-0-----1.html">SHA - BAK</a><br />
<a href="/air/list-HK-DEL--0-0-0-----1.html">HK - DEL</a><br />
<a href="/air/list-HGH-DXB--0-0-0-----1.html">HGH - DXB</a><br />		
</div>
<div class="r_hot_bt"><img src="/images2/2011_fcl/r_hot_bt.gif" /></div>
</div>
<div class="right_ad" style="margin-top:10px;"><a href="/topic/solution20100826/" target="_blank"><img src="http://img02.100allin.com/topic/solution20100826/images/so_6_3.jpg" width="200" height="120" border="0" /></a></div>


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
<%--<div style="width:950px; float:left; margin-bottom:12px;"><a href="/supplier/"><img src="/images2/2011_fcl/ysdl_950.gif" border="0" /></a></div>--%>
<div class="bot_box">
<div class="bot_box_l"><img src="/images2/2011_fcl/bt_l.gif" /></div>
<div class="bot_box_m">
<div class="sp_l"><a href="/topic/air090716/" target="_blank"><img src="/images2/2011_fcl/ky.jpg" border="0" /></a></div>
<user201102listbottomspecial:user201102listbottomspecial ID="user201102listbottomspecial1" runat="server" />
<user201102listbottomsupplier:user201102listbottomsupplier ID="user201102listbottomsupplier1" runat="server" />
</div>
<div class="bot_box_r"><img src="/images2/2011_fcl/bt_r.gif" /></div>
</div>
<userlinkbottom1:userlinkbottom1 ID="userlinkbottom11" runat="server" />
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div>

</form>
<script language="javascript">
<!--
if(typeof(LiveReceptionCode_isonline)!='undefined'  && LR_GetObj('LR_User_Icon1')!=null)
{
if(LiveReceptionCode_isonline)
LR_GetObj('LR_User_Icon1').innerHTML='<a '+LiveReceptionCode_BuildChatWin('您有新访客','您好，请问有什么需要帮忙？')+'><b>点击这里</b></a>';
else
LR_GetObj('LR_User_Icon1').innerHTML='<a '+LiveReceptionCode_BuildChatWin('您有新访客','客服人员不在线,请点击留言')+'><b>点击这里</b></a>';
}
//-->
</script>

<script type="text/javascript">

document.getElementById("mm").onmouseout=function(e){
var e = window.event || e, relatedTarget = e.toElement || e.relatedTarget;
while(relatedTarget && relatedTarget != this){
relatedTarget = relatedTarget.parentNode;
if(!relatedTarget){
hidden1();
}
}
}; 
</script>   
</body>
</html>
