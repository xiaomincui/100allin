<%@ Page Language="C#" AutoEventWireup="true" CodeFile="livepreview_detail.aspx.cs" Inherits="livepreview_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>精品预展</title>
<link href="css/css.css" rel="stylesheet" type="text/css" /><link rel="stylesheet" href="css/style.css" type="text/css" />
 
	<style type="text/css">
        .tdtest:hover
        {
            border: solid 1px blue;
        }
    </style>
    
<link href="css/common.css" type="text/css" rel="stylesheet" media="all" />
<link href="css/photoShow.css" type="text/css" rel="stylesheet" media="all"/>
<script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="js/ScrollPic.js"></script>
<script type="text/javascript"> 
window.onload=function ()
{
	var oMark = document.getElementById('wbMark');
	var oFloat = document.getElementById('wbFloatLayer');
	var oBig = document.getElementById('imgBig');
	var oImg = oBig.getElementsByTagName('img')[0];
	var oSmall = document.getElementById('imgSmall');
	var oImgSmall = oSmall.getElementsByTagName('img')[0];
	var oZoom = document.getElementById('zoom');
	var oZoomIn = oZoom.getElementsByTagName('li')[0];
	var oZoomOut = oZoom.getElementsByTagName('li')[2];
	if(oImgSmall.offsetWidth > oImgSmall.offsetHeight){
		oImgSmall.style.width = 100 +'%';
	}else{
		oImgSmall.style.height = 100 +'%';
	}
	oMark.style.width = oImgSmall.offsetWidth + 'px';
	oMark.style.height = oImgSmall.offsetHeight + 'px';
	oFloat.style.width = oBig.offsetWidth/oImg.offsetWidth*oMark.offsetWidth + 'px';
	oFloat.style.height = oBig.offsetHeight/oImg.offsetHeight*oMark.offsetHeight + 'px';
	
	oMark.onmousemove=function (ev){
		var oEvent=ev||event;
		var l=oEvent.clientX-oSmall.offsetLeft-oFloat.offsetWidth/2;
		var t=oEvent.clientY-oSmall.offsetTop-oFloat.offsetHeight/2;	
		if(l<0){
			l=0;
		}else if(l>oMark.offsetWidth-oFloat.offsetWidth){
			l=oMark.offsetWidth-oFloat.offsetWidth;
		}
		if(t<0){
			t=0;
		}
		else if(t>oMark.offsetHeight-oFloat.offsetHeight){
			t=oMark.offsetHeight-oFloat.offsetHeight;
		}
		oFloat.style.left=l+'px';
		oFloat.style.top=t+'px';	
		var percentX=l/(oMark.offsetWidth-oFloat.offsetWidth);
		var percentY=t/(oMark.offsetHeight-oFloat.offsetHeight);		
		oImg.style.left=-percentX*(oImg.offsetWidth-oBig.offsetWidth)+'px';
		oImg.style.top=-percentY*(oImg.offsetHeight-oBig.offsetHeight)+'px';
	};
	var step = 5;
	var currentSize = 60;	//默认的当前显示比例 60%
	$("#sliderBlock").css("width",currentSize);
	oZoomIn.onclick = function(){
		
		currentSize-= step;
		if(currentSize<0){
			currentSize=0;
			return false;	//限制放大缩小范围
		}
		$("#sliderBlock").css("width",currentSize);
 
		oImg.style.width = oImg.offsetWidth-oImg.offsetWidth/5 +'px';
		oImg.style.height = oImg.offsetHeight-oImg.offsetHeight/5 +'px';
		oFloat.style.width = oFloat.offsetWidth+oFloat.offsetWidth/5 +'px';
		oFloat.style.height = oFloat.offsetHeight+oFloat.offsetHeight/5 +'px';
	}
	oZoomOut.onclick = function(){
		
		currentSize+= step;
		if(currentSize>100){
			currentSize=100;
			return false;//限制放大缩小范围
		}
		$("#sliderBlock").css("width",currentSize);
 
		oImg.style.width = oImg.offsetWidth+oImg.offsetWidth/5 +'px';
		oImg.style.height = oImg.offsetHeight+oImg.offsetHeight/5 +'px';
		oFloat.style.width = oFloat.offsetWidth-oFloat.offsetWidth/5 +'px';
		oFloat.style.height = oFloat.offsetHeight-oFloat.offsetHeight/5 +'px';
	}
 
	$("#scro_line").live("click",function(event){
		var _this = $(this);
		var position = event.pageX - _this.offset().left;
		if(position>100){
			position = 100;
		}
		if(position<0){
			position = 0;
		}
		var isZoomIn = position<currentSize;
		if(isZoomIn){
			var clickTimes = parseInt((currentSize-position)/step);
			for(var i=0;i<clickTimes;i++){
				oZoomIn.onclick();
			}
		}else{
			var clickTimes = parseInt((position - currentSize)/step);
			for(var i=0;i<clickTimes;i++){
				oZoomOut.onclick();
			}
		}
		//currentSize = position;
		//$("#sliderBlock").css("width",currentSize);
	});
};
</script>
<script type="text/javascript"> 
$(document).ready(function(){
		$(".open").toggle(
		function () {
			$(this).text('关闭详细');
			$('.quality_detail').slideDown(100);
		  },
		  function () {
			$(this).text('展开详细');
			$('.quality_detail').slideUp(100);
		  })
		  
		  
	
});
$(document).ready(function(){
	var tableheight = $(window).height() - 94; //浏览器当前窗口可视区域高度
	$(".wb_conleft,.wb_content .wb_conleft .imgbig").css("height",tableheight + "px");
	$(".quality_detail").css("height",tableheight - 24 +"px");
})
</script>
<script language="JavaScript"> 
<!--
var flag=false;
function DrawImage(ImgD,w,h){
 var image=new Image();
 image.src=ImgD.src;
 if(image.width>0 && image.height>0){
  flag=true;
  if(image.width/image.height>= w/h){
   if(image.width>w){
    ImgD.width=w;
    ImgD.height=(image.height*w)/image.width;
   }else{
    ImgD.width=image.width;
    ImgD.height=image.height;
   }
   //ImgD.alt=image.width+"x"+image.height;
  }
  else{
   if(image.height>h){
    ImgD.height=h;
    ImgD.width=(image.width*h)/image.height;
   }else{
    ImgD.width=image.width;
    ImgD.height=image.height;
   }
   ImgD.alt=image.width+"x"+image.height;
   /*
   if(image.width>w){
    ImgD.width=w;
    ImgD.height=(image.height*w)/image.width;
   }else{
    ImgD.width=image.width;
    ImgD.height=image.height;
   }
   */
   //ImgD.alt=image.width+"x"+image.height;
  }
 }
}
//-->
</script>
<script type="text/javascript"> 
var _mvq = _mvq || [];
_mvq.push(['$setAccount', 'm-21302-0']);
 
