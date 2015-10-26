
Partial Class en_search_news
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim cn As New data_conn
            Dim ds As Data.DataSet = cn.mdb_ds("select * from TB_En_News where id=" + Request.QueryString("id").ToString, "new")
            Littitle.Text = ds.Tables("new").Rows(0)("title")
            Litcontent.Text = ds.Tables("new").Rows(0)("content")
        End If
    End Sub

End Class
