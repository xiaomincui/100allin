function orderForm(){
    if (checkForm())
    {   
        calForm(); 
        dialog("我的标题","id:testID","543px","auto","id");
    }
}

function saveForm(){
    if (checkForm())
    {   
        calForm(); 
        dialog("我的标题","id:testID","543px","auto","id");
    }
}

function orderReject(){
    if (checkRequire1('txtRejectReason','拒绝订舱的理由'))
    {
        document.getElementById('btnReject').click();
    }
}

function calForm(){
    document.getElementById("spanstartport").innerHTML = document.getElementById("txtstartport").value;
    document.getElementById("spandestport").innerHTML = document.getElementById("txtdestport").value;
    document.getElementById("spanfee").innerHTML = document.getElementById("hyf").innerHTML;
    document.getElementById("spancarrier").innerHTML = document.getElementById("txtcarrier_name").value;
    document.getElementById("spanstart").innerHTML = document.getElementById("txtkaihangri").value;
    
var price20gp = 0;
var price40gp = 0;
var price40hq = 0;
var price45hq = 0;
var fprice20gp = 0;
var fprice40gp = 0;
var fprice40hq = 0;
var fprice45hq = 0;
var totalgp = "";
var totaldingcang = "";

if (document.getElementById("txtgp").value != "" & document.getElementById("txtgp").value != "0")
{
    price20gp = document.getElementById("txtgp").value;
    totalgp = totalgp + price20gp + " KGS";
    totaldingcang = totaldingcang + price20gp + "*10";
}

var totaldingcangn = price20gp*10;

totaldingcang = totaldingcang + " = " + totaldingcangn;

document.getElementById("spangp").innerHTML = totalgp;
document.getElementById("spandingcang").innerHTML = totaldingcang;
document.getElementById("spandingcang1").innerHTML = totaldingcangn;
    
}

function calForm2(){
    document.getElementById("span1").innerHTML = document.getElementById("txtstartport").innerHTML;
    document.getElementById("span2").innerHTML = document.getElementById("txtdestport").innerHTML;
    document.getElementById("span4").innerHTML = document.getElementById("hyf").innerHTML;
    document.getElementById("span5").innerHTML = document.getElementById("txtcarrier_name").innerHTML;
    document.getElementById("span6").innerHTML = document.getElementById("txtkaihangri").innerHTML;
    
var price20gp = 0;
var price40gp = 0;
var price40hq = 0;
var price45hq = 0;
var fprice20gp = 0;
var fprice40gp = 0;
var fprice40hq = 0;
var fprice45hq = 0;
var totalgp = "";
var totaldingcang = "";

if (document.getElementById("txtgp").innerHTML != "" & document.getElementById("txtgp").value != "innerHTML")
{
    price20gp = document.getElementById("txtgp").innerHTML;
    totalgp = totalgp + price20gp + " KGS";
    totaldingcang = totaldingcang + price20gp + "*60";
}

var totaldingcangn = price20gp*1;

totaldingcang = totaldingcang + " = " + totaldingcangn;

document.getElementById("span3").innerHTML = totalgp;
document.getElementById("span7").innerHTML = totaldingcang;
}



function calForm3(){
    document.getElementById("span8").innerHTML = document.getElementById("txtstartport").innerHTML;
    document.getElementById("span9").innerHTML = document.getElementById("txtdestport").innerHTML;
    document.getElementById("span11").innerHTML = document.getElementById("hyf").innerHTML;
    document.getElementById("span12").innerHTML = document.getElementById("txtcarrier_name").innerHTML;
    document.getElementById("span13").innerHTML = document.getElementById("txtkaihangri").innerHTML;
    
var price20gp = 0;
var price40gp = 0;
var price40hq = 0;
var price45hq = 0;
var fprice20gp = 0;
var fprice40gp = 0;
var fprice40hq = 0;
var fprice45hq = 0;
var totalgp = "";
var totaldingcang = "";

if (document.getElementById("txtgp").innerHTML != "" & document.getElementById("txtgp").innerHTML != "0")
{
    price20gp = document.getElementById("txtgp").innerHTML;
    totalgp = totalgp + price20gp + " KGS";
    totaldingcang = totaldingcang + price20gp + "*60";
}


var totaldingcangn = price20gp*60;

totaldingcang = totaldingcang + "=" + totaldingcangn;

document.getElementById("span10").innerHTML = totalgp;
    
}