_mvq.push(['$logConversion']);
(function() {
	var mvl = document.createElement('script');
	mvl.type = 'text/javascript'; mvl.async = true;
	mvl.src = ('https:' == document.location.protocol ? 'https://secure' : 'http://static') + 
 
'.mediav.com/mvl.js';
	var s = document.getElementsByTagName('script')[0];
	s.parentNode.insertBefore(mvl, s); 
})();	
</script>
 
<script type="text/javascript"> 
 
  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-36202056-1']);
  _gaq.push(['_setDomainName', 'artron.net']);
  _gaq.push(['_trackPageview']);
 
  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();
 
</script></head>
 
<body>
<table width="950" height="118" border="0" align="center" cellpadding="0" cellspacing="0" style="padding:5px 0 3px 0;">
  <tr>
    <td width="261"  height="118" class="line"><a href="http://www.n21ce.com"><img src="images/logo1.jpg" alt="" /></a></td>
    <td width="691"  height="118"><iframe align="center" width="691" height="118" src="http://www.n21ce.com/frm_adv.aspx?gid=4" frameborder="no" border="0" marginwidth="0" marginheight="0" scrolling="no"></iframe></td>
  </tr>
</table>
 
<div id="menu">
    <div id="menu_content">
        <a href="http://www.n21ce.com/default.aspx">首页</a>
        <a href="http://www.n21ce.com:8080/live/liveauction.aspx">拍卖信息</a>
        <a href="http://www.n21ce.com:8080/live/liveauction.aspx">网上预展</a>
        <a href="http://www.n21ce.com:8080/live/vidarchive.aspx">网上直播</a>
        <a href="http://www.n21ce.com:8080/live/archive.aspx">成交结果</a>
        <a href="http://www.n21ce.com/list.aspx?cid=5">业内新闻</a>
        <a href="http://www.n21ce.com/list.aspx?cid=57">人物专访</a>
        <a href="http://www.n21ce.com/list.aspx?cid=8">易胜动态</a>
        <a href="http://www.n21ce.com/list.aspx?cid=59">易胜服务</a>
        <a href="http://www.n21ce.com/list.aspx?cid=64" class="last">精品赏析</a>
    </div>
