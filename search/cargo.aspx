<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cargo.aspx.vb" Inherits="search_cargo" EnableEventValidation="false" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="货盘,货盘查询" /></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content=货盘查询发布板块,提供最新的货盘信息,包含海运空运等不同类型的货盘信息,全球货盘信息查询-环球运费网" /></asp:Literal>
<asp:Literal id="Literal1" runat="server"><title>货盘信息-货盘发布版块,查询货盘信息,货主货盘的发布平台</title></asp:Literal>
<link href="/css/fcl1210.css" rel="stylesheet" type="text/css" />
<link href="/css/fcl_list.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="/js/function.js"></script>
<script language="javascript" type="text/javascript" src="/js/cargo_list.js"></script>
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
<div class="main_content"><!--中部开始-->
<div class="search">
<div class="search_mid">
<div class="search_bar" style="border:none;">
<div class="sear_top">
<span class="blue"><img src="/images/fcl/fcl_ico.gif" />&nbsp;货盘种类:
</span><asp:DropDownList ID="txtLine" runat="server" Width=110 Font-Size="12px">
<asp:ListItem Text="全部" Value=""></asp:ListItem>
<asp:ListItem>海运货盘</asp:ListItem>
<asp:ListItem>空运货盘</asp:ListItem>
</asp:DropDownList>		
<span class="blue">起运港:</span>
<asp:TextBox ID="txtStartport" runat="server" CssClass="bigTextbox" width="194px"></asp:TextBox>
<span class="blue">目的港:</span>
<asp:TextBox ID="txtDestport" runat="server" CssClass="bigTextbox" width="194px"></asp:TextBox>
&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/images/fcl/search.gif" width="128" height="28" border="0" style="margin-bottom:-6px;"  />
<br/><br/>
</div>
</div>

</div>
</div>

<div class="notice"><p>
共找到<span class="orange"><asp:Label ID="hidTotalItem" runat="server" ></asp:Label></span>条记录
<asp:Label ID="Label6" runat="server" Text="种类："></asp:Label><b><asp:Label ID="hidTxtLine" runat="server" ></asp:Label></b>&nbsp;&nbsp;
<asp:Label ID="Label7" runat="server" Text="起运港："></asp:Label><b><asp:Label ID="hidTxtStartport" runat="server" ></asp:Label></b>&nbsp;&nbsp;
<asp:Label ID="Label13" runat="server" Text="目的港："></asp:Label><b><asp:Label ID="hidTxtDestport" runat="server" ></asp:Label></b>

你怎么还在找货盘？货主们都在找“<strong>安运通会员</strong>"订舱了，赶紧申请吧！</p>
</div>

<div class="freight_List_title">
<h2><img src="/images/fcl/zx_ico_2.gif" width="20" height="20" />货盘信息</h2>
&nbsp;<a href="/member/cargoselect.aspx" target="_blank"><img src="/images/fcl/w_bt.gif" style="margin-left:10px;" border=0  /></a>
</div>

<div class="biaoti">
<table width="950" height="44" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="1" bgcolor="#CAC9C7"><img src="/images/fcl/biaoti_bg.gif" /></td>
<td background="/images/fcl/biaoti_bg2.gif"><table width="742" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="blue2"><table width="99%" height="38" border="0" cellpadding="0" cellspacing="1">
<tr>
<td width="1%" height="38" align="center">&nbsp;</td>
<td width="33%"><strong>标题</strong></td>
<td width="13%"><strong>起运港</strong></td>
<td width="13%"><strong>目的港</strong></td>
<td width="13%"><strong>类型</strong></td>
<td width="13%"><strong>货量</strong></td>
<td width="13%"><strong>发布/截止时间</strong></td>
</tr>
</table></td>
</tr>
</table></td>
<td width="1"><img src="/images/fcl/biaoti_bg3.gif" /></td>
</tr>
</table>
</div>
<div class="main_left"><!--左边开始-->
<div class="freight_List">
<div class="list_box">
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
<ul>
<li>
<table width="100%" height="38" border="0" cellpadding="0" cellspacing="1">
<tr>
<td width="2%" height="38" align="center">&nbsp;</td>
<td width="33%"><a href="../cargo/<%# eval("id") %>.html" target="_blank"  style="font:14px '宋体'; color:#22568F;"><strong><asp:Label ID="Label8" runat="server" Text='<%# eval("name") %>'></asp:Label> <asp:Label ID="Label4" runat="server" Text='<%# eval("title") %>'></asp:Label></strong></a></td>
<td width="13%"><%# eval("startport") %></td>
<td width="13%"><%# eval("destport") %></td>
<td width="13%"><asp:Label ID="Label3" runat="server" Text='<%# eval("typem") %>'></asp:Label>/<asp:Label ID="Label9" runat="server" Text='<%# eval("type") %>'></asp:Label></td>
<td width="13%"><%# eval("amount") %></td>
<td width="13%"><%# FORMAT(eval("postdate"),"yyyy-MM-dd").tostring  %><br />
<%# IIF ((FORMAT(NOW(),"yyyy-MM-dd").tostring > eval("enddate")) ,"<span style=""color:#FF0000;"">" & eval("enddate") & "</span>",eval("enddate"))%></td>
</tr>
</table>
</li>
</ul>
</ItemTemplate>
</asp:Repeater>  	
</div>
<DIV class=manu>
<SPAN class=disabled style="margin:0px; padding:0px; line-height:27px; height:27px; border:none; color:#28385A; float:left;">
<asp:Label ID="lblCurrentPage" runat="server" Text="1"></asp:Label>/<asp:Label ID="lblTotalPage" runat="server"  Text="1"></asp:Label><asp:HiddenField
ID="hidTotalPage" runat="server" />
</SPAN>
<asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
<asp:Label ID="hidSaveSearchWords" runat="server" Text="1" CssClass="hidden"></asp:Label>
直接到第 <input id="txtPageJump" name="txtPageJump" type="text" style=" width:20px; height:12px;" runat="server"/> 页 
<input id="btnPageJump" name="btnPageJump" type="button" value="确定" style=" width:40px; height:20px;" runat="server"/>
</DIV>
</div>


<div class="ad" style="display:none;">
<a href="/topic/lcl090619/" target="_blank">
<img src="/images/index/home_lcl090619.gif" width="742" height="65" border="0" alt="拼箱知识大放送"/>
</a>
</div>	

</div>

<div class="main_right"><!--右边开始-->
<div class="assured">
<h2>&nbsp;</h2>
<ul>
	<asp:Repeater ID="RptOrder" runat="server">
	<ItemTemplate>						
	<li>·<a href="/company/<%# key(Eval("userid").ToString())%>/" target="_blank"><%#GetFirstString(Eval("companyname").ToString(),24)%></a></li>
	</ItemTemplate>
	</asp:Repeater>						
</ul>
<div class="assured_an"><a href="/topic/try20091215/" target="_blank"><img src="/images/company/assured_an.gif" width="159" height="38" border="0" /></a></div>
</div>
<div class="right_ad" style="margin-bottom:4px;"><a href="/topic/order20091104/product_1.aspx" target="_blank"><img src="/images/company/company_bt2.gif" width="200" height="47" border="0" /></a></div>			
<uservisited:uservisited ID="uservisited1" runat="server" />

</div><!--右边结束-->			
</div>
<userlinkbottom5:userlinkbottom5 ID="userlinkbottom51" runat="server" />
<userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
</form>
</body>
</html>
