<%@ Page Language="C#" AutoEventWireup="true" CodeFile="me.aspx.cs" Inherits="member_feed_me" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>我的动态</title>
<link href="/member/css/offices.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
	<div class="main_container">
    <memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
            <memberleft:memberleft ID="memberleft1" runat="server" />
	        <div class="center_box">
				<div class="dynamic">
					<div class="dynamic_title"><strong>我的动态</strong></div>
					<DIV id=tabs1>
					  <DIV class=menu1box>
								<UL id=menu1>
								  <LI style="border-left:none;"><A 
								  href="/member/feed/friend.aspx"><strong>商友动态</strong></A></LI>
								  <LI class=hover><A
								  href="/member/feed/me.aspx"><strong>我的动态</strong></A></LI>
								  <LI><A
								  href="/home/space.php?do=home" target="_blank"><strong>社区动态</strong></A></LI>
							    </UL>
					  </DIV>
							<DIV class=main1box>
								<ul>
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
<li>
<table width="100%" border="0" cellspacing="1" cellpadding="0">
<tr>
<td width="18%" rowspan="3" align="center"><table width="1" border="0" cellspacing="1" cellpadding="0">
<tr>
<td><a href="/company/<%#setkey(Eval("userid").ToString()) %>/" target="_blank"><img src="/member/Head/<%#Eval("HeadURL").ToString() == "False"? "default": Eval("userid").ToString() %>.jpg" border="0" width="54" height="54" /></a></td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
</table><a href="#"></a></td>
<td height="24"  style="line-height:25px;"><%#Eval("TXT").ToString().Replace("{1}", setkey(Eval("id").ToString())).Replace("{2}", setkey(Eval("userid").ToString()))%></td>
<td align="right"><%#Convert.ToDateTime(Eval("POSTDATE").ToString()).ToString("yyyy-M-d").ToString() %><br/>
<%#Convert.ToDateTime(Eval("POSTDATE").ToString()).ToString("h:mm:ss").ToString() %>
</td>
<td width="2%" align="right">&nbsp;</td>
</tr>
</table>
</li>
</ItemTemplate>
</asp:Repeater>
								</ul>
					  		</DIV>
					</DIV>
				</div>
		  </div>
			<memberright:memberright ID="memberright1" runat="server" />	

		</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>

</form>
</body>
</html>
