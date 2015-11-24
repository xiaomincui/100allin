<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="member_index" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>我的办公室</title>
<link href="css/offices.css" rel="stylesheet" type="text/css" />
<link href="/css/style.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.main_box{
}

.main_box h2{
	font:14px "宋体";
	line-height:24px;
	margin:0px;
	font-weight:normal;
	padding:0 0 20px 0;
	border-bottom:1px dashed #C5D8DE;
}

.main_box p{
	margin:0px;
	padding:15px 0 0 0;
}
.ui-tabs-nav
{
    /*导航容器定义*/
}
.ui-tabs-nav li
{
    /*默认标签样式*/
}
.ui-tabs-nav li.ui-tabs-selected
{
    /*激活的标签样式*/
}
.ui-tabs-panel
{
    /*默认的显示区域样式*/
}
.ui-tabs-hide
{
    display: none;
}
</style>
<link href="/member/css/dialog.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/member/js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="/member/js/dialog.js"></script>
<script type="text/javascript">
$(function(){

$("#bt2").click(function(){
  dialog("我的标题","text:我的内容","200px","auto","text");
});

$("#bt3").click(function(){
  dialog("我的标题","id:testID","600px","auto","id");
});

$("#bt4").click(function(){
  alert("我的标题");
});
  
});

$(function(){
      $(".ui-tabs-nav > li > a").mouseover(function(e){
          if(this == e.target){
            var container = $(this).parent().parent().parent();
            var arrNav = $(this).parent().parent().find("li");
            var index = $.inArray(this, $(this).parent().parent().find("a"));
            var panels = $(this).parent().parent().parent().parent().find(".ui-tabs-panel");
            if (panels.eq(index).is(".ui-tabs-panel")){
              arrNav.removeClass("hover").eq(index).addClass("hover");
              panels.addClass("ui-tabs-hide").eq(index).removeClass("ui-tabs-hide");
            }
            var panels2 = $(this).parent().parent().parent().find(".ui-tabs-panel2");
            if (panels2.eq(index).is(".ui-tabs-panel2")){
              arrNav.removeClass("hover").eq(index).addClass("hover");
              panels2.addClass("ui-tabs-hide").eq(index).removeClass("ui-tabs-hide");
            }            
          }
      });//tab切换
    });//jquery的onready
</script>
</head>
<body>
<form id="form1" runat="server">
<div class="main_container">
<memberheader:memberheader ID="memberheader1" runat="server" />
<div class="center">
<memberleft:memberleft ID="memberleft1" runat="server" />		
<div class="center_box">
<div class="user">
<div class="uesr_pic">
<a href="/member/useredit3.aspx"><img src="/member/head/<asp:Literal ID="ltrHead" runat="server"></asp:Literal>.jpg" border="0" width="120" height="120" /></a><br/>
<a href="/member/useredit3.aspx">基本信息</a>&nbsp;&nbsp;<a href="/member/useredit2.aspx">个人资料</a>
</div>
<div class="uesr_text" style="line-height:25px;">
<span class="orange"><strong><asp:Literal ID="ltrMyName" runat="server"></asp:Literal>，您好！</strong></span><br/>
您的客服专员<a title="欢迎使用在线客服" href="#" onclick="document.getElementById('aliserv').click();">晓萍</a>随时为您服务！<br/>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
您可以在此 <a href="/member/pm.aspx">管理消息</a><br/>
发布 <a href="/member/Release.aspx">整箱运价</a>、<a href="/member/SpellRelease.aspx">拼箱运价</a>、<a href="/member/AirRelease.aspx">空运运价</a><br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/member/ReleaseCargo.aspx">紧急询价</a>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
    <div style="border:1px solid #ff6000; padding:5px; font-size:12px;display:none;">传真公司营业执照和业务资质（海运:NVOCC和一代证照;空运:一代铜牌资质)至021-63509508，您将享受更多服务</div>
    </asp:PlaceHolder>
</div>
<div class="uesr_text" style="display:none;">
<textarea id="TextArea1" cols="20" rows="3" style="width:350px; overflow:auto; border-color:#7C7C7C #C3C3C3 #DDDDDD;border-style:solid;border-width:1px;">记录你的心情</textarea>
    <div style="margin-top:10px;"><input id="Button1" type="button" value="发送" /></div>
