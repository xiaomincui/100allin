﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="lcl_old.aspx.vb" Inherits="search_lcl_old" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<asp:Literal id="Literal2" runat="server"><meta name="keywords" content="国际货运,国际海运,拼箱,拼箱报价" /></asp:Literal>
<asp:Literal id="Literal3" runat="server"><meta name="description" content="海运拼箱价格频道-及时的国际货运拼箱运费查询,详尽的国际海运拼箱报价信息,为全行业货代公司提供最优质的服务,为货主提供最便捷的需求发布平台,环球运费网" /></asp:Literal>
<asp:Literal id="Literal1" runat="server"><title>拼箱价格信息查询-该页面已转移-环球运费网</title></asp:Literal>
<link href="/css/fcl_css2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<script language="javascript" type="text/javascript">
Sys.Application.add_load(function(){var form=Sys.WebForms.PageRequestManager.getInstance()._form;form._initialAction=form.action=window.location.href;});
</script>   
<div class="main_container"><!--页面主体开始-->	
<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
			<h1><userwelcome:userwelcome ID="userwelcome1" runat="server" /><a href="/" target="_blank">首页</a> > 整箱海运价</h1>
			<span class="right_tn"><img src="/images/fcl/lian.GIF" />&nbsp;<a href="#" target="_parent">在线客服</a></span>
		</div><!--导航结束-->
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
                      <asp:Label ID="Label28" runat="server" Text=""></asp:Label>
                  </td>
                </tr>
              </table>
              <br/><br/><br/><br/>
			  </div>
		  </div>

  		</div>     
	  	  <userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
    </form>
</body>
</html>
