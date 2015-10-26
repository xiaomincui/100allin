<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test_services.aspx.cs" Inherits="test_services" %>
<%@ OutputCache Duration="120" VaryByParam="none" VaryByCustom="SessionID"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="最新运费,海运运费,空运运费,整箱运价,拼箱运价,运价排行,货运代理,货主,运价查询" />
<meta name="description" content="环球运费网是全球最大的专业运费查询平台,主要提供全面,高效,简捷的海运空运运价的发布和查询服务,拥有海量货主会员进行运费查询和对比,更多运费查询信息请点击进入" />
<asp:Literal id="Literal1" runat="server"><title>环球运费网是全球最大的海运空运运价B2B平台,空运费海运费查询与发布平台</title></asp:Literal>
<meta name="verify-v1" content="2GJHw6PkclRHULfOZ1pBCMO+5aWClHL2ZEUirlXgwwA=" />
<link href="/css/index0122.css" rel="stylesheet" type="text/css" />
<link href="/css/home.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/js/function.js"></script>
<script src="/topic/lcl090619/js/jquery-1.2.1.pack.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/MSClass.js"></script>
<script type="text/javascript" src="/js/home.js"></script>
</head>
<body>
<form id="form1" runat="server" autocomplete="off">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="main" style="position:relative;">
<DIV class=sabrosus> 
<SPAN class=current id="csbsp01" onclick="dyts3.showtab(0);dyts3.clearautoshow();">1</SPAN>
<SPAN class=notcurrent id="csbsp02" onclick="dyts3.showtab(1);dyts3.clearautoshow();">2</SPAN>
<SPAN class=notcurrent id="csbsp03" onclick="dyts3.showtab(2);dyts3.clearautoshow();">3</SPAN>		
</DIV>	
<div class="head">
<div class="head_top">
<h2><asp:Label ID="Label8" runat="server" Text=""></asp:Label> <a href="/accounts/reg.aspx">[免费注册]</a></h2>
<ul>
<li><a href="/member/">我的办公室</a>&nbsp;|&nbsp;</li>
<li><a href="/topic/order20091104/product_1.aspx" target="_blank">安运通</a>&nbsp;|&nbsp;</li>
<li><a href="/topic/order20091104/product_4.aspx" target="_blank">订舱</a>&nbsp;|&nbsp;</li>
<li><a href="/help/help_about.html" target="_blank">帮助</a>&nbsp;&nbsp;</li>
</ul>
</div>
<div class="head_mid">
<div id="logo"><a href="/"><img src="/images/index/logo.jpg" alt="环球运费网" border="0" /></a></div>
<div class="search_bar">
<div class="search_bar_box">
<div class="search_bar_t">
<ul>
<li class="set" id="fcl_search_tab"><a href="/fcl/" onmouseover="change_search('fcl_search');">整箱海运价</a></li>
<li id="lcl_search_tab"><a href="/lcl/" onmouseover="change_search('lcl_search');">拼箱海运价</a></li>
<li id="air_search_tab"><a href="/air/" onmouseover="change_search('air_search');">空运运价</a></li>
<li id="company_search_tab"><a href="/company/" onmouseover="change_search('company_search');">公司库</a></li>
</ul>
<div class="search_form" id="fcl_search">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="130"><div id="select">
<span id="select_text">
<span class="select-style">
<select name="txtLine" id="txtLine" style="width:115px; color:#AAAAAA;" onkeydown="KeyDown(event);" onfocus="javascript:this.style.color='#000000';"  onblur="javascript:this.style.color='#AAAAAA';">
<option value="">全部航线</option>
<option value="美加线">美加线</option>
<option value="欧地线">欧地线</option>
<option value="中南美线">中南美线</option>
<option value="日韩线">日韩线</option>
<option value="近洋线">近洋线</option>
<option value="非洲线">非洲线</option>
<option value="澳洲线">澳洲线</option>
<option value="中东印巴线">中东印巴线</option>
<option value="红海线">红海线</option>
</select>
</span></span>
</div></td>
<td width="176">
<asp:TextBox ID="txtStartport" runat="server" CssClass="text_area" ForeColor="#CCCCCC" Text="起运港"></asp:TextBox>
<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
TargetControlID="txtStartport" 
CompletionSetCount="25" 
EnableCaching="true" 
MinimumPrefixLength="1" 
ServicePath="sql_test.asmx" 
CompletionListElementID="dropdown1" 
ServiceMethod="GetShippingStartPortList" CompletionInterval="100" > 
</ajaxToolkit:AutoCompleteExtender>
</td>
<td width="176">
<asp:TextBox ID="txtDestport" runat="server" CssClass="text_area" ForeColor="#CCCCCC" Text="目的港"></asp:TextBox>
<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
TargetControlID="txtDestport" 
CompletionSetCount="1000" 
EnableCaching="true" 
MinimumPrefixLength="1" 
ServicePath="sql_test.asmx" 
CompletionListElementID="dropdown2" 
ServiceMethod="GetShippingPortList" CompletionInterval="100" > 
</ajaxToolkit:AutoCompleteExtender> 
</td>
<td width="97">
<asp:TextBox ID="txtCarrier" runat="server" CssClass="ship_area" ForeColor="#CCCCCC" Text="船公司"></asp:TextBox>
<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
TargetControlID="txtCarrier" 
CompletionSetCount="1000" 
EnableCaching="true" 
MinimumPrefixLength="1" 
ServicePath="sql_test.asmx" 
CompletionListElementID="dropdown3" 
ServiceMethod="GetCarrierList" CompletionInterval="100" > 
</ajaxToolkit:AutoCompleteExtender>
</td>
<td>
<a href="/fcl/" id="fcl_jump" target="_blank" onclick="search_fcl_jump();"><img src="/images/index/bot1.GIF" border="0" /></a></td>
</tr> 
</table>
</div>

