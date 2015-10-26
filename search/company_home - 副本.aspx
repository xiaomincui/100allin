<%@ Page Language="VB" AutoEventWireup="false" CodeFile="company_home.aspx.vb" Inherits="search_company_home" EnableEventValidation="false" ValidateRequest="false" %><%@ OutputCache Duration="300" VaryByParam="*" VaryByCustom="SessionID" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="货代,货代公司,货运代理,公司库,环球运费网" />
<meta name="description" content="货代名录(环球运费网公司库)拥有大量货代公司的注册信息,货代名录的会员资料齐全,每日有大量的新注册公司,加入成为货代公司库中的一员,货运代理公司尽在环球运费网货代名录" />
<title>货代名录-公司库,货运代理公司黄页,货代公司查询-环球运费网</title>
<link href="/css3/fcl.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server" autocomplete="off">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<script type='text/javascript'>document.getElementById('form1').action = window.location.href;</script>
<div class="h_box">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_1" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_1" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_1" runat="server" />
</div>
<div class="main">
<div class="s_bar">
<div class="s_bar_l"><img src="/images2/2011_fcl/bar1.gif" /></div>
<div class="s_bar_m">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
<ContentTemplate>
<div class="s_bar_mp">
<table width="890" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td align="right"><strong>公司名</strong>：</td>
<td><asp:TextBox ID="txtCompanyName" runat="server" Width="250"></asp:TextBox>
</td>
<td align="right"><strong>省</strong>：</td>
<td><asp:DropDownList ID="ddlcity1" runat="server" AutoPostBack="True" Width="150px"></asp:DropDownList></td>
<td align="right"><strong>市</strong>：</td>
<td><asp:DropDownList ID="ddlcity2" runat="server"  Width="150px"></asp:DropDownList></td>
<td align="center"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images2/2011_fcl/s_bt.jpg" /></td>
</tr>
</table>
</div>
</ContentTemplate>
</asp:UpdatePanel>					
</div>
<div class="s_bar_r"><img src="/images2/2011_fcl/bar2.gif" /></div>
<div class="fd_jt"><img src="/images2/2011_fcl/fdjt.jpg" /></div>
</div>
<div class="main_left_company">
		<div class="freight_List_title_company" style="background:url(/images2/2011_fcl/btbar_top2.jpg) no-repeat top; height:35px; padding:0px; line-height:35px;">
		 	 <h2 style="letter-spacing:2px;">热门货代公司</h2>
            &nbsp;<img style="margin-left:720px;" src="/images2/fcl/whao.gif"  /><a href="/help/help_fcl.html#tips" target="_blank">相关帮助</a></div>
		<div class="biaoti_company">
		    <table width="950" height="39" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td width="1" bgcolor="#CAC9C7"><img src="/images2/2011_fcl/btbar_l.gif" width="6" height="39" /></td>
                <td background="/images2/2011_fcl/btbar_bg.jpg"><table width="938" border="0" cellpadding="0" cellspacing="1">
                  <tr>
                    <td width="12" align="left" ></td>
                    <td width="90" align="left"><strong>公司名</strong></td>
                    <td width="250" align="left"><strong>&nbsp;</strong></td>
                    <td width="160" align="left"><strong>联系人</strong></td>
                    <td width="150" align="left"><strong>联系人</strong></td>
                    <td width="200" align="left"><strong>服务</strong></td>
                    <td width="76" align="left"><strong>联系方式</strong></td>
                  </tr>
                </table></td>
                <td width="1" ><img src="/images2/2011_fcl/btbar_r.gif" width="6" height="39" /></td>
              </tr>
          </table>
	  </div>
				<div class="freight_List">
				  <div class="list_box_company">
