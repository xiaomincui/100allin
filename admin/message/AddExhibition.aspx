<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddExhibition.aspx.cs" Inherits="admin_message_Default" %>

<%@ Register Assembly="CuteEditor.ImageEditor" Namespace="CuteEditor.ImageEditor"
    TagPrefix="iws" %>

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
				  
                  <div style=" float :left">标题：<asp:TextBox ID="txtTitle" runat="server" Width="572px"></asp:TextBox></div>
                  <br />
                  <br />
                  <br />
                  
                  <CE:Editor ID="Editor1" runat="server">
                  </CE:Editor>
                  
                  <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确定" /></div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