<div class="search_form" id="lcl_search" style="display:none;">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="130"><div id="Div1">
<span id="Span1">
<span class="select-style">
<select name="txtLine2" id="txtLine2" style="width:115px; color:#AAAAAA;" onkeydown="KeyDown(event);" onfocus="javascript:this.style.color='#000000';"  onblur="javascript:this.style.color='#AAAAAA';">
<option value="">全部航线</option>
<option value="美加线">美加线</option>
<option value="欧地线">欧地线</option>
<option value="中南美线">中南美线</option>
<option value="日韩线">日韩线</option>
<option value="近洋线">近洋线</option>
<option value="非洲线">非洲线</option>
<option value="澳洲线">澳洲线</option>
<option value="中东印巴线">中东印巴线</option>
<option value="红海线">红海线</option>
</select>
</span></span>
</div></td>
<td width="176">
<asp:TextBox ID="txtStartport2" runat="server" CssClass="text_area" ForeColor="#CCCCCC" Text="起运港"></asp:TextBox>
<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" 
TargetControlID="txtStartport2" 
CompletionSetCount="25" 
EnableCaching="true" 
MinimumPrefixLength="1" 
ServicePath="sql_test.asmx" 
CompletionListElementID="dropdown1" 
ServiceMethod="GetShippingStartPortList" CompletionInterval="100" > 
</ajaxToolkit:AutoCompleteExtender>
</td>
<td width="176">
<asp:TextBox ID="txtDestport2" runat="server" CssClass="text_area" ForeColor="#CCCCCC" Text="目的港"></asp:TextBox>
<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" 
TargetControlID="txtDestport2" 
CompletionSetCount="1000" 
EnableCaching="true" 
MinimumPrefixLength="1" 
ServicePath="sql_test.asmx" 
CompletionListElementID="dropdown2" 
ServiceMethod="GetShippingPortList" CompletionInterval="100" > 
</ajaxToolkit:AutoCompleteExtender> 
</td>
<td width="97">
<asp:TextBox ID="txtCarrier2" runat="server" CssClass="ship_area" ForeColor="#CCCCCC" Text="船公司"></asp:TextBox>
<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" 
TargetControlID="txtCarrier2" 
CompletionSetCount="1000" 
EnableCaching="true" 
MinimumPrefixLength="1" 
ServicePath="sql_test.asmx" 
CompletionListElementID="dropdown3" 
ServiceMethod="GetCarrierList" CompletionInterval="100" > 
</ajaxToolkit:AutoCompleteExtender>
</td>
<td>
<a href="/fcl/" id="lcl_jump" target="_blank" onclick="search_lcl_jump();"><img src="/images/index/bot1.GIF" border="0" /></a></td>
</tr> 
</table>
</div>

<div class="search_form" id="air_search" style="display:none;">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="130"><div id="Div2">
<span id="Span2">
<span class="select-style">
<select name="txtLine3" id="txtLine3" style="width:115px; color:#AAAAAA;" onkeydown="KeyDown(event);" onfocus="javascript:this.style.color='#000000';"  onblur="javascript:this.style.color='#AAAAAA';">
<option value="">全部航线</option>
<option value="美加线">北美线</option>
<option value="欧地线">欧洲线</option>
<option value="中南美线">南美线</option>
<option value="日韩线">亚洲线</option>
<option value="近洋线">非洲线</option>
<option value="非洲线">澳洲线</option>
<option value="澳洲线">国内航线</option>
</select>
</span></span>
</div></td>
<td width="220">
<asp:TextBox ID="txtStartport3" runat="server" CssClass="text_area3" ForeColor="#CCCCCC" Text="起运地"></asp:TextBox>
<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender7" runat="server" 
TargetControlID="txtStartport3" 
CompletionSetCount="1000" 
EnableCaching="true" 
MinimumPrefixLength="1" 
ServicePath="sql_test.asmx" 
CompletionListElementID="dropdown4"
ServiceMethod="GetAirPortList" CompletionInterval="100" > 
</ajaxToolkit:AutoCompleteExtender>
</td>
<td width="229">
<asp:TextBox ID="txtDestport3" runat="server" CssClass="text_area3" ForeColor="#CCCCCC" Text="目的地"></asp:TextBox>
<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender8" runat="server" 
TargetControlID="txtDestport3" 
CompletionSetCount="1000" 
EnableCaching="true" 
MinimumPrefixLength="1" 
ServicePath="sql_test.asmx" 
CompletionListElementID="dropdown5" 
ServiceMethod="GetAirPortList" CompletionInterval="100" > 
</ajaxToolkit:AutoCompleteExtender> 
</td>
<td>
<a href="/air/" id="air_jump" target="_blank" onclick="search_air_jump();"><img src="/images/index/bot1.GIF" border="0" /></a></td>
</tr> 
</table>
</div>

