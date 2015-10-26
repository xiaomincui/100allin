<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ship.aspx.cs" Inherits="ship_ship" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <asp:Literal id="Litkey" runat="server"><meta name="keywords" content="船公司-环球运费网" /></asp:Literal>
<asp:Literal id="Litdes" runat="server"><meta name="description" content="船公司-环球运费网" /></asp:Literal>
<asp:Literal id="Littitle" runat="server"><title>船公司-环球运费网</title></asp:Literal> 
    <script type="text/javascript" src="/js/home.js"></script>
    <link href="css/ships.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="h_box">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_1" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_1" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_1" runat="server" />
</div>
	  <div class="menu">
			<h1><a href="/">首页</a> > <a href="http://www.100allin.com/ship/">船公司列表</a> > <asp:Literal
                    ID="Literal7" runat="server"></asp:Literal></h1>
		  <span class="right_tn"><%--<a href="#">免费注册会员，有惊喜收获</a>--%></span>		</div>
			<div class="main_box">
				<div class="main_box_right">
					<h1>&nbsp;</h1>
					<ul>
						<li><a href="/bis/commodity.aspx"><img src="images/Storage/ico_2.GIF" width="16" height="16" border="0"/>报关商检</a></li>
						<li><a href="/bis/nvocc.aspx"><img src="images/Storage/ico_3.GIF" border="0"/>无船承运人</a></li>
						<li><a href="/bis/hongkong.aspx"><img src="images/Storage/ico_4.GIF" border="0" />香港公司</a></li>
						<li><a href="/bis/insss.aspx"><img src="images/Storage/ico_5.GIF" border="0"/>保险</a></li>
						<li><a href="/bis/bank.aspx"><img src="/images/Storage/ico_8.GIF" border="0"/>银行</a></li>
						<li><a style="color:#FF6600; font-weight:bold; background: url(images/Storage/li_hover.gif) no-repeat right; text-decoration:none;" href="/ship/"><img src="images/Storage/ico_7.GIF" border="0"/>船公司联系方式</a></li>
						<li><a href="/ports"><img src="/images/Storage/ico_9.GIF" border="0" />世界港口查询</a></li>
					</ul>
					<div style="line-height:24px;margin-top:12px; padding:12px 0 0 40px;background:url(images/Storage/h1_bg.gif) no-repeat center top;"><strong>澳亚航运AAL船公司<br />近期公告</strong></div>
					<p style="background:none; padding-top:0px;">
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate><a href="../bbs/thread-<%#Eval("id").ToString() %>-1.html"><%#GetFirstString(Eval("title").ToString(),18)%></a><br /></ItemTemplate>
                        </asp:Repeater>
				  </p>
					<div style="line-height:24px;margin-top:12px; padding:12px 0 0 40px; background:url(images/Storage/h1_bg.gif) no-repeat center top;"><strong>澳亚航运AAL船公司<br />附加费查询</strong></div>
					<p style="background:none; padding-top:0px;">
					
					<asp:Literal ID="Literal8" runat="server"></asp:Literal>
					<asp:Literal ID="Literal9" runat="server"></asp:Literal>
					</p>
					<div style="line-height:24px;margin-top:12px; padding:12px 0 0 40px; background:url(images/Storage/h1_bg.gif) no-repeat center top;"><strong>热门船公司查询</strong></div>
					<p style="background:none; padding-top:0px;">
                        <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                        <a href="/ship/list-<%#Eval("search").ToString()%>-------1.html"><%#Eval("search").ToString()%></a><br />
                        </ItemTemplate>
                        </asp:Repeater>
					
					</p>
				</div>
				<div class="main_box_left">
					  <h1>
                          <asp:Literal ID="Literal1" runat="server"></asp:Literal></h1>
				  <div class="box_company">
				    <table width="100%" border="0" cellspacing="1" cellpadding="0">
                      <tr>
                        <td width="10%" height="72" align="center"><img src="images/Storage/ddt.gif" width="113" height="58" /></td>
                        <td width="89%" style="font-size:14px;"><strong><asp:Literal ID="Literal2" runat="server"></asp:Literal></strong></td>
                      </tr>
                      <tr>
                        <td align="right">公司网址：</td>
                        <td><asp:Literal ID="Literal3" runat="server"></asp:Literal></td>
                      </tr>
                      <tr>
                        <td align="right">货物跟踪：</td>
                        <td><asp:Literal ID="Literal4" runat="server"></asp:Literal></td>
                      </tr>
                      <tr>
                        <td align="right" valign="top" >联系方式：</td>
                        <td><asp:Literal ID="Literal5" runat="server"></asp:Literal></td>
                      </tr>
                      <tr>
                        <td align="center">&nbsp;</td>
                        <td>&nbsp;</td>
                      </tr>
                      <tr>
                        <td align="center">&nbsp;</td>
                        <td>&nbsp;</td>
                      </tr>
                      <tr>
                        <td align="center">&nbsp;</td>
                        <td>&nbsp;</td>
                      </tr>
                      <tr>
                        <td align="center">&nbsp;</td>
                        <td>&nbsp;</td>
                      </tr>
                      <tr>
                        <td align="center">&nbsp;</td>
                        <td>&nbsp;</td>
                      </tr>
                      <tr>
                        <td align="center">&nbsp;</td>
                        <td>&nbsp;</td>
                      </tr>
                    </table>
				  </div>
				  <div class="box_company">
				    <table width="100%" border="0" cellspacing="1" cellpadding="0">
                      <tr>
                        <td height="38" colspan="4" align="left"><img src="images/Storage/LedIcon_367.png" width="16" height="16" />&nbsp;<strong>船公司各港口优质货代推荐</strong></td>
                      </tr>
                      <tr>
                        <td width="25%" height="38" align="center" valign="middle"><a href="../company/list-上海市-上海市-----0-0----------1.html"><img src="images/Storage/shg.gif" width="109" height="27" border="0" /></a></td>
                        <td width="25%" height="38" align="center" valign="middle"><a href="../company/list-广东省-深圳市-----0-0----------1.html"><img src="images/Storage/sz.gif" width="109" height="27" border="0" /></a></td>
                        <td width="25%" height="38" align="center" valign="middle"><a href="../company/list-浙江省-宁波市-----0-0----------1.html"><img src="images/Storage/nb.gif" width="109" height="27" border="0" /></a></td>
                        <td width="25%" height="38" align="center" valign="middle"><a href="../company/list-天津市-天津市-----0-0----------1.html"><img src="images/Storage/tj.gif" width="109" height="27" border="0" /></a></td>
                      </tr>
                      <tr>
                        <td width="25%" height="38" align="center" valign="middle"><a href="../company/list-广东省-广州市-----0-0----------1.html"><img src="images/Storage/gz.gif" width="109" height="27" border="0" /></a></td>
                        <td width="25%" height="38" align="center" valign="middle"><a href="../company/list-山东省-青岛市-----0-0----------1.html"><img src="images/Storage/qd.gif" width="109" height="27" border="0" /></a></td>
                        <td width="25%" height="38" align="center" valign="middle"><a href="../company/list-福建省-厦门市-----0-0----------1.html"><img src="images/Storage/xm.gif" width="109" height="27" border="0" /></a></td>
                        <td width="25%" height="38" align="center" valign="middle"><a href="../company/list-辽宁省-大连市-----0-0----------1.html"><img src="images/Storage/dl.gif" width="109" height="27" border="0" /></a></td>
                      </tr>
                    </table>
				  </div>
				  <div class="box_company" style=" padding-bottom:48px; border-bottom:none">
				    <table width="100%" border="0" cellspacing="1" cellpadding="0">
                      <tr>
                        <td height="38" align="left"><img src="images/Storage/fatcow_097.png" width="16" height="16" />&nbsp;<strong>船公司介绍</strong></td>
                      </tr>
                      <tr>
                        <td valign="middle">
                        <p>　　
                            <asp:Literal ID="Literal6" runat="server"></asp:Literal>
　　
　　</p>
　　
　　</td>
                      </tr>
                    </table>
				  </div>
			  </div>
			</div>	
		
	    <userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
	</div>
    </form>
    <script language="javascript">
<!--
if(typeof(LiveReceptionCode_isonline)!='undefined'  && LR_GetObj('LR_User_Icon1')!=null)
{
if(LiveReceptionCode_isonline)
LR_GetObj('LR_User_Icon1').innerHTML='<a '+LiveReceptionCode_BuildChatWin('您有新访客','您好，请问有什么需要帮忙？')+'><b>点击这里</b></a>';
else
LR_GetObj('LR_User_Icon1').innerHTML='<a '+LiveReceptionCode_BuildChatWin('您有新访客','客服人员不在线,请点击留言')+'><b>点击这里</b></a>';
}
//-->
</script>
</body>
</html>
