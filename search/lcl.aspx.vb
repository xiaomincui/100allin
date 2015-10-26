Partial Class search_lcl
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
    Public history As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Response.Write(Request.Url.ToString)
        If Not Page.IsPostBack Then
            If Not Request.QueryString("sp") Is Nothing Then
                '提取来自网页参数的搜索条件
                Dim GetRequest1 As New GetRequest
                sp = Request.QueryString("sp").ToString
                dp = Request.QueryString("dp").ToString
                dp = dp.Replace("$", "-") '还原港口名称中的“-”分隔符
                cr = Request.QueryString("cr").ToString
                l = Request.QueryString("l").ToString
                p = Request.QueryString("p").ToString
                order = Request.QueryString("order").ToString
                history = GetRequest1.GetRequestQueryString("history", "").ToString()

                If sp <> "" Then
                    ltrYouSearch.Text = "您搜索的是："
                End If

                If sp = "" And dp = "" And cr = "" And l = "0" Then
                    ltrYouSearch.Text = "所有运价"
                End If

                If sp <> "" And dp = "" And cr = "" And l = "0" Then
                    ltrYouSearch.Text = "搜索 """ & sp.ToUpper & """ 起运的运价"
                End If

                If sp <> "" And dp <> "" Then
                    If cr = "" Then
                        ltrYouSearch.Text = "搜索 """ & sp.ToUpper & """ 至 """ & dp.ToUpper & """ 的运价"
                    Else
                        ltrYouSearch.Text = "搜索 """ & sp.ToUpper & """ 至 """ & dp.ToUpper & """ 由 """ & cr.ToUpper & """ 承运的运价"
                    End If
                End If

                Dim agent As String
                agent = System.Web.HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT").ToString()

                If agent.ToLower.Contains("youdao") Or agent.ToLower.Contains("sogou") Or agent.ToLower.Contains("ahrefs") Then
                    sp = ""
                    dp = ""
                    cr = ""
                    l = "0"
                    p = "1"
                    order = "0"
                Else


                End If

                'hidStartport.Value = sp
                'hidDestport.Value = dp
                'hidCarrier.Value = cr
                'hidLine.Value = l
                'hidHistroy.Value = history
                ''Response.Write(hidHistroy.Value)

                ''起运港、目的港、航线搜索框，提取参数内容
                'txtStartport.Text = sp
                'txtDestport.Text = dp
                'txtCarrier.Text = cr

                '搜索条件保存在label控件内
                hidTxtStartport.Text = sp.ToUpper
                hidTxtDestport.Text = dp.ToUpper
                hidTxtCarrier.Text = cr.ToUpper


                Dim LineArray(10) As String
                LineArray(0) = ",0"
                LineArray(1) = "美加线,1"
                LineArray(2) = "非洲线,6"
                LineArray(3) = "中东印巴线,8"
                LineArray(4) = "中南美线,3"
                LineArray(5) = "欧地线,2"
                LineArray(6) = "日韩线,4"
                LineArray(7) = "近洋线,5"
                LineArray(8) = "澳洲线,7"
                LineArray(9) = "红海线,9"


                For i As Integer = 0 To 9
                    If LineArray(i).IndexOf(l) <> -1 And l <> "" Then
                        hidTxtLine.Text = LineArray(i).Split(",")(0)
                        TextBox1.Text = LineArray(i).Split(",")(0)

                        If sp <> "" And dp = "" And cr = "" And l <> "0" Then
                            ltrYouSearch.Text = "搜索 """ & sp.ToUpper & """ 起运的 """ & LineArray(i).Split(",")(0) & """ 运价"
                        End If
                    End If
                Next
                ''航线下拉框，提取参数内容
                'txtLine.SelectedIndex = l

                'hidTxtLine.Text = txtLine.SelectedValue
                ''If txtDestport.Text = "" Then

                ''End If

                'If sp = "" Then
                '    Label10.Visible = False
                'Else
                '    Label10.Visible = True
                'End If

                'If dp = "" Then
                '    Label11.Visible = False
                'Else
                '    Label11.Visible = True
                'End If

                'If cr = "" Then
                '    Label9.Visible = False
                'Else
                '    Label9.Visible = True
                'End If

                'If l = "0" Then
                '    Label12.Visible = False
                'Else
                '    Label12.Visible = True
                'End If

                '开始查询符合搜索条件的记录
                LoadRecord(p)
            Else
                '无搜索条件，查询所有记录
                'Label10.Visible = False
                'Label11.Visible = False
                'Label9.Visible = False
                'Label12.Visible = False
                LoadRecord("1")
            End If
        End If


        '生成筛选链接，包括起运港、航线、船公司的筛选
        lblLineHot.Text = ""
        lblStartportHot.Text = ""
        lblDesportHot.Text = ""

        Dim StartportHotArray(16) As String

        StartportHotArray(0) = "上海,shanghai,shang hai"
        StartportHotArray(1) = "宁波,ningbo,ning bo"
        StartportHotArray(2) = "深圳,shenzhen,shen zhen"
        StartportHotArray(3) = "青岛,qingdao,qing dao"
        StartportHotArray(4) = "天津,tianjin,tian jin"
        StartportHotArray(5) = "广州,guangzhou,guang zhuo"
        StartportHotArray(6) = "厦门,xiamen,xia men"
        StartportHotArray(7) = "大连,dalian,da lian"
        StartportHotArray(8) = "连云港,lianyungang,lian yun gang"
        StartportHotArray(9) = "南京,nanjing,nan jing"
        StartportHotArray(10) = "珠海,zhuhai,zhu hai"
        StartportHotArray(11) = "香港,hongkong,xiang gang"
        StartportHotArray(12) = "汕头,shantou,shan tou"
        StartportHotArray(13) = "福州,fuzhou,fu zhou"
        StartportHotArray(14) = "中山,zhongshan,zhong shan"
        StartportHotArray(15) = "防城,fangcheng,fang cheng"


        For i As Integer = 0 To 15
            If StartportHotArray(i).IndexOf(sp.ToLower) <> -1 And sp.ToLower <> "" Then
                lblStartportHot.Text = lblStartportHot.Text & "<li class=""current"">" & StartportHotArray(i).Split(",")(0) & "</li>"
            Else
                lblStartportHot.Text = lblStartportHot.Text & "<li><a href = ""/lcl/list-" & StartportHotArray(i).Split(",")(1) & "-" & dp & "-" & cr & "-" & l & "-0-0-----1.html"">" & StartportHotArray(i).Split(",")(0) & "</a></li>"
            End If
        Next

        If sp = "" Then
            lblStartportHot.Text = "<li class=""first current"">全部</li>" & lblStartportHot.Text
        Else
            lblStartportHot.Text = "<li class=""first""><a href = ""/lcl/list--" & dp & "-" & cr & "-" & l & "-0-0-----1.html"">全部</a></li>" & lblStartportHot.Text
        End If

        'Dim StartportOtherArray(11) As String

        'StartportOtherArray(0) = "营口,yingkou,ying kou"
        'StartportOtherArray(1) = "唐山,tangshan,tang shan"
        'StartportOtherArray(2) = "秦皇岛,qinhuangdao,qin huang dao"
        'StartportOtherArray(3) = "烟台,yantai,yan tai"
        'StartportOtherArray(4) = "日照,rizhao,ri zhao"
        'StartportOtherArray(5) = "江门,jiangmen,jiang men"
        'StartportOtherArray(6) = "泉州,quanzhou,quan zhou"
        'StartportOtherArray(7) = "镇江,zhenjiang,zhen jiang"
        'StartportOtherArray(8) = "湛江,zhanjiang,zhan jiang"
        'StartportOtherArray(9) = "澳门,macao,ao men"
        'StartportOtherArray(10) = "三亚,sanya,san ya"

        'For j As Integer = 0 To 10
        '    If StartportOtherArray(j).IndexOf(sp) <> -1 And sp <> "" Then
        '        lblStartportHot.Text = lblStartportHot.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & StartportOtherArray(j).Split(",")(0) & "</b>"
        '    End If
        'Next

        'lblStartportHot.Text = lblStartportHot.Text + "&nbsp;&nbsp;" + "<a href=""javascript:;"" id=""linkmore"" onclick=""showmore('" + dp + "','" + cr + "','" + l + "');"">更多...</a>"

        LoadOtherDestPort()

        'For i As Integer = 0 To dsdestport.Tables("city").Rows.Count - 1
        '    lblDesportHot.Text = lblDesportHot.Text + "&nbsp;&nbsp;" + dsdestport.Tables("city").Rows(i)("citynamech").ToString
        'Next

        ''Response.Write(sqldestport)

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
            If LineHotArray(i).IndexOf(l) <> -1 And l <> "" Then
                If l = 0 Then
                    lblLineHot.Text = lblLineHot.Text & "<li class = ""first current"">" & LineHotArray(i).Split(",")(0) & "</li>"
                Else
                    lblLineHot.Text = lblLineHot.Text & "<li class = ""current"">" & LineHotArray(i).Split(",")(0) & "</li>"
                End If
            Else
                If i = 0 Then
                    lblLineHot.Text = lblLineHot.Text & "<li class=""first""><a href = ""/lcl/list-" & sp & "-" & dp & "-" & cr & "-" & LineHotArray(i).Split(",")(1) & "-0-0-----1.html"">" & LineHotArray(i).Split(",")(0) & "</a></li>"
                Else
                    lblLineHot.Text = lblLineHot.Text & "<li><a href = ""/lcl/list-" & sp & "-" & dp & "-" & cr & "-" & LineHotArray(i).Split(",")(1) & "-0-0-----1.html"">" & LineHotArray(i).Split(",")(0) & "</a></li>"
                End If

            End If
        Next




        'SEO部分，开始
        Dim seo_sp As String = sp
        Dim seo_sp_array(26) As String

        seo_sp_array(0) = "上海,shanghai,shang hai"
        seo_sp_array(1) = "宁波,ningbo,ning bo"
        seo_sp_array(2) = "深圳,shenzhen,shen zhen"
        seo_sp_array(3) = "青岛,qingdao,qing dao"
        seo_sp_array(4) = "天津,tianjin,tian jin"
        seo_sp_array(5) = "广州,guangzhou,guang zhuo"
        seo_sp_array(6) = "厦门,xiamen,xia men"
        seo_sp_array(7) = "大连,dalian,da lian"
        seo_sp_array(8) = "连云港,lianyungang,lian yun gang"
        seo_sp_array(9) = "南京,nanjing,nan jing"
        seo_sp_array(10) = "珠海,zhuhai,zhu hai"
        seo_sp_array(11) = "香港,hongkong,xiang gang"
        seo_sp_array(12) = "汕头,shantou,shan tou"
        seo_sp_array(13) = "福州,fuzhou,fu zhou"
        seo_sp_array(14) = "中山,zhongshan,zhong shan"
        seo_sp_array(15) = "防城,fangcheng,fang cheng"
        seo_sp_array(16) = "营口,yingkou,ying kou"
        seo_sp_array(17) = "唐山,tangshan,tang shan"
        seo_sp_array(18) = "秦皇岛,qinhuangdao,qin huang dao"
        seo_sp_array(19) = "烟台,yantai,yan tai"
        seo_sp_array(20) = "日照,rizhao,ri zhao"
        seo_sp_array(21) = "江门,jiangmen,jiang men"
        seo_sp_array(22) = "泉州,quanzhou,quan zhou"
        seo_sp_array(23) = "镇江,zhenjiang,zhen jiang"
        seo_sp_array(24) = "湛江,zhanjiang,zhan jiang"
        seo_sp_array(25) = "澳门,macao,ao men"
        seo_sp_array(26) = "三亚,sanya,san ya"

        For k As Integer = 0 To 26
            If seo_sp_array(k).IndexOf(sp) <> -1 And sp <> "" Then
                seo_sp = seo_sp_array(k).Split(",")(0)
            End If
        Next

        Dim seo_dp As String = ""
        Dim seo_dp1 As String = ""
        Dim seo_dp2 As String = ""
        Dim seo_dp3 As String = ""
        If dp <> "" Then
            seo_dp = "到" + dp + "的"
            seo_dp1 = "至" + dp + "的"
            seo_dp2 = dp + "的"
            seo_dp3 = "-" + dp + "的"
        End If

        Dim seo_cr As String = ""
        seo_cr = cr

        Dim seo_l As String = ""
        Dim lkeywordsarray(10) As String
        lkeywordsarray(0) = "全部"
        lkeywordsarray(1) = "美加线"
        lkeywordsarray(2) = "欧地线"
        lkeywordsarray(3) = "中南美线"
        lkeywordsarray(4) = "日韩线"
        lkeywordsarray(5) = "近洋线"
        lkeywordsarray(6) = "非洲线"
        lkeywordsarray(7) = "澳洲线"
        lkeywordsarray(8) = "中东印巴线"
        lkeywordsarray(9) = "红海线"

        If l <> "0" Then
            seo_l = lkeywordsarray(CInt(l))
        End If

        Dim seo_keywords As String = ""

        seo_keywords = "拼箱 运费 运价"

        If sp <> "" Then
            seo_keywords = seo_keywords & " " & seo_sp
        End If

        If dp <> "" Then
            seo_keywords = seo_keywords & " " & dp
        End If

        If l <> 0 Then
            seo_keywords = seo_keywords & " " & seo_l
        End If

        If cr <> "" Then
            seo_keywords = seo_keywords & " " & cr
        End If


        If sp = "" And dp = "" And l = "0" And cr = "" Then

        Else
            Literal1.Text = "<title>" & seo_sp & seo_dp & seo_l & seo_cr & "拼箱运费," & seo_sp & seo_dp1 & seo_l & seo_cr & "拼箱运价发布," & seo_sp & seo_dp2 & seo_l & seo_cr & "拼箱价格-环球运费网" & "</title>"
            Literal2.Text = "<meta name=""keywords"" content=""" & seo_keywords & """ />"
            Literal3.Text = "<meta name=""description"" content=""" & seo_sp & seo_dp & seo_l & seo_cr & "拼箱价格," & seo_sp & seo_dp1 & seo_l & seo_cr & "拼箱运费查询," & seo_sp & seo_dp2 & seo_l & seo_cr & "拼箱价格信息," & seo_sp & seo_dp3 & seo_l & seo_cr & "拼箱订舱,环球运费网" & """ />"
        End If


        'SEO部分，结束


        Dim lorder1 As String = "<li class=""first""><a href=""/lcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-0-0-----1.html"">最新</a></li>"
        If order = 0 Then
            lorder1 = "<li class=""current first""><a href=""/lcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-0-0-----1.html"">最新</a></li>"
        End If



        lblOrder.Text = lorder1

        If dp = "" And cr = "" Then
            lblOrder.Text = lorder1
        End If
    End Sub

    '载入列表信息
    Sub LoadRecord(ByVal page As String)

        Dim ck As New check
        '取搜索条件，搜索条件保存在隐藏的label内
        Dim line As String = ck.CheckInput(hidTxtLine.Text)
        Dim startport As String = ck.CheckInput(hidTxtStartport.Text)
        Dim carrier As String = ck.CheckInput(hidTxtCarrier.Text)
        page = ck.CheckInput(page)


        If startport <> "" Then
            startport = startport.Split(",")(0)
        End If
        Dim destport As String = ck.CheckInput(hidTxtDestport.Text)
        If destport <> "" Then
            line = ""
        End If

        Dim cn As New data_conn
        Dim ds As New Data.DataSet
        Dim sql As String = ""

        sql = "select ratesimple from TB_NEWRATE"
        ds = cn.mdb_ds(sql, "rate")

        Dim ratexxs(4) As String

        Dim ratexx As String
        ratexx = ds.Tables("rate").Rows(0)(0).ToString()

        ratexxs = ratexx.Split("|")

        sql = ""
        ltrRate1.Text = (Convert.ToDouble(ratexxs(0)) / 100).ToString()
        ltrRate2.Text = (100 / Convert.ToDouble(ratexxs(0))).ToString("f4")

        sql = "select top 8 "
        sql = sql + "id,title,postdate "
        sql = sql + "FROM TB_BBS WHERE (types = 5) ORDER BY Postdate DESC "
        ds = cn.mdb_ds(sql, "bbs")
        RptaHangYunDongTai.DataSource = ds.Tables("bbs").DefaultView
        RptaHangYunDongTai.DataBind()



        'item是(页码-1)x10，用来计算分页用
        Dim item As Integer
        item = CInt(page - 1) * 15


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

        If ds.Tables("city").Rows.Count > 0 Then
            city0 = ds.Tables("city").Rows(0)(0).ToString
            city1 = ds.Tables("city").Rows(0)(1).ToString
        End If

        '提取目的港的中英文名称
        Dim sqlto As String
        sqlto = ""
        sqlto = sqlto & "SELECT cityname, citynamech,line "
        sqlto = sqlto & "FROM TB_CITY "
        sqlto = sqlto & "WHERE "
        sqlto = sqlto & "cityname = '" & destport & "' "
        sqlto = sqlto & "OR citynamech = '" & destport & "' "
        ds = cn.mdb_ds(sqlto, "dcity")

        Dim city3 As String = ""
        Dim city4 As String = ""
        Dim line1 As String = ""


        Dim dcitycount As Integer = ds.Tables("dcity").Rows.Count

        If ds.Tables("dcity").Rows.Count > 0 Then
            city3 = ds.Tables("dcity").Rows(0)(0).ToString
            city4 = ds.Tables("dcity").Rows(0)(1).ToString
            line1 = ds.Tables("dcity").Rows(0)(2).ToString
        End If


        '提取船公司的中英文名称
        Dim sqlcr As String
        sqlcr = ""
        sqlcr = sqlcr & "SELECT cname, ccname "
        sqlcr = sqlcr & "FROM TB_CARRIER "
        sqlcr = sqlcr & "WHERE "
        sqlcr = sqlcr & "cname = '" & carrier & "' "
        sqlcr = sqlcr & "OR ccname = '" & carrier & "' "
        ds = cn.mdb_ds(sqlcr, "carrier")

        Dim carrier0 As String = ""
        Dim carrier1 As String = ""

        Dim carriercount As Integer = ds.Tables("carrier").Rows.Count

        If ds.Tables("carrier").Rows.Count > 0 Then
            carrier0 = ds.Tables("carrier").Rows(0)(0).ToString
            carrier1 = ds.Tables("carrier").Rows(0)(1).ToString
        End If

        Dim sqladv As String = ""
        Dim dsadv As New Data.DataSet
        Dim dsadv1 As New Data.DataSet

        Dim dsfreight As New Data.DataSet

        Dim item_count As Integer = 0
        Dim fakeitem As Integer = 0
        Dim sqlwords1 As String = "" 'sqlwords1和sqlwords2是为查询有效运价的脚本
        Dim sqlwords2 As String = ""
        Dim sqlwords3 As String = "" 'sqlwords3是为查询历史运价的脚本
        Dim sqlwords4 As String = "" 'sqlwords4是为统计有效运价的脚本
        Dim sqlwords5 As String = "" 'sqlwords5是为统计历史运价条数的脚本
        Dim sqlwords6 As String = "" 'sqlwords6是为统计历史运价文件数的脚本

        If dp = "" And cr = "" Then
            sqlwords1 = sqlwords1 & "insert #Tmp (yunjiainfoid,userid,postdate,limit) ("
            sqlwords1 = sqlwords1 & "select yunjiaid,TB_Yunjia_Effective_9.userid,postdate,show_limit_fcl as limit from TB_Yunjia_Effective_9,TB_user "
            sqlwords1 = sqlwords1 & "where 1=1 AND TB_Yunjia_Effective_9.ifpass = 1 AND TB_Yunjia_Effective_9.userid = TB_user.userid "
            If line <> "" Then
                sqlwords1 = sqlwords1 & "AND hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                If citycount > 0 Then
                    sqlwords1 = sqlwords1 & "AND (startport like '%" & city0 & "%' "
                    sqlwords1 = sqlwords1 & "OR startport like '%" & city1 & "%') "
                Else
                    sqlwords1 = sqlwords1 & "AND startport like '%" & startport & "%' "
                End If
            End If
            sqlwords1 = sqlwords1 & ")"

            sqlwords2 = sqlwords2 & "select T1.yunjiaid as sid,"
            sqlwords2 = sqlwords2 & "'0' as id,"
            sqlwords2 = sqlwords2 & "title as title,"
            sqlwords2 = sqlwords2 & "pricegp1 as pricegp,"
            sqlwords2 = sqlwords2 & "pricegpv1 as pricegpv,"
            sqlwords2 = sqlwords2 & "shipcompany1 as shipcompany,"
            sqlwords2 = sqlwords2 & "hangxianmiaoshu,"
            sqlwords2 = sqlwords2 & "startport,"
            sqlwords2 = sqlwords2 & "destport1 as destport,"
            sqlwords2 = sqlwords2 & "star_allin,"
            sqlwords2 = sqlwords2 & "star_user,"
            sqlwords2 = sqlwords2 & "assurance,"
            sqlwords2 = sqlwords2 & "T1.userid as userid,"
            sqlwords2 = sqlwords2 & "T2.companyname as companyname,"
            sqlwords2 = sqlwords2 & "T1.postdate as postdate,"
            sqlwords2 = sqlwords2 & "T1.enddate as enddate "
            sqlwords2 = sqlwords2 & "from TB_Yunjia_Effective_9 T1,tb_user T2,(select top 15 * from #Tmp2 where yunjiainfoid not in (select top " & item.ToString & " yunjiainfoid from #Tmp2 order by postdate desc,yunjiainfoid desc) order by postdate desc,yunjiainfoid desc) T3 where T1.yunjiaid=T3.yunjiainfoid and T2.userid = T3.userid order by T3.postdate desc,yunjiainfoid desc"


            sqlwords3 = "select top 15 "
            sqlwords3 = sqlwords3 & "sid,id,startport,title,hangxianmiaoshu,hits,destport,pricegp,pricegpv,shipcompany,assurance,"
            sqlwords3 = sqlwords3 & "userid,"
            sqlwords3 = sqlwords3 & "companyname,"
            sqlwords3 = sqlwords3 & "star_allin,"
            sqlwords3 = sqlwords3 & "star_user,"
            sqlwords3 = sqlwords3 & "postdate,"
            sqlwords3 = sqlwords3 & "enddate "
            sqlwords3 = sqlwords3 & "FROM (SELECT "
            sqlwords3 = sqlwords3 & "tb_yunjia.id as sid,'0' as id,tb_yunjia.startport as startport,tb_yunjia.title,tb_yunjia.hangxianmiaoshu,tb_yunjia.hits,tb_yunjia.DestPort1 as destport,tb_yunjia.assurance as assurance, "
            sqlwords3 = sqlwords3 & "tb_yunjia.pricegp1 as pricegp,"
            sqlwords3 = sqlwords3 & "tb_yunjia.pricegpv1 as pricegpv,"
            sqlwords3 = sqlwords3 & "tb_yunjia.shipcompany1 as shipcompany,"
            sqlwords3 = sqlwords3 & "tb_user.userid,"
            sqlwords3 = sqlwords3 & "tb_user.companyname,"
            sqlwords3 = sqlwords3 & "tb_user.star_allin,"
            sqlwords3 = sqlwords3 & "tb_user.star_user,"
            sqlwords3 = sqlwords3 & "tb_yunjia.postdate,"
            sqlwords3 = sqlwords3 & "tb_yunjia.enddate "
            sqlwords3 = sqlwords3 & "FROM "
            sqlwords3 = sqlwords3 & "tb_yunjia,tb_user "
            sqlwords3 = sqlwords3 & "WHERE "
            sqlwords3 = sqlwords3 & "1=1 AND yunjialeixing = 9 AND tb_user.userid = tb_yunjia.userid AND tb_yunjia.enddate < (GETDATE()-15) "
            If line <> "" Then
                sqlwords3 = sqlwords3 & "AND tb_yunjia.hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                If citycount > 0 Then
                    sqlwords3 = sqlwords3 & "AND (startport like '%" & city0 & "%' "
                    sqlwords3 = sqlwords3 & "OR startport like '%" & city1 & "%') "
                Else
                    sqlwords3 = sqlwords3 & "AND startport like '%" & startport & "%' "
                End If
            End If
            sqlwords3 = sqlwords3 & ") AS T "
            sqlwords3 = sqlwords3 & "WHERE sid NOT IN "
            sqlwords3 = sqlwords3 & "(SELECT id FROM"
            sqlwords3 = sqlwords3 & "(SELECT TOP " & item.ToString & " tb_yunjia.id AS id "
            sqlwords3 = sqlwords3 & "FROM "
            sqlwords3 = sqlwords3 & "tb_yunjia,tb_user "
            sqlwords3 = sqlwords3 & "WHERE "
            sqlwords3 = sqlwords3 & "1=1 AND yunjialeixing = 9 AND tb_user.userid = tb_yunjia.userid AND tb_yunjia.enddate < (GETDATE()-15) "
            If line <> "" Then
                sqlwords3 = sqlwords3 & "AND tb_yunjia.hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                If citycount > 0 Then
                    sqlwords3 = sqlwords3 & "AND (startport like '%" & city0 & "%' "
                    sqlwords3 = sqlwords3 & "OR startport like '%" & city1 & "%') "
                Else
                    sqlwords3 = sqlwords3 & "AND startport like '%" & startport & "%' "
                End If
            End If
            sqlwords3 = sqlwords3 & "ORDER BY tb_yunjia.postdate DESC,tb_yunjia.id desc "
            sqlwords3 = sqlwords3 & ") AS T "
            sqlwords3 = sqlwords3 & ") "
            sqlwords3 = sqlwords3 & "ORDER BY postdate DESC,sid DESC "


            sqlwords4 = sqlwords4 & "insert into #TMP3 (fcount1) (select count(*) as fcount1 from TB_YunjiaInfo_Effective_9 "
            sqlwords4 = sqlwords4 & "where 1=1 "
            If line <> "" Then
                sqlwords4 = sqlwords4 & "AND hangxianmiaoshux = '" & line & "' "
            End If
            If startport <> "" Then
                If citycount > 0 Then
                    sqlwords4 = sqlwords4 & "AND (startportx like '%" & city0 & "%' "
                    sqlwords4 = sqlwords4 & "OR startportx like '%" & city1 & "%') "
                Else
                    sqlwords4 = sqlwords4 & "AND startportx like '%" & startport & "%' "
                End If
            End If
            sqlwords4 = sqlwords4 & ") "

            sqlwords5 = sqlwords5 & "insert into #TMP3 (fcount1) (select count(*) as fcount1 from TB_YunJiaInfo "
            sqlwords5 = sqlwords5 & "where yunjialeixingx = 9 AND TB_YunJiaInfo.enddatex < (GETDATE()-15) "
            If line <> "" Then
                sqlwords5 = sqlwords5 & "AND hangxianmiaoshux = '" & line & "' "
            End If
            If startport <> "" Then
                If citycount > 0 Then
                    sqlwords5 = sqlwords5 & "AND (startportx like '%" & city0 & "%' "
                    sqlwords5 = sqlwords5 & "OR startportx like '%" & city1 & "%') "
                Else
                    sqlwords5 = sqlwords5 & "AND startportx like '%" & startport & "%' "
                End If
            End If
            sqlwords5 = sqlwords5 & ") "

            If line <> "" Then
                '置顶开始
                sqladv = "SELECT * FROM V_LCL_EFFECTIVE_ADV_LIST_20100804 WHERE 1=1 "
                sqladv = sqladv & "AND hangxianmiaoshu = '" & line & "' "
                If startport <> "" Then
                    If citycount > 0 Then
                        sqladv = sqladv & "AND (startport like '%" & city0 & "%' "
                        sqladv = sqladv & "OR startport like '%" & city1 & "%') "
                    Else
                        sqladv = sqladv & "AND startport like '%" & startport & "%' "
                    End If
                End If
                dsadv = cn.mdb_ds(sqladv, "fcladv")
                dsadv1 = dsadv.Clone
                Dim hidadv As String = ""
                Dim hidadvtemp As String = ""

                For iii As Integer = 0 To dsadv.Tables("fcladv").Rows.Count - 1
                    hidadvtemp = "<div style=""line-height:15px;""><a href = ""/lcl/" & key(dsadv.Tables("fcladv").Rows(iii)("sid")) & "_0.html"" target=""_blank"">" & dsadv.Tables("fcladv").Rows(iii)("title") & "</a>" & "<br/>[" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "dd").ToString & " 至 " & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "dd").ToString & "]</div>##" & dsadv.Tables("fcladv").Rows(iii)("destport") & "##" & dsadv.Tables("fcladv").Rows(iii)("pricegp") & "/" & dsadv.Tables("fcladv").Rows(iii)("pricegpv") & "##" & "" & dsadv.Tables("fcladv").Rows(iii)("shipcompany")
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

                'Response.Write(sqladv)
                Rptfcladv.DataSource = dsadv1.Tables("fcladv").DefaultView
                Rptfcladv.DataBind()



                '置顶结束
            End If
        Else

            sqlwords1 = sqlwords1 & "insert #Tmp (yunjiainfoid,userid,postdate,limit) ("
            sqlwords1 = sqlwords1 & "select yunjiainfoid,TB_YunjiaInfo_Effective_9.useridx as userid,postdatex as postdate,show_limit_fcl as limit from TB_YunjiaInfo_Effective_9,TB_user "
            sqlwords1 = sqlwords1 & "where TB_YunjiaInfo_Effective_9.useridx = TB_user.userid AND 1=1 "
            If startport <> "" Then
                If citycount > 0 Then
                    sqlwords1 = sqlwords1 & "AND (startportx like '%" & city0 & "%' "
                    sqlwords1 = sqlwords1 & "OR startportx like '%" & city1 & "%') "
                Else
                    sqlwords1 = sqlwords1 & "AND startportx like '%" & startport & "%' "
                End If
            End If
            If destport <> "" Then
                If dcitycount > 0 Then
                    sqlwords1 = sqlwords1 & "AND (destport like '%" & city3 & "%' "
                    sqlwords1 = sqlwords1 & "OR destport like '%" & city4 & "%') "
                Else
                    sqlwords1 = sqlwords1 & "AND destport like '%" & destport & "%' "
                End If
            End If
            If carrier <> "" Then
                If carriercount > 0 Then
                    sqlwords1 = sqlwords1 & "AND (shipcompany like '%" & carrier0 & "%' "
                    sqlwords1 = sqlwords1 & "OR shipcompany like '%" & carrier1 & "%') "
                Else
                    sqlwords1 = sqlwords1 & "AND shipcompany like '%" & carrier & "%' "
                End If
            End If
            sqlwords1 = sqlwords1 & ")"

            sqlwords2 = sqlwords2 & "select T1.yunjiaid as sid,"
            sqlwords2 = sqlwords2 & "T1.yunjiainfoid as id,"
            sqlwords2 = sqlwords2 & "titlex as title,"
            sqlwords2 = sqlwords2 & "pricegp as pricegp,"
            sqlwords2 = sqlwords2 & "pricegpv as pricegpv,"
            sqlwords2 = sqlwords2 & "shipcompany as shipcompany,"
            sqlwords2 = sqlwords2 & "hangxianmiaoshux as hangxianmiaoshu,"
            sqlwords2 = sqlwords2 & "startportx as startport,"
            sqlwords2 = sqlwords2 & "T1.destport,"
            sqlwords2 = sqlwords2 & "star_allin,"
            sqlwords2 = sqlwords2 & "star_user,"
            sqlwords2 = sqlwords2 & "T1.assurance,"
            sqlwords2 = sqlwords2 & "T1.useridx as userid,"
            sqlwords2 = sqlwords2 & "T2.companyname as companyname,"
            sqlwords2 = sqlwords2 & "T1.postdatex as postdate,"
            sqlwords2 = sqlwords2 & "T1.enddatex as enddate "
            sqlwords2 = sqlwords2 & "from TB_YunjiaInfo_Effective_9 T1,tb_user T2,(select top 15 * from #Tmp2 where yunjiainfoid not in (select top " & item.ToString & " yunjiainfoid from #Tmp2 order by postdate desc,yunjiainfoid desc) order by postdate desc,yunjiainfoid desc) T3 where T1.yunjiainfoid=T3.yunjiainfoid and T2.userid = T3.userid order by T3.postdate desc,T3.yunjiainfoid desc"

            sqlwords3 = "select top 15 "
            sqlwords3 = sqlwords3 & "sid,id,startport,title,hangxianmiaoshu,hits,destport,pricegp,pricegpv,shipcompany,assurance,"
            sqlwords3 = sqlwords3 & "userid,"
            sqlwords3 = sqlwords3 & "companyname,"
            sqlwords3 = sqlwords3 & "star_allin,"
            sqlwords3 = sqlwords3 & "star_user,"
            sqlwords3 = sqlwords3 & "postdate,"
            sqlwords3 = sqlwords3 & "enddate "
            sqlwords3 = sqlwords3 & "FROM (SELECT "
            sqlwords3 = sqlwords3 & "TB_YunJiaInfo.yunjiaid as sid,TB_YunJiaInfo.id as id,startportx as startport,titlex as title,hangxianmiaoshux as hangxianmiaoshu,infohits as hits,destport,assurance, "
            sqlwords3 = sqlwords3 & "pricegp,"
            sqlwords3 = sqlwords3 & "pricegpv,"
            sqlwords3 = sqlwords3 & "shipcompany,"
            sqlwords3 = sqlwords3 & "tb_user.userid,"
            sqlwords3 = sqlwords3 & "tb_user.companyname,"
            sqlwords3 = sqlwords3 & "tb_user.star_allin,"
            sqlwords3 = sqlwords3 & "tb_user.star_user,"
            sqlwords3 = sqlwords3 & "postdatex as postdate,"
            sqlwords3 = sqlwords3 & "enddatex as enddate "
            sqlwords3 = sqlwords3 & "FROM "
            sqlwords3 = sqlwords3 & "TB_YunJiaInfo,tb_user "
            sqlwords3 = sqlwords3 & "WHERE "
            sqlwords3 = sqlwords3 & "1=1 AND yunjialeixingx = 9 AND tb_user.userid = TB_YunJiaInfo.useridx AND TB_YunJiaInfo.enddatex < (GETDATE()-15) "
            If startport <> "" Then
                If citycount > 0 Then
                    sqlwords3 = sqlwords3 & "AND (startportx like '%" & city0 & "%' "
                    sqlwords3 = sqlwords3 & "OR startportx like '%" & city1 & "%') "
                Else
                    sqlwords3 = sqlwords3 & "AND startportx like '%" & startport & "%' "
                End If
            End If
            If destport <> "" Then
                If dcitycount > 0 Then
                    sqlwords3 = sqlwords3 & "AND (destport like '%" & city3 & "%' "
                    sqlwords3 = sqlwords3 & "OR destport like '%" & city4 & "%') "
                Else
                    sqlwords3 = sqlwords3 & "AND destport like '%" & destport & "%' "
                End If
            End If
            If carrier <> "" Then
                If carriercount > 0 Then
                    sqlwords3 = sqlwords3 & "AND (shipcompany like '%" & carrier0 & "%' "
                    sqlwords3 = sqlwords3 & "OR shipcompany like '%" & carrier1 & "%') "
                Else
                    sqlwords3 = sqlwords3 & "AND shipcompany like '%" & carrier & "%' "
                End If
            End If
            sqlwords3 = sqlwords3 & ") AS T "
            sqlwords3 = sqlwords3 & "WHERE id NOT IN "
            sqlwords3 = sqlwords3 & "(SELECT TOP " & item.ToString & " TB_YunJiaInfo.id AS id "
            sqlwords3 = sqlwords3 & "FROM "
            sqlwords3 = sqlwords3 & "TB_YunJiaInfo,tb_user "
            sqlwords3 = sqlwords3 & "WHERE "
            sqlwords3 = sqlwords3 & "1=1 AND yunjialeixingx = 9 AND tb_user.userid = TB_YunJiaInfo.useridx AND TB_YunJiaInfo.enddatex < (GETDATE()-15) "
            If startport <> "" Then
                If citycount > 0 Then
                    sqlwords3 = sqlwords3 & "AND (startportx like '%" & city0 & "%' "
                    sqlwords3 = sqlwords3 & "OR startportx like '%" & city1 & "%') "
                Else
                    sqlwords3 = sqlwords3 & "AND startportx like '%" & startport & "%' "
                End If
            End If
            If destport <> "" Then
                If dcitycount > 0 Then
                    sqlwords3 = sqlwords3 & "AND (destport like '%" & city3 & "%' "
                    sqlwords3 = sqlwords3 & "OR destport like '%" & city4 & "%') "
                Else
                    sqlwords3 = sqlwords3 & "AND destport like '%" & destport & "%' "
                End If
            End If
            If carrier <> "" Then
                If carriercount > 0 Then
                    sqlwords3 = sqlwords3 & "AND (shipcompany like '%" & carrier0 & "%' "
                    sqlwords3 = sqlwords3 & "OR shipcompany like '%" & carrier1 & "%') "
                Else
                    sqlwords3 = sqlwords3 & "AND shipcompany like '%" & carrier & "%' "
                End If
            End If
            sqlwords3 = sqlwords3 & "ORDER BY postdatex DESC,id DESC "
            sqlwords3 = sqlwords3 & ") "
            sqlwords3 = sqlwords3 & "ORDER BY postdate DESC,id DESC "

            sqlwords4 = sqlwords4 & "insert into #TMP3 (fcount1) (select count(*) as fcount1 from TB_YunjiaInfo_Effective_9 "
            sqlwords4 = sqlwords4 & "where 1=1 "
            If startport <> "" Then
                If citycount > 0 Then
                    sqlwords4 = sqlwords4 & "AND (startportx like '%" & city0 & "%' "
                    sqlwords4 = sqlwords4 & "OR startportx like '%" & city1 & "%') "
                Else
                    sqlwords4 = sqlwords4 & "AND startportx like '%" & startport & "%' "
                End If
            End If
            If destport <> "" Then
                If dcitycount > 0 Then
                    sqlwords4 = sqlwords4 & "AND (destport like '%" & city3 & "%' "
                    sqlwords4 = sqlwords4 & "OR destport like '%" & city4 & "%') "
                Else
                    sqlwords4 = sqlwords4 & "AND destport like '%" & destport & "%' "
                End If
            End If
            If carrier <> "" Then
                If carriercount > 0 Then
                    sqlwords4 = sqlwords4 & "AND (shipcompany like '%" & carrier0 & "%' "
                    sqlwords4 = sqlwords4 & "OR shipcompany like '%" & carrier1 & "%') "
                Else
                    sqlwords4 = sqlwords4 & "AND shipcompany like '%" & carrier & "%' "
                End If
            End If
            sqlwords4 = sqlwords4 & ") "

            sqlwords5 = sqlwords5 & "insert into #TMP3 (fcount1) (select count(*) as fcount1 from TB_YunJiaInfo "
            sqlwords5 = sqlwords5 & "where yunjialeixingx = 9 AND enddatex < (GETDATE()-15) "
            If startport <> "" Then
                If citycount > 0 Then
                    sqlwords5 = sqlwords5 & "AND (startportx like '%" & city0 & "%' "
                    sqlwords5 = sqlwords5 & "OR startportx like '%" & city1 & "%') "
                Else
                    sqlwords5 = sqlwords5 & "AND startportx like '%" & startport & "%' "
                End If
            End If
            If destport <> "" Then
                If dcitycount > 0 Then
                    sqlwords5 = sqlwords5 & "AND (destport like '%" & city3 & "%' "
                    sqlwords5 = sqlwords5 & "OR destport like '%" & city4 & "%') "
                Else
                    sqlwords5 = sqlwords5 & "AND destport like '%" & destport & "%' "
                End If
            End If
            If carrier <> "" Then
                If carriercount > 0 Then
                    sqlwords5 = sqlwords5 & "AND (shipcompany like '%" & carrier0 & "%' "
                    sqlwords5 = sqlwords5 & "OR shipcompany like '%" & carrier1 & "%') "
                Else
                    sqlwords5 = sqlwords5 & "AND shipcompany like '%" & carrier & "%' "
                End If
            End If
            sqlwords5 = sqlwords5 & ") "

            '置顶开始
            sqladv = "SELECT * FROM V_LCL_EFFECTIVE_ADV_20100804 WHERE 1=1 "
            If startport <> "" Then
                If citycount > 0 Then
                    sqladv = sqladv & "AND (startport like '%" & city0 & "%' "
                    sqladv = sqladv & "OR startport like '%" & city1 & "%') "
                Else
                    sqladv = sqladv & "AND startport like '%" & startport & "%' "
                End If
            End If
            If destport <> "" Then
                If dcitycount > 0 Then
                    sqladv = sqladv & "AND (destport like '%" & city3 & "%' "
                    sqladv = sqladv & "OR destport like '%" & city4 & "%') "
                Else
                    sqladv = sqladv & "AND destport like '%" & destport & "%' "
                End If
            End If

            If carrier <> "" Then
                If carriercount > 0 Then
                    sqladv = sqladv & "AND (shipcompany like '%" & carrier0 & "%' "
                    sqladv = sqladv & "OR shipcompany like '%" & carrier1 & "%') "
                Else
                    sqladv = sqladv & "AND shipcompany like '%" & carrier & "%' "
                End If
            End If
            dsadv = cn.mdb_ds(sqladv, "fcladv")
            dsadv1 = dsadv.Clone
            Dim hidadv As String = ""
            Dim hidadvtemp As String = ""

            For iii As Integer = 0 To dsadv.Tables("fcladv").Rows.Count - 1
                hidadvtemp = "<div style=""line-height:15px;""><a href = ""/fcl/" & key(dsadv.Tables("fcladv").Rows(iii)("sid")) & "_" & dsadv.Tables("fcladv").Rows(iii)("id") & ".html"" target=""_blank"">" & dsadv.Tables("fcladv").Rows(iii)("title") & "</a>" & "<br/>[" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "dd").ToString & " 至 " & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "dd").ToString & "]</div>##" & dsadv.Tables("fcladv").Rows(iii)("destport") & "##" & dsadv.Tables("fcladv").Rows(iii)("pricegp") & "/" & dsadv.Tables("fcladv").Rows(iii)("pricegpv") & "##" & "" & dsadv.Tables("fcladv").Rows(iii)("shipcompany")
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


            '置顶结束
            'End If

        End If



        Dim sqlconn As New Data.SqlClient.SqlConnection("Persist Security Info=False;Server=127.0.0.1;User ID=sasa;Password=SmNETEkwLzJNQmNoS;Database=DB_DataBase_new")

        Dim cmd As New Data.SqlClient.SqlCommand()
        cmd.Connection = sqlconn
        cmd.CommandText = "proc_searchLclFreight"
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
        If history = "" Then
            parameters(5).Value = 0
        Else
            parameters(5).Value = history
        End If

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
        item_count = parameters(7).Value.ToString()

        'Response.Write(sqlwords5)

        Rptfcl.DataSource = dstest.Tables("dstest").DefaultView
        Rptfcl.DataBind()


        sql = ""

        'If history = "" Then
        '    ltrMoreHistory.Text = "<a href=""/lcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-1----1.html""><img src= ""/images2/2011_fcl/history_freight.gif"" border=""0""/></a>"
        '    ltrMoreHistory1.Text = "<a href=""/lcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-1----1.html"">查看历史运价</a>"
        '    ltrMoreHistory2.Text = "有效运价"
        'Else
        '    ltrMoreHistory1.Text = "您搜索的是历史运价，<a href=""/lcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-----1.html"">查看有效运价</a>"
        '    ltrMoreHistory.Text = "<a href=""/lcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-----1.html""><img src= ""/images2/2011_fcl/effective_freight.gif"" border=""0""/></a>"
        '    ltrMoreHistory2.Text = "历史运价"
        'End If


        'If parameters(8).Value.ToString() = 1 Then
        '    ltrMoreHistory1.Text = "没有搜索到有效运价，以下列表显示的是该港口历史运价供您参考"
        '    ltrMoreHistory2.Text = "历史运价"
        'End If



        '计算出页数

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

        'Response.Write(cp.ToString)
        'Response.Write(tp.ToString)

        If (cp > tp And tp <> 0) Then
            Server.Transfer("/search/err.aspx")
        End If

        Dim base_url As String = "/lcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-" & history & "----"

        Dim end_url As String = ".html"

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



        ltrPage2.Text = s



        If line <> "" Or startport <> "" Or destport <> "" Then '如果没有填写搜索条件，那么不记录搜索条件
            If cp = "1" Then '如果是第一页，那么开始记录搜索条件
                If item_count <= 0 Then '无结果，成功值置0
                    SaveSearchWords(line, startport, destport, carrier, 0)
                    Dim pm1 = New pm()
                    pm1.SaveSearchWords2("8", line, startport, destport, carrier, 0, line1, city0, city1, city3, city4, carrier0, carrier1)
                Else '有结果，成功值置1
                    SaveSearchWords(line, startport, destport, carrier, 1)
                End If
            End If
        End If


    End Sub


    'Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
    '    If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
    '        Dim strjs As String = "alert('" + strInfo + "');"
    '        ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
    '    End If
    'End Sub

    Protected Sub SaveSearchWords(ByVal line As String, ByVal startport As String, ByVal destport As String, ByVal carrier As String, ByVal success As Integer)
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
            sql = sql & "CARRIER, "
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
            sql = sql & "'" & ck.CheckInput(carrier) & "', "
            sql = sql & ck.CheckInput(success) & ", "
            sql = sql & ck.CheckInput(userid) & ", "
            sql = sql & "'" & ck.CheckInput(address) & "', "
            sql = sql & "9, "
            sql = sql & "'" & Now.ToString & "' "
            sql = sql & ")"
            cn.mdb_exe(sql)
        End If

        Try
        Catch ex As Exception

        End Try


    End Sub '保存搜索条件

    Public Function key(ByVal es As String) As String
        Dim s As New SymmetricMethod
        Return s.Encrypto(es)
    End Function

    'Protected Sub btnPageJump_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPageJump.ServerClick
    '    Dim ck As New check
    '    Dim jumppage As String
    '    jumppage = ck.CheckNumber(txtPageJump.Value)

    '    If IsNumeric(txtPageJump.Value) Then

    '        If CInt(txtPageJump.Value.ToString) < 1 Then
    '            Response.Redirect("/lcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html")
    '        Else
    '            If CInt(txtPageJump.Value.ToString) > CInt(hidTotalPage.Value) Then
    '                Response.Redirect("/lcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----" & lblTotalPage.Text & ".html")
    '            Else
    '                Response.Redirect("/lcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----" & txtPageJump.Value & ".html")
    '            End If
    '        End If
    '    End If

    'End Sub

    Public Function bbsstyle(ByVal r As Integer) As String
        Dim s As String = "4"
        If r <= 3 Then

            Return (r + 1).ToString()
        Else

            Return s
        End If
    End Function

    'Public Function GetQueryString(ByVal q As String) As String
    '    If Request.QueryString(q) Is Nothing Then
    '        Return "0"
    '    Else
    '        If Request.QueryString(q) = "" Then
    '            Return "0"
    '        Else
    '            Return Request.QueryString(q).ToString
    '        End If
    '    End If
    'End Function

    'Public Shared Function GetFirstString(ByVal stringToSub As String, ByVal length As Integer) As String
    '    '\u4e00-\u9fa5 中文区
    '    '\uff00-\uffef 逗号区
    '    '\u3000-\u303f 句号区
    '    '\u2000-\u206f 引号区
    '    '\u25a0-\u25ff 几何图形区


    '    Dim regex As New Regex("[\u4e00-\u9fa5\uff00-\uffef\u3000-\u303f\u2000-\u206f\u25a0-\u25ff]+", RegexOptions.Compiled)
    '    Dim stringChar As Char() = stringToSub.ToCharArray()
    '    Dim sb As New StringBuilder()
    '    Dim nLength As Integer = 0
    '    Dim isCut As Boolean = False
    '    For i As Integer = 0 To stringChar.Length - 1
    '        If regex.IsMatch((stringChar(i)).ToString()) Then
    '            sb.Append(stringChar(i))
    '            nLength += 2
    '        Else
    '            sb.Append(stringChar(i))
    '            nLength = nLength + 1
    '        End If

    '        If nLength > length Then
    '            isCut = True
    '            Exit For
    '        End If
    '    Next

    '    If isCut = True Then
    '        Return sb.ToString() & ".."
    '    Else
    '        Return sb.ToString()
    '    End If

    'End Function




    Sub LoadOtherDestPort()
        '筛选目的港
        If dp = "" Then
            lblDesportHot.Text = "<li class=""first current"">全部</b>" & lblDesportHot.Text
        Else
            lblDesportHot.Text = "<li class=""first""><a href = ""/lcl/list-" & sp & "--" & cr & "-" & l & "-0-0-----1.html"">全部</a>" & lblDesportHot.Text
        End If

        Dim cndestport As New data_conn
        Dim dsdestport As New Data.DataSet()
        Dim sqldestport As String = ""

        sqldestport = "SELECT TOP 20 * FROM TB_CITY WHERE 1=1 "
        If l <> 0 Then
            sqldestport = sqldestport & " AND LINE = '" & Textbox1.Text & "' "
        End If
        sqldestport = sqldestport & " ORDER BY fcount DESC"
        dsdestport = cndestport.mdb_ds(sqldestport, "city")

        Dim DestportHotArray(dsdestport.Tables("city").Rows.Count) As String

        For j As Integer = 0 To dsdestport.Tables("city").Rows.Count - 1
            DestportHotArray(j) = dsdestport.Tables("city").Rows(j)("citynamech").ToString + "," + dsdestport.Tables("city").Rows(j)("cityname").ToString
            If DestportHotArray(j).IndexOf(dp) <> -1 And dp <> "" Then
                lblDesportHot.Text = lblDesportHot.Text & "<li class=""current"">" & DestportHotArray(j).Split(",")(0) & "</li>"
            Else
                lblDesportHot.Text = lblDesportHot.Text & "<li><a href = ""/lcl/list-" & sp & "-" & DestportHotArray(j).Split(",")(1) & "-" & cr & "-" & l & "-0-0-----1.html"">" & DestportHotArray(j).Split(",")(0) & "</a></li>"
            End If
        Next

        'lblDesportHot.Text = lblDesportHot.Text + "&nbsp;&nbsp;" + "<a href=""javascript:void(0);"" id=""linkmoredp"" onclick=""showmoredp2();"">更多...</a>"
    End Sub


End Class
