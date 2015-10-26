//可以打包为js文件;
var x0=0,y0=0,x1=0,y1=0;
var offx=6,offy=6;
var moveable=false;
var hover='#FF9900',normal='#336699';//color;
var index=10000;//z-index;
//开始拖动;
function startDrag(obj)
{
if(event.button==1)
{
//锁定标题栏;
obj.setCapture();
//定义对象;
var win = obj.parentNode;
var sha = win.nextSibling;
//记录鼠标和层位置;
x0 = event.clientX;
y0 = event.clientY;
x1 = parseInt(win.style.left);
y1 = parseInt(win.style.top);
//记录颜色;
normal = obj.style.backgroundColor;
//改变风格;
obj.style.backgroundColor = hover;
win.style.borderColor = hover;
obj.nextSibling.style.color = hover;
sha.style.left = x1 + offx;
sha.style.top = y1 + offy;
moveable = true;
}
}
//拖动;
function drag(obj)
{
if(moveable)
{
var win = obj.parentNode;
var sha = win.nextSibling;
win.style.left = x1 + event.clientX - x0;
win.style.top = y1 + event.clientY - y0;
sha.style.left = parseInt(win.style.left) + offx;
sha.style.top = parseInt(win.style.top) + offy;
}
}
//停止拖动;
function stopDrag(obj)
{
if(moveable)
{
var win = obj.parentNode;
var sha = win.nextSibling;
var msg = obj.nextSibling;
win.style.borderColor = normal;
obj.style.backgroundColor = normal;
msg.style.color = normal;
sha.style.left = parseInt(win.style.left) + offx;
sha.style.top = parseInt(win.style.top) + offy;
obj.releaseCapture();
moveable = false;
}
}
//获得焦点;
function getFocus(idno)
{
if(document.getElementById(idno).style.zIndex!=index)
{
index = index + 2;
var idx = index;
document.getElementById(idno).style.zIndex=idx;
document.getElementById(idno).nextSibling.style.zIndex=idx-1;
}
}
//最小化;
function min(obj)
{
var win = obj.parentNode.parentNode;
var sha = win.nextSibling;
var tit = obj.parentNode;
var msg = tit.nextSibling;
var flg = msg.style.display=="none";
if(flg)
{
win.style.height = parseInt(msg.style.height) + parseInt(tit.style.height) + 2*2;
sha.style.height = win.style.height;
msg.style.display = "block";
obj.innerHTML = "0";
}
else
{
win.style.height = parseInt(tit.style.height) + 2*2;
sha.style.height = win.style.height;
obj.innerHTML = "2";
msg.style.display = "none";
}
}
//创建一个对象;
function xWin(id,w,h,l,t,tit,msg)
{
index = index+2;
this.id = id;
this.width = w;
this.height = h;
this.left = l;
this.top = t;
this.zIndex = index;
this.title = tit;
this.message = msg;
this.obj = null;
this.bulid = bulid;
this.bulid();
}
//初始化;
function bulid()
{
var str = ""
+ "<div id=xMsg" + this.id + " "
+ " name=xMsg" + this.id + " "
+ "style='"
+ "z-index:" + this.zIndex + ";"
+ "width:" + this.width + ";"
+ "height:" + this.height + ";"
+ "left:" + this.left + ";"
+ "top:" + this.top + ";"
+ "color:" + normal + ";"
+ "font-size:8pt;"
+ "font-family:Tahoma;"
+ "position:absolute;"
+ "cursor:default;"
+ "' "
+ "onmousedown='getFocus(this.id)'>"
+ "<div "
+ "style='"
+ "background-color:" + normal + ";"
+ "width:" + this.width + ";"
+ "height:22px;"
+ "color:white;"
+ "' "
+ "onmousedown='startDrag(this)' "
+ "onmouseup='stopDrag(this)' "
+ "onmousemove='drag(this)' "
+ ">"
+ "<div style='width:" + (this.width-30) + ";float:left;text-align:center; margin-top:6px; font-weight:bold;'>" + this.title + "</div>"
+ "<span style='width:12px;border-width:0px;color:white;font-family:webdings;' onclick='min(this)'>0</span>"
+ "<span style='width:12px;border-width:0px;color:white;font-family:webdings;' onclick='ShowHide(\""+this.id+"\",null)'>r</span>"
+ "</div>"
+ "<div style='"
+ "width:100%;"
+ "height:" + (this.height-20-4) + ";"
+ "background-color:white;"
+ "line-height:14px;"
+ "word-break:break-all;"
+ "'>" + this.message + "</div>"
+ "</div>"
+ "<div id=xMsg" + this.id + "bg style='"
+ "width:" + this.width + ";"
+ "height:" + this.height + ";"
+ "top:" + ((this.top*1)+6) + ";"
+ "left:" + ((this.left*1)+6) + ";"
+ "z-index:" + (this.zIndex-1) + ";"
+ "position:absolute;"
+ "background-color:black;"
+ "filter:alpha(opacity=20);"
+ "'></div>";
document.body.insertAdjacentHTML("beforeEnd",str);
}
//显示隐藏窗口
function ShowHide(id,dis){
document.getElementById("chatsub"+id).src = "";
var p = document.getElementById("xMsg"+id).parentNode;
var p1 = document.getElementById("xMsg"+id+"bg").parentNode;
p.removeChild(document.getElementById("xMsg"+id));
p1.removeChild(document.getElementById("xMsg"+id+"bg"));
}


function openwindows(f,i,u){
if (readCookie('user_id') != "24") {
	alert("对不起，只有VIP会员才能与货主联系");
}
else {
	if (document.getElementById("xMsg"+i) != null){
	getFocus("xMsg"+i)
	}
	else {
    new xWin(i,552,406,200,250,"傲赢网即时聊天工具","<iframe name='chatsub" + i + "' id = 'chatsub" + i + "' src='/chat/chat.aspx?name=" + f + "&win=" + i + "&user=" + u + "' frameborder='0' scrolling='no' width='552' height = '402'></iframe>");
	}
}
}

function readCookie(name) 
{ 
    var cookieValue = ""; 
    var search = name + "="; 
    if(document.cookie.length > 0) 
    { 
        offset = document.cookie.indexOf(search);
        if (offset != -1) 
        { 
            offset += search.length; 
            end = document.cookie.indexOf(";",offset);
            if (end == -1) end = document.cookie.length; 
            cookieValue = unescape(document.cookie.substring(offset, end)) 
        } 
    } 
    return cookieValue;
} 

function showContact(id){
//alert(id);
if (readCookie('user_id') != "24") {
	alert("对不起，只有VIP会员才能与货主联系");
}
else{
	window.location.reload(); 
}
}