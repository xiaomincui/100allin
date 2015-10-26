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

'***********************************************
'��������showpage
'��  �ã���ʾ����һҳ ��һҳ������Ϣ
'��  ����sfilename  ----���ӵ�ַ
'       totalnumber ----������
'       maxperpage  ----ÿҳ����
'       ShowTotal   ----�Ƿ���ʾ������
'       ShowAllPages ---�Ƿ��������б���ʾ����ҳ���Թ���ת����ĳЩҳ�治��ʹ�ã���������JS����
'       strUnit     ----������λ
'***********************************************
sub showpage(sfilename,totalnumber,maxperpage,ShowTotal,ShowAllPages,strUnit)
	dim n, i,strTemp,strUrl
	if totalnumber mod maxperpage=0 then
    	n= totalnumber \ maxperpage
  	else
    	n= totalnumber \ maxperpage+1
  	end if
  	strTemp= "<table align='right'><tr><td>"
	if ShowTotal=true then 
		strTemp=strTemp & "�� <b>" & totalnumber & "</b> " & strUnit & "&nbsp;&nbsp;"
	end if
	strUrl=JoinChar(sfilename)
  	if CurrentPage<2 then
    		strTemp=strTemp & "��ҳ ��һҳ&nbsp;"
  	else
    		strTemp=strTemp & "<a href='" & strUrl & "page=1'>��ҳ</a>&nbsp;"
    		strTemp=strTemp & "<a href='" & strUrl & "page=" & (CurrentPage-1) & "'>��һҳ</a>&nbsp;"
  	end if

  	if n-currentpage<1 then
    		strTemp=strTemp & "��һҳ βҳ"
  	else
    		strTemp=strTemp & "<a href='" & strUrl & "page=" & (CurrentPage+1) & "'>��һҳ</a>&nbsp;"
    		strTemp=strTemp & "<a href='" & strUrl & "page=" & n & "'>βҳ</a>"
  	end if
   	strTemp=strTemp & "&nbsp;ҳ�Σ�<strong><font color=red>" & CurrentPage & "</font>/" & n & "</strong>ҳ "
    strTemp=strTemp & "&nbsp;<b>" & maxperpage & "</b>" & strUnit & "/ҳ"
		strTemp=strTemp & "&nbsp;ת����<select name='page' size='1' onchange=""javascript:window.location='" & strUrl & "page=" & "'+this.options[this.selectedIndex].value;"">"   
    	for i = 1 to n   
    		strTemp=strTemp & "<option value='" & i & "'"
			if cint(CurrentPage)=cint(i) then strTemp=strTemp & " selected "
			strTemp=strTemp & ">��" & i & "ҳ</option>"   
	    next
		strTemp=strTemp & "</select>"
	strTemp=strTemp & "</td></tr></table>"
	response.write strTemp
end sub

'***********************************************
'��������JoinChar
'��  �ã����ַ�м��� ? �� &
'��  ����strUrl  ----��ַ
'����ֵ������ ? �� & ����ַ
'***********************************************
function JoinChar(strUrl)
	if strUrl="" then
		JoinChar=""
		exit function
	end if
	if InStr(strUrl,"?")<len(strUrl) then 
		if InStr(strUrl,"?")>1 then
			if InStr(strUrl,"&")<len(strUrl) then 
				JoinChar=strUrl & "&"
			else
				JoinChar=strUrl
			end if
		else
			JoinChar=strUrl & "?"
		end if
	else
		JoinChar=strUrl
	end if
end function

