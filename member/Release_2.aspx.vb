
Partial Class member_Release_1
    Inherits System.Web.UI.Page
    Dim check As New check


    Public Sub GridViewDataBind()

        Dim strsubmit As String = Me.hidsubmit.Value


        Dim strarray As String() = Regex.Split(strsubmit, "sdfgyuio", RegexOptions.IgnoreCase)

        Dim dt As New Data.DataTable
        'dt.Columns.Add("id")
        'dt.Columns.Add("TempID")
        dt.Columns.Add("DestPort")
        dt.Columns.Add("price20gp")
        dt.Columns.Add("price40gp")
        dt.Columns.Add("price40hq")
        dt.Columns.Add("price45hq")
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
                row("price20gp") = ""
                row("price40gp") = ""
                row("price40hq") = ""
                row("price45hq") = ""
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
                row("price20gp") = strrow(1)
                row("price40gp") = strrow(2)
                row("price40hq") = strrow(3)
                row("price45hq") = strrow(4)
                row("price20gpAppend") = strrow(5)
                row("Distance") = strrow(6)
                row("DepartureWkd") = strrow(7)
                row("shipcompany") = strrow(8)
                row("memo") = strrow(9)
                row("assurance") = strrow(10)


                dt.Rows.Add(row)
            Next
        End If

        GridView2.DataSource = dt
        GridView2.DataBind()









    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chken.Attributes.Add("onclick", "endisplay()")
        If chken.Checked Then
            entitle.Style.Value = ""
            enmeno.Style.Value = ""
        Else
            entitle.Style.Value = "display:none"
            enmeno.Style.Value = "display:none"
        End If

        Try
            Page.Title = "环球运费网 - 我的办公室 - 整箱运价"

            If Me.Request.Cookies("user_id") Is Nothing Then
                Response.Redirect("reg.aspx")
            Else

                If Request.Cookies("user_id").Value.ToString = "" Then
                    Response.Redirect("reg.aspx")
                End If

            End If
            If Not Page.IsPostBack Then
                Dim ds2 As Data.DataSet
                Dim conn As New data_conn3
                Dim sql As String
                sql = "select * from TB_User where UserID=" + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
                ds2 = conn.mdb_ds(sql, "table")

                If CInt(ds2.Tables("table").Rows(0)("ifEn").ToString()) = 0 Then
                    chken.Visible = False
                    Label1.Visible = False
                End If



                If CInt(ds2.Tables("table").Rows(0)("User_Level").ToString()) = 0 Then
                    Me.Response.Redirect("useredit2.aspx")
                End If

                Dim dtime As DateTime = DateTime.Now
                Dim startMonth As DateTime = dtime.AddDays(1 - dtime.Day)
                Dim endMonth As DateTime = startMonth.AddMonths(1).AddDays(-1)

                If DateTime.Now.Day >= 15 Then
                    BasicDatePicker1_TextBox.Value = endMonth.ToString().Split(" ")(0)
                Else
                    BasicDatePicker1_TextBox.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + "15"
                End If


                '判断是否为manager用户
                If ds2.Tables("table").Rows(0)("ifmanage") = "1" Then
                    'tt.InnerHtml = "<input type=""button"" name=""Submit"" value=""选择用户"" onClick=""javascript:window.open('Register.aspx','_blank','scrollbars=yes,width=420,height=600')"" id=""Button2"" / >"
                    ' Me.Hidden1.Visible = True
                End If

                If ds2.Tables("table").Rows(0)("star_allin") = 0 Then
                    LitRow1.Text = "<input id='Button5' type='button' value='添加1行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),1,1)"" />"
                    LitRow5.Text = "<input id='Button2' type='button' value='添加5行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),5,1)"" />"
                    LitRow10.Text = "<input id='Button3' type='button' value='添加10行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),10,1)"" />"
                    'LitRow50.Text = "<input id='Button4' type='button' value='添加50行' language='javascript' onclick=""addRow(document.getElementById('GridView2'),50,1)"" />"

                    GridView2.Columns(10).ItemStyle.CssClass = "displayrow"
                    GridView2.Columns(10).HeaderStyle.CssClass = "displayrow"
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
        'If Session("Release") Is Nothing Then
        '    Response.Redirect("../search/err.aspx")
        'Else
        '    If Session("Release") = "" Then
        '        Response.Redirect("../search/err.aspx")
        '    Else


        'Try
        If chken.Checked And (WordsIScn(hidsubmit.Value) Or WordsIScn(TextBox2.Text) Or WordsIScn(TextBox3.Text) Or WordsIScn(txtStart.Text)) Then

            MessageBox("", "发布英文运价时，除了标题备注，不能出现中文")
            Return
        End If

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

        ElseIf txtStart.Text = "" Then
            MessageBox("", "启运港不能为空")

        ElseIf DropDownList1.Text = "请选择" Then
            MessageBox("", "请选择航线")

        Else
            'Try


            Dim text As String = txtRemark.Text
            text = text.Replace(Chr(10), "<br>")
            text = text.Replace(" ", "&nbsp")
            'Me.Response.Write(text)
            Dim paras(28) As Data.SqlClient.SqlParameter

            paras(0) = New Data.SqlClient.SqlParameter("@UserID", Data.SqlDbType.Int)
            paras(0).Value = check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
            paras(1) = New Data.SqlClient.SqlParameter("@title", Data.SqlDbType.NVarChar, 50)
            paras(1).Value = check.CheckInput(txtTitle.Text)
            paras(2) = New Data.SqlClient.SqlParameter("@PostDate", Data.SqlDbType.SmallDateTime)
            paras(2).Value = Date.Now
            paras(3) = New Data.SqlClient.SqlParameter("@enddate", Data.SqlDbType.SmallDateTime)
            paras(3).Value = check.CheckInput(BasicDatePicker1_TextBox.Value)
            paras(4) = New Data.SqlClient.SqlParameter("@yunjialeixing", Data.SqlDbType.Int)
            paras(4).Value = 8
            paras(5) = New Data.SqlClient.SqlParameter("@hangxianmiaoshu", Data.SqlDbType.NVarChar, 255)
            paras(5).Value = check.CheckInput(DropDownList1.Text)
            paras(6) = New Data.SqlClient.SqlParameter("@StartPort", Data.SqlDbType.NVarChar, 50)
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
            paras(25) = New Data.SqlClient.SqlParameter("@entitle", Data.SqlDbType.NVarChar, 200)
            If chken.Checked Then
                paras(25).Value = check.CheckInput(TextBox2.Text)
            Else
                paras(25).Value = ""
            End If
            paras(26) = New Data.SqlClient.SqlParameter("@enmemo", Data.SqlDbType.NText)
            If chken.Checked Then
                paras(26).Value = check.CheckInput(TextBox3.Text)
            Else
                paras(26).Value = ""
            End If
            paras(27) = New Data.SqlClient.SqlParameter("@ifen", Data.SqlDbType.Int)
            If chken.Checked Then
                paras(27).Value = 1
            Else
                paras(27).Value = 0
            End If






            paras(28) = New Data.SqlClient.SqlParameter("@id", Data.SqlDbType.Int)
            paras(28).Direction = Data.ParameterDirection.Output


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

            '生成航线排序优先的标识
            Dim stradv As String = fcl_adv(DropDownList1.Text)



            For i = 0 To strarray.Length - 2
                If strarray(i) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl0qwerhjkl" And strarray(i) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl1qwerhjkl" Then


                    strrow = Regex.Split(strarray(i), "qwerhjkl", RegexOptions.IgnoreCase)
                    value = check.CheckNumber(id.ToString) + ",'" + check.CheckInput(strrow(0)) + "','" + check.CheckInput(strrow(1)) + "','" + check.CheckInput(strrow(2)) + "','" + check.CheckInput(strrow(3)) + "','" + check.CheckInput(strrow(4)) + "','" + check.CheckInput(strrow(5)) + "','" + check.CheckInput(strrow(6)) + "','" + check.CheckInput(strrow(7)) + "','" + check.CheckInput(strrow(8)) + "','" + check.CheckInput(strrow(9)) + "'," + check.CheckInput(strrow(10)) + ",'" + check.CheckInput(txtTitle.Text) + "','" + check.CheckInput(txtStart.Text) + "','" + Date.Now + "','" + check.CheckInput(BasicDatePicker1_TextBox.Value) + "',8,'" + check.CheckInput(DropDownList1.Text) + "'," + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString + "," + stradv)

                    strSQL += "insert into TB_YunJiaInfo (YunJiaID,DestPort,price20gp,price40gp,price40hq,price45hq,price20gpAppend,Distance,DepartureWkd,shipcompany,memo,assurance,Titlex,StartPortx,PostDatex,enddatex,yunjialeixingx,hangxianmiaoshux,UserIDx,order_advx) values (" + value + ");"


                End If
                'Title, PostDate, enddate, yunjialeixing, hangxianmiaoshu

                '1	title	nvarchar	200	1
                '0	PostDate	smalldatetime	4	1
                '0	enddate	smalldatetime	4	1
                '0	yunjialeixing	int	4	1
                '0	hangxianmiaoshu	nvarchar	255	1

            Next

            strSQL += "update TB_YunJia set DestPort1='" + check.CheckInput(strrow(0)) + "',price20gp1='" + check.CheckInput(strrow(1)) + "',price40gp1='" + check.CheckInput(strrow(2)) + "',price40hq1='" + check.CheckInput(strrow(3)) + "',price45hq1='" + check.CheckInput(strrow(4)) + "',shipcompany1='" + check.CheckInput(strrow(8)) + "',assurance=" + check.CheckInput(strrow(10)) + ",order_adv=" + stradv + " where id=" + id.ToString + ";"
            strSQL += "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.fclcount = (SELECT COUNT(id) AS yunjiacount FROM tb_yunjiainfo WHERE yunjialeixingx = 8),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1;"


            Dim myCommand1 As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSQL, conn)
            myCommand1.ExecuteNonQuery()



            conn.Close()

            Dim tp As New topnew
            tp.SetTopNew(id, check.CheckInput(txtTitle.Text), Date.Now.ToString(), 8, check.CheckInput(DropDownList1.Text), check.CheckInput(txtStart.Text.Replace("'", "''")), check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString))

            'Response.Redirect("shippinglist.aspx")
            Server.Transfer("ReleaseSucceed.aspx?id=" + id.ToString() + "&type=1")

            'Catch ex As Exception
            '    Dim cn As New data_conn
            '    cn.mdb_exe("insert into TB_Error (type,UserID,errorMessage,errorTime) values (1," + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString) + ",'" + ex.ToString + "',getdate())")

            'End Try
        End If


        'Catch ex As Exception
        '    Me.Response.Redirect("error.aspx")
        'End Try



        '    End If
        'End If
    End Sub

    '判断是否是广告用户，生成航线排序优先的标识
    Public Function fcl_adv(ByVal line As String) As Integer
        Dim cn As New data_conn
        Dim ds As Data.DataSet = cn.mdb_ds("select * from TB_User where UserID=" + Request.Cookies("user_id").Value.ToString(), "user")
        Dim strArray() As String = ds.Tables("user").Rows(0)("fcl_adv").ToString().Split("|")
        For i As Integer = 0 To strArray.Length - 1
            If line = strArray(i) Then
                Return 1
            End If
        Next
        Return 0
    End Function

    Public Function WordsIScn(ByVal words As String) As Boolean
        If words = "" Then
            Return False
        End If
        Dim Tmmp As String
        For i As Integer = 0 To words.Length - 1
            Tmmp = words.Substring(i, 1)
            Dim sarr() As Byte = System.Text.Encoding.GetEncoding("gb2312").GetBytes(Tmmp)
            If sarr.Length = 2 Then
                Return True
            End If
        Next
    End Function
End Class
