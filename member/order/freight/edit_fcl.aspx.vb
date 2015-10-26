Imports System.Data

Partial Class pro_freight_edit_fcl
    Inherits System.Web.UI.Page
    Dim check As New check

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ltrHeadTitle.Text = "运价 / 整箱运价修改"


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
            Dim ds As Data.DataSet
            ds = trun(a)
            Try
                If ds.Tables(0).Rows(0)("UserID2").ToString <> Request.Cookies("user_id").Value.ToString And ds.Tables(0).Rows(0)("UserID").ToString <> Request.Cookies("user_id").Value.ToString Then
                    Response.Redirect("../search/err.aspx")
                End If
            Catch ex As Exception
                Response.Redirect("../search/err.aspx")
            End Try




            lblPostDate.Text = ds.Tables(0).Rows(0)("PostDate").ToString.Split(" ")(0)
            TextBox1.Text = ds.Tables(0).Rows(0)("title").ToString

            'txtenddate.Value = ds.Tables(0).Rows(0)("enddate").ToString.Split(" ")(0)

            Dim dt As DateTime = DateTime.Now
            Dim startMonth As DateTime = dt.AddDays(1 - dt.Day)
            Dim endMonth As DateTime = startMonth.AddMonths(1).AddDays(-1)



            Dim aaa As DateTime = DateTime.ParseExact(ds.Tables(0).Rows(0)("enddate").ToString().Split(" ")(0), "yyyy-M-d", Nothing)

            If aaa > DateTime.Now Then
                txtenddate.Value = ds.Tables(0).Rows(0)("enddate").ToString.Split(" ")(0)
            Else
                If DateTime.Now.Day >= 15 Then
                    txtenddate.Value = endMonth.ToString().Split(" ")(0)
                Else
                    txtenddate.Value = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + "15"
                End If
            End If





            If ds.Tables(0).Rows(0)("yunjialeixing") = 8 Then
                lblyunjialeixing.Text = "整箱运价"
            ElseIf ds.Tables(0).Rows(0)("yunjialeixing") = 9 Then
                lblyunjialeixing.Text = "拼箱运价"
            End If
            txtStartPost.Text = ds.Tables(0).Rows(0)("StartPort").ToString
            ddlhangxianmiaoshu.SelectedItem.Text = ds.Tables(0).Rows(0)("hangxianmiaoshu").ToString

            Dim memo As String = ds.Tables(0).Rows(0)("memo").ToString
            memo = memo.Replace("<br>", Chr(10))
            memo = memo.Replace("&nbsp", " ")
            txtmemo.Text = memo
            Me.Hidden1.Value = "0"
            'Me.Response.Write(ds.Tables(0).Rows(0)("UserID2").ToString)



            GridView1.Attributes.Add("bordercolor ", "#DBEEF5")

            Dim ds2 As DataSet
            Dim conn As New pro_data_conn3
            Dim sql As String





            If ds.Tables(0).Rows(0)("UserID2").ToString = "0" Then
                sql = "select * from TB_User where UserID=" + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
            Else
                sql = "select * from TB_User where UserID=" + check.CheckNumber(ds.Tables(0).Rows(0)("UserID2").ToString)
                '判断是否为manager用户

            End If

            ds2 = conn.mdb_ds(sql, "table")
            txtname.Text = ds2.Tables("table").Rows(0)("RealName")
            txtCompanyName.Text = ds2.Tables("table").Rows(0)("CompanyName")
            txtAddress.Text = ds2.Tables("table").Rows(0)("Address")
            txtFax.Text = ds2.Tables("table").Rows(0)("Fax").ToString
            txtMovePhone.Text = ds2.Tables("table").Rows(0)("MovePhone")
            txtPhone.Text = ds2.Tables("table").Rows(0)("Phone")
            txtPostNumber.Text = ds2.Tables("table").Rows(0)("PostNumber").ToString
            txtUserEmail.Text = ds2.Tables("table").Rows(0)("UserEmail")


            '判断是否为manager用户，是的话，显示选择用户按钮
            Dim ds3 As DataSet
            sql = "select * from TB_User where UserID=" + check.CheckNumber(Me.Request.Cookies("user_id").Value.ToString)
            ds3 = conn.mdb_ds(sql, "table")

            If ds3.Tables("table").Rows(0)("ifmanage") = 1 Then
                tt.InnerHtml = "<input type=""button"" name=""Submit"" value=""选择用户"" onClick=""javascript:window.open('user_search1.asp','_blank','scrollbars=yes,width=420,height=600')"" id=""Button2"" / >"
                Me.Hidden1.Visible = True
            End If



            Dim dsyunjia As DataSet = conn.mdb_ds("select * from TB_YunJiaInfo where YunJiaID=" + a, "yunjia")
            Dim row As Data.DataRow = dsyunjia.Tables("yunjia").NewRow

            row("DestPort") = ""
            row("price20gp") = ""
            row("price40gp") = ""
            row("price40hq") = ""
            row("price20gpAppend") = ""
            row("Distance") = ""
            row("DepartureWkd") = ""
            row("shipcompany") = ""
            row("memo") = ""

            dsyunjia.Tables("yunjia").Rows.Add(row)
            GridView1.DataSource = dsyunjia.Tables("yunjia")
            GridView1.DataBind()

        End If





    End Sub


    Function trun(ByVal id As String) As Data.DataSet
        Dim ds As Data.DataSet
        Dim strSQL As String
        strSQL = "select * from TB_YunJia where id=" + id
        Dim tt As New pro_data_conn3
        ds = tt.mdb_ds(strSQL, "asdf")
        Return ds
    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Try
        If hidsubmit.Value = "" Then
            MessageBox("", "目的港不能为0个")
            Return
        End If

        If hidsubmit.Value.Replace("qwerhjkl", "").Replace("sdfgyuio", "") = "" Then
            MessageBox("", "目的港不能为0个")
            Return
        End If

        Dim strsubmitrow As String() = Regex.Split(hidsubmit.Value, "sdfgyuio", RegexOptions.IgnoreCase)

        Dim k As Integer

        For k = 0 To strsubmitrow.Length - 2
            If strsubmitrow(k).Substring(0, 1) = "qwerhjkl" And strsubmitrow(k) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl" Then
                MessageBox("", "第" + (k + 1).ToString + "行的目的港不能为空")
                Return
            End If
        Next




        If TextBox1.Text = "" Then
            MessageBox("", "标题不能为空")
        ElseIf txtenddate.Value = "" Then
            MessageBox("", "有效日期不能为空")
        ElseIf ddlhangxianmiaoshu.Text = "请选择" Then
            MessageBox("", "请选择航线")
        ElseIf txtStartPost.Text = "" Then
            MessageBox("", "起运港不能为空")

        Else
            Dim strSql As String
            Dim meno As String = check.CheckInput(txtmemo.Text)
            meno = meno.Replace(Chr(10), "<br>")
            meno = meno.Replace(" ", "&nbsp")

            Dim data_conn As New pro_data_conn3
            Dim conn As New Data.SqlClient.SqlConnection
            conn = data_conn.mdb_conn()
            conn.Open()
            strSql = "update TB_YunJia set title='" + check.CheckInput(TextBox1.Text.Replace("'", "''")) + "',enddate='" + check.CheckInput(txtenddate.Value.Replace("'", "''")) + "',StartPort='" + check.CheckInput(txtStartPost.Text.Replace("'", "''")) + "',hangxianmiaoshu='" + check.CheckInput(ddlhangxianmiaoshu.Text.Replace("'", "''")) + "',memo='" + check.CheckInput(meno.Replace("'", "''")) + "',PostDate='" + Date.Now.ToString.Replace("'", "''") + "',UserID2=" + Me.Hidden1.Value + ",updateTimes=updateTimes+1 where id=" + check.CheckNumber(Request("id"))
            Dim myCommand As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSql, conn)

            Response.Write(strSql)
            myCommand.ExecuteNonQuery()
            lblPostDate.Text = Date.Now.ToString


            myCommand.CommandText = "delete from TB_YunJiaInfo where YunJiaID=" + check.CheckNumber(Request("id"))

            myCommand.ExecuteNonQuery()

            Dim strsubmit As String = Me.hidsubmit.Value

            Dim strarray As String() = Regex.Split(strsubmit, "sdfgyuio", RegexOptions.IgnoreCase)
            Dim i As Integer

            strSql = ""
            Dim value As String
            Dim strrow As String()
            For i = 0 To strarray.Length - 2
                If strarray(i) <> "qwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjklqwerhjkl" Then


                    strrow = Regex.Split(strarray(i), "qwerhjkl", RegexOptions.IgnoreCase)
                    value = check.CheckNumber(Request("id")) + ",'" + check.CheckInput(strrow(0)) + "','" + check.CheckInput(strrow(1)) + "','" + check.CheckInput(strrow(2)) + "','" + check.CheckInput(strrow(3)) + "','" + check.CheckInput(strrow(4)) + "','" + check.CheckInput(strrow(5)) + "','" + check.CheckInput(strrow(6)) + "','" + check.CheckInput(strrow(7)) + "','" + check.CheckInput(strrow(8)) + "'"

                    strSql += "insert into TB_YunJiaInfo (YunJiaID,DestPort,price20gp,price40gp,price40hq,price20gpAppend,Distance,DepartureWkd,shipcompany,memo) values (" + value + ");"


                End If


            Next


            strSql += "update TB_YunJia set DestPort1='" + check.CheckInput(strrow(0)) + "',price20gp1='" + check.CheckInput(strrow(1)) + "',price40gp1='" + check.CheckInput(strrow(2)) + "',price40hq1='" + check.CheckInput(strrow(3)) + "',shipcompany1='" + check.CheckInput(strrow(7)) + "' where id=" + Request("id").ToString + ";"
            strSql += "UPDATE TB_PRICECOUNT SET TB_PRICECOUNT.fclcount = (SELECT COUNT(tb_yunjia.id) AS yunjiacount FROM tb_yunjia,tb_yunjiainfo WHERE (tb_yunjia.yunjialeixing = 8) AND tb_yunjia.id = tb_yunjiainfo.yunjiaid),TB_PRICECOUNT.countdate = getdate() where TB_PRICECOUNT.cid = 1;"

            Dim myCommand1 As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSql, conn)
            myCommand1.ExecuteNonQuery()
            conn.Close()




            Me.Response.Redirect("manage_fcl.aspx")
        End If
        'Catch ex As Exception
        '    Me.Response.Redirect("error.aspx")
        'End Try



    End Sub





    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)

        If args.Value = "" Then
            args.IsValid = False
            MessageBox("", "目的港不能为空")
        End If



    End Sub

    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub



    Protected Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView1.RowUpdated
        updatePostDate()
    End Sub

    Sub updatePostDate()
        Dim strSql As String

        Dim data_conn As New pro_data_conn3
        Dim conn As New Data.SqlClient.SqlConnection
        conn = data_conn.mdb_conn()
        conn.Open()
        strSql = "update TB_YunJia set PostDate='" + Date.Now.ToString + "' where id=" + check.CheckNumber(Request("id"))
        Dim myCommand As Data.SqlClient.SqlCommand = New Data.SqlClient.SqlCommand(strSql, conn)
        myCommand.ExecuteNonQuery()
        conn.Close()
        lblPostDate.Text = Date.Now.ToString
    End Sub
End Class