<div class="search_form" id="company_search" style="display:none;">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="579">
<asp:TextBox ID="txtCompanyName" runat="server" CssClass="text_area4" ForeColor="#CCCCCC" Text="公司名称"></asp:TextBox>
</td>
<td>
<a href="/company/" id="company_jump" target="_blank" onclick="search_company_jump();"><img src="/images/index/bot1.GIF" border="0" /></a></td>
</tr> 
</table>
</div>
</div>
<div class="fcl_bar" style="display:none;"></div>
</div>
</div>
</div>
<div class="head_nav">
<ul>
<li class="st"><a href="/">首页</a></li>
<li class="divider"></li>
<li><a href="/fcl/">整箱海运价</a></li>
<li class="divider"></li>
<li><a href="/lcl/">拼箱海运价</a></li>
<li class="divider"></li>
<li><a href="/air/">空运运价</a></li>
<li class="divider"></li>
<li><a href="/cargo/">货盘信息</a></li>
<li class="divider"></li>
<li><a href="/company/">公司库</a></li>
<li class="divider"></li>
<li><a href="/bbs/">论坛</a></li>
<li class="divider"></li> 
<li><a href="/home/space.php?do=home">社区</a></li>
</ul>
</div>
</div>
<div class="container">
<div class="container_left">
<div class="left_topbar">
<div class="ad_1"><a href="/vote/20091106/" target="_blank"><img src="/images/index/ad_1.gif" border="0" /></a></div>
<asp:Repeater ID="rpttitle" runat="server" >
<ItemTemplate>			
<div style="margin-top:-3px;"><div class="center_show_box" style="display:none; margin-top:2px;" id="csb0<%#Eval("id")%>" onmouseover="dyts3.showtab(<%#(Convert.ToInt32(Eval("id"))-1).ToString()%>);dyts3.clearautoshow();" onmouseout="dyts3.autoshow();">
<div class="show_box_pic">
<h3><%#Eval("title")%></h3>
<a href="<%#Eval("image_link")%>" target="_blank"><img src="/images/index/showpic<%#Eval("id")%>.jpg" border="0" width="204px" height="147px" /></a>					    </div>
<div class="show_box_title">
<h2><a href="<%#Eval("row1_link")%>" target="_blank"><%#Eval("row1")%></a></h2>
<div class="title_link">
<%#Eval("row2")%></div>
<div class="title_link" style="background-color:#E9F4F6;">
<strong><a href="<%#Eval("row3_link")%>" style="color:#555555;" target="_blank"><%#Eval("row3_1")%></a></strong><br />
<a href="<%#Eval("row3_link")%>" style="color:#36658E;" target="_blank">·<%#Eval("row3_2")%></a></div>
<div class="title_link">
<strong><a href="<%#Eval("row4_link")%>" style="color:#555555;" target="_blank"><strong><%#Eval("row4_1")%></strong></a></strong><br />
<a href="<%#Eval("row4_link")%>" style="color:#36658E;" target="_blank">·<%#Eval("row4_2")%></a></div>
</div>
<div class="show_box_bot"><span>
<a href="/fcl/">整箱运价</a>：<span class="orange"><%#Convert.ToInt32(Eval("fclcount")).ToString("#,#")%></span> &nbsp;&nbsp;
<a href="/lcl/">拼箱运价</a>：<span class="orange"><%#Convert.ToInt32(Eval("lclcount")).ToString("#,#")%></span> &nbsp;&nbsp;
<a href="/air/">空运运价</a>：<span class="orange"><%#Convert.ToInt32(Eval("aircount")).ToString("#,#")%></span></span></div>
</div></div>
</ItemTemplate>
</asp:Repeater>				  
<script language="javascript" type="text/javascript" src="/js/home_2.js"></script>
<div class="topic">
<h2><img style="vertical-align:middle; margin-right:4px;" src="/images/index/eyes.gif" /><a href="#">专题聚焦</a></h2>
<p>
·<a href="/topic/lcl090619/" target="_blank">拼箱</a><br />
·<a href="/topic/air090716/" target="_blank">空运</a><br />
</p>
</div>
</div>
<div class="left_botbar">	
<div class="left_tools">
<div class="tool_box">
<h2><img src="/images/index/jt2.gif" />&nbsp;<a href="/baf/">附加费快报</a></h2>
<p>
·<a class="red" href="/baf/" target="_blank"><strong><%=DateTime.Now.Month.ToString() %>月最新BAF/CAF</strong></a><br />
·<a href="/caf/" target="_blank"><%=DateTime.Now.Month.ToString() %>月最新CAF</a><br />
·<a href="/thc/" target="_blank"><%=DateTime.Now.Month.ToString() %>月各大船公司最新THC</a><br />
·<a href="/orc/" target="_blank"><%=DateTime.Now.Month.ToString() %>月最新ORC</a>
</p>
<h2><img src="/images/index/jt2.gif" />&nbsp;<a href="/bis/insurance.aspx">商务服务</a></h2>
<p>
- <a href="/bis/insurance.aspx">保险</a>&nbsp;&nbsp;<a href="/bis/bank.aspx">银行</a><br />
- <a href="/bis/nvocc.aspx">NVOCC</a>&nbsp;&nbsp;<a href="/bis/commodity.aspx">报关商检</a><br />
- <a href="/bis/hongkong.aspx">香港公司</a><br />
</p>
<h2><img src="/images/index/jt2.gif" />&nbsp;<a href="#">八大港口</a></h2>
<p>
- <a href="/port/shenzhen/">深圳港</a>&nbsp;&nbsp;<a href="/port/shanghai/">上海港</a>&nbsp;&nbsp;<a href="/port/guangzhou/">广州港</a><br />
- <a href="/port/qingdao/">青岛港</a>&nbsp;&nbsp;<a href="/port/tianjin/">天津港</a>&nbsp;&nbsp;<a href="/port/dalian/">大连港</a><br />
- <a href="/port/ningbo/">宁波港</a>&nbsp;&nbsp;<a href="/port/xiamen/">厦门港</a><br />
</p>
</div>
<div class="ad_2"><a href="/topic/order20091104/product_2.aspx" target="_blank"><img src="/images/index/l_ad1.gif" border="0" alt="安运通免费体验活动" /></a></div>
<div class="tool_box" style="margin-bottom:0px;">
<h2><img src="/images/index/jt3.gif" />&nbsp;<a href="/tools/">常用工具</a></h2>
<p>
<a href="/tools/hs.aspx" target="_blank">HS编码</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<a href="/tools/tax.aspx" target="_blank">海关税率</a><br />
<a href="/tools/airports.aspx" target="_blank">空运港口代码</a>&nbsp;&nbsp;
<a href="/tools/dangerous.aspx" target="_blank">危险品标志</a><br />
<a href="/tools/airlines.aspx" target="_blank">航空公司代码</a>&nbsp;&nbsp;
<a href="/tools/flow.aspx" target="_blank">外贸单证流程</a><br />
<a href="/tools/guarantee.aspx" target="_blank">保函样本</a><br />						
</p>
<h2><img src="/images/index/jt3.gif" />&nbsp;<a href="intro/rate.aspx">最新汇率</a></h2>
<p>
<span id="nowtime"></span><br />
        <script language="javascript">
            function nowtime(){   
                var now=new Date();
                var Y = FormatDigit(now.getYear());     //得到年 
                var M = FormatDigit(now.getMonth()+1);     //得到月   
                var D = FormatDigit(now.getDate());     //得到日 
                var h = FormatDigit(now.getHours());     //得到小时 
                var m = FormatDigit(now.getMinutes());     //得到分钟
                var s = FormatDigit(now.getSeconds());     //得到秒
                document.all["nowtime"].innerHTML= Y + "年" + M + "月" + D +"日 " + h + ":" + m + ":" + s;
            }                             
            setInterval('nowtime()',1000); 
        </script>
