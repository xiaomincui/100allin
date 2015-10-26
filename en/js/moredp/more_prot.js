/*********************************************************
文件名：more_prot.js
Encode：utf-8
Copuright(c) 2010-2011 徐奕峰
文件编号：More_Prot_Div_js_1
创建人：徐奕峰
版本：1.0
日期：2010-03-16
修改人：
日期：
描述：索列表页面港口信息“更多”按钮的弹出层显示
      
      提取港口：_get_prot(line)
      
      已测浏览器 IE6,firefox,chrome.
      不兼容 opera浏览器
      前台：Default.aspx
      后台：PostBack/Port.aspx
      
备注：支持文件 prototype.js
               
**********************************************************/
 var Route = '[{"url":"0","rou":"全部"},{"url":"1","rou":"美加线"},{"url":"2","rou":"欧地线"},{"url":"3","rou":"中南美线"},{"url":"4","rou":"日韩线"},{"url":"5","rou":"近洋线"},{"url":"6","rou":"非洲线"},{"url":"7","rou":"澳洲线"},{"url":"8","rou":"中东印巴线"},{"url":"9","rou":"红海线"}]';
var page_sum_all = 24;/*每页的消息总数 4列 6行 根据显示宽度不同，可显示列数不同。*/
var _language = "zh"; /*默认显示的语言类型中文/英文  zh|en */
var _abc_selected = ""; /*记录英文范围的值*/
var prot_txt = ""; /*记录Ajax传回的值*/
var more_url = "/js/moredp/PostBack/Port.aspx";

window.onload = load_line;
function load_line()
{   
    var id= document.getElementById("hidLine").value;
    //var id= request("l");
    if(id.length>0)
    {
        _get_prot(id);
    }
    ch_bgc();
}
/**
 * 鼠标移过 tab时 改变背景色，并切换港口信息
*/
function ch_bgc()
{
    var idtest = document.getElementById("tab_list").getElementsByTagName("li");
    for (var i = 0; i < idtest.length; i++) 
    {
        
        idtest[i].onmouseover = function() {
            var _li = document.getElementById("tab_list").getElementsByTagName("li");
            for(var j=0;j<_li.length;j++){_li[j].className = "tab_li_out";}
            this.className = "tab_li_on";
            _abc_selected = this.id;
            show_prot_li(this.id,page_sum_all,1);
        }
    }
}

/**
 * 切换语言
*/
function ch_lan(obj,lan)
{
    obj.className ="select_Language";
    document.getElementById("language_"+lan).className = "noselect_Language";
    var s = obj.id;
    _language = s.substring(s.indexOf("_")+1,s.length);
    show_prot_li(_abc_selected,page_sum_all,1);
}

/**
 * 提取港口信息
*/
function _get_prot(line)
{
    var a = new Date();/*监测时间语句，可删除*/
    var prot_str = "";
    var i =0;
    var txt = [];
    eval("txt="+Route);
    for(i =0 ;i<txt.length;i++)
    {
        if(txt[i].url==line)
        {
            prot_str = txt[i].rou;
            break;
        }
    }
    var httpurl = more_url + "?action=GetProt&t=2&tar="+str2code(prot_str.replace(/(^\s*)|(\s*$)/g,""));
    new Ajax.Request(httpurl,   
    {     
            method:'get',
            onSuccess: function(transport)
            {       
                var o = transport.responseText || "no response Text";
                prot_txt = o;
                /*以下为测试内容*/
                eval("txt="+o);
                var s_t ="";
                for(i=0;i<txt.length-1;i++)
                {
                    s_t += "<li><a title=\""+txt[i].ENFL+"\">";
                    s_t += txt[i].CN;
                    s_t += "</a></li>";
                }
                document.getElementById("prot_list_u").innerHTML = s_t;
                //document.getElementById("msg").innerHTML = "<dl><dt>从后台提取数据共花：</dt><dd>" + (new Date().getTime()-a.getTime()) + "毫秒</dd></dl>";
                /*测试完*/
                /*显示港口信息列表*/
                show_prot_li("AC",page_sum_all,1);
             },
         onFailure: function(){
         alert("Something went wrong...Please contact with the website manager!");
    }});
}