''''''''''''''''''''''''''''''''''
'''''������̬�ļ�
'''''TemplateID:ģ��ID,Action:��������
''''''''''''''''''''''''''''''''''
function CreatFile(TemplateID,Title,Hits,Content,UpdateTime,Action,filename)

		set rsTemplate = fGetRsList("SELECT * FROM "& StrDBPrefix &"NewsTemplate WHERE id = "&TemplateID)
		
		HtmlTemplate=rsTemplate("content")
		
		HtmlTemplate=replace(HtmlTemplate,"$Title$",""&Title&"") 
		HtmlTemplate=replace(HtmlTemplate,"$Hits$",""&Hits&"") 
		HtmlTemplate=replace(HtmlTemplate,"$Content$",""&Content&"") 
		HtmlTemplate=replace(HtmlTemplate,"$UpdateTime$",""&UpdateTime&"") 
		
		HtmlFileName = Server.MapPath("../../News/")
		if Action = "Add" then 
			ranNum=int(90000*rnd)+second(now)
			TmpFileName = year(now)&"_"&month(now)&"_"&day(now)&"_"&hour(now)&minute(now)&second(now)&rannum
			TmpFileName = TmpFileName&".asp"
		else
			TmpFileName = filename
		end if
		
		HtmlFileName = HtmlFileName&"\"&TmpFileName
		
		Set Myfso = Server.CreateObject("Scripting.FileSystemObject")

		Set fout = Myfso.CreateTextFile(HtmlFileName)
		fout.WriteLine HtmlTemplate 
		fout.close:set fout = nothing
		
		CreatFile = TmpFileName
		
end function

