<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Agent.aspx.vb" Inherits="en_search_fcl" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>100allin.com-The biggest freight rate web in the world</title>
<link href="/en/css/fcl_list.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="/js/autocomplete/port_en.js"></script>
<script type="text/javascript">
function AllClick()
{
    if(document.getElementById('allnet').checked)
    {
        document.getElementById('wca').checked=true;
        document.getElementById('apln').checked=true;
        document.getElementById('cgln').checked=true;
        document.getElementById('igln').checked=true;
        document.getElementById('wcap').checked=true;
        document.getElementById('wcapn').checked=true;
        document.getElementById('dgla').checked=true;
        document.getElementById('pla').checked=true;
        document.getElementById('pub').checked=true;
        document.getElementById('rm').checked=true;
        document.getElementById('pp').checked=true;
    }
    else
    {
        document.getElementById('wca').checked=false;
        document.getElementById('apln').checked=false;
        document.getElementById('cgln').checked=false;
        document.getElementById('igln').checked=false;
        document.getElementById('wcap').checked=false;
        document.getElementById('wcapn').checked=false;
        document.getElementById('dgla').checked=false;
        document.getElementById('pla').checked=false;
        document.getElementById('pub').checked=false;
        document.getElementById('rm').checked=false;
        document.getElementById('pp').checked=false;
    }
}

function ChkAll()
{
    if(document.getElementById('wca').checked &&
        document.getElementById('apln').checked &&
        document.getElementById('cgln').checked &&
        document.getElementById('igln').checked &&
        document.getElementById('wcap').checked &&
        document.getElementById('wcapn').checked &&
        document.getElementById('dgla').checked &&
        document.getElementById('pla').checked &&
        document.getElementById('pub').checked &&
        document.getElementById('rm').checked &&
        document.getElementById('pp').checked)
        {
            document.getElementById('allnet').checked=true;
        }
        else
        {
            document.getElementById('allnet').checked=false;
        }
}

function UpdateFilter(a)
{
    if(a=="city")
    {
        document.getElementById('trstatecity').style.display="";
        document.getElementById('Letter').style.display="none";
    }
    else if(a=="name")
    {
        document.getElementById('trstatecity').style.display="none";
        document.getElementById('Letter').style.display="";
    }
    else
    {
        document.getElementById('Letter').style.display="none";
        document.getElementById('trstatecity').style.display="none";
    }
}
</script>
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
						<li class="st"><a href="/en/search/fcl.aspx">FCL Freight</a></li>
						<li class="divider"></li>
						<li><a href="/en/search/lcl.aspx">LCL Freight</a></li>
						<li class="divider"></li>
						<li><a href="/en/search/air.aspx">Air Freight</a></li>
						<li class="divider"></li>
						<li><a href="#">Surcharge</a></li>
						<li class="divider"></li>
						<li><a href="/en/agent/">Agent</a></li>
						<li class="divider"></li>
						<li><a href="/en/search/company.aspx">Company</a></li>
</ul>
</div>
<div class="search">
<div class="search_mid">
<div class="search_bar_b">
<div class="sear_top">

