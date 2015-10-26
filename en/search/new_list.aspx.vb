
Partial Class en_search_new_list
    Inherits System.Web.UI.Page
    '页码参数
    Public p As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Request.QueryString("p") Is Nothing Then
                p = Request.QueryString("p").ToString
                LoadRecord(p)
            Else
                LoadRecord("1")
            End If
        End If
        


    End Sub


    Sub LoadRecord(ByVal page As String)
        Dim item As Integer
        item = CInt(page - 1) * 15

        Dim cn As New data_conn
        Dim sql As String = ""
        
        sql += "select top 15 id,title,content,datepart(month,PostDate) as month,datepart(year,PostDate) as year,datepart(day,PostDate) as day from (select * from TB_En_News) as T where id not in (select top " + item.ToString() + " id from TB_En_News order by PostDate desc) order by PostDate desc"
        Dim ds As Data.DataSet = cn.mdb_ds(sql, "new")
        Repeater1.DataSource = ds.Tables("new").DefaultView
        Repeater1.DataBind()
        LoadTotalCount()
    End Sub

    Sub LoadTotalCount()
        '计算出页数
        Dim cn As New data_conn
        Dim ds2 As New Data.DataSet

        Dim sql As String = ""
        sql = sql & "SELECT "
        sql = sql & "count(id) as T "
        sql = sql & "FROM "
        sql = sql & "TB_En_News "
        ds2 = cn.mdb_ds(sql, "count")
        Dim item_count As Integer

        Dim fakeitem As Integer
        fakeitem = ds2.Tables("count").Rows(0)(0).ToString

        If fakeitem < 1500 Then
            item_count = fakeitem
        Else
            item_count = 1500
        End If



        Dim page_count As Integer
        If item_count Mod 15 > 0 Or item_count = 0 Then
            page_count = item_count \ 15 + 1
        Else
            page_count = item_count \ 15
        End If

        '以下为页码控制栏相关
        Dim s As String = ""
        Dim cp As Integer = 1
        If Not Request.QueryString("p") Is Nothing Then
            cp = CInt(Request.QueryString("p").ToString)
        End If
        Dim tp As Integer = page_count

        If tp >= 100 Then
            tp = 100
        End If


        Dim base_url As String = "/en/new/list-----------"

        Dim end_url As String = ".html"

        If cp = 1 Then
            s = s + "<span class=""disabled""><img src='/images/fcl/jt5.gif' width='9' height='9'  border=0 /></span> "
            s = s + "<span class=""disabled""><img src='/images/fcl/jt6.GIF' border=0  /></span> "
            s = s + "<span class=""current"">1</span> "
            Dim i As Integer

            Dim di As Integer = 0

            If tp < 10 Then
                di = tp
            Else
                di = 10
            End If

            For i = 2 To di
                s = s + "<a href=""" + base_url + "" + i.ToString + end_url + """><span>" + i.ToString + "</span></a> "
            Next i

        Else
            s = s + "<a href=""" + base_url + "1.html""><span><img src='/images/fcl/jt5.gif' width='9' height='9'  border=0 /></span></a> "
            s = s + "<a href=""" + base_url + (cp - 1).ToString + end_url + """><span><img src='/images/fcl/jt6.GIF' border=0  /></span></a> "

            Dim i As Integer
            Dim si As Integer = 1
            Dim di As Integer = 1

            If cp <= 5 Then
                si = 1
            Else
                If tp - cp < 5 Then
                    If tp - 9 < 1 Then
                        si = 1
                    Else
                        si = tp - 9
                    End If
                Else
                    si = cp - 4
                End If
            End If


            For i = si To cp - 1
                s = s + "<a href=""" + base_url + i.ToString + end_url + """><span>" + i.ToString + "</span></a> "
            Next i

            s = s + "<span class=""current"">" + cp.ToString + "</span> "


            If cp + 5 >= tp Then
                di = tp
            Else
                If cp <= 5 Then
                    If tp >= 10 Then
                        di = 10
                    Else
                        di = tp
                    End If
                Else
                    di = cp + 5
                End If
            End If


            For i = cp + 1 To di
                s = s + "<a href=""" + base_url + i.ToString + end_url + """><span>" + i.ToString + "</span></a> "
            Next i
        End If


        If cp = tp Then
            s = s + "<span class=""disabled"">Next</span> "
            s = s + "<span class=""disabled""><img src='/images/fcl/jt7.gif' width='9' height='9' border=0 /></span> "
        Else
            s = s + "<a href=""" + base_url + (cp + 1).ToString + end_url + """><span>Next</span></a> "
            s = s + "<a href=""" + base_url + tp.ToString + end_url + """><span><img src='/images/fcl/jt7.gif' width='9' height='9' border=0 /></span></a> "
        End If



        Label8.Text = s
        '以上为页码控制栏相关

        ''最后改写总页码标签
        'lblTotalItem.Text = item.ToString
        'hidTotalItem.Text = fakeitem.ToString
        'lblTotalPage.Text = tp.ToString

        lblCurrentPage.Text = cp.ToString
        txtPageJump.Value = cp.ToString
    End Sub



    Function Month(ByVal strmonth As String) As String

        Select Case strmonth
            Case "1"
                Return "Jan."
            Case "2"
                Return "Feb."
            Case "3"
                Return "Mar."
            Case "4"
                Return "Apr."
            Case "5"
                Return "May."
            Case "6"
                Return "Jun."
            Case "7"
                Return "Jul."
            Case "8"
                Return "Aug."
            Case "9"
                Return "Sept."
            Case "10"
                Return "Oct."
            Case "11"
                Return "Nov."
            Case "12"
                Return "Dec."
        End Select
        Return ""
    End Function

    Protected Sub Button1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.ServerClick

    End Sub
End Class
