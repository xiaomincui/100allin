<%@ Page Language="C#" AutoEventWireup="true" CodeFile="repaste.aspx.cs" Inherits="club_repaste_repaste" ValidateRequest="false" %><!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>转贴 - 环球运费网</title>
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/kxcommon-40.css" rel="stylesheet" type="text/css" />
<script src="js/kxbase-3.js" type="text/javascript"></script>
<script src="js/kxcommon-47.js" type="text/javascript"></script>
</head>
<body>
<script language="JavaScript" >
g_im_web = "m101031";
</script>
<clubheader:clubheader ID="clubheader1" runat="server" />
<div id="wrap">
<div id="main">
<clubleft:clubleft ID="clubleft1" runat="server" />
<div id="mainarea">
<div class="left_tit">
<div class="left_tit_text">
<img src="images/icon28.gif" /><strong>转帖</strong></div>
<div class="left_tit_more">
<a href="javascript:history.back(-1);">返回上一页</a></div>
</div>
<div id="tabs2">
<div class="menu2box">
<ul id="menu2">
<li><a href="index.aspx">我的转帖</a></li>
<li><a href="friend.aspx">好友的转帖</a></li>
<li class="hover"><a href="repaste.aspx">我要转帖</a></li>
<li><a href="random.aspx">今日热门</a></li>
</ul>
</div>
<div class="main2box1">
<ul>
<li>
<div id="maincontent">
<div class="m2 wr1">
<div id="r2_2">

<div class="p10">

<form id="form1" runat="server" onsubmit="javascript:return checkRepasteForm(this);">
<input type="hidden" name="rpuserastr" value="2502a7d086d1b85acd49d112c131bd89">
<input type="hidden" name="textarea2" value="">
<input type="hidden" name="uploadfile" value="">
<ul class="m_zt" style="position:relative;margin-left:20px;*margin-left:10px;width:650px;">
<li><span style="width:75px;text-align:right;">帖子标题：&nbsp;</span><em class="it_s">

<input type="text" id="title" name="title" value="" class="it1" onfocus="this.className='it2';" onblur="this.className='it1';" style="width:550px" onpropertychange="javascript:checkTitleInput(this);" oninput="javascript:checkTitleInput(this);" runat="server"/></em> </li>
<li class="fbrj_d" style="width:650px;*margin-bottom:0px;margin-bottom:0px;">
<span style="width:75px;text-align:right;">帖子内容：&nbsp;</span>
<div id="content_div" name="content_div" style="margin-left:75px;margin-top:3px"></div>
<script type="text/javascript">
var e_font = true;
var e_fontsize = true;
var e_color = true;
var e_img = true;
var e_internetimg = false;
var e_uploadimg = true;
// 添加转贴视频提示
// Liulikang (2010-02-24)
var e_media_tips = true;
content_editor = new webEditor("content_editor" , $("content_div") , 557, 200);
content_editor.init("");
</script>
<asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
<asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Visible="false"></asp:TextBox>
<div class="box-t" id="tz_tips" style="position:absolute; z-index:999; left:637px; top:58px; width:170px;display:none">
<div class="box-outer-t">
<div class="box-inner-t">
<p>如果你要转帖土豆、优酷、酷6等视频，请直接将该视频的网址粘贴到“<b class="sl">原帖网址</b>”输入框</p>
</div>
</div>

</div>
</li>
<li><span style="width:75px;text-align:right;">原帖网址：&nbsp;</span><em class="it_s">
<input type="text" id="url2" name="url2" value="" class="it1" style="width:550px"  onpropertychange="javascript:checkUrlInput(this);" oninput="javascript:checkUrlInput(this);" onfocus="this.className='it2';" onblur="this.className='it1';" runat="server"  /></em></li>
<li style="display:block;margin-left:-13px;">
<span style="margin-top:0;width:auto;_position:relative;_width:85px;_margin-left:-13px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;设置观点：</span>
<input name="vpmethod" id="vpmethod" onclick="javascript:novp();" type="radio" value="0" checked runat="server"/> 无互动观点
<span style="display:none;"><input name="vpmethod" id="Radio1" onclick="javascript:showtagedit();" type="radio" value="1" runat="server" /> 标签方式</span>
<input name="vpmethod" id="Radio2" onclick="javascript:displayVpList();" type="radio" value="2" runat="server"/> 有互动观点
</li>
<!--<ul id="viewpointlist" style="display:block;text-align:left;">-->
<ul style="text-align:left;margin-top:5px;margin-left:-5px;*margin-left:8px;_margin-left:-5px;">
<li id="vptag" style="display:none;"><span style="width:75px;text-align:right;_position:relative;_margin-left:-5px;">我的标签词：</span><span class="it_s" style="text-align:left;margin-left:6px;width:130px;"><input type="text" name="tag" id="tag" class="it1" value="" onfocus="this.className='it2';" onblur="this.className='it1';" style="width:120px;_margin-left:16px;" onkeyup="javascript:checkTagInput(this);" oninput="javascript:checkTagInput(this);" runat="server"/></span></li></ul>

