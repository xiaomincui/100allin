<%@ Page Language="VB" MasterPageFile="~/member/member.master" AutoEventWireup="false" CodeFile="useredit.aspx.vb" Inherits="member_useredit" title="�����˷��� - �޸ĸ�����Ϣ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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

//��鹫˾���ڵ�
function checkLocus(n,t,f,type)
{
    var obj1=document.getElementById('ctl00_ContentPlaceHolder1_ddlcity1');
    var obj2=document.getElementById('ctl00_ContentPlaceHolder1_ddlcity2');
    if(obj1.options[obj1.selectedIndex].value!=0 && obj2.options[obj2.selectedIndex].value!=0 )
    {
        //alert("��")
        showTip(t,n,f);
    }
    else
    {
        //alert("��")
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



//���
function PhoneOnblur(n,t,f){

	if (document.getElementById("ctl00_ContentPlaceHolder1_Phone").value != ""){
		showTip(t,n,f);
	}
	else {
		hideTip(f,n,t);
	}
}

function checkPhone(n,t,f)
{
    if (document.getElementById("ctl00_ContentPlaceHolder1_Phone").value == ""){
		showTip(f,n,t);
	}
	else {
		showTip(t,n,f);
	}

}


function Phone2Onblur(n,t,f){

	if (document.getElementById("ctl00_ContentPlaceHolder1_Phone2").value != ""){
		showTip(t,n,f);
	}
	else {
		hideTip(f,n,t);
	}
}

//����û���
//s�������,i����ʾ����t����ȷ����ʾ����,f�Ǵ������ʾ����
function checkName(s,n,t,f,type){
    document.getElementById(f).innerHTML = "���û����ѱ�ʹ�ã����������롣"
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
        document.getElementById(f).innerHTML = "�û�������Ҫ��д��"
	    showTip(f,n,t);
	}
}
}

//��������
//s�������,i����ʾ����t����ȷ����ʾ����,f�Ǵ������ʾ����
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

//�������ȷ�Ͽ�
//s�������,i����ʾ����t����ȷ����ʾ����,f�Ǵ������ʾ����
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

//��������Ŀ
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

//��鹫˾����
//s�������,i����ʾ����t����ȷ����ʾ����,f�Ǵ������ʾ����
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


//����Ա�
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

//���Email
//s�������,i����ʾ����t����ȷ����ʾ����,f�Ǵ������ʾ����
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

//���绰
//s�������,i����ʾ����t����ȷ����ʾ����,f�Ǵ������ʾ����
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

//�����֤��
//s�������,i����ʾ����t����ȷ����ʾ����,f�Ǵ������ʾ����
function checkVerifyCode(s,n,t,f,type){
    document.getElementById(f).innerHTML = "��֤��������������롣"
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
        document.getElementById(f).innerHTML = "��֤�����Ҫ��д��"
	    showTip(f,n,t);
	}
}
}


