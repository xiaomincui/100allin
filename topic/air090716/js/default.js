function PageJump()
{
if(event.keyCode==13){
event.keyCode=9
document.getElementById("btnPageJump").click();
};
}

function testlink()
{
    var yids = document.getElementById('delList').value;
    if (yids == "")
    {
        alert("请选择运价后进行讨价还价")
        document.getElementById('testlink').target = "_self";
        document.getElementById('testlink').href = "javascript:;";
    }
    else
    {   
        document.getElementById('testlink').target = "_blank";
        document.getElementById('testlink').href = "/search/dicker.aspx?type=company&yid=" + yids;
    }
    
}

function hidden()
{
        
    document.getElementById('mm').style.visibility='hidden';
    
}


function tt(i)
{
    
　　document.getElementById("mm").style.visibility="visible";

    var str="<table id='pp' cellspacing='1' cellpadding='3'><tr style='font-weight:bold'><td>目的港</td><td>20GP</td><td>40GP</td><td>40HQ</td></tr>";
    var ss=document.getElementById("Hidden1").value.split("**");
    
    mm.style.top=((event.clientY||event.pageY)*1+document.documentElement.scrollTop)+"px";
    mm.style.left=((event.clientX||event.pageX)*1+document.documentElement.scrollLeft)+"px";
    
    var pp = ss[i].split("$$");

    
    for(var j=0;j<pp.length;j=j+1)
    {
        var price = pp[j].split("##");
        str = str + "<tr>"
        for(var k=0;k<price.length;k=k+1)
        {
            str = str + "<td>" + price[k]+"</td>";
            
        }
        str = str + "</tr>"
    }
    str = str + "<tr><td colspan='4'><img src='/images/light.gif'></img> 点击运价<strong>标题</strong>，查看该运价更多详细信息及联系人<td/></tr>";
    str = str + "</table>"
    mm.innerHTML = str;
}

function showmore(t,n,l,la,sc)
{
    
　　document.getElementById("more").style.visibility="visible";

    var str="";
    
    str += "<a href=\"/company/list-广东省-汕头市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\" target=\"_blank\">汕头</a> "
    str += "<a href=\"/company/list-福建省-福州市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\" target=\"_blank\">福州</a> "
    str += "<a href=\"/company/list-福建省-泉州市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\" target=\"_blank\">泉州</a> "
    str += "<a href=\"/company/list-浙江省-舟山市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\" target=\"_blank\">舟山</a> "
    str += "<a href=\"/company/list-江苏省-镇江市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\" target=\"_blank\">镇江</a> "
    str += "<a href=\"/company/list-辽宁省-营口市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\" target=\"_blank\">营口</a> "
	str += "<br/>"
    str += "<a href=\"/company/list-河北省-唐山市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\" target=\"_blank\">唐山</a> "
	str += "<a href=\"/company/list-河北省-秦皇岛市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\" target=\"_blank\">秦皇岛</a> "
    str += "<a href=\"/company/list-山东省-烟台市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\" target=\"_blank\">烟台</a> "
    str += "<a href=\"/company/list-山东省-日照市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\" target=\"_blank\">日照</a> "
    str += "<a href=\"/company/list-广东省-湛江市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\" target=\"_blank\">湛江</a> "
   
    more.style.top=((event.clientY||event.pageY)*1+document.documentElement.scrollTop)+"px";
    more.style.left=((event.clientX||event.pageX)*1+document.documentElement.scrollLeft)+"px";

    more.innerHTML = str;
}




$.fn.extend({
        Scroll:function(opt,callback){
                //参数初始化
                if(!opt) var opt={};
                var _this=this.eq(0).find("table:first");
                var        lineH=_this.find("tr:first").height(), //获取行高
                        line=opt.line?parseInt(opt.line,10):parseInt(this.height()/lineH,10), //每次滚动的行数，默认为一屏，即父容器高度
                        speed=opt.speed?parseInt(opt.speed,10):500, //卷动速度，数值越大，速度越慢（毫秒）
                        timer=opt.timer?parseInt(opt.timer,10):3000; //滚动的时间间隔（毫秒）
                if(line==0) line=1;
                var upHeight=0-line*lineH;
                //滚动函数
                scrollUp=function(){
                        _this.animate({
                                marginTop:upHeight
                        },speed,function(){
                                for(i=1;i<=line;i++){
                                        _this.find("tr:first").appendTo(_this);
                                }
                                _this.css({marginTop:0});
                        });
                }
                //鼠标事件绑定
                _this.hover(function(){
                        clearInterval(timerID);
                },function(){
                        timerID=setInterval("scrollUp()",timer);
                }).mouseout();
        }        
});

$.fn.extend({
        Scroll2:function(opt,callback){
                //参数初始化
                if(!opt) var opt={};
                var _this=this.eq(0).find("table:first");
                var        lineH=_this.find("tr:first").height(), //获取行高
                        line=opt.line?parseInt(opt.line,10):parseInt(this.height()/lineH,10), //每次滚动的行数，默认为一屏，即父容器高度
                        speed=opt.speed?parseInt(opt.speed,10):500, //卷动速度，数值越大，速度越慢（毫秒）
                        timer=opt.timer?parseInt(opt.timer,10):3000; //滚动的时间间隔（毫秒）
                if(line==0) line=1;
                var upHeight=0-line*lineH;
                //滚动函数
                scrollUp2=function(){
                        _this.animate({
                                marginTop:upHeight
                        },speed,function(){
                                for(i=1;i<=line;i++){
                                        _this.find("tr:first").appendTo(_this);
                                }
                                _this.css({marginTop:0});
                        });
                }
                //鼠标事件绑定
                _this.hover(function(){
                        clearInterval(timerID2);
                },function(){
                        timerID2=setInterval("scrollUp2()",timer);
                }).mouseout();
        }        
});

$(document).ready(function(){
        $("#scrollLcl").Scroll({line:4,speed:1000,timer:5000});
});

$(document).ready(function(){
        $("#scrollCompany").Scroll2({line:4,speed:1000,timer:5000});
});
