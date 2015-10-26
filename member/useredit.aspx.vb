Imports System.Data
Imports System.Xml

Partial Class member_useredit
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim returnValue As String

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '第一次载入页面，显示所有记录
        If Not Page.IsPostBack Then


            LoadList1()
            LoadList2(0)
            GetUserInfo()

        End If
        Button1.Attributes.Add("onclick", "checkAll();return false;")
        Dim cn As New data_conn
        Dim ds As DataSet = cn.mdb_ds("select * from TB_User where Userid=" + Me.Request.Cookies("user_id").Value.ToString, "head")
        If ds.Tables("head").Rows(0)("HeadURL") Then
            Imghead.ImageUrl = "~/member/Head/" + Me.Request.Cookies("user_id").Value.ToString + ".jpg"
        Else
            Imghead.ImageUrl = "~/member/Head/" + "default.jpg"
        End If
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
        Dim HeadURL As String = ""
        If (Me.FileUpload1.FileName.ToString() <> "") Then
            Dim filepath As String
            filepath = Server.MapPath("Head/") + Me.Request.Cookies("user_id").Value.ToString + "(old).jpg"
            FileUpload1.SaveAs(filepath)
            Dim thumbnailimage As New ThumbnailImage
            thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("Head/") + Me.Request.Cookies("user_id").Value.ToString + ".jpg", 70, 70)
            HeadURL = ",HeadURL = 1 "
        ElseIf (Imghead.ImageUrl <> "~/member/Head/" + "default.jpg") Then
            HeadURL = ",HeadURL = 1 "
        Else
            HeadURL = ",HeadURL = 0 "
        End If
        Dim ck As New check
        Dim sign As String = ""
        If Me.txtsign.Value <> "" Then
            sign = ",sign='" + ck.CheckInput(Me.txtsign.Value) + "' "
        End If
       



        Dim cn As New data_conn
        Dim sql As String = ""
        sql = sql & "UPDATE "
        sql = sql & "TB_User "
        sql = sql & "SET "
        sql = sql & "UserEmail = '" & ck.CheckInput(UserEmail.Value.ToString) & "', "
        sql = sql & "RealName = '" & ck.CheckInput(RealName.Value.ToString) & "', "
        sql = sql & "CompanyName = '" & ck.CheckInput(CompanyName.Value.ToString) & "', "
        sql = sql & "CompanyType= " & ck.CheckInput(CompanyType.Value.ToString) & ", "
        sql = sql & "Address = '" & ck.CheckInput(Address.Value.ToString) & "', "
        sql = sql & "PostNumber = '" & ck.CheckInput(PostNumber.Value.ToString) & "', "

        sql = sql & "Phone = '" & ck.CheckInput(Phone.Value.ToString) & "', "

        sql = sql & "Phone2 = '" & ck.CheckInput(Phone2.Value.ToString) & "', "






        sql = sql & "Fax = '" & ck.CheckInput(Fax.Value.ToString) & "', "
        sql = sql & "MovePhone = '" & ck.CheckInput(MovePhone.Value.ToString) & "', "
        sql = sql & "Usermsn = '" & ck.CheckInput(txtMSN.Value.ToString) & "', "
        sql = sql & "Userqq = '" & ck.CheckInput(txtQQ.Value.ToString) & "', "
        sql = sql & "introduction = '" & ck.CheckInput(txtintroduction.Value) & "', "
        sql = sql & "Login2_Locus1 = '" & ck.CheckInput(Me.ddlcity1.SelectedItem.Text) & "', "
        sql = sql & "Login2_Locus2 = '" & ck.CheckInput(Me.ddlcity2.SelectedItem.Text) & "' "
        sql = sql & HeadURL
        sql = sql & sign
        sql = sql & "WHERE UserID = " & Me.Request.Cookies("user_id").Value.ToString

        cn.mdb_exe(sql)
        Response.Redirect("usereditsuccess.aspx")
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

        Phone.Value = ds.Tables("user").Rows(0)("Phone").ToString



        Phone2.Value = ds.Tables("user").Rows(0)("Phone2").ToString





        Fax.Value = ds.Tables("user").Rows(0)("Fax").ToString
        MovePhone.Value = ds.Tables("user").Rows(0)("MovePhone").ToString
        Address.Value = ds.Tables("user").Rows(0)("Address").ToString
        PostNumber.Value = ds.Tables("user").Rows(0)("PostNumber").ToString
        txtMSN.Value = ds.Tables("user").Rows(0)("Usermsn").ToString
        txtQQ.Value = ds.Tables("user").Rows(0)("Userqq").ToString
        txtsign.Value = ds.Tables("user").Rows(0)("sign").ToString
        txtintroduction.Value = ds.Tables("user").Rows(0)("introduction").ToString


        For i As Integer = 0 To ddlcity1.Items.Count - 1
            If (ddlcity1.Items(i).Text = ds.Tables("user").Rows(0)("Login2_Locus1").ToString()) Then
                ddlcity1.Items(i).Selected = True
                LoadList2(ddlcity1.Items(i).Value)
            End If
        Next


        For i As Integer = 0 To ddlcity2.Items.Count - 1
            If (ddlcity2.Items(i).Text = ds.Tables("user").Rows(0)("Login2_Locus2").ToString()) Then
                ddlcity2.Items(i).Selected = True
            End If
        Next

        CompanyType.Value = ds.Tables("user").Rows(0)("CompanyType").ToString

        'Select Case ds.Tables("user").Rows(0)("CompanyType").ToString
        '    Case "0"
        '        CompanyType.Value = "0"
        '    Case "1"
        '        CompanyType.Value = "1"
        '    Case "2"
        '        CompanyType.Value = "2"
        '    Case "3"
        '        CompanyType.Value = "3"
        '    Case "4"
        '        CompanyType.Value = "4"
        'End Select



    End Sub

    Protected Sub Button1_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.ServerClick

    End Sub

    Protected Sub LoadList1()
        ddlcity1.Items.Clear()

        Dim doc As New XmlDocument
        doc.Load(Server.MapPath("../xml/Provinces.xml"))
        'Dim node As XmlNodeList = doc.SelectNodes("Cities")(0).ChildNodes
        Dim node As XmlNodeList = doc.SelectNodes("Provinces")(0).ChildNodes
        For i As Integer = 0 To node.Count - 1
            Dim pp As New ListItem(node(i).InnerText, node(i).Attributes("ID").Value)
            ddlcity1.Items.Add(pp)
        Next

    End Sub

    Protected Function LoadList1search(ByVal str As Integer) As String
        Dim doc As New XmlDocument
        doc.Load(Server.MapPath("../xml/Provinces.xml"))
        Dim node As XmlNodeList = doc.SelectNodes("Provinces")(0).ChildNodes
        For i As Integer = 0 To node.Count - 1
            If (node(i).InnerText = str) Then
                Return node(i).Attributes("ID").Value
            End If
        Next
        Return ""
    End Function

    Protected Sub LoadList2(ByVal ID As Integer)
        ddlcity2.Items.Clear()


        Dim doc As New XmlDocument
        doc.Load(Server.MapPath("../xml/Cities.xml"))


        Dim node As XmlNodeList = doc.SelectNodes("Cities")(0).ChildNodes


        Dim flag As String
        For i As Integer = 0 To node.Count - 1
            If node(i).Attributes("PID").Value = ID.ToString Or node(i).Attributes("PID").Value = 0 Then
                If ddlcity2.Items.Count = 0 Then
                    flag = node(i).Attributes("ID").Value
                End If
                Dim pp As New ListItem(node(i).InnerText, node(i).Attributes("ID").Value)
                ddlcity2.Items.Add(pp)
            End If
        Next

        'LoadList3(flag)
    End Sub

    Protected Sub LoadList3(ByVal ID As Integer)
        ddlcity3.Items.Clear()


        Dim doc As New XmlDocument
        doc.Load(Server.MapPath("../xml/Districts.xml"))


        Dim node As XmlNodeList = doc.SelectNodes("Districts")(0).ChildNodes



        For i As Integer = 0 To node.Count - 1
            If (node(i).Attributes("CID").Value = ID.ToString Or node(i).Attributes("CID").Value = 0) Then
                Dim pp As New ListItem(node(i).InnerText, node(i).Attributes("ID").Value)
                ddlcity3.Items.Add(pp)
            End If


        Next

        If ddlcity3.Items.Count = 1 And ddlcity2.SelectedItem.Text <> "请选择" Then
            ddlcity3.Items.Add(ddlcity2.SelectedItem.Text)
        End If

    End Sub



    Protected Sub ddlcity1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcity1.SelectedIndexChanged
        LoadList2(ddlcity1.SelectedValue)
        ddlcity1.Focus()

        If ddlcity1.SelectedValue <> 0 And ddlcity2.SelectedValue <> 0 Then
            tipLocusNormal.Style.Value = "display:none;"
            tipLocusTrue.Style.Value = ""
            tipLocusFalse.Style.Value = "display:none;"
        Else
            tipLocusNormal.Style.Value = "display:none;"
            tipLocusTrue.Style.Value = "display:none;"
            tipLocusFalse.Style.Value = ""
        End If



    End Sub

    Protected Sub ddlcity2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcity2.SelectedIndexChanged
        LoadList3(ddlcity2.SelectedValue)

        If ddlcity1.SelectedValue <> 0 And ddlcity2.SelectedValue <> 0 Then
            tipLocusNormal.Style.Value = "display:none;"
            tipLocusTrue.Style.Value = ""
            tipLocusFalse.Style.Value = "display:none;"
        Else
            tipLocusNormal.Style.Value = "display:none;"
            tipLocusTrue.Style.Value = "display:none;"
            tipLocusFalse.Style.Value = ""
        End If

    End Sub
End Class