1美元= <span class="orange"><strong><asp:Literal ID="ltrRate1" runat="server"></asp:Literal></strong></span>人民币<br />
1欧元= <span class="orange"><strong><asp:Literal ID="ltrRate2" runat="server"></asp:Literal></strong></span>人民币<br />
100日元= <span class="orange"><strong><asp:Literal ID="ltrRate3" runat="server"></asp:Literal></strong></span>人民币<br />
100港币= <span class="orange"><strong><asp:Literal ID="ltrRate4" runat="server"></asp:Literal></strong></span>人民币
</p>
</div>
</div>
<div class="right_info">
<div class="ask">
<div style="position:relative; ">
<div style="border:1px solid #d8a9a9;background:#F8FBFE;line-height:20px;position:absolute;top:35px; left:35px; width:300px; display:none; " id="div_sub_qsyj">
<p style="border:3px solid #ffebeb;padding:5px 8px;">环球运费网及时显示用户未搜索运价的港口，如您能把握商机及时补全价格，则将大大成交概率。</p></div>
</div>
<div id="scrollLcl" onmouseover="document.getElementById('div_sub_qsyj').style.display = ''" onmouseout="document.getElementById('div_sub_qsyj').style.display = 'none'">
<asp:DataList ID="RptaPriceNeed" runat="server" CellPadding="0" RepeatDirection="Horizontal" RepeatColumns="2">
<ItemTemplate>
<a href="/member/<%# Eval("Y").ToString() == "8" ? "Release":"SpellRelease" %>.aspx?DestPort=<%# Eval("destport") %>&StartPort=<%# Eval("startport") %>" target="_blank"><%# Eval("startport")%>到<%# Eval("destport")%> <%# Eval("Y").ToString() == "8" ? "[整箱]" : "[拼箱]" %></a>
</ItemTemplate>
</asp:DataList>
</div>
<script src="/js/home_scroll.js" type="text/javascript"></script>
</div>
<div class="info_box">
<h2><img src="/images/index/ico_1.GIF" /><a href="/fcl/">最新整箱海运价</a><a style="font:12px '宋体'; font-weight:normal; margin-left:310px;" href="/fcl/">更多>></a></h2>
<ul>
<li class="info_box_tit" style=" border:none;">
<table width="100%" border="0" cellpadding="0" cellspacing="0" background="/images/index/info_bg3.gif">
<tr>
<td width="40%" height="26">标题</td>
<td width="15%">起运港</td>
<td width="28%">公司</td>
<td width="17%">航线</td>
</tr>
</table>
</li>
<asp:Repeater ID="Rptfcl" runat="server" OnPreRender="Rptfcl_ItemDataBound">
<ItemTemplate>
<li>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="1">
<tr>
<td width="40%">
<asp:Literal ID="Literal1" runat="server" Text='<%# Eval("id")%>' Visible="false"></asp:Literal>
<asp:Literal ID="Literal2" runat="server" Text='<%# Eval("userid")%>' Visible="false"></asp:Literal>
<a href="/fcl/<%#setkey(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>"><%#GetFirstString(Eval("title").ToString(),26)%></a></td>
<td width="15%"><%#GetFirstString(Eval("startport").ToString(),6)%></td>
<td width="28%"><a href="/company/<%# setkey(Eval("userid").ToString())%>/" target="_blank" title="<%#Eval("companyname").ToString()%>"><%#GetFirstString(Eval("companyname").ToString(),16)%></a></td>
<td width="17%"><%#Eval("hangxianmiaoshu").ToString().Replace("线","")%></td>
</tr>
</table>
</li>
</ItemTemplate>
</asp:Repeater>
</ul>
</div>
<div class="info_box">
<h2 style="background:url(images/index/info_bg2_2.gif) no-repeat bottom;"><img src="/images/index/ico_2.GIF" width="14" height="14" /><a href="/lcl/">最新拼箱海运价</a><a style="font:12px '宋体'; font-weight:normal; margin-left:310px;" href="/lcl/">更多>></a></h2>
<ul>
<li class="info_box_tit" style=" border:none;">
<table width="100%" border="0" cellpadding="0" cellspacing="0" background="/images/index/info_bg3.gif">
<tr>
<td width="40%" height="26">标题</td>
<td width="15%">起运港</td>
<td width="28%">公司</td>
<td width="17%">航线</td>
</tr>
</table>
</li>
<asp:Repeater ID="Rptlcl" runat="server" OnPreRender="Rptlcl_ItemDataBound">
<ItemTemplate>							
<li>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="1">
<tr>
<td width="40%">
<asp:Literal ID="Literal1" runat="server" Text='<%# Eval("id")%>' Visible="false"></asp:Literal>
<asp:Literal ID="Literal2" runat="server" Text='<%# Eval("userid")%>' Visible="false"></asp:Literal>
<a href="/lcl/<%#setkey(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>"><%#GetFirstString(Eval("title").ToString(),26)%></a></td>
<td width="15%"><%#GetFirstString(Eval("startport").ToString(),6)%></td>
<td width="28%"><a href="/company/<%# setkey(Eval("userid").ToString())%>/" target="_blank" title="<%#Eval("companyname").ToString()%>"><%#GetFirstString(Eval("companyname").ToString(),16)%></a></td>
<td width="17%"><%#Eval("hangxianmiaoshu").ToString().Replace("线","")%></td>
</tr>
</table>
</li>
</ItemTemplate>
</asp:Repeater>
</ul>
</div>
<div class="info_box" style="border-bottom:1px solid #ABCADE;">
<h2 style="background:url(images/index/info_bg2_3.gif) no-repeat bottom;"><img src="/images/index/ico_3.GIF" width="14" height="14" /><a href="/air/">最新空运运价</a><a style="font:12px '宋体'; font-weight:normal; margin-left:324px;" href="/air/">更多>></a></h2>
<ul>
<li class="info_box_tit" style=" border:none;">
<table width="100%" border="0" cellpadding="0" cellspacing="0" background="/images/index/info_bg3.gif">
<tr>
<td width="40%" height="26">标题</td>
<td width="15%">起运港</td>
<td width="28%">公司</td>
<td width="17%">航线</td>
</tr>
</table>
</li>
<asp:Repeater ID="Rptair" runat="server" OnPreRender="Rptair_ItemDataBound">
<ItemTemplate>							
<li>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="1">
<tr>
<td width="40%">
<asp:Literal ID="Literal1" runat="server" Text='<%# Eval("id")%>' Visible="false"></asp:Literal>
<asp:Literal ID="Literal2" runat="server" Text='<%# Eval("userid")%>' Visible="false"></asp:Literal>
<a href="/air/<%#setkey(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>"><%#GetFirstString(Eval("title").ToString(),26)%></a></td>
<td width="15%"><%#GetFirstString(Eval("startport").ToString(),6)%></td>
<td width="28%"><a href="/company/<%# setkey(Eval("userid").ToString())%>/" target="_blank" title="<%#Eval("companyname").ToString()%>"><%#GetFirstString(Eval("companyname").ToString(),16)%></a></td>
<td width="17%"><%#Eval("hangxianmiaoshu").ToString().Replace("线","")%></td>
</tr>
</table>
</li>
</ItemTemplate>
</asp:Repeater>
</ul>
</div>
<div class="gzhu">
<h2><img src="/images/index/ico_4.GIF" width="15" height="14" />&nbsp;当月运价关注排行</h2>
<p><strong>整箱海运</strong> | 
<a href="/billboard/topview.aspx?type=fcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=shanghai&l=" target="_blank">上海</a>  
<a href="/billboard/topview.aspx?type=fcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=ningbo&l=" target="_blank">宁波</a>  
<a href="/billboard/topview.aspx?type=fcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=shenzhen&l=" target="_blank">深圳</a>  
<a href="/billboard/topview.aspx?type=fcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=qingdao&l=" target="_blank">青岛</a>  
<a href="/billboard/topview.aspx?type=fcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=tianjin&l=" target="_blank">天津</a>  
<a href="/billboard/topview.aspx?type=fcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=guangzhou&l=" target="_blank">广州</a>  
<a href="/billboard/topview.aspx?type=fcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=xiamen&l=" target="_blank">厦门</a>  
<a href="/billboard/topview.aspx?type=fcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=dalian&l=" target="_blank">大连</a>  
<a href="/billboard/topview.aspx?type=fcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=lianyungang&l=" target="_blank">连云港</a>  
<a href="/billboard/topview.aspx?type=fcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=&l=" target="_blank">更多>></a>
</p>
<p><strong>拼箱海运</strong> | 
<a href="/billboard/topview.aspx?type=lcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=shanghai&l=" target="_blank">上海</a>  
<a href="/billboard/topview.aspx?type=lcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=ningbo&l=" target="_blank">宁波</a>  
<a href="/billboard/topview.aspx?type=lcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=shenzhen&l=" target="_blank">深圳</a>  
<a href="/billboard/topview.aspx?type=lcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=qingdao&l=" target="_blank">青岛</a>  
<a href="/billboard/topview.aspx?type=lcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=tianjin&l=" target="_blank">天津</a>  
<a href="/billboard/topview.aspx?type=lcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=guangzhou&l=" target="_blank">广州</a>  
<a href="/billboard/topview.aspx?type=lcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=xiamen&l=" target="_blank">厦门</a>  
<a href="/billboard/topview.aspx?type=lcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=dalian&l=" target="_blank">大连</a>  
<a href="/billboard/topview.aspx?type=lcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=lianyungang&l=" target="_blank">连云港</a>  
<a href="/billboard/topview.aspx?type=lcl&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=&l=" target="_blank">更多>></a>
</p>
<p><strong>空运</strong> | 
<a href="/billboard/topview.aspx?type=air&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=shanghai&l=" target="_blank">上海</a>  
<a href="/billboard/topview.aspx?type=air&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=ningbo&l=" target="_blank">宁波</a>  
<a href="/billboard/topview.aspx?type=air&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=shenzhen&l=" target="_blank">深圳</a>  
<a href="/billboard/topview.aspx?type=air&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=qingdao&l=" target="_blank">青岛</a>  
<a href="/billboard/topview.aspx?type=air&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=tianjin&l=" target="_blank">天津</a>  
<a href="/billboard/topview.aspx?type=air&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=guangzhou&l=" target="_blank">广州</a>  
<a href="/billboard/topview.aspx?type=air&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=xiamen&l=" target="_blank">厦门</a>  
<a href="/billboard/topview.aspx?type=air&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=dalian&l=" target="_blank">大连</a>  
<a href="/billboard/topview.aspx?type=air&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=lianyungang&l=" target="_blank">连云港</a>  
<a href="/billboard/topview.aspx?type=air&y=<%=DateTime.Now.Year.ToString() %>&m=<%=DateTime.Now.Month.ToString() %>&sp=&l=" target="_blank">更多>></a>
</p>
</div>
</div>
</div>
<div class="ad_3"><img src="/images/index/ad_3.gif" width="703" height="69"/></div>
</div>
<div class="container_right" style="position:relative;">
<div style="border:1px solid #4F89AF;background:#F8FBFE;padding:8px;line-height:20px;position:absolute;top:70px; left:11px; display:none;" id="release_freight" onmouseover="show_release_freight();" onmouseout="hide_release_freight();">
<a href="/member/Release.aspx" target="_blank">整箱海运</a> <br/>
<a href="/member/SpellRelease.aspx" target="_blank">拼箱海运</a> <br/>
<a href="/member/AirRelease.aspx" target="_blank">空运运价</a> 
</div>
<div style="border:1px solid #4F89AF;background:#F8FBFE;padding:8px;line-height:20px;position:absolute;top:70px; left:83px; display:none;" id="release_cargo" onmouseover="show_release_cargo();" onmouseout="hide_release_cargo();">
<a href="/member/temp_add_ship.aspx" target="_blank">海运货盘</a> <br/>
<a href="/member/temp_add_air.aspx" target="_blank">空运货盘</a>
</div> 
<asp:PlaceHolder ID="PlaceHolder1" runat="server">
<div class="login">
<div class="login_top">
<div class="login_bar" style="position:relative:">
<input type="text" style="color:#ccc" value="输入用户名" onfocus="focusit()" onblur="blurit()" id="txtUsername" runat="server"/><br />
<input type="password" value="" onfocus="focusit1()" onblur="blurit1()" id="txtPassword" runat="server" />
<div style="position:absolute;left:18px;top:55px;color:#ccc" id="password_tip">输入密码</div>
</div>
<div class="bot"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/index/bot.gif" TabIndex="3" OnClick="ImageButton1_Click" /><br />
<a href="/accounts/reg.aspx">立即注册</a></div>
</div>
<div class="login_bot"><asp:CheckBox ID="chkAutoLogin" runat="server" Checked="True" />自动登录 | <a href="#">忘记密码</a> | <a href="#">在线客服</a></div>           
</div>
</asp:PlaceHolder>

