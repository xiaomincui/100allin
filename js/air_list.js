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
        document.getElementById('testlink').href = "/search/dicker.aspx?type=air&yid=" + yids;
    }
    
}

function hidden(e)
{
	e = window.event||e;
	
	var m_x = document.documentElement.scrollLeft+e.clientX;
	var m_y = document.documentElement.scrollTop+e.clientY;
	
	var d_x = document.getElementById('mm').offsetLeft-10;
	var d_y = document.getElementById('mm').offsetTop;
	
	var d_w = document.getElementById('mm').offsetWidth;
	var d_h = document.getElementById('mm').offsetHeight;
	

	if (m_x >= d_x & m_y >= d_y)
	{
		
	}
	else
	{
		document.getElementById('mm').style.visibility='hidden';
		pop_id = 0;
	}

}


function hidden1()
{
	//document.getElementById('test_1').innerHTML = d_x;
	document.getElementById('mm').style.visibility='hidden';
	pop_id = 0;
}

var pop_id = 0
//弹出窗口显示的是哪条信息


function tt(i,id,e)
{
	
	if (pop_id == 0)
	{
		tt_sub(i,id,e);	
		pop_id = id;
	}
	else
	{
		if (pop_id != id)
		{
			tt_sub(i,id,e);
			pop_id = id;
		}
	}
	
    

}

function tt2(i,id,e)
{
	
	if (pop_id == 0)
	{
		tt_sub2(i,id,e);	
		pop_id = id;
	}
	else
	{
		if (pop_id != id)
		{
			tt_sub2(i,id,e);
			pop_id = id;
		}
	}
}


function tt2_1(i,id,e)
{
	
	if (pop_id == 0)
	{
		tt_sub2_1(i,id,e);	
		pop_id = id;
	}
	else
	{
		if (pop_id != id)
		{
			tt_sub2_1(i,id,e);
			pop_id = id;
		}
	}
}

function   get_x(id){
e = document.getElementById(id)
var   t=e.offsetTop;   
var   l=e.offsetLeft;   
while(e=e.offsetParent){   
t+=e.offsetTop;   
l+=e.offsetLeft;}   
return l
}  


function   get_y(id){
e = document.getElementById(id)
var   t=e.offsetTop;   
var   l=e.offsetLeft;   
while(e=e.offsetParent){   
t+=e.offsetTop;   
l+=e.offsetLeft;}   
return t
}  

