<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userbbslogin.ascx.cs" Inherits="usercontrols_userbbslogin" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="lodin_box">
	<h2><a href="/accounts/login.aspx">用户登陆</a></h2>	
	<div class="nb">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>	
		<asp:Panel ID="Panel1" runat="server">					
	  <div class="username">用户名：
	    <asp:TextBox ID="txtUsername" runat="server" CssClass="loginbox" TabIndex="1"></asp:TextBox>
	    &nbsp;<a href="#" target="_parent"></a>&nbsp;<a class="gray" href="#" target="_blank"></a>							</div>
	  <div class="password">密&nbsp;&nbsp;码：
		 <asp:TextBox ID="txtPassword" runat="server" CssClass="loginbox" TextMode="Password" TabIndex="2"></asp:TextBox>
		  &nbsp;</div>
	  <div class="ld_bt">
		    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkAutoLogin" runat="server" Checked="True" />记住用户名&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/bbs/ldbt.GIF" TabIndex="3" OnClick="ImageButton1_Click"  BorderWidth="0px" /></div>
	 <div class="ld_nav"><img src="/images/bbs/ld1.GIF" alt=""/><a href="/accounts/reg.aspx">注册新用户</a><img src="/images/bbs/ld2.GIF" alt="" style="display:none;"/><a href="#" style="display:none;">忘记密码</a>     <img src="/images/bbs/ld3.GIF" alt="" style="display:;"/><a href="/help/help_about.html">帮助中心</a></div>
	 <asp:Label ID="homelogout" runat="server" Text="<script src='/home/newlogout.php' type='text/javascript' language='javascript'></script>"></asp:Label>
	 </asp:Panel>
	 
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <div style="padding:10px 10px 0px 10px; " class="divaldlogin">
                    <div style="float:left; width:90px;">
                    <img id="imghead" src="/images/fcl/people.GIF" width="70" height="70" runat="server" style="border:1px solid #CCCCCC" />
                    </div>
                <div style="float:;line-height:17px;">
            <b>欢迎您！<br /><asp:Label ID="Label1" runat="server" Text=""></asp:Label></b>&nbsp;<br />
            <div style="line-height:22px; padding-top:3px;">
            <a href ="/bbs/my.aspx">我的帖子</a> <a href ="/bbs/post.aspx">我要发帖</a><br />
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"  >退出登录</asp:LinkButton>
            </div>
                </div>
                </div>
                <div class="ld_nav">
                <img src="/images/bbs/ld1.GIF" alt=""/><a href="/accounts/reg.aspx">注册新用户</a>
                <img src="/images/bbs/ld2.GIF" alt="" style="display:none;"/>
                <a href="#" style="display:none;">忘记密码</a>
                <img src="/images/bbs/ld3.GIF" alt="" style="display:;"/>
                <a href="/help/help_about.html">帮助中心</a></div>    
                 <asp:Label ID="homelogin" runat="server" Text="<script src='/home/newlogin.php' type='text/javascript' language='javascript'></script>"></asp:Label>
            </asp:Panel>     
	 
        </ContentTemplate>
        </asp:UpdatePanel>
	</div>
</div>