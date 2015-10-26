<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_1.aspx.cs" Inherits="topic_order20091104_product_1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>关于安运通 - 环球运费网</title>
<link href="css/product.css" rel="stylesheet" type="text/css" />
</head>

<body>
<div class="main">
				<div class="head"><!--顶部开始-->
			<div class="head_mid">
				<div id="logo"><a href="/"><img src="images/fcl/p_logo.GIF" alt="环球运费网" width="201" border="0" /></a></div>
			</div>
		</div><!--顶部结束-->
		<div class="container"><!--主体开始-->
			<DIV id="tabs2">
					  <DIV class="menu2box">
<UL id="menu2">
<LI class="hover"><A 
href="/topic/order20091104/product_1.aspx"><strong>关于安运通</strong></A></LI>
<LI><A
href="/topic/order20091104/product_3.aspx">支付宝担保交易</A></LI>
</UL>
						<span style="float:right; line-height:28px; color:#263E58;"><img style="vertical-align:middle;" src="images/fcl/dhua.GIF" />&nbsp;咨询电话：<strong>400-888-9256</strong>&nbsp;&nbsp;&nbsp;<img src="images/fcl/LedIcon_280.GIF" width="16" height="16" style="vertical-align:middle;" />&nbsp;<a style="color:#FF6600; text-decoration:underline;" href="#" onclick="document.getElementById('aliserv').click();">在线咨询</a>&nbsp;&nbsp;&nbsp;</span></DIV>
							<DIV class="main2box">
								<table width="946" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="1" height="1"></td>
    </tr>
  <tr>
    <td><img src="/images2/fcl/P_4.gif" width="946" height="97" /><br />
      <img src="/images2/fcl/P_5.gif" width="946" height="97" /><br />
      <img src="/images2/fcl/P_6.gif" width="946" height="97" /><br />
      <img src="images/fcl/P_6.gif" width="946" height="68" /><br />
      <img src="images/fcl/P_7.gif" width="946" height="108" border="0" usemap="#Map" /><br />
      <br /></td>
    </tr>
  <tr>
    <td height="33" background="images/fcl/P_8.gif"><table width="200" height="33" border="0" cellpadding="0" cellspacing="1">
      <tr>
        <td>&nbsp;&nbsp;&nbsp;<img src="images/fcl/P_8_1.gif" width="18" height="18" /></td>
        <td><span style="font:14px '宋体';"><strong>成为安运通会员的理由</strong></span></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="15"></td>
  </tr>
  <tr>
    <td><table width="946" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td align="center"><img src="images/fcl/P_9_1.gif" width="247" height="57" /></td>
        <td align="center"><img src="images/fcl/P_9_2.gif" width="334" height="57" /></td>
        <td align="center"><img src="/images2/fcl/P_9_3.gif" width="334" height="58" /></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="20">&nbsp;</td>
  </tr>
  <tr>
    <td><img src="/images2/fcl/P_10.gif" width="946" height="150" /><br />
      <img src="/images2/fcl/P_11.gif" width="946" height="64" border="0" usemap="#Map2" />
      <map name="Map2" id="Map22">
        <area shape="rect" coords="243,79,396,113" href="#" target="_parent" />
      </map>
      <map name="Map2" id="Map2">
        <area shape="rect" coords="243,79,396,113" href="/topic/order20091104/product_2.aspx" />
      </map></td>
  </tr>
  <tr>
    <td height="30">&nbsp;</td>
  </tr>
  <tr>
    <td height="33" background="images/fcl/P_12.gif"><table width="399" height="33" border="0" cellpadding="0" cellspacing="1">
      <tr>
        <td width="41">&nbsp;&nbsp;&nbsp;<img src="images/fcl/P_12_1.gif" width="18" height="18" /></td>
        <td width="355"><span style="font:14px '宋体';"><strong>我们是安运通会员，郑重承诺提供优质服务</strong></span></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td><div class="cp_box">
								<ul>
									<li  style="background-color:#E9EEF1; margin-top:1px; border-bottom:1px solid #D1DCE2;border-top:1px solid #D1DCE2;">
									  <table width="100%" border="0" cellspacing="1" cellpadding="0">
										<tr>
										  <td width="2%" height="30">&nbsp;</td>
										  <td width="40%">公司名称</td>
										  <td width="18%">省份\城市</td>
										  <td width="20%">主要服务</td>
										  <td width="20%">&nbsp;</td>
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
										  <td width="10%" align="left"  class="picSmall"><a href="/company/<%#key(Eval("userid").ToString())%>/" target="_blank"><img src="/member/Head/<%#Convert.ToBoolean(Eval("HeadURL").ToString()) == true ? (Eval("userid").ToString()): "default" %>.jpg" width="70" height="70" border="0" /></a></td>
										  <td width="30%"><table width="100%" border="0" cellspacing="1" cellpadding="0">
                                            <tr>
                                              <td height="25"><a href="/company/<%#key(Eval("userid").ToString())%>/" target="_blank"><strong><%#Eval("CompanyName").ToString()%></strong></a></td>
                                            </tr>
                                            <tr>
                                              <td height="25"><%#Eval("Realname").ToString()%>&nbsp;<%#Star1(Eval("star_allin").ToString())%></td>
                                            </tr>
                                            <tr>
                                              <td height="24">信誉指数：<%#Star2(Eval("star_user").ToString())%></td>
                                            </tr>
                                          </table>										    
									      </td>
										  <td width="18%" c><table width="100%" border="0" cellspacing="1" cellpadding="0">
                                            <tr>
                                              <td height="25"><%#Eval("Login2_Locus1").ToString()%>-<%#Eval("Login2_Locus2").ToString()%></td>
                                            </tr>
                                            <tr>
                                              <td height="25">号码验证：<span class="orange">正确</span></td>
                                            </tr>
                                          </table></td>
										  <td width="20%" class="blue"><table width="100%" border="0" cellspacing="1" cellpadding="0">
                                            <tr>
                                              <td height="25"><%#Eval("Login2_Adventage_Type_fcl").ToString() == "1"? "整箱海运":""%> </td>
                                            </tr>
                                            <tr>
                                              <td height="25"><%#Eval("Login2_Adventage_Type_lcl").ToString() == "1"? "拼箱海运":""%> </td>
                                            </tr>
                                            <tr>
                                              <td height="25"><%#Eval("Login2_Adventage_Type_air").ToString() == "1"? "空运":""%></td>
                                            </tr>
                                          </table></td>
										  <td width="20%"><table width="100%" border="0" cellspacing="1" cellpadding="0">
                                            <tr>
                                              <td height="25"><a href="/member/pm_detail.aspx?pid=1&cid=<%#Eval("userid").ToString() %>" target="_blank"><img src="images/company/booking_bt3.gif" width="76" height="25" border="0" /></a></td>
                                            </tr>
                                            <tr>
                                              <td height="10"></td>
                                            </tr>
                                            <tr>
                                              <td height="24"><a href="#" style="display:none;"><img src="images/company/booking_bt2.gif" width="76" height="25" border="0" /></a></td>
                                            </tr>
                                          </table></td>
									    </tr>
									  </table>
									</li>
								</ul>
                        </ItemTemplate>
                      </asp:Repeater>	
								<div class="page_head">&nbsp;&nbsp;</div>
								<div class="page">
										<a href="/company/">>> 更多</a>&nbsp;&nbsp;
							  </div>
		    </div></td>
  </tr>
</table>

			  </DIV>
		  </DIV>
		</div><!--主体结束-->
		 <userbottomline:userbottomline id="userbottomline1" runat="server"/>
 <userbottom:userbottom ID="userbottom1" runat="server" />
</div>
<map name="Map" id="Map">
  <area shape="rect" coords="619,15,930,63" href="/help/help_7.aspx" />
</map>
<script src="http://s16.cnzz.com/stat.php?id=2376862&web_id=2376862&show=pic1" language="JavaScript"></script>

</body>
</html>
