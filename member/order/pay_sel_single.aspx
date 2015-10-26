<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pay_sel_single.aspx.cs" Inherits="member_order_pay_sel_single" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>支付</title>
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
<script src="js/list.js" type="text/javascript"></script>
<script type="text/javascript">

function GoAliLink(){
if (document.getElementById('TextBox1').value == "")
{
alert("请先填写您的支付宝帐户");
document.getElementById('TextBox1').focus();
}
else
{
var a = document.getElementById('TextBox1').value
var o = document.getElementById('orderid').value
if (document.getElementById('rad1').checked == true)
{
    document.getElementById('alilink').href = "/member/order/alitemp.aspx?plus=0&account=" + a + "&orderid=" + o;
}
if (document.getElementById('rad2').checked == true)
{
    document.getElementById('alilink').href = "/member/order/alitemp.aspx?plus=2000&account=" + a;
}
if (document.getElementById('rad3').checked == true)
{
    document.getElementById('alilink').href = "/member/order/alitemp.aspx?plus=5000&account=" + a;
}
if (document.getElementById('rad4').checked == true)
{
    document.getElementById('alilink').href = "/member/order/alitemp.aspx?plus=10000&account=" + a;
}
}


}
</script>
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
				<div class="fcl_tit"><table width="100%" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td width="6%" align="center"><img src="/member/images/edit_icon_2.gif" width="44" height="27" /></td>
    <td width="44%"><strong>支付</strong></td>
    <td width="50%" align="right"><a href="#"></a></td>
  </tr>
</table>
</div>
				<div class="fcl">
					<table width="100%" border="0" cellspacing="1" cellpadding="0">
                        <tr>
                          <td width="2%" height="28">&nbsp;</td>
                          <td height="28" colspan="2" align="left"><strong>您的账户没有足够金额，请您选择支付额度继续下一步操作</strong>：</td>
                        </tr>
                        <tr>
                          <td width="2%" height="28">&nbsp;</td>
                          <td width="49%" align="left"><span class="text">
                          <input type="radio" name="radiobutton" value="radiobutton" checked="checked" id="rad1" />
                          单笔支付本次费用<span class="STYLE3"><asp:Literal ID="Literal1" runat="server"></asp:Literal></span>元 
                          <span class="gray1">（交易完成返还<asp:Literal ID="Literal2" runat="server"></asp:Literal></span>元<a href="#">了解规则</a>）</span></span></td>
                          <td width="49%" align="left"><span class="text">
                            <input type="radio" name="radiobutton" value="radiobutton" id="rad2"/>
                          预存<span class="STYLE3">2000</span>元 <span class="gray1">（推荐预存<a href="#">享有功能？</a>）</span></span></td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td align="left"><span class="text">
                            <input type="radio" name="radiobutton" value="radiobutton" id="rad3"/>
                          预存<span class="STYLE3">5000</span>元 <span class="gray1">（推荐预存<a href="#">享有功能？</a>）</span></span></td>
                          <td align="left"><span class="text">
                            <input type="radio" name="radiobutton" value="radiobutton" id="rad4"/>
                          预存<span class="STYLE3">10000</span>元 <span class="gray1">（推荐预存<a href="#">享有功能？</a>）</span></span></td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td align="left">&nbsp;</td>
                          <td align="left">&nbsp;</td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td colspan="2" align="left"><strong>请选择支付方式</strong>：</td>
                        </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="1" cellpadding="0">
                        <tr>
                          <td width="3%" height="28">&nbsp;&nbsp;</td>
                          <td width="3%">1&nbsp;</td>
                          <td height="60" align="left"><input type="text" id="orderid" runat="server" style="display:none;"/>
                          <a href="#" id="alilink"><img src="/member/images/zfb.GIF" width="120" height="25" border="0" onclick="GoAliLink();" /></a>
                          </td>
                          <td width="77%" align="left">填写您的支付宝账户： <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                           <td height="28">&nbsp;&nbsp;</td>
                           <td>2&nbsp;</td>
                          <td height="28" colspan="2" ><a href="/member/order/pay_bank.aspx"><img src="/member/images/zfb_2.GIF" width="120" height="25" border="0" /></a>
                           </td>
                        </tr>                        
                  </table>
			</div>
			<div class="bill_box">
			    <p>您的预存金额：<span class="red"><asp:Literal ID="ltrCredits" runat="server"></asp:Literal>元</span>&nbsp;&nbsp;
			    可用余额：<span class="red"><asp:Literal ID="ltrOverage" runat="server"></asp:Literal>元</span>&nbsp;&nbsp;
			    <a href="/member/order/bill.aspx">查看账单明细</a>&nbsp;&nbsp;
			    <a href="/member/order/pay_sel.aspx">预存费用充值</a><br/>
			    <span class="red"><asp:Literal ID="ltrResultTip" runat="server"></asp:Literal></span>
			    
			    </p>
			  </div>
		  </div>            
		</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>

</form>
</body>
</html>
