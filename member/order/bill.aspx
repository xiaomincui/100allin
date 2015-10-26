<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bill.aspx.cs" Inherits="member_order_bill" EnableEventValidation="false" EnableViewState="false"%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
				<DIV id="tabs2">
					  <DIV class="menu2box" style="background:url(../images/ms_bg2.gif) no-repeat left top;">
								<UL id="menu2">
<asp:Literal ID="ltrOrderAll" runat="server"></asp:Literal>
<asp:Literal ID="ltrOrderWait" runat="server"></asp:Literal>
<asp:Literal ID="ltrOrderBusy" runat="server"></asp:Literal>
<asp:Literal ID="ltrOrderFinish" runat="server"></asp:Literal>
<asp:Literal ID="ltrOrderInvalid" runat="server"></asp:Literal>
<asp:Literal ID="ltrOrderCheck" runat="server"></asp:Literal>
<asp:PlaceHolder ID="plhOrderSave" runat="server"><asp:Literal ID="ltrOrderSave" runat="server"></asp:Literal></asp:PlaceHolder>
<li class="hover"><a href="bill.aspx">账单</a></li>
							    </UL>
				  </DIV>
							<DIV class="main2box" style="position:relative;">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<ul>
	<li style="border:none;">
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr>
			<td width="2%" height="39" align="center" background="../images/outbox_bg2.jpg"><a href="#"></a></td>
		    <td width="24%" align="left" background="../images/outbox_bg2.jpg">日期</td>
		    <td width="30%" align="left" background="../images/outbox_bg2.jpg">交易明细</td>
		    <td width="12%" align="left" background="../images/outbox_bg2.jpg">交易类型</td>
		    <td width="12%" align="left" background="../images/outbox_bg2.jpg">信息费</td>
		    <td width="20%" align="left" background="../images/outbox_bg2.jpg">可用金额</td>
		  </tr>
	  </table>
	</li>
<asp:Repeater ID="RptOrder" runat="server">
<ItemTemplate>	
  <li style="line-height:18px; padding:8px 0px;">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="2%" height="39" align="center"><a href="#"></a></td>
        <td width="24%" align="left"><%#Convert.ToDateTime(Eval("detail_date")).ToString("yyyy-MM-dd")%> <%#Convert.ToDateTime(Eval("detail_date")).ToString("HH:mm")%></td>
        <td width="30%" align="left"><a href="<%#ChooseLink(Eval("freight_type").ToString(),Eval("order_code").ToString(),Eval("role").ToString())%>" target="_blank"><%#Eval("order_code")%></a></td>
        <td width="12%" align="left"><%#Eval("status")%></td>
        <td width="12%" align="left"><%#Eval("fee")%></td>
        <td width="20%" align="left"><%#Eval("overage")%></td>
      </tr>
    </table>
  </li>
</ItemTemplate>
</asp:Repeater>		
<li style="line-height:18px; padding:8px 10px 8px 10px; text-align:right;" class="manu">
<%= pagecontrol_string%>
</li>    
</ul>


<div style="display:none;">

<asp:TextBox ID="txtCode" runat="server"></asp:TextBox>

<asp:Button ID="btnSendOrder1" runat="server" Text="提交保存的订单" OnClick="btnSendOrder1_Click" />
<asp:Button ID="btnDelOrder1" runat="server" Text="删除保存的订单" OnClick="btnDelOrder1_Click" />
<asp:Button ID="btnRecoverOrder1" runat="server" Text="恢复订单10" OnClick="btnRecoverOrder1_Click" />
<asp:Button ID="btnAcceptOrder1" runat="server" Text="接受订单" OnClick="btnAcceptOrder1_Click" />
<asp:Button ID="btnFinishOrderShipper1" runat="server" Text="货主完成订单1" OnClick="btnFinishOrderShipper1_Click" />
<asp:Button ID="btnFinishOrderForward1" runat="server" Text="货代完成订单1" OnClick="btnFinishOrderForward1_Click" />
<asp:Button ID="btnFinishOrderForward2" runat="server" Text="货代完成订单2" OnClick="btnFinishOrderForward2_Click" />

<asp:Button ID="btnRejectOrderForward" runat="server" Text="货代不接受订单" OnClick="btnRejectOrderForward_Click" />
<asp:Button ID="btnRerejectOrderForward" runat="server" Text="货代重新接受订单" OnClick="btnRerejectOrderForward_Click" />
<asp:Button ID="btnRecoverOrderForward" runat="server" Text="货代恢复不接受的订单" OnClick="btnRecoverOrderForward_Click" />

<asp:Button ID="btnCancelOrder2" runat="server" Text="撤销订单2" OnClick="btnCancelOrder2_Click" />
<asp:Button ID="btnCancelOrder3" runat="server" Text="撤销订单3" OnClick="btnCancelOrder3_Click" />
<asp:Button ID="btnCancelOrder4" runat="server" Text="撤销订单4" OnClick="btnCancelOrder4_Click" />
<asp:Button ID="btnCancelCancelOrder7" runat="server" Text="取消撤销订单7" OnClick="btnCancelCancelOrder7_Click" />
<asp:Button ID="btnCancelCancelOrder8" runat="server" Text="取消撤销订单8" OnClick="btnCancelCancelOrder8_Click" />
<asp:Button ID="btnCancelCancelOrder9" runat="server" Text="取消撤销订单9" OnClick="btnCancelCancelOrder9_Click" />

<asp:Button ID="btnRecoverOrder11" runat="server" Text="恢复订单11" OnClick="btnRecoverOrder11_Click" />
<asp:Button ID="btnRecoverOrder12" runat="server" Text="恢复订单12" OnClick="btnRecoverOrder12_Click" />
<asp:Button ID="btnRecoverOrder13" runat="server" Text="恢复订单13" OnClick="btnRecoverOrder13_Click" />
<asp:Button ID="btnRecoverOrder14" runat="server" Text="恢复订单14" OnClick="btnRecoverOrder14_Click" />

</div>
<div style="position:absolute; top:40px; left:160px; border:2px solid #81A4AD; background:#FFFFFF; text-align:left; padding:15px; line-height:30px; display:none;" id="evaluationDiv">                        
请对对方商户进行评价：<br />
<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
<asp:ListItem Value="3"  Selected="True">好评 </asp:ListItem>
<asp:ListItem Value="0">中评 </asp:ListItem>
<asp:ListItem Value="-3">差评 </asp:ListItem>
</asp:RadioButtonList>
<br />
评价内容：<br />
<asp:TextBox ID="TextBox1" runat="server" Height="120px" TextMode="MultiLine" Width="400px"></asp:TextBox><br />
<div style="margin:10px 0px;">
<asp:Button ID="Button1" runat="server" Text="提交评价"  OnClick="Button1_Click"/>
<input type="text" value="" id="txtEvaluation" runat="server" style="display:none;"/>
<input type="text" value="" id="txtEvaluationType" runat="server" style="display:none;"/>
<input type="button" value="取消" onclick="CancelEvaluation();"/>
</div>
</div>   

</ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
<ProgressTemplate>
<div style="position:absolute; top:100px; left:200px; border:1px solid #999999; background:#FFFFFF; text-align:center; padding:10px;">
正在处理，请稍候...<br/>
<img src="../images/loading5.gif" alt=""/>
</div>
</ProgressTemplate>
</asp:UpdateProgress>	
 

		  		  </DIV>
			  </DIV>
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