function tt_sub(i,id,e)
{			
			
		　　document.getElementById("mm").style.visibility="visible";
		
			var ss=document.getElementById("Hidden1").value.split("$|**|$");
			
			e = window.event||e;


			document.getElementById("mm").style.top=(get_y(id)-50)+"px";
			document.getElementById("mm").style.left=((e.clientX||e.pageX)*1+20+document.documentElement.scrollLeft)+"px";
			
			//mm.style.top=((event.clientY||event.pageY)*1-60+document.documentElement.scrollTop)+"px";
			//mm.style.left=((event.clientX||event.pageX)*1+20+document.documentElement.scrollLeft)+"px";

			var str = "";
			str += "<div class=\"pop_main_sub\">";
			str += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
			str += "<tr><td height=\"28\" colspan=\"8\" align=\"left\"><span style=\"font:12px '宋体'; color:#000000;\">" + document.getElementById(id).innerHTML + "</strong></span></td>";
			str += "<td align=\"right\"><a href=\"javascript:void(0);\" onclick=\"hidden1();\"><img src=\"/images/fcl/close.gif\" width=\"38\" height=\"11\" border=\"0\" /></a></td></tr>";
			str += "<tr><td height=\"10\" colspan=\"9\" align=\"left\"></td></tr>";
			str += "<tr>";
			str += "<td height=\"28\" align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>目的港</strong></span></td>";
			str += "<td align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>+45</strong></span></td>";
			str += "<td align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>+100</strong></span></td>";
			str += "<td align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>+300</strong></span></td>";
			str += "<td align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>+500</strong></span></td>";	
			str += "<td align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>+1000</strong></span></td>";	
			str += "<td width=\"10%\" colspan=\"2\" align=\"left\">&nbsp;</td>";
			str += "<td width=\"10%\" align=\"left\">&nbsp;</td>";
			str += "</tr>";
			str += "<tr><td height=\"10\" colspan=\"9\" align=\"left\" background=\"/images2/fcl/tchu_bg1.GIF\"></td></tr>";
			str += "<tr><td height=\"3\" colspan=\"9\"></td></tr>";
			
			
			var pp = ss[i].split("$$");
		
			
			for(var j=0;j<pp.length;j=j+1)
			{
				var price = pp[j].split("##");
				var price1 = 0;
				str += "<tr>"
				for(var k=0;k<price.length;k=k+1)
				{
					if (price[k].indexOf("查看其余") > -1)
					{
						price1 = 1;	
					}

					if (k == 0)
					{
						str = str + "<td><div class='tmb2'>" + price[k]+"</div></td>";	
					}

					if (k <= 5 & k >=1)
					{
						str = str + "<td>" + price[k]+"</td>";	
					}
					
					if (k == 6)
					{	
						if (price[k] == 1)
						{
							str += "<td><a href=\"/topic/order20091104/readme.aspx#a007\" target=\"_blank\"><img src=\"/images/fcl/cang.gif\" width=\"16\" height=\"16\" border=\"0\" alt=\"舱位保证\" /></a></td>";
						}
						else
						{
							str += "<td></td>";
						}
						
					}
					
					if (k == 7)
					{
						if (price[k] > 0)
						{
							str += "<td><a href=\"/topic/order20091104/readme.aspx#a008\" target=\"_blank\"><img src=\"/images/fcl/dc16.gif\" width=\"16\" height=\"16\" border=\"0\" alt=\"价格保证\" /></a></td>";
						}
						else
						{
							str += "<td></td>";
						}						
					}
					
					if (k == 8)
					{
						str += "<td align=\"center\"  class=\"dc\"><a href=\"/search/air_order.aspx?filter=new&" + price[k] + "\" target=\"_blank\"></a></td>"
					}
				}
					str += "</tr>"

			}
		
			
			str += "<tr></tr>";
			str += "</table>";
			
			
			str += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
			str += "<tr><td height=\"10\" colspan=\"2\" align=\"left\"></td></tr>";
			str += "<tr><td width=\"18%\" height=\"28\" align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>公司信息</strong></span></td>";
			str += "<td width=\"82%\" align=\"left\">&nbsp;</td></tr>"
			str += "<tr><td height=\"10\" colspan=\"2\" align=\"left\" background=\"/images2/fcl/tchu_bg1.GIF\"></td></tr>"
			str += "<tr><td height=\"3\" colspan=\"2\"></td></tr>"

			if(document.getElementById("Hiddennn1").value=="")
			{
				var ss=document.getElementById("Hiddenmm1").value.split("$|**|$");
				
				if(ss[i]=="")
				{
					str = str + "<tr><td colspan=4><div style='padding:10px 10px 10px 10px;'>想查看该用户公司信息请立即 <a href=\"/accounts/login.aspx\">登陆</a> <br />如您还不是环球运费网会员请 <a href=\"/accounts/reg.aspx\">注册</a></div></td></tr>"
				}
				else
				{
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
				}
				
				
				 
			}
			else
			{
				var ss=document.getElementById("Hiddennn1").value.split("$|**|$");
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
				
			}


			
			str += "<tr><td height=\"10\" colspan=\"2\"></td></tr>";
			//str += "<tr><td colspan=\"2\"><h2>为防止运费高收和服务欺诈，100allin提醒您选择“<strong>安运通会员</strong>”进行订舱。如与货代私下订舱交易，风险自担。</h2></td></tr>";
			str += "<tr><td height=\"10\" colspan=\"2\"></td></tr>";
			str += "</table>";
			str += "</div>";
			str += "<div id=\"arrow\"><img src=\"/images2/fcl/tchu_bg2.GIF\" /></div>";
			document.getElementById("pop_main_window").innerHTML = str;
}

