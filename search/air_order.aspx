<%@ Page Language="C#" AutoEventWireup="true" CodeFile="air_order.aspx.cs" Inherits="search_air_order" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>订舱单</title>
<link href="/css/booking0118.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="/css/air_order.css" />
<link rel="stylesheet" type="text/css" href="/js/date/css/w.css"></link>
<style type="text/css">
</style>
<script type="text/javascript" src="/js/air_order.js"></script>
<script type="text/JavaScript">
document.onkeydown=esckeydown;
</script>
<link href="/member/css/dialog2.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/member/js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="/member/js/dialog.js"></script>
<script type="text/javascript">
$(function(){

$("#btnAcceptTemp").click(function(){
  dialog("我的标题","id:divAccept","543px","auto","id");
});

$("#btnRejectTemp").click(function(){
  dialog("我的标题","id:divReject","543px","auto","id");
});  

$("#btnAcceptTemp1").click(function(){
  dialog("我的标题","id:divAccept","543px","auto","id");
});

$("#btnRejectTemp1").click(function(){
  dialog("我的标题","id:divReject","543px","auto","id");
});  
  
});

function editPrice(){
    document.getElementById("txt_edit_priceP45").className = "";
    document.getElementById("txt_edit_priceP100").className = "";
    document.getElementById("txt_edit_priceP300").className = "";
    document.getElementById("txt_edit_priceP500").className = "";
    document.getElementById("txt_edit_priceP1000").className = "";
    
    document.getElementById("fa45").style.display = "none";
    document.getElementById("fa100").style.display = "none";
    document.getElementById("fa300").style.display = "none";
    document.getElementById("fa500").style.display = "none";
    document.getElementById("fa1000").style.display = "none";
    
    document.getElementById("btnCancelEditPrice").className = "";
    document.getElementById("btnAcceptEditPrice").className = "";
    document.getElementById("btnEditPrice").className = "hidden";
}

function cancelEditPrice(){
    document.getElementById("txt_edit_priceP45").className = "hidden";
    document.getElementById("txt_edit_priceP100").className = "hidden";
    document.getElementById("txt_edit_priceP300").className = "hidden";
    document.getElementById("txt_edit_priceP500").className = "hidden";
    document.getElementById("txt_edit_priceP1000").className = "hidden";
    
    document.getElementById("fa45").style.display = "";
    document.getElementById("fa100").style.display = "";
    document.getElementById("fa300").style.display = "";
    document.getElementById("fa500").style.display = "";
    document.getElementById("fa1000").style.display = "";
    
    document.getElementById("btnCancelEditPrice").className = "hidden";
    document.getElementById("btnAcceptEditPrice").className = "hidden";
    document.getElementById("btnEditPrice").className = "";
}
</script>
<style type="text/css">
<!--
.red1 {	color:red;
}
-->
</style>
</head>

<body>

<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div style="display:none;">
<asp:TextBox ID="txtPubf" runat="server"></asp:TextBox>
<asp:Button ID="btnFinishOrderShipper1" runat="server" Text="货主完成订单1" OnClick="btnFinishOrderShipper1_Click" />
<asp:Button ID="btnFinishOrderShipper2" runat="server" Text="货主完成订单2" OnClick="btnFinishOrderShipper2_Click" />
<asp:Button ID="btnFinishOrderForward1" runat="server" Text="货代完成订单1" OnClick="btnFinishOrderForward1_Click" />
<asp:Button ID="btnFinishOrderForward2" runat="server" Text="货代完成订单2" OnClick="btnFinishOrderForward2_Click" />
<asp:Literal ID="ltrBasicOrderCode" runat="server"></asp:Literal>
<asp:Literal ID="ltrSMS" runat="server"></asp:Literal>
</div>
<div class="main_container"><!--页面主体开始-->	
	<div class="top_bar_hd">
		<h2><a href="/"><img src="/images/fcl/home.gif" border="0" alt="环球运费网" /><strong>环球运费网</strong></a></h2>
		<ul>
		<li>&nbsp;<a href="/help/help_about.html" target="_blank"><span class="orange bold">帮助</span></a>&nbsp;</li>
		<li>&nbsp;<a href="/member/" target="_blank">进入办公室</a>&nbsp;|</li>
		<li>&nbsp;<a href="/accounts/reg.aspx">免费注册</a>&nbsp;|</li>
		<li><a href="/accounts/login.aspx">登陆</a>&nbsp;|</li>
		<li><strong class="blue2">欢迎您，<asp:Literal ID="ltrLoginName" runat="server"></asp:Literal>！</strong></li>					
		</ul>
	</div>
  <div class="menu_end"><!--导航开始-->
			<h1><a href="/" target="_blank">首页</a> > 订舱</h1>
 </div>
  <div class="booking_sm">
  <asp:Literal ID="ltrStep" runat="server"></asp:Literal>
  </div>
 <div class="notice"><p>填写订舱单，带 <span class="red1">*</span> 的为必填项目</p>
  </div>
<asp:Literal ID="ltrOrderStatus" runat="server"></asp:Literal>
		<div class="main_content">
			<div class="book">
				<h2><img src="/images/fcl/booking_h2.GIF" /></h2>
				<table width="840" border="0" cellpadding="0" cellspacing="1" bgcolor="#d3d3d3">
