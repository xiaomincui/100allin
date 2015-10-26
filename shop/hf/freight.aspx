<%@ Page Language="C#" AutoEventWireup="true" CodeFile="freight.aspx.cs" Inherits="shop_hf_freight" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>新海丰有限公司宁波分公司</title>
<link href="web.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
.STYLE7 {color: #3399CC}
-->
</style></head>

<body>
	<div class="main">
<div class="top">
<div id="logo"><a href="/herocean/"><img src="images/logo.gif" border="0" /></a></div>
<div id="allin"><a href="http://www.100allin.com"><img src="images/allin.gif" border="0" /></a></div>
<div class="menu">
  <table border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td align="right"><a href="/shop/hf/"><img src="images/menu_1.gif" border="0" /></a></td>
      <td><a href="freight.aspx"><img src="images/menu_2.gif" width="144" height="30" border="0" /></a></td>
      <td><a href="about.aspx"><img src="images/menu_3.gif" width="100" height="30" border="0" /></a></td>
      <td> <a href="contact.aspx"><img src="images/menu_5.gif" width="109" height="30" border="0" /></a></td>
    </tr>
  </table>
</div>
</div>

	  <div style="padding:15px 20px 20px 20px; line-height:22px; overflow:hidden;">
	  公司在拼箱上有着极大的优势和丰富的经验，日韩航线和近洋航线是我们多年培育的精品业务，我们将继续利用海丰集团高频率集装箱班轮运输服务优势，不断优化服务，成为客户首选。公司操作-车队-报关-集装箱-航运-目的港等服务均为海丰集团分公司，有效的保证了货物流转的快捷、高效、安全，从而使客户的利益得到最大化。
	  </div>
	  <div class="STYLE7" style="padding:10px 20px 20px 20px; line-height:22px; overflow:hidden;">
	  我们的承诺：<br/>
	  1、全程由SITC为您服务。2、目的港拆箱快，处理问题高效。3、目的港不高收，正常费用提单显示。</div>
	  <div style="padding:10px 20px 20px 20px; line-height:22px; overflow:hidden; border:1px #BBBBBB solid; margin:15px; background:#EEEEEE;">
	    <p>
	    整箱优势港口：<asp:Literal ID="Literal3" runat="server"></asp:Literal><br />
	    拼箱优势港口：<asp:Literal ID="Literal2" runat="server"></asp:Literal><br />
	    拼箱运价：<asp:Literal ID="Literal1" runat="server"></asp:Literal></p>
      </div>
	  <div style="padding:5px 5px 5px 5px; line-height:22px; overflow:hidden;  margin:15px; ">
          <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
            <table border="0" cellpadding="0" cellspacing="0" bgcolor="#EEEEEE">
              <tr>
                <td width="120"><strong>航线</strong></td>
                <td width="150"><strong>起运港</strong></td>
                <td width="231"><strong>目的港</strong></td>
                <td width="121"><strong>价格（重量）</strong></td>
                <td width="124"><strong>价格（体积）</strong></td>
                <td width="92"><strong>船公司</strong></td>
                <td width="80"></td>
              </tr>
        </table>	
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
            <table border="0" cellpadding="0" cellspacing="0" bgcolor="#EEEEEE">
              <tr>
                <td width="120"><strong>航线</strong></td>
                <td width="150"><strong>起运港</strong></td>
                <td width="231"><strong>目的港</strong></td>
                <td width="62"><strong>20GP</strong></td>
                <td width="62"><strong>40GP</strong></td>
                <td width="62"><strong>40HQ</strong></td>
                <td width="62"><strong>45HQ</strong></td>
                <td width="92"><strong>船公司</strong></td>
                <td width="80"></td>
              </tr>
        </table>
        </asp:PlaceHolder>	          
            <br />
            <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
            <table border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td colspan="7"><a href="/lcl/<%#setkey(Eval("id").ToString()) %>_0.html" target="_blank"><%#Eval("title").ToString() %></a> [<%#Convert.ToDateTime(Eval("postdate")).ToString("yyyy-MM-dd")%> 至 <%#Convert.ToDateTime(Eval("enddate")).ToString("yyyy-MM-dd")%>] </td>
              </tr>
              <tr>
                <td width="120"><%#Eval("hangxianmiaoshu").ToString() %></td>
                <td width="150"><%#Eval("startport").ToString() %></td>
                <td width="231"><%#Eval("destport").ToString() %></td>
                <td width="121"><%#Eval("pricegp").ToString() %></td>
                <td width="124"><%#Eval("pricegpv").ToString()%></td>
                <td width="92"><%#Eval("shipcompany").ToString() %></td>
                <td width="80"><a href="/company/<%#setkey(Eval("userid").ToString()) %>/" target="_blank"><img src="/images2/fcl/dingc_r62.gif" width="68" height="29" border="0" /></a></td>
              </tr>
              <tr>
                <td colspan="7">&nbsp;</td>
              </tr>
            </table>
            <hr color="#EEEEEE"/>
          </ItemTemplate>
          </asp:Repeater>
          <asp:Repeater ID="Repeater2" runat="server">
          <ItemTemplate>
            <table border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td colspan="7"><a href="/lcl/<%#setkey(Eval("id").ToString()) %>_0.html" target="_blank"><%#Eval("title").ToString() %></a> [<%#Convert.ToDateTime(Eval("postdate")).ToString("yyyy-MM-dd")%> 至 <%#Convert.ToDateTime(Eval("enddate")).ToString("yyyy-MM-dd")%>] </td>
              </tr>
              <tr>
                <td width="120"><%#Eval("hangxianmiaoshu").ToString() %></td>
                <td width="150"><%#Eval("startport").ToString() %></td>
                <td width="231"><%#Eval("destport").ToString() %></td>
                <td width="62"><%#Eval("price20gp").ToString() %></td>
                <td width="62"><%#Eval("price40gp").ToString()%></td>
                <td width="62"><%#Eval("price40hq").ToString() %></td>
                <td width="62"><%#Eval("price45hq").ToString()%></td>                
                <td width="92"><%#Eval("shipcompany").ToString() %></td>
                <td width="80"><a href="/company/<%#setkey(Eval("userid").ToString()) %>/" target="_blank"><img src="/images2/fcl/dingc_r62.gif" width="68" height="29" border="0" /></a></td>
              </tr>
              <tr>
                <td colspan="7">&nbsp;</td>
              </tr>
            </table>
            <hr color="#EEEEEE"/>
          </ItemTemplate>
          </asp:Repeater>
	  </div>
	  <div class="manu"><%= pagecontrol_string%> </div>
		<hobottom:hobottom ID="hobottom1" runat="server" />
		<userblankbottom:userblankbottom ID="userblankbottom1" runat="server" />
	</div>
</body>
</html>