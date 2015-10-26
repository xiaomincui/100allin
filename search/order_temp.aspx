<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_temp.aspx.cs" Inherits="search_order_temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>订舱提示</title>
<link href="/css/booking.css" rel="stylesheet" type="text/css" />
</head>

<body>
<div class="main_container"><!--页面主体开始-->	
		<div class="top_bar"><!--顶部登陆开始-->
			<div class="top_bar_hd">
		<h2><a href="/"><img src="/images/fcl/home.gif" border="0" alt="环球运费网" /><strong>环球运费网</strong></a></h2>
		<ul>
		<li>&nbsp;<a href="/help/help_about.html" target="_blank"><span class="orange bold">帮助</span></a>&nbsp;</li>
		<li>&nbsp;<a href="/member/" target="_blank">进入办公室</a>&nbsp;|</li>
		<li>&nbsp;<a href="/accounts/reg.aspx">免费注册</a>&nbsp;|</li>
		<li><a href="/accounts/login.aspx">登陆</a>&nbsp;|</li>		
		</ul>
	</div>
		</div><!--顶部登陆结束-->	
   <div class="booking_sm">
  <img src="/images/fcl/shipper_booking_m_r1_c1.gif" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="/images/fcl/booking_m_r1_c12.gif" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="/images/fcl/booking_m2_r1_c3.gif" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="/images/fcl/booking_bb2.gif" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="/images/fcl/booking_m2_r1_c5.gif" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="/images/fcl/booking_bb2.gif" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="/images/fcl/shipper_booking_m2_r1_c9.gif" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="/images/fcl/booking_bb2.gif" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="/images/fcl/booking_m2_r1_c7.gif" />
  </div>
   <div class="notice"><p>对方未操作“<strong>接受订舱</strong>”前，运费保证条款未生效，请不要实际下单出货。</p>
  </div>
		<!--导航结束-->
<table width="70%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#1c6cbe" style="line-height:24px; font-size:14px;">
          <tr>
            <td align="center" style=" background:#FFFFFF url(/images/fcl/fcl_qiao.jpg) no-repeat left top; "><a href="#"></a> <br />
                <br />
                <br />
                <table width="86%" border="0" align="center" cellpadding="0" cellspacing="0" style="line-height:24px; font-size:14px;">
                  <tr>
                    <td align="left" style="color:Navy;">· 网上订舱单只作为环球运费网提供的价格及舱位保障依据，不能取代常规线下订舱操作！<br />
                                  <br />
                      · 与对方协商后如运费有调整，请要求对方在收到舱单后修改运费，并经过您的重新确认，否则您有权撤消订舱。</td>
                  </tr>
                  <tr>
                    <td height="80" align="center" class="red"><asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                  </tr>
              </table></td>
          </tr>
        </table>
  
  		
		
	    <userbottomline:userbottomline id="userbottomline1" runat="server"/>
	  <userbottom:userbottom ID="userbottom1" runat="server" />
</div><!--页面主体结束-->	
</body>
</html>
