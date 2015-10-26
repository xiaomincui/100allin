<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="track_index" EnableEventValidation="false" EnableViewState="false" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>船公司跟踪,海运提单查询,集装箱货物跟踪 - 环球运费网</title>
<meta name="description" content="提供各大船公司提单查询,货物跟踪,集装箱运输状态查询,船舶靠泊信息,可跟踪的集装箱包括马士基(MSK),地中海(MSC),达飞(CMA),中远(COSCO),中海(CSCL),美国总统(APL),太平(PIL),川崎(K-LINE)等,几乎覆盖全部主流船公司" />
<link href="/css3/fcl.css" rel="stylesheet" type="text/css" />
<link href="/js/auto/port.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="/js/auto/ac_zd.js"></script>
<script type="text/javascript" language="javascript" src="/js/auto/ac_zd_head_fcl.js"></script>
<script type="text/javascript" src="/js/MSClass.js"></script>
<script language="javascript" type="text/javascript">
function SetWinHeight(obj)
{
var win=obj;
if (document.getElementById)
{
if (tracksub && !window.opera)
{
if (tracksub.contentDocument && tracksub.contentDocument.body.offsetHeight)
tracksub.height = tracksub.contentDocument.body.offsetHeight;
else if(win.Document && win.Document.body.scrollHeight)
tracksub.height = tracksub.Document.body.scrollHeight;
}
}
} 







function doSearch()
{
var portlist = new Array();
portlist.push(['1','川崎汽船','KLINE']);
portlist.push(['2','东方海外','OOCL']);
portlist.push(['3','泛洲海运','PCL']);
portlist.push(['4','海丰国际','SITC']);
portlist.push(['5','兴亚海运','HAS']);
portlist.push(['6','南青','NANTSING']);
portlist.push(['7','中海集运','CSCL']);
portlist.push(['8','中外运航运','SNL']);
portlist.push(['9','中远集运','COSCO']);
portlist.push(['10','神原汽船','KKC']);
portlist.push(['11','韩进海运','HJS']);
portlist.push(['12','法国达飞','CMA']);
portlist.push(['13','以星航运','ZIM']);
portlist.push(['14','阳明海运','YML']);
portlist.push(['15','长荣海运','EMC']);
portlist.push(['17','地中海','MSC']);
portlist.push(['18','阿拉伯轮船','UASC']);
portlist.push(['36','宏海箱运','RCL']);
portlist.push(['16','万海航运','WHL']);
portlist.push(['20','南美轮船','CSAV']);
portlist.push(['21','马士基','MAERSK']);
portlist.push(['22','商船三井','MOL']);
portlist.push(['23','美国总统','APL']);
portlist.push(['24','意大利邮船','LT']);
portlist.push(['25','日本邮船','NYK']);
portlist.push(['26','澳航','ANL']);
portlist.push(['27','达贸','DELMAS']);
portlist.push(['28','北欧亚航','NOR']);
portlist.push(['29','智利航运','CCNI']);
portlist.push(['30','太平船务','PIL']);
portlist.push(['31','巴西轮船','LIBRA']);
portlist.push(['32','南星海运','NSS']);
portlist.push(['33','天敬海运','CKL']);
portlist.push(['42','民生轮船','MSL']);
portlist.push(['45','美国轮船','USL']);
portlist.push(['48','诺达纳','NORDAN']);
portlist.push(['19','现代商船','HMM']);
portlist.push(['34','长锦','SINKOR']);
portlist.push(['35','穆勒航运','MCC']);
portlist.push(['37','金星轮船','GSL']);
portlist.push(['38','阿联酋航运','ESL']);
portlist.push(['39','东映海运','DYS']);
portlist.push(['40','高丽海运','KMTC']);
portlist.push(['41','南非轮船','SAF']);
portlist.push(['43','世腾船务','STX']);
portlist.push(['44','美森轮船','MATSON']);
portlist.push(['46','太古船务','NGPL']);
portlist.push(['47','格里戈星航','GSS']);
portlist.push(['49','沙特航运','NSCSA']);
portlist.push(['50','赫伯罗特','HPL']);
portlist.push(['51','玛丽亚那','MELL']);
portlist.push(['64','德翔海运','TSL']);
portlist.push(['52','汉堡南美','HBS']);
portlist.push(['53','亚利安莎','ALI']);
portlist.push(['54','天熙箱运','TCC']);
portlist.push(['55','大西洋','ACL']);
portlist.push(['57','锦江','JINJIANG']);
portlist.push(['58','上海浦海','PHL']);
portlist.push(['59','亚川船务','IAL']);
portlist.push(['60','德国非洲','DAL']);
portlist.push(['61','巴拉基','BSL']);
portlist.push(['62','德利','HUBLINE']);
portlist.push(['63','斗宇海运','DOOW']);
portlist.push(['65','尼罗河航运','NDS']);
portlist.push(['66','远东船务','FESCO']);

document.getElementById("iGZ-Code").value = "";

for (var i=0;i<portlist.length;i++)
{
    if (document.getElementById("carrier").value.toLowerCase() == portlist[i][1].toLowerCase() | document.getElementById("carrier").value.toLowerCase() == portlist[i][2].toLowerCase())
    {
        document.getElementById("iGZ-Code").value = portlist[i][0];
    }
}

if (document.getElementById("blno").value == "")
{
    alert("请输入提单号/箱号");
}
else
{
    if (document.getElementById("carrier").value == "")
    {
        alert("请输入船公司名称");
    }
    else
    {
        document.getElementById('title').style.display = "none";
        document.getElementById('detail').style.display = "";
        document.getElementById('btnSubmit').click();
    }
}
}