function checkForm(){
    if (!checkRequire('txtShipper','发货人'))
    {
    return;
    }

    if (!checkRequire('txtConsignee','收货人'))
    {
    return;
    }

    if (!checkRequire('txtNotifyParty','通知人'))
    {
    return;
    }
    
    if (!checkRequire('txtCompanyName','公司名称'))
    {
    return;
    }
    
    if (!checkRequire('txtEmail','邮箱'))
    {
    return;
    }
    
    if (!checkRequire('txtMobile','手机'))
    {
    return;
    }    
    
    if (!checkRequire('txtTel','电话'))
    {
    return;
    }   

    if (!checkRequire('txtFax','传真'))
    {
    return;
    }    
    
    if (!checkRequire('txtDescription','品名'))
    {
    return;
    }    
    
    if (!checkRequire4('txtGrossWeight','毛重'))
    {
    return;
    }    
    
    if (!checkRequire4('txtMeasurement','体积'))
    {
    return;
    }      
    
    if (!checkRequire('txtcarrier_name','航空公司'))
    {
    return;
    }    
    
    if (!checkRequire('txtkaihangri','开航日'))
    {
    return;
    }                    
        
    if (!checkRequire('txtgp','箱型的箱量'))
    {
    return;
    }
    
    
    //document.getElementById("btnSubmit").click();
    
    return true;
}


function checkRequire(i,n){
if (document.getElementById(i).value == "")
{
alert("请填写"+n+"！");
document.getElementById(i).focus();
return false;
}
else
{
return true;
}
}

function checkRequire4(i,n){
if (document.getElementById(i).value == "" | document.getElementById(i).value == "0")
{
alert("请填写"+n+"！");
document.getElementById(i).focus();
return false;
}
else
{
return true;
}
}

function checkRequire1(i,n){
if (document.getElementById(i).value == "")
{
alert("请填写"+n+"！");
return false;
}
else
{
return true;
}
}


function checkRequire3(i1,i2,i3,n){
    if (document.getElementById(i1).value == "" & document.getElementById(i2).value == "" & document.getElementById(i3).value == "")
    {
        alert("请至少填写一种"+n+"！");
        document.getElementById(i1).focus();
        return false;
    }
    else
    {
        if (document.getElementById(i1).value == "0" & document.getElementById(i2).value == "0" & document.getElementById(i3).value == "0")
        {
            alert("请至少填写一种"+n+"！");
            document.getElementById(i1).focus();
            return false;
        }
        else
        {
            return true;
        }
        return true;
    }
}

function isNumber(oNum)
{
if(!oNum) return false;
var strP=/^\d+(\.\d+)?$/;
if(!strP.test(oNum)) return false;
try{
if(parseFloat(oNum)!=oNum) return false;
}
catch(ex)
{
return false;
}
return true;
}


function esckeydown()
{
if(event.keyCode==27){
   event.returnValue = null;
   window.returnValue = null;
   document.getElementById('floatBox').style.display = 'none';document.getElementById('floatBoxBg').style.display = 'none';
}
}



function focusInput(focusClass, normalClass) 
{
//
    var elements = document.getElementsByTagName("input");
    var elements1 = document.getElementsByTagName("textarea");
    for (var i=0; i < elements.length; i++) 
    { 
        if (elements[i].type != "button" && elements[i].type != "submit" && elements[i].type != "reset") 
        {             
            elements[i].onfocus = function() { this.className = focusClass; };
            elements[i].onblur = function() { this.className = normalClass; };
        }    
    } 
    
    for (var i=0; i < elements1.length; i++) 
    {           
        elements1[i].onfocus = function() { this.className = focusClass; };
        elements1[i].onblur = function() { this.className = normalClass; };  
    }     
} 

function focusTextArea(focusClass, normalClass) 
{
//
    var elements = document.getElementsByTagName("textarea");
    for (var i=0; i < elements.length; i++) 
    {   
        elements[i].onfocus = function() { this.className = focusClass; };
        elements[i].onblur = function() { this.className = normalClass; };
    } 
     
} 


window.onload = function () {
//     focusInput('focusInput', 'normalInput');
//     focusTextArea('focusTextArea', 'normalTextArea');
} 

