<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="shop_bloom_index" EnableViewState="false" EnableEventValidation="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>上海凌凯国际货物运输代理有限公司—环球运费网</title>
<meta name="description" content="" />
<meta name="keywords" content="" />

<link href="web.css" rel="stylesheet" type="text/css" />

</head>
<body>
<div class="main">

    <div class="big_pic">
  <img src="images/home.jpg" alt=""/>
  <table width="960" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr> 
      <td width="950"> 
        <table width="950" border="0" cellspacing="0" cellpadding="0">
          <tr>            <td align="left"><img src="images/hometoplogo_1.jpg" width="950" height="100" border="0" usemap="#home"></tr>
        </table>
      </td>
    </tr>
  </table>
  <table width="950" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr> 
      <td><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" width="948" height="132">
          <param name="movie" value="images/homeflash1.swf">
          <param name="quality" value="high">
          <embed src="images/homeflash1.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="948" height="132">
          </embed> 
        </object></td>
    </tr>
  </table>
        
    </div>

	<div  style="overflow:hidden;margin-top:5px;">
	<div style="float:left;width:210px;height:760px;border:1px solid #DDDDDD;padding:20px;line-height:22px;">
	<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
	<td colspan="2" valign="top"><b>上海凌凯国际货物运输代理有限公司</b></td>
	</tr>	
	<tr>
	<td width="50" valign="top" style="letter-spacing:11px;">
	地址</td>
	<td valign="top">
	上海市伊犁南路111号钱江商务广场1201室	</td>
	</tr>
	<tr>
	  <td valign="top">联系人</td>
	  <td valign="top">刘小姐</td>
	  </tr>
	<tr>
	  <td valign="top" style="letter-spacing:11px;">电话</td>
	  <td valign="top">86-21-33504956<br/>
86-21-54776472<br/>
86-21-54775941</td>
	  </tr>
	</table>
	<br/>
	<img src="images/iata.jpg" />
	
	</div>
	<div style="float:right;width:650px;height:760px;border:1px solid #DDDDDD;padding:20px;">
	<div style="line-height:22px;margin-bottom:10px;">
	上海凌凯国际货物运输代理有限公司(JJB LINK LOGISTICS COMPANY LIMITED)是外经贸部批准的一级货运代理企业。我司主营空运中东；印巴；非洲和欧洲航线，其中印度、中东总货量每月在1000吨以上。EY（阿联酋水晶航线）包板大庄家，另分别在SV QR TK UW HU等航线占有大量板位和超优势价格。公司在北京，天津，重庆，成都，西安，深圳，香港等全国十几个省、市设有分支机构。拥有覆盖美国，欧洲，印巴，中东的国际性区域代理网络。 专业、高效的团队，严谨的物流管理手段，以及“诚心、高效”的服务理念是公司不断发展的保证。以优化的运输方案，最合理的运输成本，最大的满足客户的货运需求，是我们服务客户的宗旨。
</div>
	<div style="line-height:22px;margin-bottom:10px;">
	<b>最新运价（起运地：上海）</b><br/>
	<b>航空公司：</b> <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</div>
	  <table width="100%" border="0" cellpadding="5" cellspacing="1" bgcolor="#666666">
          <tr>
            <td bgcolor="#96B9D5"><span class="table_title">目的地</span></td>
            <td bgcolor="#96B9D5"><span class="table_title">+45</span></td>
            <td bgcolor="#96B9D5"><span class="table_title">+100</span></td>            
            <td bgcolor="#96B9D5"><span class="table_title">+300</span></td>
            <td bgcolor="#96B9D5"><span class="table_title">+500</span></td>
            <td bgcolor="#96B9D5"><span class="table_title">+1000</span></td>
            <td bgcolor="#96B9D5"><span class="table_title">航程</span></td>
            <td bgcolor="#96B9D5"><span class="table_title">出发日</span></td>
            <td bgcolor="#96B9D5"><span class="table_title">航空公司</span></td>
            <td bgcolor="#96B9D5" width="50"><span class="table_title">详细</span></td>
          </tr>
          <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
          <tr>
            <td bgcolor="#FFFFFF"><%#Eval("destport").ToString() %></td>
            <td bgcolor="#FFFFFF"><%#Eval("price_p45").ToString()%></td>
            <td bgcolor="#FFFFFF"><%#Eval("price_p100").ToString()%></td>
            <td bgcolor="#FFFFFF"><%#Eval("price_p300").ToString()%></td>
            <td bgcolor="#FFFFFF"><%#Eval("price_p500").ToString()%></td>
            <td bgcolor="#FFFFFF"><%#Eval("price_p1000").ToString()%></td>
            <td bgcolor="#FFFFFF"><%#Eval("distance").ToString()%></td>
            <td bgcolor="#FFFFFF"><%#Eval("departurewkd").ToString()%></td>
            <td bgcolor="#FFFFFF"><%#selectairline(Eval("titlex").ToString())%></td>
            <td bgcolor="#FFFFFF"><a href="/air/<%#setkey(Eval("sid").ToString())%>_<%#Eval("did").ToString() %>.html" target="_blank">详细</a></td>
          </tr>
          </ItemTemplate>
          </asp:Repeater>

        </table>
	<div class="manu"><%= pagecontrol_string%> </div>
	</div>

    </div>
    
    <div class="foot">Copyright &copy; 2007-2011 www.100allin.com All Rights Reserved 沪ICP备07510944号 </div> 
</div>
<userblankbottom:userblankbottom ID="userblankbottom1" runat="server" />
</body>
</html>