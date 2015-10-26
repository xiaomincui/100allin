Imports System.Data

Partial Class pro_freight_manage_fcl
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ltrHeadTitle.Text = "运价 / 整箱运价管理"

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


        Dim cn As New pro_data_conn
        Dim ds As New DataSet
        Dim sql As String = ""

        'item是(页码-1)x10，用来计算分页用
        Dim item As Integer
        item = CInt(page - 1) * 10


        If destport = "" Then
            '无目的港搜索的select语句
            sql = "select top 10 "
            sql = sql & "id,startport,title,hangxianmiaoshu,"
            sql = sql & "postdate,"
            sql = sql & "enddate "
            sql = sql & "FROM (SELECT "
            sql = sql & "id,startport,title,hangxianmiaoshu,"
            sql = sql & "postdate,"
            sql = sql & "CONVERT(varchar(10), enddate, 120) as enddate "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia "
            sql = sql & "WHERE "
            sql = sql & "1=1 "
            sql = sql & "AND (userid = " & id & " or userid2 = " & id & ") "
            sql = sql & "AND yunjialeixing = 8 "

            '加入筛选条件，编号，航线，启运港
            If yunjiaid <> "" Then
                sql = sql & "AND tb_yunjia.id = " & yunjiaid & " "
            End If
            If line <> "" Then
                sql = sql & "AND hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                sql = sql & "AND startport like '%" & startport & "%' "
            End If

            sql = sql & ") AS T "
            sql = sql & "WHERE id NOT IN "
            sql = sql & "(SELECT TOP " & item.ToString & " id "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia "
            sql = sql & "WHERE "
            sql = sql & "1=1 "
            sql = sql & "AND (userid = " & id & " or userid2 = " & id & ") "
            sql = sql & "AND yunjialeixing = 8 "

            '加入筛选条件，编号，航线，启运港
            If yunjiaid <> "" Then
                sql = sql & "AND tb_yunjia.id = " & yunjiaid & " "
            End If
            If line <> "" Then
                sql = sql & "AND hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                sql = sql & "AND startport like '%" & startport & "%' "
            End If

            sql = sql & "ORDER BY tb_yunjia.postdate DESC "
            sql = sql & ") "
            sql = sql & "ORDER BY postdate DESC "
            'sql = sql & "WHERE "
            'sql = sql & "userid = " & id
        Else
            '有目的港搜索的select语句
            sql = "select top 10 "
            sql = sql & "id,startport,title,hangxianmiaoshu,"
            sql = sql & "postdate,"
            sql = sql & "enddate "
            sql = sql & "FROM (SELECT "
            sql = sql & "DISTINCT tb_yunjia.id as id,tb_yunjia.startport as startport,title,hangxianmiaoshu,"
            sql = sql & "postdate,"
            sql = sql & "CONVERT(varchar(10), enddate, 120) as enddate "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia,tb_yunjiainfo "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_yunjia.id = tb_yunjiainfo.yunjiaid "
            sql = sql & "AND (userid = " & id & " or userid2 = " & id & ") "
            sql = sql & "AND yunjialeixing = 8 "

            '加入筛选条件，编号，航线，启运港
            If yunjiaid <> "" Then
                sql = sql & "AND tb_yunjia.id = " & yunjiaid & " "
            End If
            If line <> "" Then
                sql = sql & "AND hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                sql = sql & "AND tb_yunjia.startport like '%" & startport & "%' "
            End If
            If destport <> "" Then
                sql = sql & "AND tb_yunjiainfo.destport like '%" & destport & "%' "
            End If
            sql = sql & ") AS T "

            sql = sql & "WHERE id NOT IN "
            sql = sql & "(SELECT id FROM"
            sql = sql & "(SELECT DISTINCT TOP " & item.ToString & " tb_yunjia.id AS id,postdate "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia,tb_yunjiainfo "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_yunjia.id = tb_yunjiainfo.yunjiaid "
            sql = sql & "AND (userid = " & id & " or userid2 = " & id & ") "
            sql = sql & "AND yunjialeixing = 8 "

            '加入筛选条件，编号，航线，启运港
            If yunjiaid <> "" Then
                sql = sql & "AND tb_yunjia.id = " & yunjiaid & " "
            End If
            If line <> "" Then
                sql = sql & "AND hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                sql = sql & "AND tb_yunjia.startport like '%" & startport & "%' "
            End If
            If destport <> "" Then
                sql = sql & "AND tb_yunjiainfo.destport like '%" & destport & "%' "
            End If

            sql = sql & "ORDER BY tb_yunjia.postdate DESC "
            sql = sql & ") AS T "
            sql = sql & ") "
            sql = sql & "ORDER BY postdate DESC "
            'sql = sql & "WHERE "
            'sql = sql & "userid = " & id
        End If

        ds = cn.mdb_ds(sql, "yunjia")

        GridView1.DataSource = ds.Tables("yunjia").DefaultView
        GridView1.DataBind()

        '给表格加上框
        GridView1.Attributes.Add("bordercolor ", "#eeeeee")

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
        Dim cn As New pro_data_conn
        Dim ds As New DataSet
        Dim sql As String = ""


        If destport = "" Then
            sql = sql & "SELECT "
            sql = sql & "count(*) as T "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia "
            sql = sql & "WHERE "
            sql = sql & "1=1 "
            sql = sql & "AND (userid = " & id & " or userid2 = " & id & ") "
            sql = sql & "AND yunjialeixing = 8 "

            If yunjiaid <> "" Then
                sql = sql & "AND tb_yunjia.id = " & yunjiaid & " "
            End If
            If line <> "" Then
                sql = sql & "AND hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                sql = sql & "AND startport like '%" & startport & "%' "
            End If

        Else
            sql = sql & "SELECT "
            sql = sql & "count(DISTINCT  tb_yunjia.id) as T "
            sql = sql & "FROM "
            sql = sql & "tb_yunjia,tb_yunjiainfo "
            sql = sql & "WHERE "
            sql = sql & "1=1 AND tb_yunjia.id = tb_yunjiainfo.yunjiaid "
            sql = sql & "AND (userid = " & id & " or userid2 = " & id & ") "
            sql = sql & "AND yunjialeixing = 8 "

            If yunjiaid <> "" Then
                sql = sql & "AND tb_yunjia.id = " & yunjiaid & " "
            End If
            If line <> "" Then
                sql = sql & "AND hangxianmiaoshu = '" & line & "' "
            End If
            If startport <> "" Then
                sql = sql & "AND tb_yunjia.startport like '%" & startport & "%' "
            End If
            If destport <> "" Then
                sql = sql & "AND tb_yunjiainfo.destport like '%" & destport & "%' "
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
            Dim cn As New pro_data_conn
            Dim sql As String
            sql = ""
            sql = sql & "delete from tb_yunjia where ID in (" & id & ")"
            cn.mdb_exe(sql)
            sql = "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.fclcount = (SELECT COUNT(tb_yunjia.id) AS yunjiacount FROM tb_yunjia,tb_yunjiainfo WHERE (yunjialeixing = 8) AND tb_yunjia.id = tb_yunjiainfo.yunjiaid),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1"
            cn.mdb_exe(sql)
            MessageBox("opsuccess", "删除成功")

            '清空delList
            delList.Text = ""


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

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowIndex <> -1 Then
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#A4CEE8';")  '当鼠标停留时更改背景色 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff';") '当鼠标移开时还原背景色 
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

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
End Class
