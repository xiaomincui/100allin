Imports System.Data

Partial Class admin_Spelljilu
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
        Try


            Page.Title = "环球运费网 - 我的办公室 - 拼箱运价"


            Dim a As String
            a = check.CheckNumber(Request("id"))
            Dim ds As Data.DataSet
            ds = trun(a)


            'HyperLink2.NavigateUrl = "~/member/Spelljilu.aspx?id=" + a

            'Dim strSQL As String
            'strSQL = "select * from TB_YunJiaInfo where YunJiaID=" + a
            'Me.Response.Write(strSQL)
            'SqlDataSource1.SelectCommand = strSQL

            'Me.GridView1.DataSourceID = "SqlDataSource1"
            '====================================================
            If Not Page.IsPostBack Then
                'Literal1.Text = "<a href='Spelljilu_old.aspx?id=" + a + "'>切换到旧版</a>"

                



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




                Dim dsyunjia As DataSet = conn.mdb_ds("select * from TB_YunJiaInfo where YunJiaID=" + a + " order by DestPort", "yunjia")
                Dim TempTable As String = ""
                For i As Integer = 0 To dsyunjia.Tables("yunjia").Rows.Count - 1
                    If i <> 0 Then
                        TempTable += ""
                    End If
                    TempTable += dsyunjia.Tables("yunjia").Rows(i)("DestPort").ToString() + ""
                    TempTable += dsyunjia.Tables("yunjia").Rows(i)("pricegp").ToString() + ""
                    TempTable += dsyunjia.Tables("yunjia").Rows(i)("pricegpv").ToString() + ""
                    TempTable += dsyunjia.Tables("yunjia").Rows(i)("price20gpAppend").ToString() + ""
                    TempTable += dsyunjia.Tables("yunjia").Rows(i)("Distance").ToString() + ""
                    TempTable += dsyunjia.Tables("yunjia").Rows(i)("DepartureWkd").ToString() + ""
                    TempTable += dsyunjia.Tables("yunjia").Rows(i)("shipcompany").ToString() + ""
                    TempTable += dsyunjia.Tables("yunjia").Rows(i)("memo").ToString()


                Next

                txthidden.Value = TempTable
                LoadScript()

            Else

                Dim ds3 As DataSet
                LoadScript()
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

        Dim dsuser As Data.DataSet
        dsuser = trun(check.CheckNumber(Request("id")))

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

            Dim strsubmit As String = Me.txthidden.Value

            Dim strarray As String() = Regex.Split(strsubmit, "", RegexOptions.IgnoreCase)
            Dim i As Integer

            strSql = ""
            Dim value As String
            Dim strrow As String()
            For i = 0 To strarray.Length - 1



                strrow = Regex.Split(strarray(i), "", RegexOptions.IgnoreCase)

                If (strrow(1) = "" And strrow(2) <> "") Then
                    strrow(1) = strrow(2)
                End If
                If (strrow(2) = "" And strrow(1) <> "") Then
                    strrow(2) = strrow(1)
                End If

                value = check.CheckNumber(Request("id")) + ",'" + check.CheckInput(strrow(0)) + "','" + check.CheckInput(strrow(1)) + "','" + check.CheckInput(strrow(2)) + "','" + check.CheckInput(strrow(3)) + "','" + check.CheckInput(strrow(4)) + "','" + check.CheckInput(strrow(5)) + "','" + check.CheckInput(strrow(6)) + "','" + check.CheckInput(strrow(7)) + "',0,'" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "','" + check.CheckInput(txtStart.Text) + "','" + Date.Now.ToString + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',9,'" + check.CheckInput(DropDownList1.Text) + "'," + check.CheckNumber(dsuser.Tables(0).Rows(0)("UserID").ToString) + ",'" + StartPort_en + "'"

                strSql += "insert into TB_YunJiaInfo (YunJiaID,DestPort,pricegpv,pricegp,price20gpAppend,Distance,DepartureWkd,shipcompany,memo,assurance,Titlex,StartPortx,PostDatex,enddatex,yunjialeixingx,hangxianmiaoshux,UserIDx,StartPort_en) values (" + value + ");"

                '",'" + check.CheckInput(txtTitle.Text.Replace("'", "''")) + "','" +Date.Now.ToString + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value.Replace("'", "''")) + "',9,'" + check.CheckInput(DropDownList1.Text) + "'"



            Next

            strSql += "update TB_YunJia set DestPort1='" + check.CheckInput(strrow(0)) + "',pricegpv1='" + check.CheckInput(strrow(1)) + "',pricegp1='" + check.CheckInput(strrow(2)) + "',shipcompany1='" + check.CheckInput(strrow(6)) + "',assurance=0,ifend=1 where id=" + check.CheckNumber(Request("id")) + ";"
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
                tp.SetTopNew(check.CheckNumber(Request("id")), check.CheckInput(txtTitle.Text.Replace("'", "''")), Date.Now, 9, check.CheckInput(DropDownList1.Text.Replace("'", "''")), check.CheckInput(StartPort_en.Replace("'", "''")), check.CheckNumber(dsuser.Tables(0).Rows(0)("UserID").ToString))

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
