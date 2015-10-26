<%@ Page Language="C#" AutoEventWireup="true" CodeFile="portedit.aspx.cs" Inherits="admin_portedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/userlist.css" rel="stylesheet" type="text/css" />
    <script language=javascript src=js/function.js></script>    
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
					<div class="icon"><img src="images/home_title.gif" /></div>
					<div class="text">信息管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">港口编辑</div>
				</div>			  	
		  	    <div style="border:1px solid #D9D9D9;background:#F0F0F0;padding:  6px 5px 5px 10px;margin:0px 0px 7px 0px;">
		  	          <table>
		  	            <tr>
		  	                <td><strong>港口英文名</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px"><asp:TextBox ID="txtCityName" runat="server"></asp:TextBox></div></td>
		  	                <td style="width: 182px"><div style=" padding:0px 0px 0px 40px">
		  	            </tr>
		  	            <tr>
		  	                <td><strong>港口中文名</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px"><asp:TextBox ID="txtCityNameCH" runat="server"></asp:TextBox></div></td>
		  	                <td style="width: 182px"><div style=" padding:0px 0px 0px 40px">
		  	            </tr>	
		  	            <tr>
		  	                <td><strong>所属国家英文名</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px"><asp:TextBox ID="txtCountry" runat="server"></asp:TextBox></div></td>
		  	                <td style="width: 182px"><div style=" padding:0px 0px 0px 40px">
		  	            </tr>
		  	            <tr>
		  	                <td><strong>所属国家中文名</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px"><asp:TextBox ID="txtCountryCH" runat="server"></asp:TextBox></div></td>
		  	                <td style="width: 182px"><div style=" padding:0px 0px 0px 40px">
		  	            </tr>	
		  	            <tr>
		  	                <td><strong>航线</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px"><asp:TextBox ID="txtLine" runat="server"></asp:TextBox></div></td>
		  	                <td style="width: 182px"><div style=" padding:0px 0px 0px 40px">
		  	            </tr>	
		  	            <tr>
		  	                <td><strong>地图链接</strong></td>
		  	                <td><div style=" padding:0px 0px 0px 20px"><asp:TextBox ID="txtMapsLinks" runat="server"></asp:TextBox></div></td>
		  	                <td style="width: 182px"><div style=" padding:0px 0px 0px 40px">
		  	            </tr>			  	            		  	            	  	            		  	            	  	          
		  	          </table>
                      <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" /> <asp:Button ID="Button2" runat="server" Text="取消" />
                </div>
                
                <div id="tmain">
                <table cellspacing="0" cellpadding="3" rules="rows" bordercolor ="#D9D9D9" border="1" id="GridView1" style="border-width:1px;border-style:Solid;border-collapse:collapse; width:780px">
                    
                    
                    
                    
                    
                
                </table>
                
                </div>
                
                
                
		  	</div>		
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>

