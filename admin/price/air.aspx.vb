Imports System.Data
Partial Class search_air
    Inherits System.Web.UI.Page
    '起运港参数
    Public sp As String = ""
    '目的港参数
    Public dp As String = ""
    '船公司参数
    Public cr As String = ""
    '航线参数
    Public l As String = "0"
    '页码参数
    Public p As String = ""
    '排序参数
    Public order As String = "0"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Write(Request.Url.ToString)
        If Not Page.IsPostBack Then
            If Not Request.QueryString("sp") Is Nothing Then
                '提取来自网页参数的搜索条件
                sp = Request.QueryString("sp").ToString
                dp = Request.QueryString("dp").ToString
                cr = Request.QueryString("cr").ToString
                l = Request.QueryString("l").ToString
                p = Request.QueryString("p").ToString
                order = Request.QueryString("order").ToString

                '起运港、目的港、航线搜索框，提取参数内容
                txtStartport.Text = sp
                txtDestport.Text = dp

                '搜索条件保存在label控件内
                hidTxtStartport.Text = sp
                hidTxtDestport.Text = dp

                '航线下拉框，提取参数内容
                If txtDestport.Text = "" Then
                    txtLine.SelectedIndex = l
                    hidTxtLine.Text = txtLine.SelectedValue
                End If

                If sp = "" Then
                    Label10.Visible = False
                Else
                    Label10.Visible = True
                End If

                If dp = "" Then
                    Label11.Visible = False
                Else
                    Label11.Visible = True
                End If


                If l = "0" Then
                    Label12.Visible = False
                Else
                    Label12.Visible = True
                End If

                '开始查询符合搜索条件的记录
                LoadRecord(p)
            Else
                '无搜索条件，查询所有记录
                Label10.Visible = False
                Label11.Visible = False
                Label12.Visible = False
                LoadRecord("1")
            End If
        End If


        '生成筛选链接，包括起运港、航线、船公司的筛选
        lblLineHot.Text = ""
        lblStartportHot.Text = ""
        'lblCarrierHot.Text = ""

        Dim StartportHotArray(15) As String

        StartportHotArray(0) = "上海,shanghai"
        StartportHotArray(1) = "广州,guangzhou"
        StartportHotArray(2) = "香港,hongkong"
        StartportHotArray(3) = "深圳,shenzhen"
        StartportHotArray(4) = "北京,beijing"
        StartportHotArray(5) = "厦门,xiamen"
        StartportHotArray(6) = "青岛,qingdao"
        StartportHotArray(7) = "珠海,zhuhai"
        StartportHotArray(8) = "大连,dalian"
        StartportHotArray(8) = "长沙,changsha"
        StartportHotArray(9) = "武汉,wuhan"
        StartportHotArray(10) = "成都,chengdu"
        StartportHotArray(11) = "重庆,chongqing"
        StartportHotArray(12) = "杭州,hangzhou"
        StartportHotArray(13) = "宁波,ningbo"
        StartportHotArray(14) = "大连,dalian"

        For i As Integer = 0 To 14
            If StartportHotArray(i).IndexOf(sp) <> -1 And sp <> "" Then
                lblStartportHot.Text = lblStartportHot.Text & "&nbsp;&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & StartportHotArray(i).Split(",")(0) & "</b>"
            Else
                lblStartportHot.Text = lblStartportHot.Text & "&nbsp;&nbsp;&nbsp;" & "<a href = ""/air/list-" & StartportHotArray(i).Split(",")(1) & "---" & l & "-0-0-----1.html"">" & StartportHotArray(i).Split(",")(0) & "</a>"
            End If
        Next

        If sp = "" Then
            lblStartportHot.Text = "&nbsp;&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & lblStartportHot.Text
        Else
            lblStartportHot.Text = "&nbsp;&nbsp;&nbsp;" & "<a href = ""/air/list--" & dp & "--" & l & "-0-0-----1.html"">全部</a>" & lblStartportHot.Text
        End If


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
            If LineHotArray(i).IndexOf(l) <> -1 And l <> "" Then
                lblLineHot.Text = lblLineHot.Text & "&nbsp;&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & LineHotArray(i).Split(",")(0) & "</b>"
            Else
                lblLineHot.Text = lblLineHot.Text & "&nbsp;&nbsp;&nbsp;" & "<a href = ""/air/list-" & sp & "---" & LineHotArray(i).Split(",")(1) & "-0-0-----1.html"">" & LineHotArray(i).Split(",")(0) & "</a>"
            End If
        Next

        If sp <> "" Then
            '写入并读取最近浏览过的运价列表
            Dim tempsearch() As String
            Dim tempsearch_string As String

            If Not Request.Cookies("tempsearch") Is Nothing Then
                tempsearch_string = Request.Cookies("tempsearch").Value
                tempsearch = tempsearch_string.Split("|")
            Else
                tempsearch_string = ""
                tempsearch = tempsearch_string.Split("|")
            End If

            If tempsearch_string.IndexOf(Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/air/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "--" & txtLine.SelectedIndex.ToString & "-0-0-----1.html"" target=""_blank"">[空运] " & sp & "-" & dp & "</a></nobr></div></li>")) = -1 Then
                If tempsearch.Length < 6 Then
                    tempsearch_string = Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/air/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "--" & txtLine.SelectedIndex.ToString & "-0-0-----1.html"" target=""_blank"">[空运] " & sp & "-" & dp & "</a></nobr></div></li>") & "|" & tempsearch_string
                Else
                    tempsearch_string = Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/air/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "--" & txtLine.SelectedIndex.ToString & "-0-0-----1.html"" target=""_blank"">[空运] " & sp & "-" & dp & "</a></nobr></div></li>")
                    For i As Integer = 0 To tempsearch.Length - 2
                        tempsearch_string = tempsearch_string & "|" & tempsearch(i)
                    Next
                End If
            End If
            Response.Cookies("tempsearch").Value = tempsearch_string
            Response.Cookies("tempsearch").Expires = DateTime.Now.AddDays(365)
        End If

        'SEO部分，开始
        Dim seo_sp As String = sp
        Dim seo_sp_array(15) As String

        seo_sp_array(0) = "上海,shanghai"
        seo_sp_array(1) = "广州,guangzhou"
        seo_sp_array(2) = "香港,hongkong"
        seo_sp_array(3) = "深圳,shenzhen"
        seo_sp_array(4) = "北京,beijing"
        seo_sp_array(5) = "厦门,xiamen"
        seo_sp_array(6) = "青岛,qingdao"
        seo_sp_array(7) = "珠海,zhuhai"
        seo_sp_array(8) = "大连,dalian"
        seo_sp_array(8) = "长沙,changsha"
        seo_sp_array(9) = "武汉,wuhan"
        seo_sp_array(10) = "成都,chengdu"
        seo_sp_array(11) = "重庆,chongqing"
        seo_sp_array(12) = "杭州,hangzhou"
        seo_sp_array(13) = "南京,nanjing'"
        seo_sp_array(14) = "南宁,nanning"

        For k As Integer = 0 To 14
            If seo_sp_array(k).IndexOf(sp) <> -1 And sp <> "" Then
                seo_sp = seo_sp_array(k).Split(",")(0)
            End If
        Next


        Dim seo_dp As String = ""
        Dim seo_dp1 As String = ""
        Dim seo_dp2 As String = ""
        Dim seo_dp3 As String = ""
        If dp <> "" Then
            seo_dp = "到" + dp
            seo_dp1 = "至" + dp
            seo_dp2 = dp
            seo_dp3 = "-" + dp
        End If

        Dim seo_l As String = ""
        Dim lkeywordsarray(8) As String
        lkeywordsarray(0) = "全部,0"
        lkeywordsarray(1) = "北美线,1"
        lkeywordsarray(2) = "欧洲线,2"
        lkeywordsarray(3) = "南美线,3"
        lkeywordsarray(4) = "亚洲线,4"
        lkeywordsarray(5) = "非洲线,5"
        lkeywordsarray(6) = "澳洲线,6"
        lkeywordsarray(7) = "国内航线,7"

        If l <> "0" Then
            seo_l = lkeywordsarray(CInt(l)).Split(",")(0)
        End If

        Dim seo_keywords As String = ""

        seo_keywords = "空运 运费 运价"

        If sp <> "" Then
            seo_keywords = seo_keywords & " " & seo_sp
        End If

        If dp <> "" Then
            seo_keywords = seo_keywords & " " & dp
        End If

        If l <> 0 Then
            seo_keywords = seo_keywords & " " & seo_l
        End If


        If sp = "" And dp = "" And l = "0" Then

        Else
            Literal1.Text = "<title>" & seo_sp & seo_dp & seo_l & "空运运费发布," & seo_sp & seo_dp1 & seo_l & "空运价格," & seo_sp & seo_dp2 & seo_l & "空运代理报价及订舱服务-环球运费网" & "</title>"
            Literal2.Text = "<meta name=""keywords"" content=""" & seo_keywords & """ />"
            Literal3.Text = "<meta name=""description"" content=""" & seo_sp & seo_dp & seo_l & "空运价格专栏," & seo_sp & seo_dp1 & seo_l & "空运最新空运运费," & seo_sp & seo_dp2 & seo_l & "空运运价查询,环球运费网" & """ />"
        End If


        'SEO部分，结束

        '快速转到第X页的功能的js函数
        txtPageJump.Attributes.Add("onkeydown", "PageJump();")

        '定义所有输入框按回车跳到下一格
        txtLine.Attributes.Add("onkeydown", "KeyDown(event);")
        'txtStartport.Attributes.Add("onkeydown", "KeyDown(event);")
        'txtDestport.Attributes.Add("onkeydown", "KeyDown(event);")

        txtStartport.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")
        txtDestport.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")

    End Sub


    '载入列表信息
    Sub LoadRecord(ByVal page As String)

        Dim ck As New check
        '取搜索条件，搜索条件保存在隐藏的label内
        Dim line As String = ck.CheckInput(hidTxtLine.Text)
        Dim startport As String = ck.CheckInput(hidTxtStartport.Text)
        If startport <> "" Then
            startport = Trim(startport.Split("(")(0))
        End If
        Dim destport As String = ck.CheckInput(hidTxtDestport.Text)
        page = ck.CheckInput(page)
        If destport <> "" Then
            destport = Trim(destport.Split("(")(0))
        End If
        If destport <> "" Then
            line = ""
        End If



        Dim cn As New data_conn
        Dim ds As New Data.DataSet
        Dim sql As String = ""

        'item是(页码-1)x10，用来计算分页用
        Dim item As Integer
        item = CInt(page - 1) * 15

        '提取起运港的中英文名称
        Dim dsfrom As New DataSet
        Dim sqlfrom As String
        sqlfrom = ""
        sqlfrom = sqlfrom & "SELECT cityname, citynameen,ad "
        sqlfrom = sqlfrom & "FROM TB_Airport "
        sqlfrom = sqlfrom & "WHERE "
        sqlfrom = sqlfrom & "cityname = '" & startport & "' "
        sqlfrom = sqlfrom & "OR citynameen = '" & startport & "' "
        sqlfrom = sqlfrom & "OR ad = '" & startport & "' "
        ds = cn.mdb_ds(sqlfrom, "city")
        dsfrom = cn.mdb_ds(sqlfrom, "city")

        '起运港提取，起运港缩写为一数组，因为一个起运港城市可能有多个机场
        Dim startport_1 As String = ""
        Dim startport_2 As String = ""
        Dim startport_3 As New ArrayList
        If ds.Tables("city").Rows.Count > 0 Then
            startport_1 = ds.Tables("city").Rows(0)(0).ToString
            startport_2 = ds.Tables("city").Rows(0)(1).ToString
            For i As Integer = 0 To ds.Tables("city").Rows.Count - 1
                If ds.Tables("city").Rows(i)(2).ToString <> "" Then
                    startport_3.Add(ds.Tables("city").Rows(i)(2).ToString)
                End If
            Next
        End If

        '提取目的港的中英文名称
        Dim dsto As New DataSet
        Dim sqlto As String
        sqlto = ""
        sqlto = sqlto & "SELECT cityname,citynameen,ad "
        sqlto = sqlto & "FROM TB_Airport "
        sqlto = sqlto & "WHERE "
        sqlto = sqlto & "cityname = '" & destport & "' "
        sqlto = sqlto & "OR citynameen = '" & destport & "' "
        sqlto = sqlto & "OR ad = '" & destport & "' "

        'Response.Write(sqlto)
        'Response.Write("<br/>")
        dsto = cn.mdb_ds(sqlto, "city2")

        '目的港提取，目的港缩写为一数组
        Dim destportlist As New ArrayList
        If dsto.Tables("city2").Rows.Count > 0 Then
            If dsto.Tables("city2").Rows(0)(0).ToString <> "" Then
                destportlist.Add(dsto.Tables("city2").Rows(0)(0).ToString)
            End If
            If dsto.Tables("city2").Rows(0)(1).ToString <> "" Then
                destportlist.Add(dsto.Tables("city2").Rows(0)(1).ToString)
            End If
            For i As Integer = 0 To dsto.Tables("city2").Rows.Count - 1
                If dsto.Tables("city2").Rows(i)(2).ToString <> "" Then
                    destportlist.Add(dsto.Tables("city2").Rows(i)(2).ToString)
                End If
            Next
        End If


        Dim dsfreight As New Data.DataSet
        If dp = "" And cr = "" Then
            '没有船公司及目的港时
            sql = "select top 15 "
            sql = sql & "sid,id,startport,title,line,hits,destport,price_p45,price_p100,price_p300,price_p500,price_p1000,assurance,"
            sql = sql & "userid,"
            sql = sql & "companyname,"
            sql = sql & "star_allin,"
            sql = sql & "star_user,"
            sql = sql & "postdate,"
            sql = sql & "ifend,"
            sql = sql & "enddate "
            sql = sql & "FROM (SELECT "
            sql = sql & "distinct t_airinfo.id as sid,'0' as id,t_airinfo.startport as startport,t_airinfo.title,t_airinfo.line,t_airinfo.hits,t_airinfo.DestPort1 as destport,t_airinfo.assurance as assurance, "
            sql = sql & "t_airinfo.PRICE_P451 as price_p45,"
            sql = sql & "t_airinfo.PRICE_P1001 as price_p100,"
            sql = sql & "t_airinfo.PRICE_P3001 as price_p300,"
            sql = sql & "t_airinfo.PRICE_P5001 as price_p500,"
            sql = sql & "t_airinfo.PRICE_P10001 as price_p1000,"
            sql = sql & "tb_user.userid,"
            sql = sql & "tb_user.companyname,"
            sql = sql & "tb_user.star_allin,"
            sql = sql & "tb_user.star_user,"
            sql = sql & "t_airinfo.postdate,"
            sql = sql & "(CASE WHEN t_airinfo.enddate > GETDATE() THEN 1 ELSE 0 END) AS ifend, "
            sql = sql & "CONVERT(varchar(10), t_airinfo.enddate, 120) as enddate "
            sql = sql & "FROM "
            sql = sql & "t_airinfo,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_user.userid = t_airinfo.userid "


            '加入筛选条件，编号，航线，起运港
            If line <> "" Then
                sql = sql & "AND t_airinfo.line = '" & line & "' "
            End If
            If startport <> "" Then
                If ds.Tables("city").Rows.Count > 0 Then
                    sql = sql & "AND (t_airinfo.startport like '%" & startport_1 & "%' "
                    sql = sql & "OR t_airinfo.startport like '%" & startport_2 & "%' "
                    '循环提取起运港缩写
                    For i As Integer = 0 To startport_3.Count - 1
                        sql = sql & "OR t_airinfo.startport like '%" & startport_3(i) & "%' "
                    Next
                    sql = sql & ") "
                    dsfreight = GetFreightCompanyAir(startport_1, startport_2, startport_3, destport)

                Else
                    sql = sql & "AND t_airinfo.startport like '%" & startport & "%' "
                    dsfreight = GetFreightCompany(startport, "", destport)
                End If
            End If

            sql = sql & ") AS T "

            sql = sql & "WHERE sid NOT IN "
            sql = sql & "(SELECT id FROM"
            sql = sql & "(SELECT distinct TOP " & item.ToString & " t_airinfo.id AS id,t_airinfo.postdate "
            sql = sql & "FROM "
            sql = sql & "t_airinfo,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_user.userid = t_airinfo.userid "

            '加入筛选条件，编号，航线，起运港
            If line <> "" Then
                sql = sql & "AND t_airinfo.line = '" & line & "' "
            End If
            If startport <> "" Then
                If ds.Tables("city").Rows.Count > 0 Then
                    sql = sql & "AND (t_airinfo.startport like '%" & startport_1 & "%' "
                    sql = sql & "OR t_airinfo.startport like '%" & startport_2 & "%' "
                    '循环提取起运港缩写
                    For i As Integer = 0 To startport_3.Count - 1
                        sql = sql & "OR t_airinfo.startport like '%" & startport_3(i) & "%' "
                    Next
                    sql = sql & ") "

                Else
                    sql = sql & "AND t_airinfo.startport like '%" & startport & "%' "
                    dsfreight = GetFreightCompany(startport, "", destport)


                End If
            End If

            sql = sql & "ORDER BY t_airinfo.postdate DESC "
            sql = sql & ") AS T "
            sql = sql & ") "
            sql = sql & "ORDER BY postdate DESC "

            lblCompanyStart.Text = sp
        Else
            sql = "select top 15 "
            sql = sql & "sid,id,startport,title,line,hits,destport,price_p45,price_p100,price_p300,price_p500,price_p1000,assurance,"
            sql = sql & "userid,"
            sql = sql & "companyname,"
            sql = sql & "star_allin,"
            sql = sql & "star_user,"
            sql = sql & "postdate,"
            sql = sql & "ifend,"
            sql = sql & "enddate "
            sql = sql & "FROM (SELECT "
            sql = sql & "t_airinfo.id as sid,t_airprice.id as id,t_airinfo.startport as startport,t_airinfo.title,t_airinfo.line,t_airinfo.hits,t_airprice.DestPort as destport,t_airprice.assurance as assurance,"
            sql = sql & "t_airprice.PRICE_P45 as price_p45,"
            sql = sql & "t_airprice.PRICE_P100 as price_p100,"
            sql = sql & "t_airprice.PRICE_P300 as price_p300,"
            sql = sql & "t_airprice.PRICE_P500 as price_p500,"
            sql = sql & "t_airprice.PRICE_P1000 as price_p1000,"
            sql = sql & "tb_user.userid,"
            sql = sql & "tb_user.companyname,"
            sql = sql & "tb_user.star_allin,"
            sql = sql & "tb_user.star_user,"
            sql = sql & "t_airinfo.postdate,"
            sql = sql & "(CASE WHEN t_airinfo.enddate > GETDATE() THEN 1 ELSE 0 END) AS ifend, "
            sql = sql & "CONVERT(varchar(10), t_airinfo.enddate, 120) as enddate "
            sql = sql & "FROM "
            sql = sql & "t_airinfo,t_airprice,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND t_airinfo.id = t_airprice.airid AND tb_user.userid = t_airinfo.userid "


            '加入筛选条件，编号，航线，起运港
            If line <> "" Then
                sql = sql & "AND t_airinfo.line = '" & line & "' "
            End If
            If startport <> "" Then
                If ds.Tables("city").Rows.Count > 0 Then
                    sql = sql & "AND (t_airinfo.startport like '%" & startport_1 & "%' "
                    sql = sql & "OR t_airinfo.startport like '%" & startport_2 & "%' "
                    '循环提取起运港缩写
                    For i As Integer = 0 To startport_3.Count - 1
                        sql = sql & "OR t_airinfo.startport like '%" & startport_3(i) & "%' "
                    Next
                    sql = sql & ") "
                    dsfreight = GetFreightCompanyAir(startport_1, startport_2, startport_3, destport)

                Else
                    sql = sql & "AND t_airinfo.startport like '%" & startport & "%' "
                    dsfreight = GetFreightCompany(startport, "", destport)


                End If
            End If

            If destport <> "" Then
                If dsto.Tables("city2").Rows.Count > 0 Then
                    sql = sql & "AND ("
                    For i As Integer = 0 To destportlist.Count - 1
                        If i = 0 Then
                            sql = sql & "t_airprice.destport like '%" & destportlist(i) & "%' "
                        Else
                            sql = sql & "OR t_airprice.destport like '%" & destportlist(i) & "%' "
                        End If
                    Next
                    sql = sql & ") "
                Else
                    sql = sql & "AND t_airprice.destport like '%" & destport & "%' "
                End If
            End If

            sql = sql & ") AS T "

            sql = sql & "WHERE id NOT IN "
            sql = sql & "(SELECT id FROM"
            sql = sql & "(SELECT TOP " & item.ToString & " t_airprice.id AS id,t_airinfo.postdate "
            sql = sql & "FROM "
            sql = sql & "t_airinfo,t_airprice,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND t_airinfo.id = t_airprice.airid AND tb_user.userid = t_airinfo.userid "

            '加入筛选条件，编号，航线，起运港
            If line <> "" Then
                sql = sql & "AND t_airinfo.line = '" & line & "' "
            End If
            If startport <> "" Then
                If ds.Tables("city").Rows.Count > 0 Then
                    sql = sql & "AND (t_airinfo.startport like '%" & startport_1 & "%' "
                    sql = sql & "OR t_airinfo.startport like '%" & startport_2 & "%' "
                    '循环提取起运港缩写
                    For i As Integer = 0 To startport_3.Count - 1
                        sql = sql & "OR t_airinfo.startport like '%" & startport_3(i) & "%' "
                    Next
                    sql = sql & ") "

                Else
                    sql = sql & "AND t_airinfo.startport like '%" & startport & "%' "
                    dsfreight = GetFreightCompany(startport, "", destport)


                End If
            End If

            If destport <> "" Then
                If dsto.Tables("city2").Rows.Count > 0 Then
                    sql = sql & "AND ("
                    For i As Integer = 0 To destportlist.Count - 1
                        If i = 0 Then
                            sql = sql & "t_airprice.destport like '%" & destportlist(i) & "%' "
                        Else
                            sql = sql & "OR t_airprice.destport like '%" & destportlist(i) & "%' "
                        End If
                    Next
                    sql = sql & ") "
                Else
                    sql = sql & "AND t_airprice.destport like '%" & destport & "%' "
                End If
            End If

            sql = sql & "ORDER BY t_airinfo.postdate DESC "
            sql = sql & ") AS T "
            sql = sql & ") "
            sql = sql & "ORDER BY postdate DESC "


            lblCompanyStart.Text = sp
            lblCompanyDest.Text = "-" + dp
        End If

        'Me.Response.Write(sql)
        ds = cn.mdb_ds(sql, "yunjia")

        Rptair.DataSource = ds.Tables("yunjia").DefaultView
        Rptair.DataBind()

        If startport <> "" Then
            RptFreight.DataSource = dsfreight.Tables("freight").DefaultView
            RptFreight.DataBind()
            If dsfreight.Tables("freight").Rows.Count > 0 Then
                PnlFreight.Visible = True
            End If
        Else
            PnlFreight.Visible = False
        End If


        sql = ""


        If dp = "" And cr = "" Then
            sql = sql & "SELECT "
            sql = sql & "count(t_airinfo.id) as T "
            sql = sql & "FROM "
            sql = sql & "t_airinfo "
            sql = sql & "WHERE "
            sql = sql & "1=1  "

            '加入筛选条件，编号，航线，起运港
            If line <> "" Then
                sql = sql & "AND t_airinfo.line = '" & line & "' "
            End If
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sql = sql & "AND (t_airinfo.startport like '%" & startport_1 & "%' "
                    sql = sql & "OR t_airinfo.startport like '%" & startport_2 & "%' "
                    '循环提取起运港缩写
                    For i As Integer = 0 To startport_3.Count - 1
                        sql = sql & "OR t_airinfo.startport like '%" & startport_3(i) & "%' "
                    Next
                    sql = sql & ") "

                Else
                    sql = sql & "AND t_airinfo.startport like '%" & startport & "%' "
                    dsfreight = GetFreightCompany(startport, "", destport)
                End If
            End If
        Else
            sql = sql & "SELECT "
            sql = sql & "count(t_airprice.id) as T "
            sql = sql & "FROM "
            sql = sql & "t_airinfo,t_airprice "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND t_airinfo.id = t_airprice.airid "

            '加入筛选条件，编号，航线，起运港
            If line <> "" Then
                sql = sql & "AND t_airinfo.line = '" & line & "' "
            End If
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sql = sql & "AND (t_airinfo.startport like '%" & startport_1 & "%' "
                    sql = sql & "OR t_airinfo.startport like '%" & startport_2 & "%' "
                    '循环提取起运港缩写
                    For i As Integer = 0 To startport_3.Count - 1
                        sql = sql & "OR t_airinfo.startport like '%" & startport_3(i) & "%' "
                    Next
                    sql = sql & ") "

                Else
                    sql = sql & "AND t_airinfo.startport like '%" & startport & "%' "
                    dsfreight = GetFreightCompany(startport, "", destport)


                End If
            End If

            If destport <> "" Then
                If dsto.Tables("city2").Rows.Count > 0 Then
                    sql = sql & "AND ("
                    For i As Integer = 0 To destportlist.Count - 1
                        If i = 0 Then
                            sql = sql & "t_airprice.destport like '%" & destportlist(i) & "%' "
                        Else
                            sql = sql & "OR t_airprice.destport like '%" & destportlist(i) & "%' "
                        End If
                    Next
                    sql = sql & ") "
                Else
                    sql = sql & "AND t_airprice.destport like '%" & destport & "%' "
                End If
            End If


        End If



        ds = cn.mdb_ds(sql, "count")



        sql = "SELECT "
        sql = sql & "count(t_airprice.id) as T "
        sql = sql & "FROM "
        sql = sql & "t_airinfo,t_airprice "
        sql = sql & "WHERE "
        sql = sql & "1=1 AND t_airinfo.id = t_airprice.airid "

        '加入筛选条件，编号，航线，起运港
        If line <> "" Then
            sql = sql & "AND t_airinfo.line = '" & line & "' "
        End If
        If startport <> "" Then
            If dsfrom.Tables("city").Rows.Count > 0 Then
                sql = sql & "AND (t_airinfo.startport like '%" & startport_1 & "%' "
                sql = sql & "OR t_airinfo.startport like '%" & startport_2 & "%' "
                '循环提取起运港缩写
                For i As Integer = 0 To startport_3.Count - 1
                    sql = sql & "OR t_airinfo.startport like '%" & startport_3(i) & "%' "
                Next
                sql = sql & ") "

            Else
                sql = sql & "AND t_airinfo.startport like '%" & startport & "%' "
                dsfreight = GetFreightCompany(startport, "", destport)


            End If
        End If

        If destport <> "" Then
            If dsto.Tables("city2").Rows.Count > 0 Then
                sql = sql & "AND ("
                For i As Integer = 0 To destportlist.Count - 1
                    If i = 0 Then
                        sql = sql & "t_airprice.destport like '%" & destportlist(i) & "%' "
                    Else
                        sql = sql & "OR t_airprice.destport like '%" & destportlist(i) & "%' "
                    End If
                Next
                sql = sql & ") "
            Else
                sql = sql & "AND t_airprice.destport like '%" & destport & "%' "
            End If
        End If

        Dim ds2 As New Data.DataSet
        ds2 = cn.mdb_ds(sql, "count")


        '计算出页数
        Dim items As Integer
        items = ds.Tables("count").Rows(0)(0)

        Dim fakeitem As Integer
        fakeitem = ds2.Tables("count").Rows(0)(0)

        Dim pages As Integer
        If items Mod 15 > 0 Or items = 0 Then
            pages = items \ 15 + 1
        Else
            pages = items \ 15
        End If


        '以下为页码控制栏相关
        Dim s As String = ""
        Dim cp As Integer = 1
        If Not Request.QueryString("p") Is Nothing Then
            cp = CInt(Request.QueryString("p").ToString)
        End If
        Dim tp As Integer = pages

        If tp >= 100 Then
            tp = 100
        End If


        Dim base_url As String = "/air/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-----"

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
        'lblTotalItem.Text = item.ToString
        hidTotalItem.Text = fakeitem.ToString
        lblTotalPage.Text = tp.ToString
        hidTotalPage.Value = tp.ToString
        lblCurrentPage.Text = cp.ToString
        txtPageJump.Value = cp.ToString


        If line <> "" Or startport <> "" Or destport <> "" Then '如果没有填写搜索条件，那么不记录搜索条件
            If cp = "1" Then '如果是第一页，那么开始记录搜索条件
                If items <= 0 Then '无结果，成功值置0

                    phNoResult.Visible = True
                    Dim pm1 = New pm()
                    pm1.SaveSearchWords2("10", line, startport, destport, "", 0, "", "", "", "", "", "", "")
                End If
            End If
        End If
    End Sub


    '计算页数
    Sub LoadTotalCount()

        Dim ck As New check
        '取搜索条件，搜索条件保存在隐藏的label内
        Dim line As String = ck.CheckInput(hidTxtLine.Text)
        Dim startport As String = ck.CheckInput(hidTxtStartport.Text)
        If startport <> "" Then
            startport = startport.Split(",")(0)
        End If
        Dim destport As String = ck.CheckInput(hidTxtDestport.Text)

        If destport <> "" Then
            line = ""
        End If


        '访问数据库，统计记录条数
        Dim cn As New data_conn
        Dim ds As New Data.DataSet
        Dim ds2 As New Data.DataSet
        Dim sql As String = ""



        '提取起运港的中英文名称
        Dim sqlfrom As String
        sqlfrom = ""
        sqlfrom = sqlfrom & "SELECT cityname, citynamech "
        sqlfrom = sqlfrom & "FROM TB_CHINACITY "
        sqlfrom = sqlfrom & "WHERE "
        sqlfrom = sqlfrom & "cityname = '" & startport & "' "
        sqlfrom = sqlfrom & "OR citynamech = '" & startport & "' "
        ds = cn.mdb_ds(sqlfrom, "city")

        Dim city0 As String = ""
        Dim city1 As String = ""

        Dim citycount As Integer = ds.Tables("city").Rows.Count

        If citycount > 0 Then
            city0 = ds.Tables("city").Rows(0)(0).ToString
            city1 = ds.Tables("city").Rows(0)(1).ToString
        End If





    End Sub




    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub



    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If txtDestport.Text <> "" Then
            Response.Redirect("/air/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "--0-0-0-----1.html")
        Else
            Response.Redirect("/air/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "--" & txtLine.SelectedIndex.ToString & "-0-0-----1.html")
        End If
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
        sql = sql + "SELECT TOP 6 T_AIRINFO.UserID, TB_User.CompanyName, COUNT(T_AIRINFO.UserID) AS c, dbo.get_airid(MAX(T_AIRPRICE.ID)) AS yid, MAX(T_AIRPRICE.ID) AS ydid "
        sql = sql + "FROM T_AIRINFO INNER JOIN T_AIRPRICE ON T_AIRINFO.id = T_AIRPRICE.AIRID INNER JOIN TB_User ON T_AIRINFO.UserID = TB_User.UserID "
        sql = sql + "WHERE ((T_AIRINFO.StartPort LIKE '%" & s1 & "%') OR (T_AIRINFO.StartPort LIKE '%" & s2 & "%')"


        sql = sql + ") AND (T_AIRPRICE.DestPort LIKE '%" & d & "%') AND (T_AIRINFO.enddate >= { fn NOW() }) AND T_AIRINFO.USERID <> 44"
        sql = sql + "GROUP BY T_AIRINFO.UserID, TB_User.CompanyName "
        sql = sql + "ORDER BY c DESC "

        ds = cn.mdb_ds(sql, "freight")
        'Response.Write(sql)
        Return ds
    End Function

    Public Function GetFreightCompanyAir(ByVal s1 As String, ByVal s2 As String, ByVal s3 As ArrayList, ByVal d As String) As Data.DataSet
        Dim cn As New data_conn
        Dim ds As New Data.DataSet
        Dim sql As String
        sql = ""
        sql = sql + "SELECT TOP 6 T_AIRINFO.UserID, TB_User.CompanyName, COUNT(T_AIRINFO.UserID) AS c, dbo.get_airid(MAX(T_AIRPRICE.ID)) AS yid, MAX(T_AIRPRICE.ID) AS ydid "
        sql = sql + "FROM T_AIRINFO INNER JOIN T_AIRPRICE ON T_AIRINFO.id = T_AIRPRICE.AIRID INNER JOIN TB_User ON T_AIRINFO.UserID = TB_User.UserID "
        sql = sql + "WHERE ((T_AIRINFO.StartPort LIKE '%" & s1 + "%') OR (T_AIRINFO.StartPort LIKE '%" + s2 + "%')"
        For i As Integer = 0 To s3.Count - 1


            sql = sql + " OR (T_AIRINFO.StartPort LIKE '%" + s3(i) + "%') "
        Next

        sql = sql + ") AND (T_AIRPRICE.DestPort LIKE '%" & d & "%') AND (T_AIRINFO.enddate >= { fn NOW() }) AND T_AIRINFO.USERID <> 44"
        sql = sql + "GROUP BY T_AIRINFO.UserID, TB_User.CompanyName "
        sql = sql + "ORDER BY c DESC "

        ds = cn.mdb_ds(sql, "freight")
        'Response.Write(sql)
        Return ds
    End Function


    Protected Sub btnPageJump_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPageJump.ServerClick

        If IsNumeric(txtPageJump.Value) Then

            If CInt(txtPageJump.Value.ToString) < 1 Then
                Response.Redirect("/air/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "--" & txtLine.SelectedIndex.ToString & "-0-0-----1.html")
            Else
                If CInt(txtPageJump.Value.ToString) > CInt(hidTotalPage.Value) Then
                    Response.Redirect("/air/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "--" & txtLine.SelectedIndex.ToString & "-0-0-----" & lblTotalPage.Text & ".html")
                Else
                    Response.Redirect("/air/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "--" & txtLine.SelectedIndex.ToString & "-0-0-----" & txtPageJump.Value & ".html")
                End If
            End If
        End If

    End Sub

    Protected Sub Rptair_ItemDataBound(ByVal sender As Object, ByVal e As EventArgs) Handles Rptair.PreRender
        Dim ck As New check
        If Rptair.Items.Count <> 0 Then
            Dim ds As Data.DataSet
            Dim conn As New data_conn
            Dim a As Label
            Dim i As Integer
            a = Rptair.Items(0).FindControl("Label1")
            Dim ids As String = a.Text
            For i = 1 To Rptair.Items.Count - 1
                a = Rptair.Items(i).FindControl("Label1")
                ids += "," + a.Text
            Next


            ds = conn.mdb_ds("select yunjiaid,DESTPORT,PRICE_P45,PRICE_P100,PRICE_P300,PRICE_P500,PRICE_P1000,assurance,star_allin,qstring from V_POP_AIR where yunjiaid in (" + ck.CheckInput(ids) + ") order by DESTPORT", "table")

            Dim str As String = ""
            For i = 0 To Rptair.Items.Count - 1
                Dim point As String = ""
                Dim j As Integer
                Dim count As Integer
                a = Rptair.Items(i).FindControl("Label1")
                If ds.Tables("table").Select("yunjiaid=" + a.Text).Length > 10 Then
                    count = 9
                    Dim realcount As Integer
                    realcount = ds.Tables("table").Select("yunjiaid=" + a.Text).Length - 9
                    point = "<a href=""/air/" + key(a.Text) + "_0.html"" target=""_blank"">查看其余" + realcount.ToString + "条运价</a>######"
                Else
                    count = ds.Tables("table").Select("yunjiaid=" + a.Text).Length - 1
                End If

                If count > 9 Then
                    count = 9
                End If
                '增加预览的上限是10个

                For j = 0 To count
                    Dim k As Integer
                    For k = 1 To 9
                        str += ds.Tables("table").Select("yunjiaid=" + a.Text)(j).Item(k).ToString()
                        If k <> 9 Then
                            str += "##"
                        End If
                    Next
                    If j <> ds.Tables("table").Select("yunjiaid=" + a.Text).Length - 1 Then
                        str += "$$"
                    End If
                Next
                str += point
                If i <> Rptair.Items.Count - 1 Then
                    str += "$|**|$"
                End If
            Next
            Hidden1.Value = str

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            If Me.Request.Cookies("user_id") Is Nothing Then

                Hiddennn1.Value = ""
            Else

                If Request.Cookies("user_id").Value.ToString = "" Then
                    Hiddennn1.Value = ""
                Else
                    a = Rptair.Items(0).FindControl("Label2")
                    ids = a.Text
                    For i = 1 To Rptair.Items.Count - 1
                        a = Rptair.Items(i).FindControl("Label2")
                        ids += "," + a.Text
                    Next

                    ds = conn.mdb_ds("select * from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table")
                    'Hiddennn1.Value = "select * from TB_User where UserID in (" + ids + ")"
                    str = ""
                    For i = 0 To Rptair.Items.Count - 1
                        Dim point As String = ""
                        Dim j As Integer
                        Dim count As Integer
                        a = Rptair.Items(i).FindControl("Label2")
                        If ds.Tables("table").Select("UserID=" + a.Text).Length = 1 Then



                            str += "公司名称" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("CompanyName").ToString()
                            str += "$$"
                            str += "联系人" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("Realname").ToString()
                            str += "$$"
                            str += "电话号码" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("Phone").ToString()
                            str += "$$"
                            str += "传真号码" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("Fax").ToString()
                            str += "$$"
                            str += "手机号码" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("MovePhone").ToString()
                            str += "$$"
                            str += "MSN" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("Usermsn").ToString()
                            str += "$$"
                            str += "QQ" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("Userqq").ToString()
                            str += "$$"
                            str += "电子邮箱" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("UserEmail").ToString()
                        Else
                        End If
                        If i <> Rptair.Items.Count - 1 Then
                            str += "$|**|$"
                        End If
                    Next
                    Hiddennn1.Value = str
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

    Public Shared Function Star3(ByVal s As String) As String
        Dim ss As Integer
        ss = Convert.ToInt32(s)
        Dim w As String
        w = ""

        For i As Integer = 0 To ss - 1
            w = w + "信誉:"
        Next

        If ss = 0 Then
            w = ""
        End If

        Return w.ToString()
    End Function
End Class
