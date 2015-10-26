Imports System.Data

Partial Class member_jilu
    Inherits System.Web.UI.Page
    Dim check As New check


    Public Sub LoadScript(ByVal star_allin As String)
        Dim ReceiverScript As String = ""
        ReceiverScript += vbCrLf + "<script type=""text/javascript"" language=""JavaScript"">"
        ReceiverScript += vbCrLf + "function Load_Table(){"
        ReceiverScript += vbCrLf + "var table1 = new Dtable(""t1"");"
        ReceiverScript += vbCrLf + "var Ttittle =[];"
        If star_allin = 1 Then
            ReceiverScript += vbCrLf + "Ttittle.push({v:"""",w:20,t:""checkbox"",c:""fth""});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""<span class=\""redfont\"">*</span>目的港"",w:58});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""20GP"",w:58});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""40GP"",w:58});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""40HQ"",w:58});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""45HQ"",w:58});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""附加费"",w:58});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""航程"",w:58});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""出发日"",w:58});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""<span class=\""redfont\"">*</span>船公司"",w:58});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""备注"",w:58,t:""textarea"",c:""t_h txt""});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""倉位"",w:50,t:""checkbox""});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""Del"",w:30,t:""span"",f:""Del_row"",c:""eth""});"
        Else
            ReceiverScript += vbCrLf + "Ttittle.push({v:"""",w:20,t:""checkbox"",c:""fth""});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""<span class=\""redfont\"">*</span>目的港"",w:63});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""20GP"",w:63});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""40GP"",w:63});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""40HQ"",w:63});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""45HQ"",w:63});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""附加费"",w:63});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""航程"",w:63});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""出发日"",w:63});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""<span class=\""redfont\"">*</span>船公司"",w:63});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""备注"",w:63,t:""textarea"",c:""t_h txt""});"
            ReceiverScript += vbCrLf + "Ttittle.push({v:""Del"",w:30,t:""span"",f:""Del_row"",c:""eth""});"
        End If

        ReceiverScript += vbCrLf + "table1.TittleArray = Ttittle;"
        ReceiverScript += vbCrLf + "table1.Rows =15;//初始化行數"
        ReceiverScript += vbCrLf + "table1.DrawTable();"
        ReceiverScript += vbCrLf + "table1.init();"
        ReceiverScript += vbCrLf + "table1.fill_table(""textbox"",""txthidden"");"
        'ReceiverScript += vbCrLf + "document.getElementById(""addtr"").onclick =function(){"
        'ReceiverScript += vbCrLf + "var sum=document.getElementById(""trsum"").value;"
        'ReceiverScript += vbCrLf + "table1.addTr(sum)};"

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

            Literal1.Text = "<a href='jilu_old.aspx?id=" + a + "'>切换到旧版</a>"

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


            If aaa.Day - DateTime.Now.Day > 5 Then
                BasicDatePicker1_TextBox.Value = ds.Tables(0).Rows(0)("enddate").ToString.Split(" ")(0)
            Else
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





            '判断是否为manager用户，是的话，显示选择用户按钮
            Dim ds3 As DataSet
            sql = "select * from TB_User where UserID=" + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
            ds3 = conn.mdb_ds(sql, "table")

            If ds3.Tables("table").Rows(0)("ifmanage") = 1 Then
                'tt.InnerHtml = "<input type=""button"" name=""Submit"" value=""选择用户"" onClick=""javascript:window.open('user_search1.asp','_blank','scrollbars=yes,width=420,height=600')"" id=""Button2"" / >"
                'Me.Hidden1.Visible = True
            End If



            Dim dsyunjia As DataSet = conn.mdb_ds("select * from TB_YunJiaInfo where YunJiaID=" + a + " order by DestPort", "yunjia")
            Dim TempTable As String = ""
            For i As Integer = 0 To dsyunjia.Tables("yunjia").Rows.Count - 1
                If i <> 0 Then
                    TempTable += ""
                End If
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("DestPort").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("price20gp").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("price40gp").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("price40hq").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("price45hq").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("price20gpAppend").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("Distance").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("DepartureWkd").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("shipcompany").ToString() + ""




                If ds3.Tables("table").Rows(0)("star_allin").ToString = 0 Then
                    TempTable += dsyunjia.Tables("yunjia").Rows(i)("memo").ToString()
                Else
                    TempTable += dsyunjia.Tables("yunjia").Rows(i)("memo").ToString() + ""
                    TempTable += dsyunjia.Tables("yunjia").Rows(i)("assurance").ToString()
                End If

            Next

            txthidden.Value = TempTable
            LoadScript(ds3.Tables("table").Rows(0)("star_allin").ToString)

        Else
            Dim ds3 As DataSet
            Dim conn As New data_conn3
            ds3 = conn.mdb_ds("select * from TB_User where UserID=" + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString), "table")
            LoadScript(ds3.Tables("table").Rows(0)("star_allin").ToString)
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
        If txthidden.Value = "" Then


            Dim cn As New data_conn
            cn.mdb_exe("insert into A (A) values ('空')")
            MessageBox("", "目的港不能为0个")
            Return
        End If

        If txthidden.Value.Replace("", "").Replace("", "").Replace("0", "").Replace("1", "") = "" Then
            Dim cn As New data_conn
            cn.mdb_exe("insert into A (A) values ('部分空')")
            MessageBox("", "目的港不能为0个")
            Return
        End If


        Dim strsubmitrow As String() = Regex.Split(txthidden.Value, "", RegexOptions.IgnoreCase)
        For k As Integer = 0 To strsubmitrow.Length - 1
            If strsubmitrow(k).Substring(0, 1) = "" Then
                MessageBox("", "第" + (k + 1).ToString + "行的目的港不能为空")
                Return
            End If

            Dim strrow As String()
            strrow = Regex.Split(strsubmitrow(k), "", RegexOptions.IgnoreCase)
            If strrow(8) = "" Then
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

            Dim strArrayStartport() As String
            If ds.Tables("user").Rows(0)("Login2_Adventage_Startport_Adv").ToString <> "" Then
                strArrayStartport = ds.Tables("user").Rows(0)("Login2_Adventage_Startport_Adv").ToString.Split("|")
                For j As Integer = 0 To strArrayStartport.Length - 1
                    If strArrayStartport(j) = txtStart.Text Then
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

            Dim strsubmit As String = Me.txthidden.Value

            Dim strarray As String() = Regex.Split(strsubmit, "", RegexOptions.IgnoreCase)
            Dim i As Integer

            strSql = ""
            Dim value As String
            Dim strrow As String()
            For i = 0 To strarray.Length - 1


                Dim advx As String = advx1
                strrow = Regex.Split(strarray(i), "", RegexOptions.IgnoreCase)




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

                If ds.Tables("user").Rows(0)("star_allin").ToString = 0 Then

                    value = check.CheckNumber(Request("id").ToString) + ",'" + check.CheckInput(strrow(0)) + "','" + check.CheckInput(strrow(1)) + "','" + check.CheckInput(strrow(2)) + "','" + check.CheckInput(strrow(3)) + "','" + check.CheckInput(strrow(4)) + "','" + check.CheckInput(strrow(5)) + "','" + check.CheckInput(strrow(6)) + "','" + check.CheckInput(strrow(7)) + "','" + check.CheckInput(strrow(8)) + "','" + check.CheckInput(strrow(9)) + "',0,'" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "','" + check.CheckInput(txtStart.Text.Replace("'", "''")) + "','" + Date.Now.ToString.Replace("'", "''") + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',8,'" + check.CheckInput(DropDownList1.Text.Replace("'", "''")) + "'," + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString) + "," + advx + ",'" + StartPort_en + "'"
                    strSql += "insert into TB_YunJiaInfo (YunJiaID,DestPort,price20gp,price40gp,price40hq,price45hq,price20gpAppend,Distance,DepartureWkd,shipcompany,memo,assurance,Titlex,StartPortx,PostDatex,enddatex,yunjialeixingx,hangxianmiaoshux,UserIDx,order_advx,StartPort_en) values (" + value + ");"

                Else
                    value = check.CheckNumber(Request("id")) + ",'" + check.CheckInput(strrow(0)) + "','" + check.CheckInput(strrow(1)) + "','" + check.CheckInput(strrow(2)) + "','" + check.CheckInput(strrow(3)) + "','" + check.CheckInput(strrow(4)) + "','" + check.CheckInput(strrow(5)) + "','" + check.CheckInput(strrow(6)) + "','" + check.CheckInput(strrow(7)) + "','" + check.CheckInput(strrow(8)) + "','" + check.CheckInput(strrow(9)) + "'," + check.CheckInput(strrow(10)) + ",'" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "','" + check.CheckInput(txtStart.Text.Replace("'", "''")) + "','" + Date.Now.ToString.Replace("'", "''") + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',8,'" + check.CheckInput(DropDownList1.Text.Replace("'", "''")) + "'," + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString) + "," + advx + ",'" + StartPort_en + "'"
                    strSql += "insert into TB_YunJiaInfo (YunJiaID,DestPort,price20gp,price40gp,price40hq,price45hq,price20gpAppend,Distance,DepartureWkd,shipcompany,memo,assurance,Titlex,StartPortx,PostDatex,enddatex,yunjialeixingx,hangxianmiaoshux,UserIDx,order_advx,StartPort_en) values (" + value + ");"

                End If


            Next

            If ds.Tables("user").Rows(0)("star_allin").ToString = 0 Then
                strSql += "update TB_YunJia set DestPort1='" + check.CheckInput(strrow(0)) + "',price20gp1='" + check.CheckInput(strrow(1)) + "',price40gp1='" + check.CheckInput(strrow(2)) + "',price40hq1='" + check.CheckInput(strrow(3)) + "',price45hq1='" + check.CheckInput(strrow(4)) + "',shipcompany1='" + check.CheckInput(strrow(8)) + "',assurance=0,ifend=1 where id=" + Request("id").ToString + ";"
            Else
                strSql += "update TB_YunJia set DestPort1='" + check.CheckInput(strrow(0)) + "',price20gp1='" + check.CheckInput(strrow(1)) + "',price40gp1='" + check.CheckInput(strrow(2)) + "',price40hq1='" + check.CheckInput(strrow(3)) + "',price45hq1='" + check.CheckInput(strrow(4)) + "',shipcompany1='" + check.CheckInput(strrow(8)) + "',assurance=" + check.CheckInput(strrow(10)) + ",ifend=1 where id=" + Request("id").ToString + ";"
            End If


            strSql += "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.fclcount = (SELECT COUNT(id) AS yunjiacount FROM tb_yunjiainfo WHERE yunjialeixingx = 8),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1;"


            Response.Write(strSql)
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





End Class
