<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login_2.aspx.cs" Inherits="en_login_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
			
			<enusertop:enusertop ID="enusertop1" runat="server" />
		<div class="main_page">
		<div class="dhang">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="images/login/bh_ico1.gif" />&nbsp;&nbsp;&nbsp;<strong>Registration</strong></div>
		<div class="lg_main">
<div class="lg_sm" style="padding:15px 0 15px 230px;"><img style="margin:0 5px -11px 0;" src="images/login/rg.jpg" height="32" />&nbsp;<span class="red"><strong style="font-size:22px;">Congratulations</strong><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You have successfully registered with 100allin.net<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Your ID : <asp:Literal ID="Literal1" runat="server"></asp:Literal>  Password : <asp:Literal ID="Literal2" runat="server"></asp:Literal>  (Automatically Email sent to your registed Email box)</span><br />
<strong><br />
<span class="red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Now you can :</strong><br />
            <span class="red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1<strong>.</strong> <a href="#">Go to post your rates & products</a><br />
            <span class="red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2<strong>.</strong> <a href="#">Go back to homepage</a></div>
		  </div>
		<div class="foot"><a href="#">About Us</a>︱<a href="#">Privacy Policy</a>︱<a href="#">Terms Of Use Agreement</a>︱ <a href="#">Site Map</a>︱<a href="#">Contact Us</a></div>
	  </div>
	</div>
    </form>
</body>
</html>
