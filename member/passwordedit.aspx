<%@ Page Language="VB" MasterPageFile="~/member/member.master" AutoEventWireup="false" CodeFile="passwordedit.aspx.vb" Inherits="member_passwordedit" title="环球运费网 - 修改密码" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
checkPassword('ctl00_ContentPlaceHolder1_UserPassword','tipUserPasswordNormal','tipUserPasswordTrue','tipUserPasswordFalse',0);
checkPassword2('ctl00_ContentPlaceHolder1_UserPassword','ctl00_ContentPlaceHolder1_UserPassword2','tipUserPassword2Normal','tipUserPassword2True','tipUserPassword2False',0);

//除用户名及验证码以外的信息，如果填写正确，进入下一步验证用户名及注册码
if (document.getElementById("tipUserPasswordTrue").style.display == "" & 
document.getElementById("tipUserPassword2True").style.display == "" ){
    document.getElementById("ctl00_ContentPlaceHolder1_Button3").click();
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

<div class="searchbox" style="line-height:25px; font-size:12px;">
<div style="margin-right:10px; margin-top:10px;">
              <fieldset style="border:1px solid #CCCCCC; padding-bottom:5px;">
              <legend style="color:#000000; font-weight:bold; font-size:14px;margin-left:5px;"> 修改您的密码 </legend>
                <table border="0" cellpadding="4" cellspacing="0">
                <tr>
                  <td colspan="3" style="height:5px"></td>
                </tr>
                <tr>
                  <td width="80"><div align="right"><span >新&nbsp;&nbsp;&nbsp;&nbsp;密&nbsp;&nbsp;&nbsp;&nbsp;码</span></div></td>
                  <td width="15"><span class="regRequired">*</span></td>
                  <td width="610"><div style="float:left;">
                  <input name="UserPassword" id="UserPassword" type="password" class="textbox1" style="width:200px" onfocus="showTip('tipUserPasswordNormal','tipUserPasswordTrue','tipUserPasswordFalse')"  onblur="checkPassword('ctl00_ContentPlaceHolder1_UserPassword','tipUserPasswordNormal','tipUserPasswordTrue','tipUserPasswordFalse',1);checkPassword2('ctl00_ContentPlaceHolder1_UserPassword2','ctl00_ContentPlaceHolder1_UserPassword','tipUserPassword2Normal','tipUserPassword2True','tipUserPassword2False')" runat="server"  /></div>
                  <div class="tipNormal" id="tipUserPasswordNormal" style="display:none;">密码由6-20个字母或数字组成，不支持中文。</div><div class="tipTrue" id="tipUserPasswordTrue"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipUserPasswordFalse" style="display:none;">您的填写错误。密码由6-20个字母或数字组成，不支持中文。</div></td>
                </tr>
                <tr>
                  <td><div align="right"><span >确认新密码</span></div></td>
                  <td><span class="regRequired">*</span></td>
                  <td><div style="float:left;">
                      <input name="UserPassword2" id="UserPassword2" type="password" class="textbox1" style="width:200px" onfocus="showTip('tipUserPassword2Normal','tipUserPassword2True','tipUserPassword2False')"  onblur="checkPassword2('ctl00_ContentPlaceHolder1_UserPassword','ctl00_ContentPlaceHolder1_UserPassword2','tipUserPassword2Normal','tipUserPassword2True','tipUserPassword2False',1)" runat="server" /></div>
					   <div class="tipNormal" id="tipUserPassword2Normal" style="display:none;">请再输入一遍您上面填写的密码。</div><div class="tipTrue" id="tipUserPassword2True"  style="display:none;">填写正确。</div><div class="tipFalse" id="tipUserPassword2False" style="display:none;">两次输入的密码不一致。请再输入一遍您上面填写的密码。</div></td>
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
			  <div align="center"><br />
                  <input name="Submit" type="button" class="InputBtn" value="确认修改密码" style="width:120px; height:30px; line-height:25px; font-size:12px;"  id="Button1" runat="server" />
			    &nbsp;&nbsp;&nbsp;
                  <asp:Button ID="Button3" runat="server" Text="Button" CssClass="hidden" />
                  <input name="Submit2" type="button" class="InputBtn" value="返回首页" style="width:120px; height:30px;  line-height:25px; font-size:12px;" id="Button2" runat="server" />
		  </div>
		  <br />
		  <br />
		  <br />
		  <br />
		  <br />
		</div>
</div>
</asp:Content>


