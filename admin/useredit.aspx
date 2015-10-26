<%@ Page Language="VB" AutoEventWireup="false" CodeFile="useredit.aspx.vb" Inherits="admin_useredit" validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据管理</title>
    <link href="css/master.css" rel="stylesheet" type="text/css" />
    <link href="css/userlist.css" rel="stylesheet" type="text/css" />
    <script language=javascript src=js/function.js></script>    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script language="javascript" type="text/javascript">
function checkLocus(n,t,f)
{
    if(document.getElementById("ddlcity1").value=="0" || document.getElementById("ddlcity2").value=="0")
    {
        showTip(f,n,t);
    }
    else
    {
        showTip(t,n,f);
    }
}

function funcChina(a){ 
var obj = a; 
if(/.*[\u4e00-\u9fa5]+.*$/.test(obj)) 
{  
return false; 
} 
return true; 
} 

function selectAdd()
{
	if(document.getElementById("ListBox1").selectedIndex!=-1)
	{
		//alert(document.getElementById("ListBox1").options[document.getElementById("ListBox1").selectedIndex].value);
		var varItem = new Option(document.getElementById("ListBox1").options[document.getElementById("ListBox1").selectedIndex].text, document.getElementById("ListBox1").options[document.getElementById("ListBox1").selectedIndex].value);
		
		
		document.getElementById("selshiper").options.add(varItem);
		document.getElementById("ListBox1").options.remove(document.getElementById("ListBox1").selectedIndex);        
		
	}
	Hidtypes()
}

function selectDelete()
{
	if(document.getElementById("selshiper").selectedIndex!=-1)
	{
		//alert(document.getElementById("ListBox1").options[document.getElementById("ListBox1").selectedIndex].value);
		var varItem = new Option(document.getElementById("selshiper").options[document.getElementById("selshiper").selectedIndex].text, document.getElementById("ListBox1").options[document.getElementById("selshiper").selectedIndex].value);
		
		
		document.getElementById("ListBox1").options.add(varItem);
		document.getElementById("selshiper").options.remove(document.getElementById("selshiper").selectedIndex);        
		
	}
	Hidtypes()
}

function selectClear()
{
	document.getElementById("selshiper").options.length = 0;
	document.getElementById("ListBox1").options.length = 0;
	var selectText = document.getElementById("Hidden1").value.split("|");
	var selectValue = document.getElementById("Hidden2").value.split("|");
	for(var i=0;i<selectText.length;i++)
	{
		var varItem = new Option(selectText[i],selectValue[i]);
		document.getElementById("ListBox1").options.add(varItem);
	}
	
	Hidtypes()
	
}

function Hidtypes()
{
    document.getElementById("Hidtypes").value="";
    for(var i=0;i<document.getElementById("selshiper").options.length;i++)
    {
        document.getElementById("Hidtypes").value+=document.getElementById("selshiper").options(i).value+"|";
    }
}


function maketime(id)
{
    var today,hour,second,minute,year,month,date,time;
    var strDate ;
    today=new Date();
     var n_day = today.getDay();
     switch (n_day)
     {
     case 0:{
     strDate = "星期日"
     }break;
     case 1:{
     strDate = "星期一"
     }break;
     case 2:{
     strDate ="星期二"
     }break;
     case 3:{
     strDate =  "星期三"
     }break;
     case 4:{
     strDate =  "星期四"
     }break;
     case 5:{
     strDate =  "星期五"
     }break;
     case 6:{
     strDate =  "星期六"
     }break;
     case 7:{
     strDate =  "星期日"
     }break;
     }
    year = today.getYear();
    month = today.getMonth()+1;
    date = today.getDate();
    hour = today.getHours();
    minute =today.getMinutes();
    second = today.getSeconds();
    time = year + " 年 " + month + " 月 " + date + " 日 " +  strDate +" " + hour + ":" + minute + ":" + second; //显示时间
    document.getElementById(id).value = document.getElementById(id).value + "\n" + time;
     
}

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

