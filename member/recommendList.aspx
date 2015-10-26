<%@ Page Language="C#" AutoEventWireup="true" CodeFile="recommendList.aspx.cs" Inherits="message_BBSList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>环球运费网 - 积分活动</title>
    <link href="../css/master.css" rel="stylesheet" type="text/css" />
    <link href="../css/list.css" rel="stylesheet" type="text/css" />
    <link href="css/BBSList.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
<!--
#pp td{nowrap=true;}
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
							  	        <a href="../member/reg.aspx"><img src="../images/reg.gif" width="140" height="40" border="0" /></a> </div>
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
                                        <asp:Label ID="Label6" runat="server" Text="推荐用户列表"></asp:Label>
                                    </div>

                                </td>
                            <td style="width: 10px">
                                <img height="31" src="../images/box_3.gif" width="10" /></td>
                        </tr>
                        
                        
                    </table>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="800px" GridLines="Horizontal" style=" float:left; border-left: #D3EBF3 1px solid; border-right: #D3EBF3 1px solid; border-top:#D3EBF3 1px solid">
                        <Columns>					
                                <asp:TemplateField>
                                    <HeaderTemplate>                                   
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="10px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        编号
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Eval("UserID") %>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="40px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        类型
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# (Convert.ToInt32(Eval("CompanyType").ToString()) == 2) ? "<img src='/admin/images/type2.gif'/>" : ((Convert.ToInt32(Eval("CompanyType").ToString()) == 1) ? "<img src='/admin/images/type1.gif'/>" : "<img src='/admin/images/type0.gif'/>")%>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="40px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        用户名
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c2"><nobr><%# Eval("UserName") %></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="40px" />
                                </asp:TemplateField> 
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        真实姓名
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c3"><nobr><%# Eval("RealName")%></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="40px" />
                                </asp:TemplateField>    
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        公司名称
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c4"><nobr><%# Eval("CompanyName")%></nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="188px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        电话
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="c5"><nobr>固: <%# Eval("Phone")%></nobr></div>
                                        <div class="c5"><nobr>移: <%# Eval("MovePhone")%>&nbsp;</nobr></div>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="60px" />
                                </asp:TemplateField>    
                               <asp:TemplateField>
                                    <HeaderTemplate>
                                        注册时间
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# Convert.ToDateTime(Eval("Regtime")).ToString("yyyy-MM-dd")%><BR/>
                                        <%# Convert.ToDateTime(Eval("Regtime")).ToString("HH:mm:ss")%>
                                    </ItemTemplate>                                                
                                    <ItemStyle Width="70px" />
                                </asp:TemplateField>    
                            
                            
                            
                        </Columns>
                        <RowStyle Height="45px"  BorderStyle="Dashed" />
                        <HeaderStyle Height="20px" BackColor="#F2F8FB"/>
                        
                    </asp:GridView>
                    <table border="0" cellpadding="0" cellspacing="0" style="   float: left">
                        <tr>
                            <td width="10">
                                <img height="31" src="../images/box_7_2.gif" width="10" /></td>
                            <td background="../images/box_8_2.gif" width="780">
                                <div class="page" style="float: left">
                                    <div class="pageCount">
                            共 <strong>
                                            <asp:Label ID="lblTotalPage" runat="server" Text="1"></asp:Label></strong> 页
                                        <strong>
                                            <asp:Label ID="lblTotalItem" runat="server" Text="0"></asp:Label></strong> 条记录
                            &nbsp; 以上是第 <strong>
                                            <asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label></strong>
                                        页</div>
                                    <div class="pageControl">
                                        <asp:LinkButton ID="lnkFirstPage" runat="server" OnClick="lnkFirstPage_Click">第一页</asp:LinkButton>
                                        <asp:LinkButton ID="lnkPrePage" runat="server" OnClick="lnkPrePage_Click">上一页</asp:LinkButton>
                                        <asp:LinkButton ID="lnkNextPage" runat="server" OnClick="lnkNextPage_Click">下一页</asp:LinkButton>
                                        <asp:LinkButton ID="lnkLastPage" runat="server" OnClick="lnkLastPage_Click">最后页</asp:LinkButton>
                                        <asp:Label ID="hidSaveSearchWords" runat="server" CssClass="hidden" Text="1"></asp:Label>
                                    </div>
                                    <div class="pageText">
                            直接翻页：</div>
                                    <div class="pageSelect">
                                        <asp:DropDownList ID="ddlPageSelect" runat="server" AutoPostBack="true" CssClass="pageDropdown"
                                            OnSelectedIndexChanged="ddlPageSelect_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </td>
                            <td width="10">
                                <img height="31" src="../images/box_9_2.gif" width="10" /></td>
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
<script language="javascript" src="http://count48.51yes.com/click.aspx?id=485102224&logo=1">function right_onclick() {

}

</script>	
</body>
</html>
