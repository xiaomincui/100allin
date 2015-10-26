<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cargoselect.aspx.vb" Inherits="member_cargoselect" EnableEventValidation="false" EnableViewState="false"%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>请选择您要发布的货盘类型</title>
<link href="/member/css/offices.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1">
	<div class="main_container">
    <memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
            <memberleft:memberleft ID="memberleft1" runat="server" />
	        <div class="main">
                <memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
				
<div class="fcl_tit"><table width="100%" border="0" cellspacing="1" cellpadding="0">
<tr>
<td width="6%" align="center"><img src="images/tz.gif" width="44" height="27" /></td>
<td width="44%"><strong>请选择您要发布的货盘类型</strong></td>
<td width="50%" align="right"><a href="#"></a></td>
</tr>
</table>
</div>
<div class="fcl">
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="2%" height="24" align="left">&nbsp;</td>
            <td colspan="2" align="left"><table class="other_yf" width="100%" border="0" cellpadding="0" cellspacing="1">
                <tr>
                  <td height="31" align="center">
                  <a href="/member/temp_add4.aspx">发布海运货盘</a><a href="/member/temp_add5.aspx">发布空运货盘</a>
                  </td>
                  </tr>
                
            </table></td>
            <td width="2%" align="left">&nbsp;</td>
          </tr>
          <tr>
            <td height="50" align="left">&nbsp;</td>
            <td width="7%" align="right"><img src="images/warning.gif" width="16" height="16" />&nbsp;</td>
            <td width="89%" align="left"><span style="color:#FF0000;">查询到合适价格后，向对方发送网上订舱单，环球运费网将为您提供价格保证等服务以保障您的权益</span>&nbsp;&nbsp;<a href="/topic/order20091104/product_4.aspx">了解更多&gt;&gt;</a></td>
            <td align="left">&nbsp;</td>
          </tr>
        </table>
			</div>
		    </div>

		</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>

</form>
</body>
</html>