
Partial Class member_SpellRelease1
    Inherits System.Web.UI.Page
    Dim check As New check


    Public Sub GridViewDataBind()
        Dim strsubmit As String = Me.hidsubmit.Value

        Dim strarray As String() = Regex.Split(strsubmit, "sdfgyuio", RegexOptions.IgnoreCase)
        Dim dt As New Data.DataTable
        'dt.Columns.Add("id")
        'dt.Columns.Add("TempID")
        dt.Columns.Add("DestPort")
        dt.Columns.Add("pricegpv")
        dt.Columns.Add("pricegp")
        dt.Columns.Add("price20gpAppend")
        dt.Columns.Add("Distance")
        dt.Columns.Add("DepartureWkd")
        dt.Columns.Add("shipcompany")
        dt.Columns.Add("memo")
        dt.Columns.Add("assurance")

        If strarray.Length = 1 Then
            Dim i As Integer
            For i = 0 To 14
                Dim row As Data.DataRow = dt.NewRow


                If Me.Request("DestPort") <> "" And i = 0 Then
                    'txtStart.Text = Me.Request("StartPort")
                    row("DestPort") = Me.Request("DestPort")
                Else
                    row("DestPort") = ""
                End If

                row("pricegpv") = ""
                row("pricegp") = ""
                row("price20gpAppend") = ""
                row("Distance") = ""
                row("DepartureWkd") = ""
                If Me.Request("shipcompany") <> "" And i = 0 Then
                    row("shipcompany") = Me.Request("shipcompany")
                Else
                    row("shipcompany") = ""
                End If
                row("memo") = ""
                row("assurance") = "0"

                dt.Rows.Add(row)
            Next

        Else
            Dim k As Integer
            For k = 0 To strarray.Length - 2

                Dim strrow As String()

                strrow = Regex.Split(strarray(k), "qwerhjkl", RegexOptions.IgnoreCase)
                Dim row As Data.DataRow = dt.NewRow


                row("DestPort") = strrow(0)
                row("pricegpv") = strrow(1)
                row("pricegp") = strrow(2)
                row("price20gpAppend") = strrow(3)
                row("Distance") = strrow(4)
                row("DepartureWkd") = strrow(5)
                row("shipcompany") = strrow(6)
                row("memo") = strrow(7)
                row("assurance") = strrow(8)

                dt.Rows.Add(row)
            Next
        End If

        GridView2.DataSource = dt
        GridView2.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.Title = "环球运费网 - 我的办公室 - 拼箱运价"

            If Me.Request.Cookies("user_id") Is Nothing Then

                Response.Redirect("/accounts/login.aspx")
            Else

                If Request.Cookies("user_id").Value.ToString = "" Then
                    Response.Redirect("/accounts/login.aspx")
                End If
            End If

            If Not Page.IsPostBack Then
                Literal1.Text = "<a href='SpellRelease_1.aspx'>切换到新版</a>"
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
                    BasicDatePicker1_TextBox.Value = endMonth.ToString().Split(" ")(0)
                Else
                    BasicDatePicker1_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + "15"
                End If

                '判断是否为manager用户
                If ds2.Tables("table").Rows(0)("ifmanage") = "1" Then
                    'tt.InnerHtml = "<input type=""button"" name=""Submit"" value=""选择用户"" onClick=""javascript:window.open('user_search1.asp','_blank','scrollbars=yes,width=420,height=600')"" id=""Button2"" / >"
                    'Me.Hidden1.Visible = True
                End If

                If ds2.Tables("table").Rows(0)("star_allin") = 0 Then
                    LitRow1.Text = "<input id='Button5' type='button' value='添加1行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),1,1)"" />"
                    LitRow5.Text = "<input id='Button2' type='button' value='添加5行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),5,1)"" />"
                    LitRow10.Text = "<input id='Button3' type='button' value='添加10行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),10,1)"" />"
                    'LitRow50.Text = "<input id='Button4' type='button' value='添加50行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),50,1)"" />"

                    GridView2.Columns(8).ItemStyle.CssClass = "displayrow"
                    GridView2.Columns(8).HeaderStyle.CssClass = "displayrow"
                End If

                '填入页面参数
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
                'a = hidSave.Text
                'strSQL = "select * from TB_TempYunJiaInfo where TempID=" + a
                'SqlDataSource2.SelectCommand = strSQL
                'SqlDataSource2.UpdateCommand = "UPDATE [TB_TempYunJiaInfo] SET [TempID] = ?, [DestPort] = ?, [DepartureWkd] = ?, [Distance] = ?, [memo] = ?, [StartPort] = ?, [price20gpAppend] = ?, [price20gp] = ?, [price20gpMark] = ?, [price40gp] = ?, [price40gpAppend] = ?, [price40gpMark] = ?, [price40hq] = ?, [price40hqMark] = ?, [price40hqAppend] = ?, [pricegp] = ? WHERE [id] = ?"

                'Me.GridView2.DataSourceID = "SqlDataSource2"

            End If
            Me.labnow.Text = Date.Now.ToString.Split(" ")(0)


            GridViewDataBind()

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


        'If Session("SpellRelease") Is Nothing Then
        '    Response.Redirect("../search/err.aspx")
        'Else
        '    If Session("SpellRelease") = "" Then
        '        Response.Redirect("../search/err.aspx")
        '    Else


        If hidsubmit.Value = "" Then
            MessageBox("", "目的港不能为0个")
            Return
        End If

        If hidsubmit.Value.Replace("qwerhjkl", "").Replace("sdfgyuio", "").Replace("0", "").Replace("1", "") = "" Then
            MessageBox("", "目的港不能为0个")
            Return
        End If

        Dim strsubmitrow As String() = Regex.Split(hidsubmit.Value, "sdfgyuio", RegexOptions.IgnoreCase)

        Dim k As Integer

        For k = 0 To strsubmitrow.Length - 2
            If strsubmitrow(k).Substring(0, 8) = "qwerhjkl" And (strsubmitrow(k) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl0qwerhjkl" And strsubmitrow(k) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl1qwerhjkl") Then
                MessageBox("", "第" + (k + 1).ToString + "行的目的港不能为空")
                Return
            End If

            Dim strrow As String()
            strrow = Regex.Split(strsubmitrow(k), "qwerhjkl", RegexOptions.IgnoreCase)
            If strrow(6) = "" And (strsubmitrow(k) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl0qwerhjkl" And strsubmitrow(k) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl1qwerhjkl") Then
                MessageBox("", "第" + (k + 1).ToString + "行的船公司不能为空")
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

            Dim cn As New data_conn
            Dim dsStartPort As Data.DataSet = cn.mdb_ds("select * from TB_CHINACITY where CityNameCH='" + check.CheckInput(txtStart.Text.Trim().Replace("'", "''")) + "'", "StartPort")

            Dim StartPort_en As String
            If dsStartPort.Tables("StartPort").Rows.Count > 0 Then
                StartPort_en = dsStartPort.Tables("StartPort").Rows(0)("CityName").ToString().ToUpper
            Else
                StartPort_en = check.CheckInput(txtStart.Text.Replace("'", "''")).ToUpper
            End If

            Dim paras(27) As Data.SqlClient.SqlParameter

            paras(0) = New Data.SqlClient.SqlParameter("@UserID", Data.SqlDbType.Int)
            paras(0).Value = check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
            paras(1) = New Data.SqlClient.SqlParameter("@title", Data.SqlDbType.NVarChar, 50)
            paras(1).Value = check.CheckInput(txtTitle.Text.Replace("'", "''"))
            paras(2) = New Data.SqlClient.SqlParameter("@PostDate", Data.SqlDbType.SmallDateTime)
            paras(2).Value = Date.Now.ToString
            paras(3) = New Data.SqlClient.SqlParameter("@enddate", Data.SqlDbType.SmallDateTime)
            paras(3).Value = check.CheckInput(BasicDatePicker1_TextBox.Value)
            paras(4) = New Data.SqlClient.SqlParameter("@yunjialeixing", Data.SqlDbType.Int)
            paras(4).Value = 9
            paras(5) = New Data.SqlClient.SqlParameter("@hangxianmiaoshu", Data.SqlDbType.NVarChar, 255)
            paras(5).Value = check.CheckInput(DropDownList1.Text)
            paras(6) = New Data.SqlClient.SqlParameter("@StartPort", Data.SqlDbType.NVarChar)
            paras(6).Value = check.CheckInput(txtStart.Text.Replace("'", "''"))
            paras(7) = New Data.SqlClient.SqlParameter("@DestPort", Data.SqlDbType.NVarChar)
            paras(7).Value = ""
            paras(8) = New Data.SqlClient.SqlParameter("@zhuangxiangchangdi", Data.SqlDbType.NVarChar)
            paras(8).Value = ""
            paras(9) = New Data.SqlClient.SqlParameter("@baozhuangyaoqiu", Data.SqlDbType.NVarChar)
            paras(9).Value = ""
            paras(10) = New Data.SqlClient.SqlParameter("@PriceDesc", Data.SqlDbType.NText)
            paras(10).Value = ""
            paras(11) = New Data.SqlClient.SqlParameter("@memo", Data.SqlDbType.NText)
            paras(11).Value = text.Replace("'", "''")
            paras(12) = New Data.SqlClient.SqlParameter("@fujiandizhi", Data.SqlDbType.NVarChar)
            paras(12).Value = ""
            paras(13) = New Data.SqlClient.SqlParameter("@ifpass", Data.SqlDbType.Int)
            paras(13).Value = 0
            paras(14) = New Data.SqlClient.SqlParameter("@hits", Data.SqlDbType.Int)
            paras(14).Value = 0
            paras(15) = New Data.SqlClient.SqlParameter("@OnTop", Data.SqlDbType.Int)
            paras(15).Value = 0
            paras(16) = New Data.SqlClient.SqlParameter("@supportspecial", Data.SqlDbType.Bit)
            paras(16).Value = False
            paras(17) = New Data.SqlClient.SqlParameter("@specialdesc", Data.SqlDbType.NVarChar)
            paras(17).Value = ""
            paras(18) = New Data.SqlClient.SqlParameter("@CompanyName", Data.SqlDbType.NVarChar)
            paras(18).Value = ""
            paras(19) = New Data.SqlClient.SqlParameter("@CompanyAddr", Data.SqlDbType.NVarChar)
            paras(19).Value = ""
            paras(20) = New Data.SqlClient.SqlParameter("@CompanyPhone", Data.SqlDbType.NVarChar)
            paras(20).Value = ""
            paras(21) = New Data.SqlClient.SqlParameter("@CompanyFax", Data.SqlDbType.NVarChar)
            paras(21).Value = ""
            paras(22) = New Data.SqlClient.SqlParameter("@CommuPerson", Data.SqlDbType.NVarChar)
            paras(22).Value = ""
            paras(23) = New Data.SqlClient.SqlParameter("@email", Data.SqlDbType.NVarChar)
            paras(23).Value = ""
            paras(24) = New Data.SqlClient.SqlParameter("@mobile", Data.SqlDbType.NVarChar)
            paras(24).Value = ""
            paras(25) = New Data.SqlClient.SqlParameter("@UserID2", Data.SqlDbType.Int)
            paras(25).Value = "0"
            paras(26) = New Data.SqlClient.SqlParameter("@StartPort_en", Data.SqlDbType.NVarChar)
            paras(26).Value = StartPort_en
            'If Me.Hidden1.Visible = True Then
            '    If Hidden1.Value = "" Then
            '        paras(25).Value = "0"
            '    Else

            '        paras(25).Value = Me.Hidden1.Value.ToString
            '    End If
            'Else
            '    paras(25).Value = "0"
            'End If




            paras(27) = New Data.SqlClient.SqlParameter("@id", Data.SqlDbType.Int)
            paras(27).Direction = Data.ParameterDirection.Output


            Dim id As Integer = ExecoutID("UP_brand_add", paras)



            Dim strsubmit As String = Me.hidsubmit.Value

            Dim strarray As String() = Regex.Split(strsubmit, "sdfgyuio", RegexOptions.IgnoreCase)
            Dim i As Integer

            Dim data_conn As New data_conn3
            Dim conn As New Data.SqlClient.SqlConnection
            conn = data_conn.mdb_conn()
            conn.Open()
            Dim value As String
            Dim strSQL As String = ""
            Dim strrow As String()
            For i = 0 To strarray.Length - 2

                If strarray(i) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl0qwerhjkl" And strarray(i) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl1qwerhjkl" Then

                    strrow = Regex.Split(strarray(i), "qwerhjkl", RegexOptions.IgnoreCase)
                    value = check.CheckNumber(id.ToString) + ",'" + check.CheckInput(strrow(0)) + "','" + check.CheckInput(strrow(1)) + "','" + check.CheckInput(strrow(2)) + "','" + check.CheckInput(strrow(3)) + "','" + check.CheckInput(strrow(4)) + "','" + check.CheckInput(strrow(5)) + "','" + check.CheckInput(strrow(6)) + "','" + check.CheckInput(strrow(7)) + "'," + check.CheckInput(strrow(8)) + ",'" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "','" + check.CheckInput(txtStart.Text) + "','" + Date.Now.ToString + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value) + "',9,'" + check.CheckInput(DropDownList1.Text) + "'," + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString) + ",'" + StartPort_en + "'"

                    strSQL += "insert into TB_YunJiaInfo (YunJiaID,DestPort,pricegpv,pricegp,price20gpAppend,Distance,DepartureWkd,shipcompany,memo,assurance,Titlex,StartPortx,PostDatex,enddatex,yunjialeixingx,hangxianmiaoshux,UserIDx,StartPort_en) values (" + value + ");"


                End If


            Next


            strSQL += "update TB_YunJia set DestPort1='" + check.CheckInput(strrow(0)) + "',pricegpv1='" + check.CheckInput(strrow(1)) + "',pricegp1='" + check.CheckInput(strrow(2)) + "',shipcompany1='" + check.CheckInput(strrow(6)) + "',assurance=" + check.CheckInput(strrow(8)) + " where id=" + id.ToString + ";"
            strSQL += "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.lclcount = (SELECT COUNT(id) AS yunjiacount FROM tb_yunjiainfo WHERE yunjialeixingx = 9),TB_PRICECOUNT.countdate = getdate() where (TB_PRICECOUNT.cid = 1);"
            Dim myCommand1 As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSQL, conn)
            Try
                myCommand1.ExecuteNonQuery()
            Catch ex As Exception
                Me.Response.Write("错误：" + strSQL)
            End Try

            conn.Close()
            If dsStartPort.Tables("StartPort").Rows.Count > 0 Then
                Dim tp As New topnew
                tp.SetTopNew(id, check.CheckInput(txtTitle.Text), Date.Now.ToString(), 9, check.CheckInput(DropDownList1.Text), check.CheckInput(StartPort_en.Replace("'", "''")), check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString))

            End If
            
            Dim ds As Data.DataSet = cn.mdb_ds("select * from TB_User where UserID=" + Request.Cookies("user_id").Value, "user")

	    If (ds.Tables("user").Rows(0)("time_limiter").ToString = "1") Then
                cn.mdb_exe("update TB_User set time_limit_lcl=getdate() where UserID=" + ds.Tables("user").Rows(0)("UserID").ToString)
            End If

            Server.Transfer("ReleaseSucceed.aspx?id=" + id.ToString() + "&type=2")
            'Response.Redirect("lcllist.aspx")

        End If

        '    End If
        'End If
    End Sub
End Class
