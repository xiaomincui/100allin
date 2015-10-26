/*********************************************************
文件名：port.js
Encode：utf-8
Copuright(c) 2010-2011 徐奕峰
文件编号：Auto_Words_js_1
创建人：徐奕峰
版本：1.0
日期：2010-03-09
修改人：
日期：
描述：主页港口搜索框的自动完成功能（AJAX交互）
      3-10增加支持键盘 ↑↓选择 操作, 回车 确定选择功能。
      3-11继续完善操作细节。解决和输入法冲突。
      提取港口信息：Get_Prot()
      
      已测浏览器 IE6,firefox,chrome.
      不兼容 opera浏览器
      前台：Default.aspx
      后台：PostBack/Port.aspx
      
备注：支持文件 prototype.js
               
**********************************************************/

var t1 = "loading_prot_txt"; /*启运港*/
var t2 = "destination_prot_txt";/*目的港*/
var loadimg = "loading.gif";/*loading图片路径*/

var url = "PostBack/Port.aspx";
var currentIndex = -1;
    

/**
 * 动态创建div，并弹出
 * @param objid 对象id
*/
function autowords(objid,event)
{
	var obj = document.getElementById(objid);
	if(!obj)return;
	var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
	if(keyCode == 9)closediv();
	if(obj.value.length<1){closediv();return;}/*判断文本框里是否有文字*/
	if(document.getElementById("autodiv"+objid)==null)/*判断是否已经创建过div*/
	{
	    var div = document.createElement("DIV");
	    div.setAttribute("id","autodiv"+objid);
	    var pos = getPosition(obj);
	    div.style.left = pos.x+"px";
        //div.style.width = obj.offsetWidth+"px";
        div.style.width = "300px";
        var h = pos.y + obj.offsetHeight;
        div.style.top = h +"px";
        div.style.visibility = "visible";
        div.style.position = "absolute";
        div.style.zIndex = "2";
	    div.style.overflow = "auto";
	    //div.style.height= "150px";
	    div.className ="autodiv";
	    div.style.border = "1px solid #000000";
        document.body.appendChild(div);
        
    }
    //如果按下 向上, 向下 或 回车
    if (keyCode == 38 || keyCode == 40 ){
        SelectItem(keyCode,objid);/*注册键盘操作事件*/
    }
    else
    {
        if(keyCode == 13){ /*解决与输入法冲突*/
            if(currentIndex ==-1)
            {
                Get_Prot(objid);
             }
             else
            {
                SelectItem(keyCode,objid);/*注册键盘操作事件*/
            }
        }
        else
        {
            Get_Prot(objid);
        }
    }
}
function closediv()
{
    hidediv(t1);
    hidediv(t2);
    currentIndex = -1;
}
/**
 * 消除动态创建的div
*/
function hidediv(objid)
{
	var divobj = document.getElementById("autodiv"+objid);
	if(!divobj)return;
	divobj.parentNode.removeChild(divobj);
	currentIndex = -1;
}

/**
 * 获取控件绝对位置
 * @param obj 对象
 * @return 坐标x:_x, y:_y
*/
function getPosition(obj)
{
        var _x = 0;
        var _y = 0;
        while(null != obj.offsetParent){
            _x += obj.offsetLeft;
            _y += obj.offsetTop;
            obj = obj.offsetParent;
        }
        return {x:_x, y:_y};
}

/**
 * 根据txtbox id 判断港口类型，获取相应的港口信息
 * @param objid 对象id
 * @return 港口信息
*/
function Get_Prot(objid)
{
    var prot_str ="";
    var tar = document.getElementById(objid).value;
    if(tar.length<1){return;}else{
    document.getElementById("autodiv"+objid).innerHTML = "<img src=\""+loadimg+"\" alt=\"loading\"/>正在智能匹配港口名称，请稍候...";
    httpurl = url + "?action=GetProt&obj="+objid+"&tar="+str2code(tar.replace(/(^\s*)|(\s*$)/g,""));
    new Ajax.Request(httpurl,   
    {     
            method:'get',
            onSuccess: function(transport)
            {       
                var o = transport.responseText || "no response Text";
                var cn="",ch="";
                var txt = [];
                var res = o || "[]";
                eval("txt = " + res);
                for (var i = 0; i < txt.length-1; i++) 
                {
                    cn = txt[i].CN;
                    ch = txt[i].CNCH;
                    if(objid == t1)
                    prot_str +="<a href=\"#\" onclick=\"document.getElementById('"+objid+"').value='"+cn+"';hidediv('"+objid+"');\" id=\""+cn+"\"><span>"+ch+"</span>"+cn+"</a>";
                    if(objid == t2)
                    prot_str +="<a href=\"#\" onclick=\"document.getElementById('"+objid+"').value='"+cn+"';hidediv('"+objid+"');\" title=\""+txt[i].Country+"\" id=\""+cn+"\"><span>"+ch+"("+txt[i].CountryCH+")</span>"+cn+"</a>";
                }
                var html_str ="";
                html_str += "<div id=\"prot_warp\">";
                if(txt.length<2){
                html_str += "<div id=\"prot_message\" style=\"color:#C0C0C0\">对不起,找不到:"+tar+"</div>";}
                else{
                html_str += "<div id=\"prot_message\">输入中文/拼音/缩写或↑↓选择.</div>";}
				html_str += "<div id=\"prot_list\">";
				html_str += prot_str;
				html_str += "</div></div>";
                document.getElementById("autodiv"+objid).innerHTML = html_str;
                currentIndex = -1;
                if (typeof document.attachEvent!='undefined'){
                    document.attachEvent("onclick",closediv)
                }else{
                    document.addEventListener("click",closediv,false);
                }
             },
         onFailure: function(){
         alert("Something went wrong...Please contact with the website manager!");
         }});
   }
   
}

/**
 * 响应键盘操作
 * @param keyCode 按键码
 * @param objid 对象id
*/
function SelectItem(keyCode,objid)
{
    var myArray = document.getElementById("prot_list").getElementsByTagName("a");
    var Length = myArray.length;
    //向上 
    if (keyCode == 38){
    currentIndex-=1;if(currentIndex < 0 ) currentIndex = Length-1;}
    //向下 
    if (keyCode == 40){
    currentIndex+=1;if(currentIndex == Length)currentIndex = 0;}
    //回车 
    if (keyCode == 13) 
    {
        var s = myArray[currentIndex].id;
        document.getElementById(objid).value=s;
        hidediv(objid);
        return false;
    }
    
    for(var i = 0; i < Length; i++)
    {
        myArray[i].className ="";
    }
    myArray[currentIndex].className = "hov";
    myArray[currentIndex].focus();
    document.getElementById(objid).focus();
}
/*处理用户输入字符*/
var unit = 6;
function str2code(str){
    var code = "";
	var char;
	var charLength = 0;
	for(i = 0; i < str.length; i++){
	    char = str.charCodeAt(i);
		charLength = (char + "").length;
		if(charLength < unit){
		    for(j=0;j<(unit - charLength);j++){
			    char = "0" + char;
			}
		}
		code += char;
	}
    return code;
}