function tt_sub2(i,id,e)
{			
			
		　　document.getElementById("mm").style.visibility="visible";
		
			var ss=document.getElementById("Hidden2").value.split("$|**|$");
			
			e = window.event||e;


			document.getElementById("mm").style.top=(get_y(id)-50)+"px";
			document.getElementById("mm").style.left=((e.clientX||e.pageX)*1+20+document.documentElement.scrollLeft)+"px";
			
			//mm.style.top=((event.clientY||event.pageY)*1-60+document.documentElement.scrollTop)+"px";
			//mm.style.left=((event.clientX||event.pageX)*1+20+document.documentElement.scrollLeft)+"px";

			var str = "";
			str += "<div class=\"pop_main_sub\">";
			str += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
			str += "<tr><td height=\"28\" colspan=\"2\" align=\"left\"><span style=\"font:12px '宋体'; color:#000000;\">" + document.getElementById(id).innerHTML + "</strong></span></td>";
			str += "<td align=\"right\"><a href=\"javascript:void(0);\" onclick=\"hidden1();\"><img src=\"/images/fcl/close.gif\" width=\"38\" height=\"11\" border=\"0\" /></a></td></tr>";
			str += "<tr><td height=\"10\" colspan=\"3\" align=\"left\"></td></tr>";
			str += "<tr>";
			str += "<td height=\"28\" align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>标题</strong></span></td>";
			str += "<td align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>目的港</strong></span></td>";
			str += "<td align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>价格</strong></span></td>";
			str += "</tr>";
			str += "<tr><td height=\"10\" colspan=\"3\" align=\"left\" background=\"/images2/fcl/tchu_bg1.GIF\"></td></tr>";
			str += "<tr><td height=\"3\" colspan=\"3\"></td></tr>";
			
			
			var pp = ss[i].split("$$");
		
			
			for(var j=0;j<pp.length;j=j+1)
			{
				var price = pp[j].split("##");
				var price1 = 0;
				str += "<tr>"
				for(var k=0;k<price.length;k=k+1)
				{
					if (price[k].indexOf("查看其余") > -1)
					{
						price1 = 1;	
					}

					if (k == 0)
					{
						str = str + "<td><div class='tmb2'>" + price[k]+"</div></td>";	
					}

					if (k <= 5 & k >=1)
					{
						str = str + "<td>" + price[k]+"</td>";	
					}
					
					if (k == 6)
					{	
						if (price[k] == 1)
						{
							str += "<td><a href=\"/topic/order20091104/readme.aspx#a007\" target=\"_blank\"><img src=\"/images/fcl/cang.gif\" width=\"16\" height=\"16\" border=\"0\" alt=\"舱位保证\" /></a></td>";
						}
						else
						{
							str += "<td></td>";
						}
						
					}
					
					if (k == 7)
					{
						if (price[k] > 0)
						{
							str += "<td><a href=\"/topic/order20091104/readme.aspx#a008\" target=\"_blank\"><img src=\"/images/fcl/dc16.gif\" width=\"16\" height=\"16\" border=\"0\" alt=\"价格保证\" /></a></td>";
						}
						else
						{
							str += "<td></td>";
						}						
					}
					
					if (k == 8)
					{
						str += "<td align=\"center\"  class=\"dc\"><a href=\"/search/air_order.aspx?filter=new&" + price[k] + "\" target=\"_blank\"></a></td>"
					}
				}
					str += "</tr>"

			}
		
			
			str += "<tr></tr>";
			str += "</table>";
			
			
			str += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
			str += "<tr><td height=\"10\" colspan=\"2\" align=\"left\"></td></tr>";
			str += "<tr><td width=\"18%\" height=\"28\" align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>公司信息</strong></span></td>";
			str += "<td width=\"82%\" align=\"left\">&nbsp;</td></tr>"
			str += "<tr><td height=\"10\" colspan=\"2\" align=\"left\" background=\"/images2/fcl/tchu_bg1.GIF\"></td></tr>"
			str += "<tr><td height=\"3\" colspan=\"2\"></td></tr>"

				var ss=document.getElementById("Hiddennn2").value.split("$|**|$");
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

			
			str += "<tr><td height=\"10\" colspan=\"2\"></td></tr>";
			str += "<tr><td height=\"10\" colspan=\"2\"></td></tr>";
			str += "</table>";
			str += "</div>";
			str += "<div id=\"arrow\"><img src=\"/images2/fcl/tchu_bg2.GIF\" /></div>";
			document.getElementById("pop_main_window").innerHTML = str;
}

