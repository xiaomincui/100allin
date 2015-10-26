<!--#include file="../include/include_all.asp"-->
<%
if Request.Cookies("user_id")="" then response.Redirect("../JumpHome.html")

ID = CheckNumber(Request.QueryString("ID"))

if ID <> "" then
Set Rs= Server.CreateObject("ADODB.Recordset")
Sql = "SELECT * FROM TB_AIRGOODS WHERE ID = " &ID& ""
Rs.open sql,conn,1,1

if not Rs.eof then
ID = Rs("ID")
UserID = Rs("UserID")
if trim(UserID) <> trim(Request.Cookies("user_id")) then response.Redirect("/search/err.aspx")
title = Rs("title")
endtime = Rs("LAUNCHDATE")
types = Rs("types")
type1 = Rs("type")
nums = Rs("AMOUNT")
ddlPayType = Rs("PAYMENT")
tbGoodsName = Rs("NAME")
ddlline = Rs("LINE")
price = Rs("price")
StartPort = Rs("StartPort")
CityName = Rs("DestPort")
tbremark = Rs("DESCRIPTION")
posttime = Rs("POSTDATE")
rbldange = Rs("ISDANGER")
showtel = rs("showtel")
showmo = rs("showmo")
showadd = rs("showadd")
showemail = rs("showemail")
showcom = rs("showcom")
hits = rs("hits")
end if
end if

