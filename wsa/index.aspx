<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="wsa_index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>上海伟胜贤国际货运代理有限公司</title>
<meta name="keywords" content="上海伟胜贤,国际货运,拼箱,近洋线,中东印巴线">
<META name="description" content="上海伟胜贤国际货运代理有限公司,海运出口拼箱,航线描述-近洋线与中东印巴线">

<style type="text/css">
<!--
body {
	margin: 0px;
	font:12px "宋体";
}

.foot_text{
	color: #FFFFFF;
}

.blue,.yj{
	color:#49708d;
	line-height:22px;
}

.blue a{
	color:#49708d;
	text-decoration:none;
	line-height:22px;
}

.blue a:hover{
	color: #FF6600;
	text-decoration:underline;
}

.yj td{
	padding-left:3px;
}

-->
</style></head>

<body>
<table width="945" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><a href="/wsa"><img src="images/1.gif" width="360" height="91" border="0" /></a><a href="http://www.wsachina.com/newEbiz1/EbizPortalFG/portal/html/GeneralContentShow.html" target="_blank"><img src="images/2.gif" alt="走进伟胜贤" width="94" height="91" border="0" /></a><a href="http://www.wsachina.com/newEbiz1/EbizPortalFG/portal/html/InfoPublishs.html" target="_blank"><img src="images/3.gif" alt="新闻资讯" width="82" height="91" border="0" /></a><a href="http://www.wsachina.com/newEbiz1/EbizPortalFG/portal/html/CategoryList.html?ProductMultiCategoryPicker210_action=SearchCategory&amp;CategoryID=c373e916a86b9bc08ffa12c2579d014f" target="_blank"><img src="images/4.gif" alt="公司业务" width="82" height="91" border="0" /></a><a href="http://www.wsachina.com/newEbiz1/EbizPortalFG/portal/html/GeneralContentShow2.html" target="_blank"><img src="images/5.gif" alt="客户服务" width="81" height="91" border="0" /></a><a href="http://www.wsachina.com/newEbiz1/EbizPortalFG/portal/html/GeneralContentShow3.html" target="_blank"><img src="images/6.gif" alt="人才招聘" width="82" height="91" border="0" /></a><a href="http://www.wsachina.com/newEbiz1/EbizPortalFG/portal/html/EnterpriseMap.html" target="_blank"><img src="images/7.gif" 电子地图 width="82" height="91" border="0" /></a><a href="http://www.wsachina.com/newEbiz1/EbizPortalFG/portal/html/GeneralContentShow4.html?GeneralContentShow_DocID=c373e91834c39bfb8f7ab9fbcb3f3908" target="_blank"><img src="images/8.gif" alt="联系我们" width="82" height="91" border="0" /></a></td>
  </tr>
</table>
<table width="945" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><img src="images/9.jpg" width="945" height="202" /></td>
  </tr>
</table>
<table width="945" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><img src="images/10.jpg" width="945" height="46" /></td>
  </tr>
</table>
<table width="945" border="0" align="center" cellpadding="0" cellspacing="0" background="images/11.jpg">
  <tr>
    <td width="273" valign="top"><table width="236" border="0" align="right" cellpadding="0" cellspacing="0">
      <tr>
        <td><img src="images/13.gif" width="236" height="18" /></td>
      </tr>
      <tr>
        <td background="images/14.gif">
          <table width="211" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td><img src="images/bar_1.gif" width="211" height="30" /></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td class="blue">
              联系人：岳文杰/柴晨<br/>
              电 话：021-63097903<br />
                传 真：021-63093711/6980<br />
                手 机：13761090727/13818008212<br />
                Email：link.yue.sha@wsachina.com<br />
                地 址：上海市吴淞路469号森林湾大厦C座602<br />
                <br />
                <strong>宁波分公司：</strong><br />
                联系人：赵江凌<br />
                电 话：0574-87973985<br />
                手 机：15988603118<br />
                Email：vincent.zhao.nbo@wsachina.com </td>
            </tr>
            <tr>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td><img src="images/bar_2.gif" width="211" height="30" /></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td class="blue"><asp:Repeater ID="Repeater1" runat="server"><ItemTemplate><a href="/lcl/<%#setkey(Eval("yunjiaid").ToString()) %>_<%#Eval("Destport").ToString() %>.html"><%#Eval("Destport").ToString() %></a>　</ItemTemplate></asp:Repeater></td>
            </tr>
          </table>
