<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lcl.aspx.vb" Inherits="search_lcl"  EnableEventValidation="false" ValidateRequest="false" EnableViewState="false"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="拼箱,拼箱运费,拼箱运价,拼箱订舱" /></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="海运拼箱价格频道,拼箱运费查询,国际海运拼箱报价信息,提供最优质的拼箱订舱服务,最便捷的拼箱运费运价发布平台,环球运费网" /></asp:Literal>
<asp:Literal id="Literal1" runat="server"><title>拼箱价格查询,海运拼箱运费查询,拼箱在线订舱服务,拼箱运价发布-环球运费网</title></asp:Literal>
<link href="/css/fcl1204.css" rel="stylesheet" type="text/css" />
<link href="/css/lcl_list.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/js/function.js"></script>
<script language="javascript" type="text/javascript" src="/js/lcl_list.js"></script>
<script type="text/javascript" language="javascript" src="/js/autocomplete/prototype.js"></script>
<script type="text/javascript" language="javascript" src="/js/autocomplete/port2.js"></script>
<script type="text/javascript" language="javascript" src="/js/moredp/more_prot.js"></script>
</head>
<body>
<div id="no_div"></div>
    <form id="form1" runat="server" autocomplete="off">
<script type='text/javascript'>
document.getElementById('form1').action = window.location.href;
</script>     
    <div class="main"><!--页面主体开始-->	
<usernewtop1209:usernewtop1209 ID="usernewtop12091" runat="server" />
		<div class="main_content"><!--中部开始-->
<div class="tchu_box" id="more" style="position:absolute; width:225px; left:10px; visibility:hidden; padding:10px; line-height:22px;z-index:100;">
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
         <div id="tab_list">
            <ul>
                <li id="AC" class="tab_li_on">A-C</li>
                <li id="DK">D-K</li>
                <li id="LO">L-O</li>
                <li id="PS">P-S</li>
                <li id="TZ">T-Z</li>
            </ul>
        </div><div style="clear:both;"></div>
        <div class="p_l_d">
        <ul id="prot_list_u" class="prot_ul">
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li><img src="/js/autocomplete/loading.gif" /></li>
            <li>正在载入港口列表...</li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
        </ul>
        </div>
        <div style="clear: both;">
        </div>
        <div id="page_number"></div>
        <div style="clear: both;">
        </div>
    </div>

</div>
<div class="tchu_box_bot" style="width:429px;background:url(../images/fcl/tchu2_b.gif) no-repeat top;"></div>
</div>	

<div class="tchu_box" id="morecarrier" style="position:absolute; width:225px; left:10px; visibility:hidden; padding:10px; line-height:22px;z-index:100;">
	<div class="tchu_box_top"></div>
	<div class="tchu_box_mid" id="morecarrier_in"></div>
	<div class="tchu_box_bot"></div>
</div>				
<div id="mm" style="position:absolute; visibility:hidden; z-index:100;" >
<div class="pop_main" id="pop_main_window">

</div>
</div> 

<div id="jgpop" style="position:absolute; visibility:hidden; z-index:100;width:200px;" >
    <div style="border:1px solid #d8a9a9;background:#F8FBFE;line-height:20px; ">
    <p style="border:3px solid #ffebeb;padding:5px 8px;">
    该用户承诺:此运价在环球运费网上接受订舱后<b>决不加价</b>.否则愿意赔偿
    </p>
    </div>
</div> 
<div id="cwpop" style="position:absolute; visibility:hidden; z-index:100;width:200px;" >
    <div style="border:1px solid #d8a9a9;background:#F8FBFE;line-height:20px;">
    <p style="border:3px solid #ffebeb;padding:5px 8px;">
    该用户承诺:此运价在有效期内<b>保证有舱位</b>
    </p>
    </div>
</div> 

<div id="dcpop" style="position:absolute; visibility:hidden; z-index:100;width:200px;" >
    <div style="border:1px solid #d8a9a9;background:#F8FBFE;line-height:20px;">
    <p style="border:3px solid #ffebeb;padding:5px 8px;">
    订舱可获<b>价格保证</b>和<b>信息费奖励</b>
    </p>
    </div>
</div>    
<div class="search">
		<div class="search_mid">
		  <div class="search_bar">
		  	<div class="sear_top">
