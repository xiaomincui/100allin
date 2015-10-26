<%@ Control Language="C#" AutoEventWireup="true" CodeFile="headnav20150520.ascx.cs" Inherits="usercontrols_headnav20150520" %>
    <div class="header-nav">
		<ul>
			<li <%=(Request.Url.ToString().ToLower().IndexOf(".com/default") != -1)?" class=\"st\"":""%>><a href="/">首页</a></li>
			<li <%=(Request.Url.ToString().ToLower().IndexOf("fcl") != -1)?" class=\"st\"":""%>><a href="/fcl/">整箱海运价</a></li>
			<li <%=(Request.Url.ToString().ToLower().IndexOf("lcl") != -1)?" class=\"st\"":""%>><a href="/lcl/">拼箱海运价</a></li>
			<li <%=(Request.Url.ToString().ToLower().IndexOf("air") != -1)?" class=\"st\"":""%>><a href="/air/">空运运价</a></li>
			<li <%=(Request.Url.ToString().ToLower().IndexOf("company") != -1)?" class=\"st\"":""%>><a href="/company/">公司库</a></li>
			<li <%=(Request.Url.ToString().ToLower().IndexOf("news") != -1)?" class=\"st\"":""%>><a href="/news/">物流聚焦</a></li>
		</ul>
	</div>