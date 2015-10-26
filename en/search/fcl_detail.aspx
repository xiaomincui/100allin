<%@ Page Language="VB" AutoEventWireup="false" CodeFile="fcl_detail.aspx.vb" Inherits="search_fcl_detail" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="整箱海运运价-环球运费网" /></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="整箱海运运价-环球运费网" /></asp:Literal>
<asp:Literal id="Literal1" runat="server"><title>整箱海运运价-环球运费网</title></asp:Literal>
<link href="/css/fcl1204.css" rel="stylesheet" type="text/css" />
<link href="/css/fcl_detail.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/fcl_detail.js"></script>  
</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"> 
</asp:ScriptManager>
<script language="javascript" type="text/javascript">
    Sys.Application.add_load(function(){var form=Sys.WebForms.PageRequestManager.getInstance()._form;form._initialAction=form.action=window.location.href;});
</script>   
<div class="main"><!--页面主体开始-->	
<usernewtop1209:usernewtop1209 ID="usernewtop12091" runat="server" />
        <asp:Panel ID="Panel4" runat="server" Visible="false">
		<div class="main_content"><!--中部开始-->
			<div class="" style="background:url(/images/fcl/info_bg.gif) no-repeat left top;"><!--左边开始-->
			<div style="clear:both;">
		      <table width="92%" border="0" align="center" cellpadding="0" cellspacing="1" style="background:url(/images/fcl/33.gif) no-repeat right 65px;">
                <tr>
                  <td height="10" align="center"></td>
                </tr>
				<tr>
                  <td height="32" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images/fcl/jt2.gif" />&nbsp;<strong>环球运费网提示</strong></div></td>
                </tr>
				<tr>
                  <td height="10" align="center" ></td>
				</tr>
				<tr>
                  <td height="10" align="center" ></td>
				</tr>
				<tr>
                  <td height="10" align="center" ></td>
				</tr>								
                <tr>
                  <td height="28" align="left" style="line-height:18px; font-size:14px;">
                     亲爱的用户，该运价已被删除或不存在，请点击以下地址，查询更多运价<br/>
                     <a href="/fcl/">http://www.100allin.com/fcl/</a>
                  </td>
                </tr>
              </table>
              <br/><br/><br/><br/>
			  </div>
		  </div>
  		</div>  
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server" Visible="false">
		<div class="main_content"><!--中部开始-->
			<div class="" style="background:url(/images/fcl/info_bg.gif) no-repeat left top;">
			<div style="clear:both;">
		      <table width="92%" border="0" align="center" cellpadding="0" cellspacing="1" style="background:url(/images/fcl/33.gif) no-repeat right 65px;">
                <tr>
                  <td height="10" align="center"></td>
                </tr>
				<tr>
                  <td height="32" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images/fcl/jt2.gif" />&nbsp;<strong>环球运费网提示</strong></div></td>
                </tr>
				<tr>
                  <td height="10" align="center" ></td>
				</tr>
				<tr>
                  <td height="10" align="center" ></td>
				</tr>
				<tr>
                  <td height="10" align="center" ></td>
				</tr>								
                <tr>
                  <td height="28" align="left" style="line-height:18px; font-size:14px;">
                      <asp:Label ID="Label28" runat="server" Text=""></asp:Label>
                  </td>
                </tr>
              </table>
              <br/><br/><br/><br/>
			  </div>
		  </div>

  		</div>        
            
        </asp:Panel>
        <asp:Panel ID="Panel6" runat="server">
				<div class="info_box">
					<div class="info_left">
					<h1><asp:Label ID="Label1" runat="server" Text="运价标题"></asp:Label></h1>
			    <ul>
				  <li><span class="blue2">运价类型</span>：<asp:Label ID="Label4" runat="server" Text=""></asp:Label></li>
			      <li><span class="blue2">航线描述</span>：<asp:Label ID="Label6" runat="server" Text=""></asp:Label></li>
			      <li>&nbsp;&nbsp;<span class="blue2">起运港</span>：<asp:Label ID="Label5" runat="server" Text="" ></asp:Label></li>
			      <li>&nbsp;&nbsp;<span class="blue2">目的港</span>：<asp:Label ID="LabDestport" runat="server" Text="" ></asp:Label></li>
			      <li><span class="blue2">发布时间</span>：<asp:Label ID="Label2" runat="server" Text=""></asp:Label></li>
			      <li><span class="blue2">截止时间</span>：<asp:Label ID="Label3" runat="server" Text=""></asp:Label></li>
			      <li style="width:580px;"><div class="blue_box"><span class="sju">20GP:<a><asp:Label ID="Lab20GP" runat="server" Text=""></asp:Label></a></span><span class="sju">40GP:<a><asp:Label ID="Lab40GP" runat="server" Text=""></asp:Label></a></span><span class="sju">40HQ:<a><asp:Label ID="Lab40HQ" runat="server" Text=""></asp:Label></a></span><span class="sju">45HQ:<a><asp:Label ID="Lab45HQ" runat="server" Text=""></asp:Label></a></span></div>
                  <asp:PlaceHolder ID="PlaceHolder4" runat="server">
			      <div class="zhushi">订舱保证：&nbsp;
                  <asp:Literal ID="LtrCang" runat="server"></asp:Literal>
                  <asp:Literal ID="LtrJia" runat="server"></asp:Literal>
			      </div>
			      </asp:PlaceHolder>
			      </li>
			      <li>&nbsp;&nbsp;<span class="blue2">附加费</span>：<asp:Label ID="LabPlus" runat="server" Text=""></asp:Label></li>
				  <li>&nbsp;&nbsp;<span class="blue2">船公司</span>：<asp:Label ID="Labshipcompany" runat="server" Text=""></asp:Label></li>
				  <li>&nbsp;&nbsp;<span class="blue2">出发日</span>：<asp:Label ID="LabDepartureWkd" runat="server" Text=""></asp:Label></li>
			      <li>&nbsp;&nbsp;&nbsp;&nbsp;<span class="blue2">航程</span>：<asp:Label ID="LabDistance" runat="server" Text=""></asp:Label></li>
				  <li id="bttj"><asp:Label ID="Label66" runat="server" Text=""></asp:Label><br />
		          ( 订舱有什么好处？ )</li>
			      </ul>
			  </div>
					<div class="info_right">
						<h2><asp:Label ID="Label8" runat="server" Text=""></asp:Label></h2>
						<div id="pic"><img id="imghead" src="/images/fcl/people.GIF" runat="server" width="76" height="76" /></div>
					  <div class="name"><img src="/images/fcl/women.gif" />&nbsp;<asp:Label ID="Label15" runat="server" Text=""></asp:Label><br />
                          <asp:PlaceHolder ID="PlaceHolder3" runat="server">
						  <asp:Literal ID="Literal25" runat="server"></asp:Literal><br />
						  <asp:Literal ID="Literal26" runat="server"></asp:Literal>
                          </asp:PlaceHolder>
                          </div>
                      <asp:Panel ID="Panel3" runat="server">
                     <div class="details_info">
					<ul>
						  <table width="100%" border="0" cellspacing="1" cellpadding="0">
                            <tr>
                              <td width="40%" height="23">&nbsp;</td>
                            </tr>
                            <tr>
                              <td width="40%" height="23" align="center"><span class="blue bold">想查看该用户联系方式请 <a href="/accounts/login.aspx"><span class="red">立即登陆</span></a></span></td>
                            </tr>
                            <tr>
                              <td width="40%" height="23" align="center"><span class="blue bold">如您还不是环球运费网会员请</span></td>
                            </tr>
                            <tr>
                              <td width="40%" height="23" align="center"><a href="/accounts/reg.aspx"><img src="/images/login/bt2.GIF" width="128" height="35" border="0" /></a></td>
                            </tr>
                            <tr>
                              <td width="40%" height="23">&nbsp;</td>
                            </tr>
                            <tr>
                              <td width="40%" height="23">&nbsp;</td>
                            </tr>
                            <tr>
                              <td height="23"><a href="#"></a></td>
                            </tr>
                          </table>
					</ul>
					</div> 
					</asp:Panel>  
					   <asp:Panel ID="Panel1" runat="server">  
						<div class="details_info" style="border:none; margin-top:0px;">
							<ul>
							    <li>电 话：<asp:Label ID="Label9" runat="server" Text=""></asp:Label></li>
								<li>手 机：<asp:Label ID="Label11" runat="server" Text=""></asp:Label> </li>
								<li>email：<asp:Label ID="Label12" runat="server" Text=""></asp:Label></li>
								<li>地 址：<asp:Label ID="Label13" runat="server" Text=""></asp:Label></li>
								<li>邮 编：<asp:Label ID="Label14" runat="server" Text=""></asp:Label></li>
							</ul>
					  </div>
						<div class="details_info">
								<ul>
								<li>
								  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                      <td width="36%">安运通等级：</td>
                                      <td width="64%"><asp:Literal ID="LtrStars1" runat="server"></asp:Literal></td>
                                    </tr>
                                  </table>
								</li>
								<li>
								  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                      <td width="26%">信誉等级：</td>
                                      <td width="74%"><asp:Literal ID="LtrStars2" runat="server"></asp:Literal></td>
                                    </tr>
                                  </table>
								</li>
								<li>客户评价：<asp:Label ID="LabCommentCount" runat="server" Text="" ForeColor="OrangeRed" Font-Bold="true"></asp:Label>条&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发布运价：<asp:Label ID="LabYunjiaCount" runat="server" Text="" ForeColor="OrangeRed" Font-Bold="true"></asp:Label>条</li>
									<li>
									  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                          <td width="26%">在线联系：</td>
                                          <td width="11%"><asp:Label ID="Label29" runat="server" Text=""></asp:Label></td>
                                          <td width="63%"><asp:Label ID="Label30" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                      </table>
									</li>
								</ul>
					  </div>
					  </asp:Panel>  
					</div>
			  		</div>
	  <div class="notice_hd"><a name="detail"></a>为防止运费高收和服务欺诈，100allin提醒您选择“<strong>放心货代</strong>”进行订舱。如与货代私下订舱交易，风险自担。</div>			  		
		<div class="info_other">
				<table id="pd" cellspacing="0" cellpadding="0" width="100%"  border="0">
				  <tbody>
				  <tr>
                      <td colspan="13" align="left"><h2><asp:Label ID="Label27" runat="server" Text=""></asp:Label></h2></td>
                    </tr>
				  <tr>
                      <td colspan="13" align="left" style="background: url(/images/fcl/qit2.gif) repeat-x top; line-height:20px; padding:9px 0 9px 6px;">目的港：
			      <%=IIf(ddest.ToString = "", "<b style=""color:#ff6600"">全部</b>&nbsp;", "<a href=""/fcl/" & GetQueryString("yid") & "_0.html"">全部</a>")%>
                  <asp:Repeater ID="Repeater1" runat="server">
			      <ItemTemplate>
			      <%#IIf(Eval("destport").ToString() = ddest.ToString, "<b style=""color:#ff6600"">" & Eval("destport").ToString() & "</b>&nbsp;", "<a href=""/fcl/" & key(Eval("sid")) & "_" & JingHao(Eval("destport").ToString) & ".html"">" & Eval("destport").ToString() & "</a>")%>
			      </ItemTemplate>
                  </asp:Repeater>                      
                      </td>
                    </tr>
                    <tr style="background-image:url(/images/fcl/fjf_bg1.gif)">
                      <td width="10%" height="26" align="left"  class="blue2"><strong>目的港</strong></td>
                      <td width="8%" align="left"><strong>20GP</strong></td>
                      <td width="8%" align="left"><strong>40GP</strong></td>
                      <td width="8%" align="left"><strong>40HQ</strong></td>
                      <td width="8%" align="left"><strong>45HQ</strong></td>
                      <td width="10%" align="left"><strong>附加费</strong></td>
                      <td width="10%" align="left"><strong>航程</strong></td>
                      <td width="6%" align="left"><strong>出发日</strong></td>
                      <td width="10%" align="left"><strong>船公司</strong></td>
                      <td width="10%" align="left"><strong>备注</strong></td>
                      <td width="7%" align="left"><strong>订舱保证</strong></td>
                      <td width="7%" align="left"><strong>订舱</strong></td>                                            
                      <td width="6%" align="left"><strong>继续搜</strong></td>
                    </tr>
                <asp:Repeater ID="RptYunjia" runat="server">
                   <ItemTemplate>                    
                    <tr>
                      <td align="left" bgcolor="#ffffff" height="32"><%#Eval("destport") %></td>
                      <td align="left" bgcolor="#ffffff"><%#Eval("price20gp")%></td>
                      <td align="left" bgcolor="#ffffff"><%#Eval("price40gp")%></td>
                      <td align="left" bgcolor="#ffffff"><%#Eval("price40hq")%></td>
                      <td align="left" bgcolor="#ffffff"><%#Eval("price45hq")%></td>
                      <td align="left" bgcolor="#ffffff"><%#Eval("price20gpAppend") %></td>
                      <td align="left" bgcolor="#ffffff"><%#Eval("Distance")%></td>
                      <td align="left" bgcolor="#ffffff"><%#Eval("DepartureWkd")%></td>
                      <td align="left" bgcolor="#ffffff"><%#Eval("shipcompany")%></td>
                      <td align="left" bgcolor="#ffffff"><%#Eval("memo")%></td>
                      <td align="left" bgcolor="#ffffff"><img src="/images/fcl/cang.gif" width="16" height="16" border="0" style="display:<%#IIf (CInt(Eval("assurance").ToString) <> 0,"","none")%>" alt="舱位保证"/></a> <img src="/images/fcl/dc16.gif" width="16" height="16" style="display:<%#IIf (CInt(Eval("star_allin").ToString) <> 0,"","none")%>" alt="价格保证"/></td>
                      <td align="center" bgcolor="#ffffff"><a href="/search/fcl_order.aspx?filter=new&<%#Eval("qstring")%>" target="_blank">
                      <img src="/images/fcl/c_booking.gif" border=0 alt="向该公司订舱" /></td>                                            
                      <td align="left" bgcolor="#ffffff"><a href="/fcl/list-<%#Eval("startport1")%>-<%#Eval("destport") %>--0-0-0-----1.html" target="_blank">
                      <img src="/images/fcl/c_search.gif" border=0 alt="从<%#Eval("startport1")%>到<%#Eval("destport") %>更多运价" />
                      </a></td>
                    </tr>
					<tr style="display:<%#Every3(RptYunjia.Items.Count.ToString) %>">
                      <td height="1" colspan="13" align="left" bgcolor="#F3F3F3"></td>
                    </tr>
                   </ItemTemplate>
                </asp:Repeater>
					<tr>
                      <td height="25" colspan="13" align="left" style="line-height:20px; background:#F7FDFD; border-top:1px solid #CAE7EF; "><DIV class="page clearfix" style="TEXT-ALIGN: right">
                      <span id="fen">共 
        <asp:Literal ID="ltrTp" runat="server"></asp:Literal> 页 <asp:Literal ID="ltrTi" runat="server"></asp:Literal> 条结果
        <asp:Literal ID="ltrPage" runat="server" Visible="false"></asp:Literal></span>
                      <asp:Literal ID="ltrPage2" runat="server"></asp:Literal>
                      </DIV></td>
                    </tr>                
                    <tr>
                      <td colspan="13" align="left" style="line-height:20px; background:#F7FDFD; border-bottom:1px solid #CAE7EF; border-top:1px solid #CAE7EF; padding:6px 0 6px 6px;">
                        <span class="gray"><img src="/images/fcl/gt.gif" width="14" height="13" /> 备注：<asp:Label ID="LabMemo" runat="server" Text=""></asp:Label></span></td>
                    </tr>
			      </tbody>
		  </table>
	  </div>
    <div class="fcl_rd"><table id="Table3" cellspacing="0" cellpadding="0" width="100%"  border="0">
				  <tbody>
				  				  <tr>
                      <td colspan="11" align="left" style="background: url(/images/fcl/qit2.gif) repeat-x top; line-height:20px; padding:9px 0 9px 15px; font:14px '宋体';"><img src="/images/fcl/LedIcon_306.GIF" /> <strong>该公司订舱记录</strong></td>
                    </tr>
										<tr>
                      <td height="5" colspan="11" align="left"></td>
                    </tr>
                    <tr>
                      <td width="16%" height="26" align="left" background="/images/fcl/fjf_bg1.gif" class="blue_1"><strong>日期</strong></td>
                      <td width="12%" align="left" background="/images/fcl/fjf_bg1.gif" class="blue_1"><strong>运输方式</strong></td>
                      <td width="12%" align="left" background="/images/fcl/fjf_bg1.gif" class="blue_1"><strong>订舱状态</strong></td>
                      <td width="12%" align="left" background="/images/fcl/fjf_bg1.gif" class="blue_1"><strong>成交对象</strong></td>
                      <td width="36%" align="left" background="/images/fcl/fjf_bg1.gif" class="blue_1"><strong>相关运价</strong></td>
                      <td width="12%" align="center" background="/images/fcl/fjf_bg1.gif" class="blue_1"><strong>评价</strong></td>
                    </tr>
                  <asp:Repeater ID="RptOrder" runat="server">
                  <ItemTemplate>                     
                    <tr>
                      <td height="28" align="left"><%#Eval("date_create")%></td>
                      <td align="left" ><%#GetFreightType(Eval("freight_type"))%></td>
                      <td align="left"><%#Eval("status_name_forward")%></td>
                      <td align="left"><%#Eval("RealName")%></td>
                      <td align="left"><%#Eval("title")%></td>
                      <td align="left"><%#GetPingType(Eval("yiping_forward"), Eval("ping_forward"))%></td>
                    </tr>
                   </ItemTemplate>
                </asp:Repeater>
                      <asp:PlaceHolder ID="phNoOrder" runat="server" Visible="false">
                      <tr><td colspan="6" align="center"><div style="margin-top:10px;">暂无订舱记录</div></td></tr>
                      </asp:PlaceHolder>
			      </tbody>
		  </table>
		</div>
		<userbottomline:userbottomline id="userbottomline2" runat="server"/>	  
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
			<div class="other_list">
			<h1><asp:Label ID="Label17" runat="server" Text=""></asp:Label><asp:Label ID="Label18" runat="server" Text=""></asp:Label></h1>
			  <div class="other_list_left">
			  		<h2><strong>相关整箱运价</strong><asp:Literal ID="Literal4" runat="server"></asp:Literal></h2>
					<div class="other_list_box">
