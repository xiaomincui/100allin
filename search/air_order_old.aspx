<%@ Page Language="C#" AutoEventWireup="true" CodeFile="air_order_old.aspx.cs" Inherits="search_air_order" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>订舱单</title>
<link href="/css/fcl_css0904.css" rel="stylesheet" type="text/css" />
<link href="/css/WebResource.css"  rel="stylesheet" type="text/css" />	
<style type="text/css">
.red{
	color:red;
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
	padding:19px 27px;
	background:url(/member/images/tchu_2.gif) repeat-y center;
	float:left;
}

.tc_main h1{
	font:14px "宋体";
	margin:0 0 6px 0;
	padding:0 0 6px 0;
	line-height:26px;
	border-bottom:1px dashed #CCCCCC;
}

.tc_main p{
	margin:0 0 6px 0;
	line-height:20px;
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

.normalInput {
 BORDER-TOP-WIDTH: 0px; 
 PADDING-RIGHT: 3px; 
 PADDING-LEFT: 4px; 
 BORDER-LEFT-WIDTH: 0px; 
 BACKGROUND: #f0f0f0; 
 BORDER-BOTTOM-WIDTH: 0px; 
 PADDING-BOTTOM: 3px; 
 PADDING-TOP: 3px; 
 BORDER-RIGHT-WIDTH: 0px;
} 

.focusInput {     
 BORDER-TOP-WIDTH: 0px; 
 PADDING-RIGHT: 3px; 
 PADDING-LEFT: 4px; 
 BORDER-LEFT-WIDTH: 0px; 
 BACKGROUND: #E1F1FF; 
 BORDER-BOTTOM-WIDTH: 0px; 
 PADDING-BOTTOM: 3px; 
 PADDING-TOP: 3px; 
 BORDER-RIGHT-WIDTH: 0px;
} 

.normalTextArea {
 BORDER-TOP-WIDTH: 0px; 
 BORDER-LEFT-WIDTH: 0px; 
 BACKGROUND: #f0f0f0; 
 BORDER-BOTTOM-WIDTH: 0px; 
 OVERFLOW: auto; 
 BORDER-RIGHT-WIDTH: 0px;
} 

.focusTextArea {     
 BORDER-TOP-WIDTH: 0px; 
 BORDER-LEFT-WIDTH: 0px; 
 BACKGROUND: #E1F1FF; 
 BORDER-BOTTOM-WIDTH: 0px; 
 OVERFLOW: auto; 
 BORDER-RIGHT-WIDTH: 0px;
} 
</style>
<script type="text/JavaScript">
function orderForm(){
    if (checkForm())
    {   
        calForm(); 
        dialog("我的标题","id:testID","543px","auto","id");
    }
}

function saveForm(){
    if (checkForm())
    {   
        calForm(); 
        dialog("我的标题","id:testID","543px","auto","id");
    }
}

function orderReject(){
    if (checkRequire1('txtRejectReason','拒绝订舱的理由'))
    {
        document.getElementById('btnReject').click();
    }
}

function calForm(){
    document.getElementById("spanstartport").innerHTML = document.getElementById("txtstartport").value;
    document.getElementById("spandestport").innerHTML = document.getElementById("txtdestport").value;
    document.getElementById("spanfee").innerHTML = document.getElementById("hyf").innerHTML;
    document.getElementById("spancarrier").innerHTML = document.getElementById("txtcarrier_name").value;
    document.getElementById("spanstart").innerHTML = document.getElementById("txtkaihangri").value;
    
var price20gp = 0;
var price40gp = 0;
var price40hq = 0;
var fprice20gp = 0;
var fprice40gp = 0;
var fprice40hq = 0;
var totalgp = "";
var totaldingcang = "";

if (document.getElementById("txt20gp").value != "" & document.getElementById("txt20gp").value != "0")
{
    price20gp = document.getElementById("txt20gp").value;
    totalgp = totalgp + price20gp + " CBM";
    totaldingcang = totaldingcang + price20gp + "*50";
}

if (document.getElementById("txt40gp").value != "" & document.getElementById("txt40gp").value != "0")
{
    price40gp = document.getElementById("txt40gp").value;
    totalgp = totalgp + " " + price40gp + "*40'";
    if (totaldingcang != "")
    {
        totaldingcang = totaldingcang + " + " + price40gp + "*50";
    }
    else
    {
        totaldingcang = totaldingcang + price40gp + "*50";
    }
    
}

if (document.getElementById("txt40hq").value != "" & document.getElementById("txt40hq").value != "0")
{
    price40hq = document.getElementById("txt40hq").value;
    totalgp = totalgp + " " + price40hq + "*40H'";
    if (totaldingcang != "")
    {
        totaldingcang = totaldingcang + " + " + price40hq + "*50";
    }
    else
    {
        totaldingcang = totaldingcang + price40hq + "*50";
    }    
    
}

var totaldingcangn = price20gp*50 + price40gp*50 + price40hq*50;

totaldingcang = totaldingcang + "=" + totaldingcangn;

document.getElementById("spangp").innerHTML = totalgp;
document.getElementById("spandingcang").innerHTML = totaldingcang;
    
}

function calForm2(){
    document.getElementById("span1").innerHTML = document.getElementById("txtstartport").value;
    document.getElementById("span2").innerHTML = document.getElementById("txtdestport").value;
    document.getElementById("span4").innerHTML = document.getElementById("hyf").innerHTML;
    document.getElementById("span5").innerHTML = document.getElementById("txtcarrier_name").value;
    document.getElementById("span6").innerHTML = document.getElementById("txtkaihangri").value;
    
var price20gp = 0;
var price40gp = 0;
var price40hq = 0;
var fprice20gp = 0;
var fprice40gp = 0;
var fprice40hq = 0;
var totalgp = "";
var totaldingcang = "";

if (document.getElementById("txt20gp").value != "" & document.getElementById("txt20gp").value != "0")
{
    price20gp = document.getElementById("txt20gp").value;
    totalgp = totalgp + price20gp + " CBM";
    totaldingcang = totaldingcang + price20gp + "*100";
}

if (document.getElementById("txt40gp").value != "" & document.getElementById("txt40gp").value != "0")
{
    price40gp = document.getElementById("txt40gp").value;
    totalgp = totalgp + " " + price40gp + "*40'";
    if (totaldingcang != "")
    {
        totaldingcang = totaldingcang + " + " + price40gp + "*100";
    }
    else
    {
        totaldingcang = totaldingcang + price40gp + "*100";
    }
    
}

if (document.getElementById("txt40hq").value != "" & document.getElementById("txt40hq").value != "0")
{
    price40hq = document.getElementById("txt40hq").value;
    totalgp = totalgp + " " + price40hq + "*40H'";
    if (totaldingcang != "")
    {
        totaldingcang = totaldingcang + " + " + price40hq + "*100";
    }
    else
    {
        totaldingcang = totaldingcang + price40hq + "*100";
    }    
    
}

var totaldingcangn = price20gp*100 + price40gp*100 + price40hq*100;

totaldingcang = totaldingcang + "=" + totaldingcangn;

document.getElementById("span3").innerHTML = totalgp;
document.getElementById("span7").innerHTML = totaldingcang;
}



function calForm3(){
    document.getElementById("span8").innerHTML = document.getElementById("txtstartport").value;
    document.getElementById("span9").innerHTML = document.getElementById("txtdestport").value;
    document.getElementById("span11").innerHTML = document.getElementById("hyf").innerHTML;
    document.getElementById("span12").innerHTML = document.getElementById("txtcarrier_name").value;
    document.getElementById("span13").innerHTML = document.getElementById("txtkaihangri").value;
    
var price20gp = 0;
var price40gp = 0;
var price40hq = 0;
var fprice20gp = 0;
var fprice40gp = 0;
var fprice40hq = 0;
var totalgp = "";
var totaldingcang = "";

if (document.getElementById("txt20gp").value != "" & document.getElementById("txt20gp").value != "0")
{
    price20gp = document.getElementById("txt20gp").value;
    totalgp = totalgp + price20gp + " CBM";
    totaldingcang = totaldingcang + price20gp + "*100";
}


if (document.getElementById("txt40gp").value != "" & document.getElementById("txt40gp").value != "0")
{
    price40gp = document.getElementById("txt40gp").value;
    totalgp = totalgp + " " + price40gp + "*40'";
    if (totaldingcang != "")
    {
        totaldingcang = totaldingcang + " + " + price40gp + "*100";
    }
    else
    {
        totaldingcang = totaldingcang + price40gp + "*100";
    }
    
}

if (document.getElementById("txt40hq").value != "" & document.getElementById("txt40hq").value != "0")
{
    price40hq = document.getElementById("txt40hq").value;
    totalgp = totalgp + " " + price40hq + "*40H'";
    if (totaldingcang != "")
    {
        totaldingcang = totaldingcang + " + " + price40hq + "*100";
    }
    else
    {
        totaldingcang = totaldingcang + price40hq + "*100";
    }    
    
}

var totaldingcangn = price20gp*100 + price40gp*100 + price40hq*100;

totaldingcang = totaldingcang + "=" + totaldingcangn;

document.getElementById("span10").innerHTML = totalgp;
    
}

function checkForm(){
    if (!checkRequire('txtShipper','发货人'))
    {
    return;
    }

    if (!checkRequire('txtConsignee','收货人'))
    {
    return;
    }

    if (!checkRequire('txtNotifyParty','通知人'))
    {
    return;
    }
    
    if (!checkRequire('txtCompanyName','公司名称'))
    {
    return;
    }
    
    if (!checkRequire('txtEmail','邮箱'))
    {
    return;
    }
    
    if (!checkRequire('txtMobile','手机'))
    {
    return;
    }    
    
    if (!checkRequire('txtTel','电话'))
    {
    return;
    }   

    if (!checkRequire('txtFax','传真'))
    {
    return;
    }    
    
    if (!checkRequire('txtDescription','品名'))
    {
    return;
    }    
    
    if (!checkRequire('txtGrossWeight','毛重'))
    {
    return;
    }    
    
    if (!checkRequire('txtMeasurement','体积'))
    {
    return;
    }      
    
    if (!checkRequire('txtkaihangri','开航日'))
    {
    return;
    }                    
           
    //document.getElementById("btnSubmit").click();
    
    return true;
}


function checkRequire(i,n){
if (document.getElementById(i).value == "")
{
alert("请填写"+n+"！");
document.getElementById(i).focus();
return false;
}
else
{
return true;
}
}

function checkRequire1(i,n){
if (document.getElementById(i).value == "")
{
alert("请填写"+n+"！");
return false;
}
else
{
return true;
}
}


function checkRequire3(i1,i2,i3,n){
    if (document.getElementById(i1).value == "" & document.getElementById(i2).value == "" & document.getElementById(i3).value == "")
    {
        alert("请至少填写一种"+n+"！");
        document.getElementById(i1).focus();
        return false;
    }
    else
    {
        if (document.getElementById(i1).value == "0" & document.getElementById(i2).value == "0" & document.getElementById(i3).value == "0")
        {
            alert("请至少填写一种"+n+"！");
            document.getElementById(i1).focus();
            return false;
        }
        else
        {
            return true;
        }
        return true;
    }
}

function isNumber(oNum)
{
if(!oNum) return false;
var strP=/^\d+(\.\d+)?$/;
if(!strP.test(oNum)) return false;
try{
if(parseFloat(oNum)!=oNum) return false;
}
catch(ex)
{
return false;
}
return true;
}


function esckeydown()
{
if(event.keyCode==27){
   event.returnValue = null;
   window.returnValue = null;
   document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';
}
}
document.onkeydown=esckeydown;


function focusInput(focusClass, normalClass) 
{
//
    var elements = document.getElementsByTagName("input");
    var elements1 = document.getElementsByTagName("textarea");
    for (var i=0; i < elements.length; i++) 
    { 
        if (elements[i].type != "button" && elements[i].type != "submit" && elements[i].type != "reset") 
        {             
            elements[i].onfocus = function() { this.className = focusClass; };
            elements[i].onblur = function() { this.className = normalClass; };
        }    
    } 
    
    for (var i=0; i < elements1.length; i++) 
    {           
        elements1[i].onfocus = function() { this.className = focusClass; };
        elements1[i].onblur = function() { this.className = normalClass; };  
    }     
} 

function focusTextArea(focusClass, normalClass) 
{
//
    var elements = document.getElementsByTagName("textarea");
    for (var i=0; i < elements.length; i++) 
    {   
        elements[i].onfocus = function() { this.className = focusClass; };
        elements[i].onblur = function() { this.className = normalClass; };
    } 
     
} 


window.onload = function () {
     focusInput('focusInput', 'normalInput');
     focusTextArea('focusTextArea', 'normalTextArea');
} 

function caljfzl(){
    var gw = document.getElementById("txtGrossWeight").value;
    var m = document.getElementById("txtMeasurement").value;
    
    var jfzl = 0;
    
    if (document.getElementById("txtGrossWeight").value != "" & document.getElementById("txtMeasurement").value != "")
    {
        if (gw*1 >= m*167)
        {
            jfzl = gw;
        }
        else
        {
            jfzl = m*167;
        }
        document.getElementById("txt20gp").value = jfzl;
    }
}

function calhyf(){
var price20gp = 0;
var price40gp = 0;
var price40hq = 0;
var fprice20gp = 0;
var fprice40gp = 0;
var fprice40hq = 0;

if (document.getElementById("txt20gp").value != "")
{
    price20gp = document.getElementById("txt20gp").value;
}

if (document.getElementById("txt40gp").value != "")
{
    price40gp = document.getElementById("txt40gp").value;
}

if (document.getElementById("txt40hq").value != "")
{
    price40hq = document.getElementById("txt40hq").value;
}

if (document.getElementById("f20gp").innerHTML != "")
{
    fprice20gp = document.getElementById("f20gp").innerHTML;
}

if (document.getElementById("f40gp").innerHTML != "")
{
    fprice40gp = document.getElementById("f40gp").innerHTML;
}

if (document.getElementById("f40hq").innerHTML != "")
{
    fprice40hq = document.getElementById("f40hq").innerHTML;
}

document.getElementById("hyf").innerHTML = price20gp * fprice20gp + price40gp * fprice40gp + price40hq * fprice40hq;

}
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
</script>
</head>

<body>

<form id="form1" runat="server">
<div style="display:none;">
<asp:TextBox ID="txtPubf" runat="server"></asp:TextBox>
<asp:Button ID="btnFinishOrderShipper1" runat="server" Text="货主完成订单1" OnClick="btnFinishOrderShipper1_Click" />
<asp:Button ID="btnFinishOrderForward1" runat="server" Text="货代完成订单1" OnClick="btnFinishOrderForward1_Click" />
<asp:Button ID="btnFinishOrderForward2" runat="server" Text="货代完成订单2" OnClick="btnFinishOrderForward2_Click" />
</div>
<div class="main_container">
<div class="top_bar"><!--顶部登陆开始-->
	<div class="top_bar_hd">
		<h2><a href="/"><img src="/images/fcl/home.gif" border="0" alt="环球运费网" /><strong>环球运费网</strong></a></h2>
		<ul>
		<li>&nbsp;<a href="/help/help_about.html" target="_blank"><span class="orange bold">帮助</span></a>&nbsp;</li>
		<li>&nbsp;<a href="/member/" target="_blank">进入办公室</a>&nbsp;|</li>
		<li>&nbsp;<a href="/accounts/reg.aspx">免费注册</a>&nbsp;|</li>
		<li><a href="/accounts/login.aspx">登陆</a>&nbsp;|</li>
		<li><div style="line-height:21px;"><iframe src="/member/pm_shortcut.aspx" width="80px" height="16px" frameborder="0" scrolling="no"></iframe>&nbsp;|&nbsp;</div></li>					
		</ul>
	</div>
</div>
<div class="menu2"><!--导航开始-->
	  <h1><strong class="blue2">欢迎您，<asp:Literal ID="ltrLoginName" runat="server"></asp:Literal>！</strong>&nbsp;您现在的位置:<a href="#" target="_blank">首页</a> > 订舱</h1>
	  <span class="right_tn">&nbsp;<a style="color:#1E5995;" title="欢迎使用在线客服" href="#" onclick="document.getElementById('aliserv').click();">在线客服</a></span>	</div>
<asp:Literal ID="ltrOrderStatus" runat="server"></asp:Literal>
 <div class="main_content">
 <div id="table_b">
 <table width="100%" align="center" class="order_table_a" border="0" cellspacing="0" cellpadding="0">
  <tbody>
   <tr>
    <th width="46%" align="left" rowspan="9"><strong>　发货人（Shipper）</strong><span class="red">*</span><br/>
    <textarea id="txtShipper" class="normalTextArea" style="WIDTH: 99%" rows="7" cols="60" runat="server"></textarea>
    <div class="hr"/><strong>　收货人（Consignee）</strong><span class="red">*</span> <textarea class="normalTextArea" id="txtConsignee" style="WIDTH: 99%" rows="7" cols="60" runat="server"></textarea>
    <div class="hr"/><strong>　通知人（Notify Party）</strong><span class="red">*</span> <textarea class="normalTextArea" id="txtNotifyParty" style="WIDTH: 99%" rows="7" cols="60" runat="server"></textarea> </th>
    <th height="24" colspan="4"><strong>　订单编号：</strong> <input style="PADDING-BOTTOM: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; BACKGROUND: none transparent scroll repeat 0% 0%; PADDING-TOP: 0px" class="normalInput" readonly="readonly" value="" id="txtCode" runat="server"/> </th>
   </tr>
   <tr>
    <th height="110" align="center" colspan="4"><center><b><font color="red" style="LINE-HEIGHT: 28px; FONT-SIZE: 26px">订舱委托书</font></b> </center></th>
   </tr>
   <tr>
    <th align="left" style="height: 24px"><strong>　公司名称：</strong><span class="red">*</span></th>
    <th align="left" colspan="3" style="height: 24px"><input size="50" class="normalInput" id="txtCompanyName" runat="server"/></th>
   </tr>
   <tr>
    <th height="24" align="left"><strong>　邮箱：</strong><span class="red">*</span></th>
    <th height="24" align="left" colspan="3"><input size="50" class="normalInput" id="txtEmail" runat="server"/></th>
   </tr>
   <tr>
    <th width="10%" height="24" align="left"><strong>　联系人：</strong></th>
    <th width="17%" height="24"><input  size="20" class="normalInput" id="txtContactor" runat="server"/></th>
    <th width="10%" align="left"><strong>　手机：</strong><span class="red">*</span></th>
    <th width="17%"><input size="20" class="normalInput" id="txtMobile" runat="server"/></th>
   </tr>
   <tr>
    <th height="24" align="left"><strong>　电话：</strong><span class="red">*</span></th>
    <th height="24"><input size="20" class="normalInput" id="txtTel" runat="server"/>
</th>
    <th align="left"><strong>　传真：</strong><span class="red">*</span></th>
    <th><input size="20" class="normalInput" id="txtFax" runat="server"/></th>
   </tr>
   <tr>
    <th height="24" align="left" colspan="2"><strong>　起运港（PORT OF LOADING）：</strong> </th>
    <th align="left" colspan="2"><input size="25" class="normalInput" id="txtstartport" runat="server"/></th>
   </tr>
   <tr>
    <th height="12" align="left" colspan="2"><strong>　中转港（PORT OF DISCHARGE）：</strong></th>
    <th align="left" colspan="2"><input size="25" class="normalInput" id="txtmidport" runat="server"/></th>
   </tr>
   <tr>
    <th height="12" align="left" colspan="2"><strong>　目的港（PORT OF DELIVERY）：</strong></th>
    <th align="left" colspan="2"><input size="25" class="normalInput" id="txtdestport" runat="server"/></th>
   </tr>
  </tbody>
 </table>
 <table width="100%" class="order_table_a" style="BORDER-TOP-WIDTH: 0px" border="0" cellspacing="0" cellpadding="0">
  <tbody>
   <tr>
    <th width="17%" align="center"><center><strong>唛　头<br/>
    Marks &amp; Numbers </strong>
    <div class="hr"/><textarea rows="15" cols="16" class="normalTextArea" id="txtMarksNumbers" runat="server"></textarea> </center></th><th width="17%" align="center"><center><strong>件　数<br/>
    Numbers of Packages </strong>
    <div class="hr"/><textarea rows="15" cols="16" class="normalTextArea" id="txtNumbersofPackages" runat="server"></textarea> </center></th><th width="42%" align="center"><center><span class="red">*</span><strong> 品　名<br/>
    Description of Goods &amp; Packages</strong><br/>
    <div class="hr"/><textarea rows="15" style="width:99%;" class="normalTextArea" id="txtDescription" runat="server"></textarea> </center></th><th width="12%" align="center"><center><span class="red">*</span><strong> 毛　重<br/>
    Gross Weight</strong><br/>
    <div class="hr"/><textarea rows="15" cols="16" class="normalTextArea" id="txtGrossWeight" runat="server" onchange="caljfzl();" onkeyup="caljfzl()" style="ime-mode:Disabled" onkeypress="return event.keyCode>=48&&event.keyCode<=57" onpaste="return !clipboardData.getData('text').match(/\D/)"></textarea></center></th><th width="12%" align="center"><center><font color="red">*</font><strong> 体　积<br/>
    Measurement</strong><br/>
    <div class="hr"/><textarea rows="15" cols="16" class="normalTextArea" id="txtMeasurement" runat="server" onchange="caljfzl();" onkeyup="caljfzl()" style="ime-mode:Disabled" onkeypress="return event.keyCode>=48&&event.keyCode<=57" onpaste="return !clipboardData.getData('text').match(/\D/)"></textarea></center></th>
   </tr>
  </tbody>
 </table>
 <table width="100%" class="order_table_a" style="BORDER-TOP-WIDTH: 0px" border="0" cellspacing="0" cellpadding="0">
  <tbody>
   <tr>
    <th width="11%" height="32"><strong>　运费条款：</strong></th><th align="left" colspan="3"><input name="prepaid" type="radio" checked="checked" value="1"/> 预付（Freight Prepaid) <span style="DISPLAY: none"><strong>网络服务费： </strong><input name="feeservice" type="radio" checked="checked" value="1"/> 买家承担</span></th><th align="center" colspan="2">　<strong>运费详情</strong></th>
   </tr>
   <tr>
    <th height="32"><font color="red">*</font><strong> 开航日：</strong> </th>
    <th width="21%" align="left"><input id="txtkaihangri" class="normalInput" size="5" runat="server" readonly="readonly"/> <img width="28" height="22" align="middle" style="CURSOR: pointer" src="/images/fcl/calendar.gif" alt="" id="imgkaihangri"/><span class="note"> <asp:Literal ID="ltrEndDate" runat="server"></asp:Literal>结束</span></th>
    <th width="10%" align="center"><strong>航空公司：</strong></th>
    <th width="19%" align="left"><input size="14" class="normalInput" id="txtcarrier_name" runat="server"/></th>
    <th width="9%"><strong>　关联信息：</strong></th>
    <th width="30%" align="left">&nbsp;<asp:Literal ID="ltrFreight" runat="server"></asp:Literal></th>
   </tr>
   <tr>
    <th style="HEIGHT: 36px"><strong>　预计装箱日：</strong> </th>
    <th align="left" style="HEIGHT: 36px"><input size="14" class="normalInput" id="txtzhuangxiangri" runat="server" readonly="readonly"/> <img width="28" height="22" align="middle" style="CURSOR: pointer" src="/images/fcl/calendar.gif" alt="" id="imgzhuangxiangri"/></th>
    <th align="center" style="HEIGHT: 36px"><strong>运价详情：</strong><input size="14" class="normalInput" id="txtjieguanri" runat="server" readonly="readonly" style="display:none;"/> <img width="28" height="22" align="middle" style="CURSOR: pointer; display:none;" src="/images/fcl/calendar.gif" alt="" id="imgjieguanri"/></th>
    <th align="left" style="HEIGHT: 36px" colspan="3">&nbsp;<asp:Literal ID="ltrFreightDetail" runat="server"></asp:Literal>  </th>
   </tr>
