Imports System.Data

Partial Class member_jilu
    Inherits System.Web.UI.Page
    Dim check As New check


    'Public Sub GridViewDataBind()

    '    Dim strsubmit As String = Me.hidsubmit.Value


    '    Dim strarray As String() = Regex.Split(strsubmit, "sdfgyuio", RegexOptions.IgnoreCase)
    '    Dim dt As New Data.DataTable
    '    'dt.Columns.Add("id")
    '    'dt.Columns.Add("TempID")
    '    dt.Columns.Add("DestPort")
    '    dt.Columns.Add("price20gp")
    '    dt.Columns.Add("price40gp")
    '    dt.Columns.Add("price40hq")
    '    dt.Columns.Add("price20gpAppend")
    '    dt.Columns.Add("Distance")
    '    dt.Columns.Add("DepartureWkd")
    '    dt.Columns.Add("shipcompany")
    '    dt.Columns.Add("memo")

    '    If strarray.Length = 1 Then
    '        Dim i As Integer
    '        For i = 0 To 19
    '            Dim row As Data.DataRow = dt.NewRow
    '            If Me.Request("DestPort") <> "" And i = 0 Then
    '                txtStart.Text = Me.Request("StartPort")
    '                row("DestPort") = Me.Request("DestPort")
    '            Else
    '                row("DestPort") = ""
    '            End If

    '            row("price20gp") = ""
    '            row("price40gp") = ""
    '            row("price40hq") = ""
    '            row("price20gpAppend") = ""
    '            row("Distance") = ""
    '            row("DepartureWkd") = ""
    '            row("shipcompany") = ""
    '            row("memo") = ""


    '            dt.Rows.Add(row)
    '        Next

    '    Else
    '        Dim k As Integer
    '        For k = 0 To strarray.Length - 2

    '            Dim strrow As String()

    '            strrow = Regex.Split(strarray(k), "qwerhjkl", RegexOptions.IgnoreCase)
    '            Dim row As Data.DataRow = dt.NewRow


    '            row("DestPort") = strrow(0)
    '            row("price20gp") = strrow(1)
    '            row("price40gp") = strrow(2)
    '            row("price40hq") = strrow(3)
    '            row("price20gpAppend") = strrow(4)
    '            row("Distance") = strrow(5)
    '            row("DepartureWkd") = strrow(6)
    '            row("shipcompany") = strrow(7)
    '            row("memo") = strrow(8)

    '            dt.Rows.Add(row)
    '        Next
    '    End If

    '    GridView2.DataSource = dt
    '    GridView2.DataBind()









    'End Sub

    Function trun(ByVal id As String) As Data.DataSet
        Dim ds As Data.DataSet
        Dim strSQL As String
        strSQL = "select * from TB_YunJia where id=" + id
        Dim tt As New data_conn3
        ds = tt.mdb_ds(strSQL, "asdf")
        Return ds
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        Page.Title = "环球运费网 - 我的办公室 - 整箱运价"


        If Me.Request.Cookies("user_id") Is Nothing Then

            Response.Redirect("reg.aspx")
        Else

            If Request.Cookies("user_id").Value.ToString = "" Then
                Response.Redirect("reg.aspx")
            End If
        End If

        Dim a As String
        a = check.CheckNumber(Request("id"))
        'HyperLink2.NavigateUrl = "~/member/jilu.aspx?id=" + a
        'Dim strSQL As String
        'strSQL = "select * from TB_YunJiaInfo where YunJiaID=" + a
        'Me.Response.Write(strSQL)
        'SqlDataSource1.SelectCommand = strSQL

        'Me.GridView1.DataSourceID = "SqlDataSource1"
        '====================================================

        If Not Page.IsPostBack Then
            Literal1.Text = "<a href='jilu.aspx?id=" + a + "'>切换到旧版</a>"

            Dim ds As Data.DataSet
            ds = trun(a)
            Try
                If ds.Tables(0).Rows(0)("UserID2").ToString <> Request.Cookies("user_id").Value.ToString And ds.Tables(0).Rows(0)("UserID").ToString <> Request.Cookies("user_id").Value.ToString Then
                    Response.Redirect("../search/err.aspx")
                End If
            Catch ex As Exception
                Response.Redirect("../search/err.aspx")
            End Try




            labpost.Text = ds.Tables(0).Rows(0)("PostDate").ToString.Split(" ")(0)
            txtTitle.Text = HttpContext.Current.Server.HtmlDecode(ds.Tables(0).Rows(0)("title").ToString)

            'BasicDatePicker1_TextBox.Value = ds.Tables(0).Rows(0)("enddate").ToString.Split(" ")(0)

            Dim dt As DateTime = DateTime.Now
            Dim startMonth As DateTime = dt.AddDays(1 - dt.Day)
            Dim endMonth As DateTime = startMonth.AddMonths(1).AddDays(-1)



            Dim aaa As DateTime = DateTime.ParseExact(ds.Tables(0).Rows(0)("enddate").ToString().Split(" ")(0), "yyyy-M-d", Nothing)

            If aaa > DateTime.Now Then
                BasicDatePicker1_TextBox.Value = ds.Tables(0).Rows(0)("enddate").ToString.Split(" ")(0)
            Else
                If DateTime.Now.Day >= 15 Then
                    BasicDatePicker1_TextBox.Value = endMonth.ToString().Split(" ")(0)
                Else
                    BasicDatePicker1_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + "15"
                End If
            End If






            txtStart.Text = HttpContext.Current.Server.HtmlDecode(ds.Tables(0).Rows(0)("StartPort").ToString)
            DropDownList1.SelectedItem.Text = ds.Tables(0).Rows(0)("hangxianmiaoshu").ToString

            Dim memo As String = ds.Tables(0).Rows(0)("memo").ToString
            memo = memo.Replace("<br>", Chr(10))
            memo = memo.Replace("&nbsp", " ")
            txtRemark.Text = HttpContext.Current.Server.HtmlDecode(memo)
            'Me.Hidden1.Value = ds.Tables(0).Rows(0)("UserID2").ToString
            'Me.Response.Write(ds.Tables(0).Rows(0)("UserID2").ToString)




            Dim ds2 As DataSet
            Dim conn As New data_conn3
            Dim sql As String





            If ds.Tables(0).Rows(0)("UserID2").ToString = "0" Then
                sql = "select * from TB_User where UserID=" + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
            Else
                sql = "select * from TB_User where UserID=" + check.CheckNumber(ds.Tables(0).Rows(0)("UserID2").ToString)
                '判断是否为manager用户

            End If

            ds2 = conn.mdb_ds(sql, "table")
            'txtname.Text = ds2.Tables("table").Rows(0)("RealName").ToString
            'txtCompanyName.Text = ds2.Tables("table").Rows(0)("CompanyName").ToString
            'txtAddress.Text = ds2.Tables("table").Rows(0)("Address").ToString
            'txtFax.Text = ds2.Tables("table").Rows(0)("Fax").ToString
            'txtMovePhone.Text = ds2.Tables("table").Rows(0)("MovePhone").ToString
            'txtPhone.Text = ds2.Tables("table").Rows(0)("Phone").ToString
            'txtPostNumber.Text = ds2.Tables("table").Rows(0)("PostNumber").ToString
            'txtUserEmail.Text = ds2.Tables("table").Rows(0)("UserEmail").ToString

            If ds2.Tables("table").Rows(0)("star_allin") = 0 Then
                LitRow1.Text = "<input id='Button5' type='button' value='添加1行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),1,1)"" />"
                LitRow5.Text = "<input id='Button2' type='button' value='添加5行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),5,1)"" />"
                LitRow10.Text = "<input id='Button3' type='button' value='添加10行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),10,1)"" />"
                'LitRow50.Text = "<input id='Button4' type='button' value='添加50行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),50,1)"" />"

                GridView2.Columns(10).ItemStyle.CssClass = "displayrow"
                GridView2.Columns(10).HeaderStyle.CssClass = "displayrow"
            End If



            '判断是否为manager用户，是的话，显示选择用户按钮
            Dim ds3 As DataSet
            sql = "select * from TB_User where UserID=" + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
            ds3 = conn.mdb_ds(sql, "table")

            If ds3.Tables("table").Rows(0)("ifmanage") = 1 Then
                'tt.InnerHtml = "<input type=""button"" name=""Submit"" value=""选择用户"" onClick=""javascript:window.open('user_search1.asp','_blank','scrollbars=yes,width=420,height=600')"" id=""Button2"" / >"
                'Me.Hidden1.Visible = True
            End If



            Dim dsyunjia As DataSet = conn.mdb_ds("select * from TB_YunJiaInfo where YunJiaID=" + a + " order by DestPort", "yunjia")
            Dim row As Data.DataRow = dsyunjia.Tables("yunjia").NewRow

            row("DestPort") = ""
            row("price20gp") = ""
            row("price40gp") = ""
            row("price40hq") = ""
            row("price45hq") = ""
            row("price20gpAppend") = ""
            row("Distance") = ""
            row("DepartureWkd") = ""
            row("shipcompany") = ""
            row("memo") = ""
            row("assurance") = "0"

            dsyunjia.Tables("yunjia").Rows.Add(row)
            GridView2.DataSource = dsyunjia.Tables("yunjia")
            GridView2.DataBind()

        End If
        'Catch ex As Exception
        '    Me.Response.Redirect("error.aspx")
        'End Try

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
            If strsubmitrow(k).Substring(0, 8) = "qwerhjkl" And (strsubmitrow(k) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl0qwerhjkl" And strsubmitrow(k) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl1qwerhjkl") Then
                MessageBox("", "第" + (k + 1).ToString + "行的目的港不能为空")
                Return
            End If

            Dim strrow As String()
            strrow = Regex.Split(strsubmitrow(k), "qwerhjkl", RegexOptions.IgnoreCase)
            If strrow(8) = "" And (strsubmitrow(k) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl0qwerhjkl" And strsubmitrow(k) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl1qwerhjkl") Then
                MessageBox("", "第" + (k + 1).ToString + "行的船公司不能为空")
                Return
            End If

        Next




        If txtTitle.Text = "" Then
            MessageBox("", "标题不能为空")
        ElseIf BasicDatePicker1_TextBox.Value = "" Then
            MessageBox("", "有效日期不能为空")
        ElseIf DropDownList1.Text = "请选择" Then
            MessageBox("", "请选择航线")
        ElseIf txtStart.Text = "" Then
            MessageBox("", "启运港不能为空")

        Else
            Dim strSql As String
            Dim meno As String = check.CheckInput(txtRemark.Text)
            meno = meno.Replace(Chr(10), "<br>")
            meno = meno.Replace(" ", "&nbsp")

            Dim data_conn As New data_conn3
            Dim conn As New Data.SqlClient.SqlConnection
            conn = data_conn.mdb_conn()
            conn.Open()

            '==================================================
            Dim adv As String = "0"
            Dim advx1 As String = "0"
            'If CInt(Request.Cookies("user_id").Value) = 1199 And (DropDownList1.Text = "中南美线" Or DropDownList1.Text = "中东印巴线" Or DropDownList1.Text = "非洲线") Then
            '    adv = "1"
            '    advx = "1"
            'End If

            'If Request.Cookies("user_id").Value = 62944 And DropDownList1.Text = "中东印巴线" Then
            '    adv = "1"
            '    advx = "1"
            'End If

            'If CInt(Request.Cookies("user_id").Value = 25855) And (DropDownList1.Text = "日韩线") Then
            '    adv = "1"
            '    advx = "1"
            'End If
            Dim cn As New data_conn
            Dim ds As Data.DataSet = cn.mdb_ds("select * from TB_User where UserID=" + Request.Cookies("user_id").Value, "user")
            Dim strArrayLine() As String
            If ds.Tables("user").Rows(0)("Login2_Adventage_Line_Adv").ToString <> "" Then
                strArrayLine = ds.Tables("user").Rows(0)("Login2_Adventage_Line_Adv").ToString.Split("|")
                For j As Integer = 0 To strArrayLine.Length - 1
                    If strArrayLine(j) = DropDownList1.Text Then
                        adv = ds.Tables("user").Rows(0)("star_adv").ToString
                        advx1 = ds.Tables("user").Rows(0)("star_adv").ToString
                    End If
                Next
            End If
            '==================================================
            '转换成英文
            Dim dsStartPort As Data.DataSet = cn.mdb_ds("select * from TB_CHINACITY where CityNameCH='" + check.CheckInput(txtStart.Text.Trim().Replace("'", "''")) + "'", "StartPort")
            Dim StartPort_en As String
            If dsStartPort.Tables("StartPort").Rows.Count > 0 Then
                StartPort_en = dsStartPort.Tables("StartPort").Rows(0)("CityName").ToString().ToUpper
            Else
                StartPort_en = check.CheckInput(txtStart.Text.Replace("'", "''")).ToUpper
            End If
            '==========================

            strSql = "update TB_YunJia set order_adv=" + adv + ",title='" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "',enddate='" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',StartPort='" + check.CheckInput(txtStart.Text.Replace("'", "''")) + "',hangxianmiaoshu='" + check.CheckInput(DropDownList1.Text.Replace("'", "''")) + "',memo='" + meno.Replace("'", "''") + "',PostDate='" + Date.Now.ToString.Replace("'", "''") + "',updateTimes=updateTimes+1,StartPort_en='" + StartPort_en + "' where id=" + check.CheckNumber(Request("id"))


            Dim myCommand As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSql, conn)

            myCommand.ExecuteNonQuery()
            Me.labpost.Text = Date.Now.ToString


            myCommand.CommandText = "delete from TB_YunJiaInfo where YunJiaID=" + check.CheckNumber(Request("id"))

            myCommand.ExecuteNonQuery()

            Dim strsubmit As String = Me.hidsubmit.Value

            Dim strarray As String() = Regex.Split(strsubmit, "sdfgyuio", RegexOptions.IgnoreCase)
            Dim i As Integer

            strSql = ""
            Dim value As String
            Dim strrow As String()
            For i = 0 To strarray.Length - 2

                If strarray(i) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl0qwerhjkl" And strarray(i) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl1qwerhjkl" Then
                    Dim advx As String = advx1
                    strrow = Regex.Split(strarray(i), "qwerhjkl", RegexOptions.IgnoreCase)




                    Dim strArrayDestport() As String
                    If ds.Tables("user").Rows(0)("Login2_Adventage_Destport_Adv").ToString <> "" Then
                        strArrayDestport = ds.Tables("user").Rows(0)("Login2_Adventage_Destport_Adv").ToString.Split("|")
                        For j As Integer = 0 To strArrayDestport.Length - 1
                            If strArrayDestport(j) = strrow(0) Then
                                advx = ds.Tables("user").Rows(0)("star_adv").ToString
                            End If
                        Next
                    End If
                    Dim strArrayshipper() As String
                    If ds.Tables("user").Rows(0)("Login2_Adventage_shipper_Adv").ToString <> "" Then
                        strArrayshipper = ds.Tables("user").Rows(0)("Login2_Adventage_shipper_Adv").ToString.Split("|")
                        For j As Integer = 0 To strArrayshipper.Length - 1
                            If strArrayshipper(j).ToUpper = strrow(8).ToUpper Then
                                advx = ds.Tables("user").Rows(0)("star_adv").ToString
                            End If
                        Next
                    End If



                    value = check.CheckNumber(Request("id")) + ",'" + check.CheckInput(strrow(0)) + "','" + check.CheckInput(strrow(1)) + "','" + check.CheckInput(strrow(2)) + "','" + check.CheckInput(strrow(3)) + "','" + check.CheckInput(strrow(4)) + "','" + check.CheckInput(strrow(5)) + "','" + check.CheckInput(strrow(6)) + "','" + check.CheckInput(strrow(7)) + "','" + check.CheckInput(strrow(8)) + "','" + check.CheckInput(strrow(9)) + "'," + check.CheckInput(strrow(10)) + ",'" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "','" + check.CheckInput(txtStart.Text.Replace("'", "''")) + "','" + Date.Now.ToString.Replace("'", "''") + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',8,'" + check.CheckInput(DropDownList1.Text.Replace("'", "''")) + "'," + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString) + "," + advx + ",'" + StartPort_en + "'"
                    strSql += "insert into TB_YunJiaInfo (YunJiaID,DestPort,price20gp,price40gp,price40hq,price45hq,price20gpAppend,Distance,DepartureWkd,shipcompany,memo,assurance,Titlex,StartPortx,PostDatex,enddatex,yunjialeixingx,hangxianmiaoshux,UserIDx,order_advx,StartPort_en) values (" + value + ");"
                End If

            Next


            strSql += "update TB_YunJia set DestPort1='" + check.CheckInput(strrow(0)) + "',price20gp1='" + check.CheckInput(strrow(1)) + "',price40gp1='" + check.CheckInput(strrow(2)) + "',price40hq1='" + check.CheckInput(strrow(3)) + "',price45hq1='" + check.CheckInput(strrow(4)) + "',shipcompany1='" + check.CheckInput(strrow(8)) + "',assurance=" + check.CheckInput(strrow(10)) + ",ifend=1 where id=" + Request("id").ToString + ";"
            strSql += "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.fclcount = (SELECT COUNT(id) AS yunjiacount FROM tb_yunjiainfo WHERE yunjialeixingx = 8),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1;"

            Dim myCommand1 As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSql, conn)
            myCommand1.ExecuteNonQuery()
            conn.Close()


            If dsStartPort.Tables("StartPort").Rows.Count > 0 Then
                Dim tp As New topnew
                tp.SetTopNew(check.CheckNumber(Request("id")), check.CheckInput(txtTitle.Text.Replace("'", "''")), Date.Now, 8, check.CheckInput(DropDownList1.Text.Replace("'", "''")), check.CheckInput(StartPort_en.Replace("'", "''")), check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString))

            End If
            












            Me.Response.Redirect("shippinglist.aspx")
        End If
        'Catch ex As Exception
        '    Me.Response.Redirect("error.aspx")
        'End Try

    End Sub


    Protected Sub GridView2_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView2.RowUpdated
        updatePostDate()
    End Sub

    Sub updatePostDate()
        Dim strSql As String

        Dim data_conn As New data_conn3
        Dim conn As New Data.SqlClient.SqlConnection
        conn = data_conn.mdb_conn()
        conn.Open()
        strSql = "update TB_YunJia set PostDate='" + Date.Now.ToString + "' where id=" + check.CheckNumber(Request("id"))
        Dim myCommand As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSql, conn)
        myCommand.ExecuteNonQuery()
        conn.Close()
        labpost.Text = Date.Now.ToString
    End Sub

End Class
