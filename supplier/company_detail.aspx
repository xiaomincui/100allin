<%@ Page Language="VB" AutoEventWireup="false" CodeFile="company_detail.aspx.vb"  Inherits="company_company_detail" EnableEventValidation="false" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal1" runat="server"><title>航线优势代理运价-环球运费网</title></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="整箱海运运价-环球运费网" /></asp:Literal>
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="整箱海运运价-环球运费网" /></asp:Literal>
<asp:Literal id="ltrCSS" runat="server"></asp:Literal>
<script language="javascript" type="text/javascript" src="/js/function.js"></script>
<script language="javascript" type="text/javascript" src="/js/company_detail.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    		<div id="mm" style="position:absolute; width:400px; background:#FFFFFF; left:10px;border:1px solid #999999; visibility:hidden;">
        </div>
        <div id="nn" style="position:absolute; width:300px; left:10px;background:#FFFFFF; border:1px solid #999999; visibility:hidden;">
        </div>		
       <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
    Sys.Application.add_load(function(){var form=Sys.WebForms.PageRequestManager.getInstance()._form;form._initialAction=form.action=window.location.href;});
</script>
<div class="main_container"><!--页面主体开始-->
  <!--顶部登陆结束-->
<div class="header"><!--头部LOGO开始-->	
			<div id="logo"><asp:Literal ID="Literal5" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="ltrYz" runat="server"></asp:Literal></div>
			<ul>
				<li><img src="/images/shops/nav1.GIF" width="16" height="16" /><a href="/" target="_blank">环球运费网</a>&nbsp;&nbsp;</li>
			    <li><img src="/images/shops/nav3.GIF" width="16" height="16" /><asp:Label ID="Label19" runat="server" Text=""></asp:Label>&nbsp;&nbsp;</li>
			</ul>
  </div><!--头部LOGO结束-->
  <div class="dh"><p><span class="dh_head"></span><a href="/">首页</a> > <a href="/company/">公司库</a> > <asp:Label ID="Label1" runat="server" Text=""></asp:Label> <asp:Label ID="Label20" runat="server" Text=""></asp:Label></p>
  </div>
		<!--导航结束-->
		<div class="main_content"><!--中部开始-->
			<div class="main">
				<div class="gs_box">
					<div class="box_dit">
						<div class="jies">
							<div class="nt" style="border:none;">
						<h2><asp:Literal ID="Literal6" runat="server"></asp:Literal></h2>
						<p id="ps"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></p>
						  </div>
							<div class="nt">
							  <h2><asp:Literal ID="Literal7" runat="server"></asp:Literal></h2>
							<p><asp:Label ID="Label18" runat="server" Text=""></asp:Label></p>
						  </div>
							<div class="nt">
										<h2><asp:Literal ID="Literal8" runat="server"></asp:Literal></h2>
										<p>海运：<asp:Label ID="Label16" runat="server" Text=""></asp:Label><br />
									  &nbsp;&nbsp;&nbsp;&nbsp;空运：<asp:Label ID="Label17" runat="server" Text=""></asp:Label></p>
						  </div>
					 	    <div class="nt" style="border:none;">
										<h2><asp:Literal ID="Literal9" runat="server"></asp:Literal></h2>
										<p><asp:Label ID="Label15" runat="server" Text=""></asp:Label></p>
						  </div>
						</div>
					    <div class="right_pic">
							<h2><asp:Literal ID="Literal4" runat="server"></asp:Literal></h2>
							                <asp:Panel ID="Panel7" runat="server">
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
<asp:Panel ID="Panel8" runat="server">
		<div id="pic"><img id="imghead" src="/images/fcl/people.GIF" runat="server" width="76" height="76" /></div>
		<div class="name"><img src="/images/fcl/women.gif" />&nbsp;<asp:Label ID="Label4" runat="server" Text=""></asp:Label><br />
            <asp:Literal ID="Literal25" runat="server"></asp:Literal>&nbsp;<br /><asp:Literal ID="Literal26" runat="server"></asp:Literal>
		</div>
		<div class="details_info" style="border:none; margin-top:0px;">
		<ul>
		    <li style="margin-bottom:10px;">电话：<asp:ImageButton ID="ImageButton1" runat="server" Enabled="false" CssClass="get" /></li>
			<li style="margin-bottom:10px;">传真：<asp:ImageButton ID="ImageButton2" runat="server" Enabled="false" CssClass="get" /></li>
			<li style="margin-bottom:10px;">手机：<asp:ImageButton ID="ImageButton4" runat="server" Enabled="false" CssClass="get" /></li>
			<li style="margin-bottom:10px;">email：<asp:ImageButton ID="ImageButton3" runat="server" Enabled="false" CssClass="get" /></li>
			<li>地址：<asp:Label ID="Label11" runat="server" Text=""></asp:Label></li>
			<li>邮编：<asp:Label ID="Label9" runat="server" Text=""></asp:Label></li>
		</ul>						
  </div>
		<div class="details_info" style="padding-bottom:18px;">
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
						<li>
						  <table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
							  <td width="26%">在线联系：</td>
							  <td width="11%"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
							  <td width="63%"><asp:Label ID="Label14" runat="server" Text=""></asp:Label></td>
							</tr>
						  </table>
						</li>
					</ul>
	  </div>
