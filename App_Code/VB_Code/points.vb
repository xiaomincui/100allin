Imports Microsoft.VisualBasic

Public Class points
    Public Sub AddView(ByVal type As String, ByVal UserID As String)
        Dim conn As New data_conn
        Dim ck As New check
        Dim sql As String = ""

        If UserID <> "" Then
            UserID = ck.CheckInput(UserID)
            sql = sql & "UPDATE TB_User_Points SET " + type + "_view = " + type + "_view + 1,view_points = view_points + 1,total_points = total_points + 1 WHERE userid =" & UserID
            'HttpContext.Current.Response.Write(sql)
            conn.mdb_exe(sql)
        End If
    End Sub

    Public Sub CutView(ByVal type As String, ByVal UserID As String)
        Dim conn As New data_conn
        Dim ck As New check
        Dim sql As String = ""

        If UserID <> "" Then
            UserID = ck.CheckInput(UserID)
            sql = sql & "UPDATE TB_User_Points SET " + type + "_view = " + type + "_view - 1,view_points = view_points - 1,total_points = total_points - 1 WHERE userid =" & UserID
            'HttpContext.Current.Response.Write(sql)
            conn.mdb_exe(sql)
        End If
    End Sub

    Public Sub AddPub(ByVal type As String, ByVal UserID As String)
        Dim conn As New data_conn
        Dim ck As New check
        Dim sql As String = ""

        If UserID <> "" Then
            UserID = ck.CheckInput(UserID)
            sql = sql & "UPDATE TB_User_Points SET " + type + "_pub = " + type + "_pub + 1,pub_points = pub_points + 1,total_points = total_points + 1 WHERE userid =" & UserID
            'HttpContext.Current.Response.Write(sql)
            conn.mdb_exe(sql)
        End If
    End Sub

    Public Sub CutPub(ByVal type As String, ByVal UserID As String)
        Dim conn As New data_conn
        Dim ck As New check
        Dim sql As String = ""

        If UserID <> "" Then
            UserID = ck.CheckInput(UserID)
            sql = sql & "UPDATE TB_User_Points SET " + type + "_pub_v = " + type + "_pub_v + 1,pub_points = pub_points - 1,total_points = total_points - 1 WHERE userid =" & UserID
            'HttpContext.Current.Response.Write(sql)
            conn.mdb_exe(sql)
        End If
    End Sub

    Public Sub AddNewPoints(ByVal UserID As String)
        Dim conn As New data_conn
        Dim ck As New check
        Dim sql As String = ""

        If UserID <> "" Then
            UserID = ck.CheckInput(UserID)

            sql = sql & "Insert TB_User_Points (userid) VALUES (" & UserID & ")"
            'HttpContext.Current.Response.Write(sql)
            conn.mdb_exe(sql)
        End If
    End Sub
End Class