function tt_sub2_1(i,id,e)
{			
			
		　　document.getElementById("mm").style.visibility="visible";
		
			var ss=document.getElementById("Hidden2").value.split("$|**|$");
			
			e = window.event||e;


			document.getElementById("mm").style.top=(get_y(id)-50)+"px";
			document.getElementById("mm").style.left=((e.clientX||e.pageX)*1+20+document.documentElement.scrollLeft)+"px";
			
			//mm.style.top=((event.clientY||event.pageY)*1-60+document.documentElement.scrollTop)+"px";
			//mm.style.left=((event.clientX||event.pageX)*1+20+document.documentElement.scrollLeft)+"px";

			var str = "";
			str += "<div class=\"pop_main_sub\">";
			str += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
			str += "<tr><td height=\"28\" colspan=\"2\" align=\"left\"><span style=\"font:12px '宋体'; color:#000000;\">" + document.getElementById(id).innerHTML + "</strong></span></td>";
			str += "<td align=\"right\"><a href=\"javascript:void(0);\" onclick=\"hidden1();\"><img src=\"/images/fcl/close.gif\" width=\"38\" height=\"11\" border=\"0\" /></a></td></tr>";
			str += "<tr><td height=\"10\" colspan=\"3\" align=\"left\"></td></tr>";
			str += "<tr>";
			str += "<td height=\"28\" align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>标题</strong></span></td>";
			str += "<td align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>目的港</strong></span></td>";
			str += "<td align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>价格</strong></span></td>";
			str += "</tr>";
			str += "<tr><td height=\"10\" colspan=\"3\" align=\"left\" background=\"/images2/fcl/tchu_bg1.GIF\"></td></tr>";
			str += "<tr><td height=\"3\" colspan=\"3\"></td></tr>";
			
			
			var pp = document.getElementById("Hidden2_1").value.split("$$");
		
			
			for(var j=0;j<pp.length;j=j+1)
			{
				var price = pp[j].split("##");
				var price1 = 0;
				str += "<tr>"
				for(var k=0;k<price.length;k=k+1)
				{
					if (price[k].indexOf("查看其余") > -1)
					{
						price1 = 1;	
					}

					if (k == 0)
					{
						str = str + "<td><div class='tmb2'>" + price[k]+"</div></td>";	
					}

					if (k <= 5 & k >=1)
					{
						str = str + "<td>" + price[k]+"</td>";	
					}
					
					if (k == 6)
					{	
						if (price[k] == 1)
						{
							str += "<td><a href=\"/topic/order20091104/readme.aspx#a007\" target=\"_blank\"><img src=\"/images/fcl/cang.gif\" width=\"16\" height=\"16\" border=\"0\" alt=\"舱位保证\" /></a></td>";
						}
						else
						{
							str += "<td></td>";
						}
						
					}
					
					if (k == 7)
					{
						if (price[k] > 0)
						{
							str += "<td><a href=\"/topic/order20091104/readme.aspx#a008\" target=\"_blank\"><img src=\"/images/fcl/dc16.gif\" width=\"16\" height=\"16\" border=\"0\" alt=\"价格保证\" /></a></td>";
						}
						else
						{
							str += "<td></td>";
						}						
					}
					
					if (k == 8)
					{
						str += "<td align=\"center\"  class=\"dc\"><a href=\"/search/air_order.aspx?filter=new&" + price[k] + "\" target=\"_blank\"></a></td>"
					}
				}
					str += "</tr>"

			}
		
			
			str += "<tr></tr>";
			str += "</table>";
			
			
			str += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
			str += "<tr><td height=\"10\" colspan=\"2\" align=\"left\"></td></tr>";
			str += "<tr><td width=\"18%\" height=\"28\" align=\"left\"><span style=\"font:13px '宋体'; color:#000000;\"><strong>公司信息</strong></span></td>";
			str += "<td width=\"82%\" align=\"left\">&nbsp;</td></tr>"
			str += "<tr><td height=\"10\" colspan=\"2\" align=\"left\" background=\"/images2/fcl/tchu_bg1.GIF\"></td></tr>"
			str += "<tr><td height=\"3\" colspan=\"2\"></td></tr>"

				var ss=document.getElementById("Hiddennn2_1").value.split("$|**|$");
				var pp = document.getElementById("Hiddennn2_1").value.split("$$");
	
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

			
			str += "<tr><td height=\"10\" colspan=\"2\"></td></tr>";
			str += "<tr><td height=\"10\" colspan=\"2\"></td></tr>";
			str += "</table>";
			str += "</div>";
			str += "<div id=\"arrow\"><img src=\"/images2/fcl/tchu_bg2.GIF\" /></div>";
			document.getElementById("pop_main_window").innerHTML = str;
}

function tt_jgpop(e)
{
	e = window.event||e;
	document.getElementById("jgpop").style.visibility="visible";
	
	document.getElementById("jgpop").style.top=((e.clientY||e.pageY)*1+10+document.documentElement.scrollTop)+"px";
	document.getElementById("jgpop").style.left=((e.clientX||e.pageX)*1+10+document.documentElement.scrollLeft)+"px";

}

function hid_jgpop()
{
	document.getElementById("jgpop").style.visibility="hidden";

}

function tt_cwpop(e)
{
	e = window.event||e;
	document.getElementById("cwpop").style.visibility="visible";
	
	document.getElementById("cwpop").style.top=((e.clientY||e.pageY)*1+10+document.documentElement.scrollTop)+"px";
	document.getElementById("cwpop").style.left=((e.clientX||e.pageX)*1+10+document.documentElement.scrollLeft)+"px";

}

function hid_cwpop()
{
	document.getElementById("cwpop").style.visibility="hidden";

}

function tt_dcpop(e)
{
	e = window.event||e;
	document.getElementById("dcpop").style.visibility="visible";
	
	document.getElementById("dcpop").style.top=((e.clientY||e.pageY)*1+10+document.documentElement.scrollTop)+"px";
	document.getElementById("dcpop").style.left=((e.clientX||e.pageX)*1+10+document.documentElement.scrollLeft)+"px";

}

function hid_dcpop()
{
	document.getElementById("dcpop").style.visibility="hidden";

}