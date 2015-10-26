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
    
    str += "<a href=\"/company/list-广东省-汕头市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\">汕头</a> "
    str += "<a href=\"/company/list-福建省-福州市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\">福州</a> "
    str += "<a href=\"/company/list-福建省-泉州市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\">泉州</a> "
    str += "<a href=\"/company/list-浙江省-舟山市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\">舟山</a> "
    str += "<a href=\"/company/list-江苏省-镇江市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\">镇江</a> "
    str += "<a href=\"/company/list-辽宁省-营口市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\">营口</a> "
	str += "<br/>"
    str += "<a href=\"/company/list-河北省-唐山市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\">唐山</a> "
	str += "<a href=\"/company/list-河北省-秦皇岛市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\">秦皇岛</a> "
    str += "<a href=\"/company/list-山东省-烟台市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\">烟台</a> "
    str += "<a href=\"/company/list-山东省-日照市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\">日照</a> "
    str += "<a href=\"/company/list-广东省-湛江市-" + t + "-" + n + "-" + l + "-" + la + "-0-" + sc + "----------1.html\">湛江</a> "
   
    more.style.top=((event.clientY||event.pageY)*1+document.documentElement.scrollTop)+"px";
    more.style.left=((event.clientX||event.pageX)*1+document.documentElement.scrollLeft)+"px";

    more.innerHTML = str;
}


function hiddenmore()
{
    document.getElementById('more').style.visibility='hidden'; 
}

document.onclick = function() 
{
    if(event.srcElement.id != document.getElementById("more").id && event.srcElement.id != document.getElementById("linkmore").id) 
    { 
       hiddenmore();
    } 
    

}