<asp:PlaceHolder ID="phOrderView" runat="server">
  <tr>
    <td width="420" rowspan="3" align="center" valign="top" bgcolor="#FFFFFF"><table width="380" border="0" align="center" cellpadding="0" cellspacing="0">
	  <tr>
        <td height="6" align="left"></td>
      </tr>
	  <tr>
        <td height="24" align="left"><span class="red1">*</span><strong> 发货人</strong>(Shipper)：</td>
      </tr>
      <tr>
        <td align="left"><div style="height:80px; border:1px solid #DDDDDD; padding:5px;"><asp:Literal ID="ltrOrderViewShipper" runat="server"></asp:Literal></div></td>
      </tr>
      <tr>
        <td height="24" align="left"><span class="red1">*</span> <strong>收货人</strong>(Consignee)：</td>
      </tr>
      <tr>
        <td align="left"><div style="height:80px; border:1px solid #DDDDDD; padding:5px;"><asp:Literal ID="ltrOrderViewConsignee" runat="server"></asp:Literal></div></td>
      </tr>
      <tr>
        <td height="24" align="left"><span class="red1">*</span> <strong>通知人</strong>(Notify Party)：</td>
      </tr>
      <tr>
        <td align="left"><div style="height:80px; border:1px solid #DDDDDD; padding:5px;"><asp:Literal ID="ltrOrderViewNotifyParty" runat="server"></asp:Literal></div></td>
      </tr>
      <tr>
        <td height="6" align="left"></td>
      </tr>
    </table></td>
    <td width="420" height="24" align="center" bgcolor="#FFFFFF"><strong>订单编号</strong>：<asp:Literal ID="ltrOrderViewCode" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td height="110" align="center" bgcolor="#FFFFFF" class="red" style="font-size:26px;"><strong>订舱委托书</strong></td>
  </tr>
  <tr>
    <td valign="top" bgcolor="#FFFFFF"><table border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="6" colspan="4" align="left"></td>
		</tr>
	  <tr>
        <td width="89" height="31" align="left"><strong>　</strong><span class="red1">*</span> <strong>公司</strong>：</td>
        <td colspan="3" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewCompanyName" runat="server"></asp:Literal></div></td>
        </tr>
      <tr>
        <td height="31" align="left"><strong>　</strong><span class="red1">*</span> <strong>邮箱</strong>：</td>
        <td colspan="3" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewEmail" runat="server"></asp:Literal></div></td>
        </tr>
      <tr>
        <td width="89" height="31" align="left"><span class="red1">*</span> <strong>联系人</strong>：</td>
        <td width="105" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewContactor" runat="server"></asp:Literal></div></td>
        <td width="87" align="left">&nbsp;&nbsp;<span class="red1">*</span><strong> 手机</strong>：</td>
        <td width="99" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewMobile" runat="server"></asp:Literal></div></td>
      </tr>
      <tr>
        <td width="89" height="31" align="left"><strong>　</strong><span class="red1">*</span> <strong>电话</strong>：</td>
        <td width="105" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewTel" runat="server"></asp:Literal></div></td>
        <td width="87" align="left">&nbsp;&nbsp;<span class="red1">*</span> <strong>传真</strong>：</td>
        <td width="99" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewFax" runat="server"></asp:Literal></div></td>
      </tr>
      <tr>
        <td height="31" align="left"><span class="red1">&nbsp;</span> <strong>起运港</strong>：</td>
        <td colspan="3" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;" id="txtstartport"><asp:Literal ID="ltrOrderViewStartport" runat="server"></asp:Literal></div></td>
        </tr>
      <tr>
        <td height="31" align="left"><span class="red1">&nbsp;</span> <strong>中转港</strong>：</td>
        <td colspan="3" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewMidport" runat="server"></asp:Literal></div></td>
        </tr>
		<tr>
        <td height="31" align="left"><span class="red1">&nbsp;</span> <strong>目的港</strong>：</td>
        <td colspan="3" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;" id="txtdestport"><asp:Literal ID="ltrOrderViewDestport" runat="server"></asp:Literal></div></td>
        </tr>
		<tr>
        <td height="6" colspan="4" align="left"></td>
		</tr>
    </table></td>
  </tr>
  <tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table width="820" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" colspan="5" align="center"></td>
        </tr>
	  <tr>
        <td width="140" height="34" align="center"><strong>唛头</strong>：<br />
  Marks & Numbers</td>
        <td width="140" height="31" align="center"><strong>件数</strong>：<br />
          Numbers of Packages</td>
        <td width="240" height="31" align="center"><span class="red">*</span><strong> 品名</strong>：<br />
          Description of Goods &amp;Packages</td>
        <td width="140" height="31" align="center"><span class="red">*</span><strong> 毛重(KGS)</strong>：<br />
          Gross Weight</td>
        <td width="140" height="31" align="center"><span class="red">*</span><strong> 体积(CBM)</strong>：<br />
         Measurement</td>
      </tr>
      <tr>
        <td height="34" align="center"><div style="height:172px; width:115px; border:1px solid #DDDDDD; padding:5px; text-align:left;"><asp:Literal ID="ltrOrderViewMarksNumbers" runat="server"></asp:Literal></div></td>
        <td height="31" align="center"><div style="height:172px; width:115px; border:1px solid #DDDDDD; padding:5px; text-align:left;"><asp:Literal ID="ltrOrderViewNumbersofPackages" runat="server"></asp:Literal></div></td>
        <td height="31" align="center"><div style="height:172px; width:215px; border:1px solid #DDDDDD; padding:5px; text-align:left;"><asp:Literal ID="ltrOrderViewDescription" runat="server"></asp:Literal></div></td>
        <td height="31" align="center"><div style="height:172px; width:115px; border:1px solid #DDDDDD; padding:5px; text-align:left;"><asp:Literal ID="ltrOrderViewGrossWeight" runat="server"></asp:Literal></div></td>
        <td height="31" align="center"><div style="height:172px; width:115px; border:1px solid #DDDDDD; padding:5px; text-align:left;"><asp:Literal ID="ltrOrderViewMeasurement" runat="server"></asp:Literal></div></td>
      </tr>
      <tr>
        <td height="12" colspan="5" align="center"></td>
        </tr>
    </table></td>
    </tr>
  <tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table style="background:url(images/fcl/book_bg.gif) no-repeat 495px;" width="800" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" colspan="9" align="center"></td>
      </tr>
		<tr>
		  <td height="40" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<strong>运费条款</strong>：</td>
		  <td width="121" height="31" align="left">预付(PP)</td>
		  <td width="61" height="31" align="left">&nbsp;</td>
		  <td width="82" height="31" align="left">&nbsp;</td>
		  <td width="105" height="31" align="left">&nbsp;&nbsp;<font color="red">*</font><strong> 航空公司</strong>：</td>
		  <td width="120" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;" id="txtcarrier_name"><asp:Literal ID="ltrOrderViewCarrier" runat="server"></asp:Literal></div></td>
		  <td width="73" align="left">&nbsp;</td>
		  <td width="131" align="left">&nbsp;</td>
		  <td width="15" align="left"></td>
		  </tr>
		<tr>
		  <td height="40" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<font color="red">*</font><strong> 开航日</strong>：</td>
		  <td height="31" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;" id="txtkaihangri"><asp:Literal ID="ltrOrderViewKaihangri" runat="server"></asp:Literal></div>
            </td>
		  <td height="31" align="left"><strong>&nbsp;结束日</strong>：</td>
		  <td height="31" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewEnddate" runat="server"></asp:Literal></div></td>
		  <td height="31" align="left">&nbsp;&nbsp;<strong>预计货妥日</strong>：</td>
		  <td align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewZhuangxiangri" runat="server"></asp:Literal></div>
            </td>
		  <td align="left"><strong style="display:none;">&nbsp;&nbsp;截关日</strong>：</td>
		  <td align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;display:none;"><asp:Literal ID="ltrOrderViewJieguanri" runat="server"></asp:Literal></div>
            </td>
		  <td align="left"></td>
		  </tr>
	  <tr>
	    <td width="91" height="40" align="left"><font color="red">*</font><strong> 计费重量</strong>：</td>
	    <td height="31" colspan="4" align="left"><table border="0" cellpadding="0" cellspacing="0">
	      <tr>
	        <td width="38"><div style="border:1px solid #DDDDDD; padding:3px; width:30px;height:13px;" id="txtgp"><asp:Literal ID="ltrOrderViewGP" runat="server"></asp:Literal></div></td>
	        <td width="45">&nbsp;<strong>KGS</strong></td>
	        </tr>
	      </table></td>
	    <td colspan="3" align="left">
        <div style="border:1px #A4DDFF solid; padding:5px; text-align:center; background:#F4FFFF;line-height:22px;">
        <strong style="font-size:14px;">运费</strong>： <span style="font-size:16px; color:#FF0000; font-weight:bold;">$</span> <span id="hyf" style="font-size:16px; color:#FF0000; font-weight:bold;">
	      <asp:Literal ID="ltrOrderViewHyf" runat="server">0</asp:Literal></span> 
	      <span style="color:#666666;"><asp:Literal ID="ltrOrderFujiafei" runat="server"></asp:Literal></span>
	      </div>
          </td>
	    <td align="left">&nbsp;</td>
	    </tr>
      <tr>
        <td height="12" colspan="9" align="center"></td>
      </tr>
    </table></td>
    </tr>
