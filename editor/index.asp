<%
IF request.QueryString("action")="saveadd" Then
    response.Write "���⣺"&request.Form("title")
    response.Write "<br />���ݣ�"&request.Form("content")
	response.End()
End IF

%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta name="save" content="history">
<title>��ӭ����QQ����༭��(�˵���)</title>
<link rel="stylesheet" type="text/css" href="editor/comm.css" />
<script language="javascript" src="editor/all.js"></script>
<script language="javascript" src="editor/editor.js"></script>
<script language="javascript" src="editor/editor_toolbar.js"></script>
<script language="javascript">
function checkform(){
    if(document.form1.title.value ==""){
	    alert("���������");
		return false;
	}
	var v = DoProcess();
	if(v != true){
	    alert("����������");
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
<div class="prompt">һֱ����HTML���߱༭����Ŀǰ���ϵı༭�����Ƚ�ӷ�ף����ǰ�QQMail�ı༭����������Ȼ���Լ����˸�ͼƬ�ϴ����ܣ�ϣ����һ�ϲ���� <div style="float:right">СС�˵� QQ:275171</div></div>
<table width="550" border="0" cellpadding="2" cellspacing="1">
<form name="form1" method="post" action="?action=saveadd" target="_blank" onSubmit="return checkform();">
  <tr>
    <td width="100" align="right">���⣺</td>
    <td><input name="title" type="text" id="title" style="width:260px"> <span  id="editor_toolbar_btn_container" style="margin:0 0 0 10px"></span></td>
  </tr>
  <tr>
    <td align="right" valign="top" style="padding-top:4px">���ݣ�</td>
    <td><textarea id="content" name="content" style="display:none;">���ã���ӭ����QQ����༭��(�˵���)��</textarea>
		<script language="javascript">
		gContentId = "content";//Ҫ�������ݵ�content ID
		OutputEditorLoading();
		</script>
		<iframe id="HtmlEditor" class="editor_frame" frameborder="0" marginheight="0" marginwidth="0" style="width:100%;height:200px;overflow:visible;" hideFocus></iframe></td>
  </tr>
  <tr>
    <td align="right">&nbsp;</td>
    <td><input type="submit"  value="ȷ���ύ"><input type="reset" value="�������" onClick="UnDoProcess();" /></td>
  </tr>
  <tr>
    <td align="right">&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</form>  
</table>
</body>
</html>
