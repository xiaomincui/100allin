<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="waysglobal_index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="西非 非洲 东非 非洲内陆点 Cotonou Apapa Tincan Mombasa Waivis bay Lome 海运费" />
<meta name="description" content="上海伟仕物流有限公司提供上海至西非/非洲/东非/非洲内陆点/Cotonou/Apapa/Tincan/Mombasa/Waivis bay/Lome专业海运服务,欢迎前来咨询相关海运费" />
<title>上海伟仕物流有限公司 - 上海至非洲(西非,东非内陆点)海运费</title>
<script type="text/javascript" src="/js/home.js"></script>
<link href="/waysglobal/css/ways.css" rel="stylesheet" type="text/css" />
</head>

<body>
	<div class="main">
	<div id="mm" style="position:absolute; width:300px; background:#FFFFFF; left:10px;border:1px solid #999999; visibility:hidden; z-index:10;"></div>
<waysheader:waysheader ID="waysheader1" runat="server" />
		<div class="box">
			<div class="left">
			  <table width="228" border="0" cellpadding="0" cellspacing="0">
<waysleft:waysleft ID="waysleft1" runat="server" />					  
                <tr>
                  <td height="22" background="/waysglobal/images/14.gif">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>相关资质</strong></td>
                </tr>
                <tr style="word-break:break-all;">
                  <td>
                  <div class="yt">
                  营业执照：<img src='/images/shops/t_1.gif'><br />
                  NVOCC：<img src='/images/shops/t_2.gif'>
                  </div>
                      <%--<asp:Repeater ID="Repeater1" runat="server"><ItemTemplate><a href="/fcl/<%#setkey(Eval("yunjiaid").ToString()) %>_<%#Eval("Destport").ToString() %>.html"><%#Eval("Destport").ToString() %></a>　<br/></ItemTemplate></asp:Repeater>--%>
                      
                  </td>
                </tr>
              </table>
			</div>
			<div class="right">
				<table width="703" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="21" bgcolor="#999999"></td>
  </tr>
  <tr>
    <td height="15"></td>
  </tr>
   <tr>
    <td height="32" style="font-size:16px;"><strong>上海伟仕物流有限公司</strong></td>
  </tr>
   <tr>
    <td height="15"></td>
  </tr>  <tr>
    <td height="22" style="color:#FF6600; font-size:13px;"><img src="/waysglobal/images/15.gif" width="4" height="7" />&nbsp;<strong>企业简介</strong></td>
  </tr>
  <tr>
    <td><p>伟仕物流有限公司是一家提供专业化物流航线平台服务的货运代理企业,  全球运营总部设于国际航运中心 ---上海。公司主营业务涵盖非洲，中东，印巴，红海及东南亚航线。尤其是非洲航线业务代理上在中国保持有绝对的行业领先地位。 伟仕物流在中国各大口岸如大连， 天津，青岛，上海，扬州， 宁波， 福州，厦门，广州，深圳 都已设有全资分公司。 配合总公司自行研发的先进的网上系统，为客户提供了更加便捷的服务,企业内部也从而实现了更有效的科学化管理。 多年的经营成果和公司始终领先市场的航线经营理念获得了所有国际著名航运公司的高度认可，并且多次荣获物流行业的奖项。<br/>
目前公司在非洲航线上的主营合作伙伴包括 : MAERSK, SAFMARINE, CMA-CGM, DELMAS, PIL, NYK, KLINE, EMC, EMI, ZIM等，并均与之签有一系列的优质运价。<br/>
公司拥有覆盖全球的代理网络，尤其是在非洲这一刚刚起步的新兴市场中，伟仕物流已经可以承接几乎所有覆盖非洲内陆点的DDU，DDP等目的港一站式服务，为中国的货物安全送达非洲大陆提供了无法替代的保证 ！<br/>
企业的愿景 -- 立足中国, 百年航商<br/>
公司的使命 -- 为往来中国的中小贸易商，合作伙伴，提供与全球航运公司对接的更加方便快捷及规模化的操作平台。<br/>
</p></td>
  </tr>


  <tr style="display:;">
    <td height="22" style="color:#FF6600; font-size:13px;"><img src="/waysglobal/images/15.gif" width="4" height="7" />&nbsp;<strong>热点运价</strong></td>
  </tr>
  <tr style="display:;">
    <td >
    <table width="100%" cellpadding="3" cellspacing="0" class="STYLE2">
      <tr bgcolor="#CCCCCC">
        <td width="26%" height="31">标题</td>
        <td width="17%">起运港</td>
        <td width="10%">航线</td>
        <td width="17%">目的港</td>
        <td width="5%">20GP</td>
        <td width="5%">40GP</td>
        <td width="5%">40HQ</td>
        <td width="5%">45HQ</td>
        <td width="10%">船公司</td>
      </tr>
<asp:Repeater ID="Rptfcl" runat="server" OnPreRender="Rptfcl_ItemDataBound">
<ItemTemplate>
<tr onmouseover="tt('<%#Rptfcl.Items.Count %>',1)" onmouseout="hidden()">
<td width="26%" height="31"><asp:Literal ID="Literal1" runat="server" Text='<%# Eval("id")%>' Visible="false"></asp:Literal><asp:Literal ID="Literal2" runat="server" Text='<%# Eval("userid")%>' Visible="false"></asp:Literal><a href="/fcl/<%#setkey(Eval("id").ToString()) %>_0.html" target="_blank" style="color:#666666;"><%#Eval("title").ToString() %></a></td>
<td width="17%"><%#Eval("Startport").ToString()%></td>
<td width="10%"><%#Eval("hangxianmiaoshu").ToString() %></td>
<td width="17%"><%#Eval("destport1").ToString() %></td>
<td width="5%"><%#Eval("price20gp1").ToString()%></td>
<td width="5%"><%#Eval("price40gp1").ToString()%></td>
<td width="5%"><%#Eval("price40hq1").ToString()%></td>
<td width="5%"><%#Eval("price45hq1").ToString() %></td>
<td width="10%"><%#Eval("shipcompany1").ToString() %></td>
</tr>
</ItemTemplate>
</asp:Repeater>

    </table></td>
  </tr>
  <tr>
    <td height="22" >&nbsp;</td>
  </tr>
</table>
		
			</div>
		</div>
<waysfooter:waysfooter ID="waysfooter1" runat="server" />		
	</div>
	<input id="Hidden1" runat="server" style="width: 1px" type="hidden" />
<input id="Hiddennn1" runat="server" style="width: 1px" type="hidden" />
</body>
</html>