</td>
      </tr>
      <tr>
        <td><img src="images/15.gif" width="236" height="17" /></td>
      </tr>
    </table></td>
    <td width="27"></td>
    <td width="645" align="left" valign="top"><table width="610" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td><img src="images/16.gif" width="610" height="18" /></td>
      </tr>
      <tr>
        <td valign="top" background="images/17.gif"><table width="570" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td><table width="570" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="19"><img src="images/ico_1.gif" width="15" height="15" /></td>
                <td width="209" class="blue"><strong>上海伟胜贤国际货运代理有限公司</strong></td>
                <td width="342"><img src="images/ico_2.gif" width="342" height="14" /></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td class="blue">上海伟胜贤国际货运代理有限公司系隶属于以香港伟成船务（国际）有限公司为母体的伟成集团网络的
中国地区联络总部。始建于1991年7月1日，为首批境外知名货运企业在中国大陆投资的成功实践。总公
司香港伟成船务（国际）有限公司创立于1983年7月1日， 至今二十四年历史，在海外设立了近五十家伟
成系统成员公司，并建立了超过400家覆盖全球的代理网络。以突出优势立足东南亚市场。 <br />
<br />
集团内香港总公司， 区域总部新加坡，财务总部加拿大以及下属马来西亚，印度，斯里兰卡，意大利等地伟成公司
均为当地货运界龙头，在货运界享有极高声誉。集团网络始终贯彻ISO质量体系精神，充分孕育和提炼伟
成企业文化。上海伟胜贤国际货运代理有限公司自成立以来，秉承专业精神，应运急速变化的市场需要，先后于1997年和
2002年实现两次重大改组，目前已取得国家交通部认可的无船承运业务资格（MOC-NV02682），依托雄厚的海外背景，全方位为客户提供：海运出口方面的定舱，租船，中转，仓储，装箱，拼箱， 运输，报关，报检，缮制单证及相关咨询；海运进口方面的国外联运，目的港换单，报检，报关，码头（仓库）提货，   拆箱，分拨，仓储，中转，配送，包装，保险，报关及咨询；以及空运进出口，陆运，大宗散杂货及部分工程项目的策划实施。公司凭借一批出色资质的业务操作队伍和高级管理人员，在先进的咨讯科技支持下，通过网络的经营管理，充分调集信息流动，从而确保物流方案得以最为准确，协调和高效的实现；为海内外客户提供全球连锁，专业标准和安全节省的全程物流服务。<br /></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
          </tr>
		  <tr>
            <td><table width="570" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="19"><img src="images/ico_1.gif" width="15" height="15" /></td>
                <td width="209" class="blue"><strong>优势拼箱运价-上海</strong></td>
                <td width="342" align="right"><a href="/company/V25pdkNKS2d3OHNzcTd2ajVlY2JsZz09/" target="_blank"><img src="images/bt.gif" width="78" height="23" border="0" /></a></td>
              </tr>
            </table></td>
          </tr>
		  <tr>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td><table width="100%" cellpadding="0" cellspacing="1" bgcolor="#BFD3DE" class="yj">
              <tr>
                <td colspan="7" bgcolor="#B5E4F7"><strong></strong><strong>近洋线</strong></td>
                </tr>
              
			  <tr>
                <td width="22%" rowspan="2" bgcolor="#D6F0FA"><strong>港口</strong></td>
                <td colspan="2" bgcolor="#D6F0FA"><strong>US$/</strong></td>
                <td width="15%" rowspan="2" bgcolor="#D6F0FA"><strong>船期</strong></td>
                <td width="35%" rowspan="2" bgcolor="#D6F0FA"><strong>船公司</strong></td>
                <td width="6%" rowspan="2" bgcolor="#D6F0FA"><strong>VIA</strong></td>
                <td width="6%" rowspan="2" bgcolor="#D6F0FA"><strong>T/T DAYS</strong></td>
              </tr>
              <tr>
                <td width="8%" bgcolor="#D6F0FA"><strong>CBM</strong></td>
                <td width="8%" bgcolor="#D6F0FA"><strong>TON</strong></td>
              </tr>
              <tr>
                <td bgcolor="#FFFFFF">SINGAPORE(直客)</td>
                <td bgcolor="#FFFFFF">(85)</td>
                <td bgcolor="#FFFFFF">(80)</td>
                <td bgcolor="#FFFFFF">三/六</td>
                <td bgcolor="#FFFFFF">YML/SPEEDA(RCL)</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">7</td>
              </tr>
              <tr>
                <td bgcolor="#F2FAFD">SINGAPORE(同行)</td>
                <td bgcolor="#F2FAFD">(78)</td>
                <td bgcolor="#F2FAFD">(73)</td>
                <td bgcolor="#F2FAFD">三/六</td>
                <td bgcolor="#F2FAFD">YML/SPEEDA(RCL)</td>
                <td bgcolor="#F2FAFD">-</td>
                <td bgcolor="#F2FAFD">7</td>
              </tr>
              <tr>
                <td bgcolor="#FFFFFF">PENANG</td>
                <td bgcolor="#FFFFFF">3</td>
                <td bgcolor="#FFFFFF">8</td>
                <td bgcolor="#FFFFFF">六</td>
                <td bgcolor="#FFFFFF">KMTC</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">14</td>
              </tr>
              <tr>
                <td bgcolor="#F2FAFD">PORT KELANG</td>
                <td bgcolor="#F2FAFD">（2）</td>
                <td bgcolor="#F2FAFD">3</td>
                <td bgcolor="#F2FAFD">二／四／六</td>
                <td bgcolor="#F2FAFD">WANHAI(北港)/YML(西港)/KMTC(北港)</td>
                <td bgcolor="#F2FAFD">-</td>
                <td bgcolor="#F2FAFD">8</td>
              </tr>
              <tr>
                <td bgcolor="#FFFFFF">JAKARTA</td>
                <td bgcolor="#FFFFFF">(130)</td>
                <td bgcolor="#FFFFFF">(125)</td>
                <td bgcolor="#FFFFFF">三/六</td>
                <td bgcolor="#FFFFFF">KMTC/TS</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">12</td>
              </tr>
              <tr>
                <td bgcolor="#F2FAFD">MANILA</td>
                <td bgcolor="#F2FAFD">(60)</td>
                <td bgcolor="#F2FAFD">(55)</td>
                <td bgcolor="#F2FAFD">六</td>
                <td bgcolor="#F2FAFD">SITC</td>
                <td bgcolor="#F2FAFD">-</td>
                <td bgcolor="#F2FAFD">6</td>
              </tr>
              <tr>
                <td bgcolor="#FFFFFF">BANGKOK</td>
                <td bgcolor="#FFFFFF">(15)</td>
                <td bgcolor="#FFFFFF">(10)</td>
                <td bgcolor="#FFFFFF">四/日</td>
                <td bgcolor="#FFFFFF">MOL/KLINE</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">7</td>
              </tr>
              <tr>
                <td bgcolor="#F2FAFD">HO CHI MING</td>
                <td bgcolor="#F2FAFD">2</td>
                <td bgcolor="#F2FAFD">7</td>
                <td bgcolor="#F2FAFD">四/日</td>
                <td bgcolor="#F2FAFD">SITC/YML</td>
                <td bgcolor="#F2FAFD">-</td>
                <td bgcolor="#F2FAFD">7</td>
              </tr>
              <tr>
                <td bgcolor="#FFFFFF">HAIPHONG</td>
                <td bgcolor="#FFFFFF">9</td>
                <td bgcolor="#FFFFFF">14</td>
                <td bgcolor="#FFFFFF">一/三/四/五</td>
                <td bgcolor="#FFFFFF">外运/SITC/KMTC/YML(PAN OCEAN)</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">5</td>
              </tr>
              <tr>
                <td bgcolor="#F2FAFD">HANOI</td>
                <td bgcolor="#F2FAFD">28</td>
                <td bgcolor="#F2FAFD">33</td>
                <td bgcolor="#F2FAFD">三/六</td>
                <td bgcolor="#F2FAFD">SITC/YML(PAN OCEAN)</td>
                <td bgcolor="#F2FAFD">HAI</td>
                <td bgcolor="#F2FAFD">15</td>
              </tr>
              <tr>
                <td bgcolor="#FFFFFF">PASIR GUDANG</td>
                <td bgcolor="#FFFFFF">15</td>
                <td bgcolor="#FFFFFF">20</td>
                <td bgcolor="#FFFFFF">三/六</td>
                <td bgcolor="#FFFFFF">YML/SPEEDA（KMTC直达9天）</td>
                <td bgcolor="#FFFFFF">SGP</td>
                <td bgcolor="#FFFFFF">15</td>
              </tr>
              <tr>
                <td bgcolor="#F2FAFD">SEMARANG</td>
                <td bgcolor="#F2FAFD">16</td>
                <td bgcolor="#F2FAFD">21</td>
                <td bgcolor="#F2FAFD">三/六</td>
                <td bgcolor="#F2FAFD">YML/SPEEDA(RCL)</td>
                <td bgcolor="#F2FAFD">SGP</td>
                <td bgcolor="#F2FAFD">20</td>
              </tr>
              <tr>
                <td bgcolor="#FFFFFF">BELAWAN</td>
                <td bgcolor="#FFFFFF">20</td>
                <td bgcolor="#FFFFFF">25</td>
                <td bgcolor="#FFFFFF">三/六</td>
                <td bgcolor="#FFFFFF">YML/SPEEDA(RCL)</td>
                <td bgcolor="#FFFFFF">SGP</td>
                <td bgcolor="#FFFFFF">25</td>
              </tr>
              <tr>
                <td bgcolor="#F2FAFD">SURABAYA</td>
                <td bgcolor="#F2FAFD">(10)</td>
                <td bgcolor="#F2FAFD">(5)</td>
                <td bgcolor="#F2FAFD">六</td>
                <td bgcolor="#F2FAFD">CNC（YML）</td>
                <td bgcolor="#F2FAFD">-</td>
                <td bgcolor="#F2FAFD">13</td>
              </tr>
              <tr>
                <td bgcolor="#FFFFFF">LAEM CHABANG</td>
                <td bgcolor="#FFFFFF">8</td>
                <td bgcolor="#FFFFFF">13</td>
                <td bgcolor="#FFFFFF">四/日</td>
                <td bgcolor="#FFFFFF">RCL/KLINE</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">8</td>
              </tr>
              <tr>
                <td bgcolor="#F2FAFD">CEBU</td>
                <td bgcolor="#F2FAFD">25</td>
                <td bgcolor="#F2FAFD">30</td>
                <td bgcolor="#F2FAFD">三/六</td>
                <td bgcolor="#F2FAFD">YML/SPEEDA(RCL)</td>
                <td bgcolor="#F2FAFD">SGP</td>
                <td bgcolor="#F2FAFD">20</td>
              </tr>
              <tr>
                <td bgcolor="#FFFFFF">PORT LOUIS</td>
                <td bgcolor="#FFFFFF">55</td>
                <td bgcolor="#FFFFFF">60</td>
                <td bgcolor="#FFFFFF">一/三/六</td>
                <td bgcolor="#FFFFFF">HL/YML/SPEEDA(KMTC)</td>
                <td bgcolor="#FFFFFF">SGP</td>
                <td bgcolor="#FFFFFF">35</td>
              </tr>
              <tr>
                <td bgcolor="#F2FAFD">PORT LOUIS(直拼)</td>
                <td bgcolor="#F2FAFD">50</td>
                <td bgcolor="#F2FAFD">55</td>
                <td bgcolor="#F2FAFD">四/日</td>
                <td bgcolor="#F2FAFD">MSK/PIL</td>
                <td bgcolor="#F2FAFD">-</td>
                <td bgcolor="#F2FAFD">28</td>
              </tr>
              <tr>
                <td bgcolor="#FFFFFF">YANGON</td>
                <td bgcolor="#FFFFFF">45</td>
                <td bgcolor="#FFFFFF">50</td>
                <td bgcolor="#FFFFFF">三/六</td>
                <td bgcolor="#FFFFFF">YML/SPEEDA(RCL)</td>
                <td bgcolor="#FFFFFF">SGP</td>
                <td bgcolor="#FFFFFF">25</td>
              </tr>
              <tr>
                <td bgcolor="#F2FAFD">PHNOMPENH</td>
                <td bgcolor="#F2FAFD">50</td>
                <td bgcolor="#F2FAFD">55</td>
                <td bgcolor="#F2FAFD">三/六</td>
                <td bgcolor="#F2FAFD">YML/SPEEDA(RCL)</td>
                <td bgcolor="#F2FAFD">SGP</td>
                <td bgcolor="#F2FAFD">35</td>
              </tr>
              <tr>
                <td bgcolor="#FFFFFF">SIBU</td>
                <td bgcolor="#FFFFFF">50</td>
                <td bgcolor="#FFFFFF">55</td>
                <td bgcolor="#FFFFFF">三/六</td>
                <td bgcolor="#FFFFFF">YML/SPEEDA(RCL)</td>
                <td bgcolor="#FFFFFF">SGP</td>
                <td bgcolor="#FFFFFF">25</td>
              </tr>
              <tr>
                <td bgcolor="#F2FAFD">KUCHING</td>
                <td bgcolor="#F2FAFD">43</td>
                <td bgcolor="#F2FAFD">48</td>
                <td bgcolor="#F2FAFD">三/六</td>
                <td bgcolor="#F2FAFD">YML/SPEEDA(RCL)</td>
                <td bgcolor="#F2FAFD">SGP</td>
                <td bgcolor="#F2FAFD">25</td>
              </tr>
              <tr>
                <td bgcolor="#FFFFFF">MUARA</td>
                <td bgcolor="#FFFFFF">35</td>
                <td bgcolor="#FFFFFF">40</td>
                <td bgcolor="#FFFFFF">三/六</td>
                <td bgcolor="#FFFFFF">YML/SPEEDA(RCL)</td>
                <td bgcolor="#FFFFFF">SGP</td>
                <td bgcolor="#FFFFFF">30</td>
              </tr>
            </table></td>
          </tr>
		  <tr>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td><table width="100%" cellpadding="0" cellspacing="1" bgcolor="#BFD3DE" class="yj">
              <tr>
                <td colspan="7" bgcolor="#B5E4F7"><strong></strong><strong>中东印巴线</strong></td>
                </tr>
              
			  <tr>
                <td width="22%" rowspan="2" bgcolor="#D6F0FA"><strong>港口</strong></td>
                <td colspan="2" bgcolor="#D6F0FA"><strong>US$/</strong></td>
                <td width="15%" rowspan="2" bgcolor="#D6F0FA"><strong>船期</strong></td>
                <td width="27%" rowspan="2" bgcolor="#D6F0FA"><strong>船公司</strong></td>
                <td width="10%" rowspan="2" bgcolor="#D6F0FA"><strong>VIA</strong></td>
                <td width="10%" rowspan="2" bgcolor="#D6F0FA"><strong>T/T DAYS</strong></td>
              </tr>
              <tr>
                <td width="8%" bgcolor="#D6F0FA"><strong>CBM</strong></td>
                <td width="8%" bgcolor="#D6F0FA"><strong>TON</strong></td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">KARACHI</td>
                <td bgcolor="#FFFFFF">(7)</td>
                <td bgcolor="#FFFFFF">（2）</td>
                <td bgcolor="#FFFFFF">三/四</td>
                <td bgcolor="#FFFFFF">HANJIN/YML</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">16-20</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">COLOMBO</td>
                <td bgcolor="#F2FAFD">25</td>
                <td bgcolor="#F2FAFD">30</td>
                <td bgcolor="#F2FAFD">一</td>
                <td bgcolor="#F2FAFD">APL(洋山)</td>
                <td bgcolor="#F2FAFD">-</td>
                <td bgcolor="#F2FAFD">12</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">CHITTAGONG</td>
                <td bgcolor="#FFFFFF">55</td>
                <td bgcolor="#FFFFFF">60</td>
                <td bgcolor="#FFFFFF">三/六</td>
                <td bgcolor="#FFFFFF">APL/MSK</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">15-20</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">BOMBAY/MUMBAI</td>
                <td bgcolor="#F2FAFD">15</td>
                <td bgcolor="#F2FAFD">20</td>
                <td bgcolor="#F2FAFD">六</td>
                <td bgcolor="#F2FAFD">RCL(KMTC)</td>
                <td bgcolor="#F2FAFD">-</td>
                <td bgcolor="#F2FAFD">22</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">NHAVA    SHEVA/JNPT</td>
                <td bgcolor="#FFFFFF">（10）</td>
                <td bgcolor="#FFFFFF">电议</td>
                <td bgcolor="#FFFFFF">四/六</td>
                <td bgcolor="#FFFFFF">OOCL/WH(TS-LINE)</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">14-16</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">NEW DELHI</td>
                <td bgcolor="#F2FAFD">33</td>
                <td bgcolor="#F2FAFD">38</td>
                <td bgcolor="#F2FAFD">六/一</td>
                <td bgcolor="#F2FAFD">HMM/SCI</td>
                <td bgcolor="#F2FAFD">-</td>
                <td bgcolor="#F2FAFD">26-30</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">MADRAS/CHENNAI</td>
                <td bgcolor="#FFFFFF">（2）</td>
                <td bgcolor="#FFFFFF">3</td>
                <td bgcolor="#FFFFFF">一/三</td>
                <td bgcolor="#FFFFFF">OOCL/APL(WHL)</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">12-15</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">CALCUTTA</td>
                <td bgcolor="#F2FAFD">40</td>
                <td bgcolor="#F2FAFD">45</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">APL/YML/KMTC</td>
                <td bgcolor="#F2FAFD">SIN或COLOMBO</td>
                <td bgcolor="#F2FAFD">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">BANGALORE</td>
                <td bgcolor="#FFFFFF">28</td>
                <td bgcolor="#FFFFFF">33</td>
                <td bgcolor="#FFFFFF">一/四</td>
                <td bgcolor="#FFFFFF">OOCL/APL</td>
                <td bgcolor="#FFFFFF">CHEN</td>
                <td bgcolor="#FFFFFF">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">DHAKA</td>
                <td bgcolor="#F2FAFD">76</td>
                <td bgcolor="#F2FAFD">81</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">KLINE/APL/MSK</td>
                <td bgcolor="#F2FAFD">CHIT</td>
                <td bgcolor="#F2FAFD">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">LAHORE</td>
                <td bgcolor="#FFFFFF">85</td>
                <td bgcolor="#FFFFFF">90</td>
                <td bgcolor="#FFFFFF">三/四</td>
                <td bgcolor="#FFFFFF">HANJIN/YML</td>
                <td bgcolor="#FFFFFF">KAR</td>
                <td bgcolor="#FFFFFF">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">TUTICORIN</td>
                <td bgcolor="#F2FAFD">35</td>
                <td bgcolor="#F2FAFD">40</td>
                <td bgcolor="#F2FAFD">三</td>
                <td bgcolor="#F2FAFD">APL</td>
                <td bgcolor="#F2FAFD">CHEN</td>
                <td bgcolor="#F2FAFD">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">HYDERABAD</td>
                <td bgcolor="#FFFFFF">41</td>
                <td bgcolor="#FFFFFF">46</td>
                <td bgcolor="#FFFFFF">一/三</td>
                <td bgcolor="#FFFFFF">OOCL/APL(WHL)</td>
                <td bgcolor="#FFFFFF">CHEN</td>
                <td bgcolor="#FFFFFF">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">COCHIN</td>
                <td bgcolor="#F2FAFD">35</td>
                <td bgcolor="#F2FAFD">40</td>
                <td bgcolor="#F2FAFD">二</td>
                <td bgcolor="#F2FAFD">APL(洋山)</td>
                <td bgcolor="#F2FAFD">CLB</td>
                <td bgcolor="#F2FAFD">22</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">MALE</td>
                <td bgcolor="#FFFFFF">113</td>
                <td bgcolor="#FFFFFF">118</td>
                <td bgcolor="#FFFFFF">二</td>
                <td bgcolor="#FFFFFF">APL(洋山)</td>
                <td bgcolor="#FFFFFF">CLB</td>
                <td bgcolor="#FFFFFF">22</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">DUBAI/JEBEL    ALI</td>
                <td bgcolor="#F2FAFD">(9)</td>
                <td bgcolor="#F2FAFD">(4)</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">EMI/CSCL/TS</td>
                <td bgcolor="#F2FAFD">-</td>
                <td bgcolor="#F2FAFD">16</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">DUBAI/JEBEL ALI</td>
                <td bgcolor="#FFFFFF">(25)</td>
                <td bgcolor="#FFFFFF">(20)</td>
                <td bgcolor="#FFFFFF">一/三/六</td>
                <td bgcolor="#FFFFFF">EMI/CSCL/TS</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">16</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">AQABA</td>
                <td bgcolor="#F2FAFD">35</td>
                <td bgcolor="#F2FAFD">40</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">EMI/CSCL/TS</td>
                <td bgcolor="#F2FAFD">DBI</td>
                <td bgcolor="#F2FAFD">45</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">AQABA(直拼)</td>
                <td bgcolor="#FFFFFF">28</td>
                <td bgcolor="#FFFFFF">33</td>
                <td bgcolor="#FFFFFF">四</td>
                <td bgcolor="#FFFFFF">YML(CSCL)</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">ADEN</td>
                <td bgcolor="#F2FAFD">80</td>
                <td bgcolor="#F2FAFD">85</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">EMI/CSCL/TS</td>
                <td bgcolor="#F2FAFD">DBI</td>
                <td bgcolor="#F2FAFD">45</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">ABU DHABI</td>
                <td bgcolor="#FFFFFF">35</td>
                <td bgcolor="#FFFFFF">40</td>
                <td bgcolor="#FFFFFF">一/三/六</td>
                <td bgcolor="#FFFFFF">EMI/CSCL/TS</td>
                <td bgcolor="#FFFFFF">DBI</td>
                <td bgcolor="#FFFFFF">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">BANDAR ABBAS</td>
                <td bgcolor="#F2FAFD">60</td>
                <td bgcolor="#F2FAFD">65</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">EMI/CSCL/TS</td>
                <td bgcolor="#F2FAFD">DBI</td>
                <td bgcolor="#F2FAFD">30</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">B.ABBAS(直拼)</td>
                <td bgcolor="#FFFFFF">48</td>
                <td bgcolor="#FFFFFF">53</td>
                <td bgcolor="#FFFFFF">二</td>
                <td bgcolor="#FFFFFF">ANL</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">22</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">BAHRAIN</td>
                <td bgcolor="#F2FAFD">35</td>
                <td bgcolor="#F2FAFD">40</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">EMI/CSCL/TS</td>
                <td bgcolor="#F2FAFD">DBI</td>
                <td bgcolor="#F2FAFD">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">DOHA</td>
                <td bgcolor="#FFFFFF">54</td>
                <td bgcolor="#FFFFFF">59</td>
                <td bgcolor="#FFFFFF">一/三/六</td>
                <td bgcolor="#FFFFFF">EMI/CSCL/TS</td>
                <td bgcolor="#FFFFFF">DBI</td>
                <td bgcolor="#FFFFFF">35</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">DAMMAN</td>
                <td bgcolor="#F2FAFD">30</td>
                <td bgcolor="#F2FAFD">35</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">EMI/CSCL/TS</td>
                <td bgcolor="#F2FAFD">DBI</td>
                <td bgcolor="#F2FAFD">30</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">DAMMAN(直拼)</td>
                <td bgcolor="#FFFFFF">13</td>
                <td bgcolor="#FFFFFF">18</td>
                <td bgcolor="#FFFFFF">四</td>
                <td bgcolor="#FFFFFF">CSCL</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">KUWAIT</td>
                <td bgcolor="#F2FAFD">30</td>
                <td bgcolor="#F2FAFD">37</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">EMI/CSCL/TS</td>
                <td bgcolor="#F2FAFD">DBI</td>
                <td bgcolor="#F2FAFD">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">KUWAIT(直拼)</td>
                <td bgcolor="#FFFFFF">18</td>
                <td bgcolor="#FFFFFF">23</td>
                <td bgcolor="#FFFFFF">四</td>
                <td bgcolor="#FFFFFF">CSCL</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">28</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">MUSCAT</td>
                <td bgcolor="#F2FAFD">46</td>
                <td bgcolor="#F2FAFD">51</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">EMI/CSCL/TS</td>
                <td bgcolor="#F2FAFD">DBI</td>
                <td bgcolor="#F2FAFD">30</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">PORT SUDAN</td>
                <td bgcolor="#FFFFFF">80</td>
                <td bgcolor="#FFFFFF">85</td>
                <td bgcolor="#FFFFFF">一/三/六</td>
                <td bgcolor="#FFFFFF">EMI/CSCL/TS</td>
                <td bgcolor="#FFFFFF">DBI</td>
                <td bgcolor="#FFFFFF">55</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">JEDDAH</td>
                <td bgcolor="#F2FAFD">80</td>
                <td bgcolor="#F2FAFD">85</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">EMI/CSCL/TS</td>
                <td bgcolor="#F2FAFD">DBI</td>
                <td bgcolor="#F2FAFD">30</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">JEDDAH(直拼)</td>
                <td bgcolor="#FFFFFF">32</td>
                <td bgcolor="#FFFFFF">37</td>
                <td bgcolor="#FFFFFF">四</td>
                <td bgcolor="#FFFFFF">HL</td>
                <td bgcolor="#FFFFFF">-</td>
                <td bgcolor="#FFFFFF">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">SHARJAH</td>
                <td bgcolor="#F2FAFD">38</td>
                <td bgcolor="#F2FAFD">43</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">EMI/CSCL/TS</td>
                <td bgcolor="#F2FAFD">DBI</td>
                <td bgcolor="#F2FAFD">25</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">HODEIDAH</td>
                <td bgcolor="#FFFFFF">76</td>
                <td bgcolor="#FFFFFF">81</td>
                <td bgcolor="#FFFFFF">一/三/六</td>
                <td bgcolor="#FFFFFF">EMI/CSCL/TS</td>
                <td bgcolor="#FFFFFF">DBI</td>
                <td bgcolor="#FFFFFF">35</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">MOMBASA</td>
                <td bgcolor="#F2FAFD">66</td>
                <td bgcolor="#F2FAFD">71</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">EMI/CSCL/TS</td>
                <td bgcolor="#F2FAFD">DBI</td>
                <td bgcolor="#F2FAFD">55</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">RIYADH</td>
                <td bgcolor="#FFFFFF">32</td>
                <td bgcolor="#FFFFFF">38</td>
                <td bgcolor="#FFFFFF">一/三/六</td>
                <td bgcolor="#FFFFFF">EMI/CSCL/TS</td>
                <td bgcolor="#FFFFFF">DBI</td>
                <td bgcolor="#FFFFFF">35</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">RIYADH(直拼)</td>
                <td bgcolor="#F2FAFD">23</td>
                <td bgcolor="#F2FAFD">28</td>
                <td bgcolor="#F2FAFD">四</td>
                <td bgcolor="#F2FAFD">CSCL</td>
                <td bgcolor="#F2FAFD">-</td>
                <td bgcolor="#F2FAFD">30</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#FFFFFF">DAR ES SALAM</td>
                <td bgcolor="#FFFFFF">105</td>
                <td bgcolor="#FFFFFF">110</td>
                <td bgcolor="#FFFFFF">一/三/六</td>
                <td bgcolor="#FFFFFF">EMI/CSCL/TS</td>
                <td bgcolor="#FFFFFF">DBI</td>
                <td bgcolor="#FFFFFF">35</td>
              </tr>
              <tr height="22">
                <td height="22" bgcolor="#F2FAFD">DJIBOUTI</td>
                <td bgcolor="#F2FAFD">80</td>
                <td bgcolor="#F2FAFD">85</td>
                <td bgcolor="#F2FAFD">一/三/六</td>
                <td bgcolor="#F2FAFD">EMI/CSCL/TS</td>
                <td bgcolor="#F2FAFD">DBI</td>
                <td bgcolor="#F2FAFD">25</td>
              </tr>
              
            </table></td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td valign="top" background="images/17.gif">&nbsp;</td>
      </tr>
      <tr>
        <td valign="top" background="images/17.gif"><div align="center"><a href="/company/V25pdkNKS2d3OHNzcTd2ajVlY2JsZz09/" target="_blank"><img src="images/bt.gif" width="78" height="23" border="0" /></a></div></td>
      </tr>
      <tr>
        <td valign="top" background="images/17.gif">&nbsp;</td>
      </tr>
      <tr>
        <td><img src="images/18.gif" width="610" height="17" /></td>
      </tr>
    </table></td>
  </tr>
</table>
<table width="945" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><img src="images/12.jpg" width="945" height="30" /></td>
  </tr>
</table>
<table width="945" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="8"></td>
    <td width="920" height="37" align="center" background="images/19.jpg" class="foot_text">《中华人民共和国电信与信息服务业务经营许可证》 编号:沪ICP备07510944号</td>
    <td width="6"></td>
  </tr>
</table>
<table width="945" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="8"></td>
    <td width="920" height="37" align="center" background="images/20.jpg"><img src="images/allin.jpg" width="162" /></td>
    <td width="6"></td>
  </tr>
</table>
</body>
</html>
