<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sign.aspx.cs" Inherits="en_sign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>sign</title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
			<enusertop:enusertop ID="enusertop1" runat="server" />
		<div class="main_page">
				<div class="login_main_left">
						  <table width="385" border="0" cellspacing="0" cellpadding="0">
							<tr>
							  <td colspan="2"><img src="images/login/login_1.gif" width="385" height="66" /></td>
							</tr>
							<tr>
							  <td height="10" colspan="2"></td>
							</tr>
							<tr>
							  <td width="112" height="42" align="right"><span class="red">Member ID</span>&nbsp;:&nbsp;&nbsp;</td>
							  <td width="302"><input name="Username" type="text" id="username" size="30" runat="server" /></td>
							</tr>
							<tr>
							  <td height="42" align="right"><span class="red">Password</span>&nbsp;:&nbsp;&nbsp;</td>
							  <td><input name="Password" type="password" id="password" size="30" runat="server" /></td>
							</tr>
							<tr>
							  <td height="24" align="right">&nbsp;</td>
							  <td><asp:CheckBox ID="chkAutoLogin" runat="server" Checked="True" />
								<span class="gray">Keep me signed in</span></td>
							</tr>
							<tr>
							  <td height="82" align="right">&nbsp;</td>
							  <td>
							  <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/login/login_2.jpg" OnClick="ImageButton1_Click" />
							  </td>
							</tr>
						  </table>
		        </div>
				<div class="login_main_right">
				  <table width="385" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td colspan="2"><img src="images/login/login_4.gif" width="385" height="66" /></td>
                    </tr>
                    <tr>
                      <td height="10" colspan="2"></td>
                    </tr>
                    <tr>
                      <td width="50" height="42" align="right">&nbsp;</td>
                      <td width="335">· Registration is easy and free ! </td>
                    </tr>

                    <tr>
                      <td height="82" align="right">&nbsp;</td>
                      <td>
                      <a href="login_1.aspx"><img src="images/login/login_5.jpg"  height="36" border="0" /></a>
                      </td>
                    </tr>
                    <tr>
                      <td height="20" colspan="2" align="right"></td>
                    </tr>
                    <tr>
                      <td height="1" colspan="2" align="right" background="images/login/login_6.gif"></td>
                    </tr>
					<tr>
                      <td height="30" colspan="2"></td>
                    </tr>
					<tr>
                      <td height="10" colspan="2" align="left"><img src="images/login/login_7.gif" height="42" /></td>
                    </tr>
					<tr>
					  <td height="7" colspan="2" ></td>
				    </tr>
					<tr>
					  <td height="86" colspan="2" style="background:url(images/login/login_8.gif) no-repeat left;"><table width="385" height="119" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                          <td width="50">&nbsp;</td>
                          <td class="login_red"><img src="images/login/login_9.gif" width="9" height="10" /> find freight forwarders worldwide<br />
                            <img src="images/login/login_9.gif" width="9" height="10" /> Post business offers to reach deals<br />
                            <img src="images/login/login_9.gif" width="9" height="10" /> Enjoy recommendation Service<br />
                          <img src="images/login/login_9.gif" width="9" height="10" /> Search for the freight you need<br />
						  <img src="images/login/login_9.gif" width="9" height="10" /> Choose reliable partner
						  </td>
                        </tr>
                      </table></td>
				    </tr>
                  </table>
				</div>
		  <div class="foot"><a href="#">About Us</a><a href="#">Privacy Policy</a><a href="#">Terms Of Use Agreement</a>?<a href="#">Site Map</a><a href="#">Contact Us</a></div>
		</div>
	</div>
    </form>
</body>
</html>
