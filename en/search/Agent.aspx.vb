
Partial Class en_search_fcl

    Inherits System.Web.UI.Page
    Public strwca As String = "0"
    Public strapln As String = "0"
    Public strcgln As String = "0"
    Public strigln As String = "0"
    Public strwcap As String = "0"
    Public strwcapn As String = "0"
    Public strdgla As String = "0"
    Public strpla As String = "0"
    Public strpub As String = "0"
    Public strrm As String = "0"
    Public strpp As String = "0"
    Public strorder As String = ""
    Public strCountry As String = ""
    Public strcity As String = ""
    Public strletter As String = ""
    Public strkeyWord As String = ""
    Public p As String = ""
    Public strsearch As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        searchby.Attributes.Add("onChange", "UpdateFilter(this.value);")
        wca.Attributes.Add("onclick", "ChkAll()")
        apln.Attributes.Add("onclick", "ChkAll()")
        cgln.Attributes.Add("onclick", "ChkAll()")
        igln.Attributes.Add("onclick", "ChkAll()")
        wcap.Attributes.Add("onclick", "ChkAll()")
        wcapn.Attributes.Add("onclick", "ChkAll()")
        dgla.Attributes.Add("onclick", "ChkAll()")
        pla.Attributes.Add("onclick", "ChkAll()")
        pub.Attributes.Add("onclick", "ChkAll()")
        rm.Attributes.Add("onclick", "ChkAll()")
        pp.Attributes.Add("onclick", "ChkAll()")


        ltrTotalSurcharge.Text = "·<a href=""/baf/"" target=""_blank"">" & Now.Month.ToString & "月各大船公司最新BAF/CAF</a><br/>"
        ltrTotalSurcharge.Text += "·<a href=""/thc/"" target=""_blank"">" & Now.Month.ToString & "月各大船公司最新THC</a><br/>"
        ltrTotalSurcharge.Text += "·<a href=""/orc/"" target=""_blank"">" & Now.Month.ToString & "月最新ORC</a><br/>"

        Dim cn As New data_conn




        'Response.Write(Request.Url.ToString)
        If Not Page.IsPostBack Then
            statecity.Items.Add(New ListItem("All Countries", ""))
            Dim ds As Data.DataSet = cn.mdb_ds("select * from TB_Agent_Country", "Country")
            For i As Integer = 0 To ds.Tables("Country").Rows.Count - 1
                statecity.Items.Add(New ListItem(ds.Tables("Country").Rows(i)("country").ToString, ds.Tables("Country").Rows(i)("id").ToString))
            Next
            If Request.QueryString("wca") Is Nothing And Request.QueryString("order") Is Nothing And Request.QueryString("Country") Is Nothing And Request.QueryString("city") Is Nothing And Request.QueryString("letter") Is Nothing And Request.QueryString("keyWord") Is Nothing And Request.QueryString("p") Is Nothing Then
                LoadRecord("1")
            Else
                '提取来自网页参数的搜索条件
                If Not Request.QueryString("wca") Is Nothing Then
                    strwca = Request.QueryString("wca").ToString().Substring(0, 1)
                    strapln = Request.QueryString("wca").ToString().Substring(1, 1)
                    strcgln = Request.QueryString("wca").ToString().Substring(2, 1)
                    strigln = Request.QueryString("wca").ToString().Substring(3, 1)
                    strwcap = Request.QueryString("wca").ToString().Substring(4, 1)
                    strwcapn = Request.QueryString("wca").ToString().Substring(5, 1)
                    strdgla = Request.QueryString("wca").ToString().Substring(6, 1)
                    strpla = Request.QueryString("wca").ToString().Substring(7, 1)
                    strpub = Request.QueryString("wca").ToString().Substring(8, 1)
                    strrm = Request.QueryString("wca").ToString().Substring(9, 1)
                    strpp = Request.QueryString("wca").ToString().Substring(10, 1)
                End If
                If Not Request.QueryString("order") Is Nothing Then
                    strorder = Request.QueryString("order").ToString()
                End If
                If Not Request.QueryString("Country") Is Nothing Then
                    strCountry = Request.QueryString("Country").ToString()
                End If
                If Not Request.QueryString("city") Is Nothing Then
                    strcity = Request.QueryString("city").ToString()
                End If
                If Not Request.QueryString("letter") Is Nothing Then
                    strletter = Request.QueryString("letter").ToString()
                End If
                If Not Request.QueryString("keyWord") Is Nothing Then
                    strkeyWord = Request.QueryString("keyWord").ToString()
                End If
                If Not Request.QueryString("p") Is Nothing Then
                    p = Request.QueryString("p").ToString()
                End If
                If Not Request.QueryString("search") Is Nothing Then
                    strsearch = Request.QueryString("search").ToString()
                End If


                Hidstrwca.Value = strwca
                Hidapln.Value = strapln
                Hidcgln.Value = strcgln
                Hidigln.Value = strigln
                Hidwcap.Value = strwcap
                Hidwcapn.Value = strwcapn
                Hiddgla.Value = strdgla
                Hidpla.Value = strpla
                Hidpub.Value = strpub
                Hidrm.Value = strrm
                Hidpp.Value = strpp
                Hidorder.Value = strorder
                HidCountry.Value = strCountry
                Hidcity.Value = strcity
                Hidletter.Value = strletter
                HidkeyWord.Value = strkeyWord
                Hidsearch.Value = strsearch

                wca.Checked = IntToBoole(strwca)
                apln.Checked = IntToBoole(strapln)
                cgln.Checked = IntToBoole(strcgln)
                igln.Checked = IntToBoole(strigln)
                wcap.Checked = IntToBoole(strwcap)
                wcapn.Checked = IntToBoole(strwcapn)
                dgla.Checked = IntToBoole(strdgla)
                pla.Checked = IntToBoole(strpla)
                pub.Checked = IntToBoole(strpub)
                rm.Checked = IntToBoole(strrm)
                pp.Checked = IntToBoole(strpp)
                orderby.SelectedValue = strorder
                searchby.SelectedValue = strsearch

                If strsearch = "city" Then
                    trstatecity.Style.Value = ""
                    Letter.Style.Value = "display:none"
                    statecity.SelectedValue = strCountry

                    If statecity.SelectedValue <> "" Then
                        Dim dscity As Data.DataSet = cn.mdb_ds("select * from TB_Agent_City where CountryID=" + statecity.SelectedValue, "City")
                        city.Items.Clear()
                        city.Items.Add(New ListItem("All Cities", ""))
                        For i As Integer = 0 To dscity.Tables("City").Rows.Count - 1
                            city.Items.Add(New ListItem(dscity.Tables("City").Rows(i)("City").ToString, dscity.Tables("City").Rows(i)("id").ToString))
                        Next
                    Else
                        city.Items.Clear()
                        city.Items.Add(New ListItem("All Cities", ""))
                    End If

                    

                    city.SelectedValue = strcity
                Else
                    trstatecity.Style.Value = "display:none"
                    Letter.Style.Value = ""
                    ddlLetter.SelectedValue = strletter
                End If


                keyword.Value = strkeyWord

                LoadRecord(p)
            End If
        End If



        'If sp <> "" Then
        '    '写入并读取最近浏览过的运价列表
        '    Dim tempsearch() As String
        '    Dim tempsearch_string As String

        '    If Not Request.Cookies("tempsearch") Is Nothing Then
        '        tempsearch_string = Request.Cookies("tempsearch").Value
        '        tempsearch = tempsearch_string.Split("|")
        '    Else
        '        tempsearch_string = ""
        '        tempsearch = tempsearch_string.Split("|")
        '    End If

        '    If tempsearch_string.IndexOf(Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html"" target=""_blank"">[整箱] " & sp & "-" & dp & "</a></nobr></div></li>")) = -1 Then
        '        If tempsearch.Length < 6 Then
        '            tempsearch_string = Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html"" target=""_blank"">[整箱] " & sp & "-" & dp & "</a></nobr></div></li>") & "|" & tempsearch_string
        '        Else
        '            tempsearch_string = Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html"" target=""_blank"">[整箱] " & sp & "-" & dp & "</a></nobr></div></li>")
        '            For i As Integer = 0 To tempsearch.Length - 2
        '                tempsearch_string = tempsearch_string & "|" & tempsearch(i)
        '            Next
        '        End If
        '    End If
        '    Response.Cookies("tempsearch").Value = tempsearch_string
        '    Response.Cookies("tempsearch").Expires = DateTime.Now.AddDays(365)
        'End If




        '定义所有输入框按回车跳到下一格
        'txtLine.Attributes.Add("onkeydown", "KeyDown(event);")
        'txtStartport.Attributes.Add("onkeyup", "autowords(this,event);")
        'txtStartport.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")
        'txtDestport.Attributes.Add("onkeyup", "autowords(this,event);")
        'txtDestport.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")
        'txtCarrier.Attributes.Add("onkeyup", "autowords(this,event);")
        'txtCarrier.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")


    End Sub

    '载入列表信息
    Sub LoadRecord(ByVal page As String)
        Dim item As Integer
        item = CInt(page - 1) * 15
        Dim cn As New data_conn



        Dim sql As String


        sql = "select top 15 "
        sql = sql & "id,country,city,CompanyName,ifHead_Office,Partner_Pay,Risk_Management,WCA,APLN,CGLN,IGLN,WCAPN,DGLA "
        sql = sql & "FROM (SELECT "
        sql = sql & "TB_Agent.id,country,TB_Agent_City.city,CompanyName,ifHead_Office,Partner_Pay,Risk_Management,WCA,APLN,CGLN,IGLN,WCAPN,DGLA "
        sql = sql & "FROM "
        sql = sql & "TB_Agent,TB_Agent_Company,TB_Agent_City,TB_Agent_Country "
        sql = sql & "WHERE "
        sql = sql & "TB_Agent_Company.id = TB_Agent.CompanyID and TB_Agent.City=TB_Agent_City.id and TB_Agent_City.CountryID=TB_Agent_Country.id "


        If strwca = 1 Then
            sql = sql & "and TB_Agent.WCA = 1 "
        End If

        If strapln = 1 Then
            sql = sql & "and TB_Agent.APLN = 1 "
        End If

        If strcgln = 1 Then
            sql = sql & "and TB_Agent.CGLN = 1 "
        End If

        If strigln = 1 Then
            sql = sql & "and TB_Agent.IGLN = 1 "
        End If

        If strwcap = 1 Then
            sql = sql & "and TB_Agent.Specialty_Networks = 1 "
        End If

        If strwcapn = 1 Then
            sql = sql & "and TB_Agent.WCAPN = 1 "
        End If
        If strdgla = 1 Then
            sql = sql & "and TB_Agent.DGLA = 1 "
        End If

        If strpla = 1 Then
            sql = sql & "and TB_Agent.Perishables = 1 "
        End If

        If strpub = 1 Then
            sql = sql & "and TB_Agent.Publishers = 1 "
        End If
        If strrm = 1 Then
            sql = sql & "and TB_Agent.Risk_Management = 1 "
        End If

        If strpp = 1 Then
            sql = sql & "and TB_Agent.Partner_Pay = 1 "
        End If

        If strCountry <> "" Then
            sql = sql & "and TB_Agent_City.CountryID = '" + strCountry + "' "
        End If
        If strcity <> "" Then
            sql = sql & "and TB_Agent.City = '" + strcity + "' "
        End If

        If strletter <> "" Then
            sql = sql & "and (CompanyName like '" + strletter + "%' or CompanyName like '" + strletter.ToLower + "%') "
        End If

        If strkeyWord <> "" Then
            sql = sql & "and CompanyName like '%" + strkeyWord + "%'"
        End If

        sql = sql & ") AS T "
        sql = sql & "WHERE id NOT IN "
        sql = sql & "(SELECT TOP " & item.ToString & " TB_Agent.id "
        sql = sql & "FROM "
        sql = sql & "TB_Agent,TB_Agent_Company,TB_Agent_City,TB_Agent_Country "
        sql = sql & "WHERE "
        sql = sql & "TB_Agent_Company.id = TB_Agent.CompanyID and TB_Agent.City=TB_Agent_City.id and TB_Agent_City.CountryID=TB_Agent_Country.id "
        If strwca = 1 Then
            sql = sql & "and TB_Agent.WCA = 1 "
        End If

        If strapln = 1 Then
            sql = sql & "and TB_Agent.APLN = 1 "
        End If

        If strcgln = 1 Then
            sql = sql & "and TB_Agent.CGLN = 1 "
        End If

        If strigln = 1 Then
            sql = sql & "and TB_Agent.IGLN = 1 "
        End If

        If strwcap = 1 Then
            sql = sql & "and TB_Agent.Specialty_Networks = 1 "
        End If

        If strwcapn = 1 Then
            sql = sql & "and TB_Agent.WCAPN = 1 "
        End If
        If strdgla = 1 Then
            sql = sql & "and TB_Agent.DGLA = 1 "
        End If

        If strpla = 1 Then
            sql = sql & "and TB_Agent.Perishables = 1 "
        End If

        If strpub = 1 Then
            sql = sql & "and TB_Agent.Publishers = 1 "
        End If
        If strrm = 1 Then
            sql = sql & "and TB_Agent.Risk_Management = 1 "
        End If

        If strpp = 1 Then
            sql = sql & "and TB_Agent.Partner_Pay = 1 "
        End If

        If strCountry <> "" Then
            sql = sql & "and TB_Agent_City.CountryID = '" + strCountry + "' "
        End If
        If strcity <> "" Then
            sql = sql & "and TB_Agent.City = '" + strcity + "' "
        End If

        If strletter <> "" Then
            sql = sql & "and (CompanyName like '" + strletter + "%' or CompanyName like '" + strletter.ToLower + "%') "
        End If

        If strkeyWord <> "" Then
            sql = sql & "and CompanyName like '%" + strkeyWord + "%'"
        End If
        sql = sql & "ORDER BY TB_Agent.id DESC "
        sql = sql & ") "
        sql = sql & "ORDER BY id DESC "


        Dim ds As Data.DataSet = cn.mdb_ds(sql, "agent")
        Rptfcl.DataSource = ds.Tables("agent").DefaultView
        Rptfcl.DataBind()
        LoadTotalCount()
    End Sub

    '计算页数
    Sub LoadTotalCount()

        Dim ck As New check
        '取搜索条件，搜索条件保存在隐藏的label内

        If strwca = 1 Then
            hidtxtWeb.Text += "WCA  "
        End If

        If strapln = 1 Then
            hidtxtWeb.Text += "APLN  "
        End If

        If strcgln = 1 Then
            hidtxtWeb.Text += "CGLN  "
        End If

        If strigln = 1 Then
            hidtxtWeb.Text += "IGLN  "
        End If

        If strwcap = 1 Then
            hidtxtWeb.Text += "Specialty_Networks  "
        End If

        If strwcapn = 1 Then
            hidtxtWeb.Text += "WCAPN  "
        End If

        If strdgla = 1 Then
            hidtxtWeb.Text += "DGLA  "
        End If

        If strpla = 1 Then
            hidtxtWeb.Text += "Perishables  "
        End If

        If strpub = 1 Then
            hidtxtWeb.Text += "Publishers  "
        End If
        If strrm = 1 Then
            hidtxtWeb.Text += "Risk_Management  "
        End If

        If strpp = 1 Then
            hidtxtWeb.Text += "Partner_Pay  "
        End If

        If searchby.SelectedValue = "city" Then
            hidtxtcondition.Text = "Location  "
            hidtxtcondition.Text += statecity.SelectedItem.Text + "  "
            hidtxtcondition.Text += city.SelectedItem.Text
        ElseIf searchby.SelectedValue = "name" Then
            hidtxtcondition.Text = "Company Name"
            hidtxtcondition.Text += ddlLetter.SelectedItem.Text
        Else
            hidtxtcondition.Text = ""
        End If

        hidtxtkeyword.Text = keyword.Value



        '访问数据库，统计记录条数
        Dim cn As New data_conn
        Dim ds As New Data.DataSet
        Dim sql As String = ""







        sql = sql & "SELECT count(*) "
        sql = sql & "FROM "
        sql = sql & "TB_Agent,TB_Agent_Company,TB_Agent_City,TB_Agent_Country "
        sql = sql & "WHERE "
        sql = sql & "TB_Agent_Company.id = TB_Agent.CompanyID and TB_Agent.City=TB_Agent_City.id and TB_Agent_City.CountryID=TB_Agent_Country.id "
        If strwca = 1 Then
            sql = sql & "and TB_Agent.WCA = 1 "
        End If

        If strapln = 1 Then
            sql = sql & "and TB_Agent.APLN = 1 "
        End If

        If strcgln = 1 Then
            sql = sql & "and TB_Agent.CGLN = 1 "
        End If

        If strigln = 1 Then
            sql = sql & "and TB_Agent.IGLN = 1 "
        End If

        If strwcap = 1 Then
            sql = sql & "and TB_Agent.Specialty_Networks = 1 "
        End If

        If strwcapn = 1 Then
            sql = sql & "and TB_Agent.WCAPN = 1 "
        End If
        If strdgla = 1 Then
            sql = sql & "and TB_Agent.DGLA = 1 "
        End If

        If strpla = 1 Then
            sql = sql & "and TB_Agent.Perishables = 1 "
        End If

        If strpub = 1 Then
            sql = sql & "and TB_Agent.Publishers = 1 "
        End If
        If strrm = 1 Then
            sql = sql & "and TB_Agent.Risk_Management = 1 "
        End If

        If strpp = 1 Then
            sql = sql & "and TB_Agent.Partner_Pay = 1 "
        End If

        If strCountry <> "" Then
            sql = sql & "and TB_Agent_City.CountryID = '" + strCountry + "' "
        End If
        If strcity <> "" Then
            sql = sql & "and TB_Agent.City = '" + strcity + "' "
        End If

        If strletter <> "" Then
            sql = sql & "and (CompanyName like '" + strletter + "%' or CompanyName like '" + strletter.ToLower + "%') "
        End If

        If strkeyWord <> "" Then
            sql = sql & "and CompanyName like '%" + strkeyWord + "%'"
        End If


        ds = cn.mdb_ds(sql, "count")




        '计算出页数
        Dim item As Integer
        item = ds.Tables("count").Rows(0)(0)


        Dim page As Integer
        If item Mod 15 > 0 Or item = 0 Then
            page = item \ 15 + 1
        Else
            page = item \ 15
        End If


        '以下为页码控制栏相关
        Dim s As String = ""
        Dim cp As Integer = 1
        If Not Request.QueryString("p") Is Nothing Then
            cp = CInt(Request.QueryString("p").ToString)
        End If
        Dim tp As Integer = page

        If tp >= 100 Then
            tp = 100
        End If

        Dim base_url As String = "list-" & strwca & strapln & strcgln & strigln & strwcap & strwcapn & strdgla & strpla & strpub & strrm & strpp & "-" & strorder & "-" & strsearch & "-" & strCountry & "-" & strcity & "-" & strletter & "-" & strkeyWord & "-"

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
            s = s + "<span class=""disabled"">下一页</span> "
            s = s + "<span class=""disabled""><img src='/images/fcl/jt7.gif' width='9' height='9' border=0 /></span> "
        Else
            s = s + "<a href=""" + base_url + (cp + 1).ToString + end_url + """><span>下一页</span></a> "
            s = s + "<a href=""" + base_url + tp.ToString + end_url + """><span><img src='/images/fcl/jt7.gif' width='9' height='9' border=0 /></span></a> "
        End If



        Label8.Text = s
        '以上为页码控制栏相关

        ''最后改写总页码标签
        hidTotalItem.Text = item.ToString
        lblTotalPage.Text = tp.ToString
        hidTotalPage.Value = tp.ToString
        lblCurrentPage.Text = cp.ToString
        txtPageJump.Value = cp.ToString



    End Sub


    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub

    Protected Sub SaveSearchWords(ByVal line As String, ByVal startport As String, ByVal destport As String, ByVal success As Integer)
        Try
            Dim ck As New check
            Dim rqst As String = ""
            If Request.ServerVariables("HTTP_REFERER") Is Nothing Then
                rqst = ""
            Else
                rqst = Request.ServerVariables("HTTP_REFERER").ToString
            End If

            Dim address As String = Page.Request.UserHostAddress
            Dim userid As String = ""
            If Request.Cookies("user_id") Is Nothing Then
                userid = "0"
            Else
                If Request.Cookies("user_id").Value = "" Then
                    userid = "0"
                Else
                    userid = Request.Cookies("user_id").Value.ToString
                End If
            End If

            Dim cn As New data_conn
            Dim sql As String = ""
            sql = sql & "INSERT INTO "
            sql = sql & "TB_SEA_SEARCHWORDS "
            sql = sql & "("
            sql = sql & "LINE, "
            sql = sql & "STARTPORT, "
            sql = sql & "DESTPORT, "
            sql = sql & "SUCCESS,"
            sql = sql & "SUSERID,"
            sql = sql & "SUSERIP,"
            sql = sql & "STYPE,"
            sql = sql & "STIME "
            sql = sql & ")"
            sql = sql & "VALUES "
            sql = sql & "("
            sql = sql & "'" & ck.CheckInput(line) & "', "
            sql = sql & "'" & ck.CheckInput(startport) & "', "
            sql = sql & "'" & ck.CheckInput(destport) & "', "
            sql = sql & ck.CheckInput(success) & ", "
            sql = sql & ck.CheckInput(userid) & ", "
            sql = sql & "'" & ck.CheckInput(address) & "', "
            sql = sql & "8, "
            sql = sql & "'" & Now.ToString & "' "
            sql = sql & ")"
            cn.mdb_exe(sql)
        Catch ex As Exception

        End Try


    End Sub '保存搜索条件

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim linkletter, linkcity, linkCountry As String
        If searchby.SelectedValue = "city" Then
            linkCountry = statecity.SelectedValue
            linkcity = city.SelectedValue
            linkletter = ""
            Response.Write("trstatecity")
        ElseIf searchby.SelectedValue = "name" Then
            linkCountry = ""
            linkcity = ""
            linkletter = ddlLetter.SelectedValue
            Response.Write("lerter")
        Else
            linkCountry = ""
            linkcity = ""
            linkletter = ddlLetter.SelectedValue
        End If


        Response.Redirect("/en/agent/list-" & BooleToInt(wca.Checked) & BooleToInt(apln.Checked) & BooleToInt(cgln.Checked) & BooleToInt(igln.Checked) & BooleToInt(wcap.Checked) & BooleToInt(wcapn.Checked) & BooleToInt(dgla.Checked) & BooleToInt(pla.Checked) & BooleToInt(pub.Checked) & BooleToInt(rm.Checked) & BooleToInt(pp.Checked) & "-" & orderby.SelectedValue & "-" & searchby.SelectedValue & "-" & linkCountry & "-" & linkcity & "-" & linkletter & "-" & keyword.Value & "-1.html")
    End Sub

    Public Function key(ByVal es As String) As String
        Dim s As New SymmetricMethod
        Return s.Encrypto(es)
    End Function

    Public Function GetFreightCompany(ByVal s1 As String, ByVal s2 As String, ByVal d As String) As Data.DataSet
        Dim cn As New data_conn
        Dim ds As New Data.DataSet
        Dim sql As String
        sql = ""
        sql = sql + "SELECT TOP 6 TB_YunJia.UserID, TB_User.CompanyName, COUNT(TB_YunJia.UserID) AS c, dbo.get_yunjiaid(MAX(TB_YunJiaInfo.ID)) AS yid, MAX(TB_YunJiaInfo.ID) AS ydid "
        sql = sql + "FROM TB_YunJia INNER JOIN TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID INNER JOIN TB_User ON TB_YunJia.UserID = TB_User.UserID "
        sql = sql + "WHERE ((TB_YunJia.StartPort LIKE '%" & s1 & "%') OR (TB_YunJia.StartPort LIKE '%" & s2 & "%')) AND (TB_YunJiaInfo.DestPort LIKE '%" & d & "%') AND (TB_YunJia.yunjialeixing = 8) AND (TB_YunJia.enddate >= { fn NOW() }) AND TB_YunJia.USERID <> 44"
        sql = sql + "GROUP BY TB_YunJia.UserID, TB_User.CompanyName "
        sql = sql + "ORDER BY c DESC "

        ds = cn.mdb_ds(sql, "freight")
        'Response.Write(sql)
        Return ds
    End Function

    Protected Sub btnPageJump_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPageJump.ServerClick
        Dim ck As New check
        Dim jumppage As String
        jumppage = ck.CheckNumber(txtPageJump.Value)

        If IsNumeric(txtPageJump.Value) Then

            If CInt(txtPageJump.Value.ToString) < 1 Then
                'Response.Redirect("/en/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html")
            Else
                If CInt(txtPageJump.Value.ToString) > CInt(hidTotalPage.Value) Then
                    'Response.Redirect("/en/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----" & lblTotalPage.Text & ".html")
                Else
                    'Response.Redirect("/en/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----" & txtPageJump.Value & ".html")
                End If
            End If
        End If

    End Sub



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

        If isCut = True Then
            Return sb.ToString() & ".."
        Else
            Return sb.ToString()
        End If

    End Function


    Public Function GetQueryString(ByVal WCA As String, ByVal APLN As String, ByVal CGLN As String, ByVal IGLN As String, ByVal WCAPN As String, ByVal DGLA As String) As String
        Dim strReturn As String = "("

        If WCA = 1 Then
            strReturn += "WCA/"
        End If

        If APLN = 1 Then
            strReturn += "APLN/"
        End If

        If CGLN = 1 Then
            strReturn += "CGLN/"
        End If

        If IGLN = 1 Then
            strReturn += "IGLN/"
        End If

        If WCAPN = 1 Then
            strReturn += "WCAPN/"
        End If

        If DGLA = 1 Then
            strReturn += "DGLA/"
        End If

        strReturn = strReturn.Substring(0, strReturn.Length - 1)
        strReturn += ")"

        Return strReturn
    End Function



    Protected Sub statecity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles statecity.SelectedIndexChanged
        trstatecity.Style.Value = ""
        Letter.Style.Value = "display:none"
        If statecity.SelectedValue <> "" Then
            Dim cn As New data_conn
            Dim ds As Data.DataSet = cn.mdb_ds("select * from TB_Agent_City where CountryID=" + statecity.SelectedValue, "City")
            city.Items.Clear()
            city.Items.Add(New ListItem("All Cities", ""))
            For i As Integer = 0 To ds.Tables("City").Rows.Count - 1
                city.Items.Add(New ListItem(ds.Tables("City").Rows(i)("City").ToString, ds.Tables("City").Rows(i)("id").ToString))
            Next
        Else
            city.Items.Clear()
            city.Items.Add(New ListItem("All Cities", ""))
        End If
        
    End Sub

    Public Function IntToBoole(ByVal strInt As String) As Boolean
        If strInt = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function BooleToInt(ByVal bol As Boolean) As String
        If bol Then
            Return "1"
        Else
            Return "0"
        End If
    End Function


End Class