</div>
<div style="position:relative; width:980px; margin:auto; z-index:9999;">
<div class="quality_title">
    <h1 class="fl">640 高茜 Gao Qian 条纹桌布和白色花瓶 striped tablecloth and white vase</h1>
    <a href="javascript:viod();" class="open fl">展开详细</a>
		
	
    <div class="share2 fr">
    
    </div>
    <div class="clear"></div>
</div>
<div class="quality_detail" >
        	<dl>
            	<dd><strong>类别：</strong><span>绘画</span></dd>
               <!-- <dd><strong>尺寸：</strong><span>高43CM</span></dd>-->
			   				
				
            </dl>
            <dl>
            	<dd><strong>详情：</strong><span>高茜 Gao Qian 条纹桌布和白色花瓶 striped tablecloth and white vase<br />
纸本彩墨 colorful ink on paper<br />
2001年作 painted in 2001<br />
43x66cm</span></dd>
            </dl>
            <dl class="margin0">
            	<dd><strong>公司名称：</strong><a href="jgjj.php?jgcd=JG0155" target="_blank" title="北京永乐">北京永乐</a>										</dd>
                <dd><strong>拍卖会：</strong><span>2012年秋季拍卖会</span></dd>
                <!--<dd><strong>专场名称：</strong><span>古董珍玩专场</span></dd>-->
                <dd><strong>拍卖日期：</strong><span>2012-12-14</span></dd>
            </dl>
        </div>
</div>
<div class="wb_bg">
<div class="wb_content clearfix">
	<div class="wb_conleft">
		<div class="imgbig" id="imgBig" ><img src="images/main.jpg" /></div>
		<div class="imgdiv"></div>
	</div>
	<div class="wb_conright">
		<ul class="zoomdiv" id="zoom"><li class="zoomin">小</li>
        <li class="scro">
         <div  id="scro_line" class="scro_line"> <div  id="sliderBlock" class="sliderBlock"></div></div>
       
       </li>
      <li class="zoomout">大</li></ul>
		<div class="imgsmall" id="imgSmall"><span class="mark" id="wbMark"></span><span class="float_layer" id="wbFloatLayer"></span>
	
		
		<img src="images/main_s.jpg" border="0"    >
		
		</div>
		<ul class="imgsmallul">
									<li><a href="javascript:void(0);"  title=""  onclick="window.location.href='photoShow.php?ArtId=392&Pid=640&pmhId=PMH203033'">
						
						
				        <img src="images/main_s2.jpg" border="0"    >
						
						
						</a></li>
			 	
 
		</ul>
	</div>
</div>
</div>
 