<asp:PlaceHolder ID="PlaceHolder2" runat="server">
<div class="login_2">
<div class="login_2_top"><div class="r"><asp:LinkButton ID="LinkButton1" runat="server"  OnClick="LinkButton1_Click">退出登录</asp:LinkButton>&nbsp;</div>
欢迎您！<img src="images/index/people.gif" width="14" height="14" /><asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>
<div class="login_2_mid" ><a href="javascript:void(0);" onmouseover="show_release_freight();" onmouseout="hide_release_freight();">发布运价</a><a href="javascript:void(0);" onmouseover="show_release_cargo();" onmouseout="hide_release_cargo();">发布货盘</a><a href="/bbs/post.aspx">发表帖子</a> 
</div>
<div class="login_2_bot"><div class="tchu"><img src="images/index/login_3.gif" /><a href="/member/">我的办公室</a>&nbsp;</div>
<img src="images/index/login_2_1.gif" /><a href="/member/pm.aspx">查看留言</a>(<a href="/member/pm.aspx" class="orange"><strong><asp:Literal ID="ltrLiuyan" runat="server">0</asp:Literal></strong></a>)</div>
</div>
</asp:PlaceHolder>

<div class="booking">
<div class="booking_top">
<table border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td height="57" align="center">&nbsp;</td>
</tr>
<tr>
<td><img src="/images/index/book_bg1.gif" width="215" height="30" border="0" usemap="#Map" />
<map name="Map" id="Map"><area shape="rect" coords="22,6,98,25" href="/topic/order20091104/readme.aspx#a007" target="_blank"/><area shape="rect" coords="117,6,194,26" href="/topic/order20091104/readme.aspx#a008" target="_blank" /></map>
</td>
</tr>
</table>
</div>
<div class="booking_mid">
<a href="/topic/order20091104/product_1.aspx"><img src="images/index/book_top3.jpg" width="238" height="121" border="0" alt="点击查看安运通介绍"/></a><br />
      <a href="/topic/order20091104/product_3.aspx" target="_blank"><img src="images/index/book_ad1.gif" width="238" height="92" border="0" alt="安运通支付宝担保交易"/></a>
