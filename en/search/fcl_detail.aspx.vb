Imports System.Data

Partial Class search_fcl_detail
    Inherits System.Web.UI.Page
    Public chatuser As String = ""
    Public chatowner As String = ""
    Public ddest As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ss As New SymmetricMethod
        Dim flag As Integer = 0
        Panel6.Visible = True
        Panel5.Visible = False
        If Not Me.Request.QueryString("id") Is Nothing Then
            If Me.Request.QueryString("id").ToString <> "" Then
                If CInt(Me.Request.QueryString("id").ToString) <= 18184 Then
                    Panel6.Visible = False
                    Panel5.Visible = True
                    Label28.Text = "亲爱的用户，由于系统升级，您所查看的运价已转移至以下地址：<br/>"
                    Label28.Text = Label28.Text + "<a href=""http://www.100allin.com/fcl/" & ss.Encrypto(Request.QueryString("id").ToString) & "_0.html"">http://www.100allin.com/fcl/" & ss.Encrypto(Request.QueryString("id").ToString) & "_0.html</a>"
                    flag = 1
                End If
            End If
        End If

        If Not Me.Request.QueryString("yid") Is Nothing Then
            If IsNumeric(Me.Request.QueryString("yid").ToString) Then
                If CInt(Me.Request.QueryString("yid").ToString) <= 18184 Then
                    Panel6.Visible = False
                    Panel5.Visible = True
                    Label28.Text = "亲爱的用户，由于系统升级，您所查看的运价已转移至以下地址：<br/>"
                    Label28.Text = Label28.Text + "<a href=""http://www.100allin.com/fcl/" & ss.Encrypto(Request.QueryString("id").ToString) & "_0.html"">http://www.100allin.com/fcl/" & ss.Encrypto(Request.QueryString("yid").ToString) & "_0.html</a>"
                    flag = 1
                End If
            End If
        End If


        If flag = 0 Then
            Panel6.Visible = True
            Panel5.Visible = False
            If (Me.Request.Cookies("user_id") Is Nothing) Then
            Else
                chatowner = Me.Request.Cookies("user_id").Value.ToString
            End If



            If (Me.Request.Cookies("user_id") Is Nothing) Then
                Panel3.Visible = True
                PlaceHolder3.Visible = False
                Panel1.Visible = False

            Else
                If (Me.Request.Cookies("user_id").Value.ToString = "") Then
                    Panel3.Visible = True
                    PlaceHolder3.Visible = False
                    Panel1.Visible = False
                Else

                    Panel3.Visible = False
                    PlaceHolder3.Visible = True
                    Panel1.Visible = True
                End If

            End If

            Try
                Dim ck As New check
                If ck.CheckNumber(ss.Decrypto(Request.QueryString("yid").ToString)) <= 0 Then
                    Panel6.Visible = False
                    Panel4.Visible = True
                Else
                    If Page.IsPostBack = False Then
                        AddHits()
                        LoadDetail()
                        LoadMessage()
                    End If
                End If
            Catch ex As Exception
                Panel6.Visible = False
                Panel4.Visible = True
                'Response.Write(ex.ToString)
            End Try



        End If
    End Sub

    Sub LoadDetail()
        Dim ss As New SymmetricMethod
        Dim ck As New check
        Dim id As String = ck.CheckNumber(ss.Decrypto(Request.QueryString("yid").ToString))
        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""
        sql = sql & "SELECT "
        sql = sql & "* "
        sql = sql & "FROM "
        sql = sql & "tb_yunjia "
        sql = sql & "WHERE "
        sql = sql & "id= " & id

        'Response.Write(sql)
        ds = cn.mdb_ds(sql, "base")

        If ds.Tables("base").Rows.Count <= 0 Then
            Response.Redirect("err.aspx")
        End If

        '写入并读取最近浏览过的运价列表，开始
        Dim tempfreight() As String
        Dim tempfreight_string As String

        If Not Request.Cookies("tempfreight") Is Nothing Then
            tempfreight_string = Request.Cookies("tempfreight").Value
            tempfreight = tempfreight_string.Split("|")
        Else
            tempfreight_string = ""
            tempfreight = tempfreight_string.Split("|")
        End If


        If tempfreight_string.IndexOf(Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/fcl/" & Request.QueryString("yid").ToString & "_" & Request.QueryString("ydid").ToString & ".html"" target=""_blank"">[整箱] " & ds.Tables("base").Rows(0)("title") & "</a></nobr></div></li>")) = -1 Then
            If tempfreight.Length < 6 Then
                tempfreight_string = Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/fcl/" & Request.QueryString("yid").ToString & "_" & Request.QueryString("ydid").ToString & ".html"" target=""_blank"">[整箱] " & ds.Tables("base").Rows(0)("title") & "</a></nobr></div></li>") & "|" & tempfreight_string
            Else
                tempfreight_string = Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/fcl/" & Request.QueryString("yid").ToString & "_" & Request.QueryString("ydid").ToString & ".html"" target=""_blank"">[整箱] " & ds.Tables("base").Rows(0)("title") & "</a></nobr></div></li>")
                For i As Integer = 0 To tempfreight.Length - 2
                    tempfreight_string = tempfreight_string & "|" & tempfreight(i)
                Next
            End If
        End If



        Response.Cookies("tempfreight").Value = tempfreight_string
        Response.Cookies("tempfreight").Expires = DateTime.Now.AddDays(365)
        '写入并读取最近浏览过的运价列表，结束


        '运价基本信息

        'lblWindowTitle.Text = GetFirstString(ds.Tables("base").Rows(0)("title").ToString, 70)
        Label1.Text = ds.Tables("base").Rows(0)("title").ToString
        Label2.Text = Format(ds.Tables("base").Rows(0)("postdate"), "yyyy-MM-dd").ToString
        Label3.Text = Format(ds.Tables("base").Rows(0)("enddate"), "yyyy-MM-dd").ToString
        Select Case ds.Tables("base").Rows(0)("yunjialeixing").ToString
            Case "8"
                Label4.Text = "整箱海运价"
            Case "9"
                Label4.Text = "拼箱海运价"
        End Select
        Label5.Text = ds.Tables("base").Rows(0)("startport").ToString
        Label6.Text = ds.Tables("base").Rows(0)("hangxianmiaoshu").ToString
        LabMemo.Text = ds.Tables("base").Rows(0)("memo").ToString.Replace("&lt;br&gt;", "<br/>").Replace("&amp;", "").Replace("amp;", "").Replace("lt;brgt;", "")
        'Label21.Text = ds.Tables("base").Rows(0)("hits").ToString

        '载入发布者信息，如果是代发的信息，则载入被代发者信息
        Dim user As String = ""

        If IsDBNull(ds.Tables("base").Rows(0)("userid2")) Then
            user = ds.Tables("base").Rows(0)("userid").ToString
        Else
            If ds.Tables("base").Rows(0)("userid2").ToString = 0 Then
                user = ds.Tables("base").Rows(0)("userid").ToString
            Else
                user = ds.Tables("base").Rows(0)("userid2").ToString
            End If
        End If

        chatuser = user

        Dim p As String = "1"
        If Not Request.QueryString("p") Is Nothing Then
            p = ck.CheckNumber(Request.QueryString("p").ToString)
        End If

        Dim yid As String = Request.QueryString("yid").ToString
        Dim did As String = ck.CheckNumber1(Request.QueryString("ydid").ToString)

        If did = "-1" Then
            ddest = ck.CheckInput(Request.QueryString("ydid").ToString)
        End If

        Dim sqlcount As String = ""

        sqlcount = sqlcount & "SELECT "
        sqlcount = sqlcount & "count(*) as c "
        sqlcount = sqlcount & "FROM TB_YunJiaInfo "
        sqlcount = sqlcount & "WHERE 1=1 "
        If did = "-1" Then
            sqlcount = sqlcount & "AND destport = '" & ddest & "' "
            sqlcount = sqlcount & "AND yunjiaid = " & id & " "
        Else
            sqlcount = sqlcount & "AND yunjiaid = " & id & " "
        End If

        'Response.Write(sqlother)
        ds = cn.mdb_ds(sqlcount, "count")


        'item是(页码-1)x10，用来计算分页用
        Dim item As Integer
        item = CInt(p - 1) * 15

        Dim tp As Integer
        tp = Convert.ToInt32(ds.Tables("count").Rows(0)(0).ToString)

        ltrTi.Text = tp

        If tp Mod 15 > 0 Or tp = 0 Then
            tp = tp \ 15 + 1
        Else
            tp = tp \ 15
        End If

        ltrTp.Text = tp

        Dim cp As Integer
        cp = p

        Dim s As String = ""
        Dim s1 As String = ""

        Dim base_url As String = ""

        If did = "-1" Then
            base_url = "/fcl/" & yid & "_" & ddest & "_"
        Else
            base_url = "/fcl/" & yid & "_" & did & "_"
        End If



        Dim end_url As String = ".html#detail"

        If cp = 1 Then
            s = s + "<span class=""disabled"">|<</span> "
            s = s + "<span class=""disabled""><</span> "
            s1 = s1 + "<span class=""disabled""><span>上一页</span></span> "
            s = s + "<span class=""selected"">1</span> "
            s1 = s1 + "<b>1</b> "
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
            s = s + "<a href=""" + base_url + "1.html""><span>|<</span></a> "
            s = s + "<a href=""" + base_url + (cp - 1).ToString + end_url + """><span><</span></a> "
            s1 = s1 + "<a href=""" + base_url + (cp - 1).ToString + end_url + """><span>上一页</span></a> "

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

            s = s + "<span class=""selected"">" + cp.ToString + "</span> "
            s1 = s1 + "<b>" + cp.ToString + "</b> "


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
            s1 = s1 + "<span class=""disabled"">下一页</span> "
            s = s + "<span class=""disabled"">>|</span> "
        Else
            s = s + "<a href=""" + base_url + (cp + 1).ToString + end_url + """><span>下一页</span></a> "
            s1 = s1 + "<a href=""" + base_url + (cp + 1).ToString + end_url + """><span>下一页</span></a> "
            s = s + "<a href=""" + base_url + tp.ToString + end_url + """><span>>|</span></a> "
        End If
        ltrPage.Text = s1
        ltrPage2.Text = s

        '提取起运港的中英文名称
        Dim sqlfrom As String
        sqlfrom = ""
        sqlfrom = sqlfrom & "SELECT cityname, citynamech "
        sqlfrom = sqlfrom & "FROM TB_CHINACITY "
        sqlfrom = sqlfrom & "WHERE "
        sqlfrom = sqlfrom & "cityname = '" & Label5.Text & "' "
        sqlfrom = sqlfrom & "OR citynamech like '%" & Label5.Text & "%' "
        ds = cn.mdb_ds(sqlfrom, "city")

        Dim city0 As String = ""
        Dim city1 As String = ""
        Dim sqlstarport As String = ""

        If ds.Tables("city").Rows.Count > 0 Then
            sqlstarport = "and (tb_yunjia.startport like '%" & ds.Tables("city").Rows(0)(0).ToString & "%' "
            sqlstarport = sqlstarport + "or tb_yunjia.startport like '%" & ds.Tables("city").Rows(0)(1).ToString & "%') "
            city0 = ds.Tables("city").Rows(0)(0).ToString
        Else
            sqlstarport = "and tb_yunjia.startport like '%" & Label5.Text & "%' "
            city0 = Label5.Text
        End If



        sql = ""
        sql = sql & "SELECT TOP 15 * "
        sql = sql & "FROM "
        sql = sql & "("
        sql = sql & "SELECT * ,'" & city0 & "' as startport1 "
        sql = sql & "FROM V_POP_FCL "
        sql = sql & "WHERE 1=1 "

        If did = "-1" Then
            sql = sql & "AND destport = '" & ddest & "' "
            sql = sql & "AND yunjiaid = " & id & " "
        Else
            sql = sql & "AND yunjiaid = " & id & " "
        End If

        sql = sql & ") AS T "
        sql = sql & "WHERE "
        sql = sql & "id NOT IN "
        sql = sql & "("
        sql = sql & "SELECT top " & item.ToString & " id "
        sql = sql & "FROM V_POP_FCL "
        sql = sql & "WHERE 1=1 "

        If did = "-1" Then
            sql = sql & "AND destport = '" & ddest & "' "
            sql = sql & "AND yunjiaid = " & id & " "
        Else
            sql = sql & "AND yunjiaid = " & id & " "
        End If

        sql = sql & "ORDER BY destport "
        sql = sql & ") "
        sql = sql & "ORDER BY destport "
        'Response.Write(sql)

        ds = cn.mdb_ds(sql, "detail")

        '其他运价详细信息
        RptYunjia.DataSource = ds.Tables("detail").DefaultView
        RptYunjia.DataBind()



        If did <> "0" Then

            Dim sqldetail As String = ""
            sqldetail = sqldetail & "SELECT "
            sqldetail = sqldetail & "* "
            sqldetail = sqldetail & "FROM TB_YunJiaInfo "
            sqldetail = sqldetail & "WHERE 1=1 "
            If did = "-1" Then
                sqldetail = sqldetail & "AND destport = '" & ddest & "' "
                sqldetail = sqldetail & "AND yunjiaid = " & id & " "
            Else
                sqldetail = sqldetail & "AND TB_YunJiaInfo.id= " & did & " "
            End If
            ds = cn.mdb_ds(sqldetail, "search")

            If ds.Tables("search").Rows.Count > 0 Then
                If did = "-1" Then

                Else
                    'Label21.Text = ds.Tables("search").Rows(0)("infohits").ToString
                End If

                LabDestport.Text = ds.Tables("search").Rows(0)("destport").ToString
                Lab20GP.Text = ds.Tables("search").Rows(0)("price20gp").ToString
                Lab40GP.Text = ds.Tables("search").Rows(0)("price40gp").ToString
                Lab40HQ.Text = ds.Tables("search").Rows(0)("price40hq").ToString
                Lab45HQ.Text = ds.Tables("search").Rows(0)("price45hq").ToString
                LabPlus.Text = ds.Tables("search").Rows(0)("price20gpAppend").ToString
                LabDistance.Text = ds.Tables("search").Rows(0)("Distance").ToString
                LabDepartureWkd.Text = ds.Tables("search").Rows(0)("DepartureWkd").ToString
                Labshipcompany.Text = ds.Tables("search").Rows(0)("shipcompany").ToString
                If ds.Tables("search").Rows(0)("assurance").ToString = "1" Then
                    LtrCang.Text = "<img src=""/images/fcl/cang.gif"" /><a href=""/topic/order20091104/readme.aspx#a008"" target=""_blank"">舱位保证</a>"
                End If
            Else

                sqldetail = "SELECT TOP 1 "
                sqldetail = sqldetail & "* "
                sqldetail = sqldetail & "FROM TB_YunJiaInfo "
                sqldetail = sqldetail & "WHERE 1=1 "
                If did = "-1" Then
                    sqldetail = sqldetail & "AND destport = '" & ddest & "' "
                    sqldetail = sqldetail & "AND yunjiaid = " & id & " "
                Else
                    sqldetail = sqldetail & "AND yunjiaid = " & id & " "
                End If
                sqldetail = sqldetail & "ORDER BY TB_YunJiaInfo.id DESC"
                ds = cn.mdb_ds(sqldetail, "search")
                If ds.Tables("search").Rows.Count > 0 Then
                    LabDestport.Text = ds.Tables("search").Rows(0)("destport").ToString
                    Lab20GP.Text = ds.Tables("search").Rows(0)("price20gp").ToString
                    Lab40GP.Text = ds.Tables("search").Rows(0)("price40gp").ToString
                    Lab40HQ.Text = ds.Tables("search").Rows(0)("price40hq").ToString
                    Lab45HQ.Text = ds.Tables("search").Rows(0)("price45hq").ToString
                    LabPlus.Text = ds.Tables("search").Rows(0)("price20gpAppend").ToString
                    LabDistance.Text = ds.Tables("search").Rows(0)("Distance").ToString
                    LabDepartureWkd.Text = ds.Tables("search").Rows(0)("DepartureWkd").ToString
                    Labshipcompany.Text = ds.Tables("search").Rows(0)("shipcompany").ToString
                    If ds.Tables("search").Rows(0)("assurance").ToString = "1" Then
                        LtrCang.Text = "<img src=""/images/fcl/cang.gif"" /><a href=""/topic/order20091104/readme.aspx#a008"" target=""_blank"">舱位保证</a>"
                    End If
                Else

                End If
            End If
        Else

            Dim sqldetail As String = ""
            sqldetail = sqldetail & "SELECT TOP 1 "
            sqldetail = sqldetail & "* "
            sqldetail = sqldetail & "FROM TB_YunJiaInfo "
            sqldetail = sqldetail & "WHERE 1=1 "
            If did = "-1" Then
                sqldetail = sqldetail & "AND destport = '" & ddest & "' "
                sqldetail = sqldetail & "AND yunjiaid = " & id & " "
            Else
                sqldetail = sqldetail & "AND yunjiaid = " & id & " "
            End If
            sqldetail = sqldetail & "ORDER BY TB_YunJiaInfo.id DESC"
            'Response.Write(sqldetail)
            ds = cn.mdb_ds(sqldetail, "search")

            If ds.Tables("search").Rows.Count > 0 Then
                'Label21.Text = ds.Tables("search").Rows(0)("infohits").ToString
                LabDestport.Text = ds.Tables("search").Rows(0)("destport").ToString
                Lab20GP.Text = ds.Tables("search").Rows(0)("price20gp").ToString
                Lab40GP.Text = ds.Tables("search").Rows(0)("price40gp").ToString
                Lab40HQ.Text = ds.Tables("search").Rows(0)("price40hq").ToString
                Lab45HQ.Text = ds.Tables("search").Rows(0)("price45hq").ToString
                LabPlus.Text = ds.Tables("search").Rows(0)("price20gpAppend").ToString
                LabDistance.Text = ds.Tables("search").Rows(0)("Distance").ToString
                LabDepartureWkd.Text = ds.Tables("search").Rows(0)("DepartureWkd").ToString
                Labshipcompany.Text = ds.Tables("search").Rows(0)("shipcompany").ToString
                If ds.Tables("search").Rows(0)("assurance").ToString = "1" Then
                    LtrCang.Text = "<img src=""/images/fcl/cang.gif"" /><a href=""/topic/order20091104/readme.aspx#a008"" target=""_blank"">舱位保证</a>"
                End If
            Else

            End If

        End If

        Try
            ds = GetFreightCompany(Label5.Text, "", "", LabDestport.Text)
            RptFreight.DataSource = ds.Tables("freight").DefaultView
            RptFreight.DataBind()

            ds = GetFreightCompany(Label5.Text, "", Label6.Text, "")
            RptFreightLine.DataSource = ds.Tables("freight").DefaultView
            RptFreightLine.DataBind()
        Catch ex As Exception
        End Try

        Label27.Text = "运价详情"
        Label17.Text = Label5.Text
        Label18.Text = " 到 " & LabDestport.Text
        Label20.Text = Label5.Text
        Label22.Text = " - " & Label6.Text

        Literal4.Text = "<a href=""/fcl/list-" & city0 & "-" & LabDestport.Text & "--0-0-0-----1.html"" style=""margin-left:445px;"" target=""_blank"">更多相关运价>></a>"

        Literal5.Text = "<a href=""/fcl/list-" & city0 & "---0-0-0-----1.html"" style=""margin-left:445px;"" target=""_blank"">更多相关运价>></a>"

        Dim LineHotArray(10) As String
        LineHotArray(0) = "全部,0"
        LineHotArray(1) = "美加线,1"
        LineHotArray(2) = "非洲线,6"
        LineHotArray(3) = "中东印巴线,8"
        LineHotArray(4) = "中南美线,3"
        LineHotArray(5) = "欧地线,2"
        LineHotArray(6) = "日韩线,4"
        LineHotArray(7) = "近洋线,5"
        LineHotArray(8) = "澳洲线,7"
        LineHotArray(9) = "红海线,9"
        For i As Integer = 0 To 9
            If LineHotArray(i).IndexOf(Label6.Text) <> -1 Then
                Literal5.Text = "<a href=""/fcl/list-" & city0 & "---" & LineHotArray(i).Split(",")(1) & "-0-0-----1.html"" style=""margin-left:445px;"" target=""_blank"">更多相关运价>></a>"
            End If
        Next

        Dim sqlother As String = ""

        sqlother = sqlother & "SELECT "
        sqlother = sqlother & "distinct destport,'" & id & "' as sid "
        sqlother = sqlother & "FROM TB_YunJiaInfo "
        sqlother = sqlother & "WHERE "
        sqlother = sqlother & "yunjiaid= " & id & " "
        sqlother = sqlother & "ORDER BY destport "

        'Response.Write(sqlother)
        ds = cn.mdb_ds(sqlother, "other")

        Repeater1.DataSource = ds.Tables("other").DefaultView
        Repeater1.DataBind()

        Try
            Dim OtherListDestPort As String
            OtherListDestPort = LabDestport.Text


            Dim sqlsearch As String = ""

            sqlsearch = "select distinct top 5 "
            sqlsearch = sqlsearch & "tb_yunjia.startport as startport, "
            sqlsearch = sqlsearch & "tb_yunjiainfo.destport as destport, "
            sqlsearch = sqlsearch & "tb_yunjiainfo.id as id, "
            sqlsearch = sqlsearch & "tb_yunjia.id as sid, "
            sqlsearch = sqlsearch & "tb_yunjia.title as title, "
            sqlsearch = sqlsearch & "tb_yunjiainfo.price20gp as price20gp, "
            sqlsearch = sqlsearch & "tb_yunjiainfo.price40gp as price40gp, "
            sqlsearch = sqlsearch & "tb_yunjiainfo.price40hq as price40hq, "
            sqlsearch = sqlsearch & "tb_yunjia.hangxianmiaoshu as hangxianmiaoshu, "
            sqlsearch = sqlsearch & "tb_yunjia.postdate as postdate, "
            sqlsearch = sqlsearch & "tb_yunjia.enddate as enddate, "
            sqlsearch = sqlsearch & "tb_yunjiainfo.shipcompany as shipcompany "
            sqlsearch = sqlsearch & "from tb_yunjia,tb_yunjiainfo where 1=1 and tb_yunjia.id = tb_yunjiainfo.yunjiaid "
            sqlsearch = sqlsearch & "and TB_YunJia.yunjialeixing = 8 "
            sqlsearch = sqlsearch & sqlstarport
            sqlsearch = sqlsearch & "and tb_yunjiainfo.destport like '%" & OtherListDestPort & "%' "
            sqlsearch = sqlsearch & "and (tb_yunjia.userid <> " & user & " and tb_yunjia.userid2 <> " & user & ") "
            sqlsearch = sqlsearch & "and TB_YunJia.enddate >= { fn NOW() } "
            sqlsearch = sqlsearch & "order by tb_yunjia.postdate desc "

            'Response.Write(sqlsearch)
            ds = cn.mdb_ds(sqlsearch, "search")


            RptOtherDestport.DataSource = ds.Tables("search").DefaultView
            RptOtherDestport.DataBind()

            If ds.Tables("search").Rows.Count <= 0 Then
                PlaceHolder1.Visible = False
            End If

            sqlsearch = "select distinct top 5 "
            sqlsearch = sqlsearch & "tb_yunjia.startport as startport, "
            sqlsearch = sqlsearch & "tb_yunjia.destport1 as destport, "
            sqlsearch = sqlsearch & "0 as id, "
            sqlsearch = sqlsearch & "tb_yunjia.id as sid, "
            sqlsearch = sqlsearch & "tb_yunjia.title as title, "
            sqlsearch = sqlsearch & "tb_yunjia.price20gp1 as price20gp, "
            sqlsearch = sqlsearch & "tb_yunjia.price40gp1 as price40gp, "
            sqlsearch = sqlsearch & "tb_yunjia.price40hq1 as price40hq, "
            sqlsearch = sqlsearch & "tb_yunjia.hangxianmiaoshu as hangxianmiaoshu, "
            sqlsearch = sqlsearch & "tb_yunjia.postdate as postdate, "
            sqlsearch = sqlsearch & "tb_yunjia.enddate as enddate, "
            sqlsearch = sqlsearch & "tb_yunjia.shipcompany1 as shipcompany "
            sqlsearch = sqlsearch & "from tb_yunjia,tb_yunjiainfo where 1=1 and tb_yunjia.id = tb_yunjiainfo.yunjiaid "
            sqlsearch = sqlsearch & "and TB_YunJia.yunjialeixing = 8 "
            sqlsearch = sqlsearch & sqlstarport
            sqlsearch = sqlsearch & "and tb_yunjia.hangxianmiaoshu like '%" & Label6.Text & "%' "
            sqlsearch = sqlsearch & "and (tb_yunjia.userid <> " & user & " and tb_yunjia.userid2 <> " & user & ") "
            sqlsearch = sqlsearch & "and TB_YunJia.enddate >= { fn NOW() } "
            sqlsearch = sqlsearch & "order by tb_yunjia.postdate desc "

            'Response.Write(sqlsearch)
            ds = cn.mdb_ds(sqlsearch, "search")

            RptOtherLine.DataSource = ds.Tables("search").DefaultView
            RptOtherLine.DataBind()

            If ds.Tables("search").Rows.Count <= 0 Then
                PlaceHolder2.Visible = False
            End If


        Catch ex As Exception

        End Try

        sql = ""
        sql = sql & "SELECT "
        sql = sql & "* "
        sql = sql & "FROM "
        sql = sql & "tb_user "
        sql = sql & "WHERE "
        sql = sql & "userid= " & user
        ds = cn.mdb_ds(sql, "user")

        Label15.Text = "<a href=""/company/" & key(ds.Tables("user").Rows(0)("userid").ToString) & "/"" style=""color:red;"" target=""_blank"" title=""点击查看TA的商铺"">" & ds.Tables("user").Rows(0)("realname").ToString & "</a>"
        Label8.Text = "<a href=""/company/" & key(ds.Tables("user").Rows(0)("userid").ToString) & "/"" target=""_blank"" title=""点击查看TA的商铺"" style=""color:293B5E"">" & ds.Tables("user").Rows(0)("CompanyName").ToString & "</a>"

        Label9.Text = ds.Tables("user").Rows(0)("Phone").ToString
        'Label10.Text = ds.Tables("user").Rows(0)("Fax").ToString
        Label11.Text = ds.Tables("user").Rows(0)("MovePhone").ToString
        Label12.Text = ds.Tables("user").Rows(0)("UserEmail").ToString
        Label13.Text = ds.Tables("user").Rows(0)("Address").ToString & "<span classid=""edushianchor"" city=""" & ds.Tables("user").Rows(0)("city").ToString & """ sitename=""" & ds.Tables("user").Rows(0)("CompanyName").ToString & """ address=""" & ds.Tables("user").Rows(0)("Address").ToString & """ style=""display:none""></span>"
        Label14.Text = ds.Tables("user").Rows(0)("PostNumber").ToString
        LtrStars1.Text = Star1(ds.Tables("user").Rows(0)("star_allin").ToString)
        LtrStars2.Text = Star2(ds.Tables("user").Rows(0)("star_user").ToString)
        If ds.Tables("user").Rows(0)("star_allin").ToString <> "0" Then
            LtrJia.Text = "<img src=""/images/fcl/dc16.gif"" /><a href=""/topic/order20091104/readme.aspx#a007"" target=""_blank"">价格保证</a>"
        End If

        If LtrJia.Text = "" And LtrCang.Text = "" Then
            PlaceHolder4.Visible = False
        End If


        Label29.Text = ds.Tables("user").Rows(0)("Userqq").ToString
        If (Label29.Text <> "") Then
            Label29.Text = "<a href=""tencent://message/?uin=" & Label29.Text & "&Site=www.100allin.com&Menu=yes"" ><img src=""/images/qq.gif"" style=""margin:0px"" border=0 alt=""Ta的QQ：" & Label29.Text & """ /></a>"
        End If

        Label30.Text = ds.Tables("user").Rows(0)("Usermsn").ToString
        If (Label30.Text <> "") Then
            Label30.Text = "<a href=""msnim:chat?contact=" & Label30.Text & """ ><img src=""/images/msn.gif"" style=""margin:0px"" border=0 alt=""Ta的MSN：" & Label30.Text & """ /></a>"
        End If

        If CBool(ds.Tables("user").Rows(0)("HeadURL")) = True Then
            imghead.Src = "/member/Head/" + ds.Tables("user").Rows(0)("UserID").ToString + ".jpg"
        Else
            imghead.Src = "/member/Head/default.jpg"
        End If


        Literal25.Text = "<a href=""/member/pm_detail.aspx?pid=1&cid=" & ds.Tables("user").Rows(0)("userid").ToString & """ target=""_blank""><img src=""/images/fcl/bot_1.jpg""  border=""0"" style= 'margin-top: 12px;'/></a>"
        Label66.Text = "<a href=""/search/fcl_order.aspx?filter=new&yid=" & id & "&ydid=" & did & "&f=" & user & """ target=""_blank""><img src=""/images/fcl/bot_3.gif"" border=""0"" /></a>"

        Literal26.Text = "<a href='/home/?99999' target='blank'><img src='/images/fcl/bot_2.jpg' border = '0' style= 'margin-top: 12px;'/></a>"

        If ds.Tables("user").Rows(0)("UCenterHomeUid").ToString <> "" Then
            Literal26.Text = "<a href='/home/?" + ds.Tables("user").Rows(0)("UCenterHomeUid").ToString + "' target='blank'><img src='/images/fcl/bot_2.jpg' border = '0' style= 'margin-top: 12px;' /></a>"
        End If

        Dim dsCommentCount As Data.DataSet = cn.mdb_ds("select count(*) from TB_Message_Comment where issuer=" + ds.Tables("user").Rows(0)("UserID").ToString, "commentcount")
        Dim dsYunjiaCount As Data.DataSet = cn.mdb_ds("select count(*) from TB_YunJia,TB_YunJiaInfo where TB_YunJia.id=TB_YunJiaInfo.YunJiaID and Userid=" + ds.Tables("user").Rows(0)("UserID").ToString, "commentcount")
        LabCommentCount.Text = dsCommentCount.Tables(0).Rows(0)(0).ToString
        LabYunjiaCount.Text = dsYunjiaCount.Tables(0).Rows(0)(0).ToString





        'SEO部分，开始
        Dim seotitle As String = "整箱海运运价-环球运费网"
        Dim seokeywords As String = "整箱海运,国际海运,整箱运费"
        Dim seodescription As String = ""

        Dim seocr As String = ""
        If Labshipcompany.Text <> "" Then
            seocr = Labshipcompany.Text + "船公司,"
        End If




        Dim seocr1 As String = ""
        If Labshipcompany.Text <> "" Then
            seocr1 = Labshipcompany.Text + "-"
        End If

        Dim seodestport As String = ""
        If LabDestport.Text <> "" Then
            seodestport = LabDestport.Text + "运费"
        End If

        If LabDestport.Text = "" Then
            seotitle = Label1.Text & "-" & Label5.Text & "起运-" & Label6.Text & "-" & seotitle
            Literal2.Text = "<meta name=""keywords"" content=""" & seokeywords & "," & Label5.Text & "运费" & "," & Label6.Text & "运费" & "," & ds.Tables("user").Rows(0)("CompanyName").ToString & "运费"" />"
            Literal3.Text = "<meta name=""description"" content=""" & Label5.Text & "起运,航线描述-" & Label6.Text & ",由" & ds.Tables("user").Rows(0)("CompanyName").ToString & "发布该运费价格.环球运费网提供最新最全面的国际海运整箱运费运价查询与发布"" />"
        Else
            seotitle = seocr1 & Label1.Text & "-" & Label5.Text & "到" & LabDestport.Text & "-" & Label6.Text & "-" & seotitle
            Literal2.Text = "<meta name=""keywords"" content=""" & seokeywords & "," & Label5.Text & "运费" & "," & Label6.Text & "运费" & "," & seodestport & "," & ds.Tables("user").Rows(0)("CompanyName").ToString & "运费"" />"
            Literal3.Text = "<meta name=""description"" content=""" & seocr & Label5.Text & "到" & LabDestport.Text & ",航线描述-" & Label6.Text & ",由" & ds.Tables("user").Rows(0)("CompanyName").ToString & "发布该运费价格.环球运费网提供最新最全面的国际海运整箱运费运价查询与发布"" />"
        End If
        Literal1.Text = "<title>" & seotitle & "</title>"

        'SEO部分，结束



        sql = ""
        sql = sql & "SELECT TB_ORDER.date_create, TB_ORDER.freight_type, TB_ORDER.freight_code,TB_ORDER_STATUS.status_name_forward, TB_User.RealName, TB_YunJia.title,TB_ORDER.yiping_forward, TB_YunJia.title,TB_ORDER.ping_forward "
        sql = sql & "FROM TB_ORDER INNER JOIN "
        sql = sql & "TB_User ON TB_ORDER.order_shipper = TB_User.UserID INNER JOIN "
        sql = sql & "TB_ORDER_STATUS ON "
        sql = sql & "TB_ORDER.order_status = TB_ORDER_STATUS.sid INNER JOIN "
        sql = sql & "TB_YunJia ON TB_ORDER.freight_code = TB_YunJia.id "
        sql = sql & "WHERE TB_ORDER.order_forward = " & user
        ds = cn.mdb_ds(sql, "order")

        RptOrder.DataSource = ds.Tables("order").DefaultView
        RptOrder.DataBind()

        If (ds.Tables("order").Rows.Count = 0) Then
            phNoOrder.Visible = True
        Else
            phNoOrder.Visible = False
        End If


    End Sub

    Public Function GetFreightCompany(ByVal s1 As String, ByVal s2 As String, ByVal l As String, ByVal d As String) As Data.DataSet
        Dim cn As New data_conn
        Dim ds As New Data.DataSet
        Dim ck As New check
        s1 = ck.CheckSqlWords(s1)
        s2 = ck.CheckSqlWords(s2)
        d = ck.CheckSqlWords(d)

        Dim sql As String
        sql = ""
        sql = sql + "SELECT TOP 5 TB_YunJia.UserID, TB_User.CompanyName, COUNT(TB_YunJia.UserID) AS c, dbo.get_yunjiaid(MAX(TB_YunJiaInfo.ID)) AS yid, MAX(TB_YunJiaInfo.ID) AS ydid "
        sql = sql + "FROM TB_YunJia INNER JOIN TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID INNER JOIN TB_User ON TB_YunJia.UserID = TB_User.UserID "
        If s2 = "" Then
            sql = sql + "WHERE (TB_YunJia.StartPort LIKE '%" & s1 & "%') AND (TB_YunJiaInfo.DestPort LIKE '%" & d & "%') AND (TB_YunJia.yunjialeixing = 8) AND (TB_YunJia.hangxianmiaoshu LIKE '%" & l & "%') AND (TB_YunJia.enddate >= { fn NOW() }) AND TB_YunJia.USERID <> 44 "
        Else
            sql = sql + "WHERE ((TB_YunJia.StartPort LIKE '%" & s1 & "%') OR (TB_YunJia.StartPort LIKE '%" & s2 & "%')) AND (TB_YunJiaInfo.DestPort LIKE '%" & d & "%') AND (TB_YunJia.yunjialeixing = 8) AND (TB_YunJia.hangxianmiaoshu LIKE '%" & l & "%') AND (TB_YunJia.enddate >= { fn NOW() }) AND TB_YunJia.USERID <> 44 "
        End If

        sql = sql + "GROUP BY TB_YunJia.UserID, TB_User.CompanyName "
        sql = sql + "ORDER BY c DESC "

        ds = cn.mdb_ds(sql, "freight")
        'Response.Write(sql & "<br/>")
        Return ds
    End Function

    Sub AddHits()
        Dim ck As New check
        Dim ss As New SymmetricMethod
        Dim id As String = ck.CheckNumber(Request.QueryString("ydid").ToString)
        Dim yid As String = ck.CheckNumber(ss.Decrypto(Request.QueryString("yid").ToString))
        Dim cn As New data_conn
        Dim sql_hits As String = ""

        '增加一次点击

        sql_hits = "UPDATE "
        sql_hits = sql_hits & "tb_yunjiainfo "
        sql_hits = sql_hits & "SET "
        sql_hits = sql_hits & "infohits = infohits + 1 "
        sql_hits = sql_hits & "WHERE "
        sql_hits = sql_hits & "id= " & id

        'Response.Write(sql_hits)
        cn.mdb_exe(sql_hits)

        sql_hits = "UPDATE "
        sql_hits = sql_hits & "tb_yunjia "
        sql_hits = sql_hits & "SET "
        sql_hits = sql_hits & "hits = hits + 1 "
        sql_hits = sql_hits & "WHERE "
        sql_hits = sql_hits & "id= " & yid

        cn.mdb_exe(sql_hits)
    End Sub

    Public Sub LoadMessage()
        Dim ck As New check
        Dim cn As New data_conn
        Dim ss As New SymmetricMethod
        Dim sql As String = "select TB_Message_Comment.id,TB_Message_Comment.UserID,TB_User.UserName,TB_Message_Comment.PostDate,TB_Message_Comment.EditDate,TB_Message_Comment.Data,TB_Message_Reply.Data as ReplyData,TB_Message_Reply.PostDate as ReplyPostDate,TB_Message_Comment.goodbad from TB_Message_Comment,TB_User,TB_Message_Reply where TB_Message_Comment.type=1 and TB_Message_Comment.UserID*=TB_User.UserID and TB_Message_Comment.id*=TB_Message_Reply.MessageID and BBSID=" + ck.CheckInput(ss.Decrypto(Request.QueryString("yid").ToString))

        Dim ds As Data.DataSet = cn.mdb_ds(sql, "BBS")
        RptComment.DataSource = ds.Tables("BBS").DefaultView
        RptComment.DataBind()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Me.TextBox1.Value.Length > 100 Then
            MessageBox("", "不能大于100个字")
        Else
            Dim ck As New check
            Dim message As String = ck.CheckInput(Me.TextBox1.Value)

            If Me.TextBox1.Value = "写点评论内容吧 您的评论内容对他人有很大帮助" Then
                message = ""
            End If
            Dim Userid As String
            If CheckBox1.Checked = True Then
                Userid = 0
            Else
                If (Me.Request.Cookies("user_id") Is Nothing) Then
                    Userid = 0
                Else
                    If (Me.Request.Cookies("user_id").Value.ToString = "") Then
                        Userid = 0
                    End If
                    Userid = Me.Request.Cookies("user_id").Value.ToString
                End If
            End If

            Dim cn As New data_conn
            Dim ss As New SymmetricMethod

            Dim ds As Data.DataSet = cn.mdb_ds("select UserID from TB_YunJia where id=" + ss.Decrypto(Request.QueryString("yid").ToString), "issuer")

            cn.mdb_exe("insert into TB_Message_Comment (UserID,PostDate,Data,type,BBSID,issuer,goodbad) values (" + Userid + ",getdate(),'" + message + "',1," + ss.Decrypto(Request.QueryString("yid").ToString) + "," + ds.Tables("issuer").Rows(0)(0).ToString() + "," + RadioButtonList1.SelectedItem.Value + ")")
            'Me.Response.Write("insert into TB_Message_Comment (UserID,PostDate,Data,type,BBSID,issuer) values (" + Userid + ",getdate(),'" + message + "',2," + Request.QueryString("ydid").ToString + "," + ds.Tables("issuer").Rows(0)(0).ToString() + ")")
            TextBox1.Value = ""

            LoadMessage()
        End If

    End Sub

    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub

    Function UnixTimestamp(ByVal dt As DateTime) As String
        Dim dtStart As DateTime = TimeZone.CurrentTimeZone.ToLocalTime(New DateTime(1970, 1, 1))
        Dim toNow As TimeSpan = dt.Subtract(dtStart)
        Dim timeStamp As String = toNow.Ticks.ToString()
        Return timeStamp.Substring(0, timeStamp.Length - 7)
    End Function

    Function IptoInt(ByVal sip As String) As Int64
        Dim Ip_List() As String = sip.Split(".".ToCharArray())
        Dim X_Ip As String = ""
        For Each ip As String In Ip_List
            If CInt(ip) < 10 Then
                X_Ip += "0" + CInt(ip).ToString("X")
            Else
                X_Ip += CInt(ip).ToString("X")
            End If
        Next
        Dim N_Ip As Int64 = Int64.Parse(X_Ip, System.Globalization.NumberStyles.HexNumber)
        Return N_Ip
    End Function

    Public Function key(ByVal es As String) As String
        Dim s As New SymmetricMethod
        Return s.Encrypto(es)
    End Function

    Protected Function Encode(ByVal str As String) As String
        str = str.Replace("&", "&amp;")
        str = str.Replace("'", "''")
        str = str.Replace("\", "&amp;")
        str = str.Replace("   ", "&nbsp;")
        str = str.Replace("<", "&lt;")
        str = str.Replace(">", "&gt;")
        str = str.Replace(vbCrLf, "<br />")
        Return str
    End Function

    Public Function GetQueryString(ByVal q As String) As String
        If Request.QueryString(q) Is Nothing Then
            Return "0"
        Else
            If Request.QueryString(q) = "" Then
                Return "0"
            Else
                Return Request.QueryString(q).ToString
            End If
        End If
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

        If isCut Then
            Return sb.ToString() & ".."
        Else
            Return sb.ToString()
        End If

        Return sb.ToString()

    End Function

    Public Shared Function JingHao(ByVal s As String) As String
        Try
            Return s.Replace("#", "%23")
        Catch ex As Exception
            Return "0"
        End Try
    End Function

    Public Shared Function Every3(ByVal s As String) As String
        If ((CInt(s) + 1) Mod 3) = 0 Then
            Return ""
        Else
            Return "none"
        End If
    End Function

    Public Shared Function GetFreightType(ByVal s1 As String) As String
        If s1 = "8" Then
            Return "海运整箱"
        End If

        If s1 = "9" Then
            Return "海运拼箱"
        End If

        If s1 = "10" Then
            Return "空运"
        End If
    End Function

    Public Shared Function GetPingType(ByVal s1 As String, ByVal s2 As String) As String
        If s1 = "0" Then
            Return "未评价"
        Else
            If s2 = "3" Then
                Return "好评"
            End If
            If s2 = "0" Then
                Return "中评"
            End If
            If s2 = "-3" Then
                Return "差评"
            End If
        End If


    End Function

    Public Shared Function Star1(ByVal s As String) As String
        Dim ss As Integer
        ss = Convert.ToInt32(s)
        Dim w As String
        w = ""

        Select Case s
            Case "1"
                w = "<img src=""/images/fcl/ay_1.jpg"" border=""0"" class=""yt"">"
            Case "2"
                w = "<img src=""/images/fcl/ay_2.jpg"" border=""0"" class=""yt"">"
            Case "3"
                w = "<img src=""/images/fcl/ay_3.gif"" border=""0"" class=""yt"">"
            Case "4"
                w = "<img src=""/images/fcl/ay_4.jpg"" border=""0"" class=""yt"">"
            Case "5"
                w = "<img src=""/images/fcl/ay_5.jpg"" border=""0"" class=""yt"">"

        End Select

        Return w.ToString()
    End Function

    Public Shared Function Star2(ByVal s As String) As String
        Dim ss As Integer
        ss = Convert.ToInt32(s)
        Dim w As String
        w = ""

        For i As Integer = 0 To ss - 1
            w = w + "<img src=""/images/fcl/star.gif"" border=""0"" alt=""信誉等级：" + s + "级"" >"
        Next

        If ss = 0 Then
            w = "-"
        End If

        Return w.ToString()
    End Function
End Class
