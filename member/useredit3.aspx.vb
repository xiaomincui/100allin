Imports System.Data
Imports System.Xml

Partial Class member_Default3
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim returnValue As String

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '第一次载入页面，显示所有记录
        If Not Page.IsPostBack Then


            GetUserInfo()

        End If
        Button1.Attributes.Add("onclick", "checkAll();return false;")
        Dim cn As New data_conn
        Dim ds As DataSet = cn.mdb_ds("select * from TB_User where Userid=" + Me.Request.Cookies("user_id").Value.ToString, "head")
       
        '=   "Word文件   (*.doc)|*.doc|All   files   (*.*)|*.* "   ;
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



    Protected Sub Button2_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.ServerClick
        Response.Redirect("/default.aspx")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Dim nowlong As String = ""
        'nowlong = Year(Now()) & "-" & Right("0" & Month(Now()), 2) & "-" & Right("0" & Day(Now()), 2) & "&nbsp;&nbsp;" & Right("0" & Hour(Now()), 2) & ":" & Right("0" & Minute(Now()), 2) & ":" & Right("0" & Second(Now()), 2)
        '修改用户信息

        '头像上传

        Dim ck As New check





        Dim cn As New data_conn
        Dim sql As String = ""
        sql = sql & "UPDATE "
        sql = sql & "TB_User "
        sql = sql & "SET "
        sql = sql & "UserEmail = '" & ck.CheckInput(UserEmail.Value.ToString) & "', "
        sql = sql & "RealName = '" & ck.CheckInput(RealName.Value.ToString) & "', "
        If UserPassword.Value <> "" Then
            sql = sql & "UserPassword = '" & ck.CheckInput(UserPassword.Value.ToString) & "', "
        End If


        sql = sql & "CompanyName = '" & ck.CheckInput(CompanyName.Value.ToString) & "', "
        sql = sql & "Phone = '" & ck.CheckInput(Phone.Value.ToString) & "' "
        sql = sql & "WHERE UserID = " & Me.Request.Cookies("user_id").Value.ToString

        cn.mdb_exe(sql)
        MessageBox("修改成功", "修改成功")
    End Sub


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

        Dim cn As New data_conn
        Dim ds As DataSet
        Dim sql As String = ""
        sql = sql & "SELECT * "
        sql = sql & "FROM "
        sql = sql & "TB_User "
        sql = sql & "WHERE "
        sql = sql & "userid = " & userid
        ds = cn.mdb_ds(sql, "user")

        RealName.Value = ds.Tables("user").Rows(0)("RealName").ToString
        CompanyName.Value = ds.Tables("user").Rows(0)("CompanyName").ToString
        UserEmail.Value = ds.Tables("user").Rows(0)("UserEmail").ToString
        UserPassword.Value = ds.Tables("user").Rows(0)("UserPassword").ToString
        Phone.Value = ds.Tables("user").Rows(0)("Phone").ToString




    End Sub

    Protected Sub Button1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.ServerClick

    End Sub



    

   

    



    
End Class
