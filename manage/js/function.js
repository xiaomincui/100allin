function PageJump()
{
if(event.keyCode==13){
event.keyCode=9;
document.getElementById("btnPageJump").click();
}
}

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
	document.getElementById("delList").value = id;
	var delQus;
	delQus=confirm('真的要删除吗？');
	if (delQus==true){
		document.getElementById("btnHidDel").click();
	}else{
		checkToList(document.getElementById('form1'));
	}	
}

function checkToList(form) {
document.getElementById("delList").value = ""
  for (var i=0;i<form.elements.length;i++)
    {
    var e = form.elements[i];
    if (e.name != "chkAll"&&e.type == "checkbox" &&e.disabled==false)
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
		document.getElementById("btnHidDel").click();
	}else{
		
	}	
}

function sendSeacch() {
	document.getElementById("btnHidSearch").click();
}

function KeyDown()
{
if(event.keyCode==13)event.keyCode=9;
}


function addConfirm() {//确认confirm事件
	var addQus;
	addQus=confirm('添加成功！继续添加吗？');
	if (addQus==true){
		
	}else{
		window.location = "/manage/priceneed/linelist.aspx";
	}	
}