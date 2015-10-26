<%@ Control Language="C#" AutoEventWireup="true" CodeFile="usernewtop.ascx.cs" Inherits="usercontrols_usernewtop" %>
		<div class="top_bar"><!--顶部登陆开始-->
			<div class="top_bar_hd">
				<h2>专业<span class="orange bold">运价</span>搜索查询和发布平台<img src="/images/index/gold.gif" alt="" /></h2>				
				<ul>
					<li>&nbsp;<a href="/help/help_about.html" target="_blank"><span class="orange bold">帮助</span></a>&nbsp;&nbsp;</li>
					<li>&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>&nbsp;|</li>			
					<li>&nbsp;<a href="#" onclick="var strHref=window.location.href;this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.100allin.com');">设为首页</a>&nbsp;|</li>
					<li>&nbsp;<a href="#" onclick="window.external.addFavorite('http://www.100allin.com','环球运费网-发布搜索运价平台')">收藏</a>&nbsp;|</li>
					<li>&nbsp;<a href="/member/">进入办公室</a>&nbsp;|</li>
					<li>&nbsp;<a href="/member/cargoselect.aspx" target="_blank" style="color:Red;">发货盘</a>&nbsp;|</li>
					<li>&nbsp;<a href="/member/releaseselect.aspx" target="_blank" >发运价</a>&nbsp;|</li>
					<li>&nbsp;<a href="/accounts/reg.aspx">免费注册</a>&nbsp;|</li>
					<li><asp:Literal ID="Literal1" runat="server" Text=""></asp:Literal>&nbsp;|</li>
					<li><div style="line-height:21px;"><iframe src="/member/pm_shortcut.aspx" width="80px" height="16px" frameborder="0" scrolling="no"></iframe>&nbsp;|&nbsp;</div></li>					
				</ul>
			</div>
		</div><!--顶部登陆结束-->	
		<div class="header"><!--头部LOGO开始-->	
			<div id="logo">
				<a href="/"><img src="/images/index/logo.gif" alt="环球运费网" border="0" width="182" height="72" /></a>
			</div>
			<ul>
				<li><img src="/images/fcl/ico_1.png" alt=""/>&nbsp;<a href="/">首页</a>&nbsp;&nbsp;</li>
				<li><img src="/images/fcl/ico_2.png" alt=""/>&nbsp;<a href="/fcl/" <%=(Request.Url.ToString().ToLower().IndexOf("fcl") != -1)?"style=\"color:#FF6600;\"":""%>>整箱海运价</a>&nbsp;&nbsp;</li>
				<li><img src="/images/fcl/ico_3.png" alt=""/>&nbsp;<a href="/lcl/" <%=(Request.Url.ToString().ToLower().IndexOf("lcl") != -1)?"style=\"color:#FF6600;\"":""%>>拼箱海运价</a>&nbsp;&nbsp;</li>
				<li><img src="/images/fcl/ico_4.png" alt=""/>&nbsp;<a href="/air/" <%=(Request.Url.ToString().ToLower().IndexOf("air") != -1)?"style=\"color:#FF6600;\"":""%>>空运运价</a>&nbsp;&nbsp;</li>
				<li><img src="/images/fcl/ico_5.png" alt=""/>&nbsp;<a href="/cargo/" <%=(Request.Url.ToString().ToLower().IndexOf("cargo") != -1)?"style=\"color:#FF6600;\"":""%>>货盘信息</a>&nbsp;&nbsp;</li>
				<li><img src="/images/fcl/ico_6.png" alt=""/>&nbsp;<a href="/company/" <%=(Request.Url.ToString().ToLower().IndexOf("company") != -1)?"style=\"color:#FF6600;\"":""%>>公司库</a>&nbsp;&nbsp;</li>
				<li><img src="/images/fcl/ico_7.png" alt=""/>&nbsp;<a href="/home/space.php?do=home">社区</a>&nbsp;&nbsp;</li>
				<li><img src="/images/fcl/ico_8.png" alt=""/>&nbsp;<a href="/bbs/" <%=(Request.Url.ToString().ToLower().IndexOf("bbs") != -1)?"style=\"color:#FF6600;\"":""%>>论坛</a>&nbsp;&nbsp;</li>
			</ul>
		</div><!--头部LOGO结束-->