<table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#CAE7F0">  
  <tr>
    <td width="18%" height=28 align="center" bgcolor="#E9F3F8" class="blue">标题</td>
    <td width="8%" align="center" bgcolor="#E9F3F8" class="blue">航线</td>
    <td width="10%" align="center" bgcolor="#E9F3F8" class="blue"><span class="blue">起运港</span></td>
    <td width="10%" align="center" bgcolor="#E9F3F8" class="blue">目的港</td>
    <td width="5%" align="center" bgcolor="#E9F3F8" class="blue">20GP</td>
    <td width="5%" align="center" bgcolor="#E9F3F8" class="blue">40GP</td>
    <td width="5%" align="center" bgcolor="#E9F3F8" class="blue">40HQ</td>
    <td width="12%" align="center" bgcolor="#E9F3F8" class="blue">发布/截止日期</td>
    <td width="7%" align="center" bgcolor="#E9F3F8" class="blue">船公司</td>
  </tr>
  <asp:Repeater ID="RptOtherDestport" runat="server">
  <ItemTemplate>                                                                                        
   <tr>
    <td bgcolor="#FFFFFF" class="blue">&nbsp;<a href="/fcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#GetFirstString(Eval("title").ToString, 20)%></a></td>
    <td bgcolor="#FFFFFF">&nbsp;<%#Eval("hangxianmiaoshu").ToString.Replace("线", "")%></td>
    <td height=36 bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("startport").ToString, 9)%></td>
    <td bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("destport").ToString, 9)%></td>
    <td bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("price20gp").ToString, 5)%></td>
    <td bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("price40gp").ToString, 5)%></td>
    <td bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("price40hq").ToString, 5)%></td>
    <td align="center" bgcolor="#FFFFFF" style="color:#666666"><%#Format(Eval("postdate"), "MM-dd").ToString%> 到 <%#Format(Eval("enddate"), "MM-dd").ToString%></td>
    <td bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("shipcompany").ToString, 6)%></td>
  </tr>
  </ItemTemplate>
  </asp:Repeater>
  </table>
    
					</div>
			  </div>
				<div class="other_list_right">
					<h2><strong>相关优质货代公司</strong></h2>
					<ul>
                      <asp:Repeater ID="RptFreight" runat="server">
                      <ItemTemplate>					
					  <li><a href="/company/<%#Key(Eval("UserID"))%>/" target="_blank"><%#GetFirstString(Eval("CompanyName").ToString, 34)%></a></li>
                      </ItemTemplate>
                      </asp:Repeater>	
					</ul>
				</div>
		  </div>
		    </asp:PlaceHolder>
		    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
		    <div class="other_list">
		    <h1><asp:Label ID="Label20" runat="server" Text=""></asp:Label><asp:Label ID="Label22" runat="server" Text=""></asp:Label></h1>
				  <div class="other_list_left">
						<h2><strong>相关整箱运价</strong><asp:Literal ID="Literal5" runat="server"></asp:Literal></h2>
						<div class="other_list_box">
