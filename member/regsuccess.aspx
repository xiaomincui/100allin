<%@ Page Language="VB" AutoEventWireup="false" CodeFile="regsuccess.aspx.vb" Inherits="member_regsuccess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>�����˷��� - ע��ɹ�</title>
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
<div class="main_container"><!--ҳ�����忪ʼ-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--������ʼ-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />�����ڵ�λ��:<a href="/" target="_blank">��ҳ</a> > ע��ɹ�</h1>
			<userservice:userservice ID="userservice1" runat="server" />
		</div><!--��������-->
		<div class="main_content"><!--�в���ʼ-->
			<div class="main_left" style="background:url(images/fcl/info_bg.gif) no-repeat left top;"><!--��߿�ʼ-->
			<div style="clear:both;">
		      <table width="92%" border="0" align="center" cellpadding="3" cellspacing="1" style="background:url(images/fcl/33.gif) no-repeat right 65px;">
                <tr>
                  <td height="10" colspan="2" align="center"></td>
                </tr>
				<tr>
                  <td height="32" colspan="2" align="left" ><div class="blue" style=" font:14px '����'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images/fcl/jt2.gif" />&nbsp;<strong>ע��ɹ�</strong></div></td>
                </tr>
				<tr>
                  <td height="10" colspan="2" align="center" ></td>
				</tr>

                </table> 
                <table width="92%" border="0" align="center" cellpadding="3" cellspacing="1">
                <tr>
                  <td><span class="orange"><strong>�����˷�����ʾ</strong></span>:</td>
                </tr>
                <tr>
                  <td>��ϲ�������ѳɹ�ע���Ա��5���Ӻ󽫱�ҳ���Զ���ת����վ��ҳ��</td>
                </tr>                
                </table>                 			                                         
                
			  </div>
		  </div>
			<!--��߽���-->	
			<div class="main_right"><!--�ұ߿�ʼ-->
				<userrate2:userrate2 ID="userrate22" runat="server" />
				<usertranslate2:usertranslate2 ID="usertranslate22" runat="server" />
			</div><!--�ұ߽���-->		
  		</div>
	  	  <userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--ҳ���������-->	
</form> 
</body>
</html>

