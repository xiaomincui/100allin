Imports System.Data

Partial Class search_company_bis
    Inherits System.Web.UI.Page

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.PreviousPage Is Nothing Then
            '第一次载入页面，显示所有记录
            If Not Page.IsPostBack Then
                LoadRecord(lblCurrentPage.Text)
            End If
        Else

            '重新搜索，页码置1
            lblCurrentPage.Text = "1"
            LoadRecord(lblCurrentPage.Text)
            'pnlSearchIntro.CssClass = "listTable"
        End If


        ''定义"搜索"按钮改变颜色的事件
        'ImageButton1.Attributes.Add("onmouseover", "this.src='../images/search_s.gif'")
        'ImageButton1.Attributes.Add("onmouseout", "this.src='../images/search.gif'")
        'ImageButton1.Attributes.Add("onfocus", "this.src='../images/search_s.gif'")
        'ImageButton1.Attributes.Add("onblur", "this.src='../images/search.gif'")

        '定义所有输入框按回车跳到下一格
        txtDestport.Attributes.Add("onkeydown", "KeyDown(event);")
        Dim tempsearch() As String
        Dim tempsearch_string As String

        If Not Request.Cookies("tempsearch") Is Nothing Then
            tempsearch_string = Request.Cookies("tempsearch").Value
            tempsearch = tempsearch_string.Split("|")
        Else
            tempsearch_string = ""
            tempsearch = tempsearch_string.Split("|")
        End If
        Label23.Text = Server.UrlDecode(tempsearch_string).Replace("|", "")


        '读取最近浏览过的运价列表
        Dim tempfreight_string As String
        If Not Request.Cookies("tempfreight") Is Nothing Then
            tempfreight_string = Request.Cookies("tempfreight").Value
        Else
            tempfreight_string = ""
        End If
        Label24.Text = Server.UrlDecode(tempfreight_string).Replace("|", "")
    End Sub


    '载入列表信息
    Sub LoadRecord(ByVal page As String)

        Dim ck As New check
        '取搜索条件，搜索条件保存在隐藏的label内
        Dim destport As String = ck.CheckInput(hidTxtDestport.Text)

        Dim keywords As String = destport
        Dim keyword As String()
        keyword = keywords.Split(" ")
        page = ck.CheckInput(page)

        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""

        'item是(页码-1)x10，用来计算分页用
        Dim item As Integer
        item = CInt(page - 1) * 15


        '无目的港搜索的select语句
        sql = "select top 15 "
        sql = sql & "id,机构名称,法人,经营范围,电话 "
        sql = sql & "FROM (SELECT "
        sql = sql & "id,机构名称,法人,经营范围,电话 "
        sql = sql & "FROM "
        sql = sql & "v_company_search "
        sql = sql & "WHERE "
        sql = sql & "1=1 "

        '加入筛选条件，编号，航线，起运港

        If destport <> "" Then
            If keyword.Length <= 3 Then
                For i As Integer = 0 To keyword.Length - 1
                    If keyword(i) <> "" Then
                        sql = sql & " AND 所有 like '%" & keyword(i) & "%' "
                    End If
                Next
            Else
                sql = sql & " AND 1=0 "
            End If
        End If

        sql = sql & ") AS T "
        sql = sql & "WHERE id NOT IN "
        sql = sql & "(SELECT TOP " & item.ToString & " id "
        sql = sql & "FROM "
        sql = sql & "v_company_search "
        sql = sql & "WHERE "
        sql = sql & "1=1 "

        '加入筛选条件，编号，航线，起运港
        If destport <> "" Then
            If keyword.Length <= 3 Then
                For i As Integer = 0 To keyword.Length - 1
                    If keyword(i) <> "" Then
                        sql = sql & " AND 所有 like '%" & keyword(i) & "%' "
                    End If
                Next
            Else
                sql = sql & " AND 1=0 "
            End If
        End If

        sql = sql & "ORDER BY id DESC "
        sql = sql & ") "
        sql = sql & "ORDER BY id DESC "

        ds = cn.mdb_ds(sql, "yunjia")

        'Repeater1.Enabled = True
        Repeater1.DataSource = ds.Tables("yunjia").DefaultView
        Repeater1.DataBind()
        '给表格加上框
        'GridView1.Attributes.Add("bordercolor ", "#D3EBF3")


        '计算页数
        LoadTotalCount()
    End Sub


    '计算页数
    Sub LoadTotalCount()

        '先动态删除下拉页码表所有的页码
        ddlPageSelect.Items.Clear()

        Dim ck As New check
        '取搜索条件，搜索条件保存在隐藏的label内
        Dim destport As String = ck.CheckInput(hidTxtDestport.Text)
        Dim keywords As String = destport
        Dim keyword As String()
        keyword = keywords.Split(" ")

        '访问数据库，统计记录条数
        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""


        sql = sql & "SELECT "
        sql = sql & "count(*) as T "
        sql = sql & "FROM "
        sql = sql & "v_company_search "
        sql = sql & "WHERE "
        sql = sql & "1=1 "

        '加入筛选条件，编号，航线，起运港
        If destport <> "" Then
            If keyword.Length <= 3 Then
                For i As Integer = 0 To keyword.Length - 1
                    If keyword(i) <> "" Then
                        sql = sql & " AND 所有 like '%" & keyword(i) & "%' "
                    End If
                Next
            Else
                MessageBox("a", "对不起，关键字数量不能大于3个")
                sql = sql & " AND 1=0 "
            End If
        End If

        ds = cn.mdb_ds(sql, "count")


        '计算出页数
        Dim item As Integer
        item = ds.Tables("count").Rows(0)(0)
        Dim page As Integer
        If item Mod 15 > 0 Or item = 0 Then
            page = item \ 15 + 1
        Else
            page = item \ 15
        End If



        '填充下拉页码框
        'For i As Integer = 0 To page - 1
        '    Dim l As New ListItem("第" & (i + 1).ToString & "页", (i + 1).ToString)
        '    ddlPageSelect.Items.Add(l)
        'Next
        For i As Integer = 0 To 10
            Dim l As New ListItem("第" & (i + 1).ToString & "页", (i + 1).ToString)
            ddlPageSelect.Items.Add(l)
        Next

        '最后改写总页码标签
        lblTotalItem.Text = item.ToString
        hidTotalItem.Text = item.ToString
        lblTotalPage.Text = page.ToString
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
            'ddlPageSelect.SelectedIndex = CInt(lblCurrentPage.Text) - 1
        Else
            MessageBox("opfail", "已经是第一页")
        End If
    End Sub

    '点击下一页链接
    Protected Sub lnkNextPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNextPage.Click
        If CInt(lblCurrentPage.Text) < CInt(lblTotalPage.Text) Then
            lblCurrentPage.Text = (CInt(lblCurrentPage.Text) + 1).ToString
            LoadRecord(lblCurrentPage.Text)
            'ddlPageSelect.SelectedIndex = CInt(lblCurrentPage.Text) - 1
        Else
            MessageBox("opfail", "已经是最后页")
        End If
    End Sub

    '点击最后页链接
    Protected Sub lnkLastPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLastPage.Click

        If CInt(lblCurrentPage.Text) <> CInt(lblTotalPage.Text) Then
            lblCurrentPage.Text = lblTotalPage.Text
            LoadRecord(lblCurrentPage.Text)
            'ddlPageSelect.SelectedIndex = CInt(lblCurrentPage.Text) - 1
        Else
            MessageBox("opfail", "已经是最后页")
        End If

    End Sub

    '选择页码下拉框
    'Protected Sub ddlPageSelect_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPageSelect.SelectedIndexChanged
    '    lblCurrentPage.Text = ddlPageSelect.SelectedIndex.ToString + 1
    '    LoadRecord(lblCurrentPage.Text)
    '    ddlPageSelect.SelectedIndex = CInt(lblCurrentPage.Text) - 1
    'End Sub

    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        '搜索条件保存在label控件内
        hidTxtDestport.Text = txtDestport.Text

        '重新搜索，页码置1
        lblCurrentPage.Text = "1"
        LoadRecord(lblCurrentPage.Text)

    End Sub
End Class
