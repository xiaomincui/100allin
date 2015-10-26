<%@ Page Language="VB" AutoEventWireup="false" CodeFile="air_home.aspx.vb" Inherits="search_air_home" EnableEventValidation="false" ValidateRequest="false" EnableViewState="false"%><%@ OutputCache Duration="300" VaryByParam="*" VaryByCustom="SessionID" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>空运运费发布,空运价格,空运代理报价及订舱服务-环球运费网</title>
<meta name="description" content="空运价格专栏,空运最新空运运费,空运运价查询,环球运费网" />
<meta name="keywords" content="空运 运费 运价" />
<link href="/css3/fcl.css" rel="stylesheet" type="text/css" />
<link href="/js/auto/port.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="/js/auto/ac_zd.js"></script>
<script type="text/javascript" language="javascript" src="/js/auto/airprot_ch.js"></script>
<script type="text/javascript" language="javascript" src="/js/auto/ac_zd_head_air.js"></script>
<script type="text/javascript" src="/js/MSClass.js"></script>
<script type="text/javascript" src="/js/home.js"></script>
<script language="javascript" type="text/javascript" src="/js/air_home.js"></script>
</head>
<body>
<div id="messages"></div>
<form id="form1" runat="server" autocomplete="off">
<script type='text/javascript'>document.getElementById('form1').action = window.location.href;</script>
	<div class="h_box">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_1" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_1" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_1" runat="server" />
		</div>
	<div class="main">
	<div id="mm" style="position:absolute;  background:#FFFFFF; left:10px;border:1px solid #999999; visibility:hidden; z-index:10;"></div>
	<div class="tchu_box" id="more" style="position:absolute; width:225px; left:10px; visibility:hidden; padding:10px; line-height:22px; z-index:100;">
<div class="tchu_box_top"></div>
<div class="tchu_box_mid" id="more_in"></div>
<div class="tchu_box_bot"></div>
</div>
<div class="tchu_box" id="moredp" style="position:absolute; width:429px; left:10px; visibility:hidden; padding:10px; line-height:22px; z-index:100;">
<div class="tchu_box_top" style="width:429px;background:url(../images/fcl/tchu1_b.gif) no-repeat top;"></div>
<div class="tchu_box_mid" id="moredp_in" style="width:399px;line-height:12px;background:url(../images/fcl/tchu_bg_b.gif) repeat-y;">
<div style="width: 400px;">
<div style="padding-bottom:5px;font-size:12px;  "><strong>点击选择目的地（按字母排列）</strong>
<a id="language_zh" class="select_Language" onmouseover="ch_lan(this,'en')" style="margin-left:100px;">中文</a> <a id="language_en" class="noselect_Language" onmouseover="ch_lan(this,'zh')">English</a>
</div>        
<div id="tab_list"><ul><li id="AC" class="tab_li_on">A-C</li><li id="DK">D-K</li><li id="LO">L-O</li><li id="PS">P-S</li><li id="TZ">T-Z</li></ul></div>
<div style="clear:both;"></div>
<div class="p_l_d"><ul id="prot_list_u" class="prot_ul"><li></li><li></li><li></li><li></li><li><img src="/js/autocomplete/loading.gif" /></li><li>正在载入港口列表...</li><li></li><li></li><li></li><li></li></ul></div>
<div style="clear: both;"></div>
<div id="page_number"></div>
<div style="clear: both;"></div>
</div>
</div>
<div class="tchu_box_bot" style="width:429px;background:url(../images/fcl/tchu2_b.gif) no-repeat top;"></div>
</div>	

