Imports System.Data

Partial Class search_air_detail
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
                    Label28.Text = Label28.Text + "<a href=""http://www.100allin.com/air/" & ss.Encrypto(Request.QueryString("id").ToString) & "_0.html"">http://www.100allin.com/air/" & ss.Encrypto(Request.QueryString("id").ToString) & "_0.html</a>"
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
                    Label28.Text = Label28.Text + "<a href=""http://www.100allin.com/air/" & ss.Encrypto(Request.QueryString("id").ToString) & "_0.html"">http://www.100allin.com/air/" & ss.Encrypto(Request.QueryString("yid").ToString) & "_0.html</a>"
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

            Dim ck As New check
            If ck.CheckNumber(ss.Decrypto(Request.QueryString("yid").ToString)) <= 0 Then
                Panel6.Visible = False
                Panel4.Visible = True
            Else
                If Page.IsPostBack = False Then
                    AddHits()
                    LoadDetail()
                End If
            End If




        End If
    End Sub

    Sub LoadDetail()
        Dim g As New GetRequest
        Dim ss As New SymmetricMethod
        Dim ck As New check
        Dim id As String = ck.CheckNumber(ss.Decrypto(Request.QueryString("yid").ToString))
        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""
        sql = sql & "SELECT "
        sql = sql & "* "
        sql = sql & "FROM "
        sql = sql & "T_AIRINFO "
        sql = sql & "WHERE "
        sql = sql & "id= " & id

        'Response.Write(sql)
        ds = cn.mdb_ds(sql, "base")

        If ds.Tables("base").Rows.Count <= 0 Then
            Response.Redirect("err.aspx")
        End If


        If ds.Tables("base").Rows(0)("ifpass").ToString() = 0 Then    '若运价未通过审核
            If ds.Tables("base").Rows(0)("userid").ToString() <> g.GetRequestCookies("user_id", "0") And g.GetRequestCookies("admin", "0") <> "yes" Then '只有发运价的用户和管理员能看到该条运价，否则跳转到出错页面
                Response.Redirect("err.aspx")
            Else
                Panel2.Visible = True
            End If
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


        If tempfreight_string.IndexOf(Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/air/" & Request.QueryString("yid").ToString & "_" & Request.QueryString("ydid").ToString & ".html"" target=""_blank"">[整箱] " & ds.Tables("base").Rows(0)("title") & "</a></nobr></div></li>")) = -1 Then
            If tempfreight.Length < 6 Then
                tempfreight_string = Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/air/" & Request.QueryString("yid").ToString & "_" & Request.QueryString("ydid").ToString & ".html"" target=""_blank"">[整箱] " & ds.Tables("base").Rows(0)("title") & "</a></nobr></div></li>") & "|" & tempfreight_string
            Else
                tempfreight_string = Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/air/" & Request.QueryString("yid").ToString & "_" & Request.QueryString("ydid").ToString & ".html"" target=""_blank"">[整箱] " & ds.Tables("base").Rows(0)("title") & "</a></nobr></div></li>")
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
        ltrPostDate.Text = Format(ds.Tables("base").Rows(0)("postdate"), "yyyy-MM-dd").ToString
        ltrEndDate.Text = Format(ds.Tables("base").Rows(0)("enddate"), "yyyy-MM-dd").ToString
        Literal4.Text = "空运运价"
        Literal5.Text = ds.Tables("base").Rows(0)("startport").ToString
        Literal6.Text = ds.Tables("base").Rows(0)("line").ToString
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
        sqlcount = sqlcount & "FROM t_airprice "
        sqlcount = sqlcount & "WHERE 1=1 "
        If did = "-1" Then
            sqlcount = sqlcount & "AND destport = '" & ddest & "' "
            sqlcount = sqlcount & "AND airid = " & id & " "
        Else
            sqlcount = sqlcount & "AND airid = " & id & " "
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
            base_url = "/air/" & yid & "_" & ddest & "_"
        Else
            base_url = "/air/" & yid & "_" & did & "_"
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


        If did <> "0" Then

            Dim sqldetail As String = ""
            sqldetail = sqldetail & "SELECT "
            sqldetail = sqldetail & "* "
            sqldetail = sqldetail & "FROM t_airprice "
            sqldetail = sqldetail & "WHERE 1=1 "
            If did = "-1" Then
                sqldetail = sqldetail & "AND destport = '" & ddest & "' "
                sqldetail = sqldetail & "AND airid = " & id & " "
            Else
                sqldetail = sqldetail & "AND t_airprice.id= " & did & " "
            End If
            ds = cn.mdb_ds(sqldetail, "search")


            If ds.Tables("search").Rows.Count > 0 Then
                If did = "-1" Then

                Else
                    'Label21.Text = ds.Tables("search").Rows(0)("infohits").ToString
                End If

                LabDestport.Text = ds.Tables("search").Rows(0)("destport").ToString
                LabM.Text = ds.Tables("search").Rows(0)("PRICE_M").ToString
                LabN.Text = ds.Tables("search").Rows(0)("PRICE_N").ToString
                Lab45.Text = ds.Tables("search").Rows(0)("PRICE_P45").ToString
                Lab100.Text = ds.Tables("search").Rows(0)("PRICE_P100").ToString
                Lab300.Text = ds.Tables("search").Rows(0)("PRICE_P300").ToString
                Lab500.Text = ds.Tables("search").Rows(0)("PRICE_P500").ToString
                Lab1000.Text = ds.Tables("search").Rows(0)("PRICE_P1000").ToString
                LabPlus.Text = ds.Tables("search").Rows(0)("price20gpAppend").ToString
                LabDistance.Text = ds.Tables("search").Rows(0)("Distance").ToString
                LabDepartureWkd.Text = ds.Tables("search").Rows(0)("DepartureWkd").ToString

            Else
                sqldetail = "SELECT TOP 1 "
                sqldetail = sqldetail & "* "
                sqldetail = sqldetail & "FROM t_airprice "
                sqldetail = sqldetail & "WHERE 1=1 "
                If did = "-1" Then
                    sqldetail = sqldetail & "AND destport = '" & ddest & "' "
                    sqldetail = sqldetail & "AND airid = " & id & " "
                Else
                    sqldetail = sqldetail & "AND airid = " & id & " "
                End If
                sqldetail = sqldetail & "ORDER BY t_airprice.id DESC"
                'Response.Write(sqldetail)
                ds = cn.mdb_ds(sqldetail, "search")

                If ds.Tables("search").Rows.Count > 0 Then
                    LabDestport.Text = ds.Tables("search").Rows(0)("destport").ToString
                    LabM.Text = ds.Tables("search").Rows(0)("PRICE_M").ToString
                    LabN.Text = ds.Tables("search").Rows(0)("PRICE_N").ToString
                    Lab45.Text = ds.Tables("search").Rows(0)("PRICE_P45").ToString
                    Lab100.Text = ds.Tables("search").Rows(0)("PRICE_P100").ToString
                    Lab300.Text = ds.Tables("search").Rows(0)("PRICE_P300").ToString
                    Lab500.Text = ds.Tables("search").Rows(0)("PRICE_P500").ToString
                    Lab1000.Text = ds.Tables("search").Rows(0)("PRICE_P1000").ToString
                    LabPlus.Text = ds.Tables("search").Rows(0)("price20gpAppend").ToString
                    LabDistance.Text = ds.Tables("search").Rows(0)("Distance").ToString
                    LabDepartureWkd.Text = ds.Tables("search").Rows(0)("DepartureWkd").ToString
                Else

                End If

            End If
        Else

            Dim sqldetail As String = ""
            sqldetail = sqldetail & "SELECT TOP 1 "
            sqldetail = sqldetail & "* "
            sqldetail = sqldetail & "FROM t_airprice "
            sqldetail = sqldetail & "WHERE 1=1 "
            If did = "-1" Then
                sqldetail = sqldetail & "AND destport = '" & ddest & "' "
                sqldetail = sqldetail & "AND airid = " & id & " "
            Else
                sqldetail = sqldetail & "AND airid = " & id & " "
            End If
            sqldetail = sqldetail & "ORDER BY t_airprice.id DESC"
            'Response.Write(sqldetail)
            ds = cn.mdb_ds(sqldetail, "search")

            If ds.Tables("search").Rows.Count > 0 Then

                LabDestport.Text = ds.Tables("search").Rows(0)("destport").ToString
                LabM.Text = ds.Tables("search").Rows(0)("PRICE_M").ToString
                LabN.Text = ds.Tables("search").Rows(0)("PRICE_N").ToString
                Lab45.Text = ds.Tables("search").Rows(0)("PRICE_P45").ToString
                Lab100.Text = ds.Tables("search").Rows(0)("PRICE_P100").ToString
                Lab300.Text = ds.Tables("search").Rows(0)("PRICE_P300").ToString
                Lab500.Text = ds.Tables("search").Rows(0)("PRICE_P500").ToString
                Lab1000.Text = ds.Tables("search").Rows(0)("PRICE_P1000").ToString
                LabPlus.Text = ds.Tables("search").Rows(0)("price20gpAppend").ToString
                LabDistance.Text = ds.Tables("search").Rows(0)("Distance").ToString
                LabDepartureWkd.Text = ds.Tables("search").Rows(0)("DepartureWkd").ToString
            Else

            End If

        End If

        '提取起运港的中英文名称
        Dim sqlfrom As String

        sqlfrom = ""
        sqlfrom = sqlfrom & "SELECT citynameen,cityname ,ad "
        sqlfrom = sqlfrom & "FROM TB_Airport "
        sqlfrom = sqlfrom & "WHERE "
        sqlfrom = sqlfrom & "cityname = '" & Literal5.Text & "' "
        sqlfrom = sqlfrom & "OR citynameen = '" & Literal5.Text & "' "
        sqlfrom = sqlfrom & "OR ad = '" & Literal5.Text & "' "

        ds = cn.mdb_ds(sqlfrom, "city")

        Dim city0 As String = ""
        Dim sqlstarport As String = ""

        If ds.Tables("city").Rows.Count > 0 Then
            sqlstarport = "and (t_airinfo.startport like '%" & ck.CheckWords(ds.Tables("city").Rows(0)(0).ToString) & "%' "
            sqlstarport = sqlstarport + "or t_airinfo.startport like '%" & ck.CheckWords(ds.Tables("city").Rows(0)(1).ToString) & "%' "
            sqlstarport = sqlstarport + "or t_airinfo.startport like '%" & ck.CheckWords(ds.Tables("city").Rows(0)(2).ToString) & "%') "
            city0 = ck.CheckWords(ds.Tables("city").Rows(0)(0).ToString)
        Else
            sqlstarport = "and t_airinfo.startport like '%" & ck.CheckWords(Literal5.Text) & "%' "
            city0 = ck.CheckWords(Literal5.Text)
        End If

        '提取目的港的中英文名称
        Dim sqlto As String

        sqlto = ""
        sqlto = sqlto & "SELECT citynameen,cityname ,ad "
        sqlto = sqlto & "FROM TB_Airport "
        sqlto = sqlto & "WHERE "
        sqlto = sqlto & "cityname = '" & LabDestport.Text & "' "
        sqlto = sqlto & "OR citynameen = '" & LabDestport.Text & "' "
        sqlto = sqlto & "OR ad = '" & LabDestport.Text & "' "

        ds = cn.mdb_ds(sqlto, "city")

        Dim city1 As String = ""
        Dim sqldestport As String = ""

        If ds.Tables("city").Rows.Count > 0 Then
            sqldestport = "and (t_airprice.destport like '%" & ck.CheckWords(ds.Tables("city").Rows(0)(0).ToString) & "%' "
            sqldestport = sqldestport + "or t_airprice.destport like '%" & ck.CheckWords(ds.Tables("city").Rows(0)(1).ToString) & "%' "
            sqldestport = sqldestport + "or t_airprice.destport like '%" & ck.CheckWords(ds.Tables("city").Rows(0)(2).ToString) & "%') "
            city1 = ck.CheckWords(ds.Tables("city").Rows(0)(0).ToString)
        Else
            sqldestport = "and t_airprice.destport like '%" & ck.CheckWords(LabDestport.Text) & "%' "
            city1 = ck.CheckWords(LabDestport.Text)
        End If

        Try
            'ds = GetFreightCompany(Literal5.Text, "", LabDestport.Text)
            'RptFreight.DataSource = ds.Tables("freight").DefaultView
            'RptFreight.DataBind()

            'ds = GetFreightCompany(Literal5.Text, Literal6.Text, "")
            'RptFreightLine.DataSource = ds.Tables("freight").DefaultView
            'RptFreightLine.DataBind()
        Catch ex As Exception
        End Try



        sql = ""
        sql = sql & "SELECT TOP 15 * "
        sql = sql & "FROM "
        sql = sql & "("
        sql = sql & "SELECT * ,'" & city0 & "' as startport1 "
        sql = sql & "FROM V_POP_AIR "
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
        sql = sql & "FROM V_POP_AIR "
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




        Label27.Text = "运价详情"
        Label17.Text = Literal5.Text
        Label18.Text = " 到 " & LabDestport.Text
        Label20.Text = Literal5.Text
        Label22.Text = " - " & Literal6.Text

        ltrXgLink1.Text = "<a href=""/air/list-" & city0 & "-" & LabDestport.Text & "--0-0-0-----1.html"" style=""margin-left:445px;"" target=""_blank"">更多相关运价>></a>"

        ltrXgLink2.Text = "<a href=""/air/list-" & city0 & "---0-0-0-----1.html"" style=""margin-left:445px;"" target=""_blank"">更多相关运价>></a>"

        Dim LineHotArray(8) As String
        LineHotArray(0) = "全部,0"
        LineHotArray(1) = "北美线,1"
        LineHotArray(2) = "欧洲线,2"
        LineHotArray(3) = "南美线,3"
        LineHotArray(4) = "亚洲线,4"
        LineHotArray(5) = "非洲线,5"
        LineHotArray(6) = "澳洲线,6"
        LineHotArray(7) = "国内航线,7"
        For i As Integer = 0 To 7
            If LineHotArray(i).IndexOf(Literal6.Text) <> -1 Then
                ltrXgLink2.Text = "<a href=""/air/list-" & city0 & "---" & LineHotArray(i).Split(",")(1) & "-0-0-----1.html"" style=""margin-left:445px;"" target=""_blank"">更多相关运价>></a>"
            End If
        Next

        Dim sqlother As String = ""

        sqlother = sqlother & "SELECT "
        sqlother = sqlother & "distinct destport,'" & id & "' as sid "
        sqlother = sqlother & "FROM t_airprice "
        sqlother = sqlother & "WHERE "
        sqlother = sqlother & "airid= " & id & " "
        sqlother = sqlother & "ORDER BY destport "

        'Response.Write(sqlother)
        ds = cn.mdb_ds(sqlother, "other")

        Repeater1.DataSource = ds.Tables("other").DefaultView
        Repeater1.DataBind()


        Dim OtherListDestPort As String
        OtherListDestPort = LabDestport.Text

        Dim sqlsearch As String = ""

        'sqlsearch = "select top 5 "
        'sqlsearch = sqlsearch & "t_airinfo.startport as startport, "
        'sqlsearch = sqlsearch & "t_airprice.destport as destport, "
        'sqlsearch = sqlsearch & "t_airprice.id as id, "
        'sqlsearch = sqlsearch & "t_airinfo.id as sid, "
        'sqlsearch = sqlsearch & "t_airinfo.title as title, "
        'sqlsearch = sqlsearch & "t_airprice.price_p45 as price_p45, "
        'sqlsearch = sqlsearch & "t_airprice.price_p100 as price_p100, "
        'sqlsearch = sqlsearch & "t_airprice.price_p300 as price_p300, "
        'sqlsearch = sqlsearch & "t_airprice.price_p500 as price_p500, "
        'sqlsearch = sqlsearch & "t_airprice.price_p1000 as price_p1000, "
        'sqlsearch = sqlsearch & "t_airinfo.line as hangxianmiaoshu, "
        'sqlsearch = sqlsearch & "t_airinfo.postdate as postdate, "
        'sqlsearch = sqlsearch & "t_airinfo.enddate as enddate, "
        'sqlsearch = sqlsearch & "tb_user.userid as userid, "
        'sqlsearch = sqlsearch & "tb_user.companyname as companyname "
        'sqlsearch = sqlsearch & "from t_airinfo,t_airprice,tb_user where 1=1 and t_airinfo.id = t_airprice.airid and t_airinfo.userid = tb_user.userid "
        'sqlsearch = sqlsearch & sqlstarport
        'sqlsearch = sqlsearch & sqldestport
        'sqlsearch = sqlsearch & "and (t_airinfo.userid <> " & user & " and t_airinfo.userid2 <> " & user & ") "
        'sqlsearch = sqlsearch & "and t_airinfo.enddate >= { fn NOW() } "
        'sqlsearch = sqlsearch & "order by t_airinfo.postdate desc "

        ''Response.Write(sqlsearch)
        'ds = cn.mdb_ds(sqlsearch, "search")


        'RptOtherDestport.DataSource = ds.Tables("search").DefaultView
        'RptOtherDestport.DataBind()

        'If ds.Tables("search").Rows.Count <= 0 Then
        '    PlaceHolder1.Visible = False
        'End If

        'sqlsearch = "select distinct top 5 "
        'sqlsearch = sqlsearch & "t_airinfo.startport as startport, "
        'sqlsearch = sqlsearch & "t_airinfo.destport1 as destport, "
        'sqlsearch = sqlsearch & "0 as id, "
        'sqlsearch = sqlsearch & "t_airinfo.id as sid, "
        'sqlsearch = sqlsearch & "t_airinfo.title as title, "
        'sqlsearch = sqlsearch & "t_airprice.price_p45 as price_p45, "
        'sqlsearch = sqlsearch & "t_airprice.price_p100 as price_p100, "
        'sqlsearch = sqlsearch & "t_airprice.price_p300 as price_p300, "
        'sqlsearch = sqlsearch & "t_airprice.price_p500 as price_p500, "
        'sqlsearch = sqlsearch & "t_airprice.price_p1000 as price_p1000, "
        'sqlsearch = sqlsearch & "t_airinfo.line as hangxianmiaoshu, "
        'sqlsearch = sqlsearch & "t_airinfo.postdate as postdate, "
        'sqlsearch = sqlsearch & "t_airinfo.enddate as enddate "
        'sqlsearch = sqlsearch & "from t_airinfo,t_airprice where 1=1 and t_airinfo.id = t_airprice.airid "
        'sqlsearch = sqlsearch & sqlstarport
        'sqlsearch = sqlsearch & "and t_airinfo.line like '%" & Literal6.Text & "%' "
        'sqlsearch = sqlsearch & "and (t_airinfo.userid <> " & user & " and t_airinfo.userid2 <> " & user & ") "
        'sqlsearch = sqlsearch & "and t_airinfo.enddate >= { fn NOW() } "
        'sqlsearch = sqlsearch & "order by t_airinfo.postdate desc "

        ''Response.Write(sqlsearch)
        'ds = cn.mdb_ds(sqlsearch, "search")

        'RptOtherLine.DataSource = ds.Tables("search").DefaultView
        'RptOtherLine.DataBind()

        'If ds.Tables("search").Rows.Count <= 0 Then
        '    PlaceHolder2.Visible = False
        'End If

        sql = ""
        sql = sql & "SELECT "
        sql = sql & "* "
        sql = sql & "FROM "
        sql = sql & "tb_user "
        sql = sql & "WHERE "
        sql = sql & "userid= " & user
        ds = cn.mdb_ds(sql, "user")

        Label15.Text = "<a href=""/company/" & key(ds.Tables("user").Rows(0)("userid").ToString) & "/"" style=""color:red;"" target=""_blank"" title=""点击查看TA的商铺"">" & ds.Tables("user").Rows(0)("realname").ToString & "</a>"
        Literal8.Text = "<a href=""/company/" & key(ds.Tables("user").Rows(0)("userid").ToString) & "/"" target=""_blank"" title=""点击查看TA的商铺"" style=""color:293B5E"">" & ds.Tables("user").Rows(0)("CompanyName").ToString & "</a>"

        Label9.Text = ds.Tables("user").Rows(0)("Phone").ToString
        'Label10.Text = ds.Tables("user").Rows(0)("Fax").ToString
        Label11.Text = ds.Tables("user").Rows(0)("MovePhone").ToString
        Label12.Text = ds.Tables("user").Rows(0)("UserEmail").ToString
        Label13.Text = ds.Tables("user").Rows(0)("Address").ToString & "<span classid=""edushianchor"" city=""" & ds.Tables("user").Rows(0)("city").ToString & """ sitename=""" & ds.Tables("user").Rows(0)("CompanyName").ToString & """ address=""" & ds.Tables("user").Rows(0)("Address").ToString & """ style=""display:none""></span>"
        Label14.Text = ds.Tables("user").Rows(0)("PostNumber").ToString

        Literal29.Text = ds.Tables("user").Rows(0)("Userqq").ToString
        If (Literal29.Text <> "") Then
            Literal29.Text = "<a href=""tencent://message/?uin=" & Literal29.Text & "&Site=www.100allin.com&Menu=yes"" ><img src=""/images/fcl_s/qq.png"" style=""margin:0px"" border=0 alt=""Ta的QQ：" & Literal29.Text & """ width='15' height='16'/></a>"
        End If

        Literal30.Text = ds.Tables("user").Rows(0)("Usermsn").ToString
        If (Literal30.Text <> "") Then
            Literal30.Text = "<a href=""msnim:chat?contact=" & Literal30.Text & """ ><img src=""/images/fcl_s/msn.png"" style=""margin:0px"" border=0 alt=""Ta的MSN：" & Literal30.Text & """ width='16' height='16'/></a>"
        End If

        If CBool(ds.Tables("user").Rows(0)("HeadURL")) = True Then
            imghead.Src = "/member/Head/" + ds.Tables("user").Rows(0)("UserID").ToString + ".jpg"
        Else
            imghead.Src = "/member/Head/default.jpg"
        End If

        If ds.Tables("user").Rows(0)("star_adv").ToString() <> "0" Then
            Panel1.Visible = True
            Panel3.Visible = False
        End If


        Literal25.Text = "<a href=""/member/pm_detail.aspx?pid=1&cid=" & ds.Tables("user").Rows(0)("userid").ToString & """ target=""_blank""><img src=""/images/fcl_s/bot_1.jpeg""  border=""0"" style= 'margin-top: 12px;' width='78' height='20'/></a>"

        Literal26.Text = "<a href=""/member/addfriend.aspx?u=" & ds.Tables("user").Rows(0)("userid").ToString & """ target=""blank""><img src='/images/fcl_s/bot_2.jpeg' border = '0' style= 'margin-top: 12px;' width='78' height='20'/></a>"

        Dim dsCommentCount As Data.DataSet = cn.mdb_ds("select count(*) from TB_Message_Comment where issuer=" + ds.Tables("user").Rows(0)("UserID").ToString, "commentcount")
        'Dim dsYunjiaCount As Data.DataSet = cn.mdb_ds("select count(*) from t_airinfo,t_airprice where t_airinfo.id=t_airprice.airid and Userid=" + ds.Tables("user").Rows(0)("UserID").ToString, "commentcount")
        LabCommentCount.Text = dsCommentCount.Tables(0).Rows(0)(0).ToString
        'LabYunjiaCount.Text = dsYunjiaCount.Tables(0).Rows(0)(0).ToString


        'SEO部分，开始
        Dim seotitle As String = "空运运价-环球运费网"
        Dim seokeywords As String = "空运，国际空运，空运运费"
        Dim seodescription As String = "环球运费网最新国际空运运费运价发布:"

        Literal2.Text = "<meta name=""keywords"" content=""" & seokeywords & "," & Literal5.Text & "运费" & "," & Literal6.Text & "运费" & "," & ds.Tables("user").Rows(0)("CompanyName").ToString & "运费"" />"

        If LabDestport.Text = "" Then
            seotitle = Label1.Text & "-起运地 " & Literal5.Text & "-" & seotitle
            Literal3.Text = "<meta name=""description"" content=""" & seodescription & "起运地-" & Literal5.Text & ",航线-" & Literal6.Text & ",由" & ds.Tables("user").Rows(0)("CompanyName").ToString & "发布.环球运费网提供最新最全面的国际空运运费运价查询与发布"" />"
        Else
            seotitle = Label1.Text & "-起运地 " & Literal5.Text & "-目的地 " & LabDestport.Text & "-" & seotitle
            Literal3.Text = "<meta name=""description"" content=""" & seodescription & "起运地-" & Literal5.Text & ",航线-" & Literal6.Text & ",目的地-" & LabDestport.Text & ",由" & ds.Tables("user").Rows(0)("CompanyName").ToString & "发布.环球运费网提供最新最全面的国际空运运费运价查询与发布"" />"
        End If
        Literal1.Text = "<title>" & seotitle & "</title>"

        'SEO部分，结束

        sql = ""
        'sql = sql & "SELECT TB_ORDER.date_create, TB_ORDER.freight_type, TB_ORDER.freight_code,TB_ORDER_STATUS.status_name_forward, TB_User.RealName, TB_ORDER.price_title,TB_ORDER.yiping_forward, TB_ORDER.ping_forward "
        'sql = sql & "FROM TB_ORDER INNER JOIN "
        'sql = sql & "TB_User ON TB_ORDER.order_shipper = TB_User.UserID INNER JOIN "
        'sql = sql & "TB_ORDER_STATUS ON "
        'sql = sql & "TB_ORDER.order_status = TB_ORDER_STATUS.sid "
        'sql = sql & "WHERE TB_ORDER.order_status=6 AND TB_ORDER.freight_code = " & id & " AND TB_ORDER.freight_code1 = " & did
        'ds = cn.mdb_ds(sql, "order")

        'RptOrder.DataSource = ds.Tables("order").DefaultView
        'RptOrder.DataBind()

        'If ds.Tables("order").Rows.Count = 0 Then
        '    phOrder.Visible = False
        'End If

        'If (ds.Tables("order").Rows.Count = 0) Then
        '    phNoOrder.Visible = True
        'Else
        '    phNoOrder.Visible = False
        'End If

        Dim AllinFreight1 As New AllinFreight()
        AllinFreight1.SetFreightViewrecord2("10", ck.CheckNumber(ss.Decrypto(Request.QueryString("yid").ToString)), ck.CheckInput(Request.QueryString("ydid").ToString), ck.CheckInput(user))


        Literal20.Text = "<a href=""/fcl/list-" + Literal5.Text + "-" + LabDestport.Text + "--0-0-0-----1.html"" target=""_blank"">查看全部 " + Literal5.Text + " 至 " + LabDestport.Text + " 的运价 >></a>"

    End Sub

    Public Function GetFreightCompany(ByVal s1 As String, ByVal l As String, ByVal d As String) As Data.DataSet
        Dim cn As New data_conn
        Dim ds As New Data.DataSet
        Dim ck As New check
        s1 = ck.CheckSqlWords(s1)

        d = ck.CheckSqlWords(d)

        Dim sqlfrom As String
        sqlfrom = ""
        sqlfrom = sqlfrom & "SELECT cityname, citynameen,ad "
        sqlfrom = sqlfrom & "FROM TB_Airport "
        sqlfrom = sqlfrom & "WHERE "
        sqlfrom = sqlfrom & "cityname = '" & s1 & "' "
        sqlfrom = sqlfrom & "OR citynameen = '" & s1 & "' "
        sqlfrom = sqlfrom & "OR ad = '" & s1 & "' "
        ds = cn.mdb_ds(sqlfrom, "city")

        Dim sqlstart As String = ""

        If ds.Tables("city").Rows.Count <= 0 Then
            sqlstart = "AND (t_airinfo.StartPort LIKE '%" & s1 & "%') "
        Else
            sqlstart = "AND ((t_airinfo.StartPort LIKE '%" & ds.Tables("city").Rows(0)(0) & "%') OR (t_airinfo.StartPort LIKE '%" & ds.Tables("city").Rows(0)(1) & "%') OR (t_airinfo.StartPort LIKE '%" & ds.Tables("city").Rows(0)(2) & "%')) "
        End If

        Dim sqlto As String
        sqlto = ""
        sqlto = sqlto & "SELECT cityname, citynameen,ad "
        sqlto = sqlto & "FROM TB_Airport "
        sqlto = sqlto & "WHERE "
        sqlto = sqlto & "cityname = '" & d & "' "
        sqlto = sqlto & "OR citynameen = '" & d & "' "
        sqlto = sqlto & "OR ad = '" & d & "' "
        ds = cn.mdb_ds(sqlto, "city")

        Dim sqldest As String = ""

        If ds.Tables("city").Rows.Count <= 0 Then
            sqldest = "AND (t_airprice.DestPort LIKE '%" & d & "%') "
        Else
            sqldest = "AND ((t_airprice.DestPort LIKE '%" & ds.Tables("city").Rows(0)(0) & "%') OR (t_airprice.DestPort LIKE '%" & ds.Tables("city").Rows(0)(1) & "%') OR (t_airprice.DestPort LIKE '%" & ds.Tables("city").Rows(0)(2) & "%')) "
        End If



        Dim sql As String
        sql = ""

        sql = sql + "SELECT TOP 7 TB_User.star_allin,t_airinfo.UserID, TB_User.CompanyName, COUNT(t_airinfo.UserID) AS c "
        sql = sql + "FROM t_airinfo INNER JOIN t_airprice ON t_airinfo.id = t_airprice.airid INNER JOIN TB_User ON t_airinfo.UserID = TB_User.UserID "
        sql = sql + "WHERE 1=1 "
        sql = sql + sqlstart
        sql = sql + sqldest
        sql = sql + "AND (t_airinfo.line LIKE '%" & l & "%') AND (t_airinfo.enddate >= { fn NOW() }) "
        sql = sql + "GROUP BY TB_User.star_allin,t_airinfo.UserID, TB_User.CompanyName "
        sql = sql + "ORDER BY TB_User.star_allin DESC,c DESC "



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
        sql_hits = sql_hits & "t_airprice "
        sql_hits = sql_hits & "SET "
        sql_hits = sql_hits & "infohits = infohits + 1 "
        sql_hits = sql_hits & "WHERE "
        sql_hits = sql_hits & "id= " & id

        'Response.Write(sql_hits)
        cn.mdb_exe(sql_hits)

        sql_hits = "UPDATE "
        sql_hits = sql_hits & "t_airinfo "
        sql_hits = sql_hits & "SET "
        sql_hits = sql_hits & "hits = hits + 1 "
        sql_hits = sql_hits & "WHERE "
        sql_hits = sql_hits & "id= " & yid

        cn.mdb_exe(sql_hits)
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
                w = "<img src=""/images/fcl/ay_1.jpg"" border=""0"" class=""yt"" width=""35"" height=""18"">"
            Case "2"
                w = "<img src=""/images/fcl/ay_2.jpg"" border=""0"" class=""yt"" width=""35"" height=""18"">"
            Case "3"
                w = "<img src=""/images/fcl/ay_3.gif"" border=""0"" class=""yt"" width=""35"" height=""18"">"
            Case "4"
                w = "<img src=""/images/fcl/ay_4.jpg"" border=""0"" class=""yt"" width=""35"" height=""18"">"
            Case "5"
                w = "<img src=""/images/fcl/ay_5.jpg"" border=""0"" class=""yt"" width=""35"" height=""18"">"

        End Select

        Return w.ToString()
    End Function

    Public Shared Function Star2(ByVal s As String) As String
        Dim ss As Integer
        ss = Convert.ToInt32(s)
        Dim w As String
        w = ""

        For i As Integer = 0 To ss - 1
            w = w + "<img src=""/images/fcl/star.gif"" border=""0"" alt=""信誉等级：" + s + "级"" width=""16"" height=""16"">"
        Next

        If ss = 0 Then
            w = "-"
        End If

        Return w.ToString()
    End Function
End Class
