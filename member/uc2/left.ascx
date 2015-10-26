<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left.ascx.cs" Inherits="member_uc_left" %>
<div class="left_box">
	<div class="detail">
		<h1><img src="/member/images/ico1.gif" />订舱单管理&nbsp;<img style="margin-top:-15px;" src="/member/images/news.gif" /></h1>
		<ul>
			<li><img src="/member/images/jt.gif" />&nbsp;<a href="/member/order/list.aspx?f1=1&f2=0">我收到的订舱单</a>（<a style="color:#FF0000;" href="/member/order/list.aspx?f1=1&f2=0"><strong><asp:Literal ID="ltrNewBooking" runat="server">0</asp:Literal></strong></a>）</li>
			<li><img src="/member/images/jt.gif" />&nbsp;<a href="/member/order/list.aspx?f1=0&f2=0">我发出的订舱单</a></li>
			<li><img src="/member/images/jt.gif" />&nbsp;<a href="/member/order/bill.aspx">我的账单</a></li>
			<li><img src="/member/images/jt.gif" />&nbsp;<a href="/member/order/pay_sel.aspx">预存订舱费</a></li>
		</ul>
		<p style="display:none;"><img src="/member/images/ico2.gif" />&nbsp;<a href="#">订舱流程演示</a>&nbsp;&nbsp;</p>
	</div>
	<div class="detail">
		<h1><img src="/member/images/ico3.gif" width="16" height="16" />运价/货盘管理发布</h1>
		<ul>
			<li><span class="gray">整箱运价</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/member/shippinglist.aspx">管理</a> <span class="gray">|</span> <a href="/member/Release.aspx">发布</a></li>
			<li><span class="gray">拼箱运价</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/member/lcllist.aspx">管理</a> <span class="gray">|</span> <a href="/member/SpellRelease.aspx">发布</a></li>
			<li><span class="gray">空运运价</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/member/airlist.aspx">管理</a> <span class="gray">|</span> <a href="/member/AirRelease.aspx">发布</a></li>
			<li><span class="gray">海运货盘</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/member/cargolist.aspx">管理</a> <span class="gray">|</span> <a href="/member/temp_add_ship.aspx">发布</a></li>
			<li><span class="gray">空运货盘</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/member/aircargolist.aspx">管理</a> <span class="gray">|</span> <a href="/member/temp_add_air.aspx">发布</a></li>
		</ul>
  </div>
    <div class="detail">
			<h1><img src="/member/images/ico4.gif" width="16" height="16" />消息管理</h1>
			<ul>
				<li><img src="/member/images/jt.gif" />&nbsp;<a href="/member/pm.aspx">我的站内留言</a>（<a style="color:#FF0000;" href="/member/pm.aspx"><strong><asp:Literal ID="ltrPm" runat="server">0</asp:Literal></strong></a>）</li>
				<li style="display:none;"><img src="/member/images/jt.gif" />&nbsp;<a href="#">谁看过我的运价</a></li>
				<li><img src="/member/images/jt.gif" />&nbsp;<a href="/member/friend.aspx">我的好友</a></li>
			</ul>
  </div>
	<div class="detail">
		<h1><img src="/member/images/ico5.gif" width="16" height="16" />修改资料</h1>
		<ul>
			<li><img src="/member/images/jt.gif" />&nbsp;<a href="/member/useredit3.aspx">修改基本注册信息</a></li>
			<li><img src="/member/images/jt.gif" />&nbsp;<a href="/member/useredit2.aspx">修改简介和服务优势</a></li>
			<!--<li><img src="/member/images/jt.gif" />&nbsp;<a href="/member/useredit1.aspx">修改公司照片/头像/签名</a></li>-->
		</ul>
  </div>
  <div class="exit">
    <table width="100%" border="0" cellspacing="1" cellpadding="0">
			  <tr style="display:none;">
				<td width="7%"><img src="/member/images/ico6.gif" /></td>
				<td width="92%" height="28" align="left"><a href="#">我的办公室帮助</a></td>
			  </tr>
			  <tr>
				<td width="7%"><img src="/member/images/ico7.gif" /></td>
				<td height="28" align="left"><a href="/accounts/logout.aspx">退出登录</a></td>
			  </tr>
    </table>

		<br/>
  </div>
</div>