<%@ Control Language="C#" AutoEventWireup="true" CodeFile="clubheader.ascx.cs" Inherits="club_uc_clubheader" %>
<DIV id=header>
<DIV class=headerwarp>
<H1 class=logo><A href="http://www.100allin.com/home/index.php"><IMG alt=环球运费网 
src="images/logo.gif"></A></H1>
<UL class=menu>
  <LI><A href="http://www.100allin.com/" target=_blank>首页</A> </LI>
  <LI><A href="/home/space.php?do=home">社区首页</A> </LI>
  <LI><A href="http://www.100allin.com/home/space.php">个人主页</A> </LI>
  <LI><A href="http://www.100allin.com/home/space.php?do=friend">好友</A> </LI>
  <LI><A href="http://www.100allin.com/home/network.php">随便看看</A> </LI>
  <LI><A href="http://www.100allin.com/home/space.php?do=pm">消息</A> </LI></UL>
<DIV class=nav_account>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
<BR><A href="http://www.100allin.com/home/cp.php?ac=invite">邀请</A> | <A 
href="http://www.100allin.com/home/cp.php">设置</A> | <A 
href="http://www.100allin.com/home/cp.php?ac=privacy">隐私</A>
<script src='/home/newlogin.php'></script>
</asp:PlaceHolder> 
<asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
<script src='/home/newlogout.php'></script>
</asp:PlaceHolder>
</DIV></DIV></DIV>

