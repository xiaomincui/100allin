<%@ Page Language="C#" AutoEventWireup="true" CodeFile="air_order.aspx.cs" Inherits="search_air_order" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>订舱单</title>
<link href="/css/booking0118.css" rel="stylesheet" type="text/css" />
</head>

<body>

<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div style="display:none;">
<asp:TextBox ID="txtPubf" runat="server"></asp:TextBox>
<asp:Literal ID="ltrBasicOrderCode" runat="server"></asp:Literal>
<asp:Literal ID="ltrSMS" runat="server"></asp:Literal>
</div>
<div class="main_container"><!--页面主体开始-->	

<asp:Literal ID="ltrOrderStatus" runat="server"></asp:Literal>
		<div class="main_content">
			<div class="book">
				<h2><img src="/images/fcl/booking_h2.GIF" /></h2>
				<table width="840" border="0" cellpadding="0" cellspacing="1" bgcolor="#d3d3d3">
  <tr>
    <td width="420" rowspan="3" align="center" valign="top" bgcolor="#FFFFFF"><table width="380" border="0" align="center" cellpadding="0" cellspacing="0">
	  <tr>
        <td height="6" align="left"></td>
      </tr>
	  <tr>
        <td height="24" align="left"><span class="red1">*</span><strong> 发货人</strong>(Shipper)：</td>
      </tr>
      <tr>
        <td align="left"><div style="height:80px; border:1px solid #DDDDDD; padding:5px;"><asp:Literal ID="ltrOrderViewShipper" runat="server"></asp:Literal></div></td>
      </tr>
      <tr>
        <td height="24" align="left"><span class="red1">*</span> <strong>收货人</strong>(Consignee)：</td>
      </tr>
      <tr>
        <td align="left"><div style="height:80px; border:1px solid #DDDDDD; padding:5px;"><asp:Literal ID="ltrOrderViewConsignee" runat="server"></asp:Literal></div></td>
      </tr>
      <tr>
        <td height="24" align="left"><span class="red1">*</span> <strong>通知人</strong>(Notify Party)：</td>
      </tr>
      <tr>
        <td align="left"><div style="height:80px; border:1px solid #DDDDDD; padding:5px;"><asp:Literal ID="ltrOrderViewNotifyParty" runat="server"></asp:Literal></div></td>
      </tr>
      <tr>
        <td height="6" align="left"></td>
      </tr>
    </table></td>
    <td width="420" height="24" align="center" bgcolor="#FFFFFF"><strong>订单编号</strong>：<asp:Literal ID="ltrOrderViewCode" runat="server"></asp:Literal></td>
  </tr>
  <tr>
    <td height="110" align="center" bgcolor="#FFFFFF" class="red" style="font-size:26px;"><strong>订舱委托书</strong></td>
  </tr>
  <tr>
    <td valign="top" bgcolor="#FFFFFF"><table border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="6" colspan="4" align="left"></td>
		</tr>
	  <tr>
        <td width="89" height="31" align="left"><strong>　</strong><span class="red1">*</span> <strong>公司</strong>：</td>
        <td colspan="3" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewCompanyName" runat="server"></asp:Literal></div></td>
        </tr>
      <tr>
        <td height="31" align="left"><strong>　</strong><span class="red1">*</span> <strong>邮箱</strong>：</td>
        <td colspan="3" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewEmail" runat="server"></asp:Literal></div></td>
        </tr>
      <tr>
        <td width="89" height="31" align="left"><span class="red1">*</span> <strong>联系人</strong>：</td>
        <td width="105" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewContactor" runat="server"></asp:Literal></div></td>
        <td width="87" align="left">&nbsp;&nbsp;<span class="red1">*</span><strong> 手机</strong>：</td>
        <td width="99" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewMobile" runat="server"></asp:Literal></div></td>
      </tr>
      <tr>
        <td width="89" height="31" align="left"><strong>　</strong><span class="red1">*</span> <strong>电话</strong>：</td>
        <td width="105" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewTel" runat="server"></asp:Literal></div></td>
        <td width="87" align="left">&nbsp;&nbsp;<span class="red1">*</span> <strong>传真</strong>：</td>
        <td width="99" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewFax" runat="server"></asp:Literal></div></td>
      </tr>
      <tr>
        <td height="31" align="left"><span class="red1">&nbsp;</span> <strong>起运港</strong>：</td>
        <td colspan="3" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;" id="txtstartport"><asp:Literal ID="ltrOrderViewStartport" runat="server"></asp:Literal></div></td>
        </tr>
      <tr>
        <td height="31" align="left"><span class="red1">&nbsp;</span> <strong>中转港</strong>：</td>
        <td colspan="3" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewMidport" runat="server"></asp:Literal></div></td>
        </tr>
		<tr>
        <td height="31" align="left"><span class="red1">&nbsp;</span> <strong>目的港</strong>：</td>
        <td colspan="3" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;" id="txtdestport"><asp:Literal ID="ltrOrderViewDestport" runat="server"></asp:Literal></div></td>
        </tr>
		<tr>
        <td height="6" colspan="4" align="left"></td>
		</tr>
    </table></td>
  </tr>
  <tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table width="820" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" colspan="5" align="center"></td>
        </tr>
	  <tr>
        <td width="140" height="34" align="center"><strong>唛头</strong>：<br />
  Marks & Numbers</td>
        <td width="140" height="31" align="center"><strong>件数</strong>：<br />
          Numbers of Packages</td>
        <td width="240" height="31" align="center"><span class="red">*</span><strong> 品名</strong>：<br />
          Description of Goods &amp;Packages</td>
        <td width="140" height="31" align="center"><span class="red">*</span><strong> 毛重(KGS)</strong>：<br />
          Gross Weight</td>
        <td width="140" height="31" align="center"><span class="red">*</span><strong> 体积(CBM)</strong>：<br />
         Measurement</td>
      </tr>
      <tr>
        <td height="34" align="center"><div style="height:172px; width:115px; border:1px solid #DDDDDD; padding:5px; text-align:left;"><asp:Literal ID="ltrOrderViewMarksNumbers" runat="server"></asp:Literal></div></td>
        <td height="31" align="center"><div style="height:172px; width:115px; border:1px solid #DDDDDD; padding:5px; text-align:left;"><asp:Literal ID="ltrOrderViewNumbersofPackages" runat="server"></asp:Literal></div></td>
        <td height="31" align="center"><div style="height:172px; width:215px; border:1px solid #DDDDDD; padding:5px; text-align:left;"><asp:Literal ID="ltrOrderViewDescription" runat="server"></asp:Literal></div></td>
        <td height="31" align="center"><div style="height:172px; width:115px; border:1px solid #DDDDDD; padding:5px; text-align:left;"><asp:Literal ID="ltrOrderViewGrossWeight" runat="server"></asp:Literal></div></td>
        <td height="31" align="center"><div style="height:172px; width:115px; border:1px solid #DDDDDD; padding:5px; text-align:left;"><asp:Literal ID="ltrOrderViewMeasurement" runat="server"></asp:Literal></div></td>
      </tr>
      <tr>
        <td height="12" colspan="5" align="center"></td>
        </tr>
    </table></td>
    </tr>
  <tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table style="background:url(images/fcl/book_bg.gif) no-repeat 495px;" width="800" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" colspan="9" align="center"></td>
      </tr>
		<tr>
		  <td height="40" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<strong>运费条款</strong>：</td>
		  <td width="121" height="31" align="left">预付(PP)</td>
		  <td width="61" height="31" align="left">&nbsp;</td>
		  <td width="82" height="31" align="left">&nbsp;</td>
		  <td width="105" height="31" align="left">&nbsp;&nbsp;<font color="red">*</font><strong> 航空公司</strong>：</td>
		  <td width="120" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;" id="txtcarrier_name"><asp:Literal ID="ltrOrderViewCarrier" runat="server"></asp:Literal></div></td>
		  <td width="73" align="left">&nbsp;</td>
		  <td width="131" align="left">&nbsp;</td>
		  <td width="15" align="left"></td>
		  </tr>
		<tr>
		  <td height="40" align="left">&nbsp;&nbsp;&nbsp;&nbsp;<font color="red">*</font><strong> 开航日</strong>：</td>
		  <td height="31" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;" id="txtkaihangri"><asp:Literal ID="ltrOrderViewKaihangri" runat="server"></asp:Literal></div>
            </td>
		  <td height="31" align="left"><strong>&nbsp;结束日</strong>：</td>
		  <td height="31" align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewEnddate" runat="server"></asp:Literal></div></td>
		  <td height="31" align="left">&nbsp;&nbsp;<strong>预计货妥日</strong>：</td>
		  <td align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;"><asp:Literal ID="ltrOrderViewZhuangxiangri" runat="server"></asp:Literal></div>
            </td>
		  <td align="left"><strong style="display:none;">&nbsp;&nbsp;截关日</strong>：</td>
		  <td align="left"><div style="border:1px solid #DDDDDD; padding:3px;height:13px;display:none;"><asp:Literal ID="ltrOrderViewJieguanri" runat="server"></asp:Literal></div>
            </td>
		  <td align="left"></td>
		  </tr>
	  <tr>
	    <td width="91" height="40" align="left"><font color="red">*</font><strong> 计费重量</strong>：</td>
	    <td height="31" colspan="4" align="left"><table border="0" cellpadding="0" cellspacing="0">
	      <tr>
	        <td width="38"><div style="border:1px solid #DDDDDD; padding:3px; width:30px;height:13px;" id="txtgp"><asp:Literal ID="ltrOrderViewGP" runat="server"></asp:Literal></div></td>
	        <td width="45">&nbsp;<strong>KGS</strong></td>
	        </tr>
	      </table></td>
	    <td colspan="3" align="left">
        <div style="border:1px #A4DDFF solid; padding:5px; text-align:center; background:#F4FFFF;line-height:22px;">
        <strong style="font-size:14px;">运费</strong>： <span style="font-size:16px; color:#FF0000; font-weight:bold;">$</span> <span id="hyf" style="font-size:16px; color:#FF0000; font-weight:bold;">
	      <asp:Literal ID="ltrOrderViewHyf" runat="server">0</asp:Literal></span> 
	      <span style="color:#666666;"><asp:Literal ID="ltrOrderFujiafei" runat="server"></asp:Literal></span>
	      </div>
          </td>
	    <td align="left">&nbsp;</td>
	    </tr>
      <tr>
        <td height="12" colspan="9" align="center"></td>
      </tr>
    </table></td>
    </tr>    
  <tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table style="background:url(images/fcl/book_bg.gif) no-repeat 495px;" width="800" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" align="center"></td>
      </tr>
      <tr>
        <td height="31" align="left"><table width="796" border="0" cellpadding="0" cellspacing="0">
          <tr style="background:url(/images/fcl/order_biaoti_bg2.gif)">
            <td width="6" height="30" align="center"><img src="/images/fcl/order_biaoti_bg.gif" /></td>
            <td>&nbsp;<strong>相关运费详情：</strong></td>
            <td width="70"><strong>+45</strong></td>
            <td width="70"><strong>+100</strong></td>
            <td width="70"><strong>+300</strong></td>
            <td width="70"><strong>+500</strong></td>							
            <td width="70"><strong>+1000</strong></td>
            <td width="103" align="center"><strong>订舱保证</strong></td>
            <td width="8" align="center"><img src="/images/fcl/order_biaoti_bg3.gif" /></td>
            </tr>
          <tr>
            <td>&nbsp;</td>
            <td><table border="0" cellpadding="3" cellspacing="1">
              <tr>
                <td height="25"><asp:Literal ID="ltrFreightTitle" runat="server"></asp:Literal> 
                <span class="gray"><asp:Literal ID="ltrFreightPostdate" runat="server"></asp:Literal>～<asp:Literal ID="ltrFreightEnddate" runat="server"></asp:Literal></span>
                <span style="display:none;">
                <asp:Literal ID="ltrFreightTitleHid" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightCompanyHid" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightPostdateHid" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightEnddateHid" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightAssuranceSpaceLevel" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightAssurancePriceLevel" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightAllinStarHid" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightUserStarHid" runat="server"></asp:Literal>
                <strong><span id='fappend' style="display:none;"><asp:Literal ID="ltrFreightAppend" runat="server"></asp:Literal></span><asp:Literal ID="ltrFreightCarrier" runat="server"></asp:Literal></strong>
                </span>                </td>
                </tr>
              <tr>
                <td><span class="blue_2"><b><asp:Literal ID="ltrFreightLine" runat="server"></asp:Literal></b></span>&nbsp;<span class="gray">|</span>&nbsp;<span class="blue_2"><b><asp:Literal ID="ltrFreightStartport" runat="server"></asp:Literal></b></span>&nbsp;<span class="gray">至</span>&nbsp;<span class="blue_2"><b><asp:Literal ID="ltrFreightDestport" runat="server"></asp:Literal></b></span>&nbsp;</td>
                </tr>
              <tr>
                <td><asp:Literal ID="ltrFreightCompany" runat="server"></asp:Literal>
                <asp:Literal ID="ltrFreightAllinStar" runat="server"></asp:Literal>
                &nbsp; <span class="blue_1">信誉等级：</span><span class="yt"><asp:Literal ID="ltrFreightUserStar" runat="server"></asp:Literal></span></td>
                </tr>
              </table></td>
            <td><strong><span id='fa45'><asp:Literal ID="ltrFreightA45" runat="server"></asp:Literal></span></strong></td>
            <td><strong><span id='fa100'><asp:Literal ID="ltrFreightA100" runat="server"></asp:Literal></span></strong></td>
			<td><strong><span id='fa300'><asp:Literal ID="ltrFreightA300" runat="server"></asp:Literal></span></strong></td>
			<td><strong><span id='fa500'><asp:Literal ID="ltrFreightA500" runat="server"></asp:Literal></span></strong></td>
			<td><strong><span id='fa1000'><asp:Literal ID="ltrFreightA1000" runat="server"></asp:Literal></span></strong></td>
            <td>
              <table border="0" cellpadding="3" cellspacing="1">
                <tr>
                  <td><asp:Literal ID="ltrFreightAssuranceSpace" runat="server"></asp:Literal>                  </td>
                  </tr>
                <tr>
                  <td><asp:Literal ID="ltrFreightAssurancePrice" runat="server"></asp:Literal>                  </td>
                  </tr>
                </table></td>
            <td>&nbsp;</td>
            </tr>
          </table></td>
      </tr>
      <tr>
        <td height="12" align="center"></td>

      </tr>
    </table></td>
  </tr>
  <tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table width="800" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" align="center"></td>
      </tr>
      <tr>
        <td height="34" align="left"><strong>备注及其他要求</strong>：</td>
        </tr>
      <tr>
        <td height="34" align="center"><div style="border:1px solid #DDDDDD; padding:5px; text-align:left; height:120px;"><asp:Literal ID="ltrOrderViewBeizhu" runat="server"></asp:Literal></div></td>
        </tr>
      <tr>
        <td height="12" align="center"></td>
      </tr>
    </table></td>
  </tr>
<tr>
    <td colspan="2" align="center" valign="top" bgcolor="#FFFFFF"><table width="800" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="6" align="center"></td>
      </tr>
      <tr>
        <td height="34" align="left"><strong>订单过程</strong>：</td>
        </tr>
      <tr>
        <td height="34" align="center">
            <div style="border:1px solid #DDDDDD; padding:5px; text-align:left; line-height:20px;">
            <asp:Literal ID="ltrOrderFirstStep" runat="server"></asp:Literal> <br/>
            <asp:Repeater ID="rptOrder" runat="server">
            <ItemTemplate>
            <%# Eval("detail_date").ToString() %>：<%# Eval("detail_txt").ToString() %> <br/>
            </ItemTemplate>
            </asp:Repeater></div>        
            
        </td>
        </tr>
      <tr>
        <td height="12" align="center"></td>
      </tr>
    </table></td>
  </tr>
</table>
			
<br/><br/>
			</div>
			
			
  </div>
 <userbottomline:userbottomline id="userbottomline1" runat="server"/>
 <userbottom:userbottom ID="userbottom1" runat="server" />
</div>


</form>

</body>
</html>