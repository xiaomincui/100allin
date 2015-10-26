function CheckAll(form)//全选
  {
  for (var i=0;i<form.elements.length;i++)
    {
    var e = form.elements[i];
    if (e.Name != "chkAll"&&e.disabled==false)
       e.checked = form.chkAll.checked;
    }
	checkToList(form);
}

function delConfirm(id) {//确认confirm事件
	document.getElementById("ctl00_ContentPlaceHolder1_delList").value = id;
	var delQus;
	delQus=confirm('真的要删除吗？');
	if (delQus==true){
		document.getElementById("ctl00_ContentPlaceHolder1_btnHidDel").click();
	}else{
		checkToList(document.getElementById('aspnetForm'));
	}	
}

function checkToList(form) {
document.getElementById("ctl00_ContentPlaceHolder1_delList").value = ""
  for (var i=0;i<form.elements.length;i++)
    {
    var e = form.elements[i];
    if (e.name != "chkAll"&&e.type == "checkbox" &&e.disabled==false)
       if (e.checked == 1){
		   if (document.getElementById("ctl00_ContentPlaceHolder1_delList").value == ""){
			   document.getElementById("ctl00_ContentPlaceHolder1_delList").value = e.value;
			   }
		   else {
				document.getElementById("ctl00_ContentPlaceHolder1_delList").value = document.getElementById("ctl00_ContentPlaceHolder1_delList").value + "," + e.value;   
			   }
	   
	   }
    }
}


function CheckAll1(form)//全选
  {
  for (var i=0;i<form.elements.length;i++)
    {
    var e = form.elements[i];
    if (e.Name != "chkAll"&&e.disabled==false)
       e.checked = form.chkAll.checked;
    }
	checkToList1(form);
}

function delConfirm1(id) {//确认confirm事件
	document.getElementById("delList").value = id;
	var delQus;
	delQus=confirm('真的要删除吗？');
	if (delQus==true){
		document.getElementById("btnHidDel").click();
	}else{
		checkToList(document.getElementById('aspnetForm'));
	}	
}

function checkToList1(form) {
document.getElementById("delList").value = ""
  for (var i=0;i<form.elements.length;i++)
    {
    var e = form.elements[i];
    if (e.name != "chkAll" &&e.name != "Userlogin1$chkAutoLogin" &&e.type == "checkbox" &&e.disabled==false)
       if (e.checked == 1){
		   if (document.getElementById("delList").value == ""){
			   document.getElementById("delList").value = e.value;
			   }
		   else {
				document.getElementById("delList").value = document.getElementById("delList").value + "," + e.value;   
			   }
	   
	   }
    }
}


function delAll() {
	var delQus;
	delQus=confirm('真的要删除吗？');
	if (delQus==true){
		document.getElementById("ctl00_ContentPlaceHolder1_btnHidDel").click();
	}else{
		
	}	
}

function sendSeacch() {
	document.getElementById("ctl00_ContentPlaceHolder1_btnHidSearch").click();
}


function KeyDown()
{
if(event.keyCode==13)event.keyCode=9;
}

function PageJump()
{
if(event.keyCode==13){
event.keyCode=9
document.getElementById("btnPageJump").click();
};
}

//TabStrip切换
function dytabstrip(c1,c2){
	var dh = this;
	//定义TabStrip标签内容对象
	this.tabobj = [];
	//定义当前标签索引；
	this.nowindex = null;
	//定义自动展示变量
	this.autoid = null;
	this.startindex = 0;
	this.timeset = 5000;
	//添加标签及内容
	this.addtab = function(tab,content){
		this.tabobj[this.tabobj.length] = {"tab":tab,"content":content};
	}
	//展示指定索引的标签内容
	this.showtab = function(index){
		if(isNaN(index) || index<=0 || index>=this.tabobj.length){
			index = 0;
		}
		if(this.tabobj.length>0){
			this.tabobj[index].tab.className = c1;
			this.tabobj[index].content.style.display = "block";
			if(this.nowindex != null && index != this.nowindex){
				this.tabobj[this.nowindex].tab.className = c2;
				this.tabobj[this.nowindex].content.style.display = "none"; 
			}
			this.nowindex = index;
			this.startindex = index;
		}
	}
	//自动展示
	this.autoshow = function(){
		if(this.startindex>=this.tabobj.length){
			this.startindex = 0;
		}
		this.showtab(this.startindex);
		this.startindex += 1;
		this.autoid = window.setTimeout(function(){dh.autoshow()},this.timeset)
	}
	//清除自动展示
	this.clearautoshow = function(){
		window.clearTimeout(this.autoid);
	}
}

function AutoTips(t){
	setTimeout("ShowTips('officetips')",2000);
	setTimeout("HideTips('officetips')",20000);
}

function ShowTips(t){
	if (document.getElementById(t) != null){
		document.getElementById(t).style.display = "";
	}
}

function HideTips(t){
	if (document.getElementById(t) != null){
		document.getElementById(t).style.display = "none";
	}
}

function nowtime(){   
	var now=new Date();
	var Y = now.getFullYear();     //得到年 
	var M = FormatDigit(now.getMonth()+1);     //得到月   
	var D = FormatDigit(now.getDate());     //得到日 
	var h = FormatDigit(now.getHours());     //得到小时 
	var m = FormatDigit(now.getMinutes());     //得到分钟
	var s = FormatDigit(now.getSeconds());     //得到秒
	document.getElementById("nowtime").innerHTML= Y + "年" + M + "月" + D +"日 " + h + ":" + m + ":" + s;
}  

function FormatDigit(d){
    var di;
    di = d+"";
    if (di.length <= 1)
    {
        di = "0" + di;
    } 
    return di;
}