<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="en_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>100allin.com-The biggest Rate rate web in the world</title>
<link href="css/index.css" rel="stylesheet" type="text/css" />
<script src="/topic/lcl090619/js/jquery-1.2.1.pack.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/MSClass.js"></script>
<script type="text/javascript" src="/js/home.js"></script>
<script type="text/javascript" language="javascript" src="/js/autocomplete_new/airprot_ch.js"></script>
<script type="text/javascript" language="javascript" src="/js/autocomplete_new/port_add.js"></script>
<script type="text/javascript">
function change_search(id)
{
	document.getElementById('fcl_search').style.display = "none";
	document.getElementById('lcl_search').style.display = "none";
	document.getElementById('air_search').style.display = "none";
	document.getElementById('company_search').style.display = "none";	
	document.getElementById(id).style.display = "";
	
	document.getElementById('fcl_search_tab').className = "";
	document.getElementById('lcl_search_tab').className = "";
	document.getElementById('air_search_tab').className = "";
	document.getElementById('company_search_tab').className = "";
	document.getElementById(id+'_tab').className = "set";
}

</script>
</head>

<body>
<form id="form1" runat="server">
<div class="main">
<div class="head">
<div class="top_box">
<div class="solo">The biggest Rate rate web in the world</div>
<div class="top_links"><img src="images/index/head_top_ico1.gif" /><a href="#" target="_blank">Home</a>︱<img src="images/index/head_top_ico2.gif" width="16" height="16" /><a href="sign.aspx" target="blank">Register</a>︱<img src="images/index/head_top_ico3.gif" width="16" height="16" /><a href="login_1.aspx" target="_blank">Login</a>︱<img src="images/index/head_top_ico4.gif" width="16" height="16" /><a href="#" target="_blank">help</a></div>
</div>
<div class="head_mid">
<div id="logo"><a href="#"><img src="images/index/logo.gif" border="0" /></a></div>
<div class="search_bar">
<div class="search_bar_box">
<%--<div class="search_bar_t">
<ul>
<li class="set"><a href="#">FCL Rate</a></li>
<li><a href="#">LCL Rate</a></li>
<li><a href="#">Air Rate</a></li>
<li><a href="#">company</a></li>
</ul>
<div class="search_form">
<table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
<tr>
<td width="128"><div id="select"><span id="select_text">line</span></div></td>
<td width="143"><input class="text_area" name="textfield" type="text" value="Port of Loading" /></td>
<td width="143"><input class="text_area" name="textfield2" type="text" value="port of destination" /></td>
<td width="86"><input class="ship_area" name="textfield2" type="text" value="Company" /></td>
<td><input id="aniu" name="" type="button" /></td>
</tr>
</table>

