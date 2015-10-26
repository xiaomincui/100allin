<%@ Control Language="C#" AutoEventWireup="true" CodeFile="adminleft.ascx.cs" Inherits="admin_usercontrols_adminleft" %>
<div id="left">
    <div class="leftbox">
	    <span class="tt14 bd txth30">管理者信息</span><br/>
	    <span class="bd">allinadmin</span>，欢迎您！<br/>
	    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">退出</asp:LinkButton>
    </div>
    <div class="leftbox">
	    <span class="tt14 bd txth30">用户</span><br/>
	    <a href="/manage/user/userlist.aspx">所有用户</a><br/>
    </div>
    <div class="leftbox">
	    <span class="tt14 bd txth30">订单</span><br/>
	    <a href="/manage/order/orderlist.aspx">所有订单</a><br/>
	    <a href="/manage/order/accountlist.aspx">账户管理</a><br/>
    </div>
    <div class="leftbox">
	    <span class="tt14 bd txth30">短消息</span><br/>
	    <a href="/manage/pm/pmlist.aspx">所有系统短消息</a><br/>
    </div>    
    <div class="leftbox">
	    <span class="tt14 bd txth30">缺失运价</span><br/>
	    <a href="/manage/priceneed/pricelist.aspx">缺失运价列表</a><br/>
	    <a href="/manage/priceneed/addprice.aspx">添加缺失运价</a><br/>
	    <a href="/manage/priceneed/linelist.aspx">缺失航线列表</a><br/>
	    <a href="/manage/priceneed/addline.aspx">添加缺失航线</a><br/>
    </div>              
</div>