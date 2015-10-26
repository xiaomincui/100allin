Imports System.Data

Partial Class member_passwordedit
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim returnValue As String

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '第一次载入页面，显示所有记录
        If Not Page.IsPostBack Then
            GetUserInfo()
        End If
        Button1.Attributes.Add("onclick", "checkAll();return false;")

    End Sub

    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub



    '这个函数负责把字符串输出给客户端的javascript函数
    Public Function GetCallbackResult() As String Implements System.Web.UI.ICallbackEventHandler.GetCallbackResult
        Try
            '等待0.1秒显示结果，给予服务器缓冲时间，并增强浏览效果
            System.Threading.Thread.Sleep(300)

            Dim p() As String = returnValue.Split("|")
            If p(0) = "username" Then
                '取表单上的用户名
                Dim name As String
                name = p(1)

                '检查用户名是否被注册过
                Dim cn As New data_conn3
                Dim sql As String = ""
                sql = sql + "select * "
                sql = sql + "from TB_User "
                sql = sql + "where UserName = '" & name & "'"
                Dim ds As New Data.DataSet
                ds = cn.mdb_ds(sql, "T_User")

                If ds.Tables("T_User").Rows.Count > 0 Then
                    Return "failed"
                Else
                    Return "success"
                End If
            ElseIf p(0) = "verifycode" Then
                If String.Compare(p(1).ToString().Trim(), p(2).ToString().Trim(), True) <> 0 Then
                    Return "failed"
                Else
                    Return "success"
                End If

            End If

        Catch ex As Exception
            Return ex.ToString
        End Try

    End Function

    '这个函数读取从客户端callback来的字符串，读取后在服务器端放置在容器eventArgument内
    Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
        returnValue = eventArgument
    End Sub

    Protected Sub Button1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.ServerClick

    End Sub

    Protected Sub Button2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.ServerClick
        Response.Redirect("/")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Dim nowlong As String = ""
        'nowlong = Year(Now()) & "-" & Right("0" & Month(Now()), 2) & "-" & Right("0" & Day(Now()), 2) & "&nbsp;&nbsp;" & Right("0" & Hour(Now()), 2) & ":" & Right("0" & Minute(Now()), 2) & ":" & Right("0" & Second(Now()), 2)
        '修改用户信息
        Dim ck As New check
        Dim cn As New data_conn
        Dim sql As String = ""
        sql = sql & "UPDATE "
        sql = sql & "TB_User "
        sql = sql & "SET "
        sql = sql & "UserPassword = '" & ck.CheckInput(UserPassword.Value.ToString) & "' "
        sql = sql & "WHERE UserID = " & Me.Request.Cookies("user_id").Value.ToString
        cn.mdb_exe(sql)


        Dim ds As DataSet = cn.mdb_ds("select * from TB_User where UserID=" + Me.Request.Cookies("user_id").Value.ToString, "temp")


        Dim r As New Random
        Dim salt As String = r.Next().ToString().Substring(0, 6)
        Dim mysqlcn As New mysqldata_conn
        Dim password As String = MD5(MD5(UserPassword.Value.ToString) + salt)

        'mysqlcn.mdb_exe("update uc_members set password='" + password + "',salt='" + salt + "' where uid=" + ds.Tables("temp").Rows(0)("UCenterHomeUid"))
        Response.Redirect("passwordeditsuccess.aspx")
    End Sub

    Function MD5(ByVal str As String) As String
        Dim b() As Byte = System.Text.Encoding.Default.GetBytes(str)
        b = New System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b)
        Dim ret As String = ""
        Dim i As Integer
        For i = 0 To b.Length - 1
            ret += b(i).ToString("x").PadLeft(2, "0")
        Next
        Return ret
    End Function

    Sub GetUserInfo()
        Dim userid As String = ""
        If (Me.Request.Cookies("user_id") Is Nothing) Then
            '如果用户未登录，则跳转到错误页面
            Response.Redirect("usererror.aspx")
        Else
            If Me.Request.Cookies("user_id").Value.ToString = "" Then
                Response.Redirect("usererror.aspx")
            Else
                userid = Me.Request.Cookies("user_id").Value.ToString
            End If
        End If
    End Sub
End Class