<ul>
					  <li style="background:url(/images2/2011_fcl/li_bg.jpg) repeat-x bottom;">
					    <table width="938" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td width="12" height="30" align="center" >·</td>
                            <td width="90" align="left"  class="picSmall"><a href="/company/VUR6THhyMUpMU292VFRvbGFid1B0QT09/" target="_blank"><img src="/member/Head/127584.jpg" width="50" height="50" border="0" /></a></td>
                            <td width="250" align="left"><a href="/company/VUR6THhyMUpMU292VFRvbGFid1B0QT09/" target="_blank" style="color:#971817;font-weight:bold;">上海康铁国际物流有限公司</a></td>
                            <td width="160" align="left">方小姐/路先生</td>
                            <td width="150" align="left">上海市-上海市</td>
                            <td width="200" align="left">全铁运输</td>
                            <td width="76" align="left"><a href="/company/VUR6THhyMUpMU292VFRvbGFid1B0QT09/" target="_blank" style="color:#666666;"><img src="/pm/p/images/e2.gif" border="0" title="点击查看联系方式" /></a></td>
                          </tr>                         
                        </table>
					  </li>
					</ul>

                      <asp:Repeater ID="RptNewUser" runat="server">
                      <ItemTemplate>
				    <ul>
					  <li style="background:url(/images2/2011_fcl/li_bg.jpg) repeat-x bottom;">
					    <table width="938" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td width="12" height="30" align="center" >·</td>
                            <td width="90" align="left"  class="picSmall"><a href="/company/<%#key(eval("userid")) %>/" target="_blank"><img src="/member/Head/<%#eval("userid") %>.jpg" width="50" height="50" border="0" /></a></td>
                            <td width="250" align="left"><a href="<%#IIf(Eval("userid")="73066","http://www.100allin.com/waysglobal/",IIf(Eval("userid")="74973","http://www.100allin.com/wsa/","/company/"& key(eval("userid")) & "/"))%>" target="_blank"><%#Eval("CompanyName").ToString()%></a></td>
                            <td width="160" align="left"><%#Eval("Realname").ToString()%></td>
                            <td width="150" align="left"><%#Eval("Login2_Locus1").ToString()%>-<%#Eval("Login2_Locus2").ToString()%></td>
                            <td width="200" align="left"><%#IIf(Eval("Login2_Adventage_Type_fcl").ToString() = "1", "整箱海运", "")%> <%#IIf(Eval("Login2_Adventage_Type_lcl").ToString() = "1", "拼箱海运", "")%> <%#IIf(Eval("Login2_Adventage_Type_air").ToString() = "1", "空运", "")%></td>
                            <td width="76" align="left"><a href="/company/<%#key(eval("userid"))%>/" target="_blank" style="color:#666666;"><img src="/images2/fcl/dingc_r62.gif" border="0" title="点击查看联系方式" /></a></td>
                          </tr>                         
                        </table>
					  </li>
					</ul>
                      </ItemTemplate>
                      </asp:Repeater>
				  </div>
				  <div class="page">
						<span class="selected">1</span>
						<a href="/company/list-------0-0----------2.html">2</a>
						<a href="/company/list-------0-0----------3.html">3</a>
						<a href="/company/list-------0-0----------4.html">4</a>
						<a href="/company/list-------0-0----------5.html">5</a>
						<a href="/company/list-------0-0----------6.html">6</a>
						<a href="/company/list-------0-0----------7.html">7</a>
						<a href="/company/list-------0-0----------8.html">8</a>
						<a href="/company/list-------0-0----------9.html">9</a>
						<a href="/company/list-------0-0----------10.html">10</a>
						<span>...</span>
						<a class="next" href="/company/list-------0-0----------1.html" style="padding:2px 12px 2px 6px;">下一页</a>
<%--						<a class="next" href="/fcl/list----0-0-0-----1.html" style="padding:2px 12px 2px 6px;">更多整箱海运价</a>--%>
				  </div>
				</div>
				
    </div>

