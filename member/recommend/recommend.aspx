<%@ Page Language="C#" AutoEventWireup="true" CodeFile="recommend.aspx.cs" Inherits="message_BBSList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>环球运费网 - 积分活动</title>
    <link href="../../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../../css/list.css" rel="stylesheet" type="text/css" />
    <link href="../css/BBSList.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--
#pp td{nowrap=true;}
-->
</style>
<script language="javascript" type="text/javascript" src="/js/function.js"></script>
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
					<div id="help"><a href="/">回到首页</a>|<a href="#" onclick="var strHref=window.location.href;this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.100allin.com');">设为首页</a>|<a href="#" onclick="window.external.addFavorite('http://www.100allin.com','环球运费网-发布搜索运价平台')">加入收藏</a>|<a href="javascript:;">使用帮助</a>|<a href="javascript:;" onclick="document.getElementById('servicebox').style.display = '';" style="color:#FF0000; font-weight:bold;" title="点击此处打开客户服务列表">客户服务</a><DIV id="servicebox" style="Z-INDEX:999; right:10px; top:30px; POSITION: absolute;  display:none;"><img src="../images/servicebox_head1.gif"  width="108" height="30" border="0" onclick="document.getElementById('servicebox').style.display = 'none';" style="cursor:pointer;" alt="点击此处隐藏客户服务列表" id="servicebox_head" /><br />
