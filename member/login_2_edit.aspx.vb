Imports System.Xml
Imports System.Data

Partial Class member_login_2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        checkall.Attributes.Add("onClick", "allcheck();")


        If Me.Request.Cookies("user_id") Is Nothing Then

            Response.Redirect("../accounts/login.aspx")
        Else

            If Request.Cookies("user_id").Value.ToString = "" Then
                Response.Redirect("../accounts/login.aspx")
            End If
        End If
        If Not Page.IsPostBack Then
            LoadList1()
            LoadList2(0)



            Dim id As String = Request.Cookies("user_id").Value.ToString
            Dim cn As New data_conn
            Dim ds As DataSet = cn.mdb_ds("select * from TB_User where UserID=" + id, "user")


            If ds.Tables("user").Rows(0)("Login2_Head").ToString <> DBNull.Value.ToString Then


                If CBool(ds.Tables("user").Rows(0)("Login2_Head")) = True Then
                    imgcompanyhead.Src = "/member/companyhead/" + ds.Tables("user").Rows(0)("UserID").ToString + ".jpg"
                Else
                    imgcompanyhead.Src = "/images/shops/gs.gif"
                End If
            End If

            If ds.Tables("user").Rows(0)("Login2_Adventage_Type_fcl").ToString() = "1" Then
                checkfcl.Checked = True
            End If
            If (ds.Tables("user").Rows(0)("Login2_Adventage_Type_lcl").ToString() = "1") Then
                checklcl.Checked = True
            End If
            If (ds.Tables("user").Rows(0)("Login2_Adventage_Type_air").ToString() = "1") Then
                checkair.Checked = True
            End If


            TextBox1.Text = ds.Tables("user").Rows(0)("Login2_Registered_Capital").ToString()

            If ds.Tables("user").Rows(0)("Login2_Establish_Time").ToString() <> "" Then
                Dim Establish_Time As DateTime = DateTime.Parse(ds.Tables("user").Rows(0)("Login2_Establish_Time").ToString())
                DropDownList1.SelectedValue = Establish_Time.Year.ToString
            End If
            

            'ddlcity1.SelectedItem.Text = ds.Tables("user").Rows(0)("Login2_Locus1").ToString()
            'ddlcity2.SelectedItem.Text = ds.Tables("user").Rows(0)("Login2_Locus2").ToString()
            'ddlcity3.SelectedItem.Text = ds.Tables("user").Rows(0)("Login2_Locus3").ToString()

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


            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line").ToString().IndexOf(chk_ship_Europe.Value) > -1) Then
                chk_ship_Europe.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line").ToString().IndexOf(chk_ship_SOUTH_AMERICA.Value) > -1) Then
                chk_ship_SOUTH_AMERICA.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line").ToString().IndexOf(chk_air_Australia.Value) > -1) Then
                chk_ship_Australia.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line").ToString().IndexOf(chk_ship_Caribbean.Value) > -1) Then
                chk_ship_Caribbean.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line").ToString().IndexOf(chk_ship_offing.Value) > -1) Then
                chk_ship_offing.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line").ToString().IndexOf(chk_ship_Japan_Korea.Value) > -1) Then
                chk_ship_Japan_Korea.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line").ToString().IndexOf(chk_ship_CIMEX.Value) > -1) Then
                chk_ship_CIMEX.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line").ToString().IndexOf(chk_ship_Red_Sea.Value) > -1) Then
                chk_ship_Red_Sea.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line").ToString().IndexOf(chk_ship_Africa.Value) > -1) Then
                chk_ship_Africa.Checked = True
            End If



            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line2").ToString().IndexOf(chk_air_North_America.Value) > -1) Then
                chk_air_North_America.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line2").ToString().IndexOf(chk_air_Europe.Value) > -1) Then
                chk_air_Europe.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line2").ToString().IndexOf(chk_air_poncho.Value) > -1) Then
                chk_air_poncho.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line2").ToString().IndexOf(chk_air_Asia.Value) > -1) Then
                chk_air_Asia.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line2").ToString().IndexOf(chk_air_Africa.Value) > -1) Then
                chk_air_Africa.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line2").ToString().IndexOf(chk_air_Australia.Value) > -1) Then
                chk_air_Australia.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Line2").ToString().IndexOf(chk_air_internal.Value) > -1) Then
                chk_air_internal.Checked = True
            End If


            '船公司
            If (ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().IndexOf(chkMSK.Value) > -1) Then
                chkMSK.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().IndexOf(chkMSC.Value) > -1) Then
                chkMSC.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().IndexOf(chkEMC.Value) > -1) Then
                chkEMC.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().IndexOf(chkPIL.Value) > -1) Then
                chkPIL.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().IndexOf(chkCSCL.Value) > -1) Then
                chkCSCL.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().IndexOf(chkOOCL.Value) > -1) Then
                chkOOCL.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().IndexOf(chkCMA.Value) > -1) Then
                chkCMA.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().IndexOf(chkCOSCO.Value) > -1) Then
                chkCOSCO.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().IndexOf(chkHANJIN.Value) > -1) Then
                chkHANJIN.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().IndexOf(chkZIM.Value) > -1) Then
                chkZIM.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().IndexOf(chkWANHAI.Value) > -1) Then
                chkWANHAI.Checked = True
            End If

            If (ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().IndexOf(chkYML.Value) > -1) Then
                chkYML.Checked = True
            End If

            othershipper.Text = ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().Split("|")(ds.Tables("user").Rows(0)("Login2_Adventage_Shipper").ToString().Split("|").Length - 1)


            Username9.Value = ds.Tables("user").Rows(0)("Login2_Feature").ToString()
            TEXTAREA1.Value = ds.Tables("user").Rows(0)("Login2_Competence").ToString()
            Username11.Value = ds.Tables("user").Rows(0)("Login2_Server_Acceptance").ToString()
        End If

        ''初始化下拉框
        'Dim cn As New data_conn
        'Dim ds As Data.DataSet = cn.mdb_ds("select * from TB_QuestionTypeName", "TypeName")
        ''初始化类型1
        'For i As Integer = 0 To ds.Tables("TypeName").Rows.Count - 1
        '    Dim item As New ListItem(ds.Tables("TypeName").Rows(i)("name").ToString(), ds.Tables("TypeName").Rows(i)("id").ToString())
        '    Select1.Items.Add(item)
        'Next

        'Dim count As Integer = ds.Tables("TypeName").Rows.Count

        ''初始化类型2，放入hidstrselect隐藏控件中
        'ds = cn.mdb_ds("select * from TB_QuestionSecondTypeName", "TypeSecondName")
        'Dim strselect As String = "$$"


        'For i As Integer = 0 To count - 1
        '    Dim row() As Data.DataRow = ds.Tables("TypeSecondName").Select("typeid=" + (i + 1).ToString())
        '    For j As Integer = 0 To row.Length - 1
        '        strselect += row(j)("name").ToString() + "|"
        '    Next
        '    strselect += "$$"
        'Next


        'Me.HidStrSelect.Value = strselect

        'Select1.Size = count
        'Select2.Size = count
    End Sub

    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ck As New check
        Dim cn As New data_conn

        Dim sql As String
        Dim Login2_Adventage_Type_fcl, Login2_Adventage_Type_lcl, Login2_Adventage_Type_air, Login2_Registered_Capital, Login2_Establish_Time, Login2_Locus1, Login2_Locus2, Login2_Locus3, Login2_Adventage_Line, Login2_Adventage_Line2, Login2_Adventage_Shipper, Login2_Feature, Login2_Competence, Login2_Server_Acceptance As String

        Login2_Adventage_Type_fcl = "0"
        Login2_Adventage_Type_lcl = "0"
        Login2_Adventage_Type_air = "0"
        If (checkall.Checked = True) Then
            Login2_Adventage_Type_fcl = "1"
            Login2_Adventage_Type_lcl = "1"
            Login2_Adventage_Type_air = "1"
        End If
        If (checkfcl.Checked = True) Then
            Login2_Adventage_Type_fcl = "1"
        End If
        If (checklcl.Checked = True) Then
            Login2_Adventage_Type_lcl = "1"
        End If
        If (checkair.Checked = True) Then
            Login2_Adventage_Type_air = "1"
        End If
        If (Login2_Adventage_Type_fcl = 0 And Login2_Adventage_Type_lcl = 0 And Login2_Adventage_Type_air = 0) Then
            MessageBox("经营类型不能为空", "经营类型不能为空")
            Return
        End If

        Login2_Registered_Capital = ck.CheckInput(TextBox1.Text)
        If (Login2_Registered_Capital = "") Then
            MessageBox("公司注册资金不能为空", "公司注册资金不能为空")
            Return
        End If
        If (DropDownList1.SelectedValue = "1990以前") Then
            Login2_Establish_Time = "1990"
        Else
            Login2_Establish_Time = DropDownList1.SelectedValue
        End If



        If (Login2_Establish_Time = "请选择") Then

            MessageBox("公司成立时间不能为空", "公司成立时间不能为空")
            Return
        End If

        If (Me.ddlcity1.SelectedItem.Text = "请选择" Or Me.ddlcity2.SelectedItem.Text = "请选择") Then
            MessageBox("公司所在地不能为空", "公司所在地不能为空")
            Return
        End If

        Login2_Locus1 = Me.ddlcity1.SelectedItem.Text
        Login2_Locus2 = Me.ddlcity2.SelectedItem.Text
        'Login2_Locus3 = Me.ddlcity3.SelectedItem.Text

        '航线
        Login2_Adventage_Line = ""
        If (chk_ship_Europe.Checked = True) Then
            Login2_Adventage_Line += chk_ship_Europe.Value + "|"
        End If

        If (chk_ship_SOUTH_AMERICA.Checked = True) Then
            Login2_Adventage_Line += chk_ship_SOUTH_AMERICA.Value + "|"
        End If

        If (chk_air_Australia.Checked = True) Then
            Login2_Adventage_Line += chk_ship_Australia.Value + "|"
        End If

        If (chk_ship_Caribbean.Checked = True) Then
            Login2_Adventage_Line += chk_ship_Caribbean.Value + "|"
        End If

        If (chk_ship_offing.Checked = True) Then
            Login2_Adventage_Line += chk_ship_offing.Value + "|"
        End If

        If (chk_ship_Japan_Korea.Checked = True) Then
            Login2_Adventage_Line += chk_ship_Japan_Korea.Value + "|"
        End If

        If (chk_ship_CIMEX.Checked = True) Then
            Login2_Adventage_Line += chk_ship_CIMEX.Value + "|"
        End If

        If (chk_ship_Red_Sea.Checked = True) Then
            Login2_Adventage_Line += chk_ship_Red_Sea.Value + "|"
        End If

        If (chk_ship_Africa.Checked = True) Then
            Login2_Adventage_Line += chk_ship_Africa.Value + "|"
        End If
        Login2_Adventage_Line = Login2_Adventage_Line.Substring(0, Login2_Adventage_Line.Length - 1)


        '空运
        Login2_Adventage_Line2 = ""
        If (chk_air_North_America.Checked = True) Then
            Login2_Adventage_Line2 += chk_air_North_America.Value + "|"
        End If

        If (chk_air_Europe.Checked = True) Then
            Login2_Adventage_Line2 += chk_air_Europe.Value + "|"
        End If

        If (chk_air_poncho.Checked = True) Then
            Login2_Adventage_Line2 += chk_air_poncho.Value + "|"
        End If

        If (chk_air_Asia.Checked = True) Then
            Login2_Adventage_Line2 += chk_air_Asia.Value + "|"
        End If

        If (chk_air_Africa.Checked = True) Then
            Login2_Adventage_Line2 += chk_air_Africa.Value + "|"
        End If

        If (chk_air_Australia.Checked = True) Then
            Login2_Adventage_Line2 += chk_air_Australia.Value + "|"
        End If

        If (chk_air_internal.Checked = True) Then
            Login2_Adventage_Line2 += chk_air_internal.Value + "|"
        End If
        If (Login2_Adventage_Line2 = "") Then
            MessageBox("优势航线不能为空", "优势航线不能为空")
            Return
        End If
        Login2_Adventage_Line2 = Login2_Adventage_Line2.Substring(0, Login2_Adventage_Line2.Length - 1)

        '船公司
        Login2_Adventage_Shipper = ""
        If (chkMSK.Checked = True) Then
            Login2_Adventage_Shipper += chkMSK.Value + "|"
        End If

        If (chkMSC.Checked = True) Then
            Login2_Adventage_Shipper += chkMSC.Value + "|"
        End If

        If (chkEMC.Checked = True) Then
            Login2_Adventage_Shipper += chkEMC.Value + "|"
        End If

        If (chkPIL.Checked = True) Then
            Login2_Adventage_Shipper += chkPIL.Value + "|"
        End If

        If (chkCSCL.Checked = True) Then
            Login2_Adventage_Shipper += chkCSCL.Value + "|"
        End If

        If (chkOOCL.Checked = True) Then
            Login2_Adventage_Shipper += chkOOCL.Value + "|"
        End If

        If (chkCMA.Checked = True) Then
            Login2_Adventage_Shipper += chkCMA.Value + "|"
        End If

        If (chkCOSCO.Checked = True) Then
            Login2_Adventage_Shipper += chkCOSCO.Value + "|"
        End If

        If (chkHANJIN.Checked = True) Then
            Login2_Adventage_Shipper += chkHANJIN.Value + "|"
        End If

        If (chkZIM.Checked = True) Then
            Login2_Adventage_Shipper += chkZIM.Value + "|"
        End If

        If (chkWANHAI.Checked = True) Then
            Login2_Adventage_Shipper += chkWANHAI.Value + "|"
        End If

        If (chkYML.Checked = True) Then
            Login2_Adventage_Shipper += chkYML.Value + "|"
        End If


        Login2_Adventage_Shipper += othershipper.Text + "|"

        Login2_Adventage_Shipper = Login2_Adventage_Shipper.Substring(0, Login2_Adventage_Shipper.Length - 1)


        Login2_Feature = ck.CheckInput(Username9.Value)
        Login2_Competence = ck.CheckInput(TEXTAREA1.Value)
        Login2_Server_Acceptance = ck.CheckInput(Username11.Value)

        If (Me.FileUpload1.FileName.ToString() <> "") Then
            Dim filepath As String
            filepath = Server.MapPath("/member/companyhead/") + Me.Request.Cookies("user_id").Value.ToString + "(old).jpg"
            FileUpload1.SaveAs(filepath)
            Dim thumbnailimage As New ThumbnailImage
            thumbnailimage.GetThumbnailImage(filepath, Server.MapPath("/member/companyhead/") + Me.Request.Cookies("user_id").Value.ToString + ".jpg", 256, 256)

            cn.mdb_exe("update TB_User set Login2_Head=1 where UserId=" + Me.Request.Cookies("user_id").Value.ToString)
        End If



        sql = "update TB_User set Login2_Adventage_Type_fcl=" + Login2_Adventage_Type_fcl + ",Login2_Adventage_Type_lcl=" + Login2_Adventage_Type_lcl + ",Login2_Adventage_Type_air=" + Login2_Adventage_Type_air + ",Login2_Registered_Capital='" + Login2_Registered_Capital + "',Login2_Establish_Time='" + Login2_Establish_Time + "',Login2_Locus1='" + Login2_Locus1 + "',Login2_Locus2='" + Login2_Locus2 + "',Login2_Adventage_Line='" + Login2_Adventage_Line + "',Login2_Adventage_Line2='" + Login2_Adventage_Line2 + "',Login2_Adventage_Shipper='" + Login2_Adventage_Shipper + "',Login2_Feature='" + Login2_Feature + "',Login2_Competence='" + Login2_Competence + "',Login2_Server_Acceptance='" + Login2_Server_Acceptance + "' where UserID=" + Me.Request.Cookies("user_id").Value.ToString
        'Me.Response.Write(sql)
        cn.mdb_exe(sql)

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
    End Sub

    Protected Sub ddlcity2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcity2.SelectedIndexChanged
        LoadList3(ddlcity2.SelectedValue)
    End Sub

End Class