</asp:PlaceHolder>				
<asp:PlaceHolder ID="phOrderNew" runat="server">			
  <tr>
    <td width="420" rowspan="3" align="center" valign="top" bgcolor="#FFFFFF"><table width="380" border="0" align="center" cellpadding="0" cellspacing="0">
	  <tr>
        <td height="6" align="left"></td>
      </tr>
	  <tr>
        <td height="24" align="left"><span class="red1">*</span><strong> 发货人</strong>(Shipper)：</td>
      </tr>
      <tr>
        <td align="left"><textarea rows="7" class="ipt" id="txtShipper" runat="server"></textarea></td>
      </tr>
      <tr>
        <td height="24" align="left"><span class="red1">*</span> <strong>收货人</strong>(Consignee)：</td>
      </tr>
      <tr>
        <td align="left"><textarea rows="7" class="ipt" id="txtConsignee" runat="server"></textarea></td>
      </tr>
      <tr>
        <td height="24" align="left"><span class="red1">*</span> <strong>通知人</strong>(Notify Party)：</td>
      </tr>
      <tr>
        <td align="left"><textarea rows="7" class="ipt" id="txtNotifyParty" runat="server"></textarea></td>
      </tr>
      <tr>
        <td height="6" align="left"></td>
      </tr>
    </table></td>
    <td width="420" height="24" align="center" bgcolor="#FFFFFF"><strong>订单编号</strong>：<input style="PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; border:0px; BACKGROUND: none transparent scroll repeat 0% 0%; PADDING-TOP: 0px" class="normalInput" readonly="readonly" value="" id="txtCode" runat="server"/></td>
  </tr>
  <tr>
    <td height="110" align="center" bgcolor="#FFFFFF" class="red" style="font-size:26px;"><strong>订舱委托书</strong></td>
  </tr>
  <tr>
    <td valign="top" bgcolor="#FFFFFF"><table border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="6" colspan="4" align="left"></td>
		</tr>
	  <tr>
        <td width="89" height="31" align="left"><strong>　</strong><span class="red1">*</span> <strong>公司</strong>：</td>
        <td colspan="3" align="left"><input class="ipt2" type="text" id="txtCompanyName" runat="server" /></td>
        </tr>
      <tr>
        <td height="31" align="left"><strong>　</strong><span class="red1">*</span> <strong>邮箱</strong>：</td>
        <td colspan="3" align="left"><input class="ipt2" type="text" id="txtEmail" runat="server" /></td>
        </tr>
      <tr>
        <td width="89" height="31" align="left"><span class="red1">*</span> <strong>联系人</strong>：</td>
        <td width="105" align="left"><input class="ipt3" type="text" id="txtContactor" runat="server" /></td>
        <td width="87" align="left">&nbsp;&nbsp;<span class="red1">*</span><strong> 手机</strong>：</td>
        <td width="99" align="left"><input class="ipt3" type="text" id="txtMobile" runat="server" /></td>
      </tr>
      <tr>
        <td width="89" height="31" align="left"><strong>　</strong><span class="red1">*</span> <strong>电话</strong>：</td>
        <td width="105" align="left"><input class="ipt3" type="text" id="txtTel" runat="server" /></td>
        <td width="87" align="left">&nbsp;&nbsp;<span class="red1">*</span> <strong>传真</strong>：</td>
        <td width="99" align="left"><input class="ipt3" type="text" id="txtFax" runat="server" /></td>
      </tr>
      <tr>
        <td height="31" align="left"><span class="red1">&nbsp;</span> <strong>起运港</strong>：</td>
        <td colspan="3" align="left"><input class="ipt2" type="text" id="txtstartport" runat="server" /></td>
        </tr>
      <tr>
        <td height="31" align="left"><span class="red1">&nbsp;</span> <strong>中转港</strong>：</td>
        <td colspan="3" align="left"><input class="ipt2" type="text" id="txtmidport" runat="server" /></td>
        </tr>
		<tr>
        <td height="31" align="left"><span class="red1">&nbsp;</span> <strong>目的港</strong>：</td>
        <td colspan="3" align="left"><input class="ipt2" type="text" id="txtdestport" runat="server" /></td>
        </tr>
		<tr>
        <td height="6" colspan="4" align="left"></td>
		</tr>
    </table></td>
  </tr>
  <tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table width="820" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" colspan="5" align="center"></td>
        </tr>
	  <tr>
        <td width="140" height="34" align="center"><strong>唛头</strong>：<br />
  Marks & Numbers</td>
        <td width="140" height="31" align="center"><strong>件数</strong>：<br />
          Numbers of Packages</td>
        <td width="240" height="31" align="center"><span class="red">*</span><strong> 品名</strong>：<br />
          Description of Goods &amp;Packages</td>
        <td width="140" height="31" align="center"><span class="red">*</span><strong> 毛重(KGS)</strong>：<br />
          Gross Weight</td>
        <td width="140" height="31" align="center"><span class="red">*</span><strong> 体积(CBM)</strong>：<br />
          Measurement</td>
      </tr>
      <tr>
        <td height="34" align="center"><textarea rows="15" class="ipt4" id="txtMarksNumbers" runat="server"></textarea></td>
        <td height="31" align="center"><textarea rows="15" class="ipt4" id="txtNumbersofPackages" runat="server"></textarea></td>
        <td height="31" align="center"><textarea rows="15" class="ipt5" id="txtDescription" runat="server"></textarea></td>
        <td height="31" align="center"><textarea rows="15" class="ipt4" id="txtGrossWeight" runat="server" onchange="calhyf()" onkeyup="calhyf()" onkeypress="return event.keyCode>=48&&event.keyCode<=57||event.keyCode==46" ondragenter="return false" onpaste="return !clipboardData.getData('text').match(/\D/)" style="ime-mode:Disabled"></textarea></td>
        <td height="31" align="center"><textarea rows="15" class="ipt4" id="txtMeasurement" runat="server" onchange="calhyf()" onkeyup="calhyf()" onkeypress="return event.keyCode>=48&&event.keyCode<=57||event.keyCode==46" ondragenter="return false" onpaste="return !clipboardData.getData('text').match(/\D/)" style="ime-mode:Disabled"></textarea></td>
      </tr>
      <tr>
        <td height="12" colspan="5" align="center"></td>
        </tr>
    </table></td>
    </tr>
  <tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table style="background:url(images/fcl/book_bg.gif) no-repeat 495px;" width="800" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" colspan="9" align="center"></td>
      </tr>
		<tr>
		  <td height="40" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<strong>运费条款</strong>：</td>
		  <td width="121" height="31" align="left">预付(PP)</td>
		  <td width="61" height="31" align="left">&nbsp;</td>
		  <td width="82" height="31" align="left">&nbsp;</td>
		  <td width="105" height="31" align="left">&nbsp;&nbsp;<font color="red">*</font><strong> 航空公司</strong>：</td>
		  <td width="120" align="left"><input class="ipt6" id="txtcarrier_name" runat="server"/></td>
		  <td width="73" align="left">&nbsp;</td>
		  <td width="131" align="left">&nbsp;</td>
		  <td width="15" align="left"></td>
		  </tr>
		<tr>
		  <td height="40" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<font color="red">*</font><strong> 开航日</strong>：</td>
		  <td height="31" align="left"><input id="txtkaihangri" class="ipt6" size="5" runat="server" readonly="readonly"/>

            <img width="28" height="22" align="middle" style="CURSOR: pointer" src="/images/fcl/calendar.gif" alt="" id="imgkaihangri"/></td>
		  <td height="31" align="left"><strong>&nbsp;结束日</strong>：</td>
		  <td height="31" align="left"><asp:Literal ID="ltrEndDate" runat="server"></asp:Literal></td>
		  <td height="31" align="left">&nbsp;&nbsp;<strong>预计装箱日</strong>：</td>
		  <td align="left"><input size="14" class="ipt6" id="txtzhuangxiangri" runat="server" readonly="readonly"/>
            <img width="28" height="22" align="middle" style="CURSOR: pointer" src="/images/fcl/calendar.gif" alt="" id="imgzhuangxiangri"/></td>
		  <td align="left"><strong style="display:none;">&nbsp;&nbsp;截关日</strong>：</td>
		  <td align="left"><span style="display:none;"><input size="14" class="ipt6" id="txtjieguanri" runat="server" readonly="readonly"/>
            <img width="28" height="22" align="middle" style="CURSOR: pointer" src="/images/fcl/calendar.gif" alt="" id="imgjieguanri"/></span></td>
		  <td align="left"></td>
		  </tr>