</asp:Panel>	

					   </div>
					   <div class="right_bot"></div>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
					   <div class="contact">
					     <table width="100%" height="121" border="0" cellpadding="0" cellspacing="1">
                           <tr>
                             <td height="40">&nbsp;</td>
                             <td>&nbsp;</td>
                           </tr>
                           <tr>
                             <td><table width="420" border="0" align="center" cellpadding="0" cellspacing="1">
                               <tr>
                                 <td width="24" rowspan="3"><img src="/images/shops/contact_bg2.gif" width="24" height="83" /></td>
                                 <td width="9" height="28">&nbsp;</td>
                                 <td width="95">安运通等级：</td>
                                 <td width="95"><asp:Literal ID="ltrAnyuntong" runat="server"></asp:Literal></td>
                                 <td width="95"> </td>
                                 <td width="95"></td>
                               </tr>
                               <tr>
                                 <td height="28">&nbsp;</td>
                                 <td>信誉等级：<asp:Literal ID="ltrXinyu" runat="server"></asp:Literal><asp:Literal ID="ltrCjcs" runat="server" Visible="false"></asp:Literal></td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                               </tr>
                               <tr>
                                 <td height="28">&nbsp;</td>
                                 <td>好评：<asp:Literal ID="ltrHp" runat="server"></asp:Literal>个 </td>
                                 <td><span style="display:none;">中评：<asp:Literal ID="ltrZp" runat="server"></asp:Literal>个</span></td>
                                 <td>差评：<asp:Literal ID="ltrCp" runat="server"></asp:Literal>个</td>
                                 <td>&nbsp;</td>
                               </tr>
                             </table></td>
                             <td><table width="420" border="0" align="center" cellpadding="0" cellspacing="1">
                               <tr>
                                 <td width="24" rowspan="3"><img src="/images/shops/contact_bg3.gif" width="24" height="83" /></td>
                                 <td width="10" height="28">&nbsp;</td>
                                 <td width="194">营业执照：<span class="yt"><asp:Literal ID="ltr_z_yingyezhizhao" runat="server"></asp:Literal></span></td>
                                 <td width="194">空运铜牌：<span class="yt"><asp:Literal ID="ltr_z_kongyuntongpai" runat="server"></asp:Literal></span></td>
                               </tr>
                               <tr>
                                 <td height="28">&nbsp;</td>
                                 <td>&nbsp;&nbsp;身份证：<span class="yt"><asp:Literal ID="ltr_z_shenfenzheng" runat="server"></asp:Literal></span></td>
                                 <td>&nbsp;</td>
                               </tr>
                               <tr>
                                 <td height="28">&nbsp;</td>
                                 <td>&nbsp;&nbsp;&nbsp;NVOCC：<span class="yt"><asp:Literal ID="ltr_z_nvocc" runat="server"></asp:Literal></span></td>
                                 <td>&nbsp;</td>
                               </tr>
                             </table></td>
                           </tr>
                         </table>
					   </div>
					   </asp:PlaceHolder>
					</div>
				</div>
				<div class="freight_List">
				<asp:Panel ID="Panel9" runat="server">
                <asp:Panel ID="Panel1" runat="server" CssClass="menu0box">
					<UL id=menu0>
					  <LI class=hover onclick="window.location.href =('/company/<%=GetQueryString("cid")%>/fcl')" style="padding-top:5px;display:<%=IIf(havefcl = "0","none","") %>;"><A style="color:#05233B;" href="/company/<%=GetQueryString("cid")%>/fcl/">TA的<%=Request.QueryString("line").ToString %>运价</A></LI>
					  <LI onclick="window.location.href =('/company/<%=GetQueryString("cid")%>/')" style="padding-top:5px;"><A href="/company/<%=GetQueryString("cid")%>/">进入TA的商铺</A></LI>
					  <LI onclick="window.location.href =('/company/<%=GetQueryString("cid")%>/lcl')" style="display:<%=IIf(havelcl = "0","none","") %>;"><A href="/company/<%=GetQueryString("cid")%>/lcl/">TA的最新拼箱运价</A></LI>
					  <LI onclick="window.location.href =('/company/<%=GetQueryString("cid")%>/air')" style="display:<%=IIf(haveair = "0","none","") %>;"><A href="/company/<%=GetQueryString("cid")%>/air/">TA的最新空运运价</A></LI>
					  </UL>
                </asp:Panel>
                
                <asp:Panel ID="Panel2" runat="server" CssClass="menu0box" Visible="false">
					<UL id=menu0>
					  <LI onclick="window.location.href =('/company/<%=GetQueryString("cid")%>/fcl')" style="display:<%=IIf(havefcl = "0","none","") %>;"><A href="/company/<%=GetQueryString("cid")%>/fcl/">TA的最新整箱运价</A></LI>
					  <LI class=hover onclick="window.location.href =('/company/<%=GetQueryString("cid")%>/lcl')" style="display:<%=IIf(havelcl = "0","none","") %>;"><A style="color:#05233B;" href="/company/<%=GetQueryString("cid")%>/lcl/">TA的最新拼箱运价</A></LI>
					  <LI onclick="window.location.href =('/company/<%=GetQueryString("cid")%>/air')" style="display:<%=IIf(haveair = "0","none","") %>;"><A href="/company/<%=GetQueryString("cid")%>/air/">TA的最新空运运价</A></LI>
					  </UL>
                </asp:Panel>
                
                <asp:Panel ID="Panel3" runat="server" CssClass="menu0box" Visible="false">
					<UL id=menu0>
					  <LI onclick="window.location.href =('/company/<%=GetQueryString("cid")%>/fcl')" style="display:<%=IIf(havefcl = "0","none","") %>;"><A href="/company/<%=GetQueryString("cid")%>/fcl/">TA的最新整箱运价</A></LI>
					  <LI onclick="window.location.href =('/company/<%=GetQueryString("cid")%>/lcl')" style="display:<%=IIf(havelcl = "0","none","") %>;"><A href="/company/<%=GetQueryString("cid")%>/lcl/">TA的最新拼箱运价</A></LI>
					  <LI class=hover onclick="window.location.href =('/company/<%=GetQueryString("cid")%>/air')" style="display:<%=IIf(haveair = "0","none","") %>;"><A style="color:#05233B;" href="/company/<%=GetQueryString("cid")%>/air/">TA的最新空运运价</A></LI>
					  </UL>
                </asp:Panel>
                
                      <asp:Panel ID="Panel4" runat="server">
	              <div class="biaoti">
		                <table width="950" height="44" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td width="1" bgcolor="#CAC9C7"><img src="/images/fcl/biaoti_bg.gif" /></td>
                            <td background="/images/fcl/biaoti_bg2.gif"><table width="100%" border="0" cellpadding="0" cellspacing="0" class="fcl_spbox">
                              <tr>
                                <td width="46%" height="24"><a href="#" style="font:14px '宋体'; color:#22568F;"></a></td>
                                <td width="25%"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="20%"><strong>20'</strong></td>
                                        <td width="20%"><strong>40'</strong></td>
                                        <td width="20%"><strong>40H'</strong></td>
                                        <td width="20%"><strong>45H'</strong></td>
                                        <td width="20%"><strong>船公司</strong></td>
                                    </tr>
                                </table></td>
                                <td width="15%"><table width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="fcl_spbox">
                                    <tr>
                                      <td align="center"><a style="color:#3f7fb7;" href="#"></a><strong>订舱保证</strong></td>
                                    </tr>
                                </table></td>
                                <td width="15%" align="center">&nbsp;</td>
                              </tr>
                            </table></td>
                            <td width="1" ><img src="/images/fcl/biaoti_bg3.gif" /></td>
                          </tr>
                        </table>
	              </div>
                <div class="list_box">	              
				<asp:Repeater ID="Rptfcl" runat="server">
                  <ItemTemplate>
					<ul>
						<li>
						  <table width="100%" height="90" border="0" cellpadding="0" cellspacing="0">
							<tr>
							  <td height="80" align="center"><table width="15" border="0" cellpadding="0" cellspacing="1" class="fcl_spbox">
								<tr>
								  <td width="2%" height="24" align="right"><a href="#">·</a><div style="display:none"><asp:Label ID="Label1"  runat="server" Text='<%# eval("sid") %>'></asp:Label><asp:Label ID="Label2"  runat="server" Text='<%#Eval("userid")%> '></asp:Label></div></td>
								</tr>
								<tr>
								  <td height="24" bordercolor="0">&nbsp;</td>
								</tr>
								<tr>
								  <td height="24" bordercolor="0">&nbsp;</td>
								</tr>
							  </table></td>
							  <td width="98%"><table width="100%" border="0" cellpadding="0" cellspacing="0" class="fcl_spbox" >
								<tr>
								  <td width="45%" height="24" onmouseover="ttfcl('<%#Rptfcl.Items.Count %>')" onmouseout="hidden()"><a href="/fcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank" style="font:14px '宋体'; color:#22568F;"><strong><%# Eval("title") %></strong></a></td>
								  <td width="25%" onmouseover="ttfcl('<%#Rptfcl.Items.Count %>')" onmouseout="hidden()">&nbsp;</td>
								  <td width="15%"><table width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="fcl_spbox">
