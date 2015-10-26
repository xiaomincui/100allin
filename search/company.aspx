<%@ Page Language="VB" AutoEventWireup="false" CodeFile="company.aspx.vb" Inherits="search_company" EnableEventValidation="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<asp:Literal id="Literal1" runat="server"><title>货代名录-公司库,环球运费网公司黄页,找货代公司尽在环球运费网</title></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="环球运费网货代名录(环球运费网公司库)拥有大量货代公司的注册信息,环球运费网货代名录的会员遍布全国各个地区,每日有大量的新注册公司,加入环球运费网,即可立即成为公货代司库中的一员,查找货运代理公司就在环球运费网货代名录" /></asp:Literal>
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="货代,货代公司,货运代理,公司库,环球运费网" /></asp:Literal>
<link href="/css2/company.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/js/company_list.js"></script>
<script language="javascript" type="text/javascript" src="/js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<script language="javascript" type="text/javascript">
    Sys.Application.add_load(function(){var form=Sys.WebForms.PageRequestManager.getInstance()._form;form._initialAction=form.action=window.location.href;});
</script>       
    <div class="main"><!--页面主体开始-->	
<div class="head"><!--顶部开始-->
            <usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_1" runat="server" />
            <usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_1" runat="server" />
			<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_1" runat="server" />
		</div>
		<div class="main_content"><!--中部开始-->
        <div id="more" style="position:absolute; width:195px; left:10px;background:#FFFFE1; border:1px solid #7F9DB9; visibility:hidden; padding:10px; line-height:22px;">
        </div>		
			<div class="main_left"><!--左边开始-->
			  <div class="company">
			  	<div class="company_box">
					<DIV id=tabs1>
					  <DIV class=menu1box>
								<UL id=menu1>
                                    <asp:Literal ID="ltrMenu1" runat="server"></asp:Literal>
                                    <asp:Literal ID="ltrMenu2" runat="server"></asp:Literal>
							    </UL>
						  <a style="float:right; margin:6px 0 0 0; color:#FF6600; text-decoration:underline; background:url(/images/fcl/com_j.gif) no-repeat left; padding:0 15px 0 15px;" href="/accounts/reg.aspx">申请加入</a>						</DIV>

 							<DIV class=main1box>
								<p id="box_top"><img src="/images/fcl/fcl_ico.gif" />&nbsp;公司名：
                                    <asp:TextBox ID="txtCompanyName" runat="server" Width="200"></asp:TextBox>&nbsp;&nbsp;
					<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                        <ContentTemplate>                                    
                                    省： <asp:DropDownList ID="ddlcity1" runat="server" AutoPostBack="True" Width="100px">
                                    </asp:DropDownList>
                                    市： <asp:DropDownList ID="ddlcity2" runat="server"  Width="100px">
                                    </asp:DropDownList>
					      </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:TextBox ID="txtType" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtLine" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtLineAir" runat="server" Visible="false"></asp:TextBox>&nbsp;&nbsp;
								    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/fcl/cp_bt.gif" width="101" height="26" border="0" style="margin-bottom:-6px;"  /></p>
								<p id="box_bot">
								筛选城市： <asp:Literal ID="ltrCityHot" runat="server"></asp:Literal><br />
								<asp:PlaceHolder ID="PlaceHolder1" runat="server">
								业务类型： <asp:Literal ID="ltrTypeHot" runat="server"></asp:Literal><br/>
								<asp:Literal ID="Literal4" runat="server">主营海运： </asp:Literal><asp:Literal ID="ltrLineHot" runat="server"></asp:Literal>
								<asp:Label ID="Label4" runat="server" ForeColor="#CCCCCC" Visible="false">主营海运：&nbsp;&nbsp;&nbsp;<b>全部</b>&nbsp;&nbsp;美加线&nbsp;&nbsp;非洲线&nbsp;&nbsp;中东印巴线&nbsp;&nbsp;中南美线&nbsp;&nbsp;欧地线&nbsp;&nbsp;日韩线&nbsp;&nbsp;近洋线&nbsp;&nbsp;澳洲线&nbsp;&nbsp;红海线</asp:Label><br/>
                                <asp:Literal ID="Literal5" runat="server">主营空运： </asp:Literal><asp:Literal ID="ltrLineHotAir" runat="server"></asp:Literal>
                                <asp:Label ID="Label5" runat="server" ForeColor="#CCCCCC" Visible="false">主营空运：&nbsp;&nbsp;&nbsp;<b>全部</b>&nbsp;&nbsp;北美线&nbsp;&nbsp;欧洲线&nbsp;&nbsp;南美线&nbsp;&nbsp;亚洲线&nbsp;&nbsp;非洲线&nbsp;&nbsp;澳洲线&nbsp;&nbsp;近洋线&nbsp;&nbsp;国内航线 </asp:Label><br/>
                                
                                <asp:Literal ID="Literal6" runat="server">主营公司： </asp:Literal><asp:Literal ID="Literal7" runat="server"></asp:Literal>
                                <asp:Label ID="Label1" runat="server" ForeColor="#CCCCCC" Visible="false">主营公司：&nbsp;<b>全部</b>&nbsp;&nbsp;马士基&nbsp;&nbsp;地中海&nbsp;&nbsp;川崎&nbsp;&nbsp;长荣&nbsp;&nbsp;太平&nbsp;&nbsp;中海&nbsp;&nbsp;东方海外&nbsp;&nbsp;达飞&nbsp;&nbsp;中远&nbsp;&nbsp;以星&nbsp;&nbsp;阳明&nbsp;&nbsp;美国总统&nbsp;&nbsp;南美邮船&nbsp;&nbsp;现代&nbsp;&nbsp;韩进&nbsp;&nbsp;万海 </asp:Label><br/>
                                <asp:Literal ID="Literal8" runat="server">特殊服务： </asp:Literal><asp:Literal ID="Literal9" runat="server"></asp:Literal>
                                <asp:Label ID="Label2" runat="server" ForeColor="#CCCCCC" Visible="false">特殊服务：&nbsp;<b>全部</b>&nbsp;&nbsp;冷冻冷藏&nbsp;&nbsp;危险品&nbsp;&nbsp;罐箱&nbsp;&nbsp;其他特种柜&nbsp;&nbsp;散杂货船&nbsp;&nbsp;进口&nbsp;&nbsp;私人物品 </asp:Label>
							    </asp:PlaceHolder> 
							    </p>
					  </DIV>	  
			</DIV>
			
					<div class="cp_box">
					 <asp:PlaceHolder ID="PlaceHolder4" runat="server" >
                    <div style="padding-top:10px; padding-left:10px; color:#666666">
			    <img src="/images/fcl/gt.gif" />&nbsp;
                       
			    环球运费网共为您找到<asp:Label ID="hidTotalItem" runat="server" ></asp:Label>条记录<br/>    
			    您搜索的是：&nbsp;
                            <asp:Label ID="Label9" runat="server" Text="所在城市："></asp:Label><b><asp:Literal ID="hidTxtProvince" runat="server" ></asp:Literal>-<asp:Literal ID="hidTxtCity" runat="server" ></asp:Literal></b>&nbsp;
                            <asp:Label ID="Label10" runat="server" Text="业务类型："></asp:Label><b><asp:Literal ID="hidType" runat="server" ></asp:Literal></b>&nbsp;
                            <asp:Label ID="Label11" runat="server" Text="公司名："></asp:Label><b><asp:Literal ID="hidName" runat="server" ></asp:Literal></b>&nbsp;
                            <asp:Label ID="Label12" runat="server" Text="主营海运："></asp:Label><b><asp:Literal ID="hidLine" runat="server" ></asp:Literal></b>&nbsp;                    
                            <asp:Label ID="Label13" runat="server" Text="主营空运："></asp:Label><b><asp:Literal ID="hidLineAir" runat="server" ></asp:Literal></b>&nbsp;        
				            <asp:Literal ID="hidSC" runat="server" Visible="false" ></asp:Literal>
                      </div>
                      </asp:PlaceHolder>
                        <asp:PlaceHolder ID="PlaceHolder2" runat="server">
						<ul>
							<li  style="background-color:#E9EEF1; margin-top:15px; border-bottom:1px solid #D1DCE2;border-top:1px solid #D1DCE2;">
							  <table width="100%" border="0" cellspacing="1" cellpadding="0">
								<tr>
								  <td width="2%" height="30">&nbsp;</td>
								  <td width="48%">公司及联系人&nbsp;<img src="/images/company/arrowy.gif" width="7" height="4" /></td>
								  <td width="18%">省份\城市&nbsp;<img src="/images/company/arrowy.gif" width="7" height="4" /></td>
								  <td width="16%">主要服务&nbsp;<img src="/images/company/arrowy.gif" width="7" height="4" /></td>
								  <td width="16%">联系对方&nbsp;<img src="/images/company/arrowy.gif" width="7" height="4" /></td>
							    </tr>
							  </table>
							</li>
					  </ul>
                      <asp:Repeater ID="RptUser" runat="server">
                        <ItemTemplate>
                        <ul>
									<li>
									  <table width="100%" border="0" cellspacing="1" cellpadding="0">
										<tr>
										  <td width="2%" align="center">&nbsp;</td>
										  <td width="10%" align="left"  class="picSmall"><a href="<%#IIf(Eval("userid")="2061","http://www.100allin.com/shop/hf/",IIf(Eval("userid")="77805","http://www.100allin.com/shop/bloom/",IIf(Eval("userid")="117726","http://www.100allin.com/shop/jituo/","/company/"& key(eval("userid")) & "/")))%>" target="_blank"><img src="/member/Head/<%#IIf(CBool(Eval("HeadURL").ToString()) = True,Eval("userid").ToString(),"default")%>.jpg" width="70" height="70" border="0" /></a></td>
										  <td width="38%"><table width="100%" border="0" cellspacing="1" cellpadding="0">
                                            <tr>
                                              <td height="25"><a href="<%#IIf(Eval("userid")="2061","http://www.100allin.com/shop/hf/",IIf(Eval("userid")="77805","http://www.100allin.com/shop/bloom/",IIf(Eval("userid")="117726","http://www.100allin.com/shop/jituo/","/company/"& key(eval("userid")) & "/")))%>" target="_blank" <%#IIf(Eval("ifend").ToString()="1","style='color:#971817;'","")%>><strong><%#Eval("CompanyName").ToString()%></strong></a><%#IIf(Eval("ifend") = "0", "", "<img src=""http://img02.100allin.com/images2/fcl/02270434.gif"" width=""30"" height=""13"" title=""环球运费网推荐"" />")%></td>
                                            </tr>
                                            <tr>
                                              <td height="25"><%#Eval("Realname").ToString()%>&nbsp;</td>
                                            </tr>
                                            <tr>
                                              <td height="24">信誉等级：<%#Star2(Eval("star_user").ToString)%></td>
                                            </tr>
                                          </table>										    
									      </td>
										  <td width="18%"><table width="100%" border="0" cellspacing="1" cellpadding="0">
                                            <tr>
                                              <td height="25"><%#Eval("Login2_Locus1").ToString()%>-<%#Eval("Login2_Locus2").ToString()%></td>
                                            </tr>
                                            <tr>
                                              <td height="25"><span style="display:none;">号码验证：<span class="orange">正确</span></span></td>
                                            </tr>
                                          </table></td>
										  <td width="16%" class="blue"><table width="100%" border="0" cellspacing="1" cellpadding="0">
                                            <tr>
                                              <td height="25"><%#IIf(Eval("Login2_Adventage_Type_fcl").ToString() = "1", "整箱海运", "")%> </td>
                                            </tr>
                                            <tr>
                                              <td height="25"><%#IIf(Eval("Login2_Adventage_Type_lcl").ToString() = "1", "拼箱海运", "")%> </td>
                                            </tr>
                                            <tr>
                                              <td height="25"><%#IIf(Eval("Login2_Adventage_Type_air").ToString() = "1", "空运", "")%></td>
                                            </tr>
                                          </table></td>
										  <td width="16%"><table width="100%" border="0" cellspacing="1" cellpadding="0">
                                            <tr>
                                              <td height="25"><a href="/member/pm_detail.aspx?pid=1&cid=<%#Eval("userid").ToString()%>" target="_blank"><img src="/images/company/booking_bt3.gif" width="76" height="25" border="0" /></a></td>
                                            </tr>
                                            <tr>
                                              <td height="10"></td>
                                            </tr>
                                            <tr>
                                              <td height="24"><a href="/member/addfriend.aspx?u=<%#Eval("userid").ToString()%>" target="_blank"><img src="/images/company/booking_bt2.gif" width="76" height="25" border="0" /></a></td>
                                            </tr>
                                          </table></td>
									    </tr>
									  </table>
									</li>
								</ul>						
                        </ItemTemplate>
                      </asp:Repeater>
                      </asp:PlaceHolder>
                        <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible="false">
						<ul>
							<li style="background-color:#E9EEF1; margin-top:15px; border-bottom:1px solid #D1DCE2;border-top:1px solid #D1DCE2;">
							  <table width="100%" border="0" cellspacing="1" cellpadding="0">
								<tr>
								  <td width="2%" height="30">&nbsp;</td>
								  <td width="38%">公司名称</td>
								  <td width="14%">省份\城市</td>
								  <td width="13%">联系人</td>
								  <td width="13%">发短消息</td>
							    </tr>
							  </table>
							</li>
					  </ul>
                      <asp:Repeater ID="RptOtherUser" runat="server">
                        <ItemTemplate>
						<ul>
							<li>
							  <table width="100%" border="0" cellspacing="1" cellpadding="0">
								        <tr>
								          <td width="2%" height="45" align="center">&nbsp;</td>
								          <td width="38%"><a href="/company/<%#key(Eval("userid").ToString())%>/" target="_blank"><strong><%#Eval("CompanyName").ToString()%></strong></a></td>
								          <td width="14%" class="gray"><%#Eval("Login2_Locus1").ToString()%>-<%#Eval("Login2_Locus2").ToString()%></td>
								          <td width="13%" class="blue"><%#Eval("Realname").ToString()%></strong></td>
								          <td width="13%"><a href="/member/pm_detail.aspx?pid=1&cid=<%#Eval("userid").ToString()%>" target="_blank"><img src="/images/fcl/dxx.gif" border=0 /></a></td>
							            </tr>
							  </table>
							</li>
						</ul>
                        </ItemTemplate>
                      </asp:Repeater>
                      </asp:PlaceHolder>                      
				  </div>
