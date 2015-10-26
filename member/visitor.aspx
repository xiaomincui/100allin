<%@ Page Language="C#" AutoEventWireup="true" CodeFile="visitor.aspx.cs" Inherits="member_visitor"  EnableEventValidation="false" EnableViewState="false"%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>所有访客</title>
<link href="/member/css/offices.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
	<div class="main_container">
    <memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
            <memberleft:memberleft ID="memberleft1" runat="server" />
	        <div class="main">
			  <div class="friend_title"><strong>最近来访</strong></div>	        
			  <DIV id="tabs2">
					  <DIV class="menu2box" style="padding-top:">
								<UL id="menu2" style="margin-left:25px;">
								  <LI><A
								  href="/member/friend.aspx">我的好友</A></LI>
								  <LI class=hover  style="border-left:none;"><A 
								  href="#"><strong>最近来访</strong></A></LI>
							    </UL>
			    </DIV>
							<DIV class="main2box" style="padding-top:10px;">
                <asp:Repeater ID="RptVisitFriends" runat="server">
                    <ItemTemplate>						
					<div class="vaflist">
						<div class="vaflist_pic"><a href="/company/<%#setkey(Eval("userid").ToString()) %>/" target="_blank"><img src="/member/Head/<%#Eval("HeadURL").ToString() == "False"? "default": Eval("userid").ToString() %>.jpg" border="0" width="54" height="54" /></a></div>
					  <div class="vaflist_tn"><a href="/company/<%#setkey(Eval("userid").ToString()) %>/" target="_blank"><%#Eval("Realname") %></a><br/>
					     <%#GetFirstString(Eval("CompanyName").ToString(),30)%></div>   
					</div>
                    </ItemTemplate>
                </asp:Repeater>					
		  		            </DIV>
			  </DIV>
		    </div>

		</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>

</form>
</body>
</html>