function isDigit(s) 
{ 
var patrn=/^(\w){6,20}$/; 
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

function isIntroduction(s)
{
    var value = document.getElementById(s).value;
    if(value.length > 800)
    {
        return false;
    }
    else
    {
        return true;
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

//检查用户名
//s是输入框,i是提示区域，t是正确的提示内容,f是错误的提示内容
function checkName(s,n,t,f,type){

    document.getElementById(f).innerHTML = "该用户名已被使用，请重新输入。"
    
if (type==1){
    
	if (document.getElementById(s).value != "" && document.getElementById(s).value != document.getElementById("hidusername").value ) {
	    
		CallServer1()
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

//检查英文项
function checkEn(s,n,t,f,type)
{
    if(!funcChina(document.getElementById(s).value))
    {
        showTip(f,n,t);
    }
    else
    {
        if (type==0)
        {
	        if (document.getElementById(s).value == "" )
	        {
		        showTip(f,n,t);
	        }
	        else {
		        showTip(t,n,f);
	        }
        }
        else
        {
	        if (document.getElementById(s).value != "" )
	        {
		        showTip(t,n,f);
	        }
	        else 
	        {
		        hideTip(f,n,t);
	        }
        }
    }
}

//检查电话
function checkPhone(s,a,n,t,f,type){
if (type==0){
	if (document.getElementById(s).value == ""){
		showTip(f,n,t);
	}
	else {
	    if (document.getElementById(s).value != "" && document.getElementById(a).value != "" )
	    {
		    showTip(t,n,f);
		}
	}
}
else{
	if (document.getElementById(s).value != "" && document.getElementById(a).value != "" ){
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

//检查
function PhoneOnblur(n,t,f){

	if (document.getElementById("Phone").value != ""){
		showTip(t,n,f);
	}
	else {
		hideTip(f,n,t);
	}
}

function checkPhone(n,t,f)
{
    if (document.getElementById("Phone").value == ""){
		showTip(f,n,t);
	}
	else {
		showTip(t,n,f);
	}

}


function Phone2Onblur(n,t,f){

	if (document.getElementById("Phone2").value != ""){
		showTip(t,n,f);
	}
	else {
		hideTip(f,n,t);
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
checkRequired('RealName','tipRealNameNormal','tipRealNameTrue','tipRealNameFalse',0);
checkRequired('CompanyName','tipCompanyNameNormal','tipCompanyNameTrue','tipCompanyNameFalse',0);
checkCompanyType('CompanyType','tipCompanyType','tipCompanyTypeTrue','tipCompanyTypeFalse',0)
checkEmail('UserEmail','tipUserEmailNormal','tipUserEmailTrue','tipUserEmailFalse',0);
checkPhone('tipPhoneNormal','tipPhoneTrue','tipPhoneFalse');
checkIntroduction('txtintroduction','tipintroductionNormal','tipintroductionTrue','tipintroductionFalse',1);
checkEn('Firstname','tipFirstnameNormal','tipFirstnameTrue','tipFirstnameFalse',0)
checkEn('Lastname','tipLastnameNormal','tipLastnameTrue','tipLastnameFalse',1)
checkEn('EN_CompanyName','tipEN_CompanyNameNormal','tipEN_CompanyNameTrue','tipEN_CompanyNameFalse',0)
checkEn('Country','tipCountryNormal','tipCountryTrue','tipCountryFalse',0)
checkEn('City','tipCityNormal','tipCityTrue','tipCityFalse',0)
checkEn('En_Address','tipEn_AddressNormal','tipEn_AddressTrue','tipEn_AddressFalse',1)
checkEn('Company_profile','tipCompany_profileNormal','tipCompany_profileTrue','tipCompany_profileFalse',1)
checkLocus('tipLocusNormal','tipLocusTrue','tipLocusFalse')

    if(document.getElementById("ckb_cn").checked && !document.getElementById("ckb_en").checked)
    {
        if(document.getElementById("tipCompanyTypeTrue").style.display == "" && 
        document.getElementById("tipPhoneTrue").style.display == "" &&
        document.getElementById("tipUserEmailTrue").style.display == "" &&
        document.getElementById("tipRealNameTrue").style.display == "" &&
        document.getElementById("tipCompanyNameTrue").style.display == "" &&
        document.getElementById("tipLocusTrue").style.display == "" &&
        document.getElementById("tipPhone2False").style.display == "none" &&
        document.getElementById("tipintroductionFalse").style.display == "none"
           )
        {
            
            document.getElementById("Button3").click();
        }
    }
    else if(document.getElementById("ckb_en").checked && !document.getElementById("ckb_cn").checked)
    {
        if(document.getElementById("tipCompanyTypeTrue").style.display == "" && 
        document.getElementById("tipPhoneTrue").style.display == "" &&
        document.getElementById("tipUserEmailTrue").style.display == "" &&
        document.getElementById("tipFirstnameTrue").style.display == "" && 
        document.getElementById("tipLastnameFalse").style.display == "none" &&
        document.getElementById("tipEN_CompanyNameTrue").style.display == "" && 
        document.getElementById("tipCountryTrue").style.display == "" && 
        document.getElementById("tipCityTrue").style.display == "" && 
        document.getElementById("tipEn_AddressFalse").style.display == "none" &&
        document.getElementById("tipCompany_profileFalse").style.display == "none" 
           )
        {
            document.getElementById("Button3").click();
        }
    }
    else if(document.getElementById("ckb_en").checked && document.getElementById("ckb_cn").checked)
    {
        if(document.getElementById("tipCompanyTypeTrue").style.display == "" && 
        document.getElementById("tipPhoneTrue").style.display == "" &&
        document.getElementById("tipUserEmailTrue").style.display == "" &&
        document.getElementById("tipRealNameTrue").style.display == "" &&
        document.getElementById("tipCompanyNameTrue").style.display == "" &&
        document.getElementById("tipLocusTrue").style.display == "" &&
        document.getElementById("tipPhone2False").style.display == "none" &&
        document.getElementById("tipintroductionFalse").style.display == "none" &&
        document.getElementById("tipFirstnameTrue").style.display == "" && 
        document.getElementById("tipLastnameFalse").style.display == "none" &&
        document.getElementById("tipEN_CompanyNameTrue").style.display == "" && 
        document.getElementById("tipCountryTrue").style.display == "" && 
        document.getElementById("tipCityTrue").style.display == "" && 
        document.getElementById("tipEn_AddressFalse").style.display == "none" &&
        document.getElementById("tipCompany_profileFalse").style.display == "none" 
           )
        {
            document.getElementById("Button3").click();
        }
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







//=====================================================================================
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

function entablechange()
{
    if(document.getElementById("ckb_en").checked)
    {
        document.getElementById("entable").style.display = "";
    }
    else
    {
        document.getElementById("entable").style.display = "none";
    }
}

function cntablechange()
{
    if(document.getElementById("ckb_cn").checked)
    {
        document.getElementById("cntable").style.display = "";
    }
    else
    {
        document.getElementById("cntable").style.display = "none";
    }
}
</script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="page">
		<div id="center">
			<admintop:admintop id="admintop1" runat="server" />
			<adminmenu:adminmenu id="adminmenu1" runat="server" />
		  <div id="main">
			<adminleft:adminleft id="adminleft1" runat="server" />												
		  	<div id="right">
				<div class="tt18 bd rightTitle">
					<div class="text">用户管理</div>
				</div>
				<div class="tt14 bd rightSubTitle">
					<div class="text">用户编辑</div>
				</div>	
				<div class="rightArea txth22">
                    <div style="margin-right:10px; margin-top:10px;">
                    <div style="padding:0px 0px 10px 0px; font-size:14px;">
                    <a href="useremail.aspx?id=<%=Request.QueryString("id") %>" target="_blank">给TA发邮件</a>
                    <a href="fcllist.aspx?uid=<%=Request.QueryString("id") %>" target="_blank">TA的整箱运价</a>
                    <a href="lcllist.aspx?uid=<%=Request.QueryString("id") %>" target="_blank">TA的拼箱运价</a>
                    <a href="airlist.aspx?uid=<%=Request.QueryString("id") %>" target="_blank">TA的空运运价</a>
                    <a href="searchwordslist.aspx?uid=<%=Request.QueryString("id") %>" target="_blank">TA的运价搜索轨迹</a>
                    <a href="pageviewlist.aspx?uid=<%=Request.QueryString("id") %>" target="_blank">TA的浏览轨迹</a>
                    <a href="userdataprice.aspx?u=<%=Request.QueryString("id") %>" target="_blank">TA的运价分析</a>
                    <a href="/admin/sales/hitindex.aspx?u=<%=Request.QueryString("id") %>" target="_blank">TA的运价点击量</a>
                    </div>
                    
                          <fieldset style="border:1px solid #CCCCCC; padding-bottom:5px;">
                          <legend style="color:#000000; font-weight:bold; font-size:14px;margin-left:5px;"> 修改您的个人信息 </legend>
                          
                          
                          <table id="Table1" border="0" cellpadding="4" cellspacing="0" runat="server" >
                            <tr>
                              <td colspan="3" style="height:5px"></td>
                            </tr>
                            <tr>
                              <td width="80"><div align="right"><span >用&nbsp;&nbsp;户&nbsp;&nbsp;名</span></div></td>
                              <td width="15"><span class="regRequired">*</span></td>
                              <td width="610"><div style="float:left;">
		                      <input name="UserName" id="UserName" type="text"  style="width:200px" onfocus="showTip('tipUserNameWarning','tipUserNameTrue','tipUserNameFalse')"  onblur="hideTip1('tipUserNameWarning');checkName('UserName','tipUserNameNormal','tipUserNameTrue','tipUserNameFalse',1);" runat="server"   /></div>
                              <input id="hidusername" type="hidden" runat="server" />
                              <div class="tipNormal" id="tipUserNameWarning" style="display:none;">注意：注册成功后，用户名将不可以修改</div><div class="tipNormal" id="tipUserNameNormal" style="display:none;">用户名检测中，请稍候...</div><div class="tipTrue" id="tipUserNameTrue"  style="display:none;">该用户名可以注册。</div><div class="tipFalse" id="tipUserNameFalse" style="display:none;">该用户名已被使用，请重新输入。</div></td>
                            </tr>
                            <tr>
                              <td><div align="right"><span >密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码</span></div></td>
                              <td><span class="regRequired">*</span></td>
                              <td><div style="float:left;">
                              <input name="UserPassword" id="UserPassword" type="text"  class="textbox1" style="width:200px" onfocus="showTip('tipUserPasswordNormal','tipUserPasswordTrue','tipUserPasswordFalse')"  onblur="checkPassword('UserPassword','tipUserPasswordNormal','tipUserPasswordTrue','tipUserPasswordFalse',1);" runat="server"  /></div>
                              <div class="tipNormal" id="tipUserPasswordNormal" style="display:none;">密码由6-20个字母或数字组成，不支持中文。</div><div class="tipTrue" id="tipUserPasswordTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipUserPasswordFalse" style="display:none;">您的填写错误。密码由6-20个字母或数字组成，不支持中文。</div></td>
                            </tr>
                            <tr >
                              <td><div align="right">公司类型</div></td>
                              <td><span style="color: #ff6600">*</span></td>
                              <td><div style="float:left;"><select name="CompanyType" onfocus="showTip('tipCompanyType','tipCompanyTypeTrue','tipCompanyTypeFalse');"  onblur="checkCompanyType('CompanyType','tipCompanyType','tipCompanyTypeTrue','tipCompanyTypeFalse',1)" id="CompanyType" runat="server" style="width:100px">
			                      <option value="0">请选择</option>
                      <option value="1">货主</option>
                      <option value="2">货代</option>
                      <option value="3">船东</option>
                      <option value="5">船代</option>
                      <option value="6">快递</option>
                      <option value="7">场站</option>
                      <option value="8">仓储</option>
                      <option value="9">集卡</option>
                      <option value="10">报关</option>
                      <option value="4">其他</option>
                              </select></div>
                              <div class="tipNormal" id="tipCompanyType" style="display:none;">请选择您公司的类型。</div><div class="tipTrue" id="tipCompanyTypeTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipCompanyTypeFalse" style="display:none;">必须选择公司类型。</div></td>
                            </tr>
                            <tr>
                  <td><div align="right"><span >电话号码1</span></div></td>
                  <td><span class="regRequired">*</span></td>
                  <td>
                  <div style="float:left;">
                      
                      <input name="Phone" type="text" maxlength="50" id="Phone" style="width:150px" onfocus="showTip('tipPhoneNormal','tipPhoneTrue','tipPhoneFalse')"  onblur="PhoneOnblur('tipPhoneNormal','tipPhoneTrue','tipPhoneFalse');" runat="server" />
                     
                  </div>
                      
                  <div class="tipNormal" id="tipPhoneNormal" style="display:none;">
                      为方便其他用户联系到您，请填写正确有效的电话。</div><div class="tipTrue" id="tipPhoneTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipPhoneFalse" style="display:none;">必须填写电话。</div> </td>
                            </tr>
                            <tr>
                              <td><div align="right">传真号码</div></td>
                              <td>&nbsp;</td>
                              <td><div style="float:left;"><input name="Fax" type="text" class="textbox1" id="Fax" style="width:250px" onfocus="showTip1('tipFax')"  onblur="hideTip1('tipFax')" runat="server" /></div>
                                <div class="tipNormal" id="tipFax" style="display:none;">为方便其他用户联系到您，请填写正确有效的传真号码。</div></td>
                            </tr>
                            <tr>
                              <td><div align="right"><span >电子邮箱</span></div></td>
                              <td><span class="regRequired">*</span></td>
                              <td><div style="float:left;">
                              <input name="UserEmail" id="UserEmail" type="text" class="textbox1" style="width:250px"  onfocus="showTip('tipUserEmailNormal','tipUserEmailTrue','tipUserEmailFalse')"  onblur="checkEmail('UserEmail','tipUserEmailNormal','tipUserEmailTrue','tipUserEmailFalse',1)" runat="server" /></div>
                                <div class="tipNormal" id="tipUserEmailNormal" style="display:none;">为方便其他用户联系到您，请填写正确有效的电子邮箱地址。</div><div class="tipTrue" id="tipUserEmailTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipUserEmailFalse" style="display:none;">您的填写错误。请填写正确有效的电子邮箱地址。</div><span id="err" style="color:#FF6600"></span></td>
                            </tr>
                            <tr>
                              <td><div align="right">邮政编码</div></td>
                              <td>&nbsp;</td>
                              <td><div style="float:left;"><input name="PostNumber" type="text" class="textbox1" id="PostNumber" style="width:100px" onfocus="showTip1('tipPostNumber')"  onblur="hideTip1('tipPostNumber')" runat="server" /></div>
                                <div class="tipNormal" id="tipPostNumber" style="display:none;">为方便其他用户联系到您，请填写正确有效的邮政编码。</div></td>
                            </tr>
                          </table>
                          
                          
                            
                        </fieldset>
                        
                        <fieldset style="border:1px solid #CCCCCC" >
                          <legend style="color:#999999"> 中文会员 </legend>
                            <table width="540" border="0" cellpadding="5" cellspacing="1">
                            <tr>
                              <td width="100"><div align="right">
                                  中文会员&nbsp;&nbsp;&nbsp;&nbsp;</div></td>
                              <td width="417">
                                  <asp:CheckBox ID="ckb_cn" runat="server" />
                                      <%--<input name="ifvip" type="checkbox" class="InputTxt" id="ckb_cn" value="1" onclick="cntablechange()" />--%>
                              </td>
                            </tr>
                          </table>
                          <table id="cntable" border="0" cellpadding="4" cellspacing="0" runat="server" style="display:none;">
                            <tr>
                              <td colspan="3" style="height:5px"></td>
                            </tr>
                            
                            
                            
                            
                            
                            

                            <tr>
                              <td width="80"><div align="right"><span >真实姓名</span></div></td>
                              <td width="15"><span class="regRequired">*</span></td>
                              <td width="610"><div style="float:left;"><input name="RealName" type="text" class="textbox1" id="RealName" style="width:250px" onfocus="showTip('tipRealNameNormal','tipRealNameTrue','tipRealNameFalse')"  onblur="checkRequired('RealName','tipRealNameNormal','tipRealNameTrue','tipRealNameFalse',1)" runat="server" /></div> <div class="tipNormal" id="tipRealNameNormal" style="display:none;"></div><div class="tipTrue" id="tipRealNameTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipRealNameFalse" style="display:none;">此项必填</div></td>
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
                              <td><div style="float:left;"><input name="CompanyName" type="text" class="textbox1" id="CompanyName" style="width:250px" onfocus="showTip('tipCompanyNameNormal','tipCompanyNameTrue','tipCompanyNameFalse')"  onblur="checkRequired('CompanyName','tipCompanyNameNormal','tipCompanyNameTrue','tipCompanyNameFalse',1)" runat="server" /></div>
                              <div class="tipNormal" id="tipCompanyNameNormal" style="display:none;">为方便其他用户联系到您，请尽量填写公司全称。</div><div class="tipTrue" id="tipCompanyNameTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipCompanyNameFalse" style="display:none;">必须填写公司名称。</div></td>
                            </tr>
                            
                            
                            
                            
                            
                            
                            
                
                
                <tr>
                  <td><div align="right"><span >电话号码2</span></div></td>
                  <td></td>
                  <td>
                  <div style="float:left;">

                      <input name="Phone" type="text" maxlength="50" id="Phone2" style="width:150px" onfocus="showTip('tipPhone2Normal','tipPhone2True','tipPhone2False')"  onblur="Phone2Onblur('tipPhone2Normal','tipPhone2True','tipPhone2False');" runat="server" />
                      
                  </div>
                      
                  <div class="tipNormal" id="tipPhone2Normal" style="display:none;">
                      为方便其他用户联系到您，请填写正确有效的电话。</div><div class="tipTrue" id="tipPhone2True"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipPhone2False" style="display:none;">必须填写完整的电话。</div> </td>
                </tr>
                
                
                
                
                <tr>
                  <td><div align="right">公司所在地</div></td>
                  <td>
                      <span class="regRequired">*</span></td>
                  <td>

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <div style="float:left;">
                        <asp:DropDownList ID="ddlcity1" runat="server" AutoPostBack="True" Width="100px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlcity2" runat="server" AutoPostBack="True" Width="100px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlcity3" runat="server" AutoPostBack="True" Width="100px" Visible="False">
                        </asp:DropDownList>
                        </div>
                        <div class="tipNormal" id="tipLocusNormal" style="display:none;" runat="server">请填写正确有效的公司所在地。</div><div class="tipTrue" id="tipLocusTrue"  style="display:none;" runat="server">填写正确。</div><div class="tipFalse" id="tipLocusFalse" style="display:none;" runat="server">必须填写完整的公司所在地。</div> 
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    
                  </td>
                </tr>
                
                
                
                
                            
                            
                            
                            <tr>
                              <td><div align="right">手机号码</div></td>
                              <td>&nbsp;</td>
                              <td><div style="float:left;"><input name="MovePhone" type="text" class="textbox1" id="MovePhone" style="width:250px" onfocus="showTip1('tipMovePhone')"  onblur="hideTip1('tipMovePhone')" runat="server" /></div>
                                <div class="tipNormal" id="tipMovePhone" style="display:none;">为方便其他用户联系到您，请填写正确有效的手机号码。</div></td>
                            </tr>
                            <tr>
                              <td><div align="right">联系地址</div></td>
                              <td>&nbsp;</td>
                              <td><div style="float:left;"><input name="Address" type="text" class="textbox1" id="Address" style="width:250px" onfocus="showTip1('tipAddress')"  onblur="hideTip1('tipAddress')" runat="server" /></div>
                                <div class="tipNormal" id="tipAddress" style="display:none;">为方便其他用户联系到您，请填写正确有效的联系地址。</div></td>
                            </tr>
                            
                            
                            
                            <tr>
                        <td style="text-align: right">
                            公司简介</td>
                        <td>
                        </td>
                        <td style="width: 651px">
                        <div style="float:left;">
                        <textarea name="txtintroduction" type="text"  class="textbox1" id="txtintroduction" style="width:250px; height: 80px;" onfocus="showTip('tipintroductionNormal','tipintroductionTrue','tipintroductionFalse')"  onblur="checkIntroduction('txtintroduction','tipintroductionNormal','tipintroductionTrue','tipintroductionFalse',1)" runat="server" /><%--<input  />--%>
                        </div>
                            <div class="tipNormal" id="tipintroductionNormal" style="display:none;">
                                可以为您运价增加一个公司简介。</div>
                            <div class="tipTrue" id="tipintroductionTrue"  style="display:none;">
                                填写正确。</div>
                            <div class="tipFalse" id="tipintroductionFalse" style="display:none;">
                                必须小于800个字符</div>    
                            
                            
                        </td>
                    </tr>
                    
                    
                            <tr>
                              <td><div align="right">备注</div></td>
                              <td>&nbsp;</td>
                              <td><div style="float:left;"><textarea name="txtmemo" class="textbox1" id="txtmemo" style="width:250px; height: 126px;" onfocus="showTip1('tipMemo')"  onblur="hideTip1('tipMemo')" runat="server" /></div>
                                <input type="button" id="maketiem" onclick="maketime('txtmemo')" value="插入当前时间" />
                                <div class="tipNormal" id="tipMemo" style="display:none;">客户联系信息保留</div></td>
                            </tr>
                                <tr>
                                    <td><div align="right">论坛管理级别</div></td>
                                    <td>
                                    </td>
                                    <td>
                                        <div style="float: left">
                                            <select id="ListBox1" runat="server" name="ListBox1" size="4" style="width: 109px">
                                            </select>
                                            
                                            
                                        </div>
                                        <div style="float: left; height: 55px">
                                            <input id="Button4" name="Button4" onclick="selectAdd()" type="button" value="添加" /><br />
                                            <input id="Button5" name="Button5" onclick="selectDelete()" type="button" value="删除" /><br />
                                            <input id="Button6" name="Button6" onclick="selectClear()" type="button" value="清空" />
                                        </div>
                                        <div style="float: left">
                                        
                                            <select id="selshiper" runat="server" name="ListBox2" size="4" style="width: 109px">
                                            </select>
                                        </div>
                                        <input id="Hidden1" runat="server" type="hidden" />
                                        <input id="Hidden2" runat="server" type="hidden" />
                                        <input id="Hidtypes" runat="server" type="hidden" /></td>
                                </tr>
                              <tr>
                                  <td><div align="right">置顶(整)</div>
                                  </td>
                                  <td>
                                  </td>
                                  <td>
                                      航&nbsp;&nbsp;线：<asp:TextBox ID="txtLine" runat="server" Width="249px"></asp:TextBox>
                                      目的港：<asp:TextBox ID="txtDestport" runat="server" Width="249px"></asp:TextBox>
                                  </td>
                              </tr>
                              <tr>
                                  <td>
                                  </td>
                                  <td>
                                  </td>
                                  <td>
                                  船公司：<asp:TextBox ID="txtShiper" runat="server" Width="249px"></asp:TextBox>
                                  出发港：<asp:TextBox ID="txtStartport" runat="server" Width="249px"></asp:TextBox>
                                  </td>
                              </tr>
                              <tr>
                                  <td><div align="right">置顶(拼)</div>
                                  </td>
                                  <td>
                                  </td>
                                  <td>
                                      航&nbsp;&nbsp;线：<asp:TextBox ID="txtLine2" runat="server" Width="249px"></asp:TextBox>
                                      目的港：<asp:TextBox ID="txtDestport2" runat="server" Width="249px"></asp:TextBox>
                                  </td>
                              </tr>
                              <tr>
                                  <td>
                                  </td>
                                  <td>
                                  </td>
                                  <td>
                                  船公司：<asp:TextBox ID="txtShiper2" runat="server" Width="249px"></asp:TextBox>
                                  出发港：<asp:TextBox ID="txtStartport2" runat="server" Width="249px"></asp:TextBox>
                                  </td>
                              </tr>
                              
                              <tr>
                                  <td><div align="right">置顶等级</div>
                                  </td>
                                  <td>
                                  </td>
                                  <td>
                                      <asp:DropDownList ID="ddlstar_adv" runat="server">
                                      <asp:ListItem Value="0">请选择</asp:ListItem>
                                      <asp:ListItem Value="1">1</asp:ListItem>
                                      <asp:ListItem Value="2">2</asp:ListItem>
                                      <asp:ListItem Value="3">3</asp:ListItem>
                                      <asp:ListItem Value="4">4</asp:ListItem>
                                      <asp:ListItem Value="5">5</asp:ListItem>
                                      </asp:DropDownList>
                                  </td>
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
                        
                        <fieldset style="border:1px solid #CCCCCC" >
                          <legend style="color:#999999"> 英文站会员 </legend>
                            <table width="740" border="0" cellpadding="5" cellspacing="1">
                            <tr>
                              <td width="80"><div align="right">
                                  英文会员&nbsp;&nbsp;&nbsp;&nbsp;</div></td>
                              <td width="660">
                              
                                      <%--<input name="ifvip" type="checkbox" class="InputTxt" id="ckb_en" value="1" onclick="entablechange()" runat="server" />--%>
                                  <asp:CheckBox ID="ckb_en" runat="server" /></td>
                            </tr>
                          </table>
                          <table id="entable" width="740" border="0" cellpadding="5" cellspacing="1" style="display:none;" runat="server">
                            <tr>
                              <td width="100"><div align="right">
                                  First name</div></td>
                                  <td><span class="regRequired">*</span></td>
                              <td width="617">
                                  <div style="float:left;"><input name="Address" type="text" class="textbox1" id="Firstname" style="width:250px" onfocus="showTip('tipFirstnameNormal','tipFirstnameTrue','tipFirstnameFalse')"  onblur="checkEn('Firstname','tipFirstnameNormal','tipFirstnameTrue','tipFirstnameFalse',0)" runat="server" /></div>
                              <div class="tipNormal" id="tipFirstnameNormal" style="display:none;">First name</div><div class="tipTrue" id="tipFirstnameTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipFirstnameFalse" style="display:none;">填写错误</div>    
                              </td>
                            </tr>
                            <tr>
                              <td><div align="right">
                                  Last name</div></td>
                                  <td></td>
                              <td>
                                  <div style="float:left;"><input name="Address" type="text" class="textbox1" id="Lastname" style="width:250px"  runat="server"  onfocus="showTip('tipLastnameNormal','tipLastnameTrue','tipLastnameFalse')"  onblur="checkEn('Lastname','tipLastnameNormal','tipLastnameTrue','tipLastnameFalse',1)" /></div>
                                  <div class="tipNormal" id="tipLastnameNormal" style="display:none;">为方便其他用户联系到您，请尽量填写公司全称。</div><div class="tipTrue" id="tipLastnameTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipLastnameFalse" style="display:none;">填写错误</div>
                              </td>
                            </tr>
                            <tr>
                              <td><div align="right">
                                  Company name</div></td>
                                  <td><span class="regRequired">*</span></td>
                              <td>
                                  <div style="float:left;"><input name="Address" type="text" class="textbox1" id="EN_CompanyName" style="width:250px" onfocus="showTip('tipEN_CompanyNameNormal','tipEN_CompanyNameTrue','tipEN_CompanyNameFalse')"  onblur="checkEn('EN_CompanyName','tipEN_CompanyNameNormal','tipEN_CompanyNameTrue','tipEN_CompanyNameFalse',0)" runat="server" /></div>
                              <div class="tipNormal" id="tipEN_CompanyNameNormal" style="display:none;">为方便其他用户联系到您，请尽量填写公司全称。</div><div class="tipTrue" id="tipEN_CompanyNameTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipEN_CompanyNameFalse" style="display:none;">填写错误</div>    
                              </td>
                            </tr>
                            <tr>
                              <td><div align="right">
                                  Country/Region</div></td>
                                  <td><span class="regRequired">*</span></td>
                              <td>
                                  <div style="float:left;"><input name="Address" type="text" class="textbox1" id="Country" style="width:250px"  onfocus="showTip('tipCountryNormal','tipCountryTrue','tipCountryFalse')"  onblur="checkEn('Country','tipCountryNormal','tipCountryTrue','tipCountryFalse',0)" runat="server" /></div>
                                  <div class="tipNormal" id="tipCountryNormal" style="display:none;">为方便其他用户联系到您，请尽量填写公司全称。</div><div class="tipTrue" id="tipCountryTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipCountryFalse" style="display:none;">填写错误</div>
                                  </td>
                            </tr>
                            <tr>
                              <td><div align="right">
                                  City</div></td>
                                  <td><span class="regRequired">*</span></td>
                              <td>
                                  <div style="float:left;"><input name="Address" type="text" class="textbox1" id="City" style="width:250px" onfocus="showTip('tipCityNormal','tipCityTrue','tipCityFalse')"  onblur="checkEn('City','tipCityNormal','tipCityTrue','tipCityFalse',0)" runat="server" /></div>
                                  <div class="tipNormal" id="tipCityNormal" style="display:none;">为方便其他用户联系到您，请尽量填写公司全称。</div><div class="tipTrue" id="tipCityTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipCityFalse" style="display:none;">填写错误</div>
                               </td>
                            </tr>
                            <tr>
                              <td><div align="right">
                                  Address</div></td>
                                  <td></td>
                              <td>
                                  <div style="float:left;"><input name="Address" type="text" class="textbox1" id="En_Address" onfocus="showTip('tipEn_AddressNormal','tipEn_AddressTrue','tipEn_AddressFalse')"  onblur="checkEn('En_Address','tipEn_AddressNormal','tipEn_AddressTrue','tipEn_AddressFalse',1)" style="width:250px"  runat="server"  /></div>
                                  <div class="tipNormal" id="tipEn_AddressNormal" style="display:none;">为方便其他用户联系到您，请尽量填写公司全称。</div><div class="tipTrue" id="tipEn_AddressTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipEn_AddressFalse" style="display:none;">填写错误</div>
                               
                              </td>
                            </tr>
                            <tr>
                              <td><div align="right">
                                  Company profile</div></td>
                                  <td></td>
                              <td>
                                 <div style="float:left;"><textarea name="txtmemo" class="textbox1" id="Company_profile" style="width:250px; height: 126px;" runat="server" onfocus="showTip('tipCompany_profileNormal','tipCompany_profileTrue','tipCompany_profileFalse')"  onblur="checkEn('Company_profile','tipCompany_profileNormal','tipCompany_profileTrue','tipCompany_profileFalse',1)" /></div>
                                 <div class="tipNormal" id="tipCompany_profileNormal" style="display:none;">为方便其他用户联系到您，请尽量填写公司全称。</div><div class="tipTrue" id="tipCompany_profileTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipCompany_profileFalse" style="display:none;">填写错误</div>
                              </td>
                            </tr>
                          </table>
                          
                        </fieldset>
                        
	                      <div align="center"><br />
                              <input name="Submit" type="button" class="InputBtn" value="保存信息" style="width:80px; height:30px; line-height:25px; font-size:12px;"  id="Button1" runat="server" />
	                        &nbsp;&nbsp;&nbsp;
                              <asp:Button ID="Button3" runat="server" Text="Button" CssClass="hidden" />
                              <input name="Submit2" type="button" class="InputBtn" value="返回列表" style="width:80px; height:30px;  line-height:25px; font-size:12px;" id="Button2" runat="server" />
                      </div>
                    </div>               
			    </div>			
			</div>			
		  </div>
		<adminbottom:adminbottom id="adminbottom1" runat="server" />	
		</div>
    </div>
</form>
</body>
</html>

