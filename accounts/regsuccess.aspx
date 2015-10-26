<%@ Page Language="C#" AutoEventWireup="true" CodeFile="regsuccess.aspx.cs" Inherits="accounts_regsuccess" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="最新运费 海运运费 空运运费  整箱运价 拼箱运价 运价排行 货运代理 货主 运价查询" />
<meta name="description" content="环球运费网是全球最大的专业运价查询平台，主要提供全面、高效、简捷的海空运运价的发布和查询服务。拥有海量货主会员进行运价的查询和对比，更多运价查询信息请点击进入。" />
<title>高级会员注册成功</title>
<link href="css/login.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-1.2.1.pack.js" type="text/javascript"></script>
<script src="js/regnormal.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="main_container"><!--页面主体开始-->
  <!--顶部登陆结束-->
<div class="header"><!--头部LOGO开始-->	
			<div id="logo">
				<a href="/" target="_blank"><img src="images/logo.gif" alt="环球运费网" border="0" width="340" height="75" /></a>			</div>
			<ul><li><a title="欢迎使用在线客服" href="#" onclick="document.getElementById('aliserv').click();">在线客服</a> | <a href="/" target="_blank">返回首页</a><br />
			  如遇注册问题请拨打：<span class="red">400-888-9256</span></li>
			</ul>
  </div><!--头部LOGO结束-->
  <div class="menu"><!--导航开始-->
			<h1><span style="color:#29395b;">注册步骤</span>：<span><img src="images/1_1.jpg" width="12" height="12" />注册初级会员</span> >    <img src="images/2_2.JPG" width="12" height="12" /><strong>注册普通会员</strong> >    <img src="images/3.JPG" width="12" height="12" /><span class="orange"><strong>审核注册资料</strong></span> </h1>
  <span class="right_tn"><a>*</a> 为必填项</span></div>
		<!--导航结束-->
		<div class="main_content"><!--中部开始-->
		  <div class="login_box">
		  	<div class="lg">
				<div class="zc2" style="display:inherit;" id="cong">
					<div class="zc2_top"><p><span class="tt">您好！<b style="color:#3399FF;"><asp:Literal ID="ltrName" runat="server">尊敬的网站访客</asp:Literal></b>，您的注册资料正在审核中！</span>
                      <br />
                  审核成功后，您可以无限制浏览环球运费网信息、发布各类信息！<br />
				<a href="/">>> 立即体验环球运费网的无障碍浏览</a><br/>
				<a href="/member/">>> 去我的办公室发布运价</a>
				</p>
				  </div>
				  	<div class="zc2_bt">
				  	  <p><span class="tt"><b style="color:red;">网站普通会员将享有更多服务!</b></span>
                      <br />
                      ·拥有公司独立商铺页面，获得更多宣传机会；<br />
                      ·无限制发布各类信息（运价、货盘、论坛帖子等）；<br />
                      ·初级会员的所有服务；<br />
				  	  </p>
			  	  </div>
			  	  
				</div>

			</div>
		  </div>
		</div>
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
</form>
</body>
</html>
