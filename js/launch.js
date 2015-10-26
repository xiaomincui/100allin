
var __SME_STATIC = {};
__SME_STATIC.ZH_CN = "zh_cn";
__SME_STATIC.EN_US = "en_us";
__SME_STATIC.NO = "n";
__SME_STATIC.YES = "y";
__SME_STATIC.F = "false";
__SME_STATIC.T = "true";
__SME_STATIC.BINDING_WW_PREFIX = "cnalichn";
var _sme_wwonline_status_scriptObj;
var _sme_wwmobileonline_status_scriptObj;
var _sme_headNode = document.getElementsByTagName('head')[0];
var online = new Array();
var _sme_check_wwmobile_onlineArray = new Array();
var _sme_wwmobile_online = new Array();
var __SME_PROBE_CUSTOM_PARAMS = null;

var __SME_CLIENT_VAR = {};
__SME_CLIENT_VAR.openedWebIm = null;
__SME_CLIENT_VAR.wwId = "";
__SME_CLIENT_VAR.visitorId = "";
__SME_CLIENT_VAR.offlineMsgFlag = "0";
__SME_CLIENT_VAR.contactType = "";
__SME_CLIENT_VAR.hasChanged = false;
__SME_CLIENT_VAR.inviteHeaderCN = "&#24744;&#25910;&#21040;&#32593;&#31449;&#26381;&#21153;&#20154;&#21592;&#28040;&#24687;&#65306;";
__SME_CLIENT_VAR.phoneCnTitleStart = "&#x603B;&#x673A;&#xFF1A;";
__SME_CLIENT_VAR.phoneCnTitleEnd = "&#x6765;&#x7535;&#x514D;&#x957F;&#x9014;&#x8D39;";
__SME_CLIENT_VAR.inviteHeaderEN = "You got a message:";
__SME_CLIENT_VAR.visitorInputInitCodeCN = "&#35831;&#22312;&#27492;&#36755;&#20837;&#20449;&#24687;";
__SME_CLIENT_VAR.visitorInputInitCodeEN = "Please leave a message.";
__SME_CLIENT_VAR.ct = "";// click type.
__SME_CLIENT_VAR.visitorInputCode = "";
__SME_CLIENT_VAR.serverForNaviWWId = "";
__SME_CLIENT_VAR.NaviContentId = "";
__SME_CLIENT_VAR.borderColor = "";
__SME_CLIENT_VAR.phoneFontColor = "";
__SME_CLIENT_VAR.phoneBarTdColor = "";
__SME_CLIENT_VAR.scrollBarCSS = "";
__SME_CLIENT_VAR.language = "";


function __clear(timer) {
	clearTimeout(timer);
	clearInterval(timer);
	return null;
}

function _sme_set_serverForNaviWWId(wwid, contentId) {
__SME_CLIENT_VAR.serverForNaviWWId = wwid;
__SME_CLIENT_VAR.NaviContentId  = contentId;
}


function _sme_ww_getOnlineStatus(idList) {
_sme_wwonline_status_scriptObj = document.createElement("script");
if (__SME_PROBE_CUSTOM_PARAMS.turnonServerForNavigate != "1") {
	return ;
}
var _sme_wwIds = "";
var _sme_wwIds_Length = __SME_PROBE_CUSTOM_PARAMS.serverWWIdList.length;
var _sme_wwIds_Index = 0;
var _sme_match_site_ids = "";

for (; _sme_wwIds_Index<_sme_wwIds_Length; _sme_wwIds_Index++ ) {
if (_sme_wwIds_Index == _sme_wwIds_Length-1) {
_sme_wwIds += __SME_PROBE_CUSTOM_PARAMS.serverWWIdList[_sme_wwIds_Index];
} else {
_sme_wwIds += __SME_PROBE_CUSTOM_PARAMS.serverWWIdList[_sme_wwIds_Index] + ";";
}
}
_sme_wwonline_status_scriptObj.src = "http://amos.im.alisoft.com/mullidstatus.aw?beginnum=0&uids="+_sme_wwIds;
if ( window.addEventListener) {
_sme_wwonline_status_scriptObj.onload = _sme_ww_showOnlineStatus;
} else {
_sme_wwonline_status_scriptObj.onreadystatechange = _sme_ww_showOnlineStatus;
}
_sme_headNode.insertBefore(_sme_wwonline_status_scriptObj, _sme_headNode.firstChild);
}

function _sme_wwmobile_getOnlineStatus(url){
if (url == "") {
	return ;
}
_sme_wwmobileonline_status_scriptObj = document.createElement("script");
_sme_wwmobileonline_status_scriptObj.src = url;
if ( window.addEventListener) {
_sme_wwmobileonline_status_scriptObj.onload = _sme_wwmobile_showOnlineStatus;
} else {
_sme_wwmobileonline_status_scriptObj.onreadystatechange = _sme_wwmobile_showOnlineStatus;
}
_sme_headNode.insertBefore(_sme_wwmobileonline_status_scriptObj, _sme_headNode.firstChild);
}


function _sme_ww_showOnlineStatus() {
var index = 0;
var mobileCheckWWList = "";
_sme_check_wwmobile_onlineArray = new Array();
for (; index<online.length; index++) {
if (online[index]=="1") {
document.getElementById(__SME_PROBE_CUSTOM_PARAMS.serverWWIdList[index]+(index+1)).src="http://cnimg.alisoft.com//images/online.gif";
} else {
if (index == online.length-1) {
mobileCheckWWList += __SME_PROBE_CUSTOM_PARAMS.serverWWIdList[index];
}else{
mobileCheckWWList += __SME_PROBE_CUSTOM_PARAMS.serverWWIdList[index] + ",";
}
_sme_check_wwmobile_onlineArray = _sme_check_wwmobile_onlineArray.concat(__SME_PROBE_CUSTOM_PARAMS.serverWWIdList[index]+(index+1));
}
}
if (mobileCheckWWList!="") {
mobileCheckWWList = "http://cn.alisoft.com/sme/enetvisitor/wwmobile!checkOnlineStatus.jspa?ts="+new Date()+"&siteId=" + _sme_site_id + "&longWwIds=" + mobileCheckWWList;
_sme_wwmobile_getOnlineStatus(mobileCheckWWList);
}
}

function _sme_wwmobile_showOnlineStatus() {
var index = 0;
var length = _sme_check_wwmobile_onlineArray.length;
for (; index<length; index++) {
if (_sme_wwmobile_online[index] == "1") {
	document.getElementById(_sme_check_wwmobile_onlineArray[index]).src="http://cnimg.alisoft.com//images/m_online.gif";
}
}
}


