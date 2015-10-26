<%@ Control Language="C#" AutoEventWireup="true" CodeFile="usertop.ascx.cs" Inherits="usercontrols_usertop" %>
<div id="top">
	<div id="logo"><a href="/"><img src="/images/logo.gif" width="149" height="47" border="0" /></a></div>
	<div id="title"><h1 class="blueText"><span >专业<span class="orangeText">运价</span>搜索查询和发布</span></h1></div>
	<div id="banner">
		<div id="help"><a href="/">回到首页</a>|<a href="#" onclick="var strHref=window.location.href;this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.100allin.com');">设为首页</a>|<a href="#" onclick="window.external.addFavorite('http://www.100allin.com','傲赢网-发布搜索运价平台')">加入收藏</a>|<a href="/intro/searchunion.aspx" target="_blank">运价搜索服务</a>|<a href="/member/releaseselect.aspx" target="_blank">运价发布</a>|<a href="javascript:;" onclick="document.getElementById('servicebox').style.display = '';" style="color:#FF0000; font-weight:bold;" title="点击此处打开客户服务列表">客户服务</a><DIV id="servicebox" style="Z-INDEX:999; right:10px; top:30px; POSITION: absolute;  display:none;"><img src="/images/servicebox_head1.gif"  width="108" height="30" border="0" onclick="document.getElementById('servicebox').style.display = 'none';" style="cursor:pointer;" alt="点击此处隐藏客户服务列表" id="servicebox_head" /><br />
<img src="/images/servicebox_body2.gif" name="servicebox_head" width="108" height="125" border="0" usemap="#servicebox_headMap" id="servicebox_body" />
<map name="servicebox_headMap" id="servicebox_headMap">
<area shape="rect" coords="10,6,95,33" href="tencent://message/?uin=744593820&amp;Site=www.100allin.com&amp;Menu=yes" />
<area shape="rect" coords="10,34,95,61" href="tencent://message/?uin=914019684&amp;Site=www.100allin.com&amp;Menu=yes" />
<area shape="rect" coords="10,63,95,89" href="msnim:chat?contact=100allin03@LIVE.CN" />
<area shape="rect" coords="10,91,95,117" href="msnim:chat?contact=100allin02@LIVE.CN" />
</map></DIV></div>
	    <div id="count">
            <span class="countText">目前网站共有：</span>
            <span class="countText">
                整箱运价：<span class="countNumber smallBoldOrange"><asp:Label ID="lblCountZx" runat="server"></asp:Label>
                </span> 条</span>
            <span class="countText">
                拼箱运价：<span class="countNumber smallBoldOrange"><asp:Label ID="lblCountPx" runat="server"></asp:Label>
                </span> 条</span>
            <span class="countText">
                空运运价：<span class="countNumber smallBoldOrange"><asp:Label ID="lblCountHk" runat="server"></asp:Label>
                </span> 条</span>
            <span class="countText" style="display:none;">
                货盘数量：<span class="countNumber smallBoldOrange"><asp:Label ID="lblCountHp" runat="server"></asp:Label>
                </span> 条</span>
        </div>
	</div>
</div>