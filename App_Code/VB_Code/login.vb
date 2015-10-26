Imports Microsoft.VisualBasic

Public Class login
    Public Sub login()
        If (HttpContext.Current.Request.Cookies("user_id") Is Nothing) Then
            HttpContext.Current.Response.Redirect("/accounts/loginfirst.aspx?redirect_url=" & HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.ToString()))
        Else
            If HttpContext.Current.Request.Cookies("user_id").Value.ToString = "" Then
                HttpContext.Current.Response.Redirect("/accounts/loginfirst.aspx?redirect_url=" & HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.ToString()))
            Else
            End If
        End If
    End Sub
End Class
