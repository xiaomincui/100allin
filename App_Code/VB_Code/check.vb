Imports Microsoft.VisualBasic

Public Class check
    Public Function CheckInput(ByVal i As String) As String
        i = CheckWords(i)
        i = CheckHtmlWords(i)
        i = CheckSqlWords(i)
        Return i
    End Function

    Public Function ShowInput(ByVal i As String) As String
        i = CheckHtmlWords(i)
        i = CheckSqlWords(i)
        Return i
    End Function

    Public Function CheckRecord(ByVal i As String) As String
        i = CheckWords(i)
        i = CheckSqlWords(i)
        Return i
    End Function

    Public Function CheckWords(ByVal i As String) As String
        i = Trim(i)
        i = Replace(i, "'", "''") '去掉单引号
        Return i
    End Function

    Public Function CheckHtmlWords(ByVal i As String) As String
        i = Trim(i)
        i = HttpContext.Current.Server.HtmlEncode(i) '过滤HTML代码
        Return i
    End Function

    Public Function CheckSqlWords(ByVal i As String) As String
        i = Trim(i)
        Dim fbdstr = "/*|*/|--|and |exec |insert |select |delete |update |count |* |chr |mid |master |truncate |char |declare |Times New Roman" '过滤SQL关键字字符串
        Dim anyfbdstr() = Split(fbdstr, "|")
        For Each s As String In anyfbdstr
            If i.ToLower.IndexOf(s) >= 0 Then
                i = Left(i, i.ToLower.IndexOf(s)) & Mid(i, (i.ToLower.IndexOf(s) + s.Length + 1))
            End If
        Next
        Return i
    End Function

    Public Function CheckNumber(ByVal i As String) As String
        If IsNumeric(i) Then
            Return i
        Else
            Return 0
        End If
    End Function

    Public Function CheckNumber1(ByVal i As String) As String
        If IsNumeric(i) Then
            Return i
        Else
            Return -1
        End If
    End Function
End Class
