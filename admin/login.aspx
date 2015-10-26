<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--

-->
</style>
</head>
<body>
<form id="form1" runat="server">
    <div id="page">
		<div id="center">
			<admintop:admintop id="admintop1" runat="server" />
			<adminmenu:adminmenu id="adminmenu1" runat="server" />			
		  <div id="main">
		  	<div id="login">
			  <table border="0" cellspacing="1" cellpadding="5">
                  <tr>
                    <td colspan="2"><span class="tt18 bd">登录网站管理中心</span></td>
                  </tr>
                  <tr>
                    <td width="50">用户名</td>
                    <td width="160">
                        <asp:TextBox ID="txtName" runat="server" Width="150px"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td>密&nbsp;&nbsp;&nbsp;码</td>
                    <td>
                        <asp:TextBox ID="txtPass" runat="server" Width="150px" TextMode="Password"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td colspan="2">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/login.gif" OnClick="ImageButton1_Click" /></td>
                  </tr>
                </table>
			</div>
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />
		</div>
    </div>
</form>
</body>
</html>
