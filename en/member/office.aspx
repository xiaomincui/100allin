<%@ Page Language="C#" AutoEventWireup="true" CodeFile="office.aspx.cs" Inherits="en_office" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/office.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
		<enusertop:enusertop ID="enusertop1" runat="server" />
		<div class="main_page">
			<div class="dhang"><img src="../images/office/of_nav.gif" /></div>
			
			
			<enuserleft:enuserleft ID="enuserleft1" runat="server" />
			
			<div class="of_rg">
				<div class="of_rg_bar">
					<div class="of_rg_solo">Hello, <asp:Literal ID="LitUserName" runat="server"></asp:Literal></div>
					<%--<div class="of_rg_links">Visit Time(s) : <a href="#">3</a></div>--%>
				</div>
				<%--<div class="of_rg_box">
					<h2>My Messages</h2>
				    <p style="border-bottom:1px dotted #cdcdcd;"><img src="../images/office/of_ico1.gif" />&nbsp;I have <a href="#">2 New Messages</a><br />
				      <img src="../images/office/of_ico2.gif" width="16" height="16" />&nbsp;I have sent <a href="#">5 Messages</a></p>
					  <p>· I sent <a href="#">X</a> business messages，N of them are out of date<br />
			      · Your company profile is not complete，<a href="#">Add right now</a></p>
				</div>--%>
				<div class="of_rg_box">
					<h2>Business info</h2>
					<h3><table width="612" border="0" align="center" cellpadding="0" cellspacing="0">
	  <tr>
		<td width="206" height="32"><strong>Column</strong></td>
		<td width="153" height="32"><strong> Post</strong></td>
		<td width="153" height="32"><strong>Edit Messages</strong></td>
		<td width="100" height="32"><strong>Sent</strong></td>
	  </tr>
	  <tr>
		<td height="1" colspan="4" bgcolor="#CDCDCD"></td>
		</tr>
	  <tr>
		<td>Cooperation</td>
		<td>Cooperation</td>
		<td>Cooperation</td>
		<td>2</td>
	  </tr>
	  <tr>
		<td bgcolor="#f0f0f0">Cooperation</td>
		<td bgcolor="#f0f0f0">Cooperation</td>
		<td bgcolor="#f0f0f0">Cooperation</td>
		<td bgcolor="#f0f0f0">2</td>
	  </tr>
	  <tr>
		<td>Cooperation</td>
		<td>Cooperation</td>
		<td>Cooperation</td>
		<td>2</td>
	  </tr>
	  <tr>
		<td bgcolor="#F0F0F0">Cooperation</td>
		<td bgcolor="#F0F0F0">Cooperation</td>
		<td bgcolor="#F0F0F0">Cooperation</td>
		<td bgcolor="#F0F0F0">2</td>
	  </tr>
	  <tr>
		<td>Cooperation</td>
		<td>Cooperation</td>
		<td>Cooperation</td>
		<td>2</td>
	  </tr>
	</table>
					</h3>
				</div>
			</div>
		    <div class="foot"><a href="#">About Us</a>︱<a href="#">Privacy Policy</a>︱<a href="#">Terms Of Use Agreement</a>︱ <a href="#">Site Map</a>︱<a href="#">Contact Us</a></div>
		</div>
	</div>
    </form>
</body>
</html>
