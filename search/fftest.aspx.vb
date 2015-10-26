Imports System.Data

Partial Class search_fftest
    Inherits System.Web.UI.Page
    Public chatuser As String = ""
    Public chatowner As String = ""
    Public ddest As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadDetail()
    End Sub

    Sub LoadDetail()
        Dim ss As New SymmetricMethod
        Dim ck As New check
        Dim id As String = ck.CheckNumber(ss.Decrypto(Request.QueryString("yid").ToString))
	Response.Write(id)
    End Sub

End Class