<div class="column_mid blk_29">
	<div id="slide-box">
	<b class="corner"></b>
    <DIV class=Cont id="J_slide" style="height:54px;"><!-- 图片列表 begin -->
    <div class="wrap">
    <ul class="ks-switchable-content">
  	  				<li><a href="photoShow.php?ArtId=385&pmhId=PMH203033"  title="傅抱石 西风吹下红雨来"     >
				 <img src="images/s01.jpg"    alt="傅抱石 西风吹下红雨来" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=386&pmhId=PMH203033"  title="程十发 竹影情趣"     >
				 <img src="images/s02.jpg"    alt="程十发 竹影情趣" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=387&pmhId=PMH203033"  title="张大千 接天荷叶无穷碧"     >
				 <img src="images/s03.jpg"    alt="张大千 接天荷叶无穷碧" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=388&pmhId=PMH203033"  title="林风眠 扬帆"     >
				 <img src="images/s04.jpg"    alt="林风眠 扬帆" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=389&pmhId=PMH203033"  title="赵望云 秦岭奇峰"     >
				 <img src="images/s05.jpg"    alt="赵望云 秦岭奇峰" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=390&pmhId=PMH203033"  title="洪凌 Hong Ling 江雪 Snowing River"     >
				 <img src="images/s06.jpg"    alt="洪凌 Hong Ling 江雪 Snowing River" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=391&pmhId=PMH203033"  title="朱铭 Ju Ming 太极系列 -- 云手 Tai Chi Series -- Moving hands like clouds"     >
				 <img src="images/s07.jpg"    alt="朱铭 Ju Ming 太极系列 -- 云手 Tai Chi Series -- Moving hands like clouds" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=392&pmhId=PMH203033"  title="高茜 Gao Qian 条纹桌布和白色花瓶 striped tablecloth and white vase"  class="over"  >
				 <img src="images/s08.jpg"    alt="高茜 Gao Qian 条纹桌布和白色花瓶 striped tablecloth and white vase" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=393&pmhId=PMH203033"  title="邵岩 Shao Yan 气结 Knot of Qi"     >
				 <img src="images/s09.jpg"    alt="邵岩 Shao Yan 气结 Knot of Qi" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=394&pmhId=PMH203033"  title="蓝正辉 LanZhenghui C-107"     >
				 <img src="images/s10.jpg"    alt="蓝正辉 LanZhenghui C-107" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=395&pmhId=PMH203033"  title="陈承卫 Chen Chengwei 青春启示录-梳妆 Revelation of Youth- dress and make u"     >
				 <img src="images/s11.jpg"    alt="陈承卫 Chen Chengwei 青春启示录-梳妆 Revelation of Youth- dress and make u" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=396&pmhId=PMH203033"  title="李永飞 Li Yongfei 飞翔的孔雀 Flight of the Peacock"     >
				 <img src="images/s12.jpg"    alt="李永飞 Li Yongfei 飞翔的孔雀 Flight of the Peacock" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=470&pmhId=PMH203033"  title="周碧初 潭江风景"     >
				 <img src="images/s13.jpg"    alt="周碧初 潭江风景" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=471&pmhId=PMH203033"  title="黄鹤 手风琴"     >
				 <img src="images/s14.jpg"    alt="黄鹤 手风琴" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=398&pmhId=PMH203033"  title="清乾隆 楠木雕灵芝如意纹如意"     >
				 <img src="images/s15.jpg"    alt="清乾隆 楠木雕灵芝如意纹如意" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=399&pmhId=PMH203033"  title="清雍正 青花缠枝花卉纹小壶"     >
				 <img src="images/s06.jpg"    alt="清雍正 青花缠枝花卉纹小壶" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=464&pmhId=PMH203033"  title="清雍正 窑变釉菊瓣壶 清雍正/乾隆 紫砂合菊壶"     >
				 <img src="pics.php?img=/auction_manager/201211/small_2012110609112852975&w=50&h=60&sig=1366115598"    alt="清雍正 窑变釉菊瓣壶 清雍正/乾隆 紫砂合菊壶" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=401&pmhId=PMH203033"  title="明晚期 五彩童子图茶壶 明嘉靖 青花童子图碗"     >
				 <img src="pics.php?img=/auction_manager/201210/small_2012101914404847598&w=50&h=60&sig=1366115598"    alt="明晚期 五彩童子图茶壶 明嘉靖 青花童子图碗" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=403&pmhId=PMH203033"  title="清光绪 万丰顺记小周盘壶 清道光 青花矾红莲纹小杯"     >
				 <img src="pics.php?img=/auction_manager/201210/small_2012101914422755604&w=50&h=60&sig=1366115598"    alt="清光绪 万丰顺记小周盘壶 清道光 青花矾红莲纹小杯" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=404&pmhId=PMH203033"  title="清雍正 青花一束莲纹大盘"     >
				 <img src="pics.php?img=/auction_manager/201210/small_2012101914432183304&w=50&h=60&sig=1366115598"    alt="清雍正 青花一束莲纹大盘" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=405&pmhId=PMH203033"  title="清光绪御用青玉雕“体和殿御赏”交龙钮宝玺"     >
				 <img src="pics.php?img=/auction_manager/201210/small_2012101914463672021&w=50&h=60&sig=1366115598"    alt="清光绪御用青玉雕“体和殿御赏”交龙钮宝玺" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=406&pmhId=PMH203033"  title="清康熙青花海水云龙纹经筒"     >
				 <img src="pics.php?img=/auction_manager/201210/small_2012101914473349413&w=50&h=60&sig=1366115598"    alt="清康熙青花海水云龙纹经筒" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=407&pmhId=PMH203033"  title="逸居长物"     >
				 <img src="pics.php?img=/auction_manager/201210/small_2012101914483250032&w=50&h=60&sig=1366115598"    alt="逸居长物" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=463&pmhId=PMH203033"  title="明永乐 青花缠枝莲纹双系小罐"     >
				 <img src="pics.php?img=/auction_manager/201211/small_2012110609102813117&w=50&h=60&sig=1366115598"    alt="明永乐 青花缠枝莲纹双系小罐" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=465&pmhId=PMH203033"  title="关山月 梅花香自苦寒来 "     >
				 <img src="pics.php?img=/auction_manager/201211/small_2012110609121170340&w=50&h=60&sig=1366115598"    alt="关山月 梅花香自苦寒来 " border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=466&pmhId=PMH203033"  title="张大千 秋山萧寺  "     >
				 <img src="pics.php?img=/auction_manager/201211/small_2012110609124667183&w=50&h=60&sig=1366115598"    alt="张大千 秋山萧寺  " border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=467&pmhId=PMH203033"  title="黄永玉 鹤来  "     >
				 <img src="pics.php?img=/auction_manager/201211/small_2012110609132018700&w=50&h=60&sig=1366115598"    alt="黄永玉 鹤来  " border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=468&pmhId=PMH203033"  title="吴昌硕 清风扬竹"     >
				 <img src="pics.php?img=/auction_manager/201211/small_2012110609135841836&w=50&h=60&sig=1366115598"    alt="吴昌硕 清风扬竹" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=469&pmhId=PMH203033"  title="徐悲鸿  对联"     >
				 <img src="pics.php?img=/auction_manager/201211/small_2012110609144076498&w=50&h=60&sig=1366115598"    alt="徐悲鸿  对联" border="0"  >
				
				
				</a></li>
	   				<li><a href="photoShow.php?ArtId=472&pmhId=PMH203033"  title="侯志民 夏日序曲"     >
				 <img src="pics.php?img=/auction_manager/201211/small_2012110617270764688&w=50&h=60&sig=1366115598"    alt="侯志民 夏日序曲" border="0"  >
				
				
				</a></li>
	 	
 
  
	  </ul>
    </div><!-- 图片列表 end -->
     <div class="ks-switchable-triggers">
				<a class="prev" id="J_prev" href="javascript:void(0);"></a> 
				<a class="next" id="J_next" href="javascript:void(0);"></a>            </div>
     </DIV>
     <b class=corner></b>
    </DIV>
