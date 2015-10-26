var $w = window;
var $d = document;
var $l = location;
function $i(s){return $d.getElementById(s);}
function $t(s){return $d.getElementsByTagName(s);}
function $n(s){return $d.getElementsByName(s);}

var www_100allin_com = {};

www_100allin_com.client = (function(){ 
 var t = {};
 var b = navigator.userAgent.toLowerCase();
 t.isOpera = (b.indexOf('opera') > -1);
 t.isIE = (!t.isOpera && b.indexOf('msie') > -1);
 t.isFF = (!t.isOpera &&!t.isIE&&b.indexOf('firefox') > -1);
 return t;
})();

www_100allin_com.util = (function(){
 var t = {};
 t.addEvent = function(o,c,h){
  if(www_100allin_com.client.isIE){
   o.attachEvent('on'+c,h);
  }else{
   o.addEventListener(c,h,false);
  }
  return true;
 };
 t.delEvent = function(o,c,h){
  if(www_100allin_com.client.isIE){
   o.detachEvent('on'+c,h);
  }else{
   o.removeEventListener(c,h,false);
  }
  return true;
 };
 t.ga = function(o,s){
  return o.getAttribute(s);
 };
 t.sa = function(o,k,v){
  return o.setAttribute(k,v);
 };
 t.s2d = function(s){
  var sa = s.split('-');
  var d =  new Date(sa[0],(sa[1]-1),sa[2]);
  return d;
 };
 t.d2s = function(d,b){
  var ye = d.getFullYear();
  var me = (parseInt(d.getMonth())+1).toString()
  var de = d.getDate();
  if(me.length==1&&b)me='0'+me;
  if(de.length==1&&b)de='0'+de;
  return ye+me+de;
 };
 return t;
})();

www_100allin_com.cookies = (function(){
 var t = {};
 t.setCookie = function(name,value,days)
 {
  if(days){
    var exp  = new Date(); 
    exp.setTime(exp.getTime() + days*60*60*1000*24);
    document.cookie = name + "="+ escape(value) +";expires="+ exp.toGMTString()+";path=/;";
  }else{
   document.cookie = name + "="+ escape(value)+";path=/;";
  }
 };
 
 t.getCookie = function(name)
 {
   var arr = document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)"));
   if(arr != null) return unescape(arr[2]); return null;
 };
 
 t.setCookie2 = function(name,value,days)
 {
  if(days){
    var exp  = new Date(); 
    exp.setTime(exp.getTime() + days*60*60*1000*24);
    document.cookie = name + "="+ encodeURIComponent(value) +";expires="+ exp.toGMTString()+";path=/;";
  }else{
   document.cookie = name + "="+ encodeURIComponent(value)+";path=/;";
  }
 };
 
 t.getCookie2 = function(name)
 {
   var arr = document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)"));
   if(arr != null) return decodeURIComponent(arr[2]); return null;
 };
 
 t.delCookie = function(name)
 {
   var exp = new Date();
   exp.setTime(exp.getTime() - 1);
   var cval=getCookie(name);
   if(cval!=null) document.cookie=name +"="+cval+";expires="+exp.toGMTString();
 };
 
 t.delCookie2 = function(name)
 {
   var exp = new Date();
   exp.setTime(exp.getTime() - 1);
   var cval=getCookie2(name);
   if(cval!=null) document.cookie=name +"="+cval+";expires="+exp.toGMTString();
 };
 
 return t;
})();

www_100allin_com.jscload = (function(){
 var t = function(){
     if(!www_100allin_com.quickload){
      var cs = $t('label');
      for(var i=0;i<cs.length;i++){  
       var ct = www_100allin_com.util.ga(cs[i],'c_type');
       if(ct){
        var pe = www_100allin_com.dom.gNxtSib(cs[i]);
        if(pe){
         eval("new "+ct+"(pe)");
        }
       }
      }
  }
  if(typeof jsconload == 'function'){
   jsconload();
  }
  www_100allin_com.loaded = true;
 };
 return t;
})();

www_100allin_com.jscunload = (function(){
 var t = function(){
  if(true){
      try{
    if(typeof jsconload == 'function'){
     jsconunload();
    }                           
            }catch(e){}
  }
 };
 return t;
})();

