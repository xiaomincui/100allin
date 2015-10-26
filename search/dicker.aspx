<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dicker.aspx.vb" Inherits="search_dicker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>讨价还价</title>
<link href="/css/fcl_css.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.divexcees {
    text-overflow:ellipsis;
    overflow: hidden;
}

.divexcees a:link {
	color: #293B5E;
	text-decoration: underline;
}
.divexcees a:visited {
	text-decoration: underline;
	color: #293B5E;
}
.divexcees a:hover {
	text-decoration: underline;
	color: #FF6600;
}
.divexcees a:active {
	text-decoration: underline;
	color: #293B5E;
}
.hidden {
    display:none;
}
</style>
<script type="text/javascript" language="javascript">
function   Close()   
{   
var   ua   =   navigator.userAgent; 
var   ie   =   navigator.appName   ==   "Microsoft   Internet   Explorer "   ?   true   :   false; 
if   (ie)   
{   
var   IEversion   =   parseFloat(ua.substring(ua.indexOf( "MSIE   ")+5,ua.indexOf( "; ",ua.indexOf( "MSIE   "))))   
if   (IEversion   <   5.5)   
{   
var   str   =   ' <object   id=noTipClose   classid= "clsid:ADB880A6-D8FF-11CF-9377-00AA003B7A11 "> '; 
str   +=   ' <param   name= "Command "   value= "Close "> </object> ';   
document.body.insertAdjacentHTML( "beforeEnd ",   str);   
document.all.noTipClose.Click();   
}   
else   
{   
window.opener   =   null;   
window.close();   
}   
}   
else   
{   
window.close()   
}   
} 
</script>
</head>

