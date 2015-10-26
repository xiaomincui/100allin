Imports System.Data

Partial Class search_lcl_need
    Inherits System.Web.UI.Page

    Public city As String = ""

    '起运港参数
    Public sp As String = ""
    '目的港参数
    Public dp As String = ""
    '航线参数
    Public l As String = ""
    '页码参数
    Public p As String = ""
    '排序参数
    Public order As String = "0"
    '船公司参数
    Public cr As String = ""

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""
        Dim check1 As New check

        Dim GetRequest1 As New GetRequest
        p = check1.CheckNumber(GetRequest1.GetRequestQueryString("p", "1"))

        sp = check1.CheckInput(GetRequest1.GetRequestQueryString("sp", ""))
        dp = check1.CheckInput(GetRequest1.GetRequestQueryString("dp", ""))
        l = check1.CheckInput(GetRequest1.GetRequestQueryString("l", ""))
        cr = check1.CheckInput(GetRequest1.GetRequestQueryString("cr", ""))

        hidTxtStartport.Text = Server.UrlDecode(sp)
        hidTxtDestport.Text = Server.UrlDecode(dp)
        hidTxtLine.Text = Server.UrlDecode(l)


        LoadRecord(p)

        sql = "SELECT TOP 15 * "
        sql += "FROM ("
        'sql += "FROM (SELECT STARTPORT, COUNT(STARTPORT) AS c "
        'sql += "FROM TB_LOST_PRICE "
        'sql += "WHERE (STYPE = 9) AND (STARTPORT_1 = '99999999') "
        'sql += "GROUP BY STARTPORT "
        'sql += "UNION ALL "
        sql += "SELECT STARTPORT_2 AS STARTPORT, COUNT(STARTPORT_2) AS c "
        sql += "FROM TB_LOST_PRICE "
        sql += "WHERE (STYPE = 9) AND (STARTPORT_1 <> '99999999') "
        sql += "GROUP BY STARTPORT_2) t "
        sql += "ORDER BY c DESC"

        'Response.Write(sql)

        ds = cn.mdb_ds(sql, "bbs")


        Dim StartportHotArray(8) As String

        StartportHotArray(0) = "上海,shanghai,shang hai"
        StartportHotArray(1) = "宁波,ningbo,ning bo"
        StartportHotArray(2) = "深圳,shenzhen,shen zhen"
        StartportHotArray(3) = "青岛,qingdao,qing dao"
        StartportHotArray(4) = "天津,tianjin,tian jin"
        StartportHotArray(5) = "广州,guangzhou,guang zhuo"
        StartportHotArray(6) = "厦门,xiamen,xia men"
        StartportHotArray(7) = "大连,dalian,da lian"

        Dim starporthot As String = ""
        If sp = "" Then
            starporthot += "<strong>全部</strong> "
        Else
            starporthot += "<a href=""/search/lcl_need.aspx"">全部</a> "
        End If
        'For i As Integer = 0 To ds.Tables("bbs").Rows.Count - 1
        '    If sp = ds.Tables("bbs").Rows(i)(0).ToString Then
        '        starporthot += "<strong>" + ds.Tables("bbs").Rows(i)(0).ToString + "</strong> "
        '    Else
        '        starporthot += "<a href=""/search/lcl_need.aspx?sp=" & Server.UrlEncode(ds.Tables("bbs").Rows(i)(0).ToString) & "&dp=" & dp & "&l=" & l & "&cr=" & cr & """>" + ds.Tables("bbs").Rows(i)(0).ToString + "</a> "
        '    End If
        'Next
        For i As Integer = 0 To 7
            If sp = StartportHotArray(i).Split(",")(0) Then
                starporthot += "<strong>" + StartportHotArray(i).Split(",")(0) + "</strong> "
            Else
                starporthot += "<a href=""/search/lcl_need.aspx?sp=" & StartportHotArray(i).Split(",")(0) & "&dp=" & dp & "&l=" & l & "&cr=" & cr & """>" + StartportHotArray(i).Split(",")(0) + "</a> "
            End If
        Next
        lblStartportHot.Text = starporthot


        sql = "SELECT TOP 15 * "
        sql += "FROM (SELECT DESTPORT, COUNT(DESTPORT) AS c "
        sql += "FROM TB_LOST_PRICE "
        sql += "WHERE (STYPE = 9) AND (DESTPORT_1 = '99999999') "
        sql += "GROUP BY DESTPORT "
        sql += "UNION ALL "
        sql += "SELECT DESTPORT_2 AS DESTPORT, COUNT(DESTPORT_2) AS c "
        sql += "FROM TB_LOST_PRICE "
        sql += "WHERE (STYPE = 9) AND (DESTPORT_1 <> '99999999') "
        sql += "GROUP BY DESTPORT_2) t "
        sql += "ORDER BY c DESC"

        'Response.Write(sql)

        ds = cn.mdb_ds(sql, "bbs")


        Dim destporthot As String = ""
        If dp = "" Then
            destporthot += "<strong>全部</strong> "
        Else
            destporthot += "<a href=""/search/lcl_need.aspx"">全部</a> "
        End If
        For i As Integer = 0 To ds.Tables("bbs").Rows.Count - 1
            If dp = ds.Tables("bbs").Rows(i)(0).ToString Then
                destporthot += "<strong>" + ds.Tables("bbs").Rows(i)(0).ToString + "</strong> "
            Else
                destporthot += "<a href=""/search/lcl_need.aspx?sp=" & sp & "&dp=" & Server.UrlEncode(ds.Tables("bbs").Rows(i)(0).ToString) & "&l=" & l & "&cr=" & cr & """>" + ds.Tables("bbs").Rows(i)(0).ToString + "</a> "
            End If

        Next
        lblDestportHot.Text = destporthot

        sql = "SELECT TOP 15 LINE,count(LINE) as c "
        sql += "FROM TB_LOST_PRICE WHERE (STYPE = 9) "
        sql += "GROUP BY LINE "
        sql += "ORDER BY c DESC"

        'Response.Write(sql)

        ds = cn.mdb_ds(sql, "bbs")


        Dim linehot As String = ""
        If l = "" Then
            linehot += "<strong>全部</strong> "
        Else
            linehot += "<a href=""/search/lcl_need.aspx"">全部</a> "
        End If
        For i As Integer = 0 To ds.Tables("bbs").Rows.Count - 1
            If l = ds.Tables("bbs").Rows(i)(0).ToString Then
                linehot += "<strong>" + ds.Tables("bbs").Rows(i)(0).ToString + "</strong> "
            Else
                linehot += "<a href=""/search/lcl_need.aspx?sp=" & sp & "&dp=" & dp & "&l=" & Server.UrlEncode(ds.Tables("bbs").Rows(i)(0).ToString) & "&cr=" & cr & """>" + ds.Tables("bbs").Rows(i)(0).ToString + "</a> "
            End If

        Next
        lblLineHot.Text = linehot

        sql = "SELECT TOP 5 STARTPORT,Line "
        sql += "FROM TB_LOST_LINE "
        sql += "WHERE "
        sql += "lftype = 8 AND lhidden = 0 "
        sql += "ORDER BY lorder DESC,lhot DESC,ltime DESC "

        ds = cn.mdb_ds(sql, "bbs")
        RptHotFcl.DataSource = ds.Tables("bbs").DefaultView
        RptHotFcl.DataBind()


        sql = "SELECT TOP 5 STARTPORT,Line "
        sql += "FROM TB_LOST_LINE "
        sql += "WHERE "
        sql += "lftype = 9 AND lhidden = 0"
        sql += "ORDER BY lorder DESC,lhot DESC,ltime DESC "

        ds = cn.mdb_ds(sql, "bbs")
        RptHotLcl.DataSource = ds.Tables("bbs").DefaultView
        RptHotLcl.DataBind()

        sql = "SELECT TOP 5 STARTPORT,Line "
        sql += "FROM TB_LOST_LINE "
        sql += "WHERE "
        sql += "lftype = 10 AND lhidden = 0"
        sql += "ORDER BY lorder DESC,lhot DESC,ltime DESC "

        ds = cn.mdb_ds(sql, "bbs")
        RptHotAir.DataSource = ds.Tables("bbs").DefaultView
        RptHotAir.DataBind()
    End Sub

    '载入列表信息
    Sub LoadRecord(ByVal page As String)

        Dim ck As New check
        '取搜索条件，搜索条件保存在隐藏的label内
        Dim startport As String = ck.CheckInput(hidTxtStartport.Text)
        If startport <> "" Then
            startport = startport.Split(",")(0)
        End If
        Dim destport As String = ck.CheckInput(hidTxtDestport.Text)

        page = ck.CheckInput(page)

        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""

        'item是(页码-1)x10，用来计算分页用
        Dim item As Integer
        item = CInt(page - 1) * 20

        '搜索的select语句
        sql = "select top 20 "
        sql = sql & "SID,STIME,STARTPORT,DESTPORT,CARRIER,LINE,STYPE "
        sql = sql & "FROM (SELECT "
        sql = sql & "SID,STIME,STARTPORT_1 AS STARTPORT,DESTPORT_1 AS DESTPORT,CARRIER,LINE,STYPE "
        sql = sql & "FROM "
        sql = sql & "TB_LOST_PRICE "
        sql = sql & "WHERE "
        sql = sql & "1=1 AND STYPE = 9 AND STARTPORT_1 <> '99999999' AND DESTPORT_1 <> '99999999' "
        If sp <> "" Then
            sql = sql & "AND (STARTPORT = '" & sp & "' OR STARTPORT_2 = '" & sp & "')"
        End If
        If dp <> "" Then
            sql = sql & "AND (DESTPORT = '" & dp & "' OR DESTPORT_2 = '" & dp & "')"
        End If
        If l <> "" Then
            sql = sql & "AND (LINE = '" & l & "') "
        End If
        sql = sql & ") AS T "
        sql = sql & "WHERE SID NOT IN "
        sql = sql & "(SELECT TOP " & item.ToString & " SID "
        sql = sql & "FROM "
        sql = sql & "TB_LOST_PRICE "
        sql = sql & "WHERE "
        sql = sql & "1=1 AND STYPE = 9 AND STARTPORT_1 <> '99999999' AND DESTPORT_1 <> '99999999' "
        If sp <> "" Then
            sql = sql & "AND (STARTPORT = '" & sp & "' OR STARTPORT_2 = '" & sp & "')"
        End If
        If dp <> "" Then
            sql = sql & "AND (DESTPORT = '" & dp & "' OR DESTPORT_2 = '" & dp & "')"
        End If
        If l <> "" Then
            sql = sql & "AND (LINE = '" & l & "') "
        End If
        sql = sql & "ORDER BY SID DESC "
        sql = sql & ") "
        sql = sql & "ORDER BY SID DESC "

        ds = cn.mdb_ds(sql, "yunjia")

        Repeater1.DataSource = ds.Tables("yunjia").DefaultView
        Repeater1.DataBind()


        '计算页数
        LoadTotalCount()
    End Sub


    '计算页数
    Sub LoadTotalCount()
        Dim ck As New check
        '取搜索条件，搜索条件保存在隐藏的label内
        Dim startport As String = ck.CheckInput(hidTxtStartport.Text)
        If startport <> "" Then
            startport = startport.Split(",")(0)
        End If
        Dim destport As String = ck.CheckInput(hidTxtDestport.Text)


        '访问数据库，统计记录条数
        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""

        sql = sql & "SELECT "
        sql = sql & "COUNT(*) as T "
        sql = sql & "FROM "
        sql = sql & "TB_LOST_PRICE "
        sql = sql & "WHERE "
        sql = sql & "1=1 AND STYPE = 9 AND STARTPORT_1 <> '99999999' AND DESTPORT_1 <> '99999999' "
        If sp <> "" Then
            sql = sql & "AND (STARTPORT = '" & sp & "' OR STARTPORT_2 = '" & sp & "')"
        End If
        If dp <> "" Then
            sql = sql & "AND (DESTPORT = '" & dp & "' OR DESTPORT_2 = '" & dp & "')"
        End If
        If l <> "" Then
            sql = sql & "AND (LINE = '" & l & "') "
        End If
        ds = cn.mdb_ds(sql, "count")


        '计算出页数
        Dim item As Integer
        item = ds.Tables("count").Rows(0)(0)


        Dim fakeitem As Integer
        fakeitem = ds.Tables("count").Rows(0)(0)

        Dim page As Integer
        If item Mod 20 > 0 Or item = 0 Then
            page = item \ 20 + 1
        Else
            page = item \ 20
        End If


        '以下为页码控制栏相关
        Dim s As String = ""
        Dim cp As Integer = 1
        If Not Request.QueryString("p") Is Nothing Then
            cp = CInt(Request.QueryString("p").ToString)
        End If
        Dim tp As Integer = page

        'If tp >= 100 Then
        '    tp = 100
        'End If


        Dim base_url As String = "/search/lcl_need.aspx?sp=" & Server.UrlEncode(sp) & "&dp=" & Server.UrlEncode(dp) & "&l=" & Server.UrlEncode(l) & "&cr=" & Server.UrlEncode(cr) & "&p="

        Dim end_url As String = ""

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
            s = s + "<span class=""disabled"">下一页</span> "
            s = s + "<span class=""disabled""><img src='/images/fcl/jt7.gif' width='9' height='9' border=0 /></span> "
        Else
            s = s + "<a href=""" + base_url + (cp + 1).ToString + end_url + """><span>下一页</span></a> "
            s = s + "<a href=""" + base_url + tp.ToString + end_url + """><span><img src='/images/fcl/jt7.gif' width='9' height='9' border=0 /></span></a> "
        End If



        Label8.Text = s
        '以上为页码控制栏相关

        ''最后改写总页码标签
        'lblTotalItem.Text = item.ToString
        hidTotalItem.Text = fakeitem.ToString
        lblTotalPage.Text = tp.ToString
        hidTotalPage.Value = tp.ToString
        lblCurrentPage.Text = cp.ToString
        txtPageJump.Value = cp.ToString


    End Sub


    Public Function key(ByVal es As String) As String
        Dim s As New SymmetricMethod
        Return s.Encrypto(es)
    End Function

    Public Shared Function GetFirstString(ByVal stringToSub As String, ByVal length As Integer) As String
        '\u4e00-\u9fa5 中文区
        '\uff00-\uffef 逗号区
        '\u3000-\u303f 句号区
        '\u2000-\u206f 引号区
        '\u25a0-\u25ff 几何图形区


        Dim regex As New Regex("[\u4e00-\u9fa5\uff00-\uffef\u3000-\u303f\u2000-\u206f\u25a0-\u25ff]+", RegexOptions.Compiled)
        Dim stringChar As Char() = stringToSub.ToCharArray()
        Dim sb As New StringBuilder()
        Dim nLength As Integer = 0
        Dim isCut As Boolean = False
        For i As Integer = 0 To stringChar.Length - 1
            If regex.IsMatch((stringChar(i)).ToString()) Then
                sb.Append(stringChar(i))
                nLength += 2
            Else
                sb.Append(stringChar(i))
                nLength = nLength + 1
            End If

            If nLength > length Then
                isCut = True
                Exit For
            End If
        Next
        Return sb.ToString()
    End Function
End Class
