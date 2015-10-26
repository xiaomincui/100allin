Imports System.Data
Partial Class en_member_office_fcl_list
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '取保存在Cookies中的用户编号id
        Dim id As String = ""
        If Not Me.Request.Cookies("user_id") Is Nothing Then
            If Not Page.IsPostBack Then
                id = Me.Request.Cookies("user_id").Value.ToString
                LoadRecord(lblCurrentPage.Text)
            End If
        Else
            '如果用户未登录，则跳转到网站首页
            Response.Redirect("/")
        End If

        '在页头加入该页所属的CSS文件链接
        AddStyleSheet(Me.Page, "css/list.css")
    End Sub


    '在页头加入CSS文件链接的函数
    Sub AddStyleSheet(ByVal page As Page, ByVal cssPath As String)
        Dim link As New HtmlLink
        link.Href = cssPath
        link.Attributes("rel") = "stylesheet"
        link.Attributes("type") = "text/css"
        page.Header.Controls.Add(link)
    End Sub

    '载入列表信息
    Sub LoadRecord(ByVal page As String)

        Dim ck As New check
        '取搜索条件，搜索条件保存在隐藏的label内
        Dim yunjiaid As String = ck.CheckInput(hidTxtYunjiaid.Text)
        Dim line As String = ck.CheckInput(hidTxtLine.Text)
        Dim startport As String = ck.CheckInput(hidTxtStartport.Text)
        Dim destport As String = ck.CheckInput(hidTxtDestport.Text)


        '取保存在Cookies中的用户编号id
        Dim id As String = ""
        If Not Me.Request.Cookies("user_id") Is Nothing Then
            id = Me.Request.Cookies("user_id").Value.ToString
        Else
            '如果用户未登录，则跳转到网站首页
            Response.Redirect("/")
        End If


        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""

        '跳转
        Dim check As New check
        Dim ds2 As Data.DataSet
        Dim conn As New data_conn3
        sql = "select * from TB_User where UserID=" + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
        ds2 = conn.mdb_ds(sql, "table")

        If CInt(ds2.Tables("table").Rows(0)("User_Level").ToString()) = 0 Then
            Me.Response.Redirect("../accounts/regnormal.aspx")
        End If

        'item是(页码-1)x10，用来计算分页用
        Dim item As Integer
        item = CInt(page - 1) * 10


        If destport = "" Then
            '无目的港搜索的select语句
            sql = "select top 10 "
            sql = sql & "id,startport,entitle,title,line,"
            sql = sql & "postdate,"
            sql = sql & "enddate "
            sql = sql & "FROM (SELECT "
            sql = sql & "id,startport,entitle,title,line,"
            sql = sql & "postdate,"
            sql = sql & "CONVERT(varchar(10), enddate, 120) as enddate "
            sql = sql & "FROM "
            sql = sql & "t_airinfo "
            sql = sql & "WHERE "
            sql = sql & "ifEn=1 "
            sql = sql & "AND (userid = " & id & " or userid2 = " & id & ") "

            '加入筛选条件，编号，航线，启运港
            If yunjiaid <> "" Then
                sql = sql & "AND t_airinfo.id = " & yunjiaid & " "
            End If
            If line <> "" Then
                sql = sql & "AND line = '" & line & "' "
            End If
            If startport <> "" Then
                sql = sql & "AND startport like '%" & startport & "%' "
            End If

            sql = sql & ") AS T "
            sql = sql & "WHERE id NOT IN "
            sql = sql & "(SELECT TOP " & item.ToString & " id "
            sql = sql & "FROM "
            sql = sql & "t_airinfo "
            sql = sql & "WHERE "
            sql = sql & "ifEn=1 "
            sql = sql & "AND (userid = " & id & " or userid2 = " & id & ") "

            '加入筛选条件，编号，航线，启运港
            If yunjiaid <> "" Then
                sql = sql & "AND t_airinfo.id = " & yunjiaid & " "
            End If
            If line <> "" Then
                sql = sql & "AND line = '" & line & "' "
            End If
            If startport <> "" Then
                sql = sql & "AND startport like '%" & startport & "%' "
            End If
            sql = sql & "ORDER BY t_airinfo.postdate DESC "
            sql = sql & ") "
            sql = sql & "ORDER BY postdate DESC "
            'sql = sql & "WHERE "
            'sql = sql & "userid = " & id
        Else
            '有目的港搜索的select语句
            sql = "select top 10 "
            sql = sql & "id,startport,entitle,title,line,"
            sql = sql & "postdate,"
            sql = sql & "enddate "
            sql = sql & "FROM (SELECT "
            sql = sql & "DISTINCT t_airinfo.id as id,t_airinfo.startport as startport,entitle,title,line,"
            sql = sql & "postdate,"
            sql = sql & "CONVERT(varchar(10), enddate, 120) as enddate "
            sql = sql & "FROM "
            sql = sql & "t_airinfo,t_airprice "
            sql = sql & "WHERE "
            sql = sql & "ifEn=1 AND t_airinfo.id = t_airprice.airid "
            sql = sql & "AND (userid = " & id & " or userid2 = " & id & ") "

            '加入筛选条件，编号，航线，启运港
            If yunjiaid <> "" Then
                sql = sql & "AND t_airinfo.id = " & yunjiaid & " "
            End If
            If line <> "" Then
                sql = sql & "AND line = '" & line & "' "
            End If
            If startport <> "" Then
                sql = sql & "AND t_airinfo.startport like '%" & startport & "%' "
            End If
            If destport <> "" Then
                sql = sql & "AND t_airprice.destport like '%" & destport & "%' "
            End If
            sql = sql & ") AS T "

            sql = sql & "WHERE id NOT IN "
            sql = sql & "(SELECT id FROM"
            sql = sql & "(SELECT DISTINCT TOP " & item.ToString & " t_airinfo.id AS id,postdate "
            sql = sql & "FROM "
            sql = sql & "t_airinfo,t_airprice "
            sql = sql & "WHERE "
            sql = sql & "ifEn=1 AND t_airinfo.id = t_airprice.airid "
            sql = sql & "AND (userid = " & id & " or userid2 = " & id & ") "

            '加入筛选条件，编号，航线，启运港
            If yunjiaid <> "" Then
                sql = sql & "AND t_airinfo.id = " & yunjiaid & " "
            End If
            If line <> "" Then
                sql = sql & "AND line = '" & line & "' "
            End If
            If startport <> "" Then
                sql = sql & "AND t_airinfo.startport like '%" & startport & "%' "
            End If
            If destport <> "" Then
                sql = sql & "AND t_airprice.destport like '%" & destport & "%' "
            End If

            sql = sql & "ORDER BY t_airinfo.postdate DESC "
            sql = sql & ") AS T "
            sql = sql & ") "
            sql = sql & "ORDER BY postdate DESC "
            'sql = sql & "WHERE "
            'sql = sql & "userid = " & id
        End If

        ds = cn.mdb_ds(sql, "yunjia")

        Repeater1.DataSource = ds.Tables("yunjia").DefaultView
        Repeater1.DataBind()


        '计算页数
        LoadTotalCount()
    End Sub


    '计算页数
    Sub LoadTotalCount()

        '取保存在Cookies中的用户编号id
        Dim id As String = ""
        If Not Me.Request.Cookies("user_id") Is Nothing Then
            id = Me.Request.Cookies("user_id").Value.ToString
        Else
            '如果用户未登录，则跳转到网站首页
            Response.Redirect("/")
        End If

        '先动态删除下拉页码表所有的页码
        ddlPageSelect.Items.Clear()

        Dim ck As New check
        '取搜索条件，搜索条件保存在隐藏的label内
        Dim yunjiaid As String = ck.CheckInput(hidTxtYunjiaid.Text)
        Dim line As String = ck.CheckInput(hidTxtLine.Text)
        Dim startport As String = ck.CheckInput(hidTxtStartport.Text)
        Dim destport As String = ck.CheckInput(hidTxtDestport.Text)


        '访问数据库，统计记录条数
        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""


        If destport = "" Then
            sql = sql & "SELECT "
            sql = sql & "count(*) as T "
            sql = sql & "FROM "
            sql = sql & "t_airinfo "
            sql = sql & "WHERE "
            sql = sql & "ifEn=1 "
            sql = sql & "AND (userid = " & id & " or userid2 = " & id & ") "

            If yunjiaid <> "" Then
                sql = sql & "AND t_airinfo.id = " & yunjiaid & " "
            End If
            If line <> "" Then
                sql = sql & "AND line = '" & line & "' "
            End If
            If startport <> "" Then
                sql = sql & "AND startport like '%" & startport & "%' "
            End If

        Else
            sql = sql & "SELECT "
            sql = sql & "count(DISTINCT  t_airinfo.id) as T "
            sql = sql & "FROM "
            sql = sql & "t_airinfo,t_airprice "
            sql = sql & "WHERE "
            sql = sql & "ifEn=1 AND t_airinfo.id = t_airprice.airid "
            sql = sql & "AND (userid = " & id & " or userid2 = " & id & ") "

            If yunjiaid <> "" Then
                sql = sql & "AND t_airinfo.id = " & yunjiaid & " "
            End If
            If line <> "" Then
                sql = sql & "AND line = '" & line & "' "
            End If
            If startport <> "" Then
                sql = sql & "AND t_airinfo.startport like '%" & startport & "%' "
            End If
            If destport <> "" Then
                sql = sql & "AND t_airprice.destport like '%" & destport & "%' "
            End If

        End If


        ds = cn.mdb_ds(sql, "count")


        '计算出页数
        Dim item As Integer
        item = ds.Tables("count").Rows(0)(0)
        Dim page As Integer
        If item Mod 10 > 0 Or item = 0 Then
            page = item \ 10 + 1
        Else
            page = item \ 10
        End If



        '填充下拉页码框
        For i As Integer = 0 To page - 1
            Dim l As New ListItem("第" & (i + 1).ToString & "页", (i + 1).ToString)
            ddlPageSelect.Items.Add(l)
        Next

        '最后改写总页码标签
        lblTotalItem.Text = item.ToString
        hidTotalItem.Text = item.ToString
        lblTotalPage.Text = page.ToString
    End Sub

    Sub delete()
        '删除信息
        '要删除的纪录的ID，保存在delList隐藏控件内
        Dim id As String = delList.Text
        If id <> "" Then
            Dim cn As New data_conn
            Dim sql As String
            sql = ""
            sql = sql & "delete from t_airinfo where ID in (" & id & ")"
            cn.mdb_exe(sql)
            sql = "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.aircount = (SELECT COUNT(t_airinfo.id) AS yunjiacount FROM t_airinfo,t_airprice WHERE t_airinfo.id = t_airprice.airid),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1"
            cn.mdb_exe(sql)
            MessageBox("opsuccess", "删除成功")

            '清空delList
            delList.Text = ""

            '同步topnew
            Dim tp As New topnew
            tp.CheckTopNew("10", Me.Request.Cookies("user_id").Value.ToString)
        Else
            '没有选择任何要删除的ID，弹出此对话框
            MessageBox("opfail", "未选择任何要删除的项目")
        End If
    End Sub

    '点击第一页链接
    Protected Sub lnkFirstPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFirstPage.Click
        If CInt(lblCurrentPage.Text) <> 1 Then
            lblCurrentPage.Text = "1"
            LoadRecord(lblCurrentPage.Text)
            ddlPageSelect.SelectedIndex = CInt(lblCurrentPage.Text) - 1
        Else
            MessageBox("opfail", "已经是第一页")
        End If


    End Sub

    '点击上一页链接
    Protected Sub lnkPrePage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrePage.Click
        If CInt(lblCurrentPage.Text) > 1 Then
            lblCurrentPage.Text = (CInt(lblCurrentPage.Text) - 1).ToString
            LoadRecord(lblCurrentPage.Text)
            ddlPageSelect.SelectedIndex = CInt(lblCurrentPage.Text) - 1
        Else
            MessageBox("opfail", "已经是第一页")
        End If
    End Sub

    '点击下一页链接
    Protected Sub lnkNextPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNextPage.Click
        If CInt(lblCurrentPage.Text) < CInt(lblTotalPage.Text) Then
            lblCurrentPage.Text = (CInt(lblCurrentPage.Text) + 1).ToString
            LoadRecord(lblCurrentPage.Text)
            ddlPageSelect.SelectedIndex = CInt(lblCurrentPage.Text) - 1
        Else
            MessageBox("opfail", "已经是最后页")
        End If
    End Sub

    '点击最后页链接
    Protected Sub lnkLastPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLastPage.Click

        If CInt(lblCurrentPage.Text) <> CInt(lblTotalPage.Text) Then
            lblCurrentPage.Text = lblTotalPage.Text
            LoadRecord(lblCurrentPage.Text)
            ddlPageSelect.SelectedIndex = CInt(lblCurrentPage.Text) - 1
        Else
            MessageBox("opfail", "已经是最后页")
        End If

    End Sub

    '选择页码下拉框
    Protected Sub ddlPageSelect_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPageSelect.SelectedIndexChanged
        lblCurrentPage.Text = ddlPageSelect.SelectedIndex.ToString + 1
        LoadRecord(lblCurrentPage.Text)
        ddlPageSelect.SelectedIndex = CInt(lblCurrentPage.Text) - 1
    End Sub


    '点击隐藏的删除记录按钮
    Protected Sub btnHidDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHidDel.Click
        '删除被选择的记录
        delete()
        '重新载入当前页
        LoadRecord(lblCurrentPage.Text)

        '如果当前页码大于总页码，不合理，于是载入前一页
        If CInt(lblCurrentPage.Text) > CInt(lblTotalPage.Text) Then
            lblCurrentPage.Text = lblCurrentPage.Text - 1
            LoadRecord(lblCurrentPage.Text)
        Else
            LoadRecord(lblCurrentPage.Text)
        End If
    End Sub

    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub

    Protected Sub btnHidSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHidSearch.Click

        '搜索条件保存在label控件内
        hidTxtYunjiaid.Text = txtYunjiaid.Text
        hidTxtLine.Text = txtLine.SelectedValue
        hidTxtStartport.Text = txtStartport.Text
        hidTxtDestport.Text = txtDestport.Text

        '重新搜索，页码置1
        lblCurrentPage.Text = "1"
        LoadRecord(lblCurrentPage.Text)

        pnlSearchIntro.CssClass = "listTable"
    End Sub



    Protected Sub lnkShowAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkShowAll.Click
        '搜索条件保存在label控件内
        hidTxtYunjiaid.Text = ""
        hidTxtLine.Text = ""
        hidTxtStartport.Text = ""
        hidTxtDestport.Text = ""

        '重新搜索，页码置1
        lblCurrentPage.Text = "1"
        LoadRecord(lblCurrentPage.Text)

        pnlSearchIntro.CssClass = "hidden"
    End Sub

    Public Function key(ByVal es As String) As String
        Dim s As New SymmetricMethod
        Return s.Encrypto(es)
    End Function

    Sub update()
        '更新信息
        '要更新的纪录的ID，保存在delList隐藏控件内
        Dim id As String = delList.Text
        If id <> "" Then
            Dim cn As New data_conn

            Dim enddate As String = ""
            Dim dt As DateTime = DateTime.Now
            Dim startMonth As DateTime = dt.AddDays(1 - dt.Day)
            Dim endMonth As DateTime = startMonth.AddMonths(1).AddDays(-1)

            If DateTime.Now.Day >= 15 Then
                enddate = endMonth.ToString().Split(" ")(0)
            Else
                enddate = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + "15"
            End If

            Dim sql As String
            sql = ""
            sql = sql & "update t_airinfo set PostDate=getdate(),enddate='" + enddate + "' where ID in (" & id & ")"
            cn.mdb_exe(sql)
            sql = ""
            sql = sql & "update T_AIRPRICE set PostDatex=getdate(),enddatex='" + enddate + "' where AIRID in (" & id & ")"
            cn.mdb_exe(sql)
            sql = "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.aircount = (SELECT COUNT(t_airinfo.id) AS yunjiacount FROM t_airinfo,t_airprice WHERE t_airinfo.id = t_airprice.airid),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1"
            cn.mdb_exe(sql)
            MessageBox("opsuccess", "更新成功")

            '清空delList
            delList.Text = ""

            '同步topnew
            Dim tp As New topnew
            tp.CheckTopNew("10", Me.Request.Cookies("user_id").Value.ToString)
        Else
            '没有选择任何要删除的ID，弹出此对话框
            MessageBox("opfail", "未选择任何要更新的项目")
        End If

    End Sub


    Protected Sub btnHidUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHidUpdate.Click
        '删除被选择的记录
        update()
        '重新载入当前页
        LoadRecord(lblCurrentPage.Text)

        '如果当前页码大于总页码，不合理，于是载入前一页
        If CInt(lblCurrentPage.Text) > CInt(lblTotalPage.Text) Then
            lblCurrentPage.Text = lblCurrentPage.Text - 1
            LoadRecord(lblCurrentPage.Text)
        Else
            LoadRecord(lblCurrentPage.Text)
        End If
    End Sub

    Public Function LineCNtoEN(ByVal line As String) As String
        Select Case line
            Case "澳洲线"
                Return "Australia"
            Case "非洲线"
                Return "Africa"
            Case "北美线"
                Return "North America"
            Case "南美线"
                Return "South America"
            Case "欧洲线"
                Return "Euro"
            Case "亚洲线"
                Return "Asia"
            Case "国内航线"
                Return "China"
            Case Else
                Return "error"
        End Select
    End Function



End Class