function __get_cookie_map(name) {
	var map = new Object();
	var cookie = document.cookie;
	var start = cookie.indexOf(name + "=");
	if (start >= 0) {
		start = start + name.length + 1;
		var end = cookie.indexOf(";", start);
		if (end < 0) {
			end = cookie.length;
		}

		var value = __unesc(cookie.substring(start, end));
		var pairs = value.split(";");
		for (var i = 0; i < pairs.length; i++) {
			var kv = pairs[i].split(/\s*=\s*/);
			if (kv.length == 2) {
				map[kv[0]] = __unesc(kv[1]);
			}
		}
	}
	return map;
}

function __save_cookie_map(map, name, domain, path, isPerm) {
	var s = "";
	for (var p in map) {
		s += p + "=" + __esc(map[p]) + ";";
	}

	if (s.length > 0) s.length--;

	var cookie = name + "=" + __esc(s) + "; domain=" + domain + "; path=" + path;
	if (isPerm) {
		cookie += "; expires=Sat, 1 Jan 2050 00:00:00 GMT";
	}

	document.cookie = cookie;
}

function __parse_int(value) {
	var iv = parseInt(value);
	return isNaN(iv) ? 0 : iv;
}

function __parse_float(value) {
	var fv = parseFloat(value);
	return isNaN(fv) ? 0 : fv;
}

function __esc(s) {
	return s == null ? "" : escape(s.toString());
}

function __unesc(s) {
	return s == null ? "" : unescape(s.toString());
}

function __attach_event(evt, callback) {
	if (window.addEventListener) {
		window.addEventListener(evt, callback, false);
	} else if (window.attachEvent) {
		window.attachEvent("on" + evt, callback);
	}
}

function __detach_event(evt, callback) {
	if (window.removeEventListener) {
		window.removeEventListener(evt, callback, false);
	} else if (window.detachEvent) {
		window.detachEvent("on" + evt, callback);
	}
}

function __do_request(reqId, url) {
	if (reqId != null) {
		var sc = document.getElementById(reqId);
		if (sc != null) {
			sc.parentNode.removeChild(sc);
		}
	}
	var sc = document.createElement("script");
	if (reqId != null) {
		sc.id = reqId;
	}

	sc.src = url;
	var headNode = document.getElementsByTagName('head')[0];
	headNode.insertBefore(sc, headNode.firstChild);
}


function __do_tracelog(url) {
	var sc = document.createElement("img");
	sc.src = url;
	var headNode = document.getElementsByTagName('head')[0];
	headNode.insertBefore(sc, headNode.firstChild);
}

var __tips_closed = false;

var __isInvoke_tipsblock = false;
function __open_win(winId, width, height, url, fallback, language, paramsObject) {

	if (__SME_PROBE_CUSTOM_PARAMS==null && 'undefined'!=paramsObject) {
		__SME_PROBE_CUSTOM_PARAMS = paramsObject;
	}

	var feature = "menubar=0,toolbar=0,status=0,resizable=0,width=" + width + ",height=" + height;
	var win = null;
	try {
	if ( __SME_CLIENT_VAR.openedWebIm == null || __SME_CLIENT_VAR.openedWebIm.closed ) {
		win = window.open(url, winId, feature);
		if ( win != null ) {
			__SME_CLIENT_VAR.openedWebIm = win;
		}
	} else {
		__close_tips_block();
		__SME_CLIENT_VAR.openedWebIm.focus();
	}
	} catch (ex) {
	}
	if (win == null && fallback) {
		__remove_tips_block();
		__create_tips_block(winId, width, height, url, language);

		__setTimeout_winId = winId;
        __setTimeout_width = width;
        __setTimeout_height = height;
        __setTimeout_url = url;
        __setTimeout_language = language;
		__attach_event("scroll", function() {
			if (!__isInvoke_tipsblock) {
				__isInvoke_tipsblock = true;
				setTimeout("__adjust_tips_block('" + winId + "'," +width + "," + height + ",'" + url + "','" + language + "')", 10);
			}
		});
		__attach_event("resize", function() {
			if (!__isInvoke_tipsblock) {
				__isInvoke_tipsblock = true;
				setTimeout("__adjust_tips_block('" + winId + "'," +width + "," + height + ",'" + url + "','" + language + "')", 10);
			}
		});
	} else {
		__close_tips_block();
	}

	return win;
}

