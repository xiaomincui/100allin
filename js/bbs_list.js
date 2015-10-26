function PageJump()
{
if(event.keyCode==13){
event.keyCode=9
document.getElementById("btnPageJump").click();
};
}

function LoginJump()
{
if(event.keyCode==13){
event.keyCode=9
document.getElementById("ImageButton1").click();
};
}

function PageJump2()
{
if(event.keyCode==13){
event.keyCode=9
document.getElementById("btnSearch").focus();
document.getElementById("btnSearch").click();
};
}

function PageJump3()
{
if(event.keyCode==13){
event.keyCode=9
document.getElementById("usertopmidbbs20100711_1_btnSearch").focus();
document.getElementById("usertopmidbbs20100711_1_btnSearch").click();
};
}

function focusit()
{
	if (document.getElementById("s_inp").style.color == "#999999")
	{
		document.getElementById("s_inp").value = "";
		document.getElementById("s_inp").style.color = "#000000"
		document.getElementById("hidHaveSearchKeywords").value = "1";		
	}
}

function blurit()
{
	if (document.getElementById("s_inp").value == "")
	{
		document.getElementById("s_inp").value = "请输入搜索关键词";
		document.getElementById("s_inp").style.color = "#999999"
		document.getElementById("hidHaveSearchKeywords").value = "0";	
	}
}

