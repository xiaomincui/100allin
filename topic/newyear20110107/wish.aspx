<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wish.aspx.cs" Inherits="topic_newyear20110107_wish" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>新年祝福 - 环球运费网</title>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background:#8E0000 url(/images2/newyear/nw1.jpg) repeat-x top;
}

.box{ border:1px solid #980108; width:358px; height:153px;}

.t1{ color:#666666; font-size:12px;}
	.t1 a{ color:#666666; font-size:12px; text-decoration:none;}
.t2{ color:#000; font-size:22px;}
	.t2 .disabled{color:#999999; display:none;}
	.t2 .current{font-weight:bold;color:#FF2255;}
	.t2 a{ font-size:22px; text-decoration:underline;color:#FF2255;font-weight:bold;}
	.t2 span{margin:0px 5px 0px 5px;}
	
-->
</style>

<script>
function check1(){
if (document.getElementById("TEXTAREA1").value == "")
{
alert("请填写您的祝福语！");
document.getElementById("TEXTAREA1").focus();
}
else
{
document.getElementById("wish1").style.display = "none";
document.getElementById("wish2").style.display = "";
}
}

function check2(){
if (document.getElementById("Text1").value == "")
{
alert("请填写您的公司名称！");
document.getElementById("Text1").focus();
}
else
{
document.getElementById("Button1").click();
}
}
</script>
</head>

<body>
<form runat="server" id="form1">
<table width="958" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="123" height="42"><a href="/"><img src="/images2/newyear/nw3.jpg" width="123" height="42" border="0" /></a></td>
    <td width="835" align="right" class="t1"><span style="display:none;">欢迎您!&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">登录</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">免费注册</a>&nbsp;&nbsp;</span></td>
  </tr>
  <tr>
    <td colspan="2"><img src="/images2/newyear/nw2.jpg" width="958" height="259" /></td>
  </tr>
  <tr>
    <td colspan="2"><img src="/images2/newyear/nw4.jpg" width="958" height="62" border="0" usemap="#Map" /></td>
  </tr>
  <tr>
    <td colspan="2" background="/images2/newyear/nw5.jpg" style="padding:10px 20px 0px 25px; line-height:28px; color:#333333; font-size:14px;" align="center">
    <br/>
	<div class="box" id="wish1">
	  <table width="358" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td><img src="/images2/newyear/nw7.jpg" width="339" height="36" /><a href="#"><img src="/images2/newyear/nw8.jpg" width="19" height="36" border="0" /></a></td>
        </tr>
        <tr>
          <td height="88" bgcolor="#FFDEDF" ><textarea name="textfield" style="border:none; width:350px; height:78px; background:url(images/ad/nw11.gif) no-repeat top; padding:4px;" id="TEXTAREA1" runat="server"></textarea></td>
        </tr>
        <tr>
          <td><img src="/images2/newyear/nw9.jpg" width="285" height="29" /><a href="javascript:check1();"><img src="/images2/newyear/nw10.jpg" width="73" height="29" border="0" /></a></td>
        </tr>
      </table>
	</div>
	<div style="width:360px; height:155px;display:none;" id="wish2">
	  <table width="360" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td colspan="2"><img src="/images2/newyear/nw16.gif" width="360" height="66" /></td>
        </tr>
        <tr>
          <td width="296" height="41" background="/images2/newyear/nw17.gif">&nbsp;&nbsp;&nbsp;
          <input style=" border:1px solid #fff; width:260px; height:30px; line-height:30px;" type="text" name="textfield2" id="Text1"  runat="server" /></td>
          <td width="64"><a href="javascript:check2();"><img src="/images2/newyear/nw18.gif" width="64" height="41" border="0" /></a></td>
        </tr>
        <tr>
          <td colspan="2"><img src="/images2/newyear/nw19.gif" width="234" height="48" /><a href="/accounts/login.aspx"><img src="/images2/newyear/nw20.gif" width="126" height="48" border="0" /></a></td>
        </tr>
      </table>
	</div>	
        <div style="display:none;"><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /></div>
    </td>
  </tr>
  <tr>
    <td height="40" colspan="2" align="right" background="/images2/newyear/nw5.jpg" class="t2">&nbsp;&nbsp;&nbsp;&nbsp;</td>
  </tr>
  <tr>
    <td colspan="2"><img src="/images2/newyear/nw6.jpg" width="958" height="16" /></td>
  </tr>
</table>
<table width="958" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td align="center" style="color:#FFCC00; line-height:24px; font-size:12px;">Copyright 2007-2011 100Allin.com All Rights Reserved<br />
    沪ICP备07510944号</td>
  </tr>
</table>

<map name="Map" id="Map">
<area shape="rect" coords="806,10,942,56" href="wish.aspx" />
</map>
</form>
</body>
</html>