<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logout.aspx.cs" Inherits="accounts_logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>环球运费网-登录</title>
<link href="/css/login.css" rel="stylesheet" type="text/css" />
</head>

<body>
<form id="form1" runat="server" autocomplete="off" onKeydown="if(event.enterKey){return   false}">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="main_container"><!--页面主体开始-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><img src="images/fcl/hand.GIF" width="16" height="16" />&nbsp;<strong>欢迎您</strong>&nbsp;<a href="#">首页</a> &gt; 退出登陆</h1>
			<span class="right_tn"><img src="images/fcl/lian.GIF" />&nbsp;<a href="#" target="_parent">在线客服</a></span>
  </div><!--导航结束-->
		<div class="main_content"><!--中部开始-->
			<div class="landing_box">
                正在退出，请稍候...</div>
			<div class="landing_box" style="border-left:1px dashed #A4A4A4;">
			  <table width="400" border="0" align="center" cellpadding="2" cellspacing="1">
                <tr>
                  <td height="40" colspan="3" ><img src="images/login/bg2.gif" width="400" height="40" /></td>
                </tr>
                <tr>
                  <td height="32" align="right"><img src="images/fcl/gt.gif" width="14" height="13" /></td>
                  <td colspan="2" align="left"><strong>作为一个</strong><span class="orange"><strong>游客</strong></span>,<strong>您可以</strong>：</td>
                </tr>
                <tr>
                  <td width="32" height="32" align="right">&nbsp;</td>
                  <td height="32" colspan="2">·无限制查看环球运费网的<span class="orange"><strong>资讯</strong></span>信息<br />
·无限制查看环球运费网的<span class="orange"><strong>运价</strong></span>信息,但无法查看货代联系方式<br />
·无限制查看环球运费网的<span class="orange"><strong>货盘</strong></span>信息,但无法查看货主联系方式</td>
                </tr>
				  <tr>
                  <td width="32" height="32" align="left" >&nbsp;</td>
                  <td width="173" align="left" >&nbsp;&nbsp;<span class="orange"><strong>我想拥有更多权限 &gt;&gt;</strong></span></td>
                  <td width="185" align="left" ><a href="#"><img src="images/login/bt2.GIF" width="128" height="35" border="0" /></a></td>
			    </tr>                
                <tr>
                  <td width="32" height="32" align="left" >&nbsp;</td>
                  <td colspan="2" align="left" >&nbsp;</td>
                </tr>                <tr>
                  <td height="32" align="right" ><img src="images/fcl/gt.gif" width="14" height="13" /></td>
                  <td colspan="2" align="left" ><strong>作为一个</strong><span class="red"><strong>免费注册会员</strong></span>,<strong>您可以</strong>：                    </td>
                </tr>
                <tr>
                  <td height="30" align="center">&nbsp;</td>
                  <td height="30" colspan="2" align="left">·无限制查看环球运费网的<span class="red"><strong>资讯</strong></span>信息,并查看货代联系方式 <br />
·无限制查看环球运费网的<span class="red"><strong>运价</strong></span>信息,并查看货代联系方式 <br />
·无限制查看环球运费网的<span class="red"><strong>货盘</strong></span> 信息,并查看货主联系方式 <br />
·无限制发布<span class="red"><strong>运价</strong></span>信息 <br />
·无限制发布<span class="red"><strong>货盘</strong></span>信息 <br />
&nbsp;&nbsp;自动成为 <span class="red"><strong>环球运费网社区</strong></span> 会员，结交商友</td>
                </tr>
                <tr>
                  <td height="32" align="center">&nbsp;</td>
                  <td height="30" colspan="2" align="left">&nbsp;&nbsp;<a href="#"><img src="images/login/bt2.GIF" width="128" height="35" border="0" /></a></td>
                </tr>
                <tr>
                  <td height="32" align="center">&nbsp;</td>
                  <td height="30" colspan="2" align="left">&nbsp;</td>
                </tr>
              </table>
			</div>
		</div>
	  <userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
</form> 
</body>
</html>