<tr style="display:<%#IIf (CInt(Eval("assurance").ToString) <> 0,"","none")%>">
<td width="30%" align="center"><a style="color:#3f7fb7;" href="#"><img src="/images/fcl/cang.gif" width="16" height="16" border="0" /></a></td>
<td width="70%" class="blue2">舱位保证</td>
</tr>
<tr style="display:<%#IIf (CInt(Eval("assurance").ToString) = 0,"","none")%>">
<td width="30%" align="center" bordercolor="0">&nbsp;</td>
<td width="70%" bordercolor="0" class="blue2">&nbsp;</td>
</tr>
								  </table></td>
								  <td width="15%" rowspan="3" align="center" ><a href="/search/order_temp.aspx?type=fcl&filter=new&yid=<%# Eval("sid") %>&ydid=<%# Eval("id") %>&f=<%# Eval("userid") %>" target="_blank"  style="display:<%#IIf (CInt(Eval("star_allin").ToString) <> 0,"","none")%>"><img src="/images/fcl/dingc_r5_c1.jpg" width="68" height="29" border=0 /></a></td>
								</tr>
								<tr onmouseover="ttfcl('<%#Rptfcl.Items.Count %>')" onmouseout="hidden()">
								  <td height="24" bordercolor="0"><span class="blue2"><%#Eval("hangxianmiaoshu").ToString.Replace("线", "")%></span>&nbsp;|&nbsp;
								  <span class="blue2"><%#Eval("Startport")%></span>&nbsp;<span class="gray">至</span>&nbsp;<span class="blue2"><%#Eval("Destport")%></span>&nbsp;|&nbsp;
								  <span class="gray"><%#Format(Eval("postdate"), "MM-dd").ToString%> 至 <%#Format(CDate(Eval("enddate")), "MM-dd").ToString%></span></td>
								  <td bordercolor="0"><table width="100%" border="0" cellspacing="0" cellpadding="0">
									<tr>