%>
<html>
<style type="text/css">
<!--
.textbox1 {
	height: 20px;
	border: 1px solid #CCCCCC;
}
.STYLE2 {color: #000000}
.STYLE6 {
	color: #27A1CF;
	font-size: 14px;
	font-weight: bold;
}
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
body,td,th {
	font-size: 12px;
}
.STYLE5 {color: #FF6600}
.STYLE3 {color: #999999}
#cities {
	position:absolute;
	height:0px;
	z-index:1;
	border: 1px solid #bbbbbb;
}
-->
</style>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>环球运费网</title>
<script language="javascript">
<!--
var keyst = 0
var lastcontent=""; 
function AutoComp()
{ 
var destcity = document.frmMain.CityName.value;
if(destcity != lastcontent){
	lastcontent = destcity; 
}
else
	return true; 
var xmlObj = false;
var xmlResult;
try {
    xmlObj=new XMLHttpRequest;
}catch(e) {
    try {
        xmlObj=new ActiveXObject("MSXML2.XMLHTTP");
    } catch(e2) {
        try {
            xmlObj=new ActiveXObject("Microsoft.XMLHTTP");
        }catch(e3) {
            xmlObj=false;
        }
    }
}
if (!xmlObj) {
    window.alert("XMLHttpRequest init Failed!");
}
 xmlObj.open ("GET", "/airportsearch.asp?begin="+lastcontent, true);
    xmlObj.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
    xmlObj.onreadystatechange=function() {
        if(xmlObj.readyState==4) {
            if(xmlObj.status==200) {
                cities.innerHTML=xmlObj.responseText;
					if(cities.innerHTML == ""){
						HideCity();
					}
					else{
						ShowCity();
					}
            }
        }
    }
    xmlObj.send(null);
}	
function SelectCity(city)
{
if(keyst==0){
	cities.innerHTML="";
	document.frmMain.CityName.value = city;
	lastcontent = city;
	document.getElementById("CityName").focus();
	HideCity();
	}
else{
	document.frmMain.CityName.value = select111.value;
}
keyst = 0;
}




function ShowCity(){
	document.getElementById("cities").style.visibility = "";
}
function HideCity(){
	document.getElementById("cities").style.visibility = "hidden";
}

function ShowCity1(){
	if(cities.innerHTML != ""){	
	ShowCity();
	}
}
function HideCity1(){
	HideCity();
}


function setfocus() {
if(event.keyCode==40 & cities.innerHTML!=""){
	keyst = 1;
	document.getElementById("select111").focus();
	}
} 
function setkey() {
ShowCity();
if(event.keyCode ==13){
	keyst = 0;
	SelectCity(select111.value);
	}
else{
	keyst = 1;
	}
}


function setyunjialeixing() {
var y
y = <%=Request.QueryString("yunjialeixing")%> + "";
if (y != ""){
	document.getElementById("yunjialeixing").value = y;
	frmMain.action = "price_lcl_list_sub.asp?yunjialeixing="+y;
	document.getElementById("yunjialeixing").style.display = "none";
	document.getElementById("toGoods").style.display = "none";
	switch (y){
		case "8": 
			document.getElementById("selYunjia").innerHTML = "整箱价格";
			return
		case "9": 
			document.getElementById("selYunjia").innerHTML = "拼箱价格";
			return
		case "10": 
			document.getElementById("selYunjia").innerHTML = "散杂件价格";
			return
		}
	}
}

function setpricetype() {
var y
y = document.getElementById("yunjialeixing").value;
	switch (y){
		case "8": 
			document.getElementById("pricetype").style.display = "";
			return
		case "9": 
			document.getElementById("pricetype").style.display = "none";
			document.frmMain.pricetype.value="";			
			return
		case "10": 
			document.getElementById("pricetype").style.display = "none";
			document.frmMain.pricetype.value="";
			return
		}

}


function   getDim(el){   
var rd = {x:0,y:0}   
do{   
	rd.x += el.offsetLeft   
	rd.y += el.offsetTop   
	el = el.offsetParent   
	}while(el)   
return rd   
}
  
function test(){
var mySpanDim
mySpanDim = getDim(document.getElementById("CityName"));
document.getElementById("cities").style.left = mySpanDim.x+"px"
document.getElementById("cities").style.top = mySpanDim.y+19+"px"
}


function UseVal(p,d,m){
var v
v = p.value
if (v ==""){
p.dataType =""
p.msg =""
}
else{
p.dataType = d
p.msg = m
}
}

function sendCheckbox(c,h){
	if (document.getElementById(c).checked == 1) {
		document.getElementById(h).value = "1"
	}
	else {
		document.getElementById(h).value = "0"
	}
}

-->
</script>


</head>

<body onLoad="test()">
<div id="cities" name="cities" style="visibility:hidden"></div>
<form name="frmMain" method="post" action="AirGoodsAction.asp?type=<%=request.QueryString("type")%>"  onSubmit="return Validator.Validate(this,1)">
  <table width="90%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td height="30"><span class="STYLE6">
		<%if request.QueryString("type") = "1" then%>
海运货盘发布管理
		<%else%>
航空货盘发布管理
	    <%end if%>	  
	  
	  
	  </span></td>
    </tr>
    <tr>
      <td height="5"></td>
    </tr>
  </table>

<table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#E8E8E8" class="bgTbTop">
	<tr align="left" bgcolor="#F6F6F6" class="news_font" >
       	<td width="184" height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2">货盘信息标题&nbsp;&nbsp;</span></div></td>
   	  <td width="914" bgcolor="#FFFFFF"><input name="title" type="text"  id="title" value="<%=title%>" size="30" maxlength="50"style="width:200px" >		</td>
    </tr>
	<tr bgcolor="#F6F6F6" class="news_font">
	  <td height="30" bgcolor="#FFFFFF" class="bgTdMain"><div align="right"><span class="STYLE2">点击量&nbsp;&nbsp;</span></div></td>
	  <td bgcolor="#FFFFFF" class="bgTdMain"><%=hits%></td>
    </tr>
	<tr bgcolor="#F6F6F6" class="news_font">
      <td height="30" bgcolor="#FFFFFF" class="bgTdMain"><div align="right"><span class="STYLE2"><strong>出运日期</strong><span class="STYLE5">*</span>&nbsp;&nbsp; </span></div></td>
	  <td bgcolor="#FFFFFF" class="bgTdMain"><input name="endtime" type="text" class="InputTxt" value="<%=endtime%>"  id="endtime" dataType="Date" msg="出运日期格式不正确" style="width:100px" readonly="readonly"   >
	    &nbsp; <A onclick=event.cancelBubble=true; href="javascript:showCalendar('imageCalendar1',false,'endtime',null);"> <IMG id=imageCalendar1 height=21 src="../web_Admin/images/button.gif" width=34 align=absMiddle border=0></A> <span class="STYLE3">时间格式为“年-月-日 时:分:秒”，如： <%=date()%></span> </td>
    </tr>
	<tr align="left" bgcolor="#F6F6F6" class="news_font">
      <td height="30" bgcolor="#FFFFFF"><div align="right" class="STYLE2">货源&nbsp;&nbsp;</div></td>
	  <td bgcolor="#FFFFFF"><select name="types" style="width:100px">
          <option value="直客" <%if types="直客" then%> selected<%end if%>>直客</option>
          <option value="同行" <%if types="同行" then%> selected<%end if%>>同行</option>
        </select>
	    &nbsp;
		<%if request.QueryString("type") = "1" then%>
		  <input type="hidden" name="typem" value="海运货盘">
		<%else%>
		  <input type="hidden" name="typem" value="空运货盘">
	    <%end if%></td>
    </tr>
	<tr align="left"  bgcolor="#F6F6F6" class="news_font">
		<td height="30" bgcolor="#FFFFFF"><div align="right" class="STYLE2">类型&nbsp;&nbsp;</div></td>
		<td bgcolor="#FFFFFF">
		<%if request.QueryString("type") = "1" then%>
		  <select name="type" style="width:100px">
		  <option value="整箱" <%if type1 = "整箱" then response.Write("selected")%>>整箱</option>
		  <option value="拼箱" <%if type1 = "拼箱" then response.Write("selected")%>>拼箱</option>
		  </select>
		<%else%>
		  <select name="type" style="width:100px">
		  <option value="暂无" <%if type1 = "暂无" then response.Write("selected")%>>暂无</option>
		  <option value="平货" <%if type1 = "平货" then response.Write("selected")%>>平货</option>
		  <option value="泡货" <%if type1 = "泡货" then response.Write("selected")%>>泡货</option>
		  </select>
	    <%end if%>

		  &nbsp;</td>
	</tr>
	<tr align="left"  bgcolor="#F6F6F6" class="news_font">
		<td height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2"><strong>货量</strong><span class="STYLE5">*</span>&nbsp;&nbsp;</span></div></td>
		<td bgcolor="#FFFFFF"><input name="nums" type="text" class="InputTxt" id="nums" value="<%=nums%>" size="30" maxlength="60" dataType="Require" msg="请填写货量" style="width:200px">
			&nbsp;</td>
	</tr>
	<tr align="left"  bgcolor="#F6F6F6" class="news_font">
		<td height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2">运费支付方式&nbsp;&nbsp;</span></div></td>
		<td bgcolor="#FFFFFF" ><select name="ddlPayType" id="ddlPayType" style="width:100px;">
				<option value="预付" <%if ddlPayType="预付" then%> selected<%end if%>>预付</option>
				<option value="到付" <%if ddlPayType="到付" then%> selected<%end if%>>到付</option>
				<option value="其它" <%if ddlPayType="其它" then%> selected<%end if%>>其它</option>
			</select></td>
	</tr>
	<!--
	<tr align="left"  bgcolor="#F6F6F6" class="news_font">
		<td height="30" bgcolor="#F6F6F6"><strong>　商品所在地：</strong></td>
		<td>
			  <input name="tbGoodsAddr" type="text" id="tbGoodsAddr" value="<%=tbGoodsAddr%>" size="30" maxlength="60" class="InputTxt" style="border:#A7A6AA 1px solid; line-height:120%;">
			<FONT color="#ff0000">*</FONT>&nbsp;<span class="black12">（如：上海祝贺街35号）</span>
		</td>
	</tr>
	-->
	<tr align="left" bgcolor="#F6F6F6" class="news_font" >
        <td height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2"><strong>货物名称</strong><span class="STYLE5">*</span>&nbsp;&nbsp;</span></div></td>
        <td bgcolor="#FFFFFF"><input name="tbGoodsName" type="text" class="InputTxt" id="tbGoodsName" value="<%=tbGoodsName%>" size="30" maxlength="50"  dataType="Require" msg="请填写货盘名称" style="width:100px"  ></td>
    </tr>
                <tr bgcolor="#F6F6F6" class="news_font"> 
                  <td height="30" bgcolor="#FFFFFF" class="bgTdMain"><div align="right" class="STYLE2">出货航线&nbsp;&nbsp;</div></td>
                  <td bgcolor="#FFFFFF" class="bgTdMain"><select name="ddlline" id="ddlline" style="width:200px;">
	<option selected="selected" value="CHINA-WEST AMERICA">中国-美西</option>
	<option value="CHINA-EAST AMERICA" <%if ddlline="CHINA-EAST AMERICA" then%>selected<%end if%>>中国-美东</option>
	<option value="CHINA-MIDDLE SOUTH AMERICA" <%if ddlline="CHINA-MIDDLE SOUTH AMERICA" then%>selected<%end if%>>中国-中南美</option>
	<option value="CHINA-EURO/MED" <%if ddlline="CHINA-EURO/MED" then%>selected<%end if%>>中国-欧地</option>
	<option value="CHINA-AFRICA" <%if ddlline="CHINA-AFRICA" then%>selected<%end if%>>中国-非洲</option>
	<option value="CHINA-JAPAN" <%if ddlline="CHINA-JAPAN" then%>selected<%end if%>>中国-日本</option>
	<option value="CHINA-KOREA" <%if ddlline="CHINA-KOREA" then%>selected<%end if%>>中国-韩国</option>
	<option value="CHINA-RUSSIA/FAR EAST" <%if ddlline="CHINA-RUSSIA/FAR EAST" then%>selected<%end if%>>中国-俄罗斯远东</option>
	<option value="CHINA-SOUTHEASTASIA" <%if ddlline="CHINA-SOUTHEASTASIA" then%>selected<%end if%>>中国-东南亚</option>
	<option value="CHINA-MIDDLE EAST/PERSIAN GULF" <%if ddlline="CHINA-MIDDLE EAST/PERSIAN GULF" then%>selected<%end if%>>中国-中东/波斯湾</option>
	<option value="CHINA-AUSTRALIA" <%if ddlline="CHINA-AUSTRALIA" then%>selected<%end if%>>中国-澳洲</option>
	<option value="CHINA-香港" <%if ddlline="CHINA-香港" then%>selected<%end if%>>中国-中国香港</option>
	<option value="CHINA-MACAO" <%if ddlline="CHINA-MACAO" then%>selected<%end if%>>中国-中国澳门</option>
	<option value="CHINA-TAIWANG" <%if ddlline="CHINA-TAIWANG" then%>selected<%end if%>>中国-中国台湾</option>
	<option value="THE WHOLE WORLD" <%if ddlline="THE WHOLE WORLD" then%>selected<%end if%>>环球航线</option>
	<option value="其它" <%if ddlline="其它" then%>selected<%end if%>>其它航线</option>
</select></td>
            </tr>
				<tr align="left"  bgcolor="#F6F6F6" class="news_font">
                  <td height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2">属危险品&nbsp;&nbsp;</span></div></td>
                  <td bgcolor="#FFFFFF"><input name="rbldange" type="radio" id="rbldange_0" value="0" <%if rbldange=false then%>checked<%end if%> />
				  <label for="rbldange_0">否</label>
				  <input id="rbldange_1" type="radio" name="rbldange" value="1" <%if rbldange=true then%>checked<%end if%> />
				  <label for="rbldange_1">是</label>                  </td>
            </tr>
                <tr align="left"  bgcolor="#F6F6F6" class="news_font" style="display:none">
                  <td height="30" bgcolor="#FFFFFF"><div align="right">目标价格&nbsp;&nbsp;</div></td>
                  <td bgcolor="#FFFFFF"><input name="price" type="text" class="InputTxt" id="price" value="<%=price%>" size="10" maxlength="10" > 
                    <span class="STYLE3">单位为美元</span> </td>
            </tr>
				
                <tr align="left" bgcolor="#F6F6F6" class="news_font">
                  <td height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2">启运港&nbsp;&nbsp;</span></div></td>
                  <td bgcolor="#FFFFFF"><input  name="StartPort" type="text" value="<%=StartPort%>"/></td>
            </tr>
                <tr align="left"  bgcolor="#F6F6F6" class="news_font">
                  <td height="30" bgcolor="#FFFFFF"><div align="right"><span class="STYLE2">目的港&nbsp;&nbsp;</span></div></td>
                  <td bgcolor="#FFFFFF"><span class="bgTdMain">
                    <input type="text" name="CityName"  id="CityName" onFocus="ShowCity1()"  onkeyup="AutoComp();"  onkeydown="setfocus()" style="width:144px" value = "<%=CityName%>"/>
                  </span> </td>
            </tr>
				
						     <tr bgcolor="#F6F6F6" class="news_font">
                  <td height="85" valign="middle" bgcolor="#FFFFFF"  class="bgTdMain"><div align="right"><span class="STYLE2">货盘描述&nbsp;&nbsp; </span></div></td>
                  <td bgcolor="#FFFFFF" class="bgTdMain"><textarea name="tbremark" id="tbremark" style="height:80px;width:320px;" class="InputTxt" ><%=tbremark%></textarea>
                    <span class="black12 STYLE3"> </span>                  </td>
			</tr>
                             <tr valign="middle" bgcolor="#F6F6F6" class="news_font">
                               <td align="center" bgcolor="#FFFFFF" class="bgTdMain"><div align="right"><span class="STYLE2">联系方式设定&nbsp;&nbsp; </span></div></td>
                               <td bgcolor="#FFFFFF" class="bgTdMain">在货盘中显示以下联系方式 (以下选项可复选，可不选)：<br>
                                   <input name="chkTel" type="checkbox" id="chkTel" value="1" onClick="sendCheckbox('chkTel','txtTelc');" <%if showtel <> 0 or request.QueryString("id") = "" then%>checked<%end if%>>
                                 电话 
                                 <input name="txtTelc" type="hidden" id="txtTelc" value="<%if request.QueryString("id") = "" then response.write("1") else response.write(showtel)%>">
                                 <br>
                                 <input name="chkMobile" type="checkbox" id="chkMobile" value="1" onClick="sendCheckbox('chkMobile','txtMobilec');" <%if showmo <> 0 or request.QueryString("id") = "" then%>checked<%end if%>>
                                 手机 <input name="txtMobilec" type="hidden" id="txtMobilec" value="<%if request.QueryString("id") = "" then response.write("1") else response.write(showmo)%>">
                                 <br>
                                 <input name="chkAddress" type="checkbox" id="chkAddress" value="1" onClick="sendCheckbox('chkAddress','txtAddressc');" <%if showadd <> 0 or request.QueryString("id") = "" then%>checked<%end if%>>
                                 地址 <input name="txtAddressc" type="hidden" id="txtAddressc" value="<%if request.QueryString("id") = "" then response.write("1") else response.write(showadd)%>">
                                 <br>
                                 <input name="chkEmail" type="checkbox" id="chkEmail" value="1" onClick="sendCheckbox('chkEmail','txtEmailc');" <%if showemail <> 0 or request.QueryString("id") = "" then%>checked<%end if%>>
                                 电子邮箱 <input name="txtEmailc" type="hidden" id="txtEmailc" value="<%if request.QueryString("id") = "" then response.write("1") else response.write(showemail)%>">
                                 <br>
                                 <input name="chkCompany" type="checkbox" id="chkCompany" value="1" onClick="sendCheckbox('chkCompany','txtCompanyc');" <%if showcom <> 0 or request.QueryString("id") = "" then%>checked<%end if%>>
                                 公司名称 
                                 <input name="txtCompanyc" type="hidden" id="txtCompanyc" value="<%if request.QueryString("id") = "" then response.write("1") else response.write(showcom)%>"></td>
                             </tr>
                <tr valign="middle" bgcolor="#F6F6F6" class="news_font"> 
                  <td height="50" colspan="2" align="center" bgcolor="#FFFFFF" class="bgTdMain"><span class="tablebody1">
                  </span>                                      
				    <span class="tablebody1">
				    <input name="posttime" type="hidden"  id="posttime" 	<% if posttime = "" then 
	  response.Write("value='"&date()&"'")
	  else
	  response.Write("value='"&posttime&"'")
	  end if
	  %>

	>
				    <input name="ID" type="hidden" id="ID" value="<%=ID%>">
					<input name="SubName" type="hidden">
                    </span>
                    <input name="Action" type="hidden" id="Action" 
					  <% if ID = "" or id = "0" then 
					  response.Write("value='Add'")
					  else
					  response.Write("value='Edit'")
					  end if
					  %>
					  >   
					
					<input type="submit" value="完成" onClick="javascript:frmMain.SubName.value='SubEnd'">
					&nbsp;&nbsp;
			      <input name="Submit2" type="button" class="InputBtn" value="返回" onclick=history.back()></td>
    </tr>
  </table>
<table width="98%"  border="0" cellspacing="0" cellpadding="0">
  <TR>
    <TD height="30" align="center" class="news_font STYLE5"> 以上信息由企业自行提供，该企业负责信息内容的真实性、准确性和合法性。我们对此不承担任何保证责任</TD>
  </TR>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>
<br>

</form>
</body>
</html>