/**
 * 显示港口信息列表
 * @param abc  字母范围
 * @param page_sum  每页的li的总数
 * @param page  当前页数
 * @return 此范围内的字母数组
 * @call _push_mid_abc(A-D)
 *       return [A,B,C,D]
*/
function show_prot_li(abc,page_sum,page)
{
    var a = new Date();/*监测时间语句，可删除*/
    if(prot_txt.length >0){var aaaa=0;
        var arr_a = [],txt = [];
        var s_t ="",pagenumber_s="";
        arr_a = _push_mid_abc(abc);
        var i=0,j=0,sum=0,arr_h=0;
        arr_h = arr_a.length;
        eval("txt="+prot_txt);
        var e = page_sum*page;
        var h = e-page_sum;
        var max = h+page_sum;
        if(max>=txt.length)max = txt.length-1;
        for(j=0;j<=txt.length-1;j++)
        {
            
            for(i=0;i<arr_h;i++)
            {
                if(sum>=h && sum<page_sum*page)
                {
                    if(_language == "zh")
                    if(txt[j].CHFL == arr_a[i])
                    {
                        s_t += "<li><a title=\""+txt[j].CN+"\" href=\"/" + document.getElementById("hidType").value +"/list-"+ document.getElementById("hidStartport").value +"-"+ txt[j].CN  +"-" + document.getElementById("hidCarrier").value + "-0-0-0-----1.html\">"+txt[j].CNCH+"</a></li>";
                        sum++;
                    }
                    if(_language == "en")
                    if(txt[j].ENFL == arr_a[i])
                    {
                        s_t += "<li><a title=\""+txt[j].CNCH+"\" href=\"/" + document.getElementById("hidType").value +"/list-"+ document.getElementById("hidStartport").value +"-"+ txt[j].CN  +"-" + document.getElementById("hidCarrier").value + "-0-0-0-----1.html\">"+txt[j].CN+"</a></li>";
                        sum++;
                    }
                }
                else
                {
                    if(_language == "zh")
                    if(txt[j].CHFL == arr_a[i])
                    {
                        sum++;
                    }
                    if(_language == "en")
                    if(txt[j].ENFL == arr_a[i])
                    {
                        sum++;
                    }
                }
            }
        }
        /*生成页码*/
        var pn = Math.ceil(sum/page_sum);
        if(pn>=2)
        for(var k=pn;k>0;k--)
        {
            if (page == k)
            {
            pagenumber_s +=" <a href=\"javascript:void(0);\" style=\"background:#DDDDDD;\" title=\"第"+k+"页\" onmousemove=\"show_prot_li('"+abc+"',"+page_sum+","+k+")\">"+k+"</a> ";
            }
            else
            {
            pagenumber_s +=" <a href=\"javascript:void(0);\" title=\"第"+k+"页\" onmousemove=\"show_prot_li('"+abc+"',"+page_sum+","+k+")\">"+k+"</a> ";
            }

        }
        /*监测时间语句，可删除*/var time1 = new Date().getTime()-a.getTime();
        var b = new Date();/*监测时间语句，可删除*/
        document.getElementById("page_number").innerHTML = pagenumber_s ;
        document.getElementById("prot_list_u").innerHTML = s_t;
        ///*监测时间语句，可删除*/document.getElementById("msg").innerHTML += "<dl><dt>重新排序花费：</dt><dd>" + (new Date().getTime()-a.getTime()) + "毫秒</dd></dl>";
        //document.getElementById("msg").innerHTML += "<dl><dt>页面显示花费：</dt><dd>" + (new Date().getTime()-b.getTime()) + "毫秒</dd></dl>";
    }
}

/**
 * 将id传来的范围补全
 * @param id  范围的id
 * @return 此范围内的字母数组
 * @call _push_mid_abc(A-D)
 *       return [A,B,C,D]
*/
function _push_mid_abc(id)
{
    var abc_arr = [],_ar_cir = [];
    var abc_str = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
    abc_arr = abc_str.split(',');
    if(id.length<1)id="AC";
    var _s_cir = id.split('');
    var t1 = _s_cir[0].toUpperCase();
    var t2 = _s_cir[1].toUpperCase();
    for(var i=0;i<abc_arr.length;i++)
    {
        if(abc_arr[i] >= t1 && abc_arr[i] <= t2)
        {
            _ar_cir.push(abc_arr[i]);
        }
        if(abc_arr[i] == t2)break;
    }
    return _ar_cir;
}

/**
 * 获取URL参数
 * @param paras 参数
 * @return 参数的值
*/
function request(paras)
{
	var url=location.href;
	var paraString=url.substring(url.indexOf("?")+1,url.length).split("&");
	var paraObj={};	
	for(i=0;j=paraString[i];i++)
	{
		paraObj[j.substring(0,j.indexOf("=")).toLowerCase()]=j.substring(j.indexOf("=")+1,j.length);
	}
	var returnValue=paraObj[paras.toLowerCase()];
	if(typeof(returnValue)=="undefined")
	{
		return "";
	}else 
	{
		return returnValue;
	}
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