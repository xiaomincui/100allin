
Partial Class message_Exhibition
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Dim ck As New check



        Dim cn As New data_conn
        Dim ds As Data.DataSet = cn.mdb_ds("select * from TB_Exhibition where id=" + ck.CheckNumber(Request("id")), "Exhibition")
        Labtitle.Text = ds.Tables("Exhibition").Rows(0)("title")
        Labposition.Text = "<a href='/message/Exhibition.aspx?id='" + ds.Tables("Exhibition").Rows(0)("id").ToString + " target='_blank'>" + ds.Tables("Exhibition").Rows(0)("title").ToString + "</a>"
        LabPostDate.Text = ds.Tables("Exhibition").Rows(0)("postdate")
        LabDetail.Text = ds.Tables("Exhibition").Rows(0)("detail")
        '读取最近浏览过的运价列表
        Dim tempfreight_string As String
        If Not Request.Cookies("tempfreight") Is Nothing Then
            tempfreight_string = Request.Cookies("tempfreight").Value
        Else
            tempfreight_string = ""
        End If
        Label22.Text = Server.UrlDecode(tempfreight_string).Replace("|", "")

        '读取最近浏览过的运价列表
        Dim tempsearch_string As String
        If Not Request.Cookies("tempsearch") Is Nothing Then
            tempsearch_string = Request.Cookies("tempsearch").Value
        Else
            tempsearch_string = ""
        End If
        Label23.Text = Server.UrlDecode(tempsearch_string).Replace("|", "")



    End Sub
End Class
