<%
OnUrl=Lcase(Request.ServerVariables("SERVER_NAME"))
PrevUrl=Lcase(request.servervariables("http_referer"))
IF instr(PrevUrl,OnUrl)=0 Then
    response.Write "<script language='javascript'>alert('�Ƿ�������');history.go(-1);</script>"
    response.End()
End IF

Server.ScriptTimeOut=5000
%>
<!--#include FILE="UpLoadClass.asp"-->
<%
	Sub CreateFolder(strFolder)
	    strTestFolder = Server.Mappath(strFolder)
 	   Set objFSO = CreateObject("Scripting.FileSystemObject")
	    If not objFSO.FolderExists(strTestFolder) Then
	      strTestFolder = Server.Mappath(strFolder)
	      Set objFSO = CreateObject("Scripting.FileSystemObject")
	     objFSO.CreateFolder(strTestFolder)
	     Set objFSO = Nothing
	   End If
	End Sub

	dim CaiDao,FilePath,DayPath,FileName,UrlFile,UrlFiles,UrlPath
	
    FilePath  = "Api_Uppic/"
    DayPath   = year(now())&"-"&month(now())&"-"&day(now())	
	FilePath1 = "../../"&FilePath&DayPath&"/"
    CreateFolder(FilePath1)

	set CaiDao=new UpLoadClass'�����ϴ�����
	CaiDao.FileType="gif/jpg/png" 'gif/jpg/png
	CaiDao.SavePath = FilePath1 '���÷������ļ�����·��
	CaiDao.Charset="gb2312"'�����ַ���
	CaiDao.Open() '�򿪶���

%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html;charset=gb2312" />
<title>�ϴ��ļ�</title>
<style type="text/css">
 body {font:12px Tahoma;font-family:"����";margin:0px;background:#FFF;}
 body,form,ul,li,p,dl,dd,dt,h,td,th,h3{padding:0;font-size:12px;color:#444;}
</style>
<script type="text/javascript">
document.domain="100allin.com";
</script>
</head>
<body>
<%
	FileName = FilePath&DayPath&"/"&CaiDao.Form("content_editor_i_file")
	
	UrlFile  = Lcase("http://"&Request.ServerVariables("HTTP_HOST")&request.ServerVariables("PATH_INFO"))
	UrlFile  = split(UrlFile,"/upapi/upfile.asp")
	UrlFiles = split(UrlFile(0),"/")
	UrlPath  = ""
	For j=0 to UBound(UrlFiles)-1
	    UrlPath = UrlPath&UrlFiles(j)&"/"
	Next	
	response.Write "<script language=javascript>"&vbCrLf
	response.Write "str='<img src="+UrlPath&FileName+" border=0>';"
	'response.Write "window.parent.document.getElementById('"&CaiDao.Form("instance")&"').insertHTML(str);;"&vbCrLf
	response.Write "window.parent.window."&CaiDao.Form("instance")&".insertHTML(str);"&vbCrLf
	response.Write "window.parent.window."&CaiDao.Form("instance")&".removePanel('content_editor_image');"&vbCrLf
	'response.Write "window.location.href='upload.asp';"&vbCrLf
	if mid(FileName,Len(FileName),1)="/" then
		response.Write "alert(""�Բ������ϴ���ͼƬ�������ϴ�С��300k��ͼƬ"");"&vbCrLf
	end if
	response.Write "</script>"&vbCrLf
%>
</body>
</html>