<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="topic_newyear20110107_Default" %>
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

.t1{ color:#666666; font-size:12px;}
	.t1 a{ color:#666666; font-size:12px; text-decoration:none;}
.t2{ color:#000; font-size:22px;}
	.t2 .disabled{color:#999999; display:none;}
	.t2 .current{font-weight:bold;color:#FF2255;}
	.t2 a{ font-size:22px; text-decoration:underline;color:#FF2255;font-weight:bold;}
	.t2 span{margin:0px 5px 0px 5px;}
	.t3 a{ color:#333333; text-decoration:underline;}	
	.t3 a:hover{ color:#333333; text-decoration:underline;}	
-->
</style>


</head>

<body>
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
    <td colspan="2" background="/images2/newyear/nw5.jpg" style="padding:10px 20px 0px 25px; line-height:28px; color:#333333; font-size:14px;" class="t3">
      <asp:Repeater ID="Rptzhufu" runat="server">
      <ItemTemplate>
         <p> <b><%#Eval("userid").ToString() == "0" ? Eval("companyname").ToString() : "<a href=\"/company/" + setkey(Eval("userid").ToString()) + "/\" target=\"_blank\">" + Eval("companyname").ToString() + "</a>"%></b> 发来贺电：<br/>
          <%#(Eval("zhufu").ToString())%></p>
      </ItemTemplate>
      </asp:Repeater>
    </td>
  </tr>
  <tr>
    <td height="40" colspan="2" align="right" background="/images2/newyear/nw5.jpg" class="t2"><%=pagecontrol_string %>&nbsp;&nbsp;&nbsp;&nbsp;</td>
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
<script>
var success = <%=success %>
if (success == 1)
{
alert("您的祝福发布成功！");
}
</script>
</body>
</html>