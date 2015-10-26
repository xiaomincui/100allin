<%@ Page Language="C#" AutoEventWireup="true" CodeFile="releasesucceed.aspx.cs" Inherits="test_releasesucceed" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server" >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>发布成功</title>
<style type="text/css">
<!--
.STYLE3 {color: red; font-weight: bold; }
.gray1 {	color:#989797;
}
.text {	margin:0 0 6px 0;
	line-height:28px;
}
-->
</style>

<link href="/member/css/offices.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
	<div class="main_container">
    <memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
            <memberleft:memberleft ID="memberleft1" runat="server" />
<div class="main">
				<memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
				<div class="remind">
				<div style=" width:686px; height:155px; background-image:url(images/bg01.jpg); border:1px solid #B7BEC6">
	<div style="padding:30px 0 0 179px;float:left; width:42px; height:39px">
		<img src="images/gou01.gif" />
	</div>
	<div style="padding:45px 0 10px 23px;float:left;width:442px;">
		<strong><span style="color:#980203; font-size:14px">亲爱的用户，我们正在审核您的运价，审核成功后将会显示在网站上</span></strong>
	</div>
	
		<div style="padding:38px 0 0px 121px;width:109px;height:30px;float:left"><asp:Literal ID="Literal1" runat="server"></asp:Literal>
</div>
		<div style="padding:38px 0 0px 63px;width:109px;height:30px;float:left"><asp:Literal ID="Literal2" runat="server"></asp:Literal></div>
		<div style="padding:38px 0 0px 63px;width:109px;height:30px;float:left"><asp:Literal ID="Literal3" runat="server"></asp:Literal></div>
	
</div>
<div style="padding:46px 0 0 0"><img src="images/advpicture.jpg" /></div>
<div style="padding:38px 0 0px 140px;width:109px;float:left"><a href="http://www.100allin.com/products/"><img src="images/knowvenditionbnt.jpg" border="0" /></a></div>
<div style="padding:38px 0 0px 86px;width:109px;float:left"><a href="http://www.100allin.com/products/buy.aspx?type=1"><img src="images/applyvenditionbnt.jpg" border="0" /></a></div>





				

			  </div>
				
			
		  </div>            
		</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>

</form>
</body>
</html>