function __create_tips_block(winId, width, height, url, language) {
	__do_tracelog('http://e.alisoft.com/portal/sme/statistics.html?tracelog=alisoft_enet_webim_failed&ts=' + new Date().getTime());
	if (document.getElementById("__parent_tips_block") && document.getElementById("__tips_block")) { return; }
	var spDiv = document.createElement("div");
	spDiv.id = "__parent_tips_block";
	spDiv.style.width = 0;
	spDiv.style.height = 0;
	spDiv.style.border = "none";

	
	var div = document.createElement("div");
	div.style.position = "absolute";
	div.id = "__tips_block";
	div.style.zIndex = 61345;
	div.style.width = 421;
	if(""==__SME_PROBE_CUSTOM_PARAMS.phone400Number){
		div.style.height = 158;
	} else {
		div.style.height = 174;
	}
	div.style.left = (document.body.clientWidth - 495) / 2 + "px";
	div.style.top = "118px";
	div.style.filter = "progid:DXImageTransform.Microsoft.Alpha(opacity=100)";

	var img1 = null;
	var img2 = null;
	var img3 = null;
	var img4 = null;
	var img5 = null;
	var img6 = null;
	
	var imgStartChat = null;
	var imgIngoreChat = null;

	img2 = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/ww_alert_012.gif"
	img3 = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/ww_alert_02.gif";
	img4 = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/ww_alert_05.gif";
	img5 = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/ww_alert_03.gif";
	imgLineBg = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_line_bg.gif";
	
	
	if ("zh_cn" == language) {
		img1 = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/ww_alert_011.gif";
		img6 = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/ww_alert_04.gif";
		imgStartChat = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_chn_b_01.gif";
		imgIngoreChat = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_chn_b_02.gif";
	} else {
		img1 = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/ww_alert_011_eng.gif";
		img6 = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/ww_alert_04_eng.gif";
		imgStartChat = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_eng_b_01.gif";
		imgIngoreChat = "http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_eng_b_02.gif";
	}

	var temp_block_tip_text = "";
	if ('undefined'==__SME_PROBE_CUSTOM_PARAMS.msgFromServer||__SME_PROBE_CUSTOM_PARAMS.msgFromServer==null||__SME_PROBE_CUSTOM_PARAMS.msgFromServer=='') {
		if (language == "zh_cn") {
			temp_block_tip_text =   "<strong style='display:block; font-size:12px;'>" + __SME_CLIENT_VAR.inviteHeaderCN + "</strong>" + __SME_PROBE_CUSTOM_PARAMS.inviteText;
		} else {
			temp_block_tip_text =   "<strong style='display:block; font-size:12px;'>" + __SME_CLIENT_VAR.inviteHeaderEN + "</strong>" + __SME_PROBE_CUSTOM_PARAMS.inviteText;
		}
	} else {
		if (language == "zh_cn") {
			temp_block_tip_text =   "<strong style='display:block;  font-size:12px;'>" + __SME_CLIENT_VAR.inviteHeaderCN + "</strong><span style='text-indent:28px;'>" + __SME_PROBE_CUSTOM_PARAMS.msgFromServer+"</span>";
		} else {
			temp_block_tip_text =   "<strong style='display:block; font-size:12px;'>" + __SME_CLIENT_VAR.inviteHeaderEN + "</strong><span style='text-indent:28px;'>" + __SME_PROBE_CUSTOM_PARAMS.msgFromServer+"</span>";
		}
	}

	var content = [], i = 0;
	var trace_log = "__do_tracelog('http://e.alisoft.com/portal/sme/statistics.html?tracelog=alisoft_enet_webim_invited_rejected&ts=' + new Date().getTime());";
	content[i++] = '<table width="421" height="127" border="0" cellpadding="0" cellspacing="0" style="word-break:break-all;">';
	content[i++] = '<tr><td style="height:20px;background:url('+img1+') left no-repeat;padding:0 0 0 0px;" align="right"><img style="cursor:hand;border;display:left;border:0px none #ffffff" onclick="'+trace_log+'__close_tips_block();__sme_hightlight_msg();" src="'+img2+'" width="47" height="26" alt="" border="0"/></td></tr>';
	content[i++] = '<tr><td style="background:url('+img3+') bottom no-repeat;padding:0 0 0 0px;">';
	content[i++] = '<table style="inline-height:0px;" width="421" height="59" border="0" cellspacing="0" cellpadding="0" align="center" ><tr>';
	content[i++] = '<td rowspan="2" style="width:84px; height:84px; background:url('+img4+') center no-repeat;  padding:8px 7px 6px; text-align:center; vertical-align:middle;"><img src="'+__SME_PROBE_CUSTOM_PARAMS.invitePanelPic+'" width="70" height="70" alt="" border="0" style="display:left;"></td>';
	content[i++] = '<td style="width:225px;line-height:20px; font-size:14px; text-align:left; padding:18px 5px 23px; overflow:hidden; color:#666;"><div style="overflow-x;width:225px;height:70px;overflow-y:auto;font-size:12px;'+__SME_CLIENT_VAR.scrollBarCSS+'">'+temp_block_tip_text+'</div></td>';
	content[i++] = '<td style="padding-top:8px;"><img style="cursor:hand;" src="'+imgStartChat+'" onClick="__statInvitedAccepted();if(__open_win(\''+ winId + '\', ' + width + ', ' + height + ', \''+ url + '\', false, \''+language+'\'))__close_tips_block()" border="0"><span style="height:5px; line-height:5px; display:block;"></span><img style="cursor:hand;" onclick="'+trace_log+'__close_tips_block();__sme_hightlight_msg();" src="'+imgIngoreChat+'" border="0"></td>';
	content[i++] = "</tr><tr>";

	if(""==__SME_PROBE_CUSTOM_PARAMS.phone400Number){
	} else {
		content[i++] = "<td colspan='2' align='right'><table style='width:95%; margin-right:14px;'><tr>";
		content[i++] = "<td style='text-align:right; background:url("+imgLineBg+") repeat-x 0 6px; color:"+__SME_CLIENT_VAR.phoneBarTdColor+"; padding:10px 0 4px 0;";
    	if("zh_cn" == language){
        	content[i++] = "font-size:12px;'><img style='display:left;' src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/tel.gif' alt='&#20225;&#19994;&#24635;&#26426;' /><i style='font-style:normal; font-size:11px; font-family:Verdana; color:"+__SME_CLIENT_VAR.phoneFontColor+"; font-weight:bold; margin-left:3px;'>"+__SME_PROBE_CUSTOM_PARAMS.phone400Number+"</i>&nbsp;&nbsp;&nbsp;&nbsp;"+__SME_CLIENT_VAR.phoneCnTitleEnd+"</td>";
        }else{
        	content[i++] = "font-size:12px;'><img style='display:left;' src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/tel.gif' alt='Hotline' /><i style='font-style:normal; font-size:11px; font-family:Verdana; color:"+__SME_CLIENT_VAR.phoneFontColor+"; font-weight:bold; margin-left:3px;'>"+__SME_PROBE_CUSTOM_PARAMS.phone400Number+"</i></td>";
        }
	}
	content[i++] = "</tr></table></td></tr></table>";
	div.innerHTML = content.join("");
	var isIe = /msie/i.test(navigator.userAgent);
	if(""==__SME_PROBE_CUSTOM_PARAMS.phone400Number){
		if (isIe) {
			spDiv.innerHTML = "<iframe style='position:absolute;z-index:61344;width:421px;height:138px;top:expression(this.nextSibling.offsetTop);left:expression(this.nextSibling.offsetLeft);filter:Alpha(opacity=0);' frameborder='0' scrolling='no'></iframe>";
    	} else {
			spDiv.innerHTML = "<iframe style='position:absolute;z-index:61344;width:421px;height:138px;top:-100px;left:-400px;filter:Alpha(opacity=0);' frameborder='0' scrolling='no'></iframe>";
    	}
	} else {
		if (isIe) {
			spDiv.innerHTML = "<iframe style='position:absolute;z-index:61344;width:421px;height:158px;top:expression(this.nextSibling.offsetTop);left:expression(this.nextSibling.offsetLeft);filter:Alpha(opacity=0);' frameborder='0' scrolling='no'></iframe>";
    	} else {
			spDiv.innerHTML = "<iframe style='position:absolute;z-index:61344;width:421px;height:158px;top:-100px;left:-400px;filter:Alpha(opacity=0);' frameborder='0' scrolling='no'></iframe>";
    	}
	}
	spDiv.appendChild(div);
	document.body.insertBefore(spDiv, document.body.firstChild);
}

