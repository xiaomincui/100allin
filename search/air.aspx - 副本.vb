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
    Public p As String = "1"
    '排序参数
    Public order As String = "0"
    Public history As String = "0"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Response.Write(Request.Url.ToString)
        If Not Page.IsPostBack Then
            If Not Request.QueryString("sp") Is Nothing Then
                '提取来自网页参数的搜索条件
                Dim GetRequest1 As New GetRequest
                sp = GetRequest1.GetRequestQueryString("sp", "").ToString()
                dp = GetRequest1.GetRequestQueryString("dp", "").ToString()
                cr = GetRequest1.GetRequestQueryString("cr", "").ToString()
                l = GetRequest1.GetRequestQueryString("l", "0").ToString()
                p = GetRequest1.GetRequestQueryString("p", "1").ToString()
                order = GetRequest1.GetRequestQueryString("order", "0").ToString()
                history = GetRequest1.GetRequestQueryString("history", "0").ToString()

                '起运港、目的港、航线搜索框，提取参数内容
                txtStartport.Text = sp
                txtDestport.Text = dp

                If sp <> "" Then
                    ltrYouSearch.Text = "您搜索的是："
                End If

                '搜索条件保存在label控件内
                hidTxtStartport.Text = sp
                hidTxtDestport.Text = dp
                hidHistroy.Value = history

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
        StartportHotArray(1) = "深圳,shenzhen"
        StartportHotArray(2) = "广州,guangzhou"
        StartportHotArray(3) = "北京,beijing"
        StartportHotArray(4) = "香港,hongkong"
        StartportHotArray(5) = "杭州,hangzhou"
        StartportHotArray(6) = "南京,nanjing"
        StartportHotArray(7) = "厦门,xiamen"
        StartportHotArray(8) = "青岛,qingdao"
        StartportHotArray(9) = "珠海,zhuhai"
        StartportHotArray(10) = "长沙,changsha"
        StartportHotArray(11) = "武汉,wuhan"
        StartportHotArray(12) = "成都,chengdu"
        StartportHotArray(13) = "重庆,chongqing"
        StartportHotArray(14) = "宁波,ningbo"
        StartportHotArray(15) = "大连,dalian"

        For i As Integer = 0 To 14
            If StartportHotArray(i).IndexOf(sp.ToLower) <> -1 And sp <> "" Then
                lblStartportHot.Text = lblStartportHot.Text & "&nbsp;&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & StartportHotArray(i).Split(",")(0) & "</b>"
            Else
                lblStartportHot.Text = lblStartportHot.Text & "&nbsp;&nbsp;&nbsp;" & "<a href = ""/air/list-" & StartportHotArray(i).Split(",")(1) & "---" & l & "-0-0-0----1.html"">" & StartportHotArray(i).Split(",")(0) & "</a>"
            End If
        Next

        If sp = "" Then
            lblStartportHot.Text = "&nbsp;&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & lblStartportHot.Text
        Else
            lblStartportHot.Text = "&nbsp;&nbsp;&nbsp;" & "<a href = ""/air/list--" & dp & "--" & l & "-0-0-0----1.html"">全部</a>" & lblStartportHot.Text
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
                lblLineHot.Text = lblLineHot.Text & "&nbsp;&nbsp;&nbsp;" & "<a href = ""/air/list-" & sp & "---" & LineHotArray(i).Split(",")(1) & "-0-0-0----1.html"">" & LineHotArray(i).Split(",")(0) & "</a>"
            End If
        Next

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
        sqlfrom = sqlfrom & "SELECT cityname,   citynameen,ad "
        sqlfrom = sqlfrom & "FROM TB_Airport "
        sqlfrom = sqlfrom & "WHERE "
        sqlfrom = sqlfrom & "cityname = '" & startport & "' "
        sqlfrom = sqlfrom & "OR citynameen = '" & startport & "' "
        sqlfrom = sqlfrom & "OR ad = '" & startport & "' "
        dsfrom = cn.mdb_ds(sqlfrom, "city")

        '起运港提取，起运港缩写为一数组，因为一个起运港城市可能有多个机场
        Dim startportlist As New ArrayList
        If dsfrom.Tables("city").Rows.Count > 0 Then
            If dsfrom.Tables("city").Rows(0)(0).ToString <> "" Then
                startportlist.Add(dsfrom.Tables("city").Rows(0)(0).ToString)
            End If
            If dsfrom.Tables("city").Rows(0)(1).ToString <> "" Then
                startportlist.Add(dsfrom.Tables("city").Rows(0)(1).ToString)
            End If
            For i As Integer = 0 To dsfrom.Tables("city").Rows.Count - 1
                If dsfrom.Tables("city").Rows(i)(2).ToString <> "" Then
                    startportlist.Add(dsfrom.Tables("city").Rows(i)(2).ToString)
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

        Dim sqladv As String = ""
        Dim sqladv_1 As String = ""
        Dim dsadv As New Data.DataSet
        Dim dsadv_1 As New Data.DataSet
        Dim dsadv1 As New Data.DataSet
        Dim dsadv1_1 As New Data.DataSet

        Dim items As Integer = 0
        Dim fakeitem As Integer = 0
        Dim sqlwords1 As String = "" 'sqlwords1和sqlwords2是为查询有效运价的脚本
        Dim sqlwords2 As String = ""
        Dim sqlwords3 As String = "" 'sqlwords3是为查询历史运价的脚本
        Dim sqlwords4 As String = "" 'sqlwords4是为统计有效运价的脚本
        Dim sqlwords5 As String = "" 'sqlwords5是为统计历史运价的脚本

        If dp = "" And cr = "" Then
            sqlwords1 = sqlwords1 & "insert #Tmp (yunjiainfoid,userid,postdate,limit) ("
            sqlwords1 = sqlwords1 & "select airid,TB_Yunjia_Effective_10.userid,postdate,show_limit_air as limit from TB_Yunjia_Effective_10,TB_user "
            sqlwords1 = sqlwords1 & "where 1=1 AND TB_Yunjia_Effective_10.ifpass = 1 AND TB_Yunjia_Effective_10.userid = TB_user.userid "
            If line <> "" Then
                sqlwords1 = sqlwords1 & "AND line = '" & line & "' "
            End If
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqlwords1 = sqlwords1 & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqlwords1 = sqlwords1 & "startport like '%" & startportlist(i) & "%' "
                        Else
                            sqlwords1 = sqlwords1 & "OR startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqlwords1 = sqlwords1 & ") "

                Else
                    sqlwords1 = sqlwords1 & "AND startport like '%" & startport & "%' "
                End If
            End If
            sqlwords1 = sqlwords1 & ")"

            sqlwords2 = sqlwords2 & "select T1.airid as sid,"
            sqlwords2 = sqlwords2 & "'0' as id,"
            sqlwords2 = sqlwords2 & "title as title,"
            sqlwords2 = sqlwords2 & "PRICE_P451 as price_p45,"
            sqlwords2 = sqlwords2 & "PRICE_P1001 as price_p100,"
            sqlwords2 = sqlwords2 & "PRICE_P3001 as price_p300,"
            sqlwords2 = sqlwords2 & "PRICE_P5001 as price_p500,"
            sqlwords2 = sqlwords2 & "PRICE_P10001 as price_p1000,"
            sqlwords2 = sqlwords2 & "line,"
            sqlwords2 = sqlwords2 & "startport,"
            sqlwords2 = sqlwords2 & "destport1 as destport,"
            sqlwords2 = sqlwords2 & "star_allin,"
            sqlwords2 = sqlwords2 & "star_user,"
            sqlwords2 = sqlwords2 & "assurance,"
            sqlwords2 = sqlwords2 & "T1.userid as userid,"
            sqlwords2 = sqlwords2 & "T2.companyname as companyname,"
            sqlwords2 = sqlwords2 & "T1.postdate as postdate,"
            sqlwords2 = sqlwords2 & "T1.enddate as enddate "
            sqlwords2 = sqlwords2 & "from TB_Yunjia_Effective_10 T1,tb_user T2,(select top 15 * from #Tmp2 where yunjiainfoid not in (select top " & item.ToString & " yunjiainfoid from #Tmp2 order by postdate desc,yunjiainfoid desc) order by postdate desc,yunjiainfoid desc) T3 where T1.airid=T3.yunjiainfoid and T2.userid = T3.userid order by T3.postdate desc,yunjiainfoid desc"


            sqlwords3 = "select top 15 "
            sqlwords3 = sqlwords3 & "sid,id,startport,title,line,hits,destport,price_p45,price_p100,price_p300,price_p500,price_p1000,assurance,"
            sqlwords3 = sqlwords3 & "userid,"
            sqlwords3 = sqlwords3 & "companyname,"
            sqlwords3 = sqlwords3 & "star_allin,"
            sqlwords3 = sqlwords3 & "star_user,"
            sqlwords3 = sqlwords3 & "postdate,"
            sqlwords3 = sqlwords3 & "enddate "
            sqlwords3 = sqlwords3 & "FROM (SELECT "
            sqlwords3 = sqlwords3 & "t_airinfo.id as sid,'0' as id,t_airinfo.startport as startport,t_airinfo.title,t_airinfo.line,t_airinfo.hits,t_airinfo.DestPort1 as destport,t_airinfo.assurance as assurance, "
            sqlwords3 = sqlwords3 & "t_airinfo.PRICE_P451 as price_p45,"
            sqlwords3 = sqlwords3 & "t_airinfo.PRICE_P1001 as price_p100,"
            sqlwords3 = sqlwords3 & "t_airinfo.PRICE_P3001 as price_p300,"
            sqlwords3 = sqlwords3 & "t_airinfo.PRICE_P5001 as price_p500,"
            sqlwords3 = sqlwords3 & "t_airinfo.PRICE_P10001 as price_p1000,"
            sqlwords3 = sqlwords3 & "tb_user.userid,"
            sqlwords3 = sqlwords3 & "tb_user.companyname,"
            sqlwords3 = sqlwords3 & "tb_user.star_allin,"
            sqlwords3 = sqlwords3 & "tb_user.star_user,"
            sqlwords3 = sqlwords3 & "t_airinfo.postdate,"
            sqlwords3 = sqlwords3 & "t_airinfo.enddate "
            sqlwords3 = sqlwords3 & "FROM "
            sqlwords3 = sqlwords3 & "t_airinfo,tb_user "
            sqlwords3 = sqlwords3 & "WHERE "
            sqlwords3 = sqlwords3 & "1=1 AND tb_user.userid = t_airinfo.userid AND t_airinfo.enddate < GETDATE()"
            If line <> "" Then
                sqlwords3 = sqlwords3 & "AND t_airinfo.line = '" & line & "' "
            End If
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqlwords3 = sqlwords3 & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqlwords3 = sqlwords3 & "t_airinfo.startport like '%" & startportlist(i) & "%' "
                        Else
                            sqlwords3 = sqlwords3 & "OR t_airinfo.startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqlwords3 = sqlwords3 & ") "
                Else
                    sqlwords3 = sqlwords3 & "AND t_airinfo.startport like '%" & startport & "%' "

                End If
            End If
            sqlwords3 = sqlwords3 & ") AS T "
            sqlwords3 = sqlwords3 & "WHERE sid NOT IN "
            sqlwords3 = sqlwords3 & "(SELECT id FROM"
            sqlwords3 = sqlwords3 & "(SELECT TOP " & item.ToString & " t_airinfo.id AS id "
            sqlwords3 = sqlwords3 & "FROM "
            sqlwords3 = sqlwords3 & "t_airinfo,tb_user "
            sqlwords3 = sqlwords3 & "WHERE "
            sqlwords3 = sqlwords3 & "1=1 AND tb_user.userid = t_airinfo.userid AND t_airinfo.enddate < GETDATE()"
            If line <> "" Then
                sqlwords3 = sqlwords3 & "AND t_airinfo.line = '" & line & "' "
            End If
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqlwords3 = sqlwords3 & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqlwords3 = sqlwords3 & "t_airinfo.startport like '%" & startportlist(i) & "%' "
                        Else
                            sqlwords3 = sqlwords3 & "OR t_airinfo.startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqlwords3 = sqlwords3 & ") "
                Else
                    sqlwords3 = sqlwords3 & "AND t_airinfo.startport like '%" & startport & "%' "

                End If
            End If
            sqlwords3 = sqlwords3 & "ORDER BY t_airinfo.postdate DESC,t_airinfo.id desc "
            sqlwords3 = sqlwords3 & ") AS T "
            sqlwords3 = sqlwords3 & ") "
            sqlwords3 = sqlwords3 & "ORDER BY postdate DESC,sid DESC "


            sqlwords4 = sqlwords4 & "insert into #TMP3 (fcount1) (select count(*) as fcount1 from TB_Yunjia_Effective_10,TB_YunjiaInfo_Effective_10 "
            sqlwords4 = sqlwords4 & "where TB_Yunjia_Effective_10.airid = TB_YunjiaInfo_Effective_10.airid AND 1=1 "
            If line <> "" Then
                sqlwords4 = sqlwords4 & "AND line = '" & line & "' "
            End If
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqlwords4 = sqlwords4 & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqlwords4 = sqlwords4 & "TB_Yunjia_Effective_10.startport like '%" & startportlist(i) & "%' "
                        Else
                            sqlwords4 = sqlwords4 & "OR TB_Yunjia_Effective_10.startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqlwords4 = sqlwords4 & ") "

                Else
                    sqlwords4 = sqlwords4 & "AND TB_Yunjia_Effective_10.startport like '%" & startport & "%' "
                End If
            End If
            sqlwords4 = sqlwords4 & ") "

            sqlwords5 = sqlwords5 & "insert into #TMP3 (fcount1) (select count(*) as fcount1 from t_airinfo,t_airprice "
            sqlwords5 = sqlwords5 & "where t_airinfo.id = t_airprice.airid AND 1=1 AND t_airinfo.enddate < GETDATE() "
            If line <> "" Then
                sqlwords5 = sqlwords5 & "AND line = '" & line & "' "
            End If
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqlwords5 = sqlwords5 & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqlwords5 = sqlwords5 & "t_airinfo.startport like '%" & startportlist(i) & "%' "
                        Else
                            sqlwords5 = sqlwords5 & "OR t_airinfo.startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqlwords5 = sqlwords5 & ") "

                Else
                    sqlwords5 = sqlwords5 & "AND t_airinfo.startport like '%" & startport & "%' "
                End If
            End If
            sqlwords5 = sqlwords5 & ") "


            '置顶开始
            sqladv = "SELECT * FROM V_AIR_EFFECTIVE_ADV_LIST_20110425 WHERE 1=1 "
            If line <> "" Then
                sqladv = sqladv & "AND line = '" & line & "' "
            End If
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqladv = sqladv & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqladv = sqladv & "startport like '%" & startportlist(i) & "%' "
                        Else
                            sqladv = sqladv & "OR startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqladv = sqladv & ") "

                Else
                    sqladv = sqladv & "AND startport like '%" & startport & "%' "
                End If
            End If
            'Response.Write(sqlwords1 + "<br />")
            'Response.Write(sqlwords2)

            dsadv = cn.mdb_ds(sqladv, "fcladv")
            dsadv1 = dsadv.Clone
            Dim hidadv As String = ""
            Dim hidadvtemp As String = ""

            For iii As Integer = 0 To dsadv.Tables("fcladv").Rows.Count - 1
                hidadvtemp = "<div style=""line-height:15px;""><a href = ""/air/" & key(dsadv.Tables("fcladv").Rows(iii)("sid")) & "_0.html"" target=""_blank"">" & dsadv.Tables("fcladv").Rows(iii)("title") & "</a>" & "<br/>[" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "dd").ToString & " 至 " & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "dd").ToString & "]</div>##" & dsadv.Tables("fcladv").Rows(iii)("destport") & "##" & dsadv.Tables("fcladv").Rows(iii)("price_p45") & "/" & dsadv.Tables("fcladv").Rows(iii)("price_p100") & "/" & dsadv.Tables("fcladv").Rows(iii)("price_p300") & "/" & dsadv.Tables("fcladv").Rows(iii)("price_p500") & "/" & "" & dsadv.Tables("fcladv").Rows(iii)("price_p1000")
                If iii = 0 Then
                    dsadv1.Tables("fcladv").Rows.Add(dsadv.Tables("fcladv").Rows(iii).ItemArray)
                    hidadv = hidadvtemp
                Else
                    If (dsadv.Tables("fcladv").Rows(iii)("userid").ToString <> dsadv.Tables("fcladv").Rows(iii - 1)("userid").ToString) Then
                        dsadv1.Tables("fcladv").Rows.Add(dsadv.Tables("fcladv").Rows(iii).ItemArray)
                        hidadv = hidadv & "$|**|$" & hidadvtemp
                    Else
                        hidadv = hidadv & "$$" & hidadvtemp
                    End If

                End If
            Next


            Rptfcladv.DataSource = dsadv1.Tables("fcladv").DefaultView
            Rptfcladv.DataBind()

            Hidden2.Value = hidadv

            If dsadv.Tables("fcladv").Rows.Count > 0 Then
                PlaceHolder3.Visible = True
            End If	




            sqladv_1 = "SELECT * FROM V_AIR_EFFECTIVE_ADV_LIST_BASIC_20110425 WHERE 1=1 "
            If line <> "" Then
                sqladv_1= sqladv_1 & "AND line = '" & line & "' "
            End If
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqladv_1 = sqladv_1 & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqladv_1 = sqladv_1 & "startport like '%" & startportlist(i) & "%' "
                        Else
                            sqladv_1 = sqladv_1 & "OR startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqladv_1 = sqladv_1 & ") "

                Else
                    sqladv_1 = sqladv_1 & "AND startport like '%" & startport & "%' "
                End If
            End If
            'Response.Write(sqlwords1 + "<br />")
            'Response.Write(sqladv_1)

            dsadv_1 = cn.mdb_ds(sqladv_1, "fcladv")
            dsadv1_1 = dsadv_1.Clone
            Dim hidadv_1 As String = ""
            Dim hidadvtemp_1 As String = ""

            For iii As Integer = 0 To dsadv_1.Tables("fcladv").Rows.Count - 1
                hidadvtemp_1 = "<div style=""line-height:15px;""><a href = ""/air/" & key(dsadv_1.Tables("fcladv").Rows(iii)("sid")) & "_0.html"" target=""_blank"">" & dsadv_1.Tables("fcladv").Rows(iii)("title") & "</a>" & "<br/>[" & Format(dsadv_1.Tables("fcladv").Rows(iii)("postdate"), "yy").ToString & "/" & Format(dsadv_1.Tables("fcladv").Rows(iii)("postdate"), "MM").ToString & "/" & Format(dsadv_1.Tables("fcladv").Rows(iii)("postdate"), "dd").ToString & " 至 " & Format(dsadv_1.Tables("fcladv").Rows(iii)("enddate"), "yy").ToString & "/" & Format(dsadv_1.Tables("fcladv").Rows(iii)("enddate"), "MM").ToString & "/" & Format(dsadv_1.Tables("fcladv").Rows(iii)("enddate"), "dd").ToString & "]</div>##" & dsadv_1.Tables("fcladv").Rows(iii)("destport") & "##" & dsadv_1.Tables("fcladv").Rows(iii)("price_p45") & "/" & dsadv_1.Tables("fcladv").Rows(iii)("price_p100") & "/" & dsadv_1.Tables("fcladv").Rows(iii)("price_p300") & "/" & dsadv_1.Tables("fcladv").Rows(iii)("price_p500") & "/" & "" & dsadv_1.Tables("fcladv").Rows(iii)("price_p1000")
                If iii = 0 Then
                    dsadv1_1.Tables("fcladv").Rows.Add(dsadv_1.Tables("fcladv").Rows(iii).ItemArray)
                    hidadv_1 = hidadvtemp_1
                Else
                    If (dsadv_1.Tables("fcladv").Rows(iii)("userid").ToString <> dsadv_1.Tables("fcladv").Rows(iii - 1)("userid").ToString) Then
                        dsadv1_1.Tables("fcladv").Rows.Add(dsadv_1.Tables("fcladv").Rows(iii).ItemArray)
                        hidadv_1 = hidadv_1 & "$|**|$" & hidadvtemp_1
                    Else
                        hidadv_1 = hidadv_1 & "$$" & hidadvtemp_1
                    End If

                End If
            Next



            'Rptfcladv_1.DataSource = dsadv1_1.Tables("fcladv").DefaultView
            'Rptfcladv_1.DataBind()

            Hidden2_1.Value = hidadv_1

            If dsadv_1.Tables("fcladv").Rows.Count > 0 Then
                PlaceHolder3_1.Visible = True
		'ltrBanner_1.Text = "<div class=""right_ad""><a href=""http://www.100allin.com/company/SGk0NTZQV2xPdHU3Ymh1aENmdEdEQT09/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/gc.jpg"" width=""200"" height=""150"" border=""0"" /></a></div>"
            End If


        Else
            sqlwords1 = sqlwords1 & "insert #Tmp (yunjiainfoid,userid,postdate,limit) ("
            sqlwords1 = sqlwords1 & "select AIRPRICEID,TB_Yunjia_Effective_10.userid,postdate,show_limit_air as limit from TB_YunjiaInfo_Effective_10,TB_Yunjia_Effective_10,TB_user "
            sqlwords1 = sqlwords1 & "where TB_Yunjia_Effective_10.airid = TB_YunjiaInfo_Effective_10.airid AND TB_Yunjia_Effective_10.userid = TB_user.userid AND TB_Yunjia_Effective_10.ifpass = 1 AND 1=1 "
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqlwords1 = sqlwords1 & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqlwords1 = sqlwords1 & "TB_Yunjia_Effective_10.startport like '%" & startportlist(i) & "%' "
                        Else
                            sqlwords1 = sqlwords1 & "OR TB_Yunjia_Effective_10.startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqlwords1 = sqlwords1 & ") "

                Else
                    sqlwords1 = sqlwords1 & "AND TB_Yunjia_Effective_10.startport like '%" & startport & "%' "
                End If
            End If
            If destport <> "" Then
                If dsto.Tables("city2").Rows.Count > 0 Then
                    sqlwords1 = sqlwords1 & "AND ("
                    For i As Integer = 0 To destportlist.Count - 1
                        If i = 0 Then
                            sqlwords1 = sqlwords1 & "TB_YunjiaInfo_Effective_10.destport like '%" & destportlist(i) & "%' "
                        Else
                            sqlwords1 = sqlwords1 & "OR TB_YunjiaInfo_Effective_10.destport like '%" & destportlist(i) & "%' "
                        End If
                    Next
                    sqlwords1 = sqlwords1 & ") "
                Else
                    sqlwords1 = sqlwords1 & "AND TB_YunjiaInfo_Effective_10.destport like '%" & destport & "%' "
                End If
            End If
            sqlwords1 = sqlwords1 & ")"

            sqlwords2 = sqlwords2 & "select T1.airid as sid,"
            sqlwords2 = sqlwords2 & "T1.AIRPRICEID as id,"
            sqlwords2 = sqlwords2 & "title as title,"
            sqlwords2 = sqlwords2 & "PRICE_P45 as price_p45,"
            sqlwords2 = sqlwords2 & "PRICE_P100 as price_p100,"
            sqlwords2 = sqlwords2 & "PRICE_P300 as price_p300,"
            sqlwords2 = sqlwords2 & "PRICE_P500 as price_p500,"
            sqlwords2 = sqlwords2 & "PRICE_P1000 as price_p1000,"
            sqlwords2 = sqlwords2 & "line,"
            sqlwords2 = sqlwords2 & "T4.startport,"
            sqlwords2 = sqlwords2 & "T1.destport,"
            sqlwords2 = sqlwords2 & "star_allin,"
            sqlwords2 = sqlwords2 & "star_user,"
            sqlwords2 = sqlwords2 & "T1.assurance,"
            sqlwords2 = sqlwords2 & "T1.useridx as userid,"
            sqlwords2 = sqlwords2 & "T2.companyname as companyname,"
            sqlwords2 = sqlwords2 & "T1.postdatex as postdate,"
            sqlwords2 = sqlwords2 & "T1.enddatex as enddate "
            sqlwords2 = sqlwords2 & "from TB_YunjiaInfo_Effective_10 T1,tb_user T2,(select top 15 * from #Tmp2 where yunjiainfoid not in (select top " & item.ToString & " yunjiainfoid from #Tmp2 order by postdate desc,yunjiainfoid desc) order by postdate desc,yunjiainfoid desc) T3,TB_Yunjia_Effective_10 T4 where T1.AIRPRICEID=T3.yunjiainfoid and T2.userid = T3.userid and T4.airid = T1.airid order by T3.postdate desc,yunjiainfoid desc"

            sqlwords3 = "select top 15 "
            sqlwords3 = sqlwords3 & "sid,id,startport,title,line,hits,destport,price_p45,price_p100,price_p300,price_p500,price_p1000,assurance,"
            sqlwords3 = sqlwords3 & "userid,"
            sqlwords3 = sqlwords3 & "companyname,"
            sqlwords3 = sqlwords3 & "star_allin,"
            sqlwords3 = sqlwords3 & "star_user,"
            sqlwords3 = sqlwords3 & "postdate,"
            sqlwords3 = sqlwords3 & "enddate "
            sqlwords3 = sqlwords3 & "FROM (SELECT "
            sqlwords3 = sqlwords3 & "t_airinfo.id as sid,t_airprice.id as id,t_airinfo.startport as startport,t_airinfo.title,t_airinfo.line,t_airinfo.hits,t_airprice.DestPort as destport,t_airprice.assurance as assurance, "
            sqlwords3 = sqlwords3 & "t_airprice.PRICE_P45 as price_p45,"
            sqlwords3 = sqlwords3 & "t_airprice.PRICE_P100 as price_p100,"
            sqlwords3 = sqlwords3 & "t_airprice.PRICE_P300 as price_p300,"
            sqlwords3 = sqlwords3 & "t_airprice.PRICE_P500 as price_p500,"
            sqlwords3 = sqlwords3 & "t_airprice.PRICE_P1000 as price_p1000,"
            sqlwords3 = sqlwords3 & "tb_user.userid,"
            sqlwords3 = sqlwords3 & "tb_user.companyname,"
            sqlwords3 = sqlwords3 & "tb_user.star_allin,"
            sqlwords3 = sqlwords3 & "tb_user.star_user,"
            sqlwords3 = sqlwords3 & "t_airinfo.postdate,"
            sqlwords3 = sqlwords3 & "t_airinfo.enddate "
            sqlwords3 = sqlwords3 & "FROM "
            sqlwords3 = sqlwords3 & "t_airinfo,t_airprice,tb_user "
            sqlwords3 = sqlwords3 & "WHERE "
            sqlwords3 = sqlwords3 & "1=1 AND t_airinfo.id = t_airprice.airid AND tb_user.userid = t_airinfo.userid AND t_airinfo.enddate < GETDATE()"
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqlwords3 = sqlwords3 & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqlwords3 = sqlwords3 & "t_airinfo.startport like '%" & startportlist(i) & "%' "
                        Else
                            sqlwords3 = sqlwords3 & "OR t_airinfo.startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqlwords3 = sqlwords3 & ") "
                Else
                    sqlwords3 = sqlwords3 & "AND t_airinfo.startport like '%" & startport & "%' "

                End If
            End If
            If destport <> "" Then
                If dsto.Tables("city2").Rows.Count > 0 Then
                    sqlwords3 = sqlwords3 & "AND ("
                    For i As Integer = 0 To destportlist.Count - 1
                        If i = 0 Then
                            sqlwords3 = sqlwords3 & "t_airprice.destport like '%" & destportlist(i) & "%' "
                        Else
                            sqlwords3 = sqlwords3 & "OR t_airprice.destport like '%" & destportlist(i) & "%' "
                        End If
                    Next
                    sqlwords3 = sqlwords3 & ") "
                Else
                    sqlwords3 = sqlwords3 & "AND t_airprice.destport like '%" & destport & "%' "
                End If
            End If
            sqlwords3 = sqlwords3 & ") AS T "
            sqlwords3 = sqlwords3 & "WHERE sid NOT IN "
            sqlwords3 = sqlwords3 & "(SELECT id FROM"
            sqlwords3 = sqlwords3 & "(SELECT TOP " & item.ToString & " t_airinfo.id AS id "
            sqlwords3 = sqlwords3 & "FROM "
            sqlwords3 = sqlwords3 & "t_airinfo,t_airprice,tb_user "
            sqlwords3 = sqlwords3 & "WHERE "
            sqlwords3 = sqlwords3 & "1=1 AND t_airinfo.id = t_airprice.airid AND tb_user.userid = t_airinfo.userid AND t_airinfo.enddate < GETDATE()"
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqlwords3 = sqlwords3 & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqlwords3 = sqlwords3 & "t_airinfo.startport like '%" & startportlist(i) & "%' "
                        Else
                            sqlwords3 = sqlwords3 & "OR t_airinfo.startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqlwords3 = sqlwords3 & ") "
                Else
                    sqlwords3 = sqlwords3 & "AND t_airinfo.startport like '%" & startport & "%' "

                End If
            End If
            If destport <> "" Then
                If dsto.Tables("city2").Rows.Count > 0 Then
                    sqlwords3 = sqlwords3 & "AND ("
                    For i As Integer = 0 To destportlist.Count - 1
                        If i = 0 Then
                            sqlwords3 = sqlwords3 & "t_airprice.destport like '%" & destportlist(i) & "%' "
                        Else
                            sqlwords3 = sqlwords3 & "OR t_airprice.destport like '%" & destportlist(i) & "%' "
                        End If
                    Next
                    sqlwords3 = sqlwords3 & ") "
                Else
                    sqlwords3 = sqlwords3 & "AND t_airprice.destport like '%" & destport & "%' "
                End If
            End If
            sqlwords3 = sqlwords3 & "ORDER BY t_airinfo.postdate DESC "
            sqlwords3 = sqlwords3 & ") AS T "
            sqlwords3 = sqlwords3 & ") "
            sqlwords3 = sqlwords3 & "ORDER BY postdate DESC "

            sqlwords4 = sqlwords4 & "insert into #TMP3 (fcount1) (select count(*) as fcount1 from TB_Yunjia_Effective_10,TB_YunjiaInfo_Effective_10 "
            sqlwords4 = sqlwords4 & "where TB_Yunjia_Effective_10.airid = TB_YunjiaInfo_Effective_10.airid AND 1=1 "
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqlwords4 = sqlwords4 & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqlwords4 = sqlwords4 & "TB_Yunjia_Effective_10.startport like '%" & startportlist(i) & "%' "
                        Else
                            sqlwords4 = sqlwords4 & "OR TB_Yunjia_Effective_10.startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqlwords4 = sqlwords4 & ") "

                Else
                    sqlwords4 = sqlwords4 & "AND TB_Yunjia_Effective_10.startport like '%" & startport & "%' "
                End If
            End If
            If destport <> "" Then
                If dsto.Tables("city2").Rows.Count > 0 Then
                    sqlwords4 = sqlwords4 & "AND ("
                    For i As Integer = 0 To destportlist.Count - 1
                        If i = 0 Then
                            sqlwords4 = sqlwords4 & "TB_YunjiaInfo_Effective_10.destport like '%" & destportlist(i) & "%' "
                        Else
                            sqlwords4 = sqlwords4 & "OR TB_YunjiaInfo_Effective_10.destport like '%" & destportlist(i) & "%' "
                        End If
                    Next
                    sqlwords4 = sqlwords4 & ") "
                Else
                    sqlwords4 = sqlwords4 & "AND TB_YunjiaInfo_Effective_10.destport like '%" & destport & "%' "
                End If
            End If
            sqlwords4 = sqlwords4 & ") "

            sqlwords5 = sqlwords5 & "insert into #TMP3 (fcount1) (select count(*) as fcount1 from t_airinfo,t_airprice "
            sqlwords5 = sqlwords5 & "where t_airinfo.id = t_airprice.airid AND t_airinfo.enddate < GETDATE() "
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqlwords5 = sqlwords5 & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqlwords5 = sqlwords5 & "t_airinfo.startport like '%" & startportlist(i) & "%' "
                        Else
                            sqlwords5 = sqlwords5 & "OR t_airinfo.startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqlwords5 = sqlwords5 & ") "

                Else
                    sqlwords5 = sqlwords5 & "AND t_airinfo.startport like '%" & startport & "%' "
                End If
            End If
            If destport <> "" Then
                If dsto.Tables("city2").Rows.Count > 0 Then
                    sqlwords5 = sqlwords5 & "AND ("
                    For i As Integer = 0 To destportlist.Count - 1
                        If i = 0 Then
                            sqlwords5 = sqlwords5 & "t_airprice.destport like '%" & destportlist(i) & "%' "
                        Else
                            sqlwords5 = sqlwords5 & "OR t_airprice.destport like '%" & destportlist(i) & "%' "
                        End If
                    Next
                    sqlwords5 = sqlwords5 & ") "
                Else
                    sqlwords5 = sqlwords5 & "AND t_airprice.destport like '%" & destport & "%' "
                End If
            End If
            sqlwords5 = sqlwords5 & ") "

            '置顶开始
            sqladv = "SELECT * FROM V_AIR_EFFECTIVE_ADV_20110425 WHERE 1=1 "
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqladv = sqladv & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqladv = sqladv & "startport like '%" & startportlist(i) & "%' "
                        Else
                            sqladv = sqladv & "OR startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqladv = sqladv & ") "

                Else
                    sqladv = sqladv & "AND startport like '%" & startport & "%' "
                End If
            End If
            If destport <> "" Then
                If dsto.Tables("city2").Rows.Count > 0 Then
                    sqladv = sqladv & "AND ("
                    For i As Integer = 0 To destportlist.Count - 1
                        If i = 0 Then
                            sqladv = sqladv & "destport like '%" & destportlist(i) & "%' "
                        Else
                            sqladv = sqladv & "OR destport like '%" & destportlist(i) & "%' "
                        End If
                    Next
                    sqladv = sqladv & ") "
                Else
                    sqladv = sqladv & "AND destport like '%" & destport & "%' "
                End If
            End If
            dsadv = cn.mdb_ds(sqladv, "fcladv")
            dsadv1 = dsadv.Clone
            Dim hidadv As String = ""
            Dim hidadvtemp As String = ""

            For iii As Integer = 0 To dsadv.Tables("fcladv").Rows.Count - 1
                hidadvtemp = "<div style=""line-height:15px;""><a href = ""/fcl/" & key(dsadv.Tables("fcladv").Rows(iii)("sid")) & "_" & dsadv.Tables("fcladv").Rows(iii)("id") & ".html"" target=""_blank"">" & dsadv.Tables("fcladv").Rows(iii)("title") & "</a>" & "<br/>[" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "dd").ToString & " 至 " & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "dd").ToString & "]</div>##" & dsadv.Tables("fcladv").Rows(iii)("destport") & "##" & dsadv.Tables("fcladv").Rows(iii)("price_p45") & "/" & dsadv.Tables("fcladv").Rows(iii)("price_p100") & "/" & dsadv.Tables("fcladv").Rows(iii)("price_p300") & "/" & dsadv.Tables("fcladv").Rows(iii)("price_p500") & "/" & "" & dsadv.Tables("fcladv").Rows(iii)("price_p1000")
                If iii = 0 Then
                    dsadv1.Tables("fcladv").Rows.Add(dsadv.Tables("fcladv").Rows(iii).ItemArray)
                    hidadv = hidadvtemp
                Else
                    If (dsadv.Tables("fcladv").Rows(iii)("userid").ToString <> dsadv.Tables("fcladv").Rows(iii - 1)("userid").ToString) Then
                        dsadv1.Tables("fcladv").Rows.Add(dsadv.Tables("fcladv").Rows(iii).ItemArray)
                        hidadv = hidadv & "$|**|$" & hidadvtemp
                    Else
                        hidadv = hidadv & "$$" & hidadvtemp
                    End If

                End If
            Next


            Rptfcladv.DataSource = dsadv1.Tables("fcladv").DefaultView
            Rptfcladv.DataBind()

            Hidden2.Value = hidadv

            If dsadv.Tables("fcladv").Rows.Count > 0 Then
                PlaceHolder3.Visible = True
            End If




            sqladv_1 = "SELECT * FROM V_AIR_EFFECTIVE_ADV_BASIC_20110425 WHERE 1=1 "
            If startport <> "" Then
                If dsfrom.Tables("city").Rows.Count > 0 Then
                    sqladv_1 = sqladv_1 & "AND ("
                    For i As Integer = 0 To startportlist.Count - 1
                        If i = 0 Then
                            sqladv_1 = sqladv_1 & "startport like '%" & startportlist(i) & "%' "
                        Else
                            sqladv_1 = sqladv_1 & "OR startport like '%" & startportlist(i) & "%' "
                        End If
                    Next
                    sqladv_1 = sqladv_1 & ") "

                Else
                    sqladv_1 = sqladv_1 & "AND startport like '%" & startport & "%' "
                End If
            End If
            If destport <> "" Then
                If dsto.Tables("city2").Rows.Count > 0 Then
                    sqladv_1 = sqladv_1 & "AND ("
                    For i As Integer = 0 To destportlist.Count - 1
                        If i = 0 Then
                            sqladv_1 = sqladv_1 & "destport like '%" & destportlist(i) & "%' "
                        Else
                            sqladv_1 = sqladv_1 & "OR destport like '%" & destportlist(i) & "%' "
                        End If
                    Next
                    sqladv_1 = sqladv_1 & ") "
                Else
                    sqladv_1 = sqladv_1 & "AND destport like '%" & destport & "%' "
                End If
            End If

	    'Response.Write(sqladv_1)
            dsadv_1 = cn.mdb_ds(sqladv_1, "fcladv")
            dsadv1_1 = dsadv_1.Clone
            Dim hidadv_1 As String = ""
            Dim hidadvtemp_1 As String = ""

            For iii As Integer = 0 To dsadv_1.Tables("fcladv").Rows.Count - 1
                hidadvtemp_1 = "<div style=""line-height:15px;""><a href = ""/fcl/" & key(dsadv_1.Tables("fcladv").Rows(iii)("sid")) & "_" & dsadv_1.Tables("fcladv").Rows(iii)("id") & ".html"" target=""_blank"">" & dsadv_1.Tables("fcladv").Rows(iii)("title") & "</a>" & "<br/>[" & Format(dsadv_1.Tables("fcladv").Rows(iii)("postdate"), "yy").ToString & "/" & Format(dsadv_1.Tables("fcladv").Rows(iii)("postdate"), "MM").ToString & "/" & Format(dsadv_1.Tables("fcladv").Rows(iii)("postdate"), "dd").ToString & " 至 " & Format(dsadv_1.Tables("fcladv").Rows(iii)("enddate"), "yy").ToString & "/" & Format(dsadv_1.Tables("fcladv").Rows(iii)("enddate"), "MM").ToString & "/" & Format(dsadv_1.Tables("fcladv").Rows(iii)("enddate"), "dd").ToString & "]</div>##" & dsadv_1.Tables("fcladv").Rows(iii)("destport") & "##" & dsadv_1.Tables("fcladv").Rows(iii)("price_p45") & "/" & dsadv_1.Tables("fcladv").Rows(iii)("price_p100") & "/" & dsadv_1.Tables("fcladv").Rows(iii)("price_p300") & "/" & dsadv_1.Tables("fcladv").Rows(iii)("price_p500") & "/" & "" & dsadv_1.Tables("fcladv").Rows(iii)("price_p1000")
                If iii = 0 Then
                    dsadv1_1.Tables("fcladv").Rows.Add(dsadv_1.Tables("fcladv").Rows(iii).ItemArray)
                    hidadv_1 = hidadvtemp_1
                Else
                    If (dsadv_1.Tables("fcladv").Rows(iii)("userid").ToString <> dsadv_1.Tables("fcladv").Rows(iii - 1)("userid").ToString) Then
                        dsadv1_1.Tables("fcladv").Rows.Add(dsadv_1.Tables("fcladv").Rows(iii).ItemArray)
                        hidadv_1 = hidadv_1 & "$|**|$" & hidadvtemp_1
                    Else
                        hidadv_1 = hidadv_1 & "$$" & hidadvtemp_1
                    End If

                End If
            Next


            Rptfcladv_1.DataSource = dsadv1_1.Tables("fcladv").DefaultView
            Rptfcladv_1.DataBind()

            Hidden2_1.Value = hidadv_1

            If dsadv_1.Tables("fcladv").Rows.Count > 0 Then
		'Response.Write(dsadv1_1.Tables("fcladv").Rows.Count)
                PlaceHolder3_1.Visible = True
		'ltrBanner_1.Text = "<div class=""right_ad""><a href=""http://www.100allin.com/company/SGk0NTZQV2xPdHU3Ymh1aENmdEdEQT09/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/gc.jpg"" width=""200"" height=""150"" border=""0"" /></a></div>"
            End If


            '置顶结束

        End If

        Dim sqlconn As New Data.SqlClient.SqlConnection("Persist Security Info=False;Server=127.0.0.1;User ID=sasa;Password=SmNETEkwLzJNQmNoS;Database=DB_DataBase_new")
        'Dim sqlconn As New Data.SqlClient.SqlConnection("Persist Security Info=False;Server=127.0.0.1;User ID=sasa;Password=takeeasy822822;Database=DB_DataBase_new")
        Dim cmd As New Data.SqlClient.SqlCommand()
        cmd.Connection = sqlconn
        cmd.CommandText = "proc_searchAirFreight"
        cmd.CommandType = System.Data.CommandType.StoredProcedure
        Dim parameters() As Data.IDataParameter = { _
        New Data.SqlClient.SqlParameter("@sqlwords1", System.Data.SqlDbType.NVarChar, 2000), _
        New Data.SqlClient.SqlParameter("@sqlwords2", System.Data.SqlDbType.NVarChar, 2000), _
        New Data.SqlClient.SqlParameter("@sqlwords3", System.Data.SqlDbType.NVarChar, 2000), _
        New Data.SqlClient.SqlParameter("@sqlwords4", System.Data.SqlDbType.NVarChar, 2000), _
        New Data.SqlClient.SqlParameter("@sqlwords5", System.Data.SqlDbType.NVarChar, 2000), _
        New Data.SqlClient.SqlParameter("@history", System.Data.SqlDbType.Int, 4), _
        New Data.SqlClient.SqlParameter("@fcount1", System.Data.SqlDbType.Int, 4), _
        New Data.SqlClient.SqlParameter("@fcount2", System.Data.SqlDbType.Int, 4), _
        New Data.SqlClient.SqlParameter("@noeff", System.Data.SqlDbType.Int, 4) _
        }


        'Response.Write(sqlwords1)
        'Response.Write("<br /><br />")
        'Response.Write(sqlwords2)
        'Response.Write("<br /><br />")
        'Response.Write(sqlwords3)
        'Response.Write("<br /><br />")
        'Response.Write(sqlwords4)
        'Response.Write("<br /><br />")
        'Response.Write(sqlwords5)
        'Response.Write("<br /><br />")

        parameters(0).Value = sqlwords1
        parameters(1).Value = sqlwords2
        parameters(2).Value = sqlwords3
        parameters(3).Value = sqlwords4
        parameters(4).Value = sqlwords5
        parameters(5).Value = history
        parameters(6).Direction = System.Data.ParameterDirection.Output
        parameters(7).Direction = System.Data.ParameterDirection.Output
        parameters(8).Direction = System.Data.ParameterDirection.Output

        cmd.Parameters.Add(parameters(0))
        cmd.Parameters.Add(parameters(1))
        cmd.Parameters.Add(parameters(2))
        cmd.Parameters.Add(parameters(3))
        cmd.Parameters.Add(parameters(4))
        cmd.Parameters.Add(parameters(5))
        cmd.Parameters.Add(parameters(6))
        cmd.Parameters.Add(parameters(7))
        cmd.Parameters.Add(parameters(8))

        Dim dptest As New Data.SqlClient.SqlDataAdapter(cmd)
        Dim dstest As New Data.DataSet()

        dptest.Fill(dstest, "dstest")

        fakeitem = parameters(6).Value.ToString()
        items = parameters(7).Value.ToString()



        Rptair.DataSource = dstest.Tables("dstest").DefaultView
        Rptair.DataBind()

        sql = ""

        If history = "0" Then
            ltrMoreHistory.Text = "<a href=""/air/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-1----1.html""><img src= ""/images2/2011_fcl/history_freight.gif"" border=""0""/></a>"
            ltrMoreHistory1.Text = "<a href=""/air/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-1----1.html"">查看历史运价</a>"
            ltrMoreHistory2.Text = "有效运价"
        Else
            ltrMoreHistory1.Text = "您搜索的是历史运价，<a href=""/air/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-0----1.html"">查看有效运价</a>"
            ltrMoreHistory.Text = "<a href=""/air/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-0----1.html""><img src= ""/images2/2011_fcl/effective_freight.gif"" border=""0""/></a>"
            ltrMoreHistory2.Text = "历史运价"
        End If


        If parameters(8).Value.ToString() = 1 Then
            ltrMoreHistory1.Text = "没有搜索到有效运价，以下列表显示的是该港口历史运价供您参考"
            ltrMoreHistory2.Text = "历史运价"
        End If


        ''计算出页数
        'Dim items As Integer
        'items = ds.Tables("count").Rows(0)(0)

        'Dim fakeitem As Integer
        'fakeitem = ds2.Tables("count").Rows(0)(0)

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


        Dim base_url As String = "/air/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-" & history & "----"
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
            s = s + "<a href=""" + base_url + "1" + end_url + """><span><img src='/images/fcl/jt5.gif' width='9' height='9'  border=0 /></span></a> "
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


        If (startport.ToLower = "shanghai" Or startport = "上海" Or startport.ToLower = "sha" Or startport.ToLower = "pvg") Then
            ltrBanner.Text = "<div class=""right_ad""><a href=""http://www.100allin.com/company/cmdWTUtyQlZFVjRleXZiMkVxOHpmQT09/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/dz.gif"" width=""200"" height=""300"" border=""0"" /></a></div> <div class=""right_ad""><a href=""http://www.100allin.com/company/VVRwS29NK1V1ZGg4cUhrbXAxMi81QT09/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/yc.gif"" width=""200"" height=""225"" border=""0"" /></a></div>"
        Else
            ltrBanner.Text = "<div style=""padding-top:10px;overflow:hidden;""><a href=""/topic/air20110303/"" target=""_blank""><img src=""/images2/2011_fcl/kyzm.jpg"" border=""0"" /></a></div>"
        End If


        If (startport.ToLower = "beijing" Or startport = "北京" Or startport.ToLower = "bjs" Or startport.ToLower = "nay" Or startport.ToLower = "pek") Then
            ltrBanner.Text = "<div class=""right_ad""><a href=""http://www.100allin.com/company/Wk1vdUF0ZzBFeWlOVUlMTWV0TDNXUT09/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/jky.gif"" width=""200"" height=""300"" border=""0"" /></a></div>"
        End If
        'If (startport.ToLower = "shenzhen" Or startport = "深圳" Or startport.ToLower = "szx") Then
            'ltrBanner.Text = "<div class=""right_ad""><a href=""http://www.100allin.com/company/eEdnM1paa21nY3R3VGhHVUw1RUJHQT09/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/zj.gif"" width=""200"" height=""225"" border=""0"" /></a></div>"
        'End If

        'If (startport.ToLower = "hongkong" Or startport = "香港" Or startport.ToLower = "hkg") Then
            'ltrBanner.Text = "<div class=""right_ad""><a href=""http://www.100allin.com/company/cmxYVE1CYTFrN0hpQ1JqTDNMc3FUZz09/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/shuangsheng.gif"" width=""200"" height=""220"" border=""0"" /></a></div>"
        'End If



        If line <> "" Or startport <> "" Or destport <> "" Then '如果没有填写搜索条件，那么不记录搜索条件
            If cp = "1" Then '如果是第一页，那么开始记录搜索条件
                If items <= 0 Then '无结果，成功值置0
                    SaveSearchWords(line, startport, destport, 0)
                    phNoResult.Visible = True
                    Dim pm1 = New pm()
                    pm1.SaveSearchWords2("10", line, startport, destport, "", 0, "", "", "", "", "", "", "")
                Else
                    SaveSearchWords(line, startport, destport, 1)
                End If
            End If
        End If


        Try
            hotPort()
            'hydt()
        Catch ex As Exception

        End Try
    End Sub

    'Public Sub hydt()

    '    Dim sql As String = ""
    '    Dim ds As New Data.DataSet
    '    Dim cn As New data_conn

    '    '修饰起运港
    '    Dim sql_startport As String = ""

    '    sql = ""
    '    sql = sql + "select top 8  * from tb_bbs "
    '    sql = sql + "where types = 5 "
    '    sql = sql + "order by updatedate desc "



    '    'Response.Write(sql)

    '    If sql <> "" Then
    '        ds = cn.mdb_ds(sql, "yunjia")
    '        Repeater1.DataSource = ds.Tables("yunjia").DefaultView
    '        Repeater1.DataBind()
    '        If ds.Tables("yunjia").Rows.Count > 0 Then
    '            PlaceHolder2.Visible = True
    '        End If
    '    End If


    'End Sub


    Public Sub hotPort()

        Dim sql As String = ""
        Dim ds As New Data.DataSet
        Dim cn As New data_conn

        sql = ""
        sql = sql + "select * from TB_HOT_PORT "
        sql = sql + "where htype = 10 "
        sql = sql + "order by htype,horder "


        ds = cn.mdb_ds(sql, "yunjia")
        rptHotPort.DataSource = ds.Tables("yunjia").DefaultView
        rptHotPort.DataBind()


    End Sub


    Protected Sub SaveSearchWords(ByVal line As String, ByVal startport As String, ByVal destport As String, ByVal success As Integer)
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
            sql = sql & "10, "
            sql = sql & "'" & Now.ToString & "' "
            sql = sql & ")"
            cn.mdb_exe(sql)
        End If


        Try

        Catch ex As Exception

        End Try


    End Sub '保存搜索条件


    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        'If txtDestport.Text <> "" Then
        '    Response.Redirect("/air/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "--0-0-0-----1.html")
        'Else
        '    Response.Redirect("/air/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "--" & txtLine.SelectedIndex.ToString & "-0-0-----1.html")
        'End If

        If txtDestport.Text <> "" Then
            Response.Redirect("/air/list-" & txtStartport.Text.ToUpper & "-" & txtDestport.Text.ToUpper & "--0-0-0-" & hidHistroy.Value & "----1.html")
        Else
            Response.Redirect("/air/list-" & txtStartport.Text.ToUpper & "-" & txtDestport.Text.ToUpper & "--" & txtLine.SelectedIndex.ToString & "-0-0-" & hidHistroy.Value & "----1.html")
        End If

    End Sub

    Public Function key(ByVal es As String) As String
        Dim s As New SymmetricMethod
        Return s.Encrypto(es)
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

                a = Rptair.Items(0).FindControl("Label2")
                ids = a.Text
                For i = 1 To Rptair.Items.Count - 1
                    a = Rptair.Items(i).FindControl("Label2")
                    ids += "," + a.Text
                Next
                ds = conn.mdb_ds("select UserID,CompanyName,Realname,Phone,Fax,MovePhone,Usermsn,Userqq,UserEmail,star_adv_show_contact from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table")
                str = ""
                For i = 0 To Rptair.Items.Count - 1
                    Dim point As String = ""
                    Dim j As Integer
                    Dim count As Integer
                    a = Rptair.Items(i).FindControl("Label2")


                    If ds.Tables("table").Select("UserID=" + a.Text).Length = 1 Then

                        If ds.Tables("table").Select("UserID=" + a.Text)(0).Item("star_adv_show_contact").ToString() = "1" Then
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
                        End If
                    Else
                    End If
                    If i <> Rptair.Items.Count - 1 Then
                        str += "$|**|$"
                    End If
                Next
                Hiddenmm1.Value = str

            Else

                If Request.Cookies("user_id").Value.ToString = "" Then
                    Hiddennn1.Value = ""
                    a = Rptair.Items(0).FindControl("Label2")
                    ids = a.Text
                    For i = 1 To Rptair.Items.Count - 1
                        a = Rptair.Items(i).FindControl("Label2")
                        ids += "," + a.Text
                    Next
                    ds = conn.mdb_ds("select UserID,CompanyName,Realname,Phone,Fax,MovePhone,Usermsn,Userqq,UserEmail,star_adv_show_contact from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table")
                    str = ""
                    For i = 0 To Rptair.Items.Count - 1
                        Dim point As String = ""
                        Dim j As Integer
                        Dim count As Integer
                        a = Rptair.Items(i).FindControl("Label2")


                        If ds.Tables("table").Select("UserID=" + a.Text).Length = 1 Then

                            If ds.Tables("table").Select("UserID=" + a.Text)(0).Item("star_adv_show_contact").ToString() = "1" Then
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
                            End If
                        Else
                        End If
                        If i <> Rptair.Items.Count - 1 Then
                            str += "$|**|$"
                        End If
                    Next
                    Hiddenmm1.Value = str
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

    Protected Sub Rptfcladv_ItemCommand(ByVal sender As Object, ByVal e As EventArgs) Handles Rptfcladv.PreRender
        Dim ck As New check
        If Rptfcladv.Items.Count <> 0 Then
            Dim ds As Data.DataSet
            Dim conn As New data_conn
            Dim a As Label
            Dim i As Integer
            a = Rptfcladv.Items(0).FindControl("Label1")
            Dim ids As String = a.Text

            Dim str As String = ""

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            a = Rptfcladv.Items(0).FindControl("Label2")
            ids = a.Text
            For i = 1 To Rptfcladv.Items.Count - 1
                a = Rptfcladv.Items(i).FindControl("Label2")
                ids += "," + a.Text
            Next
            ds = conn.mdb_ds("select UserID,CompanyName,Realname,Phone,Fax,MovePhone,Usermsn,Userqq,UserEmail from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table")
            'Hiddennn1.Value = "select * from TB_User where UserID in (" + ids + ")"
            str = ""
            For i = 0 To Rptfcladv.Items.Count - 1
                Dim point As String = ""
                Dim j As Integer
                Dim count As Integer
                a = Rptfcladv.Items(i).FindControl("Label2")
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
                If i <> Rptfcladv.Items.Count - 1 Then
                    str += "$|**|$"
                End If
            Next
            Hiddennn2.Value = str


        End If

    End Sub

    Protected Sub Rptfcladv_1_ItemCommand(ByVal sender As Object, ByVal e As EventArgs) Handles Rptfcladv_1.PreRender
        Dim ck As New check
        If Rptfcladv_1.Items.Count <> 0 Then
            Dim ds As Data.DataSet
            Dim conn As New data_conn
            Dim a As Label
            Dim i As Integer
            a = Rptfcladv_1.Items(0).FindControl("Label1")
            Dim ids As String = a.Text

            Dim str As String = ""

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            a = Rptfcladv_1.Items(0).FindControl("Label2")
            ids = a.Text
            For i = 1 To Rptfcladv_1.Items.Count - 1
                a = Rptfcladv_1.Items(i).FindControl("Label2")
                ids += "," + a.Text
            Next
            ds = conn.mdb_ds("select UserID,CompanyName,Realname,Phone,Fax,MovePhone,Usermsn,Userqq,UserEmail from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table")
            'Hiddennn1.Value = "select * from TB_User where UserID in (" + ids + ")"
            str = ""
            For i = 0 To Rptfcladv_1.Items.Count - 1
                Dim point As String = ""
                Dim j As Integer
                Dim count As Integer
                a = Rptfcladv_1.Items(i).FindControl("Label2")
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
                If i <> Rptfcladv_1.Items.Count - 1 Then
                    str += "$|**|$"
                End If
            Next
            Hiddennn2_1.Value = str


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
