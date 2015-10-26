
Partial Class search_fcl_test

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
        ltrTotalSurcharge.Text = "<a href=""/baf/"" target=""_blank"">" & Now.Month.ToString & "月各大船公司最新BAF/CAF</a>"
        ltrTotalSurcharge.Text += "<a href=""/thc/"" target=""_blank"">" & Now.Month.ToString & "月各大船公司最新THC</a>"
        ltrTotalSurcharge.Text += "<a href=""/orc/"" target=""_blank"">" & Now.Month.ToString & "月最新ORC</a>"
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


                Dim agent As String
                agent = System.Web.HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT").ToString()

                If agent.ToLower.Contains("youdao") Then
                    sp = ""
                    dp = ""
                    cr = ""
                    l = "0"
                    p = "1"
                    order = "0"
                Else


                End If

                hidStartport.Value = sp
                hidDestport.Value = dp
                hidCarrier.Value = cr
                hidLine.Value = l

                '起运港、目的港、航线搜索框，提取参数内容
                txtStartport.Text = sp
                txtDestport.Text = dp
                txtCarrier.Text = cr

                '搜索条件保存在label控件内
                hidTxtStartport.Text = sp
                hidTxtDestport.Text = dp
                hidTxtCarrier.Text = cr

                '航线下拉框，提取参数内容
                txtLine.SelectedIndex = l

                hidTxtLine.Text = txtLine.SelectedValue
                'If txtDestport.Text = "" Then

                'End If

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

                If cr = "" Then
                    Label9.Visible = False
                    ltrTotalSurcharge.Visible = True

                    'phBAF.Visible = False
                    'phCAF.Visible = False
                    'phTHC.Visible = False
                Else
                    Label9.Visible = True
                    ltrTotalSurcharge.Visible = True
                    'LoadSurcharge(cr)
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
                Label9.Visible = False
                Label12.Visible = False
                LoadRecord("1")
            End If
        End If


        '生成筛选链接，包括起运港、航线、船公司的筛选
        lblLineHot.Text = ""
        lblStartportHot.Text = ""
        lblDesportHot.Text = ""
        lblCarrierHot.Text = ""

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
            If StartportHotArray(i).IndexOf(sp) <> -1 And sp <> "" Then
                lblStartportHot.Text = lblStartportHot.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & StartportHotArray(i).Split(",")(0) & "</b>"
            Else
                lblStartportHot.Text = lblStartportHot.Text & "&nbsp;&nbsp;" & "<a href = ""/fcl/list-" & StartportHotArray(i).Split(",")(1) & "-" & dp & "-" & cr & "-" & l & "-0-0-----1.html"">" & StartportHotArray(i).Split(",")(0) & "</a>"
            End If
        Next

        If sp = "" Then
            lblStartportHot.Text = "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & lblStartportHot.Text
        Else
            lblStartportHot.Text = "&nbsp;&nbsp;" & "<a href = ""/fcl/list--" & dp & "-" & cr & "-" & l & "-0-0-----1.html"">全部</a>" & lblStartportHot.Text
        End If

        Dim StartportOtherArray(11) As String

        StartportOtherArray(0) = "营口,yingkou,ying kou"
        StartportOtherArray(1) = "唐山,tangshan,tang shan"
        StartportOtherArray(2) = "秦皇岛,qinhuangdao,qin huang dao"
        StartportOtherArray(3) = "烟台,yantai,yan tai"
        StartportOtherArray(4) = "日照,rizhao,ri zhao"
        StartportOtherArray(5) = "江门,jiangmen,jiang men"
        StartportOtherArray(6) = "泉州,quanzhou,quan zhou"
        StartportOtherArray(7) = "镇江,zhenjiang,zhen jiang"
        StartportOtherArray(8) = "湛江,zhanjiang,zhan jiang"
        StartportOtherArray(9) = "澳门,macao,ao men"
        StartportOtherArray(10) = "三亚,sanya,san ya"

        For j As Integer = 0 To 10
            If StartportOtherArray(j).IndexOf(sp) <> -1 And sp <> "" Then
                lblStartportHot.Text = lblStartportHot.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & StartportOtherArray(j).Split(",")(0) & "</b>"
            End If
        Next

        lblStartportHot.Text = lblStartportHot.Text + "&nbsp;&nbsp;" + "<a href=""javascript:;"" id=""linkmore"" onclick=""showmore('" + dp + "','" + cr + "','" + l + "');"">更多...</a>"

        LoadOtherDestPort()

        'For i As Integer = 0 To dsdestport.Tables("city").Rows.Count - 1
        '    lblDesportHot.Text = lblDesportHot.Text + "&nbsp;&nbsp;" + dsdestport.Tables("city").Rows(i)("citynamech").ToString
        'Next

        'Response.Write(sqldestport)

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
                lblLineHot.Text = lblLineHot.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & LineHotArray(i).Split(",")(0) & "</b>"
            Else
                lblLineHot.Text = lblLineHot.Text & "&nbsp;&nbsp;" & "<a href = ""/fcl/list-" & sp & "-" & dp & "-" & cr & "-" & LineHotArray(i).Split(",")(1) & "-0-0-----1.html"">" & LineHotArray(i).Split(",")(0) & "</a>"
            End If
        Next

        Dim lblCarrierArray(16) As String
        lblCarrierArray(0) = "马士基,MSK"
        lblCarrierArray(1) = "地中海,MSC"
        lblCarrierArray(2) = "川崎,KLINE"
        lblCarrierArray(3) = "长荣,EMC"
        lblCarrierArray(4) = "太平,PIL"
        lblCarrierArray(5) = "中海,CSCL"
        lblCarrierArray(6) = "东方海外,OOCL"
        lblCarrierArray(7) = "达飞,CMA"
        lblCarrierArray(8) = "中远,COSCO"
        lblCarrierArray(9) = "以星,ZIM"
        lblCarrierArray(10) = "阳明,YML"
        lblCarrierArray(11) = "美国总统,APL"
        lblCarrierArray(12) = "南美邮船,CSAV"
        lblCarrierArray(13) = "现代,HMM"
        lblCarrierArray(14) = "韩进,HANJIN"
        lblCarrierArray(15) = "万海,WHL"


        For i As Integer = 0 To 15
            If lblCarrierArray(i).IndexOf(cr) <> -1 And cr <> "" Then
                lblCarrierHot.Text = lblCarrierHot.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & lblCarrierArray(i).Split(",")(0) & "</b>"
            Else
                lblCarrierHot.Text = lblCarrierHot.Text & "&nbsp;&nbsp;" & "<a href = ""/fcl/list-" & sp & "-" & dp & "-" & lblCarrierArray(i).Split(",")(1) & "-" & l & "-0-0-----1.html"">" & lblCarrierArray(i).Split(",")(0) & "</a>"
            End If
        Next

        Dim lblCarrierOtherArray(16) As String
        lblCarrierOtherArray(0) = "澳亚航运,AAL"
        lblCarrierOtherArray(1) = "澳国航运,ANL"
        lblCarrierOtherArray(2) = "边航,BEN"
        lblCarrierOtherArray(3) = "正利,CNC"
        lblCarrierOtherArray(4) = "汉堡南美,Hamburg Sud"
        lblCarrierOtherArray(5) = "赫伯罗特,HLC"
        lblCarrierOtherArray(6) = "高丽,KMTC"
        lblCarrierOtherArray(7) = "马航,MISC"
        lblCarrierOtherArray(8) = "商船三井,MOL"
        lblCarrierOtherArray(9) = "北欧亚,NCL"
        lblCarrierOtherArray(10) = "日本邮船,NYK"
        lblCarrierOtherArray(11) = "萨姆达拉,SAMUDERA"
        lblCarrierOtherArray(12) = "南非轮船,SAF"
        lblCarrierOtherArray(13) = "印度国航,SCI"
        lblCarrierOtherArray(14) = "海丰,SITC"
        lblCarrierOtherArray(15) = "德翔,TSLINE"

        For j As Integer = 0 To 15
            If lblCarrierOtherArray(j).IndexOf(cr) <> -1 And cr <> "" Then
                lblCarrierHot.Text = lblCarrierHot.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & lblCarrierOtherArray(j).Split(",")(0) & "</b>"
            End If
        Next

        lblCarrierHot.Text = lblCarrierHot.Text + "&nbsp;&nbsp;" + "<a href=""javascript:;"" id=""linkmorecr"" onclick=""showmorecr('" + sp + "','" + dp + "','" + l + "');"">更多...</a>"

        If cr = "" Then
            lblCarrierHot.Text = "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & lblCarrierHot.Text
        Else
            lblCarrierHot.Text = "&nbsp;&nbsp;" & "<a href = ""/fcl/list-" & sp & "---" & l & "-0-0-----1.html"">全部</a>" & lblCarrierHot.Text
        End If

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

            If tempsearch_string.IndexOf(Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html"" target=""_blank"">[整箱] " & sp & "-" & dp & "</a></nobr></div></li>")) = -1 Then
                If tempsearch.Length < 6 Then
                    tempsearch_string = Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html"" target=""_blank"">[整箱] " & sp & "-" & dp & "</a></nobr></div></li>") & "|" & tempsearch_string
                Else
                    tempsearch_string = Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html"" target=""_blank"">[整箱] " & sp & "-" & dp & "</a></nobr></div></li>")
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

        seo_keywords = "整箱 运费 运价"

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
            Literal1.Text = "<title>" & seo_sp & seo_dp & seo_l & seo_cr & "整箱运费," & seo_sp & seo_dp1 & seo_l & seo_cr & "整箱运价发布," & seo_sp & seo_dp2 & seo_l & seo_cr & "整箱价格-环球运费网" & "</title>"
            Literal2.Text = "<meta name=""keywords"" content=""" & seo_keywords & """ />"
            Literal3.Text = "<meta name=""description"" content=""" & seo_sp & seo_dp & seo_l & seo_cr & "整箱运费列表," & seo_sp & seo_dp1 & seo_l & seo_cr & "最新整箱运价," & seo_sp & seo_dp2 & seo_l & seo_cr & "整箱价格查询," & seo_sp & seo_dp3 & seo_l & seo_cr & "整箱订舱,环球运费网" & """ />"
        End If

        'SEO部分，结束

        '快速转到第X页的功能的js函数
        txtPageJump.Attributes.Add("onkeydown", "PageJump();")


        '定义所有输入框按回车跳到下一格
        txtLine.Attributes.Add("onkeydown", "KeyDown(event);")
        txtStartport.Attributes.Add("onfocus", "auto_init(event,this);")
        txtDestport.Attributes.Add("onfocus", "auto_init(event,this);")
        txtDestport.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")
        txtCarrier.Attributes.Add("onfocus", "auto_init(event,this);")
        txtCarrier.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")

        Dim lorderbase As String = "排序： "
        Dim lorder1 As String = "<a href=""/fcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-0-0-----1.html""><img src=""/images/fcl/time.gif""  border=""0"" /></a>"
        Dim lorder2 As String = "<a href=""/fcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-1-0-----1.html""><img src=""/images/fcl/20gp.gif""  border=""0"" /></a>"
        Dim lorder3 As String = "<a href=""/fcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-2-0-----1.html""><img src=""/images/fcl/40gp.gif""  border=""0"" /></a>"
        Dim lorder4 As String = "<a href=""/fcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-3-0-----1.html""><img src=""/images/fcl/40hq.gif""  border=""0"" /></a>"
        Dim lorder5 As String = "<a href=""/fcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-4-0-----1.html""><img src=""/images/fcl/45hq.gif""  border=""0"" /></a>"
        If order = 0 Then
            lorder1 = "<a href=""/fcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-0-0-----1.html""><img src=""/images/fcl/time2.gif""  border=""0"" /></a>"
        End If

        If order = 1 Then
            lorder2 = "<a href=""/fcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-1-0-----1.html""><img src=""/images/fcl/20gp2.gif""  border=""0"" /></a>"
        End If

        If order = 2 Then
            lorder3 = "<a href=""/fcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-2-0-----1.html""><img src=""/images/fcl/40gp2.gif""  border=""0"" /></a>"
        End If

        If order = 3 Then
            lorder4 = "<a href=""/fcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-3-0-----1.html""><img src=""/images/fcl/40hq2.gif""  border=""0"" /></a>"
        End If

        If order = 4 Then
            lorder5 = "<a href=""/fcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-4-0-----1.html""><img src=""/images/fcl/45hq2.gif""  border=""0"" /></a>"
        End If

        lblOrder.Text = lorderbase + lorder1 + lorder2 + lorder3 + lorder4 + lorder5

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
        sqlto = sqlto & "SELECT cityname, citynamech,Line "
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

        '有目的港搜索的select语句
        Dim strsort1, strsort2 As String


        Select Case order

            Case "1"
                strsort1 = " price20gpvalue ASC "
                strsort2 = " price20gpvalue"
            Case "2"
                strsort1 = " price40gpvalue ASC "
                strsort2 = " price40gpvalue"
            Case "3"
                strsort1 = " price40hqvalue ASC "
                strsort2 = " price40hqvalue "
            Case "4"
                strsort1 = " price45hqvalue ASC "
                strsort2 = " price45hqvalue "
            Case Else
                strsort1 = " tb_yunjiainfo.id DESC "
                strsort2 = " id DESC "
        End Select

        Dim sqladv As String = ""
        Dim dsadv As New Data.DataSet
        Dim dsadv1 As New Data.DataSet

        Dim dsfreight As New Data.DataSet


        Dim sqlconn As New Data.SqlClient.SqlConnection("Persist Security Info=False;Server=127.0.0.1;User ID=sasa;Password=SmNETEkwLzJNQmNoS;Database=DB_DataBase_new")

        Dim cmd As New Data.SqlClient.SqlCommand()
        cmd.Connection = sqlconn
        cmd.CommandText = "proc_searchFreight"
        cmd.CommandType = System.Data.CommandType.StoredProcedure
        Dim parameters() As Data.IDataParameter = { _
        New Data.SqlClient.SqlParameter("@yunjialeixing", System.Data.SqlDbType.NVarChar, 100), _
        New Data.SqlClient.SqlParameter("@line", System.Data.SqlDbType.NVarChar, 100), _
        New Data.SqlClient.SqlParameter("@startport", System.Data.SqlDbType.NVarChar, 100), _
        New Data.SqlClient.SqlParameter("@destport", System.Data.SqlDbType.NVarChar, 100), _
        New Data.SqlClient.SqlParameter("@carrier", System.Data.SqlDbType.NVarChar, 100), _
        New Data.SqlClient.SqlParameter("@page", System.Data.SqlDbType.Int, 4), _
        New Data.SqlClient.SqlParameter("@perpage", System.Data.SqlDbType.Int, 4) _
        }

        'parameters(0).Direction = System.Data.ParameterDirection.Output
        parameters(0).Value = "8"
        parameters(1).Value = line
        parameters(2).Value = sp
        parameters(3).Value = dp
        parameters(4).Value = cr
        parameters(5).Value = page
        parameters(6).Value = "15"

        cmd.Parameters.Add(parameters(0))
        cmd.Parameters.Add(parameters(1))
        cmd.Parameters.Add(parameters(2))
        cmd.Parameters.Add(parameters(3))
        cmd.Parameters.Add(parameters(4))
        cmd.Parameters.Add(parameters(5))
        cmd.Parameters.Add(parameters(6))

        Dim dptest As New Data.SqlClient.SqlDataAdapter(cmd)
        Dim dstest As New Data.DataSet()

        dptest.Fill(dstest, "dstest")


        Rptfcl.DataSource = dstest.Tables("dstest").DefaultView
        Rptfcl.DataBind()


        If dp = "" And cr = "" Then
            '没有船公司及目的港时
            sql = "select top 15 "
            sql = sql & "shipcompany,sid,id,startport,title,hangxianmiaoshu,hits,destport,price20gp,price40gp,price40hq,price45hq,assurance,"
            sql = sql & "userid,"
            sql = sql & "companyname,"
            sql = sql & "realname,"
            sql = sql & "star_allin,"
            sql = sql & "star_user,"
            sql = sql & "order_advx,"
            sql = sql & "postdate,"
            sql = sql & "ifend,"
            sql = sql & "enddate "
            sql = sql & "FROM (SELECT "
            sql = sql & "distinct tb_yunjia.shipcompany1 as shipcompany,tb_yunjia.id as sid,'0' as id,tb_yunjia.startport as startport,tb_yunjia.title,tb_yunjia.hangxianmiaoshu,tb_yunjia.hits,tb_yunjia.DestPort1 as destport,tb_yunjia.price20gp1 as price20gp,tb_yunjia.price40gp1 as price40gp,tb_yunjia.price40hq1 as price40hq,tb_yunjia.price45hq1 as price45hq,tb_yunjia.assurance as assurance,"
            sql = sql & "tb_user.userid,"
            sql = sql & "tb_user.companyname,"
            sql = sql & "tb_user.realname,"
            sql = sql & "tb_user.star_allin,"
            sql = sql & "tb_user.star_user,"
            sql = sql & "tb_yunjia.order_adv as order_advx,"
            sql = sql & "tb_yunjia.postdate,"
            sql = sql & "ifend, "
            sql = sql & "CONVERT(varchar(10), tb_yunjia.enddate, 120) as enddate "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_user.userid = tb_yunjia.userid "
            sql = sql & "AND tb_yunjia.yunjialeixing = 8 "


            '加入筛选条件，编号，航线，起运港
            If line <> "" Then
                sql = sql & "AND tb_yunjia.hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                If citycount > 0 Then
                    sql = sql & "AND (tb_yunjia.startport like '%" & city0 & "%' "
                    sql = sql & "OR tb_yunjia.startport like '%" & city1 & "%') "
                    'dsfreight = GetFreightCompany(city0, city1, destport)
                Else
                    sql = sql & "AND tb_yunjia.startport like '%" & startport & "%' "
                    'dsfreight = GetFreightCompany(startport, "", destport)
                End If
            End If

            sql = sql & ") AS T "

            sql = sql & "WHERE sid NOT IN "
            sql = sql & "(SELECT id FROM"
            sql = sql & "(SELECT TOP " & item.ToString & " tb_yunjia.id AS id,tb_yunjia.postdate,tb_user.star_allin,order_adv,ifend "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_user.userid = tb_yunjia.userid "
            sql = sql & "AND tb_yunjia.yunjialeixing = 8 "

            '加入筛选条件，编号，航线，起运港
            If line <> "" Then
                sql = sql & "AND tb_yunjia.hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                If citycount > 0 Then
                    sql = sql & "AND (tb_yunjia.startport like '%" & city0 & "%' "
                    sql = sql & "OR tb_yunjia.startport like '%" & city1 & "%') "
                Else
                    sql = sql & "AND tb_yunjia.startport like '%" & startport & "%' "
                End If
            End If

            If line = "" Then
                sql = sql & "ORDER BY ifend desc,tb_yunjia.postdate DESC "
                sql = sql & ") AS T "
                sql = sql & ") "
                sql = sql & "ORDER BY ifend desc,postdate DESC "
            Else
                sql = sql & "ORDER BY ifend desc,tb_yunjia.postdate DESC "
                sql = sql & ") AS T "
                sql = sql & ") "
                sql = sql & "ORDER BY ifend desc,postdate DESC "


                '置顶开始
                sqladv = "SELECT * FROM V_FCL_EFFECTIVE_ADV_LIST_20100804 WHERE 1=1 "
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
                    hidadvtemp = "<div style=""line-height:15px;""><a href = ""/fcl/" & key(dsadv.Tables("fcladv").Rows(iii)("sid")) & "_0.html"" target=""_blank"">" & dsadv.Tables("fcladv").Rows(iii)("title") & "</a>" & "<br/>[" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "dd").ToString & " 至 " & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "dd").ToString & "]</div>##" & dsadv.Tables("fcladv").Rows(iii)("destport") & "##" & dsadv.Tables("fcladv").Rows(iii)("price20gp") & "/" & dsadv.Tables("fcladv").Rows(iii)("price40gp") & "/" & dsadv.Tables("fcladv").Rows(iii)("price40hq") & "/" & dsadv.Tables("fcladv").Rows(iii)("price45hq") & "##" & "" & dsadv.Tables("fcladv").Rows(iii)("shipcompany")
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
                    PlaceHolder1.Visible = True
                End If

                '置顶结束
            End If



            lblOrder.Visible = False

            lblCompanyStart.Text = sp
        Else



            'If dp = "" Then
            '    sql = "select top 15 "
            '    sql = sql & "shipcompany,sid,id,startport,title,hangxianmiaoshu,destport,price20gp,price40gp,price40hq,price45hq,price20gpvalue,price40gpvalue,price40hqvalue,price45hqvalue,assurance,"
            '    sql = sql & "userid,"
            '    sql = sql & "companyname,"
            '    sql = sql & "realname,"
            '    sql = sql & "star_allin,"
            '    sql = sql & "star_user,"
            '    sql = sql & "order_advx,"
            '    sql = sql & "postdate,"
            '    sql = sql & "ifend,"
            '    sql = sql & "enddate "
            '    sql = sql & "FROM (SELECT "
            '    sql = sql & "shipcompany,V_CARRIER_PRICE.yunjiaid as sid,V_CARRIER_PRICE.id as id,V_CARRIER_PRICE.startportx as startport,V_CARRIER_PRICE.titlex as title,V_CARRIER_PRICE.hangxianmiaoshux as hangxianmiaoshu,V_CARRIER_PRICE.DestPort as destport,V_CARRIER_PRICE.price20gp as price20gp,V_CARRIER_PRICE.price20gpvalue,V_CARRIER_PRICE.price40gp as price40gp,V_CARRIER_PRICE.price40gpvalue,V_CARRIER_PRICE.price40hq as price40hq,V_CARRIER_PRICE.price40hqvalue,V_CARRIER_PRICE.price45hq as price45hq,V_CARRIER_PRICE.price45hqvalue,V_CARRIER_PRICE.assurance as assurance,"
            '    sql = sql & "tb_user.userid,"
            '    sql = sql & "tb_user.companyname,"
            '    sql = sql & "tb_user.realname,"
            '    sql = sql & "tb_user.star_allin,"
            '    sql = sql & "tb_user.star_user,"
            '    sql = sql & "V_CARRIER_PRICE.order_advx,"
            '    sql = sql & "V_CARRIER_PRICE.postdatex as postdate,"
            '    sql = sql & "(CASE WHEN V_CARRIER_PRICE.enddatex > GETDATE() THEN 1 ELSE 0 END) AS ifend, "
            '    sql = sql & "CONVERT(varchar(10), V_CARRIER_PRICE.enddatex, 120) as enddate "
            '    sql = sql & "FROM "
            '    sql = sql & "V_CARRIER_PRICE,tb_user "
            '    sql = sql & "WHERE "
            '    sql = sql & "1=1 AND tb_user.userid = V_CARRIER_PRICE.useridx "
            '    sql = sql & "AND V_CARRIER_PRICE.yunjialeixingx = 8 "


            '    '加入筛选条件，编号，航线，起运港
            '    If line <> "" Then
            '        sql = sql & "AND V_CARRIER_PRICE.hangxianmiaoshux = '" & line & "' "
            '    End If
            '    If startport <> "" Then
            '        If citycount > 0 Then
            '            sql = sql & "AND (V_CARRIER_PRICE.startportx like '%" & city0 & "%' "
            '            sql = sql & "OR V_CARRIER_PRICE.startportx like '%" & city1 & "%') "
            '            'dsfreight = GetFreightCompany(city0, city1, destport)
            '        Else
            '            sql = sql & "AND V_CARRIER_PRICE.startportx like '%" & startport & "%' "
            '            'dsfreight = GetFreightCompany(startport, "", destport)
            '        End If
            '    End If
            '    If destport <> "" Then
            '        If dcitycount > 0 Then
            '            sql = sql & "AND (V_CARRIER_PRICE.destport like '%" & city3 & "%' "
            '            sql = sql & "OR V_CARRIER_PRICE.destport like '%" & city4 & "%') "
            '        Else
            '            sql = sql & "AND V_CARRIER_PRICE.destport like '%" & destport & "%' "
            '        End If
            '    End If
            '    If carrier <> "" Then
            '        If carriercount > 0 Then
            '            sql = sql & "AND (V_CARRIER_PRICE.shipcompany like '%" & carrier0 & "%' "
            '            sql = sql & "OR V_CARRIER_PRICE.shipcompany like '%" & carrier1 & "%') "
            '        Else
            '            sql = sql & "AND V_CARRIER_PRICE.shipcompany like '%" & carrier & "%' "
            '        End If
            '    End If

            '    sql = sql & ") AS T "

            '    sql = sql & "WHERE id NOT IN "
            '    sql = sql & "(SELECT id FROM"
            '    sql = sql & "(SELECT TOP " & item.ToString & " V_CARRIER_PRICE.id AS id,V_CARRIER_PRICE.postdatex as postdate,(CASE WHEN V_CARRIER_PRICE.enddatex > GETDATE() THEN 1 ELSE 0 END) AS ifend,V_CARRIER_PRICE.price20gpvalue,V_CARRIER_PRICE.price40gpvalue,V_CARRIER_PRICE.price40hqvalue,V_CARRIER_PRICE.price45hqvalue,tb_user.star_allin,V_CARRIER_PRICE.order_advx "
            '    sql = sql & "FROM "
            '    sql = sql & "V_CARRIER_PRICE,tb_user "
            '    sql = sql & "WHERE "
            '    sql = sql & "1=1 AND tb_user.userid = V_CARRIER_PRICE.useridx "
            '    sql = sql & "AND V_CARRIER_PRICE.yunjialeixingx = 8 "

            '    '加入筛选条件，编号，航线，起运港
            '    If line <> "" Then
            '        sql = sql & "AND V_CARRIER_PRICE.hangxianmiaoshux = '" & line & "' "
            '    End If
            '    If startport <> "" Then
            '        If citycount > 0 Then
            '            sql = sql & "AND (V_CARRIER_PRICE.startportx like '%" & city0 & "%' "
            '            sql = sql & "OR V_CARRIER_PRICE.startportx like '%" & city1 & "%') "
            '        Else
            '            sql = sql & "AND V_CARRIER_PRICE.startportx like '%" & startport & "%' "
            '        End If
            '    End If
            '    If destport <> "" Then
            '        If dcitycount > 0 Then
            '            sql = sql & "AND (V_CARRIER_PRICE.destport like '%" & city3 & "%' "
            '            sql = sql & "OR V_CARRIER_PRICE.destport like '%" & city4 & "%') "
            '        Else
            '            sql = sql & "AND V_CARRIER_PRICE.destport like '%" & destport & "%' "
            '        End If
            '    End If

            '    If carrier <> "" Then
            '        If carriercount > 0 Then
            '            sql = sql & "AND (V_CARRIER_PRICE.shipcompany like '%" & carrier0 & "%' "
            '            sql = sql & "OR V_CARRIER_PRICE.shipcompany like '%" & carrier1 & "%') "
            '        Else
            '            sql = sql & "AND V_CARRIER_PRICE.shipcompany like '%" & carrier & "%' "
            '        End If
            '    End If

            '    If line = "" Then
            '        sql = sql & "ORDER BY ifend desc,tb_user.star_allin desc," + strsort1
            '        sql = sql & ") AS T "
            '        sql = sql & ") "
            '        sql = sql & "ORDER BY ifend desc,star_allin desc," + strsort2
            '    Else
            '        sql = sql & "ORDER BY ifend desc,tb_user.star_allin desc," + strsort1
            '        sql = sql & ") AS T "
            '        sql = sql & ") "
            '        sql = sql & "ORDER BY ifend desc,star_allin desc," + strsort2
            '    End If


            '    '置顶开始
            '    sqladv = "SELECT * FROM V_FCL_EFFECTIVE_ADV_20100804 WHERE 1=1 "
            '    If line <> "" Then
            '        sqladv = sqladv & "AND V_FCL_EFFECTIVE_ADV_20100804.hangxianmiaoshu = '" & line & "' "
            '    End If
            '    If startport <> "" Then
            '        If citycount > 0 Then
            '            sqladv = sqladv & "AND (startport like '%" & city0 & "%' "
            '            sqladv = sqladv & "OR startport like '%" & city1 & "%') "
            '        Else
            '            sqladv = sqladv & "AND startport like '%" & startport & "%' "
            '        End If
            '    End If
            '    If destport <> "" Then
            '        If dcitycount > 0 Then
            '            sqladv = sqladv & "AND (destport like '%" & city3 & "%' "
            '            sqladv = sqladv & "OR destport like '%" & city4 & "%') "
            '        Else
            '            sqladv = sqladv & "AND destport like '%" & destport & "%' "
            '        End If
            '    End If

            '    If carrier <> "" Then
            '        If carriercount > 0 Then
            '            sqladv = sqladv & "AND (shipcompany like '%" & carrier0 & "%' "
            '            sqladv = sqladv & "OR shipcompany like '%" & carrier1 & "%') "
            '        Else
            '            sqladv = sqladv & "AND shipcompany like '%" & carrier & "%' "
            '        End If
            '    End If
            '    dsadv = cn.mdb_ds(sqladv, "fcladv")
            '    dsadv1 = dsadv.Clone
            '    Dim hidadv As String = ""
            '    Dim hidadvtemp As String = ""
            '    Dim advlimit As Integer = 0

            '    For iii As Integer = 0 To dsadv.Tables("fcladv").Rows.Count - 1
            '        hidadvtemp = "<div style=""line-height:15px;""><a href = ""/fcl/" & key(dsadv.Tables("fcladv").Rows(iii)("sid")) & "_" & dsadv.Tables("fcladv").Rows(iii)("id") & ".html"" target=""_blank"">" & dsadv.Tables("fcladv").Rows(iii)("title") & "</a>" & "<br/>[" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "dd").ToString & " 至 " & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "dd").ToString & "]</div>##" & dsadv.Tables("fcladv").Rows(iii)("destport") & "##" & dsadv.Tables("fcladv").Rows(iii)("price20gp") & "/" & dsadv.Tables("fcladv").Rows(iii)("price40gp") & "/" & dsadv.Tables("fcladv").Rows(iii)("price40hq") & "/" & dsadv.Tables("fcladv").Rows(iii)("price45hq") & "##" & "" & dsadv.Tables("fcladv").Rows(iii)("shipcompany")
            '        If iii = 0 Then
            '            dsadv1.Tables("fcladv").Rows.Add(dsadv.Tables("fcladv").Rows(iii).ItemArray)
            '            hidadv = hidadvtemp
            '        Else
            '            If (dsadv.Tables("fcladv").Rows(iii)("userid").ToString <> dsadv.Tables("fcladv").Rows(iii - 1)("userid").ToString) Then
            '                dsadv1.Tables("fcladv").Rows.Add(dsadv.Tables("fcladv").Rows(iii).ItemArray)
            '                hidadv = hidadv & "$|**|$" & hidadvtemp
            '                advlimit = 0
            '            Else
            '                If advlimit <= 9 Then
            '                    hidadv = hidadv & "$$" & hidadvtemp
            '                End If
            '                advlimit = advlimit + 1
            '            End If

            '        End If
            '    Next

            '    Rptfcladv.DataSource = dsadv1.Tables("fcladv").DefaultView
            '    Rptfcladv.DataBind()

            '    Hidden2.Value = hidadv

            '    If dsadv.Tables("fcladv").Rows.Count > 0 Then
            '        PlaceHolder1.Visible = True
            '    End If
            'Else
            sql = "select top 15 "
            sql = sql & "shipcompany,sid,id,startport,title,hangxianmiaoshu,destport,price20gp,price40gp,price40hq,price45hq,price20gpvalue,price40gpvalue,price40hqvalue,price45hqvalue,assurance,"
            sql = sql & "userid,"
            sql = sql & "companyname,"
            sql = sql & "realname,"
            sql = sql & "star_allin,"
            sql = sql & "star_user,"
            sql = sql & "order_advx,"
            sql = sql & "postdate,"
            sql = sql & "ifend,"
            sql = sql & "enddate "
            sql = sql & "FROM (SELECT "
            sql = sql & "shipcompany,tb_yunjiainfo.yunjiaid as sid,tb_yunjiainfo.id as id,tb_yunjiainfo.startportx as startport,tb_yunjiainfo.titlex as title,tb_yunjiainfo.hangxianmiaoshux as hangxianmiaoshu,tb_yunjiainfo.DestPort as destport,tb_yunjiainfo.price20gp as price20gp,tb_yunjiainfo.price20gpvalue,tb_yunjiainfo.price40gp as price40gp,tb_yunjiainfo.price40gpvalue,tb_yunjiainfo.price40hq as price40hq,tb_yunjiainfo.price40hqvalue,tb_yunjiainfo.price45hq as price45hq,tb_yunjiainfo.price45hqvalue,tb_yunjiainfo.assurance as assurance,"
            sql = sql & "tb_user.userid,"
            sql = sql & "tb_user.companyname,"
            sql = sql & "tb_user.realname,"
            sql = sql & "tb_user.star_allin,"
            sql = sql & "tb_user.star_user,"
            sql = sql & "tb_yunjiainfo.order_advx,"
            sql = sql & "tb_yunjiainfo.postdatex as postdate,"
            sql = sql & "(CASE WHEN tb_yunjiainfo.enddatex > GETDATE() THEN 1 ELSE 0 END) AS ifend, "
            sql = sql & "CONVERT(varchar(10), tb_yunjiainfo.enddatex, 120) as enddate "
            sql = sql & "FROM "
            sql = sql & "tb_yunjiainfo,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_user.userid = tb_yunjiainfo.useridx "
            sql = sql & "AND tb_yunjiainfo.yunjialeixingx = 8 "


            '加入筛选条件，编号，航线，起运港
            If line <> "" Then
                sql = sql & "AND tb_yunjiainfo.hangxianmiaoshux = '" & line & "' "
            End If
            If startport <> "" Then
                If citycount > 0 Then
                    sql = sql & "AND (tb_yunjiainfo.startportx like '%" & city0 & "%' "
                    sql = sql & "OR tb_yunjiainfo.startportx like '%" & city1 & "%') "
                    'dsfreight = GetFreightCompany(city0, city1, destport)
                Else
                    sql = sql & "AND tb_yunjiainfo.startportx like '%" & startport & "%' "
                    'dsfreight = GetFreightCompany(startport, "", destport)
                End If
            End If

            If destport <> "" Then
                If dcitycount > 0 Then
                    sql = sql & "AND (tb_yunjiainfo.destport like '%" & city3 & "%' "
                    sql = sql & "OR tb_yunjiainfo.destport like '%" & city4 & "%') "
                Else
                    sql = sql & "AND tb_yunjiainfo.destport like '%" & destport & "%' "
                End If
            End If
            If carrier <> "" Then
                If carriercount > 0 Then
                    sql = sql & "AND (tb_yunjiainfo.shipcompany like '%" & carrier0 & "%' "
                    sql = sql & "OR tb_yunjiainfo.shipcompany like '%" & carrier1 & "%') "
                Else
                    sql = sql & "AND tb_yunjiainfo.shipcompany like '%" & carrier & "%' "
                End If
            End If

            sql = sql & ") AS T "

            sql = sql & "WHERE id NOT IN "
            sql = sql & "(SELECT id FROM"
            sql = sql & "(SELECT TOP " & item.ToString & " tb_yunjiainfo.id AS id,tb_yunjiainfo.postdatex as postdate,ifend,tb_yunjiainfo.price20gpvalue,tb_yunjiainfo.price40gpvalue,tb_yunjiainfo.price40hqvalue,tb_yunjiainfo.price45hqvalue,tb_user.star_allin,tb_yunjiainfo.order_advx "
            sql = sql & "FROM "
            sql = sql & "tb_yunjiainfo,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_user.userid = tb_yunjiainfo.useridx "
            sql = sql & "AND tb_yunjiainfo.yunjialeixingx = 8 "

            '加入筛选条件，编号，航线，起运港
            If line <> "" Then
                sql = sql & "AND tb_yunjiainfo.hangxianmiaoshux = '" & line & "' "
            End If
            If startport <> "" Then
                If citycount > 0 Then
                    sql = sql & "AND (tb_yunjiainfo.startportx like '%" & city0 & "%' "
                    sql = sql & "OR tb_yunjiainfo.startportx like '%" & city1 & "%') "
                Else
                    sql = sql & "AND tb_yunjiainfo.startportx like '%" & startport & "%' "
                End If
            End If
            If destport <> "" Then
                If dcitycount > 0 Then
                    sql = sql & "AND (tb_yunjiainfo.destport like '%" & city3 & "%' "
                    sql = sql & "OR tb_yunjiainfo.destport like '%" & city4 & "%') "
                Else
                    sql = sql & "AND tb_yunjiainfo.destport like '%" & destport & "%' "
                End If
            End If

            If carrier <> "" Then
                If carriercount > 0 Then
                    sql = sql & "AND (tb_yunjiainfo.shipcompany like '%" & carrier0 & "%' "
                    sql = sql & "OR tb_yunjiainfo.shipcompany like '%" & carrier1 & "%') "
                Else
                    sql = sql & "AND tb_yunjiainfo.shipcompany like '%" & carrier & "%' "
                End If
            End If

            sql = sql & "ORDER BY ifend desc,tb_user.star_allin desc," + strsort1
            sql = sql & ") AS T "
            sql = sql & ") "
            sql = sql & "ORDER BY ifend desc,star_allin desc," + strsort2


            '置顶开始
            sqladv = "SELECT * FROM V_FCL_EFFECTIVE_ADV_20100804 WHERE 1=1 "
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
                hidadvtemp = "<div style=""line-height:15px;""><a href = ""/fcl/" & key(dsadv.Tables("fcladv").Rows(iii)("sid")) & "_" & dsadv.Tables("fcladv").Rows(iii)("id") & ".html"" target=""_blank"">" & dsadv.Tables("fcladv").Rows(iii)("title") & "</a>" & "<br/>[" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("postdate"), "dd").ToString & " 至 " & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "yy").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "MM").ToString & "/" & Format(dsadv.Tables("fcladv").Rows(iii)("enddate"), "dd").ToString & "]</div>##" & dsadv.Tables("fcladv").Rows(iii)("destport") & "##" & dsadv.Tables("fcladv").Rows(iii)("price20gp") & "/" & dsadv.Tables("fcladv").Rows(iii)("price40gp") & "/" & dsadv.Tables("fcladv").Rows(iii)("price40hq") & "/" & dsadv.Tables("fcladv").Rows(iii)("price45hq") & "##" & "" & dsadv.Tables("fcladv").Rows(iii)("shipcompany")
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
                PlaceHolder1.Visible = True
            End If

            '置顶结束
            'End If

            lblOrder.Visible = True
            lblCompanyStart.Text = sp
            lblCompanyDest.Text = "-" + dp
        End If

        'Me.Response.Write(sql)
        'ds = cn.mdb_ds(sql, "yunjia")

        'Rptfcl.DataSource = ds.Tables("yunjia").DefaultView
        'Rptfcl.DataBind()

        If startport <> "" Then
            'RptFreight.DataSource = dsfreight.Tables("freight").DefaultView
            'RptFreight.DataBind()
            'If dsfreight.Tables("freight").Rows.Count > 0 Then
            'PnlFreight.Visible = True
            'End If
        Else
            PnlFreight.Visible = False

        End If

        'Me.Session("destportfcl") = ""  '清空会话变量，是被搜索的目的港名称，在显示详细记录时会用到该目的港名称"
        'Me.Session("destportfcl") = destport.ToString   '增加会话变量，是被搜索的目的港名称，在显示详细记录时会用到该目的港名称"

        Dim ds2 As New Data.DataSet
        sql = ""


        If dp = "" And cr = "" Then
            sql = sql & "SELECT "
            sql = sql & "count(tb_yunjia.id) as T "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia "
            sql = sql & "WHERE "
            sql = sql & "1=1  "
            sql = sql & "AND tb_yunjia.yunjialeixing = 8 "

            If line <> "" Then
                sql = sql & "AND tb_yunjia.hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                If citycount > 0 Then
                    sql = sql & "AND (tb_yunjia.startport like '%" & city0 & "%' "
                    sql = sql & "OR tb_yunjia.startport like '%" & city1 & "%') "
                Else
                    sql = sql & "AND tb_yunjia.startport like '%" & startport & "%' "
                End If
            End If

            ds = cn.mdb_ds(sql, "count")
        Else


            If dp = "" Then
                'sql = sql & "SELECT "
                'sql = sql & "count(V_CARRIER_PRICE.id) as T "
                'sql = sql & "FROM "
                'sql = sql & "V_CARRIER_PRICE "
                'sql = sql & "WHERE "
                'sql = sql & "1=1 "
                'sql = sql & "AND V_CARRIER_PRICE.yunjialeixingx = 8 "

                'If line <> "" Then
                '    sql = sql & "AND V_CARRIER_PRICE.hangxianmiaoshux = '" & line & "' "
                'End If
                'If startport <> "" Then
                '    If citycount > 0 Then
                '        sql = sql & "AND (V_CARRIER_PRICE.startportx like '%" & city0 & "%' "
                '        sql = sql & "OR V_CARRIER_PRICE.startportx like '%" & city1 & "%') "
                '    Else
                '        sql = sql & "AND V_CARRIER_PRICE.startportx like '%" & startport & "%' "
                '    End If
                'End If
                'If destport <> "" Then
                '    If dcitycount > 0 Then
                '        sql = sql & "AND (V_CARRIER_PRICE.destport like '%" & city3 & "%' "
                '        sql = sql & "OR V_CARRIER_PRICE.destport like '%" & city4 & "%') "
                '    Else
                '        sql = sql & "AND V_CARRIER_PRICE.destport like '%" & destport & "%' "
                '    End If
                'End If

                'If carrier <> "" Then
                '    If carriercount > 0 Then
                '        sql = sql & "AND (V_CARRIER_PRICE.shipcompany like '%" & carrier0 & "%' "
                '        sql = sql & "OR V_CARRIER_PRICE.shipcompany like '%" & carrier1 & "%') "
                '    Else
                '        sql = sql & "AND V_CARRIER_PRICE.shipcompany like '%" & carrier & "%' "
                '    End If
                'End If

                sql = sql & "SELECT "
                sql = sql & "count(tb_yunjiainfo.id) as T "
                sql = sql & "FROM "
                sql = sql & "tb_yunjiainfo "
                sql = sql & "WHERE "
                sql = sql & "1=1 "
                sql = sql & "AND tb_yunjiainfo.yunjialeixingx = 8 "

                If line <> "" Then
                    sql = sql & "AND tb_yunjiainfo.hangxianmiaoshux = '" & line & "' "
                End If
                If startport <> "" Then
                    If citycount > 0 Then
                        sql = sql & "AND (tb_yunjiainfo.startportx like '%" & city0 & "%' "
                        sql = sql & "OR tb_yunjiainfo.startportx like '%" & city1 & "%') "
                    Else
                        sql = sql & "AND tb_yunjiainfo.startportx like '%" & startport & "%' "
                    End If
                End If
                If destport <> "" Then
                    If dcitycount > 0 Then
                        sql = sql & "AND (tb_yunjiainfo.destport like '%" & city3 & "%' "
                        sql = sql & "OR tb_yunjiainfo.destport like '%" & city4 & "%') "
                    Else
                        sql = sql & "AND tb_yunjiainfo.destport like '%" & destport & "%' "
                    End If
                End If

                If carrier <> "" Then
                    If carriercount > 0 Then
                        sql = sql & "AND (tb_yunjiainfo.shipcompany like '%" & carrier0 & "%' "
                        sql = sql & "OR tb_yunjiainfo.shipcompany like '%" & carrier1 & "%') "
                    Else
                        sql = sql & "AND tb_yunjiainfo.shipcompany like '%" & carrier & "%' "
                    End If
                End If

                ds = cn.mdb_ds(sql, "count")
            End If

        End If


        sql = "SELECT "
        sql = sql & "count(tb_yunjiainfo.id) as T "
        sql = sql & "FROM "
        sql = sql & "tb_yunjiainfo "
        sql = sql & "WHERE "
        sql = sql & "2=2 "
        sql = sql & "AND tb_yunjiainfo.yunjialeixingx = 8 "

        If line <> "" Then
            sql = sql & "AND tb_yunjiainfo.hangxianmiaoshux = '" & line & "' "
        End If
        If startport <> "" Then
            If citycount > 0 Then
                sql = sql & "AND (tb_yunjiainfo.startportx like '%" & city0 & "%' "
                sql = sql & "OR tb_yunjiainfo.startportx like '%" & city1 & "%') "
            Else
                sql = sql & "AND tb_yunjiainfo.startportx like '%" & startport & "%' "
            End If
        End If
        If destport <> "" Then
            If dcitycount > 0 Then
                sql = sql & "AND (tb_yunjiainfo.destport like '%" & city3 & "%' "
                sql = sql & "OR tb_yunjiainfo.destport like '%" & city4 & "%') "
            Else
                sql = sql & "AND tb_yunjiainfo.destport like '%" & destport & "%' "
            End If
        End If

        If carrier <> "" Then
            If carriercount > 0 Then
                sql = sql & "AND (tb_yunjiainfo.shipcompany like '%" & carrier0 & "%' "
                sql = sql & "OR tb_yunjiainfo.shipcompany like '%" & carrier1 & "%') "
            Else
                sql = sql & "AND tb_yunjiainfo.shipcompany like '%" & carrier & "%' "
            End If
        End If

        ds2 = cn.mdb_ds(sql, "count")


        '计算出页数
        Dim item_count As Integer

        Dim fakeitem As Integer
        fakeitem = ds2.Tables("count").Rows(0)(0).ToString

        If (dp = "" And cr = "") Or (dp = "" And cr <> "") Then
            item_count = ds.Tables("count").Rows(0)(0).ToString
        Else
            If fakeitem < 1500 Then
                item_count = fakeitem
            Else
                item_count = 1500
            End If
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

        'Dim base_url As String = "/fcl/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-----"

        Dim base_url As String = "/search/fcl_test.aspx?sp=" & sp.ToUpper & "&dp=" & dp.ToUpper & "&cr=" & cr.ToUpper & "&l=" & l.ToString & "&p="

        Dim end_url As String = "&order=0"

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

        If (line = "非洲线" Or line1 = "非洲线") Then
            'ltrBanner.Text = "<div class=""right_ad""><a href=""http://www.100allin.com/company/c1haL0J4M09ObkVPYktHLytGSnFjZz09/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/ls.gif"" width=""200"" height=""150"" border=""0"" /></a></div>"
            'ltrBanner.Text = ltrBanner.Text + "<div class=""right_ad""><a href=""/herocean/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/sj.gif"" width=""200"" height=""113"" border=""0"" /></a></div>"
        End If

        If ((startport.ToLower = "shanghai" Or startport = "上海") And (line = "中南美线" Or line1 = "中南美线")) Then
            ltrBanner.Text = "<div class=""right_ad""><a href=""/company/WkQ0akpsOUdDUW9sMWNWbWxlckxNdz09/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/bh.gif"" width=""200"" height=""165"" border=""0"" /></a></div>"
        End If

        'If ((startport.ToLower = "shanghai" Or startport = "上海") And (line = "日韩线" Or line1 = "日韩线")) Then
        'ltrBanner.Text = "<div class=""right_ad""><a href=""http://www.100allin.com/shop/sunuan/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/sy.gif"" width=""200"" height=""106"" border=""0"" /></a></div>"
        'End If

        If line <> "" Or startport <> "" Or destport <> "" Then '如果没有填写搜索条件，那么不记录搜索条件
            If cp = "1" Then '如果是第一页，那么开始记录搜索条件
                If item_count <= 0 Then '无结果，成功值置0
                    phNoResult.Visible = True
                    SaveSearchWords(line, startport, destport, carrier, 0)
                    Dim pm1 = New pm()
                    pm1.SaveSearchWords2("8", line, startport, destport, carrier, 0, line1, city0, city1, city3, city4, carrier0, carrier1)
                Else '有结果，成功值置1
                    SaveSearchWords(line, startport, destport, carrier, 1)
                End If
            End If
        End If

        Try
            'hydt(line, line1, city0, city1, city3, city4, carrier0, carrier1)
            ysdl(line, line1, city0, city1)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub ysdl(ByVal line As String, ByVal line1 As String, ByVal startport_1 As String, ByVal startport_2 As String)
        Dim sql As String = ""
        Dim ds As New Data.DataSet
        Dim cn As New data_conn


        If line1 <> "" Then
            line = line1
        End If

        Dim startport As String = ""
        Dim startport_code As String = ""
        Dim line_code As String = ""

        Select Case startport_2
            Case "上海"
                startport = "上海"
                startport_code = "1"
                ltr89_startport.Text = "上海"
                ltr89_s.Text = "上海"
            Case "深圳"
                startport = "深圳"
                startport_code = "2"
                ltr89_startport.Text = "深圳"
                ltr89_s.Text = "深圳"
            Case "广州"
                startport = "广州"
                startport_code = "3"
                ltr89_startport.Text = "广州"
                ltr89_s.Text = "广州"
            Case "宁波"
                startport = "宁波"
                startport_code = "4"
                ltr89_startport.Text = "宁波"
                ltr89_s.Text = "宁波"
            Case "青岛"
                startport = "青岛"
                startport_code = "5"
                ltr89_startport.Text = "青岛"
                ltr89_s.Text = "青岛"
            Case "天津"
                startport = "天津"
                startport_code = "6"
                ltr89_startport.Text = "天津"
                ltr89_s.Text = "天津"
            Case "厦门"
                startport = "厦门"
                startport_code = "7"
                ltr89_startport.Text = "厦门"
                ltr89_s.Text = "厦门"
            Case "大连"
                startport = "大连"
                startport_code = "8"
                ltr89_startport.Text = "大连"
                ltr89_s.Text = "大连"
            Case Else
                startport = ""
                startport_code = ""
                ltr89_startport.Text = ""
                PlaceHolder3.Visible = False
                PlaceHolder4.Visible = False
        End Select

        If startport_code <> "" Then
            sql = "select * from TB_89"
            ds = cn.mdb_ds(sql, "tb89")

            If line = "" Then
                PlaceHolder4.Visible = False

                If (ds.Tables("tb89").Rows(Convert.ToInt32(startport_code) - 1)(1).ToString() <> "") Then
                    ltr89_1.Text = "<a href=""/supplier/company_detail.aspx?str=" + ds.Tables("tb89").Rows((Convert.ToInt32(startport_code) - 1).ToString())(1).ToString() + "&line=" + Server.UrlEncode("中东印巴线") + "&startport=" + Server.UrlEncode(startport) + """ target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_1.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                Else
                    ltr89_1.Text = "<a href=""/topic/supplier20101222/"" target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_1.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                End If

                If (ds.Tables("tb89").Rows(Convert.ToInt32(startport_code) - 1)(2).ToString() <> "") Then
                    ltr89_2.Text = "<a href=""/supplier/company_detail.aspx?str=" + ds.Tables("tb89").Rows((Convert.ToInt32(startport_code) - 1).ToString())(1).ToString() + "&line=" + Server.UrlEncode("非洲线") + "&startport=" + Server.UrlEncode(startport) + """ target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_2.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                Else
                    ltr89_2.Text = "<a href=""/topic/supplier20101222/"" target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_2.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                End If

                If (ds.Tables("tb89").Rows(Convert.ToInt32(startport_code) - 1)(3).ToString() <> "") Then
                    ltr89_3.Text = "<a href=""/supplier/company_detail.aspx?str=" + ds.Tables("tb89").Rows((Convert.ToInt32(startport_code) - 1).ToString())(3).ToString() + "&line=" + Server.UrlEncode("中南美线") + "&startport=" + Server.UrlEncode(startport) + """ target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_3.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                Else
                    ltr89_3.Text = "<a href=""/topic/supplier20101222/"" target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_3.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                End If

                If (ds.Tables("tb89").Rows(Convert.ToInt32(startport_code) - 1)(4).ToString() <> "") Then
                    ltr89_4.Text = "<a href=""/supplier/company_detail.aspx?str=" + ds.Tables("tb89").Rows((Convert.ToInt32(startport_code) - 1).ToString())(4).ToString() + "&line=" + Server.UrlEncode("欧地线") + "&startport=" + Server.UrlEncode(startport) + """ target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_4.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                Else
                    ltr89_4.Text = "<a href=""/topic/supplier20101222/"" target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_4.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                End If

                If (ds.Tables("tb89").Rows(Convert.ToInt32(startport_code) - 1)(5).ToString() <> "") Then
                    ltr89_5.Text = "<a href=""/supplier/company_detail.aspx?str=" + ds.Tables("tb89").Rows((Convert.ToInt32(startport_code) - 1).ToString())(5).ToString() + "&line=" + Server.UrlEncode("澳洲线") + "&startport=" + Server.UrlEncode(startport) + """ target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_5.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                Else
                    ltr89_5.Text = "<a href=""/topic/supplier20101222/"" target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_5.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                End If

                If (ds.Tables("tb89").Rows(Convert.ToInt32(startport_code) - 1)(6).ToString() <> "") Then
                    ltr89_6.Text = "<a href=""/supplier/company_detail.aspx?str=" + ds.Tables("tb89").Rows((Convert.ToInt32(startport_code) - 1).ToString())(6).ToString() + "&line=" + Server.UrlEncode("美加线") + "&startport=" + Server.UrlEncode(startport) + """ target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_6.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                Else
                    ltr89_6.Text = "<a href=""/topic/supplier20101222/"" target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_6.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                End If

                If (ds.Tables("tb89").Rows(Convert.ToInt32(startport_code) - 1)(7).ToString() <> "") Then
                    ltr89_7.Text = "<a href=""/supplier/company_detail.aspx?str=" + ds.Tables("tb89").Rows((Convert.ToInt32(startport_code) - 1).ToString())(7).ToString() + "&line=" + Server.UrlEncode("红海线") + "&startport=" + Server.UrlEncode(startport) + """ target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_7.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                Else
                    ltr89_7.Text = "<a href=""/topic/supplier20101222/"" target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_7.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                End If

                If (ds.Tables("tb89").Rows(Convert.ToInt32(startport_code) - 1)(8).ToString() <> "") Then
                    ltr89_8.Text = "<a href=""/supplier/company_detail.aspx?str=" + ds.Tables("tb89").Rows((Convert.ToInt32(startport_code) - 1).ToString())(8).ToString() + "&line=" + Server.UrlEncode("日韩线") + "&startport=" + Server.UrlEncode(startport) + """ target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_8.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                Else
                    ltr89_8.Text = "<a href=""/topic/supplier20101222/"" target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_8.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                End If

                If (ds.Tables("tb89").Rows(Convert.ToInt32(startport_code) - 1)(9).ToString() <> "") Then
                    ltr89_9.Text = "<a href=""/supplier/company_detail.aspx?str=" + ds.Tables("tb89").Rows((Convert.ToInt32(startport_code) - 1).ToString())(9).ToString() + "&line=" + Server.UrlEncode("近洋线") + "&startport=" + Server.UrlEncode(startport) + """ target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_9.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                Else
                    ltr89_9.Text = "<a href=""/topic/supplier20101222/"" target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_9.gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                End If
            Else
                PlaceHolder3.Visible = False
                Select Case line
                    Case "中东印巴线"
                        line_code = "1"
                        ltr89_l.Text = "中东印巴线"
                    Case "非洲线"
                        line_code = "2"
                        ltr89_l.Text = "非洲线"
                    Case "中南美线"
                        line_code = "3"
                        ltr89_l.Text = "中南美线"
                    Case "欧地线"
                        line_code = "4"
                        ltr89_l.Text = "欧地线"
                    Case "澳洲线"
                        line_code = "5"
                        ltr89_l.Text = "澳洲线"
                    Case "美加线"
                        line_code = "6"
                        ltr89_l.Text = "美加线"
                    Case "红海线"
                        line_code = "7"
                        ltr89_l.Text = "红海线"
                    Case "日韩线"
                        line_code = "8"
                        ltr89_l.Text = "日韩线"
                    Case "近洋线"
                        line_code = "9"
                        ltr89_l.Text = "近洋线"
                End Select

                If (ds.Tables("tb89").Rows(Convert.ToInt32(startport_code) - 1)(Convert.ToInt32(line_code)).ToString() <> "") Then
                    ltr89.Text = "<a href=""/supplier/company_detail.aspx?str=" + ds.Tables("tb89").Rows((Convert.ToInt32(startport_code) - 1).ToString())(Convert.ToInt32(line_code)).ToString() + "&line=" + Server.UrlEncode("近洋线") + "&startport=" + Server.UrlEncode(startport) + """ target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_" + line_code + ".gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                Else
                    ltr89.Text = "<a href=""/topic/supplier20101222/"" target=""_blank""><img src=""/supplier/images/supplier/cp_" + startport_code + "_" + line_code + ".gif"" width=""83"" height=""65"" border = ""0"" /></a>"
                End If
            End If



        End If


    End Sub


    Public Sub hydt(ByVal line As String, ByVal line1 As String, ByVal startport_1 As String, ByVal startport_2 As String, ByVal destport_1 As String, ByVal destport_2 As String, ByVal carrier_1 As String, ByVal carrier_2 As String)

        Dim sql As String = ""
        Dim ds As New Data.DataSet
        Dim cn As New data_conn

        '修饰起运港
        Dim sql_startport As String = ""
        sql_startport = " (title like '%" + startport_2 + "%') "

        '修饰航线
        Dim sql_line As String = ""
        '搜索航线但未搜索目的港的情况下，航线变量调整为选中的航线
        If line <> "" And destport_1 = "" And destport_2 = "" Then
            line1 = line
        End If

        line1 = line1.Replace("线", "").Replace("中南美", "南美")
        sql_line = " (title like '%" + line1 + "%') "
        If line1 = "美加" Then
            sql_line = " (title like '%美加%' or title like '%北美%' or title like '%美国%') "
        End If

        If line1 = "欧地" Then
            sql_line = " ((title like '%欧地%' or title like '%欧洲%' or title like '%地中海%') and (title not like '%地中海航运%')) "
        End If

        If line1 = "近洋" Then
            sql_line = " (title like '%近洋%' or title like '%远东%') "
        End If

        If line1 = "中东印巴" Or line1 = "红海" Then
            sql_line = " (title like '%中东%' or title like '%印巴%' or title like '%红海%') "
        End If

        '修饰目的港
        Dim sql_destport As String = ""
        sql_destport = " (title like '%" + destport_1 + "%' or title like '%" + destport_2 + "%') "

        '修饰船公司
        Dim sql_carrier As String = ""
        sql_carrier = " (title like '%" + carrier_1 + "%' or title like '%" + carrier_2 + "%') "

        '1 搜索起运港/目的港/船公司，未指定航线
        If line1 <> "" And startport_1 <> "" And startport_2 <> "" And destport_1 <> "" And destport_2 <> "" And carrier_1 <> "" And carrier_2 <> "" Then
            sql = ""
            sql = sql + "select identity(int,1,1) as iid,* into #tmp from "
            sql = sql + "(select id,title,updatedate from (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_startport + " and " + sql_line + " and " + sql_carrier + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_line + " and " + sql_carrier + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where " + sql_destport + " "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where " + sql_line + " "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + ") AS T "
            sql = sql + ";select top 8 id,title,updatedate from #tmp group by id,title,updatedate order by min(iid) "
            sql = sql + ";drop table #tmp "
        End If

        '2 指定航线，搜索起运港/船公司，未搜索目的港
        If line1 <> "" And startport_1 <> "" And startport_2 <> "" And destport_1 = "" And destport_2 = "" And carrier_1 <> "" And carrier_2 <> "" Then
            sql = ""
            sql = sql + "select identity(int,1,1) as iid,* into #tmp from "
            sql = sql + "(select id,title,updatedate from (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_startport + " and " + sql_line + " and " + sql_carrier + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_line + " and " + sql_carrier + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where " + sql_line + " "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + ") AS T "
            sql = sql + ";select top 8 id,title,updatedate from #tmp group by id,title,updatedate order by min(iid) "
            sql = sql + ";drop table #tmp "
        End If


        '3 搜索目的港/船公司，未指定航线，未搜索起运港
        If line1 <> "" And startport_1 = "" And startport_2 = "" And destport_1 <> "" And destport_2 <> "" And carrier_1 <> "" And carrier_2 <> "" Then
            sql = ""
            sql = sql + "select identity(int,1,1) as iid,* into #tmp from "
            sql = sql + "(select id,title,updatedate from (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_destport + " and " + sql_carrier + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_line + " and " + sql_carrier + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_destport + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where " + sql_line + " "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + ") AS T "
            sql = sql + ";select top 8 id,title,updatedate from #tmp group by id,title,updatedate order by min(iid) "
            sql = sql + ";drop table #tmp "
        End If

        '4 搜索起运港/目的港，未指定航线，未搜索船公司
        If line1 <> "" And startport_1 <> "" And startport_2 <> "" And destport_1 <> "" And destport_2 <> "" And carrier_1 = "" And carrier_2 = "" Then
            sql = ""
            sql = sql + "select identity(int,1,1) as iid,* into #tmp from "
            sql = sql + "(select id,title,updatedate from (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_startport + " and " + sql_line + " and " + sql_destport + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_startport + " and " + sql_destport + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_startport + " and " + sql_line + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where " + sql_destport + " "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + ") AS T "
            sql = sql + ";select top 8 id,title,updatedate from #tmp group by id,title,updatedate order by min(iid) "
            sql = sql + ";drop table #tmp "
        End If

        '5 搜索起运港/船公司，未指定航线，未搜索目的港
        If line1 = "" And startport_1 <> "" And startport_2 <> "" And destport_1 = "" And destport_2 = "" And carrier_1 <> "" And carrier_2 <> "" Then
            sql = ""
            sql = sql + "select identity(int,1,1) as iid,* into #tmp from "
            sql = sql + "(select id,title,updatedate from (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_startport + " and " + sql_carrier + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_startport + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where " + sql_carrier + " "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + ") AS T "
            sql = sql + ";select top 8 id,title,updatedate from #tmp group by id,title,updatedate order by min(iid) "
            sql = sql + ";drop table #tmp "
        End If

        '6 搜索起运港，指定航线，未搜索目的港/船公司
        If line1 <> "" And startport_1 <> "" And startport_2 <> "" And destport_1 = "" And destport_2 = "" And carrier_1 = "" And carrier_2 = "" Then
            sql = ""
            sql = sql + "select identity(int,1,1) as iid,* into #tmp from "
            sql = sql + "(select id,title,updatedate from (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_startport + " and " + sql_line + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where " + sql_line + " "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where " + sql_startport + " "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + ") AS T "
            sql = sql + ";select top 8 id,title,updatedate from #tmp group by id,title,updatedate order by min(iid) "
            sql = sql + ";drop table #tmp "
        End If


        '7 搜索船公司，指定航线，未搜索起运港/目的港
        If line1 <> "" And startport_1 = "" And startport_2 = "" And destport_1 = "" And destport_2 = "" And carrier_1 <> "" And carrier_2 <> "" Then
            sql = ""
            sql = sql + "select identity(int,1,1) as iid,* into #tmp from "
            sql = sql + "(select id,title,updatedate from (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_line + " and " + sql_carrier + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where " + sql_line + " "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where " + sql_carrier + " "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + ") AS T "
            sql = sql + ";select top 8 id,title,updatedate from #tmp group by id,title,updatedate order by min(iid) "
            sql = sql + ";drop table #tmp "
        End If


        '8 搜索起运港，未指定航线，未搜索目的港/船公司
        If line1 = "" And startport_1 <> "" And startport_2 <> "" And destport_1 = "" And destport_2 = "" And carrier_1 = "" And carrier_2 = "" Then
            sql = ""
            sql = sql + "select identity(int,1,1) as iid,* into #tmp from "
            sql = sql + "(select id,title,updatedate from (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_startport + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + ") AS T "
            sql = sql + ";select top 8 id,title,updatedate from #tmp group by id,title,updatedate order by min(iid) "
            sql = sql + ";drop table #tmp "
        End If

        '9 指定航线，未搜索起运港/目的港/船公司
        If line1 <> "" And startport_1 = "" And startport_2 = "" And destport_1 = "" And destport_2 = "" And carrier_1 = "" And carrier_2 = "" Then
            sql = ""
            sql = sql + "select identity(int,1,1) as iid,* into #tmp from "
            sql = sql + "(select id,title,updatedate from (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_line + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + ") AS T "
            sql = sql + ";select top 8 id,title,updatedate from #tmp group by id,title,updatedate order by min(iid) "
            sql = sql + ";drop table #tmp "
        End If

        '10 搜索目的港，未指定航线，未搜索起运港/船公司
        If line1 <> "" And startport_1 = "" And startport_2 = "" And destport_1 <> "" And destport_2 <> "" And carrier_1 = "" And carrier_2 = "" Then
            sql = ""
            sql = sql + "select identity(int,1,1) as iid,* into #tmp from "
            sql = sql + "(select id,title,updatedate from (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_destport + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + "union all "
            sql = sql + "select id,title,updatedate from  (select top 8  * from tb_bbs "
            sql = sql + "where " + sql_line + " "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + ") AS T "
            sql = sql + ";select top 8 id,title,updatedate from #tmp group by id,title,updatedate order by min(iid) "
            sql = sql + ";drop table #tmp "
        End If


        '11 搜索船公司，未指定航线，未搜索起运港/目的港
        If line1 = "" And startport_1 = "" And startport_2 = "" And destport_1 = "" And destport_2 = "" And carrier_1 <> "" And carrier_2 <> "" Then
            sql = ""
            sql = sql + "select identity(int,1,1) as iid,* into #tmp from "
            sql = sql + "(select id,title,updatedate from (select top 8  * from tb_bbs "
            sql = sql + "where (" + sql_carrier + ") "
            sql = sql + "and types = 5 "
            sql = sql + "order by updatedate desc) AS T "
            sql = sql + ") AS T "
            sql = sql + ";select top 8 id,title,updatedate from #tmp group by id,title,updatedate order by min(iid) "
            sql = sql + ";drop table #tmp "
        End If


        '11 未指定航线，未搜索起运港/目的港/船公司
        If line1 = "" And startport_1 = "" And startport_2 = "" And destport_1 = "" And destport_2 = "" And carrier_1 = "" And carrier_2 = "" Then
            sql = ""
            sql = sql + "select top 8  * from tb_bbs "
            sql = sql + "where types = 5 "
            sql = sql + "order by updatedate desc "
        End If


        'Response.Write(sql)

        If sql <> "" Then
            ds = cn.mdb_ds(sql, "yunjia")
            Repeater1.DataSource = ds.Tables("yunjia").DefaultView
            Repeater1.DataBind()
            If ds.Tables("yunjia").Rows.Count > 0 Then
                PlaceHolder2.Visible = True
            End If
        End If


    End Sub

    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub

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
            sql = sql & "8, "
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
        '    Response.Redirect("/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-0-0-0-----1.html")
        'Else
        '    Response.Redirect("/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html")
        'End If
        'Response.Redirect("/fcl/list-" & txtStartport.Text.ToUpper & "-" & txtDestport.Text.ToUpper & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html")
        Response.Redirect("/search/fcl_test.aspx?sp=" & txtStartport.Text.ToUpper & "&dp=" & txtDestport.Text.ToUpper & "&cr=" & txtCarrier.Text.ToUpper & "&l=" & txtLine.SelectedIndex.ToString & "&p=1&order=0")
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
        sql = sql + "SELECT TOP 6 TB_YunJia.UserID, TB_User.CompanyName, COUNT(TB_YunJia.UserID) AS c "
        sql = sql + "FROM TB_YunJia INNER JOIN TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID INNER JOIN TB_User ON TB_YunJia.UserID = TB_User.UserID "
        sql = sql + "WHERE ((TB_YunJia.StartPort LIKE '%" & s1 & "%') OR (TB_YunJia.StartPort LIKE '%" & s2 & "%')) AND (TB_YunJiaInfo.DestPort LIKE '%" & d & "%') AND (TB_YunJia.yunjialeixing = 8) AND (TB_YunJia.ifend = 1) "
        sql = sql + "GROUP BY TB_YunJia.UserID, TB_User.CompanyName,star_adv "
        sql = sql + "ORDER BY star_adv DESC,c DESC "

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
                Response.Redirect("/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html")
            Else
                If CInt(txtPageJump.Value.ToString) > CInt(hidTotalPage.Value) Then
                    Response.Redirect("/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----" & lblTotalPage.Text & ".html")
                Else
                    Response.Redirect("/fcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----" & txtPageJump.Value & ".html")
                End If
            End If
        End If

    End Sub

    Protected Sub Rptfcl_ItemDataBound(ByVal sender As Object, ByVal e As EventArgs) Handles Rptfcl.PreRender
        Dim ck As New check
        If Rptfcl.Items.Count <> 0 Then
            Dim ds As Data.DataSet
            Dim conn As New data_conn
            Dim a As Label
            Dim i As Integer
            a = Rptfcl.Items(0).FindControl("Label1")
            Dim ids As String = a.Text
            For i = 1 To Rptfcl.Items.Count - 1
                a = Rptfcl.Items(i).FindControl("Label1")
                ids += "," + a.Text
            Next
            ds = conn.mdb_ds("select YunJiaID,DESTPORT,price20gp,price40gp,price40hq,price45hq,assurance,star_allin,qstring from V_POP_FCL where YunJiaID in (" + ck.CheckInput(ids) + ") order by DESTPORT", "table")

            Dim str As String = ""
            For i = 0 To Rptfcl.Items.Count - 1
                Dim point As String = ""
                Dim j As Integer
                Dim count As Integer
                a = Rptfcl.Items(i).FindControl("Label1")
                If ds.Tables("table").Select("YunJiaID=" + a.Text).Length > 10 Then
                    count = 9
                    Dim realcount As Integer
                    realcount = ds.Tables("table").Select("YunJiaID=" + a.Text).Length - 9
                    point = "<a href=""/fcl/" + key(a.Text) + "_0.html"" target=""_blank"">查看其余" + realcount.ToString + "条运价</a>######"
                Else
                    count = ds.Tables("table").Select("YunJiaID=" + a.Text).Length - 1
                End If

                If count > 9 Then
                    count = 9
                End If
                '增加预览的上限是10个


                For j = 0 To count
                    Dim k As Integer
                    For k = 1 To 8
                        str += ds.Tables("table").Select("YunJiaID=" + a.Text)(j).Item(k).ToString()
                        If k <> 8 Then
                            str += "##"
                        End If
                    Next
                    If j <> ds.Tables("table").Select("YunJiaID=" + a.Text).Length - 1 Then
                        str += "$$"
                    End If
                Next
                str += point
                If i <> Rptfcl.Items.Count - 1 Then
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
                    a = Rptfcl.Items(0).FindControl("Label2")
                    ids = a.Text
                    For i = 1 To Rptfcl.Items.Count - 1
                        a = Rptfcl.Items(i).FindControl("Label2")
                        ids += "," + a.Text
                    Next
                    ds = conn.mdb_ds("select UserID,CompanyName,Realname,Phone,Fax,MovePhone,Usermsn,Userqq,UserEmail from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table")
                    'Hiddennn1.Value = "select * from TB_User where UserID in (" + ids + ")"
                    str = ""
                    For i = 0 To Rptfcl.Items.Count - 1
                        Dim point As String = ""
                        Dim j As Integer
                        Dim count As Integer
                        a = Rptfcl.Items(i).FindControl("Label2")
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
                        If i <> Rptfcl.Items.Count - 1 Then
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

            If Me.Request.Cookies("user_id") Is Nothing Then

                Hiddennn1.Value = ""
            Else

                If Request.Cookies("user_id").Value.ToString = "" Then
                    Hiddennn1.Value = ""
                Else
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
            w = ""
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


    Public Shared Function DingCang(ByVal s1 As String) As String

        Dim dc As New data_conn


    End Function

    Sub LoadOtherDestPort()
        '筛选目的港
        If dp = "" Then
            lblDesportHot.Text = "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & lblDesportHot.Text
        Else
            lblDesportHot.Text = "&nbsp;&nbsp;" & "<a href = ""/fcl/list-" & sp & "--" & cr & "-" & l & "-0-0-----1.html"">全部</a>" & lblDesportHot.Text
        End If

        Dim cndestport As New data_conn
        Dim dsdestport As New Data.DataSet()
        Dim sqldestport As String = ""

        sqldestport = "SELECT TOP 10 * FROM TB_CITY WHERE 1=1 "
        If l <> 0 Then
            sqldestport = sqldestport & " AND LINE = '" & txtLine.SelectedValue & "' "
        End If
        sqldestport = sqldestport & " ORDER BY fcount DESC"
        dsdestport = cndestport.mdb_ds(sqldestport, "city")

        Dim DestportHotArray(dsdestport.Tables("city").Rows.Count) As String

        For j As Integer = 0 To dsdestport.Tables("city").Rows.Count - 1
            DestportHotArray(j) = dsdestport.Tables("city").Rows(j)("citynamech").ToString + "," + dsdestport.Tables("city").Rows(j)("cityname").ToString
            If DestportHotArray(j).IndexOf(dp) <> -1 And dp <> "" Then
                lblDesportHot.Text = lblDesportHot.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & DestportHotArray(j).Split(",")(0) & "</b>"
            Else
                lblDesportHot.Text = lblDesportHot.Text & "&nbsp;&nbsp;" & "<a href = ""/fcl/list-" & sp & "-" & DestportHotArray(j).Split(",")(1) & "-" & cr & "-" & l & "-0-0-----1.html"">" & DestportHotArray(j).Split(",")(0) & "</a>"
            End If
        Next

        lblDesportHot.Text = lblDesportHot.Text + "&nbsp;&nbsp;" + "<a href=""javascript:void(0);"" id=""linkmoredp"" onclick=""showmoredp2();"">更多...</a>"
    End Sub




End Class
