
Partial Class Web_Admin_report_total1
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim returnValue As String

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


    '这个函数负责把字符串输出给客户端的javascript函数
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Try
            '等待0.1秒显示结果，给予服务器缓冲时间，并增强浏览效果
            System.Threading.Thread.Sleep(100)
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
            'Return RenderControl(DataList1)
            Return RenderControl(Panel1)
        Catch ex As Exception
            Return ex.ToString

        End Try

    End Function

    '这个函数读取从客户端callback来的字符串，读取后在服务器端放置在容器eventArgument内
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        returnValue = eventArgument
    End Sub


    Private Function RenderControl(ByVal control As Control)
        Dim writer1 As New IO.StringWriter(System.Globalization.CultureInfo.InvariantCulture)
        Dim writer2 As New UI.HtmlTextWriter(writer1)
        control.RenderControl(writer2)
        writer2.Flush()
        writer2.Close()
        Return writer1.ToString()
    End Function
End Class
