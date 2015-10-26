<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pay_bank.aspx.cs" Inherits="member_order_pay_bank" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>我的账单</title>
<script src="js/list.js" type="text/javascript"></script>
<script type="text/javascript">
function SaveEvaluation(c,t){
document.getElementById('evaluationDiv').style.display = '';
document.getElementById('txtEvaluation').value = c;
document.getElementById('txtEvaluationType').value = t;
}

function CancelEvaluation(){
document.getElementById('evaluationDiv').style.display = 'none';
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
    <td width="44%"><strong>预存费用</strong></td>
    <td width="50%" align="right"><a href="#"></a></td>
  </tr>
</table>
</div>
				<div class="fcl">
					<table width="100%" border="0" cellspacing="1" cellpadding="0">
                        <tr>
                          <td width="2%" height="28">&nbsp;</td>
                          <td height="28" align="left"><strong>充值说明</strong></td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td align="left"><table width="80%" border="0" cellpadding="0" cellspacing="2" bgcolor="#AFD0E3" style="line-height:22px;">
                            <tr>
                              <td bgcolor="#F7FCFF"><table width="100%" border="0" cellspacing="6" cellpadding="0">
                                <tr>
                                  <td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;户名：<strong>上海傲赢信息技术有限公司</strong> <br/>                                 
                                  &nbsp;汇款账号：<strong>1001268909006860459</strong><br/>
&nbsp;开户银行：<strong>022689工行上海金陵东路支行</strong><br/>

<span class="red">汇款后请将水单标注用户名并传真至021-53853022，以便客服中心进行查账处理。</span>
</td>
                                </tr>
                              </table></td>
                            </tr>
                            
                          </table></td>
                        </tr>
                        <tr>
                          <td height="12" colspan="2"></td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td align="left"><strong>联系方式</strong></td>
                        </tr>
                        <tr>
                          <td height="28">&nbsp;</td>
                          <td align="left"><table width="60%" border="0" cellpadding="0" cellspacing="2" bgcolor="#AFD0E3" style="line-height:22px;">
                            <tr>
                              <td bgcolor="#F7FCFF"><table width="100%" border="0" cellspacing="6" cellpadding="0">
                                <tr>
                                  <td>&nbsp;&nbsp;&nbsp;电话：<strong>400-888-9256</strong><br/>
&nbsp;&nbsp;&nbsp;传真：<strong>021-53853022</strong><br/>
&nbsp;E-mail：<strong>allin@100allin.com</strong></td>
                                </tr>
                              </table></td>
                            </tr>
                            
                          </table></td>
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
