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