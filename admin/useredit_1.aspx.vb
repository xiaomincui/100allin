Imports System.Data
Imports System.Xml

Partial Class admin_useredit
    Inherits System.Web.UI.Page
    Implements System.Web.UI.ICallbackEventHandler
    Dim returnValue As String

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.Cookies("admin_group").Value = "3" Then
            PlaceHolder1.Visible = False
            PlaceHolder2.Visible = False
        End If



        '第一次载入页面，显示所有记录
        If Not Page.IsPostBack Then
            LoadList1()
            LoadList2(0)
            GetUserInfo()
        End If
        Button1.Attributes.Add("onclick", "checkAll();return false;")

        ckb_en.Attributes.Add("onclick", "entablechange()")
        ckb_cn.Attributes.Add("onclick", "cntablechange()")
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
        'Response.Redirect("/default.aspx")
        'Response.Write("<script>parent.history.go(-2);</script>")
        Response.Redirect("userlist.aspx")
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click

        If Request.Cookies("admin_group").Value = "3" Then
            MessageBox("没有权限", "没有权限")
        Else



            'Dim nowlong As String = ""
            'nowlong = Year(Now()) & "-" & Right("0" & Month(Now()), 2) & "-" & Right("0" & Day(Now()), 2) & "&nbsp;&nbsp;" & Right("0" & Hour(Now()), 2) & ":" & Right("0" & Minute(Now()), 2) & ":" & Right("0" & Second(Now()), 2)
            '修改用户信息

            Dim ck As New check
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

            sql = sql & "introduction = '" & ck.CheckInput(txtintroduction.Value) & "', "
            'sql = sql & "Phone = '" & ck.CheckInput(Zone.Value.ToString + "-" + Phone.Value.ToString) & "', "
            'sql = sql & "PhoneNum = '" & ck.CheckInput(Phone.Value.ToString) & "', "
            'sql = sql & "PhoneZone = '" & ck.CheckInput(Zone.Value.ToString) & "', "



            sql = sql & "Fax = '" & ck.CheckInput(Fax.Value.ToString) & "', "
            sql = sql & "MovePhone = '" & ck.CheckInput(MovePhone.Value.ToString) & "', "
            sql = sql & "UserName = '" & ck.CheckInput(UserName.Value.ToString) & "', "
            sql = sql & "memo = '" & ck.CheckInput(txtmemo.Value.ToString) & "', "
            sql = sql & "Login2_Locus1 = '" & ck.CheckInput(Me.ddlcity1.SelectedItem.Text) & "', "
            sql = sql & "Login2_Locus2 = '" & ck.CheckInput(Me.ddlcity2.SelectedItem.Text) & "', "
            sql = sql & "UserPassword = '" & ck.CheckInput(UserPassword.Value.ToString) & "', "

            sql = sql & "First_Name = '" & ck.CheckInput(Firstname.Value.ToString) & "', "
            sql = sql & "Last_Name = '" & ck.CheckInput(Lastname.Value.ToString) & "', "
            sql = sql & "EN_CompanyName = '" & ck.CheckInput(EN_CompanyName.Value.ToString) & "', "
            sql = sql & "EN_Country = '" & ck.CheckInput(Country.Value.ToString) & "', "
            sql = sql & "EN_City = '" & ck.CheckInput(City.Value.ToString) & "', "
            sql = sql & "EN_Address = '" & ck.CheckInput(En_Address.Value.ToString) & "', "
            sql = sql & "EN_Company_profile = '" & ck.CheckInput(Company_profile.Value.ToString) & "', "
            'sql = sql & "Login2_Adventage_Line_Adv = '" & ck.CheckInput(txtLine.Text) & "', "
            'sql = sql & "Login2_Adventage_Destport_Adv = '" & ck.CheckInput(txtDestport.Text) & "', "
            'sql = sql & "Login2_Adventage_shipper_Adv = '" & ck.CheckInput(txtShiper.Text) & "', "
            Dim ifen As String = ""
            If ckb_cn.Checked And Not ckb_en.Checked Then
                ifen = "0"
            ElseIf ckb_en.Checked And Not ckb_cn.Checked Then
                ifen = "1"
            Else
                Dim dsuser As DataSet = cn.mdb_ds("select * from TB_User where UserID=" + Me.Request.QueryString("id"), "user")
                If CInt(dsuser.Tables("user").Rows(0)("ifEn")) = 0 Then
                    ifen = "3"
                ElseIf CInt(dsuser.Tables("user").Rows(0)("ifEn")) = 1 Then
                    ifen = "2"
                Else
                    ifen = dsuser.Tables("user").Rows(0)("ifEn").ToString
                End If
            End If
            sql = sql & "ifEn = " & ifen & " "

            'sql = sql & "bbsadmin = " & DropDownList1.SelectedValue & " "
            sql = sql & "WHERE UserID = " & ck.CheckInput(Me.Request.QueryString("id"))


            cn.mdb_exe(sql)

            sql = "delete from TB_BBSLevel where UserID=" & ck.CheckInput(Me.Request.QueryString("id")) + ";"
            If Hidtypes.Value <> "" Then
                Dim strHidtypes As String = Me.Hidtypes.Value.Substring(0, Hidtypes.Value.Length - 1)
                Dim arrayhid() As String = Split(strHidtypes, "|")
                For i As Integer = 0 To arrayhid.Length - 1
                    sql += "insert into TB_BBSLevel (UserID,types) values (" + ck.CheckInput(Me.Request.QueryString("id")) + "," + arrayhid(i) + ");"
                Next
            End If

            GetUserInfo()
            cn.mdb_exe(sql)
            MessageBox("成功", "成功")

            'Response.Redirect("userlist.aspx")

        End If

       
    End Sub

    Sub hidden()
        Dim cn As New data_conn
        Dim ds As DataSet = cn.mdb_ds("select * from TB_BBSList", "TB_BBSList")
        For i As Integer = 0 To ds.Tables("TB_BBSList").Rows.Count - 1
            Hidden1.Value += ds.Tables("TB_BBSList").Rows(i)("name").ToString + "|"
            Hidden2.Value += ds.Tables("TB_BBSList").Rows(i)("id").ToString + "|"
        Next

        Hidden1.Value = Hidden1.Value.Substring(0, Hidden1.Value.Length - 1)
        Hidden2.Value = Hidden2.Value.Substring(0, Hidden2.Value.Length - 1)

    End Sub


    Sub GetUserInfo()


        hidden()


        Dim userid As String = Me.Request.QueryString("id")

        Dim cn As New data_conn
        Dim ds As DataSet


        Dim sql As String = ""
        sql = "select * from TB_BBSList where id in (select types from TB_User,TB_BBSLevel where TB_User.UserID=TB_BBSLevel.UserID and TB_User.UserID=" + userid + ")"
        ds = cn.mdb_ds(sql, "BBSList")
        Me.Hidtypes.Value = ""
        For i As Integer = 0 To ds.Tables("BBSList").Rows.Count - 1
            selshiper.Items.Add(New ListItem(ds.Tables("BBSList").Rows(i)("name").ToString, ds.Tables("BBSList").Rows(i)("id").ToString))
            Me.Hidtypes.Value += ds.Tables("BBSList").Rows(i)("id").ToString + "|"
        Next

        sql = "select * from TB_BBSList where id not in (select types from TB_User,TB_BBSLevel where TB_User.UserID=TB_BBSLevel.UserID and TB_User.UserID=" + userid + ")"
        ds = cn.mdb_ds(sql, "BBSList")

        For i As Integer = 0 To ds.Tables("BBSList").Rows.Count - 1
            ListBox1.Items.Add(New ListItem(ds.Tables("BBSList").Rows(i)("name").ToString, ds.Tables("BBSList").Rows(i)("id").ToString))
        Next



        'DropDownList1.Items.Add(New System.Web.UI.WebControls.ListItem("非版主", "0"))
        'For i As Integer = 0 To ds.Tables("BBSList").Rows.Count - 1
        '    DropDownList1.Items.Add(New System.Web.UI.WebControls.ListItem(ds.Tables("BBSList").Rows(i)("name").ToString, ds.Tables("BBSList").Rows(i)("id").ToString))
        'Next
        'DropDownList1.Items.Add(New System.Web.UI.WebControls.ListItem("总管理员", (CInt(ds.Tables("BBSList").Rows(ds.Tables("BBSList").Rows.Count - 1)("id")) + 1).ToString))

        sql = ""
        sql = sql & "SELECT * "
        sql = sql & "FROM "
        sql = sql & "TB_User "
        sql = sql & "WHERE "
        sql = sql & "userid = " & userid
        'sql = sql & " AND Regtime > '2010-4-15 0:00:00' "
        ds = cn.mdb_ds(sql, "user")

        'DropDownList1.SelectedValue = ds.Tables("user").Rows(0)("bbsadmin").ToString
        Dim GetRequest1 As New GetRequest()
        If GetRequest1.GetRequestCookies("admin_group", "3") = 3 And ds.Tables("user").Rows(0)("CompanyType").ToString = "1" Then
            Response.Redirect("userlist.aspx")
        End If

        UserName.Value = ds.Tables("user").Rows(0)("UserName").ToString
        hidusername.Value = ds.Tables("user").Rows(0)("UserName").ToString
        UserPassword.Value = ds.Tables("user").Rows(0)("UserPassword").ToString
        UserEmail.Value = ds.Tables("user").Rows(0)("UserEmail").ToString
        Phone.Value = ds.Tables("user").Rows(0)("Phone").ToString
        Fax.Value = ds.Tables("user").Rows(0)("Fax").ToString
        CompanyType.Value = ds.Tables("user").Rows(0)("CompanyType").ToString
        txtLine.Text = ds.Tables("user").Rows(0)("Login2_Adventage_Line_Adv").ToString
        txtDestport.Text = ds.Tables("user").Rows(0)("Login2_Adventage_Destport_Adv").ToString
        txtShiper.Text = ds.Tables("user").Rows(0)("Login2_Adventage_shipper_Adv").ToString
        ddlstar_adv.Items.Add(New ListItem(ds.Tables("user").Rows(0)("star_adv").ToString, ds.Tables("user").Rows(0)("star_adv").ToString))

        If CInt(ds.Tables("user").Rows(0)("ifEn")) = 0 Or CInt(ds.Tables("user").Rows(0)("ifEn")) = 2 Or CInt(ds.Tables("user").Rows(0)("ifEn")) = 3 Then

            RealName.Value = ds.Tables("user").Rows(0)("RealName").ToString
            CompanyName.Value = ds.Tables("user").Rows(0)("CompanyName").ToString
            Phone2.Value = ds.Tables("user").Rows(0)("Phone2").ToString
            txtintroduction.Value = ds.Tables("user").Rows(0)("introduction").ToString
            MovePhone.Value = ds.Tables("user").Rows(0)("MovePhone").ToString
            Address.Value = ds.Tables("user").Rows(0)("Address").ToString
            PostNumber.Value = ds.Tables("user").Rows(0)("PostNumber").ToString
            txtmemo.Value = ds.Tables("user").Rows(0)("memo").ToString
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
        End If
        
        If CInt(ds.Tables("user").Rows(0)("ifEn")) = 1 Or CInt(ds.Tables("user").Rows(0)("ifEn")) = 2 Or CInt(ds.Tables("user").Rows(0)("ifEn")) = 3 Then
            Firstname.Value = ds.Tables("user").Rows(0)("First_Name").ToString
            Lastname.Value = ds.Tables("user").Rows(0)("Last_Name").ToString
            EN_CompanyName.Value = ds.Tables("user").Rows(0)("EN_CompanyName").ToString
            Country.Value = ds.Tables("user").Rows(0)("EN_Country").ToString
            City.Value = ds.Tables("user").Rows(0)("EN_City").ToString
            En_Address.Value = ds.Tables("user").Rows(0)("EN_Address").ToString
            Company_profile.Value = ds.Tables("user").Rows(0)("EN_Company_profile").ToString
        End If

        If CInt(ds.Tables("user").Rows(0)("ifEn")) = 0 Then
            ckb_cn.Checked = True
            ckb_en.Checked = False
            cntable.Style.Value = ""
            entable.Style.Value = "display:none"
        End If
        If CInt(ds.Tables("user").Rows(0)("ifEn")) = 1 Then
            ckb_en.Checked = True
            ckb_cn.Checked = False
            cntable.Style.Value = "display:none"
            entable.Style.Value = ""
        End If
        If CInt(ds.Tables("user").Rows(0)("ifEn")) = 2 Or CInt(ds.Tables("user").Rows(0)("ifEn")) = 3 Then
            ckb_en.Checked = True
            ckb_cn.Checked = True
            entable.Style.Value = ""
            cntable.Style.Value = ""
        End If









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