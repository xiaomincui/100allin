/*********************************************************
文件名：fullad.js
Encode：utf-8
Copuright(c) 2010-2011 徐奕峰
文件编号：fullad_js_1
创建人：徐奕峰
版本：1.0
日期：2010-03-22
修改人：
日期：
描述：首页全屏广告展示
     1,可自定义展示时间，动画，媒体类型（iamge|swf），链接地址，高度，宽度
     2,浏览器版本低于IE6时，解决png不透明问题
    3,判断广告图片加载完成后，再显示广告区域
     已测浏览器 IE6,opera,firefox,chrome.
            
备注：
**********************************************************/

var _ad_i = 0;
var imgshow1=new Image();
function AD_show()
{
	var div = document.getElementById("ad_full");
		if(_ad_tp == "swf"){
		div.className ="adfull_sh";
		swfobject.embedSWF(_ad_src, "flashsp", _ad_width, _ad_height, "9.0.0", "expressInstall.swf");
		_ad_i = _ad_height;
		setTimeout("close_ad()",_ad_time);
		}
		if(_ad_tp == "image")
		{
			var imgshow=new Image();
			imgshow.src = _ad_src;
			imgshow1.src = _ad_hid_src;
			imgshow1.onload;
			imgshow.onload = function(){
			div.style.width = _ad_width + "px";
			div.style.height= "1px";
			div.className ="adfull_sh";
			var ad_str ="";
			ad_str ="<a href=\""+_ad_href+"\" title=\""+_ad_directions+"\" target=\"_blank\">";
			if(isIE() == true)
			{
				if(_ad_src.indexOf(".png")!=-1)
				{
					ad_str += "<span "
					 + " style=\"" + "display:inline-block;width:" + _ad_width + "px; height:" + _ad_height + "px;"
					 + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
					 + "(src=\'" + _ad_src + "\', sizingMethod='scale');\"></span>";
				}
				else
				{
					ad_str += "<img src=\""+_ad_src+"\" alt=\""+_ad_directions+"\"/>";
				}

			}
			else
			{
				ad_str += "<img src=\""+_ad_src+"\" alt=\""+_ad_directions+"\"/>";
			}
			ad_str += "</a>";
			div.innerHTML = ad_str;
			extend();
			}
		}
}
function extend(){
	var div = document.getElementById("ad_full");
	if(_ad_i==_ad_height)clearTimeout(t1);
	_ad_i+=_ad_add;
	if(_ad_i>=_ad_height)_ad_i=_ad_height;
	if(_ad_i<_ad_height)
	{
		div.style.height = _ad_i +"px";
		var t1 = setTimeout("extend()",1);
	}
	else
	{
		setTimeout("close_ad()",_ad_time);
	}
}
function close_ad()
{
	var div = document.getElementById("ad_full");
	if(_ad_i<=_ad_hid_height)_ad_i=_ad_hid_height;	
	if(_ad_i==_ad_hid_height){
	clearTimeout(t2);
	}
	if(_ad_i>_ad_hid_height)
	{
		div.style.height = _ad_i +"px";
		var t2 = setTimeout("close_ad()",1);
		_ad_i-=_ad_add;
	}else{re_img();}
}
//收缩后，替换图片
function re_img()
{
	var div = document.getElementById("ad_full");
	var ad_str ="";
	ad_str ="<a href=\""+_ad_href+"\" title=\""+_ad_directions+"\" target=\"_blank\">";
	if(isIE() == true)
	{
		if(_ad_hid_src.indexOf(".png")!=-1)
		{
			ad_str += "<span "
			 + " style=\"" + "display:inline-block;width:" + _ad_width + "px; height:" + _ad_hid_height + "px;"
			 + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
			 + "(src=\'" + _ad_hid_src + "\', sizingMethod='scale');\"></span>";
		}
		else
		{
			ad_str += "<img src=\""+_ad_hid_src+"\" alt=\""+_ad_directions+"\" style=\"height:" + _ad_hid_height + "px;\"/>";
		}

	}
	else
	{
		ad_str += "<img src=\""+_ad_hid_src+"\" alt=\""+_ad_directions+"\" style=\"height:" + _ad_hid_height + "px;\"/>";
	}
	ad_str += "</a>";
	div.innerHTML = ad_str;
}
function isIE(){
if (navigator.appName!="Microsoft Internet Explorer") {return false}
return true
}