<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userbbshot.ascx.cs" Inherits="usercontrols_userbbshot" %>
<div class="at_box">
	<h2>大家关注</h2>
	<div class="at_show">
		<div class="pic"><asp:Literal ID="ltrHotPic1" runat="server" Text="大家关注图片1"></asp:Literal></div>
		<div class="text"><strong style="font-size:13px;"><asp:Literal ID="ltrHotTitle1" runat="server" Text="大家关注标题1"></asp:Literal></strong><br />
	    <span class="gray"><asp:Literal ID="ltrHotIndex1" runat="server" Text="大家关注索引1"></asp:Literal></span></div>
	</div>
	<div class="at_show">
		<div class="pic"><asp:Literal ID="ltrHotPic2" runat="server" Text="大家关注图片1"></asp:Literal></div>
		<div class="text"><strong style="font-size:13px;"><asp:Literal ID="ltrHotTitle2" runat="server" Text="大家关注标题2"></asp:Literal></strong><br />
	    <span class="gray"><asp:Literal ID="ltrHotIndex2" runat="server" Text="大家关注索引2"></asp:Literal></span></div>
	</div>
	<ul>
<asp:Repeater ID="RptHot" runat="server">
    <ItemTemplate>
	    <li style="background-color:<%#IsOdd(this.RptHot.Items.Count + 1) == true?"#FFFFFF":"#f8f8f8" %>;"> <img src="/images/bbs/n<%#this.RptHot.Items.Count + 1 %>.GIF" alt=""/><a href="<%#Eval("urllink").ToString()%>" title="<%#Eval("Title").ToString()%>" target="_blank"><%#GetFirstString(Eval("Title").ToString(),30)%></a></li>
    </ItemTemplate>
</asp:Repeater>								
	</ul>
</div>