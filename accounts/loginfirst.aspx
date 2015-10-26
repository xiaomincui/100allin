<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginfirst.aspx.cs" Inherits="accounts_loginfirst" EnableEventValidation="false"%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>环球运费网-登录</title>
<link href="/css/index20100319.css" rel="stylesheet" type="text/css" />
</head>

<body>
<form id="form1" runat="server" autocomplete="off" onKeydown="if(event.enterKey){return   false}">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="main">
<usernewtop1209:usernewtop1209 ID="usernewtop12091" runat="server" />
<div class="container"><!--主体开始-->
			<div class="login_main">
				<div class="login_main_left">
				  <table width="385" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td colspan="2"><img src="/images/index/login_1.gif" width="385" height="66" /></td>
                    </tr>
                    <tr>
                      <td height="10" colspan="2"></td>
                    </tr>
                    <tr>
                      <td width="112" height="42" align="right"></td>
                      <td width="302"><span style="color:#666666">请先登录网站,不是网站会员？请<a href="/accounts/reg.aspx">免费注册</a></span></td>
                    </tr>                    
                    <tr>
                      <td width="112" height="42" align="right"><span class="red">*</span>&nbsp;<span style="font-size:14px;">用户名&nbsp;:&nbsp;&nbsp;</span></td>
                      <td width="302"><input name="Username" type="text" id="username" size="30" class="input01" runat="server" /></td>
                    </tr>
                    <tr>
                      <td height="42" align="right"><span class="red">*</span>&nbsp;<span style="font-size:14px;">密&nbsp;&nbsp;码&nbsp;:&nbsp;&nbsp;</span></td>
                      <td><input name="Password" type="password" id="password" size="30" class="input01" runat="server" maxlength="15"/></td>
                    </tr>
                    <tr>
                      <td height="24" align="right">&nbsp;</td>
                      <td><asp:CheckBox ID="chkAutoLogin" runat="server" Checked="True" /> 
                        下次自动登录</td>
                    </tr>
                    <tr>
                      <td height="82" align="right">&nbsp;</td>
                      <td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/index/login_2.jpg" OnClick="ImageButton1_Click" /></td>
                    </tr>
                  </table>
				</div>
				<div class="login_main_right">
				  <table width="385" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td colspan="2"><img src="/images/index/login_4.gif" width="385" height="66" /></td>
                    </tr>
                    <tr>
                      <td height="10" colspan="2"></td>
                    </tr>
                    <tr>
                      <td width="50" height="42" align="right">&nbsp;</td>
                      <td width="335">· 无限制查看资讯信息<br />
                        · 无限制查看运价及货代联系方式 <br />
                        · 无限制查看货盘及货主联系方式</td>
                    </tr>
                    <tr>
                      <td height="82" align="right">&nbsp;</td>
                      <td><a href="/accounts/reg.aspx"><img src="/images/index/login_5.jpg" width="139" height="36" border="0" /></a></td>
                    </tr>
                    <tr>
                      <td height="20" colspan="2" align="right"></td>
                    </tr>
                    <tr>
                      <td height="1" colspan="2" align="right" background="/images/index/login_6.gif"></td>
                    </tr>
                    <tr>
                      <td height="30" colspan="2"></td>
                    </tr>
                    <tr>
                      <td height="10" colspan="2" align="left"><img src="/images/index/login_7.gif" width="190" height="42" /></td>
                    </tr>
                    <tr>
                      <td height="7" colspan="2" ></td>
                    </tr>
                    <tr>
                      <td height="86" colspan="2" style="background:url(/images/index/login_8.gif) no-repeat left;"><table width="385" height="86" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td width="19">&nbsp;</td>
                            <td width="366" class="login_red">· 有的放矢 -广告在用户的搜索基础上投放，针对性强，
                              广告投放对象特别精确。<br />
                              · 润物无声 -广告在用户有需求的搜索时出现，令用户倍感贴心<br />
                            </td>
                          </tr>
                      </table></td>
                    </tr>
                    <tr>
                      <td height="15" colspan="2"></td>
                    </tr>
                    <tr>
                      <td height="62" colspan="2"><img src="/images/index/login_11.jpg" width="383" height="34" border="0" /></td>
                    </tr>
                  </table>
				</div>
			</div>						
	  <userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
		</div>	
</div>    

</form> 
</body>
</html>