<td width="20%"><strong><%#GetFirstString(Eval("price20gp").ToString, 4)%></strong></td>
<td width="20%"><strong><%#GetFirstString(Eval("price40gp").ToString, 4)%></strong></td>
<td width="20%"><strong><%#GetFirstString(Eval("price40hq").ToString, 4)%></strong></td>
<td width="20%"><strong><%#GetFirstString(Eval("price45hq").ToString, 4)%></strong></td>
<td width="20%"><%#GetFirstString(Eval("shipcompany").ToString, 5)%></td>
									</tr>
								  </table></td>
								  <td bordercolor="0"><table width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="fcl_spbox">
<tr style="display:<%#IIf (CInt(Eval("star_allin").ToString) <> 0,"","none")%>">
<td width="30%" align="center" bordercolor="0"><img src="/images/fcl/dc16.gif" width="16" height="16" /></td>
<td width="70%" bordercolor="0" class="blue2">价格保证</td>
</tr>
<tr style="display:<%#IIf (CInt(Eval("star_allin").ToString) = 0,"","none")%>">
<td width="30%" align="center" bordercolor="0">&nbsp;</td>
<td width="70%" bordercolor="0" class="blue2">&nbsp;</td>
</tr>
								  </table></td>
								</tr>
								<tr>
								  <td height="24" colspan="3" bordercolor="0"><table width="100%" border="0" cellspacing="0" cellpadding="0">
									<tr>
									  <td width="35%"><a href="/fcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank" ><%#Eval("companyname")%></a></td>
									  <td width="14%"><a href="#"></a></td>
									  <td width="51%"><a href="#"></a></td>
									</tr>
								  </table></td>
								</tr>
							  </table></td>
							</tr>
						  </table>
						</li>
					</ul>
				 </ItemTemplate>
              </asp:Repeater>	                      
                </div>      
                      </asp:Panel>                			
                    <asp:Panel ID="Panel5" runat="server">
	              <div class="biaoti">
		                <table width="950" height="44" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td width="1" bgcolor="#CAC9C7"><img src="/images/fcl/biaoti_bg.gif" /></td>
                            <td background="/images/fcl/biaoti_bg2.gif"><table width="100%" border="0" cellpadding="0" cellspacing="0" class="fcl_spbox">
                              <tr>
                                <td width="46%" height="24"><a href="#" style="font:14px '宋体'; color:#22568F;"></a></td>
                                <td width="25%"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="33%"><strong>&nbsp;价格<br/>(重量)</strong></td>
                                        <td width="33%"><strong>&nbsp;价格<br/>(体积)</strong></td>
                                        <td width="34%"><strong>船公司</strong></td>
                                    </tr>
                                </table></td>
                                <td width="15%"><table width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="fcl_spbox">
                                    <tr>
                                      <td align="center"><a style="color:#3f7fb7;" href="#"></a><strong>订舱保证</strong></td>
                                    </tr>
                                </table></td>
                                <td width="15%" align="center">&nbsp;</td>
                              </tr>
                            </table></td>
                            <td width="1" ><img src="/images/fcl/biaoti_bg3.gif" /></td>
                          </tr>
                        </table>
	              </div>
	              <div class="list_box">                
				<asp:Repeater ID="Rptlcl" runat="server">
                  <ItemTemplate>
                    <ul>
						<li>
						  <table width="100%" height="90" border="0" cellpadding="0" cellspacing="0">
							<tr>
							  <td height="80" align="center"><table width="15" border="0" cellpadding="0" cellspacing="1" class="fcl_spbox">
								<tr>
								  <td width="2%" height="24" align="right"><a href="#">·</a><div style="display:none"><asp:Label ID="Label1"  runat="server" Text='<%# eval("sid") %>'></asp:Label><asp:Label ID="Label2"  runat="server" Text='<%#Eval("userid")%> '></asp:Label></div></td>
								</tr>
								<tr>
								  <td height="24" bordercolor="0">&nbsp;</td>
								</tr>
								<tr>
								  <td height="24" bordercolor="0">&nbsp;</td>
								</tr>
							  </table></td>
							  <td width="98%"><table width="100%" border="0" cellpadding="0" cellspacing="0" class="fcl_spbox" >
								<tr>
								  <td width="45%" height="24" onmouseover="ttlcl('<%#Rptlcl.Items.Count %>')" onmouseout="hidden()"><a href="/lcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank" style="font:14px '宋体'; color:#22568F;"><strong><%# Eval("title") %></strong></a></td>
								  <td width="25%" onmouseover="ttlcl('<%#Rptlcl.Items.Count %>')" onmouseout="hidden()">&nbsp;</td>
								  <td width="15%"><table width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="fcl_spbox">
