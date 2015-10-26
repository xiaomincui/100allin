<%@ Control Language="C#" AutoEventWireup="true" CodeFile="bbsadminleft.ascx.cs" Inherits="admin_usercontrols_adminleft" %>
<div id="left">
    <div class="leftbox">
	    <span class="tt14 bd txth30">管理者信息</span><br/>
	    <span class="bd">
            <asp:Literal ID="LitName" runat="server"></asp:Literal></span>，欢迎您！<br/>
	    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">退出</asp:LinkButton>
    </div>
    <div class="leftbox">
	    <span class="tt14 bd txth30">相关统计</span><br/>
	    <%--<a href="/admin/bbsadmin/recycleBBSadminList.aspx">回收站</a><br/>
	    <a href="/admin/bbsadmin/BBSadminList.aspx">所有帖子</a><br/>--%>
    </div>

</div>