function __sme_hightlight_msg(){
	document.getElementById("__sme_msgFromServer").style.background = "background-image: url('http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/ww_alert_011_eng.gif')";
	document.getElementById("__sme_msgFromServer").style.background = "background-image: url('http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_2_bg.gif')  bottom";

}

function __adjust_tips_block(winId, width, height, url, language) {
	var tip_div = document.getElementById("__tips_block");
	if(!tip_div) {
		__create_tips_block(winId, width, height, url, language);
	}
	var obj = _get_scrollValue();
	tip_div.style.left =  obj.scrollLeftValue + (document.body.clientWidth - 495) / 2 + "px";
	tip_div.style.top =  obj.scrollTopValue + 118 + "px";
	__isInvoke_tipsblock = false;
}

function __close_tips_block() {
	var div = document.getElementById("__parent_tips_block");
	if (div) {
		div.style.display = 'none';
	}
	__tips_closed = true;
}
function __remove_tips_block() {
	var div = document.getElementById("__parent_tips_block");
	if (div) {
		div.parentNode.removeChild(div);
	}
	__tips_closed = false;
}
function _get_scrollValue(){
	var scrollLeftValue = 0 ;
	var scrollTopValue = 0 ;
	var obj = new Object();
	if (typeof window.pageYOffset != 'undefined') {
	  scrollLeftValue = window.pageXOffset;
	  scrollTopValue = window.pageYOffset;
	}
	else if (typeof document.compatMode != 'undefined' &&
		document.compatMode != 'BackCompat') {
		scrollLeftValue = document.documentElement.scrollLeft;
		scrollTopValue = document.documentElement.scrollTop;
	}
	else if (typeof document.body != 'undefined') {
		scrollLeftValue = document.body.scrollLeft;
		scrollTopValue = document.body.scrollTop;
	}else{
		scrollLeftValue = 0 ;
		scrollTopValue = 0 ;
	}
	obj.scrollLeftValue = scrollLeftValue;
	obj.scrollTopValue = scrollTopValue;
	return obj;
}
function __auto_scroll(left, top, iconUrl, language, img) {
	var varDiv = document.getElementById("__service_panel");
	if(!varDiv) {
		__create_service_panel(left, top, iconUrl, language, img);
		return ;
	}
	var obj = _get_scrollValue();
	if ( __SME_PROBE_CUSTOM_PARAMS.horizontalAlign == "1" ) {
    		varDiv.style.left = __SME_PROBE_CUSTOM_PARAMS.styleLeft + obj.scrollLeftValue + "px";
    		varDiv.style.top = __SME_PROBE_CUSTOM_PARAMS.styleTop + obj.scrollTopValue + "px";
	} else {
		varDiv.style.left = "auto";
			varDiv.style.right = __SME_PROBE_CUSTOM_PARAMS.styleRight + obj.scrollLeftValue + "px";
    		varDiv.style.top = __SME_PROBE_CUSTOM_PARAMS.styleTop + obj.scrollTopValue + "px";
	}
	 __isInvoke_servicePanel = false;
}
function __create_service_panel(left, top, iconUrl, language,img) {
	if (!document.getElementById("__service_panel")) {
		var spDiv = document.createElement("div");
		var div = document.createElement("div");
		div.id = "__service_panel";
		div.style.display = "none";
		spDiv.style.width = 0;
		spDiv.style.height = 0;
		spDiv.style.border = "none";
		
		div.style.width = 130;
		var obj = _get_scrollValue();
		if ( __SME_PROBE_CUSTOM_PARAMS.horizontalAlign == "1" ) {
    		div.style.left = __SME_PROBE_CUSTOM_PARAMS.styleLeft + obj.scrollLeftValue + "px";
    		div.style.top = __SME_PROBE_CUSTOM_PARAMS.styleTop + obj.scrollTopValue + "px";
		} else {
		div.style.left="auto";
			div.style.right = __SME_PROBE_CUSTOM_PARAMS.styleRight + obj.scrollLeftValue + "px";
    		div.style.top = __SME_PROBE_CUSTOM_PARAMS.styleTop + obj.scrollTopValue + "px";
		}
		spDiv.width = 411;
		div.style.clear = "both";
		div.style.position = "absolute";
		div.style.zIndex = 62345;
		div.style.overflow = 'hidden';
		div.innerHTML=__get_custom_panel_html(iconUrl, language, img);
		var isIe = /msie/i.test(navigator.userAgent);
		if (isIe) {
    	spDiv.innerHTML = "<iframe style='position:absolute;z-index:62344;width:expression(this.nextSibling.offsetWidth);height:expression(this.nextSibling.offsetHeight);top:expression(this.nextSibling.offsetTop);left:expression(this.nextSibling.offsetLeft);filter:Alpha(opacity=0);' frameborder='0' scrolling='no' src='" + __getRecognizeSrc() + "'></iframe>";
    	} else {
		spDiv.innerHTML = "<iframe style='position:absolute;z-index:62344;width:100px;height:100px;top:-400px;left:-400px;filter:Alpha(opacity=0);' frameborder='0' scrolling='no' src='" + __getRecognizeSrc() + "'></iframe>";
		}
		spDiv.appendChild(div);
		document.body.insertBefore(spDiv, document.body.firstChild);
		if (__SME_PROBE_CUSTOM_PARAMS.hasProductClass!=__SME_STATIC.NO) {
			_sme_ww_getOnlineStatus(__SME_PROBE_CUSTOM_PARAMS.serverWWIdList);
		}
	}
}

function __getRecognizeSrc() {
    if(__SME_PROBE_CUSTOM_PARAMS.hasRoleDoDiscern=="true"){
	return  "http://cn.alisoft.com/sme/im/recognize!showRecognize.jspa?siteId="+_sme_site_id+"&ts=" + new Date().getTime() + "&visitorId=" + __get_cookie_map(__COOKIE_PERM)[__C_P_USER];
    }
	return ;
}