<table width="100%" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td width="3%"><img src="/images/fcl/fcl_ico.gif" /></td>
    <td width="6%">航线：</td>
    <td width="12%">
        <asp:HiddenField ID="hidType" runat="server" Value="lcl" />
        <asp:HiddenField ID="hidStartport" runat="server" Value="" />
        <asp:HiddenField ID="hidDestport" runat="server" Value="" />
        <asp:HiddenField ID="hidCarrier" runat="server" Value="" />
        <asp:HiddenField ID="hidLine" runat="server" Value="0" />    
    <asp:DropDownList ID="txtLine" runat="server" Width=105 Font-Size="12px">
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
    <td width="7%" align="right">起运港：</td>
    <td width="13%">
    <asp:TextBox ID="txtStartport" runat="server" Width="130px"></asp:TextBox> 
    </td>
    <td width="7%" align="right">目的港：</td>
    <td width="14%">
<asp:TextBox ID="txtDestport" runat="server" Width="130px"></asp:TextBox> 
    </td>
    <td width="7%" align="right">船公司：</td>
    <td width="14%">
    <asp:TextBox ID="txtCarrier" runat="server" Width="100px"></asp:TextBox> 
    </td>
    <td align="center" valign="middle">
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/fcl/search.gif" width="128" height="28" border="0"  />
    </td>
  </tr>
</table>

</div>
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
您搜索的是：&nbsp;
<asp:Label ID="Label9" runat="server" Text="船公司："></asp:Label><b><asp:Label ID="hidTxtCarrier" runat="server" ></asp:Label></b>&nbsp;
<asp:Label ID="Label10" runat="server" Text="起运港："></asp:Label><b><asp:Label ID="hidTxtStartport" runat="server" ></asp:Label></b>&nbsp;
<asp:Label ID="Label11" runat="server" Text="目的港："></asp:Label><b><asp:Label ID="hidTxtDestport" runat="server" ></asp:Label></b>&nbsp;
<asp:Label ID="Label12" runat="server" Text="航线："></asp:Label><b><asp:Label ID="hidTxtLine" runat="server" ></asp:Label></b>&nbsp;                    
</p>
</div>
<div class="freight_List_title">
<h2><img src="/images/fcl/px_ico.gif" />拼箱海运价列表</h2>
      <a href="/member/releaseselect.aspx" target="_blank">我要发布运价</a> <img style="margin-right:3px;" src="/images/fcl/whao.gif" /><a href="/help/help_fcl.html#tips" target="_blank">相关帮助</a>
</div>
<div class="biaoti" style="position:relative;">
<div style="position:absolute; left:620px; top:6px; width:270px;"><p class="notice_bar">向货代发送网上订舱单,运价服务受保障</p></div>
<table width="950" height="44" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="1" bgcolor="#CAC9C7"><img src="/images/fcl/biaoti_bg.gif" /></td>
<td background="/images/fcl/biaoti_bg2.gif"><table border="0" cellspacing="1" cellpadding="0">
<tr>
<td width="8" align="left" ></td>
<td width="70" align="left" class="gray">航线</td>
<td width="111" align="left" class="gray">起运港</td>
<td width="125" align="left" class="gray">目的港</td>
<td width="89" align="left" class="gray">价格(重量)</td>
<td width="90" align="left" class="gray">价格(体积)</td>
<td width="65" align="left" class="gray">船公司</td>
<td width="90" align="left" class="gray">订舱保证</td>
</tr>
</table></td>
<td width="1" ><img src="/images/fcl/biaoti_bg3.gif" /></td>
</tr>
</table>
</div>

<div class="main_left"><!--左边开始-->
<div class="freight_List">
<div class="list_box">
<asp:Repeater ID="Rptfcl" runat="server">
<ItemTemplate>

