function focusit()
{
	if (document.getElementById("TextBox1").style.color == "#999999")
	{
		document.getElementById("TextBox1").value = "";
		document.getElementById("TextBox1").style.color = "#000000"
	}
}

function blurit()
{
	if (document.getElementById("TextBox1").value == "")
	{
		document.getElementById("TextBox1").value = "写点评论内容吧 您的评论内容对他人有很大帮助";
		document.getElementById("TextBox1").style.color = "#999999"
	}
}


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
        document.getElementById('testlink').href = "/search/dicker.aspx?type=fcl&yid=" + yids;
    }
    
}

function hidden()
{
        
    document.getElementById('mm').style.visibility='hidden';
    
}

function hiddennn()
{
        
    document.getElementById('nn').style.visibility='hidden';
    
}

function ttfcl(i)
{
    
　　document.getElementById("mm").style.visibility="visible";

    var str="<table id='pp' cellspacing='1' cellpadding='3'><tr style='font-weight:bold'><td width=60>目的港</td><td width=60>20GP</td><td width=60>40GP</td><td width=60>40HQ</td><td width=60>45HQ</td><td width=60>船公司</td></tr>";
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
    str = str + "<tr><td colspan='6'>点击运价<strong>标题</strong>，查看该运价更多详细信息<td/></tr>";
    str = str + "</table>"
    mm.innerHTML = str;
}

function ttlcl(i)
{
    
　　document.getElementById("mm").style.visibility="visible";

    var str="<table id='pp' cellspacing='1' cellpadding='3'><tr style='font-weight:bold'><td width=60>目的港</td><td width=80>价格(重量)</td><td width=80>价格(体积)</td><td width=60>船公司</td></tr>";
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
    str = str + "<tr><td colspan='4'>点击运价<strong>主题</strong>，查看该运价更多详细信息<td/></tr>";
    str = str + "</table>"
    mm.innerHTML = str;
}

function ttair(i)
{
    
　　document.getElementById("mm").style.visibility="visible";

    var str="<table id='pp' cellspacing='1' cellpadding='3'><tr style='font-weight:bold'><td>目的港</td><td>M</td><td>N</td><td>+45</td><td>+100</td><td>+300</td><td>+500</td><td>+1000</td></tr>";
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
    str = str + "<tr><td colspan='4'>点击运价<strong>主题</strong>，查看该运价更多详细信息<td/></tr>";
    str = str + "</table>"
    mm.innerHTML = str;
}

function ttnn(i)
{
    
　　document.getElementById("nn").style.visibility="visible";

    var str="<table id='pp' cellspacing='1' cellpadding='3'><tr style='font-weight:bold'><td colspan='2'>公司信息</td></tr>";
    var ss=document.getElementById("Hiddennn1").value.split("**");
    
    nn.style.top=((event.clientY||event.pageY)*1+document.documentElement.scrollTop)+"px";
    nn.style.left=((event.clientX||event.pageX)*1+document.documentElement.scrollLeft)+"px";
    
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
    str = str + "<tr><td colspan='2'><img src='/images/light.gif'></img> 点击运价<strong>标题</strong>，查看该运价更多详细信息及联系人<td/></tr>";
    str = str + "</table>"
    nn.innerHTML = str;
}

