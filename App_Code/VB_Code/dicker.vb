Imports Microsoft.VisualBasic

Public Class dicker
    Public Sub sendpm(ByVal chater As String, ByVal listener As String, ByVal txt As String, ByVal cargo As String, ByVal reply As String, ByVal price As String, ByVal type As String, ByVal listener_realname As String, ByVal companyname As String, ByVal realname As String, ByVal username As String)
        Dim conn As New data_conn
        Dim ck As New check
        Dim sql As String = ""
        sql = sql & "insert into TB_DICKER "
        sql = sql & "( "
        sql = sql & "chater, "
        sql = sql & "listener, "
        sql = sql & "txt, "
        sql = sql & "cargo, "
        sql = sql & "reply, "
        sql = sql & "price, "
        sql = sql & "listener_realname, "
        sql = sql & "companyname, "
        sql = sql & "realname, "
        sql = sql & "username, "
        sql = sql & "chattime, "
        sql = sql & "type "
        sql = sql & ") "
        sql = sql & "values "
        sql = sql & "( "
        sql = sql & ck.CheckInput(chater) & ", "
        sql = sql & ck.CheckInput(listener) & ", "
        sql = sql & "'" & ck.CheckSqlWords(txt) & "', "
        sql = sql & "'" & ck.CheckInput(cargo) & "', "
        sql = sql & "'" & ck.CheckInput(reply) & "', "
        sql = sql & "'" & ck.CheckInput(price) & "', "
        sql = sql & "'" & ck.CheckInput(listener_realname) & "', "
        sql = sql & "'" & ck.CheckInput(companyname) & "', "
        sql = sql & "'" & ck.CheckInput(realname) & "', "
        sql = sql & "'" & ck.CheckInput(username) & "', "
        sql = sql & "getdate(), "
        sql = sql & "'" & ck.CheckInput(type) & "' "
        sql = sql & ") "

        'HttpContext.Current.Response.Write(sql)

        conn.mdb_exe(sql)
        'If HttpContext.Current.Application("dicker_" & listener) Is Nothing Then
        '    HttpContext.Current.Application("dicker_" & listener) = 1
        'Else
        '    HttpContext.Current.Application("dicker_" & listener) = CInt(HttpContext.Current.Application("dicker_" & listener)) + 1
        'End If
    End Sub


    Public Function getpm(ByVal chater As String, ByVal listener As String, ByVal chattype As String) As Data.DataSet
        Dim conn As New data_conn
        Dim ck As New check
        Dim sql As String = ""
        sql = sql & "select * from V_PM "
        sql = sql & "where 1=1 "

        If chater <> "" Then
            sql = sql & " and chater = " & ck.CheckInput(chater)
        End If

        If listener <> "" Then
            sql = sql & " and listener = " & ck.CheckInput(listener)
            If HttpContext.Current.Application("dicker_" & listener) Is Nothing Then
                HttpContext.Current.Application("dicker_" & listener) = 0
            Else
                HttpContext.Current.Application("dicker_" & listener) = 0
            End If
        End If

        If chattype <> "" Then
            sql = sql & " and chattype = " & ck.CheckInput(chattype)
        End If

        sql = sql & " order by mid "

        Dim ds As New Data.DataSet
        ds = conn.mdb_ds(sql, "pm")
        Return ds
    End Function

    Public Function getnewpm(ByVal listener As String) As String
        Dim conn As New data_conn
        Dim ck As New check
        Dim sql As String = ""
        sql = sql & "select count(*) from TB_PM "
        sql = sql & "where 1=1 "
        sql = sql & " and listener = " & ck.CheckInput(listener)
        sql = sql & " and readed = 0 "

        Dim ds As New Data.DataSet
        ds = conn.mdb_ds(sql, "pm")

        Return ds.Tables("pm").Rows(0)(0).ToString()
    End Function
End Class