<script type="text/javascript" src="/js/date/js/w.js"></script>
<script type="text/javascript" src="/js/date/js/w1.js"></script>
<script type="text/javascript" src="/js/date/js/w2.js"></script>
<script type="text/javascript" language="javascript">
//<![CDATA[
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-M-d",showCalendarOnTextBoxFocus:true,minimumDate:"1999/1/1",todayButtonText:"今日",noneButtonText:"清空",northImage:"/js/date/images/arrow_down.gif",southImage:"/js/date/images/arrow_up.gif",eastImage:"/js/date/images/arrow_right.gif",westImage:"/js/date/images/arrow_left.gif"}).applyTo({inputID:"txtkaihangri",buttonID:"imgkaihangri"}) : alert("无法载入日期控件，请联系网站客服！");
var BasicDatePicker2 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker2",dateFormat:"yyyy-M-d",showCalendarOnTextBoxFocus:true,minimumDate:"1999/1/1",todayButtonText:"今日",noneButtonText:"清空",northImage:"/js/date/images/arrow_down.gif",southImage:"/js/date/images/arrow_up.gif",eastImage:"/js/date/images/arrow_right.gif",westImage:"/js/date/images/arrow_left.gif"}).applyTo({inputID:"txtzhuangxiangri",buttonID:"imgzhuangxiangri"}) : alert("无法载入日期控件，请联系网站客服！");
var BasicDatePicker3 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker3",dateFormat:"yyyy-M-d",showCalendarOnTextBoxFocus:true,minimumDate:"1999/1/1",todayButtonText:"今日",noneButtonText:"清空",northImage:"/js/date/images/arrow_down.gif",southImage:"/js/date/images/arrow_up.gif",eastImage:"/js/date/images/arrow_right.gif",westImage:"/js/date/images/arrow_left.gif"}).applyTo({inputID:"txtjieguanri",buttonID:"imgjieguanri"}) : alert("无法载入日期控件，请联系网站客服！");
//]]>
</script>        
	  <tr>
	    <td width="91" height="40" align="left"><font color="red">*</font><strong> 计费重量</strong>：</td>
	    <td height="31" colspan="4" align="left"><table border="0" cellpadding="0" cellspacing="0">
	      <tr>
	        <td width="38"><input id="txtgp" value="0" class="ipt8" size="4" runat="server"/></td>
	        <td width="45">&nbsp;<strong>KGS</strong></td>
	        </tr>
	      </table></td>
	    <td height="31" colspan="3" align="left">
        <div style="border:1px #A4DDFF solid; padding:5px; text-align:center; background:#F4FFFF;"><strong style="font-size:14px;">运费</strong>： <span style="font-size:16px; color:#FF0000; font-weight:bold;">$</span> <span id="hyf" style="font-size:16px; color:#FF0000; font-weight:bold;">
	      <asp:Literal ID="ltrHyf" runat="server">0</asp:Literal>
	      </span>
	      <span style="color:#666666;"><asp:Literal ID="ltrOrderFujiafei1" runat="server"></asp:Literal></span>
	      </div>
          </td>
	    <td align="left">&nbsp;</td>
	    </tr>
      <tr>
        <td height="12" colspan="9" align="center"></td>
      </tr>
    </table></td>
    </tr>
