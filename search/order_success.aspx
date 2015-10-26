<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_success.aspx.cs" Inherits="search_order_success" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>订舱</title>
<link href="/css/fcl_css0927.css" rel="stylesheet" type="text/css" />
<script>
</script>
</head>
<body>
<form id="form1" runat="server">
 <div class="main_container">
<div class="top_bar"><!--顶部登陆开始-->
	<div class="top_bar_hd">
		<h2><a href="/"><img src="/images/fcl/home.gif" border="0" alt="环球运费网" /><strong>环球运费网</strong></a></h2>
		<ul>
		<li>&nbsp;<a href="/help/help_about.html" target="_blank"><span class="orange bold">帮助</span></a>&nbsp;</li>
		<li>&nbsp;<a href="/member/" target="_blank">进入办公室</a>&nbsp;|</li>
		<li>&nbsp;<a href="/accounts/reg.aspx">免费注册</a>&nbsp;|</li>
		<li><a href="/accounts/login.aspx">登陆</a>&nbsp;|</li>
		</ul>
	</div>
</div>
<div class="menu2"><!--导航开始-->
	  <h1><strong class="blue2">欢迎您，<asp:Literal ID="ltrLoginName" runat="server"></asp:Literal>！</strong>&nbsp;您现在的位置:<a href="#" target="_blank">首页</a> > 订舱</h1>
	  <span class="right_tn">&nbsp;<a style="color:#1E5995;" title="欢迎使用在线客服" href="#" onclick="document.getElementById('aliserv').click();">在线客服</a></span>	</div>
	  
		<div class="main_content"><!--中部开始-->
			<div class="prompt_top">
				<h2><strong><asp:Literal ID="Literal2" runat="server"></asp:Literal></strong></h2>
			</div>
			<div class="prompt_bot">
			  <p><span id="protmpt_tn" style="padding-bottom:20px; line-height:30px;"><asp:Literal ID="Literal1" runat="server"></asp:Literal></span><br />
			  <span class="gray"><asp:Literal ID="Literal5" runat="server"></asp:Literal></span> <br />
			  <asp:Literal ID="Literal3" runat="server"></asp:Literal><br />
		      </p>
			  <p>
			  <asp:Literal ID="Literal4" runat="server"></asp:Literal></p>
			  <p style="border:none;">
                  <asp:Literal ID="Literal6" runat="server"></asp:Literal>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
                     请您对对方商户进行评价：<br />
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1"  Selected="True">好评 </asp:ListItem>
                        <asp:ListItem Value="0">中评 </asp:ListItem>
                        <asp:ListItem Value="-1">差评 </asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    评价内容：<br />
                        <asp:TextBox ID="TextBox1" runat="server" Height="120px" TextMode="MultiLine" 
                            Width="400px"></asp:TextBox><br />
                        <asp:Button ID="Button1" runat="server" Text="提交评价" onclick="Button1_Click" />
                        </asp:PlaceHolder>
                        
                        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
                     请您对对方货主进行评价：<br />
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1"  Selected="True">好评 </asp:ListItem>
                        <asp:ListItem Value="0">中评 </asp:ListItem>
                        <asp:ListItem Value="-1">差评 </asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    评价内容：<br />
                        <asp:TextBox ID="TextBox2" runat="server" Height="120px" TextMode="MultiLine" 
                            Width="400px"></asp:TextBox><br />
                        <asp:Button ID="Button2" runat="server" Text="提交评价" onclick="Button2_Click" />
                        </asp:PlaceHolder>                        
                        <div></div>
		      </p>
			</div>
  		</div>
<userbottomline:userbottomline id="userbottomline1" runat="server"/>
<userbottom:userbottom ID="userbottom1" runat="server" />
</div>
</form>
</body>
</html>