<div class="tchu_box" id="morecarrier" style="position:absolute; width:225px; left:10px; visibility:hidden; padding:10px; line-height:22px; z-index:100;">
<div class="tchu_box_top"></div>
<div class="tchu_box_mid" id="morecarrier_in"></div>
<div class="tchu_box_bot"></div>
</div>
		<div class="s_bar">
			<div class="s_bar_l"><img src="/images2/2011_fcl/bar1.gif" /></div>
			<div class="s_bar_m">
				<div class="s_bar_mp">
				  <table width="890" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                      <td align="right"><strong>航线</strong>：</td>
                      <td>
                        <asp:DropDownList ID="txtLine" runat="server" Width="105" Height="22" Font-Size="13px">
                        <asp:ListItem Text="全部航线" Value=""></asp:ListItem>
                        <asp:ListItem>北美线</asp:ListItem>
                        <asp:ListItem>欧洲线</asp:ListItem>
                        <asp:ListItem>南美线</asp:ListItem>
                        <asp:ListItem>亚洲线</asp:ListItem>
                        <asp:ListItem>非洲线</asp:ListItem>
                        <asp:ListItem>澳洲线</asp:ListItem>
                        <asp:ListItem>国内航线</asp:ListItem>
                        </asp:DropDownList>                      
                      </td>
                      <td align="right"><strong>起运地</strong>：</td>
                      <td><asp:TextBox ID="txtStartport" runat="server" Width="200px" sou_type="air_start" onfocus="auto_init(event,this);" onclick="autowords(this,event);"></asp:TextBox></td>
                      <td align="right"><strong>目的地</strong>：</td>
                      <td><asp:TextBox ID="txtDestport" runat="server" Width="200px" sou_type="air_port" onfocus="auto_init(event,this);" onclick="autowords(this,event);"></asp:TextBox></td>
                      <td align="center"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images2/2011_fcl/s_bt.jpg" /></td>
                    </tr>
                  </table>
				</div>
			</div>
			<div class="s_bar_r"><img src="/images2/2011_fcl/bar2.gif" /></div>
			<div class="fd_jt"><img src="/images2/2011_fcl/fdjt.jpg" /></div>
	  </div>

	  	<div style="width:950px; float:left; margin-bottom:12px; display:none;"><a href="http://www.100allin.com/company/NUFTVnZYZENsazNySnBPS0JtWm5xZz09/" target="_blank"><img src="/images2/banner/by950.jpg" border="0" /></a></div>
		<div class="main_left">
		<div class="freight_List_title" style="background:url(/images2/2011_fcl/btbar_top.jpg) no-repeat top; height:35px; padding:0px; line-height:35px;">
		 	 <h2 style="letter-spacing:2px;">空运运价列表</h2>
            &nbsp;<a href="/member/releaseselect.aspx" target="_blank">我要发布运价</a><img style="margin-left:440px;" src="/images2/fcl/whao.gif"  /><a href="/help/help_fcl.html#tips" target="_blank">相关帮助</a>	  </div>
		<div class="biaoti">
		    <table width="742" height="39" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td width="1" bgcolor="#CAC9C7"><img src="/images2/2011_fcl/btbar_l.gif" width="6" height="39" /></td>
                <td background="/images2/2011_fcl/btbar_bg.jpg"><table width="730" border="0" cellpadding="0" cellspacing="1">
                  <tr>
                    <td width="10" align="left" ></td>
                    <td width="179" align="left"><strong>标题</strong></td>
                    <td width="90" align="left"><strong>起运地</strong></td>
                    <td width="100" align="left"><strong>目的地</strong></td>
                    <td width="231" align="left"><strong>运价<span style="font-weight:normal;">(+45|+100|+300|+500|+1000)</span></strong></td>
                    <td width="120" align="left"><strong>公司名</strong></td>
                  </tr>
                </table></td>
                <td width="1" ><img src="/images2/2011_fcl/btbar_r.gif" width="6" height="39" /></td>
              </tr>
          </table>
	  </div>
				<div class="freight_List">
				  <div class="list_box">
                      <asp:Repeater ID="Repeater1" runat="server">
                      <ItemTemplate>
				    <ul  onmouseover="tt('<%#Repeater1.Items.Count %>',3)" onmouseout="hidden()">
					  <li style="background:url(/images2/2011_fcl/li_bg.jpg) repeat-x bottom;">
					    <table width="730" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td width="19" height="30" align="center" >·</td>
                            <td width="170" align="left" class="red_5"><div class="tb_freight_01"><asp:Literal ID="Literal1" runat="server" Text='<%# Eval("id")%>' Visible="false"></asp:Literal><asp:Literal ID="Literal2" runat="server" Text='<%# Eval("userid")%>' Visible="false"></asp:Literal><a href="/air/<%#key(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>"><%#Eval("title").ToString()%></a></div></td>
                            <td width="90" align="left"><div class="tb_freight_02"><%#Eval("startport").ToString.ToUpper()%></div></td>
                            <td width="90" align="left"><div class="tb_freight_02"><%#Eval("destport").ToString.ToUpper()%></div></td>
                            <td width="45" align="left"><div class="air_price_detail"><b>&nbsp;</b> <%#output(Eval("PRICE_P45").ToString())%></div></td>
                            <td width="45" align="left"><div class="air_price_detail"><b>|</b> <%#output(Eval("PRICE_P100").ToString())%></div></td>
                            <td width="45" align="left"><div class="air_price_detail"><b>|</b> <%#output(Eval("PRICE_P300").ToString())%></div></td>
                            <td width="45" align="left"><div class="air_price_detail"><b>|</b> <%#output(Eval("PRICE_P500").ToString())%></div></td>
                            <td width="45" align="left"><div class="air_price_detail"><b>|</b> <%#output(Eval("PRICE_P1000").ToString())%></div></td></td>
                            <td width="120" align="left"><div class="tb_freight_05"><a href="<%#IIf(Eval("userid")="122117","http://www.100allin.com/shop/jjb/","/company/"& key(eval("userid")) & "/")%>" target="_blank" title="<%#Eval("companyname").ToString()%>"><%#Eval("companyname").ToString()%></a></div></td>
                          </tr>                         
                        </table>
					  </li>
					</ul>
                      </ItemTemplate>
                      </asp:Repeater>
				  </div>
				  <div class="page_head">共有<asp:Literal ID="Literal1" runat="server"></asp:Literal>条空运运价</div>
				  <div class="page">
						<span class="selected">1</span>
						<a href="/air/list----0-0-0-----2.html">2</a>
						<a href="/air/list----0-0-0-----3.html">3</a>
						<a href="/air/list----0-0-0-----4.html">4</a>
						<a href="/air/list----0-0-0-----5.html">5</a>
						<a href="/air/list----0-0-0-----6.html">6</a>
						<a href="/air/list----0-0-0-----7.html">7</a>
						<a href="/air/list----0-0-0-----8.html">8</a>
						<a href="/air/list----0-0-0-----9.html">9</a>
						<a href="/air/list----0-0-0-----10.html">10</a>
						<span>...</span>
						<a class="next" href="/air/list----0-0-0-----1.html" style="padding:2px 12px 2px 6px;">下一页</a>					  