''''''''''''''''''''''''''''''''''
'ͨ��fsoɾ���ļ�
'path:ɾ���ļ�·��
''''''''''''''''''''''''''''''''''''
function Fun_DelFile(path)

    'on error resume next
    Set fs=Server.CreateObject("Scripting.FileSystemObject")
    if fs.FileExists(path) then
      fs.DeleteFile path,True
     ' response.write "�ɹ�ɾ��"&path
	  Fun_DelFile = 1
    else
      'response.write "�ļ�������!"
	  Fun_DelFile = 0
    end if
    Set fs=nothing
    
end function


'*************************************************
'��������gotTopic
'��  �ã����ַ���������һ���������ַ���Ӣ����һ���ַ�
'��  ����str   ----ԭ�ַ���
'       strlen ----��ȡ����
'����ֵ����ȡ����ַ���
'*************************************************
function gotTopic(str,strlen)
	if str="" then
		gotTopic=""
		exit function
	end if
	dim l,t,c, i
	str=replace(replace(replace(replace(str,"&nbsp;"," "),"&quot;",chr(34)),"&gt;",">"),"&lt;","<")
	l=len(str)
	t=0
	for i=1 to l
		c=Abs(Asc(Mid(str,i,1)))
		if c>255 then
			t=t+2
		else
			t=t+1
		end if
		if t>=strlen then
			gotTopic=left(str,i) & "��"
			exit for
		else
			gotTopic=str
		end if
	next
	gotTopic=replace(replace(replace(replace(gotTopic," ","&nbsp;"),chr(34),"&quot;"),">","&gt;"),"<","&lt;")
end function


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



'**************************************************
'��������CheckUserLogined
'��  �ã�����û��Ƿ��¼
'��  ����ThisGroupID	--�û���id
'����ֵ��True ----�Ѿ���¼
'        False ---û�е�¼
'**************************************************
function CheckUserLogined(ThisGroupID)
	dim Logined,UserName,UserPassword,UserGroupID,UserID,rs,sql
	Logined=True
	UserName=Session("UserName")
	UserPassword=Session("UserPassword")
	UserGroupID=Session("UserGroupID")
	UserID=Request.Cookies("UserID")
	mysql = ""
	if ThisGroupID > 0 then 	mysql = " and UserGroupID = " &ThisGroupID
	
	
	if UserName="" then
		Logined=False
	end if
	if UserPassword="" then
		Logined=False
	end if
	if UserGroupID="" then
		Logined=False
	end if
	if UserID="" then
		Logined=False
	end if
	

	if Logined=True then
		UserName=replace(trim(UserName),"'","")
		UserPassword=replace(trim(UserPassword),"'","")
		UserGroupID=Cint(trim(UserGroupID))
		UserID=Cint(trim(UserID))
		set rs=server.createobject("adodb.recordset")
		sql="select * from TB_User where UserName='" & UserName & "' and UserPassword='" & UserPassword &"' "&mysql&""

		rs.open sql,conn,1,1
		if rs.bof and rs.eof then
			Logined=False
		else
			if UserPassword<>rs("UserPassword") then
				Logined=False
			end if
		end if
		rs.close
		set rs=nothing
	end if
	CheckUserLogined=Logined
end function



'**************************************************
'��������Fun_Logining
'��  �ã��û���¼
'��  ����UserGroupID	--�û���id
'����ֵ��True ----�Ѿ���¼
'        False ---û�е�¼
'**************************************************
function Fun_Logining(Username,UserPassword,UserGroupID)

	Logined=True
	
	if UserName="" then
		Logined=False
	end if
	if UserPassword="" then
		Logined=False
	end if
	if UserGroupID="" then
		Logined=False
	end if

	if Logined=True then
		UserName=replace(trim(UserName),"'","")
		UserPassword=replace(trim(UserPassword),"'","")
		UserGroupID=Cint(trim(UserGroupID))
		set rs=server.createobject("adodb.recordset")
		sql="select * from TB_User where UserName='" & UserName & "' and UserPassword='" & UserPassword &"'and UserGroupID='" & UserGroupID &"' and IfPass = 1"

		rs.open sql,conn,1,1
		if rs.bof and rs.eof then
			Logined=False
		else
			conn.execute("update tb_user set loginTime = loginTime + 1, LastLogin=getdate() where UserName = '" & Username & "'")
			Response.Cookies("UserID") = rs("userid")
			session("Username") = rs("username")
			session("UserPassword") = rs("UserPassword")
			session("UserGroupID") = rs("UserGroupID")
			Session("IfPass") = rs("IfPass")
		end if
		rs.close
		set rs=nothing
	end if

	Fun_Logining=Logined
end function


'**************************************************
'��������Fun_Logout
'��  �ã��û��ǳ�
'��  ����
'����ֵ��True ----�Ѿ���¼
'        False ---û�е�¼
'**************************************************
sub Fun_Logout(gotoURL)

Response.Cookies("UserID")=""
session("username")=""
session("UserPassword") = ""
Session("UserGroupID")=""
Session("IfPass")=""
response.redirect(gotoURL)
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

'**************************************************
'��������ShowUserGroupName
'��  �ã���ʾ�û�������
'��  ����intUserGroupID-----�û���ID
'����ֵ���û�������
'**************************************************
function ShowUserGroupName(intUserGroupID)
	if intUserGroupID="" then
		ShowUserGroupName="δ֪���û���"
	else
		SqlUserGroup="SELECT * FROM TB_UserGroup where GroupID = "&intUserGroupID
		set rsUserGroup=server.CreateObject ("Adodb.recordset")
		rsUserGroup.open SqlUserGroup,conn,1,3
		ShowUserGroupName=rsUserGroup("GroupName")
	end if
end function

'**************************************************
'��������ShowUserLoginTime
'��  �ã���ʾ�û���¼����
'��  ����intUserID-----�û�ID
'����ֵ���û���¼����
'**************************************************
function ShowUserLoginTime(intUserID)
	if intUserID="" then
		ShowUserLoginTime="δ֪���û�"
	else
		SqlUserLoginTime="SELECT loginTime FROM TB_User where Userid = "&intUserID
		set rsUserLoginTime=server.CreateObject ("Adodb.recordset")
		rsUserLoginTime.open SqlUserLoginTime,conn,1,3
		ShowUserLoginTime=rsUserLoginTime("loginTime")
	end if
end function

'**************************************************
'��������ShowUserPoint
'��  �ã���ʾ�û�����
'��  ����intUserID-----�û�ID
'����ֵ���û�����
'**************************************************
function ShowUserPoint(intUserID)
	if intUserID="" then
		ShowUserPoint="δ֪���û�"
	else
		SqlUserPoint="SELECT UserPoint FROM TB_User where Userid = "&intUserID
		set rsUserPoint=server.CreateObject ("Adodb.recordset")
		rsUserPoint.open SqlUserPoint,conn,1,3
		ShowUserPoint=rsUserPoint("UserPoint")
	end if
end function

'***********************************************
'��������Cong_PageLink
'��  �ã���ҳ
'��  ����	RsThis:��ҳ��¼��
'			GuestTotal:��������
'			Scriptname:��תҳ��
'			UrlAdd:URL����
'			Mypagesize:��ǰҳ��ʾ��¼��
'			Unit:��λ:"��"��"��"
'			ShowUnit:��ʾ��λ:"��Ϣ"��"��Ʒ"
'����ֵ��
'			PageShowState������5ƪ��־ | ÿҳ��ʾ2ƪ | ��1ҳ [��ҳ] 
'�������ӣ�
'			dim PageShowState
'			UrlAdd="FileClassid="&FileClassid
'			Scriptname = "index_test.asp"
'			Set rsFileList= Server.CreateObject("ADODB.Recordset")
'			rsFileList.open "select * From TB_File where ClassID = "&FileClassid&" order by UpdateTime desc",conn,1,1
'			GuestTotal = rsFileList.recordcount '�ܼ�¼��
'			Mypagesize = 2 '��ʾ��¼��
'			Cong_PageLink rsFileList,GuestTotal,Scriptname,UrlAdd,Mypagesize,"��","��Ϣ"
'***********************************************
Sub Cong_PageLink (RsThis,GuestTotal,Scriptname,UrlAdd,Mypagesize,Unit,ShowUnit)  

if not isempty(request("page")) then
	Mypage=cint(Request("page"))
else
	Mypage=1
end if

RsThis.pagesize=Mypagesize
maxpages=cint(RsThis.pagecount)

RsThis.absolutepage=Mypage
GuestTotal=RsThis.RecordCount

PageShowSize = 10  
if Scriptname = "" then Scriptname=Request.Servervariables("script_name") 'ScriptnameΪ��,Ĭ��Ϊ��ҳ
if UrlAdd <> "" then 'Url�޲���
Scriptname = JoinChar(JoinChar(Scriptname)&UrlAdd)
else
Scriptname = JoinChar(Scriptname)
end if

PageNextSize=int((MyPage-1)/PageShowSize)+1  
Pagetpage=int((GuestTotal-1)/MyPageSize)+1  

if Maxpages > 1 then  
   if PageNextSize >1 then  
       PagePrev=PageShowSize*(PageNextSize-1)  
       PageShowList=PageShowList&"<a href='" & Scriptname & "page=" & PagePrev & "'>[<<]</a>-"  
   end if  
   if Mypage-1 > 0 then  
       Prev_Page = MyPage - 1  
       PageShowList=PageShowList&"<a href='" & Scriptname & "page=" & Prev_Page & "'>[<]</a> "  
   end if  
   if maxpages>=PageNextSize*PageShowSize then  
       PageSizeShow = PageShowSize  
   else  
       PageSizeShow = Maxpages-PageShowSize*(PageNextSize-1)  
   end if  
   for PageCounterSize=1 to PageSizeShow  
       PageLink = (PageCounterSize+PageNextSize*10)-10  
       if PageLink <> cint(Mypage) then  
	   PageShowList=PageShowList&"<a href='" & Scriptname & "page=" & PageLink & "'>[" & PageLink & "]</a> "  
       else  
           PageShowList=PageShowList&"<b>"&PageLink  & "</b>  "  
       end if   
   next  
   if Mypage+1 <=Pagetpage  then  
       Next_Page = MyPage + 1  
       PageShowList=PageShowList& "<a href='" & Scriptname & "page=" & Next_Page & "'>[>]</a>"  
   end if  
   if maxpages > PageShowSize*PageNextSize then  
       PageNext = PageShowSize * PageNextSize + 1  
       PageShowList=PageShowList& "-<a href='" & Scriptname & "page=" & PageNext & "'>[>>]</a>"  
   end if  
   else  
       PageShowList=PageShowList&"[1]"
end if 

if Unit = "" then Unit = "��"
if ShowUnit = "" then ShowUnit = "��Ϣ"

PageShowList= "<font style='font-size:11px'>"&PageShowList&"</font>"
PageShowState = "����"&GuestTotal&Unit&ShowUnit&" | ÿҳ��ʾ"&MyPageSize&Unit&" | ��"&cint(Mypage)&"ҳ [��"&maxpages&"ҳ]"

END Sub

'***********************************************
'��������Cong_ShowOutLink
'��  �ã���TB_OutLink��ȡ����ļ�(����Ļ���)
'��  ����	OutLinkID:���ID
'����ֵ��
'***********************************************
function Cong_ShowOutLink (OutLinkID)  

Tmp_Cong_ShowOutLink = ""

sqlCong_ShowOutLink="Select * From TB_OutLink Where ID = "&OutLinkID
set rsCong_ShowOutLink=server.CreateObject("adodb.recordset")
rsCong_ShowOutLink.open sqlCong_ShowOutLink,conn,1,1

PicWidth = rsCong_ShowOutLink("PicWidth")
PicHeight = rsCong_ShowOutLink("PicHeight")
OutLink = rsCong_ShowOutLink("OutLink")
OpenType = rsCong_ShowOutLink("OpenType")

if rsCong_ShowOutLink("Picsource") = 1 then'�ϴ�����
	ThisShowPic =PublicSiteUrl&"/images/UpOutLink/"&rsCong_ShowOutLink("UpFile")
else'Web����
	ThisShowPic =rsCong_ShowOutLink("UpUrl")
end if

FileExtName = Gi_fGetFileExtName(ThisShowPic)

	if FileExtName = "swf" then 
		Tmp_Cong_ShowOutLink = Tmp_Cong_ShowOutLink & "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0' width='"&PicWidth&"' height='"&PicHeight&"'><param name='movie' value='"& ThisShowPic &"'><param name='quality' value='high'><embed src='"& ThisShowPic &"' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'  width='"&PicWidth&"' height='"&PicHeight&"'></embed></object>"
	else 
		if OutLink <> "" then '�����ָ��ͼ�����
			Tmp_Cong_ShowOutLink = Tmp_Cong_ShowOutLink &  "<a href='"&OutLink&"' " 
				if OpenType = "1" then Tmp_Cong_ShowOutLink = Tmp_Cong_ShowOutLink & " target='_blank' " '���������Ϊ����
			Tmp_Cong_ShowOutLink = Tmp_Cong_ShowOutLink & ">"
		end if 
			Tmp_Cong_ShowOutLink = Tmp_Cong_ShowOutLink & "<img src="& ThisShowPic &"  width='"&PicWidth&"' height='"&PicHeight&"' border=0>"
		if OutLink <> "" then Tmp_Cong_ShowOutLink = Tmp_Cong_ShowOutLink & "</a>"
	end if 
	
Cong_ShowOutLink = Tmp_Cong_ShowOutLink 

END function

'***********************************************
'��������	Fun_CheckPower
'��  �ã�	���ݱ���������ֵ��TB_PowerItem��ȡPowerID������session���Ȩ��
'��  ����	TableName:������
'			KeyID:����ֵ
'			
'����ֵ��	ǰ̨����Ƶ�������
'���÷�����	��KeyID=0�����Ǳ���ߵ�Ȩ��
'***********************************************
function Fun_CheckPower(TableName,KeyID)

Fun_CheckPower = false

Sqlstr = "select * From TB_PowerItem where TableName= '"&TableName&"' and KeyID = "&KeyID&""
'Response.Write(Sqlstr&"|")
set RsCheckPower=conn.execute(Sqlstr)
if not RsCheckPower.eof then
ThisPowerID = RsCheckPower("PowerID")
else
ThisPowerID = ""
end if
ThisPowerID = ","&ThisPowerID&","

if instr(","&session("AdminPower")&",",ThisPowerID)>0 then
	Fun_CheckPower = True
end if 

End function

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

%>

