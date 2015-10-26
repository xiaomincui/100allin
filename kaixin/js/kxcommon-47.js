

typeof window=="undefined"&&(window={});var Kx=window.Kx||{};function getpos(element)
{if(arguments.length!=1||element==null)
{return null;}
var elmt=element;var offsetTop=elmt.offsetTop;var offsetLeft=elmt.offsetLeft;var offsetWidth=elmt.offsetWidth;var offsetHeight=elmt.offsetHeight;while(elmt=elmt.offsetParent)
{if(elmt.style.position=='absolute'||(elmt.style.overflow!='visible'&&elmt.style.overflow!=''))
{break;}
offsetTop+=elmt.offsetTop;offsetLeft+=elmt.offsetLeft;}
return{top:offsetTop,left:offsetLeft,right:offsetWidth+offsetLeft,bottom:offsetHeight+offsetTop};}
function b_strlen(fData)
{var intLength=0;for(var i=0;i<fData.length;i++)
{if((fData.charCodeAt(i)<0)||(fData.charCodeAt(i)>255))
intLength=intLength+2;else
intLength=intLength+1;}
return intLength;}
function b_subString(str,len)
{var strlen=0;var s="";for(var i=0;i<str.length;i++)
{if(str.charCodeAt(i)>128)
{strlen+=2;}
else
{strlen++;}
if(strlen>len)
{return s;}
s+=str.charAt(i);}
return s;}
function IsIE()
{return document.all?true:false;}
function copy_clip(text2copy)
{if(window.clipboardData)
{window.clipboardData.setData("Text",text2copy);}
else
{var flashcopier='flashcopier';if(!document.getElementById(flashcopier))
{var divholder=document.createElement('div');divholder.id=flashcopier;document.body.appendChild(divholder);}
document.getElementById(flashcopier).innerHTML='';var divinfo='<embed src="http://img1.kaixin001.com.cn/i/_clipboard.swf" FlashVars="clipboard='+escape(text2copy)+'" width="0" height="0" type="application/x-shockwave-flash"></embed>';document.getElementById(flashcopier).innerHTML=divinfo;}
return true;}
function copyToClipboard(txt)
{if(window.clipboardData)
{window.clipboardData.clearData();window.clipboardData.setData("Text",txt);}
else if(navigator.userAgent.indexOf("Opera")!=-1)
{window.location=txt;}
else if(window.netscape)
{try
{netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");}
catch(e)
{alert("您的firefox安全限制限制您进行剪贴板操作，请打开'about:config'将signed.applets.codebase_principal_support'设置为true'之后重试");return false;}
var clip=Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);if(!clip)
return false;var trans=Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);if(!trans)
return false;trans.addDataFlavor('text/unicode');var str=new Object();var len=new Object();var str=Components.classes['@mozilla.org/supports-string;1'].createInstance(Components.interfaces.nsISupportsString);var copytext=txt;str.data=copytext;trans.setTransferData("text/unicode",str,copytext.length*2);var clipid=Components.interfaces.nsIClipboard;if(!clip)
return false;clip.setData(trans,null,clipid.kGlobalClipboard);}
return true;}
function _commentImageResize(thisobj,limit)
{if(thisobj.width>limit)
{thisobj.height=parseInt(limit*thisobj.height/thisobj.width);thisobj.width=limit;}}
String.prototype.trim=function()
{return this.replace(/(^[\s]*)|([\s]*$)/g,"");}
String.prototype.lTrim=function()
{return this.replace(/(^[\s]*)/g,"");}
String.prototype.rTrim=function()
{return this.replace(/([\s]*$)/g,"");}
function getDays(year,month)
{var dayarr=new Array(31,28,31,30,31,30,31,31,30,31,30,31);if(month==2)
{if((year%4==0&&year%100!=0)||year%400==0||year<1900)
return 29;else
return dayarr[month-1];}
else
{return dayarr[month-1];}}
function extractNodes(pNode)
{if(pNode.nodeType==3)
{return null;}
var node,nodes=new Array();for(var i=0;node=pNode.childNodes[i];i++)
{if(node.nodeType==1)
{nodes.push(node);}}
return nodes;}
function isArray(o)
{return Object.prototype.toString.call(o)==='[object Array]';}
function filterPng(img)
{var width=img.width;var height=img.height;var sizingMethod=(img.className.toLowerCase().indexOf("scale")>=0)?"scale":"image";img.runtimeStyle.filter="progid:DXImageTransform.Microsoft.AlphaImageLoader(src='"+img.src.replace('%23','%2523').replace("'","%27")+"', sizingMethod='"+sizingMethod+"')";img.src="http://img1.kaixin001.com.cn/i3/walls/l2_trans.gif";img.width=width;img.height=height;}
function filterPngs(obj)
{var arVersion=navigator.appVersion.split("MSIE")
var version=parseFloat(arVersion[1])
if((version>=5.5&&version<7.0)&&(document.body.filters))
{var images=obj.getElementsByTagName("img");for(var i=0;i<images.length;i++)
{var img=images[i];var imgName=img.src.toUpperCase();if(imgName.indexOf(".PNG")>0)
{filterPng(img);}}}}
function clickDirect(url,hash,full)
{if('function'==typeof(updateHash))
{if(full)
{return updateFullUri(url,hash);}
else
{if(hash)
{return updateHash(url);}
else
{return updateUri(url);}}}
else
{if(full)
{window.location=url+"#"+hash;}
else
{if(hash)
{window.location.hash=url;}
else
{window.location=url;}}
return false;}}
function getPageHash()
{var hash="";var urlparts=window.location.href.split("#");if(urlparts.length==2)
{hash=urlparts[1];if(hash.indexOf("url=")==0)
{var idx=hash.indexOf("hash=");hash=hash.substr(idx+5);}}
return hash;}
function setInnerHTML(el,html)
{if(isIE){html='<div style="display:none">for IE</div>'+html;el.innerHTML=html;execIt(el,"script");el.removeChild(el.firstChild);}
else{el.innerHTML=html;execIt(el,"script");}}
function execIt(el,stype)
{var bMoz=(navigator.appName=='Netscape');var bOpera=(navigator.appName=='Opera');if(stype=="script")
{stype=stype.toUpperCase();}
if(!el)return;var st="";st=el.getElementsByTagName(stype);var strExec;for(var i=0;i<st.length;i++)
{if(isIE||bOpera)
{strExec=st[i].text;st[i].text="";}
else if(bMoz)
{strExec=st[i].textContent;st[i].textContent="";}
else
{strExec=st[i].innerHTML;st[i].innerHTML="";}
try
{if(stype=="SCRIPT")
{var script=document.createElement("script");script.type="text/javascript";if((st[i].language&&st[i].language.toLowerCase()=='vbscript')||(st[i].type&&st[i].type.toLowerCase()=='text/vbscript'))
{script.type="text/vbscript";}
if(st[i].src)
{script.charset='UTF-8';script.src=st[i].src;}
else
{if(isIE)
{script.text=strExec;}
else
{script.innerHTML=strExec;}}
document.getElementsByTagName("head")[0].appendChild(script);}
else if(stype=="style")
{var ss=document.createElement('style');ss.type="text/css";ss.styleSheet.cssText=strExec;document.getElementsByTagName('head').item(0).appendChild(ss);}
else if(stype=="link")
{if(st[i].href)
{var link=document.createElement("link");link.rel="stylesheet";link.type="text/css";link.href=st[i].href;document.getElementsByTagName('head').item(0).appendChild(link);}}}
catch(e)
{}}};

(function(window){if(typeof(window.KxLoad)=="function")return;var loader=function(){};loader.prototype={queues:{js:{},css:{}},load:function(data,callback,context){if(!data.css)data.css=[];if(!data.js)data.js=[];if(!context)context=window;this.queueCSS(data.css,this.bind(function(){this.queueJS(data.js,this.bind(callback,context));}));},bind:function(func,context){context=context||this;return function(){func.apply(context,arguments);}},tagExists:function(type,src){var tagName="script";var attName="src";if(type=="css"){var tagName="link";var attName="href";}
var tag=document.createElement(tagName);tag[attName]=src;var tags=document.getElementsByTagName(tagName);for(var i=0;i<tags.length;i++){if(tag[attName]===tags[i][attName]){return true;}}
return false;},process:function(type,src){if(this.queues[type][src]["status"]=="init"){this.queues[type][src]["status"]="loading";this["get"+type.toUpperCase()].call(this,src);}
else if(this.queues[type][src]["status"]=="loaded")
{this.finish(type,src);}},finish:function(type,src){this.queues[type][src]["status"]="loaded";while(this.queues[type][src]["callbacks"].length>0){(this.queues[type][src]["callbacks"].shift())();}},queue:function(type,src,callback){if(!this.queues[type][src]){this.queues[type][src]={};this.queues[type][src]["callbacks"]=[];if(this.tagExists(type,src))this.queues[type][src]["status"]="loaded";else this.queues[type][src]["status"]="init";}
this.queues[type][src]["callbacks"].push(callback);this.process(type,src);},queueCSS:function(css_list,callback){var len=css_list.length;if(len>1){this.queue("css",css_list.shift(),this.bind(function(){this.queueCSS(css_list,callback);},this));}
else if(len==1){this.queue("css",css_list.shift(),callback);}
else
{callback();}},queueJS:function(js_list,callback){var len=js_list.length;if(len>1){this.queue("js",js_list.shift(),this.bind(function(){this.queueJS(js_list,callback);},this));}
else if(len==1){this.queue("js",js_list.shift(),callback);}
else
{callback();}},getHead:function(){if(!this.head){this.head=document.getElementsByTagName("head")[0]||document.documentElement;}
return this.head;},getJS:function(src){this.log("getJS: "+src);jQuery.getScript(src,this.bind(function(){this.finish("js",src);},this));},getCSS:function(src){this.log("getCSS: "+src);var link=document.createElement('link');link.setAttribute("href",src);link.setAttribute("rel","Stylesheet");link.setAttribute("type","text/css");this.getHead().appendChild(link);this.finish("css",src);},log:function(msg){}};var l=new loader();window.KxLoad=function(data,callback,context){return l.load(data,callback,context);};})(typeof window=="undefined"?this:window);var KxRequire=function(data,callback,scope){var ensure_data={js:[],css:[]};if(typeof(data)=="undefined"){data=[];}
else if(typeof(data)=="string"){data=[data];}
if(typeof(callback)=="undefined")
{callback=Prototype.emptyFunction;}
var has_kxversion=typeof(KxVersion)=="object";for(var i=0;i<data.length;i++){var parts=data[i].split(".");var type=parts[parts.length-1];var dst="http://localhost/kaixin/"+data[i];if(has_kxversion&&KxVersion[data[i]]){dst="http://localhost/kaixin/"+KxVersion[data[i]];}
if(type=="js"){ensure_data.js.push(dst);}
else if(type=="css"){ensure_data.css.push(dst);}}
KxLoad(ensure_data,callback,scope);};var KxLazyLoad=function(data,func){if(typeof(func)!="function"){Prototype.emptyFunction;}
jQuery(function(){KxRequire(data,func);});};var KxDeferredCall=function(data,funcname,args,context){var that=this;KxRequire(data,function(){return that[funcname].apply(context||this,args);});};var KxDeferredFunc=function(resouces,init_callback){var methods=_.toArray(arguments).slice(2);return function(){this.args=arguments;this.call_queue=[];for(var i=0,j=methods.length;i<j;i++){var method=methods[i];this[method]=function(){this.call_queue.push([method,arguments]);};}
this.run=function(){var wrapper;var callback_type=typeof(init_callback);if(callback_type=="string"){wrapper=window[init_callback].apply(window,this.args);}else if(callback_type=="function"){wrapper=init_callback.apply(window,this.args);}else{return;}
_.extend(this,wrapper);while(this.call_queue.length>0){call_data=this.call_queue.shift();var method=call_data[0];var args=call_data[1];this[method].apply(this,args);}};KxLazyLoad(resouces,_.bind(function(){this.run();},this));};};if(typeof(openWindow)=="undefined"){function openWindow(){KxDeferredCall("js/dialog.js","openWindow",arguments);}}
if(typeof(openAlert)=="undefined"){function openAlert(){KxDeferredCall("js/dialog.js","openAlert",arguments);}}
if(typeof(openAlertBlue)=="undefined"){function openAlertBlue(){KxDeferredCall("js/dialog.js","openAlertBlue",arguments);}}
if(typeof(alertHtml)=="undefined"){function alertHtml(){KxDeferredCall("js/dialog.js","alertHtml",arguments);}}
if(typeof(getCommentList)=="undefined"){function getCommentList()
{KxDeferredCall("js/comment.js","getCommentList",arguments);}}
if(typeof(app_showComment)=="undefined"){function app_showComment(){KxDeferredCall("js/comment.js","app_showComment",arguments);}}
if(typeof(app_showComment2)=="undefined"){function app_showComment2(){KxDeferredCall("js/comment.js","app_showComment2",arguments);}}
if(typeof(c2_replyComment)=="undefined"){function c2_replyComment(){KxDeferredCall("js/comment.js","c2_replyComment",arguments);}}
if(typeof(c2_delCommentThread)=="undefined"){function c2_delCommentThread(){KxDeferredCall("js/comment.js","c2_delCommentThread",arguments);}}
if(typeof(c2_delComment)=="undefined"){function c2_delComment(){KxDeferredCall("js/comment.js","c2_delComment",arguments);}}
if(typeof(addCommentSubmit)=="undefined"){function addCommentSubmit(){KxDeferredCall("js/comment.js","addCommentSubmit",arguments);}}
if(typeof(reply_unfold)=="undefined"){function reply_unfold(){KxDeferredCall("js/comment.js","reply_unfold",arguments);}}
if(typeof(c4_replyComment)=="undefined"){function c4_replyComment(){KxDeferredCall("js/comment.js","c4_replyComment",arguments);}}
if(typeof(c4_delComment)=="undefined"){function c4_delComment(){KxDeferredCall("js/comment.js","c4_delComment",arguments);}}
if(typeof(c4_delCommentThread)=="undefined"){function c4_delCommentThread(){KxDeferredCall("js/comment.js","c4_delCommentThread",arguments);}}
if(typeof(c6_getCommentList)=="undefined"){function c6_getCommentList(){KxDeferredCall("js/comment.js","c6_getCommentList",arguments);}}
if(typeof(initZanInfo)=="undefined"){function initZanInfo(){KxDeferredCall("js/comment.js","initZanInfo",arguments);}}
if(typeof(initMagicGift)=="undefined"){function initMagicGift(){KxDeferredCall(["js/gift.js","js/giftcommon.js"],"initMagicGift",arguments);}}
if(typeof(af_editFriend)=="undefined"){function af_editFriend(){KxDeferredCall("js/addfriend.js","af_editFriend",arguments);}}
if(typeof(af_addform)=="undefined"){function af_addform(){KxDeferredCall("js/addfriend.js","af_addform",arguments);}}
if(typeof(af_addfriend)=="undefined"){function af_addfriend(){KxDeferredCall("js/addfriend.js","af_addfriend",arguments);}}
if(typeof(a_appfriend_show)=="undefined"){function a_appfriend_show(){KxDeferredCall("js/addfriend.js","a_appfriend_show",arguments);}}
if(typeof(webEditor)=="undefined"){var webEditor=KxDeferredFunc("js/webeditor/editor.js",function(){var a=arguments;return new webEditor(a[0],a[1],a[2],a[3],a[4],a[5]);},"init");}
if(typeof(SWFObject)=="undefined"){var SWFObject=KxDeferredFunc("js/swfobject.js",function(){var a=arguments;return new SWFObject(a[0],a[1],a[2],a[3],a[4],a[5],a[6],a[7],a[8],a[9]);},"addParam","addVariable","getAttribute","getParams","getSWFHTML","getVariable","getVariablePairs","getVariables","setAttribute","write");}
if(typeof(fs2_superOnclick)=="undefined"){function fs2_superOnclick(){KxDeferredCall("js/friend_supersuggest.js","fs2_superOnclick",arguments);}}
if(typeof(fs2_viewAllfriend)=="undefined"){function fs2_viewAllfriend(){KxDeferredCall("js/friend_supersuggest.js","fs2_viewAllfriend",arguments);}}
if(typeof(fs2_selectFriend)=="undefined"){function fs2_selectFriend(){KxDeferredCall("js/friend_supersuggest.js","fs2_selectFriend",arguments);}}
if(typeof(StarIndexGift)=="undefined"){var StarIndexGift=KxDeferredFunc("js/home.js",function(){var a=arguments;return new StarIndexGift(a[0],a[1]);},"init");}