</div>

<div id="footer">
  <table width="950" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td>
        <table width="950" height="27" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="88" valign="middle" background="images/p1.jpg">
              <div align="left">
                &nbsp;&nbsp;&nbsp;<span class="sty2">合作伙伴</span>
              </div>
            </td>
            <td width="950" background="images/p-bj.jpg"></td>
            <td width="50">
              <div align="right">
                <img src="images/p-more1.jpg" width="50" height="27" />
              </div>
            </td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td background="images/p3-tiao.jpg">
		    <div style="padding:0 0 0 20px;">
            <table width="100%" border="0" align="left" cellpadding="5" cellspacing="0">
              <tr>
                <td>
                  <div id="oRollH1">
                  
<html>
<body>
<a href="http://www.cguardian.com/" target="_blank" style="width:11%"><img src="http://www.n21ce.com/upload/2012_02/temp_12021715249396.jpg"  width="88" height="31" alt="中国嘉德&#13;&#10;中国嘉德国际拍卖有限公司"/></a><a href="http://www.polypm.com.cn/" target="_blank" style="width:11%"><img src="http://www.n21ce.com/upload/2012_02/temp_12021714473524.jpg"  width="88" height="31" alt="北京保利&#13;&#10;北京保利拍卖有限公司"/></a><a href="http://www.hanhai.net" target="_blank" style="width:11%"><img src="http://www.n21ce.com/upload/2012_02/temp_12022015207187.jpg"  width="88" height="31" alt="北京翰海&#13;&#10;北京翰海拍卖有限公司"/></a><a href="http://www.council.com.cn/" target="_blank" style="width:11%"><img src="http://www.n21ce.com/upload/2012_02/temp_12021715143973.jpg"  width="88" height="31" alt="北京匡时&#13;&#10;北京匡时国际拍卖有限公司"/></a><a href="http://www.xlysauc.com/" target="_blank" style="width:11%"><img src="http://www.n21ce.com/upload/2012_02/temp_12021715403463.jpg"  width="88" height="31" alt="西泠拍卖&#13;&#10;西泠印社拍卖有限公司"/></a><a href="http://www.gzguardian.com/" target="_blank" style="width:11%"><img src="http://www.n21ce.com/upload/2012_02/temp_12021715345972.jpg"  width="88" height="31" alt="广州华艺&#13;&#10;广州华艺国际拍卖有限公司"/></a><a href="http://www.ccrnews.com.cn/" target="_blank" style="width:11%"><img src="http://www.n21ce.com/upload/2010_11/temp_10112810269020.gif"  width="88" height="31" alt="中国文物信息网"/></a><a href="http://www.sach.gov.cn/" target="_blank" style="width:11%"><img src="http://www.n21ce.com/upload/2010_12/temp_10120320218385.jpg"  width="88" height="31" alt="中国文博网&#13;&#10;中国国家文物局"/></a><a href="http://www.zzy.cn" target="_blank" style="width:11%"><img src="http://www.n21ce.com/upload/2010_11/temp_10112810228294.gif"  width="88" height="31" alt="中资源＿"/></a>
 
 
                  </div>
                </td>
              </tr>
            </table>
		    </div>
      </td>
    </tr>
    <tr>
      <td height="7">
        <img src="images/p2.jpg" width="950" height="7" />
      </td>
    </tr>
  </table>
 
  <table width="950" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td>
        <table width="950" height="27" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="88" valign="middle" background="images/p1.jpg">
              <div align="left">
                &nbsp;&nbsp;&nbsp;<span class="sty2">友情链接</span>
              </div>
            </td>
            <td width="912" background="images/p-bj.jpg"></td>
            <td width="50">
              <div align="right">
                <img src="images/p-more1.jpg" width="50" height="27" />
              </div>
            </td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td background="images/p3-tiao.jpg">
        <div style="padding:0 0 0 20px;">
          <table width="100%" border="0" align="left" cellpadding="5" cellspacing="0">
            <tr>
              <td>
                <div id="oRollV1">
                
