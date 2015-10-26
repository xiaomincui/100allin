Imports System.Xml
Imports System.Data


Partial Class search_company
    Inherits System.Web.UI.Page
    '省参数
    Public pr As String = ""
    '市参数
    Public ct As String = ""
    '业务类型参数
    Public t As String = ""
    '公司名称参数       
    Public n As String = ""
    '航线类型
    Public l As String = ""
    '空运航线类型
    Public la As String = ""
    '排序参数(没用)
    Public order As String = ""
    '排序顺序(没用)
    Public sc As String = "0"
    '页码参数
    Public p As String = "1"


    '船公司
    Public c As String = ""
    '特种类
    Public sp As String = ""


    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            LoadList1()
            LoadList2(0)


            Dim patameter As String
            Dim ArrayPatameter(18) As String
            If Not Request.QueryString("p") Is Nothing Then
                patameter = Request.QueryString("p").ToString
                ArrayPatameter = patameter.Split("-")
            End If




            '提取来自网页参数的搜索条件
            If ArrayPatameter(0) <> "" Then
                pr = ArrayPatameter(0)
            End If

            If ArrayPatameter(1) <> "" Then
                ct = ArrayPatameter(1)
            End If

            If ArrayPatameter(2) <> "" Then
                t = ArrayPatameter(2)
            End If

            If ArrayPatameter(3) <> "" Then
                n = ArrayPatameter(3)
            End If

            If ArrayPatameter(4) <> "" Then
                l = ArrayPatameter(4)
            End If

            If ArrayPatameter(5) <> "" Then
                la = ArrayPatameter(5)
            End If

            If ArrayPatameter(6) <> "" Then
                order = ArrayPatameter(6)
            End If

            If ArrayPatameter(7) <> "" Then
                sc = ArrayPatameter(7)
            End If

            If ArrayPatameter(8) <> "" Then
                c = ArrayPatameter(8)
            End If

            If ArrayPatameter(9) <> "" Then
                sp = ArrayPatameter(9)
            End If





            If ArrayPatameter(17) <> "" Then
                p = ArrayPatameter(17)
            End If



            If pr <> "" And ct <> "" And t <> "" And n <> "" And l <> "" And la <> "" Then
                '无搜索条件，查询所有记录
                Label10.Visible = False
                Label11.Visible = False
                Label9.Visible = False
                Label12.Visible = False
                PlaceHolder4.Visible = False
            Else
                If pr <> "" And ct <> "" And t <> "" And n <> "" And l <> "" And la <> "" Then
                    '无搜索条件，查询所有记录
                    Label10.Visible = False
                    Label11.Visible = False
                    Label9.Visible = False
                    Label12.Visible = False
                    PlaceHolder4.Visible = False
                End If
            End If

            '起运港、目的港、航线搜索框，提取参数内容

            For i As Integer = 0 To ddlcity1.Items.Count - 1
                If (ddlcity1.Items(i).Text = pr) Then
                    ddlcity1.Items(i).Selected = True
                    LoadList2(ddlcity1.Items(i).Value)
                End If
            Next

            For i As Integer = 0 To ddlcity2.Items.Count - 1
                If (ddlcity2.Items(i).Text = ct) Then
                    ddlcity2.Items(i).Selected = True
                End If
            Next

            txtCompanyName.Text = n


            '搜索条件保存在label控件内
            hidTxtProvince.Text = pr
            hidTxtCity.Text = ct
            hidType.Text = t
            hidName.Text = n
            hidLine.Text = l
            hidLineAir.Text = la
            hidSC.Text = sc

            txtType.Text = t
            txtLine.Text = l
            txtLineAir.Text = la


            If pr = "" Then
                Label9.Visible = False
            Else
                Label9.Visible = True
            End If

            If ct = "" Then
                Label9.Visible = False
            Else
                Label9.Visible = True
            End If

            If t = "" Then
                Label10.Visible = False
            Else
                Label10.Visible = True
            End If

            If n = "" Then
                Label11.Visible = False
            Else
                Label11.Visible = True
            End If

            If l = "" Then
                Label12.Visible = False
            Else
                Label12.Visible = True
            End If

            If la = "" Then
                Label13.Visible = False
            Else
                Label13.Visible = True
            End If

            '开始查询符合搜索条件的记录
            LoadRecord(p)

            '=========================================================
            Dim StartcarrierHotArray(16) As String
            StartcarrierHotArray(0) = "马士基"
            StartcarrierHotArray(1) = "地中海"
            StartcarrierHotArray(2) = "川崎"
            StartcarrierHotArray(3) = "长荣"
            StartcarrierHotArray(4) = "太平"
            StartcarrierHotArray(5) = "中海"
            StartcarrierHotArray(6) = "东方海外"
            StartcarrierHotArray(7) = "达飞"
            StartcarrierHotArray(8) = "中远"
            StartcarrierHotArray(9) = "以星"
            StartcarrierHotArray(10) = "阳明"
            StartcarrierHotArray(11) = "美国总统"
            StartcarrierHotArray(12) = "南美邮船"
            StartcarrierHotArray(13) = "现代"
            StartcarrierHotArray(14) = "韩进"
            StartcarrierHotArray(15) = "万海"


            For i As Integer = 0 To 15
                If StartcarrierHotArray(i) = c Then
                    Literal7.Text = Literal7.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & StartcarrierHotArray(i) & "</b>"
                Else
                    Literal7.Text = Literal7.Text & "&nbsp;&nbsp;" & "<a href = ""/company/list-" & pr & "-" & ct & "-" & t & "-" & n & "-" & l & "-" & la & "-0-" & sc & "-" & StartcarrierHotArray(i) & "-" & sp & "--------1.html"">" & StartcarrierHotArray(i) & "</a>"
                End If
            Next

            If c = "" Then
                Literal7.Text = "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & Literal7.Text
            Else
                Literal7.Text = "&nbsp;&nbsp;" & "<a href = ""/company/list---" & t & "-" & n & "-" & l & "-" & la & "-0-" & sc & "--" & sp & "--------1.html"">全部</a>" & Literal7.Text
            End If


            '=======================================================================
            Dim specialServiceArray(7) As String
            specialServiceArray(0) = "冷冻冷藏"
            specialServiceArray(1) = "危险品"
            specialServiceArray(2) = "罐箱"
            specialServiceArray(3) = "其他特种柜"
            specialServiceArray(4) = "散杂货船"
            specialServiceArray(5) = "进口"
            specialServiceArray(6) = "私人物品"

            For i As Integer = 0 To 6
                If specialServiceArray(i) = sp Then
                    Literal9.Text = Literal9.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & specialServiceArray(i) & "</b>"
                Else
		    If i = 1 Then
                    	Literal9.Text = Literal9.Text & "&nbsp;&nbsp;" & "<a href = ""http://www.100allin.com/dangerouscargo/company/list.aspx?port=shanghai"">危险品</a>"
		    Else
			Literal9.Text = Literal9.Text & "&nbsp;&nbsp;" & "<a href = ""/company/list-" & pr & "-" & ct & "-" & t & "-" & n & "-" & l & "-" & la & "-0-" & sc & "-" & c & "-" & specialServiceArray(i) & "--------1.html"">" & specialServiceArray(i) & "</a>"
		    End If
                End If
		
		
            Next

            If sp = "" Then
                Literal9.Text = "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & Literal9.Text
            Else
                Literal9.Text = "&nbsp;&nbsp;" & "<a href = ""/company/list---" & t & "-" & n & "-" & l & "-" & la & "-0-" & sc & "-" & c & "---------1.html"">全部</a>" & Literal9.Text
            End If


            '=======================================================================
            Dim StartportHotArray(12) As String

            StartportHotArray(0) = "上海,上海市,上海市"
            StartportHotArray(1) = "宁波,浙江省,宁波市"
            StartportHotArray(2) = "深圳,广东省,深圳市"
            StartportHotArray(3) = "青岛,山东省,青岛市"
            StartportHotArray(4) = "天津,天津市,天津市"
            StartportHotArray(5) = "广州,广东省,广州市"
            StartportHotArray(6) = "厦门,福建省,厦门市"
            StartportHotArray(7) = "大连,辽宁省,大连市"
            StartportHotArray(8) = "连云港,江苏省,连云港市"
            StartportHotArray(9) = "南京,江苏省,南京市"
            StartportHotArray(10) = "珠海,广东省,珠海市"
            StartportHotArray(11) = "香港,香港特别行政区,香港特别行政区"

            For i As Integer = 0 To 11
                If (StartportHotArray(i).IndexOf(ct) <> -1 Or ct.IndexOf(StartportHotArray(i).Split(",")(0)) <> -1) And ct <> "" Then
                    ltrCityHot.Text = ltrCityHot.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & StartportHotArray(i).Split(",")(0) & "</b>"
                Else
                    ltrCityHot.Text = ltrCityHot.Text & "&nbsp;&nbsp;" & "<a href = ""/company/list-" & StartportHotArray(i).Split(",")(1) & "-" & StartportHotArray(i).Split(",")(2) & "-" & t & "-" & n & "-" & l & "-" & la & "-0-" & sc & "-" & c & "-" & sp & "--------1.html"">" & StartportHotArray(i).Split(",")(0) & "</a>"
                End If
            Next

            If ct = "" Then
                ltrCityHot.Text = "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & ltrCityHot.Text
            Else
                ltrCityHot.Text = "&nbsp;&nbsp;" & "<a href = ""/company/list---" & t & "-" & n & "-" & l & "-" & la & "-0-" & sc & "-" & c & "-" & sp & "--------1.html"">全部</a>" & ltrCityHot.Text
            End If


            Dim StartportOtherArray(11) As String

            StartportOtherArray(0) = "汕头,广东省,汕头市"
            StartportOtherArray(1) = "福州,福建省,福州市"
            StartportOtherArray(2) = "泉州,福建省,泉州市"
            StartportOtherArray(3) = "舟山,浙江省,舟山市"
            StartportOtherArray(4) = "镇江,江苏省,镇江市"
            StartportOtherArray(5) = "营口,辽宁省,营口市"
            StartportOtherArray(6) = "唐山,河北省,唐山市"
            StartportOtherArray(7) = "秦皇岛,河北省,秦皇岛市"
            StartportOtherArray(8) = "烟台,山东省,烟台市"
            StartportOtherArray(9) = "日照,山东省,日照市"
            StartportOtherArray(10) = "湛江,广东省,湛江市"

            For j As Integer = 0 To 10
                If (StartportOtherArray(j).IndexOf(ct) <> -1 Or ct.IndexOf(StartportOtherArray(j).Split(",")(0)) <> -1) And ct <> "" Then
                    ltrCityHot.Text = ltrCityHot.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & StartportOtherArray(j).Split(",")(0) & "</b>"
                End If
            Next

            ltrCityHot.Text = ltrCityHot.Text + "&nbsp;&nbsp;" + "<a href=""javascript:;"" id=""linkmore"" onclick=""showmore('" + t + "','" + n + "','" + l + "','" + la + "','" + sc + "');"">更多...</a>"



            Dim TypeArray(3) As String
            TypeArray(0) = "整箱海运,fcl"
            TypeArray(1) = "拼箱海运,lcl"
            TypeArray(2) = "空运,air"

            For i As Integer = 0 To 2
                If TypeArray(i).IndexOf(t) <> -1 And t <> "" Then
                    ltrTypeHot.Text = ltrTypeHot.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & TypeArray(i).Split(",")(0) & "</b>"
                Else
                    ltrTypeHot.Text = ltrTypeHot.Text & "&nbsp;&nbsp;" & "<a href = ""/company/list-" & pr & "-" & ct & "-" & TypeArray(i).Split(",")(0) & "-" & n & "-" & l & "-" & la & "-0-" & sc & "-" & c & "-" & sp & "--------1.html"">" & TypeArray(i).Split(",")(0) & "</a>"
                End If
            Next


            If t = "" Then
                ltrTypeHot.Text = "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & ltrTypeHot.Text
            Else
                ltrTypeHot.Text = "&nbsp;&nbsp;" & "<a href = ""/company/list-" & pr & "-" & ct & "--" & n & "-" & l & "-" & la & "-0-" & sc & "-" & c & "-" & sp & "--------1.html"">全部</a>" & ltrTypeHot.Text
            End If

            Dim LineHotArray(9) As String
            LineHotArray(0) = "美加"
            LineHotArray(1) = "非洲"
            LineHotArray(2) = "中东印巴"
            LineHotArray(3) = "中南美"
            LineHotArray(4) = "欧地"
            LineHotArray(5) = "日韩"
            LineHotArray(6) = "近洋"
            LineHotArray(7) = "澳洲"
            LineHotArray(8) = "红海"

            For i As Integer = 0 To 8
                If LineHotArray(i).IndexOf(l) <> -1 And l <> "" Then
                    ltrLineHot.Text = ltrLineHot.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & LineHotArray(i).Split(",")(0) & "</b>"
                Else
                    ltrLineHot.Text = ltrLineHot.Text & "&nbsp;&nbsp;" & "<a href = ""/company/list-" & pr & "-" & ct & "-" & t & "-" & n & "-" & LineHotArray(i).Split(",")(0) & "-" & la & "-0-" & sc & "-" & c & "-" & sp & "--------1.html"">" & LineHotArray(i).Split(",")(0) & "</a>"
                End If
            Next

            If l = "" Then
                ltrLineHot.Text = "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & ltrLineHot.Text
            Else
                ltrLineHot.Text = "&nbsp;&nbsp;" & "<a href = ""/company/list-" & pr & "-" & ct & "-" & t & "-" & n & "--" & la & "-0-" & sc & "-" & c & "-" & sp & "--------1.html"">全部</a>" & ltrLineHot.Text
            End If

            Dim LineAirHotArray(8) As String
            LineAirHotArray(0) = "北美"
            LineAirHotArray(1) = "欧洲"
            LineAirHotArray(2) = "南美"
            LineAirHotArray(3) = "亚洲"
            LineAirHotArray(4) = "非洲"
            LineAirHotArray(5) = "澳洲"
            LineAirHotArray(6) = "近洋"
            LineAirHotArray(7) = "国内"

            For i As Integer = 0 To 7
                If LineAirHotArray(i).IndexOf(la) <> -1 And la <> "" Then
                    ltrLineHotAir.Text = ltrLineHotAir.Text & "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">" & LineAirHotArray(i).Split(",")(0) & "</b>"
                Else
                    ltrLineHotAir.Text = ltrLineHotAir.Text & "&nbsp;&nbsp;" & "<a href = ""/company/list-" & pr & "-" & ct & "-" & t & "-" & n & "-" & l & "-" & LineAirHotArray(i).Split(",")(0) & "-0-" & sc & "-" & c & "-" & sp & "--------1.html"">" & LineAirHotArray(i).Split(",")(0) & "</a>"
                End If
            Next

            If la = "" Then
                ltrLineHotAir.Text = "&nbsp;&nbsp;" & "<b style=""color:#FF6600"">全部</b>" & ltrLineHotAir.Text
            Else
                ltrLineHotAir.Text = "&nbsp;&nbsp;" & "<a href = ""/company/list-" & pr & "-" & ct & "-" & t & "-" & n & "-" & l & "--0-" & sc & "-" & c & "-" & sp & "--------1.html"">全部</a>" & ltrLineHotAir.Text
            End If


            If t = "整箱海运" Or t = "拼箱海运" Then
                ltrLineHot.Visible = True
                Literal4.Visible = True
                Label4.Visible = False
                ltrLineHotAir.Visible = False
                Literal5.Visible = False
                Label5.Visible = True

                Literal6.Visible = True
                Literal7.Visible = True
                Label1.Visible = False
                Literal8.Visible = True
                Literal9.Visible = True
                Label2.Visible = False
            Else
                If t = "空运" Then
                    ltrLineHot.Visible = False
                    Literal4.Visible = False
                    Label4.Visible = True
                    ltrLineHotAir.Visible = True
                    Literal5.Visible = True
                    Label5.Visible = False

                    Literal6.Visible = False
                    Literal7.Visible = False
                    Label1.Visible = True
                    Literal8.Visible = True
                    Literal9.Visible = True
                    Label2.Visible = False
                End If

            End If


        End If

        ''SEO部分，开始
        Dim seo_sp As String = ""
        Dim seo_sp_array(23) As String

        seo_sp_array(0) = "上海,上海市,上海市"
        seo_sp_array(1) = "宁波,浙江省,宁波市"
        seo_sp_array(2) = "深圳,广东省,深圳市"
        seo_sp_array(3) = "青岛,山东省,青岛市"
        seo_sp_array(4) = "天津,天津市,天津市"
        seo_sp_array(5) = "广州,广东省,广州市"
        seo_sp_array(6) = "厦门,福建省,厦门市"
        seo_sp_array(7) = "大连,辽宁省,大连市"
        seo_sp_array(8) = "连云港,江苏省,连云港市"
        seo_sp_array(9) = "南京,江苏省,南京市"
        seo_sp_array(10) = "珠海,广东省,珠海市"
        seo_sp_array(11) = "香港,香港特别行政区,香港特别行政区"
        seo_sp_array(12) = "汕头,广东省,汕头市"
        seo_sp_array(13) = "福州,福建省,福州市"
        seo_sp_array(14) = "泉州,福建省,泉州市"
        seo_sp_array(15) = "舟山,浙江省,舟山市"
        seo_sp_array(16) = "镇江,江苏省,镇江市"
        seo_sp_array(17) = "营口,辽宁省,营口市"
        seo_sp_array(18) = "唐山,河北省,唐山市"
        seo_sp_array(19) = "秦皇岛,河北省,秦皇岛市"
        seo_sp_array(20) = "烟台,山东省,烟台市"
        seo_sp_array(21) = "日照,山东省,日照市"
        seo_sp_array(22) = "湛江,广东省,湛江市"

        For k As Integer = 0 To 22
            If seo_sp_array(k).IndexOf(ct) <> -1 And ct <> "" Then
                seo_sp = seo_sp_array(k).Split(",")(0)
            End If
        Next

        Dim seo_l As String = ""

        If t = "空运" Then
            If la <> "" Then
                seo_l = la + "线"
            End If
        End If

        If t = "整箱海运" Or t = "拼箱海运" Then
            If l <> "" Then
                seo_l = l + "线"
            End If
            seo_l = seo_l + c + sp
        End If

        If t = "" Then
            If l <> "" Then
                seo_l = seo_l + "海运" + l + "线"
            End If
            seo_l = seo_l + c + sp
            If seo_l <> "" And la <> "" Then
                seo_l = seo_l + "与"
            End If
            If la <> "" Then
                seo_l = seo_l + seo_sp + "空运" + la + "线"
            End If
        End If


        Literal1.Text = "<title>" & seo_sp & seo_l & t & "货代名录-公司库," & seo_sp & seo_l & t & "货运代理公司黄页," & seo_sp & seo_l & t & "货代公司查询-环球运费网</title>"
        Literal2.Text = "<meta name=""keywords"" content=""货代,货代公司,货运代理,公司库,环球运费网"" />"
        Literal3.Text = "<meta name=""description"" content=""" & seo_sp & seo_l & t & "货代名录(环球运费网公司库)拥有大量" & seo_sp & seo_l & t & "货代公司的注册信息," & seo_sp & seo_l & t & "货代名录的会员资料齐全,每日有大量的新注册公司,加入成为" & seo_sp & seo_l & t & "货代公司库中的一员," & seo_sp & seo_l & t & "货运代理公司尽在环球运费网货代名录" & """ />"
        ''SEO部分，结束

        '快速转到第X页的功能的js函数
        txtPageJump.Attributes.Add("onkeydown", "PageJump();")

        '定义所有输入框按回车跳到下一格
        txtCompanyName.Attributes.Add("onkeydown", "KeyDown(event);")
        ddlcity1.Attributes.Add("onkeydown", "KeyDown(event);")
        ddlcity2.Attributes.Add("onkeydown", "KeyDown(event);")



    End Sub

    Sub LoadRecord(ByVal page As String)

        Dim ck As New check
        '取搜索条件，搜索条件保存在隐藏的label内

        Dim province As String = ck.CheckInput(hidTxtProvince.Text)
        Dim city As String = ck.CheckInput(hidTxtCity.Text)
        Dim type As String = ck.CheckInput(hidType.Text)
        Dim name As String = ck.CheckInput(hidName.Text)
        Dim line As String = ck.CheckInput(hidLine.Text)
        Dim lineair As String = ck.CheckInput(hidLineAir.Text)

        page = ck.CheckInput(page)

        Dim cn As New data_conn
        Dim ds As New Data.DataSet
        Dim sql As String = ""

        'item是(页码-1)x10，用来计算分页用
        Dim item As Integer
        item = CInt(page - 1) * 15


        '没有船公司及目的港时
        sql = "select top 15 "
        sql = sql & "iflocus,"
        sql = sql & "ifadv,"
        sql = sql & "userid,"
        sql = sql & "Realname,"
        sql = sql & "Companyname,"
        sql = sql & "Phone,"
        sql = sql & "HeadURL,"
        sql = sql & "star_allin, "
        sql = sql & "star_user, "
        sql = sql & "star_adv, "
        sql = sql & "Login2_Locus1,"
        sql = sql & "Login2_Locus2,"
        sql = sql & "Login2_Adventage_Type_fcl,"
        sql = sql & "Login2_Adventage_Type_lcl,"
        sql = sql & "Login2_Adventage_Type_air, "
        sql = sql & "Login2_Adventage_Line, "
        sql = sql & "Login2_Adventage_Line2, "
        sql = sql & "(CASE WHEN Login2_Adventage_Line_Adv like '%" & l & "%' AND Login2_Adventage_Line_Adv <> '' THEN 1 ELSE 0 END) AS ifend, "
        sql = sql & "Login2_Adventage_Line_Adv, "
        sql = sql & "Login2_Adventage_Line2_Adv "
        sql = sql & "FROM (SELECT "
        sql = sql & "iflocus,"
        sql = sql & "ifadv,"
        sql = sql & "userid,"
        sql = sql & "Realname,"
        sql = sql & "Companyname,"
        sql = sql & "Phone,"
        sql = sql & "HeadURL,"
        sql = sql & "star_allin, "
        sql = sql & "star_user, "
        sql = sql & "star_adv, "
        sql = sql & "Login2_Locus1,"
        sql = sql & "Login2_Locus2,"
        sql = sql & "Login2_Adventage_Type_fcl,"
        sql = sql & "Login2_Adventage_Type_lcl,"
        sql = sql & "Login2_Adventage_Type_air, "
        sql = sql & "Login2_Adventage_Line, "
        sql = sql & "Login2_Adventage_Line2, "
        sql = sql & "Login2_Adventage_Line_Adv, "
        sql = sql & "Login2_Adventage_Line2_Adv "
        sql = sql & "FROM "
        sql = sql & "V_COMPANY_USER "
        sql = sql & "WHERE "
        sql = sql & "1=1 AND ifcompanyshow = 1 AND ifpass = 1 "

        '加入筛选条件，编号，航线，起运港
        If sc <> "1" Then
            sql = sql & "AND (CompanyType = 2 OR CompanyType = 3 OR CompanyType = 5) "
        Else
            sql = sql & "AND CompanyType = 4 "
        End If

        If pr <> "" And ct = "" Then
            sql = sql & "AND Login2_Locus1 = '" & pr & "' "
        End If

        If pr <> "" And ct <> "" Then
            sql = sql & "AND Login2_Locus2 = '" & ct & "' "
        End If

        If type = "" Then
            If l <> "" Then
                sql = sql & "AND Login2_Adventage_Line like '%" & l & "%' "
            End If
            If la <> "" Then
                sql = sql & "AND Login2_Adventage_Line2 like '%" & la & "%' "
            End If
        Else
            If type = "整箱海运" Then
                sql = sql & "AND Login2_Adventage_Type_fcl = 1 "
                If l <> "" Then
                    sql = sql & "AND Login2_Adventage_Line like '%" & l & "%' "
                End If
            End If
            If type = "拼箱海运" Then
                sql = sql & "AND Login2_Adventage_Type_lcl = 1 "
                If l <> "" Then
                    sql = sql & "AND Login2_Adventage_Line like '%" & l & "%' "
                End If
            End If
            If type = "空运" Then
                sql = sql & "AND Login2_Adventage_Type_air = 1 "
                If la <> "" Then
                    sql = sql & "AND Login2_Adventage_Line2 like '%" & la & "%' "
                End If
            End If
        End If

        If n <> "" Then
            sql = sql & "AND Companyname like '%" & n & "%' "
        End If

        If c <> "" Then
            sql = sql & "AND Login2_Adventage_Shipper like '%" & c & "%' "
        End If

        If sp <> "" Then
            sql = sql & "AND " & specialService(sp) & " = 1 "
        End If

        sql = sql & ") AS T "

        sql = sql & "WHERE userid NOT IN "
        sql = sql & "(SELECT userid FROM "
        sql = sql & "(SELECT TOP " & item.ToString & " userid,(CASE WHEN Login2_Adventage_Line_Adv like '%" & l & "%' AND Login2_Adventage_Line_Adv <> '' THEN 1 ELSE 0 END) AS ifend "
        sql = sql & "FROM "
        sql = sql & "V_COMPANY_USER "
        sql = sql & "WHERE "
        sql = sql & "1=1 AND ifcompanyshow = 1 AND ifpass = 1 "

        '加入筛选条件，编号，航线，起运港
        If sc <> "1" Then
            sql = sql & "AND (CompanyType = 2 OR CompanyType = 3 OR CompanyType = 5) "
        Else
            sql = sql & "AND CompanyType = 4 "
        End If

        If pr <> "" And ct = "" Then
            sql = sql & "AND Login2_Locus1 = '" & pr & "' "
        End If

        If pr <> "" And ct <> "" Then
            sql = sql & "AND Login2_Locus2 = '" & ct & "' "
        End If

        If type = "" Then
            If l <> "" Then
                sql = sql & "AND Login2_Adventage_Line like '%" & l & "%' "
            End If
            If la <> "" Then
                sql = sql & "AND Login2_Adventage_Line2 like '%" & la & "%' "
            End If
        Else
            If type = "整箱海运" Then
                sql = sql & "AND Login2_Adventage_Type_fcl = 1 "
                If l <> "" Then
                    sql = sql & "AND Login2_Adventage_Line like '%" & l & "%' "
                End If
            End If
            If type = "拼箱海运" Then
                sql = sql & "AND Login2_Adventage_Type_lcl = 1 "
                If l <> "" Then
                    sql = sql & "AND Login2_Adventage_Line like '%" & l & "%' "
                End If
            End If
            If type = "空运" Then
                sql = sql & "AND Login2_Adventage_Type_air = 1 "
                If la <> "" Then
                    sql = sql & "AND Login2_Adventage_Line2 like '%" & la & "%' "
                End If
            End If
        End If

        If n <> "" Then
            sql = sql & "AND Companyname like '%" & n & "%' "
        End If

        If c <> "" Then
            sql = sql & "AND Login2_Adventage_Shipper like '%" & c & "%' "
        End If

        If sp <> "" Then
            sql = sql & "AND " & specialService(sp) & "=1 "
        End If


        'If sc <> "1" Then
        '    If (l = "") Then
        '        sql = sql & "ORDER BY star_adv DESC,star_allin DESC,ifadv DESC,userid DESC "
        '        sql = sql & ") AS T"
        '        sql = sql & ") "
        '        sql = sql & "ORDER BY star_adv DESC,star_allin DESC,ifadv DESC,userid DESC "
        '    Else
        '        sql = sql & "ORDER BY star_adv DESC,ifend DESC,star_allin DESC,ifadv DESC,userid DESC "
        '        sql = sql & ") AS T"
        '        sql = sql & ") "
        '        sql = sql & "ORDER BY star_adv DESC,ifend DESC,star_allin DESC,ifadv DESC,userid DESC "
        '    End If

        'Else
        '    sql = sql & "ORDER BY star_adv DESC,ifend DESC,star_allin DESC,iflocus DESC,userid DESC "
        '    sql = sql & ") AS T"
        '    sql = sql & ") "
        '    sql = sql & "ORDER BY star_adv DESC,ifend DESC,star_allin DESC,iflocus DESC,userid DESC "
        'End If

        sql = sql & "ORDER BY star_adv DESC,userid DESC "
        sql = sql & ") AS T"
        sql = sql & ") "
        sql = sql & "ORDER BY star_adv DESC,userid DESC "




        'Me.Response.Write(sql)
        ds = cn.mdb_ds(sql, "user")


        ltrAdbanner.Text = "<a href=""http://www.100allin.com/topic/dollar20110913/"" target=""_blank""><img src=""http://img02.100allin.com/images2/index/usd20110920_1.jpg"" width=""200"" height=""120"" border=""0"" /></a>"
        'If n.ToLower.Contains("上海") Or n.ToLower.Contains("shanghai") Or pr = "上海市" Then
        '    ltrAdbanner.Text = "<a href=""http://www.100allin.com/company/S3gwVlNZeUhSZnMxVHhsVWdRY3h1dz09/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/tm.gif"" width=""200"" height=""150"" border=""0"" /></a>"
        'End If

        'Response.Write(Request.Url.ToString)
        'Response.Write(sp.ToString)

        If sc <> "1" Then
            RptUser.DataSource = ds.Tables("user").DefaultView
            RptUser.DataBind()
            PlaceHolder2.Visible = True
            PlaceHolder3.Visible = False

            Dim area As Integer = 0
            Dim area_total As Integer = ds.Tables("user").Rows.Count
            For i As Integer = 0 To ds.Tables("user").Rows.Count - 1
                If (ds.Tables("user").Rows(i)("Login2_Locus1").ToString = "上海市") Then
                    area = area + 1
                End If
            Next
            If area_total > 0 Then
                If ((area * 10) / area_total) > 8 Then
                    'ltrAdbanner.Text = "<a href=""http://www.100allin.com/company/S3gwVlNZeUhSZnMxVHhsVWdRY3h1dz09/"" target=""_blank""><img src=""http://img02.100allin.com/images2/banner/tm.gif"" width=""200"" height=""150"" border=""0"" /></a>"
                End If
            End If

            If sp.Contains("其他特种柜") Then
                ltrAdbanner.Text = "<a href=""http://www.100allin.com/shop/qa/"" target=""_blank""><img src=""/images2/banner/qa.gif"" width=""200"" height=""120"" border=""0"" /></a>"
            End If


        Else
            RptOtherUser.DataSource = ds.Tables("user").DefaultView
            RptOtherUser.DataBind()
            PlaceHolder2.Visible = False
            PlaceHolder3.Visible = True
        End If





        sql = "SELECT "
        sql = sql & "count(userid) as c "
        sql = sql & "FROM "
        sql = sql & "V_COMPANY_USER "
        sql = sql & "WHERE "
        sql = sql & "1=1 AND ifcompanyshow = 1 "

        '加入筛选条件，编号，航线，起运港
        If sc <> "1" Then
            sql = sql & "AND (CompanyType = 2 OR CompanyType = 5) "
            ltrMenu1.Text = "<LI class=hover style=""border-left:none;"">"
            ltrMenu1.Text = ltrMenu1.Text + "<A href=""/company/""><strong>货代名录</strong></A>"
            ltrMenu1.Text = ltrMenu1.Text + "</LI>"
            ltrMenu2.Text = ltrMenu2.Text + "<LI><A href=""/company/list-------0-1----------1.html"">其他</A>"
            ltrMenu2.Text = ltrMenu2.Text + "</LI>"

            PlaceHolder1.Visible = True
        Else
            sql = sql & "AND CompanyType = 4 "
            ltrMenu1.Text = ltrMenu1.Text + "<LI><A href=""/company/"">货代名录</A>"
            ltrMenu1.Text = ltrMenu1.Text + "</LI>"
            ltrMenu2.Text = "<LI class=hover style=""border-left:none;"">"
            ltrMenu2.Text = ltrMenu2.Text + "<A href=""/company/""><strong>其他</strong></A>"
            ltrMenu2.Text = ltrMenu2.Text + "</LI>"

            PlaceHolder1.Visible = False
        End If

        If pr <> "" And ct = "" Then
            sql = sql & "AND Login2_Locus1 = '" & pr & "' "
        End If

        If pr <> "" And ct <> "" Then
            sql = sql & "AND Login2_Locus2 = '" & ct & "' "
        End If

        If type = "" Then
            If l <> "" Then
                sql = sql & "AND Login2_Adventage_Line like '%" & l & "%' "
            End If
            If la <> "" Then
                sql = sql & "AND Login2_Adventage_Line2 like '%" & la & "%' "
            End If
        Else
            If type = "整箱海运" Then
                sql = sql & "AND Login2_Adventage_Type_fcl = 1 "
                If l <> "" Then
                    sql = sql & "AND Login2_Adventage_Line like '%" & l & "%' "
                End If
            End If
            If type = "拼箱海运" Then
                sql = sql & "AND Login2_Adventage_Type_lcl = 1 "
                If l <> "" Then
                    sql = sql & "AND Login2_Adventage_Line like '%" & l & "%' "
                End If
            End If
            If type = "空运" Then
                sql = sql & "AND Login2_Adventage_Type_air = 1 "
                If la <> "" Then
                    sql = sql & "AND Login2_Adventage_Line2 like '%" & la & "%' "
                End If
            End If
        End If

        If n <> "" Then
            sql = sql & "AND Companyname like '%" & n & "%' "
        End If

        If c <> "" Then
            sql = sql & "AND Login2_Adventage_Shipper like '%" & c & "%' "
        End If

        If sp <> "" Then
            sql = sql & "AND " & specialService(sp) & " = 1 "
        End If


        'Response.Write(sql)
        ds = cn.mdb_ds(sql, "count")




        '计算出页数
        Dim items As Integer
        items = ds.Tables("count").Rows(0)(0)

        Dim pages As Integer
        If items Mod 15 > 0 Or item = 0 Then
            pages = items \ 15 + 1
        Else
            pages = items \ 15
        End If

        '以下为页码控制栏相关
        Dim s As String = ""
        Dim cp As Integer = 1
        If p <> "" Then
            cp = CInt(p)
        End If
        Dim tp As Integer = pages

        'If tp >= 100 Then
        '    tp = 100
        'End If


        Dim base_url As String = "/company/list-" & pr & "-" & ct & "-" & t & "-" & n & "-" & l & "-" & la & "-0-" & sc & "-" & c & "-" & sp & "--------"

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
        hidTotalItem.Text = items.ToString
        lblTotalPage.Text = tp.ToString
        lblCurrentPage.Text = cp.ToString
        txtPageJump.Value = cp.ToString


        sql = "select top 7 "
        sql = sql & "userid,"
        sql = sql & "Realname,"
        sql = sql & "Companyname "
        sql = sql & "From TB_User "
        sql = sql & "Where CompanyType = 2 AND ifpass = 1 "
        sql = sql & "Order BY userid DESC"

        ds = cn.mdb_ds(sql, "newuser")

        RptNewUser.DataSource = ds.Tables("newuser").DefaultView
        RptNewUser.DataBind()

        sql = "select top 3 "
        sql = sql + "id,startport,title,hangxianmiaoshu,companyname,UserID "
        sql = sql + "FROM  "
        sql = sql + "V_最新_整箱运价 "
        ds = cn.mdb_ds(sql, "newuser")

        RptNewFcl.DataSource = ds.Tables("newuser").DefaultView
        RptNewFcl.DataBind()

        sql = "select top 3 "
        sql = sql + "id,startport,title,hangxianmiaoshu,companyname,UserID "
        sql = sql + "FROM  "
        sql = sql + "V_最新_拼箱运价 "
        ds = cn.mdb_ds(sql, "newuser")

        RptNewLcl.DataSource = ds.Tables("newuser").DefaultView
        RptNewLcl.DataBind()

        sql = "select top 3 "
        sql = sql + "id,startport,title,hangxianmiaoshu,companyname,UserID "
        sql = sql + "FROM  "
        sql = sql + "V_最新_空运运价 "
        ds = cn.mdb_ds(sql, "newuser")

        RptNewAir.DataSource = ds.Tables("newuser").DefaultView
        RptNewAir.DataBind()

        'sql = "select top 7 *"
        'sql = sql + "FROM "
        'sql = sql + "TB_BBS "
        'sql = sql + "WHERE types = 3 and TB_BBS.DeleSign = 0"
        'sql = sql + "ORDER BY postdate desc "
        'ds = cn.mdb_ds(sql, "newuser")

        'RptNewBBS.DataSource = ds.Tables("newuser").DefaultView
        'RptNewBBS.DataBind()

        sql = "select top 7 *"
        sql = sql + "FROM "
        sql = sql + "TB_BBS "
        sql = sql + "WHERE types = 5 and TB_BBS.DeleSign = 0"
        sql = sql + "ORDER BY postdate desc "
        ds = cn.mdb_ds(sql, "newuser")

        RptNewNews.DataSource = ds.Tables("newuser").DefaultView
        RptNewNews.DataBind()


    End Sub

    Protected Sub LoadList1()
        ddlcity1.Items.Clear()

        Dim doc As New XmlDocument
        doc.Load(Server.MapPath("../xml/Provinces.xml"))
        'Dim node As XmlNodeList = doc.SelectNodes("Cities")(0).ChildNodes
        Dim node As XmlNodeList = doc.SelectNodes("Provinces")(0).ChildNodes
        For i As Integer = 0 To node.Count - 1
            Dim pp As New ListItem(node(i).InnerText, node(i).Attributes("ID").Value)
            ddlcity1.Items.Add(pp)
        Next

    End Sub

    Protected Sub LoadList2(ByVal ID As Integer)
        ddlcity2.Items.Clear()


        Dim doc As New XmlDocument
        doc.Load(Server.MapPath("../xml/Cities.xml"))


        Dim node As XmlNodeList = doc.SelectNodes("Cities")(0).ChildNodes


        Dim flag As String
        For i As Integer = 0 To node.Count - 1
            If node(i).Attributes("PID").Value = ID.ToString Or node(i).Attributes("PID").Value = 0 Then
                If ddlcity2.Items.Count = 0 Then
                    flag = node(i).Attributes("ID").Value
                End If
                Dim pp As New ListItem(node(i).InnerText, node(i).Attributes("ID").Value)
                ddlcity2.Items.Add(pp)
            End If
        Next

    End Sub

    Protected Sub ddlcity1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcity1.SelectedIndexChanged
        LoadList2(ddlcity1.SelectedValue)
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim city1 As String = ""
        Dim city2 As String = ""
        If ddlcity1.SelectedItem.Text <> "请选择" Then
            city1 = ddlcity1.SelectedItem.Text
        End If
        If ddlcity2.SelectedItem.Text <> "请选择" Then
            city2 = ddlcity2.SelectedItem.Text
        End If
        Response.Redirect("/company/list-" & city1 & "-" & city2 & "-" & txtType.Text & "-" & txtCompanyName.Text & "-" & hidLine.Text & "-" & hidLineAir.Text & "-0-" & hidSC.Text & "----------1.html")
    End Sub

    Public Function key(ByVal es As String) As String
        Dim s As New SymmetricMethod
        Return s.Encrypto(es)
    End Function

    Protected Sub btnPageJump_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPageJump.ServerClick
        Dim city1 As String = ""
        Dim city2 As String = ""
        If ddlcity1.SelectedItem.Text <> "请选择" Then
            city1 = ddlcity1.SelectedItem.Text
        End If
        If ddlcity2.SelectedItem.Text <> "请选择" Then
            city2 = ddlcity2.SelectedItem.Text
        End If

        If IsNumeric(txtPageJump.Value) Then
            If CInt(txtPageJump.Value.ToString) < 1 Then
                Response.Redirect("/company/list-" & city1 & "-" & city2 & "-" & txtType.Text & "-" & txtCompanyName.Text & "-" & hidLine.Text & "-" & hidLineAir.Text & "-0-" & hidSC.Text & "----------1.html")
            Else
                If CInt(txtPageJump.Value.ToString) > CInt(lblTotalPage.Text) Then
                    Response.Redirect("/company/list-" & city1 & "-" & city2 & "-" & txtType.Text & "-" & txtCompanyName.Text & "-" & hidLine.Text & "-" & hidLineAir.Text & "-0-" & hidSC.Text & "----------" & lblTotalPage.Text & ".html")
                Else
                    Response.Redirect("/company/list-" & city1 & "-" & city2 & "-" & txtType.Text & "-" & txtCompanyName.Text & "-" & hidLine.Text & "-" & hidLineAir.Text & "-0-" & hidSC.Text & "----------" & txtPageJump.Value & ".html")
                End If
            End If
        End If
    End Sub

    Public Shared Function GetFirstString(ByVal stringToSub As String, ByVal length As Integer) As String
        Dim regex As New Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled)
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

    Public Shared Function specialService(ByVal s As String)
        Dim w As String = ""
        Select Case s
            Case "冷冻冷藏"
                w = "Login2_Adventage_Type_cold"
            Case "危险品"
                w = "Login2_Adventage_Type_dangerous"
            Case "罐箱"
                w = "Login2_Adventage_Type_tank"
            Case "其他特种柜"
                w = "Login2_Adventage_Type_particular"
            Case "散杂货船"
                w = "Login2_Adventage_Type_BULK"
            Case "进口"
                w = "Login2_Adventage_Type_input"
            Case "私人物品"
                w = "Login2_Adventage_Type_private"
        End Select
        Return w
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
