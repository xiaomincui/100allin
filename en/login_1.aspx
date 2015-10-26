<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login_1.aspx.cs" Inherits="en_login_1" %>

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
		  <div class="lg_sm"><img src="images/login/gt.jpg" width="16" height="13" />&nbsp;Welcome to 100allin.com ! you can enjoy every service for free in this website when you finished the registration.As<br /> 
			  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;a registered
      member,you can :
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>·</strong> <strong>View and post sea freight, air freight information</strong><br />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>·</strong> <strong>View news&tools without any limitation</strong><br /> 
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>·</strong> <strong>Promote your services and products</strong></div>
		  <div class="ds">
		  	<h2>ID&Password</h2>
			<table width="858" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td height="15" colspan="2"></td>
    </tr>
  <tr>
    <td width="249" align="right"><strong>ID&nbsp;<span class="red">*</span></strong>&nbsp;:&nbsp;</td>
    <td width="606"><input id="UserName" name="textfield" type="text" size="35" runat="server" /></td>
  </tr>
  <tr>
    <td align="right"><strong>Password&nbsp;<span class="red">*</span></strong>&nbsp;:&nbsp;</td>
    <td><input name="textfield2" type="password" size="35" id="Text1" runat="server" /></td>
  </tr>
  <tr>
    <td align="right"><strong>reconfirm password&nbsp;<span class="red">*</span></strong>&nbsp;:&nbsp;</td>
    <td><input name="textfield3" type="password" size="35" id="Text2" runat="server" /></td>
  </tr>
</table>

		  </div>
		  <div class="ds">
            <h2>Account information</h2>
		    <table width="858" border="0" cellspacing="1" cellpadding="0">
              <tr>
                <td height="15" colspan="2"></td>
              </tr>
              <tr>
                <td width="249" align="right"><strong>First name&nbsp;<span class="red">*</span></strong>&nbsp;:&nbsp;</td>
                <td width="606"><input name="textfield4" type="text" size="35" id="Text3" runat="server" /></td>
              </tr>
              <tr>
                <td align="right"><strong>Last name</strong>&nbsp;:&nbsp;</td>
                <td><input name="textfield22" type="text" size="35" id="Text4" runat="server" /></td>
              </tr>
              <tr>
                <td align="right"><strong>Company name&nbsp;<span class="red">*</span></strong>&nbsp;:&nbsp;</td>
                <td><input name="textfield32" type="text" size="35" id="Text5" runat="server" /></td>
              </tr>
              <tr>
                <td align="right"><strong>Company type&nbsp;<span class="red">*</span></strong>&nbsp;:&nbsp;</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="">Please Choose</asp:ListItem>
                    <asp:ListItem Value="2">Freight Forworder</asp:ListItem>
                    <asp:ListItem Value="3">Carrier</asp:ListItem>
                    <asp:ListItem Value="11">Trading Company</asp:ListItem>
                    <asp:ListItem Value="12">Merchandiser</asp:ListItem>
                    <asp:ListItem Value="4">Others</asp:ListItem>
                    </asp:DropDownList>
                </td>
              </tr>
              <tr>
                <td align="right"><strong>Tel&nbsp;<span class="red">*</span></strong>&nbsp;:&nbsp;</td>
                <td><input name="textfield323" type="text" size="35" id="Text6" runat="server" /></td>
              </tr>
              <tr>
                <td align="right"><strong>Fax </strong>&nbsp;:&nbsp;</td>
                <td><input name="textfield324" type="text" size="35" id="Text7" runat="server" /></td>
              </tr>
              <tr>
                <td align="right"><strong>Email&nbsp;<span class="red">*</span></strong>&nbsp;:&nbsp;</td>
                <td><input name="textfield325" type="text" size="35" id="Text8" runat="server" /></td>
              </tr>
              <tr>
                <td align="right"><strong>Msn</strong>&nbsp;:&nbsp;</td>
                <td><input name="textfield326" type="text" size="35" id="Text9" runat="server" /></td>
              </tr>
              <tr>
                <td align="right"><strong>Website</strong>&nbsp;:&nbsp;</td>
                <td><input name="textfield327" type="text" size="35" id="Text10" runat="server" /></td>
              </tr>
              <tr>
                <td align="right"><strong>Country/Region&nbsp;<span class="red">*</span></strong>&nbsp;:&nbsp;</td>
                <td><input name="textfield328" type="text" size="35" id="Text11" runat="server" /></td>
              </tr>
              <tr>
                <td align="right"><strong>City&nbsp;<span class="red">*</span></strong>&nbsp;:&nbsp;</td>
                <td><input name="textfield329" type="text" size="35" id="Text12" runat="server" /></td>
              </tr>
              <tr>
                <td align="right"><strong>Address</strong>&nbsp;:&nbsp;</td>
                <td><input name="textfield3210" type="text" size="35" id="Text13" runat="server" /></td>
              </tr>
              <tr>
                <td align="right"><strong>Postal code</strong>&nbsp;:&nbsp;</td>
                <td><input name="textfield3211" type="text" size="35" id="Text14" runat="server" /></td>
              </tr>
			  <tr>
                <td height="7" colspan="2"></td>
              </tr>
              <tr>
                <td align="right" valign="top"><strong>Company profile</strong>&nbsp;:&nbsp;</td>
                <td><textarea name="textfield3212" cols="45" rows="8" id="TEXTAREA1" runat="server"></textarea></td>
              </tr>
              <tr>
                <td align="right">&nbsp;</td>
                <td><input type="checkbox" name="checkbox" value="checkbox" id="Checkbox1" runat="server" />
                  <a href="#">I have read the service terms and agree</a></td>
              </tr>
              <tr>
                <td align="right">&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                </td>
              </tr>
              <tr>
                <td align="right">&nbsp;</td>
                <td>&nbsp;</td>
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
