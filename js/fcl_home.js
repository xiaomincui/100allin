function   get_x(id){
e = document.getElementById(id)
var   t=e.offsetTop;   
var   l=e.offsetLeft;   
while(e=e.offsetParent){   
t+=e.offsetTop;   
l+=e.offsetLeft;}   
return l
}  


function   get_y(id){
e = document.getElementById(id)
var   t=e.offsetTop;   
var   l=e.offsetLeft;   
while(e=e.offsetParent){   
t+=e.offsetTop;   
l+=e.offsetLeft;}   
return t
}  



function showmore(dp,cr,l)
{
    var str="";
    
    str += "<a href=\"/fcl/list-yingkou-" + dp + "-" + cr + "-" + l + "-0-0-----1.html\">营口</a> "
    str += "<a href=\"/fcl/list-tangshan-" + dp + "-" + cr + "-" + l + "-0-0-----1.html\">唐山</a> "
    str += "<a href=\"/fcl/list-qinhuangdao-" + dp + "-" + cr + "-" + l + "-0-0-----1.html\">秦皇岛</a> "
    str += "<a href=\"/fcl/list-yantai-" + dp + "-" + cr + "-" + l + "-0-0-----1.html\">烟台</a> "
    str += "<a href=\"/fcl/list-rizhao-" + dp + "-" + cr + "-" + l + "-0-0-----1.html\">日照</a> "
    str += "<a href=\"/fcl/list-zhanjiang-" + dp + "-" + cr + "-" + l + "-0-0-----1.html\">湛江</a> "
    str += "<a href=\"/fcl/list-macao-" + dp + "-" + cr + "-" + l + "-0-0-----1.html\">澳门</a> "
    str += "<a href=\"/fcl/list-sanya-" + dp + "-" + cr + "-" + l + "-0-0-----1.html\">三亚</a> "	
   
   	document.getElementById("more_in").innerHTML = str;
	
	var _d = document.getElementById("more");
	var _a = document.getElementById("linkmore");
	
	var pos = gp(_a);
	var w = pos.x - _d.offsetWidth + _a.offsetWidth;
	_d.style.left = w+"px";
	var h = pos.y + _a.offsetHeight;
    _d.style.top = h +"px";
    _d.style.visibility="visible";
}


function showmorecr(sp,dp,l)
{
    
　　document.getElementById("morecarrier").style.visibility="visible";

    var str="";
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-AAL-" + l + "-0-0-----1.html\">澳亚航运</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-ANL-" + l + "-0-0-----1.html\">澳国航运</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-BEN-" + l + "-0-0-----1.html\">边航</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-CNC-" + l + "-0-0-----1.html\">正利</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-Hamburg Sud-" + l + "-0-0-----1.html\">汉堡南美</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-HAPAG-LLOYD-" + l + "-0-0-----1.html\">赫伯罗特</a> "
    str += "<br/>"    
	str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-KMTC-" + l + "-0-0-----1.html\">高丽</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-MISC-" + l + "-0-0-----1.html\">马航</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-MOL-" + l + "-0-0-----1.html\">商船三井</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-NYK-" + l + "-0-0-----1.html\">日本邮船</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-KMTC-" + l + "-0-0-----1.html\">高丽</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-SAMUDERA-" + l + "-0-0-----1.html\">萨姆达拉</a> "
    str += "<br/>"   
	str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-SAF-" + l + "-0-0-----1.html\">南非轮船</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-SCI-" + l + "-0-0-----1.html\">印度国航</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-SITC-" + l + "-0-0-----1.html\">海丰</a> "
    str += "<a href=\"/fcl/list-" + sp + "-" + dp + "-TS-LINE-" + l + "-0-0-----1.html\">德翔</a> "
  
   	document.getElementById("morecarrier_in").innerHTML = str;
	
	var _d = document.getElementById("morecarrier");
	var _a = document.getElementById("linkmorecr");
	
	var pos = gp(_a);
	var w = pos.x - _d.offsetWidth + _a.offsetWidth;
	_d.style.left = w+"px";
	var h = pos.y + _a.offsetHeight;
    _d.style.top = h +"px";
    _d.style.visibility="visible";

}

function hiddenmore()
{
    document.getElementById('more').style.visibility='hidden'; 
}

function hiddenmorecr()
{
    document.getElementById('morecarrier').style.visibility='hidden'; 
}

document.onclick = function(e) 
{
	e = window.event||e;
	var srcElement = e.srcElement||e.target;
    if(srcElement.id != document.getElementById("more").id && srcElement.id != document.getElementById("linkmore").id) 
    { 
       hiddenmore();
    } 
	
    if(srcElement.id != document.getElementById("morecarrier").id && srcElement.id != document.getElementById("linkmorecr").id) 
    { 
       hiddenmorecr();
    } 
}
