<%@ Page Language="VB" AutoEventWireup="false" CodeFile="about.aspx.vb" Inherits="intro_about" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>傲赢网 - 关于傲赢</title>
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
			<div id="top">
				<div id="logo"><a href="/"><img src="../images/logo.gif" width="149" height="47" border="0" /></a></div>
				<div id="title"><h1 class="blueText"><span >专业<span class="orangeText">运价</span>搜索查询和发布</span></h1></div>
				<div id="banner">
					<div id="help"><a href="/">回到首页</a>|<a href="#" onclick="var strHref=window.location.href;this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.100allin.com');">设为首页</a>|<a href="#" onclick="window.external.addFavorite('http://www.100allin.com','傲赢网-发布搜索运价平台')">加入收藏</a>|<a href="/intro/searchunion.aspx" target="_blank">运价搜索服务</a>|<a href="javascript:;" onclick="document.getElementById('servicebox').style.display = '';" style="color:#FF0000; font-weight:bold;" title="点击此处打开客户服务列表">客户服务</a><DIV id="servicebox" style="Z-INDEX:999; right:10px; top:30px; POSITION: absolute;  display:none;"><img src="/images/servicebox_head1.gif"  width="108" height="30" border="0" onclick="document.getElementById('servicebox').style.display = 'none';" style="cursor:pointer;" alt="点击此处隐藏客户服务列表" id="servicebox_head" /><br />
<img src="/images/servicebox_body2.gif" name="servicebox_head" width="108" height="125" border="0" usemap="#servicebox_headMap" id="servicebox_body" />
<map name="servicebox_headMap" id="servicebox_headMap">
<area shape="rect" coords="10,6,95,33" href="tencent://message/?uin=744593820&amp;Site=www.100allin.com&amp;Menu=yes" />
<area shape="rect" coords="10,34,95,61" href="tencent://message/?uin=914019684&amp;Site=www.100allin.com&amp;Menu=yes" />
<area shape="rect" coords="10,63,95,89" href="msnim:chat?contact=100allin03@LIVE.CN" />
<area shape="rect" coords="10,91,95,117" href="msnim:chat?contact=100allin02@LIVE.CN" />
</map></DIV></div>
					
				</div>
			</div>
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
							  <td width="780" background="../images/box_2.gif" ><div class="bigBoxTitle">关于傲赢</div></td>
							  <td width="10" ><img src="../images/box_3.gif" width="10" height="31" /></td>
							</tr>
							<tr>
							      <td background="../images/box_4.gif" style="height: 15px"></td>
							      <td bgcolor="#FFFFFF">
							        <div class="searchbox" style=" line-height:25px; font-size:14px;">
                                        <p><span style="font-weight:bold;font-size:18px;">傲赢网</span> 是上海傲赢信息技术有限公司开发的专一以海空运运价交流为目的的网站平台，网站致力于高效、简捷的运价发布、搜索系统的研发，并且不涉及任何运价以外的内容，从而保证浏览客户的单一目的性，以到达最佳的发布效果。<br /></p>
                                        <p><span style="font-weight:bold;font-size:18px;">傲赢网</span> 不提倡削价竞争，建议客户，特别是进出口企业，贯彻以服务为主，价格为辅的方针，理性选择代理。货运代理行业目前渐入微利时代，合理的利润率是赢得优质服务的保证，万不可图一时之宜而影响货物的正常起运。<br /></p>
                                        <p>希望<span style="font-weight:bold;font-size:18px;">傲赢网</span>能成为广大优秀代理和客户的桥梁。<br /></p>
										<p><span style="font-weight:bold;">傲赢网电视广告：</span><br />
										<object classid="clsid:6BF52A52-394A-11D3-B153-00C04F79FAA6" id="phx" width="320" height="256"> 
										<param name="URL" value="/images/adv.wmv"> 
										<param name="rate" value="1"> 
										<param name="balance" value="0"> 
										<param name="currentPosition" value="0"> 
										<param name="defaultFrame" value> 
										<param name="playCount" value="10"> 
										<param name="autoStart" value="-1"> 
										<param name="currentMarker" value="0"> 
										<param name="invokeURLs" value="-1"> 
										<param name="baseURL" value> 
										<param name="volume" value="50"> 
										<param name="mute" value="0"> 
										<param name="uiMode" value="mini"> 
										<param name="stretchToFit" value="0"> 
										<param name="windowlessVideo" value="0"> 
										<param name="enabled" value="-1"> 
										<param name="enableContextMenu" value="-1"> 
										<param name="fullScreen" value="0"> 
										<param name="SAMIStyle" value> 
										<param name="SAMILang" value> 
										<param name="SAMIFilename" value> 
										<param name="captioningID" value> 
										<param name="enableErrorDialogs" value="0"> 
										<param name="_cx" value="6482"> 
										<param name="_cy" value="6350"> 
										</object><br />
										</p>
                                        <br />
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
