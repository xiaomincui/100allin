function Create(c)
{
var delQus;
delQus=confirm('为此用户开户？');
if (delQus==true){
    document.getElementById("txtCode").value = c;
	document.getElementById("btnCreate").click();
}
}

function Forbidden(c)
{
var delQus;
delQus=confirm('冻结此用户？');
if (delQus==true){
    document.getElementById("txtCode").value = c;
	document.getElementById("btnForbidden").click();
}
}

function Enabled(c)
{
var delQus;
delQus=confirm('恢复此用户？');
if (delQus==true){
    document.getElementById("txtCode").value = c;
	document.getElementById("btnEnabled").click();
}
}

function Close1(c)
{
var delQus;
delQus=confirm('关闭此用户帐户？');
if (delQus==true){
    document.getElementById("txtCode").value = c;
	document.getElementById("btnClose1").click();
}
}

function Close2(c)
{
var delQus;
delQus=confirm('关闭此用户帐户？');
if (delQus==true){
    document.getElementById("txtCode").value = c;
	document.getElementById("btnClose2").click();
}
}

function Credits(c,c1)
{
	CloseCredits();
	CloseOverage();
	document.getElementById("divTempCredits").style.display = "";
	document.getElementById("txtTempCode").value = c;
	document.getElementById("txtTempCreditsOrigin").value = c1;
}

function Overage(c,c1)
{
	CloseCredits();
	CloseOverage();
	document.getElementById("divTempOverage").style.display = "";
	document.getElementById("txtTempCode1").value = c;
	//document.getElementById("txtTempOverage").value = c1;
}

function CloseCredits()
{
	document.getElementById("divTempCredits").style.display = "none";
}

function AcceptCredits()
{
	document.getElementById("divTempCredits").style.display = "none";
	var delQus;
	delQus=confirm('确认设置该帐户预存费？');
	if (delQus==true){
		document.getElementById("txtCode").value = document.getElementById("txtTempCode").value;
		document.getElementById("txtCredits").value = document.getElementById("txtTempCredits").value;
		document.getElementById("btnCredits").click();
	}
}

function CloseOverage()
{
	document.getElementById("divTempOverage").style.display = "none";
}

function AcceptOverage()
{
	document.getElementById("divTempOverage").style.display = "none";
	var delQus;
	delQus=confirm('确认设置该帐户余额？');
	if (delQus==true){
		document.getElementById("txtCode").value = document.getElementById("txtTempCode1").value;
		document.getElementById("txtOverage").value = document.getElementById("txtTempOverage").value;
		document.getElementById("btnOverage").click();
	}
}

