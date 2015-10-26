<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payment.aspx.cs" Inherits="member_order_payment" EnableEventValidation="false" EnableViewState="false"%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>付款方式</title>
<link href="../css/offices.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
	<div class="main_container">
    <memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
            <memberleft:memberleft ID="memberleft1" runat="server" />
	        <div class="main">
                <memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
				
                <asp:Button ID="Button1" runat="server" Text="支付宝方式" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="预存方式" />
		    </div>
		</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>
</form>
</body>
</html>