<tr style="display:<%#IIf (CInt(Eval("assurance").ToString) <> 0,"","none")%>">
<td width="30%" align="center"><a style="color:#3f7fb7;" href="#"><img src="/images/fcl/cang.gif" width="16" height="16" border="0" /></a></td>
<td width="70%" class="blue2">舱位保证</td>
</tr>
<tr style="display:<%#IIf (CInt(Eval("assurance").ToString) = 0,"","none")%>">
<td width="30%" align="center" bordercolor="0">&nbsp;</td>
<td width="70%" bordercolor="0" class="blue2">&nbsp;</td>
</tr>
								  </table></td>
								  <td width="15%" rowspan="3" align="center"><a href="/search/lcl_order.aspx?filter=new&yid=<%# Eval("sid") %>&ydid=<%# Eval("id") %>&f=<%# Eval("userid") %>" target="_blank" style="display:<%#IIf (CInt(Eval("star_allin").ToString) <> 0,"","none")%>"><img src="/images/fcl/dingc_r5_c1.jpg" width="68" height="29" border=0 /></a></td>
								</tr>
								<tr onmouseover="ttlcl('<%#Rptlcl.Items.Count %>')" onmouseout="hidden()">
								  <td height="24" bordercolor="0"><span class="blue2"><%#Eval("hangxianmiaoshu").ToString.Replace("线", "")%></span>&nbsp;|&nbsp;
								  <span class="blue2"><%#Eval("Startport")%></span>&nbsp;<span class="gray">至</span>&nbsp;<span class="blue2"><%#Eval("Destport")%></span>&nbsp;|&nbsp;
								  <span class="gray"><%#Format(Eval("postdate"), "MM-dd").ToString%> 至 <%#Format(CDate(Eval("enddate")), "MM-dd").ToString%></span></td>
								  <td bordercolor="0"><table width="100%" border="0" cellspacing="0" cellpadding="0">
									<tr>
