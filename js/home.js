function change_search(id)
{
	document.getElementById('fcl_search').style.display = "none";
	document.getElementById('lcl_search').style.display = "none";
	document.getElementById('air_search').style.display = "none";
	document.getElementById('company_search').style.display = "none";	
	document.getElementById(id).style.display = "";
	
	document.getElementById('fcl_search_tab').className = "";
	document.getElementById('lcl_search_tab').className = "";
	document.getElementById('air_search_tab').className = "";
	document.getElementById('company_search_tab').className = "";
	document.getElementById(id+'_tab').className = "set";
}

function focus_input(id,value)
{
	if (document.getElementById(id).style.color == "#cccccc")
	{
		document.getElementById(id).value = "";
		document.getElementById(id).style.color = "#000000"
	}
	if (document.getElementById(id).style.color == "rgb(204, 204, 204)")
	{
		document.getElementById(id).value = "";
		document.getElementById(id).style.color = "#000000"
	}
}

function blur_input(id,value)
{
	
	if (document.getElementById(id).value == "")
	{
		//alert("");
		document.getElementById(id).value = value;
		document.getElementById(id).style.color = "#cccccc"
	}
}

function focusit()
{
	if (document.getElementById("txtUsername").style.color == "#ccc")
	{
		document.getElementById("txtUsername").value = "";
		document.getElementById("txtUsername").style.color = "#000000"
	}
}

function blurit()
{
	if (document.getElementById("txtUsername").value == "")
	{
		document.getElementById("txtUsername").value = "输入用户名";
		document.getElementById("txtUsername").style.color = "#ccc"
	}
}

function focusit1()
{
	if (document.getElementById("password_tip").style.display == "")
	{
		document.getElementById("password_tip").style.display = "none"
	}
}

function blurit1()
{
	if (document.getElementById("txtPassword").value == "")
	{
		document.getElementById("password_tip").style.display = ""
	}
}


function search_focus()
{
	if (document.getElementById("txtUsername").style.color == "#ccc")
	{
		document.getElementById("txtUsername").value = "";
		document.getElementById("txtUsername").style.color = "#000000"
	}
}

function search_blur()
{
	if (document.getElementById("txtUsername").style.color == "#ccc")
	{
		document.getElementById("txtUsername").value = "";
		document.getElementById("txtUsername").style.color = "#000000"
	}
}

function search_fcl_jump()
{
    var sp = document.getElementById('txtStartport').value;
    var dp = document.getElementById('txtDestport').value.replace("-","$");
    var cr = document.getElementById('txtCarrier').value;
    var l = document.getElementById('txtLine').selectedIndex;
	
	if (document.getElementById('txtStartport').style.color == "#cccccc" || document.getElementById('txtStartport').style.color == "rgb(204, 204, 204)")
	{
		sp = "";
	}
	
	if (document.getElementById('txtDestport').style.color == "#cccccc" || document.getElementById('txtDestport').style.color == "rgb(204, 204, 204)")
	{
		dp = "";
	}
	
	if (document.getElementById('txtCarrier').style.color == "#cccccc" || document.getElementById('txtCarrier').style.color == "rgb(204, 204, 204)")
	{
		cr = "";
	}
	
	if (document.getElementById('txtLine').style.color == "#cccccc" || document.getElementById('txtLine').style.color == "rgb(204, 204, 204)")
	{
		l = "";
	}
	
	//alert(dp);
    document.getElementById('fcl_jump').href = "/fcl/" + "list" + "-" + sp + "-" + dp + "-" + cr + "-" + l +"-0-0-----1.html";
}


function search_lcl_jump()
{
    var sp = document.getElementById('txtStartport2').value;
    var dp = document.getElementById('txtDestport2').value;
    var cr = document.getElementById('txtCarrier2').value;
    var l = document.getElementById('txtLine2').selectedIndex;
	
	if (document.getElementById('txtStartport2').style.color == "#cccccc")
	{
		sp = "";
	}
	
	if (document.getElementById('txtDestport2').style.color == "#cccccc")
	{
		dp = "";
	}
	
	if (document.getElementById('txtCarrier2').style.color == "#cccccc")
	{
		cr = "";
	}
	
	if (document.getElementById('txtLine2').style.color == "#cccccc")
	{
		l = "";
	}
	
    document.getElementById('lcl_jump').href = "/lcl/" + "list" + "-" + sp + "-" + dp + "-" + cr + "-" + l +"-0-0-----1.html";
}