</asp:PlaceHolder>	    
  <tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table style="background:url(images/fcl/book_bg.gif) no-repeat 495px;" width="800" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" align="center"></td>
      </tr>
      <tr>
        <td height="31" align="left"><table width="796" border="0" cellpadding="0" cellspacing="0">
          <tr style="background:url(/images/fcl/order_biaoti_bg2.gif)">
            <td width="6" height="30" align="center"><img src="/images/fcl/order_biaoti_bg.gif" /></td>
            <td>&nbsp;<strong>相关运费详情：</strong></td>
            <td width="70"><strong>+45</strong></td>
            <td width="70"><strong>+100</strong></td>
            <td width="70"><strong>+300</strong></td>
            <td width="70"><strong>+500</strong></td>							
            <td width="70"><strong>+1000</strong></td>
            <td width="103" align="center"><strong>订舱保证</strong></td>
            <td width="8" align="center"><img src="/images/fcl/order_biaoti_bg3.gif" /></td>
            </tr>
          <tr>
            <td>&nbsp;</td>
            <td><table border="0" cellpadding="3" cellspacing="1">
              <tr>
                <td height="25"><asp:Literal ID="ltrFreightTitle" runat="server"></asp:Literal> 
                <span class="gray"><asp:Literal ID="ltrFreightPostdate" runat="server"></asp:Literal>～<asp:Literal ID="ltrFreightEnddate" runat="server"></asp:Literal></span>
                <span style="display:none;">
                <asp:Literal ID="ltrFreightTitleHid" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightCompanyHid" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightPostdateHid" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightEnddateHid" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightAssuranceSpaceLevel" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightAssurancePriceLevel" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightAllinStarHid" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightUserStarHid" runat="server"></asp:Literal>
                <strong><span id='fappend' style="display:none;"><asp:Literal ID="ltrFreightAppend" runat="server"></asp:Literal></span><asp:Literal ID="ltrFreightCarrier" runat="server"></asp:Literal></strong>
                </span>                </td>
                </tr>
              <tr>
                <td><span class="blue_2"><b><asp:Literal ID="ltrFreightLine" runat="server"></asp:Literal></b></span>&nbsp;<span class="gray">|</span>&nbsp;<span class="blue_2"><b><asp:Literal ID="ltrFreightStartport" runat="server"></asp:Literal></b></span>&nbsp;<span class="gray">至</span>&nbsp;<span class="blue_2"><b><asp:Literal ID="ltrFreightDestport" runat="server"></asp:Literal></b></span>&nbsp;</td>
                </tr>
              <tr>
                <td><asp:Literal ID="ltrFreightCompany" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightAllinStar" runat="server"></asp:Literal>
                &nbsp; <span class="blue_1">信誉等级：</span><span class="yt"><asp:Literal ID="ltrFreightUserStar" runat="server"></asp:Literal></span></td>
                </tr>
              </table></td>
            <td><asp:TextBox ID="txt_edit_priceP45" runat="server" Width="40" CssClass="hidden"></asp:TextBox><strong><span id='fa45'><asp:Literal ID="ltrFreightA45" runat="server"></asp:Literal></span></strong></td>
            <td><asp:TextBox ID="txt_edit_priceP100" runat="server" Width="40" CssClass="hidden"></asp:TextBox><strong><span id='fa100'><asp:Literal ID="ltrFreightA100" runat="server"></asp:Literal></span></strong></td>
			<td><asp:TextBox ID="txt_edit_priceP300" runat="server" Width="40" CssClass="hidden"></asp:TextBox><strong><span id='fa300'><asp:Literal ID="ltrFreightA300" runat="server"></asp:Literal></span></strong></td>
			<td><asp:TextBox ID="txt_edit_priceP500" runat="server" Width="40" CssClass="hidden"></asp:TextBox><strong><span id='fa500'><asp:Literal ID="ltrFreightA500" runat="server"></asp:Literal></span></strong></td>
			<td><asp:TextBox ID="txt_edit_priceP1000" runat="server" Width="40" CssClass="hidden"></asp:TextBox><strong><span id='fa1000'><asp:Literal ID="ltrFreightA1000" runat="server"></asp:Literal></span></strong></td>
            <td>
              <table border="0" cellpadding="3" cellspacing="1">
                <tr>
                  <td><asp:Literal ID="ltrFreightAssuranceSpace" runat="server"></asp:Literal>                  </td>
                  </tr>
                <tr>
                  <td><asp:Literal ID="ltrFreightAssurancePrice" runat="server"></asp:Literal>                  </td>
                  </tr>
                </table></td>
            <td>&nbsp;</td>
            </tr>
            <asp:PlaceHolder ID="phEditEnabled" runat="server">
            <tr>
            <td colspan="9" align="right"> 
                <asp:Button ID="btnAcceptEditPrice" runat="server" Text="确认修改" class="hidden" OnClick="btnAcceptEditPrice_Click"/>
            <input type="button" value="取消修改" onclick="cancelEditPrice();" id="btnCancelEditPrice" class="hidden"/>
            <input type="button" value="修改运费" onclick="editPrice();" id="btnEditPrice"/>&nbsp;&nbsp;
            </td>
            </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phEditDisabled" runat="server">
            <tr>
            <td colspan="9" align="right"> 
                订单在<strong class="red">等待答复</strong>状态下才可修改运费
            <input type="button" value="修改运费" disabled="disabled"/>&nbsp;&nbsp;
            </td>
            </tr>
            </asp:PlaceHolder>                      
          </table></td>
      </tr>
      <tr>
        <td height="12" align="center"></td>

      </tr>
    </table></td>
  </tr>
  <asp:PlaceHolder ID="phOrderView1" runat="server">
  <tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table width="800" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" align="center"></td>
      </tr>
      <tr>
        <td height="34" align="left"><strong>备注及其他要求</strong>：</td>
        </tr>
      <tr>
        <td height="34" align="center"><div style="border:1px solid #DDDDDD; padding:5px; text-align:left; height:120px;"><asp:Literal ID="ltrOrderViewBeizhu" runat="server"></asp:Literal></div></td>
        </tr>
      <tr>
        <td height="12" align="center"></td>
      </tr>
    </table></td>
  </tr>
  </asp:PlaceHolder>
  <asp:PlaceHolder ID="phOrderNew1" runat="server">
  <tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table width="800" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" align="center"></td>
      </tr>
      <tr>
        <td height="34" align="left"><strong>备注及其他要求</strong>：</td>
        </tr>
      <tr>
        <td height="34" align="center"><textarea class="ipt7" rows="10" cols="129" id="txtbeizhu" runat="server"></textarea></td>
        </tr>
      <tr>
        <td height="12" align="center"></td>
      </tr>
    </table></td>
  </tr>
  </asp:PlaceHolder>
  <tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table width="800" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" align="center"></td>
      </tr>
      <tr>
        <td height="34" align="left"><strong>订舱注意事项</strong>：</td>
        </tr>
      <tr>
        <td height="56" align="left" class="red">
    <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible="false">
    <span class="red">
     1.此订舱单只为线上订舱信息依据，获得对方确认后，请向对方发送线下正式订舱单；<br/>
    <br/>
     2.请提前与对方商户确认清楚人民币费用，以免发生价格纠纷。<br/>
    <br/>
    </span>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible="false">
    <span class="red">
     1.此订舱单只为线上订舱信息依据，若接受该订舱，请向对方索要正式订舱委托书；<br/>
    <br/>
     2.请提前与对方商户确认清楚人民币费用，以免发生价格纠纷。<br/>
    <br/>
    </span>
    </asp:PlaceHolder>
          </td>
      </tr>
      <tr>
        <td height="12" align="center"></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="60" colspan="2" align="center" valign="middle" bgcolor="#FFFFFF">
        <asp:PlaceHolder ID="PlaceHolder5" runat="server">
    <input type="button" value="保存"  id="Button12" onclick="saveForm();"/>
    <div style="display:none;">
    <asp:Button ID="btnEdit" runat="server"  Text="Submit" OnClick="btnEdit_Click" />
    </div></asp:PlaceHolder>

    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
     <input type="button" value="确认无误，订舱"  id="Button5" onclick="orderForm();"/>
      <input type="button" value="保存"  id="Button6" onclick="saveForm();" style="display:none;"/>
    <div style="display:none;">
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
    <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" /></div></asp:PlaceHolder>
    
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <div>        
    <input type="button" value="接受该订舱"  id="btnAcceptTemp1" onclick="calForm2();"/>&nbsp;
    <input type="button" value="不接受该订舱"  id="btnRejectTemp1" onclick="calForm3()"/>&nbsp;
    <input type="button" value="发短消息询问其他信息"  id="btnSMS1" onclick="document.getElementById('linkSMS').click();"/>
    <div style="display:none;">
        <asp:Button ID="btnAccept" runat="server" Text="Accept" OnClick="btnAccept_Click" />
    <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" /></div>
    </div></asp:PlaceHolder>
    
    </td>
  </tr>