function setColorVarByColorStyle(colorStyle) {
if(colorStyle=="blue"){
__SME_CLIENT_VAR.borderColor="#83bbd9";
__SME_CLIENT_VAR.phoneFontColor = "#2b6aa8";
__SME_CLIENT_VAR.phoneBarTdColor = "#6294c5";
__SME_CLIENT_VAR.scrollBarCSS = "scrollbar-face-color: #DBEBFE; scrollbar-shadow-color: #B8D6FA; scrollbar-highlight-color: #FFFFFF; scrollbar-3dlight-color: #DBEBFE; scrollbar-darkshadow-color:#458CE4; scrollbar-track-color: #FFFFFF; scrollbar-arrow-color: #458CE4;";
}else if(colorStyle=="red"){
__SME_CLIENT_VAR.borderColor="#ff8989";
__SME_CLIENT_VAR.phoneFontColor = "#d62121";
__SME_CLIENT_VAR.phoneBarTdColor = "#6294c5";
__SME_CLIENT_VAR.scrollBarCSS = "scrollbar-face-color: #ffdddc; scrollbar-shadow-color: #ffdddc; scrollbar-highlight-color: #fff3f3; scrollbar-3dlight-color: #ffcfcf; scrollbar-darkshadow-color:#ff4d4d; scrollbar-track-color: #FFFFFF; scrollbar-arrow-color: #ff4d4d;";
}else if(colorStyle=="green"){
__SME_CLIENT_VAR.borderColor="#a2d52a";
__SME_CLIENT_VAR.phoneFontColor = "#608900";
__SME_CLIENT_VAR.phoneBarTdColor = "#6294c5";
__SME_CLIENT_VAR.scrollBarCSS = "scrollbar-face-color: #e2f3a6; scrollbar-shadow-color: #e2f3a6; scrollbar-highlight-color: #f4fff1; scrollbar-3dlight-color: #e1ff71; scrollbar-darkshadow-color:#93b839; scrollbar-track-color: #FFFFFF; scrollbar-arrow-color: #93b839;";
}else if(colorStyle=="grey"){
__SME_CLIENT_VAR.borderColor = "#cccccc";
__SME_CLIENT_VAR.phoneFontColor = "#666666";
__SME_CLIENT_VAR.phoneBarTdColor = "#6294c5";
__SME_CLIENT_VAR.scrollBarCSS = "scrollbar-face-color: #ffffff; scrollbar-shadow-color: #aaaaaa; scrollbar-highlight-color: #ffffff; scrollbar-3dlight-color: #f2f2f2; scrollbar-arrow-color: #9999cc; scrollbar-track-color: #ffffff; scrollbar-darkshadow-color: #f2f2f2;";
}else{
__SME_CLIENT_VAR.borderColor = "#e1b283";
__SME_CLIENT_VAR.phoneFontColor = "#ff6600";
__SME_CLIENT_VAR.phoneBarTdColor = "#6294c5";
__SME_CLIENT_VAR.scrollBarCSS = "scrollbar-face-color: #ffd5a2; scrollbar-shadow-color: #ffd5a2; scrollbar-highlight-color: #fff3e1; scrollbar-3dlight-color: #ffe8ca; scrollbar-darkshadow-color: #ff7c00; scrollbar-track-color: #FFFFFF; scrollbar-arrow-color: #ff7c00;";
}
}

function minSmeProbePanel(){
document.getElementById("__"+__SME_CLIENT_VAR.language+"SmeMinPanel").style.display="";
document.getElementById("__"+__SME_CLIENT_VAR.language+"SmeMaxPanel").style.display="none";
}

function maxSmeProbePanel(){
document.getElementById("__"+__SME_CLIENT_VAR.language+"SmeMinPanel").style.display="none";
document.getElementById("__"+__SME_CLIENT_VAR.language+"SmeMaxPanel").style.display="";
}

