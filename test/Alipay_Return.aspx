<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Alipay_Return.aspx.cs" Inherits="Alipay_Return" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>支付结果</title>
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
				  <p style="color:#535353; padding:35px 0 0 130px; background:url(images/dui.jpg) no-repeat 70px 25px;"><span class="tn14 red"><strong>订舱费支付已成功！付款金额￥<asp:Literal ID="Literal1" runat="server"></asp:Literal>元。请与对方进一步联系订舱业务！ </strong></span><br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="Literal2" runat="server"></asp:Literal>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/member/order/list.aspx?f1=1&f2=0"><img src="/member/images/ms_bt2.gif" border="0" /></a> </p>
			  </div>
				
			
		  </div>            
		</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>

</form>
</body>
</html>
