<%@ Page Language="C#" AutoEventWireup="true" CodeFile="useredit_password.aspx.cs" Inherits="en_login_1" %>

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
		  <%--<div class="lg_sm"><img src="images/login/gt.jpg" width="16" height="13" />&nbsp;Welcome to 100allin.com ! you can enjoy every service for free in this website when you finished the registration.As<br /> 
			  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a registered
      member,you can :
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>·</strong> <strong>View and post sea freight, air freight information</strong><br />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>·</strong> <strong>View news&tools without any limitation</strong><br /> 
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>·</strong> <strong>Promote your services and products</strong></div>--%>
		  <div class="ds">
		  	<h2>ID&Password</h2>
			<table width="858" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td height="15" colspan="2"></td>
    </tr>
  <tr>
    <td align="right"><strong>Password&nbsp;<span class="red">*</span></strong>&nbsp;:&nbsp;</td>
    <td><input name="textfield2" type="password"size="35" id="Text1" runat="server" /></td>
  </tr>
  <tr>
    <td align="right"><strong>reconfirm password&nbsp;<span class="red">*</span></strong>&nbsp;:&nbsp;</td>
    <td><input name="textfield3" type="password" size="35" id="Text2" runat="server" /></td>
  </tr>
  <tr>
                <td align="right">&nbsp;</td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button1_Click" />
                </td>
              </tr>
</table>

		  </div>
		</div>
		  <div class="foot"><a href="#">About Us</a>︱<a href="#">Privacy Policy</a>︱<a href="#">Terms Of Use Agreement</a>︱ <a href="#">Site Map</a>︱<a href="#">Contact Us</a></div>
	  </div>
	</div>
    </form>
</body>
</html>
