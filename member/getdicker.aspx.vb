Imports System.Data
Imports System
Imports System.IO
Partial Class member_getdicker
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

        'item是(页码-1)x10，用来计算分页用
        Dim item As Integer
        item = CInt(page - 1) * 10



        '无目的港搜索的select语句
        sql = "select top 10 "
        sql = sql & "did,readed,chater,listener,listener_realname,txt,cargo,reply,price,type,companyname,realname,username,chattime "
        sql = sql & "FROM (SELECT "
        sql = sql & "did,readed,chater,listener,listener_realname,txt,cargo,reply,price,type,companyname,realname,username,chattime "
        sql = sql & "FROM "
        sql = sql & "TB_DICKER "
        sql = sql & "WHERE "
        sql = sql & "1=1 "

        If Request.QueryString("filter") = "new" Then
            sql = sql & "AND readed = 0 "
            sql = sql & "AND listener = " & Me.Request.Cookies("user_id").Value.ToString
        End If


        If Request.QueryString("filter") = "my" Then
            sql = sql & "AND chater = " & Me.Request.Cookies("user_id").Value.ToString
        End If

        If Request.QueryString("filter") = "" Then
            sql = sql & "AND listener = " & Me.Request.Cookies("user_id").Value.ToString
        End If

        sql = sql & ") AS T "
        sql = sql & "WHERE did NOT IN "
        sql = sql & "(SELECT TOP " & item.ToString & " did "
        sql = sql & "FROM "
        sql = sql & "TB_DICKER "
        sql = sql & "WHERE "
        sql = sql & "1=1 "
        If Request.QueryString("filter") = "new" Then
            sql = sql & "AND readed = 0 "
            sql = sql & "AND listener = " & Me.Request.Cookies("user_id").Value.ToString
        End If


        If Request.QueryString("filter") = "my" Then
            sql = sql & "AND chater = " & Me.Request.Cookies("user_id").Value.ToString
        End If

        If Request.QueryString("filter") = "" Then
            sql = sql & "AND listener = " & Me.Request.Cookies("user_id").Value.ToString
        End If

        sql = sql & "ORDER BY did DESC "
        sql = sql & ") "
        sql = sql & "ORDER BY did DESC "
        'sql = sql & "WHERE "
        'sql = sql & "userid = " & id


        ds = cn.mdb_ds(sql, "yunjia")


        If Request.QueryString("filter") = "my" Then
            GridView2.DataSource = ds.Tables("yunjia").DefaultView
            GridView2.DataBind()
            '给表格加上框
            GridView2.Attributes.Add("bordercolor ", "#DBEEF5")
        Else

            GridView1.DataSource = ds.Tables("yunjia").DefaultView
            GridView1.DataBind()
            '给表格加上框
            GridView1.Attributes.Add("bordercolor ", "#DBEEF5")
        End If

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



        '访问数据库，统计记录条数
        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""



        sql = sql & "SELECT "
        sql = sql & "count(*) as T "
        sql = sql & "FROM "
        sql = sql & "TB_DICKER "
        sql = sql & "WHERE "
        sql = sql & "1=1 "
        If Request.QueryString("filter") = "new" Then
            sql = sql & "AND readed = 0 "
            sql = sql & "AND listener = " & Me.Request.Cookies("user_id").Value.ToString
        End If


        If Request.QueryString("filter") = "my" Then
            sql = sql & "AND chater = " & Me.Request.Cookies("user_id").Value.ToString
        End If

        If Request.QueryString("filter") = "" Then
            sql = sql & "AND listener = " & Me.Request.Cookies("user_id").Value.ToString
        End If

        'Response.Write(sql)
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
            sql = sql & "delete from TB_DICKER where did in (" & id & ")"
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

        '重新搜索，页码置1
        lblCurrentPage.Text = "1"
        LoadRecord(lblCurrentPage.Text)

    End Sub




    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
        LoadRecord(lblCurrentPage.Text)
    End Sub


    Public Function HeadExist(ByVal h As String) As String
        Dim path As String = Server.MapPath("/member/head/")
        path = path & h & ".jpg"
        If File.Exists(path) Then
            Return "1"
        Else
            Return "0"
        End If

    End Function

End Class