</table>
			</div>
			<div class="book_bt"></div>
<div style="position:absolute; top:250px; left:410px; border:2px solid #81A4AD; background:#FFFFFF; text-align:left; padding:15px; line-height:30px; display:none;" id="CancelOrder2Div">

真的要撤销这笔订单吗？<br />
请填写您撤销订单的理由：<br />
<asp:TextBox ID="TextBox2" runat="server" Height="120px" TextMode="MultiLine" Width="400px" CssClass="normalTextArea"></asp:TextBox><br />
<div style="margin:10px 0px;">
<input type="button" value="确认撤销" onclick="ConfirmCancel();"/>
<input type="button" value="取消" onclick="CancelCancelOrder2();"/>
<span style="display:none;"><asp:Button ID="Button13" runat="server" Text="提交投诉" OnClick="Button13_Click"/></span>
<input type="text" value="" id="txtResult" runat="server" style="display:none;"/>
<input type="text" value="" id="txtResultType" runat="server" style="display:none;"/>

</div>
</div>
 
<div style="position:absolute; top:250px; left:410px; border:2px solid #81A4AD; background:#FFFFFF; text-align:left; padding:15px; line-height:30px; display:none;" id="resultDiv">
您要投诉的商家是<asp:Label ID="lblTousu" runat="server" Text="Label"></asp:Label><br />
请填写您要投诉的内容：<br />
<asp:TextBox ID="TextBox1" runat="server" Height="120px" TextMode="MultiLine" Width="400px" CssClass="normalTextArea"></asp:TextBox><br />
<div style="margin:10px 0px;">
<input type="button" value="提交投诉" onclick="ConfirmResult();"/>
<input type="button" value="取消" onclick="CancelResult();"/>
<span style="display:none;"><asp:Button ID="Button14" runat="server" Text="提交投诉"  OnClick="Button14_Click"/></span>
<input type="text" value="" id="Text1" runat="server" style="display:none;"/>
<input type="text" value="" id="Text2" runat="server" style="display:none;"/>

