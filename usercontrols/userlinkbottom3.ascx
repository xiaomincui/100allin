<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userlinkbottom3.ascx.cs" Inherits="usercontrols_userlinkbottom3" %>
<div class="foot">
<strong>友情链接</strong>：
<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
    <a href="<%#Eval("link") %>" target="_blank"><%#Eval("linkname") %></a>
    </ItemTemplate>
</asp:Repeater>

<a href="/links.aspx" target="_blank">更多...</a>

</div>