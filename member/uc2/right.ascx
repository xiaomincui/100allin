<%@ Control Language="C#" AutoEventWireup="true" CodeFile="right.ascx.cs" Inherits="member_uc_right" %>
<div class="right_box">
	<div class="visited">
		<h1><img src="/member/images/jy.gif" /><strong>最近来访</strong> (<asp:Literal ID="ltrVisitFriendCount" runat="server">0</asp:Literal>)</h1>
    <asp:Repeater ID="RptVisitFriends" runat="server">
        <ItemTemplate>
		<div class="vaflist">
			<div class="vaflist_pic">
                <a href="/company/<%#setkey(Eval("userid").ToString()) %>/" target="_blank"><img src="/member/Head/<%#Eval("HeadURL").ToString() == "False"? "default": Eval("userid").ToString() %>.jpg" border="0" width="54" height="54" /></a></div>
		  <div class="vaflist_tn"><a href="/company/<%#setkey(Eval("userid").ToString()) %>/" target="_blank"><%#Eval("Realname") %></a><br/>
		    <%#Eval("CompanyName")%>
		   </div>
		</div>	                    
        </ItemTemplate>
    </asp:Repeater>
		<div class="link"><a href="/member/visitor.aspx">所有访客>></a></div>
	</div>
	<div class="visited">
		<h1><img src="/member/images/fd.gif" /><strong>我的好友</strong> (<asp:Literal ID="ltrMyFriendCount" runat="server">0</asp:Literal>)</h1>
    <asp:Repeater ID="RptMyFriends" runat="server">
        <ItemTemplate>
		<div class="vaflist">
			<div class="vaflist_pic">
                <a href="/company/<%#setkey(Eval("userid").ToString()) %>/" target="_blank"><img src="/member/Head/<%#Eval("HeadURL").ToString() == "False"? "default": Eval("userid").ToString() %>.jpg" border="0" width="54" height="54" /></a></div>
		  <div class="vaflist_tn"><a href="/company/<%#setkey(Eval("userid").ToString()) %>/" target="_blank"><%#Eval("Realname") %></a><br/>
		    <%#GetFirstString(Eval("CompanyName").ToString(),30)%>
		   </div>
		</div>	                    
        </ItemTemplate>
    </asp:Repeater>

	  <div class="link"><a href="/member/friend.aspx">所有好友>></a></div>
	</div>
</div>