</div>
</div>
			
			
  </div>
 <userbottomline:userbottomline id="userbottomline1" runat="server"/>
 <userbottom:userbottom ID="userbottom1" runat="server" />
</div>

<div id="testID" style="display:none;">
<div class="tc">
<div class="tc_head"><table width="91%" height="32" border="0" align="center" cellpadding="0" cellspacing="1">
<tr>
<td width="92%" class="STYLE1">确认订舱</td>
<td width="8%" align="right"><a href="javascript:void(0);" onclick="javascript:document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';"><img src="/member/images/close.gif" width="38" height="11" border="0" /></a></td>
</tr>
</table>
</div>
<div class="tc_main">
<h1>尊敬的用户，您将接受的订舱信息为：</h1>
<div style="line-height:22px;">
<span id="spanstartport" style="color:Green; font-weight:bold;"></span>&nbsp;至 <span id="spandestport" style="color:Green; font-weight:bold;"></span><br/>
货量：<span id="spangp" style="color:Green; font-weight:bold;"></span><br/>
运费：<span style="color:Green; font-weight:bold;">USD <span id="spanfee"></span></span><br/>
船公司：<span id="spancarrier" style="color:Green; font-weight:bold;"></span><br/>
开航日：<span id="spanstart" style="color:Green; font-weight:bold;"></span>&nbsp;&nbsp;<br />
<span style="display:none;">订舱信息费：<span style="color:Green; font-weight:bold;">RMB <span id="spandingcang" ></span></span></span>
</div>
<div class="text" style="display:none;">货物出运后，环球运费网将奖励信息费 <strong class="green">RMB<span id="spandingcang1" ></span></strong>元 至您账户<br />
请填写您的支付宝或银行账户：</div>
<DIV class="main2box">
<ul>
<li>
<table width="100%" border="0" cellspacing="0" cellpadding="0" id="bank_tab">
<tr>
<td height="32">
支付宝：
<input name="textfield" type="text" class="ms_text" size="50" id="txtaliaccount" runat="server" onchange="javascript:document.getElementById('txtaliaccount').value = this.value;" onblur="javascript:document.getElementById('txtaliaccount').value = this.value;"/>&nbsp;
<a href="https://lab.alipay.com/user/reg/index.htm" target="_blank">注册支付宝账户</a>
</td>
</tr>
<tr>
<td height="32">开户行：
<input type="text" size="50" class="ms_text" id="txtbank" runat="server" onchange="javascript:document.getElementById('txtbank').value = this.value;" onblur="javascript:document.getElementById('txtbank').value = this.value;"/></td>
</tr>
<tr>
<td height="32">&nbsp;&nbsp;户名：
<input type="text" class="ms_text" id="txtbankname" runat="server" onchange="javascript:document.getElementById('txtbankname').value = this.value;" onblur="javascript:document.getElementById('txtbankname').value = this.value;"/></td>
</tr>
<tr>
<td height="32">&nbsp;&nbsp;账号：
<input type="text" class="ms_text" size="50" id="txtbankaccount" runat="server" onchange="javascript:document.getElementById('txtbankaccount').value = this.value;" onblur="javascript:document.getElementById('txtbankaccount').value = this.value;"/></td>
</tr>
<tr>
<td height="32">&nbsp;&nbsp;其他：
<input class="ms_text"  id="txtotheraccount" size="50" runat="server" onchange="javascript:document.getElementById('txtotheraccount').value = this.value;" onblur="javascript:document.getElementById('txtotheraccount').value = this.value;" /></td>
</tr>
</table>
</li>

<li style=" color: #666; border:1px dashed #ccc; padding:9px; background:#eee;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><strong>订舱需知</strong>：<br />
      <strong>1.</strong> 100allin提供运价保证服务，承诺运价以实际发布为准。发现对方有高收行为时，可持相关证据向100allin投诉。如经核属实，100allin将按最高整箱RMB500元/TEU，拼箱RMB500元/票，空运RMB1元/kgs的标准向您赔偿</td>
  </tr>
  <tr>
    <td><strong>2.</strong> 运价有“舱位保证”标识时，表示对方保证此运价有舱位。如接受订舱后发生无舱位现象您可向100allin投诉，如经核属实，将按最高整箱RMB500元/TEU，拼箱RMB500元/票，空运RMB1元/kgs的标准向您赔偿</td>
  </tr>
  <tr>
    <td><strong>3.</strong> 100allin将协助您监督货代服务质量，但不负责如上两条保证服务以外的任何赔偿</td>
  </tr>
  <tr>
    <td><strong>4.</strong> 环球运费网对此规则保留最终解释权</td>
  </tr>
