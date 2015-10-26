Imports System.Data

Partial Class search_dicker
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim ck As New check


            Dim s As String
            s = ck.CheckInput(Request.QueryString("yid").ToString)

            If ck.CheckNumber(s.Split(",")(0)) = 0 Then
                Response.Redirect("err.aspx")
            End If

            Dim sql As String = ""



            If Request.QueryString("type").ToString = "air" Then
                sql = sql & "SELECT DISTINCT * "
                sql = sql & "FROM (SELECT TB_User.RealName, TB_User.UserID, TB_User.CompanyName "
                sql = sql & "FROM T_AIRINFO INNER JOIN "
                sql = sql & "TB_User ON T_AIRINFO.UserID = TB_User.UserID "
                sql = sql & "WHERE (T_AIRINFO.id IN ( " & s
                sql = sql & ")) AND "
                sql = sql & "(T_AIRINFO.UserID2 = 0) OR "
                sql = sql & "(T_AIRINFO.id IN ( " & s
                sql = sql & ")) AND "
                sql = sql & "(T_AIRINFO.UserID2 IS NULL) "
                sql = sql & "UNION ALL "
                sql = sql & "SELECT TB_User.RealName, TB_User.UserID, TB_User.CompanyName "
                sql = sql & "FROM T_AIRINFO INNER JOIN "
                sql = sql & "TB_User ON T_AIRINFO.UserID2 = TB_User.UserID "
                sql = sql & "WHERE (T_AIRINFO.id IN ( " & s
                sql = sql & ")) AND "
                sql = sql & "((T_AIRINFO.UserID2 <> 0) AND (T_AIRINFO.UserID2 IS NOT NULL))) "
                sql = sql & "DERIVEDTBL "
            Else
                sql = sql & "SELECT DISTINCT * "
                sql = sql & "FROM (SELECT TB_User.RealName, TB_User.UserID, TB_User.CompanyName "
                sql = sql & "FROM TB_YunJia INNER JOIN "
                sql = sql & "TB_User ON TB_YunJia.UserID = TB_User.UserID "
                sql = sql & "WHERE (TB_YunJia.id IN ( " & s
                sql = sql & ")) AND "
                sql = sql & "(TB_YunJia.UserID2 = 0) OR "
                sql = sql & "(TB_YunJia.id IN ( " & s
                sql = sql & ")) AND "
                sql = sql & "(TB_YunJia.UserID2 IS NULL) "
                sql = sql & "UNION ALL "
                sql = sql & "SELECT TB_User.RealName, TB_User.UserID, TB_User.CompanyName "
                sql = sql & "FROM TB_YunJia INNER JOIN "
                sql = sql & "TB_User ON TB_YunJia.UserID2 = TB_User.UserID "
                sql = sql & "WHERE (TB_YunJia.id IN ( " & s
                sql = sql & ")) AND "
                sql = sql & "((TB_YunJia.UserID2 <> 0) AND (TB_YunJia.UserID2 IS NOT NULL))) "
                sql = sql & "DERIVEDTBL "
            End If



            Dim ds As New DataSet
            Dim cn As New data_conn
            ds = cn.mdb_ds(sql, "dicker")

            Repeater1.DataSource = ds.Tables("dicker").DefaultView
            Repeater1.DataBind()

            For i As Integer = 0 To ds.Tables("dicker").Rows.Count - 1
                If TextBox10.Text = "" Then
                    TextBox10.Text = ds.Tables("dicker").Rows(i)("userid").ToString
                Else
                    TextBox10.Text = TextBox10.Text + "," + ds.Tables("dicker").Rows(i)("userid").ToString
                End If

                If TextBox13.Text = "" Then
                    TextBox13.Text = ds.Tables("dicker").Rows(i)("realname").ToString
                Else
                    TextBox13.Text = TextBox13.Text + "," + ds.Tables("dicker").Rows(i)("realname").ToString
                End If
            Next



            If ds.Tables("dicker").Rows.Count = 1 Then
                If Request.QueryString("type").ToString = "air" Then
                    sql = "select title from T_AIRINFO where id = " & s.Split(",")(0)
                Else
                    sql = "select title from TB_YunJia where id = " & s.Split(",")(0)
                End If

                ds = cn.mdb_ds(sql, "dicker2")
                Label1.Text = ds.Tables("dicker2").Rows(0)(0).ToString
            Else
                Panel1.Visible = False
            End If

        End If

        If Not Request.Cookies("user_id") Is Nothing Then
            If Request.Cookies("user_id").Value.ToString <> "" Then
                Panel2.Visible = True
                Panel3.Visible = False
            Else
                Panel3.Visible = True
                Panel2.Visible = False
            End If
        Else
            Panel3.Visible = True
            Panel2.Visible = False
        End If



    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Trim(TEXTAREA1.Value) <> "" Then
            If Not Request.Cookies("user_id") Is Nothing Then
                If Request.Cookies("user_id").Value.ToString <> "" Then
                    regdick()
                Else
                    unregdick()
                End If
            Else
                unregdick()
            End If
        Else
            MessageBox("opfail", "请输入您的货物情况")
        End If
        
    End Sub

    'alert弹窗
    Sub MessageBox(ByVal strKey As String, ByVal strInfo As String)
        If (Not ClientScript.IsClientScriptBlockRegistered(strKey)) Then
            Dim strjs As String = "alert('" + strInfo + "');"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), strKey, strjs, True)
        End If
    End Sub

    Sub regdick()

        Dim cn As New data_conn
        Dim ds As New DataSet
        Dim sql As String = ""
        sql = "select * from tb_user where userid = " & Request.Cookies("user_id").Value.ToString

        ds = cn.mdb_ds(sql, "user")
        TextBox1.Text = ds.Tables("user").Rows(0)("username").ToString
        TextBox2.Text = ds.Tables("user").Rows(0)("realname").ToString
        TextBox3.Text = ds.Tables("user").Rows(0)("companyname").ToString
        TextBox4.Text = ds.Tables("user").Rows(0)("Phone").ToString
        TextBox5.Text = ds.Tables("user").Rows(0)("MovePhone").ToString
        TextBox6.Text = ds.Tables("user").Rows(0)("UserEmail").ToString
        TextBox7.Text = ds.Tables("user").Rows(0)("Usermsn").ToString
        TextBox8.Text = ds.Tables("user").Rows(0)("Userqq").ToString

        If CheckBox2.Checked = True And TextBox4.Text <> "" Then
            TextBox9.Text = "我的电话：" & TextBox4.Text & "<br/>"
        End If

        If CheckBox3.Checked = True And TextBox5.Text <> "" Then
            TextBox9.Text = TextBox9.Text & "我的手机：" & TextBox5.Text & "<br/>"
        End If

        If CheckBox4.Checked = True And TextBox5.Text <> "" Then
            TextBox9.Text = TextBox9.Text & "我的邮件：" & TextBox6.Text & "<br/>"
            TextBox9.Text = TextBox9.Text & "我的MSN：" & TextBox7.Text & "<br/>"
            TextBox9.Text = TextBox9.Text & "我的QQ：" & TextBox8.Text & "<br/>"
        End If


        Dim type As String = ""
        If Request.QueryString("type").ToString = "fcl" Then
            type = "整箱"
        Else
            If Request.QueryString("type").ToString = "lcl" Then
                type = "拼箱"
            Else
                type = "空运"
            End If
        End If

        Dim us() As String
        us = TextBox10.Text.Split(",")

        Dim un() As String
        un = TextBox13.Text.Split(",")


        Dim d As New dicker
        Dim p As New pm

        For i As Integer = 0 To us.Length - 1
            d.sendpm(Request.Cookies("user_id").Value.ToString, us(i).ToString, TextBox9.Text, TEXTAREA1.Value, TEXTAREA3.Value, Username2.Value, type, un(i).ToString, TextBox3.Text, TextBox2.Text, TextBox1.Text)
            p.sendpm("41", us(i).ToString, "您有一条新的讨价还价，请<a href=''/member/getdicker.aspx?filter=new''>点击此处查看</a>", "1")
        Next

        Response.Redirect("/search/dickersuccess.aspx")
    End Sub

    Sub unregdick()

        Dim type As String = ""
        If Request.QueryString("type").ToString = "fcl" Then
            type = "整箱"
        Else
            If Request.QueryString("type").ToString = "lcl" Then
                type = "拼箱"
            Else
                type = "空运"
            End If
        End If
        Dim us() As String
        us = TextBox10.Text.Split(",")
        Dim un() As String
        un = TextBox13.Text.Split(",")

        Dim d As New dicker
        Dim p As New pm

        If Trim(TEXTAREA4.Value) = "" Then
            MessageBox("opfail", "请输入您的联系方式")
        Else
            For i As Integer = 0 To us.Length - 1
                d.sendpm("0", us(i).ToString, TextBox9.Text, TEXTAREA1.Value, TEXTAREA4.Value, Username2.Value, type, un(i).ToString, TextBox12.Text, TextBox11.Text, "")
                p.sendpm("41", us(i).ToString, "您有一条新的讨价还价，请<a href=''/member/getdicker.aspx?filter=new''>点击此处查看</a>", "1")
            Next
            Response.Redirect("/search/dickersuccess.aspx")
        End If

        If Trim(TextBox11.Text) = "" Then
            MessageBox("opfail", "请输入您的姓名")
        Else
            For i As Integer = 0 To us.Length - 1
                d.sendpm("0", us(i).ToString, TextBox9.Text, TEXTAREA1.Value, TEXTAREA4.Value, Username2.Value, type, un(i).ToString, TextBox12.Text, TextBox11.Text, "")
                p.sendpm("41", us(i).ToString, "您有一条新的讨价还价，请<a href=''/member/getdicker.aspx?filter=new''>点击此处查看</a>", "1")
            Next
            Response.Redirect("/search/dickersuccess.aspx")
        End If

    End Sub
End Class
