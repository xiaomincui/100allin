Imports System.Data
Imports System
Imports System.IO

Partial Class member_getdicker_detail
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '在页头加入该页所属的CSS文件链接
        AddStyleSheet(Me.Page, "css/list.css")
        If Not IsPostBack Then
            LoadRecord()
        End If

    End Sub


    '在页头加入CSS文件链接的函数
    Sub AddStyleSheet(ByVal page As Page, ByVal cssPath As String)
        Dim link As New HtmlLink
        link.Href = cssPath
        link.Attributes("rel") = "stylesheet"
        link.Attributes("type") = "text/css"
        page.Header.Controls.Add(link)
    End Sub


    '载入列表信息
    Sub LoadRecord()

        Dim ck As New check

        '取保存在Cookies中的用户编号id
        Dim id As String = ""
        Dim cid As String = ""
        Dim pid As String = ""

        If Not Me.Request.Cookies("user_id") Is Nothing Then
            id = ck.CheckInput(Me.Request.Cookies("user_id").Value.ToString)
        Else
            '如果用户未登录，则跳转到网站首页
            Response.Redirect("/accounts/login.aspx")
        End If


        If Not Me.Request.QueryString("cid") Is Nothing Then
            cid = ck.CheckInput(Me.Request.QueryString("cid").ToString)
        End If

        If Not Me.Request.QueryString("pid") Is Nothing Then
            pid = ck.CheckInput(Me.Request.QueryString("pid").ToString)
        End If



        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""

        sql = sql & "SELECT "
        sql = sql & "did,readed,chater,listener,listener_realname,txt,cargo,startport,destport,hangxianmiaoshu,carrier,reply,price,type,companyname,realname,username,chattime "
        sql = sql & "FROM "
        sql = sql & "TB_DICKER "
        sql = sql & "WHERE "
        sql = sql & "1=1 "
        sql = sql & " AND listener = " & id
        sql = sql & " AND chater = " & cid
        sql = sql & " AND did = " & pid

        'Response.Write(sql)
        ds = cn.mdb_ds(sql, "pm")

        Repeater1.DataSource = ds.Tables("pm").DefaultView
        Repeater1.DataBind()

        If cid <> 0 Then
            Label2.Text = "，也可以 " & "<a href =""/member/pm_detail.aspx?cid=" & ds.Tables("pm").Rows(0)("chater").ToString & """>给Ta发送短消息</a>"
            Label1.Text = ds.Tables("pm").Rows(0)("RealName").ToString
        Else
            Label1.Text = ds.Tables("pm").Rows(0)("RealName").ToString + "<span style='color:#666666'>(未注册用户，请注意鉴别)</span>"
        End If

        sql = "update TB_DICKER set readed = 1 where did = " & pid
        cn.mdb_exe(sql)


        'sql = "SELECT "
        'sql = sql & "count(*) as c "
        'sql = sql & "FROM "
        'sql = sql & "V_PM "
        'sql = sql & "WHERE "
        'sql = sql & "1=1 "
        'sql = sql & " AND listener = " & id
        'sql = sql & " AND readed  = 0"

        'ds = cn.mdb_ds(sql, "pmcount")

        'HttpContext.Current.Application(id) = ds.Tables("pmcount").Rows(0)(0).ToString



    End Sub

    Protected Function Encode(ByVal str As String) As String
        str = str.Replace("&", "&amp;")
        str = str.Replace("'", "''")
        str = str.Replace("\", "&amp;")
        str = str.Replace("   ", "&nbsp;")
        str = str.Replace("<", "&lt;")
        str = str.Replace(">", "&gt;")
        str = str.Replace(vbCrLf, "<br />")
        Return str
    End Function

    Public Function HeadExist(ByVal h As String) As String
        Dim path As String = Server.MapPath("/member/head/")
        path = path & h & ".jpg"
        If File.Exists(path) Then
            Return "1"
        Else
            Return "0"
        End If

    End Function

End Class
