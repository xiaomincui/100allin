<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userlinkbottom.ascx.cs" Inherits="usercontrols_userlinkbottom" %>
<div class="foot">
<strong>友情链接</strong>：
<a href="http://www.chinaports.com/containerTracker/" target="_blank">集装箱查询</a>
<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
    <a href="<%#Eval("link") %>" target="_blank"><%#Eval("linkname") %></a>
    </ItemTemplate>
</asp:Repeater>

<a href="/links.aspx" target="_blank">更多...</a>

</div>