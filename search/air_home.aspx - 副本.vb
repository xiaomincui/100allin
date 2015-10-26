
Partial Class search_air_home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            '定义所有输入框按回车跳到下一格
            txtLine.Attributes.Add("onkeydown", "KeyDown(event);")
            txtStartport.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")
            txtDestport.Attributes.Add("onkeydown", "if(event.keyCode==13){return false;}")
            LoadBase()
            hotPort()
        End If
    End Sub


    Public Sub hotPort()

        Dim sql As String = ""
        Dim ds As New Data.DataSet
        Dim cn As New data_conn

        sql = ""
        sql = sql + "select top 5 * from TB_HOT_PORT "
        sql = sql + "where htype = 10 "
        sql = sql + "order by htype,horder "


        ds = cn.mdb_ds(sql, "yunjia")
        rptHotPort.DataSource = ds.Tables("yunjia").DefaultView
        rptHotPort.DataBind()


    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("/air/list-" & txtStartport.Text & "-" & txtDestport.Text.ToLower & "--" & txtLine.SelectedIndex.ToString & "-0-0-----1.html")
    End Sub

    Sub LoadBase()
        Dim cn As New data_conn
        Dim ds As New Data.DataSet
        Dim sql As String
        sql = ""
        sql = sql + "SELECT top 32 id,startport,destport,title,hangxianmiaoshu,companyname,UserID,PRICE_P45,PRICE_P100,PRICE_P300,PRICE_P500,PRICE_P1000 "
        sql = sql + "FROM V_最新_空运运价 "
        ds = cn.mdb_ds(sql, "freight")
        'Response.Write(sql)
        Repeater1.DataSource = ds.Tables("freight").DefaultView
        Repeater1.DataBind()


        sql = ""
        sql = sql + "SELECT aircount FROM TB_PRICECOUNT "

        ds = cn.mdb_ds(sql, "freight")

        Literal1.Text = ds.Tables("freight").Rows(0)(0).ToString()

    End Sub

    Public Function key(ByVal es As String) As String
        Dim s As New SymmetricMethod
        Return s.Encrypto(es)
    End Function

    Public Function output(ByVal s As String) As String
        If s = "" Then
            s = "-"
        End If
        Return s
    End Function

    Public Shared Function GetFirstString(ByVal stringToSub As String, ByVal length As Integer) As String
        '\u4e00-\u9fa5 中文区
        '\uff00-\uffef 逗号区
        '\u3000-\u303f 句号区
        '\u2000-\u206f 引号区
        '\u25a0-\u25ff 几何图形区


        Dim regex As New Regex("[\u4e00-\u9fa5\uff00-\uffef\u3000-\u303f\u2000-\u206f\u25a0-\u25ff]+", RegexOptions.Compiled)
        Dim stringChar As Char() = stringToSub.ToCharArray()
        Dim sb As New StringBuilder()
        Dim nLength As Integer = 0
        Dim isCut As Boolean = False
        For i As Integer = 0 To stringChar.Length - 1
            If regex.IsMatch((stringChar(i)).ToString()) Then
                sb.Append(stringChar(i))
                nLength += 2
            Else
                sb.Append(stringChar(i))
                nLength = nLength + 1
            End If

            If nLength > length Then
                isCut = True
                Exit For
            End If
        Next

        If isCut = True Then
            Return sb.ToString() & ".."
        Else
            Return sb.ToString()
        End If

    End Function


    Protected Sub Repeater1_ItemCommand(ByVal sender As Object, ByVal e As EventArgs) Handles Repeater1.PreRender
        Dim ck As New check
        If Repeater1.Items.Count <> 0 Then
            Dim ds As Data.DataSet
            Dim conn As New data_conn
            Dim a As Literal
            Dim i As Integer
            a = Repeater1.Items(0).FindControl("Literal1")
            Dim ids As String = a.Text
            For i = 1 To Repeater1.Items.Count - 1
                a = Repeater1.Items(i).FindControl("Literal1")
                ids += "," + a.Text
            Next
            ds = conn.mdb_ds("select airID,DESTPORT,PRICE_M,PRICE_N,PRICE_P45,PRICE_P100,PRICE_P300,PRICE_P500,PRICE_P1000 from T_AIRPRICE where airID in (" + ck.CheckInput(ids) + ") order by DESTPORT", "table")

            Dim str As String = ""
            For i = 0 To Repeater1.Items.Count - 1
                Dim point As String = ""
                Dim j As Integer
                Dim count As Integer
                a = Repeater1.Items(i).FindControl("Literal1")
                If ds.Tables("table").Select("airID=" + a.Text).Length > 10 Then
                    count = 9
                    Dim realcount As Integer
                    realcount = ds.Tables("table").Select("airID=" + a.Text).Length - 9
                    point = "还有" + realcount.ToString + "条运价######"
                Else
                    count = ds.Tables("table").Select("airID=" + a.Text).Length - 1
                End If

                If count > 9 Then
                    count = 9
                End If
                '增加预览的上限是10个


                For j = 0 To count
                    Dim k As Integer
                    For k = 1 To 8
                        str += ds.Tables("table").Select("airID=" + a.Text)(j).Item(k).ToString()
                        If k <> 8 Then
                            str += "##"
                        End If
                    Next
                    If j <> ds.Tables("table").Select("airID=" + a.Text).Length - 1 Then
                        str += "$$"
                    End If
                Next
                str += point
                If i <> Repeater1.Items.Count - 1 Then
                    str += "**"
                End If
            Next
            Hidden3.Value = str

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            If Me.Request.Cookies("user_id") Is Nothing Then

                Hiddennn3.Value = ""
            Else

                If Request.Cookies("user_id").Value.ToString = "" Then
                    Hiddennn3.Value = ""
                Else
                    a = Repeater1.Items(0).FindControl("Literal2")
                    ids = a.Text
                    For i = 1 To Repeater1.Items.Count - 1
                        a = Repeater1.Items(i).FindControl("Literal2")
                        ids += "," + a.Text
                    Next
                    ds = conn.mdb_ds("select UserID,CompanyName,Realname,Phone,Fax,MovePhone,Usermsn,Userqq,UserEmail from TB_User where UserID in (" + ck.CheckInput(ids) + ")", "table")
                    'Hiddennn1.Value = "select * from TB_User where UserID in (" + ids + ")"
                    str = ""
                    For i = 0 To Repeater1.Items.Count - 1
                        Dim point As String = ""
                        Dim j As Integer
                        Dim count As Integer
                        a = Repeater1.Items(i).FindControl("Literal2")
                        If ds.Tables("table").Select("UserID=" + a.Text).Length = 1 Then


                            str += "公司名称" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("CompanyName").ToString()
                            str += "$$"
                            str += "联系人" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("Realname").ToString()
                            str += "$$"
                            str += "电话号码" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("Phone").ToString()
                            str += "$$"
                            str += "传真号码" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("Fax").ToString()
                            str += "$$"
                            str += "手机号码" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("MovePhone").ToString()
                            str += "$$"
                            str += "MSN" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("Usermsn").ToString()
                            str += "$$"
                            str += "QQ" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("Userqq").ToString()
                            str += "$$"
                            str += "电子邮箱" + "##" + ds.Tables("table").Select("UserID=" + a.Text)(0).Item("UserEmail").ToString()
                        Else
                        End If
                        If i <> Repeater1.Items.Count - 1 Then
                            str += "$|**|$"
                        End If
                    Next
                    Hiddennn3.Value = str
                End If
            End If


        End If
    End Sub
End Class
