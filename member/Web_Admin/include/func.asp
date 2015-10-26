<%
'JS " document.title='"&PublicSiteName&"' "

'搜索字段加亮
Function Gi_GetHighLight(Str,KeyWords)
	If Not(GetHL) And IsNull(KeyWords) Then Exit Function	
	Gi_GetHighLight = Replace(Str,KeyWords,"<span style=""color:red;background-color:yellow;font-size:13px;font-weight:bold;"">"& KeyWords &"</span>")	
	
End Function

'正则式
Function Gi_fReplaceEx(Patrn,OrgiStr,ReplStr)
	Dim RegEx						' 建立变量。
	Set RegEx = New RegExp			' 建立正则表达式。
	RegEx.Pattern = Patrn			' 设置模式。
	RegEx.IgnoreCase = False			' 设置是否区分大小写。
	Set Matches = RegEx.Execute(OrgiStr)
	Gi_fReplaceEx = RegEx.Replace(OrgiStr,ReplStr)         ' 作替换。
End Function

'获得文件后缀名
Function Gi_fGetFileExtName(FileName)
	Dim Pos
	Pos = InStrRev (FileName,".")
	If Pos > 0 Then 
		Gi_fGetFileExtName = Mid (FileName,Pos+1)
	Else
		Gi_fGetFileExtName =  ""
	End If
End Function 

'获取文件名
'SCRIPT_NAME:文件路径名
'Path:int:级数
function Cong_GetFilename(SCRIPT_NAME,Path)
PathFileName = split(SCRIPT_NAME,"/") 
Cong_GetFilename = PathFileName(Path)
end function

'按顺序交替获得颜色
Function Gi_fChgBgColor(i,Sep,Color)
	If IsNull(i) Or IsNull(Sep) Then Exit Function
	Dim TmpArray
	TmpArray = Split(Color,Sep,-1)	
	Gi_fChgBgColor = TmpArray( i mod (Ubound(TmpArray)+1))
End Function

