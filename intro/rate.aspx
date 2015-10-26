<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rate.aspx.cs" Inherits="intro_rate" EnableViewState="false" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>环球运费网 - 外汇汇率 外汇牌价</title>
<link href="/css/fcl_css.css" rel="stylesheet" type="text/css" />


<style type="text/css">
#publish {width:935px;}
#Label2 table tr{height:38px;line-height:38px;}
#Label2 table th{font-weight:bold;color:#000;text-align:center;border-top:1px solid #eee;border-bottom:2px solid #eee;border:0;}
#Label2 table tr.odd{background:#f8f8f8;}
#Label2 table tr td{border:0;}

</style>



</head>

<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="main"><!--页面主体开始-->	
		<usernewtop1209:usernewtop1209 ID="usernewtop12091" runat="server" />
		<div class="menu_end">
			<h1><a href="/" target="_blank">首页</a> > 最新汇率</h1>
        </div>
		<div class="main_content"><!--中部开始-->
			<div class="" style="background:url(images/fcl/info_bg.gif) no-repeat left top;"><!--左边开始-->
			<div style="clear:both;">
		      <table width="92%" border="0" align="center" cellpadding="0" cellspacing="1" style="background:url(images/fcl/33.gif) no-repeat right 65px;">
                <tr>
                  <td height="10" align="center"></td>
                </tr>
				<tr>
                  <td height="32" align="left" ><div class="blue" style=" font:14px '宋体'; line-height:48px; border-bottom:1px dashed #ccc;"><img src="/images/fcl/jt2.gif" />&nbsp;<strong>最新汇率</strong></div></td>
                </tr>
				<tr>
                  <td height="10" align="center" ></td>
				</tr>
                <tr>
                  <td height="28" align="left">
                      <div id="publish"><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></div>
                  </td>
                </tr>
              </table>
			  </div>
		  </div>

  		</div>
	  <userbottomline:userbottomline ID="userbottomline1" runat="server" />
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
</form>
</body>
</html>
