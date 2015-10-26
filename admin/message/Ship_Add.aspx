<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ship_Add.aspx.cs" Inherits="admin_message_News" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../css/userlist.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../js/function.js" type="text/javascript"></script>    
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
			<adminleft:adminleft id="adminleft1" runat="server" />												
		  	<div id="right">
				<div class="tt18 bd rightTitle">
					<div class="text">用户管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">用户编辑</div>
				</div>
                  <div style=" float :left;padding-top:10px">
                      中文名 &nbsp;&nbsp;&nbsp;&nbsp;：<asp:TextBox ID="txtTitle" runat="server" Width="572px"></asp:TextBox></div>
                  <div style=" float :left;padding-top:10px">
                      中文缩写 ：<asp:TextBox ID="TextBox2" runat="server" Width="572px"></asp:TextBox></div>
                  <div style=" float :left;padding-top:10px">
                      英文名 &nbsp;&nbsp;&nbsp;&nbsp;：<asp:TextBox ID="TextBox3" runat="server" Width="572px"></asp:TextBox></div>
                  <div style=" float :left;padding-top:10px">
                      英文缩写&nbsp;&nbsp;：<asp:TextBox ID="TextBox4" runat="server" Width="572px"></asp:TextBox></div>
                  <div style=" float :left;padding-top:10px">
                      网址 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：<asp:TextBox ID="TextBox5" runat="server" Width="572px"></asp:TextBox></div>
                  <div style=" float :left;padding-top:10px">
                      货物跟踪 ：<asp:TextBox ID="TextBox6" runat="server" Width="572px"></asp:TextBox></div>
                  <div style=" float :left;padding-top:10px">
                      联系方式 ：<asp:TextBox ID="TextBox7" runat="server" Width="572px" Height="80px" TextMode="MultiLine"></asp:TextBox></div>
                  <div style=" float :left;padding-top:10px">
                      介绍 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：<asp:TextBox ID="TextBox8" runat="server" Width="572px" TextMode="MultiLine" Height="80px"></asp:TextBox></div>

                  <br />
                  <br />
                  
                 
                  <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确定" />
                  </div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