<table id="pd" width="100%" border="0" cellpadding="0" cellspacing="1" >
  <tr>
    <td height="32" colspan="11" align="center" bgcolor="#FFFFFF">
        <DIV class=manu>
        <SPAN class=disabled style="margin:0px; padding:0px; line-height:27px; height:27px; border:none; color:#28385A; float:left;">
    <asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label>/<asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label>
    </SPAN>
        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
    <asp:Label ID="hidSaveSearchWords" runat="server" Text="1"  Visible="false"></asp:Label>
    直接到第 <input id="txtPageJump" name="txtPageJump" type="text" style=" width:20px; height:12px;" runat="server"/> 页 
    <input id="btnPageJump" name="btnPageJump" type="button" value="确定" style=" width:40px; height:20px;" runat="server"/>
        </DIV>
    </td>
    </tr>
</table>				  
			  	</div>
			  	
			  </div>
		  </div>
			<!--左边结束-->	
			<div class="main_right"><!--右边开始-->
						<div style="margin-bottom:5px;">
                            <asp:Literal ID="ltrAdbanner" runat="server"></asp:Literal>
						</div>
			  <div class="right_boxs">
					<div class="right_boxs_title"><h2 style="color:#FFFFFF;"><img src="/images/fcl/b1.gif" />最新加入的公司</h2>
					</div>
					<ul style="height:auto;">
                      <asp:Repeater ID="RptNewUser" runat="server">
                        <ItemTemplate>					
						<li>·<a href="/company/<%#key(Eval("userid").ToString())%>/" target="_blank"><%#GetFirstString(Eval("Companyname").ToString(), 22)%></a></li>
                        </ItemTemplate>
                      </asp:Repeater>						
					</ul>
			  </div>
