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