<script src="/js/WebResource.js" type="text/javascript" language="javascript"></script>
<script src="/js/coolite.js" type="text/javascript" language="javascript"></script>
<script src="/js/basicdatepicker.js" type="text/javascript" language="javascript"></script>
<script type="text/javascript" language="javascript">
//<![CDATA[
var BasicDatePicker1 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker1",dateFormat:"yyyy-M-d",selectableWeekendDays:true,minimumDate:"1999/1/1",nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"images/arrow_up.gif",southImage:"images/arrow_down.gif",eastImage:"images/arrow_right.gif",westImage:"images/arrow_left.gif"}).applyTo({inputID:"txtkaihangri",buttonID:"imgkaihangri"}) : alert("日期控件出现问题，请刷新该页面");
var BasicDatePicker2 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker2",dateFormat:"yyyy-M-d",selectableWeekendDays:true,minimumDate:"1999/1/1",nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"images/arrow_up.gif",southImage:"images/arrow_down.gif",eastImage:"images/arrow_right.gif",westImage:"images/arrow_left.gif"}).applyTo({inputID:"txtzhuangxiangri",buttonID:"imgzhuangxiangri"}) : alert("日期控件出现问题，请刷新该页面");
var BasicDatePicker3 = (Coolite.DatePicker) ? new Coolite.DatePicker({clientID:"BasicDatePicker3",dateFormat:"yyyy-M-d",selectableWeekendDays:true,minimumDate:"1999/1/1",nullDateText:"",showWeekNumbers:true,showDaysInNextMonth:false,showDaysInPrevMonth:false,northImage:"images/arrow_up.gif",southImage:"images/arrow_down.gif",eastImage:"images/arrow_right.gif",westImage:"images/arrow_left.gif"}).applyTo({inputID:"txtjieguanri",buttonID:"imgjieguanri"}) : alert("日期控件出现问题，请刷新该页面");
//]]>
</script>   
   <tr>
    <th style="height: 48px"><font color="red"></font><strong> 计费重量：</strong></th>
    <th align="left" colspan="6" style="height: 48px">
    <input id="txt20gp" value="0" class="normalInput" size="12" runat="server" style="ime-mode:Disabled" onkeypress="return event.keyCode>=48&&event.keyCode<=57" onpaste="return !clipboardData.getData('text').match(/\D/)"/> KGS
    <input id="txt40gp" value="0" class="normalInput" size="12" runat="server" style="ime-mode:Disabled;display:none;" onkeypress="return event.keyCode>=48&&event.keyCode<=57" onpaste="return !clipboardData.getData('text').match(/\D/)"/> 
    <input id="txt40hq" value="0" class="normalInput" size="12" runat="server" style="ime-mode:Disabled;display:none;" onkeypress="return event.keyCode>=48&&event.keyCode<=57" onpaste="return !clipboardData.getData('text').match(/\D/)"/>
    <span id="hyf" style="font-size:16px; color:#FF0000; font-weight:bold; display:none;"><asp:Literal ID="ltrHyf" runat="server">0</asp:Literal></span>
    </th>
   </tr>
   <tr>
    <th height="32" align="left" colspan="6">
    <h4><strong>　备注及其他要求：　</strong></h4>
    <strong/><textarea class="normalTextArea" style="WIDTH: 99%" rows="7" cols="129" id="txtbeizhu" runat="server"></textarea></th>
   </tr>
   <tr>
    <th align="left" valign="middle" colspan="6">
    <h5>　<strong>订舱注意事项</strong>： </h5>
    <br/>
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
    </th>
   </tr>
   <tr>
    <th height="80" align="center" valign="middle" colspan="6">

    <asp:PlaceHolder ID="PlaceHolder5" runat="server">
    <input type="button" value="保存"  id="Button12" onclick="saveForm();"/>
    <div style="display:none;">
    <asp:Button ID="btnEdit" runat="server"  Text="Submit" OnClick="btnEdit_Click" />
    </div></asp:PlaceHolder>

    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
     <input type="button" value="确认无误，订舱"  id="Button5" onclick="orderForm();"/>
      <input type="button" value="保存"  id="Button6" onclick="saveForm();"/>
    <div style="display:none;">
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
    <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" /></div></asp:PlaceHolder>
    
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <div>        
    <input type="button" value="接受该订舱"  id="btnAcceptTemp1" onclick="calForm2();"/>&nbsp;
    <input type="button" value="不接受该订舱"  id="btnRejectTemp1" onclick="calForm3()"/>&nbsp;
    <input type="button" value="发短消息询问其他信息"  id="btnSMS1" onclick="document.getElementById('linkSMS').click();"/>
    <div style="display:none;"><asp:Literal ID="ltrSMS" runat="server"></asp:Literal>
        <asp:Button ID="btnAccept" runat="server" Text="Accept" OnClick="btnAccept_Click" />
    <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" /></div>
    </div></asp:PlaceHolder>

    </th>
   </tr>
  </tbody>
 </table>
 </div>
 </div>
 <userbottomline:userbottomline id="userbottomline1" runat="server"/>
 <userbottom:userbottom ID="userbottom1" runat="server" />
 </div>
 
 