function __get_custom_panel_html(iconUrl, language, img) {
	var tempHtmlCode = "";
	setColorVarByColorStyle(__SME_PROBE_CUSTOM_PARAMS.colorStyle);

	if (language==__SME_STATIC.ZH_CN) {
		tempHtmlCode="<table id='__zh_cnSmeMinPanel' border='0' cellpadding='0' cellspacing='0' style='display:none;'><tr><td><img style='cursor:hand;' src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_chn_a_00.gif' border='0' alt='' onClick='maxSmeProbePanel()' /></td></tr></table>"
		tempHtmlCode += "<table border='0' id='__zh_cnSmeMaxPanel' cellpadding='0' cellspacing='0' style='width:130px;  text-align:left; padding:0; word-break:break-all; line-height:14px;letter-spacing:0px;'>"
			+"<tr>";
	} else {
		tempHtmlCode="<table id='__en_usSmeMinPanel' border='0' cellpadding='0' cellspacing='0' style='display:none;'><tr><td><img style='cursor:hand;' src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_eng_a_00.gif' border='0' alt='' onClick='maxSmeProbePanel()' /></td></tr></table>";
		tempHtmlCode += "<table id='__en_usSmeMaxPanel' border='0' cellpadding='0' cellspacing='0' style='width:130px;  text-align:left; padding:0; font-family:Verdana, Arial, Helvetica, sans-serif; word-break:break-all; line-height:14px;letter-spacing:0px;'>"
			+"<tr>";
	}
     var tempString1 = "";
	if (__SME_PROBE_CUSTOM_PARAMS.iconOrder == "-1" || __SME_PROBE_CUSTOM_PARAMS.iconOrder == "2" || __SME_PROBE_CUSTOM_PARAMS.iconOrder == "3" || __SME_PROBE_CUSTOM_PARAMS.iconOrder == "4") {
		tempString1 = "<td style='background:url(http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_chn_c_00.gif) 0 0; text-align:right; height:16px; padding:0 8px 0 0;'><img style='cursor:hand;' src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_minimize.gif' border='0' onClick='minSmeProbePanel()' /></td></tr><tr>"
		tempString1 += "<td  style='background:url(http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_chn_c_01.gif) bottom;";
		if ( language == __SME_STATIC.ZH_CN) {
		tempString1+="overflow:hidden; display:block;";
		} else {
		}
		tempString1+=" text-align:center; padding:0 0 5px;'>";
		if(__SME_PROBE_CUSTOM_PARAMS.iconOrder == "-1"){
			tempString1+="<img onclick='__atatIconClick();__launch_contact(\"visitor\", \""+language+"\", \""+img+"\", \"\", \"\")'  style='cursor:hand' src='"+__SME_PROBE_CUSTOM_PARAMS.probeHeadPic+"' width='120' height='120' border='0' /></td></tr>";
		}else if(__SME_PROBE_CUSTOM_PARAMS.iconOrder == "2"){
			tempString1+="<img onclick='__atatIconClick();__launch_contact(\"visitor\", \""+language+"\", \""+img+"\", \"\", \"\")'  style='cursor:hand' src='http://cnimg.alisoft.com//images/tel_pic_1.jpg' width='120' height='120' border='0' /></td></tr>";
		}else if(__SME_PROBE_CUSTOM_PARAMS.iconOrder == "3") {
			tempString1+="<img onclick='__atatIconClick();__launch_contact(\"visitor\", \""+language+"\", \""+img+"\", \"\", \"\")'  style='cursor:hand' src='http://cnimg.alisoft.com//images/tel_pic_2.jpg' width='120' height='120' border='0' /></td></tr>";
		}else if(__SME_PROBE_CUSTOM_PARAMS.iconOrder == "4") {
			tempString1+="<img onclick='__atatIconClick();__launch_contact(\"visitor\", \""+language+"\", \""+img+"\", \"\", \"\")'  style='cursor:hand' src='http://cnimg.alisoft.com//images/tel_pic_3.jpg' width='120' height='120' border='0' /></td></tr>";
		}
	} else if (__SME_PROBE_CUSTOM_PARAMS.iconOrder == "0") {
		tempString1 = "<td"
		+ " style='cursor:hand; background:url(http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_chn_s_01.gif)  0 0; text-align:right; height:26px; padding:0 8px 0 0;'><img style='cursor:hand;' src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_minimize.gif' border='0' onClick='minSmeProbePanel()' /></td></tr>";
	} else {
		tempString1 = "<td"
		+ " style='cursor:hand; background:url(http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_chn_l_01.gif)  0 0; text-align:right; height:26px; padding:0 8px 0 0;'><img style='cursor:hand;' src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_minimize.gif' border='0' onClick='minSmeProbePanel()' /></td></tr>";

		tempString1 += "<tr><td onclick='__launch_contact(\"visitor\", \""+language+"\", \""+img+"\", \"\", \"\")' style='width:110px;cursor:hand; background:url(http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_chn_l_02.gif) bottom; "
			+"text-align:left; padding:2px 10px 10px; color:#333;";

		if (language==__SME_STATIC.ZH_CN) {
			tempString1+= "font-size:12px;'>";
		} else {
			tempString1+= "font-size:10px;overflow:hidden; display:block;'>";
		}
           tempString1 +="" + __SME_PROBE_CUSTOM_PARAMS.probeHeadText + "</td></tr>";
    }
    tempHtmlCode += tempString1;

	var __picMiddle = "";
	var __textFieldInitCode = "";
	var __fontSize = "";
    if (language==__SME_STATIC.ZH_CN) {
		__picMiddle = "chn";
		__textFieldInitCode = __SME_CLIENT_VAR.visitorInputInitCodeCN;
		__fontSize = "12";
	} else {
		__picMiddle = "eng";
		__textFieldInitCode = __SME_CLIENT_VAR.visitorInputInitCodeEN;
		__fontSize = "12";
	}
		tempHtmlCode += "<tr>"
			+"<td style='background:url(http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_chn_s_02.gif) bottom; line-height:14px; letter-spacing:0px; padding:5px 0 7px;'>"
			+"<table id='__sme_msgFromServerTable' style='display:none; line-height:14px;' width='118' border='0' cellspacing='0' cellpadding='0' align='center'>"
            +"<tr>"
            +"<td><img src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_"+__picMiddle+"_s_031.gif' width='118' height='16'></td>"
            +"</tr>"
            +"<tr>"
			+"<td>"
			+"<div id='__sme_msgFromServer' style='OVERFLOW-x:hidden;OVERFLOW-y:auto;WIDTH:120px;HEIGHT:80px;cursor:hand; border:"+__SME_CLIENT_VAR.borderColor+" solid 1px; border-top:none;font-size:12px;" + __SME_CLIENT_VAR.scrollBarCSS
			+" background:url(http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_2_bg.gif)  bottom; font-size:12px; text-align:left"
			+"padding:6px 4px; color:#333; overflow:hidden; display:block;' onclick='__launch_contact(\"visitor\", \""+language+"\", \""+img+"\", \"\", \"\")'></div>"
			+"</td>"
            +"</tr>"
            +"</table>"
            +"<table id='__sme_visitorWelcomeTable' width='118' border='0' cellspacing='0' cellpadding='0' align='center'>"
            +"    <tr style='cursor:hand'>"
            +"        <td ><img style='cursor:hand;' onclick='__launch_contact(\"visitor\", \""+language+"\", \""+img+"\", \"\", \"\")'  src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_"+__picMiddle+"_s_03.gif' width='118' height='16'></td>"
            +"    </tr>"
            +"</table>"
            +"<table id='__sme_visitorTextFieldTable' border='0' cellspacing='0' cellpadding='0' align='center' style='line-height:0px;width:118px; font-size:12px; text-align:left; padding:0; margin-top:4px;letter-spacing:0px;'>"
            +"    <tr>"
            +"        <td style='border:"+__SME_CLIENT_VAR.borderColor+" solid 1px;' valign='baseline'><textarea onBlur='__sme_restore_content(this);'"
			+" onFocus='__sme_clear_content(this)' onKeyDown='__sme_check_content(this, 30)' onKeyUp='__sme_check_content(this, 30)'"
			+"onChange='__sme_check_content(this, 30)' id='__sme_visitorTextField' style='visibility:visible;font-family:Arial;font-size:"+__fontSize+"px; width:116px;"
			+" height:36px; border:none; overflow-x:hidden; overflow-y:auto; padding:3px 4px; color:#888'>"+__textFieldInitCode+"</textarea></td>"
            +"    </tr>"
            +"    <tr>";

		if (language==__SME_STATIC.ZH_CN) {
			tempHtmlCode += "<td style='text-align:right;'>"
				+"<img style='cursor:hand;' id='aliserv' onclick='__launch_contact(\"visitor\", \""+language+"\", \""+img+"\", \"\", \"1\");' src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_chn_s_04.gif'"
				+" width='73' height='22' border='0'></td></tr>";
				if (""==__SME_PROBE_CUSTOM_PARAMS.phone400Number) {
					tempHtmlCode += "</table>";
				} else {
    				tempHtmlCode += "<tr><td style='text-align:center; background:url(http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_line_bg.gif) repeat-x 0 6px; color:"+__SME_CLIENT_VAR.phoneBarTdColor
    				+"; padding:10px 0 0 0 ;'><img src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/tel.gif' />"
    				+"<i style='font-style:normal; font-size:11px; font-family:Verdana;"
    				+" color:"+__SME_CLIENT_VAR.phoneFontColor+"; font-weight:bold; margin-left:3px;'>"+__SME_PROBE_CUSTOM_PARAMS.phone400Number+"</i></td></tr></table>"
				}
		} else {
			tempHtmlCode += "<td style='text-align:right;'>"
			+"<img style='cursor:hand;' onclick='__launch_contact(\"visitor\", \""+language+"\", \""+img+"\", \"\", \"1\")' src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_eng_s_04.gif'"
			+" width='73' height='22' border='0'></td></tr>";
			if (""==__SME_PROBE_CUSTOM_PARAMS.phone400Number) {
					tempHtmlCode += "</table>";
				} else {
					tempHtmlCode += "<tr><td style='text-align:center; background:url(http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_line_bg.gif) repeat-x 0 6px; color:"+__SME_CLIENT_VAR.phoneBarTdColor
    				+"; padding:10px 0 0 0 ;'><img src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/tel.gif' />"
    				+"<i style='font-style:normal; font-size:11px; font-family:Verdana;"
    				+" color:"+__SME_CLIENT_VAR.phoneFontColor+"; font-weight:bold; margin-left:3px;'>"+__SME_PROBE_CUSTOM_PARAMS.phone400Number+"</i></td></tr></table>"
				}
		}
	if (__SME_PROBE_CUSTOM_PARAMS.hasProductClass==__SME_STATIC.NO) {
    	tempHtmlCode += "</table>";
    } else {
    	tempHtmlCode += "<tr><td style='background:url(http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/e_net_1_02.png) no-repeat bottom;'>";
		if (language==__SME_STATIC.ZH_CN) {
			tempHtmlCode +="<div style='width:22px; float:left; margin-left:3px; display:inline;'><img src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_chn_nav.gif'></div>";
		} else {
			tempHtmlCode += "<div style='width:22px; float:left; margin-left:3px; display:inline;'><img src='http://cnimg.alisoft.com//images/"+__SME_PROBE_CUSTOM_PARAMS.colorStylePicPath+"/enet_eng_nav.gif'></div>"
		}
		tempHtmlCode += "<ul style='width:85px;  float:left; font-size:12px; text-align:left;height:auto;margin:10px 0px 10px 5px; list-style:none; padding:0; overflow-x:hidden;'>";
    	tempHtmlCode += __SME_PROBE_CUSTOM_PARAMS.productLabels+"</ul></td></tr>" + "</table>";
    }
	return tempHtmlCode;
}