<td width="33%"><strong><%#GetFirstString(Eval("pricegp").ToString, 4)%></strong></td>
<td width="33%"><strong><%#GetFirstString(Eval("pricegpv").ToString, 4)%></strong></td>
<td width="34%"><%#GetFirstString(Eval("shipcompany").ToString, 5)%></td>
									</tr>
								  </table></td>
								  <td bordercolor="0"><table width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="fcl_spbox">
<tr style="display:<%#IIf (CInt(Eval("star_allin").ToString) <> 0,"","none")%>">
<td width="30%" align="center" bordercolor="0"><img src="/images/fcl/dc16.gif" width="16" height="16" /></td>
<td width="70%" bordercolor="0" class="blue2">价格保证</td>
</tr>
<tr style="display:<%#IIf (CInt(Eval("star_allin").ToString) = 0,"","none")%>">
<td width="30%" align="center" bordercolor="0">&nbsp;</td>
<td width="70%" bordercolor="0" class="blue2">&nbsp;</td>
</tr>
								  </table></td>
								</tr>
								<tr>
								  <td height="24" colspan="3" bordercolor="0"><table width="100%" border="0" cellspacing="0" cellpadding="0">
									<tr>
									  <td width="35%"><a href="/lcl/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank" ><%#Eval("companyname")%></a></td>
									  <td width="14%"></td>
									  <td width="51%"><a href="#"></a></td>
									</tr>
								  </table></td>
								</tr>
							  </table></td>
							</tr>
						  </table>
						</li>
					</ul>                  			
				 </ItemTemplate>
              </asp:Repeater>	                      
               </div>        
                      </asp:Panel>
                <asp:Panel ID="Panel6" runat="server">
				  	<div class="biaoti">
		                <table width="950" height="44" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td width="1" bgcolor="#CAC9C7"><img src="/images/fcl/biaoti_bg.gif" /></td>
                            <td background="/images/fcl/biaoti_bg2.gif"><table width="100%" border="0" cellpadding="0" cellspacing="0" class="fcl_spbox">
                              <tr>
                                <td width="46%" height="24"><a href="#" style="font:14px '宋体'; color:#22568F;"></a></td>
                                <td width="25%"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="20%"><strong>+45</strong></td>
                                        <td width="20%"><strong>+100</strong></td>
                                        <td width="20%"><strong>+300</strong></td>
                                        <td width="20%"><strong>+500</strong></td>
                                        <td width="20%"><strong>+1000</strong></td>
                                    </tr>
                                </table></td>
                                <td width="15%"><table width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="fcl_spbox">
                                    <tr>
                                      <td align="center"><a style="color:#3f7fb7;" href="#"></a><strong>订舱保证</strong></td>
                                    </tr>
                                </table></td>
                                <td width="15%" align="center">&nbsp;</td>
                              </tr>
                            </table></td>
                            <td width="1" ><img src="/images/fcl/biaoti_bg3.gif" /></td>
                          </tr>
                        </table>
	              </div>
					<div class="list_box">  
				<asp:Repeater ID="Rptair" runat="server">
                  <ItemTemplate>
                    <ul>
						<li>
						  <table width="100%" height="90" border="0" cellpadding="0" cellspacing="0">
							<tr>
							  <td height="80" align="center"><table width="15" border="0" cellpadding="0" cellspacing="1" class="fcl_spbox">
								<tr>
								  <td width="2%" height="24" align="right"><a href="#">·</a><div style="display:none"><asp:Label ID="Label1"  runat="server" Text='<%# eval("sid") %>'></asp:Label><asp:Label ID="Label2"  runat="server" Text='<%#Eval("userid")%> '></asp:Label></div></td>
								</tr>
								<tr>
								  <td height="24" bordercolor="0">&nbsp;</td>
								</tr>
								<tr>
								  <td height="24" bordercolor="0">&nbsp;</td>
								</tr>
							  </table></td>
							  <td width="98%"><table width="100%" border="0" cellpadding="0" cellspacing="0" class="fcl_spbox" >
								<tr>
								  <td width="45%" height="24" onmouseover="ttair('<%#Rptair.Items.Count %>')" onmouseout="hidden()"><a href="/air/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank" style="font:14px '宋体'; color:#22568F;"><strong><%# Eval("title") %></strong></a></td>
								  <td width="25%" onmouseover="ttair('<%#Rptair.Items.Count %>')" onmouseout="hidden()">&nbsp;</td>
								  <td width="15%"><table width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="fcl_spbox">