</div>
<div class="booking_mid" style="height:255px; background:url(images/index/book_top4.jpg) no-repeat center;">
<ul id="textnomouse" style="width:230px;height:120px;overflow:hidden;">
<asp:Repeater ID="RptOrder" runat="server">
<ItemTemplate>	
<li><a href="/company/<%# setkey(Eval("userid").ToString())%>/" target="_blank"><%#GetFirstString(Eval("companyname").ToString(),28)%></a></li>
</ItemTemplate>
</asp:Repeater>	
</ul>
<script>
var marquee1=new Marquee("textnomouse")
marquee1.ScrollStep=-1;
marquee1.Start();
</script>

<a style="margin:8px 0 0 10px; float:left;" href="/topic/order20091104/product_2.aspx" target="_blank"><img src="/images/index/book_bt.jpg" border="0" /></a><br />
<br />
</div>

</div>                
<div class="right_ad"><a href="/topic/order20091104/product_2.aspx" target="_blank"><img src="/images/index/right_ad.gif" width="238" height="96" border=0 /></a></div> 

<div class="news">
<h2><a href="/news/1/2/list.html" target="_blank">航运动态</a><a style="font:12px '宋体'; font-weight:normal; margin-left:115px;" href="/news/1/2/list.html" target="_blank">更多>></a></h2>
<div class="picSmall"><asp:Literal ID="LitIMG" runat="server"></asp:Literal></div>
<div class="links">
<ul>
<li><asp:Literal ID="LitTitle" runat="server"></asp:Literal></li>
<li style="line-height:18px; margin:4px 0 0 0;"><asp:Label ID="labtext" runat="server" Text=""></asp:Label><asp:Literal ID="Litclick" runat="server"></asp:Literal></li>
</ul>
</div>
<div class="links_bt">
<ul>
<asp:Repeater ID="RptaHangYunDongTai" runat="server">
<ItemTemplate>
<li><div class="r">[<%# Convert.ToDateTime(Eval("postdate")).ToString("MM-dd")%>]</div><a href="/news/1/2/<%#Eval("id")%>.html" target="_blank" title="<%#Eval("title")%>" >·<%#GetFirstString(Eval("title").ToString(),22)%></a></li>
</ItemTemplate>
</asp:Repeater>							
</ul>
</div>
</div>
</div>
<div style="position:relative;">
<div style="border:1px solid #4F89AF;background:#F8FBFE;padding:5px 8px;line-height:20px;position:absolute;top:60px; left:145px; display:none; " id="sub_div_fbyj" onmouseover="document.getElementById('sub_div_fbyj').style.display = ''" onmouseout="document.getElementById('sub_div_fbyj').style.display = 'none'">
<a href="/member/Release.aspx" target="_blank">整箱运价</a>
<a href="/member/SpellRelease.aspx" target="_blank">拼箱运价</a> 
<a href="/member/AirRelease.aspx" target="_blank">空运运价</a></div>
<div style="border:1px solid #4F89AF;background:#F8FBFE;padding:5px 8px;line-height:20px;position:absolute;top:87px; left:145px; display:none;" id="sub_div_cxyj" onmouseover="document.getElementById('sub_div_cxyj').style.display = ''" onmouseout="document.getElementById('sub_div_cxyj').style.display = 'none'">
<a href="/fcl/" target="_blank">整箱运价</a> <a href="/lcl/" target="_blank">拼箱运价</a> <a href="/air/" target="_blank">空运运价</a></div>
</div>
<div class="bot_tool">
	<div class="bot_tool_box"> 
		<ul>
			<li style=" background-image:none; padding-left:55px; margin-bottom:4px;"><img src="/images/index/bot_tool_fw.gif" /></li>
			<li><a href="javascript:void(0);" onmouseover="document.getElementById('sub_div_fbyj').style.display = ''" onmouseout="document.getElementById('sub_div_fbyj').style.display = 'none'">发布运价</a></li>
			<li><a href="javascript:void(0);" onmouseover="document.getElementById('sub_div_cxyj').style.display = ''" onmouseout="document.getElementById('sub_div_cxyj').style.display = 'none'">查询运价</a></li>
			<li><a href="/topic/order20091104/readme.aspx#a021">线上订舱</a></li>
			<li><a href="/topic/order20091104/readme.aspx">安运通</a></li>
		</ul>
		<ul>
			<li style=" background-image:none; padding-left:55px; margin-bottom:4px;"><img src="/images/index/bot_tool_zn.gif" width="105" height="32" /></li>
			<li><a href="/topic/order20091104/readme.aspx#a027">如何订舱</a></li>
			<li><a href="/topic/order20091104/readme.aspx#a007">价格保证</a></li>
			<li><a href="/topic/order20091104/readme.aspx#a008">舱位保证</a></li>
			<li><a href="/topic/order20091104/readme.aspx#a025">订舱信息费</a></li>
		</ul>
		<ul>
			<li style=" background-image:none; padding-left:55px; margin-bottom:4px;"><img src="/images/index/bot_tool_ayt.gif" width="105" height="32" /></li>
			<li><a href="/topic/order20091104/readme.aspx#a004">轻松揽货</a></li>
			<li><a href="/topic/order20091104/readme.aspx#a004">免费宣传</a></li>
			<li><a href="/topic/order20091104/readme.aspx#a004">按效果付费</a></li>
		</ul>
		<ul style="background-image:none;">
			<li style=" background-image:none; padding-left:55px; margin-bottom:4px;"><img src="/images/index/bot_tool_zf.gif" width="105" height="32" /></li>
			<li><a href="/member/order/pay_sel.aspx" target="_blank">支付宝在线支付</a></li>
			<li><a href="/member/order/pay_bank.aspx" target="_blank">银行汇款</a></li>
		</ul>
	
	</div>
</div>


<userlinkbottom:userlinkbottom ID="userlinkbottom1" runat="server" />
<userbottom:userbottom ID="userbottom1" runat="server" />
</div>
</div>

<asp:Panel ID="dropdown1" Height="150px" ScrollBars=Vertical runat=server ></asp:Panel>
<asp:Panel ID="dropdown2" Height="150px" ScrollBars=Vertical runat=server ></asp:Panel>
<asp:Panel ID="dropdown3" Height="150px" ScrollBars=Vertical runat=server ></asp:Panel>
<asp:Panel ID="dropdown4" Height="150px" ScrollBars=Vertical runat=server ></asp:Panel>
<asp:Panel ID="dropdown5" Height="150px" ScrollBars=Vertical runat=server ></asp:Panel>	

<input id="Hidden1" runat="server" style="width: 1px" type="hidden" />
<input id="Hidden2" runat="server" style="width: 1px" type="hidden" />
<input id="Hidden3" runat="server" style="width: 1px" type="hidden" />
<input id="Hiddennn1" runat="server" style="width: 1px" type="hidden" />
<input id="Hiddennn2" runat="server" style="width: 1px" type="hidden" />
<input id="Hiddennn3" runat="server" style="width: 1px" type="hidden" />
</form>
<script type="text/javascript">
document.getElementById('dropdown1').style.display='none';
document.getElementById('dropdown2').style.display='none';
document.getElementById('dropdown3').style.display='none';
document.getElementById('dropdown4').style.display='none';
document.getElementById('dropdown5').style.display='none';
</script>

</body>
</html>
<script language="javascript" src="http://kht.zoosnet.net/JS/LsJS.aspx?siteid=KHT92889409&float=1"></script> 