<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="member_order_list" EnableEventValidation="false" EnableViewState="false"%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>我的订舱单</title>
<script src="js/list.js" type="text/javascript"></script>
<script type="text/javascript">
function popup(f,o)
{
    alert('本订单' + o + '订舱费为'+ f + '，您的余额不足，请充值！');
    window.location = 'pay_sel_single.aspx?orderid='+ o;
}

function popup_normal(id)
{
    document.getElementById("tcDiv").style.display = "";
    //window.open('payment.aspx?orderid='+ id ,'_blank','');
}

function close_popup()
{
    document.getElementById("tcDiv").style.display = "none";
}

function toali()
{
    window.open('alitemp.aspx?orderid='+ document.getElementById('txtCode').value ,'_blank','');
}

function esckeydown()
{
if(event.keyCode==27){
   event.returnValue = null;
   window.returnValue = null;
   document.getElementById('evaluationDiv').style.display = 'none';
   document.getElementById('resultDiv').style.display = 'none';
}
}
document.onkeydown=esckeydown;

function SaveEvaluation(c,t){
document.getElementById('evaluationDiv').style.display = '';
document.getElementById('txtEvaluation').value = c;
document.getElementById('txtEvaluationType').value = t;
}

function CancelEvaluation(){
document.getElementById('evaluationDiv').style.display = 'none';
}


function SaveResult(c,t){
document.getElementById('resultDiv').style.display = '';
document.getElementById('txtResult').value = c;
document.getElementById('txtResultType').value = t;
document.getElementById('Label1').innerHTML = document.getElementById('span_' + c).innerHTML;
}

function ConfirmResult(){
if (document.getElementById('TextBox2').value != "")
{
    var delQus;
    delQus=confirm('确认要投诉对方？');
    if (delQus==true){
	    document.getElementById("Button2").click();
    }	
}
else
{
    alert("请输入投诉内容！");
}
}

function CancelResult(){
document.getElementById('resultDiv').style.display = 'none';
}

</script>
<link href="../css/offices.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
.red{
	color:red;
}

.gray{
	color:#989797;
}

.14n{
	font:14px "宋体";
}

.tc{
	width:543px;
}

.tc_head{
	width:543px;
	height:32px;
	background:url(/member/images/tchu_1.gif) no-repeat center;
	float:left;
}

.tc_main{
	width:489px;
	padding:14px 27px 24px 27px;
	background:url(/member/images/tchu_2.gif) repeat-y center;
	float:left;
}

.tc_main h1{
	font:13px "宋体";
	margin:0 0 6px 0;
	padding:0px;
	line-height:22px;
}

.tc_main p{
	font:12px "宋体";
	color: #999;
	margin:0 0 20px 0;
	padding:0 0 6px 0;
	padding:8px;
	border:1px dashed #CCCCCC;
	line-height:22px;
}

.text{
	margin:0 0 6px 0;
	line-height:28px;
}

.text a{
	color:#305E8F;
}

.text a:hover{
	color:#FF6600;
}

.tc_foot{
	width:543px;
	height:4px;
	background:url(/member/images/tchu_3.gif) no-repeat center;
	float:left;
}

.ms_text{
	font:14px;
	border-left:1px solid #6A6A6A;
	border-top:1px solid #6A6A6A;
	border-bottom:1px solid #B5B5B5;
	border-right:1px solid #B5B5B5;
	line-height:18px;
}
.STYLE1 {font: 14px "宋体"; font-weight: bold; }
.STYLE3 {color: red; font-weight: bold; }

-->
</style>
</head>
<body>
<form id="form1" runat="server">
	<div class="main_container">
    <memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
            <memberleft:memberleft ID="memberleft1" runat="server" />
	        <div class="main" style="overflow:visible;">
                <memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
				<DIV id="tabs2">
					  <DIV class="menu2box" style="background:url(../images/<asp:Literal ID="ltrHeadTitle" runat="server"></asp:Literal>.gif) no-repeat left top;">
								<UL id="menu2">
