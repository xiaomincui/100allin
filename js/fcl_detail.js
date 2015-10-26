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
		document.getElementById("TextBox1").value = "写点评论内容吧 您的评论内容对他人有很大帮助";
		document.getElementById("TextBox1").style.color = "#999999"
	}
}

function hidden()
{
    document.getElementById('mm').style.visibility='hidden';   
}

function tt(s)
{
    
　　document.getElementById("mm").style.visibility="visible";
    
    mm.style.top=((event.clientY||event.pageY)*1+document.documentElement.scrollTop)+"px";
    mm.style.left=((event.clientX||event.pageX)*1+document.documentElement.scrollLeft)+"px";

    mm.innerHTML = "公司简介：<br/>" + s;
        
    
}