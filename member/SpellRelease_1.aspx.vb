
Partial Class member_SpellRelease1
    Inherits System.Web.UI.Page
    Dim check As New check


    Public Sub LoadScript()
        Dim ReceiverScript As String = ""
        ReceiverScript += vbCrLf + "<script type=""text/javascript"" language=""JavaScript"">"
        ReceiverScript += vbCrLf + "function Load_Table(){"
        ReceiverScript += vbCrLf + "var table1 = new Dtable(""t1"");"
        ReceiverScript += vbCrLf + "var Ttittle =[];"
        'If star_allin = 1 Then
        '    ReceiverScript += vbCrLf + "Ttittle.push({v:"""",w:20,t:""checkbox"",c:""fth""});"
        '    ReceiverScript += vbCrLf + "Ttittle.push({v:""<span class=\""redfont\"">*</span>目的港"",w:58,ac:""end_port""});"
        '    ReceiverScript += vbCrLf + "Ttittle.push({v:""价格(体积)"",w:58});"
        '    ReceiverScript += vbCrLf + "Ttittle.push({v:""价格(重量)"",w:58});"
        '    ReceiverScript += vbCrLf + "Ttittle.push({v:""附加费"",w:58});"
        '    ReceiverScript += vbCrLf + "Ttittle.push({v:""航程"",w:58});"
        '    ReceiverScript += vbCrLf + "Ttittle.push({v:""出发日"",w:58,ac:""day""});"
        '    ReceiverScript += vbCrLf + "Ttittle.push({v:""<span class=\""redfont\"">*</span>船公司"",w:58,ac:""ship_com""});"
        '    ReceiverScript += vbCrLf + "Ttittle.push({v:""备注"",w:58,t:""textarea"",c:""t_h txt""});"
        '    ReceiverScript += vbCrLf + "Ttittle.push({v:""倉位"",w:50,t:""checkbox""});"
        '    ReceiverScript += vbCrLf + "Ttittle.push({v:""Del"",w:30,t:""span"",f:""Del_row"",c:""eth""});"
        'Else
        ReceiverScript += vbCrLf + "Ttittle.push({v:"""",w:20,t:""checkbox"",c:""fth""});"
        'ReceiverScript += vbCrLf + "Ttittle.push({v:""<span class=\""redfont\"">*</span>目的港"",w:80,ac:""end_port""});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""<span class=\""redfont\"">*</span>目的港"",w:80});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""价格(体积)"",w:80});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""价格(重量)"",w:80});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""附加费"",w:80});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""航程"",w:80});"
        'ReceiverScript += vbCrLf + "Ttittle.push({v:""出发日"",w:80,ac:""day""});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""出发日"",w:80});"
        'ReceiverScript += vbCrLf + "Ttittle.push({v:""<span class=\""redfont\"">*</span>船公司"",w:80,ac:""ship_com""});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""<span class=\""redfont\"">*</span>船公司"",w:80});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""备注"",w:80,t:""textarea"",c:""t_h txt""});"
        ReceiverScript += vbCrLf + "Ttittle.push({v:""Del"",w:30,t:""span"",f:""Del_row"",c:""eth""});"
        'End If

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

        Dim ds2 As Data.DataSet
        Dim conn As New data_conn3
        Dim sql As String
        sql = "select * from TB_User where UserID=" + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
        ds2 = conn.mdb_ds(sql, "table")


        LoadScript()


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
                
                Literal1.Text = "<a href='SpellRelease_old.aspx'>切换到旧版</a>"



                Dim dt As DateTime = DateTime.Now
                Dim startMonth As DateTime = dt.AddDays(1 - dt.Day)
                Dim endMonth As DateTime = startMonth.AddMonths(1).AddDays(-1)


                '15日以前的，如果离15日在5天之内，结束日期为月底，否则结束日期为15日
                '15日以后的，如果离月底在5天之内，结束日期为下月15日，否则结束日期为本月月底
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

            Dim strrow As String()
            strrow = Regex.Split(strsubmitrow(k), "", RegexOptions.IgnoreCase)
            If strrow(6) = "" Then
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

            '======================================
            Dim adv As String = "0"
            Dim advx1 As String = "0"


            Dim ds As Data.DataSet = cn.mdb_ds("select * from TB_User where UserID=" + Request.Cookies("user_id").Value, "user")
            Dim strArrayLine() As String
            If ds.Tables("user").Rows(0)("Login3_Adventage_Line_Adv").ToString <> "" Then
                strArrayLine = ds.Tables("user").Rows(0)("Login3_Adventage_Line_Adv").ToString.Split("|")
                For j As Integer = 0 To strArrayLine.Length - 1
                    If strArrayLine(j) = DropDownList1.Text Then
                        adv = ds.Tables("user").Rows(0)("star_adv").ToString
                        advx1 = ds.Tables("user").Rows(0)("star_adv").ToString
                    End If
                Next
            End If

            Dim strArrayStartport() As String
            If ds.Tables("user").Rows(0)("Login3_Adventage_Startport_Adv").ToString <> "" Then
                strArrayStartport = ds.Tables("user").Rows(0)("Login3_Adventage_Startport_Adv").ToString.Split("|")
                For j As Integer = 0 To strArrayStartport.Length - 1
                    If strArrayStartport(j) = txtStart.Text Then
                        adv = ds.Tables("user").Rows(0)("star_adv").ToString
                        advx1 = ds.Tables("user").Rows(0)("star_adv").ToString
                    End If
                Next
            End If
            '======================================

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

                Dim advx As String = advx1

                strrow = Regex.Split(strarray(i), "", RegexOptions.IgnoreCase)


                If (strrow(1) = "" And strrow(2) <> "") Then
                    strrow(1) = strrow(2)
                End If
                If (strrow(2) = "" And strrow(1) <> "") Then
                    strrow(2) = strrow(1)
                End If
                value = check.CheckNumber(id.ToString) + ",'" + check.CheckInput(strrow(0)) + "','" + check.CheckInput(strrow(1)) + "','" + check.CheckInput(strrow(2)) + "','" + check.CheckInput(strrow(3)) + "','" + check.CheckInput(strrow(4)) + "','" + check.CheckInput(strrow(5)) + "','" + check.CheckInput(strrow(6)) + "','" + check.CheckInput(strrow(7)) + "','" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "','" + check.CheckInput(txtStart.Text) + "','" + Date.Now.ToString + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value) + "',9,'" + check.CheckInput(DropDownList1.Text) + "'," + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString) + "," + advx + ",'" + StartPort_en + "'"

                strSQL += "insert into TB_YunJiaInfo (YunJiaID,DestPort,pricegpv,pricegp,price20gpAppend,Distance,DepartureWkd,shipcompany,memo,Titlex,StartPortx,PostDatex,enddatex,yunjialeixingx,hangxianmiaoshux,UserIDx,order_advx,StartPort_en) values (" + value + ");"





            Next


            strSQL += "update TB_YunJia set order_adv=" + adv + ",DestPort1='" + check.CheckInput(strrow(0)) + "',pricegpv1='" + check.CheckInput(strrow(1)) + "',pricegp1='" + check.CheckInput(strrow(2)) + "',shipcompany1='" + check.CheckInput(strrow(6)) + "' where id=" + id.ToString + ";"
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

            ds = cn.mdb_ds("select * from TB_User where UserID=" + Request.Cookies("user_id").Value, "user")

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
