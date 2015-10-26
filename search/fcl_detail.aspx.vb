Imports System.Data

Partial Class search_fcl_detail
    Inherits System.Web.UI.Page
    Public chatuser As String = ""
    Public chatowner As String = ""
    Public ddest As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ss As New SymmetricMethod
        Dim flag As Integer = 0
        PlaceHolder6.Visible = True
        Panel5.Visible = False
        Dim agent As String
        agent = System.Web.HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT").ToString()

        If agent.ToLower.Contains("orion") Then
            flag = 1
        End If
        If Not Me.Request.QueryString("id") Is Nothing Then
            If Me.Request.QueryString("id").ToString <> "" Then
                If CInt(Me.Request.QueryString("id").ToString) <= 18184 Then
                    PlaceHolder6.Visible = False
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
                    PlaceHolder6.Visible = False
                    Panel5.Visible = True
                    Label28.Text = "亲爱的用户，由于系统升级，您所查看的运价已转移至以下地址：<br/>"
                    Label28.Text = Label28.Text + "<a href=""http://www.100allin.com/fcl/" & ss.Encrypto(Request.QueryString("id").ToString) & "_0.html"">http://www.100allin.com/fcl/" & ss.Encrypto(Request.QueryString("yid").ToString) & "_0.html</a>"
                    flag = 1
                End If
            End If
        End If


        If flag = 0 Then
            PlaceHolder6.Visible = True
            Panel5.Visible = False
            If (Me.Request.Cookies("user_id") Is Nothing) Then
            Else
                chatowner = Me.Request.Cookies("user_id").Value.ToString
            End If



            If (Me.Request.Cookies("user_id") Is Nothing) Then
                PlaceHolder2.Visible = True
                'PlaceHolder3.Visible = False
                PlaceHolder1.Visible = False

            Else
                If (Me.Request.Cookies("user_id").Value.ToString = "") Then
                    PlaceHolder2.Visible = True
                    'PlaceHolder3.Visible = False
                    PlaceHolder1.Visible = False
                Else

                    PlaceHolder2.Visible = False
                    'PlaceHolder3.Visible = True
                    PlaceHolder1.Visible = True
                End If

            End If

            Dim ck As New check
            If ck.CheckNumber(ss.Decrypto(Request.QueryString("yid").ToString)) <= 0 Then
                PlaceHolder6.Visible = False
                Panel4.Visible = True
            Else
                If Page.IsPostBack = False Then
                    'AddHits()
                    LoadDetail()
                    '
                End If
            End If

            Try

            Catch ex As Exception
                PlaceHolder6.Visible = False
                Panel4.Visible = True
                'Response.Write(ex.ToString)
            End Try



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
        sql = sql & "tb_yunjia "
        sql = sql & "WHERE "
        sql = sql & "id= " & id

        'Response.Write(sql)
        ds = cn.mdb_ds(sql, "base")

        Dim detail_table1 = "V_POP_FCL"
        Dim detail_table2 = "TB_YunJiaInfo"

        If ds.Tables("base").Rows.Count <= 0 Then
            sql = "SELECT "
            sql = sql & "* "
            sql = sql & "FROM "
            sql = sql & "TB_YunJia_bak "
            sql = sql & "WHERE "
            sql = sql & "id= " & id

            ds = cn.mdb_ds(sql, "base")

            If ds.Tables("base").Rows.Count <= 0 Then
                Response.Redirect("err.aspx?errno=1")
            Else
                detail_table1 = "TB_YunJiaInfo_bak"
                detail_table2 = "TB_YunJiaInfo_bak"

                PlaceHolder4.Visible = True

            End If
        End If

        'Response.Write(g.GetRequestCookies("user_id", "0"))

        If ds.Tables("base").Rows(0)("ifpass").ToString() = 0 Then    '若运价未通过审核
            If ds.Tables("base").Rows(0)("userid").ToString() <> g.GetRequestCookies("user_id", "0") And g.GetRequestCookies("admin", "0") <> "yes" Then '只有发运价的用户和管理员能看到该条运价，否则跳转到出错页面
                Response.Redirect("err.aspx?errno=2")
            Else
                Panel2.Visible = True
            End If
        End If




        '运价基本信息

        ltrTitleBC.Text = ds.Tables("base").Rows(0)("title").ToString
        ltrTitle.Text = ds.Tables("base").Rows(0)("title").ToString
        ltrEndDate.Text = Format(ds.Tables("base").Rows(0)("enddate"), "yyyy-MM-dd").ToString
        Literal5.Text = ds.Tables("base").Rows(0)("startport").ToString.ToUpper
        Literal6.Text = ds.Tables("base").Rows(0)("hangxianmiaoshu").ToString
        LabMemo.Text = ds.Tables("base").Rows(0)("memo").ToString.Replace("&lt;br&gt;", "<br/>").Replace("&amp;", "").Replace("amp;", "").Replace("lt;brgt;", "")

        If LabMemo.Text.Trim = "" Then
            LabMemo.Text = "<span class=""notxt"">暂无备注</span>"
        End If

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
        sqlcount = sqlcount & "FROM " & detail_table2 & " "
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
        item = CInt(p - 1) * 10

        Dim tp As Integer
        tp = Convert.ToInt32(ds.Tables("count").Rows(0)(0).ToString)

        ltrTi.Text = tp

        If tp Mod 10 > 0 Or tp = 0 Then
            tp = tp \ 10 + 1
        Else
            tp = tp \ 10
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
            s = s + "<span class=""disabled""><<</span> "
            s = s + "<span class=""disabled""><</span> "
            's1 = s1 + "<span class=""disabled""><span>上一页</span></span> "
            s = s + "<span class=""selected"">1</span> "
            's1 = s1 + "<b>1</b> "
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
            s = s + "<a href=""" + base_url + "1.html""><span class=""button""><<</span></a> "
            s = s + "<a href=""" + base_url + (cp - 1).ToString + end_url + """><span class=""button""><</span></a> "
            's1 = s1 + "<a href=""" + base_url + (cp - 1).ToString + end_url + """><span>上一页</span></a> "

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
            s = s + "<span class=""disabled"">></span> "
            's1 = s1 + "<span class=""disabled"">下一页</span> "
            s = s + "<span class=""disabled"">>|</span> "
        Else
            s = s + "<a href=""" + base_url + (cp + 1).ToString + end_url + """><span class=""button"">></span></a> "
            's1 = s1 + "<a href=""" + base_url + (cp + 1).ToString + end_url + """><span>下一页</span></a> "
            s = s + "<a href=""" + base_url + tp.ToString + end_url + """><span class=""button"">>></span></a> "
        End If
        'ltrPage.Text = s1
        ltrPage2.Text = s

        '提取起运港的中英文名称
        Dim sqlfrom As String
        sqlfrom = ""
        sqlfrom = sqlfrom & "SELECT cityname, citynamech "
        sqlfrom = sqlfrom & "FROM TB_CHINACITY "
        sqlfrom = sqlfrom & "WHERE "
        sqlfrom = sqlfrom & "cityname = '" & Literal5.Text & "' "
        sqlfrom = sqlfrom & "OR citynamech like '%" & Literal5.Text & "%' "
        ds = cn.mdb_ds(sqlfrom, "city")

        Dim city0 As String = ""
        Dim city1 As String = ""
        Dim sqlstarport1 As String = ""
        Dim sqlstarport2 As String = ""

        If ds.Tables("city").Rows.Count > 0 Then
            sqlstarport1 = "and (startportx like '%" & ds.Tables("city").Rows(0)(0).ToString & "%' "
            sqlstarport1 = sqlstarport1 + "or startportx like '%" & ds.Tables("city").Rows(0)(1).ToString & "%') "
            sqlstarport2 = "and (startport like '%" & ds.Tables("city").Rows(0)(0).ToString & "%' "
            sqlstarport2 = sqlstarport2 + "or startport like '%" & ds.Tables("city").Rows(0)(1).ToString & "%') "
            city0 = ds.Tables("city").Rows(0)(0).ToString
        Else
            sqlstarport1 = "and startportx like '%" & Literal5.Text & "%' "
            sqlstarport2 = "and startport like '%" & Literal5.Text & "%' "
            city0 = Literal5.Text
        End If



        sql = ""
        sql = sql & "SELECT TOP 10 * "
        sql = sql & "FROM "
        sql = sql & "("
        sql = sql & "SELECT * ,'" & city0 & "' as startport1 "
        sql = sql & "FROM " & detail_table2 & " "
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
        sql = sql & "FROM " & detail_table2 & " "
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
            sqldetail = sqldetail & "FROM " & detail_table2 & " "
            sqldetail = sqldetail & "WHERE 1=1 "
            If did = "-1" Then
                sqldetail = sqldetail & "AND destport = '" & ddest & "' "
                sqldetail = sqldetail & "AND yunjiaid = " & id & " "
            Else
                sqldetail = sqldetail & "AND " & detail_table2 & ".id= " & did & " "
            End If
            ds = cn.mdb_ds(sqldetail, "search")

            If ds.Tables("search").Rows.Count > 0 Then
                LtrDestport.Text = ds.Tables("search").Rows(0)("destport").ToString.ToUpper
                Ltr20GP.Text = ds.Tables("search").Rows(0)("price20gp").ToString
                Ltr40GP.Text = ds.Tables("search").Rows(0)("price40gp").ToString
                Ltr40HQ.Text = ds.Tables("search").Rows(0)("price40hq").ToString
                Ltr45HQ.Text = ds.Tables("search").Rows(0)("price45hq").ToString
                LtrPlus.Text = ds.Tables("search").Rows(0)("price20gpAppend").ToString
                LtrDistance.Text = ds.Tables("search").Rows(0)("Distance").ToString
                If ds.Tables("search").Rows(0)("Distance").ToString.Trim <> "" Then
                    Label1.Text = ds.Tables("search").Rows(0)("Distance").ToString
                Else
                    Label1.Text = ""
                    Label1.CssClass = "hide"
                End If
                LtrDepartureWkd.Text = ds.Tables("search").Rows(0)("DepartureWkd").ToString
                Ltrshipcompany.Text = ds.Tables("search").Rows(0)("shipcompany").ToString
                If ds.Tables("search").Rows(0)("shipcompany").ToString.Trim <> "" Then
                    Label2.Text = ds.Tables("search").Rows(0)("shipcompany").ToString
                Else
                    Label2.Text = ""
                    Label2.CssClass = "hide"
                End If
            Else

                sqldetail = "SELECT TOP 1 "
                sqldetail = sqldetail & "* "
                sqldetail = sqldetail & "FROM " & detail_table2 & " "
                sqldetail = sqldetail & "WHERE 1=1 "
                If did = "-1" Then
                    sqldetail = sqldetail & "AND destport = '" & ddest & "' "
                    sqldetail = sqldetail & "AND yunjiaid = " & id & " "
                Else
                    sqldetail = sqldetail & "AND yunjiaid = " & id & " "
                End If
                sqldetail = sqldetail & "ORDER BY " & detail_table2 & ".id DESC"
                ds = cn.mdb_ds(sqldetail, "search")
                If ds.Tables("search").Rows.Count > 0 Then
                    LtrDestport.Text = ds.Tables("search").Rows(0)("destport").ToString.ToUpper
                    Ltr20GP.Text = ds.Tables("search").Rows(0)("price20gp").ToString
                    Ltr40GP.Text = ds.Tables("search").Rows(0)("price40gp").ToString
                    Ltr40HQ.Text = ds.Tables("search").Rows(0)("price40hq").ToString
                    Ltr45HQ.Text = ds.Tables("search").Rows(0)("price45hq").ToString
                    LtrPlus.Text = ds.Tables("search").Rows(0)("price20gpAppend").ToString
                    LtrDistance.Text = ds.Tables("search").Rows(0)("Distance").ToString
                    If ds.Tables("search").Rows(0)("Distance").ToString.Trim <> "" Then
                        Label1.Text = ds.Tables("search").Rows(0)("Distance").ToString
                    Else
                        Label1.Text = ""
                        Label1.CssClass = "hide"
                    End If
                    LtrDepartureWkd.Text = ds.Tables("search").Rows(0)("DepartureWkd").ToString
                    Ltrshipcompany.Text = ds.Tables("search").Rows(0)("shipcompany").ToString
                    If ds.Tables("search").Rows(0)("shipcompany").ToString.Trim <> "" Then
                        Label2.Text = ds.Tables("search").Rows(0)("shipcompany").ToString
                    Else
                        Label2.Text = ""
                        Label2.CssClass = "hide"
                    End If
                Else

                End If
            End If
        Else

            Dim sqldetail As String = ""
            sqldetail = sqldetail & "SELECT TOP 1 "
            sqldetail = sqldetail & "* "
            sqldetail = sqldetail & "FROM " & detail_table2 & " "
            sqldetail = sqldetail & "WHERE 1=1 "
            If did = "-1" Then
                sqldetail = sqldetail & "AND destport = '" & ddest & "' "
                sqldetail = sqldetail & "AND yunjiaid = " & id & " "
            Else
                sqldetail = sqldetail & "AND yunjiaid = " & id & " "
            End If
            sqldetail = sqldetail & "ORDER BY " & detail_table2 & ".id DESC"
            'Response.Write(sqldetail)
            ds = cn.mdb_ds(sqldetail, "search")

            If ds.Tables("search").Rows.Count > 0 Then
                'Label21.Text = ds.Tables("search").Rows(0)("infohits").ToString
                LtrDestport.Text = ds.Tables("search").Rows(0)("destport").ToString.ToUpper
                Ltr20GP.Text = ds.Tables("search").Rows(0)("price20gp").ToString
                Ltr40GP.Text = ds.Tables("search").Rows(0)("price40gp").ToString
                Ltr40HQ.Text = ds.Tables("search").Rows(0)("price40hq").ToString
                Ltr45HQ.Text = ds.Tables("search").Rows(0)("price45hq").ToString
                LtrPlus.Text = ds.Tables("search").Rows(0)("price20gpAppend").ToString
                LtrDistance.Text = ds.Tables("search").Rows(0)("Distance").ToString
                If ds.Tables("search").Rows(0)("Distance").ToString.Trim <> "" Then
                    Label1.Text = ds.Tables("search").Rows(0)("Distance").ToString
                Else
                    Label1.Text = ""
                    Label1.CssClass = "hide"
                End If
                LtrDepartureWkd.Text = ds.Tables("search").Rows(0)("DepartureWkd").ToString
                Ltrshipcompany.Text = ds.Tables("search").Rows(0)("shipcompany").ToString
                If ds.Tables("search").Rows(0)("shipcompany").ToString.Trim <> "" Then
                    Label2.Text = ds.Tables("search").Rows(0)("shipcompany").ToString
                Else
                    Label2.Text = ""
                    Label2.CssClass = "hide"
                End If
            Else

            End If

        End If


        If LtrPlus.Text.Trim = "" Then

            LtrPlus.Text = "<span class=""notxt"">暂未提供附加费</span>"
        End If


        Dim sqlsearch As String = ""


        sql = ""
        sql = sql & "SELECT "
        sql = sql & "* "
        sql = sql & "FROM "
        sql = sql & "tb_user "
        sql = sql & "WHERE "
        sql = sql & "userid= " & user
        ds = cn.mdb_ds(sql, "user")

        LtrRealname.Text = "<a href=""/company/" & key(ds.Tables("user").Rows(0)("userid").ToString) & "/""  target=""_blank"" title=""点击查看TA的商铺"">" & ds.Tables("user").Rows(0)("realname").ToString & "</a>"
        Literal8.Text = "<a href=""/company/" & key(ds.Tables("user").Rows(0)("userid").ToString) & "/"" target=""_blank"" title=""点击查看TA的商铺"" style=""color:293B5E"">" & ds.Tables("user").Rows(0)("CompanyName").ToString & "</a>"


        Literal9.Text = ds.Tables("user").Rows(0)("Phone").ToString
        Literal11.Text = ds.Tables("user").Rows(0)("MovePhone").ToString
        Literal12.Text = ds.Tables("user").Rows(0)("UserEmail").ToString
        Literal13.Text = ds.Tables("user").Rows(0)("Address").ToString

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


        Literal25.Text = "<a href=""/member/pm_detail.aspx?pid=1&cid=" & ds.Tables("user").Rows(0)("userid").ToString & """ target=""_blank""><img src=""/images2015/pm.gif""  /></a>"




        'SEO部分，开始
        Dim seotitle As String = "整箱海运运价-环球运费网"
        Dim seokeywords As String = "整箱海运,国际海运,整箱运费"
        Dim seodescription As String = ""

        Dim seocr As String = ""
        If Ltrshipcompany.Text <> "" Then
            seocr = Ltrshipcompany.Text + "船公司,"
        End If




        Dim seocr1 As String = ""
        If Ltrshipcompany.Text <> "" Then
            seocr1 = Ltrshipcompany.Text + "-"
        End If

        Dim seodestport As String = ""
        If LtrDestport.Text <> "" Then
            seodestport = LtrDestport.Text + "运费"
        End If

        If LtrDestport.Text = "" Then
            seotitle = ltrTitle.Text & "-" & Literal5.Text & "起运-" & Literal6.Text & "-" & seotitle
            Literal2.Text = "<meta name=""keywords"" content=""" & seokeywords & "," & Literal5.Text & "运费" & "," & Literal6.Text & "运费" & "," & ds.Tables("user").Rows(0)("CompanyName").ToString & "运费"" />"
            Literal3.Text = "<meta name=""description"" content=""" & Literal5.Text & "起运,航线描述-" & Literal6.Text & ",由" & ds.Tables("user").Rows(0)("CompanyName").ToString & "发布该运费价格.环球运费网提供最新最全面的国际海运整箱运费运价查询与发布"" />"
        Else
            seotitle = seocr1 & ltrTitle.Text & "-" & Literal5.Text & "到" & LtrDestport.Text & "-" & Literal6.Text & "-" & seotitle
            Literal2.Text = "<meta name=""keywords"" content=""" & seokeywords & "," & Literal5.Text & "运费" & "," & Literal6.Text & "运费" & "," & seodestport & "," & ds.Tables("user").Rows(0)("CompanyName").ToString & "运费"" />"
            Literal3.Text = "<meta name=""description"" content=""" & seocr & Literal5.Text & "到" & LtrDestport.Text & ",航线描述-" & Literal6.Text & ",由" & ds.Tables("user").Rows(0)("CompanyName").ToString & "发布该运费价格.环球运费网提供最新最全面的国际海运整箱运费运价查询与发布"" />"
        End If
        Literal1.Text = "<title>" & seotitle & "</title>"

        'SEO部分，结束



        sql = ""


        Dim AllinFreight1 As New AllinFreight()
        AllinFreight1.SetFreightViewrecord2("8", ck.CheckNumber(ss.Decrypto(Request.QueryString("yid").ToString)), ck.CheckInput(Request.QueryString("ydid").ToString), ck.CheckInput(user))





        Literal20.Text = "<a href=""/fcl/list-" + Literal5.Text + "-" + LtrDestport.Text + "--0-0-0-----1.html"" target=""_blank"">查看全部 " + Literal5.Text + " 至 " + LtrDestport.Text + " 的运价 >></a>"

        If detail_table2 = "TB_YunJiaInfo_bak" Then
            Literal21.Text = "您查看的该条运价的历史快照，<a href=""/fcl/list-" + Literal5.Text + "-" + LtrDestport.Text + "--0-0-0-----1.html"" target=""_blank"">更多同航线运价 >></a>"
        End If





    End Sub



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








End Class
