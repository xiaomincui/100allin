<%
OnUrl=Lcase(Request.ServerVariables("SERVER_NAME"))
PrevUrl=Lcase(request.servervariables("http_referer"))
IF instr(PrevUrl,OnUrl)=0 Then
    response.Write "<script language='javascript'>alert('�Ƿ�������');history.go(-1);</script>"
    response.End()
End IF
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html;charset=gb2312" />
<title>�ϴ��ļ�</title>
<style type="text/css">
 body {font:12px Tahoma;font-family:"����";margin:0px;background:#f3f8fb;}
 body,form,ul,li,p,dl,dd,dt,h,td,th,h3{padding:0;font-size:12px;color:#444;}
 .button {border:#7F9DB9 1px solid;}
 .input  {border:#7F9DB9 1px solid;}
 .table  {width:250px;}
</style>
<script type="text/javascript">
function checkform(){
  var strs=document.upform.file.value;
  if(strs==""){
      alert("��ѡ��Ҫ�ϴ���ͼƬ!");
	  return false;     
  }  
  var n1=strs.lastIndexOf('.')+1;
  var fileExt=strs.substring(n1,n1+3).toLowerCase()
  if(fileExt!="jpg"&&fileExt!="gif"&&fileExt!="jpeg"&&fileExt!="bmp"&&fileExt!="png"){
	  alert('Ŀǰϵͳ��֧��jpg��gif��bmp��png��׺ͼƬ�ϴ�!');
	  return false;
  }
}
</script>
</head>
<body>
<form action="upfile.asp" method="post" enctype="multipart/form-data" name="upform" onSubmit="return checkform();">
<input name="file" id="file" type="file" class="input" />
<input name="Submit" type="submit" class="button" value="�� ��" />
</form>
</body>
</html>