function s(s){if(!$(s))return;$(s).style.display="block";}
function h(s){if(!$(s))return;$(s).style.display="none";}
function sh(s){if(!$(s))return;$(s).style.display=$(s).style.display=="none"?"block":"none";}
function hs(s){if(!$(s))return;$(s).style.display=$(s).style.display=="block"?"none":"block";}
function vv(s){if(!$(s))return;$(s).style.visibility="visible";}
function vh(s){if(!$(s))return;$(s).style.visibility="hidden";}
var flag=0;function hy(){return;for(var i=1;i<=4;i++){$("hn"+i).className="hn_of";s("hn_xx"+i);h("hn"+i+"_l");setflag("hn"+i+"_l");}}
function xs(n){hy();s("hn"+n+"_l");$("hn"+n+"_l").focus();h("hn_xx"+n);$("hn"+n).className="hn_on";void(0);}
function setflag(s){if(!$(s))return;if(document.all?true:false){$(s).onmouseover=function(){hnmouseover(event);};$(s).onmouseout=function(){hnmouseout(event);};}
else{$(s).addEventListener("mouseover",function(evnt){hnmouseover(evnt);},false);$(s).addEventListener("mouseout",function(evnt){hnmouseout(evnt);},false);}}
function hnmouseover(event){flag=1;}
function hnmouseout(event){flag=0;}
function init(){return;if(document.all?true:false){document.onmousedown=function(){mousedown(event);};}
else{document.addEventListener("mousedown",function(evnt){mousedown(evnt);},false);}}
function mousedown(evnt){if(flag==0){hy();}}
function mes(m,n){h("r42"+n);s("r42"+m);$("ms").src="http://img1.kaixin001.com.cn/i/ms_"+n+".gif";$("es").src="http://img1.kaixin001.com.cn/i/es_"+m+".gif";}
function bq_hy(){for(var i=1;i<=3;i++){$("bq"+i).className="bq_of";$("bq"+i+"_d").style.display="none";}
$("bq1").className="bq1_of";}
function bq_on(bq,n){bq_hy();if(bq.id=="bq1"){bq.className="bq1_on";$("r30").style.display="block";}
else{bq.className="bq_on";$("r30").style.display="none";}
$("bq"+n+"_d").style.display="block";}
function bq_hy5(){for(var i=1;i<=5;i++){$("bq"+i).className="bq_of";$("bq"+i+"_d").style.display="none";}
$("bq1").className="bq1_of";}
function bq_on5(bq,n){bq_hy5();if(bq.id=="bq1")bq.className="bq1_on";else bq.className="bq_on";$("bq"+n+"_d").style.display="block";}
function zt_hy(){for(var i=1;i<=12;i++){$("zt"+i).className="x_zt1";}}
function zt_on(zt){if(zt.className=="x_zt3")return false;else{zt.className="x_zt2";}}
function zt_of(zt){if(zt.className=="x_zt3")return false;else{zt.className="x_zt1";}}
function zt_now(zt){if(zt.className=="x_zt3")return false;else{zt_hy();zt.className="x_zt3";}}
function cc1_now(cc){for(var i=1;i<=3;i++){$("cc1_d"+i).className="cc_f";}
cc.className="cc_n";}
function cc2_now(cc){for(var i=1;i<=3;i++){$("cc2_d"+i).className="cc_f";}
cc.className="cc_n";}
function fg_hy(){for(var i=1;i<=12;i++){$("x_fg"+i).className="x_fg1";}}
function fg_on(fg){if(fg.className=="x_fg3")return false;else{fg.className="x_fg2";}}
function fg_of(fg){if(fg.className=="x_fg3")return false;else{fg.className="x_fg1";}}
function fg_now(fg){if(fg.className=="x_fg3")return false;else{fg_hy();fg.className="x_fg3";}}
function z_fl_now(fl){for(var i=1;i<=6;i++){$("z_fl"+i).className="r30_f";}
fl.className="r30_n";}
function nn_c(){nn.style.color=(nn.style.color!="#fff")?"#fff":"#e88f9d";setTimeout("nn_c()",1000);}
function ep_hy(){for(var i=1;i<=12;i++){$("ep"+i).src="i/editor/ep"+i+"_1.gif";}}
function ep_cc(p,n){ep_hy();p.src="i/editor/ep"+n+"_3.gif";}
function ep_on(p,n){if(/3.gif/g.test(p.src))return false;else p.src="i/editor/ep"+n+"_2.gif";}
function ep_of(p,n){if(/3.gif/g.test(p.src))return false;else p.src="i/editor/ep"+n+"_1.gif";}
function pe_hy(){for(var i=1;i<=6;i++){$("pe"+i).src="i/editor/pe"+i+"_1.gif";}}
function pe_cc(p,n){pe_hy();p.src="i/editor/pe"+n+"_3.gif";}
function pe_on(p,n){if(/3.gif/g.test(p.src))return false;else p.src="i/editor/pe"+n+"_2.gif";}
function pe_of(p,n){if(/3.gif/g.test(p.src))return false;else p.src="i/editor/pe"+n+"_1.gif";}
function getExpDate(days,hours,minutes)
{var expDate=new Date();if(typeof(days)=="number"&&typeof(hours)=="number"&&typeof(hours)=="number")
{expDate.setDate(expDate.getDate()+parseInt(days));expDate.setHours(expDate.getHours()+parseInt(hours));expDate.setMinutes(expDate.getMinutes()+parseInt(minutes));return expDate.toGMTString();}}
function getCookieVal(offset)
{var endstr=document.cookie.indexOf(";",offset);if(endstr==-1)
{endstr=document.cookie.length;}
return unescape(document.cookie.substring(offset,endstr));}
function getCookie(name)
{var arg=name+"=";var alen=arg.length;var clen=document.cookie.length;var i=0;while(i<clen)
{var j=i+alen;if(document.cookie.substring(i,j)==arg)
{return getCookieVal(j);}
i=document.cookie.indexOf(" ",i)+1;if(i==0)break;}
return"";}
function setCookie(name,value,expires,path,domain,secure)
{document.cookie=name+"="+escape(value)+
((expires)?"; expires="+expires:"")+
((path)?"; path="+path:"")+
((domain)?"; domain="+domain:"")+
((secure)?"; secure":"");}
function deleteCookie(name,path,domain)
{if(getCookie(name))
{document.cookie=name+"="+
((path)?"; path="+path:"")+
((domain)?"; domain="+domain:"")+"; expires=Thu, 01-Jan-70 00:00:01 GMT";}}

