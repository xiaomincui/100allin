﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="userloginhome.ascx.cs" Inherits="usercontrols_userloginhome" %>
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
			  <div class="inLeftBox" style="position:relative"><span class="smallBoldOrange"><asp:Label ID="lblUserName" runat="server"></asp:Label></span>，欢迎您！<br /><div id="officetips" style="Z-INDEX:999; left:10px; top:-64px; POSITION: absolute; line-height:15px; width: 150px; height: 82px; background:url(/images/qipao.gif); padding-left:10px; padding-top:8px; display:none;" onclick="HideTips('officetips')"><strong>提示：</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<BR/>管理发布运价和货盘信息，修改个人信息和密码<BR/>请点击下面的链接</div>
				   <div><a href="/member" target="_blank"><img src="/images/myoffice.gif" border="0"/></a></div>
				   <% Response.Write("<script src='/home/newlogin.php'></script>");%>
				   <div><a href="/home/space.php?do=home" target="_blank"><img src="/images/myspace.gif" border="0"/></a></div>
                  <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="/default.aspx" OnClick="LinkButton1_Click">退出登录</asp:LinkButton>
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
								<td width="77">下次自动登录
								<% Response.Write("<script src='/home/newlogout.php'></script>");%>
								</td>
							  </tr>
							</table>										
						</div>									
                     </td>
                  </tr>
                  <tr>
                    <td height="30">&nbsp;</td>
                    <td height="30">
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="/images/login.gif" PostBackUrl="/default.htm" OnClick="ImageButton2_Click" /><BR/>
                        <div style="text-align:right; line-height:12px; margin-top:10px; "><a href="/member/reg.aspx">免费注册</a></div>
                    </td>
                  </tr>
                </table>
				<div style="text-align:right; line-height:12px; margin-top:6px; color:#999999; display:none">忘记密码？请点击这里</div>
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

<script language="javascript">
    setInterval('nowtime()',1000); 
</script>
<div id="yunfei" class="leftbox">
  <table border="0" cellspacing="0" cellpadding="0">
		<tr>
		  <td width="10"><img src="/images/box_1_o.gif" width="10" height="31" /></td>
		  <td width="155" background="/images/box_2_o.gif"><div class="tabTitleSelect2"><a href="/intro/baf.aspx" target="_blank">运费调整中心</a></div></td>
		  <td width="10"><img src="/images/box_3_o.gif" width="10" height="31" /></td>
		</tr>
		<tr>
		  <td background="/images/box_4_o.gif"></td>
		  <td>
		  <div class="inLeftBox" style="width:155px;">
		    <div style="color:Red; display:none;">各船公司将依然维持11月以来持续低走的附加费水平，并且1月下调的力度明显大于前两月。以期吸引市场上宝贵的货源。</div>
		    <a href="/intro/baf.aspx" target="_blank">3月最新BAF/CAF</a> <span style="color:Red; font-style:italic;">每日更新</span> <BR/>
		    <a href="/intro/baf.aspx#feb" target="_blank">2月最新BAF/CAF</a><BR/>
		    <a href="/intro/baf.aspx#jan" target="_blank">1月最新BAF/CAF</a> <BR/>				    
		  </div>
		  </td>
		  <td background="/images/box_6_o.gif"></td>
		</tr>
		<tr>
		  <td><img src="/images/box_7_o.gif" width="10" height="10" /></td>
		  <td background="/images/box_8_o.gif"></td>
		  <td><img src="/images/box_9_o.gif" width="10" height="10" /></td>
		</tr>
  </table>
</div>
<div class="leftbox">
    <a href="/insure/index.htm" target="_blank"><img src="/insure/images/adv.gif" width="175px" border="0" /></a>
</div>
<div class="leftbox">
  <table border="0" cellspacing="0" cellpadding="0">
		<tr>
		  <td width="10"><img src="/images/box_1.gif" width="10" height="31" /></td>
		  <td background="/images/box_2.gif" style="width: 155px"><div class="smallBoxTitle"><a href="/intro/rate.aspx" target="_blank">最新汇率</a></div></td>
		  <td width="10"><img src="/images/box_3.gif" width="10" height="31" /></td>
		</tr>
		<tr>
		  <td background="/images/box_4.gif" style="height: 55px"></td>
		  <td style="width: 155px; height: 55px;">
			  <div class="inLeftBox" >
			  		<div id="nowtime"></div>
                    <div style="font-size:14px;">1美元= <strong><asp:Label ID="lblRate" runat="server" Text="暂无"></asp:Label></strong>人民币</div>
                    <div style="font-size:14px;">1欧元= <strong><asp:Label ID="lblRate2" runat="server" Text="暂无"></asp:Label></strong>人民币</div>                    
                    <div style="text-align:right;"><a href="/intro/rate.aspx" target="_blank">更多汇率资讯 >></a></div> 
			  </div>
		  </td>
		  <td background="/images/box_6.gif" style="height: 55px"></td>
		</tr>
		<tr>
		  <td><img src="/images/box_7.gif" width="10" height="10" /></td>
		  <td background="/images/box_8.gif" style="width: 155px"></td>
		  <td><img src="/images/box_9.gif" width="10" height="10" /></td>
		</tr>
  </table>
