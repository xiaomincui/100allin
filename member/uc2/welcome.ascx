<%@ Control Language="C#" AutoEventWireup="true" CodeFile="welcome.ascx.cs" Inherits="member_uc_welcome" %>
<div class="tit">
	<div class="r" style="background:url(/member/images/ico12.gif) no-repeat left; padding:0 8px 0 22px; line-height:18px;"><a href="#" class="org"><strong>联系客服</strong></a></div>
  <img src="/member/images/ico11.gif" /><span class="orange"><strong><asp:Literal ID="ltrMyName" runat="server"></asp:Literal>，欢迎您！</strong></span><a href="/member/">办公室首页</a>&nbsp;&nbsp;站内留言<a href="/member/pm.aspx" style="color:#FF0000;"><strong><asp:Literal ID="ltrPm" runat="server">0</asp:Literal></strong></a>&nbsp;&nbsp;[<a href="/member/logout.aspx">退出登录</a>]
</div>
