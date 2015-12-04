
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
    '用户ID
    Public u As String = "0"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Write(Request.Url.ToString)
        If Not Page.IsPostBack Then
            '提取来自网页参数的搜索条件
            Dim GetRequest1 As New GetRequest

            sp = GetRequest1.GetRequestQueryString("sp", "")
            dp = GetRequest1.GetRequestQueryString("dp", "")
            cr = GetRequest1.GetRequestQueryString("cr", "")
            l = GetRequest1.GetRequestQueryString("l", "")
            p = GetRequest1.GetRequestQueryString("p", "1")
            order = GetRequest1.GetRequestQueryString("order", "0")
            u = GetRequest1.GetRequestQueryString("u", "0")

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
            If txtDestport.Text = "" Then
                txtLine.SelectedValue = l
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

            If cr = "" Then
                Label9.Visible = False
            Else
                Label9.Visible = True
            End If

            If l = "0" Then
                Label12.Visible = False
            Else
                Label12.Visible = True
            End If

            '开始查询符合搜索条件的记录
            LoadRecord(p)
        End If


        '生成筛选链接，包括起运港、航线、船公司的筛选
        lblLineHot.Text = ""
        lblStartportHot.Text = ""
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
                lblStartportHot.Text = lblStartportHot.Text & "&nbsp;&nbsp;" & "<a href = ""/lcl/list-" & StartportHotArray(i).Split(",")(1) & "--" & cr & "-" & l & "-0-0-----1.html"">" & StartportHotArray(i).Split(",")(0) & "</a>"
            End If
        Next

        If sp = "" Then
            lblStartportHot.Text = "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & lblStartportHot.Text
        Else
            lblStartportHot.Text = "&nbsp;&nbsp;" & "<a href = ""/lcl/list--" & dp & "-" & cr & "-" & l & "-0-0-----1.html"">全部</a>" & lblStartportHot.Text
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

        lblStartportHot.Text = lblStartportHot.Text + "&nbsp;&nbsp;" + "<a href=""javascript:;"" id=""linkmore"" onclick=""showmore('" + cr + "','" + l + "');"">更多...</a>"

        LoadOtherDestPort()

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
                lblLineHot.Text = lblLineHot.Text & "&nbsp;&nbsp;" & "<a href = ""/lcl/list-" & sp & "--" & cr & "-" & LineHotArray(i).Split(",")(1) & "-0-0-----1.html"">" & LineHotArray(i).Split(",")(0) & "</a>"
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
                lblCarrierHot.Text = lblCarrierHot.Text & "&nbsp;&nbsp;" & "<a href = ""/lcl/list-" & sp & "-" & dp & "-" & lblCarrierArray(i).Split(",")(1) & "-" & l & "-0-0-----1.html"">" & lblCarrierArray(i).Split(",")(0) & "</a>"
            End If
        Next

        Dim lblCarrierOtherArray(16) As String
        lblCarrierOtherArray(0) = "澳亚航运,AAL"
        lblCarrierOtherArray(1) = "澳国航运,ANL"
        lblCarrierOtherArray(2) = "边航,BEN"
        lblCarrierOtherArray(3) = "正利,CNC"
        lblCarrierOtherArray(4) = "汉堡南美,Hamburg Sud"
        lblCarrierOtherArray(5) = "赫伯罗特,HAPAG-LLOYD"
        lblCarrierOtherArray(6) = "高丽,KMTC"
        lblCarrierOtherArray(7) = "马航,MISC"
        lblCarrierOtherArray(8) = "商船三井,MOL"
        lblCarrierOtherArray(9) = "北欧亚,NCL"
        lblCarrierOtherArray(10) = "日本邮船,NYK"
        lblCarrierOtherArray(11) = "萨姆达拉,SAMUDERA"
        lblCarrierOtherArray(12) = "南非轮船,SAF"
        lblCarrierOtherArray(13) = "印度国航,SCI"
        lblCarrierOtherArray(14) = "海丰,SITC"
        lblCarrierOtherArray(15) = "德翔,TS-LINE"


        For j As Integer = 0 To 15
            If lblCarrierOtherArray(j).IndexOf(cr) <> -1 And cr <> "" Then
                lblCarrierHot.Text = lblCarrierHot.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & lblCarrierOtherArray(j).Split(",")(0) & "</b>"
            End If
        Next

        lblCarrierHot.Text = lblCarrierHot.Text + "&nbsp;&nbsp;" + "<a href=""javascript:;"" id=""linkmorecr"" onclick=""showmorecr('" + sp + "','" + l + "');"">更多...</a>"

        If cr = "" Then
            lblCarrierHot.Text = "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & lblCarrierHot.Text
        Else
            lblCarrierHot.Text = "&nbsp;&nbsp;" & "<a href = ""/lcl/list-" & sp & "---" & l & "-0-0-----1.html"">全部</a>" & lblCarrierHot.Text
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

            If tempsearch_string.IndexOf(Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/lcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html"" target=""_blank"">[拼箱] " & sp & "-" & dp & "</a></nobr></div></li>")) = -1 Then
                If tempsearch.Length < 6 Then
                    tempsearch_string = Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/lcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html"" target=""_blank"">[拼箱] " & sp & "-" & dp & "</a></nobr></div></li>") & "|" & tempsearch_string
                Else
                    tempsearch_string = Server.UrlEncode("<li><div class='divexcees' style='width:162px;height:25px;'><nobr><a href = ""/lcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html"" target=""_blank"">[拼箱] " & sp & "-" & dp & "</a></nobr></div></li>")
                    For i As Integer = 0 To tempsearch.Length - 2
                        tempsearch_string = tempsearch_string & "|" & tempsearch(i)
                    Next
                End If
            End If
            Response.Cookies("tempsearch").Value = tempsearch_string
            Response.Cookies("tempsearch").Expires = DateTime.Now.AddDays(365)
        End If

        '快速转到第X页的功能的js函数
        txtPageJump.Attributes.Add("onkeydown", "PageJump();")

        '定义所有输入框按回车跳到下一格
        txtLine.Attributes.Add("onkeydown", "KeyDown(event);")
        txtStartport.Attributes.Add("onkeyup", "autowords(this.id,event);")
        txtStartport.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")
        txtDestport.Attributes.Add("onkeyup", "autowords(this.id,event);")
        txtDestport.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")
        txtCarrier.Attributes.Add("onkeyup", "autowords(this.id,event);")
        txtCarrier.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")

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
        sqlto = sqlto & "SELECT cityname, citynamech "
        sqlto = sqlto & "FROM TB_CITY "
        sqlto = sqlto & "WHERE "
        sqlto = sqlto & "cityname = '" & destport & "' "
        sqlto = sqlto & "OR citynamech = '" & destport & "' "
        ds = cn.mdb_ds(sqlto, "dcity")

        Dim city3 As String = ""
        Dim city4 As String = ""

        Dim dcitycount As Integer = ds.Tables("dcity").Rows.Count

        If ds.Tables("dcity").Rows.Count > 0 Then
            city3 = ds.Tables("dcity").Rows(0)(0).ToString
            city4 = ds.Tables("dcity").Rows(0)(1).ToString
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



        Dim dsfreight As New Data.DataSet
        If dp = "" And cr = "" Then
            '没有船公司及目的港时
            sql = "select top 15 "
            sql = sql & "shipcompany,sid,id,startport,title,hangxianmiaoshu,hits,destport,pricegp,pricegpv,assurance,"
            sql = sql & "userid,"
            sql = sql & "companyname,"
            sql = sql & "star_allin,"
            sql = sql & "star_user,"
            sql = sql & "postdate,"
            sql = sql & "ifend,"
            sql = sql & "enddate "
            sql = sql & "FROM (SELECT "
            sql = sql & "distinct tb_yunjia.shipcompany1 as shipcompany,tb_yunjia.id as sid,'0' as id,tb_yunjia.startport as startport,tb_yunjia.title,tb_yunjia.hangxianmiaoshu,tb_yunjia.hits,tb_yunjia.DestPort1 as destport,tb_yunjia.pricegp1 as pricegp,tb_yunjia.pricegpv1 as pricegpv,tb_yunjia.assurance as assurance, "
            sql = sql & "tb_user.userid,"
            sql = sql & "tb_user.companyname,"
            sql = sql & "tb_user.star_allin,"
            sql = sql & "tb_user.star_user,"
            sql = sql & "tb_yunjia.postdate,"
            sql = sql & "(CASE WHEN TB_YunJia.enddate > GETDATE() THEN 1 ELSE 0 END) AS ifend, "
            sql = sql & "CONVERT(varchar(10), tb_yunjia.enddate, 120) as enddate "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_user.userid = tb_yunjia.userid "
            sql = sql & "AND tb_yunjia.yunjialeixing = 9 and tb_yunjia.userid = " & u & " "


            '加入筛选条件，编号，航线，起运港
            If line <> "" Then
                sql = sql & "AND tb_yunjia.hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                If citycount > 0 Then
                    sql = sql & "AND (tb_yunjia.startport like '%" & city0 & "%' "
                    sql = sql & "OR tb_yunjia.startport like '%" & city1 & "%') "
                    dsfreight = GetFreightCompany(city0, city1, destport)
                Else
                    sql = sql & "AND tb_yunjia.startport like '%" & startport & "%' "
                    dsfreight = GetFreightCompany(startport, "", destport)
                End If
            End If

            sql = sql & ") AS T "

            sql = sql & "WHERE sid NOT IN "
            sql = sql & "(SELECT id FROM"
            sql = sql & "(SELECT distinct TOP " & item.ToString & " tb_yunjia.id AS id,tb_yunjia.postdate "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_user.userid = tb_yunjia.userid "
            sql = sql & "AND tb_yunjia.yunjialeixing = 9 and tb_yunjia.userid = " & u & " "

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

            sql = sql & "ORDER BY tb_yunjia.postdate DESC "
            sql = sql & ") AS T "
            sql = sql & ") "
            sql = sql & "ORDER BY postdate DESC "

        Else
            If dp = "" Then
                sql = "select top 15 "
                sql = sql & "shipcompany,sid,id,startport,title,hangxianmiaoshu,destport,pricegp,pricegpv,assurance,"
                sql = sql & "userid,"
                sql = sql & "companyname,"
                sql = sql & "star_allin,"
                sql = sql & "star_user,"
                sql = sql & "postdate,"
                sql = sql & "ifend,"
                sql = sql & "enddate "
                sql = sql & "FROM (SELECT "
                sql = sql & "shipcompany,V_CARRIER_PRICE.id as sid,V_CARRIER_PRICE.id as id,V_CARRIER_PRICE.startport as startport,V_CARRIER_PRICE.titlex as title,V_CARRIER_PRICE.hangxianmiaoshux as hangxianmiaoshu,V_CARRIER_PRICE.DestPort as destport,V_CARRIER_PRICE.pricegp as pricegp,V_CARRIER_PRICE.pricegpv as pricegpv,V_CARRIER_PRICE.assurance as assurance,"
                sql = sql & "tb_user.userid,"
                sql = sql & "tb_user.companyname,"
                sql = sql & "tb_user.star_allin,"
                sql = sql & "tb_user.star_user,"
                sql = sql & "V_CARRIER_PRICE.postdatex as postdate,"
                sql = sql & "(CASE WHEN V_CARRIER_PRICE.enddatex > GETDATE() THEN 1 ELSE 0 END) AS ifend, "
                sql = sql & "CONVERT(varchar(10), V_CARRIER_PRICE.enddatex, 120) as enddate "
                sql = sql & "FROM "
                sql = sql & "V_CARRIER_PRICE,tb_user "
                sql = sql & "WHERE "
                sql = sql & "1=1 AND tb_user.userid = V_CARRIER_PRICE.useridx "
                sql = sql & "AND V_CARRIER_PRICE.yunjialeixingx = 9 and V_CARRIER_PRICE.useridx = " & u & " "


                '加入筛选条件，编号，航线，起运港
                If line <> "" Then
                    sql = sql & "AND V_CARRIER_PRICE.hangxianmiaoshux = '" & line & "' "
                End If
                If startport <> "" Then
                    If citycount > 0 Then
                        sql = sql & "AND (V_CARRIER_PRICE.startportx like '%" & city0 & "%' "
                        sql = sql & "OR V_CARRIER_PRICE.startportx like '%" & city1 & "%') "
                        dsfreight = GetFreightCompany(city0, city1, destport)
                    Else
                        sql = sql & "AND V_CARRIER_PRICE.startportx like '%" & startport & "%' "
                        dsfreight = GetFreightCompany(startport, "", destport)
                    End If
                End If
                If destport <> "" Then
                    If dcitycount > 0 Then
                        sql = sql & "AND (V_CARRIER_PRICE.destport like '%" & city3 & "%' "
                        sql = sql & "OR V_CARRIER_PRICE.destport like '%" & city4 & "%') "
                    Else
                        sql = sql & "AND V_CARRIER_PRICE.destport like '%" & destport & "%' "
                    End If
                End If
                If carrier <> "" Then
                    If carriercount > 0 Then
                        sql = sql & "AND (V_CARRIER_PRICE.shipcompany like '%" & carrier0 & "%' "
                        sql = sql & "OR V_CARRIER_PRICE.shipcompany like '%" & carrier1 & "%') "
                    Else
                        sql = sql & "AND V_CARRIER_PRICE.shipcompany like '%" & carrier & "%' "
                    End If
                End If

                sql = sql & ") AS T "

                sql = sql & "WHERE id NOT IN "
                sql = sql & "(SELECT id FROM"
                sql = sql & "(SELECT TOP " & item.ToString & " V_CARRIER_PRICE.id AS id,(CASE WHEN V_CARRIER_PRICE.enddatex > GETDATE() THEN 1 ELSE 0 END) AS ifend,V_CARRIER_PRICE.postdatex as postdate,tb_user.star_allin "
                sql = sql & "FROM "
                sql = sql & "V_CARRIER_PRICE,tb_user "
                sql = sql & "WHERE "
                sql = sql & "1=1 AND tb_user.userid = V_CARRIER_PRICE.useridx "
                sql = sql & "AND V_CARRIER_PRICE.yunjialeixingx = 9 and V_CARRIER_PRICE.useridx = " & u & " "

                '加入筛选条件，编号，航线，起运港
                If line <> "" Then
                    sql = sql & "AND V_CARRIER_PRICE.hangxianmiaoshux = '" & line & "' "
                End If
                If startport <> "" Then
                    If citycount > 0 Then
                        sql = sql & "AND (V_CARRIER_PRICE.startportx like '%" & city0 & "%' "
                        sql = sql & "OR V_CARRIER_PRICE.startportx like '%" & city1 & "%') "
                    Else
                        sql = sql & "AND V_CARRIER_PRICE.startportx like '%" & startport & "%' "
                    End If
                End If
                If destport <> "" Then
                    If dcitycount > 0 Then
                        sql = sql & "AND (V_CARRIER_PRICE.destport like '%" & city3 & "%' "
                        sql = sql & "OR V_CARRIER_PRICE.destport like '%" & city4 & "%') "
                    Else
                        sql = sql & "AND V_CARRIER_PRICE.destport like '%" & destport & "%' "
                    End If
                End If

                If carrier <> "" Then
                    If carriercount > 0 Then
                        sql = sql & "AND (V_CARRIER_PRICE.shipcompany like '%" & carrier0 & "%' "
                        sql = sql & "OR V_CARRIER_PRICE.shipcompany like '%" & carrier1 & "%') "
                    Else
                        sql = sql & "AND V_CARRIER_PRICE.shipcompany like '%" & carrier & "%' "
                    End If
                End If

                sql = sql & "ORDER BY ifend desc,tb_user.star_allin desc,V_CARRIER_PRICE.id DESC "
                sql = sql & ") AS T "
                sql = sql & ") "
                sql = sql & "ORDER BY ifend desc,star_allin desc,id DESC "
            Else
                sql = "select top 15 "
                sql = sql & "shipcompany,sid,id,startport,title,hangxianmiaoshu,destport,pricegp,pricegpv,assurance,"
                sql = sql & "userid,"
                sql = sql & "companyname,"
                sql = sql & "realname,"
                sql = sql & "star_allin,"
                sql = sql & "star_user,"
                sql = sql & "postdate,"
                sql = sql & "ifend,"
                sql = sql & "enddate "
                sql = sql & "FROM (SELECT "
                sql = sql & "shipcompany,tb_yunjiainfo.yunjiaid as sid,tb_yunjiainfo.id as id,tb_yunjiainfo.startportx as startport,tb_yunjiainfo.titlex as title,tb_yunjiainfo.hangxianmiaoshux as hangxianmiaoshu,tb_yunjiainfo.DestPort as destport,tb_yunjiainfo.pricegp as pricegp,tb_yunjiainfo.pricegpv as pricegpv,tb_yunjiainfo.assurance as assurance,"
                sql = sql & "tb_user.userid,"
                sql = sql & "tb_user.companyname,"
                sql = sql & "tb_user.realname,"
                sql = sql & "tb_user.star_allin,"
                sql = sql & "tb_user.star_user,"
                sql = sql & "tb_yunjiainfo.postdatex as postdate,"
                sql = sql & "(CASE WHEN tb_yunjiainfo.enddatex > GETDATE() THEN 1 ELSE 0 END) AS ifend, "
                sql = sql & "CONVERT(varchar(10), tb_yunjiainfo.enddatex, 120) as enddate "
                sql = sql & "FROM "
                sql = sql & "tb_yunjiainfo,tb_user "
                sql = sql & "WHERE "
                sql = sql & "1=1 AND tb_user.userid = tb_yunjiainfo.useridx "
                sql = sql & "AND tb_yunjiainfo.yunjialeixingx = 9 and tb_yunjiainfo.useridx = " & u & " "


                '加入筛选条件，编号，航线，起运港
                If line <> "" Then
                    sql = sql & "AND tb_yunjiainfo.hangxianmiaoshux = '" & line & "' "
                End If
                If startport <> "" Then
                    If citycount > 0 Then
                        sql = sql & "AND (tb_yunjiainfo.startportx like '%" & city0 & "%' "
                        sql = sql & "OR tb_yunjiainfo.startportx like '%" & city1 & "%') "
                        dsfreight = GetFreightCompany(city0, city1, destport)
                    Else
                        sql = sql & "AND tb_yunjiainfo.startportx like '%" & startport & "%' "
                        dsfreight = GetFreightCompany(startport, "", destport)
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
                sql = sql & "(SELECT TOP " & item.ToString & " tb_yunjiainfo.id AS id,(CASE WHEN tb_yunjiainfo.enddatex > GETDATE() THEN 1 ELSE 0 END) AS ifend,tb_yunjiainfo.postdatex as postdate,tb_user.star_allin "
                sql = sql & "FROM "
                sql = sql & "tb_yunjiainfo,tb_user "
                sql = sql & "WHERE "
                sql = sql & "1=1 AND tb_user.userid = tb_yunjiainfo.useridx "
                sql = sql & "AND tb_yunjiainfo.yunjialeixingx = 9 and tb_yunjiainfo.useridx = " & u & " "

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

                sql = sql & "ORDER BY ifend desc,tb_user.star_allin desc,tb_yunjiainfo.id DESC "
                sql = sql & ") AS T "
                sql = sql & ") "
                sql = sql & "ORDER BY ifend desc,star_allin desc,id DESC "
            End If

        End If

        'Me.Response.Write(sql)
        ds = cn.mdb_ds(sql, "yunjia")

        Rptfcl.DataSource = ds.Tables("yunjia").DefaultView
        Rptfcl.DataBind()


        Me.Session("destportlcl") = ""  '清空会话变量，是被搜索的目的港名称，在显示详细记录时会用到该目的港名称"
        Me.Session("destportlcl") = destport.ToString   '增加会话变量，是被搜索的目的港名称，在显示详细记录时会用到该目的港名称"

        '计算页数
        LoadTotalCount()
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


        Dim carrier As String = ck.CheckInput(hidTxtCarrier.Text)

        'If Not Request.QueryString("cr") Is Nothing Then
        '    carrier = Request.QueryString("cr").ToString
        'End If

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

        'Response.Write(sqlcr)

        Dim carrier0 As String = ""
        Dim carrier1 As String = ""

        Dim carriercount As Integer = ds.Tables("carrier").Rows.Count

        If ds.Tables("carrier").Rows.Count > 0 Then
            carrier0 = ds.Tables("carrier").Rows(0)(0).ToString
            carrier1 = ds.Tables("carrier").Rows(0)(1).ToString
        End If

        If dp = "" And cr = "" Then
            sql = sql & "SELECT "
            sql = sql & "count(tb_yunjia.id) as T "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia "
            sql = sql & "WHERE "
            sql = sql & "1=1  "
            sql = sql & "AND tb_yunjia.yunjialeixing = 9 and tb_yunjia.userid = " & u & " "

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
                sql = sql & "SELECT "
                sql = sql & "count(V_CARRIER_PRICE.id) as T "
                sql = sql & "FROM "
                sql = sql & "V_CARRIER_PRICE "
                sql = sql & "WHERE "
                sql = sql & "1=1 "
                sql = sql & "AND V_CARRIER_PRICE.yunjialeixingx = 9 and V_CARRIER_PRICE.useridx = " & u & " "

                If line <> "" Then
                    sql = sql & "AND V_CARRIER_PRICE.hangxianmiaoshux = '" & line & "' "
                End If
                If startport <> "" Then
                    If citycount > 0 Then
                        sql = sql & "AND (V_CARRIER_PRICE.startportx like '%" & city0 & "%' "
                        sql = sql & "OR V_CARRIER_PRICE.startportx like '%" & city1 & "%') "
                    Else
                        sql = sql & "AND V_CARRIER_PRICE.startportx like '%" & startport & "%' "
                    End If
                End If
                If destport <> "" Then
                    If dcitycount > 0 Then
                        sql = sql & "AND (V_CARRIER_PRICE.destport like '%" & city3 & "%' "
                        sql = sql & "OR V_CARRIER_PRICE.destport like '%" & city4 & "%') "
                    Else
                        sql = sql & "AND V_CARRIER_PRICE.destport like '%" & destport & "%' "
                    End If
                End If

                If carrier <> "" Then
                    If carriercount > 0 Then
                        sql = sql & "AND (V_CARRIER_PRICE.shipcompany like '%" & carrier0 & "%' "
                        sql = sql & "OR V_CARRIER_PRICE.shipcompany like '%" & carrier1 & "%') "
                    Else
                        sql = sql & "AND V_CARRIER_PRICE.shipcompany like '%" & carrier & "%' "
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
        sql = sql & "1=1 "
        sql = sql & "AND tb_yunjiainfo.yunjialeixingx = 9 and tb_yunjiainfo.useridx = " & u & " "

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
        Dim item As Integer

        Dim fakeitem As Integer
        fakeitem = ds2.Tables("count").Rows(0)(0).ToString


        If (dp = "" And cr = "") Or (dp = "" And cr <> "") Then
            item = ds.Tables("count").Rows(0)(0).ToString
        Else
            If fakeitem < 1500 Then
                item = fakeitem
            Else
                item = 1500
            End If
        End If

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



        Dim base_url As String = "/admin/price/lcl.aspx?l=" & Server.UrlEncode(l) & "&cr=" & cr & "&u=" & u & "&p="

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

        If line <> "" Or startport <> "" Or destport <> "" Then '如果没有填写搜索条件，那么不记录搜索条件
            If cp = "1" Then '如果是第一页，那么开始记录搜索条件
                If item <= 0 Then '无结果，成功值置0
                    phNoResult.Visible = True
                    SaveSearchWords(line, startport, destport, 0)
                    Dim pm1 = New pm()
                    pm1.SaveSearchWords2("9", line, startport, destport, carrier, 0, line1, city0, city1, city3, city4, carrier0, carrier1)
                Else '有结果，成功值置1
                    SaveSearchWords(line, startport, destport, 1)
                End If
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
            sql = sql & "9, "
            sql = sql & "'" & Now.ToString & "' "
            sql = sql & ")"
            cn.mdb_exe(sql)
        Catch ex As Exception

        End Try


    End Sub '保存搜索条件


    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If txtDestport.Text <> "" Then
            Response.Redirect("/lcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-0-0-0-----1.html")
        Else
            Response.Redirect("/lcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html")
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
        sql = sql + "SELECT TOP 6 TB_YunJia.UserID, TB_User.CompanyName, COUNT(TB_YunJia.UserID) AS c, dbo.get_yunjiaid(MAX(TB_YunJiaInfo.ID)) AS yid, MAX(TB_YunJiaInfo.ID) AS ydid "
        sql = sql + "FROM TB_YunJia INNER JOIN TB_YunJiaInfo ON TB_YunJia.id = TB_YunJiaInfo.YunJiaID INNER JOIN TB_User ON TB_YunJia.UserID = TB_User.UserID "
        sql = sql + "WHERE ((TB_YunJia.StartPort LIKE '%" & s1 & "%') OR (TB_YunJia.StartPort LIKE '%" & s2 & "%')) AND (TB_YunJiaInfo.DestPort LIKE '%" & d & "%') AND (tb_yunjia.yunjialeixing = 9) AND (TB_YunJia.enddate >= { fn NOW() }) AND TB_YunJia.USERID <> 44"
        sql = sql + "GROUP BY TB_YunJia.UserID, TB_User.CompanyName "
        sql = sql + "ORDER BY c DESC "

        ds = cn.mdb_ds(sql, "freight")
        'Response.Write(sql)
        Return ds
    End Function


    Protected Sub btnPageJump_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPageJump.ServerClick

        If IsNumeric(txtPageJump.Value) Then

            If CInt(txtPageJump.Value.ToString) < 1 Then
                Response.Redirect("/lcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----1.html")
            Else
                If CInt(txtPageJump.Value.ToString) > CInt(hidTotalPage.Value) Then
                    Response.Redirect("/lcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----" & lblTotalPage.Text & ".html")
                Else
                    Response.Redirect("/lcl/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "-" & txtCarrier.Text.ToUpper & "-" & txtLine.SelectedIndex.ToString & "-0-0-----" & txtPageJump.Value & ".html")
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
            ds = conn.mdb_ds("select YunJiaID,DESTPORT,pricegp,pricegpv,assurance,star_allin,qstring from V_POP_LCL where YunJiaID in (" + ck.CheckInput(ids) + ") order by DESTPORT", "table")

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
                    point = "<a href=""/lcl/" + key(a.Text) + "_0.html"" target=""_blank"">查看其余" + realcount.ToString + "条运价</a>######"
                Else
                    count = ds.Tables("table").Select("YunJiaID=" + a.Text).Length - 1
                End If

                If count > 9 Then
                    count = 9
                End If
                '增加预览的上限是10个

                For j = 0 To count
                    Dim k As Integer
                    For k = 1 To 6
                        str += ds.Tables("table").Select("YunJiaID=" + a.Text)(j).Item(k).ToString()
                        If k <> 6 Then
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
                    ds = conn.mdb_ds("select * from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table")
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


    Sub LoadOtherDestPort()
        '筛选目的港
        If dp = "" Then
            lblDesportHot.Text = "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & lblDesportHot.Text
        Else
            lblDesportHot.Text = "&nbsp;&nbsp;" & "<a href = ""/lcl/list-" & sp & "--" & cr & "-" & l & "-0-0-----1.html"">全部</a>" & lblDesportHot.Text
        End If

        Dim cndestport As New data_conn
        Dim dsdestport As New Data.DataSet()
        Dim sqldestport As String = ""

        sqldestport = "SELECT TOP 10 * FROM TB_CITY WHERE 1=1 "
        If l <> "" Then
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
                lblDesportHot.Text = lblDesportHot.Text & "&nbsp;&nbsp;" & "<a href = ""/lcl/list-" & sp & "-" & DestportHotArray(j).Split(",")(1) & "-" & cr & "-" & l & "-0-0-----1.html"">" & DestportHotArray(j).Split(",")(0) & "</a>"
            End If
        Next

        lblDesportHot.Text = lblDesportHot.Text + "&nbsp;&nbsp;" + "<a href=""javascript:void(0);"" id=""linkmoredp"" onclick=""showmoredp2();"">更多...</a>"

    End Sub

End Class