var f2_inputid="";var f2_frienddata=[];var f2_seluid=0;var f2_word1="";var f2_word2="";var f2_pars="";var f2_maxnum=0;function friendSuggest2(inputid,word1,word2)
{f2_inputid=inputid;f2_word1=word1;f2_word2=word2;var obj=$(f2_inputid);if($("f2_suggest")!=null)
{if($("f2_suggest").parentNode!=obj.parentNode)
{$("f2_suggest").parentNode.removeChild($("f2_suggest"));}
else
{return;}}
var pos=getpos($(f2_inputid));var html='<div class="fsg_nl" id="f2_suggest" style="display:none;border-width: 1px 1px 1px 1px; z-index:99999;width:'+(pos.right-pos.left-5)+'px;"></div><div id="f2_emptysuggest" class="fsg_nl" style="z-index:99999;display:none;font-size:12px;padding-left:7px;background:#eeeeee;color:#666666;width:'+(pos.right-pos.left-9+32)+'px;border-width:1px 1px 1px 1px;"></div>';new Insertion.After(f2_inputid,html);f2_adjustPos();var el=$(f2_inputid).next("span");if(el){el.observe("click",function(){var value=$(f2_inputid).value;if(value.length>0&&value!="查找好友...")
{document.location="/find/search.php?open=other&real_name="+encodeURIComponent(value);}
else
{document.location="/friend/search.php";}});}}
function f2_adjustPos()
{var pos=getpos($(f2_inputid));try
{$("f2_suggest").style.left=parseInt(pos.left)+"px";$("f2_suggest").style.top=parseInt(pos.bottom+1)+"px";$("f2_suggest").style.width=parseInt(pos.right-pos.left-5+12)+"px";$("f2_emptysuggest").style.left=parseInt(pos.left)+"px";$("f2_emptysuggest").style.top=parseInt(pos.bottom+1)+"px";$("f2_emptysuggest").style.width=parseInt(pos.right-pos.left-9+32)+"px";}
catch(e)
{}}
function f2_inputOnfocus(event,thisobj)
{if(thisobj.value=="")
{f2_adjustPos();$("f2_emptysuggest").innerHTML=f2_word1;$("f2_emptysuggest").style.display="block";}}
function f2_inputOnkeydown(evnt,thisobj)
{if(evnt.keyCode==13)
{if($("f2_emptysuggest").style.display=="block")
{if(thisobj.value=="")
{document.location="/friend/search.php";}
else
{document.location="/find/search.php?open=other&real_name="+encodeURIComponent(thisobj.value);}}
return false;}
var hotinfo=f2_getHotNum();var hotnum=hotinfo.hotnum;var num=hotinfo.totalnum;if(evnt.keyCode==40)
{if($("f2_suggest_0")!=null&&$("f2_suggest").style.display=="block")
{if(hotnum==-1)
{$("f2_suggest_0").className="sgt_on";}
else
{var nextnum=hotnum==num-1?0:hotnum+1;$("f2_suggest_"+hotnum).className="sgt_of";$("f2_suggest_"+nextnum).className="sgt_on";}
return false;}}
if(evnt.keyCode==38)
{if($("f2_suggest_0")!=null&&$("f2_suggest").style.display=="block")
{if(hotnum==-1)
{$("f2_suggest_"+(num-1)).className="sgt_on";}
else
{var prevnum=hotnum==0?num-1:hotnum-1;$("f2_suggest_"+hotnum).className="sgt_of";$("f2_suggest_"+prevnum).className="sgt_on";}}}}
function f2_inputOnkeyup(evnt,thisobj)
{var hasthisperson=false;for(var i=0;i<f2_frienddata.length;i++)
{if(f2_frienddata[i].real_name==$(f2_inputid).value)
{hasthisperson=true;}}
if(hasthisperson==false)
{f2_seluid=0;}
if(evnt.keyCode==13)
{var hotinfo=f2_getHotNum();var hotnum=hotinfo.hotnum;var totalnum=hotinfo.totalnum;if($("f2_suggest").style.display=="block"&&hotnum!=-1&&totalnum>0)
{$(f2_inputid).value=f2_frienddata[hotnum].real_name_unsafe;f2_seluid=f2_frienddata[hotnum].uid;if('function'==typeof(f2_gotouser))
{f2_gotouser(f2_seluid);}
$("f2_suggest").style.display="none";}}
else if(evnt.keyCode==38||evnt.keyCode==40)
{}
else
{f2_ajax_submit();}}
function f2_ajax_submit()
{var url="/interface/suggestfriend.php";var text=encodeURIComponent($(f2_inputid).value);var pars="text="+text+"&pars="+f2_pars+"&maxnum="+f2_maxnum;var myAjax=new Ajax.Request(url,{method:"post",parameters:pars,onComplete:function(req){f2_ajax_show(req,$(f2_inputid).value);}});}
function f2_ajax_show(req,text)
{var arr=eval(req.responseText);f2_frienddata=arr;if(arr.length==0)
{$("f2_suggest").style.display="none";if($(f2_inputid).value=="")
{$("f2_emptysuggest").innerHTML=f2_word1;$("f2_emptysuggest").style.display="block";}
else
{f2_word2="你的好友里面没有"+text+"，请按回车搜索";if(f2_word2=="")
{$("f2_emptysuggest").style.display="none";}
else
{$("f2_emptysuggest").innerHTML=f2_word2;$("f2_emptysuggest").style.display="block";}}
return;}
var html="";for(var i=0;i<arr.length;i++)
{html+='<div id=f2_suggest_'+i+' class="sgt_of" style="border-width: 1px 1px 1px 1px;font-size:12px;width:'+(parseInt($("f2_suggest").style.width)-10)+'px;" onmouseover="f2_suggestOnmouseover(this)" onmousedown="f2_suggestOnmousedown(this);">'+arr[i].real_name+'&nbsp;&nbsp;'+f2_logo20(arr[i])+'</div>';}
$("f2_suggest").innerHTML=html;$("f2_suggest").style.display="block";$("f2_emptysuggest").style.display="none";f2_adjustPos();if($("f2_suggest_0")!=null&&$("f2_suggest").style.display=="block")
{$("f2_suggest_0").className="sgt_on";}}
function f2_getHotNum()
{var obj;var num=0;var hotnum=-1;while((obj=$("f2_suggest_"+num))!=null)
{if(obj.className=="sgt_on")
{hotnum=num;}
num++;}
return{"hotnum":hotnum,"totalnum":num};}
function f2_suggestOnmouseover(thisobj)
{var arr=thisobj.id.split('_');var thisnum=arr[2];var obj;var num=0;while((obj=$("f2_suggest_"+num))!=null)
{if(thisnum==num)
{obj.className="sgt_on";}
else
{obj.className="sgt_of";}
num++;}}
function f2_suggestOnmousedown(thisobj)
{var arr=thisobj.id.split('_');var num=arr[2];$(f2_inputid).value=f2_frienddata[num].real_name_unsafe;f2_seluid=f2_frienddata[num].uid;if('function'==typeof(f2_gotouser))
{f2_gotouser(f2_seluid);}
$("f2_suggest").style.display="none";}
function f2_inputOnblur()
{if($("f2_suggest"))
{$("f2_suggest").style.display="none";}
$("f2_emptysuggest").style.display="none";}
function f2_logo20(obj)
{var logo20="";if(typeof obj.logo20!="undefined")
{logo20="<img src='"+obj.logo20+"'  align=absmiddle width=15  />";}
return logo20;}

