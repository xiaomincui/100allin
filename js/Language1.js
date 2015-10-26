if (StranLink_Obj)
{
	var JF_cn="100allin_"+self.location.hostname.toString().replace(/\./g,"")
	var BodyIsFt=readCookie(JF_cn)
	if(BodyIsFt!="1")BodyIsFt=Default_isFT

	with(StranLink_Obj)
	{
		if(typeof(document.all)!="object") 	//非IE浏览器
		{
			href="javascript:StranBody()"
		}
		else
		{
			href="#";
			onclick= new Function("StranBody();return false")
		}
		title=StranText("点击以繁体中文方式浏览",1,1)
		innerHTML=StranText(innerHTML,1,1)
	}
	if(BodyIsFt=="1"){setTimeout("StranBody()",StranIt_Delay)}
}﻿