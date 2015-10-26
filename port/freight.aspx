<%@ Page Language="C#" AutoEventWireup="true" CodeFile="freight.aspx.cs" Inherits="port_freight" EnableViewState="false" EnableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="ltrKey" runat="server"><meta name="keywords" content="深圳港" /></asp:Literal>
<asp:Literal id="ltrDesc" runat="server"><meta name="description" content="深圳港至美加线各港口整箱运价查询，拼箱运价查询" /></asp:Literal>
<title><asp:Literal ID="ltrTitle" runat="server">深圳</asp:Literal>港至<asp:Literal ID="ltrLine2" runat="server">美加线</asp:Literal>各港口整箱运价查询，拼箱运价查询</title>
<link href="/port/css/port.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
  
     function showtab(m,n,count){
	for(var i=1;i<=count;i++){
		if (i==n){			
			getObject("td_"+m+"_"+i).className="hover";
			getObject("b_"+m+"_"+i).className="main3box";
			getObject("tab_"+m+"_"+i).className="main3box";
			}
		else {
			getObject("td_"+m+"_"+i).className="hover";
			getObject("b_"+m+"_"+i).className="null";
			getObject("tab_"+m+"_"+i).className="null";
			}
	}
}
 
</script>
</head>
<body>
<form id="form1" runat="server">
<div class="main_container">
<div class="top">
<div class="l_left"></div>
<div class="m_left">
<div class="top_nav">
<div class="topnav_l"><a href="/" target="_blank"><strong>环球运费网</strong></a></div>					<div class="topnav_r"><a href="/" target="_blank">首页</a> | <a href="/fcl/" target="_blank">整箱运价</a> | <a href="/lcl/" target="_blank">拼箱运价</a> | <a href="/air/" target="_blank">空运运价</a> | <a href="/company/" target="_blank">公司库</a> | <a href="/bbs/" target="_blank">论坛</a>  |  <a href="/member/" target="_blank">办公室</a> |  <a href="/accounts/reg.aspx" target="_blank">注册</a> | <a href="/accounts/login.aspx" target="_blank">登录</a>&nbsp;&nbsp;</div>
</div>
<div class="top_tit" style=" background:url(/port/images/bg/<asp:Literal ID="ltrBg" runat="server"></asp:Literal>.jpg) no-repeat right;"><strong><asp:Literal ID="ltrPort1" runat="server"></asp:Literal>港</strong></div>
<div class="top_list"><strong>港口切换</strong>：<a href="/port/shenzhen/">深圳港</a>  <a href="/port/shanghai/">上海港</a>  <a href="/port/qingdao/">青岛港</a>  <a href="/port/tianjin/">天津港</a>  <a href="/port/ningbo/">宁波港</a>  <a href="/port/dalian/">大连港</a>  <a href="/port/guangzhou/">广州港</a>  <a href="/port/xiamen/">厦门港</a></div>
</div>
<div class="r_left"></div>
</div>
<div class="main">
<div class="introduce">
<h1 style="border:none;"><span class="red"><asp:Literal ID="ltrPort2" runat="server"></asp:Literal>港</span>至<span class="red"><asp:Literal ID="ltrLine1" runat="server"></asp:Literal></span>各港口运价查询</h1>
<div id="tabs3">
<div class="menu3box" style="background: url(images/ms_bg2.gif) no-repeat left top;">
<ul id="menu3">
<li class="hover" style="border-left:none;" id="label_1" ><a
href="#"
target="_self" onmouseover="this.parentNode.className='hover';
document.getElementById('label_2').className='null';
document.getElementById('table2').style.display='block';
document.getElementById('table1').style.display='none';" ><strong>整箱运价</strong></a></li>
<li  id="label_2"  ><a href="#" 
target="_self"
onmouseover="this.parentNode.className='hover';
document.getElementById('label_1').className='null';
document.getElementById('table1').style.display='block';
document.getElementById('table2').style.display='none';">拼箱运价</a></li>
</ul>
</div>
<div class="main3box" >
<asp:DataList ID="table2" runat="server" CellPadding="0" CellSpacing="1" RepeatColumns="4" RepeatDirection="Horizontal"  Width="100%">
<ItemStyle Height="28px" />
<ItemTemplate><%#Eval("Portlink") %></ItemTemplate>
</asp:DataList> 
<asp:DataList ID="table1" runat="server" CellPadding="0" CellSpacing="1" RepeatColumns="4" RepeatDirection="Horizontal"  Width="100%" CssClass="hidden">
<ItemStyle Height="28px" />
<ItemTemplate><%#Eval("Portlink") %></ItemTemplate>
</asp:DataList>  
</div>
</div>
<div class="other_yf">
<h2><strong>其他航线港口运价查询</strong></h2>
<a href="/port/<asp:Literal ID="ltrOther1" runat="server">shenzhen</asp:Literal>/freight/1/"><asp:Literal ID="ltrOther1c" runat="server">深圳</asp:Literal>港至美加线各港口最新运价</a>
<a href="/port/<asp:Literal ID="ltrOther2" runat="server">shenzhen</asp:Literal>/freight/2/"><asp:Literal ID="ltrOther2c" runat="server">深圳</asp:Literal>港至欧地线各港口最新运价</a>
<a href="/port/<asp:Literal ID="ltrOther3" runat="server">shenzhen</asp:Literal>/freight/3/"><asp:Literal ID="ltrOther3c" runat="server">深圳</asp:Literal>港至中南美线各港口最新运价</a>
<a href="/port/<asp:Literal ID="ltrOther4" runat="server">shenzhen</asp:Literal>/freight/4/"><asp:Literal ID="ltrOther4c" runat="server">深圳</asp:Literal>港至日韩线各港口最新运价</a>
<a href="/port/<asp:Literal ID="ltrOther5" runat="server">shenzhen</asp:Literal>/freight/5/"><asp:Literal ID="ltrOther5c" runat="server">深圳</asp:Literal>港至近洋线各港口最新运价</a>
<a href="/port/<asp:Literal ID="ltrOther6" runat="server">shenzhen</asp:Literal>/freight/6/"><asp:Literal ID="ltrOther6c" runat="server">深圳</asp:Literal>港至非洲线各港口最新运价</a>
<a href="/port/<asp:Literal ID="ltrOther7" runat="server">shenzhen</asp:Literal>/freight/7/"><asp:Literal ID="ltrOther7c" runat="server">深圳</asp:Literal>港至澳洲线各港口最新运价</a>
<a href="/port/<asp:Literal ID="ltrOther8" runat="server">shenzhen</asp:Literal>/freight/8/"><asp:Literal ID="ltrOther8c" runat="server">深圳</asp:Literal>港至中东印巴线各港口最新运价</a>
<a href="/port/<asp:Literal ID="ltrOther9" runat="server">shenzhen</asp:Literal>/freight/8/"><asp:Literal ID="ltrOther9c" runat="server">深圳</asp:Literal>港至红海线各港口最新运价</a>
</div>
</div>
</div>
<div class="foot"><a href="/about.html" target="_blank">关于我们</a> | <a href="/service.html" target="_blank">服务条款</a> | <a href="/law.html" target="_blank">法律声明</a> | <a href="/sitemap.html" target="_blank">网站地图</a> | <a href="/contact.html" target="_blank">联系我们</a>          <br />
Copyright 2007-2009 100Allin.com All Rights Reserved
<br />
沪ICP备07510944号
</div>
</div>

</form>
</body>
</html>
