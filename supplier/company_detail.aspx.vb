Imports System.Data

Partial Class company_company_detail
    Inherits System.Web.UI.Page
    Public havefcl As String
    Public havelcl As String
    Public haveair As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ss As New SymmetricMethod
        If Page.IsPostBack = False Then
            LoadDetail()
            If Not Request.Cookies("user_name") Is Nothing Then
                If Request.Cookies("user_name").Value.ToString() <> "" Then
                    Label20.Text = "欢迎您！" + Server.UrlDecode(Request.Cookies("user_name").Value.ToString()) + " <a href=""/accounts/logout.aspx"">退出登录</a>"
                    'homelogin.Visible = True
                    'homelogout.Visible = False
                Else
                    Label20.Text = "欢迎您！" + "<a href=""/accounts/login.aspx "">登录</a>"
                    'homelogin.Visible = False
                    'homelogout.Visible = True
                End If
            Else
                Label20.Text = "欢迎您！" + "<a href=""/accounts/login.aspx"">登录</a>"
                'homelogin.Visible = False
                'homelogout.Visible = True
            End If
        End If

        If (Me.Request.Cookies("user_id") Is Nothing) Then
            Panel7.Visible = True
            Panel8.Visible = False
        Else
            If (Me.Request.Cookies("user_id").Value.ToString = "") Then
                Panel7.Visible = True
                Panel8.Visible = False
            Else
                Panel7.Visible = False
                Panel8.Visible = True
            End If

        End If
        txtPageJump.Attributes.Add("onkeydown", "PageJump();")

        If Not Request.Cookies("user_name") Is Nothing Then
            If (Request.Cookies("user_name").Value.ToString() <> "") Then
                Label19.Text = "<a href=""/accounts/logout.aspx"">退出登录</a>"
            Else
                Label19.Text = "<a href=""/accounts/login.aspx"">登录</a>"
            End If
        Else

            Label19.Text = "<a href=""/accounts/login.aspx"">登录</a>"
        End If


        'If Not Request.Cookies("user_lan") Is Nothing Then
        '    If (Request.Cookies("user_lan").Value = "0") Then
        '        usernewtop1_LinkButton1.Text = "繁體中文"
        '    Else
        '        usernewtop1_LinkButton1.Text = "简体中文"
        '    End If
        'Else
        '    usernewtop1_LinkButton1.Text = "繁體中文"
        'End If
    End Sub





    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub



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

    Sub LoadDetail()
        Dim ss As New SymmetricMethod
        Dim ck As New check
        Dim sql As String = ""



        Dim cid As String = ""
        Dim original_id As String = ""
        Dim p As Integer = 1

        Dim str As String = ck.CheckInput(Request.QueryString("str").ToString)
        Dim line As String = ck.CheckInput(Request.QueryString("line").ToString)
        Dim startport As String = ck.CheckInput(Request.QueryString("startport").ToString)





        Dim strs(3) As String
        strs = str.Split("/")
        original_id = strs(0)
        cid = strs(0)
        cid = ss.Decrypto(cid)


        Dim type As String = ""

        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim ds2 As New DataSet


        '提取起运港的中英文名称
        Dim sqlfrom As String
        Dim dsfrom As New DataSet
        sqlfrom = ""
        sqlfrom = sqlfrom & "SELECT cityname, citynamech "
        sqlfrom = sqlfrom & "FROM TB_CHINACITY "
        sqlfrom = sqlfrom & "WHERE "
        sqlfrom = sqlfrom & "cityname = '" & startport & "' "
        sqlfrom = sqlfrom & "OR citynamech = '" & startport & "' "
        dsfrom = cn.mdb_ds(sqlfrom, "city")

        Dim city0 As String = ""
        Dim city1 As String = ""

        If dsfrom.Tables("city").Rows.Count > 0 Then
            city0 = dsfrom.Tables("city").Rows(0)(0).ToString
            city1 = dsfrom.Tables("city").Rows(0)(1).ToString
        End If


        sql = "SELECT "
        sql = sql & "COUNT(*) "
        sql = sql & "FROM "
        sql = sql & "tb_user,tb_yunjia "
        sql = sql & "WHERE tb_user.userid = tb_yunjia.userid "
        sql = sql & "AND tb_yunjia.yunjialeixing = 8 "
        sql = sql & "AND tb_user.userid= " & cid
        sql = sql & "UNION ALL "
        sql = sql & "SELECT "
        sql = sql & "COUNT(*) "
        sql = sql & "FROM "
        sql = sql & "tb_user,tb_yunjia "
        sql = sql & "WHERE tb_user.userid = tb_yunjia.userid "
        sql = sql & "AND tb_yunjia.yunjialeixing = 9 "
        sql = sql & "AND tb_user.userid= " & cid
        sql = sql & "UNION ALL "
        sql = sql & "SELECT "
        sql = sql & "COUNT(*) "
        sql = sql & "FROM "
        sql = sql & "tb_user,t_airinfo "
        sql = sql & "WHERE tb_user.userid = t_airinfo.userid "
        sql = sql & "AND tb_user.userid= " & cid

        ds = cn.mdb_ds(sql, "user")

        havefcl = ds.Tables("user").Rows(0)(0).ToString()
        havelcl = ds.Tables("user").Rows(1)(0).ToString()
        haveair = ds.Tables("user").Rows(2)(0).ToString()

        If havefcl = "0" Then
            If havelcl = "0" Then
                If haveair = "0" Then

                Else
                    type = "air"
                End If
            Else
                type = "lcl"
            End If
        Else
            type = "fcl"
        End If

        If strs.Length = 3 Then
            type = strs(1)
            If strs(2) = "" Then

            Else
                p = Convert.ToInt32(strs(2))
            End If

        End If

        If strs.Length = 2 Then
            If strs(1) = "" Then

            Else
                type = strs(1)
            End If
        End If

        sql = "SELECT "
        sql = sql & "* "
        sql = sql & "FROM "
        sql = sql & "tb_user "
        sql = sql & "WHERE "
        sql = sql & "userid= " & cid

        'Response.Write(sql)
        ds = cn.mdb_ds(sql, "user")


        Label1.Text = ds.Tables("user").Rows(0)("companyname").ToString
        Literal4.Text = ds.Tables("user").Rows(0)("companyname").ToString
        Literal5.Text = ds.Tables("user").Rows(0)("companyname").ToString
        'Label2.Text = Label1.Text
        Label3.Text = ds.Tables("user").Rows(0)("introduction").ToString
        Label4.Text = "<span><a href=""/home/?" & ds.Tables("user").Rows(0)("ucenterhomeuid").ToString & """ style='font-size:14px; font-weight:bold; color:#FF6600;'>" & ds.Tables("user").Rows(0)("realname").ToString & "</a></span>"
        Literal25.Text = "<a href=""/member/pm_detail.aspx?pid=1&cid=" & ds.Tables("user").Rows(0)("userid").ToString & """ target=""_blank""><img src=""/images/fcl/bot_1.jpg""  border=""0"" style= 'margin-top: 12px;'/></a>"
        Literal26.Text = "<a href=""/member/addfriend.aspx?u=" & ds.Tables("user").Rows(0)("userid").ToString & """ target=""blank""><img src='/images/fcl/bot_2.jpg' border = '0' style= 'margin-top: 12px;'/></a>"
        Try
            ImageButton1.ImageUrl = "/images/get/company_tel.aspx?u=" & original_id
            ImageButton2.ImageUrl = "/images/get/company_fax.aspx?u=" & original_id
            ImageButton3.ImageUrl = "/images/get/company_email.aspx?u=" & original_id
            ImageButton4.ImageUrl = "/images/get/company_mobile.aspx?u=" & original_id
            'ImageButton5.ImageUrl = "/images/get/company_msn.aspx?u=" & original_id
        Catch ex As Exception

        End Try

        Label9.Text = ds.Tables("user").Rows(0)("postnumber").ToString
        Label11.Text = ds.Tables("user").Rows(0)("address").ToString

        If (ds.Tables("user").Rows(0)("star_allin").ToString = "0") Then
            ltrCSS.Text = "<link href=""/css2/shops.css"" rel=""stylesheet"" type=""text/css"" />"
            PlaceHolder1.Visible = False
            Literal6.Text = "公司简介&nbsp;<img src=""/images/shops/jt.gif"" />"
            Literal7.Text = "主要服务&nbsp;<img src=""/images/shops/jt.gif"" />"
            Literal8.Text = "优势航线&nbsp;<img src=""/images/shops/jt.gif"" />"
            Literal9.Text = "优势船公司&nbsp;<img src=""/images/shops/jt.gif"" />"
        Else
            ltrCSS.Text = "<link href=""/css2/shops2.css"" rel=""stylesheet"" type=""text/css"" />"
            PlaceHolder1.Visible = True
            Literal6.Text = "<img src=""/images2/shops/p1.gif"" width=""116"" height=""34"" />"
            Literal7.Text = "<img src=""/images2/shops/p2.gif"" width=""116"" height=""34"" />"
            Literal8.Text = "<img src=""/images2/shops/p3.gif"" width=""116"" height=""34"" />"
            Literal9.Text = "<img src=""/images2/shops/p4.gif"" width=""116"" height=""34"" />"
        End If

        LtrStars1.Text = Star1(ds.Tables("user").Rows(0)("star_allin").ToString)
        LtrStars2.Text = Star2(ds.Tables("user").Rows(0)("star_user").ToString)

        Label13.Text = ds.Tables("user").Rows(0)("usermsn").ToString
        Label13.Text = "<a href=""msnim:chat?contact=" & Label13.Text & """ ><img src=""/images/msn.gif"" style=""margin:0px"" border=0 alt=""Ta的MSN：" & Label13.Text & """ /></a>"

        Label14.Text = ds.Tables("user").Rows(0)("Userqq").ToString
        If (Label14.Text <> "") Then
            Label14.Text = "<a href=""tencent://message/?uin=" & Label14.Text & "&Site=www.100allin.com&Menu=yes"" ><img src=""/images/qq.gif"" style=""margin:0px"" border=0 alt=""Ta的QQ：" & Label14.Text & """ /></a>"
        End If

        If CBool(ds.Tables("user").Rows(0)("HeadURL")) = True Then
            imghead.Src = "/member/Head/" + ds.Tables("user").Rows(0)("UserID").ToString + ".jpg"
        Else
            imghead.Src = "/member/Head/default.jpg"
        End If

        'If CBool(ds.Tables("user").Rows(0)("Login2_Head")) = True Then
        '    imgcompanyhead.Src = "/member/companyhead/" + ds.Tables("user").Rows(0)("UserID").ToString + ".jpg"
        'Else
        '    imgcompanyhead.Src = "/images/shops/gs.gif"
        'End If

        Label15.Text = ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString
        Label16.Text = ds.Tables("user").Rows(0)("Login2_Adventage_Line").ToString
        Label17.Text = ds.Tables("user").Rows(0)("Login2_Adventage_Line2").ToString

        If ds.Tables("user").Rows(0)("Login2_Adventage_Type_fcl").ToString = 0 Then

        Else
            Label18.Text = "整箱海运"
        End If

        If ds.Tables("user").Rows(0)("Login2_Adventage_Type_lcl").ToString = 0 Then

        Else
            If Label18.Text = "" Then
                Label18.Text = "拼箱海运"
            Else
                Label18.Text = Label18.Text + " | 拼箱海运"
            End If
        End If

        If ds.Tables("user").Rows(0)("Login2_Adventage_Type_air").ToString = 0 Then

        Else
            If Label18.Text = "" Then
                Label18.Text = "空运"
            Else
                Label18.Text = Label18.Text + " | 空运"
            End If
        End If



        'item是(页码-1)x10，用来计算分页用
        Dim item As Integer

        item = CInt(p - 1) * 10


        If type = "fcl" Then
            Panel1.Visible = "true"
            Panel2.Visible = "false"
            Panel3.Visible = "false"
            Panel4.Visible = "true"
            Panel5.Visible = "false"
            Panel6.Visible = "false"

            sql = ""
            sql = "select top 10 "
            sql = sql & "shipcompany,sid,id,startport,title,hangxianmiaoshu,hits,destport,price20gp,price40gp,price40hq,price45hq,assurance,"
            sql = sql & "userid,"
            sql = sql & "companyname,"
            sql = sql & "star_allin,"
            sql = sql & "star_user,"
            sql = sql & "postdate,"
            sql = sql & "ifend,"
            sql = sql & "enddate "
            sql = sql & "FROM (SELECT "
            sql = sql & "distinct tb_yunjia.shipcompany1 as shipcompany,tb_yunjia.id as sid,'0' as id,tb_yunjia.startport as startport,tb_yunjia.title,tb_yunjia.hangxianmiaoshu,tb_yunjia.hits,tb_yunjia.DestPort1 as destport,tb_yunjia.price20gp1 as price20gp,tb_yunjia.price40gp1 as price40gp,tb_yunjia.price40hq1 as price40hq,tb_yunjia.price40hq1 as price45hq,tb_yunjia.assurance as assurance,"
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
            sql = sql & "AND tb_yunjia.yunjialeixing = 8 "
            sql = sql & "AND tb_yunjia.userid= " & cid
            sql = sql & " AND (tb_yunjia.startport like '%" & city0 & "%' "
            sql = sql & "OR tb_yunjia.startport like '%" & city1 & "%') "
            sql = sql & " AND tb_yunjia.hangxianmiaoshu= '" & line & "' "
            sql = sql & ") AS T "
            sql = sql & "WHERE sid NOT IN "
            sql = sql & "(SELECT id FROM"
            sql = sql & "(SELECT distinct TOP " & item.ToString & " tb_yunjia.id AS id,tb_yunjia.postdate "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_user.userid = tb_yunjia.userid "
            sql = sql & "AND tb_yunjia.yunjialeixing = 8 "
            sql = sql & "AND tb_yunjia.userid= " & cid
            sql = sql & " AND (tb_yunjia.startport like '%" & city0 & "%' "
            sql = sql & "OR tb_yunjia.startport like '%" & city1 & "%') "
            sql = sql & " AND tb_yunjia.startport= '" & startport & "' "
            sql = sql & " AND tb_yunjia.hangxianmiaoshu= '" & line & "' "
            sql = sql & "ORDER BY tb_yunjia.postdate DESC "
            sql = sql & ") AS T "
            sql = sql & ") "
            sql = sql & "ORDER BY postdate DESC "


            ds = cn.mdb_ds(sql, "yunjia")

            Rptfcl.DataSource = ds.Tables("yunjia").DefaultView
            Rptfcl.DataBind()


            sql = "SELECT "
            sql = sql & "count(tb_yunjia.id) as T "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia "
            sql = sql & "WHERE "
            sql = sql & "1=1  "
            sql = sql & "AND tb_yunjia.yunjialeixing = 8 "
            sql = sql & "AND tb_yunjia.userid= " & cid

            ds = cn.mdb_ds(sql, "count")

            'SEO部分，开始
            Dim seotitle As String = "-整箱海运价-公司商铺-环球运费网"
            Dim seokeywords As String = "整箱海运价-公司商铺-环球运费网"
            Dim seodescription As String = "整箱海运价-公司商铺-环球运费网"

            Literal1.Text = "<title>" & Label1.Text & "-" & seokeywords & "</title>"
            Literal2.Text = "<meta name=""keywords"" content=""" & Label1.Text & "-" & seokeywords & """ />"
            Literal3.Text = "<meta name=""description"" content=""" & Label1.Text & "-" & seodescription & """ />"

            ''SEO部分，结束
        End If

        If type = "lcl" Then
            Panel1.Visible = "false"
            Panel2.Visible = "true"
            Panel3.Visible = "false"
            Panel4.Visible = "false"
            Panel5.Visible = "true"
            Panel6.Visible = "false"

            sql = ""
            sql = "select top 10 "
            sql = sql & "shipcompany,sid,id,startport,title,hangxianmiaoshu,hits,destport,pricegp,pricegpv,assurance,"
            sql = sql & "userid,"
            sql = sql & "companyname,"
            sql = sql & "star_allin,"
            sql = sql & "star_user,"
            sql = sql & "postdate,"
            sql = sql & "ifend,"
            sql = sql & "enddate "
            sql = sql & "FROM (SELECT "
            sql = sql & "distinct tb_yunjia.shipcompany1 as shipcompany,tb_yunjia.id as sid,'0' as id,tb_yunjia.startport as startport,tb_yunjia.title,tb_yunjia.hangxianmiaoshu,tb_yunjia.hits,tb_yunjia.DestPort1 as destport,tb_yunjia.pricegp1 as pricegp,tb_yunjia.pricegpv1 as pricegpv,tb_yunjia.assurance as assurance,"
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
            sql = sql & "AND tb_yunjia.yunjialeixing = 9 "
            sql = sql & "AND tb_yunjia.userid= " & cid
            sql = sql & ") AS T "
            sql = sql & "WHERE sid NOT IN "
            sql = sql & "(SELECT id FROM"
            sql = sql & "(SELECT distinct TOP " & item.ToString & " tb_yunjia.id AS id,tb_yunjia.postdate "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_user.userid = tb_yunjia.userid "
            sql = sql & "AND tb_yunjia.yunjialeixing = 9 "
            sql = sql & "AND tb_yunjia.userid= " & cid
            sql = sql & "ORDER BY tb_yunjia.postdate DESC "
            sql = sql & ") AS T "
            sql = sql & ") "
            sql = sql & "ORDER BY postdate DESC "


            ds = cn.mdb_ds(sql, "yunjia")

            Rptlcl.DataSource = ds.Tables("yunjia").DefaultView
            Rptlcl.DataBind()


            sql = "SELECT "
            sql = sql & "count(tb_yunjia.id) as T "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia "
            sql = sql & "WHERE "
            sql = sql & "1=1  "
            sql = sql & "AND tb_yunjia.yunjialeixing = 9 "
            sql = sql & "AND tb_yunjia.userid= " & cid

            ds = cn.mdb_ds(sql, "count")
            'SEO部分，开始
            Dim seotitle As String = "-拼箱海运价-公司商铺-环球运费网"
            Dim seokeywords As String = "拼箱海运价-公司商铺-环球运费网-"
            Dim seodescription As String = "拼箱海运价-公司商铺-环球运费网-"

            Literal1.Text = "<title>" & Label1.Text & "-" & seokeywords & "</title>"
            Literal2.Text = "<meta name=""keywords"" content=""" & Label1.Text & "-" & seokeywords & """ />"
            Literal3.Text = "<meta name=""description"" content=""" & Label1.Text & "-" & seodescription & """ />"

            ''SEO部分，结束
        End If

        If type = "air" Then
            Panel1.Visible = "false"
            Panel2.Visible = "false"
            Panel3.Visible = "true"
            Panel4.Visible = "false"
            Panel5.Visible = "false"
            Panel6.Visible = "true"

            sql = ""
            sql = "select top 10 "
            sql = sql & "sid,id,startport,title,line,hits,destport,price_p45,price_p100,price_p300,price_p500,price_p1000,assurance,"
            sql = sql & "userid,"
            sql = sql & "companyname,"
            sql = sql & "star_allin,"
            sql = sql & "star_user,"
            sql = sql & "postdate,"
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
            sql = sql & "CONVERT(varchar(10), t_airinfo.enddate, 120) as enddate "
            sql = sql & "FROM "
            sql = sql & "t_airinfo,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_user.userid = t_airinfo.userid "


            sql = sql & "AND t_airinfo.userid= " & cid
            sql = sql & ") AS T "
            sql = sql & "WHERE sid NOT IN "
            sql = sql & "(SELECT id FROM"
            sql = sql & "(SELECT distinct TOP " & item.ToString & " t_airinfo.id AS id,t_airinfo.postdate "
            sql = sql & "FROM "
            sql = sql & "t_airinfo,tb_user "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_user.userid = t_airinfo.userid "
            sql = sql & "AND t_airinfo.userid= " & cid
            sql = sql & "ORDER BY t_airinfo.postdate DESC "
            sql = sql & ") AS T "
            sql = sql & ") "
            sql = sql & "ORDER BY postdate DESC "


            ds = cn.mdb_ds(sql, "yunjia")

            Rptair.DataSource = ds.Tables("yunjia").DefaultView
            Rptair.DataBind()


            sql = "SELECT "
            sql = sql & "count(t_airinfo.id) as T "
            sql = sql & "FROM "
            sql = sql & "t_airinfo "
            sql = sql & "WHERE "
            sql = sql & "1=1  "
            sql = sql & "AND t_airinfo.userid= " & cid

            ds = cn.mdb_ds(sql, "count")
            'SEO部分，开始
            Dim seotitle As String = "-空运运价-公司商铺-环球运费网"
            Dim seokeywords As String = "空运运价-公司商铺-环球运费网-"
            Dim seodescription As String = "空运运价-公司商铺-环球运费网-"

            Literal1.Text = "<title>" & Label1.Text & "-" & seokeywords & "</title>"
            Literal2.Text = "<meta name=""keywords"" content=""" & Label1.Text & "-" & seokeywords & """ />"
            Literal3.Text = "<meta name=""description"" content=""" & Label1.Text & "-" & seodescription & """ />"

            ''SEO部分，结束
        End If


        If strs.Length = 1 Then

            'SEO部分，开始
            Dim seotitle As String = "-公司商铺-环球运费网"
            Dim seokeywords As String = "公司商铺-环球运费网"
            Dim seodescription As String = "公司商铺-环球运费网"

            Literal1.Text = "<title>" & Label1.Text & "-" & seokeywords & "</title>"
            Literal2.Text = "<meta name=""keywords"" content=""" & Label1.Text & "-" & seokeywords & """ />"
            Literal3.Text = "<meta name=""description"" content=""" & Label1.Text & "-" & seodescription & """ />"

            'SEO部分，结束
        End If

        If strs.Length = 2 Then

            If strs(1) = "" Then
                'SEO部分，开始
                Dim seotitle As String = "-公司商铺-环球运费网"
                Dim seokeywords As String = "公司商铺-环球运费网"
                Dim seodescription As String = "公司商铺-环球运费网"

                Literal1.Text = "<title>" & Label1.Text & "-" & seokeywords & "</title>"
                Literal2.Text = "<meta name=""keywords"" content=""" & Label1.Text & "-" & seokeywords & """ />"
                Literal3.Text = "<meta name=""description"" content=""" & Label1.Text & "-" & seodescription & """ />"

                'SEO部分，结束
            End If


        End If



        '计算出页数
        Dim items As Integer = 0
        If Not ds.Tables("count") Is Nothing Then
            items = ds.Tables("count").Rows(0)(0)
            Panel9.Visible = True
        Else
            Panel9.Visible = False
        End If



        Dim pages As Integer
        If items Mod 10 > 0 Or items = 0 Then
            pages = items \ 10 + 1
        Else
            pages = items \ 10
        End If


        '以下为页码控制栏相关
        Dim s As String = ""
        Dim cp As Integer = 1
        cp = p
        Dim tp As Integer = pages

        If tp >= 100 Then
            tp = 100
        End If


        Dim base_url As String = "/company/" & strs(0) & "/" & type & "/"

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
            s = s + "<a href=""" + base_url + "1""><span><img src='/images/fcl/jt5.gif' width='9' height='9'  border=0 /></span></a> "
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

        Label12.Text = s

        lblTotalPage.Text = tp.ToString
        hidTotalPage.Value = tp.ToString
        lblCurrentPage.Text = cp.ToString
        txtPageJump.Value = cp.ToString



        sql = ""
        sql += "SELECT * FROM TB_User,TB_ORDER_ACCOUNT WHERE TB_User.userid = TB_ORDER_ACCOUNT.userid AND TB_User.userid = " + cid

        ds = cn.mdb_ds(sql, "account")

        ltrYz.Text = Star1(ds.Tables("account").Rows(0)("star_allin").ToString)
        'ltrKz.Text = Star2(ds.Tables("account").Rows(0)("star_user").ToString)
        'ltrYz1.Text = ltrYz.Text
        'ltrKz1.Text = ltrKz.Text

        'ltrBzj.Text = ds.Tables("account").Rows(0)("credit").ToString

        'ltrPf.Text = ds.Tables("account").Rows(0)("point").ToString
        ltrHp.Text = ds.Tables("account").Rows(0)("haoping").ToString
        ltrCp.Text = ds.Tables("account").Rows(0)("chaping").ToString

        If ds.Tables("account").Rows(0)("z_yingyezhizhao").ToString Then
            ltr_z_yingyezhizhao.Text = "<img src='/images/shops/t_1.gif'>"
        End If

        If ds.Tables("account").Rows(0)("z_shenfenzheng").ToString Then
            ltr_z_shenfenzheng.Text = "<img src='/images/shops/t_3.gif'>"
        End If

        If ds.Tables("account").Rows(0)("z_nvocc").ToString Then
            ltr_z_nvocc.Text = "<img src='/images/shops/t_2.gif'>"
        End If

        If ds.Tables("account").Rows(0)("z_kongyuntongpai").ToString Then
            ltr_z_kongyuntongpai.Text = "<img src='/images/shops/t_4.gif'>"
        End If

        ltrAnyuntong.Text = Star1(ds.Tables("account").Rows(0)("star_allin").ToString)
        ltrXinyu.Text = Star2(ds.Tables("account").Rows(0)("star_user").ToString)

        sql = ""
        sql += "SELECT * FROM TB_ORDER WHERE order_status = 5 and order_forward = " + cid

        ds = cn.mdb_ds(sql, "order")

        ltrCjcs.Text = ds.Tables("order").Rows.Count.ToString

        sql = ""
        sql += "SELECT * FROM TB_User,TB_ORDER WHERE TB_User.userid = TB_ORDER.order_shipper AND yiping_shipper = 1 AND order_forward = " + cid + " ORDER BY date_create DESC"
        ds = cn.mdb_ds(sql, "pingjia")

        RptPingjia.DataSource = ds.Tables("pingjia").DefaultView
        RptPingjia.DataBind()

        If ds.Tables("pingjia").Rows.Count = 0 Then
            phPingJia.Visible = False
        End If

        Try
            sql = ""
            sql = sql & "SELECT TB_ORDER.date_create, TB_ORDER.freight_code,TB_ORDER.freight_code1,TB_ORDER.freight_type, TB_ORDER.freight_code,TB_ORDER_STATUS.status_name_forward, TB_User.RealName, TB_ORDER.price_title,TB_ORDER.yiping_forward, TB_ORDER.ping_forward "
            sql = sql & "FROM TB_ORDER INNER JOIN "
            sql = sql & "TB_User ON TB_ORDER.order_shipper = TB_User.UserID INNER JOIN "
            sql = sql & "TB_ORDER_STATUS ON "
            sql = sql & "TB_ORDER.order_status = TB_ORDER_STATUS.sid "
            sql = sql & "WHERE TB_ORDER.order_status=6 AND TB_ORDER.order_forward = " & cid
            ds = cn.mdb_ds(sql, "order")

            RptOrder.DataSource = ds.Tables("order").DefaultView
            RptOrder.DataBind()

            If ds.Tables("order").Rows.Count = 0 Then
                phOrder.Visible = False
            End If

            If (ds.Tables("order").Rows.Count = 0) Then
                phNoOrder.Visible = True
            Else
                phNoOrder.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub btnPageJump_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPageJump.ServerClick
        Dim ss As New SymmetricMethod
        Dim ck As New check

        Dim cid As String = ""
        Dim type As String = "fcl"

        Dim str As String = ck.CheckInput(Request.QueryString("str").ToString)

        Dim strs(3) As String
        strs = str.Split("/")
        cid = strs(0)

        If Panel4.Visible = True Then
            type = "fcl"
        End If

        If Panel5.Visible = True Then
            type = "lcl"
        End If

        If Panel6.Visible = True Then
            type = "air"
        End If


        If IsNumeric(txtPageJump.Value) Then

            If CInt(txtPageJump.Value.ToString) < 1 Then
                Response.Redirect("/company/" & cid & "/" & "1")
            Else
                If CInt(txtPageJump.Value.ToString) > CInt(hidTotalPage.Value) Then
                    Response.Redirect("/company/" & cid & "/" & type & "/" & hidTotalPage.Value)
                Else
                    Response.Redirect("/company/" & cid & "/" & type & "/" & txtPageJump.Value)
                End If
            End If
        End If

    End Sub

    Public Function GetQueryString(ByVal q As String) As String

        Dim ss As New SymmetricMethod
        Dim ck As New check

        Dim cid As String = ""
        Dim type As String = "fcl"
        Dim p As Integer = 1

        Dim str As String = ck.CheckInput(Request.QueryString("str").ToString)

        Dim strs(3) As String
        strs = str.Split("/")

        If strs.Length = 3 Then
            cid = strs(0)
            type = strs(1)
            If strs(2) = "" Then

            Else
                p = Convert.ToInt32(strs(2))
            End If
        End If

        If strs.Length = 2 Then
            cid = strs(0)
            type = strs(1)
        End If

        If strs.Length = 1 Then
            cid = strs(0)
        End If

        If q = "cid" Then
            Return cid
        End If

        If q = "type" Then
            Return type
        End If

        If q = "p" Then
            Return p
        End If

    End Function


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
            ds = conn.mdb_ds("select YunJiaID,DESTPORT,price20gp,price40gp,price40hq,price45hq,shipcompany from TB_YunJiaInfo where YunJiaID in (" + ck.CheckInput(ids) + ") order by DESTPORT", "table")

            Dim str As String = ""
            For i = 0 To Rptfcl.Items.Count - 1
                Dim point As String = ""
                Dim j As Integer
                Dim count As Integer
                a = Rptfcl.Items(i).FindControl("Label1")
                If ds.Tables("table").Select("YunJiaID=" + a.Text).Length > 20 Then
                    count = 19
                    point = "$$......######"
                Else
                    count = ds.Tables("table").Select("YunJiaID=" + a.Text).Length - 1
                End If
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
                    str += "**"
                End If
            Next
            Hidden1.Value = str

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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
                    str += "**"
                End If
            Next
            Hiddennn1.Value = str
        End If
    End Sub


    Protected Sub Rptlcl_ItemDataBound(ByVal sender As Object, ByVal e As EventArgs) Handles Rptlcl.PreRender
        Dim ck As New check
        If Rptlcl.Items.Count <> 0 Then
            Dim ds As Data.DataSet
            Dim conn As New data_conn
            Dim a As Label
            Dim i As Integer
            a = Rptlcl.Items(0).FindControl("Label1")
            Dim ids As String = a.Text
            For i = 1 To Rptlcl.Items.Count - 1
                a = Rptlcl.Items(i).FindControl("Label1")
                ids += "," + a.Text
            Next
            ds = conn.mdb_ds("select YunJiaID,DESTPORT,pricegp,pricegpv,shipcompany from TB_YunJiaInfo where YunJiaID in (" + ck.CheckInput(ids) + ") order by DESTPORT", "table")

            Dim str As String = ""
            For i = 0 To Rptlcl.Items.Count - 1
                Dim point As String = ""
                Dim j As Integer
                Dim count As Integer
                a = Rptlcl.Items(i).FindControl("Label1")
                If ds.Tables("table").Select("YunJiaID=" + a.Text).Length > 20 Then
                    count = 19
                    point = "$$......######"
                Else
                    count = ds.Tables("table").Select("YunJiaID=" + a.Text).Length - 1
                End If
                For j = 0 To count
                    Dim k As Integer
                    For k = 1 To 4
                        str += ds.Tables("table").Select("YunJiaID=" + a.Text)(j).Item(k).ToString()
                        If k <> 4 Then
                            str += "##"
                        End If
                    Next
                    If j <> ds.Tables("table").Select("YunJiaID=" + a.Text).Length - 1 Then
                        str += "$$"
                    End If
                Next
                str += point
                If i <> Rptlcl.Items.Count - 1 Then
                    str += "**"
                End If
            Next
            Hidden1.Value = str

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            a = Rptlcl.Items(0).FindControl("Label2")
            ids = a.Text
            For i = 1 To Rptlcl.Items.Count - 1
                a = Rptlcl.Items(i).FindControl("Label2")
                ids += "," + a.Text
            Next
            ds = conn.mdb_ds("select * from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table")
            'Hiddennn1.Value = "select * from TB_User where UserID in (" + ids + ")"
            str = ""
            For i = 0 To Rptlcl.Items.Count - 1
                Dim point As String = ""
                Dim j As Integer
                Dim count As Integer
                a = Rptlcl.Items(i).FindControl("Label2")
                If ds.Tables("table").Select("UserID=" + a.Text).Length = 1 Then



                    str += "公司名称" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("CompanyName").ToString()
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
                If i <> Rptlcl.Items.Count - 1 Then
                    str += "**"
                End If
            Next
            Hiddennn1.Value = str
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


            ds = conn.mdb_ds("select airid,DESTPORT,PRICE_M,PRICE_N,PRICE_P45,PRICE_P100,PRICE_P300,PRICE_P500,PRICE_P1000 from t_airprice where airid in (" + ck.CheckInput(ids) + ") order by DESTPORT", "table")

            Dim str As String = ""
            For i = 0 To Rptair.Items.Count - 1
                Dim point As String = ""
                Dim j As Integer
                Dim count As Integer
                a = Rptair.Items(i).FindControl("Label1")
                If ds.Tables("table").Select("airid=" + a.Text).Length > 20 Then
                    count = 19
                    point = "$$......######"
                Else
                    count = ds.Tables("table").Select("airid=" + a.Text).Length - 1
                End If
                For j = 0 To count
                    Dim k As Integer
                    For k = 1 To 8
                        str += ds.Tables("table").Select("airid=" + a.Text)(j).Item(k).ToString()
                        If k <> 8 Then
                            str += "##"
                        End If
                    Next
                    If j <> ds.Tables("table").Select("airid=" + a.Text).Length - 1 Then
                        str += "$$"
                    End If
                Next
                str += point
                If i <> Rptair.Items.Count - 1 Then
                    str += "**"
                End If
            Next
            Hidden1.Value = str

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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
                    str += "**"
                End If
            Next
            Hiddennn1.Value = str
        End If
    End Sub


    'Protected Sub usernewtop1_LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles usernewtop1_LinkButton1.Click
    '    If Not Request.Cookies("user_lan") Is Nothing Then
    '        If Request.Cookies("user_lan").Value = "0" Then
    '            Response.Cookies("user_lan").Value = "1"
    '        Else
    '            Response.Cookies("user_lan").Value = "0"
    '            Response.Cookies("user_lan").Expires = DateTime.Now.AddDays(365)
    '        End If
    '    Else
    '        Response.Cookies("user_lan").Value = "1"
    '        Response.Cookies("user_lan").Expires = DateTime.Now.AddDays(365)
    '    End If

    '    Response.Redirect(Request.ServerVariables("HTTP_REFERER"))
    'End Sub


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
        Return sb.ToString()
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

    Public Shared Function Ping1(ByVal s As String) As String
        Dim ss As String = ""

        If s = "3" Then
            ss = "好评"
        End If

        If s = "0" Then
            ss = "中评"
        End If

        If s = "-3" Then
            ss = "差评"
        End If

        Return ss.ToString()
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


    Public Shared Function GetFreightType2(ByVal s1 As String) As String
        If s1 = "8" Then
            Return "fcl"
        End If

        If s1 = "9" Then
            Return "lcl"
        End If

        If s1 = "10" Then
            Return "air"
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
End Class