www_100allin_com.init = (function(){
 www_100allin_com.util.addEvent(window,'load',www_100allin_com.jscload);
 www_100allin_com.util.addEvent(window,'unload',www_100allin_com.jscunload);
 return true;
})();

var downMsg=function(msgid,contentid,config){
 this.msg = $i(msgid);
 this.content = $i(contentid);
 this.config = config ? config : {start_delay:3000, speed: 5, movepx:2,cookie:'downMsgcookie',expiresDay:0};
 this.offsetHeight;
 this.emsg_objTimer;
 this.ie6Add =0;
 var _this = this;
 
 this.init = function(){
  var ifcookie=www_100allin_com.cookies.getCookie(this.config.cookie);
  if(ifcookie == "show")
   return;
  window.setTimeout(_this.start,parseInt(_this.config.start_delay,10));
 }
 
 this.start = function(){
  _this.msg.style.display="block";
  _this.content.style.display="block";
  _this.offsetHeight = _this.content.offsetHeight;
  _this.content.style.height ="0px";
  _this.emsg_objTimer = setInterval(_this.moveUpDiv,parseInt(_this.config.speed,10));
 }
 
 this.moveUpDiv = function(){
   if(_this.offsetHeight> parseInt(_this.content.style.height,10)){
    _this.content.style.height =  parseInt(_this.content.style.height,10)+parseInt(_this.config.movepx,10)+"px";
   }
   else{
    window.clearInterval(_this.emsg_objTimer);
    //www_100allin_com.cookies.setCookie(_this.config.cookie,"show",_this.config.expiresDay);
    // ie6下才做，因为没有fixed属性
    var isMSIE = !!(/*@cc_on!@*/0);
  if(isMSIE &&!(window.XMLHttpRequest))
  { 
    _this.content.style.height = parseInt(_this.content.style.height,10) +2+"px";
    _this.autoMoveIe6();
    }
   }
 }
 this.autoMoveIe6 = function(){

  if(_this.ie6Add ==0){
   _this.content.style.height =  parseInt(_this.content.style.height,10) + 1 +"px";
   _this.msg.style.bottom="-2px";
   _this.ie6Add =1;
  }
  else{
   _this.content.style.height =  parseInt(_this.content.style.height,10) - 1 +"px";
   _this.msg.style.bottom="-1px";
   _this.ie6Add =0;
  }
  setTimeout(_this.autoMoveIe6,100)
 }
}

function closeDiv()
{
 document.getElementById('downmsg_emessage').style.display='none';
}

function showHideDiv()
{
 var ct = document.getElementById('donwmsg_content');
 var btn = document.getElementById('msg_hidden_btn');
 if(ct.style.display!="none"){
   ct.style.display = "none"
   btn.className="msg-hidden-btn-2";
 }else{
   ct.style.display="block";
   btn.className="msg-hidden-btn-1";
 }

}

var start=new Date();
 start=Date.parse(start)/1000;
 var counts=30;
 function CountDown(){
  var now=new Date();
  now=Date.parse(now)/1000;
  var x=parseInt(counts-(now-start),10);
  if(x>0){
   window.setTimeout('CountDown()',300)
  }else{
   showHideDiv()
  }
 }
//window.setTimeout('CountDown()',300);


function closeDiv()
{
 document.getElementById('downmsg_emessage').style.display='none';
}

function showHideDiv()
{
 var ct = document.getElementById('donwmsg_content');
 var btn = document.getElementById('msg_hidden_btn');
 if(ct.style.display!="none"){
   ct.style.display = "none"
   btn.className="msg-hidden-btn-2";
 }else{
   ct.style.display="block";
   btn.className="msg-hidden-btn-1";
 }

}



function SetCookies3(name,value,days)
 {
  if(days){
    var exp  = new Date(); 
    exp.setTime(exp.getTime() + days*60*60*1000*24);
    document.cookie = name + "="+ escape(value) +";expires="+ exp.toGMTString()+";path=/;";
  }else{
   document.cookie = name + "="+ escape(value)+";path=/;";
  }
 };