<%--						<a class="next" href="/air/list----0-0-0-----1.html" style="padding:2px 12px 2px 6px;">更多空运运价</a>--%>
				  </div>
				</div>
				
	  </div>
		<div class="main_right">
			<div class="r_nav">
				<div class="r_nav_top"><img src="/images2/2011_fcl/r_nav_top.gif" /></div>
				<div class="r_nav_md">
					<h2>分类筛选</h2>
					<ul>
					  <h3><img src="/images2/2011_fcl/ico1.gif" />选择起运地</h3>
					  <P><a href = "/air/list----0-0-0-----1.html">全部</a>&nbsp;<a href = "/air/list-shanghai---0-0-0-----1.html">上海</a>&nbsp;<a href = "/air/list-shenzhen---0-0-0-----1.html">深圳</a>&nbsp;<a href = "/air/list-guangzhou---0-0-0-----1.html">广州</a>&nbsp;<a href = "/air/list-beijing---0-0-0-----1.html">北京</a>&nbsp;<br/><a href = "/air/list-hongkong---0-0-0-----1.html">香港</a>&nbsp;<a href = "/air/list-hangzhou---0-0-0-----1.html">杭州</a>&nbsp;<a href = "/air/list-nanjing---0-0-0-----1.html">南京</a>&nbsp;<a href = "/air/list-xiamen---0-0-0-----1.html">厦门</a>&nbsp;<a href = "/air/list-qingdao---0-0-0-----1.html">青岛</a>&nbsp;<br/><a href = "/air/list-zhuhai---0-0-0-----1.html">珠海</a>&nbsp;<a href = "/air/list-changsha---0-0-0-----1.html">长沙</a>&nbsp;<a href = "/air/list-wuhan---0-0-0-----1.html">武汉</a>&nbsp;<a href = "/air/list-chengdu---0-0-0-----1.html">成都</a>&nbsp;<a href = "/air/list-chongqing---0-0-0-----1.html">重庆</a>&nbsp;<br/><a href = "/air/list-ningbo---0-0-0-----1.html">宁波</a>&nbsp;<a href = "/air/list-dalian---0-0-0-----1.html">大连</a>&nbsp;<a href = "/air/list----0-0-0-----1.html">更多...</a></P>
					  <h3><img src="/images2/2011_fcl/ico2.gif" />选择航线</h3>
					  <P><a href = "/air/list----0-0-0-----1.html">全部</a>&nbsp;&nbsp;<a href = "/air/list----1-0-0-----1.html">北美线</a>&nbsp;&nbsp;<a href = "/air/list----2-0-0-----1.html">欧洲线</a>&nbsp;&nbsp;<a href = "/air/list----3-0-0-----1.html">南美线</a><br/><a href = "/air/list----4-0-0-----1.html">亚洲线</a>&nbsp;&nbsp;<a href = "/air/list----5-0-0-----1.html">非洲线</a>&nbsp;&nbsp;<a href = "/air/list----6-0-0-----1.html">澳洲线</a><br/><a href = "/air/list----7-0-0-----1.html">国内航线</a></P>  
					</ul>
				</div>
				<div class="r_nav_bt"><img src="/images2/2011_fcl/r_nav_bt.gif" /></div>
			</div>
			<div class="r_hot" style="display:none;">
				<div class="r_hot_top"><strong>当前空运热门港口</strong></div>
				<div class="r_hot_md">
