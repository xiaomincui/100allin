<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userloginchat.ascx.cs" Inherits="usercontrols_userloginchat" %>
<asp:Panel ID="pnlHuiyuan" runat="server">
	<div id="huiyuan" class="leftbox">
	  <table border="0" cellspacing="0" cellpadding="0">
			<tr>
			  <td width="10"><img src="/images/box_1.gif" width="10" height="31" /></td>
			  <td width="155" background="/images/box_2.gif"><div class="smallBoxTitle">会员信息</div></td>
			  <td style="width: 11px"><img src="/images/box_3.gif" width="10" height="31" /></td>
			</tr>
			<tr>
			  <td background="/images/box_4_b.gif"></td>
			  <td bgcolor="#f6fbfd">
			  <div class="inLeftBox" style="position:relative"><span class="smallBoldOrange"><asp:Label ID="lblUserName" runat="server"></asp:Label></span>，欢迎您！<br /><div id="officetips" style="Z-INDEX:999; left:30px; top:-64px; POSITION: absolute; line-height:15px; width: 150px; height: 82px; background:url(/images/qipao.gif); padding-left:10px; padding-top:8px; display:none;" onclick="HideTips('officetips')"><strong>提示：</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<BR/>管理发布运价和货盘信息，修改个人信息和密码<BR/>请点击下面的链接</div>
				   <a href="/member" target="_blank">进入我的办公室</a><br />
                  <asp:LinkButton ID="LinkButton1" runat="server"  OnClick="LinkButton1_Click">退出登录</asp:LinkButton>
			  </div>
			  </td>
			  <td background="/images/box_6_b.gif" style="width: 11px"></td>
			</tr>
			<tr>
			  <td><img src="/images/box_7_b.gif" width="10" height="10" /></td>
			  <td background="/images/box_8_b.gif"></td>
			  <td style="width: 11px"><img src="/images/box_9_b.gif" width="10" height="10" /></td>
			</tr>
      </table>
	</div>
</asp:Panel>
<asp:Panel ID="pnlDenglu" runat="server">
	<div id="denglu" class="leftbox">
	  <table border="0" cellspacing="0" cellpadding="0">
			<tr>
			  <td width="10"><img src="/images/box_1.gif" width="10" height="31" /></td>
			  <td width="155" background="/images/box_2.gif"><div class="smallBoxTitle">会员登录</div></td>
			  <td width="10"><img src="/images/box_3.gif" width="10" height="31" /></td>
			</tr>
			<tr>
			  <td background="/images/box_4_b.gif"></td>
			  <td bgcolor="#F6FBFD">
			  <div class="inLeftBox">
			  	<table width="151" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="55" height="30">用户名：</td>
                    <td width="96"><asp:TextBox ID="txtUsername" runat="server" Width="90" Height="15"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td height="30">密&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
                    <td><asp:TextBox ID="txtPassword" runat="server" Width="90" Height="15" TextMode="Password"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td height="30" colspan="2">
						<div style="margin-left:51px;">
							<table border="0" cellspacing="0" cellpadding="0">
							  <tr>
								<td style="width: 23px"><asp:CheckBox ID="chkAutoLogin" runat="server" Checked="True" /></td>
								<td width="77">下次自动登录</td>
							  </tr>
							</table>										
						</div>									
                     </td>
                  </tr>
                  <tr>
                    <td height="30">&nbsp;</td>
                    <td height="30">
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="/images/login.gif"  OnClick="ImageButton2_Click" /><BR/>
                        <div style="text-align:right; line-height:12px; margin-top:10px; "><a href="/member/reg.aspx">免费注册</a></div>
                    </td>
                  </tr>
                </table>
				<div style="text-align:right; line-height:12px; margin-top:10px; color:#999999; display:none">忘记密码？请点击这里</div>
			  </div>
			  </td>
			  <td background="/images/box_6_b.gif"></td>
			</tr>
			<tr>
			  <td><img src="/images/box_7_b.gif" width="10" height="10" /></td>
			  <td background="/images/box_8_b.gif"></td>
			  <td><img src="/images/box_9_b.gif" width="10" height="10" /></td>
			</tr>
      </table>
	</div>
</asp:Panel>
<asp:HiddenField ID="lblUrl" runat="server" />
<script type="text/javascript" language="javascript">
    document.getElementById("Userlogin1$lblUrl").value = window.location.href;
</script>