Imports Microsoft.VisualBasic

Public Class topnew
    Public Sub SetTopNew(ByVal yid As String, ByVal title As String, ByVal PostDate As String, ByVal yunjialeixing As String, ByVal hangxianmiaoshu As String, ByVal StartPort As String, ByVal UserID As String)
        Dim conn As New data_conn
        Dim ck As New check
        Dim ds As New Data.DataSet
        Dim sql As String = ""
        Dim sql1 As String = ""

        yid = ck.CheckInput(yid)
        title = ck.CheckInput(title)
        PostDate = ck.CheckInput(PostDate)
        yunjialeixing = ck.CheckInput(yunjialeixing)
        hangxianmiaoshu = ck.CheckInput(hangxianmiaoshu)
        StartPort = ck.CheckInput(StartPort)
        UserID = ck.CheckInput(UserID)

        sql = sql & "select * from TB_TOPNEW "
        sql = sql & "where 1=1"
        sql = sql & " and userid=" & UserID
        sql = sql & " and yunjialeixing=" & yunjialeixing

        ds = conn.mdb_ds(sql, "topnew")

        If ds.Tables("topnew").Rows.Count > 0 Then
            sql1 = "update TB_TOPNEW set "
            sql1 = sql1 & "yid =" & yid & ", "
            sql1 = sql1 & "title ='" & title & "', "
            sql1 = sql1 & "PostDate ='" & PostDate & "', "
            sql1 = sql1 & "yunjialeixing =" & yunjialeixing & ", "
            sql1 = sql1 & "hangxianmiaoshu ='" & hangxianmiaoshu & "', "
            sql1 = sql1 & "StartPort ='" & StartPort & "' "
            sql1 = sql1 & "where UserID =" & UserID & " "
            sql1 = sql1 & " and yunjialeixing=" & yunjialeixing
        Else
            sql1 = "insert TB_TOPNEW "
            sql1 = sql1 & "("
            sql1 = sql1 & "yid, "
            sql1 = sql1 & "title, "
            sql1 = sql1 & "PostDate, "
            sql1 = sql1 & "yunjialeixing, "
            sql1 = sql1 & "hangxianmiaoshu, "
            sql1 = sql1 & "StartPort, "
            sql1 = sql1 & "UserID "
            sql1 = sql1 & ") "
            sql1 = sql1 & "values "
            sql1 = sql1 & "("
            sql1 = sql1 & yid & ", "
            sql1 = sql1 & "'" & title & "', "
            sql1 = sql1 & "'" & PostDate & "', "
            sql1 = sql1 & yunjialeixing & ", "
            sql1 = sql1 & "'" & hangxianmiaoshu & "', "
            sql1 = sql1 & "'" & StartPort & "', "
            sql1 = sql1 & UserID
            sql1 = sql1 & ") "
        End If

        conn.mdb_exe(sql1)
    End Sub

    Public Sub CheckTopNew(ByVal yunjialeixing As String, ByVal UserID As String)
        Dim conn As New data_conn
        Dim ck As New check
        Dim ds As New Data.DataSet
        Dim sql As String = ""
        Dim sql1 As String = ""

        Dim yid As String
        Dim title As String
        Dim PostDate As String
        Dim hangxianmiaoshu As String
        Dim StartPort As String

        yunjialeixing = ck.CheckInput(yunjialeixing)
        UserID = ck.CheckInput(UserID)

        '搜索该用户该种类的最新运价，注意区分海运与空运运价
        If yunjialeixing = "10" Then
            sql = sql & "select top 1 id,title,PostDate,10 as yunjialeixing,line as hangxianmiaoshu,StartPort,UserID,StartPort_en from T_AIRINFO where userid =" & UserID
        Else
            sql = sql & "select top 1 id,title,PostDate,yunjialeixing,hangxianmiaoshu,StartPort,UserID,StartPort_en from tb_yunjia where yunjialeixing = " & yunjialeixing & " and userid =" & UserID
        End If

        ds = conn.mdb_ds(sql, "topnew")

        If ds.Tables("topnew").Rows.Count > 0 Then
            '如果该用户还有该种类运价，则提取最新的一条加入最新运价表
            Dim topnew As New topnew
            yid = ds.Tables("topnew").Rows(0)("id").ToString
            title = ds.Tables("topnew").Rows(0)("title").ToString
            PostDate = ds.Tables("topnew").Rows(0)("PostDate").ToString
            hangxianmiaoshu = ds.Tables("topnew").Rows(0)("hangxianmiaoshu").ToString
            StartPort = ds.Tables("topnew").Rows(0)("StartPort_en").ToString

            If StartPort = "" Then
                Dim cn As New data_conn
                Dim StartPort_cn As String = ds.Tables("topnew").Rows(0)("StartPort").ToString
                Dim dsStartPort As Data.DataSet = cn.mdb_ds("select * from TB_CHINACITY where CityNameCH='" + StartPort_cn + "'", "StartPort")


                If dsStartPort.Tables("StartPort").Rows.Count > 0 Then
                    StartPort = dsStartPort.Tables("StartPort").Rows(0)("CityName").ToString().ToUpper
                    topnew.SetTopNew(yid, title, PostDate, yunjialeixing, hangxianmiaoshu, StartPort, UserID)
                Else
                    StartPort = StartPort_cn.ToUpper
                End If
            Else
                topnew.SetTopNew(yid, title, PostDate, yunjialeixing, hangxianmiaoshu, StartPort, UserID)
            End If


        Else
            '如果该用户没有该种类运价，则删除其在最新运价表中的数据
            DelTopNew(yunjialeixing, UserID)
        End If
    End Sub

    Public Sub DelTopNew(ByVal yunjialeixing As String, ByVal UserID As String)
        Dim conn As New data_conn
        Dim ck As New check
        Dim sql As String = ""

        yunjialeixing = ck.CheckInput(yunjialeixing)
        UserID = ck.CheckInput(UserID)

        sql = sql & "delete from TB_TOPNEW where yunjialeixing = " & yunjialeixing & " and userid =" & UserID
        conn.mdb_exe(sql)
    End Sub

End Class