<asp:Repeater ID="rptHotPort" runat="server">
<ItemTemplate>
<a href="/air/list-<%#Eval("startport").ToString() %>-<%#Eval("destport").ToString() %>--0-0-0-----1.html"><%#Eval("startport").ToString()%> - <%#Eval("destport").ToString()%></a><br />	
</ItemTemplate>
</asp:Repeater>
                </div>
				<div class="r_hot_bt"><img src="/images2/2011_fcl/r_hot_bt.gif" /></div>
			</div>
			<div class="r_hot"><a href="http://www.100allin.com/company/cmdWTUtyQlZFVjRleXZiMkVxOHpmQT09/" target="_blank"><img src="/images2/banner/dz.gif" border="0" /></a></div>
			<div class="r_hot"><a href="http://www.100allin.com/company/VVRwS29NK1V1ZGg4cUhrbXAxMi81QT09/" target="_blank"><img src="/images2/banner/yc.gif" border="0" /></a></div>
			<div class="r_hot"><a href="http://www.100allin.com/company/Wk1vdUF0ZzBFeWlOVUlMTWV0TDNXUT09/" target="_blank"><img src="/images2/banner/jky.gif" border="0" /></a></div>
		
			
			</div>

<%--			<div class="bot_box">
			<div class="bot_box_l"><img src="/images2/2011_fcl/bt_l.gif" /></div>
			<div class="bot_box_m">
				<div class="sp_l">
					<a href="/topic/air090716/" target="_blank"><img src="/images2/2011_fcl/ky.jpg" border="0" /></a>
				</div>
<user201102listbottomspecial:user201102listbottomspecial ID="user201102listbottomspecial1" runat="server" />
<user201102listbottomsupplier:user201102listbottomsupplier ID="user201102listbottomsupplier1" runat="server" />
			</div>
			<div class="bot_box_r"><img src="/images2/2011_fcl/bt_r.gif" /></div>
		</div>--%>
<div style="margin-bottom:10px;"><a href="/ports/" target="_blank"><img src="/images2/fcl/port_fcl_20110913.gif" border="0" /></a></div>
<userlinkbottom1:userlinkbottom1 ID="userlinkbottom11" runat="server" />
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
<input id="Hidden3" runat="server" style="width: 1px" type="hidden" />
<input id="Hiddennn3" runat="server" style="width: 1px" type="hidden" />
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

<script type="text/javascript">

document.getElementById("mm").onmouseout=function(e){
	var e = window.event || e, relatedTarget = e.toElement || e.relatedTarget;
	while(relatedTarget && relatedTarget != this){
		relatedTarget = relatedTarget.parentNode;
		if(!relatedTarget){
			hidden1();
		}
	}
}; 
</script>       
</body>
</html>

