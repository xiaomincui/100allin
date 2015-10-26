Imports System.Data

Partial Class search_company_detail
    Inherits System.Web.UI.Page

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Request.QueryString("id") <> "" Then
            Dim ck As New check
            If ck.CheckNumber(Request.QueryString("id").ToString) <= 0 Then
                Response.Redirect("err.aspx")
            End If
            LoadBase()

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
        sql = sql & "company "
        sql = sql & "WHERE "
        sql = sql & "id= " & id
        ds = cn.mdb_ds(sql, "base")

        If ds.Tables("base").Rows.Count <= 0 Then
            Response.Redirect("err.aspx")
        End If


        '运价基本信息
        Page.Title = "环球运费网 - 公司库 - " & ds.Tables("base").Rows(0)("机构名称").ToString
        'lblWindowTitle.Text = "环球运费网 - 公司库 - " & ds.Tables("base").Rows(0)("机构名称").ToString
        Label1.Text = ds.Tables("base").Rows(0)("机构名称").ToString
        Label2.Text = ds.Tables("base").Rows(0)("法人").ToString
        Label3.Text = ds.Tables("base").Rows(0)("职位").ToString
        Label4.Text = ds.Tables("base").Rows(0)("经营范围").ToString
        Label5.Text = ds.Tables("base").Rows(0)("经济行业").ToString
        Label6.Text = ds.Tables("base").Rows(0)("经济类型").ToString
        Label7.Text = ds.Tables("base").Rows(0)("行政区号").ToString
        Label8.Text = ds.Tables("base").Rows(0)("地址").ToString
        Label9.Text = ds.Tables("base").Rows(0)("邮编").ToString
        Label10.Text = ds.Tables("base").Rows(0)("电话").ToString
        Label11.Text = ds.Tables("base").Rows(0)("手机").ToString
        Label12.Text = ds.Tables("base").Rows(0)("注册资金").ToString
        Label13.Text = ds.Tables("base").Rows(0)("地区").ToString
        Label14.Text = ds.Tables("base").Rows(0)("销售产品").ToString
        Label15.Text = ds.Tables("base").Rows(0)("采购产品").ToString
        Label16.Text = ds.Tables("base").Rows(0)("Email").ToString
        Label17.Text = ds.Tables("base").Rows(0)("传真").ToString
        Label18.Text = ds.Tables("base").Rows(0)("网站").ToString
        Label19.Text = ds.Tables("base").Rows(0)("成立时间").ToString
        Label20.Text = ds.Tables("base").Rows(0)("进出口业务规模").ToString
        Label21.Text = ds.Tables("base").Rows(0)("企业规模").ToString
        Label22.Text = ds.Tables("base").Rows(0)("企业简介").ToString

        lblWindowTitle.Text = ds.Tables("base").Rows(0)("机构名称").ToString

        Dim keywords As New HtmlMeta
        keywords.Name = "keywords"
        keywords.Content = "环球运费网 - 公司库 - 专业运价搜索查询和发布"
        Page.Header.Controls.Add(keywords)

        Dim descstring As String = ds.Tables("base").Rows(0)("机构名称").ToString & " | " & ds.Tables("base").Rows(0)("经营范围").ToString & " | " & ds.Tables("base").Rows(0)("地址").ToString

        Dim desc As New HtmlMeta
        desc.Name = "Description"
        desc.Content = descstring
        Page.Header.Controls.Add(desc)


    End Sub
End Class
