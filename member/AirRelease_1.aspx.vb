
Partial Class member_SpellRelease
    Inherits System.Web.UI.Page
    Dim check As New check

    Public Sub LoadScript()
        Dim ReceiverScript As String = ""
        ReceiverScript += vbCrLf + "<script type=""text/javascript"" language=""JavaScript"">"
        ReceiverScript += vbCrLf + "function Load_Table(){"
        ReceiverScript += vbCrLf + "var table1 = new Dtable(""t1"");"
        ReceiverScript += vbCrLf + "var Ttittle =[];"
       
        ReceiverScript += vbCrLf + "Ttittle.push({v:"""",w:20,t:""checkbox"",c:""fth""});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""<span class=\""redfont\"">*</span>目的港"",w:62});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""M"",w:50});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""N"",w:50});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""45"",w:50});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""100"",w:50});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""300"",w:50});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""500"",w:50});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""1000"",w:50});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""附加费"",w:52});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""航程"",w:52});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""出发日"",w:52});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""备注"",w:52,t:""textarea"",c:""t_h txt""});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""Del"",w:30,t:""span"",f:""Del_row"",c:""eth""});"


        ReceiverScript += vbCrLf + "table1.TittleArray = Ttittle;"
        ReceiverScript += vbCrLf + "table1.Rows =15;//初始化行數"
        ReceiverScript += vbCrLf + "table1.DrawTable();"
        ReceiverScript += vbCrLf + "table1.init();"
        ReceiverScript += vbCrLf + "table1.fill_table(""textbox"",""txthidden"");"
        'ReceiverScript += vbCrLf + "document.getElementById(""addtr"").onclick =function(){"
        'ReceiverScript += vbCrLf + "var sum=document.getElementById(""trsum"").value;"
        'ReceiverScript += vbCrLf + "table1.addTr(sum)};"
1017:
        ReceiverScript += vbCrLf + "document.getElementById(""addtr1"").onclick =function(){"
        ReceiverScript += vbCrLf + "table1.addTr(1)};"

        ReceiverScript += vbCrLf + "document.getElementById(""addtr5"").onclick =function(){"
        ReceiverScript += vbCrLf + "table1.addTr(5)};"

        ReceiverScript += vbCrLf + "document.getElementById(""addtr10"").onclick =function(){"
        ReceiverScript += vbCrLf + "table1.addTr(10)};"

        ReceiverScript += vbCrLf + "document.getElementById(""deltr"").onclick =function()"
        ReceiverScript += vbCrLf + "{"
        ReceiverScript += vbCrLf + "var sum=document.getElementById(""trdsum"").value;"
        ReceiverScript += vbCrLf + "table1.delTr(sum);"
        ReceiverScript += vbCrLf + "}"
        ReceiverScript += vbCrLf + "document.getElementById(""dc"").onclick=function()"
        ReceiverScript += vbCrLf + "{"
        ReceiverScript += vbCrLf + "	table1.delchecked();"
        ReceiverScript += vbCrLf + "}"
        ReceiverScript += vbCrLf + "document.getElementById(""clearall"").onclick = function() {"
        ReceiverScript += vbCrLf + "table1.clearall();"
        ReceiverScript += vbCrLf + "}"
        ReceiverScript += vbCrLf + "document.getElementById(""sub"").onclick = function() {"
        ReceiverScript += vbCrLf + "table1.getinfo(""textbox"",""txthidden"", true, ""t_message"");"
        ReceiverScript += vbCrLf + "document.getElementById(""Button11"").click();"
        ReceiverScript += vbCrLf + "}"
        ReceiverScript += vbCrLf + "}"
        ReceiverScript += vbCrLf + "</script>"
        Page.ClientScript.RegisterClientScriptBlock(GetType(String), "ReceiverScript", ReceiverScript)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lg As New login
        lg.login()

        LoadScript()


        Try


            Page.Title = "环球运费网 - 我的办公室 - 空运运价"

            If Me.Request.Cookies("user_id") Is Nothing Then

                Response.Redirect("/accounts/login.aspx")
            Else

                If Request.Cookies("user_id").Value.ToString = "" Then
                    Response.Redirect("/accounts/login.aspx")
                End If
            End If

            If Not Page.IsPostBack Then
                Dim ds2 As Data.DataSet
                Dim conn As New data_conn3
                Dim sql As String
                sql = "select * from TB_User where UserID=" + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)

                ds2 = conn.mdb_ds(sql, "table")

                'If CInt(ds2.Tables("table").Rows(0)("User_Level").ToString()) = 0 Then
                    'Me.Response.Redirect("../accounts/regnormal.aspx")
                'End If


                'txtname.Text = ds2.Tables("table").Rows(0)("RealName")

                'txtCompanyName.Text = ds2.Tables("table").Rows(0)("CompanyName")
                'txtAddress.Text = ds2.Tables("table").Rows(0)("Address")
                'txtFax.Text = ds2.Tables("table").Rows(0)("Fax").ToString
                'txtMovePhone.Text = ds2.Tables("table").Rows(0)("MovePhone")
                'txtPhone.Text = ds2.Tables("table").Rows(0)("Phone")
                'txtPostNumber.Text = ds2.Tables("table").Rows(0)("PostNumber").ToString
                'txtUserEmail.Text = ds2.Tables("table").Rows(0)("UserEmail")

                Dim dt As DateTime = DateTime.Now
                Dim startMonth As DateTime = dt.AddDays(1 - dt.Day)
                Dim endMonth As DateTime = startMonth.AddMonths(1).AddDays(-1)

                If DateTime.Now.Day >= 15 Then
                    If (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) - DateTime.Now.Day) > 5 Then
                        BasicDatePicker1_TextBox.Value = endMonth.ToString().Split(" ")(0)
                    Else
                        BasicDatePicker1_TextBox.Value = DateTime.Now.AddMonths(1).Year.ToString() + "-" + DateTime.Now.AddMonths(1).Month.ToString() + "-" + "15"
                    End If
                Else
                    If (15 - DateTime.Now.Day) > 5 Then
                        BasicDatePicker1_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + "15"
                    Else
                        BasicDatePicker1_TextBox.Value = endMonth.ToString().Split(" ")(0)
                    End If
                End If

                '判断是否为manager用户
                If ds2.Tables("table").Rows(0)("ifmanage") = "1" Then
                    'tt.InnerHtml = "<input type=""button"" name=""Submit"" value=""选择用户"" onClick=""javascript:window.open('user_search1.asp','_blank','scrollbars=yes,width=420,height=600')"" id=""Button2"" / >"
                    'Me.Hidden1.Visible = True
                End If



                If Me.Request("startport") IsNot Nothing Then
                    If Request("startport").ToString <> "" Then
                        txtStart.Text = Request("startport").ToString
                    End If
                End If

                If Me.Request("hx") IsNot Nothing Then
                    If Request("hx").ToString <> "" Then
                        DropDownList1.SelectedValue = Request("hx").ToString
                    End If
                End If

            End If




            If (hidSave.Text = "") Then
                Dim i As Integer
                Dim strDate(2), strTime(3), strDay(3), strRam As String
                strDate = Date.Now.ToString.Split(" ")
                strDay = strDate(0).Split("-")
                strTime = strDate(1).Split(":")
                i = CInt(Int((1000 * Rnd()) + 1))
                strRam = i.ToString
                hidSave.Text = strDay(0) + strDay(1) + strDay(2) + strTime(0) + strTime(1) + strTime(2) + strRam
            Else


            End If
            Me.labnow.Text = Date.Now.ToString.Split(" ")(0)






        Catch ex As Exception

            'Me.Response.Redirect("error.aspx")
        End Try
    End Sub



    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub




    Function ExecoutID(ByVal cmdtext As String, ByVal paras() As Data.SqlClient.SqlParameter)
        Dim cmd As New Data.SqlClient.SqlCommand
        Dim data_conn As New data_conn3
        Dim conn As New Data.SqlClient.SqlConnection
        conn = data_conn.mdb_conn()
        conn.Open()
        cmd.Connection = conn
        cmd.CommandText = cmdtext
        cmd.CommandType = Data.CommandType.StoredProcedure
        Dim newid As String = String.Empty

        If paras.Length > 0 Then
            Dim i As Integer
            For i = 0 To paras.Length - 1
                cmd.Parameters.Add(paras(i))
            Next

        End If
        cmd.ExecuteNonQuery()



        If paras.Length > 0 Then


            Dim i As Integer
            For i = 0 To paras.Length - 1

                If paras(i).Direction = Data.ParameterDirection.Output Then

                    newid = Convert.ToString(paras(i).Value)

                End If

            Next

        End If

        conn.Close()

        Return newid

    End Function

    Protected Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
        'Try
        'If Session("AirRelease") Is Nothing Then
        '    Response.Redirect("../search/err.aspx")
        'Else
        '    If Session("AirRelease") = "" Then
        '        Response.Redirect("../search/err.aspx")
        '    Else

        If txthidden.Value = "" Then
            MessageBox("", "目的港不能为0个")
            Return
        End If

        If txthidden.Value.Replace("", "").Replace("", "").Replace("0", "").Replace("1", "") = "" Then
            MessageBox("", "目的港不能为0个")
            Return
        End If

        Dim strsubmitrow As String() = Regex.Split(txthidden.Value, "", RegexOptions.IgnoreCase)

        Dim k As Integer

        For k = 0 To strsubmitrow.Length - 1
            If strsubmitrow(k).Substring(0, 1) = "" Then
                MessageBox("", "第" + (k + 1).ToString + "行的目的港不能为空")
                Return
            End If
        Next


        If txtTitle.Text = "" Then
            MessageBox("", "标题不能为空")
        ElseIf BasicDatePicker1_TextBox.Value = "" Then
            MessageBox("", "有效日期不能为空")
        ElseIf txtStart.Text = "" Then
            MessageBox("", "启运港不能为空")
        ElseIf DropDownList1.Text = "请选择" Then
            MessageBox("", "请选择航线")
        Else

            Dim text As String = check.CheckInput(txtRemark.Text)
            text = text.Replace(Chr(10), "<br>")
            text = text.Replace(" ", "&nbsp")


            '转换成英文
            Dim cn As New data_conn
            Dim dsStartPort As Data.DataSet = cn.mdb_ds("select * from TB_CHINACITY where CityNameCH='" + check.CheckInput(txtStart.Text.Trim().Replace("'", "''")) + "'", "StartPort")
            Dim StartPort_en As String
            If dsStartPort.Tables("StartPort").Rows.Count > 0 Then
                StartPort_en = dsStartPort.Tables("StartPort").Rows(0)("CityName").ToString().ToUpper
            Else
                StartPort_en = check.CheckInput(txtStart.Text.Replace("'", "''")).ToUpper
            End If
            '==========================

            Dim paras(21) As Data.SqlClient.SqlParameter

            paras(0) = New Data.SqlClient.SqlParameter("@PostDate", Data.SqlDbType.SmallDateTime)
            paras(0).Value = Date.Now
            paras(1) = New Data.SqlClient.SqlParameter("@DestPort", Data.SqlDbType.NVarChar)
            paras(1).Value = ""
            paras(2) = New Data.SqlClient.SqlParameter("@StartPort", Data.SqlDbType.NVarChar)
            paras(2).Value = check.CheckInput(txtStart.Text)
            paras(3) = New Data.SqlClient.SqlParameter("@enddate", Data.SqlDbType.NVarChar)
            paras(3).Value = check.CheckInput(BasicDatePicker1_TextBox.Value)
            paras(4) = New Data.SqlClient.SqlParameter("@memo", Data.SqlDbType.NText)
            paras(4).Value = text.Replace("'", "''")
            paras(5) = New Data.SqlClient.SqlParameter("@COMPANY", Data.SqlDbType.NVarChar)
            paras(5).Value = ""
            paras(6) = New Data.SqlClient.SqlParameter("@AIRCOMPANY", Data.SqlDbType.NVarChar)
            paras(6).Value = ""
            paras(7) = New Data.SqlClient.SqlParameter("@UserID", Data.SqlDbType.Int)
            paras(7).Value = check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
            paras(8) = New Data.SqlClient.SqlParameter("@title", Data.SqlDbType.NVarChar, 50)
            paras(8).Value = check.CheckInput(txtTitle.Text)
            paras(9) = New Data.SqlClient.SqlParameter("@attach", Data.SqlDbType.NVarChar, 50)
            paras(9).Value = ""
            paras(10) = New Data.SqlClient.SqlParameter("@hits", Data.SqlDbType.Int)
            paras(10).Value = 0
            paras(11) = New Data.SqlClient.SqlParameter("@LINE", Data.SqlDbType.NVarChar, 50)
            paras(11).Value = check.CheckInput(DropDownList1.Text)
            paras(12) = New Data.SqlClient.SqlParameter("@CompanyName", Data.SqlDbType.NVarChar)
            paras(12).Value = ""
            paras(13) = New Data.SqlClient.SqlParameter("@CompanyAddr", Data.SqlDbType.NVarChar)
            paras(13).Value = ""
            paras(14) = New Data.SqlClient.SqlParameter("@CompanyPhone", Data.SqlDbType.NVarChar)
            paras(14).Value = ""
            paras(15) = New Data.SqlClient.SqlParameter("@CompanyFax", Data.SqlDbType.NVarChar)
            paras(15).Value = ""
            paras(16) = New Data.SqlClient.SqlParameter("@CommuPerson", Data.SqlDbType.NVarChar)
            paras(16).Value = ""
            paras(17) = New Data.SqlClient.SqlParameter("@email", Data.SqlDbType.NVarChar)
            paras(17).Value = ""
            paras(18) = New Data.SqlClient.SqlParameter("@mobile", Data.SqlDbType.NVarChar)
            paras(18).Value = ""
            paras(19) = New Data.SqlClient.SqlParameter("@UserID2", Data.SqlDbType.Int)
            paras(19).Value = "0"
            paras(20) = New Data.SqlClient.SqlParameter("@StartPort_en", Data.SqlDbType.NVarChar)
            paras(20).Value = check.CheckInput(StartPort_en)
            'If Me.Hidden1.Visible = True Then
            '    If Hidden1.Value = "" Then
            '        paras(19).Value = "0"
            '    Else

            '        paras(19).Value = Me.Hidden1.Value.ToString
            '    End If
            'Else
            '    paras(19).Value = "0"
            'End If




            paras(21) = New Data.SqlClient.SqlParameter("@id", Data.SqlDbType.Int)
            paras(21).Direction = Data.ParameterDirection.Output


            Dim id As Integer = ExecoutID("Air_UP_brand_add", paras)





            Dim strsubmit As String = Me.txthidden.Value

            Dim strarray As String() = Regex.Split(strsubmit, "", RegexOptions.IgnoreCase)

            Dim i As Integer

            Dim data_conn As New data_conn3
            Dim conn As New Data.SqlClient.SqlConnection
            conn = data_conn.mdb_conn()
            conn.Open()
            Dim value As String
            Dim strSQL As String = ""
            Dim strrow As String()
            For i = 0 To strarray.Length - 1



                strrow = Regex.Split(strarray(i), "", RegexOptions.IgnoreCase)

                If strrow(3) = "" And strrow(4) = "" And strrow(5) = "" And strrow(6) = "" And strrow(7) = "" Then
                    strrow(5) = "电询"
                End If
                value = check.CheckNumber(id.ToString) + ",'" + check.CheckInput(strrow(0)) + "','" + check.CheckInput(strrow(1)) + "','" + check.CheckInput(strrow(2)) + "','" + check.CheckInput(strrow(3)) + "','" + check.CheckInput(strrow(4)) + "','" + check.CheckInput(strrow(5)) + "','" + check.CheckInput(strrow(6)) + "','" + check.CheckInput(strrow(7)) + "','" + check.CheckInput(strrow(8)) + "','" + check.CheckInput(strrow(9)) + "','" + check.CheckInput(strrow(10)) + "','" + check.CheckInput(strrow(11)) + "',0,'" + check.CheckInput(txtTitle.Text) + "','" + Date.Now + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value) + "','" + check.CheckInput(DropDownList1.Text) + "'," + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString) + ",'" + StartPort_en + "'"

                strSQL += "insert into T_AIRPRICE (AIRID,DestPort,PRICE_M,PRICE_N,PRICE_P45,PRICE_P100,PRICE_P300,PRICE_P500,PRICE_P1000,price20gpAppend,Distance,departurewkd,memo,assurance,Titlex,PostDatex,enddatex,LINEx,UserIDx,StartPort_en) values (" + value + ");"



            Next

            strSQL += "update T_AIRINFO set DestPort1='" + check.CheckInput(strrow(0)) + "',PRICE_P451='" + check.CheckInput(strrow(3)) + "',PRICE_P1001='" + check.CheckInput(strrow(4)) + "',PRICE_P3001='" + check.CheckInput(strrow(5)) + "',PRICE_P5001='" + check.CheckInput(strrow(6)) + "',PRICE_P10001='" + check.CheckInput(strrow(7)) + "',assurance=0 where id=" + id.ToString + ";"
            strSQL += "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.aircount = (SELECT COUNT(t_airinfo.id) AS yunjiacount FROM t_airinfo,t_airprice WHERE t_airinfo.id = t_airprice.airid),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1"

            Dim myCommand1 As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSQL, conn)

            myCommand1.ExecuteNonQuery()
            conn.Close()
            If dsStartPort.Tables("StartPort").Rows.Count > 0 Then
                Dim tp As New topnew
                tp.SetTopNew(id, check.CheckInput(txtTitle.Text), Date.Now.ToString(), 10, check.CheckInput(DropDownList1.Text), check.CheckInput(StartPort_en.Replace("'", "''")), check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString))
            End If

            Dim ds As Data.DataSet = cn.mdb_ds("select * from TB_User where UserID=" + Request.Cookies("user_id").Value, "user")
            If (ds.Tables("user").Rows(0)("time_limiter").ToString = "1") Then
                cn.mdb_exe("update TB_User set time_limit_air=getdate() where UserID=" + ds.Tables("user").Rows(0)("UserID").ToString)
            End If

            'Response.Redirect("airlist.aspx")
            Server.Transfer("ReleaseSucceed.aspx?id=" + id.ToString() + "&type=3")
        End If


        '    End If
        'End If


        'Catch ex As Exception
        '    Me.Response.Redirect("error.aspx")
        'End Try
    End Sub
End Class
