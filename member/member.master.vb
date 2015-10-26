Imports System.Data

Partial Class member_member
    Inherits System.Web.UI.MasterPage

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lg As New login
        lg.login()

        lblVip.Visible = False
        lblAdv.Visible = False

        LoadMember()
        If Me.Request.Cookies("user_id").Value.ToString = "24" Then
            lblVip.Visible = True
        Else
            lblVip.Visible = False
        End If

        If Me.Request.Cookies("user_id").Value.ToString = "28" Then
            lblAdv.Visible = True
        Else
            lblAdv.Visible = False
        End If


    End Sub

    Sub LoadMember()
        '显示用户名
        If Not Me.Request.Cookies("user_id") Is Nothing Then
            lblUserName.Text = Server.UrlDecode(Me.Request.Cookies("user_name").Value.ToString)
            UserPm()
        Else
            lblUserName.Text = "访客"
            '如果用户未登录，则跳转到网站首页
            Response.Redirect("/accounts/login.aspx?redirect_url=" & Server.UrlEncode(Request.Url.ToString()))
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Cookies("user_id").Value = ""
        Response.Cookies("user_name").Value = ""
        Response.Redirect("/")
    End Sub

    Sub UserPm()
        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""

        sql = "select count(mid) from TB_PM where readed = 0 and listener = " & Me.Request.Cookies("user_id").Value.ToString

        ds = cn.mdb_ds(sql, "pm")

        Label1.Text = " (<b style='color:red'>" & ds.Tables("pm").Rows(0)(0).ToString & "</b>条未读)"

        sql = "select count(did) from TB_DICKER where readed = 0 and listener = " & Me.Request.Cookies("user_id").Value.ToString

        ds = cn.mdb_ds(sql, "dk")

        Label2.Text = " (<b style='color:red'>" & ds.Tables("dk").Rows(0)(0).ToString & "</b>条未读)"

    End Sub

End Class