<tr style="display:<%#IIf (CInt(Eval("assurance").ToString) <> 0,"","none")%>">
<td width="30%" align="center"><a style="color:#3f7fb7;" href="#"><img src="/images/fcl/cang.gif" width="16" height="16" border="0" /></a></td>
<td width="70%" class="blue2">舱位保证</td>
</tr>
<tr style="display:<%#IIf (CInt(Eval("assurance").ToString) = 0,"","none")%>">
<td width="30%" align="center" bordercolor="0">&nbsp;</td>
<td width="70%" bordercolor="0" class="blue2">&nbsp;</td>
</tr>
								  </table></td>
								  <td width="15%" rowspan="3" align="center"><a href="/search/air_order.aspx?filter=new&yid=<%# Eval("sid") %>&ydid=<%# Eval("id") %>&f=<%# Eval("userid") %>" target="_blank" style="display:<%#IIf (CInt(Eval("star_allin").ToString) <> 0,"","none")%>"><img src="/images/fcl/dingc_r5_c1.jpg" width="68" height="29" border=0 /></a></td>
								</tr>
								<tr onmouseover="ttair('<%#Rptair.Items.Count %>')" onmouseout="hidden()">
								  <td height="24" bordercolor="0"><span class="blue2"><%#Eval("line").ToString.Replace("线", "")%></span>&nbsp;|&nbsp;
								  <span class="blue2"><%#Eval("Startport")%></span>&nbsp;<span class="gray">至</span>&nbsp;<span class="blue2"><%#Eval("Destport")%></span>&nbsp;|&nbsp;
								  <span class="gray"><%#Format(Eval("postdate"), "MM-dd").ToString%> 至 <%#Format(CDate(Eval("enddate")), "MM-dd").ToString%></span></td>
								  <td bordercolor="0"><table width="100%" border="0" cellspacing="0" cellpadding="0">
									<tr>
									  <td width="20%"><strong><%#Eval("price_p45")%></strong></td>
									  <td width="20%"><strong><%#Eval("price_p100")%></strong></td>
									  <td width="20%"><strong><%#Eval("price_p300")%></strong></td>
									  <td width="20%"><strong><%#Eval("price_p500")%></strong></td>									  
									  <td width="20%"><strong><%#Eval("price_p1000")%></strong></td>									  
									</tr>
								  </table></td>
								  <td bordercolor="0"><table width="80%" border="0" align="center" cellpadding="0" cellspacing="0" class="fcl_spbox">
