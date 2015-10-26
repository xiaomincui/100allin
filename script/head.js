<!--
var loc=stringA=location.href.toLowerCase()
var strhref=""
var strlocation="/";
var len=strlocation.length;
var pos=stringA.indexOf(strlocation)

function lastfilename(stringA){

if (pos>=0){
	stringA=stringA.substring(pos+len,stringA.length);
	while (stringA.indexOf("/")>=0){
		pos=stringA.indexOf("/")
		stringA=stringA.substring(pos+1,stringA.length);
	}
}
return stringA
}	


function lastfoldername(stringA){
if (pos>=0){
	var pos1,pos2
	pos1 = stringA.lastIndexOf("/")//得到所在目录位置end
	stringA=stringA.substring(pos+len,pos1);
	pos2 = stringA.lastIndexOf("/")//得到所在目录位置start
	stringA=stringA.substring(pos2+1,pos1)
	}
return stringA
}
function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}
function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}



/*------------------------------------------------------------------------------------------[0]--END*/




/*START--[0]-------------------------------------------------------------------------定义判断类型*/

var lastfoldername=lastfoldername(stringA)


/*------------------------------------------------------------------------------------------[0]--END*/



/*START--[0]------------------------------------------------------links[x] = 这儿输入连接页面--*/



//可添加更多数组

var links = new Array();
links[0] = "index.asp";
links[1] = "intro";
links[2] = "../intro";
links[3] = "../intro";
links[4] = "../intro";
links[5] = "../intro";
links[6] = "../advice";
links[7] = "paper";
links[8] = "../advice";

/*var name = new Array()
name[0] = "Image5";
name[1] = "Image6";
name[2] = "Image7";
name[3] = "Image8";
name[4] = "Image9";*/
//name[5] = "Image10";
//name[6] = "Image11";

var pic = new Array()
pic[0] = "images/mune/mune1.jpg";
pic[1] = " images/mune/mune2.jpg";
pic[2] = " images/mune/mune3.jpg";
pic[3] = " images/mune/mune4.jpg";
pic[4] = " images/mune/mune5.jpg";
pic[5] = " images/mune/mune6.jpg";
pic[6] = " images/mune/mune7.jpg";
pic[7] = " images/mune/mune8.jpg";
pic[8] = " images/mune/mune9.jpg";


var pic1 = new Array()
pic1[0] = " images/mune/mune_1.jpg";
pic1[1] = " images/mune/mune_2.jpg";
pic1[2] = " images/mune/mune_3.jpg";
pic1[3] = " images/mune/mune_4.jpg";
pic1[4] = " images/mune/mune_5.jpg";
pic1[5] = " images/mune/mune_6.jpg";
pic1[6] = " images/mune/mune_7.jpg";
pic1[7] = " images/mune/mune_8.jpg";
pic1[8] = " images/mune/mune_9.jpg";



/*----------------------------------------------------------------------------------------------[0]--END*/

     document.write("<table  border='0' cellspacing='0' cellpadding='0'>");
     document.write("<tr>") ;
	 //document.write("<td><img src='../images/pu_index/mune_lift.jpg'></td>") ;
	 
for (var i=0; i<links.length; i++) {

// 判断验证
	temp = links[i].replace(/(.+\/)/,"")
//	document.write(temp) 
//	document.write(anyfoldername) 
//	document.write(lastfilename)
	if (temp == lastfoldername){
	
// 判断后内容
    document.write("<td><a id=menu"+[i+1]+" href=\""+links[i]+"\"><img src='"+pic1[i]+"' id=button"+[1+i]+" name=button"+[1+i]+" border='0'></a></td>");
	}
	else{
		//document.write("<td><a id=menu"+[i+1]+" href=\""+links[i]+"\"><img src='"+pic[i]+"' id=button"+[1+i]+" name=button"+[1+i]+" border='0'></a></td>");
	document.write("<td><a href=\""+links[i]+"\" id=menu"+[i+1]+" onMouseOut=\"MM_swapImgRestore()\"onMouseOver=\"MM_swapImage(\'Image2"+[i]+"\',\'\',\'"+pic1[i]+"\',1)\"><img src=\""+pic[i]+"\" name=\"Image2"+[i]+"\"  border=\"0\" id=button"+[1+i]+" name=button"+[1+i]+"></a></td>");
	}
}
document.write("<td><img src='images/mune/lift.jpg'></td>") ;
document.write("</tr>");
document.write("</table>");
//-->