<table id="Table2" width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#CAE7F0" >
  <tr>
    <td width="18%" height=28 align="center" bgcolor="#E9F3F8" class="blue">标题</td>
    <td width="8%" align="center" bgcolor="#E9F3F8" class="blue">航线</td>
    <td width="10%" align="center" bgcolor="#E9F3F8" class="blue"><span class="blue">起运港</span></td>
    <td width="10%" align="center" bgcolor="#E9F3F8" class="blue">目的港</td>
    <td width="5%" align="center" bgcolor="#E9F3F8" class="blue">20GP</td>
    <td width="5%" align="center" bgcolor="#E9F3F8" class="blue">40GP</td>
    <td width="5%" align="center" bgcolor="#E9F3F8" class="blue">40HQ</td>
    <td width="12%" align="center" bgcolor="#E9F3F8" class="blue">发布/截止日期</td>
    <td width="7%" align="center" bgcolor="#E9F3F8" class="blue">船公司</td>
  </tr>
  <asp:Repeater ID="RptOtherLine" runat="server">
  <ItemTemplate>
   <tr style="color:#333333;">
    <td bgcolor="#FFFFFF" class="blue">&nbsp;<a href="/fcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank"><%#GetFirstString(Eval("title").ToString, 18)%></a></td>
    <td bgcolor="#FFFFFF">&nbsp;<%#Eval("hangxianmiaoshu").ToString.Replace("线", "")%></td>
    <td height=36 bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("startport").ToString, 7)%></td>
    <td bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("destport").ToString, 7)%></td>
    <td bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("price20gp").ToString, 5)%></td>
    <td bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("price40gp").ToString, 5)%></td>
    <td bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("price40hq").ToString, 5)%></td>
    <td align="center" bgcolor="#FFFFFF" style="color:#666666"><%#Format(Eval("postdate"), "MM-dd").ToString%> 到 <%#Format(Eval("enddate"), "MM-dd").ToString%></td>
    <td bgcolor="#FFFFFF">&nbsp;<%#GetFirstString(Eval("shipcompany").ToString, 6)%></td>
  </tr>
  </ItemTemplate>
  </asp:Repeater>
  </table>
  
  </div>
				  </div>
				<div class="other_list_right">
					<h2><strong>相关优质货代公司</strong></h2>
					<ul>
                      <asp:Repeater ID="RptFreightLine" runat="server">
                      <ItemTemplate>					
					  <li><a href="/company/<%#Key(Eval("UserID"))%>/" target="_blank"><%#GetFirstString(Eval("CompanyName").ToString, 34)%></a></li>
                      </ItemTemplate>
                      </asp:Repeater>	
					</ul>
				</div>			  
		  </div>
		    </asp:PlaceHolder>

			<div class="comments" style="display:none;">
					  <div class="comments_title">
								<h2>该条运价的评价</h2>
								<a class="orange" href="javascript:alert('该功能即将推出')" >> 查看该公司的综合评价图</a>
					  </div>
					  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                <div class="comments_box">
				    <table width="100%" border="0" cellspacing="1" cellpadding="0">
                      <asp:Repeater ID="RptComment" runat="server">
                        <ItemTemplate>
                        <tr valign="top">
                            <td width="17%" class="gray"><%#Eval("PostDate")%></td>
                            <td width="83%" colspan="2"><span class="blue"><%#IIf(CInt(Eval("UserID")) <> 0, Eval("UserName"), "<span class='blue'>游客</span><span class='gray'>（未注册用户，请注意鉴别）</span>")%></span> 
                            说：<%#IIf(Eval("goodbad").ToString() = "1", "顶", "踩")%>，<%#Eval("Data")%>  
                            <%#IIf(Eval("ReplyData").ToString() = "", "", "")%></td>
                        </tr>
                        <%#IIf(Eval("ReplyData").ToString() <> "", "<tr><td class='gray'>&nbsp;</td><td colspan='2' class='orange'>主人的回复： " + Eval("ReplyPostDate") + "：" + Eval("ReplyData") + "</td></tr>", "")%>
                        
                        </ItemTemplate>
                      </asp:Repeater>
                      <tr>
                        <td height="15"></td>
                        <td height="15" colspan="2"></td>
                      </tr>
                      <tr>
                        <td align="right" class="blue bold" style="height: 20px">我也来评价:</td>
                        <td colspan="2" style="height: 20px">
                            
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Selected="True">顶它</asp:ListItem>
                                <asp:ListItem Value="2 ">踩它 </asp:ListItem>
                            </asp:RadioButtonList>
           </td>
                      </tr>
                      <tr>
                        <td height="10"></td>
                        <td height="10" colspan="2"></td>
                      </tr>
                      <tr>
                        <td class="blue bold">&nbsp;</td>
                        <td><textarea name="textarea" id="TextBox1" cols="90" rows="6" runat="server" style="font-family:arial,sans-serif,宋体; color:#999999; " onfocus="focusit()" onblur="blurit()">写点评论内容吧 您的评论内容对他人有很大帮助</textarea></td>
                        <td>&nbsp;</td>
                      </tr>
                      <tr>
                        <td height="10"></td>
                        <td height="10" colspan="2"></td>
                      </tr>
                      <tr>
                        <td class="blue bold">&nbsp;</td>
                        <td colspan="2">
                            <asp:Button ID="Button1" runat="server" Text="提交" />&nbsp;&nbsp;
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="匿名" /></td>
                      </tr>
                      <tr>
                        <td class="blue bold">&nbsp;</td>
                        <td colspan="2">&nbsp;</td>
                      </tr>
                    </table>
				  </div>                        
                        
                        </ContentTemplate>
                      
                      </asp:UpdatePanel>
				</div> 
				
        </asp:Panel>
        <userbottomline:userbottomline id="userbottomline1" runat="server"/>
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
    </form>
</body>
</html>
