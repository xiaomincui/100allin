Imports System.Data

Partial Class admin_airjilu
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
        'Try


        Page.Title = "环球运费网 - 我的办公室 - 空运运价"




        Dim a As String
        a = check.CheckNumber(Request("id"))
        Dim ds As Data.DataSet
        ds = trun(a)


        '====================================================
        If Not Page.IsPostBack Then

            'Literal1.Text = "<a href='airjilu_old.aspx?id=" + a + "'>切换到旧版</a>"

            




            txtTitle.Text = HttpContext.Current.Server.HtmlDecode(ds.Tables(0).Rows(0)("title").ToString)
            labpost.Text = ds.Tables(0).Rows(0)("PostDate").ToString.ToString.Split(" ")(0)


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

            DropDownList1.SelectedItem.Text = ds.Tables(0).Rows(0)("LINE").ToString

            Dim memo As String = ds.Tables(0).Rows(0)("memo").ToString
            memo = memo.Replace("<br>", Chr(10))
            memo = memo.Replace("&nbsp", " ")
            txtRemark.Text = HttpContext.Current.Server.HtmlDecode(memo)
            'Me.Hidden1.Value = ds.Tables(0).Rows(0)("UserID2").ToString




            Dim conn As New data_conn3
            Dim sql As String






            '判断是否为manager用户，是的话，显示选择用户按钮
            Dim ds3 As DataSet
            sql = "select * from TB_User where UserID=" + ds.Tables(0).Rows(0)("UserID").ToString
            ds3 = conn.mdb_ds(sql, "table")

            If ds3.Tables("table").Rows(0)("ifmanage") = 1 Then
                'tt.InnerHtml = "<input type=""button"" name=""Submit"" value=""选择用户"" onClick=""javascript:window.open('user_search1.asp','_blank','scrollbars=yes,width=420,height=600')"" id=""Button2"" / >"
                'Me.Hidden1.Visible = True

            End If


            Dim dsyunjia As DataSet = conn.mdb_ds("select * from T_AIRPRICE where AIRID=" + a + " order by DestPort", "yunjia")
            Dim TempTable As String = ""
            For i As Integer = 0 To dsyunjia.Tables("yunjia").Rows.Count - 1
                If i <> 0 Then
                    TempTable += ""
                End If
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("DestPort").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("PRICE_M").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("PRICE_N").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("PRICE_P45").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("PRICE_P100").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("PRICE_P300").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("PRICE_P500").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("PRICE_P1000").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("price20gpAppend").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("Distance").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("DepartureWkd").ToString() + ""
                TempTable += dsyunjia.Tables("yunjia").Rows(i)("memo").ToString()

            Next

            txthidden.Value = TempTable
            LoadScript()


        Else
            LoadScript()
        End If

        'Catch ex As Exception
        'Me.Response.Redirect("error.aspx")
        'End Try
    End Sub


    Function trun(ByVal id As String) As Data.DataSet
        Dim ds As Data.DataSet
        Dim strSQL As String
        strSQL = "select * from T_AIRINFO where id=" + check.CheckNumber(id)
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
        Dim dsuser1 As Data.DataSet
        dsuser1 = trun(check.CheckNumber(Request("id")))

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



        If txtTitle.Text = "" Then
            MessageBox("", "标题不能为空")
        ElseIf BasicDatePicker1_TextBox.Value = "" Then
            MessageBox("", "有效日期不能为空")
        ElseIf txtStart.Text = "" Then
            MessageBox("", "启运港不能为空")
        ElseIf DropDownList1.Text = "请选择" Then
            MessageBox("", "请选择航线")
        Else



            '=====================================================
            '统计用户发布运价的小记录条数

            Dim dsUser As Data.DataSet = cn.mdb_ds("select * from TB_User where UserID=" + dsuser1.Tables(0).Rows(0)("UserID").ToString, "User")
            If dsUser.Tables("User").Rows(0)("CompanyName").ToString().IndexOf("多运多") <> -1 Then
                '=====================================================
                '统计用户发布运价的小记录条数
                Dim dsYunjiaInfo As Data.DataSet = cn.mdb_ds("select * from T_AIRPRICE where UserIDx=" + check.CheckNumber(dsuser1.Tables(0).Rows(0)("UserID").ToString) + " and PostDatex>='" + DateTime.Now.Date.ToString() + "' and PostDatex<'" + DateTime.Now.Date.AddDays(1).ToString() + "'", "AIRPRICE")
                Dim strtemparray As String() = Regex.Split(Me.txthidden.Value, "", RegexOptions.IgnoreCase)
                Dim intTemp As Integer = 0
                For j As Integer = 0 To strtemparray.Length - 1

                    intTemp = intTemp + 1

                Next
                '=====================================================
                If dsYunjiaInfo.Tables("AIRPRICE").Rows.Count + intTemp > 50 Then
                    MessageBox("", "您好，每天发布运价不能超过50条")
                    Return
                End If
            End If





            '=====================================================



            Dim strSql As String
            Dim meno As String = check.CheckInput(txtRemark.Text)
            meno = meno.Replace(Chr(10), "<br>")
            meno = meno.Replace(" ", "&nbsp")

            Dim data_conn As New data_conn3
            Dim conn As New Data.SqlClient.SqlConnection
            conn = data_conn.mdb_conn()
            conn.Open()
            strSql = "update T_AIRINFO set title='" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "',enddate='" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',StartPort='" + check.CheckInput(txtStart.Text.Replace("'", "''")) + "',LINE='" + check.CheckInput(DropDownList1.Text.Replace("'", "''")) + "',memo='" + check.CheckInput(meno.Replace("'", "''")) + "',PostDate='" + Date.Now.ToString.Replace("'", "''") + "',updateTimes=updateTimes+1,StartPort_en='" + StartPort_en + "' where id=" + check.CheckNumber(Request("id"))
            Dim myCommand As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSql, conn)
            myCommand.ExecuteNonQuery()



            labpost.Text = Date.Now.ToString
            myCommand.CommandText = "delete from T_AIRPRICE where AIRID=" + check.CheckNumber(Request("id"))
            myCommand.ExecuteNonQuery()

            Dim strsubmit As String = Me.txthidden.Value

            Dim strarray As String() = Regex.Split(strsubmit, "", RegexOptions.IgnoreCase)
            Dim i As Integer


            Dim value As String
            strSql = ""
            Dim strrow As String()
            For i = 0 To strarray.Length - 1



                strrow = Regex.Split(strarray(i), "", RegexOptions.IgnoreCase)

                If strrow(3) = "" And strrow(4) = "" And strrow(5) = "" And strrow(6) = "" And strrow(7) = "" Then
                    strrow(5) = "电询"
                End If

                value = check.CheckNumber(Request("id")) + ",'" + check.CheckInput(strrow(0)) + "','" + check.CheckInput(strrow(1)) + "','" + check.CheckInput(strrow(2)) + "','" + check.CheckInput(strrow(3)) + "','" + check.CheckInput(strrow(4)) + "','" + check.CheckInput(strrow(5)) + "','" + check.CheckInput(strrow(6)) + "','" + check.CheckInput(strrow(7)) + "','" + check.CheckInput(strrow(8)) + "','" + check.CheckInput(strrow(9)) + "','" + check.CheckInput(strrow(10)) + "','" + check.CheckInput(strrow(11)) + "',0,'" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "','" + Date.Now.ToString.Replace("'", "''") + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "','" + check.CheckInput(DropDownList1.Text.Replace("'", "''")) + "'," + check.CheckNumber(dsuser1.Tables(0).Rows(0)("UserID").ToString) + ",'" + StartPort_en + "'"

                strSql += "insert into T_AIRPRICE (AIRID,DestPort,PRICE_M,PRICE_N,PRICE_P45,PRICE_P100,PRICE_P300,PRICE_P500,PRICE_P1000,price20gpAppend,Distance,departurewkd,memo,assurance,Titlex,PostDatex,enddatex,LINEx,UserIDx,StartPort_en) values (" + value + ");"


            Next

            strSql += "update T_AIRINFO set DestPort1='" + check.CheckInput(strrow(0)) + "',PRICE_P451='" + check.CheckInput(strrow(3)) + "',PRICE_P1001='" + check.CheckInput(strrow(4)) + "',PRICE_P3001='" + check.CheckInput(strrow(5)) + "',PRICE_P5001='" + check.CheckInput(strrow(6)) + "',PRICE_P10001='" + check.CheckInput(strrow(7)) + "',assurance=0 where id=" + check.CheckNumber(Request("id")) + ";"
            strSql += "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.aircount = (SELECT COUNT(t_airinfo.id) AS yunjiacount FROM t_airinfo,t_airprice WHERE t_airinfo.id = t_airprice.airid),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1"
            Dim myCommand1 As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSql, conn)

            myCommand1.ExecuteNonQuery()
            conn.Close()
            If dsStartPort.Tables("StartPort").Rows.Count > 0 Then
                Dim tp As New topnew
                tp.SetTopNew(check.CheckNumber(Request("id")), check.CheckInput(txtTitle.Text.Replace("'", "''")), Date.Now, 10, check.CheckInput(DropDownList1.Text.Replace("'", "''")), check.CheckInput(StartPort_en.Replace("'", "''")), check.CheckNumber(dsuser1.Tables(0).Rows(0)("UserID").ToString))
            End If


            Me.Response.Redirect("airlist.aspx")
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
        strSql = "update T_AIRINFO set PostDate='" + Date.Now.ToString + "' where id=" + check.CheckNumber(Request("id"))
        Dim myCommand As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSql, conn)
        myCommand.ExecuteNonQuery()
        conn.Close()
        labpost.Text = Date.Now.ToString.Split(" ")(0)
    End Sub

End Class
