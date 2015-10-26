<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orc.aspx.cs" Inherits="intro_Orc" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>2009年最新ORC附加费-该页面已转移-环球运费网</title>
<meta name="keywords" content="ORC 附加费" />
<meta name="description" content="环球运费网是全球最大的专业运价查询平台，提供最新ORC附加费查询。" />
    <link href="/css/fcl_css.css" rel="stylesheet" type="text/css" />

    <style type="text/css">


.divexcees {
    text-overflow:clip;
    overflow: hidden;
}

.pm a:link {
	color: #666666;
	text-decoration: none;
}
.pm a:visited {
	text-decoration: none;
	color: #666666;
}
.pm a:hover {
	text-decoration: none;
	color: #FF6600;
}
.pm a:active {
	text-decoration: none;
	color: #666666;
}

.divexcees a:link {
	color: #333333;
	text-decoration: underline;
}
.divexcees a:visited {
	text-decoration: underline;
	color: #333333;
}
.divexcees a:hover {
	text-decoration: underline;
	color: #FF6600;
}
.divexcees a:active {
	text-decoration: underline;
	color: #333333;
}
.hidden {
    display:none;
}
</style>
<script language="javascript" type="text/javascript" src="../js/function.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main_container"><!--页面主体开始-->	
		<usernewtop:usernewtop ID="usernewtop1" runat="server" />
		<div class="menu"><!--导航开始-->
		  <h1><userwelcome:userwelcome ID="userwelcome1" runat="server" />
		    您现在的位置:<a href="/" target="_blank">首页</a> > 2009年最新ORC</h1>
			<userservice:userservice ID="userservice1" runat="server" />
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

