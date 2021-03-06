﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="reg.aspx.vb" Inherits="member_reg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>环球运费网 - 免费注册会员</title>
    <link href="../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../css/list.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--
.regRequired {color: #FF6600;}
.tipNormal {color:blue; float:left;  margin-left:10px;}
.tipFalse {color:red; float:left;  margin-left:10px;}
.tipTrue {color:green; float:left;  margin-left:10px;}
-->
</style>
<script language="javascript" type="text/javascript" src="../js/function.js"></script>
<script language="javascript" type="text/javascript">

function showTip(s,h1,h2){
document.getElementById(s).style.display = "";
document.getElementById(h1).style.display = "none";
document.getElementById(h2).style.display = "none";
}

function hideTip(s,h1,h2){
document.getElementById(s).style.display = "none";
document.getElementById(h1).style.display = "none";
document.getElementById(h2).style.display = "none";
}


function showTip1(s){
document.getElementById(s).style.display = "";
}

function hideTip1(s){
document.getElementById(s).style.display = "none";
}


function isName(s) 
{ 
var patrn=/^([\u4e00-\u9fa5]|[ 0-9_a-zA-Z]){6,15}$/; 
if (!patrn.exec(document.getElementById(s).value)) {
return false
}
else {
return true
}
} 


function isDigit(s) 
{ 
var patrn=/^(\w){6,15}$/; 
if (!patrn.exec(document.getElementById(s).value)) {
return false
}
else {
return true
}
} 


function isEmail(s) 
{ 
var patrn=/(\S)+[@]{1}(\S)+[.]{1}(\w)+/; 
if (!patrn.exec(document.getElementById(s).value)) {
return false
}
else {
return true
}
} 

function isTel(s) 
{ 
var patrn=/(\(\d{3,4}\)|\d{3,4}-|\s)?\d{7,14}/; 
if (!patrn.exec(document.getElementById(s).value)) {
return false
}
else {
return true
}
} 

function isIntroduction(s)
{
    var value = document.getElementById(s).value;
    if(value.length > 200)
    {
        return false;
    }
    else
    {
        return true;
    }
}

function isSign(s)
{
    var value = document.getElementById(s).value;
    if(value.length > 50)
    {
        return false;
    }
    else
    {
        return true;
    }
}

function isPicture(s)
{
    
    var value = document.getElementById(s).value;
    var word = value.substring(value.length-3,value.length);
    if(word == "jpg" || word=="gif")
    {
        return true;
    }
    else
    {
        return false;
    }
    
    
}

function checkIntroduction(s,n,t,f,type)
{
    if(document.getElementById(s).value=="")
    {
        hideTip(f,n,t);
    }
    else
    {
        if(isIntroduction(s)==true)
        {
            showTip(t,n,f);
        }
        else
        {
            showTip(f,n,t);
        }
    }
}

function checkSign(s,n,t,f,type)
{
    if(document.getElementById(s).value=="")
    {
        hideTip(f,n,t);
    }
    else
    {
        if(isSign(s)==true)
        {
            showTip(t,n,f);
        }
        else
        {
            showTip(f,n,t);
        }
    }
}

function checkPicture(s,n,t,f,type)
{
    if(document.getElementById(s).value=="")
    {
        hideTip(f,n,t);
    }
    else
    {
        if(isPicture(s)==true)
        {
            showTip(t,n,f);
        }
        else
        {
            showTip(f,n,t);
        }
    }
}

//检查用户名
//s是输入框,i是提示区域，t是正确的提示内容,f是错误的提示内容
function checkName(s,n,t,f,type){
    document.getElementById(f).innerHTML = "该用户名已被使用，请重新输入。"
if (type==1){
	if (document.getElementById(s).value != "") {
	    CallServer1();
	}
	else {
		hideTip(f,n,t);
	}	
}
else{
    if (document.getElementById(s).value == "") {
        document.getElementById(f).innerHTML = "用户名必须要填写。"
	    showTip(f,n,t);
	}
}
}

//检查密码框
//s是输入框,i是提示区域，t是正确的提示内容,f是错误的提示内容
function checkPassword(s,n,t,f,type){
if (isDigit(s)==1){
	showTip(t,n,f);
}
else {
	if (type==1){
		if (document.getElementById(s).value != "") {
			showTip(f,n,t);
		}
		else {
			hideTip(f,n,t);
		}	
	}
	else{
		showTip(f,n,t);
	}
}
}

//检查密码确认框
//s是输入框,i是提示区域，t是正确的提示内容,f是错误的提示内容
function checkPassword2(p1,p2,n,t,f,type){
if (document.getElementById(p1).value != document.getElementById(p2).value){
	if (type==1){
		if (document.getElementById(p2).value != "") {
			showTip(f,n,t);
		}
		else {
			hideTip(f,n,t);
		}
	}
	else {
		showTip(f,n,t);
	}

}
else{
	if (document.getElementById(p2).value != "") {
		showTip(t,n,f);
	}
	else {
		hideTip(f,n,t);
	}	
}
}

//检查必填项目
function checkRequired(s,n,t,f,type){
if (type==0){
	if (document.getElementById(s).value == "" ){
		showTip(f,n,t);
	}
	else {
		showTip(t,n,f);
	}
}
else{
	if (document.getElementById(s).value != "" ){
		showTip(t,n,f);
	}
	else {
		hideTip(f,n,t);
	}
}
}

//检查公司类型
//s是输入框,i是提示区域，t是正确的提示内容,f是错误的提示内容
function checkCompanyType(s,n,t,f,type){
if (type==0){
	if (document.getElementById(s).value == "0" ){
		showTip(f,n,t);
	}
	else {
		showTip(t,n,f);
	}
}
else{
	if (document.getElementById(s).value != "0" ){
		showTip(t,n,f);
	}
	else {
		hideTip(f,n,t);
	}
}
}


//检查性别
function checkGender(s,t,f){
if (type==0){
	if (document.getElementById(s).value == "" ){
		showTip(f,n,t);
	}
	else {
		showTip(t,n,f);
	}
}
else{
	if (document.getElementById(s).value != "" ){
		showTip(t,n,f);
	}
	else {
		hideTip(f,n,t);
	}
}
}


function checkRadio(s,n,t,f)
{ 
var selected = 0
var objRadio = document.getElementsByName(s); 
for(var  i=0;i<objRadio.length;i++) { 
	if (objRadio(i).checked){
		selected = 1;
	}
}   
if (selected ==1){
	showTip(t,n,f);
}
else {
	showTip(f,n,t);
}
}  

//检查Email
//s是输入框,i是提示区域，t是正确的提示内容,f是错误的提示内容
function checkEmail(s,n,t,f,type){
if (isEmail(s)==1){
	showTip(t,n,f);
}
else {
	if (type==1){
		if (document.getElementById(s).value != "") {
			showTip(f,n,t);
		}
		else {
			hideTip(f,n,t);
		}	
	}
	else{
		showTip(f,n,t);
	}
}
}

//检查电话
//s是输入框,i是提示区域，t是正确的提示内容,f是错误的提示内容
function checkTel(s,n,t,f,type){
if (isTel(s)==1){
	showTip(t,n,f);
}
else {
	if (type==1){
		if (document.getElementById(s).value != "") {
			showTip(f,n,t);
		}
		else {
			hideTip(f,n,t);
		}	
	}
	else{
		showTip(f,n,t);
	}
}
}

//检查验证码
//s是输入框,i是提示区域，t是正确的提示内容,f是错误的提示内容
function checkVerifyCode(s,n,t,f,type){
    document.getElementById(f).innerHTML = "验证码错误，请重新输入。"
if (type==1){
	if (document.getElementById(s).value != "") {
		CallServer2()
	}
	else {
		hideTip(f,n,t);
	}	
}
else{
    if (document.getElementById(s).value == "") {
        document.getElementById(f).innerHTML = "验证码必须要填写。"
	    showTip(f,n,t);
	}
}
}


function checkAll(){
//验证必填信息格式
checkName('UserName','tipUserNameNormal','tipUserNameTrue','tipUserNameFalse',0);
checkPassword('UserPassword','tipUserPasswordNormal','tipUserPasswordTrue','tipUserPasswordFalse',0);
checkPassword2('UserPassword','UserPassword2','tipUserPassword2Normal','tipUserPassword2True','tipUserPassword2False',0);
checkRequired('RealName','tipRealNameNormal','tipRealNameTrue','tipRealNameFalse',0);
checkRequired('CompanyName','tipCompanyNameNormal','tipCompanyNameTrue','tipCompanyNameFalse',0);
checkCompanyType('CompanyType','tipCompanyType','tipCompanyTypeTrue','tipCompanyTypeFalse',0)
checkEmail('UserEmail','tipUserEmailNormal','tipUserEmailTrue','tipUserEmailFalse',0);
checkRequired('Phone','tipPhoneNormal','tipPhoneTrue','tipPhoneFalse',0);
checkRequired('Fax','tipFaxNormal','tipFaxTrue','tipFaxFalse',0);
checkRequired('MovePhone','tipMovePhone','tipMovePhoneTrue','tipMovePhoneFalse',0);
checkVerifyCode('VerifyCode','tipVerifyCodeNormal','tipVerifyCodeTrue','tipVerifyCodeFalse',0);
checkPicture('FileUpload1','tipheadNormal','tipheadTrue','tipheadFalse',1);
checkSign('txtsign','tipsignNormal','tipsignTrue','tipsignFalse',1);
checkIntroduction('txtintroduction','tipintroductionNormal','tipintroductionTrue','tipintroductionFalse',1)

//除用户名及验证码以外的信息，如果填写正确，进入下一步验证用户名及验证码
if (document.getElementById("tipUserPasswordTrue").style.display == "" & 
document.getElementById("tipUserPassword2True").style.display == "" & 
document.getElementById("tipRealNameTrue").style.display == "" & 
document.getElementById("tipCompanyNameTrue").style.display == "" & 
document.getElementById("tipCompanyTypeTrue").style.display == "" & 
document.getElementById("tipUserEmailTrue").style.display == "" & 
document.getElementById("tipPhoneTrue").style.display == "" &
document.getElementById("tipFaxTrue").style.display == "" &
document.getElementById("tipMovePhoneTrue").style.display == "" &
document.getElementById("tipheadFalse").style.display == "none" &
document.getElementById("tipsignFalse").style.display == "none" &
document.getElementById("tipintroductionFalse").style.display == "none"){

    lastCheckName();
}
}

function CallServer1()
{   
    context = ""
    showTip('tipUserNameNormal','tipUserNameTrue','tipUserNameFalse')
    //context.innerHTML = "<table style='width:700px;height:220px;text-align:center'><tr><td>正在更新订单数据...</td></tr></table>";
    arg = "username" + "|" + document.getElementById("UserName").value;
    <%= ClientScript.GetCallbackEventReference(me, "arg", "ReceiveServerData1", "context")%>;
}

//接受callback从服务器传来的数据
function ReceiveServerData1(result, context)
{
    if (result == "success"){
        showTip('tipUserNameTrue','tipUserNameNormal','tipUserNameFalse')
    }
    else {
        showTip('tipUserNameFalse','tipUserNameNormal','tipUserNameTrue')
    }
}

function CallServer2()
{   
    context = ""
    showTip('tipVerifyCodeNormal','tipVerifyCodeTrue','tipVerifyCodeFalse')
    //context.innerHTML = "<table style='width:700px;height:220px;text-align:center'><tr><td>正在更新订单数据...</td></tr></table>";
    arg = "verifycode" + "|" + GetCookie('CheckCode') + "|" +document.getElementById("VerifyCode").value;
    <%= ClientScript.GetCallbackEventReference(me, "arg", "ReceiveServerData2", "context")%>;
}

//接受callback从服务器传来的数据
function ReceiveServerData2(result, context)
{
    if (result == "success"){
        showTip('tipVerifyCodeTrue','tipVerifyCodeNormal','tipVerifyCodeFalse');
    }
    else {
        showTip('tipVerifyCodeFalse','tipVerifyCodeNormal','tipVerifyCodeTrue');
    }
}

//提交前再检查一次用户名
function lastCheckName()
{   

    context = ""
    showTip('tipUserNameNormal','tipUserNameTrue','tipUserNameFalse');
    arg = "username" + "|" + document.getElementById("UserName").value;
    <%= ClientScript.GetCallbackEventReference(me, "arg", "lastCheckNameResult", "context")%>;
}

//接受callback从服务器传来的数据
function lastCheckNameResult(result, context)
{
    if (result == "success"){
    
        showTip('tipUserNameTrue','tipUserNameNormal','tipUserNameFalse');
        setTimeout("lastVerifyCode();",1);
    }
    else {
        showTip('tipUserNameFalse','tipUserNameNormal','tipUserNameTrue');
    }
}

//提交前再检查一次用户名
function lastVerifyCode()
{   
    
    context = ""
    showTip('tipVerifyCodeNormal','tipVerifyCodeTrue','tipVerifyCodeFalse')
    arg = "verifycode" + "|" + GetCookie('CheckCode') + "|" +document.getElementById("VerifyCode").value;
    <%= ClientScript.GetCallbackEventReference(me, "arg", "lastVerifyCodeResult", "context")%>;
}

//接受callback从服务器传来的数据
function lastVerifyCodeResult(result, context)
{
    if (result == "success"){
        showTip('tipVerifyCodeTrue','tipVerifyCodeNormal','tipVerifyCodeFalse');
        document.getElementById("Button3").click();
    }
    else {
        showTip('tipVerifyCodeFalse','tipVerifyCodeNormal','tipVerifyCodeTrue');
    }
}

function GetCookieVal(offset){
    var endstr = document.cookie.indexOf (";", offset);
    if (endstr == -1)
    endstr = document.cookie.length;
    return unescape(document.cookie.substring(offset, endstr));
    }

function GetCookie(name){
var arg = name + "=";
var alen = arg.length;
var clen = document.cookie.length;
var i = 0;
while (i < clen){
    var j = i + alen;
    if (document.cookie.substring(i, j) == arg)
    return GetCookieVal (j);
    i = document.cookie.indexOf(" ", i) + 1;
    if (i == 0) break;
}
return null;
}

function randomString(u){
    var x;
    x = Math.round(Math.random()*100000);
    u.src=u.src+x
}
</script>
</head>
<body onload="AutoTips('officetips');document.getElementById('imgVerify').click();">
<form id="form1" runat="server" autocomplete="off" onKeydown="if(event.enterKey){return   false}">
<asp:ScriptManager ID="ScriptManager1" runat="server"> 
</asp:ScriptManager>
<script language="javascript" type="text/javascript">
    Sys.Application.add_load(function(){var form=Sys.WebForms.PageRequestManager.getInstance()._form;form._initialAction=form.action=window.location.href;});
</script>
    <div id="page">
		<div id="center">
			<usertop:usertop ID="Usertop1" runat="server" />
			<div id="menu">
			  <table width="990" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="10"><img src="../images/menu_1.gif" width="10" height="35" /></td>
                      <td width="970" background="../images/menu_2.gif">
						  <ul>
							<li><a href="/">首页</a></li>
							<li>|</li>
							<li><a href="../search/fcl.htm">整箱运价</a></li>
							<li>|</li>
							<li><a href="../search/lcl.htm">拼箱运价</a></li>
							<li>|</li>
							<li><a href="../search/air.htm">空运运价</a></li>
							<li>|</li>
							<li><a href="../search/cargo.htm">货盘信息</a></li>
							<li>|</li>
							<li><a href="/search/company.htm" target="_blank">公司库</a></li>
							<li>|</li>
							<li><a href="/home/space.php?do=home" target="_blank">社区</a> <span style="color:red;font-weight:bold;">[新]</span></li>
							<li>|</li>
							<li><a href="/bbs/" target="_blank">论坛</a></li></ul>
					 </td>
                      <td width="10"><img src="../images/menu_3.gif" width="10" height="35" /></td>
                    </tr>
                  </table>
			</div>
			<div id="main">
				<div id="left">
				 
                <userlogin:userlogin id="Userlogin1" runat="server" />
							
				</div>
				<div id="right">
                <div id="search">
					  <table border="0" cellspacing="0" cellpadding="0">
							<tr>
							  <td width="10" ><img src="../images/box_1.gif" width="10" height="31" /></td>
							  <td width="780" background="../images/box_2.gif" ><div class="bigBoxTitle">免费注册会员</div></td>
							  <td width="10" ><img src="../images/box_3.gif" width="10" height="31" /></td>
							</tr>
							<tr>
							      <td background="../images/box_4.gif" style="height: 15px"></td>
							      <td bgcolor="#FFFFFF">
							        <div class="searchbox" style="line-height:25px; font-size:12px;">
                                        <div style="margin-right:10px;">
                                        <div style="margin-bottom:10px; font-size:14px;">
						亲爱的用户，如果您已经是环球运费网注册会员，请在左侧登录网站<br/>
						若您还未注册环球运费网，请在下面填写资料注册成为环球运费网会员，注册过程将不收取任何费用。注：以下带<span class="regRequired">*</span>的项目为必填内容</div>
			  <fieldset style="border:1px solid #CCCCCC; padding-bottom:5px;">
              <legend style="color:#000000; font-weight:bold; font-size:14px;margin-left:5px;">您的用户名及密码 </legend>
			    <table border="0" cellpadding="4" cellspacing="0">
                <tr>
                  <td colspan="3" style="height:5px"></td>
                </tr>
                <tr>
                  <td width="80"><div align="right"><span >用&nbsp;&nbsp;户&nbsp;&nbsp;名</span></div></td>
                  <td width="15"><span class="regRequired">*</span></td>
                  <td width="610"><div style="float:left;">
				  <input name="UserName" id="UserName" type="text" maxlength="15" style="width:200px" onfocus="showTip('tipUserNameWarning','tipUserNameTrue','tipUserNameFalse')"  onblur="hideTip1('tipUserNameWarning');checkName('UserName','tipUserNameNormal','tipUserNameTrue','tipUserNameFalse',1);" runat="server"   /></div>
                  <div class="tipNormal" id="tipUserNameWarning" style="display:none;">用户名由1-15个字符组成，支持中文，注册成功后用户名将不可修改。</div><div class="tipNormal" id="tipUserNameNormal" style="display:none;">用户名检测中，请稍候...</div><div class="tipTrue" id="tipUserNameTrue"  style="display:none;">该用户名可以注册。</div><div class="tipFalse" id="tipUserNameFalse" style="display:none;">该用户名已被使用，请重新输入。</div></td>
                </tr>
                <tr>
                  <td><div align="right"><span >密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码</span></div></td>
                  <td><span class="regRequired">*</span></td>
                  <td><div style="float:left;">
                  <input name="UserPassword" id="UserPassword" type="password" maxlength="15" class="textbox1" style="width:200px" onfocus="showTip('tipUserPasswordNormal','tipUserPasswordTrue','tipUserPasswordFalse')"  onblur="checkPassword('UserPassword','tipUserPasswordNormal','tipUserPasswordTrue','tipUserPasswordFalse',1);checkPassword2('UserPassword','UserPassword2','tipUserPassword2Normal','tipUserPassword2True','tipUserPassword2False')" runat="server"  /></div>
                  <div class="tipNormal" id="tipUserPasswordNormal" style="display:none;">密码由6-15个字母或数字组成，不支持中文。</div><div class="tipTrue" id="tipUserPasswordTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipUserPasswordFalse" style="display:none;">您的填写错误。密码由6-20个字母或数字组成，不支持中文。</div></td>
                </tr>
                <tr>
                  <td><div align="right"><span >确认密码</span></div></td>
                  <td><span class="regRequired">*</span></td>
                  <td><div style="float:left;">
                      <input name="UserPassword2" id="UserPassword2" type="password" maxlength="15" class="textbox1" style="width:200px" onfocus="showTip('tipUserPassword2Normal','tipUserPassword2True','tipUserPassword2False')"  onblur="checkPassword2('UserPassword','UserPassword2','tipUserPassword2Normal','tipUserPassword2True','tipUserPassword2False',1)" runat="server" /></div>
					   <div class="tipNormal" id="tipUserPassword2Normal" style="display:none;">请再输入一遍您上面填写的密码。</div><div class="tipTrue" id="tipUserPassword2True"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipUserPassword2False" style="display:none;">两次输入的密码不一致。请再输入一遍您上面填写的密码。</div></td>
                </tr>
                <tr>
                  <td colspan="3" style="height:5px"></td>
                </tr>
              </table>
		    </fieldset>
			  <br />
              <fieldset style="border:1px solid #CCCCCC; padding-bottom:5px;">
              <legend style="color:#000000; font-weight:bold; font-size:14px;margin-left:5px;"> 您的帐户信息 </legend>
                <table border="0" cellpadding="4" cellspacing="0">
                <tr>
                  <td colspan="3" style="height:5px"></td>
                </tr>
                <tr>
                  <td width="80"><div align="right"><span >真实姓名</span></div></td>
                  <td width="15"><span class="regRequired">*</span></td>
                  <td width="650"><div style="float:left;"><input name="RealName" type="text" maxlength="100" id="RealName" style="width:250px" onfocus="showTip('tipRealNameNormal','tipRealNameTrue','tipRealNameFalse')"  onblur="checkRequired('RealName','tipRealNameNormal','tipRealNameTrue','tipRealNameFalse',1)" runat="server" /></div> <div class="tipNormal" id="tipRealNameNormal" style="display:none;"></div><div class="tipTrue" id="tipRealNameTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipRealNameFalse" style="display:none;">此项必填</div></td>
                </tr>
                <tr style="display:none;">
                  <td><div align="right"><span >性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别</span></div></td>
                  <td><span class="regRequired">*</span></td>
                  <td><div style="float:left;"><input type="radio" name="Gender" value="男" id="GenderMale"  onclick="showTip('tipGenderTrue','tipGenderNormal','tipGenderFalse')" runat="server"/>
                    先生 
                      <input type="radio" name="Gender" value="女" id="GenderFemale" onclick="showTip('tipGenderTrue','tipGenderNormal','tipGenderFalse')" runat="server" />
                      女士</div> <div class="tipNormal" id="tipGenderNormal" style="display:none;"></div><div class="tipTrue" id="tipGenderTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipGenderFalse" style="display:none;">此项必须选择</div></td>
                </tr>
                <tr>
                  <td><div align="right"><span >公司名称</span></div></td>
                  <td><span class="regRequired">*</span></td>
                  <td><div style="float:left;"><input name="CompanyName" type="text" maxlength="100" id="CompanyName" style="width:250px" onfocus="showTip('tipCompanyNameNormal','tipCompanyNameTrue','tipCompanyNameFalse')"  onblur="checkRequired('CompanyName','tipCompanyNameNormal','tipCompanyNameTrue','tipCompanyNameFalse',1)" runat="server" /></div>
                  <div class="tipNormal" id="tipCompanyNameNormal" style="display:none;">为方便其他用户联系到您，请尽量填写公司全称。</div><div class="tipTrue" id="tipCompanyNameTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipCompanyNameFalse" style="display:none;">必须填写公司名称。</div></td>
                </tr>
                <tr >
                  <td><div align="right">公司类型</div></td>
                  <td><span style="color: #ff6600">*</span></td>
                  <td><div style="float:left;"><select name="CompanyType" onfocus="showTip('tipCompanyType','tipCompanyTypeTrue','tipCompanyTypeFalse');"  onblur="checkCompanyType('CompanyType','tipCompanyType','tipCompanyTypeTrue','tipCompanyTypeFalse',1)" id="CompanyType" runat="server" style="width:100px">
					  <option value="0">请选择</option>
                      <option value="1">货主</option>
                      <option value="2">货代</option>
                      <option value="3">船公司</option>
                      <option value="4">其他</option>
                  </select></div>
                  <div class="tipNormal" id="tipCompanyType" style="display:none;">请选择您公司的类型。</div><div class="tipTrue" id="tipCompanyTypeTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipCompanyTypeFalse" style="display:none;">必须选择公司类型。</div></td>
                </tr>
                <tr>
                  <td><div align="right"><span >电话号码</span></div></td>
                  <td><span class="regRequired">*</span></td>
                  <td><div style="float:left;"><input name="Phone" type="text" maxlength="50" id="Phone" style="width:130px" onfocus="showTip('tipPhoneNormal','tipPhoneTrue','tipPhoneFalse')"  onblur="checkRequired('Phone','tipPhoneNormal','tipPhoneTrue','tipPhoneFalse',1);" runat="server" /></div>
                  <div class="tipNormal" id="tipPhoneNormal" style="display:none;">为方便其他用户联系到您，请填写正确有效的电话。环球运费网不会向您拨打任何骚扰电话。</div><div class="tipTrue" id="tipPhoneTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipPhoneFalse" style="display:none;">必须填写电话。</div> </td>
                </tr>
                <tr>
                  <td><div align="right">传真号码</div></td>
                  <td>
                      <span style="color: #ff6600">*</span></td>
                  <td><div style="float:left;"><input name="Fax" type="text" maxlength="50" id="Fax" style="width:130px" onfocus="showTip('tipFaxNormal','tipFaxTrue','tipFaxFalse')"  onblur="checkRequired('Fax','tipFaxNormal','tipFaxTrue','tipFaxFalse',1);" runat="server" /></div>
                    <div class="tipNormal" id="tipFaxNormal" style="display:none;">为方便其他用户联系到您，请填写正确有效的传真号码。</div><div class="tipTrue" id="tipFaxTrue"  style="display:none;">
                        填写正确。</div>
                      <div class="tipFalse" id="tipFaxFalse" style="display:none;">
                          必须填写电话。</div>
                  </td>
                </tr>
                <tr>
                  <td><div align="right">手机号码</div></td>
                  <td>
                      <span style="color: #ff6600">*</span>&nbsp;</td>
                  <td><div style="float:left;"><input name="MovePhone" type="text" maxlength="50" id="MovePhone" style="width:130px" onfocus="showTip('tipMovePhone','tipMovePhoneTrue','tipMovePhoneFalse')"  onblur="checkRequired('MovePhone','tipMovePhone','tipMovePhoneTrue','tipMovePhoneFalse',1);" runat="server" /></div>
                    <div class="tipNormal" id="tipMovePhone" style="display:none;">为方便其他用户联系到您，请填写有效的手机号码。</div><div class="tipTrue" id="tipMovePhoneTrue"  style="display:none;">
                        填写正确。</div>
                      <div class="tipFalse" id="tipMovePhoneFalse" style="display:none;">
                          必须填写电话。</div>
                  </td>
                </tr>
                <tr>
                  <td><div align="right">MSN</div></td>
                  <td>&nbsp;</td>
                  <td><div style="float:left;"><input name="Usermsn" type="text" maxlength="50" id="Usermsn" style="width:130px" runat="server" /></div>
                    </td>
                </tr>   
                <tr>
                  <td><div align="right">QQ</div></td>
                  <td>&nbsp;</td>
                  <td><div style="float:left;"><input name="Userqq" type="text" maxlength="50" id="Userqq" style="width:130px" runat="server" /></div>
                    </td>
                </tr>                                
                <tr>
                  <td><div align="right">联系地址</div></td>
                  <td>&nbsp;</td>
                  <td><div style="float:left;"><input name="Address" type="text" maxlength="100" id="Address" style="width:250px" onfocus="showTip1('tipAddress')"  onblur="hideTip1('tipAddress')" runat="server" /></div>
                    <div class="tipNormal" id="tipAddress" style="display:none;">为方便其他用户联系到您，请填写正确有效的联系地址。</div></td>
                </tr>
                <tr>
                  <td><div align="right">邮政编码</div></td>
                  <td>&nbsp;</td>
                  <td><div style="float:left;"><input name="PostNumber" type="text" maxlength="50" id="PostNumber" style="width:100px" onfocus="showTip1('tipPostNumber')"  onblur="hideTip1('tipPostNumber')" runat="server" /></div>
                    <div class="tipNormal" id="tipPostNumber" style="display:none;">为方便其他用户联系到您，请填写正确有效的邮政编码。</div></td>
                </tr>
                    <tr>
                        <td style="text-align: right">
                            个性签名</td>
                        <td>
                        </td>
                        <td>
                            <div style="float: left">
                                <input id="txtsign" runat="server" class="textbox1" name="txtsign" onblur="checkSign('txtsign','tipsignNormal','tipsignTrue','tipsignFalse',1)"
                                    onfocus="showTip('tipsignNormal','tipsignTrue','tipsignFalse')" style="width: 250px"
                                    type="text" /></div>
                            <div id="tipsignNormal" class="tipNormal" style="display: none">
                                可以为您论坛中，增加一个个性签名。</div>
                            <div id="tipsignTrue" class="tipTrue" style="display: none">
                                填写正确。</div>
                            <div id="tipsignFalse" class="tipFalse" style="display: none">
                                必须小于50个字符</div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            公司简介</td>
                        <td>
                        </td>
                        <td style="width: 651px">
                        <div style="float:left;">
                        <textarea name="txtintroduction"   class="textbox1" id="txtintroduction" style="width:250px; height: 80px;" onfocus="showTip('tipintroductionNormal','tipintroductionTrue','tipintroductionFalse')"  onblur="checkIntroduction('txtintroduction','tipintroductionNormal','tipintroductionTrue','tipintroductionFalse',1)" runat="server" />
                        <%--<input  />--%>
                        </div>
                            <div class="tipNormal" id="tipintroductionNormal" style="display:none;">
                                可以为您运价增加一个公司简介。</div>
                            <div class="tipTrue" id="tipintroductionTrue"  style="display:none;">
                                填写正确。</div>
                            <div class="tipFalse" id="tipintroductionFalse" style="display:none;">
                                必须小于200个字符</div>    
                            
                            
                        </td>
                    </tr>
                <tr>
                    <td style="text-align: right">
                        头像</td>
                    <td style="width: 23px">&nbsp;
                    </td>
                    <td>
                        <div>
                            <table style="float:left ;  border-width:0px; ">
                            <tr>
                                <td><asp:FileUpload ID="FileUpload1" runat="server" Width="179px" onfocus="showTip('tipheadNormal','tipheadTrue','tipheadFalse')" onblur="checkPicture('FileUpload1','tipheadNormal','tipheadTrue','tipheadFalse',1)"  /></td>
                                <td style="text-align:center;"><asp:Image ID="Imghead" runat="server" Height="70px" ImageUrl="~/member/Head/default.jpg" Width="70px" /></td>
                                <td style="text-align:center; ">
                                    <div class="tipNormal" id="tipheadNormal" style=" float:left; display:none; margin-left:0px">
                                        可以为您论坛中的头像上传一张图片(JPG或GIF格式)</div>
                                    <div class="tipTrue" id="tipheadTrue"  style="display:none;margin-left:0px">
                                            填写正确。</div>
                                    <div class="tipFalse" id="tipheadFalse" style="display:none;margin-left:0px">
                                            必须为JPG或GIF格式的图片。</div>
                                </td>
                            </tr>
                            </table>
                        </div>
                    </td>
                </tr>                
                <tr>
                  <td colspan="3" style="height:5px"></td>
                </tr>
              </table>
            </fieldset>
			  <br />
			  <fieldset style="border:1px solid #CCCCCC; padding-bottom:5px;">
              <legend style="color:#000000; font-weight:bold; font-size:14px; margin-left:5px;"> 设置密码保护信息 </legend>
			  <table border="0" cellpadding="4" cellspacing="0">
                <tr>
                  <td colspan="3" style="height:5px"></td>
                </tr>
                <tr>
                  <td colspan="3" style="padding-left:25px; color:#000000;">请填写正确有效的电子邮箱地址。在您执行密码找回操作时，该邮箱用于接收您的密码。</td>
                </tr>                  
                <tr>
                  <td width="80"><div align="right"><span >电子邮箱</span></div></td>
                  <td width="15"><span class="regRequired">*</span></td>
                  <td width="650"><div style="float:left;"><input name="UserEmail" id="UserEmail" type="text" maxlength="100" style="width:250px"  onfocus="showTip('tipUserEmailNormal','tipUserEmailTrue','tipUserEmailFalse')"  onblur="checkEmail('UserEmail','tipUserEmailNormal','tipUserEmailTrue','tipUserEmailFalse',1)" runat="server" /></div>
                    <div class="tipNormal" id="tipUserEmailNormal" style="display:none;">请填写正确有效的电子邮箱地址。</div><div class="tipTrue" id="tipUserEmailTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipUserEmailFalse" style="display:none;">您的填写错误。请填写正确有效的电子邮箱地址。</div><span id="err" style="color:#FF6600"></span></td>
                </tr>
                <tr>
                  <td colspan="3" style="height:10px"></td>
                </tr>                
                <tr>
                  <td colspan="3" style="padding-left:25px; color:#000000;">填写机密问题与答案，当此您执行密码找回操作，并无法使用注册时填写的电子邮件时，会要求您回答该问题，这将确保是您本人在进行该操作，使您帐号更安全。</td>
                </tr>                
                <tr>
                  <td><div align="right"><span >机密问题</span></div></td>
                  <td></td>
                  <td><div style="float:left;"><input name="PasswordQuestion" type="text" maxlength="50" id="PasswordQuestion" style="width:250px" onfocus="showTip1('tipPasswordQuestion');"  onblur="hideTip1('tipPasswordQuestion');" runat="server" /></div>
                  <div class="tipNormal" id="tipPasswordQuestion" style="display:none;">请填写您的机密问题。如：我的出生地是？</div> </td>
                </tr>
                <tr>
                  <td><div align="right"><span >答案</span></div></td>
                  <td></td>
                  <td><div style="float:left;"><input name="PasswordAnswer" type="text" maxlength="50" id="PasswordAnswer" style="width:250px" onfocus="showTip1('tipPasswordAnswer');"  onblur="hideTip1('tipPasswordAnswer');" runat="server" /></div>
                  <div class="tipNormal" id="tipPasswordAnswer" style="display:none;">请填写您上面机密问题的答案。</div> </td>
                </tr>                                
                <tr>
                  <td colspan="3" style="height:5px"></td>
                </tr>
              </table>
			  </fieldset>
			  <BR/>			  
			  <fieldset style="border:1px solid #CCCCCC; padding-bottom:5px;">
              <legend style="color:#000000; font-weight:bold; font-size:14px; margin-left:5px;"> 验证您的注册 </legend>
			  
			  <table border="0" cellpadding="4" cellspacing="0">
                <tr>
                  <td colspan="3" style="height:5px"></td>
                </tr>
                <tr>
                  <td><div align="right"><span >验证图片</span></div></td>
                  <td>&nbsp;</td>
                  <td><div style="float:left;"><img id="imgVerify" src="VerifyCode.aspx?" alt="看不清楚？点击这里换张图片" onclick="randomString(this)" style="cursor:pointer;" /></div><div style="color:#226077; float:left; margin-top:5px; margin-left:10px; cursor:pointer;" onclick="randomString(document.getElementById('imgVerify'));">看不清楚？点击这里换张图片</div></td>
                </tr>
                <tr>
                  <td width="80"><div align="right"><span >验&nbsp;&nbsp;证&nbsp;&nbsp;码</span></div></td>
                  <td width="15"><span class="regRequired">*</span></td>
                  <td width="610"><div style="float:left;">
                    <input name="VerifyCode" type="text" class="textbox1" id="VerifyCode" style="width:44px" onfocus="showTip('tipVerifyCodeWarning','tipVerifyCodeTrue','tipVerifyCodeFalse')"  onblur="hideTip1('tipVerifyCodeWarning');checkVerifyCode('VerifyCode','tipVerifyCodeNormal','tipVerifyCodeTrue','tipVerifyCodeFalse',1)"  runat="server" />
                  </div>
                  <div class="tipNormal" id="tipVerifyCodeWarning" style="display:none;">请填写上图中的4个数字</div><div class="tipNormal" id="tipVerifyCodeNormal" style="display:none;">验证码检测中，请稍候...</div><div class="tipTrue" id="tipVerifyCodeTrue"  style="display:none;">验证码正确。</div><div class="tipFalse" id="tipVerifyCodeFalse" style="display:none;">验证码错误。</div>
                      <asp:Label ID="Label1" runat="server"></asp:Label></td>
                </tr>

                <tr>
                  <td colspan="3" style="height:5px"></td>
                </tr>
              </table>
			  </fieldset>
              <fieldset style="border:1px solid #CCCCCC;display:none" >
              <legend style="color:#999999"> 申请VIP会员 </legend>
                <table width="540" border="0" cellpadding="5" cellspacing="1">
                <tr>
                  <td width="100"><div align="right">VIP会员&nbsp;&nbsp;&nbsp;&nbsp;</div></td>
                  <td width="417"><table width="189" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="25"><span class="tablebody1">
                          <input name="ifvip" type="checkbox" class="InputTxt" id="ifvip" value="1" checked="checked" />
                        </span></td>
                        <td width="40">申请</td>
                        <td width="124"><span class="regRequired">VIP会员可发布运价</span></td>
                      </tr>
                  </table></td>
                </tr>
              </table>
            </fieldset>
			  <div align="center">
			  <a href="/intro/service.aspx" target="_blank">点击此处，阅读环球运费网服务条款</a><br />
                  <input name="Submit" type="button" class="InputBtn" value="同意服务条款,提交注册" style="width:150px; height:30px; line-height:25px; font-size:12px;"  id="Button1" runat="server" />
			    &nbsp;&nbsp;&nbsp;
                  <asp:Button ID="Button3" runat="server" Text="Button" CssClass="hidden" />
                  <input name="Submit2" type="button" class="InputBtn" value="返回首页" style="width:120px; height:30px;  line-height:25px; font-size:12px;" id="Button2" runat="server" />
		  </div>
		  <br />
		</div>
							        </div>
							      </td>
							      <td background="../images/box_6.gif" style="height: 15px"></td>
							</tr>
							<tr>
							  <td><img src="../images/box_7.gif" width="10" height="10" /></td>
							  <td background="../images/box_8.gif"></td>
							  <td><img src="../images/box_9.gif" width="10" height="10" /></td>
							</tr>
				      </table>
				</div>
				</div>
			</div>
		</div>
    </div>
	<div><img src="../images/blank.gif" width="100%" height="10" /></div>
	<div id="bottom">
		<div class="line"><img src="../images/line_blue.gif" width="100%" height="1" /></div>
		<div class="copyright"><a href="/intro/about.aspx">关于傲赢</a>|<a href="/intro/service.aspx">服务条款</a>|<a href="/intro/law.aspx">法律声明</a>|<a href="/intro/contact.aspx">联系我们</a><br />Copyright 2007 100Allin.com All Rights Reserved<br />沪ICP备07510944号</div>
	</div>
</form>
<script language="javascript" src="http://count48.51yes.com/click.aspx?id=485102224&logo=1"></script>	
</body>
</html>
