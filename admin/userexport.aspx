<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userexport.aspx.cs" Inherits="admin_userexport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/userlist.css" rel="stylesheet" type="text/css" />    
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
					<div class="text">用户导出为EXCEL表格</div>
				</div>	
				<div class="rightArea txth22">
                    <input type="button" name="Submit" value=" 所有 " onclick="window.open('/admin/report/user_report.aspx?type=all','report','')" style="height:25px; padding-top:2px" /> 
                    <input type="button" name="Submit" value=" 直客 " onclick="window.open('/admin/report/user_report.aspx?type=zhike','report','')" style="height:25px; padding-top:2px" /> 
                    <input type="button" name="Submit" value=" 同行 " onclick="window.open('/admin/report/user_report.aspx?type=tonghang','report','')" style="height:25px; padding-top:2px" /> 
                    <input type="button" name="Submit" value=" 其他 " onclick="window.open('/admin/report/user_report.aspx?type=qita','report','')" style="height:25px; padding-top:2px" />    
                    <iframe name="report" width="0" height="0"></iframe>
			    </div>			
			</div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