<div class="t_box"><img src="/images2/2011_fcl/flei.jpg" /></div>
<div class="t_box"><table width="950" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="470" height="80" valign="top"><table width="470" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="15">&nbsp;</td>
<td width="139"><img src="/images2/2011_fcl/zxiang.jpg" width="139" height="45" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td height="3" colspan="3"></td>
</tr>
<tr>
<td style="background:url(images/2011_fcl/zxiang_bg.jpg) repeat-x top;">&nbsp;</td>
<td height="80" colspan="2" style="background:url(images/2011_fcl/zxiang_bg.jpg) repeat-x top;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="12"></td>
</tr>
<tr>
<td height="32"><strong>按起运港分类</strong></td>
</tr>
<tr>
<td><a href="/company/list-上海市-上海市-整箱海运----0-0----------1.html">上海港货代公司</a>  <a href="/company/list-广东省-深圳市-整箱海运----0-0----------1.html">深圳港货代公司</a>  <a href="/company/list-天津市-天津市-整箱海运----0-0----------1.html">天津港</a>  <a href="/company/list-浙江省-宁波市-整箱海运----0-0----------1.html">宁波港</a> <a href="/company/list-山东省-青岛市-整箱海运----0-0----------1.html">青岛港</a><br />
<a href="/company/list-福建省-厦门市-整箱海运----0-0----------1.html">厦门港</a>  <a href="/company/list-辽宁省-大连市-整箱海运----0-0----------1.html">大连港</a>  <a href="/company/list-广东省-广州市-整箱海运----0-0----------1.html">广州港</a>  <a href="/company/list-江苏省-连云港市-整箱海运----0-0----------1.html">连云港</a>  <a href="/company/list-河北省-秦皇岛市-整箱海运----0-0----------1.html">秦皇岛</a>  <a href="/company/list-辽宁省-营口市-整箱海运----0-0----------1.html">营口</a> <br />
<a href="/company/list-山东省-日照市-整箱海运----0-0----------1.html">日照港</a>  <a href="/company/list-辽宁省-唐山市-整箱海运----0-0----------1.html">唐山港</a>  <a href="/company/list-山东省-烟台市-整箱海运----0-0----------1.html">烟台港</a>  <a href="/company/list-江苏省-南通市-整箱海运----0-0----------1.html">南通港</a>  <a href="/company/list-江苏省-南京市-整箱海运----0-0----------1.html">南京港</a>  <a href="/company/list-广东省-佛山市-整箱海运----0-0----------1.html">佛山港</a>  <a href="/company/list-广东省-珠海市-整箱海运----0-0----------1.html">珠海港</a> <br />
<a href="/company/list-广东省-中山市-整箱海运----0-0----------1.html">中山港</a>  <a href="/company/list-广东省-湛江市-整箱海运----0-0----------1.html">湛江港</a>  <a href="/company/list-广东省-汕头市-整箱海运----0-0----------1.html">汕头港</a>  <a href="/company/list-福建省-泉州市-整箱海运----0-0----------1.html">泉州港</a>  <a href="/company/list-福建省-福州市-整箱海运----0-0----------1.html">福州港</a>  <a href="/company/list-广西省-防城港市-整箱海运----0-0----------1.html">防城港</a>  <a href="/company/list---整箱海运----0-0----------1.html">更多...</a> </td>
</tr>
</table></td>
</tr>
<tr>
<td height="13" colspan="3"></td>
</tr>
<tr>
<td style="background:url(images/2011_fcl/zxiang_bg.jpg) repeat-x top;">&nbsp;</td>
<td height="80" colspan="2" style="background:url(images/2011_fcl/zxiang_bg.jpg) repeat-x top;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="12"></td>
</tr>
<tr>
<td height="32"><strong>按航线分类</strong></td>
</tr>
<tr>
<td><a href="/company/list---整箱海运--美加--0-0----------1.html">美加线</a> <a href="/company/list---整箱海运--非洲--0-0----------1.html">非洲线</a> <a href="/company/list---整箱海运--中东印巴--0-0----------1.html">中东印巴线</a> <a href="/company/list---整箱海运--中南美--0-0----------1.html">中南美线</a> <a href="/company/list---整箱海运--欧地--0-0----------1.html">欧地线</a> <a href="/company/list---整箱海运--日韩--0-0----------1.html">日韩线</a> <a href="/company/list---整箱海运--近洋--0-0----------1.html">近洋线</a> <br/><a href="/company/list---整箱海运--澳洲--0-0----------1.html">澳洲线</a> <a href="/company/list---整箱海运--红海--0-0----------1.html">红海线</a></td>
</tr>
</table></td>
</tr>
<tr>
<td height="14" colspan="3"></td>
</tr>
<tr>
<td style="background:url(images/2011_fcl/zxiang_bg.jpg) repeat-x top;">&nbsp;</td>
<td height="80" colspan="2" style="background:url(images/2011_fcl/zxiang_bg.jpg) repeat-x top;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="12"></td>
</tr>
<tr>
<td height="32"><strong>按船公司分类</strong></td>
</tr>
<tr>
<td><a href="/company/list---整箱海运----0-0-马士基---------1.html">马士基</a>  <a href="/company/list---整箱海运----0-0-地中海---------1.html">地中海</a>  <a href="/company/list---整箱海运----0-0-川崎---------1.html">川崎</a>  <a href="/company/list---整箱海运----0-0-长荣---------1.html">长荣</a>  <a href="/company/list---整箱海运----0-0-太平---------1.html">太平</a>  <a href="/company/list---整箱海运----0-0-中海---------1.html">中海</a>  <a href="/company/list---整箱海运----0-0-东方海外---------1.html">东方海外</a>  <a href="/company/list---整箱海运----0-0-达飞---------1.html">达飞</a>  <a href="/company/list---整箱海运----0-0-中远---------1.html">中远</a>  <br /><a href="/company/list---整箱海运----0-0-以星---------1.html">以星</a>  <a href="/company/list---整箱海运----0-0-阳明---------1.html">阳明</a>  <a href="/company/list---整箱海运----0-0-美国总统---------1.html">美国总统</a>  <a href="/company/list---整箱海运----0-0-南美邮船---------1.html">南美邮船</a>  <a href="/company/list---整箱海运----0-0-现代---------1.html">现代</a>  <a href="/company/list---整箱海运----0-0-韩进---------1.html">韩进</a>  <a href="/company/list---整箱海运----0-0-万海---------1.html">万海</a> <a href="/company/list---整箱海运----0-0----------1.html">更多...</a> </td>
</tr>
</table></td>
</tr>
</table></td>
<td width="10" height="400" style="background: url(images/2011_fcl/t_box_1.gif) no-repeat top;">&nbsp;</td>
<td width="470" valign="top"><table width="470" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="15">&nbsp;</td>
<td width="139"><img src="/images2/2011_fcl/pxiang.jpg" width="139" height="45" /></td>
<td>&nbsp;</td>
</tr>
<tr>
<td height="3" colspan="3"></td>
</tr>
<tr>
<td style="background:url(images/2011_fcl/pxiang_bg.jpg) repeat-x top;">&nbsp;</td>
<td height="80" colspan="2" style="background:url(images/2011_fcl/pxiang_bg.jpg) repeat-x top;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="12"></td>
</tr>
<tr>
<td height="32"><strong>按起运港分类</strong></td>
</tr>
<tr>
<td><a href="/company/list-上海市-上海市-拼箱海运----0-0----------1.html">上海港货代公司</a> <a href="/company/list-广东省-深圳市-拼箱海运----0-0----------1.html">深圳港货代公司</a>  <a href="/company/list-天津市-天津市-拼箱海运----0-0----------1.html">天津港</a>  <a href="/company/list-浙江省-宁波市-拼箱海运----0-0----------1.html">宁波港</a> <a href="/company/list-山东省-青岛市-拼箱海运----0-0----------1.html">青岛港</a><br />
<a href="/company/list-福建省-厦门市-拼箱海运----0-0----------1.html">厦门港</a>  <a href="/company/list-辽宁省-大连市-拼箱海运----0-0----------1.html">大连港</a>  <a href="/company/list-广东省-广州市-拼箱海运----0-0----------1.html">广州港</a>  <a href="/company/list-江苏省-连云港市-拼箱海运----0-0----------1.html">连云港</a>  <a href="/company/list-河北省-秦皇岛市-拼箱海运----0-0----------1.html">秦皇岛</a>  <a href="/company/list-辽宁省-营口市-拼箱海运----0-0----------1.html">营口</a> <br />
<a href="/company/list-山东省-日照市-拼箱海运----0-0----------1.html">日照港</a>  <a href="/company/list-辽宁省-唐山市-拼箱海运----0-0----------1.html">唐山港</a>  <a href="/company/list-山东省-烟台市-拼箱海运----0-0----------1.html">烟台港</a>  <a href="/company/list-江苏省-南通市-拼箱海运----0-0----------1.html">南通港</a>  <a href="/company/list-江苏省-南京市-拼箱海运----0-0----------1.html">南京港</a>  <a href="/company/list-广东省-佛山市-拼箱海运----0-0----------1.html">佛山港</a>  <a href="/company/list-广东省-珠海市-拼箱海运----0-0----------1.html">珠海港</a> <br />
<a href="/company/list-广东省-中山市-拼箱海运----0-0----------1.html">中山港</a>  <a href="/company/list-广东省-湛江市-拼箱海运----0-0----------1.html">湛江港</a>  <a href="/company/list-广东省-汕头市-拼箱海运----0-0----------1.html">汕头港</a>  <a href="/company/list-福建省-泉州市-拼箱海运----0-0----------1.html">泉州港</a>  <a href="/company/list-福建省-福州市-拼箱海运----0-0----------1.html">福州港</a>  <a href="/company/list-广西省-防城港市-拼箱海运----0-0----------1.html">防城港</a>  <a href="/company/list---拼箱海运----0-0----------1.html">更多...</a> </td>
</tr>
</table></td>
</tr>
<tr>
<td height="13" colspan="3"></td>
</tr>
<tr>
<td style="background:url(images/2011_fcl/pxiang_bg.jpg) repeat-x top;">&nbsp;</td>
<td height="80" colspan="2" style="background:url(images/2011_fcl/pxiang_bg.jpg) repeat-x top;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="12"></td>
</tr>
<tr>
<td height="32"><strong>按航线分类</strong></td>
</tr>
<tr>
<td><a href="/company/list---拼箱海运--美加--0-0----------1.html">美加线</a> <a href="/company/list---拼箱海运--非洲--0-0----------1.html">非洲线</a> <a href="/company/list---拼箱海运--中东印巴--0-0----------1.html">中东印巴线</a> <a href="/company/list---拼箱海运--中南美--0-0----------1.html">中南美线</a> <a href="/company/list---拼箱海运--欧地--0-0----------1.html">欧地线</a> <a href="/company/list---拼箱海运--日韩--0-0----------1.html">日韩线</a> <a href="/company/list---拼箱海运--近洋--0-0----------1.html">近洋线</a> <br/><a href="/company/list---拼箱海运--澳洲--0-0----------1.html">澳洲线</a> <a href="/company/list---拼箱海运--红海--0-0----------1.html">红海线</a></td>
</tr>
</table></td>
</tr>
<tr>
<td height="14" colspan="3"></td>
</tr>
<tr>
<td style="background:url(images/2011_fcl/pxiang_bg.jpg) repeat-x top;">&nbsp;</td>
<td height="80" colspan="2" style="background:url(images/2011_fcl/pxiang_bg.jpg) repeat-x top;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="12"></td>
</tr>
<tr>
<td height="32"><strong></strong></td>
</tr>
<tr>
<td></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table>
</div>
<div class="t_box" style="margin-top:12px;"><img src="/images2/2011_fcl/haiyqt.jpg" width="950" height="39" /></div>
<div class="t_box">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td align="center"><a href="/company/list-------0-0--进口--------1.html"><img src="/images2/2011_fcl/sbt_r1_c1.jpg" width="136" height="47" border="0" /></a></td>
<td align="center"><a href="/company/list-------0-0--冷冻冷藏--------1.html"><img src="/images2/2011_fcl/sbt_r1_c3.jpg" width="136" height="47" border="0" /></a></td>
<td align="center"><a href="/company/list-------0-0--其他特种柜--------1.html"><img src="/images2/2011_fcl/sbt_r1_c5.jpg" width="136" height="47" border="0" /></a></td>
<td align="center"><a href="http://www.100allin.com/dangerouscargo/company/list.aspx?port=shanghai"><img src="/images2/2011_fcl/sbt_r3_c1.jpg" width="136" height="47" border="0" /></a></td>
<td align="center"><a href="/company/list-------0-0--私人物品--------1.html"><img src="/images2/2011_fcl/sbt_r3_c3.jpg" width="136" height="47" border="0" /></a></td>
<td align="center"><a href="/company/list-------0-0--散杂货船--------1.html"><img src="/images2/2011_fcl/sbt_r3_c5.jpg" width="136" height="47" border="0" /></a></td>
</tr>
</table>
</div>
<%--<img src="/images2/2011_fcl/midmid.jpg" border="0" usemap="#Map" />
<map name="Map" id="Map"><area shape="rect" coords="54,83,185,112" href="/products/products4.aspx" target="_blank" />
<area shape="rect" coords="269,83,402,116" href="/products/buy.aspx?type=4" target="_blank" /><area shape="rect" coords="487,3,946,132" href="/company/K0dhdnl3Z3F2djVvZVd5Z2VHeFJrQT09/" target="_blank" />
</map>-->
<%--<div class="cp_show" style="display:;">
<table width="930" height="209" border="0" cellpadding="0" cellspacing="0">
<tr>
<td><table width="930" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="466"><a href="/company/WkQ0akpsOUdDUW9sMWNWbWxlckxNdz09/" target="_blank"><img src="/images2/2011_fcl/show_picc.gif" width="466" height="208" border="0" /></a></td>
<td width="464" valign="top"><table width="100%" border="0" cellspacing="2" cellpadding="0">
<tr>
<td width="4%">&nbsp;</td>
<td width="96%" height="60" >&nbsp;</td>
</tr>
<tr>
<td width="4%">&nbsp;</td>
<td width="96%" class="wit"><strong><a href="/company/S084TkU5SWRyeHFrUE5kemNCdkMwZz09/" style="color:#fff" target="_blank">上海瀛和物流有限公司</a></strong></td>
</tr>
<tr>
<td height="10" colspan="2"></td>
</tr>
<tr>
<td width="4%">&nbsp;</td>
<td width="96%" class="wit">上榜理由：<br />
拥有专业团队，专业的服务是我司的特色。从事海运业务多年，并具备相当丰富的经验。诚信、敬业、热情、高效的为广大客户服务。主要经营CSAV中东印巴整箱、NDS非洲线。价格优惠、操作规范。
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table>
</div>--%>

