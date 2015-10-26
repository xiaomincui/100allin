Imports System.Data

Partial Class member_Spelljilu
    Inherits System.Web.UI.Page
    Dim check As New check




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
            Dim a As String
            a = check.CheckNumber(Request("id"))
            'HyperLink2.NavigateUrl = "~/member/Spelljilu.aspx?id=" + a

            'Dim strSQL As String
            'strSQL = "select * from TB_YunJiaInfo where YunJiaID=" + a
            'Me.Response.Write(strSQL)
            'SqlDataSource1.SelectCommand = strSQL

            'Me.GridView1.DataSourceID = "SqlDataSource1"
            '====================================================
            If Not Page.IsPostBack Then
                Literal1.Text = "<a href='Spelljilu.aspx?id=" + a + "'>切换到新版</a>"
                Dim ds As Data.DataSet
                ds = trun(a)
                Try
                    If ds.Tables(0).Rows(0)("UserID2").ToString <> Request.Cookies("user_id").Value.ToString And ds.Tables(0).Rows(0)("UserID").ToString <> Request.Cookies("user_id").Value.ToString Then
                        Response.Redirect("../search/err.aspx")
                    End If
                Catch ex As Exception
                    Response.Redirect("../search/err.aspx")
                End Try


                txtTitle.Text = HttpContext.Current.Server.HtmlDecode(ds.Tables(0).Rows(0)("title").ToString)
                labpost.Text = ds.Tables(0).Rows(0)("PostDate").ToString.Split(" ")(0)
                'BasicDatePicker1_TextBox.Value = ds.Tables(0).Rows(0)("enddate").ToString.ToString.Split(" ")(0)
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
                DropDownList1.Text = ds.Tables(0).Rows(0)("hangxianmiaoshu").ToString

                Dim memo As String = ds.Tables(0).Rows(0)("memo").ToString
                memo = memo.Replace("<br>", Chr(10))
                memo = memo.Replace("&nbsp", " ")

                txtRemark.Text = HttpContext.Current.Server.HtmlDecode(memo)
                'Me.Hidden1.Value = ds.Tables(0).Rows(0)("UserID2").ToString




                Dim ds2 As DataSet
                Dim conn As New data_conn3
                Dim sql As String

                If ds.Tables(0).Rows(0)("UserID2").ToString = "0" Then
                    sql = "select * from TB_User where UserID=" + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
                Else
                    sql = "select * from TB_User where UserID=" + check.CheckNumber(ds.Tables(0).Rows(0)("UserID2").ToString)
                    '判断是否为manager用户
                    If ds.Tables(0).Rows(0)("UserID").ToString = Me.Request.Cookies("user_id").Value.ToString Then
                        'tt.InnerHtml = "<input type=""button"" name=""Submit"" value=""选择用户"" onClick=""javascript:window.open('user_search1.asp','_blank','scrollbars=yes,width=420,height=600')"" id=""Button2"" / >"
                        'Me.Hidden1.Visible = True

                    End If
                End If

                ds2 = conn.mdb_ds(sql, "table")
                'txtname.Text = ds2.Tables("table").Rows(0)("RealName")
                'txtCompanyName.Text = ds2.Tables("table").Rows(0)("CompanyName")
                'txtAddress.Text = ds2.Tables("table").Rows(0)("Address")
                'txtFax.Text = ds2.Tables("table").Rows(0)("Fax").ToString
                'txtMovePhone.Text = ds2.Tables("table").Rows(0)("MovePhone")
                'txtPhone.Text = ds2.Tables("table").Rows(0)("Phone")
                'txtPostNumber.Text = ds2.Tables("table").Rows(0)("PostNumber").ToString
                'txtUserEmail.Text = ds2.Tables("table").Rows(0)("UserEmail")


                If ds2.Tables("table").Rows(0)("star_allin") = 0 Then
                    LitRow1.Text = "<input id='Button5' type='button' value='添加1行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),1,1)"" />"
                    LitRow5.Text = "<input id='Button2' type='button' value='添加5行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),5,1)"" />"
                    LitRow10.Text = "<input id='Button3' type='button' value='添加10行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),10,1)"" />"
                    'LitRow50.Text = "<input id='Button4' type='button' value='添加50行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),50,1)"" />"

                    GridView2.Columns(8).ItemStyle.CssClass = "displayrow"
                    GridView2.Columns(8).HeaderStyle.CssClass = "displayrow"
                End If

                '判断是否为manager用户，是的话，显示选择用户按钮
                Dim ds3 As DataSet
                sql = "select * from TB_User where UserID=" + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
                ds3 = conn.mdb_ds(sql, "table")

                If ds3.Tables("table").Rows(0)("ifmanage") = 1 Then
                    'tt.InnerHtml = "<input type=""button"" name=""Submit"" value=""选择用户"" onClick=""javascript:window.open('user_search1.asp','_blank','scrollbars=yes,width=420,height=600')"" id=""Button2"" / >"
                    'Me.Hidden1.Visible = True

                End If


                Dim dsyunjia As DataSet = conn.mdb_ds("select * from TB_YunJiaInfo where YunJiaID=" + a, "yunjia")
                Dim row As Data.DataRow = dsyunjia.Tables("yunjia").NewRow

                row("DestPort") = ""
                row("pricegpv") = ""
                row("pricegp") = ""
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


        Catch ex As Exception
            Me.Response.Redirect("error.aspx")
        End Try
    End Sub

    Function trun(ByVal id As String) As Data.DataSet
        Dim ds As Data.DataSet
        Dim strSQL As String
        strSQL = "select * from TB_YunJia where id=" + check.CheckNumber(id)
        Dim tt As New data_conn3
        ds = tt.mdb_ds(strSQL, "asdf")
        Return ds
    End Function



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


            strSql = "update TB_YunJia set title='" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "',enddate='" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',StartPort='" + check.CheckInput(txtStart.Text) + "',hangxianmiaoshu='" + check.CheckInput(DropDownList1.Text) + "',memo='" + check.CheckInput(meno.Replace("'", "''")) + "',PostDate='" + Date.Now.ToString.Replace("'", "''") + "',updateTimes=updateTimes+1,StartPort_en='" + StartPort_en + "' where id=" + check.CheckNumber(Request("id"))
            Dim myCommand As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSql, conn)
            myCommand.ExecuteNonQuery()
            labpost.Text = Date.Now.ToString
            myCommand.CommandText = "delete from TB_YunJiaInfo where YunJiaID=" + check.CheckNumber(Request("id"))
            myCommand.ExecuteNonQuery()

            Dim strsubmit As String = Me.hidsubmit.Value

            Dim strarray As String() = Regex.Split(strsubmit, "sdfgyuio", RegexOptions.IgnoreCase)
            Dim i As Integer

            strSql = ""
            Dim value As String
            Dim strrow As String()
            For i = 0 To strarray.Length - 2
                If strarray(i) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl0qwerhjkl" And strarray(i) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl1qwerhjkl" Then


                    strrow = Regex.Split(strarray(i), "qwerhjkl", RegexOptions.IgnoreCase)
                    value = check.CheckNumber(Request("id")) + ",'" + check.CheckInput(strrow(0)) + "','" + check.CheckInput(strrow(1)) + "','" + check.CheckInput(strrow(2)) + "','" + check.CheckInput(strrow(3)) + "','" + check.CheckInput(strrow(4)) + "','" + check.CheckInput(strrow(5)) + "','" + check.CheckInput(strrow(6)) + "','" + check.CheckInput(strrow(7)) + "'," + check.CheckInput(strrow(8)) + ",'" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "','" + check.CheckInput(txtStart.Text) + "','" + Date.Now.ToString + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',9,'" + check.CheckInput(DropDownList1.Text) + "'," + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString) + ",'" + StartPort_en + "'"

                    strSql += "insert into TB_YunJiaInfo (YunJiaID,DestPort,pricegpv,pricegp,price20gpAppend,Distance,DepartureWkd,shipcompany,memo,assurance,Titlex,StartPortx,PostDatex,enddatex,yunjialeixingx,hangxianmiaoshux,UserIDx,StartPort_en) values (" + value + ");"

                    '",'" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "','" +Date.Now.ToString + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',9,'" + check.CheckInput(DropDownList1.Text) + "'"
                End If


            Next

            strSql += "update TB_YunJia set DestPort1='" + check.CheckInput(strrow(0)) + "',pricegpv1='" + check.CheckInput(strrow(1)) + "',pricegp1='" + check.CheckInput(strrow(2)) + "',shipcompany1='" + check.CheckInput(strrow(6)) + "',assurance=" + check.CheckInput(strrow(8)) + ",ifend=1 where id=" + check.CheckNumber(Request("id")) + ";"
            strSql += "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.lclcount = (SELECT COUNT(id) AS yunjiacount FROM tb_yunjiainfo WHERE yunjialeixingx = 9),TB_PRICECOUNT.countdate = getdate() where (TB_PRICECOUNT.cid = 1);"

            Dim myCommand1 As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSql, conn)
            Try
                myCommand1.ExecuteNonQuery()
            Catch ex As Exception
                Me.Response.Write(strSql)
            End Try

            conn.Close()
            If dsStartPort.Tables("StartPort").Rows.Count > 0 Then
                Dim tp As New topnew
                tp.SetTopNew(check.CheckNumber(Request("id")), check.CheckInput(txtTitle.Text.Replace("'", "''")), Date.Now, 9, check.CheckInput(DropDownList1.Text.Replace("'", "''")), check.CheckInput(StartPort_en.Replace("'", "''")), check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString))

            End If
            
            Me.Response.Redirect("lcllist.aspx")
        End If
        'Catch ex As Exception
        '    Me.Response.Redirect("error.aspx")
        'End Try
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
        labpost.Text = Date.Now.ToString.ToString.Split(" ")(0)
    End Sub
End Class