<ul style="text-align:left;margin-top:5px;margin-left:-2px;*margin-left:12px;">
<li id="vpli1" style="display:none;"><span style="width:75px;text-align:right;">您的观点：&nbsp;</span><em class="it_s" style="text-align:left;"><input type="text" name="answer1" class="it1" value="" onfocus="this.className='it2';" onblur="this.className='it1';" style="width:260px" onpropertychange="javascript:checkViewPointInput(this);" oninput="javascript:checkViewPointInput(this);" id="answer1" runat="server"/></em> 这条是您的观点</li>
<li id="vpli2" style="display:none;"><span style="width:75px;text-align:right;">观点2：&nbsp;</span><em class="it_s" style="text-align:left;"><input type="text" name="answer2" class="it1" value="" onfocus="this.className='it2';" onblur="this.className='it1';" style="width:260px" onpropertychange="javascript:checkViewPointInput(this);" oninput="javascript:checkViewPointInput(this);" id="answer2" runat="server"/></em> 您还可以发布观点2-8，让您的好友一起参与讨论</li>
<li id="vpli3" style="display:none;"><span style="width:75px;text-align:right;">观点3：&nbsp;</span><em class="it_s" style="text-align:left;"><input type="text" name="answer3" class="it1" value="" onfocus="this.className='it2';" onblur="this.className='it1';" style="width:260px" onpropertychange="javascript:checkViewPointInput(this);" oninput="javascript:checkViewPointInput(this);" id="answer3" runat="server"/></em></li>
<li id="vpli4" style="display:none;"><span style="width:75px;text-align:right;">观点4：&nbsp;</span><em class="it_s" style="text-align:left;"><input type="text" name="answer4" class="it1" value="" onfocus="this.className='it2';" onblur="this.className='it1';" style="width:260px" onpropertychange="javascript:checkViewPointInput(this);" oninput="javascript:checkViewPointInput(this);" id="answer4" runat="server"/></em></li>
<li id="vpli5" style="display:none;"><span style="width:75px;text-align:right;">观点5：&nbsp;</span><em class="it_s" style="text-align:left;"><input type="text" name="answer5" class="it1" value="" onfocus="this.className='it2';" onblur="this.className='it1';" style="width:260px" onpropertychange="javascript:checkViewPointInput(this);" oninput="javascript:checkViewPointInput(this);" id="answer5" runat="server"/></em></li>
<li id="vpli6" style="display:none;"><span style="width:75px;text-align:right;">观点6：&nbsp;</span><em class="it_s" style="text-align:left;"><input type="text" name="answer6" class="it1" value="" onfocus="this.className='it2';" onblur="this.className='it1';" style="width:260px" onpropertychange="javascript:checkViewPointInput(this);" oninput="javascript:checkViewPointInput(this);" id="answer6" runat="server"/></em></li>
<li id="vpli7" style="display:none;"><span style="width:75px;text-align:right;">观点7：&nbsp;</span><em class="it_s" style="text-align:left;"><input type="text" name="answer7" class="it1" value="" onfocus="this.className='it2';" onblur="this.className='it1';" style="width:260px" onpropertychange="javascript:checkViewPointInput(this);" oninput="javascript:checkViewPointInput(this);" id="answer7" runat="server"/></em></li>
<li id="vpli8" style="display:none;"><span style="width:75px;text-align:right;">观点8：&nbsp;</span><em class="it_s" style="text-align:left;"><input type="text" name="answer8" class="it1" value="" onfocus="this.className='it2';" onblur="this.className='it1';" style="width:260px" onpropertychange="javascript:checkViewPointInput(this);" oninput="javascript:checkViewPointInput(this);" id="answer8" runat="server"/></em></li>