<div id="testID" style="display:none;">
<div class="tc">
<div class="tc_main">
<h1>亲爱的用户,您的订舱信息：<br />
<strong>
起运港-目的港：<span id="spanstartport"></span>-<span id="spandestport"></span><br/>
计费重量：<span id="spangp"></span><span id="spanfee" style="display:none;"></span><br/>
航空公司：<span id="spancarrier"></span><br/>
开航日：<span id="spanstart"></span></strong>&nbsp;&nbsp;<br />
<strong>订舱信息费：<span id="spandingcang"></span></strong>
</h1>
<p><span class="red">环球运费网将在您的货物出运后为您支付信息费,请在此填写您的接收账户信息：</span><br />
<div style="display:none;"><input type="radio" name="radPay" value="radiobutton" id="radBank" checked="checked" onclick="javascript:document.getElementById('divbank').style.display = '';document.getElementById('txtother').style.display = 'none';"/>
<label for="radBank">银行汇款</label>
<input type="radio" name="radPay" value="radiobutton" id="radOther" onclick="javascript:document.getElementById('divbank').style.display = 'none';document.getElementById('txtother').style.display = '';"/>
<label for="radOther">其他方式</label></div>
<div style="padding:10px 0px;"><strong>银行汇款:</strong></div>
<div style="line-height:35px; border:1px solid #999999; padding:0px 0px 0px 10px;width:470px;height:120px;" id="divbank">
<table>
<tr>
<td>开户行：</td>
<td><input type="text" size="50" id="txtbank" runat="server" onchange="javascript:document.getElementById('txtbank').value = this.value;" onblur="javascript:document.getElementById('txtbank').value = this.value;"/></td>
</tr>
<tr>
<td>户名：</td>
<td><input type="text" id="txtbankname" runat="server" onchange="javascript:document.getElementById('txtbankname').value = this.value;" onblur="javascript:document.getElementById('txtbank').value = this.value;"/></td>
</tr>
<tr>
<td>账号：</td>
<td><input type="text" size="50" id="txtbankaccount" runat="server" onchange="javascript:document.getElementById('txtbankaccount').value = this.value;" onblur="javascript:document.getElementById('txtbank').value = this.value;"/></td>
</tr>
</table>
</div>
<div style="padding:10px 0px;"><strong>其他方式:</strong></div>
<textarea class="ms_text" style="width:480px;height:120px;" id="txtotheraccount" runat="server" onchange="javascript:document.getElementById('txtotheraccount').value = this.value;" onblur="javascript:document.getElementById('txtbank').value = this.value;"></textarea>
<br /><br />
<asp:PlaceHolder ID="PlaceHolder7" runat="server">
<input type="button" value="确认提交"  id="Button7" onclick="document.getElementById('btnSubmit').click();"/>
<input type="button" value="保存订单"  id="Button8" onclick="document.getElementById('btnSave').click();"/>
<input type="button" value="取消"  id="Button9" onclick="javascript:document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';"/>
</asp:PlaceHolder>