</div>
              </td>
            </tr>
          </table>
        </div>
      </td>
    </tr>
    <tr>
      <td height="7">
        <img src="images/p2.jpg" width="950" height="7" />
      </td>
    </tr>
  </table>
 
  <p align="center"><a href="http://www.n21ce.com/show.aspx?id=1054&amp;cid=59">网站简介</a> - <a href="http://www.n21ce.com/show.aspx?id=1129&amp;cid=59">广告服务</a> - <a href="javascript:void(0);">网站地图</a> - <a href="http://www.n21ce.com/show.aspx?id=1180&amp;cid=59">联系方式</a> - <a href="http://www.n21ce.com/admin_login.aspx" target="_blank">后台管理</a><br />Copyright &copy; 1995-2011 <a href="www.n21ce.com">n21ce.com</a>&nbsp;Powered by 世纪易格信息咨询有限公司<br />联系电话：010-62011128　62036480<br /><a href="http://www.miitbeian.gov.cn" target="_blank" title="备案"><font color="#000000">京ICP备05032684号</font></a><br /><script src="http://s85.cnzz.com/stat.php?id=3324593&web_id=3324593&show=pic" language="JavaScript"></script></p>
 
    <div class="menuskin" id="popmenu" onmouseover="clearhidemenu();highlightmenu(event,'on')" onmouseout="highlightmenu(event,'off');dynamichide(event)" style="Z-index:100"></div>
    <script type="text/javascript" src=""
      inc/menu.js" charset="gb2312">
    </script>
    <script type="text/javascript">
      jsdone=true;
    </script>
</div>

<SCRIPT type=text/javascript> 
	var D=YAHOO.util.Dom, E=YAHOO.util.Event;
 
	KISSY().use("*", function(S) {
		var el = D.get('J_slide'),
			activeIndex = parseInt(el.getAttribute('data-active-index')) || 0;
 
		var carousel = new S.Carousel(el, {
			hasTriggers: false,
			navCls: 'ks-switchable-nav',
			contentCls: 'ks-switchable-content',
			activeTriggerCls: 'current',
			effect: "scrollx",
			steps: 17,    //调整每次显示的列数
			viewSize: [900],
			activeIndex: activeIndex
		});
		
		E.on('J_prev', 'click', carousel.prev, carousel, true);
		E.on('J_next', 'click', carousel.next, carousel, true);
	});
 
	
</SCRIPT>
 
 

 
</body>
</html>