document.domain="localhost";var g_blinkid=0;var g_blinkswitch=0;var g_blinktitle=document.title;var g_onlineuser="";var g_sysmsg_sound=null;var g_newmsg_sound=null;var g_app_num=0;var g_appnum=0;var g_bappmore=false;var g_inputtime=0;function blinkNewMsg()
{var now=new Date();var nowtime=now.getTime();if(nowtime-g_inputtime>5000)
{document.title=g_blinkswitch%2?"【　　　】 - "+g_blinktitle:"【新消息】 - "+g_blinktitle;}
g_blinkswitch++;}
function blinkOnline()
{document.title=g_blinkswitch%2?"○"+g_onlineuser+" 上线了 - "+g_blinktitle:"●"+g_onlineuser+" 上线了 - "+g_blinktitle;g_blinkswitch++;if(g_blinkswitch>10)
{stopBlinkNewMsg();}}
function checkNewMsg()
{var url="/home/newmsg.php";var pars="";var myAjax=new Ajax.Request(url,{method:"post",parameters:pars,onComplete:function(req){var r="";eval("r="+req.responseText);checkNewMsgShow(r);}});}
function stopBlinkNewMsg()
{if(g_blinkid)
{clearInterval(g_blinkid);g_blinkid=0;$j(document).trigger("clear_notice");document.title=g_blinktitle;}}
var g_oldmsg=g_oldsysmsg=g_oldbbs=g_oldbbsreply=g_oldcomment=g_oldreply=0;function checkNewMsgShow(ret)
{var r=ret;if(r.im=="1")
{return;}
stopBlinkNewMsg();setTimeout(checkNewMsg,60000);var a_msglist=new Array("msg","sysmsg","bbs","bbsreply","comment","reply");if(r.notice=="1")
{var forbidsound=parseInt(r.forbidsound);if(!forbidsound)
{for(i=0;i<a_msglist.length;i++)
{if($("body_"+a_msglist[i]+"_num"))
{var c=parseInt($("body_"+a_msglist[i]+"_num").innerHTML);eval("g_old"+a_msglist[i]+"=c;");}}
var newmsg=parseInt(r.msg)+parseInt(r.bbs)+parseInt(r.bbsreply)+parseInt(r.comment)+parseInt(r.reply);var sysmsg=parseInt(r.sysmsg);var newchange=(parseInt(r.msg)-g_oldmsg)||(parseInt(r.bbs)-g_oldbbs)||(parseInt(r.bbsreply)-g_oldbbsreply)||(parseInt(r.comment)-g_oldcomment)||(parseInt(r.reply)-g_oldreply);var syschange=(parseInt(r.sysmsg)-g_oldsysmsg);for(i=0;i<a_msglist.length;i++)
{eval("g_old"+a_msglist[i]+"=parseInt(r."+a_msglist[i]+");");}
if(newmsg&&newchange&&(typeof(g_stopmsgblink)=="undefined"||!g_stopmsgblink))
{if(g_newmsg_sound==null)
{g_newmsg_sound=new SWFObject("http://img1.kaixin001.com.cn/i2/newmsg_sound.1.0.swf","newmsg_sound_swf","1","1","8","#ffffff",true);g_newmsg_sound.addParam("allowscriptaccess","always");g_newmsg_sound.addParam("wmode","opaque");g_newmsg_sound.addParam("menu","false");g_newmsg_sound.addVariable("autoplay","0");}
g_newmsg_sound.write("head_msgsound_div");}
else if(sysmsg&&syschange&&(typeof(g_stopmsgblink)=="undefined"||!g_stopmsgblink))
{if(g_sysmsg_sound==null)
{g_sysmsg_sound=new SWFObject("http://img1.kaixin001.com.cn/i2/sysmsg_sound.1.0.swf","sysmsg_sound_swf","1","1","8","#ffffff",true);g_sysmsg_sound.addParam("allowscriptaccess","always");g_sysmsg_sound.addParam("wmode","opaque");g_sysmsg_sound.addParam("menu","false");g_sysmsg_sound.addVariable("autoplay","0");}
g_sysmsg_sound.write("head_msgsound_div");}}
if(typeof(g_stopmsgblink)=="undefined"||!g_stopmsgblink)
{$j(document).trigger("notice");g_blinkid=setInterval(blinkNewMsg,1000);}}
else if(0&&r.online.length)
{g_blinkswitch=0;g_onlineuser=r.online;g_blinkid=setInterval(blinkOnline,500);}
for(i=0;i<a_msglist.length;i++)
{if(!parseInt(r[a_msglist[i]]))
{$("head_"+a_msglist[i]+"_num").innerHTML="";if($("body_"+a_msglist[i]+"_num"))
{$("body_"+a_msglist[i]+"_num").className="ql2";$("body_"+a_msglist[i]+"_num").innerHTML="0条新";}}
else
{$("head_"+a_msglist[i]+"_num").innerHTML="("+r[a_msglist[i]]+")";if($("body_"+a_msglist[i]+"_num"))
{$("body_"+a_msglist[i]+"_num").className="cr";$("body_"+a_msglist[i]+"_num").innerHTML=r[a_msglist[i]]+"条新";}
if(a_msglist[i]=="msg")
{if('function'==typeof(msg_view_checkNewMsg))
{msg_view_checkNewMsg();};}}}}
function outputHeadBase(vuid,vutype)
{var v_html='<div id="head">'
+' <div class="hd">'
+'  <div class="h1 wl1" style="margin-top:3px;">'
+'   <div style="padding-left:18px;"><a href="/home/?uid='+vuid+'" class="cf" title="开心网"><img src="http://img1.kaixin001.com.cn/i2/kaixinlogo.gif" alt="开心网" width="106" height="36" /></a></div>'
+'  </div>'
+'  <div class="h2" style="margin-top:16px;">'
+'   <ul id="index_dropdown">'
+'    <li class="t_title">'
+'     <a href="/home/?uid='+vuid+'&t='+Math.ceil(Math.random()*100)+'" class="t_link" onfocus="this.blur();">首页<span class="dd">更多</span></a>'
+'    <ul id="hn1_l" class="hn_l" >'
+'     <li class="wb"><a href="/home/?uid='+vuid+'">我的首页</a></li>'
+'     <li><a href="javascript:void(0);" class="disable">我的首页预览：</a></li>'
+'     <li><a href="/home/?_preview=friend" class="bg" target="_blank">好友访问时</a></li>'
+'     <li><a href="/home/?_preview=other" class="bg" target="_blank">陌生人访问时</a></li>'
+'    </ul>'
+'    </li>'
+'    <li class="t_bar"></li>'
+'    <li class="t_title">'
+'     <a class="t_link" href="/friend/?t='+Math.ceil(Math.random()*100)+'" onfocus="this.blur();">好友<span class="dd">更多</span></a>'
+'    <ul id="hn2_l" class="hn_l">'
+'     <li class="wb"><a href="/friend/">我的全部好友</a></li>'
+'     <li><a href="/friend/group.php">好友管理</a></li>'
+'     <li><a href="/friend/invite.php">邀请朋友加入</a></li>'
+'     <li><a href="/friend/search.php">查找朋友</a></li>'
+'    </ul>'
+'    </li>'
+'    <li class="t_bar"></li>'
+'    <li class="t_title t_msg">'
+'     <a class="t_link" href="/group/?t='+Math.ceil(Math.random()*100)+'" onfocus="this.blur();">群<span class="dd">更多</span></a>'
+'    <ul id="hn3_l" class="hn_l">'
+'     <li><a href="/group/">我的群</a></li>'
+'     <li class="wb"><a href="/group/flist.php">好友的群</a></li>'
+'     <li><a href="/group/new.php">创建新群</a></li>'
+'     <li><a href="/group/search.php">全部群</a></li>'
+'    </ul>'
+'    </li>'
+'    <li class="t_bar"></li>'
+'    <li class="t_title">'
+'     <a class="t_link" href="/msg/?t='+Math.ceil(Math.random()*100)+'" onfocus="this.blur();">消息<span class="dd">更多</span><b style="position: absolute; top: 5px; *top:4px; left: 55px; display: none;" id="head_msgdiv"><img border="0" src="http://img1.kaixin001.com.cn/i/ddtx2.gif"></b></a>'
+'    <ul id="hn4_l" class="hn_l">'
+'     <li><a href="/msg/inbox.php?t='+Math.ceil(Math.random()*100)+'">短消息<span style="padding-left:2px;color:red;" id=head_msg_num></span></a></li>'
+'     <li class="wb"><a href="/msg/sys.php?t='+Math.ceil(Math.random()*100)+'">系统消息<span style="padding-left:2px;color:red;" id=head_sysmsg_num></span></a></li>'
+'     <li><a href="/comment/?t='+Math.ceil(Math.random()*100)+'">评论<span style="padding-left:2px;color:red;" id=head_comment_num></span></a></li>'
+'     <li><a href="/comment/send.php?t='+Math.ceil(Math.random()*100)+'">评论回复<span style="padding-left:2px;color:red;" id=head_reply_num></span></a></li>'
+'     <li><a href="/comment/uindex.php?t='+Math.ceil(Math.random()*100)+'">留言板<span style="padding-left:2px;color:red;" id=head_bbs_num></span></a></li>'
+'     <li><a href="/comment/usend.php?t='+Math.ceil(Math.random()*100)+'">留言回复<span style="padding-left:2px;color:red;" id=head_bbsreply_num></span></a></li>'
+'    </ul>'
+'    </li>'
+'   </ul>'
+'   <div class="c"></div>'
+'  </div>'
+'  <div class="h3" style="position:relative; z-index:99999; float:left; margin-left:291px; *margin-top:2px;">'
+'   <div class="rt_nav">'
+'    <div class="rt_menu"><a href="/friend/invite.php" class="ce">邀请</a></div>'
+'    <div class="l rt_menu_bar"></div>'
+'    <div class="rt_menu"><a href="/friend/search.php" class="ce">找人</a></div>'
+'    <div class="l rt_menu_bar"></div>';if(typeof(vutype)!="undefined"&&vutype==2)
{v_html+='    <div class="l rt_menu" style="z-index:10005;"><a href="/set/star_account.php" class="ce">设置</a></div>';}
else
{v_html+='    <div class="rt_menu" onmouseover="this.className=\'rt_menu2\';s(\'set_sub\');"  onmouseout="this.className=\'rt_menu\';h(\'set_sub\');"><a href="/set/account.php" class="ce2">设置</a>'
+'     <ul class="set_sub" id="set_sub" style="display:none; height:96px;" >'
+'      <li>'
+'       <a href="/set/account.php" class="i_set1">账户设置</a>'
+'      </li>'
+'      <li>'
+'       <a href="/set/privacy.php" class="i_set2">隐私设置</a>'
+'      </li>'
+'      <li>'
+'       <a href="/set/appman.php" class="i_set3">组件设置</a>'
+'      </li>'
+'      <li>'
+'       <a href="/pay/index.php" class="i_set4">支付中心</a>'
+'      </li>'
+'     </ul>'
+'    </div>';}
v_html+='    <div class="l rt_menu_bar"></div>'
+'    <div class="rt_menu"><a najax="1" href="/login/logout.php" class="ce">退出</a></div>'
+'    <div class="c"></div>'
+'   </div>'
+'  </div>'
+'  <div class="l" style="padding:3px 0 0 1px; *padding:2px 0 0 1px;"><div style="position:relative;z-index:100100;" id="headsearchcon"><input id="headsearchuser" style="width:82px; height:18px; float:left;padding:3px 0 0 3px;font-size:12px; border:none; background:#fff url(http://img1.kaixin001.com.cn/i/h_search_bg.gif) no-repeat; color:#999;" value="查找好友..." onkeydown="var ret = f2_inputOnkeydown(event ,this);event.cancelBubble = true;return ret;" onkeyup="f2_inputOnkeyup(event,this);event.cancelBubble = true;" onblur="f2_inputOnblur();" onfocus="if (this.value==\'查找好友...\') this.value = \'\';this.className=\'c0\'; f2_inputOnfocus(event,this);" type="text" autocomplete="off"/><span style="width:19px;height:21px;display:block;float:left;background:url(http://img1.kaixin001.com.cn/i/h_search_bg.gif) no-repeat -85px 0;cursor:pointer;"></span></div></div>'
+'  <div class="c"></div>'
+' </div>'
+'</div>'
+'<div id="head_msgsound_div" style="left:0;top:0;position:absolute;"></div>';document.writeln(v_html);(function(){var setMenuBar=function(el,classname){$j(el).prev().removeClass().addClass(classname);$j(el).next().removeClass().addClass(classname);};$j(document).bind("notice",function(){var msgdiv=$j("#head_msgdiv");if(!msgdiv.data("inited")){msgdiv.data("inited",true);msgdiv.parents("li.t_title").bind("mouseenter.notice",function(){msgdiv.prev().click();msgdiv.hide();}).bind("mouseleave.notice",function(){msgdiv.show();});}
msgdiv.show();}).bind("clear_notice",function(){var msgdiv=$j("#head_msgdiv");if(msgdiv.data("inited")){msgdiv.data("inited",false);msgdiv.hide().parents("li.t_title").unbind("mouseenter.notice").unbind("mouseleave.notice");}
msgdiv.hide();});$j("#index_dropdown li.t_title").mouseenter(function(event){setMenuBar(this,'t_bar_hover');}).mouseleave(function(event){setMenuBar(this,'t_bar');$j(this).removeClass("hover").children("ul").hide();$j(this).find("span.deep").removeClass("deep");}).find("a.t_link span").click(function(e){e.preventDefault();var menu=$j(this).parent().next();if(menu.css("display")=="block"){menu.hide();$j(this).removeClass("deep");}else{menu.show();$j(this).addClass("deep");}
menu.parent().addClass("hover");});})();new friendSuggest2("headsearchuser","请输入好友的姓名，直接进入对方的首页 (支持拼音首字母快捷输入)","");}
function outputHead(vuid,vutype)
{outputHeadBase(vuid,vutype);var v_html='<div id="main">'
+' <div class="m1 wl1">'
+'     <div class="m1t"></div>'
+'     <div id="app_friend_tip" style="z-index:100101;position:absolute;background:#fff;border:2px solid #F7F7F7;width:160px;height:250px;display:none;">'
+'  </div>';document.writeln(v_html);}
function outputHeadOuterApp(vuid,vutype)
{outputHeadBase(vuid,vutype);var v_html='<div id="main" style="border:none;background-color:#fff;"><div id="app_friend_tip" style="z-index:100101;position:absolute;background:#fff;border:2px solid #F7F7F7;width:160px;height:250px;display:none;"></div><div class="main_module">';document.writeln(v_html);}
function toggleVisible(id){if($(id).style.visibility=='hidden')$(id).style.visibility='visible';else $(id).style.visibility='hidden';}
function _outputApp(v_icon,v_link,v_title,v_aid,v_index_num,v_path,v_najax)
{if(-1==v_link.indexOf("?"))
{v_link+="?t="+Math.ceil(Math.random()*100);}
else
{v_link+="&t="+Math.ceil(Math.random()*100);}
var najax="";if(v_najax&&(parseInt(v_najax,10)==1))
{najax='najax="1"';}
v_html='<div style="margin:12px 15px 12px 15px;" onmouseover="javascript:if(\''+v_index_num+'\'==\'1\'){$(\'app_friend_'+v_aid+'\').style.display=\'block\';}" onmouseout="javascript:$(\'app_friend_'+v_aid+'\').style.display=\'none\';">'
+' <div class="l"><span class="app_l_sp app_'+v_path+'"><a href="'+v_link+'" '+najax+' class="sl f14" title="'+v_title+'">'+v_title+'</a></span></div>'
+' <div class="l" id="app_friend_'+v_aid+'" style="display:none;padding:8px 3px;cursor:pointer;" onclick="javascript:a_appfriend_show('+v_aid+' , \''+v_link+'\' , \''+v_title+'\');"><img src="http://img1.kaixin001.com.cn/i2/xiasanjiao.gif" width="7" height="4" alt="快速查看你所有好友的'+v_title+'内容" align="absmiddle" /></div>'
+' <div class="c"></div>'
+'</div>';return v_html;}
function outputApp(v_icon,v_link,v_title,v_aid,v_index_num,v_path,v_najax)
{document.writeln(_outputApp(v_icon,v_link,v_title,v_aid,v_index_num,v_path,v_najax));}
function _setApplistHiddenHead()
{if(g_app_num==-1)return'';g_appnum++;if(g_appnum>g_app_num&&!g_bappmore)
{g_bappmore=true;return'<span id=applistmore style="display:none">';}
return'';}
function setApplistHiddenHead()
{document.writeln(_setApplistHiddenHead());}
function _setApplistHiddenTail()
{var slink='<ul class="applink"><li style="position:relative;"><a href="/app/list.php" class="sl2" onmouseover="showAppSetup(event);">全部组件</a><a title="组件设置" class="home_sp home_rl home_sfp" href="/set/appman.php"></a></li><li><a href="/star/" class="sl2">机构、名人主页</a></li></ul>';var slinkmore='<ul class="applink" style="margin-top:8px;"><li style="position:relative;"><a href="/app/list.php" class="sl2" onmouseover="showAppSetup(event);">全部组件</a><a title="组件设置" class="home_sp home_rl home_sfp" href="/set/appman.php"></a></li><li><a href="/star/" class="sl2">机构、名人主页</a></li></ul>';if(g_app_num==-1)return slinkmore;if(g_bappmore)
{return'</span><div id="applistscroll"><a href="javascript:showAppmore();" class="sl"  style="text-decoration:none;" title="列出我的全部组件">更多</a></div><br class="c" />'
+slink;}
return slinkmore;}
function setApplistHiddenTail()
{document.writeln(_setApplistHiddenTail());}
function showAppSetup(event)
{var el=Event.element(event);$j(el).next().css('display','block');$j(el).parent().mouseleave(function(){$j(this).unbind('mouseleave').children('a:eq(1)').css('display','none');});}
function outputHead2()
{document.write('<div style="position:relative;z-index:10000;"> <div class="install_tips" id="install_tips" style="position:absolute; left:110px; top:-103px; z-index:99; display:none;"> <div class="tar" style="padding:7px 15px 0 0;"><img src="http://img1.kaixin001.com.cn/i2/black_del.gif" title="关闭" style="cursor:pointer;" onclick="h(\'install_tips\')" /></div> <p style="padding:0px 20px;">点击这里，添加各种实用或游戏组件</p></div></div></div>');}
function showAppmore()
{if($("applistmore").style.display=="none")
{$("applistmore").style.display="block";$("applistscroll").innerHTML='<a href="javascript:showAppmore();" class="sl"  style="text-decoration:none;" title="列出我的全部组件">收起</a>';$("applistscroll").down('a').style.backgroundImage='url(http://img1.kaixin001.com.cn/i/dblue_arrow_up.gif)';}
else
{$("applistmore").style.display="none";$("applistscroll").innerHTML='<a href="javascript:showAppmore();" class="sl"  style="text-decoration:none;" title="列出我的全部组件">更多</a>';$("applistscroll").down('a').style.backgroundImage='url(http://img1.kaixin001.com.cn/i/dblue_arrow.gif)';}}
function f2_gotouser(f2_seluid)
{if(parseInt(f2_seluid))
{window.location="/home/?uid="+f2_seluid;}}
function outputAppInfo(uid)
{if(g_allapp_num>g_prevapp_num)
{var url="/app/left.php";var pars="";if(typeof(uid)!=="undefined")
{pars+="uid="+encodeURIComponent(uid);}
var myAjax=new Ajax.Request(url,{method:"get",parameters:pars,onComplete:function(req){outputAppInfoAjaxShow(req);}});}}
function outputAppInfoAjaxShow(req)
{var data=req.responseText.evalJSON();var v_html='';for(var i=0;i<data.length;i++)
{v_html+=_setApplistHiddenHead();v_html+=_outputApp(data[i]["icon"],data[i]["link"],data[i]["title"],data[i]["aid"],data[i]["index_num"],data[i]["path"],data[i]["najax"]);}
v_html+=_setApplistHiddenTail();$("head_applist").innerHTML=v_html;$("head_applist").store("app_data",data);}
function outputTail()
{document.writeln('<div class="c"></div>'
+'</div>'
+'<div id="footer" style="border:none;">'
+' <div class="left"><a href="/s/about.html" target="_blank" title="关于我们">关于我们</a><a href="/mobile/" title="手机版">手机版</a><a href="/s/job.html" target="_blank" title="招聘">招聘</a><a href="/t/cronline.html" target="_blank" title="客服">客服</a><a href="/t/help.html" target="_blank" title="帮助">帮助</a></div>'
+'<div class="right">&copy;2010 开心网 &nbsp;<a  class="c6" href=http://www.miibeian.gov.cn target=_blank>京ICP证080482号</a></div>'
+'</div>');if((typeof(needajaxload)!="undefined")&&needajaxload)
{var url=window.location.href;if(url.indexOf("#url=")==-1)
{var uri=getHashUri(url);getURIContent(uri);}}}
function g_poolchatmsg()
{pchat.poolchatmsg();}