<asp:PlaceHolder ID="PlaceHolder6" runat="server">
<input type="button" value="保存订单"  id="Button10" onclick="document.getElementById('btnEdit').click();"/>
<input type="button" value="取消"  id="Button11" onclick="javascript:document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';"/>
</asp:PlaceHolder>
</p>
</div>
<div class="tc_foot"></div>
</div> 
</div>

<div id="divAccept" style="display:none;">
<div class="tc">
<div class="tc_main">
<h1>亲爱的用户,您将确认接受的订舱信息为：<br />
<strong>
起运港-目的港：<span id="span1"></span>-<span id="span2"></span><br/>
计费重量：<span id="span3"></span><span id="span4" style="display:none;"></span><br />
航空公司：<span id="span5"></span><br />
开航日：<span id="span6"></span></strong><br />
<strong>订舱信息费：<span id="span7"></span> 元</strong>
</h1>
<p>您的账户金额<span class="red">2800</span>元，暂扣本次信息费<span class="red">300</span>元之后，可用余额为：<span class="red">2500</span>元。如货物最终未能出运，暂扣金额将返还回您的帐户<br />
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
<input type="button" value="我已阅读上述信息，并接受该订舱"  id="Button1" onclick="document.getElementById('btnAccept').click();"/>
<input type="button" value="关闭"  id="Button2" onclick="javascript:document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';"/>
</div>
</p>
</div>
<div class="tc_foot"></div>
</div> 
</div>