var __is_first_focus = true;
function __sme_clear_content(obj) {
	if (!__SME_CLIENT_VAR.hasChanged) {
		__SME_CLIENT_VAR.hasChanged = true;
	}
	if(__is_first_focus){
		obj.value="";
		document.getElementById("__sme_visitorTextField").style.color="#000";
		__is_first_focus=false;
	}
}

function __sme_restore_content(obj) {
	if (obj.value == "") {
		if (__SME_PROBE_CUSTOM_PARAMS.language == __SME_STATIC.ZH_CN) {
			obj.innerHTML = __SME_CLIENT_VAR.visitorInputInitCodeCN;
		} else {
			obj.innerHTML = __SME_CLIENT_VAR.visitorInputInitCodeEN;
		}
		obj.style.color = "#888";
		__is_first_focus=true;
	}
}

function __sme_check_content(obj, length) {
	if (obj.value.length > length) {
		obj.value = obj.value.substring(0, length);
	}
}

function __updateMsgFromServer(wwId, msg1, msg2, visitorId, offlineMsgFlag, contactType) {
	document.getElementById("__sme_msgFromServerTable").style.display = "";
	document.getElementById("__sme_visitorWelcomeTable").style.display = "none";
	document.getElementById("__sme_msgFromServer").innerHTML = msg2;
	__SME_PROBE_CUSTOM_PARAMS.msgFromServer = msg2;
	__SME_PROBE_CUSTOM_PARAMS.msgFromServerPostToWebim = encodeURIComponent(msg1);
	maxSmeProbePanel();
	if ( __SME_CLIENT_VAR.openedWebIm == null || __SME_CLIENT_VAR.openedWebIm.closed ) {
		__SME_CLIENT_VAR.wwId = wwId;
		__SME_CLIENT_VAR.visitorId = visitorId;
		__SME_CLIENT_VAR.offlineMsgFlag = offlineMsgFlag;
		__SME_CLIENT_VAR.contactType = offlineMsgFlag;
		__SME_CLIENT_VAR.ct = "2";
		__remove_tips_block();
		window.focus();
		__open_ww(visitorId, wwId, offlineMsgFlag, contactType);
	} else {
		__SME_CLIENT_VAR.openedWebIm.focus();
	}
	__sme_hightlight_msg();
}

var __isInvoke_servicePanel = false;
function __show_service_panel(left, top, iconUrl, language, img, paramsObject) {
	__SME_PROBE_CUSTOM_PARAMS = paramsObject;
	__SME_CLIENT_VAR.language=language;
	__create_service_panel(left, top, iconUrl, language, img);
	if (__SME_PROBE_CUSTOM_PARAMS.isScrollable == __SME_STATIC.YES) {
		__attach_event("scroll", function() {
			if (!__isInvoke_servicePanel) {
				__isInvoke_servicePanel = true;
				setTimeout("__auto_scroll(" + left + ", " + top + ", '" + iconUrl + "', '" + language + "', '" + img + "')", 10);
    		}
    	});
		__attach_event("resize", function() {
			if (!__isInvoke_servicePanel) {
				__isInvoke_servicePanel = true;
				setTimeout("__auto_scroll(" + left + ", " + top + ", '" + iconUrl + "', '" + language + "', '" + img + "')", 10);
    		}
		});
		window.setTimeout("__create_service_panel("+left+", "+top+", '"+iconUrl+"', '"+language+"', '"+img+"')", 3000);
	}
}

function __detect_im() {
	return null;// TODO
	try {
		var im = new ActiveXObject("AlitalkSetup.Install");
		if (im != null) {
			delete im;
			return "Alitalk";
		}
	} catch (e) { }

	try {
		var im = new ActiveXObject("WangWangX.WangWangObj");
		if (im != null) {
			delete im;
			return "WangWang";
		}
	} catch (e) { }
	return null;
}

function __open_im(im, to) {
	var url;
	if (im == "Alitalk") {
		url = im + ":SendIM?" + to.substring(8);
	} else {
		url = im + ":SendIM?tositeid=cnalichn&uid=" + to.substring(8);
	}
	__open_iframe("__iframe_im", url);
}