</div>
</div>--%>
<div class="search_bar_t">
<ul>
<li class="set" id="fcl_search_tab"><a href="#" onclick="change_search('fcl_search');">整箱海运价</a></li>
<li id="lcl_search_tab"><a href="#" onclick="change_search('lcl_search');">拼箱海运价</a></li>
<li id="air_search_tab"><a href="#" onclick="change_search('air_search');">空运运价</a></li>
<li id="company_search_tab"><a href="#" onclick="change_search('company_search');">公司库</a></li>
</ul>
<div class="search_form" id="fcl_search">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="130"><div id="select">
<span id="select_text">
<span class="select-style">
<select name="txtLine" id="txtLine" style="width:115px; color:#AAAAAA;" onkeydown="KeyDown(event);" onfocus="javascript:this.style.color='#000000';"  onblur="javascript:this.style.color='#AAAAAA';">
<option Value="">Please Choose</option>
<option Value="美加线">North America</option>
<option Value="欧地线">Euro/Med</option>
<option Value="中南美线">Middle/South America</option>
<option Value="日韩线">Japan and Korea</option>
<option Value="近洋线">Southeast Asia</option>
<option Value="非洲线">Africa</option>
<option Value="澳洲线">Australia</option>
<option Value="中东印巴线">Middle East</option>
<option Value="红海线">Red Sea</option>
</select>
</span></span>
</div></td>
<td width="176">
<asp:TextBox ID="txtStartport" runat="server" CssClass="text_area" ForeColor="#CCCCCC" Text="起运港" sou_type="start_port" onkeyup="autowords(this,event);" onclick="autowords(this,event);"></asp:TextBox>
</td>
<td width="176">
<asp:TextBox ID="txtDestport" runat="server" CssClass="text_area" ForeColor="#CCCCCC" Text="目的港" sou_type="end_port" onkeyup="autowords(this,event);" onclick="autowords(this,event);"></asp:TextBox>
</td>
<td width="97">
<asp:TextBox ID="txtCarrier" runat="server" CssClass="ship_area" ForeColor="#CCCCCC" Text="船公司" sou_type="ship_com" onkeyup="autowords(this,event);" onclick="autowords(this,event);"></asp:TextBox>
</td>
<td>
<a href="/fcl/" id="fcl_jump" target="_blank" onclick="search_fcl_jump();"><img src="http://img02.100allin.com/images/index/bot1.GIF" style="border:0; width:123px; height:26px;" /></a></td>
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
<option Value="">Please Choose</option>
<option Value="美加线">North America</option>
<option Value="欧地线">Euro/Med</option>
<option Value="中南美线">Middle/South America</option>
<option Value="日韩线">Japan and Korea</option>
<option Value="近洋线">Southeast Asia</option>
<option Value="非洲线">Africa</option>
<option Value="澳洲线">Australia</option>
<option Value="中东印巴线">Middle East</option>
<option Value="红海线">Red Sea</option>
</select>
</span></span>
</div></td>
<td width="176">
<asp:TextBox ID="txtStartport2" runat="server" CssClass="text_area" ForeColor="#CCCCCC" Text="起运港" sou_type="start_port" onkeyup="autowords(this,event);" onclick="autowords(this,event);"></asp:TextBox>
</td>
<td width="176">
<asp:TextBox ID="txtDestport2" runat="server" CssClass="text_area" ForeColor="#CCCCCC" Text="目的港" sou_type="end_port" onkeyup="autowords(this,event);" onclick="autowords(this,event);"></asp:TextBox>
</td>
<td width="97">
<asp:TextBox ID="txtCarrier2" runat="server" CssClass="ship_area" ForeColor="#CCCCCC" Text="船公司" sou_type="ship_com" onkeyup="autowords(this,event);" onclick="autowords(this,event);"></asp:TextBox>
</td>
<td>
<a href="/fcl/" id="lcl_jump" target="_blank" onclick="search_lcl_jump();"><img src="http://img02.100allin.com/images/index/bot1.GIF" style="border:0; width:123px; height:26px;"/></a></td>
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
            <option Value="">Please Choose</option>
            <option Value="澳洲线">Australia</option>
            <option Value="非洲线">Africa</option>
            <option Value="北美线">North America</option>
            <option Value="南美线">South America</option>
            <option Value="欧洲线">Euro</option>
            <option Value="亚洲线">Asia</option>
            <option Value="国内航线">China</option>
</select>
</span></span>
</div></td>
<td width="220">
<asp:TextBox ID="txtStartport3" runat="server" CssClass="text_area3" ForeColor="#CCCCCC" Text="起运地" sou_type="air_start" onkeyup="autowords(this,event);" onclick="autowords(this,event);"></asp:TextBox>
</td>
<td width="229">
<asp:TextBox ID="txtDestport3" runat="server" CssClass="text_area3" ForeColor="#CCCCCC" Text="目的地" sou_type="air_port" onkeyup="autowords(this,event);" onclick="autowords(this,event);"></asp:TextBox>
</td>
<td>
<a href="/air/" id="air_jump" target="_blank" onclick="search_air_jump();"><img src="http://img02.100allin.com/images/index/bot1.GIF" style="border:0; width:123px; height:26px;" /></a></td>
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
<a href="/company/" id="company_jump" target="_blank" onclick="search_company_jump();"><img src="http://img02.100allin.com/images/index/bot1.GIF" style="border:0; width:123px; height:26px;" /></a></td>
</tr> 
</table>
</div>
</div>


</div>




