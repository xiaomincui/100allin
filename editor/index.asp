<%
IF request.QueryString("action")="saveadd" Then
    response.Write "标题："&request.Form("title")
    response.Write "<br />内容："&request.Form("content")
	response.End()
End IF

%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta name="save" content="history">
<title>欢迎来到QQ邮箱编辑器(菜刀版)</title>
<link rel="stylesheet" type="text/css" href="editor/comm.css" />
<script language="javascript" src="editor/all.js"></script>
<script language="javascript" src="editor/editor.js"></script>
<script language="javascript" src="editor/editor_toolbar.js"></script>
<script language="javascript">
function checkform(){
    if(document.form1.title.value ==""){
	    alert("请输入标题");
		return false;
	}
	var v = DoProcess();
	if(v != true){
	    alert("请输入内容");
		return false;
	}	
}  
</script>
<style type="text/css">
 body { margin:100px 100px}
 .prompt {border:1px dotted #ccc;background-color:#ffe;color:#666;padding: 5px 5px 5px 30px;line-height:120%;width:600px} 
</style>
</head>
<body>
<div class="prompt">一直在找HTML在线编辑器，目前网上的编辑器都比较臃肿，于是把QQMail的编辑器扒下来，然后自己加了个图片上传功能，希望大家会喜欢。 <div style="float:right">小小菜刀 QQ:275171</div></div>
<table width="550" border="0" cellpadding="2" cellspacing="1">
<form name="form1" method="post" action="?action=saveadd" target="_blank" onSubmit="return checkform();">
  <tr>
    <td width="100" align="right">标题：</td>
    <td><input name="title" type="text" id="title" style="width:260px"> <span  id="editor_toolbar_btn_container" style="margin:0 0 0 10px"></span></td>
  </tr>
  <tr>
    <td align="right" valign="top" style="padding-top:4px">内容：</td>
    <td><textarea id="content" name="content" style="display:none;">您好，欢迎来到QQ邮箱编辑器(菜刀版)！</textarea>
		<script language="javascript">
		gContentId = "content";//要载入内容的content ID
		OutputEditorLoading();
		</script>
		<iframe id="HtmlEditor" class="editor_frame" frameborder="0" marginheight="0" marginwidth="0" style="width:100%;height:200px;overflow:visible;" hideFocus></iframe></td>
  </tr>
  <tr>
    <td align="right">&nbsp;</td>
    <td><input type="submit"  value="确定提交"><input type="reset" value="清除重置" onClick="UnDoProcess();" /></td>
  </tr>
  <tr>
    <td align="right">&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</form>  
</table>
</body>
</html>