function search_air_jump()
{
    var sp = document.getElementById('txtStartport3').value;
    var dp = document.getElementById('txtDestport3').value;
    var l = document.getElementById('txtLine3').selectedIndex;
	
	if (document.getElementById('txtStartport3').style.color == "#cccccc")
	{
		sp = "";
	}
	
	if (document.getElementById('txtDestport3').style.color == "#cccccc")
	{
		dp = "";
	}
	
	
	if (document.getElementById('txtLine3').style.color == "#cccccc")
	{
		l = "";
	}
	
    document.getElementById('air_jump').href = "/air/" + "list" + "-" + sp + "-" + dp + "--" + l +"-0-0-----1.html";
}

function search_company_jump()
{
    var sp = document.getElementById('txtCompanyName').value;
	
	if (document.getElementById('txtCompanyName').style.color == "#cccccc")
	{
		sp = "";
	}
		
    document.getElementById('company_jump').href = "/company/list----" + sp + "---0-0----------1.html";
}


function testlink2()
{
    var t = document.getElementById('loginselectdis').value;
    var sp = document.getElementById('txtStartport2').value;
    var dp = document.getElementById('txtDestport2').value;
    var l = document.getElementById('txtLine2').selectedIndex;
    document.getElementById('testlink2').href = "/air/list-" + sp + "-" + dp + "--" + l +"-0-0-----1.html";
}

function changetype()
{
    if (document.getElementById('loginselectdis').selectedIndex == '2')
    {
        document.getElementById('spancl').style.display = "none";
        document.getElementById('testlink').style.display = "none"; 
        document.getElementById('txtLine').style.display = "none"; 
        
        document.getElementById('spanair').style.display = "";
        document.getElementById('testlink2').style.display = ""; 
        document.getElementById('txtLine2').style.display = ""; 
    }
    else
    {
        document.getElementById('spancl').style.display = "";
        document.getElementById('testlink').style.display = "";
        document.getElementById('txtLine').style.display = "";  
        
        document.getElementById('spanair').style.display = "none";
        document.getElementById('testlink2').style.display = "none";  
        document.getElementById('txtLine2').style.display = "none";  
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


function tt(i,k)
{
    
　　document.getElementById("mm").style.visibility="visible";
    var strend="";
    var str="<table id='pp'><tr style='font-weight:bold'><td>目的港</td><td>";
    if(k==1)
    {
        str = str + "20GP</td><td>40GP</td><td>40HQ</td><td>45HQ</td><td>船公司</td></tr>";
        strend="6";
    }
    if(k==2)
    {
        str = str + "价格(重量)</td><td>价格(体积)</td></tr>";
       strend="3";
    }
    if(k==3)
    {
        str = str + "M</td><td>N</td><td>+45</td><td>+100</td><td>+300</td><td>+500</td><td>+1000</td></tr>";
        strend="8";
    }
    
    var ss=document.getElementById("Hidden"+k).value.split("**");
    
    
    mm.style.top=((event.clientY||event.pageY)*1+document.documentElement.scrollTop)+"px";
    mm.style.left=((event.clientX||event.pageX)*1+document.documentElement.scrollLeft+15)+"px";
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
    str = str + "<tr><td colspan='" + strend + "'> 点击运价<strong>标题</strong>，查看该运价更多详细信息及联系人<td/></tr>";
    str = str + "</table>"
    mm.innerHTML = str;
        
    
}

function ttnn(i,k)
{
    
　　document.getElementById("nn").style.visibility="visible";

    var str="<table id='pp' cellspacing='1' cellpadding='3'><tr style='font-weight:bold'><td colspan='2'>公司信息</td></tr>";
    var ss=document.getElementById("Hiddennn" + k).value.split("**");
    
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

function show_release_freight()
{
    document.getElementById("release_freight").style.display = "";
}

function hide_release_freight()
{
    document.getElementById("release_freight").style.display = "none";
}

function show_release_cargo()
{
    document.getElementById("release_cargo").style.display = "";
}

function hide_release_cargo()
{
    document.getElementById("release_cargo").style.display = "none";
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

function KeyDown()
{
if(event.keyCode==13)event.keyCode=9;
}


function loginInput_check(o,str)
{
	var txt = o;
	if(txt.value.length<1){
			txt.value=str
			txt.style.color="#ccc";
	}else
	{
		if(txt.value===str){
			txt.value="";
			txt.style.color="#000000";
		}
	}
}

jQuery(document).ready(
	function()
	{
		$("#txtCarrier").hover(
			function()
			{
				$("#spanCarrier").attr({"style": 'display:inline'});
				$("#spanCarrier").animate({opacity: 1, top: "-55"}, {queue:false, duration:200});
			}, 
			function(){
				$("#spanCarrier").animate({opacity: 0, top: "-50"}, {queue:false, duration:200, complete: function(){$("#spanCarrier").attr({"style": 'display:none'});}});
			}
		);
	});