</ul>
<li><span style="width:75px;text-align:right;">&nbsp;</span>
<div class="rbs1 mt10">
<input type="submit" id="submitbtn"  value="转帖给好友" title="转帖" class="rb1" onmouseover="this.className='rb2';" onmouseout="this.className='rb1';" onclick="" style="width:135px;" onserverclick="submitbtn_ServerClick" runat="server" />

</div>
</li>
</ul>
</form>

<div class="c"></div>
<div class="h50"></div>
</div>
</div>
</div>
<script type="text/javascript">

function showtagedit()
{
novp();
s("vptag");
}
function novp()
{
h("vptag");
for(var i=1 ; i<=8 ; i++)
{
h("vpli"+i);
}
}
function checkViewPointInput(istr)
{
if(istr.value.length>16)
{
istr.value = istr.value.substring(0,16);
}
}
function displayVpList()
{
novp();
//if ($('voteLinkDiv').style.display != "none")
{
//页面不好调整，不得不用这么麻烦的方法显示
h('voteLinkDiv');
for(var i=1 ; i<=8 ; i++)
{
s("vpli"+i);
}
}
}
function checkTitleInput(istr)
{
if(istr.value.length>100)
{
istr.value = istr.value.substring(0,100);
}
}
function checkUrlInput(istr)
{
if(istr.value.length>255)
{
istr.value = istr.value.substring(0,255);
}
}
function checkTagInput(istr)
{
var taglen = b_strlen(istr.value);
var len=12;
if(taglen>12)
{
istr.value = b_subString(istr.value,len);
}
return false;
}
function checkRepasteForm(v_form)
{
var vpmethod=0;
var obj = document.getElementsByName("vpmethod");
for(var i=0;i<obj.length;i++)
{
if (obj[i].checked)
{
vpmethod = obj[i].value;
}
}
v_form.url2.value = v_form.url2.value.trim();
var strUrl = v_form.url2.value;
if (strUrl.indexOf(" ")>=0)
{
alert("url格式不正确");
v_form.url2.focus();
return false;
}
v_form.title.value = v_form.title.value.trim();
if (0 == v_form.title.value.length)
{
alert("帖子标题不能为空!");
v_form.title.focus();
return false;
}
if (2 > v_form.title.value.length)
{
alert("帖子标题多写几个字吧！");
v_form.title.focus();
return false;
}
v_form.uploadfile.value = content_editor.uploadfile;
//var testContent = v_form.textarea2.value;
var testContent = content_editor.getHtml();
v_form.textarea2.value = content_editor.getHtml();
testContent = testContent.trim();
if (0 == testContent.length)
{
alert("帖子内容不能为空！");
//v_form.textarea2.focus();
content_editor.getFocus();
return false;
}
if (10 > testContent.length)
{
alert("帖子内容多写几个字吧！");
//v_form.textarea2.focus();
content_editor.getFocus();
return false;
}
//	var test_str = v_form.textarea2.value;
//	if (test_str.indexOf("<embed ")>=0)
//	{
//		if (confirm("转帖内容不支持输入嵌入代码！\n"))
//		{
//			$("submitbtn").disabled = false;
//			v_form.textarea2.focus();
//			return false;
//		}
//	}
//检查互动观点（投票）
var vpnum = 0;
for(var i=1 ; i<=8 ; i++)
{
if(v_form["answer"+i].value != "")
{
vpnum ++;
}
}
if (vpnum < 1 && vpmethod == 1)
{
alert("至少要填写1个观点吧!");
return false;
}
//检查互动观点结束（投票）
//检查互动观点（标签）
if (vpmethod == 1 && $("tag").value.trim() == '')
{
alert("你还没有添加观点呢~");
$("tag").focus();
return false;
}
//检查互动观点结束（标签）
if (vpmethod == 0)
{
$("tag").value = '';
for(var i=1 ; i<=8 ; i++)
{
v_form["answer"+i].value = "";
}
}


document.getElementById("HiddenField1").value = content_editor.getHtml();
return true;
}
function _bodyonload()
{
document.rpform.title.focus();
showtagedit();
}
function e_onwebeditfocus()
{
//	s('tz_tips');
}
function e_onwebeditblur()
{
//	h('tz_tips');
}
</script>
<!-- module end --></div>
</li>
</ul>
</div>
</div>
</div>
<!--/mainarea-->
<div id="bottom">
</div>
</div>
<!--/main-->
<clubfooter:clubfooter ID="clubfooter1" runat="server" />
</div>
</body>
</html>