<ul>
<li>
<table width="742" height="75" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="15" height="80" align="center"><table width="15" border="0" cellpadding="0" cellspacing="1" class="fcl_spbox">
<tr>
<td width="2%" height="24" align="right">·<div style="display:none"><asp:Label ID="Label1"  runat="server" Text='<%# eval("sid") %>'></asp:Label><asp:Label ID="Label2"  runat="server" Text='<%#Eval("userid")%> '></asp:Label></div></td>
</tr>
<tr>
<td height="24" bordercolor="0">&nbsp;</td>
</tr>
<tr>
<td height="24" bordercolor="0">&nbsp;</td>
</tr>
</table></td>
<td width="552" onmouseover="tt('<%#Rptfcl.Items.Count %>','pop_a_<%# eval("sid") %>',event)" onmouseout="hidden(event)"><table width="552" height="80" border="0" cellpadding="0" cellspacing="0">
<tr>
<td colspan="3" id="pop_a_<%# eval("sid") %>"><a href="/lcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#GetFirstString(Eval("title").ToString, 24)%></a>
<span class="gray_2">[<%#Format(Eval("postdate"), "yy").ToString%>/<%#Format(Eval("postdate"), "MM").ToString%>/<%#Format(Eval("postdate"), "dd").ToString%> 至 <%#Format(CDate(Eval("enddate")), "yy").ToString%>/<%#Format(CDate(Eval("enddate")), "MM").ToString%>/<%#Format(CDate(Eval("enddate")), "dd").ToString%>]</span></td>
</tr>
<tr>
<td width="307"><table width="90%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="28%" align="left"><%#Eval("hangxianmiaoshu").ToString%></td>
<td width="37%" align="left" class="blue_2"><%#GetFirstString(IIf(GetQueryString("sp") = "0", Eval("startport").ToString, GetQueryString("sp")), 6)%></td>
<td width="37%" align="left" class="blue_2"><%#GetFirstString(IIf(GetQueryString("dp") = "0", Eval("destport").ToString, GetQueryString("dp")), 8)%></td>
</tr>
</table></td>
<td width="182"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="blue_2" width="50%"><%#GetFirstString(Eval("pricegp").ToString, 4)%></td>
<td class="blue_2" width="50%"><%#GetFirstString(Eval("pricegpv").ToString, 4)%></td>
</tr>
</table></td>
<td width="63"><span class="gray"><%#GetFirstString(IIf(GetQueryString("cr") = "0", Eval("shipcompany").ToString, GetQueryString("cr")), 5)%></span></td>
</tr>
<tr>
<td colspan="3" class="gray_2"><a href="/company/<%# key(eval("userid"))%>/" target="_blank" style="color:#666666;"><%#GetFirstString(Eval("companyname").ToString, 50)%></a><a href="/company/<%# key(eval("userid"))%>/" target="_blank"><%#Star1(Eval("star_allin").ToString)%></a>&nbsp;
<%#Star3(Eval("star_user").ToString)%><span class="yt"><a href="/company/<%# key(eval("userid"))%>/" target="_blank"><%#Star2(Eval("star_user").ToString)%></a></span></td>
</tr>
</table></td>
<td width="70" valign="top"><table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="fcl_spbox">
<tr>
<td height="24" align="center" bordercolor="0"><a href="/help/services_2.aspx" style="display:<%#IIf (CInt(Eval("assurance").ToString) <> 0,"","none")%>" onmouseover="tt_cwpop(event);" onmouseout="hid_cwpop();"><img src="/images/fcl/fc_r1_c1.gif" width="69" height="18" border="0" /></a></td>
</tr>
<tr>
<td height="24" align="center" bordercolor="0"><a href="/help/services_1.aspx" style="display:<%#IIf (CInt(Eval("star_allin").ToString) <> 0,"","none")%>" onmouseover="tt_jgpop(event);" onmouseout="hid_jgpop();"><img src="/images/fcl/fc_r3_c1.gif" width="69" height="18" border="0" /></a></td>
</tr>
</table></td>
<td width="105" align="center"><a href="/search/order_temp.aspx?type=lcl&filter=new&yid=<%# Eval("sid") %>&ydid=<%# Eval("id") %>&f=<%# Eval("userid") %>" target="_blank"  onmouseover="tt_dcpop(event);" onmouseout="hid_dcpop();"><img src="/images/fcl/dingc_r5_c1.jpg" width="68" height="29" border=0 /></a></td>
</tr>
</table>
</li>
</ul>

</ItemTemplate>
</asp:Repeater>
<asp:PlaceHolder ID="phNoResult" runat="server" Visible="false">
<div style="width:100%; padding:30px 0px 30px 0px; text-align:center; font-size:14px;">
抱歉，该港口暂时没有运价发布，<a title="欢迎使用在线客服" href="#" onclick="document.getElementById('service_link').click();"><b>点击这里</b></a> 客服中心帮助您寻找运价
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
<input id="btnPageJump" name="btnPageJump" type="button" value="确定" style=" width:40px; height:20px;" runat="server"/>
</DIV>
</td>
</tr>
</table>
</div>
</div>
<div class="ad" style="display:none;">
<a href="/topic/carrier090630/" target="_blank"><img src="/images/index/carrier_20090701.gif" width="742" height="65" border="0" alt="船公司专题"/></a>
</div>				
			
</div><!--左边结束-->	
<div class="main_right"><!--右边开始-->
</div>	
  		</div>
	  <userlinkbottom2:userlinkbottom2 ID="userlinkbottom21" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
    </form>

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