</div>
</div>
<div class="nav">
<ul>
<li><a href="/">Home</a></li>
<li class="divider"></li>
<li><a href="/en/fcl/">FCL Rate</a></li>
<li class="divider"></li>
<li><a href="/en/lcl/">LCL Rate</a></li>
<li class="divider"></li>
<li><a href="/en/air/">Air Rate</a></li>
<li class="divider"></li>
<li><a href="/en/surcharge/">Surcharge</a></li>
<li class="divider"></li>
<li><a href="/en/agent/">Agent</a></li>
<li class="divider"></li>
<li><a href="/en/company/">Company</a></li>
</ul>
</div>
</div>
<div class="main_page">
<div class="page_left">
<div class="page_box">
<div class="page_title"><span class="r"><a href="fcl/">more>></a></span><a href="/en/fcl/"><strong>FCL Rate</strong></a></div>
<table width="587" border="0" cellspacing="0" cellpadding="0" class="page_text">
<tr>
<td width="15" height="28">&nbsp;</td>
<td width="60"><strong>POL</strong></td>
<td width="100"><strong>POD</strong></td>
<td width="167"><strong>Rate (20'/40'/40H')</strong></td>
<td width="80"><strong>Carrier</strong></td>
<td width="165"><strong>Company</strong></td>
</tr>
<asp:Repeater ID="Rptfcl" runat="server">
<ItemTemplate>
<tr height="28" <%#IsOdd(Rptfcl.Items.Count)==true?"":"bgcolor=\"#F1F6FA\"" %>>
<td>&nbsp;</td>
<td><a href="/en/fcl/<%#setkey(Eval("id").ToString())%>_0.html"><%#GetFirstString(Eval("startport").ToString(),5)%></a></td>
<td><a href="/en/fcl/<%#setkey(Eval("id").ToString())%>_0.html"><%#GetFirstString(Eval("destport").ToString(),8)%></a></td>
<td><a href="/en/fcl/<%#setkey(Eval("id").ToString())%>_0.html"><%#GetFirstString(Eval("price20gp").ToString(),5)%>/<%#GetFirstString(Eval("price40gp").ToString(),5)%>/<%#GetFirstString(Eval("price40hq").ToString(),5)%></a></td>
<td><a href="/en/fcl/<%#setkey(Eval("id").ToString())%>_0.html"><%#GetFirstString(Eval("shipcompany").ToString(),5)%></a></td>
<td><a href="/en/company/<%#setkey(Eval("userid").ToString())%>/"><%#GetFirstString(Eval("EN_CompanyName").ToString(), 20)%></a></td>
</tr>
</ItemTemplate>
</asp:Repeater>    
</table>

</div>
<div class="page_box">
<div class="page_title"><span class="r"><a href="lcl/">more>></a></span><a href="/en/lcl/"><strong>LCL Rate</strong></a></div>
<table width="587" border="0" cellspacing="0" cellpadding="0" class="page_text">
<tr>
<td width="15" height="28">&nbsp;</td>
<td width="60"><strong>POL</strong></td>
<td width="100"><strong>POD</strong></td>
<td width="167"><strong>Rate (W/V)</strong></td>
<td width="80"><strong>Carrier</strong></td>
<td width="165"><strong>Company</strong></td>
</tr>
<asp:Repeater ID="Rptlcl" runat="server">
<ItemTemplate>
<tr height="28" <%#IsOdd(Rptlcl.Items.Count)==true?"":"bgcolor=\"#F1F6FA\"" %>>
<td>&nbsp;</td>
<td><a href="/en/lcl/<%#setkey(Eval("id").ToString())%>_0.html"><%#GetFirstString(Eval("startport").ToString(),5)%></a></td>
<td><a href="/en/lcl/<%#setkey(Eval("id").ToString())%>_0.html"><%#GetFirstString(Eval("destport").ToString(),8)%></a></td>
<td><a href="/en/lcl/<%#setkey(Eval("id").ToString())%>_0.html"><%#GetFirstString(Eval("pricegp").ToString(),5)%>/<%#GetFirstString(Eval("pricegpv").ToString(),5)%></a></td>
<td><a href="/en/lcl/<%#setkey(Eval("id").ToString())%>_0.html"><%#GetFirstString(Eval("shipcompany").ToString(),5)%></a></td>
<td><a href="/en/lcl/<%#setkey(Eval("userid").ToString())%>_0.html"><%#GetFirstString(Eval("EN_CompanyName").ToString(), 20)%></a></td>
</tr>
</ItemTemplate>
</asp:Repeater>    
</table>

</div>
<div class="page_box">
<div class="page_title"><span class="r"><a href="air/">more>></a></span><a href="/en/air/"><strong>Air Rate</strong></a></div>
<table width="587" border="0" cellspacing="0" cellpadding="0" class="page_text">
<tr>
<td width="15" height="28">&nbsp;</td>
<td width="60"><strong>POL</strong></td>
<td width="100"><strong>POD</strong></td>
<td width="247"><strong>Rate (+50/+100/+300/+500/+1000)</strong></td>
<td width="165"><strong>Company</strong></td>
</tr>
<asp:Repeater ID="Rptair" runat="server">
<ItemTemplate>
<tr height="28" <%#IsOdd(Rptair.Items.Count)==true?"":"bgcolor=\"#F1F6FA\"" %>>
<td>&nbsp;</td>
<td><a href="/en/air/<%#setkey(Eval("id").ToString())%>_0.html"><%#GetFirstString(Eval("startport").ToString(),5)%></a></td>
<td><a href="/en/air/<%#setkey(Eval("id").ToString())%>_0.html"><%#GetFirstString(Eval("destport").ToString(),8)%></a></td>
<td><a href="/en/air/<%#setkey(Eval("id").ToString())%>_0.html"><%#GetFirstString(Eval("price_p45").ToString(),5)%>/<%#GetFirstString(Eval("price_p100").ToString(),5)%>/<%#GetFirstString(Eval("price_p300").ToString(),5)%>/<%#GetFirstString(Eval("price_p500").ToString(),5)%>/<%#GetFirstString(Eval("price_p1000").ToString(),5)%></a></td>
<td><a href="/en/air/<%#setkey(Eval("userid").ToString())%>_0.html"><%#GetFirstString(Eval("EN_CompanyName").ToString(), 20)%></a></td>
</tr>
</ItemTemplate>
</asp:Repeater>    
</table>

</div>


</div>
<div class="page_right">

<asp:PlaceHolder ID="PlaceHolder1" runat="server">
<div class="login_box">
<div class="login_box_top"><strong>New User?</strong></div>
<div class="login_box_mid">
<h2>Want more business opportunities?</h2>
<h3><a href="login_1.aspx"><img src="images/index/l_bt.jpg" border="0" /></a></h3>
<h4><a href="#"><img src="images/index/mouse.jpg" width="16" height="16" />live help</a> <%--<a href="member/office.aspx"><img src="images/index/bag.gif" />My offices</a>--%></h4>
</div>
<div class="login_box_bot">&nbsp;&nbsp;&nbsp;Want to join the member？<a href="sign.aspx">login now</a></div>
</div>
</asp:PlaceHolder>

<asp:PlaceHolder ID="PlaceHolder2" runat="server">
<div class="login_box">
					<div class="login_box_top2">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Exit</asp:LinkButton><strong>Welcome Jason! </strong></div>
					<div class="login_box_mid">
						<h2 style="margin-top:5px;">Post New Info</h2>
						<h3><a href="#"><img src="images/index/bt_r1_c1.jpg" width="116" height="39" border="0" /></a>&nbsp;&nbsp;<a href="#"><img src="images/index/bt_r1_c3.jpg" width="116" height="39" border="0" /></a></h3>
						<h4>&nbsp;</h4>
				  </div>
					<div class="login_box_bot"><a style="float:right; margin-right:12px;" href="member/office.aspx">My Office</a><%--&nbsp;&nbsp;&nbsp;Inbox(<a href="#">11</a>)--%></div>
</div>
</asp:PlaceHolder>

<div class="r_ad"><a href="#"><img src="images/index/r_ad.gif" border="0" /></a></div>
<div class="news">
<div class="news_title"><strong>Our Service for you</strong></div>
<div class="news_box">
<div class="picSmall"><a href="#"><img src="images/index/pic.gif" border="0" /></a></div>
<div class="links"><strong><a href="#">Munich  specialises</a></strong><br />Munich  specialises in intelligent Munich  specialises <a href="search/new_list.aspx">[more]</a></div>
<div class="links_b">
· <a href="#">Munich  specialises in intelligent</a>
<br />
· <a href="#">Munich  specialises in intelligent</a>
<br />
· <a href="#">Munich  specialises in intelligent</a>
</div>
</div>
<div class="texr_tit"><strong>Surcharge</strong></div>
<div class="news_box">
<div class="links_b" style="padding-bottom:13px;"> · <a href="#">Munich  specialises in intelligent</a><br />
· <a href="#">Munich  specialises in intelligent</a><br />
· <a href="#">Munich  specialises in intelligent</a><br />
· <a href="#">Munich  specialises in intelligent</a><br />
· <a href="#">Munich  specialises in intelligent</a><br />
</div>
</div>
<div class="texr_tit" style="padding-bottom:6px;"><strong>New Members</strong></div>
<div class="news_box">
<div class="links_b" style="padding-bottom:13px;">
· <a href="#">Munich  specialises in intelligent</a><br />
· <a href="#">Munich  specialises in intelligent</a><br />
· <a href="#">Munich  specialises in intelligent</a><br />
· <a href="#">Munich  specialises in intelligent</a><br />
· <a href="#">Munich  specialises in intelligent</a><br />
</div>
</div>
</div>
</div>
<div class="foot"><a href="#">About Us</a>︱<a href="#">Privacy Policy</a>︱<a href="#">Terms Of Use Agreement</a>︱ <a href="#">Site Map</a>︱<a href="#">Contact Us</a></div>
</div>
</div>
</form>
</body>
</html>