<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="main_container"><!--页面主体开始-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />您现在的位置:<a href="/" target="_blank">首页</a> > 讨价还价</h1>
			<userservice:userservice ID="userservice1" runat="server" />
		</div><!--导航结束-->
		<div class="main_content"><!--中部开始-->
			<div class="main_left" style="background:url(images/fcl/info_bg.gif) no-repeat left top;"><!--左边开始-->
			<div style="clear:both;">
		      <table width="92%" border="0" align="center" cellpadding="3" cellspacing="1" style="background:url(images/fcl/33.gif) no-repeat right 65px;">
                <tr>
                  <td height="10" colspan="2" align="center"></td>
                </tr>
				<tr>
                  <td height="32" colspan="2" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images/fcl/jt2.gif" />&nbsp;<strong>讨价还价</strong></div></td>
                </tr>
				<tr>
                  <td height="10" colspan="2" align="center" ></td>
				</tr>
                <tr>
                  <td width="20%" height="28" align="right" style=" line-height:22px;" valign="top"><span class="orange"><strong>您想要询价的公司</strong></span>:</td>
                  <td width="67%" style=" line-height:22px;" valign="top">
                      <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div><%#Eval("CompanyName")%> [<%#Eval("RealName")%>]</div>
                        </ItemTemplate>
                      </asp:Repeater>
                      <br />
                      <asp:TextBox ID="TextBox10" runat="server" CssClass="hidden"></asp:TextBox><asp:TextBox ID="TextBox13" runat="server" CssClass="hidden"></asp:TextBox></td>
                </tr>
                </table> 
                <asp:Panel ID="Panel1" runat="server" >
                <table width="92%" border="0" align="center" cellpadding="3" cellspacing="1">
                <tr>
                  <td width="20%" height="28" align="right"><span class="orange"><strong>相关内容</strong></span>:</td>
                  <td width="67%" ><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                </tr>
                </table> 
                </asp:Panel>
                <table width="92%" border="0" align="center" cellpadding="3" cellspacing="1">
                <tr>
                  <td valign="top" width="20%" align="right"  style="height: 86px"><span class="red">*</span>&nbsp;<span class="blue"><strong>我的货物情况</strong></span>:</td>
                  <td valign="top" width="67%" style="height: 86px" ><textarea name="textarea" cols="40" rows="5" id="TEXTAREA1" runat="server"></textarea></td>
                </tr>
                <tr>
                  <td valign="top" height="28" align="right"><span class="blue"><strong>我的理想价格</strong></span>:</td>
                  <td valign="top"><input name="text" type="text" id="Username2" size="30" runat="server" /></td>
                </tr>
                </table>
                             
                <table width="92%" border="0" align="center" cellpadding="3" cellspacing="1">
                 <tr>
                  <td valign="top" width="20%" height="28" align="right"><span class="blue"><strong>怎么回复我</strong></span>:</td>
                  <td valign="top" width="67%">
                      <asp:Panel ID="Panel2" runat="server">
                      <asp:CheckBox ID="CheckBox1" runat="server" Text="短消息" Checked="True" Enabled="False" />
                      <br />
                      <asp:CheckBox ID="CheckBox2" runat="server" Text="电话" Checked="True"/>
                      <br />
                      <asp:CheckBox ID="CheckBox3" runat="server" Text="手机" Checked="True"/>
                      <br />
                      <asp:CheckBox ID="CheckBox4" runat="server" Text="邮件、MSN、QQ" Checked="True"/>
                      <br />
                      <div style=" margin:8px 0px 3px 0px">其他联系方式：</div>
                    <textarea name="TEXTAREA3" cols="40" rows="3" id="TEXTAREA3" runat="server"></textarea>
                      </asp:Panel>
                      <asp:Panel ID="Panel3" runat="server">
                      <div style=" margin:0px 0px 3px 0px"><span class="red">*</span> 我的姓名：</div>
                      <asp:TextBox ID="TextBox11" runat="server" ></asp:TextBox>
                      <div style=" margin:8px 0px 3px 0px">我的公司名称：</div>
                      <asp:TextBox ID="TextBox12" runat="server" ></asp:TextBox>                      
                      <div style=" margin:8px 0px 3px 0px"><span class="red">*</span> 我的联系方式：</div>
                      <textarea name="TEXTAREA4" cols="40" rows="3" id="TEXTAREA4" runat="server"></textarea><br />
                  <span class="gray">★环球运费网建议您<a href="/accounts/login.aspx" class="orange">登录</a>，这样对方可以用短消息回复您。<a href="/accounts/reg.aspx  " class="red">免费注册</a></span>
                  </asp:Panel>
                      <asp:TextBox ID="TextBox1" runat="server" CssClass="hidden"></asp:TextBox>
                      <asp:TextBox ID="TextBox2" runat="server" CssClass="hidden"></asp:TextBox>
                      <asp:TextBox ID="TextBox3" runat="server" CssClass="hidden"></asp:TextBox>
                      <asp:TextBox ID="TextBox4" runat="server" CssClass="hidden"></asp:TextBox>
                      <asp:TextBox ID="TextBox5" runat="server" CssClass="hidden"></asp:TextBox>
                      <asp:TextBox ID="TextBox6" runat="server" CssClass="hidden"></asp:TextBox>
                      <asp:TextBox ID="TextBox7" runat="server" CssClass="hidden"></asp:TextBox>
                      <asp:TextBox ID="TextBox8" runat="server" CssClass="hidden"></asp:TextBox>
                      <asp:TextBox ID="TextBox9" runat="server" Height="131px" TextMode="MultiLine" Width="348px" CssClass="hidden"></asp:TextBox>
                      </td>
                </tr> 
                </table>                                        
                <table width="92%" border="0" align="center" cellpadding="0" cellspacing="1">
                <tr>
                  <td height="10" colspan="2" align="right"></td>
                </tr>
                <tr>
                  <td width="20%" height="32" align="right">&nbsp;</td>
                  <td width="67%"><asp:Button ID="Button1" runat="server" Text="确定" />
                        <input   name="Button12" id="Button12" value="取消" type="button" onclick="Close();" /></td>
                </tr>
                <tr>
                  <td height="32" align="right">&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
                <tr>
                  <td height="32" align="right">&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
              </table>
			  </div>
		  </div>
			<!--左边结束-->	
			<div class="main_right"><!--右边开始-->
				<userrate2:userrate2 ID="userrate22" runat="server" />
				<usertranslate2:usertranslate2 ID="usertranslate22" runat="server" />
			</div><!--右边结束-->		
  		</div>
	  	  <userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
</form> 
</body>
</html>