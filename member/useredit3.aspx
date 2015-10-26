<%@ Page Language="VB" AutoEventWireup="false" CodeFile="useredit3.aspx.vb" Inherits="member_Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改基本注册信息</title>
    <link href="css/offices.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
function a(b){
    var aa = document.getElementById(b).value;
    alert(aa.substring(aa.length-3,aa.length));
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

function isPassword(s)
{
    if(s.value.length>=6 && s.value.length<=15 || s.value.length==0)
    {
        return true;
    }
    else
    {
        return false;
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
    if(value.length > 500)
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
    if(word == "jpg" || word=="gif" || word == "JPG" || word=="GIF")
    {
        return true;
    }
    else
    {
        return false;
    }
    
    
}

//检查公司所在地
function checkLocus(n,t,f,type)
{
    var obj1=document.getElementById('ddlcity1');
    var obj2=document.getElementById('ddlcity2');
    if(obj1.options[obj1.selectedIndex].value!=0 && obj2.options[obj2.selectedIndex].value!=0 )
    {
        //alert("对")
        showTip(t,n,f);
    }
    else
    {
        //alert("错")
        showTip(f,n,t);
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

//检查用户名
//s是输入框,i是提示区域，t是正确的提示内容,f是错误的提示内容
function checkName(s,n,t,f,type){
    document.getElementById(f).innerHTML = "该用户名已被使用，请重新输入。"
if (type==1){
	if (document.getElementById(s).value != "") {
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
function checkUserPassword(s,n,t,f,type){
if (isPassword(document.getElementById(s))==1){
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

//检查Email
//s是输入框,i是提示区域，t是正确的提示内容,f是错误的提示内容
function checkPassword(s,n,t,f,type){
if (isPassword(s)==1){
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
checkRequired('RealName','tipRealNameNormal','tipRealNameTrue','tipRealNameFalse',0);
checkRequired('CompanyName','tipCompanyNameNormal','tipCompanyNameTrue','tipCompanyNameFalse',0);
checkEmail('UserEmail','tipUserEmailNormal','tipUserEmailTrue','tipUserEmailFalse',0);
checkUserPassword('UserPassword','tipUserPasswordNormal','tipUserPasswordTrue','tipUserPasswordFalse',0)
checkPhone('tipPhoneNormal','tipPhoneTrue','tipPhoneFalse',0);


//除用户名及验证码以外的信息，如果填写正确，进入下一步验证用户名及注册码
if (document.getElementById("tipRealNameTrue").style.display == "" & 
document.getElementById("tipCompanyNameTrue").style.display == "" & 
document.getElementById("tipUserEmailTrue").style.display == "" & 
document.getElementById("tipUserPasswordTrue").style.display == "" & 
document.getElementById("tipPhoneTrue").style.display == ""){
    document.getElementById("Button3").click();
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


    <link href="/member/css/dialog.css" rel="stylesheet" type="text/css" />
    <link href="/member/css/dialog.css" rel="stylesheet" type="text/css" />
    <link href="/member/css/dialog.css" rel="stylesheet" type="text/css" />
    <link href="/member/css/dialog.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
    <div class="main_container">
		<memberheader:memberheader ID="memberheader1" runat="server" />
		<div class="center">
			<memberleft:memberleft ID="memberleft1" runat="server" />	
		  <div class="main">
		  <memberwelcome:memberwelcome ID="memberwelcome1" runat="server" />
								<div class="fcl_tit"><table width="100%" border="0" cellspacing="1" cellpadding="0">
  <tr>
    <td width="6%" align="center"><img src="images/edit_icon.gif" /></td>
    <td width="44%"><strong>修改基本注册信息</strong></td>
    <td width="50%" align="right"></td>
  </tr>
</table>
</div>
<table border="0" cellpadding="4" cellspacing="0">
                <tr>
                  <td colspan="3" style="height:5px"></td>
                </tr>
    <tr>
                  <td><div align="right"><span >密码</span></div></td>
                  <td><span style="color: #ff6600">*</span></td>
                  <td style="width: 651px"><div style="float:left;"><input name="UserPassword" id="UserPassword" type="password" class="textbox1" style="width:250px"  onfocus="showTip('tipUserPasswordNormal','tipUserPasswordTrue','tipUserPasswordFalse')"  onblur="checkUserPassword('UserPassword','tipUserPasswordNormal','tipUserPasswordTrue','tipUserPasswordFalse',1)" runat="server" /></div>
                    <div class="tipNormal" id="tipUserPasswordNormal" style="display:none;">为方便其他用户联系到您，请填写正确有效的电子邮箱地址。</div><div class="tipTrue" id="tipUserPasswordTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipUserPasswordFalse" style="display:none;">您的填写错误。密码长度为6到15个字符。</div><span id="Span1" style="color:#FF6600"></span></td>
                </tr>
                
                <tr>
                  <td><div align="right"><span >电子邮箱</span></div></td>
                  <td><span style="color: #ff6600">*</span></td>
                  <td style="width: 651px"><div style="float:left;"><input name="UserEmail" id="UserEmail" type="text" class="textbox1" style="width:250px"  onfocus="showTip('tipUserEmailNormal','tipUserEmailTrue','tipUserEmailFalse')"  onblur="checkEmail('UserEmail','tipUserEmailNormal','tipUserEmailTrue','tipUserEmailFalse',1)" runat="server" /></div>
                    <div class="tipNormal" id="tipUserEmailNormal" style="display:none;">为方便其他用户联系到您，请填写正确有效的电子邮箱地址。</div><div class="tipTrue" id="tipUserEmailTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipUserEmailFalse" style="display:none;">您的填写错误。请填写正确有效的密码地址。</div><span id="err" style="color:#FF6600"></span></td>
                </tr>
                <tr>
                  <td><div align="right"><span >公司名称</span></div></td>
                  <td><span style="color: #ff6600">*</span></td>
                  <td style="width: 651px"><div style="float:left;"><input name="CompanyName" type="text" class="textbox1" id="CompanyName" style="width:250px" onfocus="showTip('tipCompanyNameNormal','tipCompanyNameTrue','tipCompanyNameFalse')"  onblur="checkRequired('CompanyName','tipCompanyNameNormal','tipCompanyNameTrue','tipCompanyNameFalse',1)" runat="server" /></div>
                  <div class="tipNormal" id="tipCompanyNameNormal" style="display:none;">为方便其他用户联系到您，请尽量填写公司全称。</div><div class="tipTrue" id="tipCompanyNameTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipCompanyNameFalse" style="display:none;">必须填写公司名称。</div></td>
                </tr>
                
                <tr>
                  <td width="80"><div align="right"><span >真实姓名</span></div></td>
                  <td width="15"><span style="color: #ff6600">*</span></td>
                  <td style="width: 651px"><div style="float:left;"><input name="RealName" type="text" class="textbox1" id="RealName" style="width:250px" onfocus="showTip('tipRealNameNormal','tipRealNameTrue','tipRealNameFalse')"  onblur="checkRequired('RealName','tipRealNameNormal','tipRealNameTrue','tipRealNameFalse',1)" runat="server" /></div> <div class="tipNormal" id="tipRealNameNormal" style="display:none;"></div><div class="tipTrue" id="tipRealNameTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipRealNameFalse" style="display:none;">此项必填</div></td>
                </tr>
                
                
                
                
                <tr>
                  <td><div align="right"><span >电话号码1</span></div></td>
                  <td><span style="color: #ff6600">*</span></td>
                  <td>
                  <div style="float:left;">
                      
                      <input name="Phone" type="text" maxlength="50" id="Phone" style="width:150px" onfocus="showTip('tipPhoneNormal','tipPhoneTrue','tipPhoneFalse')"  onblur="PhoneOnblur('tipPhoneNormal','tipPhoneTrue','tipPhoneFalse');" runat="server" />
                     
                  </div>
                      
                  <div class="tipNormal" id="tipPhoneNormal" style="display:none;">
                      为方便其他用户联系到您，请填写正确有效的电话。</div><div class="tipTrue" id="tipPhoneTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipPhoneFalse" style="display:none;">必须填写电话。</div> </td>
                </tr>
                
                

                
                
                
                
                
                
                
                
                
                
    
                   
                
                <tr>
                  <td colspan="3" style="height:5px"></td>
                </tr>
              </table>
				<div align="center"><br />
                  <input name="Submit" type="button" class="InputBtn" value="提交修改信息" style="width:120px; height:30px; line-height:25px; font-size:12px;"  id="Button1" runat="server" />
			    &nbsp;&nbsp;&nbsp;
                  <asp:Button ID="Button3" runat="server" Text="Button" CssClass="hidden" />
                  <input name="Submit2" type="button" class="hidden" value="返回首页" style="width:120px; height:30px;  line-height:25px; font-size:12px;" id="Button2" runat="server" />
		  </div>
				
		  </div>
            
		</div>
		<memberfooter:memberfooter ID="memberfooter1" runat="server" />
	</div>
    </form>
</body>
</html>
