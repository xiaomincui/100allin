<%
'JS " document.title='"&PublicSiteName&"' "

'�����ֶμ���
Function Gi_GetHighLight(Str,KeyWords)
	If Not(GetHL) And IsNull(KeyWords) Then Exit Function	
	Gi_GetHighLight = Replace(Str,KeyWords,"<span style=""color:red;background-color:yellow;font-size:13px;font-weight:bold;"">"& KeyWords &"</span>")	
	
End Function

'����ʽ
Function Gi_fReplaceEx(Patrn,OrgiStr,ReplStr)
	Dim RegEx						' ����������
	Set RegEx = New RegExp			' ����������ʽ��
	RegEx.Pattern = Patrn			' ����ģʽ��
	RegEx.IgnoreCase = False			' �����Ƿ����ִ�Сд��
	Set Matches = RegEx.Execute(OrgiStr)
	Gi_fReplaceEx = RegEx.Replace(OrgiStr,ReplStr)         ' ���滻��
End Function

'����ļ���׺��
Function Gi_fGetFileExtName(FileName)
	Dim Pos
	Pos = InStrRev (FileName,".")
	If Pos > 0 Then 
		Gi_fGetFileExtName = Mid (FileName,Pos+1)
	Else
		Gi_fGetFileExtName =  ""
	End If
End Function 

'��ȡ�ļ���
'SCRIPT_NAME:�ļ�·����
'Path:int:����
function Cong_GetFilename(SCRIPT_NAME,Path)
PathFileName = split(SCRIPT_NAME,"/") 
Cong_GetFilename = PathFileName(Path)
end function

'��˳��������ɫ
Function Gi_fChgBgColor(i,Sep,Color)
	If IsNull(i) Or IsNull(Sep) Then Exit Function
	Dim TmpArray
	TmpArray = Split(Color,Sep,-1)	
	Gi_fChgBgColor = TmpArray( i mod (Ubound(TmpArray)+1))
End Function

