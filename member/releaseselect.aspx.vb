Imports System.Data
Imports System.Net

Partial Class member_releaseselect
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '取保存在Cookies中的用户编号
        Dim id As String = ""


        If (Me.Request.Cookies("user_id") Is Nothing) Then
            '如果用户未登录，则跳转到首页
            Response.Redirect("/accounts/loginfirst.aspx?redirect_url=" & Server.UrlEncode(Request.Url.ToString()))
        Else
            If Me.Request.Cookies("user_id").Value.ToString = "" Then
                '如果用户未登录，则跳转到首页
                Response.Redirect("/accounts/loginfirst.aspx?redirect_url=" & Server.UrlEncode(Request.Url.ToString()))
            Else
                id = Me.Request.Cookies("user_id").Value.ToString
                '显示用户所发运价和货盘的统计

            End If
        End If



    End Sub


End Class