</div>

<asp:Panel ID="pnlChat" runat="server">
	<div id="chat" class="leftbox">
	  <table border="0" cellspacing="0" cellpadding="0">
			<tr>
			  <td width="10"><img src="/images/box_1.gif" width="10" height="31" /></td>
			  <td width="155" background="/images/box_2.gif"><div class="smallBoxTitle">即时聊天</div></td>
			  <td width="10"><img src="/images/box_3.gif" width="10" height="31" /></td>
			</tr>
			<tr>
			  <td background="/images/box_4.gif"></td>
			  <td>
			  <div class="inLeftBox">
			    <iframe src="chat/Default.aspx?id=<%=this.Request.Cookies["user_id"].Value%>" frameborder="0" scrolling="no" width="155" height="240"></iframe><br />
			    <div style="color:red; line-height:18px; width:150px;">提示：关闭首页将同时关闭傲赢网即时聊天工具，您将无法及时收到其他会员发给您的信息,为了其他会员能沟即时联系到您,建议工作时间不要关闭傲赢网首页,可将页面最小化。</div>
			  </div>
			  </td>
			  <td background="/images/box_6.gif"></td>
			</tr>
			<tr>
			  <td><img src="/images/box_7_2.gif" width="10" height="31" /></td>
			  <td background="/images/box_8_2.gif"></td>
			  <td><img src="/images/box_9_2.gif" width="10" height="31" /></td>
			</tr>
      </table>
	</div>
</asp:Panel>

					<div id="zhuce" class="leftbox">

					  <table border="0" cellspacing="0" cellpadding="0">
							<tr>
							  <td width="10"><img src="images/box_1.gif" width="10" height="31" /></td>
							  <td width="155" background="images/box_2.gif"><div class="smallBoxTitle">注册傲赢网会员</div></td>
							  <td width="10"><img src="images/box_3.gif" width="10" height="31" /></td>
							</tr>
							<tr>
							  <td background="images/box_4.gif"></td>
							  <td>
							  	<div class="inLeftBox" >
							  	    <div style="margin-left:5px;">
							  	        <span class="midOrangeTitle">免费</span> <span class="midBlueTitle"><a href="/member/releaseselect.aspx" target="_blank" style="text-decoration:underline">发布运价信息</a></span><br />
							  	        <span class="midOrangeTitle">免费</span> <span class="midBlueTitle"><a href="/member/cargoselect.aspx" target="_blank" style="text-decoration:underline">发布货盘信息</a></span><br />
							  	        <span class="midOrangeTitle">即时</span> <span class="midBlueTitle">与您的商友沟通</span><br />
							  	    </div>
							  	    <div style="text-align:center; margin-top:6px;">
							  	        <a href="../member/reg.aspx"><img src="images/reg.gif" width="140" height="40" border="0" /></a> </div>
							  	</div>
							  </td>
							  <td background="images/box_6.gif"></td>
							</tr>
							<tr>
							  <td><img src="images/box_7.gif" width="10" height="10" /></td>
							  <td background="images/box_8.gif"></td>
							  <td><img src="images/box_9.gif" width="10" height="10" /></td>
							</tr>
				      </table>
					</div>										
					<div id="translate" class="leftbox">
					  <table border="0" cellspacing="0" cellpadding="0">
							<tr>
							  <td width="10"><img src="images/box_1.gif" width="10" height="31" /></td>
							  <td width="155" background="images/box_2.gif"><div class="smallBoxTitle">在线英汉汉英字典</div></td>
							  <td width="10"><img src="images/box_3.gif" width="10" height="31" /></td>
							</tr>
							<tr>
							  <td background="images/box_4.gif"></td>
							  <td>
							  <div class="inLeftBox">
								<iframe src="/intro/translate.htm" width="155px" height="80px" frameborder="0" scrolling="no"></iframe>
							  </div>
							  </td>
							  <td background="images/box_6.gif"></td>
							</tr>
							<tr>
							  <td><img src="images/box_7.gif" width="10" height="10" /></td>
							  <td background="images/box_8.gif"></td>
							  <td><img src="images/box_9.gif" width="10" height="10" /></td>
							</tr>
				      </table>
					</div>	
<asp:HiddenField ID="lblUrl" runat="server" />
<script type="text/javascript" language="javascript">
    document.getElementById("Userloginhome1$lblUrl").value = window.location.href;
</script>