function checkAll(){
//��֤������Ϣ��ʽ
checkRequired('ctl00_ContentPlaceHolder1_RealName','tipRealNameNormal','tipRealNameTrue','tipRealNameFalse',0);
checkRequired('ctl00_ContentPlaceHolder1_CompanyName','tipCompanyNameNormal','tipCompanyNameTrue','tipCompanyNameFalse',0);
checkCompanyType('ctl00_ContentPlaceHolder1_CompanyType','tipCompanyType','tipCompanyTypeTrue','tipCompanyTypeFalse',0)
checkEmail('ctl00_ContentPlaceHolder1_UserEmail','tipUserEmailNormal','tipUserEmailTrue','tipUserEmailFalse',0);
//checkRequired('ctl00_ContentPlaceHolder1_Phone','tipPhoneNormal','tipPhoneTrue','tipPhoneFalse',0);
checkPhone('tipPhoneNormal','tipPhoneTrue','tipPhoneFalse');
checkPicture('ctl00_ContentPlaceHolder1_FileUpload1','tipheadNormal','tipheadTrue','tipheadFalse',1);
checkSign('ctl00_ContentPlaceHolder1_txtsign','tipsignNormal','tipsignTrue','tipsignFalse',1);
checkIntroduction('ctl00_ContentPlaceHolder1_txtintroduction','tipintroductionNormal','tipintroductionTrue','tipintroductionFalse',1);
checkLocus('ctl00_ContentPlaceHolder1_tipLocusNormal','ctl00_ContentPlaceHolder1_tipLocusTrue','ctl00_ContentPlaceHolder1_tipLocusFalse',0);


//���û�������֤���������Ϣ�������д��ȷ��������һ����֤�û�����ע����
if (document.getElementById("tipRealNameTrue").style.display == "" & 
document.getElementById("tipCompanyNameTrue").style.display == "" & 
document.getElementById("tipCompanyTypeTrue").style.display == "" & 
document.getElementById("tipUserEmailTrue").style.display == "" & 
document.getElementById("tipPhoneTrue").style.display == "" & 

document.getElementById("tipheadFalse").style.display == "none" &
document.getElementById("tipsignFalse").style.display == "none" &
document.getElementById("tipintroductionFalse").style.display == "none" &
document.getElementById("ctl00_ContentPlaceHolder1_tipLocusTrue").style.display == "" ){
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
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="searchbox" style="line-height:25px; font-size:12px;">
<div style="margin-right:10px; margin-top:10px;">
              <fieldset style="border:1px solid #CCCCCC; padding-bottom:5px;">
              <legend style="color:#000000; font-weight:bold; font-size:14px;margin-left:5px;"> �޸����ĸ�����Ϣ </legend>
                <table border="0" cellpadding="4" cellspacing="0">
                <tr>
                  <td colspan="3" style="height:5px"></td>
                </tr>
                <tr>
                  <td width="80"><div align="right"><span >��ʵ����</span></div></td>
                  <td width="15"><span class="regRequired">*</span></td>
                  <td style="width: 651px"><div style="float:left;"><input name="RealName" type="text" class="textbox1" id="RealName" style="width:250px" onfocus="showTip('tipRealNameNormal','tipRealNameTrue','tipRealNameFalse')"  onblur="checkRequired('ctl00_ContentPlaceHolder1_RealName','tipRealNameNormal','tipRealNameTrue','tipRealNameFalse',1)" runat="server" /></div> <div class="tipNormal" id="tipRealNameNormal" style="display:none;"></div><div class="tipTrue" id="tipRealNameTrue"  style="display:none;">��д��ȷ��</div><div class="tipFalse" id="tipRealNameFalse" style="display:none;">�������</div></td>
                </tr>
                <tr style="display:none;">
                  <td><div align="right"><span >��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��</span></div></td>
                  <td><span class="regRequired">*</span></td>
                  <td style="width: 651px"><div style="float:left;"><input type="radio" name="Gender" value="��" id="GenderMale"  onclick="showTip('tipGenderTrue','tipGenderNormal','tipGenderFalse')" runat="server"/>
                    ���� 
                      <input type="radio" name="Gender" value="Ů" id="GenderFemale" onclick="showTip('tipGenderTrue','tipGenderNormal','tipGenderFalse')" runat="server" />
                      Ůʿ</div> <div class="tipNormal" id="tipGenderNormal" style="display:none;"></div><div class="tipTrue" id="tipGenderTrue"  style="display:none;">��д��ȷ��</div><div class="tipFalse" id="tipGenderFalse" style="display:none;">�������ѡ��</div></td>
                </tr>
                <tr>
                  <td><div align="right"><span >��˾����</span></div></td>
                  <td><span class="regRequired">*</span></td>
                  <td style="width: 651px"><div style="float:left;"><input name="CompanyName" type="text" class="textbox1" id="CompanyName" style="width:250px" onfocus="showTip('tipCompanyNameNormal','tipCompanyNameTrue','tipCompanyNameFalse')"  onblur="checkRequired('ctl00_ContentPlaceHolder1_CompanyName','tipCompanyNameNormal','tipCompanyNameTrue','tipCompanyNameFalse',1)" runat="server" /></div>
                  <div class="tipNormal" id="tipCompanyNameNormal" style="display:none;">Ϊ���������û���ϵ�������뾡����д��˾ȫ�ơ�</div><div class="tipTrue" id="tipCompanyNameTrue"  style="display:none;">��д��ȷ��</div><div class="tipFalse" id="tipCompanyNameFalse" style="display:none;">������д��˾���ơ�</div></td>
                </tr>
                <tr >
                  <td><div align="right">��˾����</div></td>
                  <td><span style="color: #ff6600">*</span></td>
                  <td style="width: 651px"><div style="float:left;"><select name="CompanyType" onfocus="showTip('tipCompanyType','tipCompanyTypeTrue','tipCompanyTypeFalse');"  onblur="checkCompanyType('ctl00_ContentPlaceHolder1_CompanyType','tipCompanyType','tipCompanyTypeTrue','tipCompanyTypeFalse',1)" id="CompanyType" runat="server" style="width:100px">
					  <%--<option value="0">��ѡ��</option>
                      <option value="1">����</option>
                      <option value="2">����</option>
                      <option value="3">����˾</option>
                      <option value="4">����</option>--%>
                      <option value="0">��ѡ��</option>
                      <option value="1">����</option>
                      <option value="2">����</option>
                      <option value="3">����</option>
                      <option value="5">����</option>
                      <option value="6">���</option>
                      <option value="7">��վ</option>
                      <option value="8">�ִ�</option>
                      <option value="9">����</option>
                      <option value="10">����</option>
                      <option value="4">����</option>
                  </select></div>
                  <div class="tipNormal" id="tipCompanyType" style="display:none;">��ѡ������˾�����͡�</div><div class="tipTrue" id="tipCompanyTypeTrue"  style="display:none;">��д��ȷ��</div><div class="tipFalse" id="tipCompanyTypeFalse" style="display:none;">����ѡ��˾���͡�</div></td>
                </tr>
                <tr>
                  <td><div align="right"><span >��������</span></div></td>
                  <td><span class="regRequired">*</span></td>
                  <td style="width: 651px"><div style="float:left;"><input name="UserEmail" id="UserEmail" type="text" class="textbox1" style="width:250px"  onfocus="showTip('tipUserEmailNormal','tipUserEmailTrue','tipUserEmailFalse')"  onblur="checkEmail('ctl00_ContentPlaceHolder1_UserEmail','tipUserEmailNormal','tipUserEmailTrue','tipUserEmailFalse',1)" runat="server" /></div>
                    <div class="tipNormal" id="tipUserEmailNormal" style="display:none;">Ϊ���������û���ϵ����������д��ȷ��Ч�ĵ��������ַ��</div><div class="tipTrue" id="tipUserEmailTrue"  style="display:none;">��д��ȷ��</div><div class="tipFalse" id="tipUserEmailFalse" style="display:none;">������д��������д��ȷ��Ч�ĵ��������ַ��</div><span id="err" style="color:#FF6600"></span></td>
                </tr>
                
                
                
                
                <tr>
                  <td><div align="right"><span >�绰����1</span></div></td>
                  <td><span class="regRequired">*</span></td>
                  <td>
                  <div style="float:left;">
                      
                      <input name="Phone" type="text" maxlength="50" id="Phone" style="width:150px" onfocus="showTip('tipPhoneNormal','tipPhoneTrue','tipPhoneFalse')"  onblur="PhoneOnblur('tipPhoneNormal','tipPhoneTrue','tipPhoneFalse');" runat="server" />
                     
                  </div>
                      
                  <div class="tipNormal" id="tipPhoneNormal" style="display:none;">
                      Ϊ���������û���ϵ����������д��ȷ��Ч�ĵ绰��</div><div class="tipTrue" id="tipPhoneTrue"  style="display:none;">��д��ȷ��</div><div class="tipFalse" id="tipPhoneFalse" style="display:none;">������д�绰��</div> </td>
                </tr>
                
                
                <tr>
                  <td><div align="right"><span >�绰����2</span></div></td>
                  <td></td>
                  <td>
                  <div style="float:left;">

                      <input name="Phone" type="text" maxlength="50" id="Phone2" style="width:150px" onfocus="showTip('tipPhone2Normal','tipPhone2True','tipPhone2False')"  onblur="Phone2Onblur('tipPhone2Normal','tipPhone2True','tipPhone2False');" runat="server" />
                      
                  </div>
                      
                  <div class="tipNormal" id="tipPhone2Normal" style="display:none;">
                      Ϊ���������û���ϵ����������д��ȷ��Ч�ĵ绰��</div><div class="tipTrue" id="tipPhone2True"  style="display:none;">��д��ȷ��</div><div class="tipFalse" id="tipPhone2False" style="display:none;">������д�����ĵ绰��</div> </td>
                </tr>
                
                
                
                
                <tr>
                  <td><div align="right">��˾���ڵ�</div></td>
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
                        <div class="tipNormal" id="tipLocusNormal" style="display:none;" runat="server">����д��ȷ��Ч�Ĺ�˾���ڵء�</div><div class="tipTrue" id="tipLocusTrue"  style="display:none;" runat="server">��д��ȷ��</div><div class="tipFalse" id="tipLocusFalse" style="display:none;" runat="server">������д�����Ĺ�˾���ڵء�</div> 
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    
                  </td>
                </tr>
                
                
                
                <tr>
                  <td><div align="right">�������</div></td>
                  <td></td>
                  <td style="width: 651px"><div style="float:left;"><input name="Fax" type="text" class="textbox1" id="Fax" style="width:250px" onfocus="showTip('tipFax','tipFaxTrue','tipFaxFalse')"  onblur="checkRequired('ctl00_ContentPlaceHolder1_Fax','tipFax','tipFaxTrue','tipFaxFalse',1);" runat="server" /></div>
                    <div class="tipNormal" id="tipFax" style="display:none;">Ϊ���������û���ϵ����������д��ȷ��Ч�Ĵ�����롣</div>
                    <div class="tipTrue" id="tipFaxTrue"  style="display:none;">��д��ȷ��</div>
                      <div class="tipFalse" id="tipFaxFalse" style="display:none;">������д�绰��</div>
                  </td>
                </tr>
                <tr>
                  <td><div align="right">�ֻ�����</div></td>
                  <td></td>
                  <td style="width: 651px"><div style="float:left;"><input name="MovePhone" type="text" class="textbox1" id="MovePhone" style="width:250px" onfocus="showTip('tipMovePhone','tipMovePhoneTrue','tipMovePhoneFalse')"  onblur="checkRequired('ctl00_ContentPlaceHolder1_MovePhone','tipMovePhone','tipMovePhoneTrue','tipMovePhoneFalse',1);" runat="server" /></div>
                    <div class="tipNormal" id="tipMovePhone" style="display:none;">Ϊ���������û���ϵ����������д��ȷ��Ч���ֻ����롣</div>
                    <div class="tipTrue" id="tipMovePhoneTrue"  style="display:none;">��д��ȷ��</div>
                      <div class="tipFalse" id="tipMovePhoneFalse" style="display:none;">������д�绰��</div>
                  </td>
                </tr>
                <tr>
                  <td><div align="right">��ϵ��ַ</div></td>
                  <td>&nbsp;</td>
                  <td style="width: 651px"><div style="float:left;"><input name="Address" type="text" class="textbox1" id="Address" style="width:250px" onfocus="showTip1('tipAddress')"  onblur="hideTip1('tipAddress')" runat="server" /></div>
                    <div class="tipNormal" id="tipAddress" style="display:none;">Ϊ���������û���ϵ����������д��ȷ��Ч����ϵ��ַ��</div></td>
                </tr>
                <tr>
                  <td><div align="right">��������</div></td>
                  <td>&nbsp;</td>
                  <td style="width: 651px"><div style="float:left;"><input name="PostNumber" type="text" class="textbox1" id="PostNumber" style="width:100px" onfocus="showTip1('tipPostNumber')"  onblur="hideTip1('tipPostNumber')" runat="server" /></div>
                    <div class="tipNormal" id="tipPostNumber" style="display:none;">Ϊ���������û���ϵ����������д��ȷ��Ч���������롣</div></td>
                </tr>
                    <tr>
                        <td style="text-align: right">
                            QQ</td>
                        <td>
                        </td>
                        <td style="width: 651px">
                            <div style="float:left;"><input name="txtQQ" type="text" class="textbox1" id="txtQQ" style="width:250px" onfocus="showTip1('tipQQ')"  onblur="hideTip1('tipQQ')" runat="server" /></div>
                            <div class="tipNormal" id="tipQQ"  style="display:none;">
                                Ϊ���������û���ϵ����������д��ȷ��Ч��QQ���롣</div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            MSN</td>
                        <td>
                        </td>
                        <td style="width: 651px">
                            <div style="float:left;"><input name="txtMSN" type="text" class="textbox1" id="txtMSN" style="width:250px" onfocus="showTip1('tipMSN')"  onblur="hideTip1('tipMSN')" runat="server" /></div>
                            <div class="tipNormal" id="tipMSN"  style="display:none;">
                                Ϊ���������û���ϵ����������д��ȷ��Ч��MSN���롣</div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            ����ǩ��</td>
                        <td>
                        </td>
                        <td style="width: 651px">
                            <div style="float:left;"><input name="txtsign" type="text" class="textbox1" id="txtsign" style="width:250px" onfocus="showTip('tipsignNormal','tipsignTrue','tipsignFalse')"  onblur="checkSign('ctl00_ContentPlaceHolder1_txtsign','tipsignNormal','tipsignTrue','tipsignFalse',1)" runat="server" /></div>
                            <div class="tipNormal" id="tipsignNormal" style="display:none;">
                                ����Ϊ����̳�У�����һ������ǩ����</div>
                            <div class="tipTrue" id="tipsignTrue"  style="display:none;">
                                ��д��ȷ��</div>
                            <div class="tipFalse" id="tipsignFalse" style="display:none;">
                                ����С��50���ַ�</div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            ��˾���</td>
                        <td>
                        </td>
                        <td style="width: 651px">
                        <div style="float:left;">
                        <textarea name="txtintroduction" type="text"  class="textbox1" id="txtintroduction" style="width:250px; height: 80px;" onfocus="showTip('tipintroductionNormal','tipintroductionTrue','tipintroductionFalse')"  onblur="checkIntroduction('ctl00_ContentPlaceHolder1_txtintroduction','tipintroductionNormal','tipintroductionTrue','tipintroductionFalse',1)" runat="server" />
                        <%--<input  />--%>
                        </div>
                            <div class="tipNormal" id="tipintroductionNormal" style="display:none;">
                                ����Ϊ���˼�����һ����˾��顣</div>
                            <div class="tipTrue" id="tipintroductionTrue"  style="display:none;">
                                ��д��ȷ��</div>
                            <div class="tipFalse" id="tipintroductionFalse" style="display:none;">
                                ����С��500���ַ�</div>    
                            
                            
                        </td>
                    </tr>
                <tr>
                    <td><div align="right">ͷ��</div></td>
                    <td></td>
                    <td style="width: 651px; border-width:0px; " >
                        <div style="float:left">
                            <table style="float:left ;  border-width:0px; ">
                            <tr>
                                <td><asp:FileUpload ID="FileUpload1" runat="server" Width="192px" onfocus="showTip('tipheadNormal','tipheadTrue','tipheadFalse')" onblur="checkPicture('ctl00_ContentPlaceHolder1_FileUpload1','tipheadNormal','tipheadTrue','tipheadFalse',1)"  /></td>
                                <td style="text-align:center;"><asp:Image ID="Imghead" runat="server" Height="70px" ImageUrl="~/member/Head/default.jpg" Width="70px" /></td>
                                <td style="text-align:center; ">
                                    <div class="tipNormal" id="tipheadNormal" style=" float:left; display:none; width: 279px;margin-left:5px">
                                        ����Ϊ����̳�е�ͷ���ϴ�һ��ͼƬ(JPG��GIF��ʽ)</div>
                                    <div class="tipTrue" id="tipheadTrue"  style="display:none;margin-left:5px">
                                            ��д��ȷ��</div>
                                    <div class="tipFalse" id="tipheadFalse" style="display:none;margin-left:5px">
                                            ����ΪJPG��GIF��ʽ��ͼƬ��</div>
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
              <fieldset style="border:1px solid #CCCCCC;display:none" >
              <legend style="color:#999999"> ����VIP��Ա </legend>
                <table width="540" border="0" cellpadding="5" cellspacing="1">
                <tr>
                  <td width="100"><div align="right">VIP��Ա&nbsp;&nbsp;&nbsp;&nbsp;</div></td>
                  <td width="417"><table width="189" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="25"><span class="tablebody1">
                          <input name="ifvip" type="checkbox" class="InputTxt" id="ifvip" value="1" checked="checked" />
                        </span></td>
                        <td width="40">����</td>
                        <td width="124"><span class="regRequired">VIP��Ա�ɷ����˼�</span></td>
                      </tr>
                  </table></td>
                </tr>
              </table>
            </fieldset>
			  <div align="center"><br />
                  <input name="Submit" type="button" class="InputBtn" value="�ύ�޸���Ϣ" style="width:120px; height:30px; line-height:25px; font-size:12px;"  id="Button1" runat="server" />
			    &nbsp;&nbsp;&nbsp;
                  <asp:Button ID="Button3" runat="server" Text="Button" CssClass="hidden" />
                  <input name="Submit2" type="button" class="InputBtn" value="������ҳ" style="width:120px; height:30px;  line-height:25px; font-size:12px;" id="Button2" runat="server" />
		  </div>
		  <br />
		  <br />
		  <br />
		  <br />
		  <br />
		</div>
</div>
</asp:Content>