<table id="asdf" cellspacing="3" border="0" class="appbody" width="100%" >
        
          <tr>
            <td colspan="2"><span class="title_txt"> 成员名录 </span></td>
          </tr>
          <tr>
            <td align="center">            </td>
          </tr>
		  <tr>
            <td colspan="2" valign="top"><strong>以名称和位置搜索成员:</strong></td>
		    </tr>
          <tr>      
            <td width="21%" align="right" valign="top"><div align="right">所属网络:&nbsp;<br>
            </div></td>
            <td width="79%" valign="top"><input name="allnet" type="checkbox" id="allnet"  onClick="AllClick();"   >
            所有网络<br>
              <span class="SsFont">&nbsp;全球性物流网络：</span><br>
                <asp:CheckBox ID="wca" runat="server" /><a href="http://www.worldcargoalliance.com/" title="World Cargo Alliance" target="_blank">WCA</a>
             <asp:CheckBox ID="apln" runat="server" /><a href="http://www.apln.net" target="_blank" title="Advanced Professional Logistics Network">APLN</a>
              <asp:CheckBox ID="cgln" runat="server" /><a href="http://www.cgln.net" target="_blank" title="China Global Logistics Network">CGLN</a>
              <asp:CheckBox ID="igln" runat="server" /><a href="http://www.igln.net" target="_blank" title="Inter-Global Logistics Network">IGLN</a></td>
          </tr>
          <tr>
            <td valign="top">&nbsp;</td>
            <td><span class="SsFont">&nbsp;专业货、项目货网络：</span><br />
              <asp:CheckBox ID="wcap" runat="server" /><a href="http://www.wcapartnerships.com" target="_blank">Specialty Networks</a>
              <asp:CheckBox ID="wcapn" runat="server" /><a href="http://www.wcapn.com" target="_blank" title="WCA Projects Network">WCAPN</a> <br>
              <asp:CheckBox ID="dgla" runat="server" /><a href="http://www.dangerousgoodslogisticsalliance.com" target="_blank" title="Dangerous Goods Logistics Alliance">DGLA</a>
              <asp:CheckBox ID="pla" runat="server" /><span class="HiLiLink"><a href="http://www.perishablelogisticsalliance.com" target="_blank" title="Perishable Logistics Alliance (PLA)">Perishables </a></span>
              <asp:CheckBox ID="pub" runat="server" /><span class="HiLiLink"><a href="http://www.publisherslogisticsalliance.com/" target="_blank" title="Publishers Logistics Alliance">Publishers</a></span></td>
          </tr>
          <tr>
            <td valign="top">&nbsp;</td>
            <td><span class="SsFont">&nbsp;其他选项</span><br>
              <asp:CheckBox ID="rm" runat="server" />
              <a href="http://www.wcaf-riskmanagement.com" target="_blank">Risk Management</a>
              <asp:CheckBox ID="pp" runat="server" />
              <a href="http://www.wcafpp.com" target="_blank" title="WCAF Partner Pay">Partner Pay</a></td>
          </tr>
          <tr>
            <td valign="top"><div align="right">
              <div align="right">搜索条件:&nbsp;</div>
            </div></td>
            <td valign="top">
            <asp:DropDownList ID="searchby" runat="server">
              <asp:ListItem Value="">--- 请选择 ---</asp:ListItem>
              <asp:ListItem Value="city">位置</asp:ListItem>
              <asp:ListItem Value="name">公司名称</asp:ListItem>
                </asp:DropDownList> 

              排序:
              <asp:DropDownList ID="orderby" runat="server">
              <asp:ListItem Value="">--- 请选择 ---</asp:ListItem>
              <asp:ListItem Value="city">国家 － 城市</asp:ListItem>
              <asp:ListItem Value="name">名字</asp:ListItem>
                </asp:DropDownList> 
</td>
          </tr>
          <tr id="trstatecity" style="display:none" runat="server">
            <td valign="top"><div align="right">筛选条件:&nbsp; </div></td>
            <td valign="top">
                <asp:DropDownList ID="statecity" runat="server" AutoPostBack="true">
                </asp:DropDownList>  
                <asp:DropDownList ID="city" runat="server">
                <asp:ListItem Value="">All Cities</asp:ListItem>
                </asp:DropDownList>  
              </td>
          </tr>
          <tr id="Letter" style="display:none" runat="server">
            <td valign="top"><div align="right">筛选条件:&nbsp; </div></td>
            <td valign="top">
                <asp:DropDownList ID="ddlLetter" runat="server">
                <asp:ListItem Value="">All</asp:ListItem>
                <asp:ListItem Value="A">A</asp:ListItem>
                <asp:ListItem Value="B">B</asp:ListItem>
                <asp:ListItem Value="C">C</asp:ListItem>
                <asp:ListItem Value="D">D</asp:ListItem>
                <asp:ListItem Value="E">E</asp:ListItem>
                <asp:ListItem Value="F">F</asp:ListItem>
                <asp:ListItem Value="G">G</asp:ListItem>
                <asp:ListItem Value="H">H</asp:ListItem>
                <asp:ListItem Value="I">I</asp:ListItem>
                <asp:ListItem Value="J">J</asp:ListItem>
                <asp:ListItem Value="K">K</asp:ListItem>
                <asp:ListItem Value="L">L</asp:ListItem>
                <asp:ListItem Value="M">M</asp:ListItem>
                <asp:ListItem Value="N">N</asp:ListItem>
                <asp:ListItem Value="O">O</asp:ListItem>
                <asp:ListItem Value="P">P</asp:ListItem>
                <asp:ListItem Value="Q">Q</asp:ListItem>
                <asp:ListItem Value="R">R</asp:ListItem>
                <asp:ListItem Value="S">S</asp:ListItem>
                <asp:ListItem Value="T">T</asp:ListItem>
                <asp:ListItem Value="U">U</asp:ListItem>
                <asp:ListItem Value="V">V</asp:ListItem>
                <asp:ListItem Value="W">W</asp:ListItem>
                <asp:ListItem Value="X">X</asp:ListItem>
                <asp:ListItem Value="Y">Y</asp:ListItem>
                <asp:ListItem Value="Z">Z</asp:ListItem>
                <asp:ListItem Value="Other">Other</asp:ListItem>
                </asp:DropDownList>  
              </td>
          </tr>
          <tr>
            <td valign="top"><div align="right">
              <div align="right">关键字:&nbsp;</div>
              </div></td>
            <td valign="top"><input name="keyword" type="text" id="keyword" value="" runat="server"></td>
          </tr>
          <tr>
            <td valign="top"><div align="right"></div></td>
            <td valign="top">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/en/images/fcl/search.gif" width="128" height="28" border="0"  />
                <input id="Hidstrwca" type="hidden" runat="server" />
                <input id="Hidapln" type="hidden" runat="server" />
                <input id="Hidcgln" type="hidden" runat="server" />
                <input id="Hidigln" type="hidden" runat="server" />
                <input id="Hidwcap" type="hidden" runat="server" />
                <input id="Hidwcapn" type="hidden" runat="server" />
                <input id="Hiddgla" type="hidden" runat="server" />
                <input id="Hidpla" type="hidden" runat="server" />
                <input id="Hidpub" type="hidden" runat="server" />
                <input id="Hidrm" type="hidden" runat="server" />
                <input id="Hidpp" type="hidden" runat="server" />
                <input id="Hidorder" type="hidden" runat="server" />
                <input id="HidCountry" type="hidden" runat="server" />
                <input id="Hidcity" type="hidden" runat="server" />
                <input id="Hidletter" type="hidden" runat="server" />
                <input id="HidkeyWord" type="hidden" runat="server" />
                <input id="Hidsearch" type="hidden" runat="server" />
            </td>
          </tr>
          <tr>
            <td colspan="2" valign="top"><br>
			<div id="showSearch"></div></td>
          </tr>          