<asp:Literal ID="ltrOrderAll" runat="server"></asp:Literal>
<asp:Literal ID="ltrOrderWait" runat="server"></asp:Literal>
<asp:Literal ID="ltrOrderBusy" runat="server"></asp:Literal>
<asp:Literal ID="ltrOrderFinish" runat="server"></asp:Literal>
<asp:Literal ID="ltrOrderInvalid" runat="server"></asp:Literal>
<asp:Literal ID="ltrOrderCheck" runat="server"></asp:Literal>
<asp:PlaceHolder ID="plhOrderSave" runat="server"><asp:Literal ID="ltrOrderSave" runat="server"></asp:Literal></asp:PlaceHolder>
<li><a href="bill.aspx">账单</a></li>
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
		    <td width="4%" align="left" background="../images/outbox_bg2.jpg">类型</td>
		    <td width="20%" align="left" background="../images/outbox_bg2.jpg">订单</td>
		    <td width="30%" align="left" background="../images/outbox_bg2.jpg">交易方</td>
		    <td width="18%" align="left" background="../images/outbox_bg2.jpg">交易状态</td>
		    <td width="26%" align="left" background="../images/outbox_bg2.jpg">操作</td>
		  </tr>
	  </table>
	</li>
<asp:Repeater ID="RptOrder" runat="server">
<ItemTemplate>	
  <li style="line-height:18px; padding:8px 0px;">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="font-weight:<%#Eval("status_font_weight") %>;">
      <tr>
        <td width="2%" height="39" align="center"><span style="display:none;" id="span_<%#Eval("order_code").ToString()%>"><a href="/company/<%#setkey(Eval("userid").ToString())%>/" target="_blank"><%#Eval("CompanyName")%></a></span></td>
        <td width="4%" align="left"><img src="/member/images/<%#Eval("alipay_if").ToString() == "1" ?"alipay":"yucun" %>.gif" style="border:none;display:<%#Eval("status_intrade").ToString()=="0"?"none":"" %>" alt="<%#Eval("alipay_if").ToString() == "1" ?"支付宝单笔交易":"预存费交易" %>" /></td>
        <td width="20%" align="left"><a href="/search/<%#Eval("freight_type").ToString() == "8" ? "fcl" : (Eval("freight_type").ToString() == "9" ? "lcl" : (Eval("freight_type").ToString() == "10" ? "air" : "fcl"))%>_order.aspx?filter=view&role=<%#Request.QueryString["f1"].ToString() == "0" ? "shipper":"forward"%>&orderid=<%#Eval("order_code").ToString()%>" target="_blank"><%#Eval("order_code")%></a>
        <br/><%#Convert.ToDateTime(Eval("date_create")).ToString("yyyy-MM-dd")%> <%#Convert.ToDateTime(Eval("date_create")).ToString("HH:mm")%></td>
        <td width="30%" align="left"><div style="width:180px; overflow: hidden; text-overflow:ellipsis;"><nobr><a href="/company/<%#setkey(Eval("userid").ToString())%>/" target="_blank"><%#Eval("CompanyName")%></a></nobr></div></td>
        <td width="18%" align="left"><%#Eval("status_name")%><br/>
        <span style="color:#666666"><%#(Eval("yiping").ToString() == "1" & Eval("yipingother").ToString() == "1") ? "双方已评价" : ((Eval("yiping").ToString() == "1") ? "您已评价" : ((Eval("yipingother").ToString() == "1") ? "对方已评价" : "双方未评价"))%></span></td>
        <td width="26%" align="left"><%#(Eval("yiping").ToString() == "1" ? Eval("op").ToString().Replace("评价", "").Replace("{1}", Eval("order_code").ToString()) : Eval("op").ToString().Replace("{1}", Eval("order_code").ToString())).Replace("{9}", Eval("freight_type").ToString() == "8" ? "fcl" : (Eval("freight_type").ToString() == "9" ? "lcl" : (Eval("freight_type").ToString() == "10" ? "air" : "fcl")))%></td>
      </tr>
      <%#Request.QueryString["f1"].ToString() == "0" ? (Eval("edit_enabled").ToString() == "1" ? "<tr><td colspan=6 align=center><div style=\"border:1px solid #999999;width:255px;padding:5px;margin:3px;font-weight:normal\">承运方要求修改运价: <a href=\"/search/order_edit_confirm.aspx?type=ok&orderid=" + Eval("order_code").ToString() + "\">同意</a> <a href=\"/search/order_edit_confirm.aspx?type=cancel&orderid=" + Eval("order_code").ToString() + "\">不同意</a> <a href=\"/member/order_edit_detail.aspx?orderid=" + Eval("order_code").ToString() + "\" target=\"_blank\" title=\"点击查看承运方修改运费的详细信息\">查看详情</a></div></td></tr>" : "") : ""%>
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
<asp:Button ID="btnFinishOrderShipper2" runat="server" Text="货主完成订单2" OnClick="btnFinishOrderShipper2_Click" />
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

