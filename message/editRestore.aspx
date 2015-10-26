<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editRestore.aspx.cs" Inherits="message_editRestore" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>傲赢网 - 论坛</title>
    <link href="../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../css/list.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--
#pp td{nowrap=true;}
-->
</style>
<script language="javascript" type="text/javascript" src="../js/function.js"></script>

</head>
<body onload="AutoTips('officetips')">
<form id="form2" runat="server" autocomplete="off" onKeydown="if(event.enterKey){return   false}">
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
					<div id="help"><a href="/">回到首页</a>|<a href="#" onclick="var strHref=window.location.href;this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.100allin.com');">设为首页</a>|<a href="#" onclick="window.external.addFavorite('http://www.100allin.com','傲赢网-发布搜索运价平台')">加入收藏</a>|<a href="javascript:;">使用帮助</a>|<a href="javascript:;" onclick="document.getElementById('servicebox').style.display = '';" style="color:#FF0000; font-weight:bold;" title="点击此处打开客户服务列表">客户服务</a><DIV id="servicebox" style="Z-INDEX:999; right:10px; top:30px; POSITION: absolute;  display:none;"><img src="../images/servicebox_head1.gif"  width="108" height="30" border="0" onclick="document.getElementById('servicebox').style.display = 'none';" style="cursor:pointer;" alt="点击此处隐藏客户服务列表" id="servicebox_head" /><br />
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
				<div id="left">
				 <userlogin:userlogin id="Userlogin1" runat="server" />
							
				</div>
				<div id="right">
                        <div>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 31px" width="10">
                                        <img height="31" src="../member/images/box_1.gif" width="10" /></td>
                                    <td background="../member/images/box_2.gif" style="height: 31px" width="780">
                                        <div class="smallBoxTitle">
                                        <a href="BBSList.aspx"><asp:Label ID="Label11" runat="server" Text="论坛首页"></asp:Label></a>
                                         > &nbsp;<asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                                            &gt; &nbsp;
                                            <asp:Label ID="Label1" runat="server" Text="编辑回帖"></asp:Label>
                            </div>
                                    </td>
                                    <td style="width: 11px; height: 31px">
                                        <img height="31" src="../member/images/box_3.gif" width="10" /></td>
                                </tr>
                                <tr height="40px">
                                    <td  background="../images/box_4.gif" width="10">
                                    </td>
                                    <td  width="780">
                                        <div  style=" float:left; margin-left : 2px">
                                            <a href="default.aspx"><asp:Image ImageUrl="~/message/images/release.gif" ID="Image1" runat="server" /></a>
                                        </div>
                                        <div  style=" float:left; margin-left : 5px">
                                            <a href="BBSList.aspx"><asp:Image ImageUrl="~/message/images/BBSdefalut.gif" ID="Image2" runat="server" /></a>
                                        </div>
                                            
                                    </td>
                                    <td background="../images/box_6.gif" style="width: 10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" background="images/bluepoint.gif" style="height: 1px; border-right: white 1px dotted;">
                                    </td>
                                </tr>
                                <tr>
                                    <td background="../member/images/box_4.gif" style="height: 15px">
                                    </td>
                                    <td>
                                    <br />
                            <table>
                                <tr>
                                    <td style="width: 65px; text-align: center">
                                        正文</td>
                                    <td>
                            <asp:TextBox ID="TextBox1" runat="server" Height="324px" TextMode="MultiLine" Width="664px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/message/UBBCodeHelp.aspx"
                                            Target="_blank">如何发图片</asp:HyperLink></td>
                                </tr>
                                <tr>
									<td>&nbsp;</td>
                                    <td>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="发表帖子" Font-Size="14px" Width="90px" Height="30px"/>
                                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回列表" Font-Size="14px" Width="90px" Height="30px"/></td>
                                </tr>
                                <tr>
                                  <td>&nbsp;</td>
                                  <td>&nbsp;</td>
                                </tr>
                            </table>
                                    </td>
                                    <td background="../member/images/box_6.gif" style="width: 11px; height: 15px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img height="10" src="../member/images/box_7.gif" width="10" /></td>
                                    <td background="../member/images/box_8.gif">
                                    </td>
                                    <td style="width: 11px;">
                                        <img height="10" src="../member/images/box_9.gif" width="10" /></td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            </div>
                    
                    
                    



				
				
				
				
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
<script language="javascript" src="http://count48.51yes.com/click.aspx?id=485102224&logo=1">
function right_onclick() {

}

</script>	
</body>
</html>