</div>
</div>
<div class="info">
<p><table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF">
<tr>
<td width="27%" height="22" align="left"><strong>公司资料完整度</strong>：</td>
<td width="40%" height="22" align="left"><em style="width:200px;" class="tpbg"><asp:Literal ID="ltrPercentLength" runat="server"><img src="images/tt.gif" width="0" height="10" /></asp:Literal></em></td>
<td width="33%" height="22" align="left">&nbsp;&nbsp;<strong class="gray"><asp:Literal ID="ltrPercent" runat="server">0</asp:Literal>%</strong> 
<img src="images/ico8.gif" /><a href="/member/useredit2.aspx"><strong>立即完整</strong></a> 
    <asp:Literal ID="ltrPreviewCompany" runat="server"></asp:Literal></td>
</tr>
<tr>
<td height="22" colspan="3"><span class="gray" style="font-size:12px;">请完善资料，只有完整度达到80%时，才能优先得到客户询盘!</span>      </td>
</tr>
</table></p>
</div>
    <asp:PlaceHolder ID="PlaceHolder3" runat="server">
<div class="news" style="display:none;">
<h1><img src="images/jt2.gif" /><strong>&nbsp;信息提示</strong></h1>
<table width="100%" border="0" cellspacing="1" cellpadding="0">
<tr>
<td width="20%" height="28" align="left" style="padding:0 12px 0 24px; line-height:24px; color:#FF6600;"><asp:Literal ID="Literal0" runat="server"></asp:Literal>：在11月1日-12月30日期间，如果您购买环球运费网<asp:Literal
        ID="Literal1" runat="server"></asp:Literal>的航线推广服务，可享受原价的五折优惠! 仅售<asp:Literal ID="Literal2"
            runat="server"></asp:Literal>元！限售二家，先到先得，售完即止！<br/>详情了解：<asp:Literal ID="Literal3" runat="server"></asp:Literal>&nbsp;&nbsp;<img src="images/news2.gif" width="28" height="11" /></td>
</tr>
</table>
</div>
	</asp:PlaceHolder>		
<div class="news">
<h1><img src="images/jt2.gif" /><strong>&nbsp;您在环球运费网的动态</strong></h1>
<table width="100%" border="0" cellspacing="1" cellpadding="0">
<tr>
<td width="5%" height="28"></td>
<td width="18%" >·新站内留言：</td>
<td width="32%" ><img src="images/ico9.gif" width="16" height="16" /> <a style="color:#FF0000;" href="/member/pm.aspx"><asp:Literal ID="ltrNewMessage" runat="server">0</asp:Literal></a></td>
<td width="20%" style="display:none;">·待处理订舱单：</td>
<td style="display:none;"><img src="images/ico10.gif" width="16" height="16" /> <a style="color:#FF0000;" href="/member/order/list.aspx?f1=1&f2=0"><asp:Literal ID="ltrNewBooking" runat="server">0</asp:Literal></a></td>

</tr>
<!--<tr style="display:none">
<td width="5%" height="28"></td>
<td width="18%">·预存订舱费：</td>
<td  colspan=3 ><a style="color:#FF0000;" href="/member/order/bill.aspx"><asp:Literal ID="ltrOverage" runat="server"></asp:Literal></a> (余额/预存) 元。
<asp:Literal ID="ltrOverageTips" runat="server"></asp:Literal></td>
</tr>-->

<tr style="display:none;">
<td height="28" colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;今天<a href="#"><asp:Literal ID="ltrMyPort" runat="server"></asp:Literal></a>港发布了<a href="#"><asp:Literal ID="ltrNewFreight" runat="server"></asp:Literal></a>条新运价  <a href="#">马上去看看</a></td>
</tr>
</table>

</div>
<div class="dynamic">
<DIV id=tabs1>

<DIV class=menu1box>
	<UL id=menu1 class="ui-tabs-nav">
	  <LI class=hover  style="border-left:none;"><A href="/member/feed/friend.aspx" target="_blank"><strong>商友动态</strong></A></LI>
	  <LI><A href="/member/feed/me.aspx" target="_blank"><strong>我的动态</strong></A></LI>
	  <LI style="display:none;"><A href="/home/space.php?do=home" target="_blank"><strong>社区动态</strong></A></LI>
    </UL>
<a href="/member/feed/friend.aspx" class="menumore ui-tabs-panel2" target="_blank">更多商友动态</a>
<a href="/member/feed/me.aspx" class="menumore ui-tabs-panel2 ui-tabs-hide" target="_blank">更多我的动态</a>
<a href="/home/space.php?do=home" class="menumore ui-tabs-panel2 ui-tabs-hide" target="_blank">更多社区动态</a>
</DIV>