<div style="width:950px; float:left; margin:12px 0;display:none;"><a href="/topic/solution20100826/" target="_blank"><img src="/images2/2011_fcl/jz.jpg" border="0" /></a></div>
<div class="t_box" style="display:none;">
<table width="950" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="688" valign="top"><img src="/images2/2011_fcl/tuijian.jpg" width="688" height="32" /></td>
<td width="19" rowspan="3">&nbsp;</td>
<td width="243" rowspan="3"><a href="/supplier/" target="_blank"><img src="/images2/2011_fcl/ysdl.gif" width="242" height="128" border="0" /></a></td>
</tr>
<tr>
<td height="8" valign="top">&nbsp;</td>
</tr>
<tr>
<td align="center" valign="top"><table width="660" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="31%" valign="top"><table width="186" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="46%" height="24" align="left"><a href="http://www.100allin.com/company/S084TkU5SWRyeHFrUE5kemNCdkMwZz09/" target="_blank">上海瀛和</a></td>
<td width="23%" align="left">上海</td>
<td width="31%" align="right">中东印巴</td>
</tr>
<tr>
<td height="24" align="left"><a href="http://www.100allin.com/company/Y0crNzBaUkVDOUhVRXJTSnM4MGpPZz09/" target="_blank">天津长宜</a></td>
<td align="left">天津</td>
<td align="right">非洲线</td>
</tr>
<tr>
<td height="24" align="left"><a href="http://www.100allin.com/company/Ykl1Y0NYME5SVEt0bGR5S3RwbFBiUT09/" target="_blank">上海月恒</a></td>
<td align="left">上海</td>
<td align="right">美加线</td>
</tr>
</table></td>
<td width="2%" valign="top"><img src="/images2/2011_fcl/ddian.gif" width="1" height="80" /></td>
<td width="32%" align="center" valign="top"><table width="186" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="46%" height="24" align="left"><a href="http://www.100allin.com/company/SkxSZ000VUZrWEplSy9aM3EzeWIzZz09/" target="_blank">上海晋豪</a></td>
<td width="23%" align="left">上海</td>
<td width="31%" align="right">中南美线</td>
</tr>
<tr>
<td height="24" align="left"><a href="http://www.100allin.com/company/QkMxQ1k3dlpoeGJWaFRROFE0WEJLZz09/" target="_blank">上海集捷</a></td>
<td align="left">上海</td>
<td align="right">近洋线</td>
</tr>
<tr>
<td height="24" align="left"><a href="http://www.100allin.com/company/clErVGswRHVmNEVseXRSbVNBNndMZz09/" target="_blank">宁波宝航</a></td>
<td align="left">宁波</td>
<td align="right">非洲线</td>
</tr>
</table></td>
<td width="2%" valign="top"><img src="/images2/2011_fcl/ddian.gif" width="1" height="80" /></td>
<td width="33%" align="center" valign="top"><table width="186" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="46%" height="24" align="left"><a href="http://www.100allin.com/company/WkQ0akpsOUdDUW9sMWNWbWxlckxNdz09/" target="_blank">上海标航</a></td>
<td width="23%" align="left">上海</td>
<td width="31%" align="right">中南美线</td>
</tr>
<tr>
<td height="24" align="left"><a href="http://www.100allin.com/supplier/company_detail.aspx?str=OXlSRmExYVk0Q1RNVmUyYnlBU2w2Zz09&line=%e7%ba%a2%e6%b5%b7%e7%ba%bf&startport=%e5%a4%a9%e6%b4%a5" target="_blank">天津迈拓</a></td>
<td align="left">天津</td>
<td align="right">红海线</td>
</tr>
<tr>
<td height="24" align="left"><a href="http://www.100allin.com/supplier/company_detail.aspx?str=eUI2ZXh3endCclhqQ2ZUenJMTXZDdz09&line=%e6%ac%a7%e5%9c%b0%e7%ba%bf&startport=%e5%ae%81%e6%b3%a2" target="_blank">宁波格奥特</a></td>
<td align="left">宁波</td>
<td align="right">欧地线</td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table>
</div>
<div class="bot_box">
<div class="bot_box_l"><img src="/images2/2011_fcl/bt_l.gif" /></div>
<div class="bot_box_m">
<div class="sp_m" style="width:698px;">
<h2>&nbsp;<img src="/images2/2011_fcl/book_1.jpg" width="26" height="31" />空运公司分类</h2>
<table width="670" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td height="1" bgcolor="#CFCFCF"></td>
</tr>
<tr>
<td height="10"></td>
</tr>
<tr>
<td height="60" align="center"><a href="#"></a><a href="#"></a>
  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="sp_m_link">
    <tr>
      <td height="24" align="left"><strong>按起运地分类</strong><br />
        <a href="/company/list-上海市-上海市-空运----0-0----------1.html">上海</a> <a href="/company/list-广东省-深圳市-空运----0-0----------1.html">深圳</a> <a href="/company/list-广东省-广州市-空运----0-0----------1.html">广州</a> <a href="/company/list-北京市-北京市-空运----0-0----------1.html">北京</a> <a href="/company/list-香港特别行政区-香港特别行政区-空运----0-0----------1.html">香港</a> <a href="/company/list-浙江省-杭州市-空运----0-0----------1.html">杭州</a>  <a href="/company/list-江苏省-南京市-空运----0-0----------1.html">南京</a><br />
        <a href="/company/list-福建省-厦门市-空运----0-0----------1.html">厦门</a> <a href="/company/list-山东省-青岛市-空运----0-0----------1.html">青岛</a> <a href="/company/list-广东省-珠海市-空运----0-0----------1.html">珠海</a>  <a href="/company/list-湖南省-长沙市-空运----0-0----------1.html">长沙</a> <a href="/company/list-湖北省-武汉市-空运----0-0----------1.html">武汉</a> <a href="/company/list-四川省-成都市-空运----0-0----------1.html">成都</a> <a href="/company/list-重庆市-重庆市-空运---北美-0-0----------1.html">重庆</a> <a href="/company/list-浙江省-宁波市-空运----0-0----------1.html">宁波</a> <a href="/company/list-辽宁省-大连市-空运----0-0----------1.html">大连</a>
                </td>
      </tr>
	  <tr>
      <td height="8" align="left"></td>
      </tr>
    <tr>
      <td height="24" align="left"><strong>按航线分类</strong><br />
        <a href="/company/list---空运---北美-0-0----------1.html">北美线</a> <a href="/company/list---空运---欧洲-0-0----------1.html">欧洲线</a> <a href="/company/list---空运---南美-0-0----------1.html">南美线</a> <a href="/company/list---空运---亚洲-0-0----------1.html">亚洲线</a> <a href="/company/list---空运---非洲-0-0----------1.html">非洲线</a> <a href="/company/list---空运---澳洲-0-0----------1.html">澳洲线</a> <a href="/company/list---空运---近洋-0-0----------1.html">近洋线</a> <a href="/company/list---空运---国内-0-0----------1.html">国内航线</a> </td>
      </tr>
	  <tr>
      <td height="8" align="left"></td>
      </tr>
<%--        <tr>
      <td height="24" align="left"><strong>其他空运相关</strong><br />
        快递服务</td>
      </tr>--%>
  </table>      
  </td>
</tr>
</table>

		</div>
			<div class="sp_l" style="border:none; float:right; width:auto;"><a href="/topic/air090716/" target="_blank"><img src="/images2/2011_fcl/ky.jpg" width="234" height="236" border="0" /></a></div>
	  </div>
		<div class="bot_box_r"><img src="/images2/2011_fcl/bt_r.gif" /></div>
	</div>
<userbottomline:userbottomline ID="userbottomline1" runat="server" />
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div>
</form>
</body>
</html>
