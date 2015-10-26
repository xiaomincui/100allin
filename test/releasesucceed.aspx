<%@ Page Language="C#" AutoEventWireup="true" CodeFile="releasesucceed.aspx.cs" Inherits="test_releasesucceed" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
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
				  <p style="color:#535353; padding:35px 0 0 130px; background:url(images/dui.jpg) no-repeat 70px 25px;"><span class="tn14 red"><strong>恭喜您！您的信息发布已成功！ </strong></span><br />
                    <br />
                    <br />
                    <a href="/member/Release.aspx" title="点击此处继续发布整箱海运运价"><img src="/member/images/succeedbnt1.gif" border="0" /></a>

<a href="/fcl/OG5KZ2w2N0RGU2ZNV0ZMQzlXeTVUZz09_0.html" title="点击此处查看我刚才发布的运价" target="_blank"><img src="/member/images/succeedbnt2.gif" border="0" style="margin-left:20px"  /></a>

<a href="/member/shippinglist.aspx" title="点击此处查看我发布过的整箱海运运价"><img src="/member/images/succeedbnt3.gif" border="0" style="margin-left:20px"  /></a> </p>
			  </div>
				
			
		  </div>            
		</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>

</form>
</body>
</html>