function calhyf(){
var gp = 0;
var pricegp = 0;

if ((document.getElementById("txtGrossWeight").value * 1) > (document.getElementById("txtMeasurement").value * 167))
{
	gp = document.getElementById("txtGrossWeight").value;
	pricegp = document.getElementById("txtGrossWeight").value;
}
else
{
	gp = document.getElementById("txtMeasurement").value * 167;
	pricegp = document.getElementById("txtMeasurement").value * 167;
}

if (gp*1 <=45)
{
	pricegp = 0;
}

if (gp*1 >=45 & gp*1 <=100)
{
	pricegp = pricegp * document.getElementById("fa45").innerHTML;
}

if (gp*1 >100 & gp*1 <=300)
{

	pricegp = pricegp * document.getElementById("fa100").innerHTML;
}

if (gp*1 >300 & gp*1 <=500)
{
	pricegp = pricegp * document.getElementById("fa300").innerHTML;
}

if (gp*1 >500 & gp*1 <=1000)
{
	pricegp = pricegp * document.getElementById("fa500").innerHTML;
}

if (gp*1 >1000)
{
	pricegp = pricegp * document.getElementById("fa1000").innerHTML;
}

pricegp = formatNumber(pricegp,2)

document.getElementById("txtgp").value = gp;
document.getElementById("hyf").innerHTML = pricegp;
}




function CancelOrder2(){
document.getElementById('CancelOrder2Div').style.display = '';
}


function CancelCancelOrder2(){
document.getElementById('CancelOrder2Div').style.display = 'none';
}


function SaveEvaluation(c,t){
document.getElementById('evaluationDiv').style.display = '';
document.getElementById('txtEvaluation').value = c;
document.getElementById('txtEvaluationType').value = t;
}

function CancelEvaluation(){
document.getElementById('evaluationDiv').style.display = 'none';
}


function SaveResult(t){
document.getElementById('resultDiv').style.display = '';
document.getElementById('txtResultType').value = t;
//document.getElementById('Label1').innerHTML = document.getElementById('span_' + c).innerHTML;
}

function ConfirmResult(){
if (document.getElementById('TextBox1').value != "")
{
    var delQus;
    delQus=confirm('确认要投诉对方？');
    if (delQus==true){
	    document.getElementById("Button14").click();
    }	
}
else
{
    alert("请输入投诉内容！");
}
}

function ConfirmCancel(){
if (document.getElementById('TextBox2').value != "")
{
    var delQus;
    delQus=confirm('确认要撤销订舱？');
    if (delQus==true){
	    document.getElementById("Button13").click();
    }	
}
else
{
    alert("请填写您撤销订单的理由！");
}
}

function CancelResult(){
document.getElementById('resultDiv').style.display = 'none';
}


function formatNumber (num, decplaces) {
    // convert in case it arrives as a string value
    num = parseFloat(num);
    // make sure it passes conversion
    if (!isNaN(num)) {
        // multiply value by 10 to the decplaces power;
        // round the result to the nearest integer;
        // convert the result to a string
        var str = "" + Math.round (eval(num) * Math.pow(10,decplaces));
        // exponent means value is too big or small for this routine
        if (str.indexOf("e") != -1) {
            return "Out of Range";
        }
        // if needed for small values, pad zeros
        // to the left of the number
        while (str.length <= decplaces) {
            str = "0" + str;
        }
        // calculate decimal point position
        var decpoint = str.length - decplaces;
        // assemble final result from: (a) the string up to the position of
        // the decimal point; (b) the decimal point; and (c) the balance
        // of the string. Return finished product.
        return str.substring(0,decpoint) + "." + str.substring(decpoint,str.length);
    } else {
        return "NaN";
    }
}

function mul(n1, n2) {
    var m=0, s1=n1.toString(), s2=n2.toString();
    try {
        m += s1.split(".")[1].length
    } catch(e) {
    }
    try {
        m += s2.split(".")[1].length
    } catch(e){
    }
    return Number(s1.replace(".","")) * Number(s2.replace(".","")) / Math.pow(10, m)
}

function clearNoNum(obj)
{
	//先把非数字的都替换掉，除了数字和.
	obj.value = obj.value.replace(/[^\d.]/g,"");
	//必须保证第一个为数字而不是.
	obj.value = obj.value.replace(/^\./g,"");
	//保证只有出现一个.而没有多个.
	obj.value = obj.value.replace(/\.{2,}/g,".");
	//保证.只出现一次，而不能出现两次以上
	obj.value = obj.value.replace(".","$#$").replace(/\./g,"").replace("$#$",".");
}