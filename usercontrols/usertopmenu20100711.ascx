<%@ Control Language="C#" AutoEventWireup="true" CodeFile="usertopmenu20100711.ascx.cs" Inherits="usercontrols_usertopmenu20100711" %>
<div class="head_nav">
<ul>
<li><a href="/">首页</a></li>
<li class="divider"></li>
<li<%=(Request.Url.ToString().ToLower().IndexOf("fcl") != -1)?" class=\"st\"":""%>><a href="/fcl/">整箱海运价</a></li>
<li class="divider"></li>
<li<%=(Request.Url.ToString().ToLower().IndexOf("lcl") != -1)?" class=\"st\"":""%>><a href="/lcl/">拼箱海运价</a></li>
<li class="divider"></li>
<li<%=(Request.Url.ToString().ToLower().IndexOf("air") != -1)?" class=\"st\"":""%>><a href="/air/">空运运价</a></li>
<li class="divider"></li>
<li<%=(Request.Url.ToString().ToLower().IndexOf("company") != -1)?" class=\"st\"":""%>><a href="/company/">公司库</a></li>
<li class="divider"></li>
<li<%=(Request.Url.ToString().ToLower().IndexOf("news") != -1)?" class=\"st\"":""%>><a href="/news/">物流聚焦</a></li>
</ul>
</div>