</table>
</li>
<li>
<br/>
<asp:PlaceHolder ID="PlaceHolder7" runat="server">
<input type="button" value="我已阅读上述信息，并确认订舱"  id="Button7" onclick="document.getElementById('btnSubmit').click();"/>
<input type="button" value="保存订单"  id="Button8" onclick="document.getElementById('btnSave').click();" style="display:none;"/>
<input type="button" value="取消"  id="Button9" onclick="javascript:document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';"/>
</asp:PlaceHolder>

<asp:PlaceHolder ID="PlaceHolder6" runat="server">
<input type="button" value="保存订单"  id="Button10" onclick="document.getElementById('btnEdit').click();"/>
<input type="button" value="取消"  id="Button11" onclick="javascript:document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';"/>
</asp:PlaceHolder>
</li>
</ul>
</DIV>
<div class="tc_foot"></div>
</div> 
</div>

<div id="divAccept" style="display:none;">
<div class="tc">
<div class="tc_head"><table width="90%" height="32" border="0" align="center" cellpadding="0" cellspacing="1">
<tr>
<td><strong>确认接受订舱</strong></td>
<td align="right"><a href="#" onclick="javascript:document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';"><img src="/member/images/close.gif" width="38" height="11" border="0" /></a></td>
</tr>
</table>
</div>
<div class="tc_main">
<h1>亲爱的用户,您将确认接受的订舱信息为：</h1>
<div style="line-height:22px;">
<span id="span1" style="color:Green; font-weight:bold;"></span> 至 <span id="span2" style="color:Green; font-weight:bold;"></span><br/>
货量：<span id="span3" style="color:Green; font-weight:bold;"></span><br />
运费：<span style="color:Green; font-weight:bold;">USD <span id="span4"></span></span><br />
船公司：<span id="span5" style="color:Green; font-weight:bold;"></span><br />
开航日：<span id="span6" style="color:Green; font-weight:bold;"></span><br />
订舱保证金：<span style="color:Green; font-weight:bold;">RMB <span id="span7"></span></span>
</div>
<p>
您的账户金额<span class="red"><asp:Literal ID="ltrOverageTotal" runat="server"></asp:Literal></span>元
<asp:PlaceHolder ID="PlaceHolder8" runat="server">
，暂扣本次信息费<span class="red"><asp:Literal ID="ltrOverageThis" runat="server"></asp:Literal></span>元之后，
可用余额为：<span class="red"><asp:Literal ID="ltrOverageAvailable" runat="server"></asp:Literal></span>元。如货物最终未能出运，暂扣金额将返还回您的帐户<br />
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolder9" runat="server" Visible="false">
<br/><span class="red">您的余额不足以支付本次订舱费，请<asp:Literal ID="ltrPayJump" runat="server"></asp:Literal></span>
</asp:PlaceHolder>
</p>
<div style="line-height:25px; border:1px solid #999999; padding:0px 0px 0px 10px;width:470px;height:160px;" id="div2">
提醒您接受订舱后，需要对订舱客户履行以下承诺：<br />
1.海（空）运费以线上订舱时对应的报价为准，不再高收；其他人民币费用请在线下尽快确认好，货物出运后不再高收；<br />
2.整个服务过程中请尽可能提供优质服务将货物按时出运，以提高您的信誉和口碑。<br />
3.货运出运后尽快确认成交。<br />
环球运费网将保留扣除信息费赔偿客户／降低信誉等级／曝光投诉事件等权力。<br />
<br />
</div>
<br />
<div style="text-align:center;">
<asp:PlaceHolder ID="PlaceHolder10" runat="server">
<input type="button" value="我已阅读上述信息，并接受该订舱"  id="Button1" onclick="document.getElementById('btnAccept').click();"/>
</asp:PlaceHolder>
<asp:PlaceHolder ID="PlaceHolder11" runat="server" Visible="false">
<input type="button" value="我已阅读上述信息，并接受该订舱"  id="Button15" disabled="disabled"/>
</asp:PlaceHolder>
<input type="button" value="关闭"  id="Button2" onclick="javascript:document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';"/>
</div>

</div>
<div class="tc_foot"></div>
</div> 
</div>

<div id="divReject" style="display:none;">
<div class="tc">
<div class="tc_head"><table width="90%" height="32" border="0" align="center" cellpadding="0" cellspacing="1">
<tr>
<td><strong>拒绝订舱</strong></td>
<td align="right"><a href="#" onclick="javascript:document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';"><img src="/member/images/close.gif" width="38" height="11" border="0" /></a></td>
</tr>
</table>
</div>
<div class="tc_main">
<h1>亲爱的用户，您将拒绝的订舱信息为：</h1>
<div style="line-height:22px;">
<span id="span8" style="color:Green; font-weight:bold;"></span> 至 <span id="span9" style="color:Green; font-weight:bold;"></span><br/>
货量：<span id="span10" style="color:Green; font-weight:bold;"></span><br/>
运费：<span style="color:Green; font-weight:bold;">USD <span id="span11"></span></span><br/>
船公司：<span id="span12" style="color:Green; font-weight:bold;"></span><br/>
开航日：<span id="span13" style="color:Green; font-weight:bold;"></span><br/>
</div>
<p><span class="red">客户的订舱申请将会在您的商铺中永久存档，如果有不接受订舱的记录，可能会影响到您在环球运费网的运价口碑和声誉，提醒您谨慎拒绝。如确有客观因素不能接受订舱，请您认真如实填写原因：</span></p>
<textarea class="ms_text" style="width:480px;height:120px;" id="txtRejectReason" runat="server" onchange="javascript:document.getElementById('txtRejectReason').value = this.value;" onblur="javascript:document.getElementById('txtRejectReason').value = this.value;"></textarea>
<br />
<div style="text-align:center;">
<input type="button" value="提交"  id="Button3" onclick="orderReject();"/>
<input type="button" value="关闭"  id="Button4" onclick="javascript:document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';"/>
</div>
</div>
<div class="tc_foot"></div>
</div> 
</div>




</form>

</body>
</html>