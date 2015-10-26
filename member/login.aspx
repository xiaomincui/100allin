<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="member_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>环球运费网 - 关于傲赢</title>
    <link href="../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../css/list.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--

-->
</style>
<script language="javascript" type="text/javascript" src="../js/function.js"></script>
</head>
<body onload="AutoTips('officetips')">
<form id="form1" runat="server" autocomplete="off" onKeydown="if(event.enterKey){return   false}">
<asp:ScriptManager ID="ScriptManager1" runat="server"> 
</asp:ScriptManager>
<script language="javascript" type="text/javascript">
    Sys.Application.add_load(function(){var form=Sys.WebForms.PageRequestManager.getInstance()._form;form._initialAction=form.action=window.location.href;});
</script>
    <div id="page">
		<div id="center">
			<usertop:usertop ID="Usertop1" runat="server" />
			<div id="menu">
			  <table width="990" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="10"><img src="../images/menu_1.gif" width="10" height="35" /></td>
                      <td width="970" background="../images/menu_2.gif">
						  <ul>
							<li><a href="/">首页</a></li>
							<li>|</li>
							<li><a href="../search/fcl.htm">整箱运价</a></li>
							<li>|</li>
							<li><a href="../search/lcl.htm">拼箱运价</a></li>
							<li>|</li>
							<li><a href="../search/air.htm">空运运价</a></li>
							<li>|</li>
							<li><a href="../search/cargo.htm">货盘信息</a></li>
							<li>|</li>
							<li><a href="/search/company.htm" target="_blank">公司库</a></li>
							<li>|</li>
							<li><a href="/home/space.php?do=home" target="_blank">社区</a> <span style="color:red;font-weight:bold;">[新]</span></li>
							<li>|</li>
							<li><a href="/bbs/" target="_blank">论坛</a></li>
						  </ul>
					 </td>
                      <td width="10"><img src="../images/menu_3.gif" width="10" height="35" /></td>
                    </tr>
                  </table>
			</div>
			<div id="main">
				<div style="float:left;width:420px;	margin-bottom:15px; font-size:13px;">
					  <table border="0" cellspacing="0" cellpadding="0">
							<tr>
							  <td width="10"><img src="../images/box_1.gif" width="10" height="31" /></td>
							  <td width="385" background="../images/box_2.gif"><div class="smallBoxTitle">会员登录</div></td>
							  <td width="10"><img src="../images/box_3.gif" width="10" height="31" /></td>
							</tr>
							<tr>
							  <td background="../images/box_4_b.gif"></td>
							  <td align="center" bgcolor="#F6FBFD">
							  	<div class="inLeftBox" ><span style="color:#FF0000">您需要登录后才能继续刚才的操作</span><br />
							  	<table border="0" cellspacing="1" cellpadding="3"  >
                  <tr align="left">
                    <td width="62" height="30"><b class="midBlueTitle">用户名：</b></td>
                    <td width="220"><asp:TextBox ID="txtUsername" runat="server" Width="160" Height="15"></asp:TextBox></td>
                  </tr>
							  	  <tr align="left">
							  	    <td height="30"><b class="midBlueTitle">密　码：</b></td>
                      <td><asp:TextBox ID="txtPassword" runat="server" Width="160" Height="15" TextMode="Password"></asp:TextBox></td>
                    </tr>
							  	  <tr align="left">
							  	    <td height="30" colspan="2">
							  	      <div style="margin-left:67px;">
							  	        <table border="0" cellspacing="0" cellpadding="0">
							  	          <tr>
							  	            <td style="width: 23px"><asp:CheckBox ID="chkAutoLogin" runat="server" Checked="True" /></td>
								  <td>下次自动登录</td>
							  </tr>
						  	            </table>										
						  </div>									
                       </td>
                    </tr>
							  	  <tr align="left">
							  	    <td height="30">&nbsp;</td>
                      <td height="30">
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="/images/login.gif"  OnClick="ImageButton2_Click" />
                        </td>
                    </tr>
							  	  </table>							  	    
							  	</div></td>
							  <td background="../images/box_6_b.gif"></td>
							</tr>
							<tr>
							  <td><img src="../images/box_7_b.gif" width="10" height="10" /></td>
							  <td background="../images/box_8_b.gif"></td>
							  <td><img src="../images/box_9_b.gif" width="10" height="10" /></td>
							</tr>
				      </table>	
				      <script language="javascript" type="text/javascript" src="/js/adv_login.js"></script>				
				</div>
				<div style="float:left;width:570px;	margin-bottom:15px;">
					  <table border="0" cellspacing="0" cellpadding="0">
							<tr>
							  <td width="10"><img src="../images/box_1.gif" width="10" height="31" /></td>
							  <td width="550" background="../images/box_2.gif"><div class="smallBoxTitle">注册环球运费网会员</div></td>
							  <td width="10"><img src="../images/box_3.gif" width="10" height="31" /></td>
							</tr>
							<tr>
							  <td background="../images/box_4.gif"></td>
							  <td>
							  	<div class="inLeftBox" >
							  	    <div style="margin-left:5px;">
							  	        <span class="midBlueTitle">作为一个<span class="midOrangeTitle">游客</span>,您可以：</span><br />
							  	        <span class="midBlueTitle">无限制查看环球运费网的 <span class="midOrangeTitle">资讯</span> 信息</span><br />
							  	        <span class="midBlueTitle">无限制查看环球运费网的 <span class="midOrangeTitle">运价</span> 信息,但无法查看货代联系方式</span><br />
							  	        <span class="midBlueTitle">无限制查看环球运费网的 <span class="midOrangeTitle">货盘</span> 信息,但无法查看货主联系方式</span><br />
							  	    </div>
							  	    <div style="text-align:center; margin-top:6px;">
							  	        <span class="midOrangeTitle">我想拥有更多权限 >> </span><a href="../member/reg.aspx"><img src="../images/reg.gif" width="140" height="40" border="0" /></a> </div>
										<br/>
										<div style="margin-left:5px;">
							  	        <span class="midBlueTitle">作为一个<span class="midOrangeTitle">免费注册会员</span>,您可以：</span><br />
							  	        <span class="midBlueTitle">无限制查看环球运费网的 <span class="midOrangeTitle">资讯</span> 信息,并查看货代联系方式</span><br />
							  	        <span class="midBlueTitle">无限制查看环球运费网的 <span class="midOrangeTitle">运价</span> 信息,并查看货代联系方式</span><br />
							  	        <span class="midBlueTitle">无限制查看环球运费网的 <span class="midOrangeTitle">货盘</span> 信息,并查看货主联系方式</span><br />
										<span class="midBlueTitle">无限制发布 <span class="midOrangeTitle">运价</span> 信息</span><br />
										<span class="midBlueTitle">无限制发布 <span class="midOrangeTitle">货盘</span> 信息</span><br />
										<span class="midBlueTitle">自动成为 <span class="midOrangeTitle">环球运费网社区</span> 会员，结交商友</span><br />										
							  	    </div>
							  	    <div style="text-align:center; margin-top:6px;">
							  	        <a href="../member/reg.aspx"><img src="../images/reg.gif" width="140" height="40" border="0" /></a> </div>
							  	</div>
							  </td>
							  <td background="../images/box_6.gif"></td>
							</tr>
							<tr>
							  <td><img src="../images/box_7.gif" width="10" height="10" /></td>
							  <td background="../images/box_8.gif"></td>
							  <td><img src="../images/box_9.gif" width="10" height="10" /></td>
							</tr>
				      </table>
				</div>
			</div>
		</div>
    </div>
	<div><img src="../images/blank.gif" width="100%" height="10" /></div>
	<div id="bottom">
		<div class="line"><img src="../images/line_blue.gif" width="100%" height="1" /></div>
		<div class="copyright"><a href="/intro/about.aspx">关于傲赢</a>|<a href="/intro/service.aspx">服务条款</a>|<a href="/intro/law.aspx">法律声明</a>|<a href="/intro/contact.aspx">联系我们</a><br />Copyright 2007 100Allin.com All Rights Reserved<br />沪ICP备07510944号</div>
	</div>
</form>		
<script language="javascript" src="http://count48.51yes.com/click.aspx?id=485102224&logo=1"></script>	
</body>
</html>