<div class="ui-tabs-panel main1box">
<ul>
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
<li>
<table width="100%" border="0" cellspacing="1" cellpadding="0">
<tr>
<td width="18%" rowspan="3" align="center"><table width="1" border="0" cellspacing="1" cellpadding="0">
<tr>
<td><a href="/company/<%#setkey(Eval("userid").ToString()) %>/" target="_blank"><img src="/member/Head/<%#Eval("HeadURL").ToString() == "False"? "default": Eval("userid").ToString() %>.jpg" border="0" width="54" height="54" /></a></td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
</table><a href="#"></a></td>
<td height="24"  style="line-height:25px;"><%#Eval("TXT").ToString().Replace("{1}", setkey(Eval("id").ToString())).Replace("{2}", setkey(Eval("userid").ToString()))%></td>
<td align="right" width="18%"><%#Eval("POSTDATE").ToString()%><br/>
</td>
<td width="2%" align="right">&nbsp;</td>
</tr>
</table>
</li>
</ItemTemplate>
</asp:Repeater>
</ul>
</div>		  	
<div class="ui-tabs-panel ui-tabs-hide main1box">
<ul>
<asp:Repeater ID="Repeater2" runat="server">
<ItemTemplate>
<li>
<table width="100%" border="0" cellspacing="1" cellpadding="0">
<tr>
<td width="18%" rowspan="3" align="center"><table width="1" border="0" cellspacing="1" cellpadding="0">
<tr>
<td><a href="/company/<%#setkey(Eval("userid").ToString()) %>/" target="_blank"><img src="/member/Head/<%#Eval("HeadURL").ToString() == "False"? "default": Eval("userid").ToString() %>.jpg" border="0" width="54" height="54" /></a></td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
</table><a href="#"></a></td>
<td height="24" style="line-height:25px;"><%#Eval("TXT").ToString().Replace("{1}", setkey(Eval("id").ToString())).Replace("{2}", setkey(Eval("userid").ToString()))%></td>
<td align="right" width="18%"><%#Eval("POSTDATE").ToString()%><br/>

</td>
<td width="2%" align="right">&nbsp;</td>
</tr>
</table>
</li>
</ItemTemplate>
</asp:Repeater>
</ul>
</div>
<div class="ui-tabs-panel ui-tabs-hide main1box">
<div style="margin-left:20px;margin-right:20px;"><script language="javascript" type="text/javascript" src="http://www.100allin.com/home/js.php?id=3"></script></div>

</div>    					  	
</DIV>
</div>
</div>
<%--<memberright:memberright ID="memberright1" runat="server" />	--%>

</div>
<memberfooter:memberfooter ID="memberfooter1" runat="server" />
</div>

<div id="testID" style="display:none;" >
<div class="main_box">
<h2><span class="orange">Naturedeng</span>,恭喜您成为普通会员,您的公司类型为<span class="blue">“货代”</span>，我们为您提供了<span class="blue">“商铺”</span>来助您成交。为了您能得到海量询盘，建议您花一分钟补充商铺信息，每项奖励积分5分:
<input style="font:13px '宋体'; line-height:18px;" type="submit" name="Submit" value="返回修改公司类型" />
</h2>
<P><table width="100%" border="0" cellspacing="1" cellpadding="0">
<tr>
<td height="28" align="left"><strong>公司照片</strong>：</td>
<td height="28" align="left">
<asp:FileUpload ID="FileUpload1" runat="server"  onpropertychange="selectIMG(this)" /></td>
<td height="28" align="left">
</td>
</tr>


<tr>
<td height="28" align="left"><strong>个人头像</strong>：</td>
<td height="28" align="left">
<asp:FileUpload ID="FileUpload2" runat="server"  onpropertychange="selectIMG(this)" /></td>
<td height="28" align="left">
</td>
</tr>


<tr>
<td height="28" align="left"><strong>个性签名</strong>：</td>
<td height="28" align="left">
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</td>
<td height="28" align="left">
</td>
</tr>

<tr>
<td height="28" align="left"></td>
<td height="28" align="left"><input type="button" name="Submit2" id="Submit2" value="以后提醒我" onclick="javascript:document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';" />&nbsp;&nbsp;

<asp:Button ID="Button8" runat="server" Text="搞定！保存"   />
</td>
<td height="28" align="left"></td>
</tr>
</table>
</P>
</div>
</div>


</form>
</body>
</html>
