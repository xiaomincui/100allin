<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReleaseFail.aspx.cs" Inherits="test_releasesucceed" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
				  <p style="color:#535353; padding:35px 0 0 130px; background:url(images/dui.jpg) no-repeat 70px 25px;"><span class="tn14 red"><strong>对不起！ 您发布运价次数太频繁，请与我们的客服人员联系，联系电话：51086987</strong></span><br />
                      <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                      传真公司营业执照和空运一代铜牌资质至
021-53853022，成为安运通，您发布的运价就可排在前面，获取更多成交机会！</asp:PlaceHolder><br />
                    <br />
                    
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

<asp:Literal ID="Literal2" runat="server"></asp:Literal>

<asp:Literal ID="Literal3" runat="server"></asp:Literal>


                     </p>
			  </div>
				
			
		  </div>            
		</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>

</form>
</body>
</html>
