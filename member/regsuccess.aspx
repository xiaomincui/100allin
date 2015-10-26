<%@ Page Language="VB" AutoEventWireup="false" CodeFile="regsuccess.aspx.vb" Inherits="member_regsuccess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>环球运费网 - 注册成功</title>
<link href="/css/fcl_css.css" rel="stylesheet" type="text/css" />
<meta http-equiv="refresh" content="5;url=/" />
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
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />您现在的位置:<a href="/" target="_blank">首页</a> > 注册成功</h1>
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
                  <td height="32" colspan="2" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images/fcl/jt2.gif" />&nbsp;<strong>注册成功</strong></div></td>
                </tr>
				<tr>
                  <td height="10" colspan="2" align="center" ></td>
				</tr>

                </table> 
                <table width="92%" border="0" align="center" cellpadding="3" cellspacing="1">
                <tr>
                  <td><span class="orange"><strong>环球运费网提示</strong></span>:</td>
                </tr>
                <tr>
                  <td>恭喜您！您已成功注册会员，5秒钟后将本页面自动跳转到网站首页。</td>
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

