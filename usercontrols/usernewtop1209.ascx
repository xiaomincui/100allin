<%@ Control Language="C#" AutoEventWireup="true" CodeFile="usernewtop1209.ascx.cs" Inherits="usercontrols_usernewtop1209" %>
<div class="fcl_top">
	<div id="fcl_logo" style="margin-top:-10px;"><a href="/"><img src="/images/fcl/logo.jpg" alt="环球运费网 - 全球最大的空运海运运价查询与订舱平台,空运海运费查询与订舱平台" border="0" /></a></div>
	<div id="solo"></div>
	<div class="fcl_tel"><img src="/images/fcl/pep.gif" /><a title="欢迎使用在线客服" href="#" onclick="document.getElementById('aliserv').click();">在线客服</a>&nbsp;&nbsp;&nbsp;&nbsp;<img src="/images/fcl/qq.gif" width="16" height="16" />744593820 914019684</div>
	<div class="fcl_login">
        <table width="100%" border="0" cellspacing="1" cellpadding="0">
          <tr>
            <td width="80%" align="right" height=25><asp:Label ID="homelogout" runat="server" Text="<script src='/home/newlogout.php'></script>"></asp:Label><asp:Label ID="homelogin" runat="server" Text="<script src='/home/newlogin.php'></script>"></asp:Label><asp:Literal ID="Literal2" runat="server"></asp:Literal></td>
            <td width="20%" align="right"><a href="/member/"><img src="/images/fcl/jt.gif" border="0" />办公室</a></td>
          </tr>
          <tr>
            <td align="right" height=25><a href="/accounts/reg.aspx"><img src="/images/fcl/jt.gif" border="0" />注册</a></td>
            <td align="right"><a href="/help/help_23.aspx"><img src="/images/fcl/jt.gif" border="0" />帮助&nbsp;&nbsp;</a></td>
          </tr>
        </table>
	</div>
</div>
<div class="nav">
	<ul>
		<li><a href="/">首页</a></li>
		<li class="divider"></li>
		<li <%=(Request.Url.ToString().ToLower().IndexOf("fcl") != -1)?"class=\"st\"":""%>><a href="/fcl/">整箱海运价</a></li>
		<li class="divider"></li>
		<li <%=(Request.Url.ToString().ToLower().IndexOf("lcl") != -1)?"class=\"st\"":""%>><a href="/lcl/">拼箱海运价</a></li>
		<li class="divider"></li>
		<li <%=(Request.Url.ToString().ToLower().IndexOf("air") != -1)?"class=\"st\"":""%>><a href="/air/">空运运价</a></li>
		<li class="divider"></li>
		<li <%=(Request.Url.ToString().ToLower().IndexOf("company") != -1)?"class=\"st\"":""%>><a href="/company/">公司库</a></li>
		<li class="divider"></li>
	</ul>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <div class="mail">您有<a href="/member/pm.aspx"><asp:Literal ID="Literal1" runat="server"></asp:Literal></a>条未处理信息</div>
    </asp:PlaceHolder>
</div>
