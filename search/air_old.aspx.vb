
Partial Class search_air_old
    Inherits System.Web.UI.Page
    '起运港参数
    Public sp As String = ""
    '目的港参数
    Public dp As String = ""
    '船公司参数
    Public cr As String = ""
    '航线参数
    Public l As String = "0"
    '页码参数
    Public p As String = ""
    '排序参数
    Public order As String = "0"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label28.Text = "亲爱的用户，由于系统升级，您所查看的页面已转移至以下地址：<br/>"
        If Not Page.IsPostBack Then
            If Not Request.QueryString("sp") Is Nothing Then
                '提取来自网页参数的搜索条件
                sp = Request.QueryString("sp").ToString
                dp = Request.QueryString("dp").ToString
                cr = Request.QueryString("cr").ToString
                l = Request.QueryString("l").ToString
                p = Request.QueryString("p").ToString
                order = Request.QueryString("order").ToString

                Label28.Text = Label28.Text + "<a href=""http://www.100allin.com/air/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-----" & p & ".html"">" & "http://www.100allin.com/air/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-----" & p & ".html</a>"

                HttpContext.Current.Response.StatusCode = 301
                HttpContext.Current.Response.Status = "301 Moved Permanently"
                HttpContext.Current.Response.AddHeader("Location", "http://www.100allin.com/air/list-" & sp & "-" & dp & "-" & cr & "-" & l & "-" & order & "-0-----" & p & ".html")
            Else
                Label28.Text = Label28.Text + "<a href=""http://www.100allin.com/air/"">http://www.100allin.com/air/</a>"

                HttpContext.Current.Response.StatusCode = 301
                HttpContext.Current.Response.Status = "301 Moved Permanently"
                HttpContext.Current.Response.AddHeader("Location", "http://www.100allin.com/air/")
            End If
        End If

    End Sub

End Class
