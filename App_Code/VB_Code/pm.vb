Imports Microsoft.VisualBasic

Public Class pm

    Public Sub sendpm(ByVal chater As String, ByVal listener As String, ByVal txt As String, ByVal chattype As String)
        Dim conn As New data_conn

        Dim ck As New check
        Dim sql As String = ""
        sql = sql & "insert into TB_PM "
        sql = sql & "( "
        sql = sql & "chater, "
        sql = sql & "listener, "
        sql = sql & "txt, "
        sql = sql & "chattime, "
        sql = sql & "chattype "
        sql = sql & ") "
        sql = sql & "values "
        sql = sql & "( "
        sql = sql & ck.CheckInput(chater) & ", "
        sql = sql & ck.CheckInput(listener) & ", "
        sql = sql & "'" & ck.CheckSqlWords(txt) & "', "
        sql = sql & "getdate(), "
        sql = sql & ck.CheckInput(chattype)
        sql = sql & ") "

        'HttpContext.Current.Response.Write(sql)
        conn.mdb_exe(sql)
        'If HttpContext.Current.Application("pm_" & listener) Is Nothing Then
        '    HttpContext.Current.Application("pm_" & listener) = 1
        'Else
        '    HttpContext.Current.Application("pm_" & listener) = CInt(HttpContext.Current.Application("pm_" & listener)) + 1
        'End If
    End Sub


    Public Function getpm(ByVal chater As String, ByVal listener As String, ByVal chattype As String) As Data.DataSet
        Dim conn As New data_conn
        Dim sql As String = ""
        Dim ck As New check
        sql = sql & "select * from V_PM "
        sql = sql & "where 1=1 "

        If chater <> "" Then
            sql = sql & " and chater = " & ck.CheckInput(chater)
        End If

        If listener <> "" Then
            sql = sql & " and listener = " & ck.CheckInput(listener)
            If HttpContext.Current.Application("pm_" & listener) Is Nothing Then
                HttpContext.Current.Application("pm_" & listener) = 0
            Else
                HttpContext.Current.Application("pm_" & listener) = 0
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

    Public Sub SaveSearchWords2(ByVal yjlx As String, ByVal line As String, ByVal startport As String, ByVal destport As String, ByVal carrier As String, ByVal success As Integer, ByVal line1 As String, ByVal startport_1 As String, ByVal startport_2 As String, ByVal destport_1 As String, ByVal destport_2 As String, ByVal carrier_1 As String, ByVal carrier_2 As String)

        Dim ck As New check
        Dim rqst As String = ""
        Dim address As String = HttpContext.Current.Request.UserHostAddress

        'Dim ifspiderip As Integer = 0
        'Dim spiderip(17) As String
        'spiderip(0) = "61.135.249."
        'spiderip(1) = "127.0.0.1"
        'spiderip(2) = "203.208.60."
        'spiderip(3) = "124.115.0."
        'spiderip(4) = "124.115.4."
        'spiderip(5) = "202.160.178."
        'spiderip(6) = "202.160.179."
        'spiderip(7) = "202.160.180."
        'spiderip(8) = "67.195.111.232"
        'spiderip(9) = "216.129.119"
        'spiderip(10) = "67.218.116."
        'spiderip(11) = "84.105.173"
        'spiderip(12) = "66.249."
        'spiderip(13) = "66.219.58.43"
        'spiderip(14) = "220.181." '百度
        'spiderip(15) = "202.160." '雅虎
        'spiderip(16) = "207.46." 'MSN
        'spiderip(17) = "94.169.191.51" 'www.majestic12.co.uk


        'For i As Integer = 0 To spiderip.Length - 1
        '    If address.Contains(spiderip(i)) Then
        '        ifspiderip = 1
        '    End If
        'Next

        Dim agent As String = ""
        agent = System.Web.HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT").ToString

        Dim ifspider As Integer = 0
        Dim k(10) As String
        k(0) = "spider"
        k(1) = "bot"
        k(2) = "slurp"
        k(3) = "pirst"
        k(4) = "wget"

        For i As Integer = 0 To k.Length - 1
            If Not k(i) Is Nothing Then
                If agent.ToLower.Contains(k(i)) Then
                    ifspider = 1
                End If
            End If
        Next

        If ifspider = 0 Then
            Dim userid As String = ""
            If HttpContext.Current.Request.Cookies("user_id") Is Nothing Then
                userid = "0"
            Else
                If HttpContext.Current.Request.Cookies("user_id").Value = "" Then
                    userid = "0"
                Else
                    userid = HttpContext.Current.Request.Cookies("user_id").Value.ToString
                End If
            End If

            Dim cn As New data_conn
            Dim ds As New Data.DataSet
            Dim sql As String = ""

            sql = "SELECT * FROM TB_LOST_PRICE WHERE "
            sql = sql & "(STARTPORT = '" & ck.CheckInput(startport) & "' OR STARTPORT_1 = '" & ck.CheckInput(startport_1) & "') "
            sql = sql & "AND (DESTPORT = '" & ck.CheckInput(destport) & "' OR DESTPORT_1 = '" & ck.CheckInput(destport_2) & "') "
            sql = sql & "AND (CARRIER = '" & ck.CheckInput(carrier) & "' OR CARRIER_1 = '" & ck.CheckInput(carrier_1) & "') "
            If (line1 <> "") Then
                sql = sql & "AND (LINE = '" & ck.CheckInput(line1) & "') "
            Else
                sql = sql & "AND (LINE = '" & ck.CheckInput(line) & "') "
            End If
            sql = sql & "AND (STYPE = " & ck.CheckInput(yjlx) & ") "

            'HttpContext.Current.Response.Write(sql)

            ds = cn.mdb_ds(sql, "lost")

            sql = ""

            If ds.Tables("lost").Rows.Count > 0 Then
                sql = sql & "UPDATE TB_LOST_PRICE SET STIME = '" & Now.ToString & "',SCOUNT = SCOUNT+1 WHERE SID = " & ds.Tables("lost").Rows(0)("SID").ToString
            Else

                If startport_1 = "" Then
                    startport_1 = "99999999"
                    startport_2 = "99999999"
                End If

                If destport_1 = "" Then
                    destport_1 = "99999999"
                    destport_2 = "99999999"
                End If

                If carrier_1 = "" Then
                    carrier_1 = "99999999"
                    carrier_2 = "99999999"
                End If

                sql = ""
                sql = sql & "INSERT INTO "
                sql = sql & "TB_LOST_PRICE "
                sql = sql & "("
                sql = sql & "LINE, "
                sql = sql & "STARTPORT, "
                sql = sql & "DESTPORT, "
                sql = sql & "CARRIER, "
                sql = sql & "SUCCESS,"
                sql = sql & "SUSERID,"
                sql = sql & "SUSERIP,"
                sql = sql & "STYPE,"
                sql = sql & "STIME,"
                sql = sql & "STARTPORT_1,"
                sql = sql & "STARTPORT_2,"
                sql = sql & "DESTPORT_1,"
                sql = sql & "DESTPORT_2, "
                sql = sql & "CARRIER_1,"
                sql = sql & "CARRIER_2 "
                sql = sql & ")"
                sql = sql & "VALUES "
                sql = sql & "("

                If (line1 <> "") Then
                    sql = sql & "'" & ck.CheckInput(line1) & "', "
                Else
                    sql = sql & "'" & ck.CheckInput(line) & "', "
                End If

                sql = sql & "'" & ck.CheckInput(startport) & "', "
                sql = sql & "'" & ck.CheckInput(destport) & "', "
                sql = sql & "'" & ck.CheckInput(carrier) & "', "
                sql = sql & ck.CheckInput(success) & ", "
                sql = sql & ck.CheckInput(userid) & ", "
                sql = sql & "'" & ck.CheckInput(address) & "', "
                sql = sql & ck.CheckInput(yjlx) & ", "
                sql = sql & "'" & Now.ToString & "', "
                sql = sql & "'" & ck.CheckInput(startport_1) & "', "
                sql = sql & "'" & ck.CheckInput(startport_2) & "', "
                sql = sql & "'" & ck.CheckInput(destport_1) & "', "
                sql = sql & "'" & ck.CheckInput(destport_2) & "', "
                sql = sql & "'" & ck.CheckInput(carrier_1) & "', "
                sql = sql & "'" & ck.CheckInput(carrier_2) & "' "
                sql = sql & ")"
            End If
            cn.mdb_exe(sql)

            'HttpContext.Current.Response.Write(sql)

            If ((line <> "" Or line1 <> "") And startport <> "") Then
                sql = "SELECT * FROM TB_LOST_LINE WHERE "
                sql = sql & "(startport = '" & ck.CheckInput(startport) & "' OR startport = '" & ck.CheckInput(startport_1) & "' OR startport = '" & ck.CheckInput(startport_2) & "') "
                If (line <> "") Then
                    sql = sql & "AND (line = '" & ck.CheckInput(line) & "') "
                Else
                    If (line1 <> "") Then
                        sql = sql & "AND (line = '" & ck.CheckInput(line1) & "') "
                    End If
                End If
                sql = sql & "AND (lftype = " & ck.CheckInput(yjlx) & ") "

                ds = cn.mdb_ds(sql, "lost")

                If ds.Tables("lost").Rows.Count > 0 Then
                    sql = sql & "UPDATE TB_LOST_LINE SET ltime = '" & Now.ToString & "',lhot = lhot+1 WHERE lid = " & ds.Tables("lost").Rows(0)("lid").ToString
                Else
                    sql = sql & "INSERT INTO "
                    sql = sql & "TB_LOST_LINE "
                    sql = sql & "("
                    sql = sql & "line, "
                    sql = sql & "startport, "
                    sql = sql & "ltime,"
                    sql = sql & "ltype,"
                    sql = sql & "lftype,"
                    sql = sql & "lorder,"
                    sql = sql & "lhot, "
                    sql = sql & "lhidden "
                    sql = sql & ")"
                    sql = sql & "VALUES "
                    sql = sql & "("
                    If (line <> "") Then
                        sql = sql & "'" & ck.CheckInput(line) & "', "
                    Else
                        If (line1 <> "") Then
                            sql = sql & "'" & ck.CheckInput(line1) & "', "
                        End If
                    End If

                    If (startport_2 <> "99999999") Then
                        sql = sql & "'" & ck.CheckInput(startport_2) & "', "
                    Else
                        sql = sql & "'" & ck.CheckInput(startport) & "', "
                    End If

                    sql = sql & "'" & Now.ToString & "', "
                    sql = sql & "1, "
                    sql = sql & ck.CheckInput(yjlx) & ", "
                    sql = sql & "3, "
                    sql = sql & "0, "
                    sql = sql & "0 "
                    sql = sql & ")"
                End If
                cn.mdb_exe(sql)
            End If

            sql = "delete from tb_lost_price where (line = '' and stype <> 10) or carrier = '船公司' or startport like '%,%' or startport like '%-%' or startport like '%#%' or startport like '%到%'or destport like '%,%' or destport like '%-%' or destport like '%#%' or destport like '%到%'"

            cn.mdb_exe(sql)
        End If




    End Sub '保存搜索条件
End Class