<div id="divReject" style="display:none;">
<div class="tc">
<div class="tc_main">
<h1>亲爱的用户，您将拒绝的订舱信息为：<br />
<strong>
起运港-目的港：<span id="span8"></span>-<span id="span9"></span><br/>
计费重量：<span id="span10"></span><span id="span11" style="display:none;"></span><br/>
航空公司：<span id="span12"></span><br/>
开航日：<span id="span13"></span></strong><br/>
</h1>
<p><span class="red">客户的订舱申请将会在您的商铺中永久存档，如果有不接受订舱的记录，可能会影响到您在环球运费网的运价口碑和声誉，提醒您谨慎拒绝。如确有客观因素不能接受订舱，请您认真如实填写原因：</span><br />
<textarea class="ms_text" style="width:480px;height:120px;" id="txtRejectReason" runat="server" onchange="javascript:document.getElementById('txtRejectReason').value = this.value;" onblur="javascript:document.getElementById('txtRejectReason').value = this.value;"></textarea>
<br />
<div style="text-align:center;">
<input type="button" value="提交"  id="Button3" onclick="orderReject();"/>
<input type="button" value="关闭"  id="Button4" onclick="javascript:document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';"/>
</div>
</p>
</div>
<div class="tc_foot"></div>
</div> 
</div>
</form>

</body>
</html>