<%--			  <div class="right_boxs">
					<div class="right_boxs_title"><h2 style="color:#FFFFFF;"><a href="/bbs/forum-3-1.html" style="color:#FFFFFF;">最新谈天说地</a></h2>
					</div>
					<ul style="height:auto;">
                      <asp:Repeater ID="RptNewBBS" runat="server">
                        <ItemTemplate>					
						<li>·<a href="/bbs/thread-<%#Eval("id").ToString()%>-1.html" target="_blank" title="<%#Eval("title").ToString()%>"><%#GetFirstString(Eval("title").ToString(), 21)%></a></li>
                        </ItemTemplate>
                      </asp:Repeater>                                         
					</ul>
			  </div>	--%>	
			  <div class="right_boxs">
					<div class="right_boxs_title"><h2><a href="/bbs/forum-5-1.html" style="color:#FFFFFF;">最新航运动态</a></h2>
					</div>
					<ul style="height:auto;">
                      <asp:Repeater ID="RptNewNews" runat="server">
                        <ItemTemplate>					
						<li>·<a href="/bbs/thread-<%#Eval("id").ToString()%>-1.html" target="_blank" title="<%#Eval("title").ToString()%>"><%#GetFirstString(Eval("title").ToString(), 21)%></a></li>
                        </ItemTemplate>
                      </asp:Repeater>                                         
					</ul>
			  </div>				  
			  <div class="right_boxs">
					<div class="right_boxs_title"><h2><a href="/fcl/" style="color:#FFFFFF;">最新运价</a></h2>
					</div>
					<ul style="height:auto;">
                      <asp:Repeater ID="RptNewFcl" runat="server">
                        <ItemTemplate>					
						<li><a href="/fcl/<%#key(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>">[整箱] <%#GetFirstString(Eval("title").ToString(), 17)%></a></li>
                        </ItemTemplate>
                      </asp:Repeater>
                      <asp:Repeater ID="RptNewLcl" runat="server">
                        <ItemTemplate>					
						<li><a href="/lcl/<%#key(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>">[拼箱] <%#GetFirstString(Eval("title").ToString(), 17)%></a></li>
                        </ItemTemplate>
                      </asp:Repeater>
                      <asp:Repeater ID="RptNewAir" runat="server">
                        <ItemTemplate>					
						<li><a href="/air/<%#key(Eval("id").ToString())%>_0.html" target="_blank" title="<%#Eval("title").ToString()%>">[空运] <%#GetFirstString(Eval("title").ToString(), 17)%></a></li>
                        </ItemTemplate>
                      </asp:Repeater>                                            
					</ul>
			  </div>
			  	  
		  </div>
			<!--右边结束-->		
  		</div>
<userbottomline:userbottomline ID="userbottomline1" runat="server" />
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div><!--页面主体结束-->	
    </form>
    
    
</body>
</html>