'验证过程触发时间相关***********************************
'替换JAVA脚本中的特殊字符
Function Gi_fChgJsStr(Byval Str)
	If IsNull(Str) Then Exit Function
	Str = Replace(Str,"'","\'")
	Str = Replace(Str,"""","\""")
	Str = Replace(Str,chr(13)+chr(10),"\n")
	Gi_fChgJsStr = Str
End Function


'解决数据库单引号问题
Function Gi_fChgSQLStr(Byval Str)
	If IsNull(Str) Then Exit Function
	Str = replace(Str,"'","''")
	Gi_fChgSQLStr = Str
End Function

'显示用户输入的文本，替换特殊字符
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

'只显示指定数量的内容
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

'分离数组中指定项目	
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

'出错，提示后返回前页。一般用于FORM提交
Sub Gi_sOnErrGoBack(StrErr)
	R "<script Language=""JScript"">alert('" & Gi_fChgJsStr(StrErr) & "');"
	R "window.history.go(-1);</script>"
	E
End Sub


'成功，自动表单提交进入指定页面
Sub Gi_sOnSucsSubNext(StrUrl,StrSub)
	R "<form action="""& StrUrl &""" method=""post"" name=""OnSucsSubGoNext"">"& StrSub &"</form><script Language=""JScript"">document.OnSucsSubGoNext.submit(OnSucsSubGoNext.form)</script>"
	E
End Sub


'成功，进入指定页面
Sub Gi_sOnSucsGoNext(StrSucs,url)
	R "<script Language=""JScript"">alert('" & Gi_fChgJsStr(StrSucs) & "');"
	R "_top.location='" & url & "';</script>"
	E
End Sub


'出错，提示后关闭当前窗口。
Sub Gi_sOnErrCloseWindow(StrErr)
	R "<script Language=""JScript"">alert('" & Gi_fChgJsStr(StrErr) & "');"
	R "window.close();</script>"
	E
End Sub


'关闭窗口并刷新父窗口
Sub Gi_sOnSucsReloadOpener(Str)
	R "<script Language=""JScript"">alert('"& Gi_fChgJsStr(Str) &"');window.opener.window.location.reload();window.close();</script>"
	E
End Sub



'测试相关************************************************************
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


'获得本页url的request.servervariables("")集合
Sub ShowServerVariables()
	R "<TABLE border=1><!-- Table Header --><TR><TD><B>Variables</B></TD><TD><B>value</B></TD></TR>"
	For Each Ob In Request.ServerVariables
		R "<TR><TD>"& Ob &"</TD><TD>"& Request.ServerVariables (Ob) &"</TD></TR>"
	Next
	R "</TABLE>"	
End Sub




'********************************************
'函数名：IsValidEmail
'作  用：检查Email地址合法性
'参  数：email ----要检查的Email地址
'返回值：True  ----Email地址合法
'       False ----Email地址不合法
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
'函数名：IsObjInstalled
'作  用：检查组件是否已经安装
'参  数：strClassString ----组件名
'返回值：True  ----已经安装
'       False ----没有安装
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
'函数名：strLength
'作  用：求字符串长度。汉字算两个字符，英文算一个字符。
'参  数：str  ----要求长度的字符串
'返回值：字符串长度
'**************************************************
function strLength(str)
	ON ERROR RESUME NEXT
	dim WINNT_CHINESE
	WINNT_CHINESE    = (len("中国")=2)
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

'------------------检查某一目录是否存在-------------------
Function CheckDir(FolderPath)
	dim fso
	folderpath=Server.MapPath(".")&"\"&folderpath
	Set fso1 = Server.CreateObject("Scripting.FileSystemObject")
	If fso.FolderExists(FolderPath) then
	'存在
		CheckDir = True
	Else
	'不存在
		CheckDir = False
	End if
	Set fso = nothing
End Function

'-------------根据指定名称生成目录---------
Function MakeNewsDir(foldername)
	dim fso,f
	Set fso = Server.CreateObject("Scripting.FileSystemObject")
    Set f = fso.CreateFolder(foldername)
    MakeNewsDir = True
	Set fso = nothing
End Function


'****************************************************
'函数名：SendMail
'作  用：用Jmail组件发送邮件
'参  数：MailtoAddress  ----收信人地址
'        MailtoName    -----收信人姓名
'        Subject       -----主题
'        MailBody      -----信件内容
'        MailAttachment-----附件
'        FromName      -----发信人姓名
'        MailFrom      -----发信人地址
'        Priority      -----信件优先级
'****************************************************
function SendMail(MailtoAddress,MailtoName,Subject,MailBody,MailAttachment,FromName,MailFrom,Priority)
	on error resume next
	Dim JMail
	Set JMail=Server.CreateObject("JMail.Message")
	if err then
		SendMail= "<br><li>没有安装JMail组件</li>"
		err.clear
		exit function
	end if
	JMail.Charset="gb2312"          '邮件编码
	JMail.silent=FALSE				 'JMAIL不会抛出例外错误，返回的值为FALSE跟TRUE
	
	if MailAttachment = "" then 
	JMail.ContentType = "text/html"     '邮件正文格式
	else
	JMail.AddAttachment(MailAttachment)
	end if
	
	'JMail.ServerAddress=PublicMailServer     '用来发送邮件的SMTP服务器
   	JMail.logging = true   '启用使用日志
	
	'如果服务器需要SMTP身份验证则还需指定以下参数
	JMail.MailServerUserName = PublicMailServerUserName		'登录用户名
   	JMail.MailServerPassWord = PublicMailServerPassword		'登录密码
  	'JMail.MailDomain = "meao.net"       '域名（如果用“name@domain.com”这样的用户名登录时，请指明domain.com
	JMail.AddRecipient MailtoAddress	'收信人
	JMail.Subject=Subject			'主题
	JMail.HMTLBody=MailBody			'邮件正文（HTML格式）
	JMail.Body=MailBody				'邮件正文（纯文本格式）
	JMail.FromName=FromName         '发信人姓名
	JMail.From = MailFrom			'发信人Email
	JMail.Priority=Priority			'邮件等级，1为加急，3为普通，5为低级
	JMail.Send(PublicMailServer)
	JMail.ClearRecipients
	SendMail =JMail.ErrorMessage
		'Response.Write(PublicMailServer)
	JMail.Close
	Set JMail=nothing
end function


'****************************************************
  '参数说明
  '只能用"@meao.net"后缀发信
  'Subject     : 邮件标题
  'MailAddress : 发件服务器的地址,如smtp.163.com
  'Email       : 收件人邮件地址
  'Sender      : 发件人姓名
  'Content     : 邮件内容
  'Fromer      : 发件人的邮件地址
'****************************************************
			Sub SendAction(subject, email, sender, content, fromer) 
			Set jmail = CreateObject("Jmail.Message")
			jmail.silent = FALSE   'JMAIL不会抛出例外错误，返回的值为FALSE跟TRUE
			jmail.MailServerUserName = PublicMailServerUserName	     
			jmail.MailServerPassWord = PublicMailServerPassword
			jmail.logging = true   '启用使用日志
			jmail.Charset = "GB2312"  '邮件文字的代码为简体中文
			jmail.ContentType = "text/html"  '邮件的格式为HTML的
			'jmail.ContentType = "multipart/mixed"


			jmail.AddRecipient Email    '邮件的收件人
			jmail.FromName = sender   '邮件发送者的姓名
			jmail.From = fromer    '邮件发送者的邮件地址
			jmail.Priority = 1   '邮件的紧急程序，1 为最快，5 为最慢， 3 为默认值
			jmail.Subject = subject  '邮件的标题
			jmail.Body = content   '邮件的内容
			jmail.Send(PublicMailServer)
			jmail.ClearRecipients
			End Sub
  
  '调用此Sub的例子
'  Dim strSubject,strEmail,strMailAdress,strSender,strContent,strFromer
'  strSubject     = "这是一封用JMAIL发送的测试邮件1111"
'  strContent     = "JMail组件发送测试成功！"
'  strEmail       = "xuc@ucantech.com"
'  strFromer      = "xuc@ucantech.com"


'  Call SendAction (strSubject,strEmail,strSender,strContent,strFromer)
  
'**************************************************
'函数名：ReplaceBadChar
'作  用：过滤非法的SQL字符
'参  数：strChar-----要过滤的字符
'返回值：过滤后的字符
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
	showtotal = "共"
	showFirst = "首页"
	showPre = "上一页"
	showNext = "下一页"
	showLast = "尾页"
	showpage11 = "页"
	ShowNo = "第"
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
'过程名：ShowSearchForm
'作  用：显示文章搜索表单
'参  数：ShowType ----显示方式。1为简洁模式，2为标准模式，3为高级模式
'=================================================
sub ShowSearchForm(Action,ShowType)
	if ShowType<>1 and ShowType<>2 and ShowType<>3 then
		ShowType=1
	end if
	response.write "<table border='0' cellpadding='0' cellspacing='0'>"
	response.write "<form method='Get' name='SearchForm' action='" & Action & "'>"
	response.write "<tr><td height='28' align='center'>"
	if ShowType=1 then
		response.write "<input type='text' name='keyword'  size='15' value='关键字' maxlength='50' onFocus='this.select();'>&nbsp;"
		response.write "<input type='hidden' name='field' value='Title'>"
		response.write "<input type='submit' name='Submit'  value='搜索'>"
		'response.write "<br><br>高级搜索"
	elseif Showtype=2 then
		response.write "<select name='Field' size='1'>"
    	response.write "<option value='Title' selected>文章标题</option>"
	    response.write "<option value='Content'>文章内容</option>"
    	response.write "<option value='Author'>文章作者</option>"
    	response.write "<option value='Editor'>编辑姓名</option>"
		response.write "</select>&nbsp;"
		response.write "<select name='ClassID'><option value=''>所有栏目</option>"
		call Admin_ShowClass_Option(1,0)
		response.write "</select>&nbsp;<input type='text' name='keyword'  size='20' value='关键字' maxlength='50' onFocus='this.select();'>&nbsp;"
		response.write "<input type='submit' name='Submit'  value=' 搜索 '>"
	elseif Showtype=3 then
	
	end if
	response.write "</td></tr></form></table>"
end sub







'**********************************
'suwenyong增加
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
		i = Replace(i, "'", "''") '去掉单引号
	end if
	CheckWords = i
End Function

Function CheckHtmlWords(i)
	i = Trim(i)
	if i <> "" then
		i = Server.HtmlEncode(i) '过滤HTML代码
	end if	
	CheckHtmlWords = i
End Function

Function CheckSqlWords(i)
	i = Trim(i)
	if i <> "" then
		Dim fbdstr 
		fbdstr = "/*|*/|--|and |exec |insert |select |delete |update |count |* |chr |mid |master |truncate |char |declare " '过滤SQL关键字字符串
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

