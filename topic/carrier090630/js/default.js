function focusit()
{
	if (document.getElementById("TextBox1").style.color == "#999999")
	{
		document.getElementById("TextBox1").value = "";
		document.getElementById("TextBox1").style.color = "#000000"
	}
}

function blurit()
{
	if (document.getElementById("TextBox1").value == "")
	{
		document.getElementById("TextBox1").value = "想发表自己的看法吗？写在这里吧。";
		document.getElementById("TextBox1").style.color = "#999999"
	}
}


function   movepos(){ 

if(window.pageYOffset) 
{    // all except IE    
window.pageYOffset = 1444;    
} 
else if(document.documentElement && document.documentElement.scrollTop) 
{    // IE 6 Strict    
document.documentElement.scrollTop = 1444;   
} 
else if(document.body) 
{    // all other IE    
document.body.scrollTop = 1444;    
}

} 

function   movepos1(){ 

if(window.pageYOffset) 
{    // all except IE    
window.pageYOffset = 1444;    
} 
else if(document.documentElement && document.documentElement.scrollTop) 
{    // IE 6 Strict    
document.documentElement.scrollTop = 1444;   
} 
else if(document.body) 
{    // all other IE    
document.body.scrollTop = 1444;    
}

}

function GetPageScroll() 
{
var x, y;  
if(window.pageYOffset) 
{    // all except IE    
y = window.pageYOffset;    
x = window.pageXOffset;  
} 
else if(document.documentElement && document.documentElement.scrollTop) 
{    // IE 6 Strict    
y = document.documentElement.scrollTop;    
x = document.documentElement.scrollLeft;  
} 
else if(document.body) 
{    // all other IE    
y = document.body.scrollTop;    
x = document.body.scrollLeft; 
} 
return {X:x, Y:y};
}