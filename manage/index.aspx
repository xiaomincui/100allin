<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="manage_index" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>客户管理</title>
    <link href="/manage/css/master.css" type="text/css" rel="stylesheet" />
    <link href="/js/date/css/w.css" type="text/css" rel="stylesheet" />	
	<script type="text/javascript" src="/js/date/w.js"></script>
	<script type="text/javascript" src="/js/date/w1.js"></script>
	<script type="text/javascript" src="/js/date/w2.js"></script>
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
			<managertop:managertop id="managertop1" runat="server" />
			<managermenu:managermenu id="managermenu1" runat="server" />
		  <div id="main">
			<managerleft:managerleft id="managerleft1" runat="server" />												
		  	<div id="right">
				<div class="tt18 bd rightTitle">
					<div class="icon"><img src="/manage/images/home_title.gif" /></div>
					<div class="text">客户管理</div>
				</div>

				<br/>				
				<div class="tt14 bd rightSubTitle">
					<div class="text">运价/货盘统计</div>
				</div>	
				
				<div class="tt14 bd rightSubTitle">
					<div class="text">用户统计</div>
				</div>	
			  <div class="rightArea txth22">
							    
			  </div>						
			</div>			
		  </div>
		<managerbottom:managerbottom id="managerbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>
