
Partial Class Web_Admin_report_total
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cn As New data_conn
        Dim ds_sea As New Data.DataSet
        Dim ds_air As New Data.DataSet
        Dim mysql_sea As String
        Dim mysql_air As String
        mysql_sea = ""
        mysql_air = ""
        mysql_sea = "select count(*) as total from TB_YunJiaInfo"
        mysql_air = "select count(*) as total from T_AIRPRICE"


        ds_sea = cn.mdb_ds(mysql_sea, "TB_YunJiaInfo")
        ds_air = cn.mdb_ds(mysql_air, "T_AIRPRICE")

        Label2.Text = ds_sea.Tables("TB_YunJiaInfo").Rows(0)(0).ToString
        Label5.Text = ds_air.Tables("T_AIRPRICE").Rows(0)(0).ToString

    End Sub
End Class