function __open_iframe(frmId, url) {
	var frm = document.getElementById(frmId);
	if (frm == null) {
		frm = document.createElement("iframe");
		frm.id = frmId;
		frm.style.display = "none";
		document.body.appendChild(frm);
	}

	frm.src = url;
}
function _subStringUrl(varUrl){
		if(varUrl!=null&&varUrl.indexOf("http://")>-1){
			varUrl =  varUrl.substring(varUrl.indexOf("http://")+7,varUrl.length-1);
			if(varUrl.indexOf("/")>-1)return varUrl.substring(0,varUrl.indexOf("/"));
			else if(varUrl.indexOf("\\")>-1)return varUrl.substring(0,varUrl.indexOf("\\"));
			else return varUrl;
		}
		else return varUrl;
}
function _subStringTitle(titleStr,strNum){
	if(titleStr==null||titleStr.length==0)return "";
	else if(titleStr.length>strNum) return titleStr.substring(0,strNum);
	else return titleStr;
}
var __COOKIE_PERM = "__ENET_PERM";
var __COOKIE_TMP = "__ENET_TMP";

var __C_P_USER = "user";
var __C_P_VISIT_COUNT = "visit_count";
var __C_P_STAY_TIME = "stay_time";
var __C_P_LAST_CONTACT = "last_contact";

var __C_T_PAGES = "pages";
var __C_T_CONTACT_FLAGS = "contact_flags";
var __C_T_SESSION_START = "session_start";
var __C_T_STAY_TIME = "stay_time";

var __F_RULE_TRIGGERED = 0x01;
var __C_T_RULED_FLAGS = 0x01;

if (window.ActiveXObject) var __IE = window[window.XMLHttpRequest ? 'ie7' : 'ie6'] = true;
function __domReady(fn) {
	if (__domReady.done){
		fn.call(this);
		return;
	}
	if (document.readyState && __IE){
		if (!document.getElementById('ie_ready')){
			var src = (window.location.protocol == 'https:') ? '://0' : 'javascript:void(0)';
			document.write('<script id="ie_ready" defer src="' + src + '"><\/script>');
			document.getElementById('ie_ready').onreadystatechange = function(){
				if (this.readyState == 'complete') {
					__domReady.done = true;
					__domReady(fn);
				}
			};
		}
	} else {
		__attach_event("load", function () { __domReady.done = true; __domReady(fn); });
		__attach_event("DOMContentLoaded", function () { __domReady.done = true; __domReady(fn); });
	}
}
/**
  * site, The ID of the company.
  * language, The language version of WebIm.
  * img, The img url at the top right of WebIm.
  */
var _sme_site_id = "";
function __launch_probe(site, language) {
if (_sme_site_id != "") {
return ;
}
_sme_site_id = site;
	__domReady(function() {
		var url = "http://cn.alisoft.com/sme/probe/probe.jspa?site=" + site;
		var user = __get_cookie_map(__COOKIE_PERM)[__C_P_USER];
		if (user) {
			url += "&user=" + user;
		} else {
			url += "&ts=" + new Date().getTime();
		}
		url+="&img=0&requestDomain="+encodeURIComponent(document.domain) + "&lang=" + (language==null?"zh_cn":language);
		__do_request(null, url);
	});
}

function __atatIconClick(){
	__do_tracelog('http://e.alisoft.com/portal/sme/statistics.html?tracelog=alisoft_enet_webim_icon_click&ts=' + new Date().getTime());
}

function __statInvitedAccepted(){
	__do_tracelog('http://e.alisoft.com/portal/sme/statistics.html?tracelog=alisoft_enet_webim_invited_accepted&ts=' + new Date().getTime());
}

var __enet_SocialHistory = function( moreSites ){
var sites = {};
for( var site in moreSites ) {
if( typeof( sites[site] ) == "undefined" ) sites[site] = [];
if( typeof( moreSites[site] ) == "string" )
sites[site].push( moreSites[site] );
else
sites[site] = sites[site].concat( moreSites[site] );
}
var visited = {};
function getStyle(el, scopeDoc,styleProp) {
if (el.currentStyle)
var y = el.currentStyle[styleProp];
else if (window.getComputedStyle)
var y = scopeDoc.defaultView.getComputedStyle(el,null).getPropertyValue(styleProp);
return y;
}
function remove( el ) {
el.parentNode.removeChild( el );
}
function createIframe() {
var iframe = document.createElement("iframe");
iframe.style.position = "absolute";
iframe.style.visibility = "hidden";
document.body.appendChild(iframe);
if(iframe.contentDocument) iframe.doc = iframe.contentDocument;
else if(iframe.contentWindow) iframe.doc = iframe.contentWindow.document;
iframe.doc.open();
iframe.doc.write('<style>');
iframe.doc.write("a{color: #000000; display:none;}");   
iframe.doc.write("a:visited {color: #FF0000; display:inline;}");        
iframe.doc.write('</style>');
iframe.doc.close();
return iframe;
}  
var iframe = createIframe();
function embedLinkInIframe( href, text ) {
var a = iframe.doc.createElement("a");
a.href = href;
a.innerHTML = site;
iframe.doc.body.appendChild( a );
}
for( var site in sites ) {
var urls = sites[site];
for( var i=0; i<urls.length; i++ ) {
embedLinkInIframe( urls[i], site );
if( urls[i].match(/www\./) ){
var sansWWW = urls[i].replace(/www\./, "");
embedLinkInIframe( sansWWW, site );
} else {
var httpLen = urls[i].indexOf("//") + 2;
var withWWW = urls[i].substring(0, httpLen ) + "www." + urls[i].substring( httpLen );
embedLinkInIframe( withWWW, site );
}
}
}
var links = iframe.doc.body.childNodes;
for( var i=0; i<links.length; i++) {
var displayValue = getStyle(links[i], iframe.doc, "display");
var didVisit = displayValue != "none";
if( didVisit ){
visited[ links[i].innerHTML ] = true;
}
}
remove( iframe );
return new (function(){
var usedSites = [];
for( var site in visited ){
usedSites.push( site );
}
this.visitedSites = function() {
return usedSites;
}
this.doesVisit = function( site ) {
if( typeof( sites[site] ) == "undefined" )
return -1;
return typeof( visited[site] ) != "undefined";
}
var checkedSites = [];
for( var site in sites ){
checkedSites.push(site);
}
this.checkedSites = function(){
return checkedSites;
}
})();
}
