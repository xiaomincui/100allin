//引用js/css文件;
function include(path,type,title){
	var s,i,t;
	if(arguments.length < 1){
		return ;
	}
	if(arguments.length == 1){
		type = "js";
	}
	switch(type.toLowerCase()){
		case "css":
				t = document.getElementsByTagName("link");
				for(i=0;i<t.length;i++){
					if(t[i].href && t[i].href.indexOf(path)!=-1){
						return;
					}
				}
				s=document.createElement("link");
				s.rel="alternate stylesheet";
				s.type="text/css";
				s.href=path;
				s.title=title;
				s.disabled=false;
				break;
		case "js":
		case "javascript":
		default:
				t = document.getElementsByTagName("script");
				for(i=0;i<t.length;i++){
					if(t[i].src && t[i].src.indexOf(path)!=-1){
						return;
					}
				}
				s=document.createElement("script");
				s.type="text/javascript";
				s.src=path;
			break;
	}
	var h=document.getElementsByTagName("head")[0];
	h.appendChild(s);
}
//字符处理;
//去左右空格; 
function trim(s){
 	return rtrim(ltrim(s)); 
}
//去左空格; 
function ltrim(s){
 	return s.replace( /^\s*/, ""); 
} 
//去右空格; 
function rtrim(s){ 
 	return s.replace( /\s*$/, ""); 
}
//验证信息;
//空字符值; 
function isEmpty(s){
	s = trim(s); 
	return s.length == 0; 
}
//Email;
function isEmail(s){
	s = trim(s); 
 	var p = /^[_\.0-9a-z-]+@([0-9a-z][0-9a-z-]+\.){1,4}[a-z]{2,3}$/i; 
 	return p.test(s);
}
//数字; 
function isNumber(s){
	return !isNaN(s); 
}
//颜色值; 
function isColor(s){ 
	s = trim(s); 
	if (s.length !=7) return false; 
	return s.search(/\#[a-fA-F0-9]{6}/) != -1; 
}
//手机号码; 
function isMobile(s){ 
	s = trim(s); 
	var p = /13\d{9}/; 
	return p.test(s);
}
//身份证;
function isCard(s){ 
	s = trim(s); 
	var p = /^\d{15}(\d{2}[xX0-9])?$/; 
	return p.test(s);
}
//URL;
function isURL(s){
	s = trim(s).toLowerCase();
	var p = /^http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
	return p.test(s);
}
//Phone;
function isPhone(s){
	s = trim(s);
	var p = /^((\(\d{3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}$/;
	return p.test(s);
}
//Zip;
function isZip(s){
	s = trim(s);
	var p = /^[1-9]\d{5}$/;
	return p.test(s);
}
//Double;
function isDouble(s){
	s = trim(s);
	var p = /^[-\+]?\d+(\.\d+)?$/;
	return p.test(s);
}
//Integer;
function isInteger(s){
	s = trim(s);
	var p = /^[-\+]?\d+$/;
	return p.test(s);
}
//English;
function isEnglish(s){
	s = trim(s);
	var p = /^[A-Za-z]+$/;
	return p.test(s);
}
//中文;
function isChinese(s){
	s = trim(s);
	var p = /^[\u0391-\uFFE5]+$/;
	return p.test(s);
}
//双字节
function isDoubleChar(s){
	var p = /^[^\x00-\xff]+$/;
	return p.test(s);
}
//含有中文字符
function hasChineseChar(s){
	var p = /[^\x00-\xff]/;
	return p.test(s);
}
function hasAccountChar(s){
	var p = /^[a-zA-Z0-9][a-zA-Z0-9_-]{0,15}$/;
	return p.test(s);
}
function limitLen(s,Min,Max){
	s=trim(s);
	if(s=="") return false;
	if((s.length<Min)||(s.length>Max))
		return false;
	else
		return true;
}
//功能;
//延时事件;
function setDeferEvent(type,action,time){
	if (trim(time).length == 0) time = 1;
	if (typeof(time)!="number") time = 1;
	
	switch(type.toLowerCase()){
		case "go":
			window.setTimeout("window.location='"+ action +"'",time);
			break;
		case "alert":
			window.setTimeout("alert('"+ action +"')",time);
			break;
		case "js":
		case "javascript":
			window.setTimeout("'"+ action.toString() +"'",time);
			break;
		default:
			alert("Nothing will do!");
			break
	}		
}
function addLoadListener(handler){
	if (typeof window.addEventListener != 'undefined')
		window.addEventListener('load', handler, false);
	else if (typeof document.addEventListener != 'undefined')
		document.addEventListener('load', handler, false);
	else if (typeof window.attachEvent != 'undefined')
		window.attachEvent('onload', handler);
};
function addEventListener(element, eventType, handler, capture)
{
	try
	{
		if (element.addEventListener)
			element.addEventListener(eventType, handler, capture);
		else if (element.attachEvent)
			element.attachEvent("on" + eventType, handler);
	}
	catch (e) {}
};

function removeEventListener(element, eventType, handler, capture)
{
	try
	{
		if (element.removeEventListener)
			element.removeEventListener(eventType, handler, capture);
		else if (element.detachEvent)
			element.detachEvent("on" + eventType, handler);
	}
	catch (e) {}
};
//Image;
function preloadImages(){
	var d = document;
	if(d.images){
		if(!d.p_i_a) d.p_i_a = new Array();
		var i,j=d.p_i_a.length,a=arguments;
		for(i=0;i<a.length;i++){
			d.p_i_a[j]= new Image();
			d.p_i_a[j++].src = a[i];
		}
	}
}
//Ajax功能;
function loadAjaxElement(e,u,p,f,l){
	if(arguments.length < 3){
		return ;
	}
	o = $(e);
	o.innerHTML = l;
	p = $H(p).toQueryString();
	new Ajax.Updater(					 
                    {success: e},
                    u,
                    {method: 'get', parameters: p, onFailure: f});
}
function loadAjaxData(u,p,s,f){
	if(arguments.length < 3){
		return ;
	}
	p = $H(p).toQueryString();
	new Ajax.Request(					 
                    u,
                    {method: 'get', parameters: p, onSuccess:s,onFailure: f});
}
function sendAjaxElement(e,u,p,f,l){
	if(arguments.length < 3){
		return ;
	}
	o = $(e);
	o.innerHTML = l;
	p = $H(p).toQueryString();
	new Ajax.Updater(					 
                    {success: e},
                    u,
                    {method: 'post', parameters: p, onFailure: f});
}
function sendAjaxData(u,p,s,f){
	if(arguments.length < 3){
		return ;
	}
	p = $H(p).toQueryString();
	new Ajax.Request(					 
                    u,
                    {method: 'post', parameters: p, onSuccess:s,onFailure: f});
}