'��֤���̴���ʱ�����***********************************
'�滻JAVA�ű��е������ַ�
Function Gi_fChgJsStr(Byval Str)
	If IsNull(Str) Then Exit Function
	Str = Replace(Str,"'","\'")
	Str = Replace(Str,"""","\""")
	Str = Replace(Str,chr(13)+chr(10),"\n")
	Gi_fChgJsStr = Str
End Function


'������ݿⵥ��������
Function Gi_fChgSQLStr(Byval Str)
	If IsNull(Str) Then Exit Function
	Str = replace(Str,"'","''")
	Gi_fChgSQLStr = Str
End Function

'��ʾ�û�������ı����滻�����ַ�
Function Gi_fChgHtmlStr(Byval Str)
	If IsNull(Str) Then Exit Function
	Str = Replace(Str,"<","&lt;")
	Str = Replace(Str,">","&gt;")
	Str = Replace(Str,chr(34),"&quot;")             
	Str = Replace(Str," ","&nbsp;")
	Str = Replace(Str,chr(13)+chr(10),"<br>")         
	Gi_fChgHtmlStr = Str
End Function

Function Gi_fUnChgHtmlStr(Byval Str)
	If IsNull(Str) Then Exit Function
	Str = Replace(Str,"&lt;","<")
	Str = Replace(Str,"&gt;",">")
	Str = Replace(Str,"&quot;",chr(34))             
	Str = Replace(Str,"&nbsp;"," ")
	Str = Replace(Str,"<br>",chr(13)+chr(10))         
	Gi_fUnChgHtmlStr = Str
End Function

'ֻ��ʾָ������������
Function Gi_fGetLenStr(Str,Amo)
	If IsNull(Str) Or IsNull(Amo) Then Exit Function
	If Len(Str) > Amo Then
		Gi_fGetLenStr = Left (Gi_fChgHtmlStr(Str),Amo) & "....."
	Else
		Gi_fGetLenStr = Gi_fChgHtmlStr(Str)
	End If
End Function

Function GetLenStr(Str,Amo)
	If IsNull(Str) Or IsNull(Amo) Then Exit Function
	If Len(Str) > Amo Then
		GetLenStr = Left (Gi_fChgHtmlStr(Str),Amo) & "....."
	Else
		GetLenStr = Gi_fChgHtmlStr(Str)
	End If
End Function

'����������ָ����Ŀ	
Function Gi_fGetSplitStr(Str,Sep,Ordinal)
	If IsNull(Str) Or IsNull(Sep) Then Exit Function
	Dim TmpArray
	TmpArray = Split(Str,Sep,-1)
	If Ordinal = "end" Then
		Gi_fGetSplitStr = Gi_fChgHtmlStr(TmpArray(Ubound(TmpArray)))
	Elseif Ordinal > 0 And Ordinal < Ubound(TmpArray) Then
		Gi_fGetSplitStr = Gi_fChgHtmlStr(TmpArray(Ordinal))
	Else
		Gi_fGetSplitStr = Gi_fChgHtmlStr(Str)
	End If
End Function

'������ʾ�󷵻�ǰҳ��һ������FORM�ύ
Sub Gi_sOnErrGoBack(StrErr)
	R "<script Language=""JScript"">alert('" & Gi_fChgJsStr(StrErr) & "');"
	R "window.history.go(-1);</script>"
	E
End Sub


'�ɹ����Զ����ύ����ָ��ҳ��
Sub Gi_sOnSucsSubNext(StrUrl,StrSub)
	R "<form action="""& StrUrl &""" method=""post"" name=""OnSucsSubGoNext"">"& StrSub &"</form><script Language=""JScript"">document.OnSucsSubGoNext.submit(OnSucsSubGoNext.form)</script>"
	E
End Sub


'�ɹ�������ָ��ҳ��
Sub Gi_sOnSucsGoNext(StrSucs,url)
	R "<script Language=""JScript"">alert('" & Gi_fChgJsStr(StrSucs) & "');"
	R "_top.location='" & url & "';</script>"
	E
End Sub


'������ʾ��رյ�ǰ���ڡ�
Sub Gi_sOnErrCloseWindow(StrErr)
	R "<script Language=""JScript"">alert('" & Gi_fChgJsStr(StrErr) & "');"
	R "window.close();</script>"
	E
End Sub


'�رմ��ڲ�ˢ�¸�����
Sub Gi_sOnSucsReloadOpener(Str)
	R "<script Language=""JScript"">alert('"& Gi_fChgJsStr(Str) &"');window.opener.window.location.reload();window.close();</script>"
	E
End Sub



'�������************************************************************
Sub A(Str)
	R "<script Language=""JScript"">alert('"& Gi_fChgJsStr(Str) &"');</script>" 
End Sub

Sub JS(Str)
	R "<script Language=""JScript"">"&Str&"</script>"
End Sub

Sub T(Str)
	R "<script Language=""JScript"">var winname = window.open('', '_blank', 'toolbar=no, menubar=yes, scrollbaRs=yes, resizable=yes ,location=no, status=yes');	winname.document.open('text/html', 'replace');winname.document.writeln('"& Gi_fChgJsStr(Str) &"');	winname.document.close();</script>"
End Sub

Sub R(Str)
	Response.Write Str
End Sub

Sub E()
	Response.End
End Sub


'��ñ�ҳurl��request.servervariables("")����
Sub ShowServerVariables()
	R "<TABLE border=1><!-- Table Header --><TR><TD><B>Variables</B></TD><TD><B>value</B></TD></TR>"
	For Each Ob In Request.ServerVariables
		R "<TR><TD>"& Ob &"</TD><TD>"& Request.ServerVariables (Ob) &"</TD></TR>"
	Next
	R "</TABLE>"	
End Sub




'********************************************
'��������IsValidEmail
'��  �ã����Email��ַ�Ϸ���
'��  ����email ----Ҫ����Email��ַ
'����ֵ��True  ----Email��ַ�Ϸ�
'       False ----Email��ַ���Ϸ�
'********************************************
function IsValidEmail(email)
	dim names, name, i, c
	IsValidEmail = true
	names = Split(email, "@")
	if UBound(names) <> 1 then
	   IsValidEmail = false
	   exit function
	end if
	for each name in names
		if Len(name) <= 0 then
			IsValidEmail = false
    		exit function
		end if
		for i = 1 to Len(name)
		    c = Lcase(Mid(name, i, 1))
			if InStr("abcdefghijklmnopqrstuvwxyz_-.", c) <= 0 and not IsNumeric(c) then
		       IsValidEmail = false
		       exit function
		     end if
	   next
	   if Left(name, 1) = "." or Right(name, 1) = "." then
    	  IsValidEmail = false
	      exit function
	   end if
	next
	if InStr(names(1), ".") <= 0 then
		IsValidEmail = false
	   exit function
	end if
	i = Len(names(1)) - InStrRev(names(1), ".")
	if i <> 2 and i <> 3 then
	   IsValidEmail = false
	   exit function
	end if
	if InStr(email, "..") > 0 then
	   IsValidEmail = false
	end if
end function

'***************************************************
'��������IsObjInstalled
'��  �ã��������Ƿ��Ѿ���װ
'��  ����strClassString ----�����
'����ֵ��True  ----�Ѿ���װ
'       False ----û�а�װ
'***************************************************
Function IsObjInstalled(strClassString)
	On Error Resume Next
	IsObjInstalled = False
	Err = 0
	Dim xTestObj
	Set xTestObj = Server.CreateObject(strClassString)
	If 0 = Err Then IsObjInstalled = True
	Set xTestObj = Nothing
	Err = 0
End Function

'**************************************************
'��������strLength
'��  �ã����ַ������ȡ������������ַ���Ӣ����һ���ַ���
'��  ����str  ----Ҫ�󳤶ȵ��ַ���
'����ֵ���ַ�������
'**************************************************
function strLength(str)
	ON ERROR RESUME NEXT
	dim WINNT_CHINESE
	WINNT_CHINESE    = (len("�й�")=2)
	if WINNT_CHINESE then
        dim l,t,c
        dim i
        l=len(str)
        t=l
        for i=1 to l
        	c=asc(mid(str,i,1))
            if c<0 then c=c+65536
            if c>255 then
                t=t+1
            end if
        next
        strLength=t
    else 
        strLength=len(str)
    end if
    if err.number<>0 then err.clear
end function

'------------------���ĳһĿ¼�Ƿ����-------------------
Function CheckDir(FolderPath)
	dim fso
	folderpath=Server.MapPath(".")&"\"&folderpath
	Set fso1 = Server.CreateObject("Scripting.FileSystemObject")
	If fso.FolderExists(FolderPath) then
	'����
		CheckDir = True
	Else
	'������
		CheckDir = False
	End if
	Set fso = nothing
End Function

'-------------����ָ����������Ŀ¼---------
Function MakeNewsDir(foldername)
	dim fso,f
	Set fso = Server.CreateObject("Scripting.FileSystemObject")
    Set f = fso.CreateFolder(foldername)
    MakeNewsDir = True
	Set fso = nothing
End Function


'****************************************************
'��������SendMail
'��  �ã���Jmail��������ʼ�
'��  ����MailtoAddress  ----�����˵�ַ
'        MailtoName    -----����������
'        Subject       -----����
'        MailBody      -----�ż�����
'        MailAttachment-----����
'        FromName      -----����������
'        MailFrom      -----�����˵�ַ
'        Priority      -----�ż����ȼ�
'****************************************************
function SendMail(MailtoAddress,MailtoName,Subject,MailBody,MailAttachment,FromName,MailFrom,Priority)
	on error resume next
	Dim JMail
	Set JMail=Server.CreateObject("JMail.Message")
	if err then
		SendMail= "<br><li>û�а�װJMail���</li>"
		err.clear
		exit function
	end if
	JMail.Charset="gb2312"          '�ʼ�����
	JMail.silent=FALSE				 'JMAIL�����׳�������󣬷��ص�ֵΪFALSE��TRUE
	
	if MailAttachment = "" then 
	JMail.ContentType = "text/html"     '�ʼ����ĸ�ʽ
	else
	JMail.AddAttachment(MailAttachment)
	end if
	
	'JMail.ServerAddress=PublicMailServer     '���������ʼ���SMTP������
   	JMail.logging = true   '����ʹ����־
	
	'�����������ҪSMTP�����֤����ָ�����²���
	JMail.MailServerUserName = PublicMailServerUserName		'��¼�û���
   	JMail.MailServerPassWord = PublicMailServerPassword		'��¼����
  	'JMail.MailDomain = "meao.net"       '����������á�name@domain.com���������û�����¼ʱ����ָ��domain.com
	JMail.AddRecipient MailtoAddress	'������
	JMail.Subject=Subject			'����
	JMail.HMTLBody=MailBody			'�ʼ����ģ�HTML��ʽ��
	JMail.Body=MailBody				'�ʼ����ģ����ı���ʽ��
	JMail.FromName=FromName         '����������
	JMail.From = MailFrom			'������Email
	JMail.Priority=Priority			'�ʼ��ȼ���1Ϊ�Ӽ���3Ϊ��ͨ��5Ϊ�ͼ�
	JMail.Send(PublicMailServer)
	JMail.ClearRecipients
	SendMail =JMail.ErrorMessage
		'Response.Write(PublicMailServer)
	JMail.Close
	Set JMail=nothing
end function


'****************************************************
  '����˵��
  'ֻ����"@meao.net"��׺����
  'Subject     : �ʼ�����
  'MailAddress : �����������ĵ�ַ,��smtp.163.com
  'Email       : �ռ����ʼ���ַ
  'Sender      : ����������
  'Content     : �ʼ�����
  'Fromer      : �����˵��ʼ���ַ
'****************************************************
			Sub SendAction(subject, email, sender, content, fromer) 
			Set jmail = CreateObject("Jmail.Message")
			jmail.silent = FALSE   'JMAIL�����׳�������󣬷��ص�ֵΪFALSE��TRUE
			jmail.MailServerUserName = PublicMailServerUserName	     
			jmail.MailServerPassWord = PublicMailServerPassword
			jmail.logging = true   '����ʹ����־
			jmail.Charset = "GB2312"  '�ʼ����ֵĴ���Ϊ��������
			jmail.ContentType = "text/html"  '�ʼ��ĸ�ʽΪHTML��
			'jmail.ContentType = "multipart/mixed"


			jmail.AddRecipient Email    '�ʼ����ռ���
			jmail.FromName = sender   '�ʼ������ߵ�����
			jmail.From = fromer    '�ʼ������ߵ��ʼ���ַ
			jmail.Priority = 1   '�ʼ��Ľ�������1 Ϊ��죬5 Ϊ������ 3 ΪĬ��ֵ
			jmail.Subject = subject  '�ʼ��ı���
			jmail.Body = content   '�ʼ�������
			jmail.Send(PublicMailServer)
			jmail.ClearRecipients
			End Sub
  
  '���ô�Sub������
'  Dim strSubject,strEmail,strMailAdress,strSender,strContent,strFromer
'  strSubject     = "����һ����JMAIL���͵Ĳ����ʼ�1111"
'  strContent     = "JMail������Ͳ��Գɹ���"
'  strEmail       = "xuc@ucantech.com"
'  strFromer      = "xuc@ucantech.com"


'  Call SendAction (strSubject,strEmail,strSender,strContent,strFromer)
  
'**************************************************
'��������ReplaceBadChar
'��  �ã����˷Ƿ���SQL�ַ�
'��  ����strChar-----Ҫ���˵��ַ�
'����ֵ�����˺���ַ�
'**************************************************
function ReplaceBadChar(strChar)
	if strChar="" then
		ReplaceBadChar=""
	else
		ReplaceBadChar=replace(replace(replace(replace(replace(replace(replace(strChar,"'",""),"*",""),"?",""),"(",""),")",""),"<",""),".","")
	end if
end function


sub showpageLang(sfilename,totalnumber,maxperpage,ShowTotal,ShowAllPages,strUnit)

if lang = "" then lang = 1
select case lang 
case 1
	showtotal = "��"
	showFirst = "��ҳ"
	showPre = "��һҳ"
	showNext = "��һҳ"
	showLast = "βҳ"
	showpage11 = "ҳ"
	ShowNo = "��"
case 2
	showtotal = "Total"
	showFirst = "First"
	showPre = "Pre"
	showNext = "Next"
	showLast = "Last"
	showpage11 = "Page"
	ShowNo = "No"
case 3
	showtotal = "Total"
	showFirst = "First"
	showPre = "Pre"
	showNext = "Next"
	showLast = "Last"
	showpage11 = "Page"
	ShowNo = "No"
end select


	dim n, i,strTemp,strUrl
	if totalnumber mod maxperpage=0 then
    	n= totalnumber \ maxperpage
  	else
    	n= totalnumber \ maxperpage+1
  	end if
  	strTemp= "<table align='right'><tr><td >"
	if ShowTotal=true then 
		strTemp=strTemp & showtotal&" <b>" & totalnumber & "</b> " & strUnit & "&nbsp;&nbsp;"
	end if
	strUrl=JoinChar(sfilename)
  	if CurrentPage<2 then
    		strTemp=strTemp & "<img src='../../images/case/first.gif'> "&showFirst&" <img src='../../images/case/l_pic.gif'> "&showPre&"&nbsp;"
  	else
    		strTemp=strTemp & "<a href='" & strUrl & "page=1'><img src='../../images/case/first.gif'  border='0'> "&showFirst&" </a>&nbsp;"
    		strTemp=strTemp & "<a href='" & strUrl & "page=" & (CurrentPage-1) & "'><img src='../../images/case/l_pic.gif'  border='0'>"&showPre&"</a>&nbsp;"
  	end if

  	if n-currentpage<1 then
    		strTemp=strTemp & " "&showNext&" <img src='../../images/case/r_pic.gif'  border='0'>  "&showLast&" <img src='../../images/case/last.gif'  border='0'>"
  	else
    		strTemp=strTemp & "<a href='" & strUrl & "page=" & (CurrentPage+1) & "'> "&showNext&" <img src='../../images/case/r_pic.gif'  border='0'> </a>&nbsp;"
    		strTemp=strTemp & "<a href='" & strUrl & "page=" & n & "'> "&showLast&" <img src='../../images/case/last.gif'  border='0'></a> "
  	end if
   	strTemp=strTemp & "&nbsp;&nbsp;<strong><font color=red>" & CurrentPage & "</font>/" & n & "</strong>"&showpage11&" "
    strTemp=strTemp & "&nbsp;<b>" & maxperpage & "</b>" & strUnit & "/"&showpage11&""
	if ShowAllPages=True then
		strTemp=strTemp & "&nbsp;<select name='page' size='1' onchange=""javascript:window.location='" & strUrl & "page=" & "'+this.options[this.selectedIndex].value;"">"   
    	for i = 1 to n   
    		strTemp=strTemp & "<option value='" & i & "'"
			if cint(CurrentPage)=cint(i) then strTemp=strTemp & " selected "
			strTemp=strTemp & ">" & i & ""&showpage11&"</option>"   
	    next
		strTemp=strTemp & "</select>"
	end if
	strTemp=strTemp & "</td></tr></table>"
	response.write strTemp
end sub







'=================================================
'��������ShowSearchForm
'��  �ã���ʾ����������
'��  ����ShowType ----��ʾ��ʽ��1Ϊ���ģʽ��2Ϊ��׼ģʽ��3Ϊ�߼�ģʽ
'=================================================
sub ShowSearchForm(Action,ShowType)
	if ShowType<>1 and ShowType<>2 and ShowType<>3 then
		ShowType=1
	end if
	response.write "<table border='0' cellpadding='0' cellspacing='0'>"
	response.write "<form method='Get' name='SearchForm' action='" & Action & "'>"
	response.write "<tr><td height='28' align='center'>"
	if ShowType=1 then
		response.write "<input type='text' name='keyword'  size='15' value='�ؼ���' maxlength='50' onFocus='this.select();'>&nbsp;"
		response.write "<input type='hidden' name='field' value='Title'>"
		response.write "<input type='submit' name='Submit'  value='����'>"
		'response.write "<br><br>�߼�����"
	elseif Showtype=2 then
		response.write "<select name='Field' size='1'>"
    	response.write "<option value='Title' selected>���±���</option>"
	    response.write "<option value='Content'>��������</option>"
    	response.write "<option value='Author'>��������</option>"
    	response.write "<option value='Editor'>�༭����</option>"
		response.write "</select>&nbsp;"
		response.write "<select name='ClassID'><option value=''>������Ŀ</option>"
		call Admin_ShowClass_Option(1,0)
		response.write "</select>&nbsp;<input type='text' name='keyword'  size='20' value='�ؼ���' maxlength='50' onFocus='this.select();'>&nbsp;"
		response.write "<input type='submit' name='Submit'  value=' ���� '>"
	elseif Showtype=3 then
	
	end if
	response.write "</td></tr></form></table>"
end sub







'**********************************
'suwenyong����
'**********************************
Function ChkPicUrl(Str,lenght)
	if Str<>"" then
		ChkPicUrl=right(Str,len(Str)-lenght)
	else
		ChkPicUrl=""
	end if
End Function


sub AdminDelFiles_File(strUploadFiles)
	if strUploadFiles="" then exit sub
	DelUpFiles="Yes"
	ObjInstalled=True 
	if DelUpFiles="Yes" and ObjInstalled=True then
		dim fso,arrUploadFiles,i
		Set fso = CreateObject("Scripting.FileSystemObject")
		if instr(strUploadFiles,"|")>1 then
			arrUploadFiles=split(strUploadFiles,"|")
			for i=0 to ubound(arrUploadFiles)
				if fso.FileExists(server.MapPath("" & arrUploadfiles(i))) then
					fso.DeleteFile(server.MapPath("" & arrUploadfiles(i)))
				end if
			next
		else
			if fso.FileExists(server.MapPath("" & strUploadfiles)) then
				fso.DeleteFile(server.MapPath("" & strUploadfiles))
			end if
		end if
		Set fso = nothing
	end if
end sub

Function CheckInput(i)
	i = CheckWords(i)
	i = CheckHtmlWords(i)
	i = CheckSqlWords(i)
	CheckInput =  i
End Function

Function ShowInput(i)
	i = CheckHtmlWords(i)
	i = CheckSqlWords(i)
	CheckInput = i
End Function


Function CheckWords(i)
	i = Trim(i)
	if i <> "" then
		i = Replace(i, "'", "''") 'ȥ��������
	end if
	CheckWords = i
End Function

Function CheckHtmlWords(i)
	i = Trim(i)
	if i <> "" then
		i = Server.HtmlEncode(i) '����HTML����
	end if	
	CheckHtmlWords = i
End Function

Function CheckSqlWords(i)
	i = Trim(i)
	if i <> "" then
		Dim fbdstr 
		fbdstr = "/*|*/|--|and |exec |insert |select |delete |update |count |* |chr |mid |master |truncate |char |declare " '����SQL�ؼ����ַ���
		Dim anyfbdstr(17)
		anyfbdstr(0) = "/*"
		anyfbdstr(1) = "*/"
		anyfbdstr(2) = "--"
		anyfbdstr(3) = "and "
		anyfbdstr(4) = "exec "
		anyfbdstr(5) = "insert "
		anyfbdstr(6) = "select "
		anyfbdstr(7) = "delete "
		anyfbdstr(8) = "update "
		anyfbdstr(9) = "* "
		anyfbdstr(10) = "chr "
		anyfbdstr(11) = "mid "
		anyfbdstr(12) = "master "
		anyfbdstr(13) = "truncate "
		anyfbdstr(14) = "char "
		anyfbdstr(15) = "declare "
		anyfbdstr(16) = "or "
		anyfbdstr(17) = "like "
		For Each s In anyfbdstr
		dim j
		j = instr(lcase(i),s)
			If j > 0 Then
				i = Left(i, instr(lcase(i),s)-1) & Mid(i, (instr(lcase(i),s) + len(s)))
			End If
		Next
	end if	
	CheckSqlWords =  i
End Function

Function CheckNumber(i)
	If IsNumeric(i) Then
		CheckNumber = i
	else
		CheckNumber = "0"
	End If
End Function

%>

