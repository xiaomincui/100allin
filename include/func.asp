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

'***********************************************
'过程名：showpage
'作  用：显示“上一页 下一页”等信息
'参  数：sfilename  ----链接地址
'       totalnumber ----总数量
'       maxperpage  ----每页数量
'       ShowTotal   ----是否显示总数量
'       ShowAllPages ---是否用下拉列表显示所有页面以供跳转。有某些页面不能使用，否则会出现JS错误。
'       strUnit     ----计数单位
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
		strTemp=strTemp & "共 <b>" & totalnumber & "</b> " & strUnit & "&nbsp;&nbsp;"
	end if
	strUrl=JoinChar(sfilename)
  	if CurrentPage<2 then
    		strTemp=strTemp & "首页 上一页&nbsp;"
  	else
    		strTemp=strTemp & "<a href='" & strUrl & "page=1'>首页</a>&nbsp;"
    		strTemp=strTemp & "<a href='" & strUrl & "page=" & (CurrentPage-1) & "'>上一页</a>&nbsp;"
  	end if

  	if n-currentpage<1 then
    		strTemp=strTemp & "下一页 尾页"
  	else
    		strTemp=strTemp & "<a href='" & strUrl & "page=" & (CurrentPage+1) & "'>下一页</a>&nbsp;"
    		strTemp=strTemp & "<a href='" & strUrl & "page=" & n & "'>尾页</a>"
  	end if
   	strTemp=strTemp & "&nbsp;页次：<strong><font color=red>" & CurrentPage & "</font>/" & n & "</strong>页 "
    strTemp=strTemp & "&nbsp;<b>" & maxperpage & "</b>" & strUnit & "/页"
		strTemp=strTemp & "&nbsp;转到：<select name='page' size='1' onchange=""javascript:window.location='" & strUrl & "page=" & "'+this.options[this.selectedIndex].value;"">"   
    	for i = 1 to n   
    		strTemp=strTemp & "<option value='" & i & "'"
			if cint(CurrentPage)=cint(i) then strTemp=strTemp & " selected "
			strTemp=strTemp & ">第" & i & "页</option>"   
	    next
		strTemp=strTemp & "</select>"
	strTemp=strTemp & "</td></tr></table>"
	response.write strTemp
end sub

'***********************************************
'函数名：JoinChar
'作  用：向地址中加入 ? 或 &
'参  数：strUrl  ----网址
'返回值：加了 ? 或 & 的网址
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
'''''创建静态文件
'''''TemplateID:模板ID,Action:操作类型
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
'通过fso删除文件
'path:删除文件路径
''''''''''''''''''''''''''''''''''''
function Fun_DelFile(path)

    'on error resume next
    Set fs=Server.CreateObject("Scripting.FileSystemObject")
    if fs.FileExists(path) then
      fs.DeleteFile path,True
     ' response.write "成功删除"&path
	  Fun_DelFile = 1
    else
      'response.write "文件不存在!"
	  Fun_DelFile = 0
    end if
    Set fs=nothing
    
end function


'*************************************************
'函数名：gotTopic
'作  用：截字符串，汉字一个算两个字符，英文算一个字符
'参  数：str   ----原字符串
'       strlen ----截取长度
'返回值：截取后的字符串
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
			gotTopic=left(str,i) & "…"
			exit for
		else
			gotTopic=str
		end if
	next
	gotTopic=replace(replace(replace(replace(gotTopic," ","&nbsp;"),chr(34),"&quot;"),">","&gt;"),"<","&lt;")
end function


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



'**************************************************
'函数名：CheckUserLogined
'作  用：检查用户是否登录
'参  数：ThisGroupID	--用户组id
'返回值：True ----已经登录
'        False ---没有登录
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
'函数名：Fun_Logining
'作  用：用户登录
'参  数：UserGroupID	--用户组id
'返回值：True ----已经登录
'        False ---没有登录
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
'函数名：Fun_Logout
'作  用：用户登出
'参  数：
'返回值：True ----已经登录
'        False ---没有登录
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

'**************************************************
'函数名：ShowUserGroupName
'作  用：显示用户组名称
'参  数：intUserGroupID-----用户组ID
'返回值：用户组名称
'**************************************************
function ShowUserGroupName(intUserGroupID)
	if intUserGroupID="" then
		ShowUserGroupName="未知的用户组"
	else
		SqlUserGroup="SELECT * FROM TB_UserGroup where GroupID = "&intUserGroupID
		set rsUserGroup=server.CreateObject ("Adodb.recordset")
		rsUserGroup.open SqlUserGroup,conn,1,3
		ShowUserGroupName=rsUserGroup("GroupName")
	end if
end function