<img src="../images/servic ebox_body1.gif" name="servicebox_head" width="108" height="194" border="0" usemap="#servicebox_headMap" id="servicebox_body" />
<map name="servicebox_headMap" id="servicebox_headMap">
<area shape="rect" coords="10,152,95,180" href="msnim:chat?contact=100allin01@LIVE.CN" />
<area shape="rect" coords="10,123,95,150" href="msnim:chat?contact=100allin02@LIVE.CN" />
<area shape="rect" coords="10,95,95,120" href="msnim:chat?contact=100allin03@LIVE.CN" />
<area shape="rect" coords="10,68,95,93" href="tencent://message/?uin=908318342&amp;Site=www.100allin.com&amp;Menu=yes" />
<area shape="rect" coords="10,40,95,66" href="tencent://message/?uin=914019684&amp;Site=www.100allin.com&amp;Menu=yes" />
<area shape="rect" coords="10,11,95,38" href="tencent://message/?uin=744593820&amp;Site=www.100allin.com&amp;Menu=yes" />
</map></DIV></div>
					<pricecount:pricecount ID="Pricecount1" runat="server" />
				</div>
			</div>
			<div id="menu">
			  <table width="990" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="10"><img src="../images/menu_1.gif" width="10" height="35" /></td>
                      <td width="970" background="../images/menu_2.gif">
						  <ul>
							<li><a href="/" target="_blank">首页</a></li>
							<li>|</li>
							<li><a href="../search/fcl.htm" target="_blank">整箱海运运价</a></li>
							<li>|</li>
							<li><a href="../search/lcl.htm" target="_blank">拼箱海运运价</a></li>
							<li>|</li>
							<li><a href="../search/air.htm" target="_blank">空运运价</a></li>
							<li>|</li>
							<li><a href="../search/cargo.htm" target="_blank">货盘信息</a></li>
							<li>|</li>
							<li><a href="../search/company.htm" target="_blank">公司库</a></li>
							<li>|</li>
							<li><a href="../message/BBSList.aspx" target="_blank">论坛</a></li>		
						  </ul>
					 </td>
                      <td width="10"><img src="../images/menu_3.gif" width="10" height="35" /></td>
                    </tr>
                  </table>
			</div>
			<div id="main">
				<div id="left">
				 <userlogin:userlogin id="Userlogin1" runat="server" />
					<div id="zhuce" class="leftbox">
					  <table border="0" cellspacing="0" cellpadding="0">
							<tr>
							  <td width="10"><img src="../images/box_1.gif" width="10" height="31" /></td>
							  <td width="155" background="../images/box_2.gif"><div class="smallBoxTitle">注册环球运费网会员</div></td>
							  <td style="width: 11px"><img src="../images/box_3.gif" width="10" height="31" /></td>
							</tr>
							<tr>
							  <td background="../images/box_4.gif"></td>
							  <td>
							  	<div class="inLeftBox" >
							  	    <div style="margin-left:5px;">
							  	        <span class="midOrangeTitle">免费</span> <span class="midBlueTitle">发布运价信息</span><br />
							  	        <span class="midOrangeTitle">免费</span> <span class="midBlueTitle">发布货盘信息</span><br />
							  	        <span class="midOrangeTitle">即时</span> <span class="midBlueTitle">与您的商友沟通</span><br />
							  	    </div>
							  	    <div style="text-align:center; margin-top:6px;">
							  	        <a href="../../member/reg.aspx"><img src="../../images/reg.gif" width="140" height="40" border="0" /></a> </div>
							  	</div>
							  </td>
							  <td background="../images/box_6.gif" style="width: 11px"></td>
							</tr>
							<tr>
							  <td><img src="../images/box_7.gif" width="10" height="10" /></td>
							  <td background="../images/box_8.gif"></td>
							  <td style="width: 11px"><img src="../images/box_9.gif" width="10" height="10" /></td>
							</tr>
				      </table>
					</div>										
					<div id="yunfei" class="leftbox">
					  <table border="0" cellspacing="0" cellpadding="0">
							<tr>
							  <td style="width: 11px"><img src="../images/box_1.gif" width="10" height="31" /></td>
							  <td width="155" background="../images/box_2.gif"><div class="smallBoxTitle">运费调整中心</div></td>
							  <td width="10"><img src="../images/box_3.gif" width="10" height="31" /></td>
							</tr>
							<tr>
							  <td background="../images/box_4.gif" style="width: 11px"></td>
							  <td>
							  <div class="inLeftBox">
							    <a href="http://www.100allin.com/news/ShowNews.asp?id=298" target="_blank">BAF/CAF等附加费速查</a>
							  </div>
							  </td>
							  <td background="../images/box_6.gif"></td>
							</tr>
							<tr>
							  <td style="width: 11px"><img src="../images/box_7.gif" width="10" height="10" /></td>
							  <td background="../images/box_8.gif"></td>
							  <td><img src="../images/box_9.gif" width="10" height="10" /></td>
							</tr>
				      </table>
					</div>
							
				</div>
				<div id="right">
                    <table border="0" cellpadding="0" cellspacing="0" style="float: left">
                        <tr>
                            <td width="10">
                                <img height="31" src="../images/box_1.gif" width="10" /></td>
                            <td background="../images/box_2.gif" width="780">
                                
                                    <div class="smallBoxTitle" style=" float:left; margin-left : 5px">
                                        <asp:Label ID="Label6" runat="server" Text="积分规则"></asp:Label>
                                    </div>

                                </td>
                            <td style="width: 10px">
                                <img height="31" src="../images/box_3.gif" width="10" /></td>
                        </tr>
                        
                        
                        	<tr>
							  <td background="../images/box_4.gif"> 
							 
                                </td>
                                <td> 
                                 <br />
                                 <div class="searchbox" style=" line-height:25px; font-size:14px;">
                                 
							 

                                     什么是积分<br />
                                     积分是环球运费网对本网站会员贡献的一种奖励制度.通过一定的方式可以赚取积分并可兑换环球运费网的相关服务. 
                                     <br />
 				     <br />
                                     积分的作用<br />
                                     通过您赚取的积分可以兑换环球运费网子页面广告（包括整箱运价列表，拼箱运价列表，空运运价列表）下方的广告牌，广告牌的分值为100分/周.。位置由电脑随机抽取。广告牌有限，已满的情况下用积分预定。<br /><br />
                                     如何增加积分<br />
                                     首先您必需登录环球运费网，然后将以下链接地址复制粘贴给您的好友<br />
                                     <div class="bigBoxTitle" style="margin:10px;">您的会员推荐链接：<asp:TextBox ID="TextBox1" runat="server" Width="406px"></asp:TextBox><br /></div>
                                     每当您的一位好友进入上面的链接地址，并注册成为我们网站的会员，您就会获得10个积分，推荐的好友越多，获得的积分也就越多。<br />
                                     我们需要一天的时间审核会员注册并把积分加在您的帐号上。邀请注册用户不符合的条件不予加分(不符合条件指信息不真实、资料不全、已注册过等用户)。<br /><br />
                                     积分的减少<br />
                                     兑换广告成功后减去相应的积分. 更多兑换服务以后陆续推出,敬请关注.<br /><br />
                                     <div class="bigBoxTitle">
                                     
                                     您一共推荐了<a href="../recommendList.aspx"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>位</a>会员，共有积分<asp:Label
                                         ID="Label2" runat="server" Text="Label"></asp:Label>，<a href="../recommendList.aspx">您推荐的会员列表</a><br />
                                         <br />
                                         
                                         
                                         </div>
                                     
                                                                             <p>
                                        <span style="font-weight:bold;">有任何问题，可联系我们：</span>
                                        </p>
                                        <p>
                                        <span style="font-weight:bold;">地址：</span><br />
                                        上海市西藏中路18号港陆广场908室 邮编：200001<br />
                                        </p>
                                        <p>
                                        <span style="font-weight:bold;">联系电话：</span><br />
                                        总机：021-51086987<br />
                                        市场部：021-51086987-102，021-51086987-106，021-51086987-112<br />
                                        客户服务部：021-51086987-103<br />
                                        客服QQ1：<a href="tencent://message/?uin=744593820&amp;Site=www.100allin.com&amp;Menu=yes">744593820（点击可直接联系我）</a> <br />
										客服QQ2：<a href="tencent://message/?uin=914019684&amp;Site=www.100allin.com&amp;Menu=yes">914019684（点击可直接联系我）</a> <br />
                                        技术支持：021-51086987-131<br />
                                        咨询电话：021-53853033 (直线) <br />
                                        </p>
                                        <p>
                                        <span style="font-weight:bold;">传真：</span><br />
                                        021-53853022<br />
                                        </p>  
                                        <p>
                                        <span style="font-weight:bold;">E-mail：</span><br />
                                        allin@100allin.com<br />
                                        </p>
                                  </div>
                                </td>
                                <td background="../images/box_6.gif"> 
						
                                </td>

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
		<div class="copyright"><a href="/intro/about.aspx">关于傲赢</a>|<a href="/intro/service.aspx">服务条款</a>|<a href="/intro/law.aspx">法律声明</a>|<a href="/intro/contact.aspx">联系我们</a><br />Copyright 2007 100Allin.com All Rights Reserved<br />沪ICP备07510944号<input id="Hidden1" runat="server" style="width: 1px" type="hidden" /></div>
	</div>
</form>		
<script language="javascript" src="http://count48.51yes.com/click.aspx?id=485102224&logo=1"></script>	
</body>
</html>