<tr style="display:<%#IIf (CInt(Eval("star_allin").ToString) <> 0,"","none")%>">
<td width="30%" align="center" bordercolor="0"><img src="/images/fcl/dc16.gif" width="16" height="16" /></td>
<td width="70%" bordercolor="0" class="blue2">价格保证</td>
</tr>
<tr style="display:<%#IIf (CInt(Eval("star_allin").ToString) = 0,"","none")%>">
<td width="30%" align="center" bordercolor="0">&nbsp;</td>
<td width="70%" bordercolor="0" class="blue2">&nbsp;</td>
</tr>
								  </table></td>
								</tr>
								<tr>
								  <td height="24" colspan="3" bordercolor="0"><table width="100%" border="0" cellspacing="0" cellpadding="0">
									<tr>
									  <td width="35%"><a href="/air/<%# key(eval("sid")) %>_<%# eval("id") %>.html" target="_blank" ><%#Eval("companyname")%></a></td>
									  <td width="14%"></td>
									  <td width="51%"><a href="#"></a></td>
									</tr>
								  </table></td>
								</tr>
							  </table></td>
							</tr>
						  </table>
						</li>
					</ul>
				 </ItemTemplate>
              </asp:Repeater>	 
                </div>                     
               </asp:Panel>
<input id="Hidden1" runat="server" style="width: 1px" type="hidden" />	
<input id="Hiddennn1" runat="server" style="width: 1px" type="hidden" />
				  <div class="page_head">    <asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label>/<asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label><asp:HiddenField ID="hidTotalPage" runat="server" /></div>
				  <div class="page">
        <DIV class=manu>
       
        <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
    <asp:Label ID="hidSaveSearchWords" runat="server" Text="1" CssClass="hidden"></asp:Label>
    
    直接到第 <input id="txtPageJump" name="txtPageJump" type="text" style=" width:20px; height:12px;" runat="server"/> 页 
    <input id="btnPageJump" name="btnPageJump" type="button" value="确定" style=" width:40px; height:20px;" runat="server"/>
        
        </DIV>
				  </div>
</asp:Panel> 				  
				</div>
<asp:PlaceHolder ID="phPingJia" runat="server">				
            <div class="comments">
				  <div class="comments_title">
							<h2><img src="/images/fcl/jt2.gif" />&nbsp;交易相关评价</h2>
				  </div>
                <div class="comments_box">
				    <table width="100%" border="0" cellspacing="1" cellpadding="0">
                      <asp:Repeater ID="RptPingjia" runat="server">
                        <ItemTemplate>
                        <tr valign="top">
                            <td width="17%" class="gray"><%#Eval("date_create")%></td>
                            <td width="83%" colspan="2"><span class="blue"><%#Eval("realname")%></span>：
                            <span class="red"><%#Ping1(Eval("ping_shipper"))%> </span>
                            <span class="gray"><%#Eval("evaluation_shipper")%>  </span>
                            </td>
                        </tr>
                        </ItemTemplate>
                      </asp:Repeater>
                      <tr>
                        <td height="15"></td>
                        <td height="15" colspan="2"></td>
                      </tr>
                      <tr>
                        <td class="blue bold">&nbsp;</td>
                        <td colspan="2">&nbsp;</td>
                      </tr>
                    </table>
				  </div>                        
			</div>
			</asp:PlaceHolder>
<asp:PlaceHolder ID="phOrder" runat="server">
<div class="comments">
<table id="Table3" cellspacing="0" cellpadding="0" width="100%"  border="0">
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
                      <td align="left"><a href="/<%#GetFreightType2(Eval("freight_type"))%>/<%# key(eval("freight_code")) %>_<%# eval("freight_code1") %>.html" target="_blank" style="color:#22568F;"><%#Eval("price_title")%></a></td>
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
		</asp:PlaceHolder>		
			</div>
		</div>
	  <userbottomline:userbottomline ID="userbottomline1" runat="server" />
	 <userbottom:userbottom ID="userbottom1" runat="server" />
</div>
    </form>
</body>
</html>