<div style="position:absolute; top:40px; left:160px; border:2px solid #81A4AD; background:#FFFFFF; text-align:left; padding:15px; line-height:30px; display:none;" id="resultDiv">
您要投诉的商家是<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
请填写您要投诉的内容：<br />
<asp:TextBox ID="TextBox2" runat="server" Height="120px" TextMode="MultiLine" Width="400px"></asp:TextBox><br />
<div style="margin:10px 0px;">
<input type="button" value="提交投诉" onclick="ConfirmResult();"/>
<input type="button" value="取消" onclick="CancelResult();"/>
<span style="display:none;"><asp:Button ID="Button2" runat="server" Text="提交投诉"  OnClick="Button2_Click"/></span>
<input type="text" value="" id="txtResult" runat="server" style="display:none;"/>
<input type="text" value="" id="txtResultType" runat="server" style="display:none;"/>
</div>
</div>

<div class="tc" style="position:absolute; top:-30px; left:0px; z-index:10; display:none;" id="tcDiv">
	<div class="tc_head"><table width="90%" height="32" border="0" align="center" cellpadding="0" cellspacing="1">
<tr>
<td width="92%" class="STYLE1">充值</td>
<td width="8%" align="right"><a href="javascript:close_popup();"><img src="/member/images/close.gif" width="38" height="11" border="0" /></a></td>
</tr>
</table>
</div>
  <div class="tc_main">
	  <h1><strong>您的账户没有足够金额，请您选择充值额度继续下一步操作</strong>：</h1>
      <div class="text">
        <input type="radio" name="radiobutton" value="radiobutton" />单笔支付本次费用<span class="STYLE3">300</span>元 <span class="gray">（交易完成返还200元<a href="#">了解规则</a>）</span><br />
        <input type="radio" name="radiobutton" value="radiobutton" />预存<span class="STYLE3">2000</span>元 <span class="gray">（推荐预存<a href="#">享有功能？</a>）</span><br />
        <input type="radio" name="radiobutton" value="radiobutton" />预存<span class="STYLE3">5000</span>元 <span class="gray">（推荐预存<a href="#">享有功能？</a>）</span><br />
      <input type="radio" name="radiobutton" value="radiobutton" />预存<span class="STYLE3">10000</span>元 <span class="gray">（推荐预存<a href="#">享有功能？</a>）</span></div>
      <br />
	  <h1><strong>请选择支付方式</strong>：</h1>
	  <div class="text" style="line-height:23px; background:#f2f2f2; padding:10px; border-bottom:1px solid #ccc;border-top:1px solid #ccc;">
	    <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="45%" rowspan="2" align="center"><a href="javascript:toali();"><img src="/member/images/zfb.GIF" height="25" border="0" /></a></td>
            <td width="1" rowspan="3" align="left" bgcolor="#e0e0e0"></td>
            <td rowspan="3" align="left">&nbsp;</td>
            <td width="48%" height="28" align="left"><strong>银行汇款</strong></td>
          </tr>
          <tr>
            <td>请将款项汇入以下银行： <br />
              户&nbsp;&nbsp;名：上海傲赢信息技术有限公司 <br />
              开户行：022689工行上海金陵东路支行 <br />
            账&nbsp;&nbsp;号：1001268909006860459</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td><span class="red">汇款后请将水单标注用户名并传真至<br />021-53853022以便客服中心进行查账处理</span></td>
          </tr>
        </table>
	  </div>
</div>
	<div class="tc_foot"></div>
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