//function setAutoHeight(iframeElement,   iframeWindow) {
//iframeElement.style.height = iframeWindow.document.body.scrollHeight;
//iframeElement.style.width   =   iframeWindow.document.body.scrollWidth ;
//alert(iframeElement.style.height);
//// 或者
//// iframeElement.height = iframeWindow.document.body.offsetHeight ;
//// iframeElement.width   =   iframeWindow.document.body.offsetWidth;

//}


//setInterval(
//function() {
//  setAutoHeight(document.getElementById("tracksub"), window.frames[0]);
//},
//2000 );
</script>
</head>

<body >
<div id="messages"></div>
<div class="h_box">
<usertoptop20100711:usertoptop20100711 ID="usertoptop20100711_2" runat="server" />
<usertopmid20100711:usertopmid20100711 ID="usertopmid20100711_2" runat="server" />		
<usertopmenu20100711:usertopmenu20100711 ID="usertopmenu20100711_2" runat="server" />
</div>
<div style="float:left;width:100%;">
<div class="main"><!--页面主体开始-->	
<%--<div class="menu">
	<h1>您的位置：<a href="/">首页</a> >  集装箱跟踪</h1>
</div>--%>
<div class="s_bar">
<div class="s_bar_l"><img src="/images2/2011_fcl/bar1.gif" /></div>
<div class="s_bar_m">
<div class="s_bar_mp">
<form id="form1" action="http://www.igenzong.com/api2/P2P?4ffb37119ee54d38849f269c4695ab85" method="post" target="tracksub">
<table width="890" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td align="right"><strong>提单号/箱号</strong>：</td>
<td><input name="blno" type="text" id="blno" style="width:300px;" /></td>
<td align="right"><strong>船公司</strong>：</td>
<td><input name="carrier" type="text" id="carrier" sou_type="ship_com" onfocus="auto_init(event,this);" onkeydown="if(event.keyCode==13){return false;}" style="width:120px;" /></td>
<td align="center"><input type="hidden" name="iGZ-Code" id="iGZ-Code" value="" /><input type="hidden" name="APIkey" value="4ffb37119ee54d38849f269c4695ab85" /><input type="submit" id="btnSubmit" name="btnSubmit" value="搜索" style="display:none;" /><input type="image" name="ImageButton1" id="ImageButton1" src="/images2/2011_fcl/s_bt.jpg" style="border-width:0px;" onclick="doSearch();" /></td>
</tr>
</table>
</form>
</div>
</div>
<div class="s_bar_r"><img src="/images2/2011_fcl/bar2.gif" /></div>
<div class="fd_jt"><img src="/images2/2011_fcl/fdjt.jpg" /></div>
</div>


<div id="title"><img src="images/title.jpg" /></div>

<div id="detail" style="display:none;">
<div><img src="images/steps.jpg" /></div>
<div><img src="images/result.jpg" /></div>
<div style="border:2px solid #A32924;width:920px; margin:0px 0px 20px 0px;padding:20px 15px 0px 15px;overflow:hidden; float:left;">
<iframe src="about:blank" name="tracksub" id="tracksub" onload="javascript:SetWinHeight(this);" style="width:920px;height:400px;color:#666666;" frameborder="0" onclick="javascript:SetWinHeight(this);" ></iframe>
<div style="margin:10px 0px 20px 0px"><img src="images/tips.jpg" /></div>
</div>
</div>
<!--右边结束-->			
<userbottom100414:userbottom100414 ID="userbottom100414_1" runat="server" />
</div>
</div>
</body>
</html>