</table>


</div>
</div>
</div>
</div>
</div>

<div class="notice" style="padding:0px 0px 10px 20px;"><p>
共找到<span class="orange"><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></span>条记录		    
您搜索的是：&nbsp;
<asp:Label ID="Label9" runat="server" Text="网络："></asp:Label><b><asp:Label ID="hidtxtWeb" runat="server" Visible="False" ></asp:Label></b>&nbsp;
<asp:Label ID="Label10" runat="server" Text="筛选条件："></asp:Label><b><asp:Label ID="hidtxtcondition" runat="server" Visible="False" ></asp:Label></b>&nbsp;
<asp:Label ID="Label11" runat="server" Text="关键字："></asp:Label><b><asp:Label ID="hidtxtkeyword" runat="server" ></asp:Label></b>&nbsp;  
</p>
</div>

<div class="main_page">
<div class="page_left">
<div class="list">
<div class="list_title"><span class="r"></span><a href="#">MEMBERS DIRECTORY</a></div>
<ul>
<li>
<asp:Repeater ID="Rptfcl" runat="server">
<ItemTemplate>
<li style="background:#f0f6fb;">
    
&nbsp;&nbsp;&nbsp;&nbsp;<%#IIf(Eval("Risk_Management").ToString = "1", "<img src='/en/images/agent/blue_red.gif' />", "")%><%#IIf(Eval("Partner_Pay").ToString = "1", "<img src='/en/images/agent/wcafPP_mini.gif' />", "")%><a href="../search/Agent_detail.aspx?id=<%# eval("id") %>"><%# eval("country") %>&nbsp;-&nbsp;<%# eval("City") %>&nbsp;-&nbsp;<%# eval("CompanyName") %><%#IIf(Eval("ifHead_Office").ToString = "1", "(Head_Office)", "")%></a><span style=" font-size:smaller;color:Gray"><%#GetQueryString(Eval("WCA").ToString(), Eval("APLN").ToString(), Eval("CGLN").ToString(), Eval("IGLN").ToString(), Eval("WCAPN").ToString(), Eval("DGLA").ToString())%></span>
</li>
</ItemTemplate>
</asp:Repeater>
<input id="Hidden1" runat="server" style="width: 1px" type="hidden" />		
<input id="Hiddennn1" runat="server" style="width: 1px" type="hidden" />
</li>
</ul>
<div class="page_head"><SPAN class=disabled style="margin:0px; padding:0px; line-height:27px; height:27px; border:none; color:#28385A; float:left;">
<asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label>/<asp:HiddenField ID="hidTotalPage" runat="server" Value="1" /><asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label>
</SPAN></div>
<div class="page">

<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
<asp:Label ID="hidSaveSearchWords" runat="server" Text="1" CssClass="hidden"></asp:Label>
直接到第 <input id="txtPageJump" name="txtPageJump" type="text" style=" width:20px; height:12px;" runat="server"/> 页 
<input id="btnPageJump" name="btnPageJump" type="button" value="确定" style=" width:40px; height:20px;" runat="server"/>

<%--</span>--%>
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
<%--</p>--%>
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