var facetitle=["大笑","微笑","亲亲","抱抱","色色","好失望哟","好困哦","害羞","酷呆了","晕倒","眨眼","鬼脸","小声点","吃惊","翻白眼","干杯","困惑","啥？","睡觉","再见了","眼泪哗哗地","你好讨厌","我吐","怒骂","闭嘴","打你","真的生气了","超级棒","不咋地","魅力四射","心都碎了","爱","吻","玫瑰凋谢了","玫瑰盛开了","生日蛋糕","礼物","苹果","西瓜","咖啡","足球","握手","星星","精灵","小丑","大怒","生病了","小可爱","小心非典","嘴馋了","警察","抓狂了","不爽","汗","思考中","见钱眼开","呲牙","晕头转向","好好爱你哦","猪头","便便","月亮","音乐","饭","真衰","偷笑","下雨","猫猫","狗狗","骷髅","书呆子","太阳","邮件","帅帅男孩","妩媚女孩","药丸","鄙视","烧香","呲牙咧嘴","拜拜","奋斗","嗯","胜利","作揖","OK","地雷","菜刀","鼓掌","哼哼","可怜","委屈","糗大了","阴险","傲慢","快哭了","泪流满面","示爱","坏笑"];var g_gid=0;var g_inputchange=0;function webEditor(id,editorArea,width,height,toolbarpos)
{this.initEnv();this.iframeno=e_iframeno++;this.id=id;this.editorArea=editorArea;this.width=width;this.height=height;this.toolbarpos=toolbarpos;this.toolbar=null;this.iframe=null;this.textArea=null;this.range=null;this.seltype=null;this.openPanel='';this.uploadfile="";this.picfile="";this.grppicfile="";this.autoclose_timer=null;}
function gEditor_SetInputTime()
{var now=new Date();g_inputtime=now.getTime();}
webEditor.prototype.$=function(s)
{if(document.getElementById)
{return eval('document.getElementById("'+s+'")');}
else
{return eval('document.all.'+s);}}
webEditor.prototype.initEnv=function(force){if(typeof(force)=="undefined")force=false;if(force||typeof(e_isOpera)=="undefined")e_isOpera=false;if(force||typeof(e_isIE)=="undefined")e_isIE=false;if(force||typeof(e_isFF)=="undefined")e_isFF=false;if(force||typeof(e_bold)=="undefined")e_bold=true;if(force||typeof(e_italic)=="undefined")e_italic=true;if(force||typeof(e_underline)=="undefined")e_underline=true;if(force||typeof(e_JustifyLeft)=="undefined")e_JustifyLeft=false;if(force||typeof(e_JustifyCenter)=="undefined")e_JustifyCenter=false;if(force||typeof(e_JustifyRight)=="undefined")e_JustifyRight=false;if(force||typeof(e_InsertUnorderedList)=="undefined")e_InsertUnorderedList=false;if(force||typeof(e_InsertOrderedList)=="undefined")e_InsertOrderedList=false;if(force||typeof(e_font)=="undefined")e_font=true;if(force||typeof(e_fontsize)=="undefined")e_fontsize=true;if(force||typeof(e_color)=="undefined")e_color=true;if(force||typeof(e_backcolor)=="undefined")e_backcolor=false;if(force||typeof(e_img)=="undefined")e_img=true;if(force||typeof(e_link)=="undefined")e_link=true;if(force||typeof(e_media)=="undefined")e_media=true;if(force||typeof(e_audio)=="undefined")e_audio=false;if(force||typeof(e_face)=="undefined")e_face=true;if(force||typeof(e_internetimg)=="undefined")e_internetimg=true;if(force||typeof(e_uploadimg)=="undefined")e_uploadimg=false;if(force||typeof(e_media_tips)=="undefined")e_media_tips=false;if(force||typeof(e_piclink)=="undefined")e_piclink=false;if(force||typeof(e_grppiclink)=="undefined")e_grppiclink=false;if(force||typeof(e_iframeno)=="undefined")e_iframeno=0;if(force||typeof(e_toolbarbg)=="undefined")e_toolbarbg="#ffffff";if(force||typeof(e_GoogleMap)=="undefined")e_GoogleMap=false;if(force||typeof(e_onkeypress)=="undefined")e_onkeypress=null;if(force||typeof(e_onkeydown)=="undefined")e_onkeydown=null;if(force||typeof(e_init_content)=="undefined")e_init_content=null;if(force||typeof(e_onwebeditfocus)=="undefined")e_onwebeditfocus=null;if(force||typeof(e_onwebeditblur)=="undefined")e_onwebeditblur=null;if(force||typeof(e_onkeyup)=="undefined")e_onkeyup=null;}
webEditor.prototype.getUA=function()
{var UA=navigator.userAgent.toLowerCase();e_isOpera=(UA.indexOf('opera')!=-1);e_isFF=(UA.indexOf('firefox')!=-1);e_isIE=document.all?true:false;}
webEditor.prototype.drawEditor=function()
{var htmlstr;if(e_isOpera)
{htmlstr='<textarea style="font-size:14px;width:'+this.width+'px;height:'+this.height+'px;" id="'+this.id+'_aid" name="'+this.id+'_aid"></textarea>';}
else
{var framename=this.id+'_fid_'+(++this.iframeno);if(this.toolbarpos=="right")
{htmlstr='<div id="'+this.id+'_eid" style="float:left;border:1px #808080 solid;width:'+(this.width-50)+'px;height:'+this.height+'px;"><div class="it1"><iframe id="'+framename+'" name="'+framename+'" style="width:'+(this.width-50-2)+'px; height: '+(this.height-2)+'px;" frameborder=0 marginwidth=0 scrolling=auto src="http://localhost/interface/blank.php" onfocus="javascript:'+this.id+'.iframeOnfocus();" onblur="javascript:'+this.id+'.iframeOnblur();" onload="javascript:'+this.id+'.postInit();"></iframe></div></div><div id="'+this.id+'_tid" style="float:left;background-color:'+e_toolbarbg+';"></div><div style="clear:both;"></div>';}
else
{htmlstr='<div id="'+this.id+'_tid" style="width:'+(this.width+2)+'px;background-color:'+e_toolbarbg+';"></div>'
+'<div id="'+this.id+'_eid" style="border:1px #808080 solid;width:'+this.width+'px;height:'+this.height+'px;"><div class="it1"><iframe id="'+framename+'" name="'+framename+'" style="width:'+(this.width-2)+'px; height: '+(this.height-2)+'px;" frameborder=0 marginwidth=0 scrolling=auto src="http://localhost/interface/blank.php" onfocus="javascript:'+this.id+'.iframeOnfocus();" onblur="javascript:'+this.id+'.iframeOnblur();" onload="javascript:'+this.id+'.postInit();"></iframe></div></div>';}}
this.editorArea.innerHTML=htmlstr;}
webEditor.prototype.iframeOnfocus=function()
{this.$(this.id+"_eid").childNodes[0].className="it2";g_inputchange=setInterval(gEditor_SetInputTime,1000);if(typeof(e_onwebeditfocus)=="function")
{e_onwebeditfocus();}}
webEditor.prototype.iframeOnblur=function()
{if(!this.range)
{this.$(this.id+"_eid").childNodes[0].className="it1";}
if(g_inputchange)
{clearInterval(g_inputchange);}
if(typeof(e_onwebeditblur)=="function")
{e_onwebeditblur();}}
webEditor.prototype.genObj=function()
{if(e_isOpera)
{this.textArea=this.$(this.id+'_aid');}
else
{this.toolbar=this.$(this.id+'_tid');var framename=this.id+'_fid_'+this.iframeno;this.iframe=window.frames[framename];}}
webEditor.prototype.setText=function(str)
{if(typeof str=='undefined')
{str="";}
return"<html><head><style type=\"text/css\">body {background: #ffffff; margin:1px; padding:1px; font-size:14px; overflow:auto;word-wrap: break-word; font-family: Arial, '宋体';} p {padding: 0px; margin: 0px; } </style><script type='text/javascript'>document.domain='http://localhost';</script></head><body>"+str+"</body></html>";}
webEditor.prototype.setKeypressHandler=function(keyHandler)
{var frameobj=this.iframe;var doc=frameobj.document;if(doc&&keyHandler)
{if(doc.addEventListener)
{doc.addEventListener('keypress',keyHandler,false);}
else if(doc.attachEvent)
{doc.attachEvent('onkeypress',function(){keyHandler(frameobj.event);});}
else
{doc.onkeypress=keyHandler;}}}
webEditor.prototype.setKeydownHandler=function(keyHandler)
{var frameobj=this.iframe;var doc=frameobj.document;if(doc&&keyHandler)
{if(doc.addEventListener)
{doc.addEventListener('keydown',keyHandler,false);}
else if(doc.attachEvent)
{doc.attachEvent('onkeydown',function(){keyHandler(frameobj.event);});}
else
{doc.onkeydown=keyHandler;}}}
webEditor.prototype.setKeyupHandler=function(keyHandler)
{var frameobj=this.iframe;var doc=frameobj.document;if(doc&&keyHandler)
{if(doc.addEventListener)
{doc.addEventListener('keyup',keyHandler,false);}
else if(doc.attachEvent)
{doc.attachEvent('onkeyup',function(){keyHandler(frameobj.event);});}
else
{doc.onkeyup=keyHandler;}}}
webEditor.prototype.init=function(str)
{this.getUA();e_init_content=str;this.drawEditor();if(e_isOpera)
{this.genObj();this.textArea.value=e_init_content;return;}}
webEditor.prototype.postInit=function()
{if(e_isOpera)
{return;}
this.genObj();if(e_isIE)
{this.iframe.document.body.innerHTML=e_init_content;this.iframe.document.body.contentEditable=true;}
else
{this.iframe.document.body.innerHTML=e_init_content;this.iframe.document.designMode="On";this.iframe.document.contentEditable=true;}
this.createToolBar();this.setKeypressHandler(e_onkeypress);this.setKeyupHandler(e_onkeyup);this.setKeydownHandler(e_onkeydown);}
webEditor.prototype.getText=function()
{if(e_isOpera)
{return this.textArea.value;}
else if(e_isIE)
{return this.iframe.document.body.innerText;}
else
{return this.iframe.document.body.innerHTML;}}
webEditor.prototype.setContent=function(str)
{if(e_isOpera)
{this.textArea.value=str;}
else
{this.iframe.document.body.innerHTML=str;}}
webEditor.prototype.getHtml=function()
{if(e_isOpera)
{return this.textArea.value;}
var return_html=this.iframe.document.body.innerHTML;if(return_html.toLowerCase()=="<p>&nbsp;</p>"||return_html.toLowerCase()=="<br/>"||return_html.toLowerCase()=="<br />"||return_html.toLowerCase()=="<br>")
return'';return_html=return_html.replace(/<IMG style=\"WIDTH: (\d*)px; HEIGHT: (\d*)px\"[^<]*src=(\"[^\"]+\")[^<]*>/gi,'<img width=$1 height=$2 src=$3>');return_html=return_html.replace(/<img style=\"width: (\d*)px; height: (\d*)px;\"[^<]*src=(\"[^\"]+\")[^<]*>/gi,'<img width=$1 height=$2 src=$3>');return return_html;}
webEditor.prototype.isEmpty=function()
{return this.getHtml().gsub("&nbsp;","").gsub("<br>","").gsub("<br />","").gsub("<P>","").gsub("</P>","").gsub("<div>","").gsub("</div>","").strip().length==0;}
webEditor.prototype.getFocus=function()
{if(e_isOpera)
{this.textArea.focus();}
else
{this.iframe.focus();}}
webEditor.prototype.getTextType=function()
{if(e_isOpera)
{return"plain";}
else
{return"html";}}
webEditor.prototype.selectBegin=function()
{this.iframe.focus();if(e_isIE)
{this.range=this.iframe.document.selection.createRange();this.seltype=this.iframe.document.selection.type;}}
webEditor.prototype.drawPanel=function(inner,name)
{var pid=this.id+"_"+name;if(this.openPanel!='')
{this.removePanel(this.openPanel);}
this.openPanel=pid;tdiv=document.createElement("div");tdiv.id=pid;tdiv.innerHTML=inner;tdiv.style.display="block";tdiv.style.position="absolute";var btn_ele=this.id+"_"+name+'_icon';var btn=((btn_ele=='')?this.$(this.id+'_eid'):this.$(btn_ele));var btn_pos=b_getAbsolutePos(btn);tdiv.style.top=((btn_ele=='')?btn_pos.top:(btn_pos.top+28))+"px";tdiv.style.left=(btn_pos.left+1)+"px";document.body.appendChild(tdiv);tdiv.focus();}
webEditor.prototype.removePanel=function(panelid)
{if(this.$(panelid))
{document.body.removeChild(this.$(panelid));if(e_isIE&&this.range&&this.seltype!="Control")
{this.range.select();}
this.range=null;}}
webEditor.prototype.autoClose=function(pid)
{this.autoclose_timer=setTimeout(this.id+".removePanel('"+pid+"')",2000);}
webEditor.prototype.autoClose2=function(event,pid)
{if(IsIE())return;if(!event.relatedTarget||event.relatedTarget==event.currentTarget||event.relatedTarget.descendantOf(event.currentTarget))return;this.autoClose(pid);}
webEditor.prototype.removeAutoClose=function(pid)
{if(this.autoclose_timer)
{clearTimeout(this.autoclose_timer);}}
webEditor.prototype.removeAutoClose2=function(event)
{if(IsIE())return;if(!event.relatedTarget||event.relatedTarget==event.currentTarget||event.relatedTarget.descendantOf(event.currentTarget))return;this.removeAutoClose();}
function e_swapImgRestore()
{var i,x,a=document.e_sr;for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++)
x.src=x.oSrc;}
function e_findObj(n,d)
{var p,i,x;if(!d)
d=document;if((p=n.indexOf("?"))>0&&parent.frames.length)
{d=parent.frames[n.substring(p+1)].document;n=n.substring(0,p);}
if(!(x=d[n])&&d.all)
x=d.all[n];for(i=0;!x&&i<d.forms.length;i++)
x=d.forms[i][n];for(i=0;!x&&d.layers&&i<d.layers.length;i++)
x=e_findObj(n,d.layers[i].document);if(!x&&d.getElementById)
x=d.getElementById(n);return x;}
function e_swapImage()
{var i,j=0,x,a=e_swapImage.arguments;document.e_sr=new Array;for(i=0;i<(a.length-2);i+=3)
if((x=e_findObj(a[i]))!=null)
{document.e_sr[j++]=x;if(!x.oSrc)
x.oSrc=x.src;x.src=a[i+2];}}
webEditor.prototype.createToolBar=function()
{var str='<div class="editor_toolbar">';str+=(e_font?'<div id="'+this.id+'_fontname_icon" onclick="javascript:'+this.id+'.fontPanel();" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'font\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/e1_2.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/e1_2.gif" name="font" border="0" title="字体" alt="字体"></div>':'');str+=(e_fontsize?'<div id="'+this.id+'_fontsize_icon" onclick="javascript:'+this.id+'.fontsizePanel();" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'fontsize\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/e2_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/e2_1.gif" name="fontsize" border="0" title="字体大小" alt="字体大小"></div>':'');str+=(e_color?'<div id="'+this.id+'_forecolor_icon" onclick="javascript:'+this.id+'.colorPanel();" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'color\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/e3_2.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/e3_2.gif" name="color" border="0" title="字体颜色" alt="字体颜色"></div>':'');str+=(e_backcolor?'<div id="'+this.id+'_backcolor_icon" onclick="javascript:'+this.id+'.backcolorPanel();" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'backcolor\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/e4_2.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/e4_2.gif" name="backcolor" border="0" title="背景颜色" alt="背景颜色"></div>':'');str+=(e_bold?'<div onclick="javascript:'+this.id+'.setStyle(\'bold\');" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'bold\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/e5_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/e5_1.gif" name="bold" border="0" title="加粗" alt="加粗"></div>':'');str+=(e_italic?'<div onclick="javascript:'+this.id+'.setStyle(\'italic\');" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'italic\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/e6_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/e6_1.gif" name="italic" border="0" title="斜体" alt="斜体"></div>':'');str+=(e_underline?'<div onclick="javascript:'+this.id+'.setStyle(\'underline\');" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'underline\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/e7_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/e7_1.gif" name="underline" border="0" title="下划线" alt="下划线"></div>':'');str+=(e_JustifyLeft?'<div onclick="javascript:'+this.id+'.setStyle(\'JustifyLeft\');" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'JustifyLeft\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/ee1_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/ee1_1.gif" name="JustifyLeft" border="0" title="左对齐" alt="左对齐"></div>':'');str+=(e_JustifyCenter?'<div onclick="javascript:'+this.id+'.setStyle(\'JustifyCenter\');" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'JustifyCenter\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/ee2_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/ee2_1.gif" name="JustifyCenter" border="0" title="居中" alt="居中"></div>':'');str+=(e_JustifyRight?'<div onclick="javascript:'+this.id+'.setStyle(\'JustifyRight\');" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'JustifyRight\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/ee3_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/ee3_1.gif" name="JustifyRight" border="0" title="右对齐" alt="右对齐"></div>':'');str+=(e_InsertUnorderedList?'<div onclick="javascript:'+this.id+'.setStyle(\'InsertUnorderedList\');" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'InsertUnorderedList\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/ee4_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/ee4_1.gif" name="InsertUnorderedList" border="0" title="无序列表" alt="无序列表"></div>':'');str+=(e_InsertOrderedList?'<div onclick="javascript:'+this.id+'.setStyle(\'InsertOrderedList\');" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'InsertOrderedList\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/ee5_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/ee5_1.gif" name="InsertOrderedList" border="0" title="有序列表" alt="有序列表"></div>':'');str+=(e_img?'<div id="'+this.id+'_image_icon" onclick="javascript:'+this.id+'.imagePanel();" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'image\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/e9_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/e9_1.gif" name="image" border="0" title="添加图片" alt="添加图片"></div>':'');str+=(e_media?'<div id="'+this.id+'_media_icon" onclick="javascript:'+this.id+'.mediaPanel(\''+this.id+'_btn_media\');" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'media\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/ea_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/ea_1.gif" name="media" border="0" title="添加视频" alt="添加视频"></div>':'');str+=(e_audio?'<div id="'+this.id+'_audio_icon" onclick="javascript:'+this.id+'.audioPanel(\''+this.id+'_btn_audio\');" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'audio\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/ed_1.gif?20100223\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/ed_1.gif?20100223" name="audio" border="0" title="添加音频" alt="添加音频"></div>':'');str+=(e_link?'<div id="'+this.id+'_link_icon" onclick="javascript:'+this.id+'.linkPanel();" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'link\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/eb_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/eb_1.gif" name="link" border="0" title="添加链接" alt="添加链接"></div>':'');str+=(e_GoogleMap?'<div id="'+this.id+'_googlemap_icon" onclick="javascript:'+this.id+'.googleMapPanel();" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'googlemap\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/map2.gif?20100305\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/map2.gif?20100305" name="googlemap" border="0" title="添加地图" alt="添加地图"></div>':'');str+=(e_media_tips?'<div id="'+this.id+'_mediatips_icon" onclick="javascript:'+this.id+'.mediaTipsPanel();" onMouseOut="e_swapImgRestore()" onMouseOver="e_swapImage(\'mediatips\',\'\',\'http://img1.kaixin001.com.cn/js/webeditor/i/ea_1.gif\',0)"><img src="http://img1.kaixin001.com.cn/js/webeditor/i/ea_1.gif" name="mediatips" border="0" title="添加视频" alt="添加视频"></div>':'');str+=(e_face?'<img class="l" id="'+this.id+'_face_icon" onclick="javascript:'+this.id+'.facePanel();" src="http://img1.kaixin001.com.cn/js/webeditor/i/ec_1.gif" name="face" border="0" title="表情" alt="表情">':'');str+='<br class="c" /></div>';this.toolbar.innerHTML=str;}
webEditor.prototype.insertHTML=function(html)
{if(e_isIE)
{if(!this.range)
{this.selectBegin();}
if(this.range&&this.seltype!="Control")
{this.range.pasteHTML(html);this.range.select();}
this.range=null;}
else
{this.iframe.document.execCommand("insertHTML",false,html);this.iframe.focus();}}
webEditor.prototype.facePanel=function()
{this.selectBegin();if(this.$(this.id+'_face'))
{document.body.removeChild(this.$(this.id+'_face'));return;}
var pContent='';pContent+='<div onmouseenter="javascript:'+this.id+'.removeAutoClose();" onmouseover="javascript:'+this.id+'.removeAutoClose2(event);" onmouseleave="javascript:'+this.id+'.autoClose(\''+this.id+'_face\')" onmouseout="javascript:'+this.id+'.autoClose2(event, \''+this.id+'_face\')" class="face_bg" id="ec">';pContent+='<div class="face_cont">';pContent+='<div id="BQcon0" style="display:block;">';for(i=0;i<6;i++)
{for(j=1;j<=13;j++)
{var tt=(i*13+j).toString();var t='/club/repaste/images/face/'+tt+'.gif';pContent+='<div class="emo_of" onmouseover="this.className=\'emo_on\';" onmouseout="this.className=\'emo_of\';" onclick="javascript:'+this.id+'.insFace(\''+t+'\');"><img src="'+t+'" title="'+facetitle[i*13+j-1]+'" width="19" height="19" /></div>';}}
pContent+='<div class="c"></div></div>';pContent+='<div id="BQcon1" style="display:none;">';for(i=0;i<6;i++)
{for(j=1;j<=13;j++)
{if(i*13+j+78>facetitle.length)
{pContent+='<div class="emo_blank">&nbsp;</div>';}
else
{var tt=(i*13+j+78).toString();var t='/club/repaste/images/face/'+tt+'.gif';pContent+='<div onclick="javascript:'+this.id+'.insFace(\''+t+'\');" onmouseout="this.className=\'emo_of2\';" onmouseover="this.className=\'emo_on2\';" class="emo_of2"><img height="23" width="23" title="'+facetitle[i*13+j+78-1]+'" src="'+t+'" /></div>';}}}
pContent+='<div class="c"></div></div>';pContent+='<div class="fp_area">';pContent+='<div class="fp_btn" id="'+this.id+'_fp_btn">';pContent+='<p class="fp_bg">上页</p>';pContent+='<p class="next_bg1" onmouseover="this.className=\'next_bg2\';" onmouseout="this.className=\'next_bg1\';"><a href="javascript:'+this.id+'.facePanelSwitch(1);" class="sl2">下页</a></p>';pContent+='</div>';pContent+='<div class="fp_close">[<a href="javascript:'+this.id+'.facePanel();" class="sl2">关闭</a>]</div>';pContent+='<div class="c"></div></div>';pContent+='</div>';pContent+='</div>';this.drawPanel(pContent,'face');}
webEditor.prototype.facePanelSwitch=function(index)
{if(index==1)
{h("BQcon0");s("BQcon1");this.$(this.id+'_fp_btn').innerHTML='<p class="pre_bg1" onmouseover="this.className=\'pre_bg2\';" onmouseout="this.className=\'pre_bg1\';"><a href="javascript:'+this.id+'.facePanelSwitch(0);" class="sl2">上页</a></p><p class="lp_bg">下页</p>';}
else
{h("BQcon1");s("BQcon0");this.$(this.id+'_fp_btn').innerHTML='<p class="fp_bg">上页</p><p class="next_bg1" onmouseover="this.className=\'next_bg2\';" onmouseout="this.className=\'next_bg1\';"><a href="javascript:'+this.id+'.facePanelSwitch(1);" class="sl2">下页</a></p>';}}
webEditor.prototype.insFace=function(img)
{var arr=img.split('/');arr=arr[arr.length-1].split('.');var order=arr[0];var str='';if(img!='')
{str="<img src='"+img+"' title='"+facetitle[order-1]+"' border=0>";}
this.insertHTML(str);this.removePanel(this.id+'_face');}
webEditor.prototype.colorPanel=function()
{this.selectBegin();if(this.$(this.id+'_forecolor'))
{this.removePanel(this.id+'_forecolor');return;}
var color_set=new Array(new Array("#333333","#000000","#993300","#333300","#003300","#003366","#000080","#333399"),new Array("#808080","#800000","#ff6600","#808000","#008000","#008080","#0000ff","#666699"),new Array("#999999","#ff0000","#ff9900","#99cc00","#339966","#33cccc","#3366ff","#800080"),new Array("#c0c0c0","#ff00ff","#ffcc00","#ffff00","#00ff00","#00ffff","#00ccff","#993366"),new Array("#ffffff","#ff99cc","#ffcc99","#ffff99","#ccffcc","#F4F9FD","#99ccff","#cc99ff"));var cContent='';cContent+='<div class="e_d1" id="e3" onmouseleave="javascript:'+this.id+'.autoClose(\''+this.id+'_forecolor\')"><div class="e_d2"><div class="e_d3"><div class="e_d4"><div class="sk" >';for(i=0;i<5;i++)
{for(j=0;j<8;j++)
{cContent+='<div class="sk_of" onmouseover="this.className=\'sk_on\';" onmouseout="this.className=\'sk_of\';" onclick="javascript:'+this.id+'.setStyle(\'forecolor\' , \''+color_set[i][j]+'\');"><div class="sk_sk" style="background:'+color_set[i][j]+';"></div></div>';}}
cContent+='<div class="c"></div>  </div></div></div></div></div>';this.drawPanel(cContent,'forecolor');}
webEditor.prototype.backcolorPanel=function()
{this.selectBegin();if(this.$(this.id+'_backcolor'))
{this.removePanel(this.id+'_backcolor');return;}
var color_set=new Array(new Array("#000000","#cc0000","#ff0090","#993300","#333300","#003300","#000080","#666699"),new Array("#666666","#ff0000","#ff00cc","#ff6600","#808000","#008000","#0000ff","#800080"),new Array("#999999","#ff8080","#fc85c8","#ff9900","#99cc00","#339966","#3366ff","#993366"),new Array("#cccccc","#fedbdb","#fdbaf0","#ffcc00","#ffff00","#00ff00","#00ccff","#cc99ff"),new Array("#ffffff","#fdeeee","#fbe2f6","#ffe9c7","#ffff99","#ccffcc","#bcdcfd","#ead8fc"));var cContent='';cContent+='<div class="e_d1" id="e3" onmouseleave="javascript:'+this.id+'.autoClose(\''+this.id+'_backcolor\')"><div class="e_d2"><div class="e_d3"><div class="e_d4"><div class="sk">';for(i=0;i<5;i++)
{for(j=0;j<8;j++)
{cContent+='<div class="sk_of" onmouseover="this.className=\'sk_on\';" onmouseout="this.className=\'sk_of\';" onclick="javascript:'+this.id+'.setStyle(\'backcolor\' , \''+color_set[i][j]+'\');"><div class="sk_sk" style="background:'+color_set[i][j]+';"></div></div>';}}
cContent+='<div class="c"></div>  </div></div></div></div></div>';this.drawPanel(cContent,'backcolor');}
webEditor.prototype.linkPanel=function()
{this.selectBegin();if(this.$(this.id+'_link'))
{this.removePanel(this.id+'_link');return;}
lContent='';lContent+='<div class="e_d1" id="eb">\n';lContent+='<div class="e_d2">\n';lContent+='<div class="e_d3">\n';lContent+='<div class="e_d4">\n';lContent+='<div>请输入选择文字的链接地址</div>\n';lContent+='<div><span class="it_s"><input id="'+this.id+'_link_input" type="text" value="http://" style="width:200px;" class="it1" onfocus="this.className=\'it2\';" onblur="this.className=\'it1\';" /></span></div>\n';lContent+='<div class="e_d5" style="width:100%">\n';lContent+='<span class="e_d51"><input type="button" id="btn_qd" value="确定" title="确定" class="e_d51_of" onmouseover="this.className=\'e_d51_on\';" onmouseout="this.className=\'e_d51_of\';" onclick="javascript:'+this.id+'.insLink();" /></span>\n';lContent+='&nbsp;<span class="e_d52"><input type="button" id="btn_qx" value="取消" title="取消" class="e_d52_of" onmouseover="this.className=\'e_d52_on\';" onmouseout="this.className=\'e_d52_of\';" onclick="javascript:'+this.id+'.removePanel(\''+this.id+'_link\');" /></span>\n';lContent+='</div>\n';lContent+='</div>\n';lContent+='</div>\n';lContent+='</div>\n';lContent+='</div>\n';this.drawPanel(lContent,'link');}
webEditor.prototype.googleMapPanel=function()
{this.selectBegin();if(this.$(this.id+'_googlemap'))
{this.removePanel(this.id+'_googlemap');return;}
lContent='';lContent+='<div class="e_d1" id="eb_gm" style="width:470px;">\n';lContent+='<div class="e_d2">\n';lContent+='<div class="e_d3">\n';lContent+='<div class="e_d4">\n';lContent+='<div>请在Google地图右上角<span style="background:rgb(229,235,249); padding:2px; margin:0 2px; "><a href="javascript:;" style="color:#3366CC; cursor:default;">分享链接</a></span>的弹出窗口中复制相应的代码到以下输入框 <a href="/s/help_note.html#q12" class="c9" target="_blank"><img src="http://img1.kaixin001.com.cn/i/help/help_icon.gif" style="margin-top:-3px;*margin-top:0px;" align="absmiddle" title="如何添加google地图" /></a></div>\n';lContent+='<div style="padding-top:2px;"><span class="it_s"><input id="'+this.id+'_googlemap_input" type="text" value="" style="width:416px;" class="it1" onfocus="this.className=\'it2\';" onblur="this.className=\'it1\';" /></span></div>\n';lContent+='<div class="e_d5" style="width:426px;">\n';lContent+='<span class="e_d51"><input type="button" id="btn_qd" value="确定" title="确定" class="e_d51_of" onmouseover="this.className=\'e_d51_on\';" onmouseout="this.className=\'e_d51_of\';" onclick="javascript:'+this.id+'.insGoogleIframe();" /></span>\n';lContent+='&nbsp;<span class="e_d52"><input type="button" id="btn_qx" value="取消" title="取消" class="e_d52_of" onmouseover="this.className=\'e_d52_on\';" onmouseout="this.className=\'e_d52_of\';" onclick="javascript:'+this.id+'.removePanel(\''+this.id+'_googlemap\');" /></span>\n';lContent+='</div>\n';lContent+='</div>\n';lContent+='</div>\n';lContent+='</div>\n';lContent+='</div>\n';this.drawPanel_2(lContent,'googlemap',{'left':-50});}
webEditor.prototype.mediaTipsPanel=function()
{if(this.$(this.id+'_mediatips'))
{this.removePanel(this.id+'_mediatips');return;}
lContent='';lContent+='<div class="e_d1" id="eb_gm" style="width:250px;">\n';lContent+='<div class="e_d2">\n';lContent+='<div class="e_d3">\n';lContent+='<div class="e_d4">\n';lContent+='<div style="padding: 4px 2px;line-height:22px">如果你要转帖土豆、优酷、酷6等视频<br />请直接将该视频的网址粘贴到“<b class="sl">原帖网址</b>”输入框</div>'
lContent+='<div class="e_d5" style="width:100%;">\n';lContent+='<span class="e_d51"><input type="button" id="btn_qd" value="确定" title="确定" class="e_d51_of" onmouseover="this.className=\'e_d51_on\';" onmouseout="this.className=\'e_d51_of\';" onclick="javascript:'+this.id+'.removePanel(\''+this.id+'_mediatips\');" /></span>\n';lContent+='</div>\n';lContent+='</div>\n';lContent+='</div>\n';lContent+='</div>\n';lContent+='</div>\n';this.drawPanel_2(lContent,'mediatips',{});}
webEditor.prototype.drawPanel_2=function(inner,name,objParam)
{objParam=objParam||{};objParam['left']=parseInt(objParam['left']||0);var pid=this.id+"_"+name;if(this.openPanel!='')
{this.removePanel(this.openPanel);}
this.openPanel=pid;tdiv=document.createElement("div");tdiv.id=pid;tdiv.innerHTML=inner;tdiv.style.display="block";tdiv.style.position="absolute";var btn_ele=this.id+"_"+name+'_icon';var btn=((btn_ele=='')?this.$(this.id+'_eid'):this.$(btn_ele));var btn_pos=b_getAbsolutePos(btn);tdiv.style.top=((btn_ele=='')?btn_pos.top:(btn_pos.top+28))+"px";tdiv.style.left=(btn_pos.left+1+objParam['left'])+"px";document.body.appendChild(tdiv);tdiv.focus();}
webEditor.prototype.verifyurl=function(obj,url,caller){var target="/interface/verifyurl.php";var pars="url="+url;var myAjax=new Ajax.Request(target,{method:"post",parameters:pars,onComplete:function(req){webEditor.prototype.verifyurlComplete(obj,req,url,caller);}});}
webEditor.prototype.verifyurlComplete=function(obj,req,url,caller){if(req.responseText!="true"){var info;if(caller=="insAudio"){info="您输入的音频文件地址：["+url+"]可能有误。\n您确定要输入此地址吗？";}else{info="您输入的链接地址：["+url+"]有可能是无效地址。\n您确定要输入此地址吗？";}
if(!window.confirm(info)){return false;}}
if(caller=="insLink"){this.insLink(obj,"true");}else if(caller=="insMedia"){this.insMedia(obj,"true");}else if(caller=="insAudio"){this.insAudio(obj,"true");}else if(caller=="insImage"){this.insImage(obj,"true");}}
webEditor.prototype.insSwfFromWeb=function(obj,url){var target="/interface/getswffromweb.php";var pars="url="+url;var myAjax=new Ajax.Request(target,{method:"post",parameters:pars,onComplete:function(req){webEditor.prototype.insSwfFromWebComplete(obj,url,req);}});}
webEditor.prototype.insSwfFromWebComplete=function(obj,url,req){mediahtml="";if(req.responseText==""||req.responseText.indexOf("Warning")>=0){if(window.confirm("您输入的链接地址：["+url+"]有可能是无效地址。\n您确定要输入此地址吗？")){mediahtml="<a href=\""+url+"\" target=\"_blank\">"+url+"</a>";}}else{mediahtml=req.responseText;}
if(mediahtml!=""){obj.insertHTML(mediahtml);}
obj.removePanel(obj.id+'_media');}
webEditor.prototype.insLink=function(obj,verify)
{if(verify!="true"){var link=this.$(this.id+'_link_input');if(link.value!="http://"&&link.value!=""){this.verifyurl(this,link.value,"insLink");return false;}else{this.removePanel(this.id+'_link');return false;}}
var link=obj.$(obj.id+'_link_input');var linkhtml="";linkhtml+="<a href=\""+link.value+"\" target=\"_blank\">";if(e_isIE)
{if(obj.range&&obj.range.text!="")
linkhtml+=obj.range.text+"</a>";else
linkhtml+=link.value+"</a>";}
else
{if(obj.iframe.getSelection()!="")
linkhtml+=obj.iframe.getSelection()+"</a>";else
linkhtml+=link.value+"</a>";}
obj.insertHTML(linkhtml);obj.removePanel(obj.id+'_link');}
webEditor.prototype.insGoogleIframe=function(obj,verify){obj=obj||this;var link=obj.$(obj.id+'_googlemap_input');var linkhtml="";linkhtml=link.value;linkhtml=linkhtml.replace(/<iframe/ig,'<iframe style="border:1px solid gray; display:block;"');obj.insertHTML("<div style=\"display:block\">"+linkhtml+"</div>");obj.removePanel(obj.id+'_googlemap');}
function showpicdlg(instance)
{openWindow('/interface/getmypic.php?instance='+instance,570,480,'选择照片');}
function showgrppicdlg(instance)
{openWindow('/interface/getgrppic.php?gid='+g_gid+'&instance='+instance,570,480,'选择群相册照片');}
webEditor.prototype.imagePanel=function()
{this.selectBegin();if(this.$(this.id+'_image'))
{this.removePanel(this.id+'_image');return;}
iContent='';iContent+='<div class="e_d1" id="e9">\n';iContent+='<div class="e_d2">\n';iContent+='<div class="e_d3">\n';iContent+='<div class="e_d4">\n';if(e_internetimg)
{iContent+='<div>方法1：引用互联网上的图片&nbsp;<a target="_blank" href="/s/help_note.html#q3"><img src="http://img1.kaixin001.com.cn/i/help/help_icon.gif" style="margin-top:-3px;*margin-top:0px;" align="absmiddle" title="如何引用互联网上的图片" /></a></div>\n';iContent+='<div  style="margin-top:3px;"><span class="it_s"><input id="'+this.id+'_i_link" type="text" value="http://" style="width:200px;" class="it1" onfocus="this.className=\'it2\';" onblur="this.className=\'it1\';" /></span></div>\n';}
else
{iContent+='<div style="display:none;">方法1：引用互联网上的图片&nbsp;<a target="_blank" href="/s/help_note.html#q3"><img src="http://img1.kaixin001.com.cn/i/help/help_icon.gif" style="margin-top:-3px;*margin-top:0px;" align="absmiddle" title="如何引用互联网上的图片" /></a></div>\n';iContent+='<div  style="margin-top:3px;display:none;"><span class="it_s"><input id="'+this.id+'_i_link" type="text" value ="http://" style="width:200px;" class="it1" onfocus="this.className=\'it2\';" onblur="this.className=\'it1\';" /></span></div>\n';}
if(e_uploadimg)
{if(e_internetimg)
{iContent+='<div class="e_d43">方法2：上传电脑里的图片</div>\n';}
else
{iContent+='<div class="e_d43">上传电脑里的图片</div>\n';}
iContent+='<div><form name='+this.id+'_i_file_form action=/interface/getimg.php method=post enctype="multipart/form-data" target="'+this.id+'_i_file_frame"><input id="'+this.id+'_i_file" type="file" name=img class="it5" /><input type=hidden name=instance value="'+this.id+'"></form><iframe id='+this.id+'_i_file_frame name='+this.id+'_i_file_frame style="display:none;"></iframe></div>\n';}
if(e_piclink)
{iContent+='<div class="mt10">方法3：<a class="sl" href="javascript:showpicdlg(\''+this.id+'\');">插入你相册的照片</a></div>';}
if(e_grppiclink)
{iContent+='<div class="mt10">方法3：<a class="sl" href="javascript:showgrppicdlg(\''+this.id+'\');">插入群相册照片</a></div>';}
iContent+='<div class="e_d5" style="width:100%">\n';iContent+='<span class="e_d51"><input type="button" id="btn_qd" value="确定" title="确定" class="e_d51_of" onmouseover="this.className=\'e_d51_on\';" onmouseout="this.className=\'e_d51_of\';" onclick="javascript:'+this.id+'.insImage();" /></span>\n';iContent+='&nbsp;<span class="e_d52"><input type="button" id="btn_qx" value="取消" title="取消" class="e_d52_of" onmouseover="this.className=\'e_d52_on\';" onmouseout="this.className=\'e_d52_of\';" onclick="javascript:'+this.id+'.removePanel(\''+this.id+'_image\');" /></span>\n';iContent+='</div>\n';iContent+='</div>\n';iContent+='</div>\n';iContent+='</div>\n';iContent+='</div>\n';this.drawPanel(iContent,'image');}
webEditor.prototype.showerror=function(v_errno,v_error)
{alert(v_error);this.removePanel(this.id+'_image');}
webEditor.prototype.uploadComplete=function(v_link)
{if(v_link.indexOf('/upload/')>=0)
this.uploadfile+=v_link+",";var imghtml="<img src='"+v_link+"'>";this.insertHTML(imghtml);this.removePanel(this.id+'_image');}
webEditor.prototype.selectPicComplete=function(v_link)
{this.picfile+=v_link+",";var imghtml="<img src='"+v_link+"'>";this.insertHTML(imghtml);this.removePanel(this.id+'_image');}
webEditor.prototype.selectGrpPicComplete=function(v_link)
{this.grppicfile+=v_link+",";var imghtml="<img src='"+v_link+"'>";this.insertHTML(imghtml);this.removePanel(this.id+'_image');}
webEditor.prototype.insImage=function(obj,verify)
{if(verify!="true"){var i_link=this.$(this.id+'_i_link');if(i_link.value!="http://"&&i_link.value!=""&&this.seltype!="Control"){this.verifyurl(this,i_link.value,"insImage");return false;}else{this.insImage(this,"true");return false;}}
var i_link=obj.$(obj.id+'_i_link');if(i_link.value!="http://"&&i_link.value!=""&&obj.seltype!="Control")
{var imghtml="<img src='"+i_link.value+"'>";obj.insertHTML(imghtml);}
var i_file=obj.$(obj.id+'_i_file');if(i_file&&i_file.value.length!=0)
{var arr=i_file.value.split('\.');suffix=arr[arr.length-1].toLowerCase();if(suffix!="gif"&&suffix!="png"&&suffix!="jpg"&&suffix!="jpeg"&&suffix!="pjpeg"&&suffix!="bmp")
{alert("请选择gif/png/jpg/bmp类型的图片");return;}
try
{eval('document.'+obj.id+'_i_file_form.submit()');}
catch(e)
{alert("请选择正确的文件。");}}
else
{obj.removePanel(obj.id+'_image');}}
webEditor.prototype.mediaPanel=function()
{this.selectBegin();if(this.$(this.id+'_media'))
{this.removePanel(this.id+'_media');return;}
var iContent='';iContent+='<div class="e_d1" id="ea">';iContent+='<div class="e_d2">';iContent+='<div class="e_d3">';iContent+='<div class="e_d4">';iContent+='<div class="mt5">方法1：粘贴视频源文件地址(Flash地址) <a href="/s/help_note.html#q11" class="c9" target="_blank"><img src="http://img1.kaixin001.com.cn/i/help/help_icon.gif" style="margin-top:-3px;*margin-top:0px;" align="absmiddle" title="如何粘贴视频" /></a></div>';iContent+='<div><span class="it_s"><input id="'+this.id+'_m_link" type="text" value="http://" style="width:230px;" class="it1" onfocus="this.className=\'it2\';" onblur="this.className=\'it1\';" /></span></div>';iContent+='<div class="mt15">方法2：粘贴视频网页地址(<a href="/s/help_note.html#q10" class="sl" target="_blank">查看支持网站</a>)</div>';iContent+='<div><span class="it_s"><input id="'+this.id+'_m_link_web" type="text" value="http://" style="width:230px;" class="it1" onfocus="this.className=\'it2\';" onblur="this.className=\'it1\';" /></span></div>';iContent+='<div class="e_d5" style="width:100%">';iContent+='<span class="e_d51"><input type="button" id="btn_qd" value="确定" title="确定" class="e_d51_of" onmouseover="this.className=\'e_d51_on\';" onmouseout=\"this.className=\'e_d51_of\';" onclick="javascript:'+this.id+'.insMedia();" /></span>\n';iContent+='&nbsp;<span class="e_d52"><input type="button" id="btn_qx" value="取消" title="取消" class="e_d52_of" onmouseover="this.className=\'e_d52_on\';" onmouseout="this.className=\'e_d52_of\';" onclick="javascript:'+this.id+'.removePanel(\''+this.id+'_media\');" /></span>';iContent+='</div>';iContent+='</div>';iContent+='</div>';iContent+='</div>';iContent+='</div>';iContent+='<br clear="all" /><br clear="all" />';this.drawPanel(iContent,'media');}
webEditor.prototype.audioPanel=function()
{this.selectBegin();if(this.$(this.id+'_audio'))
{this.removePanel(this.id+'_audio');return;}
var iContent='';iContent+='<div class="e_d1" id="ea">';iContent+='<div class="e_d2">';iContent+='<div class="e_d3">';iContent+='<div class="e_d4">';iContent+='<div class="mt5">请粘贴音频源文件的地址</div>';iContent+='<div><span class="it_s"><input id="'+this.id+'_m_link" type="text" value="http://" style="width:230px;" class="it1" onfocus="this.className=\'it2\';" onblur="this.className=\'it1\';" /></span></div>';iContent+='<div class="e_d5" style="width:100%">';iContent+='<span class="e_d51"><input type="button" id="btn_qd" value="确定" title="确定" class="e_d51_of" onmouseover="this.className=\'e_d51_on\';" onmouseout=\"this.className=\'e_d51_of\';" onclick="javascript:'+this.id+'.insAudio();" /></span>\n';iContent+='&nbsp;<span class="e_d52"><input type="button" id="btn_qx" value="取消" title="取消" class="e_d52_of" onmouseover="this.className=\'e_d52_on\';" onmouseout="this.className=\'e_d52_of\';" onclick="javascript:'+this.id+'.removePanel(\''+this.id+'_audio\');" /></span>';iContent+='</div>';iContent+='</div>';iContent+='</div>';iContent+='</div>';iContent+='</div>';iContent+='<br clear="all" /><br clear="all" />';this.drawPanel(iContent,'audio');}
webEditor.prototype.insMedia=function(obj,verify)
{if(verify!="true"){var m_link=this.$(this.id+'_m_link').value;if(m_link!="http://"&&m_link!=""){this.verifyurl(this,m_link,"insMedia");return false;}else{this.insMedia(this,"true");return false;}}
var m_link=obj.$(obj.id+'_m_link').value;var m_link_web=obj.$(obj.id+'_m_link_web').value;if(m_link!="http://"&&m_link!=""){var dot_arr=m_link.split(".");var m_format=dot_arr[dot_arr.length-1].toLowerCase();var m_height=384;var m_width=454;if(m_format=="mp3"||m_format=="wma"||m_format=="midi")
{m_height=45;m_width=Math.ceil(this.width*0.7);}
var mediahtml='<EMBED style="DISPLAY: block; MARGIN: 0px auto 10px; TEXT-ALIGN: center" src='+m_link+' width='+m_width+' height='+m_height+' autostart="false" loop="false" wmode="transparent" />';obj.insertHTML(mediahtml);}
if(m_link_web!="http://"&&m_link_web!=""){obj.insSwfFromWeb(obj,m_link_web);}else{obj.removePanel(obj.id+'_media');}}
webEditor.prototype.insAudio=function(obj,verify)
{if(verify!="true"){var m_link=this.$(this.id+'_m_link').value;var dot_arr=m_link.split(".");var m_format=dot_arr[dot_arr.length-1].toLowerCase();if(m_format!="mp3"&&m_format!="wma"&&m_format!="wav"&&m_format!="mid")
{alert("音频格式错误，或不支持此音频格式["+m_format+"]");return false;}
if(m_link!="http://"&&m_link!=""){if(m_link.indexOf("://")<0){m_link="http://"+m_link;}
this.verifyurl(this,m_link,"insAudio");return false;}else{this.removePanel(this.id+'_audio');return false;}}
var m_link=obj.$(obj.id+'_m_link').value;var dot_arr=m_link.split(".");var m_format=dot_arr[dot_arr.length-1].toLowerCase();if(m_link.indexOf("://")<0){m_link="http://"+m_link;}
var audiohtml='<img title="'+m_link+'" src="http://img1.kaixin001.com.cn/js/webeditor/i/fake_m_player.gif" />';obj.insertHTML(audiohtml);obj.removePanel(obj.id+'_audio');}
webEditor.prototype.fontPanel=function()
{this.selectBegin();if(this.$(this.id+'_fontname'))
{this.removePanel(this.id+'_fontname');return;}
var fv=new Array("宋体","黑体","楷体_GB2312","隶书","幼圆","Arial","Tahoma","Times New Roman","Courier New","Sans-serif","Verdana");fContent='';fContent+='<div class="e_d1" id="e1" onmouseleave="javascript:'+this.id+'.autoClose(\''+this.id+'_fontname\');">';fContent+='<div class="e_d2">';fContent+='<div class="e_d3">';for(i=0;i<fv.length;i++)
{fContent+='<div class="e_of" onmouseover="this.className=\'e_on\';" onmouseout="this.className=\'e_of\';" style="font-family:\''+fv[i]+'\';" onclick="javascript:'+this.id+'.setStyle(\'fontname\', \''+fv[i]+'\');">'+fv[i]+'</div>';}
fContent+='</div>';fContent+='</div>';fContent+='</div>';this.drawPanel(fContent,'fontname');}
webEditor.prototype.setStyle=function(name,value)
{if(e_isIE)
{if(!this.range)
{this.selectBegin();}
if(this.range&&this.seltype!="Control"&&this.range.text!="")
{this.range.execCommand(name,false,value);this.range.select();}
else
{this.iframe.document.execCommand(name,false,value);}
this.range=null;}
else
{var ffname=name;if(ffname=="backcolor"){ffname="hilitecolor";}
this.iframe.document.execCommand(ffname,false,value);this.iframe.focus();}
if(this.$(this.id+"_"+name))
{this.removePanel(this.id+"_"+name);}}
webEditor.prototype.fontsizePanel=function()
{this.selectBegin();if(this.$(this.id+'_fontsize'))
{this.removePanel(this.id+'_fontsize');return;}
var fn=new Array("10","14","16","18","24","32","48");fContent='';fContent+='<div class="e_d1" onmouseleave="javascript:'+this.id+'.autoClose(\''+this.id+'_fontsize\')">\n';fContent+='<table border=0 cellpadding=0 cellspacing=0><tr><td>';fContent+='<div class="e_d2">\n';fContent+='<div class="e_d3">\n';for(i=0;i<fn.length;i++)
{fContent+='<div class="e_of" onmouseover="this.className=\'e_on\';" onmouseout="this.className=\'e_of\';" onclick="javascript:'+this.id+'.setStyle(\'fontsize\',\''+(i+1)+'\');">'+fn[i]+'px'+'</div>\n';}
fContent+='</div>\n';fContent+='</div>\n';fContent+='</td></tr></table>\n';fContent+='</div>\n';this.drawPanel(fContent,'fontsize');}
function b_getAbsolutePos(element)
{if(arguments.length!=1||element==null)
{return null;}
var elmt=element;var offsetTop=elmt.offsetTop;var offsetLeft=elmt.offsetLeft;var offsetWidth=elmt.offsetWidth;var offsetHeight=elmt.offsetHeight;while(elmt=elmt.offsetParent)
{if(elmt.style.position=='absolute'||(elmt.style.overflow!='visible'&&elmt.style.overflow!=''))
{break;}
offsetTop+=elmt.offsetTop;offsetLeft+=elmt.offsetLeft;}
return{top:offsetTop,left:offsetLeft,right:offsetWidth+offsetLeft,bottom:offsetHeight+offsetTop};}

var g_commentvuid="0";var g_commentouid="0";var g_commenttype="0";var g_commentid="0";var g_recentcomment="";var g_commenttypetext="评论";var g_commenttitle="";var g_is_privacy_pwd="0";var g_delrefresh="0";var g_threaddata=null;var g_comment_show_type="single";var g_homedir="home";var e_bold=false;var e_italic=false;var e_underline=false;var e_font=false;var e_fontsize=false;var e_color=false;var e_img=false;var e_link=false;var e_media=false;var g_viewmode="";var g3_commentvuid=0;var g3_commentisadmin=0;var g3_commenttype=0;var g3_commentid=0;var g3_commentgid=0;var g3_recentcomment="";var c4_g_commentouid=0;var c4_g_commentvuid=0;var c4_g_mainthreaddata=null;var c4_g_threaddata=null;var g_app_showing_uid=0;var g_app_showing_id=0;var g_app_uinfo={};var g_app_news_showing_aid=0;var g_app_news_showing_uid=0;var g_app_news_showing_id=0;var g_app_news_showing_cid=0;var g_app_news_showing_rid=0;var g_app_news_reply_cid=0;var news_comment_editor=null;var g_news_commenttypetext="评论";var g_news_commenttitle="";var g_news_commentvuid=0;var g_news_commentouid=0;var g_news_commenttype=0;var g_news_commentid=0;var g_news_recentcomment="";function initComment(vuid,ouid,type,id)
{g_commentvuid=vuid;g_commentouid=ouid;g_commenttype=type;g_commentid=id;if(g_commenttype=="0")
{g_commenttypetext="留言";}}