'**************************************************
'函数名：ShowUserLoginTime
'作  用：显示用户登录次数
'参  数：intUserID-----用户ID
'返回值：用户登录次数
'**************************************************
function ShowUserLoginTime(intUserID)
	if intUserID="" then
		ShowUserLoginTime="未知的用户"
	else
		SqlUserLoginTime="SELECT loginTime FROM TB_User where Userid = "&intUserID
		set rsUserLoginTime=server.CreateObject ("Adodb.recordset")
		rsUserLoginTime.open SqlUserLoginTime,conn,1,3
		ShowUserLoginTime=rsUserLoginTime("loginTime")
	end if
end function

'**************************************************
'函数名：ShowUserPoint
'作  用：显示用户积分
'参  数：intUserID-----用户ID
'返回值：用户积分
'**************************************************
function ShowUserPoint(intUserID)
	if intUserID="" then
		ShowUserPoint="未知的用户"
	else
		SqlUserPoint="SELECT UserPoint FROM TB_User where Userid = "&intUserID
		set rsUserPoint=server.CreateObject ("Adodb.recordset")
		rsUserPoint.open SqlUserPoint,conn,1,3
		ShowUserPoint=rsUserPoint("UserPoint")
	end if
end function

'***********************************************
'函数名：Cong_PageLink
'作  用：翻页
'参  数：	RsThis:翻页记录集
'			GuestTotal:数据总数
'			Scriptname:跳转页面
'			UrlAdd:URL参数
'			Mypagesize:当前页显示记录数
'			Unit:单位:"条"、"个"
'			ShowUnit:显示单位:"信息"、"产品"
'返回值：
'			PageShowState：共有5篇日志 | 每页显示2篇 | 第1页 [共页] 
'调用例子：
'			dim PageShowState
'			UrlAdd="FileClassid="&FileClassid
'			Scriptname = "index_test.asp"
'			Set rsFileList= Server.CreateObject("ADODB.Recordset")
'			rsFileList.open "select * From TB_File where ClassID = "&FileClassid&" order by UpdateTime desc",conn,1,1
'			GuestTotal = rsFileList.recordcount '总记录数
'			Mypagesize = 2 '显示记录数
'			Cong_PageLink rsFileList,GuestTotal,Scriptname,UrlAdd,Mypagesize,"条","信息"
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
if Scriptname = "" then Scriptname=Request.Servervariables("script_name") 'Scriptname为空,默认为本页
if UrlAdd <> "" then 'Url无参数
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

if Unit = "" then Unit = "条"
if ShowUnit = "" then ShowUnit = "信息"

PageShowList= "<font style='font-size:11px'>"&PageShowList&"</font>"
PageShowState = "共有"&GuestTotal&Unit&ShowUnit&" | 每页显示"&MyPageSize&Unit&" | 第"&cint(Mypage)&"页 [共"&maxpages&"页]"

END Sub

'***********************************************
'函数名：Cong_ShowOutLink
'作  用：从TB_OutLink获取广告文件(在屏幕左侧)
'参  数：	OutLinkID:广告ID
'返回值：
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

if rsCong_ShowOutLink("Picsource") = 1 then'上传文章
	ThisShowPic =PublicSiteUrl&"/images/UpOutLink/"&rsCong_ShowOutLink("UpFile")
else'Web链接
	ThisShowPic =rsCong_ShowOutLink("UpUrl")
end if

FileExtName = Gi_fGetFileExtName(ThisShowPic)

	if FileExtName = "swf" then 
		Tmp_Cong_ShowOutLink = Tmp_Cong_ShowOutLink & "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0' width='"&PicWidth&"' height='"&PicHeight&"'><param name='movie' value='"& ThisShowPic &"'><param name='quality' value='high'><embed src='"& ThisShowPic &"' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'  width='"&PicWidth&"' height='"&PicHeight&"'></embed></object>"
	else 
		if OutLink <> "" then '如果有指向就加链接
			Tmp_Cong_ShowOutLink = Tmp_Cong_ShowOutLink &  "<a href='"&OutLink&"' " 
				if OpenType = "1" then Tmp_Cong_ShowOutLink = Tmp_Cong_ShowOutLink & " target='_blank' " '如果链接设为弹出
			Tmp_Cong_ShowOutLink = Tmp_Cong_ShowOutLink & ">"
		end if 
			Tmp_Cong_ShowOutLink = Tmp_Cong_ShowOutLink & "<img src="& ThisShowPic &"  width='"&PicWidth&"' height='"&PicHeight&"' border=0>"
		if OutLink <> "" then Tmp_Cong_ShowOutLink = Tmp_Cong_ShowOutLink & "</a>"
	end if 
	
Cong_ShowOutLink = Tmp_Cong_ShowOutLink 

END function

'***********************************************
'函数名：	Fun_CheckPower
'作  用：	根据表名和主键值从TB_PowerItem提取PowerID，对照session里的权限
'参  数：	TableName:表名称
'			KeyID:主键值
'			
'返回值：	前台各个频道广告表格
'调用方法：	当KeyID=0：就是表最高的权限
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

%>

