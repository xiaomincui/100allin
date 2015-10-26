<%@ Page Language="VB" AutoEventWireup="false" CodeFile="contact.aspx.vb" Inherits="intro_contact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>傲赢网 - 联系我们</title>
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
							<li><a href="/bbs/" target="_blank">论坛</a></li></ul>
					 </td>
                      <td width="10"><img src="../images/menu_3.gif" width="10" height="35" /></td>
                    </tr>
                  </table>
			</div>
			<div id="main">
				<div id="left">
				 <userlogin:userlogin id="Userlogin1" runat="server" />
							
				</div>
				<div id="right">
                <div id="search">
					  <table border="0" cellspacing="0" cellpadding="0">
							<tr>
							  <td width="10" ><img src="../images/box_1.gif" width="10" height="31" /></td>
							  <td width="780" background="../images/box_2.gif" ><div class="bigBoxTitle">联系我们</div></td>
							  <td width="10" ><img src="../images/box_3.gif" width="10" height="31" /></td>
							</tr>
							<tr>
							      <td background="../images/box_4.gif" style="height: 15px"></td>
							      <td bgcolor="#FFFFFF">
							        <div class="searchbox" style=" line-height:25px; font-size:14px;">
							            <img src="/images/address.jpg" />
                                        <p>
                                        <span style="font-weight:bold;">地址：</span><br />
                                        上海市西藏中路18号港陆广场908室 <span classid="edushianchor" city="上海" sitename=" 上海傲赢信息技术有限公司" address="上海市西藏中路18号港陆广场908室" style="display:none">大家好</span>
<script language="javascript" src="http://dw.edushi.com/dw.js"></script><br />邮编：200001<br />
                                        </p>
                                        <p>
                                        <span style="font-weight:bold;">联系电话：</span><br />
                                        总机：021-51086987,021-53853033 (直线) <br />
                                        市场部：021-51086987-102<br />
                                        客户服务部：021-51086987-100<br />
                                        客服QQ1：<a href="tencent://message/?uin=744593820&amp;Site=www.100allin.com&amp;Menu=yes">744593820（点击可直接联系我）</a> <br />
					客服QQ2：<a href="tencent://message/?uin=914019684&amp;Site=www.100allin.com&amp;Menu=yes">914019684（点击可直接联系我）</a> <br />
                                        技术支持：021-51086987-103<br />
					咨询电话：021-51086987-111
                                        </p>
                                        <p>
                                        <span style="font-weight:bold;">传真：</span><br />
                                        021-53853022<br />
                                        </p>  
                                        <p>
                                        <span style="font-weight:bold;">E-mail：</span><br />
                                        allin@100allin.com<br />
                                        </p>
                                        <br />
                                        <br />                                                                                                           
							        </div>
							      </td>
							      <td background="../images/box_6.gif" style="height: 15px"></td>
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
