Imports System.Data

Partial Class search_cargo_detail
    Inherits System.Web.UI.Page

    Public chatuser As String = ""
    Public chatowner As String = ""


    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Me.Request.Cookies("user_id") Is Nothing) Then
        Else
            chatowner = Me.Request.Cookies("user_id").Value.ToString
        End If

        If (Me.Request.Cookies("user_id") Is Nothing) Then
            Panel3.Visible = True
            PlaceHolder2.Visible = False
            Panel1.Visible = False

        Else
            If (Me.Request.Cookies("user_id").Value.ToString = "") Then
                Panel3.Visible = True
                PlaceHolder2.Visible = False
                Panel1.Visible = False
            Else

                Panel3.Visible = False
                PlaceHolder2.Visible = True
                Panel1.Visible = True
            End If

        End If

        If Me.Request.QueryString("id") <> "" Then
            Dim ck As New check
            If ck.CheckNumber(Request.QueryString("id").ToString) <= 0 Then
                Response.Redirect("err.aspx")
            End If
            LoadBase()
            AddHits()
        Else
            Response.Redirect("err.aspx")
        End If

    End Sub

    Sub LoadBase()
        Dim ck As New check
        Dim id As String = ck.CheckNumber(Request.QueryString("id").ToString)
        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""
        sql = sql & "SELECT "
        sql = sql & "* "
        sql = sql & "FROM "
        sql = sql & "tb_airgoods "
        sql = sql & "WHERE "
        sql = sql & "id= " & ck.CheckInput(id)
        ds = cn.mdb_ds(sql, "base")

        If ds.Tables("base").Rows.Count <= 0 Then
            Response.Redirect("err.aspx")
        End If

        '运价基本信息
        Label1.Text = ds.Tables("base").Rows(0)("title").ToString
        Label2.Text = Format(ds.Tables("base").Rows(0)("postdate"), "yyyy-MM-dd").ToString
        Label3.Text = Format(ds.Tables("base").Rows(0)("launchdate"), "yyyy-MM-dd").ToString
        Label4.Text = ds.Tables("base").Rows(0)("typem").ToString & " " & ds.Tables("base").Rows(0)("types").ToString
        Label5.Text = ds.Tables("base").Rows(0)("startport").ToString
        Label16.Text = ds.Tables("base").Rows(0)("destport").ToString
        Label6.Text = ds.Tables("base").Rows(0)("line").ToString
        Label7.Text = ds.Tables("base").Rows(0)("description").ToString
        Label17.Text = ds.Tables("base").Rows(0)("name").ToString
        Label18.Text = ds.Tables("base").Rows(0)("type").ToString
        Label19.Text = ds.Tables("base").Rows(0)("amount").ToString
        Label20.Text = ds.Tables("base").Rows(0)("payment").ToString
        Label22.Text = ds.Tables("base").Rows(0)("HITS").ToString
        If ds.Tables("base").Rows(0)("isdanger").ToString = True Then
            Label21.Text = "是"
        Else
            Label21.Text = "否"
        End If

        'SEO部分，开始
        Dim seotitle As String = "货盘信息-环球运费网"
        Dim seokeywords As String = "货盘，货代"
        Dim seodescription As String = "环球运费网提供最新最全面的国际货盘信息查询与发布:"

        Literal1.Text = "<title>" & ds.Tables("base").Rows(0)("name").ToString & "-" & ds.Tables("base").Rows(0)("title").ToString & "-" & seotitle & "</title>"
        Literal2.Text = "<meta name=""keywords"" content=""" & seokeywords & "运费"" />"
        Literal3.Text = "<meta name=""description"" content=""" & seodescription & "货盘类型-" & ds.Tables("base").Rows(0)("types").ToString & ",货物名称-" & Label17.Text & ",起运港-" & Label5.Text & ",目的港-" & Label16.Text & ",走货类型-" & ds.Tables("base").Rows(0)("typem").ToString & ".环球运费网提供最新最全面的国际货盘信息查询与发布"" />"


        'SEO部分，结束


        Dim user As String = ""

        user = ds.Tables("base").Rows(0)("userid").ToString

        chatuser = user

        LoadUser(user)


    End Sub



    '载入用户信息
    Sub LoadUser(ByVal id As String)
        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim ck As New check
        Dim sql As String = ""
        sql = sql & "SELECT "
        sql = sql & "* "
        sql = sql & "FROM "
        sql = sql & "tb_user "
        sql = sql & "WHERE "
        sql = sql & "userid= " & ck.CheckInput(id)
        ds = cn.mdb_ds(sql, "user")

        Label15.Text = ds.Tables("user").Rows(0)("realname").ToString
        Label8.Text = ds.Tables("user").Rows(0)("CompanyName").ToString
        Label9.Text = ds.Tables("user").Rows(0)("Phone").ToString
        'Label10.Text = ds.Tables("user").Rows(0)("Fax").ToString
        Label11.Text = ds.Tables("user").Rows(0)("MovePhone").ToString
        Label12.Text = ds.Tables("user").Rows(0)("UserEmail").ToString
        Label13.Text = ds.Tables("user").Rows(0)("Address").ToString & "<span classid=""edushianchor"" city=""" & ds.Tables("user").Rows(0)("city").ToString & """ sitename=""" & ds.Tables("user").Rows(0)("CompanyName").ToString & """ address=""" & ds.Tables("user").Rows(0)("Address").ToString & """ style=""display:none""></span>"
        Label14.Text = ds.Tables("user").Rows(0)("PostNumber").ToString


        If CBool(ds.Tables("user").Rows(0)("HeadURL")) = True Then
            imghead.Src = "/member/Head/" + ds.Tables("user").Rows(0)("UserID").ToString + ".jpg"
        Else
            imghead.Src = "/member/Head/default.jpg"
        End If




        If ds.Tables("user").Rows(0)("introduction").ToString = "" Then
            'trintroduction.Visible = False
            Label27.Text = ""
        Else
            Label27.Text = ds.Tables("user").Rows(0)("introduction").ToString
        End If
        'If ds.Tables("user").Rows(0)("Usermsn").ToString <> "" Then
        '    Label16.Text = ds.Tables("user").Rows(0)("Usermsn").ToString & "&nbsp;&nbsp;<a href=""msnim:chat?contact=" & ds.Tables("user").Rows(0)("Usermsn").ToString & """ >马上M我</a>"
        'End If
        'If ds.Tables("user").Rows(0)("Userqq").ToString <> "" Then
        '    Label17.Text = ds.Tables("user").Rows(0)("Userqq").ToString & "&nbsp;&nbsp;<a href=""tencent://message/?uin=" & ds.Tables("user").Rows(0)("Userqq").ToString & "&Site=www.100allin.com&Menu=yes"" >马上Q我</a>"
        'End If
        'Label66.Text = "<a href='/home/?99999' target='blank'><img src='images/fcl/bot_3.gif' border = '0' /></a>"

        If ds.Tables("user").Rows(0)("UCenterHomeUid").ToString <> "" Then
            'Label66.Text = "<a href='/home/?" + ds.Tables("user").Rows(0)("UCenterHomeUid").ToString + "' target='blank'><img src='/search/images/fcl/bot_3.gif' border = '0' /></a>"
        End If

        Dim dsCommentCount As Data.DataSet = cn.mdb_ds("select count(*) from TB_Message_Comment where issuer=" + ds.Tables("user").Rows(0)("UserID").ToString, "commentcount")
        Dim dsYunjiaCount As Data.DataSet = cn.mdb_ds("select count(*) from TB_YunJia,TB_YunJiaInfo where TB_YunJia.id=TB_YunJiaInfo.YunJiaID and Userid=" + ds.Tables("user").Rows(0)("UserID").ToString, "commentcount")
        LabCommentCount.Text = dsCommentCount.Tables(0).Rows(0)(0).ToString
        LabYunjiaCount.Text = dsYunjiaCount.Tables(0).Rows(0)(0).ToString

        Label25.Text = "<a href=""/member/pm_detail.aspx?pid=1&cid=" & ds.Tables("user").Rows(0)("userid").ToString & """ target=""_blank""><img src=""/images/fcl/bot_1.jpg"" style=""margin-top:6px;"" border=""0"" /></a>"

    End Sub

    Sub AddHits()
        Dim ck As New check
        Dim id As String = ck.CheckNumber(Request.QueryString("id").ToString)
        Dim cn As New data_conn
        '增加一次点击
        Dim sql_hits As String = ""
        sql_hits = sql_hits & "UPDATE "
        sql_hits = sql_hits & "tb_airgoods "
        sql_hits = sql_hits & "SET "
        sql_hits = sql_hits & "hits = hits + 1 "
        sql_hits = sql_hits & "WHERE "
        sql_hits = sql_hits & "id= " & id
        cn.mdb_exe(sql_hits)
    End Sub


    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub
End Class
